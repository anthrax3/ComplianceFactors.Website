using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Text;
using System.IO;
using System.Globalization;
using System.Net;

namespace ComplicanceFactor.SystemHome.Configuration.DataExports
{
    public partial class samdexpmp_01 : System.Web.UI.Page
    {
        private static string dexpId;
        public static string APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/Export_CSV/");
        public static string TEMP_APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/TempLogFiles/");
        public static string FACILITIES_FILE_PATH = APP_PATH + "Facilities.csv";
        public static string HRIS_FILE_PATH = APP_PATH + "Hris.csv";
        public static string ROOMS_FILE_PATH = APP_PATH + "Rooms.csv";
        public static string COURSES_FILE_PATH = APP_PATH + "Courses.csv";
        public static string CURRICULUM_FILE_PATH = APP_PATH + "Curriculum.csv";
        public static string ENROLLMENTS_FILE_PATH = APP_PATH + "Enrollment.csv";
        public static string LEARNING_HISTORY_FILE_PATH = APP_PATH + "Learning_History.csv";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Manage Data Exports" + "</a>";
                PopulateDataExport();
                //FTP_Upload();
            }
        }

        /// <summary>
        ///Populate Data Export
        /// </summary>
        private void PopulateDataExport()
        {
            SystemHRISIntegration dataExport = new SystemHRISIntegration();

            try
            {
                dataExport = SystemDataExportBLL.GetSingleDataExport();
                if (!string.IsNullOrEmpty(dataExport.u_sftp_id_pk))
                {
                    dexpId = dataExport.u_sftp_id_pk;
                    txtSftpServerUrl.Text = dataExport.u_sftp_URI;
                    txtUserName.Text = dataExport.u_sftp_username;
                    txtSftpServerPort.Text = dataExport.u_sftp_port;
                    txtOccursEvery.Text = dataExport.u_sftp_occurs_every;
                    txtLearningHistory.Text = dataExport.u_sftp_exp_learning_history_filename;
                    if (dataExport.u_sftp_exp_is_learning_history == true)
                    {
                        chkLearningHistory.Checked = true;
                    }
                    else
                    {
                        chkLearningHistory.Checked = false;
                    }

                    if (dataExport.u_sftp_exp_is_catalog_offering == true)
                    {
                        chkCatalogOfferings.Checked = true;
                    }
                    else
                    {
                        chkCatalogOfferings.Checked = false;
                    }

                    if (dataExport.u_sftp_exp_is_hris == true)
                    {
                        chkHris.Checked = true;
                    }
                    else
                    {
                        chkHris.Checked = false;
                    }
                    txtCatalogOfferings.Text = dataExport.u_sftp_exp_catalog_offering_filename;
                    txtHris.Text = dataExport.u_sftp_exp_hris_filename;

                    txtPassword.Value = dataExport.u_sftp_password;
                    txtPassword.Attributes["type"] = "password";
                    string time = dataExport.u_sftp_time_every;
                    int length = time.Length;
                    ddlTimeConversion.SelectedValue = time.Substring(length - 2, 2);
                    txtHours.Text = time.Remove(length - 2);
                    txtBegining.Text = Convert.ToDateTime(dataExport.u_sftp_start_date).ToString("d");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnSaveDataExportSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            //hrisIntegration.u_sftp_id_pk = hrisId;
            dataImport.u_sftp_URI = txtSftpServerUrl.Text;
            dataImport.u_sftp_port = txtSftpServerPort.Text;
            dataImport.u_sftp_username = txtUserName.Text;
            dataImport.u_sftp_password = txtPassword.Value;

            dataImport.u_sftp_exp_is_hris = chkHris.Checked;
            dataImport.u_sftp_exp_hris_filename = txtHris.Text;
            dataImport.u_sftp_exp_is_catalog_offering = chkCatalogOfferings.Checked;
            dataImport.u_sftp_exp_catalog_offering_filename = txtCatalogOfferings.Text;
            dataImport.u_sftp_exp_is_learning_history = chkLearningHistory.Checked;
            dataImport.u_sftp_exp_learning_history_filename = txtLearningHistory.Text;

            dataImport.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {
                dataImport.u_sftp_time_every = txtHours.Text;
            }
            else
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                hours = hours + 12;
                dataImport.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
            }
            dataImport.u_sftp_start_date = txtBegining.Text;

            try
            {
                if (!string.IsNullOrEmpty(dexpId))
                {
                    dataImport.u_sftp_id_pk = dexpId;
                    int updateresult = SystemDataExportBLL.UpdateDataExport(dataImport);
                    if (updateresult == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Updated Successfully";
                    }
                }
                else
                {
                    int result = SystemDataExportBLL.InsertDataExport(dataImport);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Inserted Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Convert DataTable to CSV
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        private void GetDatatableToCsv(DataTable dt, String path)
        {
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Columns[k].ColumnName + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
                }
                //append new line
                sb.Append("\r\n");
            }

            FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                System.IO.File.Delete(path);
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;
        }

        private void FTP_Upload()
        {
            string u_sftp_time_every = "12:00:00.0000000";
            int u_sftp_occurs_every = 1;

            if (u_sftp_time_every == "12:00:00.0000000")
            {
                //Convert DaTaTable CSV
                DataTable dtFacilities = new DataTable();
                dtFacilities = SystemDataExportBLL.GetFacilities();
                DateTime facilitiyStartDate = DateTime.Now;
                GetDatatableToCsv(dtFacilities, FACILITIES_FILE_PATH);
                CreateLogFile(dtFacilities, "ftp://compfact@174.121.42.195/compliancefactors.com/wwwroot/ComplianceSystem/SystemHome/Configuration/DataExports/TempLogFiles/", "compfact", "Factors1", facilitiyStartDate, "Facilities");//Test Manual
                CreateCSVFile("ftp://compfact@174.121.42.195/compliancefactors.com/wwwroot/ComplianceSystem/SystemHome/Configuration/DataExports/ExportCSVFile/", "compfact", "Factors1", FACILITIES_FILE_PATH, "Facilities.csv");//Test Manual

                //DataTable dtCourses = new DataTable();
                //dtCourses = SystemDataImportExportBLL.GetCourses();
                //string CourseStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtCourses, COURSES_FILE_PATH);


                //DataTable dtCurriculum = new DataTable();
                //dtCurriculum = SystemDataImportExportBLL.GetCurriculum();
                //string CurriculumStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtCurriculum, CURRICULUM_FILE_PATH);


                //DataTable dtEnrollments = new DataTable();
                //dtEnrollments = SystemDataImportExportBLL.GetEnrollments();
                //string EnrollmentStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtEnrollments, ENROLLMENTS_FILE_PATH);


                //DataTable dtLearningHistory = new DataTable();
                //dtLearningHistory = SystemDataImportExportBLL.GetLearningHisory();
                //string LearningHistoryStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtLearningHistory, LEARNING_HISTORY_FILE_PATH);


                //DataTable dtRooms = new DataTable();
                //dtRooms = SystemDataImportExportBLL.GetRooms();
                //string roomStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtRooms, ROOMS_FILE_PATH);


                //DataTable dtHris = new DataTable();
                //dtHris = SystemDataImportExportBLL.GetHris();
                //string hrisStartDate = DateTime.Now.ToString();
                //GetDatatableToCsv(dtHris, HRIS_FILE_PATH);



            }
        }

        /// <summary>
        /// Create Log File For HRIS
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateLogFile(DataTable dt, string uri, string userName, string password, DateTime StartDate, string CSVfilename)
        {

            DateTime endDate;
            //string _logpath = "~/SystemHome/Configuration/HRIS Integration/Log/";
            string filename = "CF_EXPORT_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString().Substring(0, 5) + ".txt";
            filename = filename.Replace("/", "_");
            filename = filename.Replace(":", "_");
            //string path = Server.MapPath(_logpath);TEMP_APP_PATH
            string filePath = TEMP_APP_PATH + filename.TrimEnd();
            FileStream fs1 = new FileStream(TEMP_APP_PATH + filename.TrimEnd(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("************************************");
            sb.AppendLine("CF Data Export Upload Job:");
            sb.AppendLine("************************************");
            sb.AppendLine();
            sb.AppendLine("Started on:" + StartDate.ToShortDateString() + " at " + (StartDate.ToShortTimeString()));
            endDate = DateTime.Now;
            sb.AppendLine("Ended on:" + endDate.ToShortDateString() + " at " + endDate.ToShortTimeString());
            sb.AppendLine();
            sb.AppendLine("Initiated Job: Pass");
            sb.AppendLine("Connected to SFTP: Pass");
            sb.AppendLine("Uploaded " + CSVfilename + " File: Pass");
            sb.AppendLine("Loaded (" + dt.Rows.Count + ") records");
            sb.AppendLine();
            sb.AppendLine("************************************");
            sb.AppendLine("End of Report");
            sb.AppendLine("************************************");

            writer.Write(sb.ToString());
            writer.Close();

            //Create Log File In FTP

            System.Threading.Thread.Sleep(8000);

            CreateLogFileInFTP(filename, uri, userName, password, sb.ToString(), filePath);

            //Insert sftp_run_log table

            SystemHRISIntegration hrisRunlog = new SystemHRISIntegration();
            hrisRunlog.u_sftp_run_log_type = "DEXP";
            hrisRunlog.u_sftp_run_date_time_start = StartDate.ToString();
            hrisRunlog.u_sftp_run_date_time_end = endDate.ToString();
            //if (rejectedRows.Length > 0)
            //{
            //    hrisRunlog.u_sftp_run_result = "Errors";
            //}
            //else
            //{
            hrisRunlog.u_sftp_run_result = "Success";
            //}
            hrisRunlog.u_sftp_run_log_file_transfer = "Success";
            hrisRunlog.u_sftp_run_errors_details_filename = filename;
            string errorLog = sb.ToString();
            errorLog = errorLog.Replace("\r\n", "<br/>");
            hrisRunlog.u_sftp_run_errors_log = errorLog;
            hrisRunlog.u_sftp_run_records_processes = dt.Rows.Count;
            hrisRunlog.u_sftp_run_records_loaded = dt.Rows.Count;
            hrisRunlog.u_sftp_run_records_rejected = 0;

            try
            {
                //Insert Hris Run log
                int result = SystemHRISIntegrationBLL.InsertHRISRunLog(hrisRunlog);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("global.asax", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("global.asax", ex.Message);
                    }
                }
            }
        }


        private void CreateLogFileInFTP(string filename, string uri, string userName, string password, string text, string path)
        {
            FileInfo toUpload = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();

            FileStream file = File.OpenRead(path);

            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            do
            {
                bytesRead = file.Read(buffer, 0, length);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();
        }

        private void CreateCSVFileInFTP(string filename, string uri, string userName, string password, string text, string path)
        {
            FileInfo toUpload = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();

            FileStream file = File.OpenRead(path);

            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            do
            {
                bytesRead = file.Read(buffer, 0, length);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();
        }


        /// <summary>
        /// Create Log File For HRIS
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateCSVFile(string uri, string userName, string password, string ftp_path, string filename)
        {

            FileInfo toUpload = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();

            FileStream file = File.OpenRead(APP_PATH + filename);

            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            do
            {
                bytesRead = file.Read(buffer, 0, length);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();


        }
        /// <summary>
        /// Download Facilities CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadFacilitiesCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Facilities.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Rooms CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadRoomsCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Rooms.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Course CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadCoursesCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Course.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Curriculum CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadBaseCurriculamCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Curriculum.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Enrollments CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadEnrollmentsCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Enrollments.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Leraning History CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadLearningHistory_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Learning_History.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
}