using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.IO;
using System.Data;
using ComplicanceFactor.Common.Languages;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
namespace ComplicanceFactor.SystemHome.Configuration.Reports
{
    public partial class saerp_01 : System.Web.UI.Page
    {
        public string ReportId
        {
            get
            {
                return (ViewState["ReportId"] == null) ? "" : ViewState["ReportId"].ToString();
            }
            set
            {
                ViewState["ReportId"] = value;
            }
        }
        private string NewReportId
        {
            get
            {
                return (ViewState["NewReportId"] == null) ? "" : ViewState["NewReportId"].ToString();
            }
            set
            {
                ViewState["NewReportId"] = value;
            }
        }
        private string ReportSourceFile
        {
            get
            {
                return (ViewState["ReportSourceFile"] == null) ? "" : ViewState["ReportSourceFile"].ToString();
            }
            set
            {
                ViewState["ReportSourceFile"] = value;
            }
        }
       
        public string webReportId
        {
            get
            {
                return (ViewState["webReportId"] == null) ? "" : ViewState["webReportId"].ToString();
            }
            set
            {
                ViewState["webReportId"] = value;
            }
        }
        private string _filePath = "~/SystemHome/Configuration/Reports/Files/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.Locale = TempDataTables.TempReportLocale();
                SessionWrapper.ReportParam = TempDataTables.TempReportParam();
                SessionWrapper.ReportColumn = TempDataTables.TempReportColumn();
                SessionWrapper.ReportLabelLocale = TempDataTables.TempReportLabelLocale();
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
               
