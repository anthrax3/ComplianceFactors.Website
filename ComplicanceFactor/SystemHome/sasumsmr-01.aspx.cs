using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome
{
    public partial class sasumsmr_01 : BasePage
    {

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
            if (SecurityCenter.DecryptText(Request.QueryString["usertype"]) == "app_ddl_all_text")
            {
                userSearch.Usertype = "0";
            }
            else
            {
                userSearch.Usertype = SecurityCenter.DecryptText(Request.QueryString["usertype"]);
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
                        Logger.WriteToErrorLog("sasumsmr-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasumsmr-01r", ex.Message);
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


        public void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName, "sasumsmr-01");
                ddlUserstatus.DataBind();
                ddlUserstatus.SelectedValue = "app_ddl_all_text";
                //ListItem lstStatus = new ListItem();
                //lstStatus.Text = "All";
                //lstStatus.Value = "0";

                //ddlUserstatus.Items.Insert(0, lstStatus);
                //ddlUserstatus.SelectedIndex = 0;


                try
                {
                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sasumsmr-01");
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
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvsearchDetails.Rows[index];

            if (e.CommandName == "Select")
            {
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saantc" || SecurityCenter.DecryptText(Request.QueryString["page"]) == "saetc")
                {
                    if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["courseowner"])) && SecurityCenter.DecryptText(Request.QueryString["courseowner"]) == "true")
                    {
                        SessionWrapper.c_owner_name = row.Cells[0].Text + ", " + row.Cells[1].Text;
                        SessionWrapper.c_course_owner_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                    }
                    else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["coursecoordinatorowner"])) && SecurityCenter.DecryptText(Request.QueryString["coursecoordinatorowner"]) == "true")
                    {
                        SessionWrapper.c_coordinator_name = row.Cells[0].Text + ", " + row.Cells[1].Text;
                        SessionWrapper.c_course_coordinator_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                    }
                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saau" || SecurityCenter.DecryptText(Request.QueryString["page"]) == "saeu")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["manager"]) && SecurityCenter.DecryptText(Request.QueryString["manager"]) == "true")
                    {
                        SessionWrapper.u_hris_manager_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_manager_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["altmanager"]) && SecurityCenter.DecryptText(Request.QueryString["altmanager"]) == "true")
                    {
                        SessionWrapper.u_hris_alternate_manager_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_alternate_manager_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["supervisor"]) && SecurityCenter.DecryptText(Request.QueryString["supervisor"]) == "true")
                    {
                        SessionWrapper.u_hris_supervisor_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_supervisor_text = row.Cells[0].Text + ", " + row.Cells[1].Text;

                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["altsupervisor"]) && SecurityCenter.DecryptText(Request.QueryString["altsupervisor"]) == "true")
                    {
                        SessionWrapper.u_hris_alternate_supervisor_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_alternate_supervisor_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["mentor"]) && SecurityCenter.DecryptText(Request.QueryString["mentor"]) == "true")
                    {
                        SessionWrapper.u_hris_mentor_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_mentor_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["altmentor"]) && SecurityCenter.DecryptText(Request.QueryString["altmentor"]) == "true")
                    {
                        SessionWrapper.u_hris_alternate_mentor_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_hris_alternate_mentor_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }


                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "sand" || !string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saed")
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["deliveryowner"]) && SecurityCenter.DecryptText(Request.QueryString["deliveryowner"]) == "true")
                    {
                        SessionWrapper.c_delivery_owner_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.c_delivery_owner_name = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["deliverycoordiantor"]) && SecurityCenter.DecryptText(Request.QueryString["deliverycoordiantor"]) == "true")
                    {
                        SessionWrapper.c_delivery_coordinator_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.c_delivery_coordinator_name = row.Cells[0].Text + ", " + row.Cells[1].Text;

                    }
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saandn" || !string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saedn")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["domainowner"]) && SecurityCenter.DecryptText(Request.QueryString["domainowner"]) == "true")
                    {
                        SessionWrapper.u_domain_owner_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_domain_owner_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["domaincoordinatorowner"]) && SecurityCenter.DecryptText(Request.QueryString["domaincoordinatorowner"]) == "true")
                    {
                        SessionWrapper.u_domain_coordinator_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.u_domain_coordinator_text = row.Cells[0].Text + ", " + row.Cells[1].Text;

                    }
                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saanawn" || !string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saeaw")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["specificFirstLevelApprover"]) && SecurityCenter.DecryptText(Request.QueryString["specificFirstLevelApprover"]) == "true")
                    {
                        SessionWrapper.s_specific_user_for_first_level_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.s_specific_user_for_first_level_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["specificSecondLevelApprover"]) && SecurityCenter.DecryptText(Request.QueryString["specificSecondLevelApprover"]) == "true")
                    {
                        SessionWrapper.s_specific_user_for_second_level_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.s_specific_user_for_second_level_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["specificThirdLevelApprover"]) && SecurityCenter.DecryptText(Request.QueryString["specificThirdLevelApprover"]) == "true")
                    {
                        SessionWrapper.s_specific_user_for_third_level_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.s_specific_user_for_third_level_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                   
                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saanspn" || SecurityCenter.DecryptText(Request.QueryString["page"]) == "saespn")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["splashowner"]) && SecurityCenter.DecryptText(Request.QueryString["splashowner"]) == "true")
                    {
                        SessionWrapper.s_splash_owner_name = row.Cells[0].Text + ", " + row.Cells[1].Text;
                        SessionWrapper.s_splash_owner_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["splashCoordinator"]) && SecurityCenter.DecryptText(Request.QueryString["splashCoordinator"]) == "true")
                    {
                        SessionWrapper.s_splash_coordinator_name = row.Cells[0].Text + ", " + row.Cells[1].Text;
                        SessionWrapper.s_splash_coordinator_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                    }
                }
                else if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saanc" || !string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["page"])) && SecurityCenter.DecryptText(Request.QueryString["page"]) == "saec")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["curriculumowner"]) && SecurityCenter.DecryptText(Request.QueryString["curriculumowner"]) == "true")
                    {
                        SessionWrapper.c_curriculum_owner_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.c_curriculum_owner_text = row.Cells[0].Text + ", " + row.Cells[1].Text;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["curriculumcoordinatorowner"]) && SecurityCenter.DecryptText(Request.QueryString["curriculumcoordinatorowner"]) == "true")
                    {
                        SessionWrapper.c_curriculum_coordinator_id_fk = gvsearchDetails.DataKeys[index]["u_user_id_pk"].ToString();
                        SessionWrapper.c_curriculum_coordinator_text = row.Cells[0].Text + ", " + row.Cells[1].Text;

                    }
                }


                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }


        }

        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }




        protected void btnAddnewuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/saau-01.aspx");

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            ViewState["firstname"] = txtFirstName.Text;
            ViewState["lastname"] = txtLastName.Text;
            ViewState["username"] = txtUsername.Text;
            ViewState["usertypes"] = ddlUserTypes.SelectedValue;
            ViewState["domainid"] = ddlUserdomain.SelectedValue;
            ViewState["activestatus"] = ddlUserstatus.SelectedValue;

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


            //userResult.Usertype = ViewState["usertypes"].ToString();
            userResult.DomainId = ViewState["domainid"].ToString();
            //userResult.Active_Type = ViewState["activestatus"].ToString();

            if (ViewState["usertypes"].ToString() == "app_ddl_all_text")
            {
                userResult.Usertype = "0";
            }
            else
            {
                userResult.Usertype = ddlUserTypes.SelectedValue;
            }

            if (ViewState["activestatus"].ToString() == "app_ddl_all_text")
            {
                userResult.Active_Type = "0";
            }
            else
            {
                userResult.Active_Type = ddlUserstatus.SelectedValue;
            }

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
                        Logger.WriteToErrorLog("sasumsmr-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasumsmr-01", ex.Message);
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



    }
}