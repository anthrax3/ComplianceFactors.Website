using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.SystemHome
{
    public partial class saeu_01 : BasePage
    {
        #region Private member variable
        //private string plainText = "";    // original plaintext
        //private string cipherText = "";                 // encrypted text
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        #endregion


        public string userid;

        protected void Page_Load(object sender, EventArgs e)
        {

            //Hide validation summary
            vs_saeu.Style.Add("display", "none");

            userid = SecurityCenter.DecryptText(Request.QueryString["id"]);

          
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_user_text");
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_user_text");

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                {
                    success_msg.Style.Add("display", "block");
                    lblSuccessMessage.Text = LocalResources.GetText("app_merge_succ_text");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["sretire"]))
                {
                    lblSuccessMessage.Text = LocalResources.GetText("app_retired_succ_text");
                    success_msg.Style.Add("display", "block");
                }


               

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    try
                    {

                        ddlUserstatus.DataSource = UserBLL.GetUserStatusList(SessionWrapper.CultureName,"saeu-01");
                        ddlUserstatus.DataBind();
                        ddlUserstatus.SelectedIndex = 0;


                        ddlUserTypes.DataSource = UserBLL.GetUserTypes(SessionWrapper.CultureName, "saeu-01");
                        ddlUserTypes.DataBind();
                    
                        ddlUserdomain.DataSource = UserBLL.GetUserDomains();
                        ddlUserdomain.DataBind();
                        ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                        ddlTimezone.DataBind();

                        ddlTimezone.SelectedIndex = 13;
                      
                        ddlLocale.DataSource = UserBLL.GetLocalelist();
                        ddlLocale.DataBind();


                        ddlCarrier.DataSource = UserBLL.GetCarrierType(SessionWrapper.CultureName, "saeu-01");
                        ddlCarrier.DataBind();

                        ddlEmployeeType.DataSource = UserBLL.GetEmployeeType(SessionWrapper.CultureName);
                        ddlEmployeeType.DataBind();


                        ddlMobileType.DataSource = UserBLL.GetMobileType(SessionWrapper.CultureName, "saeu-01");
                        ddlMobileType.DataBind();
                    
                        ddlCountry.DataSource = UserBLL.GetCountrylist();
                        ddlCountry.DataBind();


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

                   

                    //Get user information
                    populateuserinfo(userid);


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
        private void populateuserinfo(string userId)
        {

            CultureInfo culture = new CultureInfo("en-US");
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

            lblManager.Text = "";
            lblSupervisor.Text = "";
            lblMentor.Text = "";
            lblAltManager.Text = "";
            lblAltSupervisor.Text = "";
            lblAltMentor.Text = "";
        

            User edituser = new User();

            try
            {
                edituser = UserBLL.GetUserInfo_by_id(userId);

                //username decrypt
                HashEncryption encHash = new HashEncryption();
                txtUsername_login.Text = encHash.Decrypt(edituser.Username_enc_ash, true);
                //end

                /// <summary>
                /// Encrypt password with salt and validation
                /// </summary>
                RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
                txtPassword_login.Value = rijndaelKey.Decrypt(edituser.Password_enc_salt);
                //txtPassword_login.Attributes["value"] = Request.Form[txtPassword_login.ClientID];
                txtPassword_login.Attributes["type"] = "password";

                //End

                txtFirstName.Text = edituser.Firstname;
                txtMiddelName.Text = edituser.Middlename;
                txtLastName.Text = edituser.Lastname;
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
                ddlUserdomain.SelectedValue = edituser.DomainId;
                ddlLocale.SelectedValue = edituser.LocaleId;
                ddlTimezone.SelectedValue = edituser.TimezoneId;
                ddlUserTypes.SelectedValue = edituser.Usertype;
                ddlLocale.SelectedValue = edituser.LocaleId;
                //user creation type
                ddlUserTypes.SelectedValue = edituser.Usertype;
                //End
                
                ddlUserstatus.SelectedValue = edituser.Active_Type;
               
               

                txtEmployeeid.Text = edituser.Hris_employeid;

                //ddlEmployeeType.Items.FindByValue(edituser.Hris_employee_type).Selected = true;
                ddlEmployeeType.SelectedValue = edituser.Hris_employee_type;

                if (!string.IsNullOrEmpty(edituser.Hris_hire_date.ToString()))
                {
                    txtHiredate.Text = Convert.ToDateTime(edituser.Hris_hire_date, culture).ToString("MM/dd/yyyy");
                }
                if (!string.IsNullOrEmpty(edituser.Hris_last_rehire_date.ToString()))
                {
                    txtLastrehire.Text = Convert.ToDateTime(edituser.Hris_last_rehire_date, culture).ToString("MM/dd/yyyy");
                }

                txtCompany.Text = edituser.Hris_company;
                txtRegion.Text = edituser.Hris_region;
                txtDivision.Text = edituser.Hris_division;
                txtDepartment.Text = edituser.Hris_department;
                txtcostcenter.Text = edituser.Hris_cost_center;
                txtJobgroup.Text = edituser.Hris_job_group;
                txtJobcode.Text = edituser.Hris_job_code;
                txtJobtitle.Text = edituser.Hris_job_title;
                txtJobPosition.Text = edituser.Hris_job_position;
                txtPayGrade.Text = edituser.Hris_pay_grade;


                SessionWrapper.u_hris_manager_text = edituser.Hris_manager_text;
                SessionWrapper.u_hris_supervisor_text = edituser.Hris_supervisor_text;
                SessionWrapper.u_hris_mentor_text = edituser.Hris_mentor_text;
                SessionWrapper.u_hris_alternate_manager_text = edituser.Hris_Alternate_manager_text;
                SessionWrapper.u_hris_alternate_supervisor_text = edituser.Hris_alternate_supervisor_text;
                SessionWrapper.u_hris_alternate_mentor_text = edituser.Alternate_mentor_text;

                SessionWrapper.u_hris_manager_id_fk = edituser.Hris_manager_id;
                SessionWrapper.u_hris_alternate_manager_id_fk = edituser.Hris_Alternate_manager_id;
                SessionWrapper.u_hris_mentor_id_fk = edituser.Hris_mentor_id;
                SessionWrapper.u_hris_alternate_mentor_id_fk = edituser.Alternate_mentor_id;
                SessionWrapper.u_hris_supervisor_id_fk = edituser.Hris_supervisor_id;
                SessionWrapper.u_hris_alternate_supervisor_id_fk = edituser.Hris_alternate_supervisor_id;

                chkEmployee.Checked = edituser.sr_is_employee;
                chkManager.Checked = edituser.sr_is_manager;
                chkCompliance.Checked = edituser.sr_is_compliance;
                chkInstructor.Checked = edituser.sr_is_instructor;
                chkTrainig.Checked = edituser.sr_is_training;
                chkAdministrator.Checked = edituser.sr_is_administrator;
                chkSystemadmin.Checked = edituser.sr_is_system_admin;
                chkComplianceApprover.Checked = edituser.sr_is_compliance_approver;
                txtCustom01.Text = edituser.Custom_01;
                txtCustom02.Text = edituser.Custom_02;
                txtCustom03.Text = edituser.Custom_03;
                txtCustom04.Text = edituser.Custom_04;
                txtCustom05.Text = edituser.Custom_05;
                txtCustom06.Text = edituser.Custom_06;
                txtCustom07.Text = edituser.Custom_07;
                txtCustom08.Text = edituser.Custom_08;
                txtCustom09.Text = edituser.Custom_09;
                txtCustom10.Text = edituser.Custom_10;
                txtCustom11.Text = edituser.Custom_11;
                txtCustom12.Text = edituser.Custom_12;
                txtCustom13.Text = edituser.Custom_13;
                chkRehire.Checked = edituser.u_hris_is_rehire;
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
        protected void btnGenerate_Click(object sender, EventArgs e)
        {

        }
        protected void btnSaveuserinfo_header_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            User updateuser = new User();
            /// <summary>
            /// Hash encryption for username and password
            /// </summary>
            HashEncryption encHash = new HashEncryption();
            updateuser.Password_enc_ash = encHash.GenerateHashvalue(txtPassword_login.Value, true);
            updateuser.Username_enc_ash = encHash.GenerateHashvalue(txtUsername_login.Text, true);
            /// <summary>
            /// Salt encryption for password
            /// </summary>
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
            updateuser.Password_enc_salt = rijndaelKey.Encrypt(txtPassword_login.Value);
            //End
            //updateuser.u_current_username = SecurityCenter.DecryptText(Request.QueryString["id"]);
            updateuser.Userid = SecurityCenter.DecryptText(Request.QueryString["id"]);

            updateuser.Firstname = txtFirstName.Text;
            updateuser.Middlename = txtMiddelName.Text;
            updateuser.Lastname = txtLastName.Text;
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
            updateuser.DomainId = ddlUserdomain.SelectedValue;
            updateuser.LocaleId = ddlLocale.SelectedValue;
            updateuser.TimezoneId = ddlTimezone.SelectedValue;
            updateuser.Usertype = ddlUserTypes.SelectedValue;

            //user creation type
            updateuser.creation_type = ddlUserTypes.SelectedValue;
            //End
            updateuser.Active_status_flag = ddlUserstatus.SelectedItem.Text;
            updateuser.Active_Type = ddlUserstatus.SelectedValue;
            updateuser.Hris_employeid = txtEmployeeid.Text;
            updateuser.Hris_employee_type = ddlEmployeeType.SelectedValue;


            DateTime? dtHiredate = null;
            DateTime tempHireDate;
            if (DateTime.TryParseExact(txtHiredate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempHireDate))
            {
                dtHiredate = tempHireDate;
            }

            //if (DateTime.TryParse(txtHiredate.Text, out tempHireDate))
            //{
            //    dtHiredate = tempHireDate;
            //}
            //if (txtHiredate.Text != string.Empty)
            //{
                updateuser.Hris_hire_date = dtHiredate;
            //}

            DateTime? txtLastrehiredate = null;
            DateTime tempLastrehiredate;

            if (DateTime.TryParseExact(txtLastrehire.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempLastrehiredate))
            {
                txtLastrehiredate = tempLastrehiredate;
            }
            //if (DateTime.TryParse(txtLastrehire.Text, out tempLastrehiredate))
            //{
            //    txtLastrehiredate = tempLastrehiredate;
            //}

            updateuser.Hris_last_rehire_date = txtLastrehiredate;

            updateuser.Hris_company = txtCompany.Text;
            updateuser.Hris_region = txtRegion.Text;
            updateuser.Hris_division = txtDivision.Text;
            updateuser.Hris_department = txtDepartment.Text;
            updateuser.Hris_cost_center = txtcostcenter.Text;
            updateuser.Hris_job_group = txtJobgroup.Text;
            updateuser.Hris_job_code = txtJobcode.Text;
            updateuser.Hris_job_title = txtJobtitle.Text;
            updateuser.Hris_job_position = txtJobPosition.Text;
            updateuser.Hris_pay_grade = txtPayGrade.Text;
            //questions
            updateuser.Hris_manager_id = SessionWrapper.u_hris_manager_id_fk;
            updateuser.Hris_supervisor_id = SessionWrapper.u_hris_supervisor_id_fk;
            updateuser.Hris_Alternate_manager_id = SessionWrapper.u_hris_alternate_manager_id_fk;
            updateuser.Hris_alternate_supervisor_id = SessionWrapper.u_hris_alternate_supervisor_id_fk;
            updateuser.Hris_mentor_id = SessionWrapper.u_hris_mentor_id_fk;
            updateuser.Alternate_mentor_id = SessionWrapper.u_hris_alternate_mentor_id_fk;
            //End
            updateuser.sr_is_employee = chkEmployee.Checked;
            updateuser.sr_is_manager = chkManager.Checked;
            updateuser.sr_is_compliance = chkCompliance.Checked;
            updateuser.sr_is_instructor = chkInstructor.Checked;
            updateuser.sr_is_training = chkTrainig.Checked;
            updateuser.sr_is_administrator = chkAdministrator.Checked;
            updateuser.sr_is_system_admin = chkSystemadmin.Checked;
            updateuser.sr_is_compliance_approver = chkComplianceApprover.Checked;
            updateuser.Custom_01 = txtCustom01.Text;
            updateuser.Custom_02 = txtCustom02.Text;
            updateuser.Custom_03 = txtCustom03.Text;
            updateuser.Custom_04 = txtCustom04.Text;
            updateuser.Custom_05 = txtCustom05.Text;
            updateuser.Custom_06 = txtCustom06.Text;
            updateuser.Custom_07 = txtCustom07.Text;
            updateuser.Custom_08 = txtCustom08.Text;
            updateuser.Custom_09 = txtCustom09.Text;
            updateuser.Custom_10 = txtCustom10.Text;
            updateuser.Custom_11 = txtCustom11.Text;
            updateuser.Custom_12 = txtCustom12.Text;
            updateuser.Custom_13 = txtCustom13.Text;
            updateuser.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Value);

            updateuser.u_hris_is_rehire = chkRehire.Checked;

           
            try
            {
                int result = UserBLL.UpdateUserInfo(updateuser);
                if (result != -2)
                {

                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    lblSuccessMessage.Text = LocalResources.GetText("app_succ_update_text");
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                }
                else
                {
                    HtmlGenericControl divSuccess = (HtmlGenericControl)Master.FindControl("success_login");
                    divSuccess.Style.Add("display", "none");
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    //error_msg.InnerHtml = "Username is already exists.";
                    txtUsername_login.Text = "";
                    txtPassword_login.Value = "";
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
                        Logger.WriteToErrorLog("saeu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeu-01", ex.Message);
                    }
                }
            }

        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
        }

        protected void btnsaveuserinfo_footer_Click(object sender, EventArgs e)
        {
            btnSaveuserinfo_header_Click(sender, e);

        }

        protected void btncancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
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
                        Logger.WriteToErrorLog("saeu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeu-01", ex.Message);
                    }
                }
            }


            lblRemoveFristName2.Text = SessionWrapper.u_firstname;
            lblRemoveLastName2.Text = SessionWrapper.u_lastname;
            lblRemoveMiddleName2.Text = SessionWrapper.u_middlename;
            mpeRemove.Show();

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

            if (!string.IsNullOrEmpty((string)ViewState["removesupervisor"]))
            {
                lblSupervisor.Text = "";
                ViewState["removesupervisor"] = "";
                btnSupervisor.Style.Add("display", "inline");
                btnRemoveSupervisor.Style.Add("display", "none");
                SessionWrapper.u_hris_supervisor_text = "";
                SessionWrapper.u_hris_supervisor_id_fk = "";

            }
            if (!string.IsNullOrEmpty((string)ViewState["removementor"]))
            {
                lblMentor.Text = "";
                ViewState["removementor"] = "";
                btnMentor.Style.Add("display", "inline");
                btnRemoveMentor.Style.Add("display", "none");
                SessionWrapper.u_hris_mentor_text = "";
                SessionWrapper.u_hris_mentor_id_fk = "";

            }
            if (!string.IsNullOrEmpty((string)ViewState["removealtmanager"]))
            {
                lblAltManager.Text = "";
                ViewState["removealtmanager"] = "";
                btnAltManager.Style.Add("display", "inline");
                btnRemoveAltManager.Style.Add("display", "none");
                SessionWrapper.u_hris_alternate_manager_text = "";
                SessionWrapper.u_hris_alternate_manager_id_fk = "";

            }
            if (!string.IsNullOrEmpty((string)ViewState["removealtsupervisor"]))
            {
                lblAltSupervisor.Text = "";
                ViewState["removealtsupervisor"] = "";
                btnAltSupervisor.Style.Add("display", "inline");
                btnRemoveAltSupervisor.Style.Add("display", "none");
                SessionWrapper.u_hris_alternate_supervisor_text = "";
                SessionWrapper.u_hris_alternate_supervisor_id_fk = "";

            }
            if (!string.IsNullOrEmpty((string)ViewState["removealtmentor"]))
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

       
        private void ClearHrisViewstate()
        {
            ViewState["removemanager"] = "";
            ViewState["removesupervisor"] = "";
            ViewState["removementor"] = "";
            ViewState["removealtmanager"] = "";
            ViewState["removealtsupervisor"] = "";
            ViewState["removealtmentor"] = "";
        }
        protected void btnReset_header_Click(object sender, EventArgs e)
        {
            ResetUser();
        }

        protected void btnreset_footer_Click(object sender, EventArgs e)
        {
            ResetUser();
        }
        private void ResetUser()
        {
            populateuserinfo(userid);
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
        private void ShowandHideHrisButton()
        {
            if (!string.IsNullOrEmpty(lblManager.Text))
            {
                btnManager.Style.Add("display", "none");
                btnManagerRemove.Style.Add("display", "inline");

            }
            else
            {
                btnManager.Style.Add("display", "inline");
                btnManagerRemove.Style.Add("display", "none");
            }
            if (!string.IsNullOrEmpty(lblSupervisor.Text))
            {
                btnSupervisor.Style.Add("display", "none");
                btnRemoveSupervisor.Style.Add("display", "inline");

            }
            else
            {
                btnSupervisor.Style.Add("display", "inline");
                btnRemoveSupervisor.Style.Add("display", "none");
            }
            if (!string.IsNullOrEmpty(lblMentor.Text))
            {
                btnMentor.Style.Add("display", "none");
                btnRemoveMentor.Style.Add("display", "inline");

            }
            else
            {
                btnMentor.Style.Add("display", "inline");
                btnRemoveMentor.Style.Add("display", "none");

            }
            if (!string.IsNullOrEmpty(lblAltManager.Text))
            {
                btnAltManager.Style.Add("display", "none");

                btnRemoveAltManager.Style.Add("display", "inline");

            }
            else
            {
                btnAltManager.Style.Add("display", "inline");

                btnRemoveAltManager.Style.Add("display", "none");
            }
            if (!string.IsNullOrEmpty(lblAltSupervisor.Text))
            {
                btnAltSupervisor.Style.Add("display", "none");
                btnRemoveAltSupervisor.Style.Add("display", "inline");

            }
            else
            {
                btnAltSupervisor.Style.Add("display", "inline");
                btnRemoveAltSupervisor.Style.Add("display", "none");

            }
            if (!string.IsNullOrEmpty(lblAltMentor.Text))
            {
                btnAltMentor.Style.Add("display", "none");
                btnRemoveAltMentor.Style.Add("display", "inline");

            }
            else
            {
                btnAltMentor.Style.Add("display", "inline");
                btnRemoveAltMentor.Style.Add("display", "none");

            }
        }

    }
}