                if (!string.IsNullOrEmpty(Request.QueryString["Edit"]))
                {
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Reports/samrmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_reports_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_report_text") + "</a>";
                    txtReportId.Visible = false; 
                    ReportId = SecurityCenter.DecryptText(Request.QueryString["Edit"]);
                    webReportId = SecurityCenter.EncryptText(ReportId);
                    PopulateReport(ReportId);
                   
                }
                else
                {
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Reports/samrmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_reports_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_add_report_text") + "</a>";
                    NewReportId = Guid.NewGuid().ToString();
                    webReportId = SecurityCenter.EncryptText(NewReportId);
                    lblReportId.Visible = false;
                }
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();
                ddlLocale.SelectedIndex = 0;
            }
            if (!string.IsNullOrEmpty(webReportId))
            {
                if (Request.Params["mode"].ToString() == "create")
                {
                    lblType.Text = "Custom";
                    if (SessionWrapper.ReportParam.Rows.Count > 0)
                    {                        
                        gvParameters.DataSource = SessionWrapper.ReportParam;
                        gvParameters.DataBind();
                    }
                    if (SessionWrapper.ReportColumn.Rows.Count > 0)
                    {
                        gvColumns.DataSource = SessionWrapper.ReportColumn;
                        gvColumns.DataBind();
                    }
                    if (SessionWrapper.ReportLabelLocale.Rows.Count > 0)
                    {
                        DataTable source = new DataTable();
                        source.Columns.Add("s_locale_description");
                        source.Columns.Add("s_locale_id_pk");
                        foreach (DataRow row in SessionWrapper.ReportLabelLocale.Rows)
                        {
                            bool isAdd = false;
                            foreach (DataRow sRow in source.Rows)
                            {
                                if (sRow["s_locale_id_pk"] == row["s_locale_id_pk"])
                                {
                                    isAdd = true;
                                    break;
                                }
                            }
                            if (!isAdd)
                            {
                                DataRow newRow = source.NewRow();
                                newRow["s_locale_description"] = row["s_locale_description"];
                                newRow["s_locale_id_pk"] = row["s_locale_id_pk"];
                                source.Rows.Add(newRow);
                            }
                        }
                        gvReportLocales.DataSource = source;
                        gvReportLocales.DataBind();
                        foreach (DataRow dtrow in SessionWrapper.ReportLabelLocale.Rows)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_pk"], "RemoveLocale('" + dtrow["s_locale_id_pk"] + "');", true);
                        }
                    }
                }
                else
                {
                    gvParameters.DataSource = SystemReportBLL.GetParamsOfReport(SecurityCenter.DecryptText(webReportId));
                    gvParameters.DataBind();

                    gvColumns.DataSource = SystemReportBLL.GetColumnsOfReport(SecurityCenter.DecryptText(webReportId));
                    gvColumns.DataBind();
                    DataTable reportLabelLocales = SystemReportBLL.GetLanguagesOfReport(SecurityCenter.DecryptText(webReportId));
                    gvReportLocales.DataSource = reportLabelLocales;
                    gvReportLocales.DataBind();
                    foreach (DataRow dtrow in reportLabelLocales.Rows)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_pk"], "RemoveLocale('" + dtrow["s_locale_id_pk"] + "');", true);
                    }


                }
            }
            Attachment();
        }
        private void PopulateReport(string reportId)
        {
            SystemReport report = new SystemReport();

            try
            {
                report = SystemReportBLL.GetSingleReport(reportId, SessionWrapper.Locale);

                lblReportId.Text = report.s_report_id_pk;
                txtReportId.Text = report.s_report_id_pk;
                txtReportName.Text = report.s_report_name;
                txtDescription.InnerText = report.s_report_description;
                chkInstructor.Checked = report.s_report_instructor_flag;

                chkCoordinator.Checked = report.s_report_coordinator_flag;
                chkAdminstrator.Checked = report.s_report_admin_flag;

                lblType.Text = report.s_report_type_id_fk;
                chkManager.Checked = report.s_report_manager_flag;
                chkCompliance.Checked = report.s_report_compliance_flag;
                ReportSourceFile = report.s_report_source_file_name;
               
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                SystemReport report;
                if (string.IsNullOrEmpty(ReportId))
                {
                    report = new SystemReport()
                    {
                        s_report_system_id_pk = NewReportId,//Guid.NewGuid().ToString(),
                        s_report_id_pk = txtReportId.Text,
                        s_report_name = txtReportName.Text,
                        s_report_description = txtDescription.InnerText,
                        s_report_instructor_flag = chkInstructor.Checked,
                        s_report_coordinator_flag = chkCoordinator.Checked,
                        s_report_admin_flag = chkAdminstrator.Checked,
                        s_report_manager_flag = chkManager.Checked,
                        s_report_compliance_flag = chkCompliance.Checked,
                        s_report_type_id_fk = lblType.Text,
                        s_report_source_file_name = ReportSourceFile,
                        s_report_on_off_flag = false,
                        s_report_locale = ConvertDataTableToXml(SessionWrapper.Locale),
                        s_report_param = ConvertDataTableToXml(SessionWrapper.ReportParam),
                        s_report_label_locale = ConvertDataTableToXml(SessionWrapper.ReportLabelLocale),
                        s_report_column = ConvertDataTableToXml(SessionWrapper.ReportColumn),

                    };
                
                    int result = SystemReportBLL.CreateNewReport(report);
                   
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    }
                }
                else
                {
                    DataTable locale = new DataTable();
                    report = SystemReportBLL.GetSingleReport(ReportId, locale);
                    report.s_report_id_pk = lblReportId.Text;
                    report.s_report_name = txtReportName.Text;
                    report.s_report_description = txtDescription.InnerText;
                    report.s_report_instructor_flag = chkInstructor.Checked;
                    report.s_report_coordinator_flag = chkCoordinator.Checked;
                    report.s_report_admin_flag = chkAdminstrator.Checked;
                    report.s_report_manager_flag = chkManager.Checked;
                    report.s_report_compliance_flag = chkCompliance.Checked;
                    report.s_report_source_file_name = ReportSourceFile;
                    int result = SystemReportBLL.UpdateReport(report);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
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
                        Logger.WriteToErrorLog("saerp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01.aspx", ex.Message);
                    }
                }
            }
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Reports/samrmp-01.aspx");
        }
        //Delete Audience
        [System.Web.Services.WebMethod]
        public static void DeleteParam(string args, string reportId)
        {
          
            try
            {
                if (SessionWrapper.ReportParam.Rows.Count > 0)
                {
                    var rows = SessionWrapper.ReportParam.Select("s_report_param_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                SystemReportBLL.DeleteParamOfReport(args, reportId);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message);
                    }
                }
            }


        }
        //Delete Locale
        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string reportId, string args)
        {

            try
            {
                if (SessionWrapper.ReportLabelLocale.Rows.Count > 0)
                {
                    var rows = SessionWrapper.ReportLabelLocale.Select("s_locale_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.ReportLabelLocale.AcceptChanges();
                }
                SystemReportBLL.DeleteLabelLocaleOfReport(reportId, args);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message);
                    }
                }
            }


        }
        [System.Web.Services.WebMethod]
        public static void DeleteColumn(string args, string reportId)
        {
            try
            {
                if (SessionWrapper.ReportColumn.Rows.Count > 0)
                {
                    var rows = SessionWrapper.ReportColumn.Select("s_report_column_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                SystemReportBLL.DeleteColumnOfReport(args, reportId);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message);
                    }
                }
            }


        }

        protected void btnUploadCsv_Click(object sender, EventArgs e)
        {
           DataTable table = dataset_csv("","");
           SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
               
           foreach (DataRow row in table.Rows)
           {

               DataTable locales = EmployeeCatalogBLL.GetLocalelist();
               for (int i = 0; i < table.Columns.Count; i++)
               {
                   string label_id = "";
                   if (table.Columns[0].ColumnName.Trim() == "rpt_label_id")
                   {
                       label_id = row[0].ToString();
                   }
                   else
                   {
                       return;
                   }
                   if (!string.IsNullOrEmpty(row[i].ToString()))
                   {
                       DataRow[] locale = locales.Select("s_locale_short_Name='" + table.Columns[i].ColumnName.Trim() + "'");
                       if (locale.Length > 0)
                       {
                           SystemReportBLL.UpdateLocalesOfReport(locale[0][0].ToString(), row[i].ToString(), label_id, SecurityCenter.DecryptText(Request.Params["edit"].ToString()));
                       }
                   }
               }
           
           }
          
           Response.Redirect(Request.Url.ToString());
        }
        public  DataTable dataset_csv(string sql, string fileurl)
        {
            HttpPostedFile file = default(HttpPostedFile);
            string m_file_name = null;
            string m_file_extension = null;
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
               

                if (file != null && file.ContentLength > 0)
                {
                    m_file_name = Path.GetFileName(file.FileName);
                    m_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_filePath + m_file_name));
                    ReportSourceFile = m_file_name;

                }
            }
            OleDbConnection oleconn = new OleDbConnection();
            OleDbCommand olecmd = new OleDbCommand();
            OleDbDataAdapter oleadp;
            DataSet csvdataset;
            oleconn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(_filePath)+ ";Extended Properties='Text;FMT=Delimited;HDR=YES;'";
            using (oleadp = new OleDbDataAdapter("select * from " + m_file_name, oleconn))
            {
                using (csvdataset = new DataSet("csv"))
                {
                    oleadp.Fill(csvdataset, "csvtable");
                    return csvdataset.Tables[0];
                }
            }
            olecmd.Dispose();
            oleconn.Close();
        }
        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string m_file_name = null;
                string m_file_extension = null;

                if (file != null && file.ContentLength > 0)
                {
                    m_file_name = Path.GetFileName(file.FileName);
                    m_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_filePath + m_file_name));
                    ReportSourceFile = m_file_name;

                }
            }
            Attachment();



        }
        /// <summary>
        /// Attachment
        /// </summary>
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(ReportSourceFile))
            {
                lnkFileName.Text = ReportSourceFile;
                btnAttachment.Style.Add("display", "none");
                btnEdit.Style.Add("display", "inline");
                btnRemove.Style.Add("display", "inline");
                btnView.Style.Add("display", "inline");
            }
            else
            {
                lnkFileName.Text = string.Empty;
                btnAttachment.Style.Add("display", "inline");
                btnEdit.Style.Add("display", "none");
                btnRemove.Style.Add("display", "none");
                btnView.Style.Add("display", "none");

            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            ReportSourceFile = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        /// <summary>
        /// Attachment Download
        /// </summary>
        private void AttachmentDownload()
        {
            string filePath = Server.MapPath(_filePath + ReportSourceFile);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ReportSourceFile + "\"");
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
        /// <summary>
        /// Extension
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
    }
}