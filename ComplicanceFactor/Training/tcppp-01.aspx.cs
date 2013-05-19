using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Training
{
    public partial class tcppp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_training";
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_training_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manager_pod_mprofile_title");
                //timezone
                ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                ddlTimezone.DataBind();
                //language
                ddlLocale.DataSource = UserBLL.GetLocalelist();
                ddlLocale.DataBind();
                //mobile carrier
                ddlCarrier.DataSource = UserBLL.GetCarrierType(SessionWrapper.CultureName, "tcppp-01");
                ddlCarrier.DataBind();
                //mobile type
                ddlMobileType.DataSource = UserBLL.GetMobileType(SessionWrapper.CultureName, "tcppp-01");
                ddlMobileType.DataBind();
                //country
                ddlCountry.DataSource = UserBLL.GetCountrylist();
                ddlCountry.DataBind();

                //Expand and collapsed for To Do 
                ddlCollapsedTodo.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "tcppp-01");
                ddlCollapsedTodo.DataBind();
                //Expand and collapsed for Deliveries
                ddlCollapsedDeliveries.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "tcppp-01");
                ddlCollapsedDeliveries.DataBind();
                //Expand and collapsed for Reports
                ddlCollapsedReport.DataSource = UserBLL.GetExpandCollapse(SessionWrapper.CultureName, "tcppp-01");
                ddlCollapsedReport.DataBind();

                //get user information
                PopulateUserInfo(SessionWrapper.u_userid);
            }
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

                ddlCollapsedTodo.SelectedValue = edituser.u_profile_my_train_todos_collapse_pref;
                ddlCollapsedDeliveries.SelectedValue = edituser.u_profile_my_train_deliveries_collapse_pref;
                ddlCollapsedReport.SelectedValue = edituser.u_profile_my_train_reports_collapse_pref;

                ddlNumberOfRecordTodo.SelectedValue = Convert.ToString(edituser.u_profile_my_train_todos_display_pref);
                ddlNumberOfRecourdsDeliveries.SelectedValue = Convert.ToString(edituser.u_profile_my_train_deliveries_display_pref);
                ddlNumberOfRecordsReport.SelectedValue = Convert.ToString(edituser.u_profile_my_train_reports_display_pref);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcppp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcppp-01", ex.Message);
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

            updateuser.u_profile_my_train_todos_collapse_pref = ddlCollapsedTodo.SelectedValue;
            updateuser.u_profile_my_train_deliveries_collapse_pref = ddlCollapsedDeliveries.SelectedValue;
            updateuser.u_profile_my_train_reports_collapse_pref = ddlCollapsedReport.SelectedValue;

            int tempNumberOfRecordsCourse, tempNumberofRecordsCurriclua, tempNumberofRecordsLrnHtry;
            if (int.TryParse(ddlNumberOfRecordTodo.SelectedValue, out tempNumberOfRecordsCourse))
            {
                updateuser.u_profile_my_train_todos_display_pref = tempNumberOfRecordsCourse;
            }
            else
            {
                updateuser.u_profile_my_train_todos_display_pref = 0;
            }

            if (int.TryParse(ddlNumberOfRecourdsDeliveries.SelectedValue, out tempNumberofRecordsCurriclua))
            {
                updateuser.u_profile_my_train_deliveries_display_pref = tempNumberofRecordsCurriclua;
            }
            else
            {
                updateuser.u_profile_my_train_deliveries_display_pref = 0;
            }
            if (int.TryParse(ddlNumberOfRecordsReport.SelectedValue, out tempNumberofRecordsLrnHtry))
            {
                updateuser.u_profile_my_train_reports_display_pref = tempNumberofRecordsLrnHtry;
            }
            else
            {
                updateuser.u_profile_my_train_reports_display_pref = 0;
            }
            
            try
            {
                int result = TrainingBLL.UpdateUserProfile_Trainng(updateuser);
                if (result != -1)
                {
                    SessionWrapper.u_profile_my_train_todos_collapse_pref = updateuser.u_profile_my_train_todos_collapse_pref;
                    SessionWrapper.u_profile_my_train_deliveries_collapse_pref = updateuser.u_profile_my_train_deliveries_collapse_pref;
                    SessionWrapper.u_profile_my_train_reports_collapse_pref = updateuser.u_profile_my_train_reports_collapse_pref;
                    SessionWrapper.u_profile_my_train_todos_display_pref = updateuser.u_profile_my_train_todos_display_pref;
                    SessionWrapper.u_profile_my_train_deliveries_display_pref = updateuser.u_profile_my_train_deliveries_display_pref;
                    SessionWrapper.u_profile_my_train_reports_display_pref = updateuser.u_profile_my_train_reports_display_pref;

                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "block");
                    success_msg.InnerText = "Successfully updated";
                    error_msg.Style.Add("display", "none");
                }
                else
                {
                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerText = "User details was not updated";

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
                        Logger.WriteToErrorLog("tcppp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcppp-01", ex.Message);
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
            Response.Redirect("~/Training/tchp-01.aspx");
        }
 
    }
}