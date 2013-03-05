using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using System.Globalization;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data.SqlTypes;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.SystemHome
{
    public partial class saau_01 : BasePage
    {
        #region Private member variable
        //private string plainText = "";    // original plaintext
        //private string cipherText = "";                 // encrypted text
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        #endregion
        private string userId;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide validation summary
            vs_saau.Style.Add("display", "none");

            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_add_new_user_text");

                //Clear user related session
                ClearUserRelatedSession();
                try
                {


                    ddlUserstatus.DataSource = UserBLL.GetUserStatusList(SessionWrapper.CultureName,"saau-01");
                    ddlUserstatus.DataBind();
                    ddlUserstatus.SelectedValue = "app_ddl_active_text";

                    //end
                    ddlUserTypes.DataSource = UserBLL.GetUserTypes(SessionWrapper.CultureName, "saau-01");
                    ddlUserTypes.DataBind();
                    ddlUserTypes.SelectedIndex = 2;
                    ddlUserdomain.DataSource = UserBLL.GetUserDomains();
                    ddlUserdomain.DataBind();
                    ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                    ddlTimezone.DataBind();
                    ddlTimezone.SelectedIndex = 13;


                    ddlCarrier.DataSource = UserBLL.GetCarrierType(SessionWrapper.CultureName, "saau-01");
                    ddlCarrier.DataBind();

                    ddlEmployeeType.DataSource = UserBLL.GetEmployeeType(SessionWrapper.CultureName);
                    ddlEmployeeType.DataBind();

                    ddlMobileType.DataSource = UserBLL.GetMobileType(SessionWrapper.CultureName, "saau-01");
                    ddlMobileType.DataBind();

                    ddlCountry.DataSource = UserBLL.GetCountrylist();
                    ddlCountry.DataBind();

                    ddlLocale.DataSource = UserBLL.GetLocalelist();
                    ddlLocale.DataBind();

                    ddlLocale.SelectedIndex = 1;
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
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    userId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);


                    populateuserinfo(userId);


                }
            }

            //Get manager 
            lblManager.Text = SessionWrapper.u_hris_manager_text;
            //Get alternate manager 
            lblAltManager.Text = SessionWrapper.u_hris_alternate_manager_text;
            //Get supervisor
            lblSupervisor.Text = SessionWrapper.u_hris_supervisor_text;
            //Get alternate supervisor
            lblAltSupervisor.Text = SessionWrapper.u_hris_alternate_supervisor_text;
            //Get mentor
            lblMentor.Text = SessionWrapper.u_hris_mentor_text;
            //Get alternate mentor
            lblAltMentor.Text = SessionWrapper.u_hris_alternate_mentor_text;
            //show and hide hris button
            ShowandHideHrisButton();
        }

        protected void btnSavenewuser_header_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            User addnewuser = new User();
            addnewuser.Userid = Guid.NewGuid().ToString();
            /// <summary>
            /// Hash encryption for username and password
            /// </summary>
            HashEncryption encHash = new HashEncryption();
            addnewuser.Password_enc_ash = encHash.GenerateHashvalue(txtPassword_login.Text, true);
            addnewuser.Username_enc_ash = encHash.GenerateHashvalue(txtUsername_login.Text, true);
            /// <summary>
            /// Salt encryption for password
            /// </summary>
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
            addnewuser.Password_enc_salt = rijndaelKey.Encrypt(txtPassword_login.Text);
            //End
            addnewuser.Firstname = txtFirstName.Text;
            addnewuser.Middlename = txtMiddelName.Text;
            addnewuser.Lastname = txtLastName.Text;
            addnewuser.EmailId = txtEmailAddress.Text;
            addnewuser.Mobiletype = ddlMobileType.SelectedValue;
            addnewuser.MobileCarrier = ddlCarrier.SelectedValue;
            addnewuser.MobileNumber = txtMobilenumber.Text;
            addnewuser.WorkPhone = txtWorkPhone.Text;
            addnewuser.Workextension = txtWorkExtension.Text;
            addnewuser.Address1 = txtAddress1.Text;
            addnewuser.Address2 = txtAddress2.Text;
            addnewuser.Address3 = txtAddress3.Text;
            addnewuser.City = txtCity.Text;
            addnewuser.StateProvince = txtStateprovince.Text;
            addnewuser.ZipPostalcode = txtzippostalcode.Text;
            addnewuser.Country = ddlCountry.SelectedValue;
            addnewuser.DomainId = ddlUserdomain.SelectedValue;
            addnewuser.LocaleId = ddlLocale.SelectedValue;
            addnewuser.TimezoneId = ddlTimezone.SelectedValue;
            addnewuser.Usertype = ddlUserTypes.SelectedValue;

            //user creation type
            addnewuser.creation_type = ddlUserTypes.SelectedValue;
            //End
            addnewuser.Active_status_flag = ddlUserstatus.SelectedItem.Text;
            addnewuser.Active_Type = ddlUserstatus.SelectedValue;
            addnewuser.Hris_employeid = txtEmployeeid.Text;
            addnewuser.Hris_employee_type = ddlEmployeeType.SelectedValue;


            DateTime? dtHireDate = null;
            DateTime tempHiretDate;

            if (DateTime.TryParseExact(txtHiredate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempHiretDate))
            {
                dtHireDate = tempHiretDate;
            }

            addnewuser.Hris_hire_date = dtHireDate;
            //}

            DateTime? txtLastrehiredate = null;
            DateTime tempEndDate;

            if (DateTime.TryParseExact(txtLastrehire.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
            {
                txtLastrehiredate = tempEndDate;
            }

            addnewuser.Hris_last_rehire_date = txtLastrehiredate;

            addnewuser.Hris_company = txtCompany.Text;
            addnewuser.Hris_region = txtRegion.Text;
            addnewuser.Hris_division = txtDivision.Text;
            addnewuser.Hris_department = txtDepartment.Text;
            addnewuser.Hris_cost_center = txtcostcenter.Text;
            addnewuser.Hris_job_group = txtJobgroup.Text;
            addnewuser.Hris_job_code = txtJobcode.Text;
            addnewuser.Hris_job_title = txtJobtitle.Text;
            addnewuser.Hris_job_position = txtJobPosition.Text;
            addnewuser.Hris_pay_grade = txtPayGrade.Text;
            //questions
            addnewuser.Hris_manager_id = SessionWrapper.u_hris_manager_id_fk;
            addnewuser.Hris_supervisor_id = SessionWrapper.u_hris_supervisor_id_fk;
            addnewuser.Hris_Alternate_manager_id = SessionWrapper.u_hris_alternate_manager_id_fk;
            addnewuser.Hris_alternate_supervisor_id = SessionWrapper.u_hris_alternate_supervisor_id_fk;
            addnewuser.Hris_mentor_id = SessionWrapper.u_hris_mentor_id_fk;
            addnewuser.Alternate_mentor_id = SessionWrapper.u_hris_alternate_mentor_id_fk;
            //End

            addnewuser.sr_is_employee = chkEmployee.Checked;
            addnewuser.sr_is_manager = chkManager.Checked;
            addnewuser.sr_is_compliance = chkCompliance.Checked;
            addnewuser.sr_is_instructor = chkInstructor.Checked;
            addnewuser.sr_is_training = chkTrainig.Checked;
            addnewuser.sr_is_administrator = chkAdministrator.Checked;
            addnewuser.sr_is_system_admin = chkSystemadmin.Checked;
            addnewuser.sr_is_compliance_approver = chkComplianceApprover.Checked;

            addnewuser.Custom_01 = txtCustom01.Text;
            addnewuser.Custom_02 = txtCustom02.Text;
            addnewuser.Custom_03 = txtCustom03.Text;
            addnewuser.Custom_04 = txtCustom04.Text;
            addnewuser.Custom_05 = txtCustom05.Text;
            addnewuser.Custom_06 = txtCustom06.Text;
            addnewuser.Custom_07 = txtCustom07.Text;
            addnewuser.Custom_08 = txtCustom08.Text;
            addnewuser.Custom_09 = txtCustom09.Text;
            addnewuser.Custom_10 = txtCustom10.Text;
            addnewuser.Custom_11 = txtCustom11.Text;
            addnewuser.Custom_12 = txtCustom12.Text;
            addnewuser.Custom_13 = txtCustom13.Text;
            addnewuser.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Text);
            addnewuser.u_hris_is_rehire = chkRehire.Checked;

            try
            {
                int result = UserBLL.insert_new_user(addnewuser);
                if (result != -2)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        Response.Redirect("~/SystemHome/Users/saeu-01.aspx?id=" + SecurityCenter.EncryptText(addnewuser.Userid) + "&scopy=" + SecurityCenter.EncryptText("sucess"), false);
                    }

                    //Blank form

                    reset();

                    SessionWrapper.u_hris_manager_text = "";
                    btnManager.Style.Add("display", "inline");
                    btnManagerRemove.Style.Add("display", "none");

                    SessionWrapper.u_hris_supervisor_text = "";
                    btnSupervisor.Style.Add("display", "inline");
                    btnRemoveSupervisor.Style.Add("display", "none");


                    SessionWrapper.u_hris_mentor_text = "";
                    btnMentor.Style.Add("display", "inline");
                    btnRemoveMentor.Style.Add("display", "none");


                    SessionWrapper.u_hris_alternate_manager_text = "";
                    btnAltManager.Style.Add("display", "inline");
                    btnRemoveAltManager.Style.Add("display", "none");


                    SessionWrapper.u_hris_alternate_supervisor_text = "";
                    btnAltSupervisor.Style.Add("display", "inline");
                    btnRemoveAltSupervisor.Style.Add("display", "none");


                    SessionWrapper.u_hris_alternate_mentor_text = "";
                    btnAltMentor.Style.Add("display", "inline");
                    btnRemoveAltMentor.Style.Add("display", "none");
                }
                else
                {
                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");

                    txtUsername_login.Text = "";
                    txtPassword_login.Text = "";
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
                        Logger.WriteToErrorLog("saau-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saau-01", ex.Message);
                    }
                }
            }
        }

        protected void btnsavenewuser_footer_Click(object sender, EventArgs e)
        {
            btnSavenewuser_header_Click(sender, e);
        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");

        }


        protected void btncancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        protected void btnResetNotify_Click(object sender, EventArgs e)
        {

        }
        protected void reset()
        {
            HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
            divSuccess.Style.Add("display", "none");
            success_msg.Style.Add("display", "block");
            error_msg.Style.Add("display", "none");
            // success_msg.InnerHtml = "Successfully Inserted";

            txtPassword_login.Text = "";
            txtUsername_login.Text = "";

            txtFirstName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            txtEmailAddress.Text = "";
            ddlMobileType.SelectedIndex = 0;
            ddlCarrier.SelectedIndex = 0;
            txtMobilenumber.Text = "";
            txtWorkPhone.Text = "";
            txtWorkExtension.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtCity.Text = "";
            txtStateprovince.Text = "";
            txtzippostalcode.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlUserdomain.SelectedIndex = 0;
            ddlLocale.SelectedIndex = 0;
            ddlTimezone.SelectedIndex = 0;
            ddlUserTypes.SelectedIndex = 0;

            //user creation type
            ddlUserTypes.SelectedIndex = 0;
            //End
            ddlUserstatus.SelectedIndex = 0;
            ddlUserTypes.SelectedIndex = 0;
            txtEmployeeid.Text = "";
            ddlEmployeeType.SelectedIndex = 0;

            txtHiredate.Text = "";
            txtLastrehire.Text = "";
            txtCompany.Text = "";
            txtRegion.Text = "";
            txtDivision.Text = "";
            txtDepartment.Text = "";
            txtcostcenter.Text = "";
            txtJobgroup.Text = "";
            txtJobcode.Text = "";
            txtJobtitle.Text = "";
            txtJobPosition.Text = "";
            txtPayGrade.Text = "";
            //questions


            lblManager.Text = "";
            lblSupervisor.Text = "";
            lblMentor.Text = "";
            lblAltManager.Text = "";
            lblAltSupervisor.Text = "";
            lblAltMentor.Text = "";

            //txtManager.Text = "";


            //End

            chkEmployee.Checked = false;
            chkManager.Checked = false;
            chkCompliance.Checked = false;
            chkInstructor.Checked = false;
            chkTrainig.Checked = false;
            chkAdministrator.Checked = false;
            chkSystemadmin.Checked = false;
            chkRehire.Checked = false;
            txtCustom01.Text = "";
            txtCustom02.Text = "";
            txtCustom03.Text = "";
            txtCustom04.Text = "";
            txtCustom05.Text = "";
            txtCustom06.Text = "";
            txtCustom07.Text = "";
            txtCustom08.Text = "";
            txtCustom09.Text = "";
            txtCustom10.Text = "";
            txtCustom11.Text = "";
            txtCustom12.Text = "";
            txtCustom13.Text = "";
        }
        private void populateuserinfo(string userId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            User copyUser = new User();

            try
            {
                copyUser = UserBLL.GetUserInfo_by_id(userId);
                txtFirstName.Text = copyUser.Firstname + " (Copy)";
                txtMiddelName.Text = copyUser.Middlename;
                txtLastName.Text = copyUser.Lastname + " (Copy)";
                txtEmailAddress.Text = copyUser.EmailId;
                ddlMobileType.SelectedValue = copyUser.Mobiletype;
                ddlCarrier.SelectedValue = copyUser.MobileCarrier;
                txtMobilenumber.Text = copyUser.MobileNumber;
                txtWorkPhone.Text = copyUser.WorkPhone;
                txtWorkExtension.Text = copyUser.Workextension;
                txtAddress1.Text = copyUser.Address1;
                txtAddress2.Text = copyUser.Address2;
                txtAddress3.Text = copyUser.Address3;
                txtCity.Text = copyUser.City;
                txtStateprovince.Text = copyUser.StateProvince;
                txtzippostalcode.Text = copyUser.ZipPostalcode;
                ddlCountry.SelectedValue = copyUser.Country;
                ddlUserdomain.SelectedValue = copyUser.DomainId;
                ddlLocale.SelectedValue = copyUser.LocaleId;
                ddlTimezone.SelectedValue = copyUser.TimezoneId;
                ddlUserTypes.SelectedValue = copyUser.Usertype;

                //user creation type
                ddlUserTypes.SelectedValue = copyUser.Usertype;
                //End
                ddlUserstatus.SelectedValue = copyUser.Active_Type;

                txtEmployeeid.Text = copyUser.Hris_employeid;
                ddlEmployeeType.SelectedValue = copyUser.Hris_employee_type;


                if (!string.IsNullOrEmpty(copyUser.Hris_hire_date.ToString()))
                {
                    txtHiredate.Text = Convert.ToDateTime(copyUser.Hris_hire_date, culture).ToString("MM/dd/yyyy");
                }
                if (!string.IsNullOrEmpty(copyUser.Hris_last_rehire_date.ToString()))
                {
                    txtLastrehire.Text = Convert.ToDateTime(copyUser.Hris_last_rehire_date, culture).ToString("MM/dd/yyyy");
                }



                txtCompany.Text = copyUser.Hris_company;
                txtRegion.Text = copyUser.Hris_region;
                txtDivision.Text = copyUser.Hris_division;
                txtDepartment.Text = copyUser.Hris_department;
                txtcostcenter.Text = copyUser.Hris_cost_center;
                txtJobgroup.Text = copyUser.Hris_job_group;
                txtJobcode.Text = copyUser.Hris_job_code;
                txtJobtitle.Text = copyUser.Hris_job_title;
                txtJobPosition.Text = copyUser.Hris_job_position;
                txtPayGrade.Text = copyUser.Hris_pay_grade;


                chkEmployee.Checked = copyUser.sr_is_employee;
                chkManager.Checked = copyUser.sr_is_manager;
                chkCompliance.Checked = copyUser.sr_is_compliance;
                chkInstructor.Checked = copyUser.sr_is_instructor;
                chkTrainig.Checked = copyUser.sr_is_training;
                chkAdministrator.Checked = copyUser.sr_is_administrator;
                chkSystemadmin.Checked = copyUser.sr_is_system_admin;
                chkComplianceApprover.Checked = copyUser.sr_is_compliance_approver;
                chkRehire.Checked = copyUser.u_hris_is_rehire;

                txtCustom01.Text = copyUser.Custom_01;
                txtCustom02.Text = copyUser.Custom_02;
                txtCustom03.Text = copyUser.Custom_03;
                txtCustom04.Text = copyUser.Custom_04;
                txtCustom05.Text = copyUser.Custom_05;
                txtCustom06.Text = copyUser.Custom_06;
                txtCustom07.Text = copyUser.Custom_07;
                txtCustom08.Text = copyUser.Custom_08;
                txtCustom09.Text = copyUser.Custom_09;
                txtCustom10.Text = copyUser.Custom_10;
                txtCustom11.Text = copyUser.Custom_11;
                txtCustom12.Text = copyUser.Custom_12;
                txtCustom13.Text = copyUser.Custom_13;

                SessionWrapper.u_hris_manager_text = copyUser.Hris_manager_text;
                SessionWrapper.u_hris_supervisor_text = copyUser.Hris_supervisor_text;
                SessionWrapper.u_hris_mentor_text = copyUser.Hris_mentor_text;
                SessionWrapper.u_hris_alternate_manager_text = copyUser.Hris_Alternate_manager_text;
                SessionWrapper.u_hris_alternate_supervisor_text = copyUser.Hris_alternate_supervisor_text;
                SessionWrapper.u_hris_alternate_mentor_text = copyUser.Alternate_mentor_text;

                SessionWrapper.u_hris_manager_id_fk = copyUser.Hris_manager_id;
                SessionWrapper.u_hris_alternate_manager_id_fk = copyUser.Hris_Alternate_manager_id;

                SessionWrapper.u_hris_mentor_id_fk = copyUser.Hris_mentor_id;
                SessionWrapper.u_hris_alternate_mentor_id_fk = copyUser.Alternate_mentor_id;

                SessionWrapper.u_hris_supervisor_id_fk = copyUser.Hris_supervisor_id;
                SessionWrapper.u_hris_alternate_supervisor_id_fk = copyUser.Hris_alternate_supervisor_id;

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


        protected void btnAddnewuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/saau-01.aspx");

        }


        protected void btnManagerRemove_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_manager_id_fk);
            ViewState["removemanager"] = "0";

        }
        protected void btnRemoveSupervisor_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_supervisor_id_fk);
            ViewState["removesupervisor"] = "0";

        }
        protected void btnRemoveMentor_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_mentor_id_fk);
            ViewState["removementor"] = "0";
        }

        protected void btnRemoveAltManager_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_alternate_manager_id_fk);
            ViewState["removealtmanager"] = "0";
        }

        protected void btnRemoveAltSupervisor_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_alternate_supervisor_id_fk);
            ViewState["removealtsupervisor"] = "0";
        }

        protected void btnRemoveAltMentor_Click(object sender, EventArgs e)
        {
            ClearHrisViewstate();
            GetUserNames(SessionWrapper.u_hris_alternate_mentor_id_fk);
            ViewState["removealtmentor"] = "0";
        }
        private void GetUserNames(string userId)
        {
            User username = new User();
            try
            {
                username = UserBLL.GetUserInfo_by_id(userId);
                lblRemoveFirstName.Text = username.Firstname;
                lblRemoveLastName.Text = username.Lastname;
                lblRemoveMiddleName.Text = username.Middlename;

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


            lblRemoveFristName2.Text = SessionWrapper.u_firstname;
            lblRemoveLastName2.Text = SessionWrapper.u_lastname;
            lblRemoveMiddleName2.Text = SessionWrapper.u_middlename;
            mpeRemove.Show();

        }
       
        private void ClearHrisViewstate()
        {
            ViewState["removemanager"] = "";
            ViewState["removesupervisor"] = "";
            ViewState["removementor"] = "";
            ViewState["removealtmanager"] = "";
            ViewState["removealtsupervisor"] = "";
            ViewState["removealtmentor"] = "";
        }

        protected void btnRemoveSubmit_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty((string)ViewState["removemanager"]))
            {
                lblManager.Text = "";
                ViewState["removemanager"] = "";
                btnManager.Style.Add("display", "inline");
                btnManagerRemove.Style.Add("display", "none");
                SessionWrapper.u_hris_manager_text = "";
                SessionWrapper.u_hris_manager_id_fk = "";

            }

            else if (!string.IsNullOrEmpty((string)ViewState["removesupervisor"]))
            {
                lblSupervisor.Text = "";
                ViewState["removesupervisor"] = "";
                btnSupervisor.Style.Add("display", "inline");
                btnRemoveSupervisor.Style.Add("display", "none");
                SessionWrapper.u_hris_supervisor_text = "";
                SessionWrapper.u_hris_supervisor_id_fk = "";

            }
            else if (!string.IsNullOrEmpty((string)ViewState["removementor"]))
            {
                lblMentor.Text = "";
                ViewState["removementor"] = "";
                btnMentor.Style.Add("display", "inline");
                btnRemoveMentor.Style.Add("display", "none");
                SessionWrapper.u_hris_mentor_text = "";
                SessionWrapper.u_hris_mentor_id_fk = "";

            }
            else if (!string.IsNullOrEmpty((string)ViewState["removealtmanager"]))
            {
                lblAltManager.Text = "";
                ViewState["removealtmanager"] = "";
                btnAltManager.Style.Add("display", "inline");
                btnRemoveAltManager.Style.Add("display", "none");
                SessionWrapper.u_hris_alternate_manager_text = "";
                SessionWrapper.u_hris_alternate_manager_id_fk = "";

            }
            else if (!string.IsNullOrEmpty((string)ViewState["removealtsupervisor"]))
            {
                lblAltSupervisor.Text = "";
                ViewState["removealtsupervisor"] = "";
                btnAltSupervisor.Style.Add("display", "inline");
                btnRemoveAltSupervisor.Style.Add("display", "none");
                SessionWrapper.u_hris_alternate_supervisor_text = "";
                SessionWrapper.u_hris_alternate_supervisor_id_fk = "";

            }
            else if (!string.IsNullOrEmpty((string)ViewState["removealtmentor"]))
            {
                lblAltMentor.Text = "";
                ViewState["removealtmentor"] = "";
                btnAltMentor.Style.Add("display", "inline");
                btnRemoveAltMentor.Style.Add("display", "none");
                SessionWrapper.u_hris_alternate_mentor_text = "";
                SessionWrapper.u_hris_alternate_mentor_id_fk = "";
            }



            lblRemoveFirstName.Text = "";
            lblRemoveLastName.Text = "";
            lblRemoveMiddleName.Text = "";
            lblRemoveFristName2.Text = "";
            lblRemoveLastName2.Text = "";
            lblRemoveMiddleName2.Text = "";

            mpeRemove.Hide();

        }

        protected void btnReset_header_Click(object sender, EventArgs e)
        {

            ResetUser();

        }

        protected void btnreset_footer_Click(object sender, EventArgs e)
        {
            ResetUser();

        }
        private void ShowandHideHrisButton()
        {
            if (!string.IsNullOrEmpty(lblManager.Text))
            {
                btnManager.Style.Add("display", "none");
                btnManagerRemove.Style.Add("display", "inline");
            }
            if (!string.IsNullOrEmpty(lblSupervisor.Text))
            {
                btnSupervisor.Style.Add("display", "none");
                btnRemoveSupervisor.Style.Add("display", "inline");
            }
            if (!string.IsNullOrEmpty(lblMentor.Text))
            {
                btnMentor.Style.Add("display", "none");
                btnRemoveMentor.Style.Add("display", "inline");
            }
            if (!string.IsNullOrEmpty(lblAltManager.Text))
            {
                btnAltManager.Style.Add("display", "none");
                btnRemoveAltManager.Style.Add("display", "inline");
            }
            if (!string.IsNullOrEmpty(lblAltSupervisor.Text))
            {
                btnAltSupervisor.Style.Add("display", "none");
                btnRemoveAltSupervisor.Style.Add("display", "inline");
            }
            if (!string.IsNullOrEmpty(lblAltMentor.Text))
            {
                btnAltMentor.Style.Add("display", "none");
                btnRemoveAltMentor.Style.Add("display", "inline");
            }
        }

        //Reset user
        private void ResetUser()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
            {
                //Clear user related session
                ClearUserRelatedSession();
                //get user information
                populateuserinfo(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                //Get manager 
                lblManager.Text = SessionWrapper.u_hris_manager_text;
                //Get alternate manager 
                lblAltManager.Text = SessionWrapper.u_hris_alternate_manager_text;
                //Get supervisor
                lblSupervisor.Text = SessionWrapper.u_hris_supervisor_text;
                //Get alternate supervisor
                lblAltSupervisor.Text = SessionWrapper.u_hris_alternate_supervisor_text;
                //Get mentor
                lblMentor.Text = SessionWrapper.u_hris_mentor_text;
                //Get alternate mentor
                lblAltMentor.Text = SessionWrapper.u_hris_alternate_mentor_text;
                //show and hide hris button
                ShowandHideHrisButton();

            }
            else
            {
                //Clear user related session
                ClearUserRelatedSession();

                btnManager.Style.Add("display", "inline");
                btnManagerRemove.Style.Add("display", "none");

                btnSupervisor.Style.Add("display", "inline");
                btnRemoveSupervisor.Style.Add("display", "none");

                btnMentor.Style.Add("display", "inline");
                btnRemoveMentor.Style.Add("display", "none");



                btnAltManager.Style.Add("display", "inline");

                btnRemoveAltManager.Style.Add("display", "none");

                btnAltSupervisor.Style.Add("display", "inline");
                btnRemoveAltSupervisor.Style.Add("display", "none");


                btnAltMentor.Style.Add("display", "inline");
                btnRemoveAltMentor.Style.Add("display", "none");


                lblManager.Text = "";
                lblSupervisor.Text = "";
                lblMentor.Text = "";
                lblAltManager.Text = "";
                lblAltSupervisor.Text = "";
                lblAltMentor.Text = "";
            }
        }
        //clear user related sesssion
        private void ClearUserRelatedSession()
        {
            SessionWrapper.u_hris_manager_text = "";
            SessionWrapper.u_hris_manager_id_fk = "";
            SessionWrapper.u_hris_supervisor_text = "";
            SessionWrapper.u_hris_supervisor_id_fk = "";
            SessionWrapper.u_hris_mentor_text = "";
            SessionWrapper.u_hris_mentor_id_fk = "";
            SessionWrapper.u_hris_alternate_manager_text = "";
            SessionWrapper.u_hris_alternate_manager_id_fk = "";
            SessionWrapper.u_hris_alternate_supervisor_text = "";
            SessionWrapper.u_hris_alternate_supervisor_id_fk = "";
            SessionWrapper.u_hris_alternate_mentor_text = "";
            SessionWrapper.u_hris_alternate_mentor_id_fk = "";
        }
       
        //Delete Manager
        [System.Web.Services.WebMethod]
        public static void DeleteManager()
        {
            try
            {
                SessionWrapper.u_hris_manager_id_fk = "";
                SessionWrapper.u_hris_manager_text = "";


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
        //Delete Alternate Manager
        [System.Web.Services.WebMethod]
        public static void DeleteAlternateManager()
        {
            try
            {
                SessionWrapper.u_hris_alternate_manager_id_fk = "";
                SessionWrapper.u_hris_alternate_manager_text = "";


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
        //Delete Supervisor
        [System.Web.Services.WebMethod]
        public static void DeleteSupervisor()
        {
            try
            {
                SessionWrapper.u_hris_supervisor_id_fk = "";
                SessionWrapper.u_hris_supervisor_text = "";


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
        //Delete Altername Supervisor
        [System.Web.Services.WebMethod]
        public static void DeleteAlternateSupervisor()
        {
            try
            {
                SessionWrapper.u_hris_alternate_supervisor_id_fk = "";
                SessionWrapper.u_hris_alternate_supervisor_text = "";


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
        //Delete Mentor
        [System.Web.Services.WebMethod]
        public static void DeleteMentor()
        {
            try
            {
                SessionWrapper.u_hris_mentor_id_fk = "";
                SessionWrapper.u_hris_mentor_text = "";


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
        //Delete Alternate Mentor
        [System.Web.Services.WebMethod]
        public static void DeleteAlternateMentor()
        {
            try
            {
                SessionWrapper.u_hris_alternate_mentor_id_fk = "";
                SessionWrapper.u_hris_alternate_mentor_text = "";


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
}