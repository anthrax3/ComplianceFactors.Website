using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs
{
    public partial class sambjmp_01 : System.Web.UI.Page
    {
        #region "Local variables"
        private string time;
        private string Hour;
        private string Minutes;
        private int total;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_manage_background_jobs_text") + "</a>";

                //Clear SessionWrapper
                SessionWrapper.BackgroundJobs.Clear();
                //Binding data
                gvBackgroundJobs.DataSource = SystemBackgroundJobsBLL.GetBackgroundJobs();
                gvBackgroundJobs.DataBind();
                SessionWrapper.BackgroundJobs = SystemBackgroundJobsBLL.GetBackgroundJobs();
            }
        }

        protected void gvBackgroundJobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string u_sftp_id_pk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                try
                {
                    DataRowView drheader = (DataRowView)e.Row.DataItem;
                    string time = Convert.ToString(drheader["u_sftp_time_every"]);

                    int length = time.Length;
                    DropDownList ddlTime = (DropDownList)e.Row.FindControl("ddlTime");
                    ddlTime.SelectedValue = time.Substring(length - 2, 2);


                    TextBox txtTime = (TextBox)e.Row.FindControl("txtTime");
                    txtTime.Text = time.Substring(0, length - 2);


                    if (u_sftp_id_pk.Contains("DCUB"))
                    {
                        Label lblOccursEvery = (Label)e.Row.FindControl("lblOccursEvery");
                        lblOccursEvery.Style.Add("display", "none");

                        Label lblEveryDays = (Label)e.Row.FindControl("lblEveryDays");
                        lblEveryDays.Style.Add("display", "none");                         

                        TextBox txtOccursEvery = (TextBox)e.Row.FindControl("txtOccursEvery");
                        txtOccursEvery.Style.Add("display", "none");                                   
                    }
                    else
                    {
                        Label lblOccursCommon = (Label)e.Row.FindControl("lblOccursCommon");
                        lblOccursCommon.Style.Add("display", "none");       

                        Literal ltlButton = (Literal)e.Row.FindControl("ltlButton");
                        ltlButton.Text = "<input id=" + u_sftp_id_pk + " class='manage cursor_hand' type='button' value='Manage'/>";
                    }
                    

                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sambjmp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sambjmp-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Remove Column
            SessionWrapper.BackgroundJobs.Columns.Remove("BackgroundJobName");
            SessionWrapper.BackgroundJobs.Columns.Remove("u_sftp_start_date");
            SessionWrapper.BackgroundJobs.AcceptChanges();

            foreach (GridViewRow row in gvBackgroundJobs.Rows)
            {
                TextBox txtOccursEvery = (TextBox)row.FindControl("txtOccursEvery");
                TextBox txtTime = (TextBox)row.FindControl("txtTime");
                DropDownList ddlTime = (DropDownList)row.FindControl("ddlTime");
                string u_sftp_id_pk = gvBackgroundJobs.DataKeys[row.RowIndex].Value.ToString();
                var rows = SessionWrapper.BackgroundJobs.Select("u_sftp_id_pk='" + u_sftp_id_pk + "'");
                var indexOfRow = SessionWrapper.BackgroundJobs.Rows.IndexOf(rows[0]);
                SessionWrapper.BackgroundJobs.Rows[indexOfRow]["u_sftp_occurs_every"] = txtOccursEvery.Text;

                time = txtTime.Text;
                Hour = time.Split(":".ToCharArray())[0];
                Minutes = time.Split(":".ToCharArray())[1];
                if (ddlTime.SelectedValue == "PM" && Convert.ToInt32(Hour) <= 12)
                {
                    //Get hour without AM/PM
                    total = 12 + Convert.ToInt32(Hour);
                }
                else
                {   //Get hour without AM/PM
                    total = Convert.ToInt32(Hour);
                }
                SessionWrapper.BackgroundJobs.Rows[indexOfRow]["u_sftp_time_every"] = total + ":" + Minutes+":00.0000000";//Hard Code because sql not support 23:00
                SessionWrapper.BackgroundJobs.AcceptChanges();
            }
            //Update Background Jobs
            ConvertDataTables ConvertXML = new ConvertDataTables();
            SystemBackgroundJobsBLL.UpdateBackgroundJobs(ConvertXML.ConvertDataTableToXml(SessionWrapper.BackgroundJobs));
        }
    }
}