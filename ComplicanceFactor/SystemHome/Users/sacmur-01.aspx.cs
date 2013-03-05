using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome
{
    public partial class sacmur_01 : BasePage
    {
        private string user1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["merge"]))
            {
                user1 = SecurityCenter.DecryptText(Request.QueryString["merge"]);
            }
            if (!IsPostBack)
            {

                ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName,"sacmur-01");
                ddlUserstatus.DataBind();
                ddlUserstatus.SelectedValue = "app_ddl_all_text";

                //ListItem lstStatus = new ListItem();
                //lstStatus.Text = "All";
                //lstStatus.Value = "0";

                //ddlUserstatus.Items.Insert(0, lstStatus);

                //ddlUserstatus.SelectedIndex = 0;


                if (!string.IsNullOrEmpty(Request.QueryString["merge"]))
                {
                    user1 = SecurityCenter.DecryptText(Request.QueryString["merge"]);
                    SelectedUser(user1);

                }

                try
                {
                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sacmur-01");
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

                    displayrecord();

                    lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saau-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saau-01", ex.Message);
                        }
                    }

                }
            }
        }
        public void displayrecord()
        {


            User userSearch = new User();

            //if (!string.IsNullOrEmpty(Request.QueryString["userdomain"]))
            //{

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
            //}
            //else
            //{
            //    userSearch.Firstname = "";
            //    userSearch.Lastname = "";
            //    userSearch.Username_enc_ash = "";
            //    //default values
            //    userSearch.Usertype = "0";
            //    userSearch.DomainId = "0";
            //    userSearch.Active_status_flag = "1";

            //}
            DataTable dtgetvalue = new DataTable();

            try
            {
                dtgetvalue = UserBLL.SearchUser(userSearch);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmur-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmur-01", ex.Message);
                    }
                }
            }
            gvsearchDetails.DataSource = dtgetvalue;
            gvsearchDetails.DataBind();

            if (dtgetvalue.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
            }
            if (dtgetvalue.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
       
        public void SelectedUser(string userId)
        {


            User selectedUser = new User();
            selectedUser.Userid = userId;

            try
            {
                gvSelectedUser.DataSource = UserBLL.SelectedUser(selectedUser);
                gvSelectedUser.DataBind();




            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmu-01", ex.Message);
                    }
                }
            }


        }
        protected void gvSelectedUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUsername = (Label)e.Row.FindControl("lblUsername");
                /// <summary>
                /// decrypt hash  username
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                lblUsername.Text = encHash.Decrypt(lblUsername.Text, true);


            }

        }
        //top FirstButton
        protected void btnFirst_Click(object sender, EventArgs e)
        {

            gvsearchDetails.PageIndex = 0;
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }

            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();




        }

        //Top Last Button
        protected void btnLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }

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

            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }

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

            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }

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


            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }

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
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
            txtdownpage.Text = txtPage.Text;
        }

        //Down First Button
        protected void btndownFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
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

            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
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

            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }


        //Down Last Button
        protected void btndownLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
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


            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }


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
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }
            txtPage.Text = txtdownpage.Text;
        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;
            if (!string.IsNullOrEmpty((string)ViewState["searchresult"]))
            {
                SearchResult();
            }
            else
            {
                displayrecord();
            }


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
            if (e.CommandName == "selectuser")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string user2 = gvsearchDetails.DataKeys[rowIndex].Values[1].ToString();
                Response.Redirect("~/SystemHome/Users/sacmuc-01.aspx?user1=" + SecurityCenter.EncryptText(user1) + "&user2=" + SecurityCenter.EncryptText(user2));


                
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
            ViewState["firstname"] = txtFirstName.Text;
            ViewState["lastname"] = txtLastName.Text;
            ViewState["username"] = txtUsername.Text;
            ViewState["domainid"] = ddlUserdomain.SelectedValue;
            if (ddlUserstatus.SelectedValue == "app_ddl_all_text")
            {
                ViewState["activestatus"] = "0";
            }
            else
            {
                ViewState["activestatus"] = ddlUserstatus.SelectedValue;
            }
            if (ddlUserTypes.SelectedValue == "app_ddl_all_text")
            {
                ViewState["usertypes"] = "0";
            }
            else
            {
                ViewState["usertypes"] = ddlUserTypes.SelectedValue;
            }
            SearchResult();

            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            dddownresultperpage.SelectedIndex = 0;
            ddresultperpage.SelectedIndex = 0;



            ViewState["searchresult"] = "1";
        }
        public void SearchResult()
        {


            User userResult = new User();

            userResult.Firstname = ViewState["firstname"].ToString();
            userResult.Lastname = ViewState["lastname"].ToString();
            HashEncryption encHash = new HashEncryption();
            if (!string.IsNullOrEmpty((string)ViewState["username"]))
            {
                userResult.Username_enc_ash = encHash.GenerateHashvalue(ViewState["username"].ToString(), true);
            }
            else
            {
                userResult.Username_enc_ash = "";
            }
            userResult.Usertype = ViewState["usertypes"].ToString();
            userResult.DomainId = ViewState["domainid"].ToString();
            userResult.Active_Type = ViewState["activestatus"].ToString();

            DataTable dtgetvalue = new DataTable();

            try
            {
                dtgetvalue = UserBLL.SearchUser(userResult);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmur-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmur-01", ex.Message);
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

                disable();

            }
            else
            {
                enable();
            }


        }
        private void disable()
        {
            btnFirst.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;

            btndownFirst.Visible = false;
            btndownNext.Visible = false;
            btndownPrevious.Visible = false;
            btndownLast.Visible = false;

            dddownresultperpage.Visible = false;
            ddresultperpage.Visible = false;

            txtPage.Visible = false;
            lblPage.Visible = false;

            txtdownpage.Visible = false;
            lbldownPage.Visible = false;

            btndownGoto.Visible = false;
            btnGoto.Visible = false;


            lblHeaderPage.Visible = false;
            lblFooterPage.Visible = false;
            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;
        }


        private void enable()
        {
            btnFirst.Visible = true;
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;

            btndownFirst.Visible = true;
            btndownNext.Visible = true;
            btndownPrevious.Visible = true;
            btndownLast.Visible = true;

            dddownresultperpage.Visible = true;
            ddresultperpage.Visible = true;

            txtPage.Visible = true;
            lblPage.Visible = true;

            txtdownpage.Visible = true;
            lbldownPage.Visible = true;

            btndownGoto.Visible = true;
            btnGoto.Visible = true;


            lblHeaderPage.Visible = true;
            lblFooterPage.Visible = true;
            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;
        }

        protected void gvsearchDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
        }

    }
}