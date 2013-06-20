using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;

namespace ComplicanceFactor.SystemHome
{
    public partial class saru_01 : BasePage
    {
        #region Private member variable
       // private string plainText = "";    // original plaintext
       // private string cipherText = "";                 // encrypted text
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLocalizationResourceLabelText("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLocalizationResourceLabelText("app_retire_user_text");
            string navigationText;
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
            hdNav_selected.Value = "#" + SessionWrapper.navigationText;
            lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_retire_user_text") + "</a>";
            if (!string.IsNullOrEmpty(Request.QueryString["Retire"]))
            {
                populateuserinfo(SecurityCenter.DecryptText(Request.QueryString["Retire"]));
            }

        }
        private void populateuserinfo(string userId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            User retire = new User();

            try
            {
                retire = UserBLL.GetUserInfo(userId);

                //username decrypt
                HashEncryption encHash = new HashEncryption();
                lblUserName.Text = encHash.Decrypt(retire.Username_enc_ash, true);
                //end

                /// <summary>
                /// Encrypt password with salt and validation
                /// </summary>
                RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
                lblPassword.Text = rijndaelKey.Decrypt(retire.Password_enc_salt);

                //End

                lblFirstName.Text = retire.Firstname;
                lblMiddleName.Text = retire.Middlename;
                lblLastName.Text = retire.Lastname;
                lblEmailAddress.Text = retire.EmailId;
                lblMobileType.Text = retire.Mobiletype;
                lblCarrier.Text = retire.MobileCarrier;
                lblMobileNumber.Text = retire.MobileNumber;
                lblWorkPhone.Text = retire.WorkPhone;
                lblWorkExtension.Text = retire.Workextension;
                lblAddress1.Text = retire.Address1;
                lblAddress2.Text = retire.Address2;
                lblAddress3.Text = retire.Address3;
                lblCity.Text = retire.City;
                lblStateProvince.Text = retire.StateProvince;
                lblZipPostalCode.Text = retire.ZipPostalcode;
                lblCountry.Text = retire.u_country_name;
                lblUserDomain.Text = retire.DomainId;
                //lblLocale.Text = retire.LocaleId;
                lblLocale.Text = retire.u_locale_descriptoin;
                lblTimeZone.Text = retire.u_timezone_location;
                lblUserTypes.Text = retire.Usertype;

                //user creation type
                lblUserTypes.Text = retire.Usertype;
                //End
                lblUserStatus.Text = retire.Active_status_flag;

                lblEmployeeId.Text = retire.Hris_employeid;
                lblEmployeeType.Text = retire.Hris_employee_type;



                if (!string.IsNullOrEmpty(retire.Hris_hire_date.ToString()))
                {
                    lblHireDate.Text = Convert.ToDateTime(retire.Hris_hire_date, culture).ToString("MM/dd/yyyy");
                }
                if (!string.IsNullOrEmpty(retire.Hris_last_rehire_date.ToString()))
                {
                    lblLastRehire.Text = Convert.ToDateTime(retire.Hris_last_rehire_date, culture).ToString("MM/dd/yyyy");
                } 

                //lblHireDate.Text = Convert.ToDateTime(retire.Hris_hire_date).ToShortDateString();
                //lblLastRehire.Text = Convert.ToDateTime(retire.Hris_last_rehire_date).ToShortDateString();




                lblCompany.Text = retire.Hris_company;
                lblRegion.Text = retire.Hris_region;
                lblDivision.Text = retire.Hris_division;
                lblDepartment.Text = retire.Hris_department;
                lblCostCenter.Text = retire.Hris_cost_center;
                lblJobGroup.Text = retire.Hris_job_group;
                lblJobCode.Text = retire.Hris_job_code;
                lblJobTitle.Text = retire.Hris_job_title;
                lblJobPostion.Text = retire.Hris_job_position;
                lblPayGrade.Text = retire.Hris_pay_grade;
                //questions
                //lblSupervisor.Text = retire.Hris_supervisor_text;
                //lblMentor.Text = retire.Hris_mentor_text;
                //lblAltManager.Text = retire.Hris_Alternate_manager_text;
                //lblAltSupervisor.Text = retire.Hris_alternate_supervisor_text;
                //lblAltMentor.Text = retire.Alternate_mentor_text;


                lblManager.Text = retire.Hris_manager_text;
                lblSupervisor.Text = retire.Hris_supervisor_text;
                lblMentor.Text = retire.Hris_mentor_text;
                lblAltManager.Text = retire.Hris_Alternate_manager_text;
                lblAltSupervisor.Text = retire.Hris_alternate_supervisor_text;
                lblAltMentor.Text = retire.Alternate_mentor_text;

                //addnewuser.Hris_manager = Guid.NewGuid().ToString();
                //addnewuser.Hris_supervisor = Guid.NewGuid().ToString();
                //addnewuser.Hris_Alternate_manager = Guid.NewGuid().ToString();
                //addnewuser.Hris_alternate_supervisor = Guid.NewGuid().ToString();
                //addnewuser.Hris_mentor = Guid.NewGuid().ToString();
                //End



                //lblAltMentor.Text = retire.Alternate_mentor;
                lblIsEmployee.Text = retire.text_sr_is_employee;
                lblIsManager.Text = retire.text_sr_is_manager;
                lblIsCompliance.Text = retire.text_sr_is_compliance;
                lblIsInstructor.Text = retire.text_sr_is_instructor;
                lblIsTraining.Text = retire.text_sr_is_training;
                lblIsAdministrator.Text = retire.text_sr_is_administrator;
                lblIsSystemAdmin.Text = retire.text_sr_is_system_admin;
                lblIsComplianceApprover.Text = retire.text_sr_is_compliance_approver;
                lblCustom01.Text = retire.Custom_01;
                lblCustom02.Text = retire.Custom_02;
                lblCustom03.Text = retire.Custom_03;
                lblCustom04.Text = retire.Custom_04;
                lblCustom05.Text = retire.Custom_05;
                lblCustom06.Text = retire.Custom_06;
                lblCustom07.Text = retire.Custom_07;
                lblCustom08.Text = retire.Custom_08;
                lblCustom09.Text = retire.Custom_09;
                lblCustom10.Text = retire.Custom_10;
                lblCustom11.Text = retire.Custom_11;
                lblCustom12.Text = retire.Custom_12;
                lblCustom13.Text = retire.Custom_13;

                lblIsRehire.Text = retire.u_hris_is_rehire_text;
                // addnewuser.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Text);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeu-01", ex.Message);
                    }
                }
            }

        }

        protected void btnConfirm_header_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["retire"]))
            {
                User userRetire = new User();
                userRetire.Userid = SecurityCenter.DecryptText(Request.QueryString["retire"]);
                userRetire.Active_status_flag = "0";
                //userRetire.Userid = SecurityCenter.DecryptText(Request.QueryString["id"]);
                try
                {
                    UserBLL.UpdateUserRetire(userRetire);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saru-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saru-01", ex.Message);
                        }
                    }
                }
                Response.Redirect("~/SystemHome/Users/saeu-01.aspx?id=" + SecurityCenter.EncryptText(userRetire.Userid) + "&sretire=" + SecurityCenter.EncryptText("succ"));
            }

        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
        }

        protected void btnConfirm_footer_Click(object sender, EventArgs e)
        {
            btnConfirm_header_Click(sender, e);
        }

        protected void btncancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");

        }
    }
}