using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance
{
    public partial class ccemiris_01 : BasePage
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

        CultureInfo culture = new CultureInfo("en-US");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;<a href=/Compliance/MIRIS/cccmiris-01.aspx>" + LocalResources.GetLabel("app_miris_text") + "</a>&nbsp;" + ">&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_case_text") + "</a>";
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["Edit"])))
                {
                    edit = SecurityCenter.DecryptText(Request.QueryString["Edit"]);
                }

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                if (!IsPostBack)
                {
                    try
                    {
                        PopulateYearDropDown();
                        //case category
                        ddlCaseCategory.DataSource = ComplianceBLL.GetMirisCaseCategory(SessionWrapper.CultureName, "ccemiris-01");
                        ddlCaseCategory.DataBind();

                        //case type
                        ddlCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "ccemiris-01");
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                            }
                        }
                    }

                    btnViewCaseDesc_header.OnClientClick = "window.open('ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit) + "','',''); return true;";
                    btnViewCase_footer.OnClientClick = "window.open('ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit) + "','',''); return true;";
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                            }
                        }
                    }
                    SessionWrapper.session_witness = null;
                    SessionWrapper.session_EmployeeInterview = null;
                    SessionWrapper.session_ExtenuatingCondition = null;
                    SessionWrapper.session_Photo = null;
                    SessionWrapper.session_PoliceReport = null;
                    SessionWrapper.session_SceneSketch = null;
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                            }
                        }
                    }
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
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                    }
                }

            }
        }



        protected void btnViewCase_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit));
        }

        protected void btnCancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }

        protected void btnViewCaseDesc_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(edit));
        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }
        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCase(edit);
                ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(miris.c_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblCaseNumber.Text = miris.c_case_number;
                txtCaseTitle.Text = miris.c_case_title;
                ddlCaseCategory.SelectedValue = miris.c_case_category_value;
                //ViewState["CaseCategory"] = ddlCaseCategory.SelectedValue;
                ddlCaseTypes.SelectedValue = miris.c_case_type_value;
                ddlCaseStatus.SelectedValue = miris.c_case_status_value;
                txtEmployeeName.Text = miris.c_employee_name;

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
                txtLastFourDigitOfSSN.Text = miris.c_ssn;
                txtSupervisor.Text = miris.c_supervisor;
                txtIncidentLocation.Text = miris.c_incident_location;
                txtIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date, culture).ToString("MM/dd/yyyy");
                IncidentTime.Date = miris.c_incident_time;
                IncidentTime.SetTime(miris.incident_HH, miris.incident_MM, IncidentTime.AmPm);
                txtEmployeeReportLocation.Text = miris.c_employee_report_location;
                txtNote.Text = miris.c_note;
                txtRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                txtCorrectiveActionDetails.Text = miris.c_corrective_action_info;
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                    miris.c_file_id = caseFileId;                     
                    miris.c_case_id_pk = edit;
                    miris.s_locale_culture = SessionWrapper.CultureName;
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                        }
                    }
                }
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempEmployeeInterview(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_EmployeeInterview);
            }
        }

        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string strCaseNumber = lblCaseNumber.Text;
                //strCaseNumber = strCaseNumber.Replace(ViewState["CaseCategory"].ToString().ToUpper(), ddlCaseCategory.SelectedValue.ToUpper());
                //ViewState["CaseCategory"] = ddlCaseCategory.SelectedValue.ToUpper();
                ////ComplianceDAO miris = new ComplianceDAO();

                //lblCaseNumber.Text = strCaseNumber;

                ComplianceDAO miris = new ComplianceDAO();
                DataTable dtCaseId = new DataTable();
                miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), edit);

                if (ddlCaseCategory.SelectedValue == "app_ddl_occupation_injury_text")
                {
                    Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(edit) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                else if (ddlCaseCategory.SelectedValue == "app_ddl_motor_vehicle_incident_text")
                {
                    Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(edit) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                else
                {
                    Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(edit) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                lblCaseNumber.Text = miris.c_case_number;
                ViewState["CaseCategory"] = miris.c_case_number;
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
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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

        protected void btnSavecase_header_Click(object sender, EventArgs e)
        {
            UpdateCase(ddlCaseStatus.SelectedValue);
        }

        protected void btnSaveCase_footer_Click(object sender, EventArgs e)
        {
            UpdateCase(ddlCaseStatus.SelectedValue);

        }
        private void UpdateCase(string c_case_status)
        {
            try
            {
                ComplianceDAO updateCase = new ComplianceDAO();
                updateCase.c_case_id_pk = edit;
                updateCase.u_user_id_fk = SessionWrapper.u_userid;
                updateCase.c_case_title = txtCaseTitle.Text;
                updateCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
                updateCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                updateCase.c_case_status = c_case_status;
                updateCase.c_employee_name = txtEmployeeName.Text;

                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                updateCase.c_employee_dob = birthDate;

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
                updateCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                updateCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                updateCase.c_employee_report_location = txtEmployeeReportLocation.Text;
                updateCase.c_note = txtNote.Text;
                updateCase.c_root_cause_analysic_info = txtRootCauseAnalysisDetails.Text;
                updateCase.c_corrective_action_info = txtCorrectiveActionDetails.Text;
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


                if (!string.IsNullOrEmpty((string)ViewState["CaseCategory"]))
                {


                    updateCase.c_case_number = (string)ViewState["CaseCategory"];
                }
                else
                {
                    updateCase.c_case_number = lblCaseNumber.Text;
                }


                int error = ComplianceBLL.UpdateCase(updateCase);
                if (error != -1)
                {
                    error_msg.Style.Add("display", "none");
                    success_msg.Style.Add("display", "block");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_update_succ_text");
                    if (ddlCaseStatus.SelectedItem.Text == "Closed")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx", false);
                    }
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
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
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
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                    }
                }
            }
        }

        private void PopulateYearDropDown()
        {
            int startYear = 1900;
            int endYear = DateTime.Now.Year;
            ddlYear.Items.Clear();
            ddlHireYear.Items.Clear();
            ListItem li = new ListItem("Year:", "-1");
            li.Selected = true;
            ddlYear.Items.Add(li);
            ddlHireYear.Items.Add(li);

            for (int i = endYear; i >= startYear; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlHireYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
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
                success_msg.InnerHtml = "Request Was Send Successfully to" + " " + approverInfo.Username;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ceoi-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ceoi-01", ex.Message);
                    }
                }
            }
        }
    }
}