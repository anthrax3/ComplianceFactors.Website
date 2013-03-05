using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.Employee.Profile
{
    public partial class lppp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_profile_text");
                //timezone
                ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                ddlTimezone.DataBind();
                //language
                ddlLocale.DataSource = UserBLL.GetLocalelist();
                ddlLocale.DataBind();
                //mobile carrier
                ddlCarrier.DataSource = UserBLL.GetCarrierType(SessionWrapper.CultureName, "lppp-01");
                ddlCarrier.DataBind();
                //mobile type
                ddlMobileType.DataSource = UserBLL.GetMobileType(SessionWrapper.CultureName, "lppp-01");
                ddlMobileType.DataBind();
                //country
                ddlCountry.DataSource = UserBLL.GetCountrylist();
                ddlCountry.DataBind();
                //Expand and collapsed for course
                ddlCollapsedCourse.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "lppp-01");
                ddlCollapsedCourse.DataBind();
                //Expand and collapsed for curricula
                ddlCollapsedCurricula.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "lppp-01");
                ddlCollapsedCurricula.DataBind();
                //Expand and collapsed for learning history
                ddlCollapsedLearningHistory.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "lppp-01");
                ddlCollapsedLearningHistory.DataBind();

                //get user information
                PopulateUserInfo(SessionWrapper.u_userid);

            }
            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Employee/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/ascp-01.aspx", false);
        }
        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/bchp-01.aspx", false);
        }
        private void PopulateUserInfo(string userId)
        {
            User edituser = new User();
            try
            {
                edituser = UserBLL.GetUserInfo_by_id(userId);
                //username decrypt
                HashEncryption encHash = new HashEncryption();
                lblUserName.Text = encHash.Decrypt(edituser.Username_enc_ash, true);
                //end
                lblFirstName.Text = edituser.Firstname;
                txtMiddleName.Text = edituser.Middlename;
                lblLastName.Text = edituser.Lastname;
                txtEmailAddress.Text = edituser.EmailId;
                ddlMobileType.SelectedValue = edituser.Mobiletype.Trim();
                ddlCarrier.SelectedValue = edituser.MobileCarrier;
                txtMobilenumber.Text = edituser.MobileNumber;
                txtWorkPhone.Text = edituser.WorkPhone;
                txtWorkExtension.Text = edituser.Workextension;
                txtAddress1.Text = edituser.Address1;
                txtAddress2.Text = edituser.Address2;
                txtAddress3.Text = edituser.Address3;
                txtCity.Text = edituser.City;
                txtStateprovince.Text = edituser.StateProvince;
                txtzippostalcode.Text = edituser.ZipPostalcode;
                ddlCountry.SelectedValue = edituser.Country;
                ddlLocale.SelectedValue = edituser.LocaleId;
                ddlTimezone.SelectedValue = edituser.TimezoneId;
                ddlLocale.SelectedValue = edituser.LocaleId;
                lblManager.Text = edituser.Hris_manager_text;
                lblSupervisor.Text = edituser.Hris_supervisor_text;
                lblMentor.Text = edituser.Hris_mentor_text;
                lblAltManager.Text = edituser.Hris_Alternate_manager_text;
                lblAltSupervisor.Text = edituser.Hris_alternate_supervisor_text;
                lblAltMentor.Text = edituser.Alternate_mentor_text;
                ddlCollapsedCourse.SelectedValue = edituser.u_profile_my_courses_collapse_pref;
                ddlCollapsedCurricula.SelectedValue = edituser.u_profile_my_curricula_collapse_pref;
                ddlCollapsedLearningHistory.SelectedValue = edituser.u_profile_my_learning_history_collapse_pref;
                ddlNumberOfRecordCourse.SelectedValue = Convert.ToString(edituser.u_profile_my_courses_records_display_pref);
                ddlNumberOfRecourdsCurricula.SelectedValue = Convert.ToString(edituser.u_profile_my_curricula_records_display_pref);
                ddlNumberOfRecordsLearningHistory.SelectedValue = Convert.ToString(edituser.u_profile_my_learning_history_records_display_pref);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lppp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lppp-01", ex.Message);
                    }
                }
            }

        }
        private void UpdateProfile()
        {
            User updateuser = new User();
            updateuser.Userid = SessionWrapper.u_userid;
            updateuser.Middlename = txtMiddleName.Text;
            updateuser.EmailId = txtEmailAddress.Text;
            updateuser.Mobiletype = ddlMobileType.SelectedValue;
            updateuser.MobileCarrier = ddlCarrier.SelectedValue;
            updateuser.MobileNumber = txtMobilenumber.Text;
            updateuser.WorkPhone = txtWorkPhone.Text;
            updateuser.Workextension = txtWorkExtension.Text;
            updateuser.Address1 = txtAddress1.Text;
            updateuser.Address2 = txtAddress2.Text;
            updateuser.Address3 = txtAddress3.Text;
            updateuser.City = txtCity.Text;
            updateuser.StateProvince = txtStateprovince.Text;
            updateuser.ZipPostalcode = txtzippostalcode.Text;
            updateuser.Country = ddlCountry.SelectedValue;
            updateuser.LocaleId = ddlLocale.SelectedValue;
            updateuser.TimezoneId = ddlTimezone.SelectedValue;
            updateuser.u_profile_my_courses_collapse_pref = ddlCollapsedCourse.SelectedValue;
            updateuser.u_profile_my_curricula_collapse_pref = ddlCollapsedCurricula.SelectedValue;
            updateuser.u_profile_my_learning_history_collapse_pref = ddlCollapsedLearningHistory.SelectedValue;
            int tempNumberOfRecordsCourse, tempNumberofRecordsCurriclua, tempNumberofRecordsLrnHtry;
            if (int.TryParse(ddlNumberOfRecordCourse.SelectedValue, out tempNumberOfRecordsCourse))
            {
                updateuser.u_profile_my_courses_records_display_pref = tempNumberOfRecordsCourse;
            }
            else
            {
                updateuser.u_profile_my_courses_records_display_pref = 0;
            }
            if (int.TryParse(ddlNumberOfRecourdsCurricula.SelectedValue, out tempNumberofRecordsCurriclua))
            {
                updateuser.u_profile_my_curricula_records_display_pref = tempNumberofRecordsCurriclua;
            }
            else
            {
                updateuser.u_profile_my_curricula_records_display_pref = 0;
            }
            if (int.TryParse(ddlNumberOfRecordsLearningHistory.SelectedValue, out tempNumberofRecordsLrnHtry))
            {
                updateuser.u_profile_my_learning_history_records_display_pref = tempNumberofRecordsLrnHtry;
            }
            else
            {
                updateuser.u_profile_my_learning_history_records_display_pref = 0;
            }
            updateuser.type = "Employee";
            updateuser.u_profile_my_todos_records_display_pref = 0;
            updateuser.u_profile_my_team_records_display_pref = 0;
            updateuser.u_profile_my_report_history_records_display_pref = 0;
            updateuser.u_profile_my_todos_collapse_pref = string.Empty;
            updateuser.u_profile_my_team_collapse_pref = string.Empty;
            updateuser.u_profile_my_report_history_collapse_pref = string.Empty;
            try
            {
                int result = UserBLL.UpdateUserProfile(updateuser);
                if (result != -1)
                {
                    SessionWrapper.u_profile_my_courses_collapse_pref = updateuser.u_profile_my_courses_collapse_pref;
                    SessionWrapper.u_profile_my_curricula_collapse_pref = updateuser.u_profile_my_curricula_collapse_pref;
                    SessionWrapper.u_profile_my_learning_history_collapse_pref = updateuser.u_profile_my_learning_history_collapse_pref;
                    SessionWrapper.u_profile_my_courses_records_display_pref = updateuser.u_profile_my_courses_records_display_pref;
                    SessionWrapper.u_profile_my_curricula_records_display_pref = updateuser.u_profile_my_curricula_records_display_pref;
                    SessionWrapper.u_profile_my_learning_history_records_display_pref = updateuser.u_profile_my_learning_history_records_display_pref;

                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                }
                else
                {
                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");

                }


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lppp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lppp-01", ex.Message);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateProfile();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Home/lhp-01.aspx");
        }


    }
}