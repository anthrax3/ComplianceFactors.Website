using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplianceFactors.MyTeam;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Manager
{
    public partial class mmtp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + " >&nbsp;" + "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_team_text") + "</a>";
            if (!IsPostBack)
            {
                BindMyTeam();
            }
        }
        private void BindMyTeam()
        {
            MyTeamDataAccess da = new MyTeamDataAccess();
            //get the data
            MyTeam_Dataset ds = da.GetData(SessionWrapper.u_userid);
            Cache["data"] = ds;
            this.BindData(ds);
        }

        private void BindData(MyTeam_Dataset dataSet)
        {
            List<MyTeam_Dataset.e_sp_get_team_dataRow> dataSourceRows = new List<MyTeam_Dataset.e_sp_get_team_dataRow>();

            //gets a collection of top-level rows
            IEnumerable<MyTeam_Dataset.e_sp_get_team_dataRow> topLevelRows = from MyTeam_Dataset.e_sp_get_team_dataRow teamRow
                                                                 in dataSet.e_sp_get_team_data.Rows
                                                                             where teamRow.LevelPos <= 0
                                                                             select teamRow;


            List<MyTeam_Dataset.e_sp_get_team_dataRow> rowsToBind = new List<MyTeam_Dataset.e_sp_get_team_dataRow>();

            //recursively builds a collection consisting of all the top level rows
            //and any children where isExpanded = true in the data row
            this.BuildDataSetRecursive(topLevelRows, ref rowsToBind, 0);

            //binds the locations listview
            this.lvMyteam.DataSource = rowsToBind;
            this.lvMyteam.DataBind();
        }



        private void BuildDataSetRecursive(IEnumerable<MyTeam_Dataset.e_sp_get_team_dataRow> inputRows, ref List<MyTeam_Dataset.e_sp_get_team_dataRow> outputRows, int indentationLevel)
        {
            foreach (MyTeam_Dataset.e_sp_get_team_dataRow inputRow in inputRows)
            {
                //inputRow.indentationLevel = indentationLevel;

                //add the current row to the output collection
                outputRows.Add(inputRow);

                //if the row expanded state is set to true, add any children to the output collection.
                if (inputRow.isExpanded) // need to change
                {
                    //using the data relation on the typed dataset to find the children of the current row.
                    DataRow[] childRows = inputRow.GetChildRows("FK_e_sp_get_team_data");

                    if (childRows.Length > 0)
                    {
                        List<MyTeam_Dataset.e_sp_get_team_dataRow> locationChildRows = new List<MyTeam_Dataset.e_sp_get_team_dataRow>(
                            childRows.Cast<MyTeam_Dataset.e_sp_get_team_dataRow>());
                        this.BuildDataSetRecursive(locationChildRows, ref outputRows, indentationLevel + 1);
                    }
                }
            }
        }
        protected void expandCollapse(string userId, int levelPos)
        {
            MyTeam_Dataset ds = (MyTeam_Dataset)Cache["data"];
            MyTeam_Dataset.e_sp_get_team_dataRow locationRow = (ds.e_sp_get_team_data.Select("LevelPos =" + levelPos + " AND userId ='" + userId + "'")[0] as MyTeam_Dataset.e_sp_get_team_dataRow);

            ////set the isExpanded state for the row
            this.SetExpandState(locationRow, !locationRow.isExpanded);//to pass the is expanded

            //persist the changes
            ds.AcceptChanges();

            //update the label text
            //lbt.Text = (locationRow.isExpanded) ? "-" : "+";

            //rebind the listview
            this.BindData(ds);
        }

        private void SetExpandState(MyTeam_Dataset.e_sp_get_team_dataRow row, bool state)
        {
            //update isExpanded
            row.isExpanded = state;
            if (!state)
            {
                DataRow[] childRows = row.GetChildRows("FK_e_sp_get_team_data");
                foreach (DataRow childRow in childRows)
                {
                    this.SetExpandState((MyTeam_Dataset.e_sp_get_team_dataRow)childRow, state);
                }
            }
        }
        protected void lvMyteam_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item is ListViewDataItem)
            {
                this.InitialiseOfficeRow((ListViewDataItem)e.Item);
            }
        }
        private void SetPlusSymbol(string userId, LinkButton btn)
        {
            DataSet ds = new DataSet();
            ds = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
            DataRow[] drTeam = ds.Tables[1].Select("ManagerId ='" + userId + "'");

            if (drTeam.Length > 0)
            {
                btn.Text = " [+]";
            }
            else
            {
                btn.Visible = false;
            }
        }
        private void InitialiseOfficeRow(ListViewDataItem item)
        {
            MyTeam_Dataset.e_sp_get_team_dataRow row = (MyTeam_Dataset.e_sp_get_team_dataRow)item.DataItem;

            LinkButton lbt = (LinkButton)item.FindControl("lnkExpandCollapse");
            lbt.CommandArgument = DataBinder.Eval(item.DataItem, "userId").ToString() + "," + DataBinder.Eval(item.DataItem, "LevelPos").ToString();



            string id = DataBinder.Eval(item.DataItem, "userId").ToString();
            SetPlusSymbol(id, lbt);

            if (row.isExpanded)
            {
                lbt.Text = " [-]";
            }

            if (row.LevelPos > 0)
            {
                Literal lit = (Literal)item.FindControl("litIndent");
                lit.Text = string.Concat(System.Collections.ArrayList.Repeat("&nbsp;&nbsp;", row.LevelPos).ToArray());
            }

            //set the location name text
            Label lbl = (Label)item.FindControl("lblFirstName");
            lbl.Text = DataBinder.Eval(item.DataItem, "FirstName").ToString();

        }

        protected void lvMyteam_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "ExpandCollapse"))
            {
                string positionandId = e.CommandArgument.ToString();
                string[] seperate = positionandId.Split(',');

                string userId = seperate[0].ToString();
                int levelPos = Convert.ToInt16(seperate[1]);

                expandCollapse(userId, levelPos);

            }

        }
    }
}