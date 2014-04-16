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
using System.IO;
using System.Threading;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance
{
    public partial class ccamiris_01 : BasePage
    {
        private string caseId;
        private bool isApprover;
        private static string copyCaseId;
        #region "Private Member Variables"
        private string _path = "~/Compliance/MIRIS/Upload/Witness/";
        private string _pathPolice = "~/Compliance/MIRIS/Upload/Police/";
        private string _pathPhoto = "~/Compliance/MIRIS/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/MIRIS/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/MIRIS/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/MIRIS/Upload/EmployeeInterview/";

        #endregion
        private DataTable dtTempWitness = null;
        private DataTable dtTempPhoto = null;
        private DataTable dtTempPolice = null;
        private DataTable dtTempSceneSketch = null;
        private DataTable dtTempExtenautingcond = null;
        private DataTable dtTempEmployeeInterview = null;

        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {

            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;<a href=/Compliance/MIRIS/cccmiris-01.aspx>" + LocalResources.GetLabel("app_miris_text") + "</a>&nbsp;" + ">&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_case_text") + "</a>";
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                    }
                }
            }
            if (!IsPostBack)
            {
                PopulateYearDropDown();
                //clear session
                copyCaseId = string.Empty;
                SessionWrapper.session_witness = null;
                SessionWrapper.session_EmployeeInterview = null;
                SessionWrapper.session_ExtenuatingCondition = null;
                SessionWrapper.session_Photo = null;
                SessionWrapper.session_PoliceReport = null;
                SessionWrapper.session_SceneSketch = null;

                try
                {
                    //case category
                    ddlCaseCategory.DataSource = ComplianceBLL.GetMirisCaseCategory(SessionWrapper.CultureName, "ccamiris-01");
                    ddlCaseCategory.DataBind();

                    //case type
                    ddlCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "ccamiris-01");
                    ddlCaseTypes.DataBind();
                    ddlCaseTypes.SelectedValue = "app_ddl_recordable_text";
                    //case status
                    ddlCaseStatus.DataSource = ComplianceBLL.GetMirisCaseStatus(SessionWrapper.CultureName, "ccamiris-01");
                    ddlCaseStatus.DataBind();
                    ddlCaseStatus.SelectedValue = "app_ddl_open_text";

                    //Compliance Approver
                    ddlComplianceApprover.DataSource = UserBLL.GetComplianceApproverList();
                    ddlComplianceApprover.DataBind();

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
                    //case outcome
                    //ddlCaseOutCome.DataSource = ComplianceBLL.GetMirisCaseOutCome();
                    //ddlCaseOutCome.DataBind();

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
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }

                }
                //IncidentTime.Date = Convert.ToDateTime("2012-06-10 17:25:04");
                //WorkStartTime.Date = Convert.ToDateTime(DateTime.Now.ToString());
                try
                {

                    // DateTime currentDt = DateTime.Now.ToUniversalTime();//Current Converted to UTC
                    // currentDt = DateTime.SpecifyKind(currentDt, DateTimeKind.Utc);//Say to runtime that this date is UTC date.
                    // SessionWrapper.casedate = currentDt;
                    // lblCaseDate.Text = currentDt.ToString("MM/dd/yyyy hh:mm tt");

                    ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                    ddlTimezone.DataBind();

                    ComplianceDAO miris = new ComplianceDAO();
                    miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
                    IncidentTime.Date = DateTime.Now;
                    //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                    SessionWrapper.casedate = miris.c_temp_case_date;
                    lblCaseDate.Text = SessionWrapper.casedate.ToString("MM/dd/yyyy hh:mm tt");
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    caseId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);
                    copyCaseId = caseId;
                    IncidentTime.Date = Convert.ToDateTime(DateTime.Now.ToString());
                    populatecase(caseId);
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

                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_case_id_pk = caseId;

                    //witness
                    DataTable dtGetWitness = new DataTable();
                    dtGetWitness = ComplianceBLL.GetWitness(miris);
                    dtTempWitness = new DataTable();
                    dtTempWitness = dtGetWitness;
                    SessionWrapper.session_witness = dtTempWitness;
                    this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                    this.gvAddWitness.DataBind();

                    //photo
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.Getphoto(miris);
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = dtGetPhoto;
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();

                    //police report
                    DataTable dtGetPoliceReport = new DataTable();
                    dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                    dtTempPolice = new DataTable();
                    dtTempPolice = dtGetPoliceReport;
                    SessionWrapper.session_PoliceReport = dtTempPolice;
                    this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                    this.gvPoliceReport.DataBind();

                    //SceneSketch
                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = dtGetSceneSketch;
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();

                    //Extenautingcondition
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = dtGetExtenautingCondition;
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenuatingcondition.DataBind();

                    //EmployeeInterview
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = dtGetEmployeeInterview;
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                    this.gvEmployeeInterview.DataBind();

                }
                else
                {
                    try
                    {
                        ddlTimezone.SelectedValue = SessionWrapper.u_timezone;
                        ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["cid"]);
                        //ddlCaseTypes.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["type"]);
                        uccb1.show(SecurityCenter.DecryptText(Request.QueryString["type"]));
                        txtCaseTitle.Text = SecurityCenter.DecryptText(Request.QueryString["title"]);

                        ComplianceDAO miris = new ComplianceDAO();
                        DataTable dtCaseId = new DataTable();
                        miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);

                        lblCaseNumber.Text = miris.c_case_number;

                        //witenss
                        dtTempWitness = new DataTable();
                        dtTempWitness = tempWitness();
                        SessionWrapper.session_witness = dtTempWitness;
                        this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                        this.gvAddWitness.DataBind();

                        //photo
                        dtTempPhoto = new DataTable();
                        dtTempPhoto = tempPhoto();
                        SessionWrapper.session_Photo = dtTempPhoto;
                        this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                        this.gvPhoto.DataBind();

                        //Police report
                        dtTempPolice = new DataTable();
                        dtTempPolice = tempPolice();
                        SessionWrapper.session_PoliceReport = dtTempPolice;

                        this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                        this.gvPoliceReport.DataBind();

                        //SceneSketch
                        dtTempSceneSketch = new DataTable();
                        dtTempSceneSketch = tempSceneSketch();
                        SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                        this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                        this.gvSceneSketch.DataBind();

                        //ExtenuatingCondition
                        dtTempExtenautingcond = new DataTable();
                        dtTempExtenautingcond = tempExtenautingcondition();
                        SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                        this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                        this.gvExtenuatingcondition.DataBind();

                        //EmployeeInterview
                        dtTempEmployeeInterview = new DataTable();
                        dtTempEmployeeInterview = tempEmployeeInterview();
                        SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                        this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
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
                                Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                            }
                        }
                    }
                }
            }
            if (Session["Case_Employee"] != null)
            {
                User user = (User)Session["Case_Employee"];
                txtEmployeeName.Text = user.Firstname;
                txtLastName.Text = user.Lastname;
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

        protected void btnSavenewcase_header_Click(object sender, EventArgs e)
        {
            CreateNewCase();
        }

        protected void btnSaveNewCase_footer_Click(object sender, EventArgs e)
        {
            CreateNewCase();
        }
        /// <summary>
        /// on save case
        /// </summary>
        private void CreateNewCase()
        {
            try
            {
                ComplianceDAO insertCase = new ComplianceDAO();
                insertCase.c_case_id_pk = Guid.NewGuid().ToString();
                insertCase.u_user_id_fk = SessionWrapper.u_userid;
                //insertCase.c_case_number = lblCaseNumber.Text;
                insertCase.c_case_title = txtCaseTitle.Text;
                insertCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
                //insertCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                insertCase.c_case_type_fk = uccb1.uc_values;
                insertCase.c_case_status =ddlCaseStatus.SelectedValue;
                insertCase.c_employee_name = txtEmployeeName.Text;
                insertCase.c_employee_last_name = txtLastName.Text;
                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                insertCase.c_employee_dob = birthDate;

                int hireday = Convert.ToInt32(doh_hire_day.Items[doh_hire_day.SelectedIndex].Value);
                int hiremonth = Convert.ToInt16(ddlHireMonth.SelectedValue);
                int hireyear = Convert.ToInt32(ddlHireYear.SelectedValue);
                DateTime hireDate = new DateTime(hireyear, hiremonth, hireday);
                insertCase.c_employee_hire_date = hireDate;


                //insertCase.c_employee_dob = Convert.ToDateTime(txtDateOfBirth.Text, culture);
                //insertCase.c_employee_hire_date = Convert.ToDateTime(txtEmployeHireDate.Text, culture);
                insertCase.c_employee_id = txtEmployeeId.Text;
                insertCase.c_ssn = txtLastFourDigitOfSSN.Text;
                insertCase.c_supervisor = txtSupervisor.Text;
                insertCase.c_incident_location = txtIncidentLocation.Text;
                insertCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                insertCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                insertCase.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                int day1 = Convert.ToInt32(doh_date_in_time_day.Items[doh_date_in_time_day.SelectedIndex].Value);
                int month1 = Convert.ToInt16(ddlDateInTitleMonth.SelectedValue);
                int year1 = Convert.ToInt32(ddlDateInTitleYear.SelectedValue);
                insertCase.c_date_in_title = new DateTime(year1, month1, day1);
                insertCase.c_note = txtNote.Text;
                insertCase.c_root_cause_analysic_info = txtRootCauseAnalysisDetails.Text;
                insertCase.c_corrective_action_info = txtCorrectiveActionDetails.Text;
                // insertCase.c_osha_300_case_outcome = string.Empty;
                //int DaysfromWork;
                //int.TryParse(txtDaysAwayFromWork.Text, out DaysfromWork);
                // insertCase.c_osha_300_days_away_from_work = DaysfromWork;
                //DateTime? dateofdeath = null;
                //DateTime tempdateofdeath;
                //if (DateTime.TryParseExact(txtDateOfDeath.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempdateofdeath))
                // {
                //   dateofdeath = tempdateofdeath;
                // }
                //insertCase.c_osha_300_date_of_death = dateofdeath;
                //insertCase.c_osha_300_type_of_illness = ddlTypeOfIllness.SelectedValue;
                //int daysofrestriction;
                //int.TryParse(txtDaysOfRestrictions.Text, out daysofrestriction);
                //insertCase.c_osha_300_days_of_restriction = daysofrestriction;
                //insertCase.c_osha_300_info = txtOSHA300info.Text;
                //insertCase.c_osha_301_worker_gender = ddlWorkerGender.SelectedValue;
                //DateTime? workstarttime = null;
                //DateTime tempWorkStartTime;
                //if (DateTime.TryParse(WorkStartTime.Date.ToString(), out tempWorkStartTime))
                //{
                //    workstarttime = tempWorkStartTime;
                //}
                //insertCase.c_osha_301_work_start_time = workstarttime;
                //insertCase.c_osha_301_physician = txtPhysician.Text;
                //insertCase.c_osha_301_treatment_facilities = txtTreatMentFacility.Text;
                //insertCase.c_osha_301_emergency_room = chkEmergencyRoom.Checked;
                //insertCase.c_osha_301_hospitalized = chkHospitalized.Checked;
                //insertCase.c_osha_301_address1 = txtAddress1.Text;
                //insertCase.c_osha_301_address2 = txtAddress2.Text;
                //insertCase.c_osha_301_address3 = txtAddress3.Text;
                //insertCase.c_osha_301_city = txtCity.Text;
                //insertCase.c_osha_301_state = txtState.Text;
                //insertCase.c_osha_301_zip = txtZip.Text;
                //insertCase.c_osha_301_info_1 = txtOSHA301Info1.Text;
                //insertCase.c_osha_301_info_2 = txtOSHA301Info2.Text;
                //insertCase.c_osha_301_info_3 = txtOSHA301Info3.Text;
                //insertCase.c_osha_301_info_4 = txtOSHA301Info4.Text;
                insertCase.c_custom_01 = txtCustom01.Text;
                insertCase.c_custom_02 = txtCustom02.Text;
                insertCase.c_custom_03 = txtCustom03.Text;
                insertCase.c_custom_04 = txtCustom04.Text;
                insertCase.c_custom_05 = txtCustom05.Text;
                insertCase.c_custom_06 = txtCustom06.Text;
                insertCase.c_custom_07 = txtCustom07.Text;
                insertCase.c_custom_08 = txtCustom08.Text;
                insertCase.c_custom_09 = txtCustom09.Text;
                insertCase.c_custom_10 = txtCustom10.Text;
                insertCase.c_custom_11 = txtCustom11.Text;
                insertCase.c_custom_12 = txtCustom12.Text;
                insertCase.c_custom_13 = txtCustom13.Text;
                insertCase.c_timezoneId = ddlTimezone.SelectedValue;
                insertCase.c_case_date = (DateTime)SessionWrapper.casedate;
                insertCase.c_miris_witness = ConvertDataTableToXml(SessionWrapper.session_witness);
                insertCase.c_miris_photo = ConvertDataTableToXml(SessionWrapper.session_Photo);
                insertCase.c_miris_police_report = ConvertDataTableToXml(SessionWrapper.session_PoliceReport);
                insertCase.c_miris_scene_sketch = ConvertDataTableToXml(SessionWrapper.session_SceneSketch);
                insertCase.c_miris_employee_interview = ConvertDataTableToXml(SessionWrapper.session_EmployeeInterview);
                insertCase.c_miris_extenuating_condition = ConvertDataTableToXml(SessionWrapper.session_ExtenuatingCondition);
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    DataTable dtCaseId = new DataTable();
                    miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                    insertCase.c_case_number = miris.c_case_number;
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }
                }

                int error = ComplianceBLL.InsertCase(insertCase);
                if (error != -1)
                {
                    ////WITENSS
                    //foreach (DataRow dr in SessionWrapper.session_witness.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.InsertWitness(insertCase);
                    //}
                    ////PoliceReport
                    //foreach (DataRow dr in SessionWrapper.session_PoliceReport.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.InsertPoliceReport(insertCase);
                    //}
                    ////Photo
                    //foreach (DataRow dr in SessionWrapper.session_Photo.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.Insertphoto(insertCase);
                    //}
                    ////SceneSketch
                    //foreach (DataRow dr in SessionWrapper.session_SceneSketch.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.InsertSceneSketch(insertCase);
                    //}
                    ////ExtenuatingCondition
                    //foreach (DataRow dr in SessionWrapper.session_ExtenuatingCondition.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.InsertExtenuatingCondition(insertCase);
                    //}

                    ////EmployeeInterview
                    //foreach (DataRow dr in SessionWrapper.session_EmployeeInterview.Rows)
                    //{
                    //    insertCase.c_file_guid = dr["c_file_guid"].ToString();
                    //    insertCase.c_file_name = dr["c_file_name"].ToString();
                    //    ComplianceBLL.InsertEmployeeInterview(insertCase);
                    //}
                    Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(insertCase.c_case_id_pk) + "&Succ=" + SecurityCenter.EncryptText("insert"), false);
                }
                else
                {
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
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// on complete case
        /// </summary>
        /// <param name="CaseStatus"></param>
        private void CompleteCase(string CaseStatus)
        {
            try
            {
                ComplianceDAO insertCase = new ComplianceDAO();
                insertCase.c_case_id_pk = Guid.NewGuid().ToString();
                insertCase.u_user_id_fk = SessionWrapper.u_userid;
                //insertCase.c_case_number = lblCaseNumber.Text;
                insertCase.c_case_title = txtCaseTitle.Text;
                insertCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
               // insertCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                insertCase.c_case_type_fk = uccb1.uc_values;
                insertCase.c_case_status = CaseStatus;
                //ddlCaseStatus.SelectedValue;
                insertCase.c_employee_name = txtEmployeeName.Text;
                insertCase.c_employee_last_name = txtLastName.Text;
                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                insertCase.c_employee_dob = birthDate;

                int hireday = Convert.ToInt32(doh_hire_day.Items[doh_hire_day.SelectedIndex].Value);
                int hiremonth = Convert.ToInt16(ddlHireMonth.SelectedValue);
                int hireyear = Convert.ToInt32(ddlHireYear.SelectedValue);
                DateTime hireDate = new DateTime(hireyear, hiremonth, hireday);
                insertCase.c_employee_hire_date = hireDate;

                //insertCase.c_employee_dob = Convert.ToDateTime(txtDateOfBirth.Text, culture);
                //insertCase.c_employee_hire_date = Convert.ToDateTime(txtEmployeHireDate.Text, culture);
                insertCase.c_employee_id = txtEmployeeId.Text;
                insertCase.c_ssn = txtLastFourDigitOfSSN.Text;
                insertCase.c_supervisor = txtSupervisor.Text;
                insertCase.c_incident_location = txtIncidentLocation.Text;
                insertCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                insertCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                insertCase.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                int day1 = Convert.ToInt32(doh_date_in_time_day.Items[doh_date_in_time_day.SelectedIndex].Value);
                int month1 = Convert.ToInt16(ddlDateInTitleMonth.SelectedValue);
                int year1 = Convert.ToInt32(ddlDateInTitleYear.SelectedValue);
                insertCase.c_date_in_title = new DateTime(year1, month1, day1);
                insertCase.c_note = txtNote.Text;
                insertCase.c_root_cause_analysic_info = txtRootCauseAnalysisDetails.Text;
                insertCase.c_corrective_action_info = txtCorrectiveActionDetails.Text;
                // insertCase.c_osha_300_case_outcome = string.Empty;
                //int DaysfromWork;
                //int.TryParse(txtDaysAwayFromWork.Text, out DaysfromWork);
                // insertCase.c_osha_300_days_away_from_work = DaysfromWork;
                //DateTime? dateofdeath = null;
                //DateTime tempdateofdeath;
                //if (DateTime.TryParseExact(txtDateOfDeath.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempdateofdeath))
                // {
                //   dateofdeath = tempdateofdeath;
                // }
                //insertCase.c_osha_300_date_of_death = dateofdeath;
                //insertCase.c_osha_300_type_of_illness = ddlTypeOfIllness.SelectedValue;
                //int daysofrestriction;
                //int.TryParse(txtDaysOfRestrictions.Text, out daysofrestriction);
                //insertCase.c_osha_300_days_of_restriction = daysofrestriction;
                //insertCase.c_osha_300_info = txtOSHA300info.Text;
                //insertCase.c_osha_301_worker_gender = ddlWorkerGender.SelectedValue;
                //DateTime? workstarttime = null;
                //DateTime tempWorkStartTime;
                //if (DateTime.TryParse(WorkStartTime.Date.ToString(), out tempWorkStartTime))
                //{
                //    workstarttime = tempWorkStartTime;
                //}
                //insertCase.c_osha_301_work_start_time = workstarttime;
                //insertCase.c_osha_301_physician = txtPhysician.Text;
                //insertCase.c_osha_301_treatment_facilities = txtTreatMentFacility.Text;
                //insertCase.c_osha_301_emergency_room = chkEmergencyRoom.Checked;
                //insertCase.c_osha_301_hospitalized = chkHospitalized.Checked;
                //insertCase.c_osha_301_address1 = txtAddress1.Text;
                //insertCase.c_osha_301_address2 = txtAddress2.Text;
                //insertCase.c_osha_301_address3 = txtAddress3.Text;
                //insertCase.c_osha_301_city = txtCity.Text;
                //insertCase.c_osha_301_state = txtState.Text;
                //insertCase.c_osha_301_zip = txtZip.Text;
                //insertCase.c_osha_301_info_1 = txtOSHA301Info1.Text;
                //insertCase.c_osha_301_info_2 = txtOSHA301Info2.Text;
                //insertCase.c_osha_301_info_3 = txtOSHA301Info3.Text;
                //insertCase.c_osha_301_info_4 = txtOSHA301Info4.Text;
                insertCase.c_custom_01 = txtCustom01.Text;
                insertCase.c_custom_02 = txtCustom02.Text;
                insertCase.c_custom_03 = txtCustom03.Text;
                insertCase.c_custom_04 = txtCustom04.Text;
                insertCase.c_custom_05 = txtCustom05.Text;
                insertCase.c_custom_06 = txtCustom06.Text;
                insertCase.c_custom_07 = txtCustom07.Text;
                insertCase.c_custom_08 = txtCustom08.Text;
                insertCase.c_custom_09 = txtCustom09.Text;
                insertCase.c_custom_10 = txtCustom10.Text;
                insertCase.c_custom_11 = txtCustom11.Text;
                insertCase.c_custom_12 = txtCustom12.Text;
                insertCase.c_custom_13 = txtCustom13.Text;
                insertCase.c_timezoneId = ddlTimezone.SelectedValue;
                insertCase.c_case_date = (DateTime)SessionWrapper.casedate;
                insertCase.c_miris_witness = ConvertDataTableToXml(SessionWrapper.session_witness);
                insertCase.c_miris_photo = ConvertDataTableToXml(SessionWrapper.session_Photo);
                insertCase.c_miris_police_report = ConvertDataTableToXml(SessionWrapper.session_PoliceReport);
                insertCase.c_miris_scene_sketch = ConvertDataTableToXml(SessionWrapper.session_SceneSketch);
                insertCase.c_miris_employee_interview = ConvertDataTableToXml(SessionWrapper.session_EmployeeInterview);
                insertCase.c_miris_extenuating_condition = ConvertDataTableToXml(SessionWrapper.session_ExtenuatingCondition);
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    DataTable dtCaseId = new DataTable();
                    miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                    insertCase.c_case_number = miris.c_case_number;
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }
                }

                int error = ComplianceBLL.InsertCase(insertCase);
                if (error != -1)
                {
                    if (isApprover != false)
                    {
                        Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx", false);
                    }
                    else
                    {
                        isApprover = true;
                    }
                }
                else
                {
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
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                    }
                }
            }

        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }

        protected void btnCancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }
        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCase(caseid);
                ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(DateTime.Now.ToString()).ToShortDateString();


                ddlCaseCategory.SelectedValue = miris.c_case_category_value;
                DataTable dtCaseId = new DataTable();
                ComplianceDAO caseNumber = new ComplianceDAO();
                caseNumber = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                lblCaseNumber.Text = caseNumber.c_case_number;
                //lblCaseNumber.Text = miris.c_case_number;
                txtCaseTitle.Text = miris.c_case_title + "_Copy";
                ddlCaseTypes.SelectedValue = miris.c_case_type_value;
                ddlCaseStatus.SelectedValue = miris.c_case_status_value;
                txtEmployeeName.Text = miris.c_employee_name;
                txtLastName.Text = miris.c_employee_last_name;
                dob_day.SelectedIndex = miris.c_employee_dob.Day;
                ddlMonth.SelectedValue = miris.c_employee_dob.Month.ToString();
                ddlYear.SelectedValue = miris.c_employee_dob.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "dob", "checkdateofbirth();", true); 

                doh_hire_day.SelectedIndex = miris.c_employee_hire_date.Day;
                ddlHireMonth.SelectedValue = miris.c_employee_hire_date.Month.ToString();
                ddlHireYear.SelectedValue = miris.c_employee_hire_date.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "hiredate", "checkhiredate();", true);

                //txtDateOfBirth.Text = Convert.ToDateTime(miris.c_employee_dob).ToShortDateString();
                //txtEmployeHireDate.Text = Convert.ToDateTime(miris.c_employee_hire_date).ToShortDateString();
                txtEmployeeId.Text = miris.c_employee_id;
                txtLastFourDigitOfSSN.Text = miris.c_ssn;
                txtSupervisor.Text = miris.c_supervisor;
                txtIncidentLocation.Text = miris.c_incident_location;
                txtIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date).ToShortDateString();
                IncidentTime.Date = miris.c_incident_time;
                IncidentTime.SetTime(miris.incident_HH, miris.incident_MM, IncidentTime.AmPm);
                ddlEmployeeReportLocation.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                {
                    s_establishment_id_pk = "",
                    s_establishment_city = "",
                    s_establishment_name = "",
                    s_establishment_status_id_fk = "app_ddl_active_text"
                });
                if (miris.c_date_in_title.HasValue)
                {
                    doh_date_in_time_day.SelectedIndex = miris.c_date_in_title.Value.Day;
                    ddlDateInTitleMonth.SelectedValue = miris.c_date_in_title.Value.Month.ToString();
                    ddlDateInTitleYear.SelectedValue = miris.c_date_in_title.Value.Year.ToString();
                }
                ddlEmployeeReportLocation.DataTextField = "s_establishment_name";
                ddlEmployeeReportLocation.DataValueField = "s_establishment_system_id_pk";
                ddlEmployeeReportLocation.DataBind();
                ddlEmployeeReportLocation.Items.Insert(0, new ListItem("", ""));
                ddlEmployeeReportLocation.SelectedValue = miris.c_employee_report_location;
                txtNote.Text = miris.c_note;
                txtRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                txtCorrectiveActionDetails.Text = miris.c_corrective_action_info;
                //ddlCaseOutCome.SelectedValue = miris.c_osha_300_case_outcome_value;
                // txtDaysAwayFromWork.Text = Convert.ToInt32(miris.c_osha_300_days_away_from_work).ToString();
                //if (!string.IsNullOrEmpty(miris.c_osha_300_date_of_death.ToString()))
                //{
                //     txtDateOfDeath.Text = Convert.ToDateTime(miris.c_osha_300_date_of_death).ToShortDateString();
                // }
                // ddlTypeOfIllness.SelectedValue = miris.c_osha_300_type_of_illness_value;
                // txtDaysOfRestrictions.Text = Convert.ToInt32(miris.c_osha_300_days_of_restriction).ToString();
                // txtOSHA300info.Text = miris.c_osha_300_info;
                // ddlWorkerGender.SelectedValue = miris.c_osha_301_worker_gender;
                // if (!string.IsNullOrEmpty(miris.c_osha_301_work_start_time.ToString()))
                // {
                //   WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                //  WorkStartTime.SetTime(miris.workstart_HH, miris.workstart_MM, WorkStartTime.AmPm);
                //txtWorkStartTime.Text = Convert.ToDateTime(miris.c_osha_301_work_start_time).ToShortDateString();
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
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                    }
                }
            }
        }

        protected void btnUploadWitness_Click(object sender, EventArgs e)
        {
            btnUploadWitness.Enabled = false;
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
                    if (!string.IsNullOrEmpty(hdWitness.Value))
                    {
                        EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_witness);
                        hdWitness.Value = "";
                       
                    }
                    else
                    {
                        AddDataToTempWitness(c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_witness);
                       
                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }
            btnUploadWitness.Enabled = true;
            this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
            this.gvAddWitness.DataBind();
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
                    if (!string.IsNullOrEmpty(hdPolice.Value))
                    {
                        EditDataToTempPolice(Convert.ToInt32(hdPolice.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_PoliceReport);
                        hdPolice.Value = "";
                    }
                    else
                    {
                        AddDataToTempPolice(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_PoliceReport);
                    }
                }
            }
            this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
            this.gvPoliceReport.DataBind();
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
                    if (!string.IsNullOrEmpty(hdPhoto.Value))
                    {
                        EditDataToTempPhoto(Convert.ToInt32(hdPhoto.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_Photo);
                        hdPhoto.Value = "";
                    }
                    else
                    {
                        AddDataToTempPhoto(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_Photo);
                    }
                }
            }

            this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
            this.gvPhoto.DataBind();
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
                    if (!string.IsNullOrEmpty(hdSceneSketch.Value))
                    {
                        EditDataToTempSceneSketch(Convert.ToInt32(hdSceneSketch.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_SceneSketch);
                        hdSceneSketch.Value = "";
                    }
                    else
                    {
                        AddDataToTempSceneSketch(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_SceneSketch);
                    }
                }
            }

            this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
            this.gvSceneSketch.DataBind();
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
                    if (!string.IsNullOrEmpty(hdExtenautingcond.Value))
                    {
                        EditDataToTempExtenautingcondition(Convert.ToInt32(hdExtenautingcond.Value), c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_ExtenuatingCondition);
                        hdExtenautingcond.Value = "";

                    }
                    else
                    {
                        AddDataToTempExtenautingcondition(c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_ExtenuatingCondition);
                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }
            this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenuatingcondition.DataBind();
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
                    if (!string.IsNullOrEmpty(hdEmployeeInterview.Value))
                    {
                        EditDataToTempEmployeeInterview(Convert.ToInt32(hdEmployeeInterview.Value), c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                        hdEmployeeInterview.Value = "";
                    }
                    else
                    {
                        AddDataToTempEmployeeInterview(c_file_guid + c_file_extension, c_file_name,txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }

            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }

        //witenss
        private DataTable tempWitness()
        {
            DataTable dtTempWitness = new DataTable();
            DataColumn dtTempWitnessColumn;
            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_witness_id_pk";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_case_id_fk";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_file_guid";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_file_name";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_name";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_contact_info";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            return dtTempWitness;
        }
        private void AddDataToTempWitness(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempWitness)
        {
            DataRow row;
            row = dtTempWitness.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempWitness.Rows.Add(row);
        }
        private void EditDataToTempWitness(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempWitness)
        {
            dtTempWitness.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempWitness.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempWitness.Rows[rowIndex]["c_name"] = c_name;
            dtTempWitness.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempWitness.AcceptChanges();
        }
        private void DeleteDataToTempWitness(int rowIndex, DataTable dtTempWitness)
        {
            dtTempWitness.Rows[rowIndex].Delete();
            dtTempWitness.AcceptChanges();
            this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
            this.gvAddWitness.DataBind();
        }

        //photo
        private DataTable tempPhoto()
        {
            DataTable dtTempPhoto = new DataTable();
            DataColumn dtTempPhotoColumn;
            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_photo_id_pk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_case_id_fk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_file_guid";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_file_name";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);
            return dtTempPhoto;
        }
        private void AddDataToTempPhoto(string c_file_guid, string c_file_name, DataTable dtTempPhoto)
        {
            DataRow row;
            row = dtTempPhoto.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempPhoto.Rows.Add(row);
        }
        private void EditDataToTempPhoto(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempPhoto.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempPhoto.AcceptChanges();
        }
        private void DeleteDataToTempPhoto(int rowIndex, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex].Delete();
            dtTempPhoto.AcceptChanges();
            this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
            this.gvPhoto.DataBind();
        }

        //policereport
        private DataTable tempPolice()
        {
            DataTable dtTempPoliceReport = new DataTable();
            DataColumn dtTempPoliceReportColumn;
            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_police_report_id_pk";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_case_id_fk";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_file_guid";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_file_name";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);
            return dtTempPoliceReport;
        }

        private void AddDataToTempPolice(string c_file_guid, string c_file_name, DataTable dtTempPoliceReport)
        {
            DataRow row;
            row = dtTempPoliceReport.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempPoliceReport.Rows.Add(row);
        }
        private void EditDataToTempPolice(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempPoliceReport)
        {
            dtTempPoliceReport.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempPoliceReport.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempPoliceReport.AcceptChanges();
        }
        private void DeleteDataToTempPolice(int rowIndex, DataTable dtTempPoliceReport)
        {
            dtTempPoliceReport.Rows[rowIndex].Delete();
            dtTempPoliceReport.AcceptChanges();
            this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
            this.gvPoliceReport.DataBind();
        }

        //scence sketch
        private DataTable tempSceneSketch()
        {
            DataTable dtTempSceneSketch = new DataTable();
            DataColumn dtTempSceneSketchColumn;
            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_scene_sketch_id_pk";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_case_id_fk";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_file_guid";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_file_name";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            return dtTempSceneSketch;
        }
        private void AddDataToTempSceneSketch(string c_file_guid, string c_file_name, DataTable dtTempSceneSketch)
        {
            DataRow row;
            row = dtTempSceneSketch.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempSceneSketch.Rows.Add(row);
        }
        private void EditDataToTempSceneSketch(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempSceneSketch)
        {
            dtTempSceneSketch.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempSceneSketch.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempSceneSketch.AcceptChanges();
        }
        private void DeleteDataToTempSceneSketch(int rowIndex, DataTable dtTempSceneSketch)
        {
            dtTempSceneSketch.Rows[rowIndex].Delete();
            dtTempSceneSketch.AcceptChanges();
            this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
            this.gvSceneSketch.DataBind();
        }

        //Extenautingcondition
        private DataTable tempExtenautingcondition()
        {
            DataTable dtTempExtenautingcondition = new DataTable();
            DataColumn dtTempExtenautingconditionColumn;
            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_extenauting_id_pk";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_case_id_fk";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_file_guid";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_file_name";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_name";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_contact_info";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            return dtTempExtenautingcondition;
        }
        private void AddDataToTempExtenautingcondition(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempExtenautingcondition)
        {
            DataRow row;
            row = dtTempExtenautingcondition.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempExtenautingcondition.Rows.Add(row);
        }
        private void EditDataToTempExtenautingcondition(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempExtenautingcondition.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempExtenautingcondition.Rows[rowIndex]["c_name"] = c_name;
            dtTempExtenautingcondition.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempExtenautingcondition.AcceptChanges();
        }
        private void DeleteDataToTempExtenautingcondition(int rowIndex, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex].Delete();
            dtTempExtenautingcondition.AcceptChanges();
            this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenuatingcondition.DataBind();
        }

        //EmployeeInterview
        private DataTable tempEmployeeInterview()
        {
            DataTable dtTempEmployeeInterview = new DataTable();
            DataColumn dtTempEmployeeInterviewColumn;
            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_employee_interivew_id_pk";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_case_id_fk";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_file_guid";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_file_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_contact_info";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            return dtTempEmployeeInterview;
        }
        private void AddDataToTempEmployeeInterview(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempEmployeeInterview)
        {
            DataRow row;
            row = dtTempEmployeeInterview.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempEmployeeInterview.Rows.Add(row);
        }
        private void EditDataToTempEmployeeInterview(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempEmployeeInterview.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempEmployeeInterview.Rows[rowIndex]["c_name"] = c_name;
            dtTempEmployeeInterview.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempEmployeeInterview.AcceptChanges();
        }
        private void DeleteDataToTempEmployeeInterview(int rowIndex, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex].Delete();
            dtTempEmployeeInterview.AcceptChanges();
            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }

        protected void gvAddWitness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvAddWitness.DataKeys[rowIndex][0].ToString();
                hdWitness.Value = e.CommandArgument.ToString();
                txtName.Text = gvAddWitness.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvAddWitness.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "witness", "Showeditpopup('witness');", true);
                mpeWitness.Show();
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
                DeleteDataToTempWitness(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_witness);
            }
        }
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
                string caseId = gvPoliceReport.DataKeys[rowIndex][0].ToString();
                hdPolice.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "policereport", "Showeditpopup('policereport');", true);
                mpePoliceReport.Show();
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
                DeleteDataToTempPolice(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_PoliceReport);
            }
        }

        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvPhoto.DataKeys[rowIndex][0].ToString();
                hdPhoto.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photo", "Showeditpopup('photo');", true);
                mpePhoto.Show();
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
                DeleteDataToTempPhoto(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_Photo);
            }
        }

        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                hdSceneSketch.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scenesketch", "Showeditpopup('scenesketch');", true);
                mpeSceneSketch.Show();
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
                DeleteDataToTempSceneSketch(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_SceneSketch);
            }
        }

        protected void gvExtenuatingcondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                hdExtenautingcond.Value = e.CommandArgument.ToString();
                txtName.Text = gvExtenuatingcondition.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvExtenuatingcondition.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "extenuatingcondition", "Showeditpopup('extenuatingcondition');", true);
                mpeExtenautingCondition.Show();
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
                DeleteDataToTempExtenautingcondition(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_ExtenuatingCondition);
            }
        }

        protected void gvEmployeeInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                hdEmployeeInterview.Value = e.CommandArgument.ToString();
                txtName.Text = gvEmployeeInterview.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvEmployeeInterview.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "employeeinterview", "Showeditpopup('employeeinterview');", true);
                mpeEmployeeInterview.Show();
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
                DeleteDataToTempEmployeeInterview(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_EmployeeInterview);
            }
        }

        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO miris = new ComplianceDAO();
                DataTable dtCaseId = new DataTable();
                string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
                miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                if (!string.IsNullOrEmpty(copyCaseId))
                {
                    if (caseCategory == "MV")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else if (caseCategory == "OI")
                    {
                        Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                }
                else
                {
                    if (caseCategory == "MV")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else if (caseCategory == "OI")
                    {
                        Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else if (caseCategory == "PD")
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                }



                lblCaseNumber.Text = miris.c_case_number;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                    }
                }
            }
        }

        protected void ddlTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComplianceDAO miris = new ComplianceDAO();
            miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(ddlTimezone.SelectedValue));
            IncidentTime.Date = miris.c_incident_date;
            //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
        }

        protected void btnReset_Header_Click(object sender, EventArgs e)
        {
            reset();
        }
        protected void btnReset_Footer_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            //clear session
            SessionWrapper.session_witness = null;
            SessionWrapper.session_EmployeeInterview = null;
            SessionWrapper.session_ExtenuatingCondition = null;
            SessionWrapper.session_Photo = null;
            SessionWrapper.session_PoliceReport = null;
            SessionWrapper.session_SceneSketch = null;
            hdEmployeeInterview.Value = "";
            hdExtenautingcond.Value = "";
            hdPhoto.Value = "";
            hdPolice.Value = "";
            hdSceneSketch.Value = "";
            hdWitness.Value = "";
            if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
            {
                try
                {
                    caseId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);
                    IncidentTime.Date = Convert.ToDateTime(DateTime.Now.ToString());
                    populatecase(caseId);
                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_case_id_pk = caseId;

                    //witness
                    DataTable dtGetWitness = new DataTable();
                    dtGetWitness = ComplianceBLL.GetWitness(miris);
                    dtTempWitness = new DataTable();
                    dtTempWitness = dtGetWitness;
                    SessionWrapper.session_witness = dtTempWitness;
                    this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                    this.gvAddWitness.DataBind();

                    //photo
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.Getphoto(miris);
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = dtGetPhoto;
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();

                    //police report
                    DataTable dtGetPoliceReport = new DataTable();
                    dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                    dtTempPolice = new DataTable();
                    dtTempPolice = dtGetPoliceReport;
                    SessionWrapper.session_PoliceReport = dtTempPolice;
                    this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                    this.gvPoliceReport.DataBind();

                    //SceneSketch
                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = dtGetSceneSketch;
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();

                    //Extenautingcondition
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = dtGetExtenautingCondition;
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenuatingcondition.DataBind();

                    //EmployeeInterview
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = dtGetEmployeeInterview;
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
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
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }
                }

            }
            else
            {
                try
                {
                    ddlTimezone.SelectedValue = SessionWrapper.u_timezone;
                    //lblCaseNumber.Text = SecurityCenter.DecryptText(Request.QueryString["category"]).ToUpper() + SecurityCenter.DecryptText(Request.QueryString["id"]);
                    ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["cid"]);
                    ddlCaseTypes.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["type"]);
                    txtCaseTitle.Text = SecurityCenter.DecryptText(Request.QueryString["title"]);
                    ComplianceDAO miris = new ComplianceDAO();
                    DataTable dtCaseId = new DataTable();
                    miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                    lblCaseNumber.Text = miris.c_case_number;

                    //witenss
                    dtTempWitness = new DataTable();
                    dtTempWitness = tempWitness();
                    SessionWrapper.session_witness = dtTempWitness;
                    this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                    this.gvAddWitness.DataBind();

                    //photo
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = tempPhoto();
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();

                    //Police report
                    dtTempPolice = new DataTable();
                    dtTempPolice = tempPolice();
                    SessionWrapper.session_PoliceReport = dtTempPolice;
                    this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                    this.gvPoliceReport.DataBind();

                    //SceneSketch
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = tempSceneSketch();
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();

                    //ExtenuatingCondition
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = tempExtenautingcondition();
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenuatingcondition.DataBind();

                    //EmployeeInterview
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = tempEmployeeInterview();
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                    this.gvEmployeeInterview.DataBind();

                    txtEmployeeName.Text = "";
                    txtLastName.Text = "";
                    //txtDateOfBirth.Text = "";
                    //txtEmployeHireDate.Text = "";
                    txtEmployeeId.Text = "";
                    txtLastFourDigitOfSSN.Text = "";
                    txtSupervisor.Text = "";
                    txtIncidentLocation.Text = "";
                    txtIncidentDate.Text = "";
                  
                    txtNote.Text = "";
                    txtRootCauseAnalysisDetails.Text = "";
                    txtCorrectiveActionDetails.Text = "";
                    //ddlCaseOutCome.SelectedIndex = 0;
                    // txtDaysAwayFromWork.Text = "";
                    //txtDateOfDeath.Text = "";
                    // ddlTypeOfIllness.SelectedIndex = 0;
                    // txtDaysOfRestrictions.Text = "";
                    //txtOSHA300info.Text = "";
                    // ddlWorkerGender.SelectedIndex = 0;
                    //txtPhysician.Text = "";
                    //txtTreatMentFacility.Text = "";
                    //chkEmergencyRoom.Checked = false;
                    //chkHospitalized.Checked = false;
                    //txtAddress1.Text = "";
                    //txtAddress2.Text = "";
                    //txtAddress3.Text = "";
                    //txtCity.Text = "";
                    //txtState.Text = "";
                    //txtZip.Text = "";
                    //txtOSHA301Info1.Text = "";
                    //txtOSHA301Info2.Text = "";
                    //txtOSHA301Info3.Text = "";
                    //txtOSHA301Info4.Text = "";
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

                    miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
                    IncidentTime.Date = miris.c_incident_date;
                    //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void gvAddWitness_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        ///<summary>
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
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
                isApprover = true;
                CompleteCase(ddlCaseStatus.Items.FindByText("Closed").Value);
            }
            else
            {
                isApprover = false;
                CompleteCase(ddlCaseStatus.Items.FindByText("Open").Value);
                if (isApprover == true)
                {
                    mpCompleteCase.Show();                    
                }
            }
        }

        protected void btnFooterCompleteCase_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                isApprover = true;
                CompleteCase(ddlCaseStatus.Items.FindByText("Closed").Value);
            }
            else
            {
                isApprover = false;
                CompleteCase(ddlCaseStatus.Items.FindByText("Open").Value);
                if (isApprover == true)
                {
                    mpCompleteCase.Show();
                }
            }
        }
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
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("by");
                sbCompleteCase.Append("<br><br>");
                sbCompleteCase.Append(SessionWrapper.u_username);
                Utility.SendEMailMessage(mailAddresses, "***Request for Complete Case***", sbCompleteCase.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "Send Successfully" + " " + toEmailid;

                Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx?Succ=" + SecurityCenter.EncryptText("insert"), false);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccamiris-01", ex.Message);
                    }
                }
            }
        }
    }
}