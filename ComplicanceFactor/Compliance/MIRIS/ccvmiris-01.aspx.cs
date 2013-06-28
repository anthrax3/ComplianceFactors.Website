using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Threading;
using System.Globalization;

namespace ComplicanceFactor.Compliance
{
    public partial class ccvmiris_01 : BasePage
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

        #endregion
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            //lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetLocaleResourceText("app_cchp_pagename") + "</a>&nbsp;" + " >&nbsp;" + "MIRIS" + " >&nbsp;  View Case";
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
                miris = ComplianceBLL.GetCase(caseid);
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
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message);
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
        protected void btnDownloadZip_header_Click(object sender, EventArgs e)
        {
            downloadZip();
        }
        protected void btnDownload_footer_Click(object sender, EventArgs e)
        {
            downloadZip();
        }
        protected void btnSendtoMyMobile_header_Click1(object sender, EventArgs e)
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
                    success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + PHONE;
                }
                else
                {
                    //Error message if mobile number is empty
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerHtml = LocalResources.GetText("app_mobile_number_not_registered_error_wrong");
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
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message);
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
                SystemThemes userTheme = new SystemThemes();
                userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);

                //Daily Email Report
                string filePath = string.Empty;
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/MIRIS/MirisEmailTemplate/ccvmiris.htm");
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

                sbCaseDetails.Replace("@app_case_page_title", LocalResources.GetLabel("app_case_details_page_text") + lblCaseNumber.Text);
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
                sbCaseDetails.Replace("@app_user_employee_hire_date_text", LocalResources.GetLabel("app_employee_hire_date_text"));
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
                sbCaseDetails.Replace("@app_scene_sketch(es)_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition(s)_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview(s)_text", LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text", LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text", LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_user_corrective_action_details_text", LocalResources.GetLabel("app_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                // sbCaseDetails.Replace("@app_user_osha_300_information_text", LocalResources.GetLabel("app_osha_300_information_text"));
                // sbCaseDetails.Replace("@app_user_case_outcome_text", LocalResources.GetLabel("app_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_user_days_away_from_work_text", LocalResources.GetLabel("app_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_user_days_of_restrictions_text", LocalResources.GetLabel("app_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_user_data_of_death_text", LocalResources.GetLabel("app_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_user_type_of_illness_text", LocalResources.GetLabel("app_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_user_describe_injury_or_illness_text", LocalResources.GetLabel("app_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_user_oosha_301_information_text", LocalResources.GetLabel("app_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_user_worker_gender_text", LocalResources.GetLabel("app_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_user_works_start_time_text", LocalResources.GetLabel("app_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_user_physician_text", LocalResources.GetLabel("app_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_user_treatment_facility_text", LocalResources.GetLabel("app_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_user_emergency_room_text", LocalResources.GetLabel("app_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_user_hospitalized_text", LocalResources.GetLabel("app_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_user_address_1_text", LocalResources.GetLabel("app_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_user_address_2_text", LocalResources.GetLabel("app_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_user_address_3_text", LocalResources.GetLabel("app_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_user_zip_text", LocalResources.GetLabel("app_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_employee_text", LocalResources.GetLabel("app_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_user_what_happened_tell_text", LocalResources.GetLabel("app_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_injury_text", LocalResources.GetLabel("app_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_user_object_or_substance_text", LocalResources.GetLabel("app_what_object_or_substance_text"));
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
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>"+ dtGetWitness.Rows[i]["c_name"].ToString()+"</b>");
                        sbWitness.Append("</td>");

                        sbWitness.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" +"<b>"+ dtGetWitness.Rows[i]["c_contact_info"].ToString()+"</b>");
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
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>"+ dtGetExtenautingCondition.Rows[i]["c_name"].ToString() +"</b>");
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>"+ dtGetExtenautingCondition.Rows[i]["c_contact_info"].ToString()+"</b>");
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
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["c_contact_info"].ToString()+ "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("</tr>");
                    }
                    sbEmployeeInterview.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());
                Utility.SendEMailMessage(mailAddresses, "ComplianceFactors - CaseDetails", sbCaseDetails.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + toEmailAddress;
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                //error_msg.InnerHtml = LocalResources.GetLabel("app_miris_error_msg_email_mobile");
                error_msg.InnerHtml = LocalResources.GetText("app_case_send_error_text");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message);
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
                sbCaseDetails.Replace("@app_user_employee_hire_date_text", LocalResources.GetLabel("app_user_employee_hire_date_text"));
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
                sbCaseDetails.Replace("@app_witness(es)_text", LocalResources.GetLabel("app_user_witness(es)_text"));
                sbCaseDetails.Replace("@app_police_reports(s)_text", LocalResources.GetLabel("app_user_police_reports(s)_text"));
                sbCaseDetails.Replace("@app_photo(s)_text", LocalResources.GetLabel("app_user_photo(s)_text"));
                sbCaseDetails.Replace("@app_scene_sketch(es)_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition(s)_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview(s)_text", LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text", LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text", LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_user_corrective_action_details_text", LocalResources.GetLabel("app_user_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                //sbCaseDetails.Replace("@app_user_osha_300_information_text", LocalResources.GetLabel("app_user_osha_300_information_text"));
                //sbCaseDetails.Replace("@app_user_case_outcome_text", LocalResources.GetLabel("app_user_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_user_days_away_from_work_text", LocalResources.GetLabel("app_user_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_user_days_of_restrictions_text", LocalResources.GetLabel("app_user_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_user_data_of_death_text", LocalResources.GetLabel("app_user_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_user_type_of_illness_text", LocalResources.GetLabel("app_user_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_user_describe_injury_or_illness_text", LocalResources.GetLabel("app_user_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_user_oosha_301_information_text", LocalResources.GetLabel("app_user_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_user_worker_gender_text", LocalResources.GetLabel("app_user_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_user_works_start_time_text", LocalResources.GetLabel("app_user_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_user_physician_text", LocalResources.GetLabel("app_user_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_user_treatment_facility_text", LocalResources.GetLabel("app_user_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_user_emergency_room_text", LocalResources.GetLabel("app_user_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_user_hospitalized_text", LocalResources.GetLabel("app_user_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_user_address_1_text", LocalResources.GetLabel("app_user_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_user_address_2_text", LocalResources.GetLabel("app_user_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_user_address_3_text", LocalResources.GetLabel("app_user_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_user_zip_text", LocalResources.GetLabel("app_user_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_employee_text", LocalResources.GetLabel("app_user_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_user_what_happened_tell_text", LocalResources.GetLabel("app_user_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_injury_text", LocalResources.GetLabel("app_user_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_user_object_or_substance_text", LocalResources.GetLabel("app_user_object_or_substance_text"));
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
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message);
                    }
                }
            }
            return strCaseDetails;
        }
        protected void btnSendtoMyEmail_header_Click2(object sender, EventArgs e)
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
                    error_msg.InnerHtml = LocalResources.GetText("app_email_address_not_registered_error_wrong");
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
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSendtoMyEmail_footer_Click1(object sender, EventArgs e)
        {

            SendToMyEmail();
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
                error_msg.InnerHtml = LocalResources.GetText("app_case_send_error_text");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01", ex.Message);
                    }
                }
            }

        }
        protected void btnPrintPdf_footer_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        protected void btnPrintPdf_header_Click(object sender, EventArgs e)
        {
            PrintPdf();
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
                        success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + toPhone;
                    }
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
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message);
                    }
                }

            }
            txtMultipeEmailAddress.Text = "";
        }
        protected void btnPrintSample_Click(object sender, EventArgs e)
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

            //Employee Interview
            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());
            try
            {
                dsPdf = ComplianceBLL.createPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message);
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
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISView", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Witness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_PoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Photo", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Scene_Sketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Extenuating_Condition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Employee_Interview", dsEmployeeInterview.Tables[0]));

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

            try
            {
                dsPdf = ComplianceBLL.createPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message);
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
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISView", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Witness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_PoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Photo", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Scene_Sketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Extenuating_Condition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRIS_Employee_Interview", dsEmployeeInterview.Tables[0]));

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
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.
        }
        private void downloadZip()
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
