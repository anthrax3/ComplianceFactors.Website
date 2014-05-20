using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Compliance.MIRIS.Controls;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance.MIRIS
{
    public partial class cemv_01 : System.Web.UI.Page
    {
        string edit = "";
        #region "Private Member Variables"
        private string _path = "~/Compliance/MIRIS/Upload/Witness/";
        private string _pathPolice = "~/Compliance/MIRIS/Upload/Police/";
        private string _pathPhoto = "~/Compliance/MIRIS/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/MIRIS/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/MIRIS/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/MIRIS/Upload/EmployeeInterview/";

        #endregion
        private int vCount = 0;

        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;<a href=/Compliance/MIRIS/cccmiris-01.aspx>" + LocalResources.GetGlobalLabel("app_giris_text") + "</a>&nbsp;" + ">&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_case_mv_text") + "</a>";
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["Edit"])))
                {
                    edit = SecurityCenter.DecryptText(Request.QueryString["Edit"]);
                }

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                {
                    trAddEstablishment.Visible = true;

                }
                if (!IsPostBack)
                {
                    PopulateYearDropDown();
                    try
                    {

                        imgCourse.AlternateText = "plus";
                        imgdamagedesc.AlternateText = "plus";
                        imgPublicVehicle.AlternateText = "plus";
                        imgpublicdamage.AlternateText = "plus";
                        imgPedestrain.AlternateText = "plus";
                        imgBicycleIncident.AlternateText = "plus";
                        imgfixedobject.AlternateText = "plus";
                        imganimalincident.AlternateText = "plus";
                        //case category
                        ddlCaseCategory.DataSource = ComplianceBLL.GetMirisCaseCategory(SessionWrapper.CultureName, "ccemiris-01");
                        ddlCaseCategory.DataBind();

                        //case Type
                        ddlCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                        ddlCaseTypes.DataBind();

                        //case status
                        ddlCaseStatus.DataSource = ComplianceBLL.GetMirisCaseStatus(SessionWrapper.CultureName, "ccemiris-01");
                        ddlCaseStatus.DataBind();

                        //Compliance Approver
                        ddlComplianceApprover.DataSource = UserBLL.GetComplianceApproverList();
                        ddlComplianceApprover.DataBind();
                        //case outcome
                        //ddlCaseOutCome.DataSource = ComplianceBLL.GetMirisCaseOutCome();
                        //ddlCaseOutCome.DataBind();

                        //if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                        //{
                        //    hdnIsCompliance.Value = "1";
                        //}
                        //else
                        //{
                        //    hdnIsCompliance.Value = "0";
                        //}

                        //illness
                        // ddlTypeOfIllness.DataSource = ComplianceBLL.GetMirisCaseIllness();
                        //ddlTypeOfIllness.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }

                    btnViewCaseDesc_header.OnClientClick = "window.open('cvmv-01.aspx?View=" + SecurityCenter.EncryptText(edit) + "','',''); return true;";
                    btnViewCase_footer.OnClientClick = "window.open('cvmv-01.aspx?View=" + SecurityCenter.EncryptText(edit) + "','',''); return true;";
                    if (!string.IsNullOrEmpty(Request.QueryString["Succ"]))
                    {
                        success_msg.Style.Add("display", "block");
                        success_msg.InnerHtml = LocalResources.GetText("app_case_create_succ_text");
                    }
                    try
                    {
                        ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                        ddlTimezone.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                    SessionWrapper.session_witness = null;
                    SessionWrapper.session_EmployeeInterview = null;
                    SessionWrapper.session_ExtenuatingCondition = null;
                    SessionWrapper.session_Photo = null;
                    SessionWrapper.session_PoliceReport = null;
                    SessionWrapper.session_SceneSketch = null;
                    SessionWrapper.session_vehicle_values = null;
                    //IncidentTime.Date = DateTime.Now;
                    populatecase(edit);

                    if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                    {
                        if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["cid"])))
                        {
                            ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["cid"]);
                        }
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["id"])))
                        {
                            lblCaseNumber.Text = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        }
                    }

                    try
                    {
                        ComplianceDAO miris = new ComplianceDAO();
                        miris.c_case_id_pk = edit;
                        miris.s_locale_culture = SessionWrapper.CultureName;

                        //witness
                        DataTable dtGetWitness = new DataTable();
                        dtGetWitness = ComplianceBLL.GetWitness(miris);
                        this.gvAddWitness.DataSource = dtGetWitness;
                        this.gvAddWitness.DataBind();

                        //photo
                        DataTable dtGetPhoto = new DataTable();
                        dtGetPhoto = ComplianceBLL.Getphoto(miris);
                        this.gvPhoto.DataSource = dtGetPhoto;
                        this.gvPhoto.DataBind();

                        //police report
                        DataTable dtGetPoliceReport = new DataTable();
                        dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                        this.gvPoliceReport.DataSource = dtGetPoliceReport;
                        this.gvPoliceReport.DataBind();

                        //SceneSketch
                        DataTable dtGetSceneSketch = new DataTable();
                        dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                        this.gvSceneSketch.DataSource = dtGetSceneSketch;
                        this.gvSceneSketch.DataBind();

                        //Extenautingcondition
                        DataTable dtGetExtenautingCondition = new DataTable();
                        dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                        this.gvExtenuatingcondition.DataSource = dtGetExtenautingCondition;
                        this.gvExtenuatingcondition.DataBind();

                        //EmployeeInterview
                        DataTable dtGetEmployeeInterview = new DataTable();
                        dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                        this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                        this.gvEmployeeInterview.DataBind();

                        //Vehicle Information
                        DataTable dtVehicleCount = new DataTable();
                        dtVehicleCount = ComplianceBLL.GetVehicleValues(edit);

                        ltlVehicleCount.Text = Convert.ToString(dtVehicleCount.Rows.Count);

                        DataTable dtVehicle = new DataTable();
                        dtVehicle = ComplianceBLL.GetVehicleValuesForReset(edit);



                        SessionWrapper.session_vehicle_values = dtVehicle;

                        SessionWrapper.session_witness = dtGetWitness;
                        SessionWrapper.session_Photo = dtGetPhoto;
                        SessionWrapper.session_PoliceReport = dtGetPoliceReport;
                        SessionWrapper.session_SceneSketch = dtGetSceneSketch;
                        SessionWrapper.session_ExtenuatingCondition = dtGetExtenautingCondition;
                        SessionWrapper.session_EmployeeInterview = dtGetEmployeeInterview;
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
                AddCaseTypeControl();
                AddAndRemoveVehicle();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
            if (Session["Case_Employee"] != null)
            {
                User user = (User)Session["Case_Employee"];
                txtEmployeeName.Text = user.Firstname;
                txtLastName.Text = user.Firstname;
                if (!string.IsNullOrEmpty(user.u_social_security_no))
                {
                    txtLastFourDigitOfSSN.Text = user.u_social_security_no.Substring(user.u_social_security_no.Length - 4, 4);
                }
                else
                {
                    txtLastFourDigitOfSSN.Text = "";
                }
                ddlHireMonth.SelectedValue = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Month.ToString() : "";
                ddlHireYear.SelectedValue = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Year.ToString() : "-1";
                doh_hire_day.SelectedIndex = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Day : 0;
                txtEmployeeId.Text = user.Hris_employeid;
                Session["Case_Employee"] = null;
            }
        }

        private void AddCaseTypeControl()
        {
            ComplianceDAO mirisCasteType = new ComplianceDAO();
            uccb_01 CaseControl = (uccb_01)LoadControl("../MIRIS/Controls/uccb-01.ascx");
            CaseControl.ID = "ucCaseControl1";
            CaseTypePanel.Controls.Add(CaseControl);
            mirisCasteType = ComplianceBLL.GetCaseMV(edit);
            CaseControl.show(mirisCasteType.c_case_type_fk);
        }

        private void AddAndRemoveVehicle()
        {
            int vehicleCount = Convert.ToInt16(ltlVehicleCount.Text);
            if (vehicleCount >= 8)
            {
                int ControlID = 0;
                for (int i = 1; i <= 8; i++)
                {
                    ucmv_01 vehicleUserControl = (ucmv_01)LoadControl("../MIRIS/Controls/ucmv-01.ascx");
                    string vehicleNumber = string.Empty;
                    if (i == 8)
                    {
                        vehicleNumber = "10";
                    }
                    else
                    {
                        vehicleNumber = "0" + Convert.ToString(i + 2);
                    }

                    List<ComplainceVehicle> compliance = ComplianceBLL.GetVehicle(edit, vehicleNumber);

                    vehicleUserControl.ddlVehicle = compliance[0].vehicle_fk.ToString();
                    vehicleUserControl.VechicleId = compliance[0].vehicle_id.ToString();
                    vehicleUserControl.VehicleMake = compliance[0].vehicle_make.ToString();
                    vehicleUserControl.VehicleModel = compliance[0].vehicle_model.ToString();
                    vehicleUserControl.VIN = compliance[0].vehicle_vin.ToString();
                    vehicleUserControl.ddlType = compliance[0].vehicle_type.ToString();
                    vehicleUserControl.Year = compliance[0].vehicle_year.ToString();
                    vehicleUserControl.State = compliance[0].vehicle_state.ToString();
                    vehicleUserControl.LicenseNumber = compliance[0].vehicle_licence.ToString();

                    vehicleUserControl.lblVechicle = "Vehicle " + vehicleNumber;
                    while (InDeletedVechicleControl("ucVehicleUserControl" + ControlID) == true)
                    {
                        ControlID += 1;
                    }
                    vehicleUserControl.ID = "ucVehicleUserControl" + ControlID;
                    vehicleUserControl.RemoveVehicleUserControl += new EventHandler(HandleRemoveUserControl);
                    VehiclePanel.Controls.Add(vehicleUserControl);
                    ControlID += 1;
                }
                success_msg.Style.Add("display", "none");
                //error_vehicle.Style.Add("display", "block");
                //error_vehicle.InnerText = "Sorry,Only 10 vehicle allowed";
            }
            else
            {
                int nbc = 0;
                Control c = GetPostBackControl(Page);
                if ((c != null))
                {
                    //If the add button was clicked, increase the count to let the page know we want
                    //to display an additional user control
                    if (c.ID.ToString() == "btnAddVechicle")
                    {
                        vehicleCount = Convert.ToInt16(ltlVehicleCount.Text);
                        ltlVehicleCount.Text = Convert.ToString(vehicleCount + 1);
                    }

                }
                int ControlID = 0;
                if (nbc != 0)
                {
                    //Since these are dynamic user controls, re-add them every time the page loads.
                    vCount = (Convert.ToInt16(ltlVehicleCount.Text) + nbc);
                    for (int i = 1; i <= vCount; i++)
                    {
                        ucmv_01 VehicleUserControl = (ucmv_01)LoadControl("../MIRIS/Controls/ucmv-01.ascx");
                        VehicleUserControl.ID = "ucVehicleUserControl" + ControlID;
                        VehiclePanel.Controls.Add(VehicleUserControl);
                        ControlID += 1;
                    }
                }
                else
                {
                    vCount = (Convert.ToInt16(ltlVehicleCount.Text)) + Convert.ToInt32(vCount);

                    for (int i = 1; i <= (vCount); i++)
                    {
                        ucmv_01 vehicleUserControl = (ucmv_01)LoadControl("../MIRIS/Controls/ucmv-01.ascx");
                        string vehicleNumber = string.Empty;
                        if (i == 8)
                        {
                            vehicleNumber = "10";
                        }
                        else
                        {
                            vehicleNumber = "0" + Convert.ToString(i + 2);
                        }

                        List<ComplainceVehicle> compliance = ComplianceBLL.GetVehicle(edit, vehicleNumber);

                        vehicleUserControl.ddlVehicle = compliance[0].vehicle_fk.ToString();
                        vehicleUserControl.VechicleId = compliance[0].vehicle_id.ToString();
                        vehicleUserControl.VehicleMake = compliance[0].vehicle_make.ToString();
                        vehicleUserControl.VehicleModel = compliance[0].vehicle_model.ToString();
                        vehicleUserControl.VIN = compliance[0].vehicle_vin.ToString();
                        vehicleUserControl.ddlType = compliance[0].vehicle_type.ToString();
                        vehicleUserControl.Year = compliance[0].vehicle_year.ToString();
                        vehicleUserControl.State = compliance[0].vehicle_state.ToString();
                        vehicleUserControl.LicenseNumber = compliance[0].vehicle_licence.ToString();

                        while (InDeletedVechicleControl("ucVehicleUserControl" + ControlID) == true)
                        {
                            ControlID += 1;
                        }
                        vehicleUserControl.ID = "ucVehicleUserControl" + ControlID;
                        vehicleUserControl.lblVechicle = "Vehicle " + vehicleNumber;

                        //Add an event handler to this control to raise an event when the delete button is clicked
                        //on the user control
                        vehicleUserControl.RemoveVehicleUserControl += new EventHandler(HandleRemoveUserControl);
                        //ChannelizedFrequencyBandUserControl.RemoveChannelizedFrequencyBand += this.HandleRemoveChannelizedFrequencyBand;
                        //Finally, add the user control to the panel
                        VehiclePanel.Controls.Add(vehicleUserControl);
                        //Increment the control id for the next round through the loop
                        ControlID += 1;
                    }

                }
            }
        }

        private bool InDeletedVechicleControl(string ControlID)
        {
            //Determine if the passed in user control id has been stored in the list of controls that
            //were previously deleted off the page
            string[] DeletedList = ltlRemoved.Text.Split('|');
            for (int i = 0; i <= DeletedList.GetLength(0) - 1; i++)
            {
                if (ControlID.ToLower() == DeletedList[i].ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public void HandleRemoveUserControl(object sender, EventArgs e)
        {
            Button but = sender as Button;
            ucmv_01 DynamicUserControl = (ucmv_01)but.Parent;
            VehiclePanel.Controls.Remove(DynamicUserControl);

            string lblValue = DynamicUserControl.lblVechicle;
            string countvalue = lblValue.Substring(lblValue.Length - 2, 2);

            //lblValue = lblValue.Replace("Vehicle", "");
            lblValue = lblValue.Replace(countvalue, "");
            int count = Convert.ToInt16(countvalue) - 3;

            if (count == 0)
            {
                count = 1;
            }
            for (int i = count; i < VehiclePanel.Controls.Count; i++)
            {
                ucmv_01 ucvehicle = (ucmv_01)VehiclePanel.Controls[i];
                if (i == 8)
                {
                    ucvehicle.lblVechicle = lblValue + "10";
                }
                else
                {
                    ucvehicle.lblVechicle = lblValue + "0" + Convert.ToInt16(i + 2);
                }
            }
            UpdateCase(ddlCaseStatus.SelectedValue);
            success_msg.Style.Add("display", "none");
            ltlRemoved.Text += DynamicUserControl.ID + "|";
            ltlVehicleCount.Text = (Convert.ToInt16(ltlVehicleCount.Text) - 1).ToString();
        }
        public Control GetPostBackControl(Page page)
        {
            Control control = null;
            foreach (string ctl in page.Request.Form)
            {
                if (ctl != null)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            //End If
            return control;
        }
        protected void btnViewCase_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit));
        }

        protected void btnCancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }



        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }
        /// <summary>
        /// Populate Motor vehicle Case
        /// </summary>
        /// <param name="caseid"></param>
        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCaseMV(edit);

                ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(miris.c_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblCaseNumber.Text = miris.c_case_number;
                txtCaseTitle.Text = miris.c_case_title;
                ddlCaseCategory.SelectedValue = miris.c_case_category_value;
                //ViewState["CaseCategory"] = ddlCaseCategory.SelectedValue;
                //ddlCaseTypes.SelectedValue = miris.c_case_type_value;
                ddlCaseStatus.SelectedValue = miris.c_case_status_value;
                //uccb1.show(miris.c_case_type_fk);

                txtEmployeeName.Text = miris.c_employee_name;
                txtLastName.Text = miris.c_employee_last_name;
                txtLastFourDigitOfSSN.Text = miris.c_ssn;



                dob_day.SelectedIndex = miris.c_employee_dob.Day;
                ddlMonth.SelectedValue = miris.c_employee_dob.Month.ToString();
                ddlYear.SelectedValue = miris.c_employee_dob.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "dob", "checkdateofbirth();", true);

                doh_hire_day.SelectedIndex = miris.c_employee_hire_date.Day;
                ddlHireMonth.SelectedValue = miris.c_employee_hire_date.Month.ToString();
                ddlHireYear.SelectedValue = miris.c_employee_hire_date.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "hiredate", "checkhiredate();", true);

                //txtDateOfBirth.Text = Convert.ToDateTime(miris.c_employee_dob, culture).ToString("MM/dd/yyyy");
                //txtEmployeHireDate.Text = Convert.ToDateTime(miris.c_employee_hire_date, culture).ToString("MM/dd/yyyy");
                txtEmployeeId.Text = miris.c_employee_id;
                if (miris.c_date_in_title.HasValue)
                {
                    doh_date_in_time_day.SelectedIndex = miris.c_date_in_title.Value.Day;
                    ddlDateInTitleMonth.SelectedValue = miris.c_date_in_title.Value.Month.ToString();
                    ddlDateInTitleYear.SelectedValue = miris.c_date_in_title.Value.Year.ToString();
                }
                txtSupervisor.Text = miris.c_supervisor;
                txtIncidentLocation.Text = miris.c_incident_location;
                txtIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date, culture).ToString("MM/dd/yyyy");
                IncidentTime.Date = miris.c_incident_time;
                IncidentTime.SetTime(miris.incident_HH, miris.incident_MM, IncidentTime.AmPm);

                ddlEmployeeReportLocation.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                {
                    s_establishment_id_pk = "",
                    s_establishment_city = "",
                    s_establishment_name = "",
                    s_establishment_status_id_fk = "app_ddl_active_text"
                });

                ddlEmployeeReportLocation.DataTextField = "s_establishment_name";
                ddlEmployeeReportLocation.DataValueField = "s_establishment_system_id_pk";
                ddlEmployeeReportLocation.DataBind();
                ddlEmployeeReportLocation.Items.Insert(0, new ListItem("", ""));
                ddlEmployeeReportLocation.SelectedValue = miris.c_employee_report_location;

                ddlEstablishment.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                {
                    s_establishment_id_pk = "",
                    s_establishment_city = "",
                    s_establishment_name = "",
                    s_establishment_status_id_fk = "0"
                });

                ddlEstablishment.DataTextField = "s_establishment_name";
                ddlEstablishment.DataValueField = "s_establishment_system_id_pk";
                ddlEstablishment.DataBind();
                ddlEstablishment.Items.Insert(0, new ListItem("", ""));
                ddlEstablishment.SelectedValue = miris.c_establishment;

                txtNote.Text = miris.c_note;

                if (miris.c_company_owned == true)
                {

                    rblCompanyOwned.SelectedValue = "Yes";
                }
                else
                {
                    rblCompanyOwned.SelectedValue = "No";
                }
                // txtRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                // txtCorrectiveActionDetails.Text = miris.c_corrective_action_info;
                //ddlCaseOutCome.SelectedValue = miris.c_osha_300_case_outcome_value;
                //txtDaysAwayFromWork.Text = Convert.ToInt32(miris.c_osha_300_days_away_from_work).ToString();
                //if (!string.IsNullOrEmpty(miris.c_osha_300_date_of_death.ToString()))
                //{
                //    txtDateOfDeath.Text = Convert.ToDateTime(miris.c_osha_300_date_of_death, culture).ToString("MM/dd/yyyy");
                //}
                //ddlTypeOfIllness.SelectedValue = miris.c_osha_300_type_of_illness_value;
                //txtDaysOfRestrictions.Text = Convert.ToInt32(miris.c_osha_300_days_of_restriction).ToString();
                //txtOSHA300info.Text = miris.c_osha_300_info;
                //ddlWorkerGender.SelectedValue = miris.c_osha_301_worker_gender;
                //if (!string.IsNullOrEmpty(miris.c_osha_301_work_start_time.ToString()))
                //{
                //    WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                //    WorkStartTime.SetTime(miris.workstart_HH, miris.workstart_MM, WorkStartTime.AmPm);
                //    //txtWorkStartTime.Text= Convert.ToDateTime(miris.c_osha_301_work_start_time).ToShortDateString();
                //}
                //txtPhysician.Text = miris.c_osha_301_physician;
                //txtTreatMentFacility.Text = miris.c_osha_301_treatment_facilities;
                //chkEmergencyRoom.Checked = miris.c_osha_301_emergency_room;
                //chkHospitalized.Checked = miris.c_osha_301_hospitalized;
                //txtAddress1.Text = miris.c_osha_301_address1;
                //txtAddress2.Text = miris.c_osha_301_address2;
                //txtAddress3.Text = miris.c_osha_301_address3;
                //txtCity.Text = miris.c_osha_301_city;
                //txtState.Text = miris.c_osha_301_state;
                //txtZip.Text = miris.c_osha_301_zip;
                //txtOSHA301Info1.Text = miris.c_osha_301_info_1;
                //txtOSHA301Info2.Text = miris.c_osha_301_info_2;
                //txtOSHA301Info3.Text = miris.c_osha_301_info_3;
                //txtOSHA301Info4.Text = miris.c_osha_301_info_4;
                txtCustom01.Text = miris.c_custom_01;
                txtCustom02.Text = miris.c_custom_02;
                txtCustom03.Text = miris.c_custom_03;
                txtCustom04.Text = miris.c_custom_04;
                txtCustom05.Text = miris.c_custom_05;
                txtCustom06.Text = miris.c_custom_06;
                txtCustom07.Text = miris.c_custom_07;
                txtCustom08.Text = miris.c_custom_08;
                txtCustom09.Text = miris.c_custom_09;
                txtCustom10.Text = miris.c_custom_10;
                txtCustom11.Text = miris.c_custom_11;
                txtCustom12.Text = miris.c_custom_12;
                txtCustom13.Text = miris.c_custom_13;


                ddlVehicle01.SelectedValue = miris.c_case_desc_vehicle_01_fk;
                ddlVehicle02.SelectedValue = miris.c_case_desc_vehicle_02_fk;

                txtVehicleId.Text = miris.c_case_desc_vehicle_id;
                txtVIN.Text = miris.c_case_desc_vehicle_vin;
                txtLicenseNumber.Text = miris.c_case_desc_licence_number;
                txtVehicleMake.Text = miris.c_case_desc_vehicle_make;
                txtVehicleModel.Text = miris.c_case_desc_vehicle_model;
                ddlVehicleType.Text = miris.c_case_desc_vehicle_type_fk;
                txtYear.Text = miris.c_case_desc_year;
                txtState.Text = miris.c_case_desc_state;

                txtVehicleId02.Text = miris.c_case_desc_vehicle_02_id;
                txtVin02.Text = miris.c_case_desc_vehicle_02_vin;
                txtLicenseNumber02.Text = miris.c_case_desc_licence_02_number;
                txtVehicleMake02.Text = miris.c_case_desc_vehicle_02_make;
                txtModel02.Text = miris.c_case_desc_vehicle_02_model;
                ddlVehicleType02.Text = miris.c_case_desc_vehicle_02_type_fk;
                txtYear02.Text = miris.c_case_desc_vehicle_02_year;
                txtState02.Text = miris.c_case_desc_vehicle_02_state;


                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_type_fk))
                //{
                //    ltlVehicleCount.Text = "1";
                //}                

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_type_fk))
                //{
                //    ltlVehicleCount.Text = "2";
                //}                

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_type_fk))
                //{
                //    ltlVehicleCount.Text = "3";
                //}

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_type_fk))
                //{
                //    ltlVehicleCount.Text = "4";
                //}                

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_type_fk))
                //{
                //    ltlVehicleCount.Text = "5";
                //}                 

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_type_fk))
                //{
                //    ltlVehicleCount.Text = "6";
                //}                

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_type_fk))
                //{
                //    ltlVehicleCount.Text = "7";
                //}               

                //if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_type_fk))
                //{
                //    ltlVehicleCount.Text = "8";
                //}                 

                ddlCompanyVehicleStruck.SelectedValue = miris.c_case_desc_company_vehicle_struck_fk;
                ddlCompanyVehicleStruckBy.SelectedValue = miris.c_case_desc_company_vehicle_struck_by_fk;
                if (miris.c_case_desc_non_collision == true)
                {
                    chkNonCollision.Checked = true;
                    txtNonCollision.Attributes.Add("style", "display:block");
                }
                else
                {
                    chkNonCollision.Checked = false;
                }
                txtNonCollision.Text = miris.c_case_desc_non_collision_text;

                if (miris.c_case_detail_collision_type_fk != "0" || miris.c_case_detail_collision_direction_fk != "0" || miris.c_case_detail_collision_direction_fk != "0")
                {
                    chkNonCollision.Disabled = true;
                }

                txtDriversLic.Text = miris.c_case_detail_drivers_lic;
                txtStateandClass.Text = miris.c_case_detail_state_and_class;
                if (!string.IsNullOrEmpty(miris.c_case_detail_expire_date.ToString()))
                {
                    txtExpireDate.Text = Convert.ToDateTime(miris.c_case_detail_expire_date).ToShortDateString();
                }
                // txtExpireDate.Text = miris.c_case_detail_expire_date.ToShortDateString();
                txtAddress.Text = miris.c_case_detail_address;
                txtCity.Text = miris.c_case_detail_city;
                txtCaseState.Text = miris.c_case_detail_state;
                txtNearestCrossStreet.Text = miris.c_case_detail_nearest_cross_street;
                txtTypeofRoadway.Text = miris.c_case_detail_type_of_roadway;
                ddlRoadCondition.SelectedValue = miris.c_case_detail_road_condition_fk;
                if (!string.IsNullOrEmpty(miris.c_case_detail_time_of_day.ToString()))
                {
                    txtTimeofDay.Text = Convert.ToDateTime(miris.c_case_detail_time_of_day).ToShortTimeString();
                }
                //txtTimeofDay.Text = miris.c_case_detail_time_of_day.ToShortTimeString();
                // here we need to add one column
                ddlWeather.SelectedValue = miris.c_case_detail_weather_fk;
                ddlTrafficCondition.SelectedValue = miris.c_case_detail_traffic_condition_fk;
                ddlTrafficControls.SelectedValue = miris.c_case_detail_traffic_controls_fk;
                txtOperatingSpeed.Text = miris.c_case_detail_oprating_speed;
                txtSpeedLimit.Text = miris.c_case_detail_speed_limit;
                ddlVehicleStruck.SelectedValue = miris.c_case_detail_vehicle_struck_fk;
                ddlVehicleStruckBy.SelectedValue = miris.c_case_detail_vehicle_struck_by_fk;
                ddlCollisionType.SelectedValue = miris.c_case_detail_collision_type_fk;
                ddlCollisionLocation.SelectedValue = miris.c_case_detail_collision_location_fk;
                ddlCollisionDirection.SelectedValue = miris.c_case_detail_collision_direction_fk;
                ddlNonCollisionType.SelectedValue = miris.c_case_detail_non_collision_type_fk;
                txtNumberofVehicleInvolved.Text = miris.c_case_detail_number_of_vehicle_involved;
                txtNumberofVehicletowed.Text = miris.c_case_detail_number_of_vehicle_towed;
                txtNoofPeopleInjured.Text = miris.c_case_detail_number_of_people_injured;

                if (miris.c_case_detail_cituation_issued == true)
                {
                    rblCituationIssued.SelectedValue = "Yes";
                }
                else
                {
                    rblCituationIssued.SelectedValue = "No";
                }
                txtAtWhom.Text = miris.c_case_detail_at_whom;
                if (miris.c_case_detail_at_fault == true)
                {

                    rblAtfault.SelectedValue = "Yes";
                }
                else
                {
                    rblAtfault.SelectedValue = "No";
                }
                if (miris.c_case_detail_contributory == true)
                {

                    rblContributory.SelectedValue = "Yes";
                }
                else
                {
                    rblContributory.SelectedValue = "No";
                }

                txtGrossVehicleWeight.Text = miris.c_case_detail_gross_vehicle_weight;
                txtCombinedGrossVehicleWeight.Text = miris.c_case_detail_combined_gross_vehicle_weight;
                if (miris.c_case_detail_dot_vehicle == true)
                {
                    rblDotVehicle.SelectedValue = "Yes";
                }
                else
                {
                    rblDotVehicle.SelectedValue = "No";
                }
                if (miris.c_case_detail_dot_driver == true)
                {
                    rblDotDriver.SelectedValue = "Yes";
                }
                else
                {
                    rblDotDriver.SelectedValue = "No";
                }
                if (miris.c_case_detail_seat_belt_used == true)
                {
                    rblSeatBeltUsed.SelectedValue = "Yes";
                }
                else
                {
                    rblSeatBeltUsed.SelectedValue = "No";
                }
                if (miris.c_case_detail_air_bag_eqiupped == true)
                {
                    rblAirbagEquipped.SelectedValue = "Yes";
                }
                else
                {
                    rblAirbagEquipped.SelectedValue = "No";
                }
                if (miris.c_case_detail_air_bag_deployed == true)
                {
                    rblAirBagDeployed.SelectedValue = "Yes";
                }
                else
                {
                    rblAirBagDeployed.SelectedValue = "No";
                }
                if (miris.c_case_detail_cellphone_in_use == true)
                {
                    rblCellphoneinUse.SelectedValue = "Yes";
                }
                else
                {
                    rblCellphoneinUse.SelectedValue = "No";
                }
                if (miris.c_case_detail_computer_in_use == true)
                {
                    rblComputerInUse.SelectedValue = "Yes";
                }
                else
                {
                    rblComputerInUse.SelectedValue = "No";
                }
                if (miris.c_case_detail_special_equipment == true)
                {
                    rblSpecialEquipment.SelectedValue = "Yes";
                }
                else
                {
                    rblSpecialEquipment.SelectedValue = "No";
                }



                txtSpecialEquibment.Text = miris.c_case_detail_special_equipment_text;
                ddlLocationofImpact.SelectedValue = miris.c_case_detail_location_of_impact_fk;
                if (miris.c_case_detail_driver_injured == true)    // need to add some fields
                {
                    rblDriverInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblDriverInjured.SelectedValue = "No";
                }
                if (miris.c_case_detail_passenger_injured == true)    // need to add some fields
                {
                    rblPassengerInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                }

                txtHeavyDamage.InnerText = miris.c_case_detail_damage_heavy;
                txtModerateDamage.InnerText = miris.c_case_detail_damage_moderate;
                txtLightDamage.InnerText = miris.c_case_detail_damage_light;

                if (miris.c_case_desc_was_fatality == true)
                {
                    rblFatality.SelectedValue = "Yes";
                    lblNumberofFatilities.Attributes.Add("style", "display:block");
                    txtNoofPeopleKilled.Attributes.Add("style", "display:block");
                    txtNoofPeopleKilled.Text = miris.c_case_detail_number_of_people_killed;
                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                }
                if (miris.c_case_desc_public_vehicle_involved == true)
                {
                    rblPublicVehicleInvolved.SelectedValue = "Yes";
                    div_public_vehicle_info.Attributes.Add("Style", "Display:block");
                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                    div_public_vehicle_info.Attributes.Add("Style", "Display:none");
                }


                txtDriverName.Text = miris.c_pub_vehicle_driver_name;
                txtDriverAddress.Text = miris.c_pub_vehicle_driver_address;
                txtDriverContact.Text = miris.c_pub_vehicle_driver_contact;
                txtOwnerName.Text = miris.c_pub_vehicle_owner_name;
                txtOwnerAddress.Text = miris.c_pub_vehicle_owner_address;
                txtOwnerContact.Text = miris.c_pub_vehicle_owner_contact;
                txtPublicVehicleID.Text = miris.c_pub_vehicle_vehicle_id;
                txtPublicVehicleVIN.Text = miris.c_pub_vehicle_vehicle_vin;
                txtPublicLicenseNumber.Text = miris.c_pub_vehicle_licence_number;
                txtPublicVehicleMake.Text = miris.c_pub_vehicle_vehicle_make;
                txtPublicVehicleModel.Text = miris.c_pub_vehicle_vehicle_model;
                ddlPublicVehicleType.SelectedValue = miris.c_pub_vehicle_vehicle_type_fk;
                txtPublicYear.Text = miris.c_pub_vehicle_year;
                txtPublicState.Text = miris.c_pub_vehicle_state;
                txtPublicGrossWeight.Text = miris.c_pub_vehicle_gross_vehicle_weight;
                txtPublicCombinedVehicleWeight.Text = miris.c_pub_vehicle_combined_gross_vehicle_weight;
                if (miris.c_pub_vehicle_dot_vehicle == true)
                {
                    rblPublicDotVehicle.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicDotVehicle.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_dot_driver == true)
                {
                    rblPublicDotDriver.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicDotDriver.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_seat_belt_used == true)
                {

                    rblPublicSeatBeltUsed.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicSeatBeltUsed.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_air_bag_eqiupped == true)
                {
                    rblPublicAirBagEquipped.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicAirBagEquipped.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_air_bag_deployed == true)
                {
                    rblPublicAirBagDeployed.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicAirBagDeployed.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_cellphone_in_use == true)
                {
                    rblPublicCellphoneinUse.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicCellphoneinUse.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_computer_in_use == true)
                {
                    rblPublicComputerInUse.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicComputerInUse.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_special_equipment == true)
                {
                    rblPublicSpecialEquipment.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicSpecialEquipment.SelectedValue = "No";
                }

                txtPublicSpecialEquipment.Text = miris.c_pub_vehicle_special_equipment_text;
                ddlPublicLocationOfImpact.SelectedValue = miris.c_pub_vehicle_location_of_impact_fk;
                if (miris.c_pub_vehicle_driver_injured == true)// need to add some fields
                {
                    rblPublicDriverInjured.SelectedValue = "Yes";

                    txtPublicDriverInjured.Attributes.Add("style", "display:block");
                }
                else
                {
                    rblPublicDriverInjured.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_passenger_injured == true)// need to add some fields
                {
                    rblPublicPassengerInjured.SelectedValue = "Yes";

                    txtPublicPassengerInjured.Attributes.Add("style", "display:block");
                }
                else
                {
                    rblPublicPassengerInjured.SelectedValue = "No";
                }

                txtPublicPassengerInjured.Text = miris.c_pub_vehicle_passenger_injured_text;
                txtPublicDriverInjured.Text = miris.c_pub_vehicle_driver_injured_text;

                txtTotalvehicleOccupant.Text = miris.c_pub_vehicle_number_of_total_vehicle_injured;
                txtPublicHeavyDamage.InnerText = miris.c_pub_vehicle_damage_heavy; //doubt
                txtPublicModerateDamage.InnerText = miris.c_pub_vehicle_damage_moderate;//doubt
                txtPubliclightDamage.InnerText = miris.c_pub_vehicle_damage_light;//doubt
                //Pedestrain Incident
                txtNameofPedestrian.Text = miris.c_pedestrain_name;
                txtPedestrianAddress.Text = miris.c_pedestrain_address;
                txtPedestrianPhone.Text = miris.c_pedestrain_phone;
                txtPedestrianSex.Text = miris.c_pedestrain_sex;
                txtPedestrainAge.Text = miris.c_pedestrain_age;
                ddlPedestrainCollisionType.SelectedValue = miris.c_pedestrain_collision_type_fk;
                txtPedestrianDescription.InnerText = miris.c_pedestrain_description;
                //BICycle Incident
                txtBicycleNameofPerson.Text = miris.c_bicycle_person_name;
                txtBicyclePersonAddress.Text = miris.c_bicycle_person_address;
                txtBicyclePersonPhone.Text = miris.c_bicycle_person_phone;
                txtBicyblePersonSex.Text = miris.c_bicycle_person_sex;
                txtBicycleAge.Text = miris.c_bicycle_person_age;
                ddlBicycleCollisionType.SelectedValue = miris.c_bicycle_person_collision_type_fk;
                txtBicycleIncidentDesc.InnerText = miris.c_bicycle_person_description;
                //Animal Incident
                txtAnimalName.Text = miris.c_animal_name;
                txtPlace.Text = miris.c_animal_place;
                ddlAnimalCollisionType.SelectedValue = miris.c_animal_collision_type_fk;
                txtAnimalDescription.InnerText = miris.c_animal_description;
                //Fixed Object Incident
                txtPropertyOwner.Text = miris.c_fixed_object_property_name;
                txtPropertyAddress.Text = miris.c_fixed_object_address;
                txtContactInformation.Text = miris.c_fixed_object_contact_info;
                ddlPropertyCollisionType.SelectedValue = miris.c_fixed_object_collision_type_fk;
                txtPropertyDesc.InnerText = miris.c_fixed_object_description;
                txtPhysicalPropertyDesc.InnerText = miris.c_fixed_object_property_description;
                urc1.SearchRac(caseid);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }

        protected void btnUploadWitness_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_path + c_file_guid + c_file_extension));
                    //WITENSS
                    try
                    {
                        ComplianceDAO witness = new ComplianceDAO();
                        witness.s_locale_culture = SessionWrapper.CultureName;
                        witness.c_file_guid = c_file_guid + c_file_extension;
                        witness.c_file_name = c_file_name;
                        witness.c_case_id_pk = edit;
                        witness.c_name = txtName.Text;
                        witness.c_contact_info = txtContactInfo.InnerText;
                        if (!string.IsNullOrEmpty(hdWitness.Value))
                        {
                            witness.c_file_id = hdWitness.Value;
                            witness.s_locale_culture = SessionWrapper.CultureName;
                            ComplianceBLL.UpdateWitnessFile(witness);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdWitness.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertWitness(witness);
                        }
                        txtName.Text = string.Empty;
                        txtContactInfo.Value = string.Empty;
                        //witness
                        DataTable dtGetWitness = new DataTable();
                        dtGetWitness = ComplianceBLL.GetWitness(witness);
                        this.gvAddWitness.DataSource = dtGetWitness;
                        this.gvAddWitness.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        protected void btnUploadPolice_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathPolice + c_file_guid + c_file_extension));
                    try
                    {
                        ComplianceDAO policeReport = new ComplianceDAO();
                        policeReport.c_file_guid = c_file_guid + c_file_extension;
                        policeReport.c_file_name = c_file_name;
                        policeReport.c_case_id_pk = edit;

                        if (!string.IsNullOrEmpty(hdPolice.Value))
                        {
                            policeReport.c_file_id = hdPolice.Value;
                            ComplianceBLL.UpdatePoliceReportFile(policeReport);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdPolice.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertPoliceReport(policeReport);
                        }

                        //police
                        DataTable dtGetPolice = new DataTable();
                        dtGetPolice = ComplianceBLL.GetPoliceReport(policeReport);
                        this.gvPoliceReport.DataSource = dtGetPolice;
                        this.gvPoliceReport.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathPhoto + c_file_guid + c_file_extension));
                    try
                    {
                        ComplianceDAO photo = new ComplianceDAO();
                        photo.c_file_guid = c_file_guid + c_file_extension;
                        photo.c_file_name = c_file_name;
                        photo.c_case_id_pk = edit;
                        if (!string.IsNullOrEmpty(hdPhoto.Value))
                        {
                            photo.c_file_id = hdPhoto.Value;
                            ComplianceBLL.UpdatePhotoFile(photo);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdPhoto.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.Insertphoto(photo);
                        }
                        DataTable dtGetPhoto = new DataTable();
                        dtGetPhoto = ComplianceBLL.Getphoto(photo);
                        this.gvPhoto.DataSource = dtGetPhoto;
                        this.gvPhoto.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        protected void btnUploadSceneSketch_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathSceneSketch + c_file_guid + c_file_extension));
                    try
                    {
                        ComplianceDAO sceneSketch = new ComplianceDAO();
                        sceneSketch.c_file_guid = c_file_guid + c_file_extension;
                        sceneSketch.c_file_name = c_file_name;
                        sceneSketch.c_case_id_pk = edit;

                        if (!string.IsNullOrEmpty(hdSceneSketch.Value))
                        {
                            sceneSketch.c_file_id = hdSceneSketch.Value;
                            ComplianceBLL.UpdateSceneSketchFile(sceneSketch);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdSceneSketch.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertSceneSketch(sceneSketch);
                        }
                        //scenesketch
                        DataTable dtGetSceneSketch = new DataTable();
                        dtGetSceneSketch = ComplianceBLL.GetSceneSketch(sceneSketch);
                        this.gvSceneSketch.DataSource = dtGetSceneSketch;
                        this.gvSceneSketch.DataBind();
                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        protected void btnUploadExtenautingcond_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathExtenuatingcondition + c_file_guid + c_file_extension));
                    try
                    {
                        ComplianceDAO extenautingcond = new ComplianceDAO();
                        extenautingcond.s_locale_culture = SessionWrapper.CultureName;
                        extenautingcond.c_file_guid = c_file_guid + c_file_extension;
                        extenautingcond.c_file_name = c_file_name;
                        extenautingcond.c_case_id_pk = edit;
                        extenautingcond.c_name = txtName.Text;
                        extenautingcond.c_contact_info = txtContactInfo.InnerText;
                        if (!string.IsNullOrEmpty(hdExtenautingcond.Value))
                        {
                            extenautingcond.c_file_id = hdExtenautingcond.Value;
                            extenautingcond.s_locale_culture = SessionWrapper.CultureName;
                            ComplianceBLL.UpdateExtenautingConditionFile(extenautingcond);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdExtenautingcond.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertExtenuatingCondition(extenautingcond);
                        }
                        txtName.Text = string.Empty;
                        txtContactInfo.Value = string.Empty;
                        //Extenautingcondition
                        DataTable dtGetExtenautingcondition = new DataTable();
                        dtGetExtenautingcondition = ComplianceBLL.GetExtenuatingCondition(extenautingcond);
                        this.gvExtenuatingcondition.DataSource = dtGetExtenautingcondition;
                        this.gvExtenuatingcondition.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        protected void btnUploadEmployeeInterview_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathEmployeeInterview + c_file_guid + c_file_extension));
                    try
                    {
                        ComplianceDAO employeeInterview = new ComplianceDAO();
                        employeeInterview.s_locale_culture = SessionWrapper.CultureName;
                        employeeInterview.c_file_guid = c_file_guid + c_file_extension;
                        employeeInterview.c_file_name = c_file_name;
                        employeeInterview.c_case_id_pk = edit;
                        employeeInterview.c_name = txtName.Text;
                        employeeInterview.c_contact_info = txtContactInfo.InnerText;
                        if (!string.IsNullOrEmpty(hdEmployeeInterview.Value))
                        {
                            employeeInterview.c_file_id = hdEmployeeInterview.Value;
                            employeeInterview.s_locale_culture = SessionWrapper.CultureName;
                            ComplianceBLL.UpdateEmployeeInterviewFile(employeeInterview);
                            //EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_witness);
                            hdEmployeeInterview.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertEmployeeInterview(employeeInterview);
                        }
                        txtName.Text = string.Empty;
                        txtContactInfo.Value = string.Empty;
                        //Extenautingcondition
                        DataTable dtGetEmployeeInterview = new DataTable();
                        dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(employeeInterview);
                        this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                        this.gvEmployeeInterview.DataBind();
                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cemv-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }


        protected void gvAddWitness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvAddWitness.DataKeys[rowIndex][4].ToString();
                hdWitness.Value = caseFileId;
                txtName.Text = gvAddWitness.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvAddWitness.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "witness", "Showeditpopup('witness');", true);
                mpeWitness.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string witnessFileId = gvAddWitness.DataKeys[rowIndex][0].ToString();
                string witnessFileName = gvAddWitness.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_path + witnessFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + witnessFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvAddWitness.DataKeys[rowIndex][4].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.s_locale_culture = SessionWrapper.CultureName;
                    miris.c_file_id = caseFileId;
                    miris.c_case_id_pk = edit;
                    ComplianceBLL.DeleteWitnessFile(miris);
                    //witness
                    DataTable dtGetWitness = new DataTable();
                    dtGetWitness = ComplianceBLL.GetWitness(miris);

                    this.gvAddWitness.DataSource = dtGetWitness;
                    this.gvAddWitness.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Return Extension
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        protected void gvPoliceReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvPoliceReport.DataKeys[rowIndex][2].ToString();
                hdPolice.Value = caseFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "policereport", "Showeditpopup('policereport');", true);
                mpePoliceReport.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string policeFileId = gvPoliceReport.DataKeys[rowIndex][0].ToString();
                string policeFileName = gvPoliceReport.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPolice + policeFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + policeFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvPoliceReport.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_file_id = caseFileId;
                    ComplianceBLL.DeletePoliceReportFile(miris);
                    //police report
                    miris.c_case_id_pk = edit;
                    DataTable dtGetPoliceReport = new DataTable();
                    dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);

                    this.gvPoliceReport.DataSource = dtGetPoliceReport;
                    this.gvPoliceReport.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
                // DeleteDataToTempPolice(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_PoliceReport);
            }
        }

        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvPhoto.DataKeys[rowIndex][2].ToString();
                hdPhoto.Value = caseFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photo", "Showeditpopup('photo');", true);
                mpePhoto.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string PhotoFileId = gvPhoto.DataKeys[rowIndex][0].ToString();
                string photoFileName = gvPhoto.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPhoto + PhotoFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + photoFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvPhoto.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_file_id = caseFileId;
                    ComplianceBLL.DeletePhotoFile(miris);
                    //photo
                    miris.c_case_id_pk = edit;
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.Getphoto(miris);
                    this.gvPhoto.DataSource = dtGetPhoto;
                    this.gvPhoto.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempPhoto(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_Photo);
            }
        }

        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvSceneSketch.DataKeys[rowIndex][2].ToString();
                hdSceneSketch.Value = caseFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scenesketch", "Showeditpopup('scenesketch');", true);
                mpeSceneSketch.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string SceneSketchFileId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                string sceneSketchFileName = gvSceneSketch.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathSceneSketch + SceneSketchFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + sceneSketchFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvSceneSketch.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_file_id = caseFileId;
                    ComplianceBLL.DeleteSceneSketchFile(miris);
                    miris.c_case_id_pk = edit;
                    //SceneSketch
                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                    this.gvSceneSketch.DataSource = dtGetSceneSketch;
                    this.gvSceneSketch.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
                // DeleteDataToTempSceneSketch(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_SceneSketch);
            }
        }

        protected void gvExtenuatingcondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvExtenuatingcondition.DataKeys[rowIndex][4].ToString();
                hdExtenautingcond.Value = caseFileId;
                txtName.Text = gvExtenuatingcondition.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvExtenuatingcondition.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "extenuatingcondition", "Showeditpopup('extenuatingcondition');", true);
                mpeExtenautingCondition.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingconditionFileId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                string extenuatingConditionFileName = gvExtenuatingcondition.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathExtenuatingcondition + ExtenuatingconditionFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + extenuatingConditionFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvExtenuatingcondition.DataKeys[rowIndex][4].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_file_id = caseFileId;
                    miris.s_locale_culture = SessionWrapper.CultureName;
                    ComplianceBLL.DeleteExtenautingConditionFile(miris);

                    //Extenautingcondition
                    miris.c_case_id_pk = edit;
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                    this.gvExtenuatingcondition.DataSource = dtGetExtenautingCondition;
                    this.gvExtenuatingcondition.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempExtenautingcondition(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_ExtenuatingCondition);
            }
        }

        protected void gvEmployeeInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvEmployeeInterview.DataKeys[rowIndex][4].ToString();
                hdEmployeeInterview.Value = caseFileId;
                txtName.Text = gvEmployeeInterview.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvEmployeeInterview.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "employeeinterview", "Showeditpopup('employeeinterview');", true);
                mpeEmployeeInterview.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string EmployeeInterviewFileId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                string employeeInterviewFileName = gvEmployeeInterview.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathEmployeeInterview + EmployeeInterviewFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + employeeInterviewFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseFileId = gvEmployeeInterview.DataKeys[rowIndex][4].ToString();
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_file_id = caseFileId;
                    miris.s_locale_culture = SessionWrapper.CultureName;
                    ComplianceBLL.DeleteEmployeeInterviewFile(miris);
                    miris.c_case_id_pk = edit;
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                    this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                    this.gvEmployeeInterview.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cemv-01", ex.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Get Bracket text
        /// </summary>
        /// <param name="strCaseCategory"></param>
        /// <returns></returns>

        private string GetBracketText(string strCaseCategory)
        {
            string regularExpressionPattern = @"\((.*?)\)";
            string inputText = strCaseCategory;
            Regex re = new Regex(regularExpressionPattern);
            string strresult = string.Empty;
            foreach (Match m in re.Matches(inputText))
            {
                strresult = m.Value;
            }
            strresult = strresult.Replace("(", "").Replace(")", "");
            return strresult;
        }
        protected void btnResetHeader_Click(object sender, EventArgs e)
        {
            ResetCase();

        }

        protected void btnResetFooter_Click(object sender, EventArgs e)
        {
            ResetCase();
        }
        /// <summary>
        /// Reset Motor vehicle case
        /// </summary>
        private void ResetCase()
        {
            success_msg.Style.Add("display", "none");
            error_msg.Style.Add("display", "none");
            populatecase(edit);
            try
            {
                ComplianceDAO resetCase = new ComplianceDAO();
                resetCase.c_case_id_pk = edit;
                resetCase.s_locale_culture = SessionWrapper.CultureName;
                ComplianceBLL.DeleteAdditionalInformation(resetCase);

                //WITENSS
                foreach (DataRow dr in SessionWrapper.session_witness.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    resetCase.c_name = dr["c_name"].ToString();
                    resetCase.c_contact_info = dr["c_contact_info"].ToString();
                    ComplianceBLL.InsertWitness(resetCase);
                }
                //PoliceReport
                foreach (DataRow dr in SessionWrapper.session_PoliceReport.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    ComplianceBLL.InsertPoliceReport(resetCase);
                }
                //Photo
                foreach (DataRow dr in SessionWrapper.session_Photo.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    ComplianceBLL.Insertphoto(resetCase);
                }
                //SceneSketch
                foreach (DataRow dr in SessionWrapper.session_SceneSketch.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    ComplianceBLL.InsertSceneSketch(resetCase);
                }
                //ExtenuatingCondition
                foreach (DataRow dr in SessionWrapper.session_ExtenuatingCondition.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    resetCase.c_name = dr["c_name"].ToString();
                    resetCase.c_contact_info = dr["c_contact_info"].ToString();
                    ComplianceBLL.InsertExtenuatingCondition(resetCase);
                }
                //EmployeeInterview
                foreach (DataRow dr in SessionWrapper.session_EmployeeInterview.Rows)
                {
                    resetCase.c_file_guid = dr["c_file_guid"].ToString();
                    resetCase.c_file_name = dr["c_file_name"].ToString();
                    resetCase.c_name = dr["c_name"].ToString();
                    resetCase.c_contact_info = dr["c_contact_info"].ToString();
                    ComplianceBLL.InsertEmployeeInterview(resetCase);
                }

                int result = ComplianceBLL.ResetVehicleInfo(edit, ConvertDataTableToXml(SessionWrapper.session_vehicle_values));
                if (result == 0)
                {
                    DataTable dtVehicleCount = new DataTable();
                    dtVehicleCount = ComplianceBLL.GetVehicleValues(edit);
                    ltlVehicleCount.Text = Convert.ToString(dtVehicleCount.Rows.Count);
                    vCount = 0;
                    VehiclePanel.Controls.Clear();

                    AddAndRemoveVehicle();
                }
                //SessionWrapper.session_vehicle_values

                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(resetCase);
                this.gvAddWitness.DataSource = dtGetWitness;
                this.gvAddWitness.DataBind();
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(resetCase);
                this.gvPhoto.DataSource = dtGetPhoto;
                this.gvPhoto.DataBind();
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(resetCase);
                this.gvPoliceReport.DataSource = dtGetPoliceReport;
                this.gvPoliceReport.DataBind();
                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(resetCase);
                this.gvSceneSketch.DataSource = dtGetSceneSketch;
                this.gvSceneSketch.DataBind();
                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(resetCase);
                this.gvExtenuatingcondition.DataSource = dtGetExtenautingCondition;
                this.gvExtenuatingcondition.DataBind();
                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(resetCase);
                this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                this.gvEmployeeInterview.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Convert Datatable to XML
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns></returns>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        protected void ddlTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComplianceDAO miris = new ComplianceDAO();
            miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(ddlTimezone.SelectedValue));
            IncidentTime.Date = miris.c_incident_date;
            //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
        }

        protected void btnSavecase_header_Click(object sender, EventArgs e)
        {
            UpdateCase(ddlCaseStatus.SelectedValue);
        }

        protected void btnSaveCase_footer_Click(object sender, EventArgs e)
        {
            UpdateCase(ddlCaseStatus.SelectedValue);
        }
        /// <summary>
        /// Update motor vehicle case
        /// </summary>
        /// <param name="c_case_status"></param>
        private void UpdateCase(string c_case_status)
        {
            try
            {
                ComplianceDAO updateCase = new ComplianceDAO();
                updateCase.c_case_id_pk = edit;
                updateCase.u_user_id_fk = SessionWrapper.u_userid;
                updateCase.c_case_title = txtCaseTitle.Text;
                updateCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
                //updateCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                uccb_01 casetypepanel = (uccb_01)CaseTypePanel.Controls[1];
                updateCase.c_case_type_fk = casetypepanel.uc_values;// uccb1.uc_values;
                updateCase.c_case_status = c_case_status;
                updateCase.c_employee_name = txtEmployeeName.Text;
                updateCase.c_employee_last_name = txtLastName.Text;
                //updateCase.c_establishment 
                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                updateCase.c_employee_dob = birthDate;
                int day1 = Convert.ToInt32(doh_date_in_time_day.Items[doh_date_in_time_day.SelectedIndex].Value);
                int month1 = Convert.ToInt16(ddlDateInTitleMonth.SelectedValue);
                int year1 = Convert.ToInt32(ddlDateInTitleYear.SelectedValue);
                updateCase.c_date_in_title = new DateTime(year1, month1, day1);

                int hireday = Convert.ToInt32(doh_hire_day.Items[doh_hire_day.SelectedIndex].Value);
                int hiremonth = Convert.ToInt16(ddlHireMonth.SelectedValue);
                int hireyear = Convert.ToInt32(ddlHireYear.SelectedValue);
                DateTime hireDate = new DateTime(hireyear, hiremonth, hireday);
                updateCase.c_employee_hire_date = hireDate;


                //updateCase.c_employee_dob = Convert.ToDateTime(txtDateOfBirth.Text, culture);
                //updateCase.c_employee_hire_date = Convert.ToDateTime(txtEmployeHireDate.Text, culture);
                updateCase.c_employee_id = txtEmployeeId.Text;
                updateCase.c_ssn = txtLastFourDigitOfSSN.Text;
                updateCase.c_supervisor = txtSupervisor.Text;
                updateCase.c_incident_location = txtIncidentLocation.Text;
                updateCase.c_establishment = ddlEstablishment.SelectedValue;
                updateCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                updateCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                updateCase.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                updateCase.c_note = txtNote.Text;
                updateCase.c_root_cause_analysic_info = "";
                updateCase.c_corrective_action_info = "";
                //updateCase.c_osha_300_case_outcome = ddlCaseOutCome.SelectedValue;
                //int DaysfromWork;
                //int.TryParse(txtDaysAwayFromWork.Text, out DaysfromWork);
                //updateCase.c_osha_300_days_away_from_work = DaysfromWork;
                //DateTime? dateofdeath = null;
                //DateTime tempdateofdeath;
                //if (DateTime.TryParseExact(txtDateOfDeath.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempdateofdeath))
                //{
                //    dateofdeath = tempdateofdeath;
                //}
                //updateCase.c_osha_300_date_of_death = dateofdeath;
                //updateCase.c_osha_300_type_of_illness = ddlTypeOfIllness.SelectedValue;
                //int daysofrestriction;
                //int.TryParse(txtDaysOfRestrictions.Text, out daysofrestriction);
                //updateCase.c_osha_300_days_of_restriction = daysofrestriction;
                //updateCase.c_osha_300_info = txtOSHA300info.Text;
                //updateCase.c_osha_301_worker_gender = ddlWorkerGender.SelectedValue;
                //DateTime? workstarttime = null;
                //DateTime tempWorkStartTime;
                //if (DateTime.TryParse(WorkStartTime.Date.ToString(), out tempWorkStartTime))
                //{
                //    workstarttime = tempWorkStartTime;
                //}
                //updateCase.c_osha_301_work_start_time = workstarttime;
                //updateCase.c_osha_301_physician = txtPhysician.Text;
                //updateCase.c_osha_301_treatment_facilities = txtTreatMentFacility.Text;
                //updateCase.c_osha_301_emergency_room = chkEmergencyRoom.Checked;
                //updateCase.c_osha_301_hospitalized = chkHospitalized.Checked;
                //updateCase.c_osha_301_address1 = txtAddress1.Text;
                //updateCase.c_osha_301_address2 = txtAddress2.Text;
                //updateCase.c_osha_301_address3 = txtAddress3.Text;
                //updateCase.c_osha_301_city = txtCity.Text;
                //updateCase.c_osha_301_state = txtState.Text;
                //updateCase.c_osha_301_zip = txtZip.Text;
                //updateCase.c_osha_301_info_1 = txtOSHA301Info1.Text;
                //updateCase.c_osha_301_info_2 = txtOSHA301Info2.Text;
                //updateCase.c_osha_301_info_3 = txtOSHA301Info3.Text;
                //updateCase.c_osha_301_info_4 = txtOSHA301Info4.Text;
                updateCase.c_custom_01 = txtCustom01.Text;
                updateCase.c_custom_02 = txtCustom02.Text;
                updateCase.c_custom_03 = txtCustom03.Text;
                updateCase.c_custom_04 = txtCustom04.Text;
                updateCase.c_custom_05 = txtCustom05.Text;
                updateCase.c_custom_06 = txtCustom06.Text;
                updateCase.c_custom_07 = txtCustom07.Text;
                updateCase.c_custom_08 = txtCustom08.Text;
                updateCase.c_custom_09 = txtCustom09.Text;
                updateCase.c_custom_10 = txtCustom10.Text;
                updateCase.c_custom_11 = txtCustom11.Text;
                updateCase.c_custom_12 = txtCustom12.Text;
                updateCase.c_custom_13 = txtCustom13.Text;
                updateCase.c_timezoneId = ddlTimezone.SelectedValue;

                if (rblCompanyOwned.SelectedValue == "Yes")
                {
                    updateCase.c_company_owned = true;
                }
                else
                {
                    updateCase.c_company_owned = false;
                }            


                //newly added
                updateCase.c_case_desc_vehicle_01_fk = ddlVehicle01.Text;
                updateCase.c_case_desc_vehicle_02_fk = ddlVehicle02.Text;

                updateCase.c_case_desc_vehicle_id = txtVehicleId.Text;
                updateCase.c_case_desc_vehicle_vin = txtVIN.Text;
                updateCase.c_case_desc_licence_number = txtLicenseNumber.Text;
                updateCase.c_case_desc_vehicle_make = txtVehicleMake.Text;
                updateCase.c_case_desc_vehicle_model = txtVehicleModel.Text;
                updateCase.c_case_desc_vehicle_type_fk = ddlVehicleType.Text;
                updateCase.c_case_desc_year = txtYear.Text;
                updateCase.c_case_desc_state = txtState.Text;

                updateCase.c_case_desc_vehicle_02_id = txtVehicleId02.Text;
                updateCase.c_case_desc_vehicle_02_vin = txtVin02.Text;
                updateCase.c_case_desc_licence_02_number = txtLicenseNumber02.Text;
                updateCase.c_case_desc_vehicle_02_make = txtVehicleMake02.Text;
                updateCase.c_case_desc_vehicle_02_model = txtModel02.Text;
                updateCase.c_case_desc_vehicle_02_type_fk = ddlVehicleType02.Text;
                updateCase.c_case_desc_vehicle_02_year = txtYear02.Text;
                updateCase.c_case_desc_vehicle_02_state = txtYear02.Text;

                if (VehiclePanel.Controls.Count > 1)
                {
                    ucmv_01 vehicle03 = (ucmv_01)VehiclePanel.Controls[1];
                    if (vehicle03 != null)
                    {
                        updateCase.c_case_desc_vehicle_03_fk = vehicle03.ddlVehicle;
                        updateCase.c_case_desc_vehicle_03_id = vehicle03.VechicleId;
                        updateCase.c_case_desc_vehicle_03_vin = vehicle03.VIN;
                        updateCase.c_case_desc_licence_03_number = vehicle03.LicenseNumber;
                        updateCase.c_case_desc_vehicle_03_make = vehicle03.VehicleMake;
                        updateCase.c_case_desc_vehicle_03_model = vehicle03.VehicleModel;
                        updateCase.c_case_desc_vehicle_03_type_fk = vehicle03.ddlType;
                        updateCase.c_case_desc_vehicle_03_year = vehicle03.Year;
                        updateCase.c_case_desc_vehicle_03_state = vehicle03.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_03_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_03_id = string.Empty;
                    updateCase.c_case_desc_vehicle_03_vin = string.Empty;
                    updateCase.c_case_desc_licence_03_number = string.Empty;
                    updateCase.c_case_desc_vehicle_03_make = string.Empty;
                    updateCase.c_case_desc_vehicle_03_model = string.Empty;
                    updateCase.c_case_desc_vehicle_03_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_03_year = string.Empty;
                    updateCase.c_case_desc_vehicle_03_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 2)
                {
                    ucmv_01 vehicle04 = (ucmv_01)VehiclePanel.Controls[2];
                    if (vehicle04 != null)
                    {
                        updateCase.c_case_desc_vehicle_04_fk = vehicle04.ddlVehicle;
                        updateCase.c_case_desc_vehicle_04_id = vehicle04.VechicleId;
                        updateCase.c_case_desc_vehicle_04_vin = vehicle04.VIN;
                        updateCase.c_case_desc_licence_04_number = vehicle04.LicenseNumber;
                        updateCase.c_case_desc_vehicle_04_make = vehicle04.VehicleMake;
                        updateCase.c_case_desc_vehicle_04_model = vehicle04.VehicleModel;
                        updateCase.c_case_desc_vehicle_04_type_fk = vehicle04.ddlType;
                        updateCase.c_case_desc_vehicle_04_year = vehicle04.Year;
                        updateCase.c_case_desc_vehicle_04_state = vehicle04.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_04_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_04_id = string.Empty;
                    updateCase.c_case_desc_vehicle_04_vin = string.Empty;
                    updateCase.c_case_desc_licence_04_number = string.Empty;
                    updateCase.c_case_desc_vehicle_04_make = string.Empty;
                    updateCase.c_case_desc_vehicle_04_model = string.Empty;
                    updateCase.c_case_desc_vehicle_04_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_04_year = string.Empty;
                    updateCase.c_case_desc_vehicle_04_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 3)
                {
                    ucmv_01 vehicle05 = (ucmv_01)VehiclePanel.Controls[3];
                    if (vehicle05 != null)
                    {
                        updateCase.c_case_desc_vehicle_05_fk = vehicle05.ddlVehicle;
                        updateCase.c_case_desc_vehicle_05_id = vehicle05.VechicleId;
                        updateCase.c_case_desc_vehicle_05_vin = vehicle05.VIN;
                        updateCase.c_case_desc_licence_05_number = vehicle05.LicenseNumber;
                        updateCase.c_case_desc_vehicle_05_make = vehicle05.VehicleMake;
                        updateCase.c_case_desc_vehicle_05_model = vehicle05.VehicleModel;
                        updateCase.c_case_desc_vehicle_05_type_fk = vehicle05.ddlType;
                        updateCase.c_case_desc_vehicle_05_year = vehicle05.Year;
                        updateCase.c_case_desc_vehicle_05_state = vehicle05.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_05_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_05_id = string.Empty;
                    updateCase.c_case_desc_vehicle_05_vin = string.Empty;
                    updateCase.c_case_desc_licence_05_number = string.Empty;
                    updateCase.c_case_desc_vehicle_05_make = string.Empty;
                    updateCase.c_case_desc_vehicle_05_model = string.Empty;
                    updateCase.c_case_desc_vehicle_05_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_05_year = string.Empty;
                    updateCase.c_case_desc_vehicle_05_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 4)
                {
                    ucmv_01 vehicle06 = (ucmv_01)VehiclePanel.Controls[4];
                    if (vehicle06 != null)
                    {
                        updateCase.c_case_desc_vehicle_06_fk = vehicle06.ddlVehicle;
                        updateCase.c_case_desc_vehicle_06_id = vehicle06.VechicleId;
                        updateCase.c_case_desc_vehicle_06_vin = vehicle06.VIN;
                        updateCase.c_case_desc_licence_06_number = vehicle06.LicenseNumber;
                        updateCase.c_case_desc_vehicle_06_make = vehicle06.VehicleMake;
                        updateCase.c_case_desc_vehicle_06_model = vehicle06.VehicleModel;
                        updateCase.c_case_desc_vehicle_06_type_fk = vehicle06.ddlType;
                        updateCase.c_case_desc_vehicle_06_year = vehicle06.Year;
                        updateCase.c_case_desc_vehicle_06_state = vehicle06.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_06_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_06_id = string.Empty;
                    updateCase.c_case_desc_vehicle_06_vin = string.Empty;
                    updateCase.c_case_desc_licence_06_number = string.Empty;
                    updateCase.c_case_desc_vehicle_06_make = string.Empty;
                    updateCase.c_case_desc_vehicle_06_model = string.Empty;
                    updateCase.c_case_desc_vehicle_06_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_06_year = string.Empty;
                    updateCase.c_case_desc_vehicle_06_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 5)
                {
                    ucmv_01 vehicle07 = (ucmv_01)VehiclePanel.Controls[5];
                    if (vehicle07 != null)
                    {
                        updateCase.c_case_desc_vehicle_07_fk = vehicle07.ddlVehicle;
                        updateCase.c_case_desc_vehicle_07_id = vehicle07.VechicleId;
                        updateCase.c_case_desc_vehicle_07_vin = vehicle07.VIN;
                        updateCase.c_case_desc_licence_07_number = vehicle07.LicenseNumber;
                        updateCase.c_case_desc_vehicle_07_make = vehicle07.VehicleMake;
                        updateCase.c_case_desc_vehicle_07_model = vehicle07.VehicleModel;
                        updateCase.c_case_desc_vehicle_07_type_fk = vehicle07.ddlType;
                        updateCase.c_case_desc_vehicle_07_year = vehicle07.Year;
                        updateCase.c_case_desc_vehicle_07_state = vehicle07.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_07_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_07_id = string.Empty;
                    updateCase.c_case_desc_vehicle_07_vin = string.Empty;
                    updateCase.c_case_desc_licence_07_number = string.Empty;
                    updateCase.c_case_desc_vehicle_07_make = string.Empty;
                    updateCase.c_case_desc_vehicle_07_model = string.Empty;
                    updateCase.c_case_desc_vehicle_07_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_07_year = string.Empty;
                    updateCase.c_case_desc_vehicle_07_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 6)
                {
                    ucmv_01 vehicle08 = (ucmv_01)VehiclePanel.Controls[6];
                    if (vehicle08 != null)
                    {
                        updateCase.c_case_desc_vehicle_08_fk = vehicle08.ddlVehicle;
                        updateCase.c_case_desc_vehicle_08_id = vehicle08.VechicleId;
                        updateCase.c_case_desc_vehicle_08_vin = vehicle08.VIN;
                        updateCase.c_case_desc_licence_08_number = vehicle08.LicenseNumber;
                        updateCase.c_case_desc_vehicle_08_make = vehicle08.VehicleMake;
                        updateCase.c_case_desc_vehicle_08_model = vehicle08.VehicleModel;
                        updateCase.c_case_desc_vehicle_08_type_fk = vehicle08.ddlType;
                        updateCase.c_case_desc_vehicle_08_year = vehicle08.Year;
                        updateCase.c_case_desc_vehicle_08_state = vehicle08.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_08_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_08_id = string.Empty;
                    updateCase.c_case_desc_vehicle_08_vin = string.Empty;
                    updateCase.c_case_desc_licence_08_number = string.Empty;
                    updateCase.c_case_desc_vehicle_08_make = string.Empty;
                    updateCase.c_case_desc_vehicle_08_model = string.Empty;
                    updateCase.c_case_desc_vehicle_08_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_08_year = string.Empty;
                    updateCase.c_case_desc_vehicle_08_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 7)
                {
                    ucmv_01 vehicle09 = (ucmv_01)VehiclePanel.Controls[7];
                    if (vehicle09 != null)
                    {
                        updateCase.c_case_desc_vehicle_09_fk = vehicle09.ddlVehicle;
                        updateCase.c_case_desc_vehicle_09_id = vehicle09.VechicleId;
                        updateCase.c_case_desc_vehicle_09_vin = vehicle09.VIN;
                        updateCase.c_case_desc_licence_09_number = vehicle09.LicenseNumber;
                        updateCase.c_case_desc_vehicle_09_make = vehicle09.VehicleMake;
                        updateCase.c_case_desc_vehicle_09_model = vehicle09.VehicleModel;
                        updateCase.c_case_desc_vehicle_09_type_fk = vehicle09.ddlType;
                        updateCase.c_case_desc_vehicle_09_year = vehicle09.Year;
                        updateCase.c_case_desc_vehicle_09_state = vehicle09.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_09_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_09_id = string.Empty;
                    updateCase.c_case_desc_vehicle_09_vin = string.Empty;
                    updateCase.c_case_desc_licence_09_number = string.Empty;
                    updateCase.c_case_desc_vehicle_09_make = string.Empty;
                    updateCase.c_case_desc_vehicle_09_model = string.Empty;
                    updateCase.c_case_desc_vehicle_09_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_09_year = string.Empty;
                    updateCase.c_case_desc_vehicle_09_state = string.Empty;
                }
                if (VehiclePanel.Controls.Count > 8)
                {
                    ucmv_01 vehicle10 = (ucmv_01)VehiclePanel.Controls[8];
                    if (vehicle10 != null)
                    {
                        updateCase.c_case_desc_vehicle_10_fk = vehicle10.ddlVehicle;
                        updateCase.c_case_desc_vehicle_10_id = vehicle10.VechicleId;
                        updateCase.c_case_desc_vehicle_10_vin = vehicle10.VIN;
                        updateCase.c_case_desc_licence_10_number = vehicle10.LicenseNumber;
                        updateCase.c_case_desc_vehicle_10_make = vehicle10.VehicleMake;
                        updateCase.c_case_desc_vehicle_10_model = vehicle10.VehicleModel;
                        updateCase.c_case_desc_vehicle_10_type_fk = vehicle10.ddlType;
                        updateCase.c_case_desc_vehicle_10_year = vehicle10.Year;
                        updateCase.c_case_desc_vehicle_10_state = vehicle10.State;
                    }
                }
                else
                {
                    updateCase.c_case_desc_vehicle_10_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_10_id = string.Empty;
                    updateCase.c_case_desc_vehicle_10_vin = string.Empty;
                    updateCase.c_case_desc_licence_10_number = string.Empty;
                    updateCase.c_case_desc_vehicle_10_make = string.Empty;
                    updateCase.c_case_desc_vehicle_10_model = string.Empty;
                    updateCase.c_case_desc_vehicle_10_type_fk = string.Empty;
                    updateCase.c_case_desc_vehicle_10_year = string.Empty;
                    updateCase.c_case_desc_vehicle_10_state = string.Empty;
                }
                updateCase.c_case_desc_company_vehicle_struck_fk = ddlVehicleStruck.Text;
                updateCase.c_case_desc_company_vehicle_struck_by_fk = ddlVehicleStruckBy.Text;
                updateCase.c_case_desc_non_collision = chkNonCollision.Checked;
                updateCase.c_case_desc_non_collision_text = txtNonCollision.Text;

                updateCase.c_case_detail_drivers_lic = txtDriversLic.Text;
                updateCase.c_case_detail_state_and_class = txtStateandClass.Text;
                DateTime? expiredate = null;
                DateTime tempexpiredate;
                if (DateTime.TryParseExact(txtExpireDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempexpiredate))
                {
                    expiredate = tempexpiredate;
                }
                updateCase.c_case_detail_expire_date = expiredate;

                //updateCase.c_case_detail_expire_date = Convert.ToDateTime(txtExpireDate.Text, culture);
                updateCase.c_case_detail_address = txtAddress.Text;
                updateCase.c_case_detail_city = txtCity.Text;
                updateCase.c_case_detail_state = txtCaseState.Text;
                updateCase.c_case_detail_nearest_cross_street = txtNearestCrossStreet.Text;
                updateCase.c_case_detail_type_of_roadway = txtTypeofRoadway.Text;
                updateCase.c_case_detail_road_condition_fk = ddlRoadCondition.Text;
                DateTime? timeofday = null;
                DateTime temptimeofday;
                if (DateTime.TryParseExact(txtTimeofDay.Text, "h:mm tt", culture, DateTimeStyles.None, out temptimeofday))
                {
                    timeofday = temptimeofday;
                }

                updateCase.c_case_detail_time_of_day = timeofday;

                //updateCase.c_case_detail_time_of_day = Convert.ToDateTime(txtTimeofDay.Text);
                // here we need to add one column
                updateCase.c_case_detail_weather_fk = ddlWeather.SelectedValue;
                updateCase.c_case_detail_traffic_condition_fk = ddlTrafficCondition.Text;
                updateCase.c_case_detail_traffic_controls_fk = ddlTrafficControls.Text;
                updateCase.c_case_detail_oprating_speed = txtOperatingSpeed.Text;  //doubt
                updateCase.c_case_detail_speed_limit = txtSpeedLimit.Text;   //doubt
                updateCase.c_case_detail_vehicle_struck_fk = ddlVehicleStruck.Text;
                updateCase.c_case_detail_vehicle_struck_by_fk = ddlVehicleStruckBy.Text;
                updateCase.c_case_detail_collision_type_fk = ddlCollisionType.Text;
                updateCase.c_case_detail_collision_location_fk = ddlCollisionLocation.Text;
                updateCase.c_case_detail_collision_direction_fk = ddlCollisionDirection.Text;
                updateCase.c_case_detail_non_collision_type_fk = ddlNonCollisionType.Text;
                updateCase.c_case_detail_number_of_vehicle_involved = txtNumberofVehicleInvolved.Text;
                updateCase.c_case_detail_number_of_vehicle_towed = txtNumberofVehicletowed.Text;
                updateCase.c_case_detail_number_of_people_injured = txtNoofPeopleInjured.Text;
                updateCase.c_case_detail_number_of_people_killed = txtNoofPeopleKilled.Text;
                if (rblCituationIssued.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_cituation_issued = true;
                }
                else
                {
                    updateCase.c_case_detail_cituation_issued = false;
                }
                updateCase.c_case_detail_at_whom = txtAtWhom.Text;
                if (rblAtfault.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_at_fault = true;
                }
                else
                {
                    updateCase.c_case_detail_at_fault = false;
                }
                if (rblContributory.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_contributory = true;
                }
                else
                {
                    updateCase.c_case_detail_contributory = false;
                }

                updateCase.c_case_detail_gross_vehicle_weight = txtGrossVehicleWeight.Text;
                updateCase.c_case_detail_combined_gross_vehicle_weight = txtCombinedGrossVehicleWeight.Text;
                if (rblDotVehicle.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_dot_vehicle = true;
                }
                else
                {
                    updateCase.c_case_detail_dot_vehicle = false;
                }
                if (rblDotDriver.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_dot_driver = true;
                }
                else
                {
                    updateCase.c_case_detail_dot_driver = false;
                }
                if (rblSeatBeltUsed.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_seat_belt_used = true;
                }
                else
                {
                    updateCase.c_case_detail_seat_belt_used = false;
                }
                if (rblAirbagEquipped.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_air_bag_eqiupped = true;
                }
                else
                {
                    updateCase.c_case_detail_air_bag_eqiupped = false;
                }
                if (rblAirBagDeployed.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_air_bag_deployed = true;
                }
                else
                {
                    updateCase.c_case_detail_air_bag_deployed = false;
                }
                if (rblCellphoneinUse.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_cellphone_in_use = true;
                }
                else
                {
                    updateCase.c_case_detail_cellphone_in_use = false;
                }
                if (rblComputerInUse.SelectedValue == "Yes")
                {
                    updateCase.c_case_detail_computer_in_use = true;
                }
                else
                {
                    updateCase.c_case_detail_computer_in_use = false;
                }
                if (rblSpecialEquipment.SelectedValue == "Yes")
                {

                    updateCase.c_case_detail_special_equipment = true;
                }
                else
                {
                    updateCase.c_case_detail_special_equipment = false;
                }



                updateCase.c_case_detail_special_equipment_text = txtSpecialEquibment.Text;
                updateCase.c_case_detail_location_of_impact_fk = ddlLocationofImpact.Text;
                if (rblDriverInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    updateCase.c_case_detail_driver_injured = true;
                }
                else
                {
                    updateCase.c_case_detail_driver_injured = false;
                }
                if (rblPassengerInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    updateCase.c_case_detail_passenger_injured = true;
                }
                else
                {
                    updateCase.c_case_detail_passenger_injured = false;
                }



                updateCase.c_case_detail_damage_heavy = txtHeavyDamage.InnerText;
                updateCase.c_case_detail_damage_moderate = txtModerateDamage.InnerText;
                updateCase.c_case_detail_damage_light = txtLightDamage.InnerText;

                if (rblFatality.SelectedValue == "Yes")
                {
                    updateCase.c_case_desc_was_fatality = true;
                }
                else
                {
                    updateCase.c_case_desc_was_fatality = false;
                }
                if (rblPublicVehicleInvolved.SelectedValue == "Yes")
                {
                    updateCase.c_case_desc_public_vehicle_involved = true;
                }
                else
                {
                    updateCase.c_case_desc_public_vehicle_involved = false;
                }


                updateCase.c_pub_vehicle_driver_name = txtDriverName.Text;
                updateCase.c_pub_vehicle_driver_address = txtDriverAddress.Text;
                updateCase.c_pub_vehicle_driver_contact = txtDriverContact.Text;
                updateCase.c_pub_vehicle_owner_name = txtOwnerName.Text;
                updateCase.c_pub_vehicle_owner_address = txtOwnerAddress.Text;
                updateCase.c_pub_vehicle_owner_contact = txtOwnerContact.Text;
                updateCase.c_pub_vehicle_vehicle_id = txtPublicVehicleID.Text;
                updateCase.c_pub_vehicle_vehicle_vin = txtPublicVehicleVIN.Text;
                updateCase.c_pub_vehicle_licence_number = txtPublicLicenseNumber.Text;
                updateCase.c_pub_vehicle_vehicle_make = txtPublicVehicleMake.Text;
                updateCase.c_pub_vehicle_vehicle_model = txtPublicVehicleModel.Text;
                updateCase.c_pub_vehicle_vehicle_type_fk = ddlPublicVehicleType.Text;
                updateCase.c_pub_vehicle_year = txtPublicYear.Text;
                updateCase.c_pub_vehicle_state = txtPublicState.Text;
                updateCase.c_pub_vehicle_gross_vehicle_weight = txtPublicGrossWeight.Text;
                updateCase.c_pub_vehicle_combined_gross_vehicle_weight = txtPublicCombinedVehicleWeight.Text;
                if (rblPublicDotVehicle.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_dot_vehicle = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_dot_vehicle = false;
                }
                if (rblPublicDotDriver.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_dot_driver = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_dot_driver = false;
                }
                if (rblPublicSeatBeltUsed.SelectedValue == "Yes")
                {

                    updateCase.c_pub_vehicle_seat_belt_used = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_seat_belt_used = false;
                }
                if (rblPublicAirBagEquipped.SelectedValue == "Yes")
                {

                    updateCase.c_pub_vehicle_air_bag_eqiupped = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_air_bag_eqiupped = false;
                }
                if (rblPublicAirBagDeployed.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_air_bag_deployed = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_air_bag_deployed = false;
                }
                if (rblPublicCellphoneinUse.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_cellphone_in_use = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_cellphone_in_use = false;
                }
                if (rblPublicComputerInUse.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_computer_in_use = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_computer_in_use = false;
                }
                if (rblPublicSpecialEquipment.SelectedValue == "Yes")
                {
                    updateCase.c_pub_vehicle_special_equipment = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_special_equipment = false;
                }

                updateCase.c_pub_vehicle_special_equipment_text = txtPublicSpecialEquipment.Text;
                updateCase.c_pub_vehicle_location_of_impact_fk = ddlPublicLocationOfImpact.Text;
                if (rblPublicDriverInjured.SelectedValue == "Yes")// need to add some fields
                {
                    updateCase.c_pub_vehicle_driver_injured = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_driver_injured = false;
                }
                if (rblPublicPassengerInjured.SelectedValue == "Yes")// need to add some fields
                {
                    updateCase.c_pub_vehicle_passenger_injured = true;
                }
                else
                {
                    updateCase.c_pub_vehicle_passenger_injured = false;
                }
                updateCase.c_pub_vehicle_passenger_injured_text = txtPublicPassengerInjured.Text;
                updateCase.c_pub_vehicle_driver_injured_text = txtPublicDriverInjured.Text;

                updateCase.c_pub_vehicle_number_of_total_vehicle_injured = txtTotalvehicleOccupant.Text;
                updateCase.c_pub_vehicle_damage_heavy = txtPublicHeavyDamage.InnerText; //doubt
                updateCase.c_pub_vehicle_damage_moderate = txtPublicModerateDamage.InnerText;//doubt
                updateCase.c_pub_vehicle_damage_light = txtPubliclightDamage.InnerText;//doubt
                //Pedestrain Incident
                updateCase.c_pedestrain_name = txtNameofPedestrian.Text;
                updateCase.c_pedestrain_address = txtPedestrianAddress.Text;
                updateCase.c_pedestrain_phone = txtPedestrianPhone.Text;
                updateCase.c_pedestrain_sex = txtPedestrianSex.Text;
                updateCase.c_pedestrain_age = txtPedestrainAge.Text;
                updateCase.c_pedestrain_collision_type_fk = ddlPedestrainCollisionType.Text;
                updateCase.c_pedestrain_description = txtPedestrianDescription.InnerText;
                //BICycle Incident
                updateCase.c_bicycle_person_name = txtBicycleNameofPerson.Text;
                updateCase.c_bicycle_person_address = txtBicyclePersonAddress.Text;
                updateCase.c_bicycle_person_phone = txtBicyclePersonPhone.Text;
                updateCase.c_bicycle_person_sex = txtBicyblePersonSex.Text;
                updateCase.c_bicycle_person_age = txtBicycleAge.Text;
                updateCase.c_bicycle_person_collision_type_fk = ddlBicycleCollisionType.Text;
                updateCase.c_bicycle_person_description = txtBicycleIncidentDesc.InnerText;
                //Animal Incident
                updateCase.c_animal_name = txtAnimalName.Text;
                updateCase.c_animal_place = txtPlace.Text;
                updateCase.c_animal_collision_type_fk = ddlAnimalCollisionType.Text;
                updateCase.c_animal_description = txtAnimalDescription.InnerText;
                //Fixed Object Incident
                updateCase.c_fixed_object_property_name = txtPropertyOwner.Text;
                updateCase.c_fixed_object_address = txtPropertyAddress.Text;
                updateCase.c_fixed_object_contact_info = txtContactInformation.Text;
                updateCase.c_fixed_object_collision_type_fk = ddlPropertyCollisionType.Text;
                updateCase.c_fixed_object_description = txtPropertyDesc.InnerText;
                updateCase.c_fixed_object_property_description = txtPhysicalPropertyDesc.InnerText;

                if (!string.IsNullOrEmpty((string)ViewState["CaseCategory"]))
                {


                    updateCase.c_case_number = (string)ViewState["CaseCategory"];
                }
                else
                {
                    updateCase.c_case_number = lblCaseNumber.Text;
                }


                int error = ComplianceBLL.UpdateCaseMV(updateCase);
                urc1.UpdateRac(updateCase.c_case_id_pk);
                if (error != -1)
                {
                    error_msg.Style.Add("display", "none");
                    success_msg.Style.Add("display", "block");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_update_succ_text");
                    if (ddlCaseStatus.SelectedItem.Text == "Closed")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx", false);
                    }
                    //uccb1.show(updateCase.c_case_type_fk);
                }
                else
                {
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
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }

        protected void gvAddWitness_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPoliceReport_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPhoto_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSceneSketch_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvExtenuatingcondition_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvEmployeeInterview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnHeaderCompleteCase_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                CompleteCase();
            }
            else
            {
                mpCompleteCase.Show();
            }
        }

        protected void btnFooterCompleteCase_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                CompleteCase();
            }
            else
            {
                mpCompleteCase.Show();
            }

        }
        /// <summary>
        /// change status to close
        /// </summary>
        private void CompleteCase()
        {
            try
            {
                UpdateCase(ddlCaseStatus.Items.FindByText("Closed").Value);
                Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx", false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }

        protected void ddlCaseCategory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO miris = new ComplianceDAO();
                string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
                miris = ComplianceBLL.GetCaseId(caseCategory, edit);

                if (ddlCaseCategory.SelectedValue == "app_ddl_occupation_injury_text")
                {
                    Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(edit) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                else if (ddlCaseCategory.SelectedValue == "app_ddl_motor_vehicle_incident_text")
                {
                    Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(edit), false);
                }
                else
                {
                    Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(edit) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
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
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }

        protected void btnViewCaseDesc_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit));
        }

        private void PopulateYearDropDown()
        {
            int startYear = 1900;
            int endYear = DateTime.Now.Year;
            ddlYear.Items.Clear();
            ddlHireYear.Items.Clear();
            ddlDateInTitleYear.Items.Clear();
            ListItem li = new ListItem("Year:", "-1");
            li.Selected = true;
            ddlYear.Items.Add(li);
            ddlHireYear.Items.Add(li);
            ddlDateInTitleYear.Items.Add(li);
            for (int i = endYear; i >= startYear; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlHireYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlDateInTitleYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User approverInfo = new User();
            approverInfo = UserBLL.GetApprovalNameandEmail(ddlComplianceApprover.SelectedValue.ToString());

            string toEmailid = approverInfo.EmailId;
            toEmailid = "compliancefactor.project@gmail.com";
            //"compliancefactor.project@gmail.com";
            string[] toaddress = toEmailid.Split(',');
            List<MailAddress> mailAddresses = new List<MailAddress>();
            foreach (string recipient in toaddress)
            {
                if (recipient.Trim() != string.Empty)
                {
                    mailAddresses.Add(new MailAddress(recipient));
                }
            }
            try
            {
                StringBuilder sbCompleteCase = new StringBuilder();
                sbCompleteCase.Append("Hello " + approverInfo.Username + ",");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("This email is to change the case as completed case.");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("I sent the request to you for change this " + lblCaseNumber.Text + " to Complete Case.");
                sbCompleteCase.Append("<br><br>");
                sbCompleteCase.Append("by");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append(SessionWrapper.u_username);
                Utility.SendEMailMessage(mailAddresses, "***Request for Complete Case***", sbCompleteCase.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "Request Was Send Successfully to " + " " + approverInfo.Username;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cemv-01", ex.Message);
                    }
                }
            }
        }



    }
}


