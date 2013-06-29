using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;
using Microsoft.Reporting.WebForms;
using Ionic.Zip;
using System.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Globalization;
using System.Threading;
using System.Web.UI.HtmlControls;
namespace ComplicanceFactor.Compliance.HARM
{
    public partial class ccvharm_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathCustomCustomer = "~/Compliance/HARM/Upload/CustomCustomer/";
        private string _pathPhoto = "~/Compliance/HARM/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/HARM/Upload/sceneSketch/";
        private string _pathExtenuatingCondition = "~/Compliance/HARM/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/HARM/Upload/EmployeeInterview/";
        private string _temppath = "~/Compliance/HARM/tempHarmFiles/";
        #endregion
        //CultureInfo culture = new CultureInfo("en-US");
        string view;
        int controlMeasureCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            view = SecurityCenter.DecryptText(Request.QueryString["View"]);
            populateHarm(view);

            if (!IsPostBack)
            {
                BindHazardControlSummary();
            }
            
        }
        private void populateHarm(string harmid)
        {
            ComplianceDAO harm = new ComplianceDAO();
            try
            {
                harm = ComplianceBLL.GetHarm(harmid);
                harm.h_harm_id_pk = harmid;
                lblPageHarmNumber.Text = harm.h_harm_number;
                lblHarmNumber.Text = harm.h_harm_number;
                lblHarmCaseTitle.Text = harm.h_case_title;
                lblHarmCaseDate.Text = Convert.ToDateTime(harm.h_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblHarmStatus.Text = harm.h_status_text_view;
                //lblHarmEmployeeReportLocation.Text = harm.h_employee_report_location;
                lblHarmCaseCategory.Text = harm.h_case_category_text_view;
                lblCustom01.Text = harm.h_custom_01;
                lblCustom02.Text = harm.h_custom_02;
                lblCustom03.Text = harm.h_custom_03;
                lblCustom04.Text = harm.h_custom_04;
                lblCustom05.Text = harm.h_custom_05;
                lblCustom06.Text = harm.h_custom_06;
                lblCustom07.Text = harm.h_custom_07;
                lblCustom08.Text = harm.h_custom_08;
                lblCustom09.Text = harm.h_custom_09;
                lblCustom10.Text = harm.h_custom_10;
                lblCustom11.Text = harm.h_custom_11;
                lblCustom12.Text = harm.h_custom_12;
                lblCustom13.Text = harm.h_custom_13;
                DataTable dtCustomCustomer = new DataTable();
                dtCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
                this.gvCustomCustomer.DataSource = dtCustomCustomer;
                this.gvCustomCustomer.DataBind();
                DataTable dtPhoto = new DataTable();
                dtPhoto = ComplianceBLL.GetHarmPhoto(harm);
                this.gvPhoto.DataSource = dtPhoto;
                this.gvPhoto.DataBind();
                DataTable dtSceneSketch = new DataTable();
                dtSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
                this.gvSceneSketch.DataSource = dtSceneSketch;
                this.gvSceneSketch.DataBind();
                DataTable dtExtenuatingCondition = new DataTable();
                dtExtenuatingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
                this.gvExtenuatingCondition.DataSource = dtExtenuatingCondition;
                this.gvExtenuatingCondition.DataBind();
                DataTable dtEmployeeInterview = new DataTable();
                dtEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
                this.gvEmployeeInterview.DataSource = dtEmployeeInterview;
                this.gvEmployeeInterview.DataBind();
                DataTable dtControlMeasureSummary = new DataTable();
                dtControlMeasureSummary = ComplianceBLL.GetAllHazard(harm);
                this.dlHazardSummary.DataSource = dtControlMeasureSummary;
                this.dlHazardSummary.DataBind();
               

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvharm-01(populateHarm)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01(populateHarm)", ex.Message);
                    }
                }
            }
        }
        private void BindHazardControlSummary()
        {
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = view;
            //Hazard and control measure
            DataTable dtHazard = new DataTable();
            try
            {
                dtHazard = ComplianceBLL.GetAllHazard(harm);
                if (dtHazard.Rows.Count > 0)
                {
                    dlHazardSummary.DataSource = dtHazard;
                    dlHazardSummary.DataBind();
                    lblJobTitle.Text = dtHazard.Rows[0]["h_job_title"].ToString();
                }
                else
                {
                    divAddJobTitle.Style.Add("display", "none");
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvharm-01(GetAllHazard-Load)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01(GetAllHazard-Load)", ex.Message);
                    }
                }

            }
        }
        private void BindControlMeasure(GridView GridView, string h_hazard_id_pk)
        {
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_hazard_id_pk = h_hazard_id_pk;
            DataTable dtControlMeasure = new DataTable();
            dtControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);
            GridView.DataSource = dtControlMeasure;
            GridView.DataBind();
            //AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtAddControlMeasure.Text, SessionWrapper.ControlMeasure);
            //SessionWrapper.ControlMeasure = dtControlMeasure;

        }
        protected void dlHazardSummary_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvControlMeasureSummary = (GridView)e.Item.FindControl("gvControlMeasureSummary");

            BindControlMeasure(gvControlMeasureSummary, dlHazardSummary.DataKeys[e.Item.ItemIndex].ToString());
            Label lblHazard = e.Item.FindControl("lblHazard") as Label;
            int seqHazard = Convert.ToInt32(e.Item.ItemIndex) + 1;
            lblHazard.Text = LocalResources.GetLabel("app_hazard_text") + ":" + "&nbsp;&nbsp&nbsp&nbsp" + "<b>" + lblHazard.Text + "</b>";

            Label lblHazardNumber = e.Item.FindControl("lblHazardNumber") as Label;
            lblHazardNumber.Text = Convert.ToString(seqHazard);

            if (e.Item.ItemIndex == 0)
            {
                emptyrow.Style.Add("display", "none");
            }


        }
        protected void gvControlMeasureSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                Label lblControlMeasure = (Label)e.Row.FindControl("lblControlMeasure");
                int seqHazard = dle.Item.ItemIndex + 1;
                int seqContrlMeasure = e.Row.RowIndex + 1;
                string seq = seqHazard + "." + seqContrlMeasure;


                Label lblControlCategory = (Label)e.Row.FindControl("lblControlCategory");
                string hazard_id_fk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                string strval = ((Label)(lblControlCategory)).Text;
                string title = (string)ViewState["ControlCategory"];
                string strHazardId = hazard_id_fk;
                string strhazard_id_fk = (string)ViewState["hazard_id_fk"];
                if (title == strval && strHazardId == strhazard_id_fk)
                {
                    lblControlCategory.Visible = false;
                    lblControlCategory.Text = string.Empty;

                }
                else
                {
                    title = strval;
                    strhazard_id_fk = strHazardId;
                    ViewState["ControlCategory"] = title;
                    ViewState["hazard_id_fk"] = strhazard_id_fk;
                    lblControlCategory.Visible = true;
                    lblControlCategory.Text = title;
                }


                lblControlMeasure.Text = seq + "&nbsp;&nbsp&nbsp&nbsp" + lblControlMeasure.Text;



            }

        }
        protected void gvCustomCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string CustomCustomerFileId = gvCustomCustomer.DataKeys[rowIndex][0].ToString();
                string CustomCustomerFileName = gvCustomCustomer.DataKeys[rowIndex][1].ToString();
                string filepath = Server.MapPath(_pathCustomCustomer + CustomCustomerFileId);
                if (System.IO.File.Exists(filepath))
                {
                    string strRequest = filepath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment:filename\"" + CustomCustomerFileName + "\"");
                            Response.AddHeader("Content-length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
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
        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string PhotoFiledId = gvPhoto.DataKeys[rowIndex][0].ToString();
                string PhotoFiledName = gvPhoto.DataKeys[rowIndex][1].ToString();
                string filepath = Server.MapPath(_pathPhoto + PhotoFiledId);
                if (System.IO.File.Exists(filepath))
                {
                    string strRequest = filepath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment:filename\"" + PhotoFiledName + "\"");
                            Response.AddHeader("Content-length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
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
                string SceneSketchId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                string SceneSketchFileName = gvSceneSketch.DataKeys[rowIndex][1].ToString();
                string filepath = Server.MapPath(_pathSceneSketch + SceneSketchId);
                if (System.IO.File.Exists(filepath))
                {
                    string strRequest = filepath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment:filename\"" + SceneSketchFileName + "\"");
                            Response.AddHeader("Content-length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }

            }
        }
        protected void gvExtenuatingCondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingConditionId = gvExtenuatingCondition.DataKeys[rowIndex][0].ToString();
                string ExtenuatingConditionName = gvExtenuatingCondition.DataKeys[rowIndex][1].ToString();
                string filepath = Server.MapPath(_pathExtenuatingCondition + ExtenuatingConditionId);
                if (System.IO.File.Exists(filepath))
                {
                    string strRequest = filepath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment:filename\"" + ExtenuatingConditionName + "\"");
                            Response.AddHeader("Content-length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
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
                string EmployeeInreviewId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                string EmployeeInterviewFileName = gvEmployeeInterview.DataKeys[rowIndex][1].ToString();
                string filepath = Server.MapPath(_pathEmployeeInterview + EmployeeInreviewId);
                if (System.IO.File.Exists(filepath))
                {
                    string strRequest = filepath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment:filename\"" + EmployeeInterviewFileName + "\"");
                            Response.AddHeader("Content-length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }

            }

        }
        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        private void PrintPdf()
        {
            rvHARM.LocalReport.DataSources.Clear();
            rvHARM.LocalReport.EnableExternalImages = true;
            DataSet dsPdf = new DataSet();
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = view;
            harm.s_locale_culture = SessionWrapper.CultureName;

            //witness
            DataSet dsCustomCustomer = new DataSet();
            DataTable dtCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
            dsCustomCustomer.Tables.Add(dtCustomCustomer.Copy());



            //Photo

            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.GetHarmPhoto(harm);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch

            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition

            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Employee Interview

            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Hazard and control measure

            DataSet dsHazardControlMeasure = new DataSet();
            dsHazardControlMeasure = ComplianceBLL.GetHazardControlMeasureReport(harm);

            //control measure


            try
            {
                dsPdf = ComplianceBLL.createHARMPDF(harm);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message);
                    }
                }

            }

            // Add the handler for the subreport
            rvHARM.LocalReport.SubreportProcessing += SubreportProcessingEvent;


            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvHARM.ProcessingMode = ProcessingMode.Local;
            rvHARM.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.HARM.PdfTemplate.HARMReport.rdlc";


            SystemThemes userTheme = new SystemThemes();
            userTheme = GetthemeforEmailandPdf();


            string protocol = Request.Url.AbsoluteUri;
            int len = protocol.IndexOf(':');
            protocol = protocol.Substring(0, len);
           

            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARMView", dsPdf.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Custom_Customer", dsCustomCustomer.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Photo", dsPhoto.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_SceneSketch", dsSceneSketch.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Extenuating_Condition", dsExtenuatingCondition.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Employee_Interview", dsEmployeeInterview.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Hazard_Control_Measure", dsHazardControlMeasure.Tables[0]));
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("s_theme_report_logo_file_name", protocol + "://"+Request.Url.Host.ToLower()+ "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_report_logo_file_name));
            param.Add(new ReportParameter("s_theme_css_tag_main_background_hex_value", "#" + userTheme.s_theme_css_tag_main_background_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_foot_top_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_top_line_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_foot_bot_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_bot_line_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_section_head_hex_value", "#" + userTheme.s_theme_css_tag_section_head_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_section_head_text_hex_value", "#" + userTheme.s_theme_css_tag_section_head_text_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_section_head_border_hex_value", "#" + userTheme.s_theme_css_tag_section_head_border_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_table_head_hex_value", "#" + userTheme.s_theme_css_tag_table_head_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_table_head_text_hex_value", "#" + userTheme.s_theme_css_tag_table_head_text_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_table_border_hex_value", "#" + userTheme.s_theme_css_tag_table_border_hex_value));
            param.Add(new ReportParameter("s_theme_css_tag_body_text_hex_value", "#" + userTheme.s_theme_css_tag_body_text_hex_value));
            this.rvHARM.LocalReport.SetParameters(param);
            byte[] bytes = rvHARM.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + lblHarmNumber.Text + ".pdf" + "\"");
            Response.BinaryWrite(bytes); // create the file     
            Response.Flush(); // send it to the client to download  
            Response.End();
            Response.Close();
        }
        private void SavePdf(string filepath)
        {

            rvHARM.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = view;
            harm.s_locale_culture = LanguageManager.CurrentCulture.Name;

            //witness
            DataSet dsCustomCustomer = new DataSet();
            DataTable dtCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
            dsCustomCustomer.Tables.Add(dtCustomCustomer.Copy());



            //Photo

            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.GetHarmPhoto(harm);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch

            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition

            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Employee Interview

            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Hazard and control measure

            DataSet dsHazardControlMeasure = new DataSet();
            dsHazardControlMeasure = ComplianceBLL.GetHazardControlMeasureReport(harm);

            //control measure

            try
            {
                dsPdf = ComplianceBLL.createHARMPDF(harm);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message);
                    }
                }

            }

            rvHARM.Reset(); //important

            // Add the handler for the subreport
            rvHARM.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEvent);

            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvHARM.ProcessingMode = ProcessingMode.Local;
            rvHARM.LocalReport.EnableExternalImages = true;


            rvHARM.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.HARM.PdfTemplate.HARMReport.rdlc";
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARMView", dsPdf.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Custom_Customer", dsCustomCustomer.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Photo", dsPhoto.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_SceneSketch", dsSceneSketch.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Extenuating_Condition", dsExtenuatingCondition.Tables[0]));
            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Employee_Interview", dsEmployeeInterview.Tables[0]));

            rvHARM.LocalReport.DataSources.Add(new ReportDataSource("HARM_Hazard_Control_Measure", dsHazardControlMeasure.Tables[0]));


            byte[] bytes = rvHARM.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            using (FileStream fs = File.Create(filepath + lblHarmNumber.Text + ".pdf"))
            {
                fs.Write(bytes, 0, (int)bytes.Length);
            }


        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string fldGuid = Guid.NewGuid().ToString();
            string filePath = Server.MapPath(_temppath + fldGuid + "/");
            if (!Directory.Exists(filePath))  // if it doesn't exist, create
                Directory.CreateDirectory(filePath);

            //Custom customer
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = view;
            DataTable dtGetCustomCustomer = new DataTable();
            dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
            if (dtGetCustomCustomer.Rows.Count > 0)
            {
                string destinationfilePathWitness = Server.MapPath(_temppath + fldGuid + "/CustomCustomer_" + lblHarmNumber.Text);
                if (!Directory.Exists(destinationfilePathWitness))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathWitness);

                foreach (DataRow dr in dtGetCustomCustomer.Rows)
                {
                    string sourcefilePathWitness = Server.MapPath(_pathCustomCustomer);

                    string sourceFile = System.IO.Path.Combine(sourcefilePathWitness, dr["h_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathWitness, dr["h_file_guid"].ToString());

                    File.Copy(sourceFile, destFile, true);


                }
            }




            //photo

            DataTable dtGetPhoto = new DataTable();
            dtGetPhoto = ComplianceBLL.GetHarmPhoto(harm);
            if (dtGetPhoto.Rows.Count > 0)
            {
                string destinationfilePathphoto = Server.MapPath(_temppath + fldGuid + "/Photo_" + lblHarmNumber.Text);
                if (!Directory.Exists(destinationfilePathphoto))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathphoto);

                foreach (DataRow dr in dtGetPhoto.Rows)
                {
                    string sourcefilePathphoto = Server.MapPath(_pathPhoto);

                    string sourceFile = System.IO.Path.Combine(sourcefilePathphoto, dr["h_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathphoto, dr["h_file_guid"].ToString());

                    File.Copy(sourceFile, destFile, true);


                }
            }



            //SceneSketch

            DataTable dtGetSceneSketch = new DataTable();
            dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
            if (dtGetSceneSketch.Rows.Count > 0)
            {
                string destinationfilePathsceneSketch = Server.MapPath(_temppath + fldGuid + "/sceneSketch_" + lblHarmNumber.Text);
                if (!Directory.Exists(destinationfilePathsceneSketch))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathsceneSketch);

                foreach (DataRow dr in dtGetSceneSketch.Rows)
                {
                    string sourcefilePathsceneSketch = Server.MapPath(_pathSceneSketch);

                    string sourceFile = System.IO.Path.Combine(sourcefilePathsceneSketch, dr["h_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathsceneSketch, dr["h_file_guid"].ToString());

                    File.Copy(sourceFile, destFile, true);


                }
            }



            //Extenautingcondition

            DataTable dtGetExtenautingCondition = new DataTable();
            dtGetExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
            if (dtGetExtenautingCondition.Rows.Count > 0)
            {
                string destinationfilePathExtenautingCondtion = Server.MapPath(_temppath + fldGuid + "/ExtenautingCondtion_" + lblHarmNumber.Text);
                if (!Directory.Exists(destinationfilePathExtenautingCondtion))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathExtenautingCondtion);

                foreach (DataRow dr in dtGetExtenautingCondition.Rows)
                {
                    string sourcefilePathExtenautingCondtion = Server.MapPath(_pathExtenuatingCondition);

                    string sourceFile = System.IO.Path.Combine(sourcefilePathExtenautingCondtion, dr["h_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathExtenautingCondtion, dr["h_file_guid"].ToString());

                    File.Copy(sourceFile, destFile, true);


                }
            }



            //EmployeeInterview
            DataTable dtGetEmployeeInterview = new DataTable();
            dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);

            if (dtGetEmployeeInterview.Rows.Count > 0)
            {
                string destinationfilePathEmployeeInterview = Server.MapPath(_temppath + fldGuid + "/EmployeeInterview_" + lblHarmNumber.Text);
                if (!Directory.Exists(destinationfilePathEmployeeInterview))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathEmployeeInterview);

                foreach (DataRow dr in dtGetEmployeeInterview.Rows)
                {
                    string sourcefilePathEmployeeInterview = Server.MapPath(_pathEmployeeInterview);

                    string sourceFile = System.IO.Path.Combine(sourcefilePathEmployeeInterview, dr["h_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathEmployeeInterview, dr["h_file_guid"].ToString());

                    File.Copy(sourceFile, destFile, true);


                }
            }


            SavePdf(filePath);



            // download in zip format
            Response.Clear();
            Response.BufferOutput = false;

            HttpContext c = HttpContext.Current;


            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "block; filename=\"" + lblHarmNumber.Text + ".zip" + "\"");

            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddDirectory(filePath);
                zipFile.Save(Response.OutputStream);
                Response.Close();
            }
            //DirectoryInfo deleteDirectory = new DirectoryInfo(filePath);
            Directory.Delete(filePath, true);
        }
        protected void btnSendMutipleEmail_Click(object sender, EventArgs e)
        {
            sendHarmDetails(txtMultipe.Text);
            txtMultipe.Text = "";
        }
        protected void btnSendMultipleMobile_Click(object sender, EventArgs e)
        {
            try
            {
                string MATRIXURL = "http://www.smsmatrix.com/matrix";
                // david phone = 15712138210

                string toPhone = txtMultipe.Text;
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

                        string TXT = Server.UrlEncode("HARM Number: " + lblHarmNumber.Text + ", " + "Title: " + lblHarmCaseTitle.Text + ", " + "Date: " + lblHarmCaseDate.Text + ", Type: " + lblHarmCaseCategory.Text + ", Status: " + lblHarmStatus.Text);
                        //, Employee Report Location: " + lblHarmEmployeeReportLocation.Text);



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
            txtMultipe.Text = "";

        }
        private void sendHarmDetails(string toEmailAddress)
        {
            string toEmailid = toEmailAddress;
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
                userTheme = GetthemeforEmailandPdf();
                //Daily Report
                string filepath = string.Empty;
                filepath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/HARM/EmailTemplate/ccvharm.htm");
                StringBuilder sbHarmDetails = new StringBuilder(Utility.GetHtmlTemplate(filepath));
                sbHarmDetails.Replace("@s_theme_head_logo_file_name", userTheme.s_theme_head_logo_file_name);
                sbHarmDetails.Replace("@s_theme_report_logo_file_name", userTheme.s_theme_report_logo_file_name);
                sbHarmDetails.Replace("@s_theme_notification_logo_file_name", Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_notification_logo_file_name);
                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_notification_logo_file_name + "')", true);
                sbHarmDetails.Replace("@s_theme_css_tag_section_head_hex_value", userTheme.s_theme_css_tag_section_head_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_section_head_text_hex_value", userTheme.s_theme_css_tag_section_head_text_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_section_head_border_hex_value", userTheme.s_theme_css_tag_section_head_border_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_body_text_hex_value", userTheme.s_theme_css_tag_body_text_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_main_background_hex_value", userTheme.s_theme_css_tag_main_background_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_foot_top_line_hex_value", userTheme.s_theme_css_tag_foot_top_line_hex_value);
                sbHarmDetails.Replace("@s_theme_css_tag_foot_bot_line_hex_value", userTheme.s_theme_css_tag_foot_bot_line_hex_value);
                sbHarmDetails.Replace("@app_harm_information_text:", LocalResources.GetLabel("app_harm_information_text") + lblHarmNumber.Text);
                sbHarmDetails.Replace("@app_harm_number_text", LocalResources.GetLabel("app_harm_number_text"));
                sbHarmDetails.Replace("@lblHarmNumber", lblHarmNumber.Text);
                sbHarmDetails.Replace("@app_harm_case_title_text", LocalResources.GetLabel("app_analysis_title_text"));
                sbHarmDetails.Replace("@lblHarmCaseTitle", lblHarmCaseTitle.Text);
                sbHarmDetails.Replace("@app_harm_case_date_text", LocalResources.GetLabel("app_analysis_date_text"));
                sbHarmDetails.Replace("@lblHarmCaseDate (GMT)", lblHarmCaseDate.Text);
                sbHarmDetails.Replace("@app_harm_case_category_text", LocalResources.GetLabel("app_category_text"));
                sbHarmDetails.Replace("@lblHarmCaseCategory", lblHarmCaseCategory.Text);
                sbHarmDetails.Replace("@app_harm_status_text", LocalResources.GetLabel("app_status_text"));
                sbHarmDetails.Replace("@lblHarmStatus", lblHarmStatus.Text);
                //sbHarmDetails.Replace("@app_harm_employee_report_location_text", LocalResources.GetLabel("app_employee_report_location_text"));
                //sbHarmDetails.Replace("@lblHarmEmployeeReportLocation", lblHarmEmployeeReportLocation.Text);
                sbHarmDetails.Replace("@app_harm_hazard_and_control_measure_summary_text", LocalResources.GetLabel("app_hazard_and_control_measure_summary_text"));
                sbHarmDetails.Replace("@app_harm_additional_information_text", LocalResources.GetLabel("app_additional_information_text"));
                sbHarmDetails.Replace("@app_harm_custom_customer_form(s)_text", LocalResources.GetLabel("app_custom_form(s)_text"));
                sbHarmDetails.Replace("@app_harm_photo(s)_text", LocalResources.GetLabel("app_photo(s)_text"));
                sbHarmDetails.Replace("@app_harm_scene_sketch(es)_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbHarmDetails.Replace("@app_harm_extenuating_condition(s)_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbHarmDetails.Replace("@app_harm_employee_interview(s)_text", LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbHarmDetails.Replace("@app_harm_custom_fields_text", LocalResources.GetLabel("app_custom_fields_text"));
                sbHarmDetails.Replace("@app_harm_custom_01_text", LocalResources.GetLabel("app_custom_01_text"));
                sbHarmDetails.Replace("@lblCustom01", lblCustom01.Text);
                sbHarmDetails.Replace("@app_harm_custom_02_text", LocalResources.GetLabel("app_custom_02_text"));
                sbHarmDetails.Replace("@lblCustom02", lblCustom02.Text);
                sbHarmDetails.Replace("@app_harm_custom_03_text", LocalResources.GetLabel("app_custom_03_text"));
                sbHarmDetails.Replace("@lblCustom03", lblCustom03.Text);
                sbHarmDetails.Replace("@app_harm_custom_04_text", LocalResources.GetLabel("app_custom_04_text"));
                sbHarmDetails.Replace("@lblCustom04", lblCustom04.Text);
                sbHarmDetails.Replace("@app_harm_custom_05_text", LocalResources.GetLabel("app_custom_05_text"));
                sbHarmDetails.Replace("@lblCustom05", lblCustom05.Text);
                sbHarmDetails.Replace("@app_harm_custom_06_text", LocalResources.GetLabel("app_custom_06_text"));
                sbHarmDetails.Replace("@lblCustom06", lblCustom06.Text);
                sbHarmDetails.Replace("@app_harm_custom_07_text", LocalResources.GetLabel("app_custom_07_text"));
                sbHarmDetails.Replace("@lblCustom07", lblCustom07.Text);
                sbHarmDetails.Replace("@app_harm_custom_08_text", LocalResources.GetLabel("app_custom_08_text"));
                sbHarmDetails.Replace("@lblCustom08", lblCustom08.Text);
                sbHarmDetails.Replace("@app_harm_custom_09_text", LocalResources.GetLabel("app_custom_09_text"));
                sbHarmDetails.Replace("@lblCustom09", lblCustom09.Text);
                sbHarmDetails.Replace("@app_harm_custom_10_text", LocalResources.GetLabel("app_custom_10_text"));
                sbHarmDetails.Replace("@lblCustom10", lblCustom10.Text);
                sbHarmDetails.Replace("@app_harm_custom_11_text", LocalResources.GetLabel("app_custom_11_text"));
                sbHarmDetails.Replace("@lblCustom11", lblCustom11.Text);
                sbHarmDetails.Replace("@app_harm_custom_12_text", LocalResources.GetLabel("app_custom_12_text"));
                sbHarmDetails.Replace("@lblCustom12", lblCustom12.Text);
                sbHarmDetails.Replace("@app_harm_custom_13_text", LocalResources.GetLabel("app_custom_13_text"));
                sbHarmDetails.Replace("@lblCustom13", lblCustom13.Text);
                sbHarmDetails.Replace("@app_harm_required_fields_text", LocalResources.GetLabel("app_required_fields_text"));



                ComplianceDAO harm = new ComplianceDAO();

                harm.h_harm_id_pk = view;

                //Custom Customer
                DataTable dtGetCustomCustomer = new DataTable();
                dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);

                StringBuilder sbCustomCustomer = new StringBuilder();
                if (dtGetCustomCustomer.Rows.Count > 0)
                {
                    sbCustomCustomer.Append("<table>");


                    for (int i = 0; i <= dtGetCustomCustomer.Rows.Count - 1; i++)
                    {
                        sbCustomCustomer.Append("<tr>");
                        sbCustomCustomer.Append("<td>");
                        sbCustomCustomer.Append(dtGetCustomCustomer.Rows[i]["h_file_name"].ToString());
                        sbCustomCustomer.Append("</td>");
                        sbCustomCustomer.Append("</tr>");
                    }



                    sbCustomCustomer.Append("</table>");
                }
                sbHarmDetails.Replace("@gvCustomCustomer", sbCustomCustomer.ToString());



                //photo

                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.GetHarmPhoto(harm);

                StringBuilder sbPhoto = new StringBuilder();
                if (dtGetPhoto.Rows.Count > 0)
                {
                    sbPhoto.Append("<table>");


                    for (int i = 0; i <= dtGetPhoto.Rows.Count - 1; i++)
                    {
                        sbPhoto.Append("<tr>");
                        sbPhoto.Append("<td>");
                        sbPhoto.Append(dtGetPhoto.Rows[i]["h_file_name"].ToString());
                        sbPhoto.Append("</td>");
                        sbPhoto.Append("</tr>");
                    }



                    sbPhoto.Append("</table>");
                }
                sbHarmDetails.Replace("@gvPhoto", sbPhoto.ToString());




                //SceneSketch

                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
                StringBuilder sbSceneSketch = new StringBuilder();
                if (dtGetSceneSketch.Rows.Count > 0)
                {
                    sbSceneSketch.Append("<table>");


                    for (int i = 0; i <= dtGetSceneSketch.Rows.Count - 1; i++)
                    {
                        sbSceneSketch.Append("<tr>");
                        sbSceneSketch.Append("<td>");
                        sbSceneSketch.Append(dtGetSceneSketch.Rows[i]["h_file_name"].ToString());
                        sbSceneSketch.Append("</td>");
                        sbSceneSketch.Append("</tr>");
                    }



                    sbSceneSketch.Append("</table>");
                }
                sbHarmDetails.Replace("@gvSceneSketch", sbSceneSketch.ToString());

                //Extenautingcondition

                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);

                StringBuilder sbExtenautingCondition = new StringBuilder();
                if (dtGetExtenautingCondition.Rows.Count > 0)
                {
                    sbExtenautingCondition.Append("<table>");


                    for (int i = 0; i <= dtGetExtenautingCondition.Rows.Count - 1; i++)
                    {
                        sbExtenautingCondition.Append("<tr>");
                        sbExtenautingCondition.Append("<td>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["h_file_name"].ToString());
                        sbExtenautingCondition.Append("</td>");
                        sbExtenautingCondition.Append("</tr>");
                    }



                    sbExtenautingCondition.Append("</table>");
                }
                sbHarmDetails.Replace("@gvExtenuatingCondition", sbExtenautingCondition.ToString());


                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);

                StringBuilder sbEmployeeInterview = new StringBuilder();
                if (dtGetEmployeeInterview.Rows.Count > 0)
                {
                    sbEmployeeInterview.Append("<table>");


                    for (int i = 0; i <= dtGetEmployeeInterview.Rows.Count - 1; i++)
                    {
                        sbEmployeeInterview.Append("<tr>");
                        sbEmployeeInterview.Append("<td valign=top style=width:256px>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["h_file_name"].ToString());
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["h_name"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["h_contact_info"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("</tr>");
                    }



                    sbEmployeeInterview.Append("</table>");
                }
                sbHarmDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());


                //Hazard and control measure summary
                DataTable dtHazard = new DataTable();
                dtHazard = ComplianceBLL.GetAllHazard(harm);
                StringBuilder sbHazard = new StringBuilder();
                if (dtHazard.Rows.Count > 0)
                {


                    sbHazard.Append("<b>" + LocalResources.GetLabel("app_job_title_text") + "</b>" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dtHazard.Rows[0]["h_job_title"] + "<br><br>");
                    foreach (DataRow drHazard in dtHazard.Rows)
                    {
                        sbHazard.Append("<fieldset style=width:850px;font-weight:normal;><legend style=font-weight:bold !important;>Hazard #" + Convert.ToInt32(drHazard.Table.Rows.IndexOf(drHazard) + 1) + "</asp:Label></legend><br />");
                        sbHazard.Append("<table>");
                        sbHazard.Append("<tr>");
                        sbHazard.Append("<td>");
                        sbHazard.Append(LocalResources.GetLabel("app_hazard_text") + ":&nbsp;&nbsp;&nbsp;" + "<b>" + drHazard["h_hazard_description"].ToString() + "</b></br>");
                        sbHazard.Append("</td>");
                        sbHazard.Append("</tr>");
                        sbHazard.Append("<tr>");
                        sbHazard.Append("<td>");
                        sbHazard.Append(LocalResources.GetLabel("app_program_compliance_text") + ":&nbsp;&nbsp;&nbsp;" + "<b>" + drHazard["h_program_compliance_name"].ToString() + "</b></br>");
                        sbHazard.Append("</td>");
                        sbHazard.Append("</tr>");
                        sbHazard.Append("<tr>");
                        sbHazard.Append("<td>");
                        sbHazard.Append(LocalResources.GetLabel("app_permit_compliance_text") + ":&nbsp;&nbsp;&nbsp;" + "<b>" + drHazard["h_permit_compliance_name"].ToString() + "</b></br>");
                        sbHazard.Append("</td>");
                        sbHazard.Append("</tr>");

                        //string hazardId = Guid.NewGuid().ToString();
                        harm.h_hazard_id_pk = drHazard["h_hazard_id_pk"].ToString();
                        //Get control measure
                        DataTable dtCopyControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);
                        sbHazard.Append("<tr>");
                        sbHazard.Append("<td>");
                        sbHazard.Append(LocalResources.GetLabel("app_control_measures_text") + "</br>");
                        sbHazard.Append("</td>");
                        sbHazard.Append("</tr>");
                        foreach (DataRow drCopyControlmeasure in dtCopyControlMeasure.Rows)
                        {
                            string strval = drCopyControlmeasure["h_control_measure_text"].ToString();
                            string title = (string)ViewState["ControlCategory"];
                            string strHazardId = drCopyControlmeasure["h_hazard_id_fk"].ToString();
                            string strhazard_id_fk = (string)ViewState["hazard_id_fk"];
                            string strControlMeasureName = drCopyControlmeasure["h_control_measure_text"].ToString();
                            if (title == strval && strHazardId == strhazard_id_fk)
                            {
                                strControlMeasureName = string.Empty;
                            }
                            else
                            {
                                title = strval;
                                strhazard_id_fk = strHazardId;
                                ViewState["ControlCategory"] = title;
                                ViewState["hazard_id_fk"] = strhazard_id_fk;
                                strControlMeasureName = title;
                                sbHazard.Append("<tr>");
                                sbHazard.Append("<td>");
                                sbHazard.Append("<b>" + strControlMeasureName + "</b>");
                                sbHazard.Append("</td>");
                                sbHazard.Append("</tr>");
                            }


                            sbHazard.Append("<tr>");
                            sbHazard.Append("<td>");
                            sbHazard.Append(Convert.ToInt32(drHazard.Table.Rows.IndexOf(drHazard) + 1) + "." + Convert.ToInt32(drCopyControlmeasure.Table.Rows.IndexOf(drCopyControlmeasure) + 1) + "&nbsp;&nbsp;&nbsp;" + drCopyControlmeasure["h_control_measure_summary"].ToString());
                            sbHazard.Append("</td>");
                            sbHazard.Append("</tr>");
                        }
                        sbHazard.Append("</table>");
                        sbHazard.Append("</fieldset>");
                    }

                    sbHarmDetails.Replace("@lblHazardControlSummary", sbHazard.ToString());

                }
                sbHarmDetails.Replace("@lblHazardControlSummary", LocalResources.GetLabel("app_no_hazard_and_control_measure_text"));
                Utility.SendEMailMessage(mailAddresses, "ComplianceFactors - HARM Details", sbHarmDetails.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + toEmailAddress;
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
                        Logger.WriteToErrorLog("ccvharm-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01.htm", ex.Message);
                    }
                }
            }
        }
        protected void btnSendtoMyMobile_Click(object sender, EventArgs e)
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
                    string TXT = Server.UrlEncode("HARM Number: " + lblHarmNumber.Text + ", " + "Title: " + lblHarmCaseTitle.Text + ", " + "Date: " + lblHarmCaseDate.Text + ", Type: " + lblHarmCaseCategory.Text + ", Status: " + lblHarmStatus.Text);
                    //+ ", Employee Report Location: " + lblHarmEmployeeReportLocation.Text);
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
                    //if mobile number is empty
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
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message);
                    }
                }

            }
            txtMultipe.Text = "";
        }
        protected void btnSendtoMyEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
            {
                sendHarmDetails(SessionWrapper.u_email_id);
            }
            else
            {
                //if email address is empty
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = LocalResources.GetText("app_email_address_not_registered_error_wrong");
            }
        }
        public void SubreportProcessingEvent(object sender, SubreportProcessingEventArgs e)
        {
            try
            {
                controlMeasureCount++;

                PdfTemplate.HARMControlMeasureDataSet ds1 = new PdfTemplate.HARMControlMeasureDataSet();
                PdfTemplate.HARMControlMeasureDataSetTableAdapters.c_harm_sp_report_control_measureTableAdapter da1 = new PdfTemplate.HARMControlMeasureDataSetTableAdapters.c_harm_sp_report_control_measureTableAdapter();

                Guid h_hazard_id_fk = new Guid(e.Parameters["h_hazard_id_fk"].Values[0]);
                da1.Fill(ds1.c_harm_sp_report_control_measure, h_hazard_id_fk, LanguageManager.CurrentCulture.Name, Convert.ToString(controlMeasureCount));


                //DataSet dsControlMeasure = new DataSet();
                //dsControlMeasure = ComplianceBLL.GetControlMeasureReport(e.Parameters["h_hazard_id_fk"].Values[0]);

                e.DataSources.Add(new ReportDataSource("HARMControlMeasure", ds1.Tables["c_harm_sp_report_control_measure"]));
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvharm-01.aspx", ex.Message);
                    }
                }
            }
        }
        
        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
             SystemThemes userTheme = new SystemThemes();
             userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
             return userTheme;
        }
    }
}
