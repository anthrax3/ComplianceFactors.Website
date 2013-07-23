using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Instructor
{
    public partial class samir_01 : BasePage
    {


        public void Page_Load(object sender, EventArgs e)
        {

            //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_instructors_text");
            string navigationText;
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
            hdNav_selected.Value = "#" + SessionWrapper.navigationText;
            lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_instructors_text") + "</a>";

            if (!IsPostBack)
            {
                ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName, "samir-01");
                ddlUserstatus.DataBind();
                ddlUserstatus.SelectedValue = "app_ddl_all_text";

                //ListItem lstStatus = new ListItem();
                //lstStatus.Text = "All";
                //lstStatus.Value = "0";

                //ddlUserstatus.Items.Insert(0, lstStatus);
                //ddlUserstatus.SelectedIndex = 0;


                try
                {
                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "samir-01");
                    ddlUserTypes.DataBind();
                    ddlUserdomain.DataSource = UserBLL.GetUserDomains();
                    ddlUserdomain.DataBind();

                    //ListItem lstUserType = new ListItem();
                    //lstUserType.Text = "All Types";
                    //lstUserType.Value = "0";

                    //ddlUserTypes.Items.Insert(0, lstUserType);
                    //ddlUserTypes.SelectedIndex = 0;
                    ListItem lstUserDomain = new ListItem();
                    lstUserDomain.Text = "All";
                    lstUserDomain.Value = "0";

                    ddlUserdomain.Items.Insert(0, lstUserDomain);
                    ddlUserdomain.SelectedIndex = 0;

                    SearchResult();
                    //displayrecord();

                    lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                }
                catch (Exception ex)
                {

                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samir-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samir-01", ex.Message);
                        }
                    }

                }
            }


        }
        //top FirstButton
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Top Last Button
        protected void btnLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Top Next Button
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Top Previous Button
        protected void btnPrevious_Click(object sender, EventArgs e)
        {

            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        //Top Result Per Page DropdownList
        protected void ddresultperpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddresultperpage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddresultperpage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            SearchResult();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            dddownresultperpage.SelectedValue = ddresultperpage.SelectedValue;
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();


        }
        //Top Goto Button
        protected void btnGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtPage.Text) - 1;
            SearchResult();
            txtdownpage.Text = txtPage.Text;
        }
        //Down First Button
        protected void btndownFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Down Previous Button
        protected void btndownPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Down Next Button
        protected void btndownNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //Down Last Button
        protected void btndownLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        //down Result Per Page DropDownList
        protected void dddownresultperpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dddownresultperpage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(dddownresultperpage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddresultperpage.SelectedValue = dddownresultperpage.SelectedValue;
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        //Down Goto Button
        protected void btndownGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtdownpage.Text) - 1;
            SearchResult();
            txtPage.Text = txtdownpage.Text;
        }
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;
            SearchResult();
        }
        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string username = gvsearchDetails.DataKeys[e.Row.RowIndex]["u_username_enc"].ToString();

                //Label lblUsername = (Label)e.Row.FindControl("lblUsername");
                /// <summary>
                /// decrypt hash  username
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                e.Row.Cells[3].Text = encHash.Decrypt(username, true);


            }

        }
        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string userid = gvsearchDetails.DataKeys[rowIndex].Values[1].ToString();
                Response.Redirect("~/SystemHome/Catalog/Instructor/samic-01.aspx?uid=" + SecurityCenter.EncryptText(userid));
            }


        }
        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void btnAddnewuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/saau-01.aspx");

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //ViewState["firstname"] = txtFirstName.Text;
            //ViewState["lastname"] = txtLastName.Text;
            //ViewState["username"] = txtUsername.Text;
            //ViewState["usertypes"] = ddlUserTypes.SelectedValue;
            //ViewState["domainid"] = ddlUserdomain.SelectedValue;
            //ViewState["activestatus"] = ddlUserstatus.SelectedValue;
            ViewState["SearchResult"] = "1";
            SearchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            dddownresultperpage.SelectedIndex = 0;
            ddresultperpage.SelectedIndex = 0;
        }
        public void SearchResult()
        {
            User userSearch = new User();
            if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
            {
                userSearch.Firstname = txtFirstName.Text;
                userSearch.Lastname = txtLastName.Text;
                HashEncryption encHash = new HashEncryption();
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    userSearch.Username_enc_ash = encHash.GenerateHashvalue(txtUsername.Text, true);
                }
                else
                {
                    userSearch.Username_enc_ash = "";
                }
                
                userSearch.DomainId = ddlUserdomain.SelectedValue;
                if (ddlUserTypes.SelectedValue == "app_ddl_all_text")
                {
                    userSearch.Usertype = "0";
                }
                else
                {
                    userSearch.Usertype = ddlUserTypes.SelectedValue;
                }
                if (ddlUserstatus.SelectedValue == "app_ddl_all_text")
                {
                    userSearch.Active_Type = "0";
                }
                else
                {
                    userSearch.Active_Type = ddlUserstatus.SelectedValue;
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["firstname"]))
            {
                userSearch.Firstname = SecurityCenter.DecryptText(Request.QueryString["firstname"]);
                userSearch.Lastname = SecurityCenter.DecryptText(Request.QueryString["lastname"]);
                HashEncryption encHash = new HashEncryption();
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["username"])))
                {
                    userSearch.Username_enc_ash = encHash.GenerateHashvalue(SecurityCenter.DecryptText(Request.QueryString["username"]), true);
                }
                else
                {
                    userSearch.Username_enc_ash = "";
                }
               
                userSearch.DomainId = SecurityCenter.DecryptText(Request.QueryString["userdomain"]);
                if (SecurityCenter.DecryptText(Request.QueryString["userstatus"]) == "app_ddl_all_text")
                {
                    userSearch.Active_Type = "0";
                }
                else
                {
                    userSearch.Active_Type = SecurityCenter.DecryptText(Request.QueryString["userstatus"]);
                }
                if (SecurityCenter.DecryptText(Request.QueryString["usertype"]) == "app_ddl_all_text")
                {
                    userSearch.Usertype = "0";
                }
                else
                {
                    userSearch.Usertype = SecurityCenter.DecryptText(Request.QueryString["usertype"]);
                }

            }
            else
            {
                userSearch.Firstname = txtFirstName.Text;
                userSearch.Lastname = txtLastName.Text;
                HashEncryption encHash = new HashEncryption();
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    userSearch.Username_enc_ash = encHash.GenerateHashvalue(txtUsername.Text, true);
                }
                else
                {
                    userSearch.Username_enc_ash = "";
                }
                if (ddlUserTypes.SelectedValue == "app_ddl_all_text")
                {
                    userSearch.Usertype = "0";
                }
                else
                {
                    userSearch.Usertype = ddlUserTypes.SelectedValue;
                }
                if (ddlUserstatus.SelectedValue == "app_ddl_all_text")
                {
                    userSearch.Active_Type = "0";
                }
                else
                {
                    userSearch.Active_Type = ddlUserstatus.SelectedValue;
                }
                userSearch.DomainId = ddlUserdomain.SelectedValue;
                
            }

            DataTable dtgetvalue = new DataTable();
            try
            {
                dtgetvalue = UserBLL.InstructorSearch(userSearch);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasur-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasur-01", ex.Message);
                    }
                }
            }
            gvsearchDetails.DataSource = dtgetvalue;
            gvsearchDetails.DataBind();

            gvsearchDetails.UseAccessibleHeader = true;
            if (gvsearchDetails.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (dtgetvalue.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
            }


        }
        //public void displayrecord()
        //{
        //    User userSearch = new User();
        //    userSearch.Firstname = SecurityCenter.DecryptText(Request.QueryString["firstname"]);
        //    userSearch.Lastname = SecurityCenter.DecryptText(Request.QueryString["lastname"]);
        //    HashEncryption encHash = new HashEncryption();
        //    if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["username"])))
        //    {
        //        userSearch.Username_enc_ash = encHash.GenerateHashvalue(SecurityCenter.DecryptText(Request.QueryString["username"]), true);
        //    }
        //    else
        //    {
        //        userSearch.Username_enc_ash = "";
        //    }
        //    userSearch.Usertype = SecurityCenter.DecryptText(Request.QueryString["usertype"]);
        //    userSearch.DomainId = SecurityCenter.DecryptText(Request.QueryString["userdomain"]);
        //    userSearch.Active_Type = SecurityCenter.DecryptText(Request.QueryString["userstatus"]);

        //    DataTable dtgetvalue = new DataTable();

        //    try
        //    {
        //        dtgetvalue = UserBLL.InstructorSearch(userSearch);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ConfigurationWrapper.LogErrors == true)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                Logger.WriteToErrorLog("sasur-01", ex.Message, ex.InnerException.Message);
        //            }
        //            else
        //            {
        //                Logger.WriteToErrorLog("sasur-01r", ex.Message);
        //            }
        //        }
        //    }
        //    gvsearchDetails.DataSource = dtgetvalue;
        //    gvsearchDetails.DataBind();

        //    if (dtgetvalue.Rows.Count == 0)
        //    {

        //        disable();

        //    }
        //    else
        //    {
        //        enable();
        //    }
        //    if (dtgetvalue.Rows.Count > 0)
        //    {
        //        gvsearchDetails.UseAccessibleHeader = true;
        //        if (gvsearchDetails.HeaderRow != null)
        //        {
        //            //This will tell ASP.NET to render the <thead> for the header row
        //            //using instead of the simple <tr>
        //            gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }
        //    }

        //}
        private void disable_enable(bool status)
        {
            btnFirst.Visible = status;
            btnPrevious.Visible = status;
            btnNext.Visible = status;
            btnLast.Visible = status;

            btndownFirst.Visible = status;
            btndownNext.Visible = status;
            btndownPrevious.Visible = status;
            btndownLast.Visible = status;

            dddownresultperpage.Visible = status;
            ddresultperpage.Visible = status;

            txtPage.Visible = status;
            lblPage.Visible = status;

            txtdownpage.Visible = status;
            lbldownPage.Visible = status;

            btndownGoto.Visible = status;
            btnGoto.Visible = status;


            lblHeaderPage.Visible = status;
            lblFooterPage.Visible = status;
            lblHeaderResultPerPage.Visible = status;
            lblFooterResultPerPage.Visible = status;
        }
        protected void gvsearchDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}