using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Net.Mail;
using Microsoft.Reporting.WebForms;
using Ionic.Zip;
using System.Globalization;

namespace ComplicanceFactor.Compliance.MIRIS
{
    public partial class cvoi_01 : System.Web.UI.Page
    {
        string view;
        #region "Private Member Variables"
        private string _path = "~/Compliance/MIRIS/Upload/Witness/";
        private string _pathPolice = "~/Compliance/MIRIS/Upload/Police/";
        private string _pathPhoto = "~/Compliance/MIRIS/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/MIRIS/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/MIRIS/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/MIRIS/Upload/EmployeeInterview/";
        private string _temppath = "~/Compliance/MIRIS/tempCaseFiles/";
        private string _pathEmployeeStatement = "~/Compliance/MIRIS/Upload/EmployeeStatement/";
        private string _pathPolicies = "~/Compliance/MIRIS/Upload/Policies/";
        private string _pathObservation = "~/Compliance/MIRIS/Upload/Observation/";
        private string _pathIncidentHistory = "~/Compliance/MIRIS/Upload/IncidentHistory/";
        private string _pathTrainingHistory = "~/Compliance/MIRIS/Upload/TrainingHistory/";

        #endregion
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionWrapper.u_username))
            {
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["View"])))
                {
                    view = SecurityCenter.DecryptText(Request.QueryString["View"]);
                }
                if (!IsPostBack)
                {
                    populatecase(view);
                }
            }
            else
            {
                Response.Redirect("~/glp-01.aspx");
            }

        }

        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCaseOI(caseid);
                //ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(miris.c_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblPageCaseNumber.Text = miris.c_case_number;
                lblCaseNumber.Text = miris.c_case_number;
                lblCaseTitle.Text = miris.c_case_title;
                lblCaseCategory.Text = miris.c_case_category_text;
                lblCaseTypes.Text = miris.c_case_type_text;
                lblCaseStatus.Text = miris.c_status_text;
                lblEmployeeName.Text = miris.c_employee_name;
                lblDateOfBirth.Text = Convert.ToDateTime(miris.c_employee_dob).ToShortDateString();
                lblEmployeeHireDate.Text = Convert.ToDateTime(miris.c_employee_hire_date).ToShortDateString();
                lblEmployeeId.Text = miris.c_employee_id;
                lblLastFourDigitOfSSN.Text = miris.c_ssn;
                lblSupervisor.Text = miris.c_supervisor;
                lblIncidentLocation.Text = miris.c_incident_location;
                lblIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date).ToShortDateString();
                lblIncidentTime.Text = miris.incident_HH_text;
                lblEmployeeReportLocation.Text = miris.c_employee_report_location;
                lblNote.Text = miris.c_note_text;
                lblRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                lblCorrectiveActionDetails.Text = miris.c_corrective_action_info;
                //lblCaseOutCome.Text = miris.c_outcome_text;
                //lblDaysAwayFromWork.Text = miris.c_osha_300_days_away_from_work_text;
                //lblDateOfDeath.Text = miris.c_osha_300_date_of_death_text;
                //lblTypeofIllness.Text = miris.c_illness_type_text;
                //lblDaysOfRestrictions.Text = miris.c_osha_300_days_of_restriction_text;
                //lblOSHA300info.Text = miris.c_osha_300_info;
                //lblWorkerGender.Text = miris.c_osha_301_worker_gender;
                //lblWorkStartTime.Text = miris.workstart_HH_text;
                //lblPhysician.Text = miris.c_osha_301_physician;
                //lblTreatmentFacility.Text = miris.c_osha_301_treatment_facilities;
                //lblEmergencyRoom.Text = miris.c_osha_301_emergency_room_text;
                //lblHospitalized.Text = miris.c_osha_301_hospitalized_text;
                //chkEmergencyRoom.Checked = miris.c_osha_301_emergency_room;
                //chkHospitalized.Checked = miris.c_osha_301_hospitalized;
                //lblAddress1.Text = miris.c_osha_301_address1;
                //lblAddress2.Text = miris.c_osha_301_address2;
                //lblAddress3.Text = miris.c_osha_301_address3;
                //lblCity.Text = miris.c_osha_301_city;
                //lblState.Text = miris.c_osha_301_state;
                //lblZipCode.Text = miris.c_osha_301_zip;
                //lblOSHA301Info1.Text = miris.c_osha_301_info_1;
                //lblOSHA301Info2.Text = miris.c_osha_301_info_2;
                //lblOSHA301Info3.Text = miris.c_osha_301_info_3;
                //lblOSHA301Info4.Text = miris.c_osha_301_info_4;
                lblCustom01.Text = miris.c_custom_01;
                lblCustom02.Text = miris.c_custom_02;
                lblCustom03.Text = miris.c_custom_03;
                lblCustom04.Text = miris.c_custom_04;
                lblCustom05.Text = miris.c_custom_05;
                lblCustom06.Text = miris.c_custom_06;
                lblCustom07.Text = miris.c_custom_07;
                lblCustom08.Text = miris.c_custom_08;
                lblCustom09.Text = miris.c_custom_09;
                lblCustom10.Text = miris.c_custom_10;
                lblCustom11.Text = miris.c_custom_11;
                lblCustom12.Text = miris.c_custom_12;
                lblCustom13.Text = miris.c_custom_13;

                if (!string.IsNullOrEmpty(miris.c_time_and_date_notified.ToString()))
                {
                    lblTimeandDateNotified.Text = Convert.ToDateTime(miris.c_time_and_date_notified).ToShortDateString();
                }              


                //lblTimeandDateNotified.Text = miris.c_time_and_date_notified.ToShortDateString();

                lblJobTitle.Text = miris.c_job_title;
                lblDepartmentCode.Text = miris.c_department_code;
                if (miris.c_privacy_case == true)
                {
                    lblPrivacyCase.Text = "Yes";
                }
                else
                {
                    lblPrivacyCase.Text = "No";
                }
                if (miris.c_company_owned == true)
                {
                    lblCompanyOwned.Text = "Yes";
                }
                else
                {
                    lblCompanyOwned.Text = "No";
                }
                lblLocationDescription.Text = miris.c_location_description;
                lblIncidentDescription.Text = miris.c_incident_description;
                lblInjuryComplaint.Text = miris.c_injury_complaint;
                lblInjuryType.Text = miris.c_injury_type_fk;
                lblInjuryCause.Text = miris.c_injury_cause_fk;
                lblContributingFactors.Text = miris.c_contributing_factors;
                lblContributingObjects.Text = miris.c_contributing_objects;
                lblSeverity.Text = miris.c_severity_fk;
                lblHospital.Text = miris.c_hospital;
                lblTreatmentDescription.Text = miris.c_treatment_description;
                lblDART.Text = miris.c_dart;
                lblEstLWDs.Text = miris.c_est_lwd;
                lblActualLWDandOSHA.Text = miris.c_actual_lwd_and_osha_lwd;
                lblLightDuty.Text = miris.c_light_duty;
                lblEstLd.Text = miris.c_est_ld;
                lblActualLDandOSHA.Text = miris.c_actual_ld_and_osha_restricted;
                lblRestrictedorTransferred.Text = miris.c_restricted_or_transferred;
                lblFirstDayofDaysAway.Text = miris.c_firstday_of_days_away;
                lblFirstdayRestrictedorTransferred.Text = miris.c_firstday_of_days_restricted_or_transferred;
                lblLastDatDaysAway.Text = miris.c_lastday_days_away;
                lblLastDayRestrictedorTransferred.Text = miris.c_lastday_days_restricted_or_transferred;

                miris.c_case_id_pk = caseid;
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
                //EmployeeStatment
                DataTable dtGetEmployeeStatement = new DataTable();
                dtGetEmployeeStatement = ComplianceBLL.GetEmployeeStatement(miris);
                this.gvEmployeeStatement.DataSource = dtGetEmployeeStatement;
                this.gvEmployeeStatement.DataBind();
                //Polices
                DataTable dtGetPolicies = new DataTable();
                dtGetPolicies = ComplianceBLL.GetPolicies(miris);
                this.gvPolicies.DataSource = dtGetPolicies;
                this.gvPolicies.DataBind();
                //Training History
                DataTable dtTrainingHistory = new DataTable();
                dtTrainingHistory = ComplianceBLL.GetTrainingHistory(miris);
                this.gvTrainingHistory.DataSource = dtTrainingHistory;
                this.gvTrainingHistory.DataBind();
                //Observation
                DataTable dtObservation = new DataTable();
                dtObservation = ComplianceBLL.GetObservation(miris);
                this.gvObservation.DataSource = dtObservation;
                this.gvObservation.DataBind();
                //IncidentHistory
                DataTable dtIncidentHistory = new DataTable();
                dtIncidentHistory = ComplianceBLL.GetIncidentHistory(miris);
                this.gvIncidentHistory.DataSource = dtIncidentHistory;
                this.gvIncidentHistory.DataBind();

                lblTimeZone.Text = miris.u_time_zone_location;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message);
                    }
                }
            }
        }
        protected void gvAddWitness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
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
        }
        protected void gvPoliceReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
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
        }
        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
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
        }
        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string SceneSketchFileId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                string SceneSketchFileName = gvSceneSketch.DataKeys[rowIndex][1].ToString();
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
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SceneSketchFileName + "\"");
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
        }
        protected void gvExtenuatingcondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingconditionFileId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                string ExtenuatingConditionFileName = gvExtenuatingcondition.DataKeys[rowIndex][1].ToString();
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
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ExtenuatingConditionFileName + "\"");
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
        }
        protected void gvEmployeeInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string EmployeeInterviewFileId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                string EmployeeInterviewFileName = gvEmployeeInterview.DataKeys[rowIndex][1].ToString();
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
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + EmployeeInterviewFileName + "\"");
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
        }
        protected void gvEmployeeStatement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string EmployeeStatementFileId = gvEmployeeStatement.DataKeys[rowIndex][0].ToString();
                string EmployeeStatementFileName = gvEmployeeStatement.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathEmployeeStatement + EmployeeStatementFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + EmployeeStatementFileName + "\"");
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
        }
        protected void gvPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string PolicesFileId = gvPolicies.DataKeys[rowIndex][0].ToString();
                string PolicesFileName = gvPolicies.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPolicies + PolicesFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + PolicesFileName + "\"");
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
        }
        protected void gvTrainingHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string TrainingHistoryFileId = gvTrainingHistory.DataKeys[rowIndex][0].ToString();
                string TrainingHistoryFileName = gvTrainingHistory.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathTrainingHistory + TrainingHistoryFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + TrainingHistoryFileName + "\"");
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
        }
        protected void gvObservation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ObservationFileId = gvObservation.DataKeys[rowIndex][0].ToString();
                string ObservationFileName = gvObservation.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathObservation + ObservationFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ObservationFileName + "\"");
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
        }
        protected void gvIncidentHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string IncidentHistoryFileId = gvIncidentHistory.DataKeys[rowIndex][0].ToString();
                string IncidentHistoryFileName = gvIncidentHistory.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathIncidentHistory + IncidentHistoryFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + IncidentHistoryFileName + "\"");
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

        protected void btnSendtoMyMobile_header_Click(object sender, EventArgs e)
        {
            SendToMyMobile();
        }
        protected void btnSendtoMyMobile_footer_Click(object sender, EventArgs e)
        {
            SendToMyMobile();
        }
        private void SendToMyMobile()
        {
            try
            {
                string PHONE = SessionWrapper.u_mobile_number;
                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                {
                    string MATRIXURL = "http://www.smsmatrix.com/matrix";
                    string USERNAME = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                    string PASSWORD = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);
                    StringBuilder sbSendCaseDetails = new StringBuilder();
                    string TXT = Server.UrlEncode("ComplianceFactors");
                    string q = "username=" + USERNAME +
                     "&password=" + PASSWORD +
                     "&phone=" + PHONE +
                     "&txt=" + TXT;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(MATRIXURL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = q.Length;

                    StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                    streamOut.Write(q);
                    streamOut.Close();

                    StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                    string res = streamIn.ReadToEnd();
                    //Console.WriteLine("Matrix API Response:\n" + res);
                    streamIn.Close();
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + PHONE;
                }
                else
                {
                    //Error message if mobile number is empty
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerHtml = LocalResources.GetText("app_mobile_number_not_registered_error_wrong"); ;
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = LocalResources.GetText("app_case_send_error_text");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnSendtoMyEmail_footer_Click(object sender, EventArgs e)
        {

            SendToMyEmail();
        }

        protected void btnSendtoMyEmail_header_Click(object sender, EventArgs e)
        {

            SendToMyEmail();
        }
        private void SendToMyEmail()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                {
                    sendCaseDetails(SessionWrapper.u_email_id);
                }
                else
                {
                    //Error message if email id is empty
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerHtml = "Email ID was not registered";
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSendMutiple_Click(object sender, EventArgs e)
        {
            try
            {
                sendCaseDetails(txtMultipeEmailAddress.Text);
                txtMultipeEmailAddress.Text = "";
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml =  "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01", ex.Message);
                    }
                }
            }

        }

        private void sendCaseDetails(string toEmailAddress)
        {
            string toEmailid = toEmailAddress;
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
                // for email theme
                SystemThemes userTheme = new SystemThemes();
                userTheme = SystemThemeBLL.GetThemeForEmail(SessionWrapper.u_userid);

                //Daily Email Report
                string filePath = string.Empty;
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/MIRIS/MirisEmailTemplate/coi.htm");
                StringBuilder sbCaseDetails = new StringBuilder(Utility.GetHtmlTemplate(filePath));

                sbCaseDetails.Replace("@s_theme_head_logo_file_name", userTheme.s_theme_head_logo_file_name);
                sbCaseDetails.Replace("@s_theme_report_logo_file_name", userTheme.s_theme_report_logo_file_name);
                sbCaseDetails.Replace("@s_theme_notification_logo_file_name", Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_notification_logo_file_name);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_hex_value", userTheme.s_theme_css_tag_section_head_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_text_hex_value", userTheme.s_theme_css_tag_section_head_text_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_border_hex_value", userTheme.s_theme_css_tag_section_head_border_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_body_text_hex_value", userTheme.s_theme_css_tag_body_text_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_main_background_hex_value", userTheme.s_theme_css_tag_main_background_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_foot_top_line_hex_value", userTheme.s_theme_css_tag_foot_top_line_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_foot_bot_line_hex_value", userTheme.s_theme_css_tag_foot_bot_line_hex_value);

                sbCaseDetails.Replace("@app_case_page_title", LocalResources.GetLabel("app_case_details_text") + lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_number_text", LocalResources.GetLabel("app_case_number_text"));
                sbCaseDetails.Replace("@lblCaseNumber", lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_title_text", LocalResources.GetLabel("app_case_title_text"));
                sbCaseDetails.Replace("@lblCaseTitle", lblCaseTitle.Text);
                sbCaseDetails.Replace("@app_case_date_text", LocalResources.GetLabel("app_case_date_text"));
                sbCaseDetails.Replace("@lblCaseDate", lblCaseDate.Text);
                sbCaseDetails.Replace("@app_case_category_text", LocalResources.GetLabel("app_case_category_text"));
                sbCaseDetails.Replace("@lblCaseCategory", lblCaseCategory.Text);
                sbCaseDetails.Replace("@app_case_types_text", LocalResources.GetLabel("app_case_types_text"));
                sbCaseDetails.Replace("@lblCaseTypes", lblCaseTypes.Text);
                sbCaseDetails.Replace("@app_case_status_text", LocalResources.GetLabel("app_case_status_text"));
                sbCaseDetails.Replace("@lblCaseStatus", lblCaseStatus.Text);
                sbCaseDetails.Replace("@app_case_description_text", LocalResources.GetLabel("app_case_description_text"));
                sbCaseDetails.Replace("@app_employee_name_text", LocalResources.GetLabel("app_employee_name_text"));
                sbCaseDetails.Replace("@lblEmployeeName", lblEmployeeName.Text);
                sbCaseDetails.Replace("@app_date_of_birth_text", LocalResources.GetLabel("app_date_of_birth_text"));
                sbCaseDetails.Replace("@lblDateOfBirth", lblDateOfBirth.Text);
                sbCaseDetails.Replace("@app_employee_hire_date_text", LocalResources.GetLabel("app_employee_hire_date_text"));
                sbCaseDetails.Replace("@lblEmployeeHireDate", lblEmployeeHireDate.Text);
                sbCaseDetails.Replace("@app_employee_id_text", LocalResources.GetLabel("app_employee_id_text"));
                sbCaseDetails.Replace("@lblEmployeeId", lblEmployeeId.Text);
                sbCaseDetails.Replace("@app_last_digit_of_ssn", LocalResources.GetLabel("app_last_digit_of_ssn#_text"));
                sbCaseDetails.Replace("@lblLastFourDigitOfSSN", lblLastFourDigitOfSSN.Text);
                sbCaseDetails.Replace("@app_supervisor_text", LocalResources.GetLabel("app_supervisor_text"));
                sbCaseDetails.Replace("@lblSupervisor", lblSupervisor.Text);
                sbCaseDetails.Replace("@app_incident_location_text", LocalResources.GetLabel("app_incident_location_text"));
                sbCaseDetails.Replace("@lblIncidentLocation", lblIncidentLocation.Text);
                sbCaseDetails.Replace("@app_incident_date_text", LocalResources.GetLabel("app_incident_date_text"));
                sbCaseDetails.Replace("@lblIncidentDate", lblIncidentDate.Text);
                sbCaseDetails.Replace("@app_incident_time_text", LocalResources.GetLabel("app_incident_time_text"));
                sbCaseDetails.Replace("@lblIncidentTime", lblIncidentTime.Text);
                sbCaseDetails.Replace("@app_employee_report_location_text", LocalResources.GetLabel("app_employee_report_location_text"));
                sbCaseDetails.Replace("@lblEmployeeReportLocation", lblEmployeeReportLocation.Text);
                sbCaseDetails.Replace("@app_timezone_text", LocalResources.GetLabel("app_timezone_text"));
                sbCaseDetails.Replace("@lblTimeZone", lblTimeZone.Text);
                sbCaseDetails.Replace("@app_note_text", LocalResources.GetLabel("app_note_text"));
                sbCaseDetails.Replace("@lblNote", lblNote.Text);
                sbCaseDetails.Replace("@app_additional_Information_text", LocalResources.GetLabel("app_additional_Information_text"));
                sbCaseDetails.Replace("@app_witness(es)_text", LocalResources.GetLabel("app_witness(es)_text"));
                sbCaseDetails.Replace("@app_police_reports(s)_text", LocalResources.GetLabel("app_police_reports(s)_text"));
                sbCaseDetails.Replace("@app_photo(s)_text", LocalResources.GetLabel("app_photo(s)_text"));
                sbCaseDetails.Replace("@app_scene_sketch(es)_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition(s)_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview(s)_text", LocalResources.GetLabel("app_employee_interview(s)_text"));

                sbCaseDetails.Replace("@app_employee_statement_text", LocalResources.GetLabel("app_employee_statement_text"));
                sbCaseDetails.Replace("@app_policies_procedures_text", LocalResources.GetLabel("app_policies_procedures_text"));
                sbCaseDetails.Replace("@app_training_history_text", LocalResources.GetLabel("app_training_history_text"));
                sbCaseDetails.Replace("@app_observation_text", LocalResources.GetLabel("app_observation_text"));
                sbCaseDetails.Replace("@app_incident_history_text", LocalResources.GetLabel("app_incident_history_text"));

                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text", LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text", LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_corrective_action_details_text", LocalResources.GetLabel("app_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                sbCaseDetails.Replace("@app_time_and_date_notified", LocalResources.GetLabel("app_time_and_date_notified_text"));
                sbCaseDetails.Replace("@lblTimeandDateNotified",lblTimeandDateNotified.Text);
                sbCaseDetails.Replace("@app_job_title", LocalResources.GetLabel("app_job_title_text"));
                sbCaseDetails.Replace("@lblJobTitle", lblJobTitle.Text);
                sbCaseDetails.Replace("@app_department_code", LocalResources.GetLabel("app_dept_code_text"));
                sbCaseDetails.Replace("@lblDepartmentCode", lblDepartmentCode.Text);
                sbCaseDetails.Replace("@app_privacy_case", LocalResources.GetLabel("app_privacy_case_text"));
                sbCaseDetails.Replace("@lblPrivacyCase", lblPrivacyCase.Text);
                sbCaseDetails.Replace("@app_company_owned", LocalResources.GetLabel("app_company_owned_text"));
                sbCaseDetails.Replace("@lblCompanyOwned", lblCompanyOwned.Text);
                sbCaseDetails.Replace("@app_location_description", LocalResources.GetLabel("app_location_description_text"));
                sbCaseDetails.Replace("@lblLocationDescription", lblLocationDescription.Text);
                sbCaseDetails.Replace("@app_incident_description", LocalResources.GetLabel("app_incident_description_text"));
                sbCaseDetails.Replace("@lblIncidentDescription", lblIncidentDescription.Text);
                sbCaseDetails.Replace("@app_injury_complaint", LocalResources.GetLabel("app_injury_complaint_text"));
                sbCaseDetails.Replace("@lblInjuryComplaint", lblInjuryComplaint.Text);
                sbCaseDetails.Replace("@app_injury_type", LocalResources.GetLabel("app_injury_type_text"));
                sbCaseDetails.Replace("@lblInjuryType", lblInjuryType.Text);
                sbCaseDetails.Replace("@app_injury_cause", LocalResources.GetLabel("app_injury_cause_text"));
                sbCaseDetails.Replace("@lblInjuryCause", lblInjuryCause.Text);
                sbCaseDetails.Replace("@app_contributing_factors", LocalResources.GetLabel("app_contributing_factors_text"));
                sbCaseDetails.Replace("@lblContributingFactors", lblContributingFactors.Text);
                sbCaseDetails.Replace("@app_contributing_objects", LocalResources.GetLabel("app_contributing_objects_text"));
                sbCaseDetails.Replace("@lblContributingObjects", lblContributingObjects.Text);
                sbCaseDetails.Replace("@app_severity", LocalResources.GetLabel("app_severity_text"));
                sbCaseDetails.Replace("@lblSeverity", lblSeverity.Text);
                sbCaseDetails.Replace("@app_hospital", LocalResources.GetLabel("app_hospital_text"));
                sbCaseDetails.Replace("@lblHospital", lblHospital.Text);
                sbCaseDetails.Replace("@app_additional_details_text", LocalResources.GetLabel("app_additional_details_text"));
                sbCaseDetails.Replace("@app_treatment_description", LocalResources.GetLabel("app_treatment_description_text"));
                sbCaseDetails.Replace("@lblTreatmentDescription", lblTreatmentDescription.Text);
                sbCaseDetails.Replace("@app_work_status_text", LocalResources.GetLabel("app_work_status_text"));
                sbCaseDetails.Replace("@app_dart", LocalResources.GetLabel("app_dart_text"));
                sbCaseDetails.Replace("@lblDART", lblDART.Text);
                sbCaseDetails.Replace("@app_est_lwds", LocalResources.GetLabel("app_esr_lwds_text"));
                sbCaseDetails.Replace("@lblEstLWDs", lblEstLWDs.Text);
                sbCaseDetails.Replace("@app_actual_lwd_and_osha_lwd_text", LocalResources.GetLabel("app_actual_lwd_and_osha_lwd_text"));
                sbCaseDetails.Replace("@lblActualLWDandOSHA",lblActualLWDandOSHA.Text);
                sbCaseDetails.Replace("@app_light_duty", LocalResources.GetLabel("app_light_duty_text"));
                sbCaseDetails.Replace("@lblLightDuty", lblLightDuty.Text);
                sbCaseDetails.Replace("@app_est_ld", LocalResources.GetLabel("app_est_ld_text"));
                sbCaseDetails.Replace("@lblEstLd", lblEstLd.Text);
                sbCaseDetails.Replace("@app_actual_ld_and_osha_restricted_text", LocalResources.GetLabel("app_actual_ld_and_osha_restricted_text"));
                sbCaseDetails.Replace("@lblActualLDandOSHA", lblActualLDandOSHA.Text);
                sbCaseDetails.Replace("@app_restricted_or_transferred", LocalResources.GetLabel("app_restricted_transferred_text"));
                sbCaseDetails.Replace("@lblRestrictedorTransferred", lblRestrictedorTransferred.Text);
                sbCaseDetails.Replace("@app_first_day_of_days_away", LocalResources.GetLabel("app_first_day_of_days_away_text"));
                sbCaseDetails.Replace("@lblFirstDayofDaysAway", lblFirstDayofDaysAway.Text);
                sbCaseDetails.Replace("@app_first_day_restricted_or_transferred_text", LocalResources.GetLabel("app_first_days_restricted_tranferred_text"));
                sbCaseDetails.Replace("@lblFirstDayRestrictedorTransferred", lblFirstdayRestrictedorTransferred.Text);
                sbCaseDetails.Replace("@app_last_day_days_away", LocalResources.GetLabel("app_last_day_of_days_away_text"));
                sbCaseDetails.Replace("@lblLastDatDaysAway", lblLastDatDaysAway.Text);
                sbCaseDetails.Replace("@app_last_day_restricted_or_transferred", LocalResources.GetLabel("app_last_days_restricted_transferred_text"));
                sbCaseDetails.Replace("@lblLastDayRestrictedorTransferred", lblLastDayRestrictedorTransferred.Text);
                // sbCaseDetails.Replace("@app_osha_300_information_text", LocalResources.GetLabel("app_osha_300_information_text"));
                // sbCaseDetails.Replace("@app_case_outcome_text", LocalResources.GetLabel("app_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_days_away_from_work_text", LocalResources.GetLabel("app_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_days_of_restrictions_text", LocalResources.GetLabel("app_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_data_of_death_text", LocalResources.GetLabel("app_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_type_of_illness_text", LocalResources.GetLabel("app_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_describe_injury_or_illness_text", LocalResources.GetLabel("app_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_oosha_301_information_text", LocalResources.GetLabel("app_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_worker_gender_text", LocalResources.GetLabel("app_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_works_start_time_text", LocalResources.GetLabel("app_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_physician_text", LocalResources.GetLabel("app_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_treatment_facility_text", LocalResources.GetLabel("app_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_emergency_room_text", LocalResources.GetLabel("app_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_hospitalized_text", LocalResources.GetLabel("app_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_address_1_text", LocalResources.GetLabel("app_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_address_2_text", LocalResources.GetLabel("app_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_address_3_text", LocalResources.GetLabel("app_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_zip_text", LocalResources.GetLabel("app_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_what_was_the_employee_text", LocalResources.GetLabel("app_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_what_happened_tell_text", LocalResources.GetLabel("app_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_what_was_the_injury_text", LocalResources.GetLabel("app_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_object_or_substance_text", LocalResources.GetLabel("app_what_object_or_substance_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info4", lblOSHA301Info4.Text);
                sbCaseDetails.Replace("@app_custom_fields_text", LocalResources.GetLabel("app_custom_fields_text"));
                sbCaseDetails.Replace("@app_custom_01_text", LocalResources.GetLabel("app_custom_01_text"));
                sbCaseDetails.Replace("@app_custom_02_text", LocalResources.GetLabel("app_custom_02_text"));
                sbCaseDetails.Replace("@app_custom_03_text", LocalResources.GetLabel("app_custom_03_text"));
                sbCaseDetails.Replace("@app_custom_04_text", LocalResources.GetLabel("app_custom_04_text"));
                sbCaseDetails.Replace("@app_custom_05_text", LocalResources.GetLabel("app_custom_05_text"));
                sbCaseDetails.Replace("@app_custom_06_text", LocalResources.GetLabel("app_custom_06_text"));
                sbCaseDetails.Replace("@app_custom_07_text", LocalResources.GetLabel("app_custom_07_text"));
                sbCaseDetails.Replace("@app_custom_08_text", LocalResources.GetLabel("app_custom_08_text"));
                sbCaseDetails.Replace("@app_custom_09_text", LocalResources.GetLabel("app_custom_09_text"));
                sbCaseDetails.Replace("@app_custom_10_text", LocalResources.GetLabel("app_custom_10_text"));
                sbCaseDetails.Replace("@app_custom_11_text", LocalResources.GetLabel("app_custom_11_text"));
                sbCaseDetails.Replace("@app_custom_12_text", LocalResources.GetLabel("app_custom_12_text"));
                sbCaseDetails.Replace("@app_custom_13_text", LocalResources.GetLabel("app_custom_13_text"));
                sbCaseDetails.Replace("@wp_app_release_number", LocalResources.GetText("wp_app_release_number"));
                sbCaseDetails.Replace("@lblCustom01", lblCustom01.Text);
                sbCaseDetails.Replace("@lblCustom02", lblCustom02.Text);
                sbCaseDetails.Replace("@lblCustom03", lblCustom03.Text);
                sbCaseDetails.Replace("@lblCustom04", lblCustom04.Text);
                sbCaseDetails.Replace("@lblCustom05", lblCustom05.Text);
                sbCaseDetails.Replace("@lblCustom06", lblCustom06.Text);
                sbCaseDetails.Replace("@lblCustom07", lblCustom07.Text);
                sbCaseDetails.Replace("@lblCustom08", lblCustom08.Text);
                sbCaseDetails.Replace("@lblCustom09", lblCustom09.Text);
                sbCaseDetails.Replace("@lblCustom10", lblCustom10.Text);
                sbCaseDetails.Replace("@lblCustom11", lblCustom11.Text);
                sbCaseDetails.Replace("@lblCustom12", lblCustom12.Text);
                sbCaseDetails.Replace("@lblCustom13", lblCustom13.Text);
                sbCaseDetails.Replace("@app_required_fields_text", LocalResources.GetLabel("app_required_fields_text"));

                ComplianceDAO miris = new ComplianceDAO();
                miris.c_case_id_pk = view;
                miris.s_locale_culture = SessionWrapper.CultureName;
                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(miris);
                StringBuilder sbWitness = new StringBuilder();
                if (dtGetWitness.Rows.Count > 0)
                {
                    sbWitness.Append("<table>");
                    for (int i = 0; i <= dtGetWitness.Rows.Count - 1; i++)
                    {
                        sbWitness.Append("<tr>");
                        sbWitness.Append("<td valign=top style=width:256px>");
                        sbWitness.Append(dtGetWitness.Rows[i]["c_file_name"].ToString());
                        sbWitness.Append("</td>");

                        sbWitness.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetWitness.Rows[i]["c_name"].ToString() + "</b>");
                        sbWitness.Append("</td>");

                        sbWitness.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetWitness.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbWitness.Append("</td>");
                        sbWitness.Append("</tr>");
                    }
                    sbWitness.Append("</table>");
                }
                sbCaseDetails.Replace("@gvAddWitness", sbWitness.ToString());
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(miris);
                StringBuilder sbPhoto = new StringBuilder();
                if (dtGetPhoto.Rows.Count > 0)
                {
                    sbPhoto.Append("<table>");
                    for (int i = 0; i <= dtGetPhoto.Rows.Count - 1; i++)
                    {
                        sbPhoto.Append("<tr>");
                        sbPhoto.Append("<td>");
                        sbPhoto.Append(dtGetPhoto.Rows[i]["c_file_name"].ToString());
                        sbPhoto.Append("</td>");
                        sbPhoto.Append("</tr>");
                    }
                    sbPhoto.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPhoto", sbPhoto.ToString());
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                StringBuilder sbPoliceReport = new StringBuilder();
                if (dtGetPoliceReport.Rows.Count > 0)
                {
                    sbPoliceReport.Append("<table>");
                    for (int i = 0; i <= dtGetPoliceReport.Rows.Count - 1; i++)
                    {
                        sbPoliceReport.Append("<tr>");
                        sbPoliceReport.Append("<td>");
                        sbPoliceReport.Append(dtGetPoliceReport.Rows[i]["c_file_name"].ToString());
                        sbPoliceReport.Append("</td>");
                        sbPoliceReport.Append("</tr>");
                    }
                    sbPoliceReport.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPoliceReport", sbPoliceReport.ToString());

                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                StringBuilder sbSceneSketch = new StringBuilder();
                if (dtGetSceneSketch.Rows.Count > 0)
                {
                    sbSceneSketch.Append("<table>");
                    for (int i = 0; i <= dtGetSceneSketch.Rows.Count - 1; i++)
                    {
                        sbSceneSketch.Append("<tr>");
                        sbSceneSketch.Append("<td>");
                        sbSceneSketch.Append(dtGetSceneSketch.Rows[i]["c_file_name"].ToString());
                        sbSceneSketch.Append("</td>");
                        sbSceneSketch.Append("</tr>");
                    }
                    sbSceneSketch.Append("</table>");
                }
                sbCaseDetails.Replace("@gvSceneSketch", sbSceneSketch.ToString());

                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                StringBuilder sbExtenautingCondition = new StringBuilder();
                if (dtGetExtenautingCondition.Rows.Count > 0)
                {
                    sbExtenautingCondition.Append("<table>");
                    for (int i = 0; i <= dtGetExtenautingCondition.Rows.Count - 1; i++)
                    {
                        sbExtenautingCondition.Append("<tr>");
                        sbExtenautingCondition.Append("<td valign=top style=width:256px;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["c_file_name"].ToString());
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetExtenautingCondition.Rows[i]["c_name"].ToString() + "</b>");
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetExtenautingCondition.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("</tr>");
                    }
                    sbExtenautingCondition.Append("</table>");
                }
                sbCaseDetails.Replace("@gvExtenuatingcondition", sbExtenautingCondition.ToString());

                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                StringBuilder sbEmployeeInterview = new StringBuilder();
                if (dtGetEmployeeInterview.Rows.Count > 0)
                {
                    sbEmployeeInterview.Append("<table>");
                    for (int i = 0; i <= dtGetEmployeeInterview.Rows.Count - 1; i++)
                    {
                        sbEmployeeInterview.Append("<tr>");
                        sbEmployeeInterview.Append("<td style=width:256px; valign=top>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["c_file_name"].ToString());
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["c_name"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("</tr>");
                    }
                    sbEmployeeInterview.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());

                //EmployeeStatement
                DataTable dtEmployeeStatement = new DataTable();
                dtEmployeeStatement = ComplianceBLL.GetEmployeeStatement(miris);
                StringBuilder sbEmployeeStatement = new StringBuilder();
                if (dtEmployeeStatement.Rows.Count > 0)
                {
                    sbEmployeeStatement.Append("<table>");
                    for (int i = 0; i <= dtEmployeeStatement.Rows.Count - 1; i++)
                    {
                        sbEmployeeStatement.Append("<tr>");
                        sbEmployeeStatement.Append("<td>");
                        sbEmployeeStatement.Append(dtEmployeeStatement.Rows[i]["c_file_name"].ToString());
                        sbEmployeeStatement.Append("</td>");
                        sbEmployeeStatement.Append("</tr>");
                    }
                    sbEmployeeStatement.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeStatement", sbEmployeeStatement.ToString());

                //Polices
                DataTable dtPolices = new DataTable();
                dtPolices = ComplianceBLL.GetPolicies(miris);
                StringBuilder sbPolices = new StringBuilder();
                if (dtPolices.Rows.Count > 0)
                {
                    sbPolices.Append("<table>");
                    for (int i = 0; i <= dtPolices.Rows.Count - 1; i++)
                    {
                        sbPolices.Append("<tr>");
                        sbPolices.Append("<td>");
                        sbPolices.Append(dtPolices.Rows[i]["c_file_name"].ToString());
                        sbPolices.Append("</td>");
                        sbPolices.Append("</tr>");
                    }
                    sbPolices.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPolices", sbPolices.ToString());

                //TrainingHistory
                DataTable dtTrainingHistory = new DataTable();
                dtTrainingHistory = ComplianceBLL.GetTrainingHistory(miris);
                StringBuilder sbTrainingHistory = new StringBuilder();
                if (dtTrainingHistory.Rows.Count > 0)
                {
                    sbTrainingHistory.Append("<table>");
                    for (int i = 0; i <= dtTrainingHistory.Rows.Count - 1; i++)
                    {
                        sbTrainingHistory.Append("<tr>");
                        sbTrainingHistory.Append("<td>");
                        sbTrainingHistory.Append(dtTrainingHistory.Rows[i]["c_file_name"].ToString());
                        sbTrainingHistory.Append("</td>");
                        sbTrainingHistory.Append("</tr>");
                    }
                    sbTrainingHistory.Append("</table>");
                }
                sbCaseDetails.Replace("@gvTrainingHistory", sbTrainingHistory.ToString());

                //Observation
                DataTable dtObservation = new DataTable();
                dtObservation = ComplianceBLL.GetObservation(miris);
                StringBuilder sbObservation = new StringBuilder();
                if (dtObservation.Rows.Count > 0)
                {
                    sbObservation.Append("<table>");
                    for (int i = 0; i <= dtObservation.Rows.Count - 1; i++)
                    {
                        sbObservation.Append("<tr>");
                        sbObservation.Append("<td>");
                        sbObservation.Append(dtObservation.Rows[i]["c_file_name"].ToString());
                        sbObservation.Append("</td>");
                        sbObservation.Append("</tr>");
                    }
                    sbObservation.Append("</table>");
                }
                sbCaseDetails.Replace("@gvObservation", sbObservation.ToString());

                //IncidentHistory
                DataTable dtIncidentHistory = new DataTable();
                dtIncidentHistory = ComplianceBLL.GetIncidentHistory(miris);
                StringBuilder sbIncidentHistory = new StringBuilder();
                if (dtIncidentHistory.Rows.Count > 0)
                {
                    sbIncidentHistory.Append("<table>");
                    for (int i = 0; i <= dtIncidentHistory.Rows.Count - 1; i++)
                    {
                        sbIncidentHistory.Append("<tr>");
                        sbIncidentHistory.Append("<td>");
                        sbIncidentHistory.Append(dtIncidentHistory.Rows[i]["c_file_name"].ToString());
                        sbIncidentHistory.Append("</td>");
                        sbIncidentHistory.Append("</tr>");
                    }
                    sbIncidentHistory.Append("</table>");
                }
                sbCaseDetails.Replace("@gvIncidentHistory", sbIncidentHistory.ToString());

                Utility.SendEMailMessage(mailAddresses, "ComplianceFactors - CaseDetails", sbCaseDetails.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "SendSuccessfully" + " " + toEmailAddress;
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                //error_msg.InnerHtml = LocalResources.GetLabel("app_miris_error_msg_email_mobile");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.htm", ex.Message);
                    }
                }
            }
            txtMultipeEmailAddress.Text = "";
        }
        protected void btnPrintPdf_footer_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        protected void btnPrintPdf_header_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        private void PrintPdf()
        {
            rvMIRIS.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;

            //witness
            DataSet dsWitness = new DataSet();
            DataTable dtWitness = ComplianceBLL.GetWitness(miris);
            dsWitness.Tables.Add(dtWitness.Copy());

            //police report
            DataSet dsPoliceReport = new DataSet();
            DataTable dtPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            dsPoliceReport.Tables.Add(dtPoliceReport.Copy());

            //Police
            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.Getphoto(miris);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch
            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition
            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Extenuating Condition
            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Employee Statement
            DataSet dsEmployeeStatement = new DataSet();
            DataTable dtEmployeeStatement = ComplianceBLL.GetEmployeeStatement(miris);
            dsEmployeeStatement.Tables.Add(dtEmployeeStatement.Copy());

            //Polices
            DataSet dsPolices = new DataSet();
            DataTable dtPolices = ComplianceBLL.GetPolicies(miris);
            dsPolices.Tables.Add(dtPolices.Copy());

            //Training History
            DataSet dsTrainingHistory = new DataSet();
            DataTable dtTrainingHistory = ComplianceBLL.GetTrainingHistory(miris);
            dsTrainingHistory.Tables.Add(dtTrainingHistory.Copy());

            //Observation
            DataSet dsObservation = new DataSet();
            DataTable dtObservation = ComplianceBLL.GetObservation(miris);
            dsObservation.Tables.Add(dtObservation.Copy());

            //IncidentHistory
            DataSet dsIncidentHistory = new DataSet();
            DataTable dtIncidentHistory = ComplianceBLL.GetIncidentHistory(miris);
            dsIncidentHistory.Tables.Add(dtIncidentHistory.Copy());
            try
            {
                dsPdf = ComplianceBLL.createMIRISOIPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message);
                    }
                }

            }
            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvMIRIS.ProcessingMode = ProcessingMode.Local;
            rvMIRIS.LocalReport.EnableExternalImages = true;
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISOIReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_OI_VIEW", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISWitness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPhoto", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISSceneSketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISExtenuatingCondition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeInterview", dsEmployeeInterview.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeStatement", dsEmployeeStatement.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPolices", dsPolices.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISTrainingHistory", dsTrainingHistory.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISObservation", dsObservation.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISIncidentHistory", dsIncidentHistory.Tables[0]));

            byte[] bytes = rvMIRIS.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + lblCaseNumber.Text + ".pdf" + "\"");
            Response.BinaryWrite(bytes); // create the file     
            Response.Flush(); // send it to the client to download  
            Response.End();
            Response.Close();
        }
        private void SavePdf(string filepath)
        {
            rvMIRIS.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;

            //witness
            DataSet dsWitness = new DataSet();
            DataTable dtWitness = ComplianceBLL.GetWitness(miris);
            dsWitness.Tables.Add(dtWitness.Copy());

            //police report
            DataSet dsPoliceReport = new DataSet();
            DataTable dtPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            dsPoliceReport.Tables.Add(dtPoliceReport.Copy());

            //Police
            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.Getphoto(miris);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch
            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition
            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Employee Interview
            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Employee Statement
            DataSet dsEmployeeStatement = new DataSet();
            DataTable dtEmployeeStatement = ComplianceBLL.GetEmployeeStatement(miris);
            dsEmployeeStatement.Tables.Add(dtEmployeeStatement.Copy());

            //Polices
            DataSet dsPolices = new DataSet();
            DataTable dtPolices = ComplianceBLL.GetPolicies(miris);
            dsPolices.Tables.Add(dtPolices.Copy());

            //Training History
            DataSet dsTrainingHistory = new DataSet();
            DataTable dtTrainingHistory = ComplianceBLL.GetTrainingHistory(miris);
            dsTrainingHistory.Tables.Add(dtTrainingHistory.Copy());

            //Observation
            DataSet dsObservation = new DataSet();
            DataTable dtObservation = ComplianceBLL.GetObservation(miris);
            dsObservation.Tables.Add(dtObservation.Copy());

            //IncidentHistory
            DataSet dsIncidentHistory = new DataSet();
            DataTable dtIncidentHistory = ComplianceBLL.GetIncidentHistory(miris);
            dsIncidentHistory.Tables.Add(dtIncidentHistory.Copy());

            try
            {
                dsPdf = ComplianceBLL.createMIRISOIPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message);
                    }
                }
            }
            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvMIRIS.ProcessingMode = ProcessingMode.Local;
            rvMIRIS.LocalReport.EnableExternalImages = true;
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISOIReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_OI_VIEW", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISWitness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPhoto", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISSceneSketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISExtenuatingCondition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeInterview", dsEmployeeInterview.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeStatement", dsEmployeeStatement.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPolices", dsPolices.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISTrainingHistory", dsTrainingHistory.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISObservation", dsObservation.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISIncidentHistory", dsIncidentHistory.Tables[0]));

            byte[] bytes = rvMIRIS.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            using (FileStream fs = File.Create(filepath + lblCaseNumber.Text + ".pdf"))
            {
                fs.Write(bytes, 0, (int)bytes.Length);
            }
        }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        }

        protected void btnSendMultipleMobile_Click(object sender, EventArgs e)
        {
            try
            {
                string MATRIXURL = "http://www.smsmatrix.com/matrix";
                // david phone = 15712138210

                string toPhone = txtMultipeEmailAddress.Text;
                //"compliancefactor.project@gmail.com";
                string[] toPhoneNumber = toPhone.Split(',');
                foreach (string phone in toPhoneNumber)
                {
                    if (phone.Trim() != string.Empty)
                    {
                        string PHONE = phone;
                        string USERNAME = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                        string PASSWORD = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);
                        StringBuilder sbSendCaseDetails = new StringBuilder();
                        string TXT = Server.UrlEncode("Case Number: " + lblCaseNumber.Text + ", " + "Case Title: " + lblCaseTitle.Text + ", " + "Case Date: " + lblCaseDate.Text + ", Case Category: " + lblCaseCategory.Text + ", Case Types: " + lblCaseTypes.Text + ", Case Status: " + lblCaseStatus.Text);
                        string q = "username=" + USERNAME +
                         "&password=" + PASSWORD +
                         "&phone=" + PHONE +
                         "&txt=" + TXT;

                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(MATRIXURL);
                        req.Method = "POST";
                        req.ContentType = "application/x-www-form-urlencoded";
                        req.ContentLength = q.Length;
                        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                        streamOut.Write(q);
                        streamOut.Close();
                        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                        string res = streamIn.ReadToEnd();
                        //Console.WriteLine("Matrix API Response:\n" + res);
                        streamIn.Close();
                        success_msg.Style.Add("display", "block");
                        error_msg.Style.Add("display", "none");
                        success_msg.InnerHtml =  "Send Successfully" + " " + toPhone;
                    }
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.aspx", ex.Message);
                    }
                }

            }
            txtMultipeEmailAddress.Text = "";
        }

        public string CreateCaseDetailPdf()
        {
            string strCaseDetails = string.Empty;
            try
            {
                //Daily Email Report
                string filePath = string.Empty;
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/MIRIS/MirisPdfTemplate/ccvmiris.htm");
                StringBuilder sbCaseDetails = new StringBuilder(Utility.GetHtmlTemplate(filePath));
                sbCaseDetails.Replace("@app_case_page_title", LocalResources.GetLabel("app_case_page_title") + lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_number_text", LocalResources.GetLabel("app_case_number_text"));
                sbCaseDetails.Replace("@lblCaseNumber", lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_title_text", LocalResources.GetLabel("app_case_title_text"));
                sbCaseDetails.Replace("@lblCaseTitle", lblCaseTitle.Text);
                sbCaseDetails.Replace("@app_case_date_text", LocalResources.GetLabel("app_case_date_text"));
                sbCaseDetails.Replace("@lblCaseDate", lblCaseDate.Text);
                sbCaseDetails.Replace("@app_case_category_text", LocalResources.GetLabel("app_case_category_text"));
                sbCaseDetails.Replace("@lblCaseCategory", lblCaseCategory.Text);
                sbCaseDetails.Replace("@app_case_types_text", LocalResources.GetLabel("app_case_types_text"));
                sbCaseDetails.Replace("@lblCaseTypes", lblCaseTypes.Text);
                sbCaseDetails.Replace("@app_case_status_text", LocalResources.GetLabel("app_case_status_text"));
                sbCaseDetails.Replace("@lblCaseStatus", lblCaseStatus.Text);
                sbCaseDetails.Replace("@app_case_description_text", LocalResources.GetLabel("app_case_description_text"));
                sbCaseDetails.Replace("@app_employee_name_text", LocalResources.GetLabel("app_employee_name_text"));
                sbCaseDetails.Replace("@lblEmployeeName", lblEmployeeName.Text);
                sbCaseDetails.Replace("@app_date_of_birth_text", LocalResources.GetLabel("app_date_of_birth_text"));
                sbCaseDetails.Replace("@lblDateOfBirth", lblDateOfBirth.Text);
                sbCaseDetails.Replace("@app_employee_hire_date_text", LocalResources.GetLabel("app_employee_hire_date_text"));
                sbCaseDetails.Replace("@lblEmployeeHireDate", lblEmployeeHireDate.Text);
                sbCaseDetails.Replace("@app_employee_id_text", LocalResources.GetLabel("app_employee_id_text"));
                sbCaseDetails.Replace("@lblEmployeeId", lblEmployeeId.Text);
                sbCaseDetails.Replace("@app_last_digit_of_ssn", LocalResources.GetLabel("app_last_digit_of_ssn#_text"));
                sbCaseDetails.Replace("@lblLastFourDigitOfSSN", lblLastFourDigitOfSSN.Text);
                sbCaseDetails.Replace("@app_supervisor_text", LocalResources.GetLabel("app_supervisor_text"));
                sbCaseDetails.Replace("@lblSupervisor", lblSupervisor.Text);
                sbCaseDetails.Replace("@app_incident_location_text", LocalResources.GetLabel("app_incident_location_text"));
                sbCaseDetails.Replace("@lblIncidentLocation", lblIncidentLocation.Text);
                sbCaseDetails.Replace("@app_incident_date_text", LocalResources.GetLabel("app_incident_date_text"));
                sbCaseDetails.Replace("@lblIncidentDate", lblIncidentDate.Text);
                sbCaseDetails.Replace("@app_incident_time_text", LocalResources.GetLabel("app_incident_time_text"));
                sbCaseDetails.Replace("@lblIncidentTime", lblIncidentTime.Text);
                sbCaseDetails.Replace("@app_employee_report_location_text", LocalResources.GetLabel("app_employee_report_location_text"));
                sbCaseDetails.Replace("@lblEmployeeReportLocation", lblEmployeeReportLocation.Text);
                sbCaseDetails.Replace("@app_timezone_text", LocalResources.GetLabel("app_timezone_text"));
                sbCaseDetails.Replace("@lblTimeZone", lblTimeZone.Text);
                sbCaseDetails.Replace("@app_note_text", LocalResources.GetLabel("app_note_text"));
                sbCaseDetails.Replace("@lblNote", lblNote.Text);
                sbCaseDetails.Replace("@app_additional_Information_text", LocalResources.GetLabel("app_additional_Information_text"));
                sbCaseDetails.Replace("@app_witness_text", LocalResources.GetLabel("app_witness(es)_text"));
                sbCaseDetails.Replace("@app_police_reports_text", LocalResources.GetLabel("app_police_reports(s)_text"));
                sbCaseDetails.Replace("@app_photo_text", LocalResources.GetLabel("app_photo(s)_text"));
                sbCaseDetails.Replace("@app_scene_sketch_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview_text", LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text", LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text", LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_corrective_action_details_text", LocalResources.GetLabel("app_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                //sbCaseDetails.Replace("@app_osha_300_information_text", LocalResources.GetLabel("app_osha_300_information_text"));
                //sbCaseDetails.Replace("@app_case_outcome_text", LocalResources.GetLabel("app_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_days_away_from_work_text", LocalResources.GetLabel("app_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_days_of_restrictions_text", LocalResources.GetLabel("app_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_data_of_death_text", LocalResources.GetLabel("app_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_type_of_illness_text", LocalResources.GetLabel("app_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_describe_injury_or_illness_text", LocalResources.GetLabel("app_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_oosha_301_information_text", LocalResources.GetLabel("app_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_worker_gender_text", LocalResources.GetLabel("app_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_works_start_time_text", LocalResources.GetLabel("app_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_physician_text", LocalResources.GetLabel("app_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_treatment_facility_text", LocalResources.GetLabel("app_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_emergency_room_text", LocalResources.GetLabel("app_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_hospitalized_text", LocalResources.GetLabel("app_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_address_1_text", LocalResources.GetLabel("app_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_address_2_text", LocalResources.GetLabel("app_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_address_3_text", LocalResources.GetLabel("app_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_zip_text", LocalResources.GetLabel("app_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_what_was_the_employee_text", LocalResources.GetLabel("app_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_what_happened_tell_text", LocalResources.GetLabel("app_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_what_was_the_injury_text", LocalResources.GetLabel("app_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_object_or_substance_text", LocalResources.GetLabel("app_object_or_substance_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info4", lblOSHA301Info4.Text);
                sbCaseDetails.Replace("@app_custom_fields_text", LocalResources.GetLabel("app_custom_fields_text"));
                sbCaseDetails.Replace("@app_custom_01_text", LocalResources.GetLabel("app_custom_01_text"));
                sbCaseDetails.Replace("@app_custom_02_text", LocalResources.GetLabel("app_custom_02_text"));
                sbCaseDetails.Replace("@app_custom_03_text", LocalResources.GetLabel("app_custom_03_text"));
                sbCaseDetails.Replace("@app_custom_04_text", LocalResources.GetLabel("app_custom_04_text"));
                sbCaseDetails.Replace("@app_custom_05_text", LocalResources.GetLabel("app_custom_05_text"));
                sbCaseDetails.Replace("@app_custom_06_text", LocalResources.GetLabel("app_custom_06_text"));
                sbCaseDetails.Replace("@app_custom_07_text", LocalResources.GetLabel("app_custom_07_text"));
                sbCaseDetails.Replace("@app_custom_08_text", LocalResources.GetLabel("app_custom_08_text"));
                sbCaseDetails.Replace("@app_custom_09_text", LocalResources.GetLabel("app_custom_09_text"));
                sbCaseDetails.Replace("@app_custom_10_text", LocalResources.GetLabel("app_custom_10_text"));
                sbCaseDetails.Replace("@app_custom_11_text", LocalResources.GetLabel("app_custom_11_text"));
                sbCaseDetails.Replace("@app_custom_12_text", LocalResources.GetLabel("app_custom_12_text"));
                sbCaseDetails.Replace("@app_custom_13_text", LocalResources.GetLabel("app_custom_13_text"));
                sbCaseDetails.Replace("@wp_app_release_number", LocalResources.GetLabel("wp_app_release_number"));
                sbCaseDetails.Replace("@lblCustom01", lblCustom01.Text);
                sbCaseDetails.Replace("@lblCustom02", lblCustom02.Text);
                sbCaseDetails.Replace("@lblCustom03", lblCustom03.Text);
                sbCaseDetails.Replace("@lblCustom04", lblCustom04.Text);
                sbCaseDetails.Replace("@lblCustom05", lblCustom05.Text);
                sbCaseDetails.Replace("@lblCustom06", lblCustom06.Text);
                sbCaseDetails.Replace("@lblCustom07", lblCustom07.Text);
                sbCaseDetails.Replace("@lblCustom08", lblCustom08.Text);
                sbCaseDetails.Replace("@lblCustom09", lblCustom09.Text);
                sbCaseDetails.Replace("@lblCustom10", lblCustom10.Text);
                sbCaseDetails.Replace("@lblCustom11", lblCustom11.Text);
                sbCaseDetails.Replace("@lblCustom12", lblCustom12.Text);
                sbCaseDetails.Replace("@lblCustom13", lblCustom13.Text);
                sbCaseDetails.Replace("@app_required_fields_text", LocalResources.GetLabel("app_required_fields_text"));

                ComplianceDAO miris = new ComplianceDAO();
                miris.c_case_id_pk = view;
                miris.s_locale_culture = SessionWrapper.CultureName;
                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(miris);
                StringBuilder sbWitness = new StringBuilder();
                if (dtGetWitness.Rows.Count > 0)
                {
                    sbWitness.Append("<table>");
                    for (int i = 0; i <= dtGetWitness.Rows.Count - 1; i++)
                    {
                        sbWitness.Append("<tr>");
                        sbWitness.Append("<td>");
                        sbWitness.Append(dtGetWitness.Rows[i]["c_file_name"].ToString());
                        sbWitness.Append("</td>");
                        sbWitness.Append("</tr>");
                    }
                    sbWitness.Append("</table>");
                }
                sbCaseDetails.Replace("@gvAddWitness", sbWitness.ToString());
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(miris);
                StringBuilder sbPhoto = new StringBuilder();
                if (dtGetPhoto.Rows.Count > 0)
                {
                    sbPhoto.Append("<table>");
                    for (int i = 0; i <= dtGetPhoto.Rows.Count - 1; i++)
                    {
                        sbPhoto.Append("<tr>");
                        sbPhoto.Append("<td>");
                        sbPhoto.Append(dtGetPhoto.Rows[i]["c_file_name"].ToString());
                        sbPhoto.Append("</td>");
                        sbPhoto.Append("</tr>");
                    }
                    sbPhoto.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPhoto", sbPhoto.ToString());
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                StringBuilder sbPoliceReport = new StringBuilder();
                if (dtGetPoliceReport.Rows.Count > 0)
                {
                    sbPoliceReport.Append("<table>");
                    for (int i = 0; i <= dtGetPoliceReport.Rows.Count - 1; i++)
                    {
                        sbPoliceReport.Append("<tr>");
                        sbPoliceReport.Append("<td>");
                        sbPoliceReport.Append(dtGetPoliceReport.Rows[i]["c_file_name"].ToString());
                        sbPoliceReport.Append("</td>");
                        sbPoliceReport.Append("</tr>");
                    }
                    sbPoliceReport.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPoliceReport", sbPoliceReport.ToString());
                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                StringBuilder sbSceneSketch = new StringBuilder();
                if (dtGetSceneSketch.Rows.Count > 0)
                {
                    sbSceneSketch.Append("<table>");
                    for (int i = 0; i <= dtGetSceneSketch.Rows.Count - 1; i++)
                    {
                        sbSceneSketch.Append("<tr>");
                        sbSceneSketch.Append("<td>");
                        sbSceneSketch.Append(dtGetSceneSketch.Rows[i]["c_file_name"].ToString());
                        sbSceneSketch.Append("</td>");
                        sbSceneSketch.Append("</tr>");
                    }
                    sbSceneSketch.Append("</table>");
                }
                sbCaseDetails.Replace("@gvSceneSketch", sbSceneSketch.ToString());
                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                StringBuilder sbExtenautingCondition = new StringBuilder();
                if (dtGetExtenautingCondition.Rows.Count > 0)
                {
                    sbExtenautingCondition.Append("<table>");
                    for (int i = 0; i <= dtGetExtenautingCondition.Rows.Count - 1; i++)
                    {
                        sbExtenautingCondition.Append("<tr>");
                        sbExtenautingCondition.Append("<td>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["c_file_name"].ToString());
                        sbExtenautingCondition.Append("</td>");
                        sbExtenautingCondition.Append("</tr>");
                    }
                    sbExtenautingCondition.Append("</table>");
                }
                sbCaseDetails.Replace("@gvExtenuatingcondition", sbExtenautingCondition.ToString());
                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                StringBuilder sbEmployeeInterview = new StringBuilder();
                if (dtGetEmployeeInterview.Rows.Count > 0)
                {
                    sbEmployeeInterview.Append("<table>");
                    for (int i = 0; i <= dtGetEmployeeInterview.Rows.Count - 1; i++)
                    {
                        sbEmployeeInterview.Append("<tr>");
                        sbEmployeeInterview.Append("<td>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["c_file_name"].ToString());
                        sbEmployeeInterview.Append("</td>");
                        sbEmployeeInterview.Append("</tr>");
                    }
                    sbEmployeeInterview.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());
                strCaseDetails = sbCaseDetails.ToString();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvoi-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvoi-01.htm", ex.Message);
                    }
                }
            }
            return strCaseDetails;
        }

        protected void btnDownloadZip_header_Click(object sender, EventArgs e)
        {
            Downloadzip();
        }
        protected void btnDownload_footer_Click(object sender, EventArgs e)
        {
            Downloadzip();
        }

        //Download Zip
        private void Downloadzip()
        {
            string fldGuid = Guid.NewGuid().ToString();
            string filePath = Server.MapPath(_temppath + fldGuid + "/");
            if (!Directory.Exists(filePath))  // if it doesn't exist, create
                Directory.CreateDirectory(filePath);

            //witness
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;
            DataTable dtGetWitness = new DataTable();
            dtGetWitness = ComplianceBLL.GetWitness(miris);
            if (dtGetWitness.Rows.Count > 0)
            {
                string destinationfilePathWitness = Server.MapPath(_temppath + fldGuid + "/Witness_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathWitness))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathWitness);

                foreach (DataRow dr in dtGetWitness.Rows)
                {
                    string sourcefilePathWitness = Server.MapPath(_path);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathWitness, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathWitness, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //photo
            DataTable dtGetPhoto = new DataTable();
            dtGetPhoto = ComplianceBLL.Getphoto(miris);
            if (dtGetPhoto.Rows.Count > 0)
            {
                string destinationfilePathphoto = Server.MapPath(_temppath + fldGuid + "/Photo_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathphoto))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathphoto);

                foreach (DataRow dr in dtGetPhoto.Rows)
                {
                    string sourcefilePathphoto = Server.MapPath(_pathPhoto);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathphoto, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathphoto, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //police report
            DataTable dtGetPoliceReport = new DataTable();
            dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            if (dtGetPoliceReport.Rows.Count > 0)
            {
                string destinationfilePathPoliceReport = Server.MapPath(_temppath + fldGuid + "/PoliceReport_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathPoliceReport))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathPoliceReport);

                foreach (DataRow dr in dtGetPoliceReport.Rows)
                {
                    string sourcefilePathPoliceReport = Server.MapPath(_pathPolice);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathPoliceReport, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathPoliceReport, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }

            //SceneSketch
            DataTable dtGetSceneSketch = new DataTable();
            dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            if (dtGetSceneSketch.Rows.Count > 0)
            {
                string destinationfilePathsceneSketch = Server.MapPath(_temppath + fldGuid + "/sceneSketch_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathsceneSketch))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathsceneSketch);
                foreach (DataRow dr in dtGetSceneSketch.Rows)
                {
                    string sourcefilePathsceneSketch = Server.MapPath(_pathSceneSketch);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathsceneSketch, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathsceneSketch, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Extenautingcondition
            DataTable dtGetExtenautingCondition = new DataTable();
            dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            if (dtGetExtenautingCondition.Rows.Count > 0)
            {
                string destinationfilePathExtenautingCondtion = Server.MapPath(_temppath + fldGuid + "/ExtenautingCondtion_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathExtenautingCondtion))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathExtenautingCondtion);
                foreach (DataRow dr in dtGetExtenautingCondition.Rows)
                {
                    string sourcefilePathExtenautingCondtion = Server.MapPath(_pathExtenuatingcondition);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathExtenautingCondtion, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathExtenautingCondtion, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //EmployeeInterview
            DataTable dtGetEmployeeInterview = new DataTable();
            dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);

            if (dtGetEmployeeInterview.Rows.Count > 0)
            {
                string destinationfilePathEmployeeInterview = Server.MapPath(_temppath + fldGuid + "/EmployeeInterview_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathEmployeeInterview))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathEmployeeInterview);
                foreach (DataRow dr in dtGetEmployeeInterview.Rows)
                {
                    string sourcefilePathEmployeeInterview = Server.MapPath(_pathEmployeeInterview);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathEmployeeInterview, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathEmployeeInterview, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Employee Statement
            DataTable dtGetEmployeeStatment = new DataTable();
            dtGetEmployeeStatment = ComplianceBLL.GetEmployeeStatement(miris);

            if (dtGetEmployeeStatment.Rows.Count > 0)
            {
                string destinationfilePathEmployeeStatement = Server.MapPath(_temppath + fldGuid + "/EmployeeStatment_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathEmployeeStatement))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathEmployeeStatement);
                foreach (DataRow dr in dtGetEmployeeStatment.Rows)
                {
                    string sourcefilePathEmployeeStatement = Server.MapPath(_pathEmployeeStatement);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathEmployeeStatement, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathEmployeeStatement, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Policies / Procedures
            DataTable dtGetPolicies = new DataTable();
            dtGetPolicies = ComplianceBLL.GetPolicies(miris);

            if (dtGetPolicies.Rows.Count > 0)
            {
                string destinationfilePathPolicies = Server.MapPath(_temppath + fldGuid + "/Policies_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathPolicies))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathPolicies);
                foreach (DataRow dr in dtGetPolicies.Rows)
                {
                    string sourcefilePathPolicies = Server.MapPath(_pathPolicies);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathPolicies, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathPolicies, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Training History
            DataTable dtGetTrainingHistory = new DataTable();
            dtGetTrainingHistory = ComplianceBLL.GetTrainingHistory(miris);

            if (dtGetTrainingHistory.Rows.Count > 0)
            {
                string destinationfilePathTrainingHistory = Server.MapPath(_temppath + fldGuid + "/TrainingHistory_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathTrainingHistory))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathTrainingHistory);
                foreach (DataRow dr in dtGetTrainingHistory.Rows)
                {
                    string sourcefilePathTrainingHistory = Server.MapPath(_pathTrainingHistory);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathTrainingHistory, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathTrainingHistory, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Observation
            DataTable dtGetObservation = new DataTable();
            dtGetObservation = ComplianceBLL.GetObservation(miris);

            if (dtGetObservation.Rows.Count > 0)
            {
                string destinationfilePathObservation = Server.MapPath(_temppath + fldGuid + "/Observation_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathObservation))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathObservation);
                foreach (DataRow dr in dtGetObservation.Rows)
                {
                    string sourcefilePathObservation = Server.MapPath(_pathObservation);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathObservation, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathObservation, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Incident History
            DataTable dtGetIncidentHistory = new DataTable();
            dtGetIncidentHistory = ComplianceBLL.GetIncidentHistory(miris);

            if (dtGetIncidentHistory.Rows.Count > 0)
            {
                string destinationfilePathIncidentHistory = Server.MapPath(_temppath + fldGuid + "/IncidentHistory_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathIncidentHistory))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathIncidentHistory);
                foreach (DataRow dr in dtGetIncidentHistory.Rows)
                {
                    string sourcefilePathIncidentHistory = Server.MapPath(_pathIncidentHistory);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathIncidentHistory, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathIncidentHistory, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            SavePdf(filePath);
            // download in zip format
            Response.Clear();
            Response.BufferOutput = false;
            HttpContext c = HttpContext.Current;
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "block; filename=\"" + lblCaseNumber.Text + ".zip" + "\"");
            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddDirectory(filePath);
                zipFile.Save(Response.OutputStream);
                Response.Close();
            }
            //DirectoryInfo deleteDirectory = new DirectoryInfo(filePath);
            Directory.Delete(filePath, true);
        }

    }
}