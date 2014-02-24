using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

namespace ComplicanceFactor.SystemHome.Configuration.Data_Imports
{
    public partial class samdimpmp_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        //Upload the csv file
        private string _uploadpath = "~/SystemHome/Configuration/Data Imports/Upload/";
        //private string _roompath = "~/SystemHome/Configuration/Data Imports/Room/";
        //private string _coursespath = "~/SystemHome/Configuration/Data Imports/Course/";
        //private string _curriculumpath = "~/SystemHome/Configuration/Data Imports/Curriculum/";
        //private string _enrollmentpath = "~/SystemHome/Configuration/Data Imports/Enrollment/";
        //private string _learninghistorypath = "~/SystemHome/Configuration/Data Imports/LearningHistory/";

        //Download Sample
        private string _facilitypath = "~/SystemHome/Configuration/Data Imports/SampleFacility/";
        private string _roompath = "~/SystemHome/Configuration/Data Imports/SampleRoom/";
        private string _coursespath = "~/SystemHome/Configuration/Data Imports/SampleCourse/";
        private string _curriculumpath = "~/SystemHome/Configuration/Data Imports/SampleCurriculum/";
        private string _enrollmentpath = "~/SystemHome/Configuration/Data Imports/SampleEnrollment/";
        private string _learninghistorypath = "~/SystemHome/Configuration/Data Imports/SampleLearningHistory/";
        private string _matrixassignmentpath = "~/SystemHome/Configuration/Data Imports/SampleMatrixAssignment/";

        private static string facilityFileName;
        private static string roomFileName;
        private static string courseFileName;
        private static string curriculumFileName;

        private static string dimpId;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Manage Data Imports" + "</a>";

                PopulateDataImport();
            }
        }

        /// <summary>
        ///Populate Data Import
        /// </summary>
        private void PopulateDataImport()
        {
            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            try
            {
                dataImport = SystemDataImportBLL.GetSingleDataImport();
                if (!string.IsNullOrEmpty(dataImport.u_sftp_id_pk))
                {
                    dimpId = dataImport.u_sftp_id_pk;
                    txtSftpServerUrl.Text = dataImport.u_sftp_URI;
                    txtUserName.Text = dataImport.u_sftp_username;
                    txtSftpServerPort.Text = dataImport.u_sftp_port;
                    txtOccursEvery.Text = dataImport.u_sftp_occurs_every;
                    txtEnrollments.Text = dataImport.u_sftp_imp_enrollment_filename;
                    txtLearningHistory.Text = dataImport.u_sftp_imp_learning_history_filename;
                    if (dataImport.u_sftp_imp_is_enrollment == true)
                    {
                        chkEnrollments.Checked = true;
                    }
                    else
                    {
                        chkEnrollments.Checked = false;
                    }

                    if (dataImport.u_sftp_imp_is_learning_history == true)
                    {
                        chkLearningHistory.Checked = true;
                    }
                    else
                    {
                        chkLearningHistory.Checked = false;
                    }
                    facilityFileName = dataImport.u_sftp_imp_facility_filename;
                    courseFileName = dataImport.u_sftp_imp_course_filename;
                    roomFileName = dataImport.u_sftp_imp_room_filename;
                    curriculumFileName = dataImport.u_sftp_imp_base_curricula_filename;

                    txtPassword.Value = dataImport.u_sftp_password;
                    txtPassword.Attributes["type"] = "password";
                    string time = dataImport.u_sftp_time_every;
                    int length = time.Length;
                    ddlTimeConversion.SelectedValue = time.Substring(length - 2, 2);
                    txtHours.Text = time.Remove(length - 2);
                    txtBegining.Text = Convert.ToDateTime(dataImport.u_sftp_start_date).ToString("d");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFacilityUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Facility_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    facilityFileName = s_file_name + s_file_extension;
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnRoomUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Room_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    roomFileName = s_file_name + s_file_extension;
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnCourseUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Course_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    courseFileName = s_file_name + s_file_extension;
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnCurriculumUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Curriculum_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    curriculumFileName = s_file_name + s_file_extension;
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnEnrollmentUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Enrollment_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS"); 
                    txtEnrollments.Text = s_file_name + s_file_extension;
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnLearningHistoryUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "LearningHistory_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    txtLearningHistory.Text = s_file_name + s_file_extension;
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }
        protected void btnMatrixAssignmentUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = "Matrix_Assignment_import_csv_file";
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    txtLearningHistory.Text = s_file_name + s_file_extension;
                    DataTable dtMatrixAssignment = new DataTable();
                    try
                    {
                        dtMatrixAssignment = GetCSVData(Server.MapPath(_uploadpath + s_file_name + s_file_extension));
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message);
                            }
                        }
                    }

                    AssignCourseCurriculum(dtMatrixAssignment);
                    //txtHrisCsvFileName.Text = s_file_name + s_file_extension;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }


        protected void btnSampleFacilitiesFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Facility_import_csv_sample.csv";
            string filePath = Server.MapPath(_facilitypath + attachmentFileId);
            string attachmentFileName = "Facility_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleRoomFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Room_import_csv_sample.csv";
            string filePath = Server.MapPath(_roompath + attachmentFileId);
            string attachmentFileName = "Room_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleCoursesFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Course_import_csv_sample.csv";
            string filePath = Server.MapPath(_coursespath + attachmentFileId);
            string attachmentFileName = "Course_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleBaseCurriculamFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Curriculum_import_csv_sample.csv";
            string filePath = Server.MapPath(_curriculumpath + attachmentFileId);
            string attachmentFileName = "Curriculum_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleEnrollmentsCsvFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Enrollment_import_csv_sample.csv";
            string filePath = Server.MapPath(_enrollmentpath + attachmentFileId);
            string attachmentFileName = "Enrollment_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleLearningHistoryCsvFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "LearningHistory_import_csv_sample.csv";
            string filePath = Server.MapPath(_uploadpath + attachmentFileId);
            string attachmentFileName = "LearningHistory_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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

        protected void btnSampleMatrixAssignment_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Matrix_Assignment_import_csv_sample.csv";
            string filePath = Server.MapPath(_matrixassignmentpath + attachmentFileId);
            string attachmentFileName = "Matrix_Assignment_import_csv_sample.csv";

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
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


        protected void btnSaveDataImportSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            //hrisIntegration.u_sftp_id_pk = hrisId;
            dataImport.u_sftp_URI = txtSftpServerUrl.Text;
            dataImport.u_sftp_port = txtSftpServerPort.Text;
            dataImport.u_sftp_username = txtUserName.Text;
            dataImport.u_sftp_password = txtPassword.Value;

            dataImport.u_sftp_imp_is_enrollment = chkEnrollments.Checked;
            dataImport.u_sftp_imp_enrollment_filename = txtEnrollments.Text;
            dataImport.u_sftp_imp_is_learning_history = chkLearningHistory.Checked;
            dataImport.u_sftp_imp_learning_history_filename = txtLearningHistory.Text;
            dataImport.u_sftp_imp_facility_filename = facilityFileName;
            dataImport.u_sftp_imp_room_filename = roomFileName;
            dataImport.u_sftp_imp_course_filename = courseFileName;
            dataImport.u_sftp_imp_base_curricula_filename = curriculumFileName;

            dataImport.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                if (hours == 12)
                {
                    dataImport.u_sftp_time_every = "00:" + minites;
                }
                else
                {
                    dataImport.u_sftp_time_every = txtHours.Text;
                }
            }
            else
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                if (hours == 12)
                {
                    dataImport.u_sftp_time_every = txtHours.Text;
                }
                else
                {
                    hours = hours + 12;
                    dataImport.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
                }
            }
            dataImport.u_sftp_start_date = txtBegining.Text;

            try
            {
                if (!string.IsNullOrEmpty(dimpId))
                {
                    dataImport.u_sftp_id_pk = dimpId;
                    int updateresult = SystemDataImportBLL.UpdateDataImport(dataImport);
                    if (updateresult == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Updated Successfully";
                    }
                }
                else
                {
                    int result = SystemDataImportBLL.InsertDataImport(dataImport);
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
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Extensions
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

        #region GetValueFromSpreasSheet

        public static DataTable getExcelData(string FileName, string strSheetName)
        {
            DataTable dt = new DataTable();

            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(FileName, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;

                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == strSheetName);
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();

                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                }

                foreach (Row row in rows) //this will also include your header row...
                {
                    DataRow tempRow = dt.NewRow();
                    int columnIndex = 0;
                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        // Gets the column index of the cell with data
                        int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                        cellColumnIndex--; //zero based index
                        if (columnIndex < cellColumnIndex)
                        {
                            do
                            {
                                tempRow[columnIndex] = ""; //Insert blank data here;
                                columnIndex++;
                            }
                            while (columnIndex < cellColumnIndex);
                        }
                        tempRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);

                        columnIndex++;
                    }
                    dt.Rows.Add(tempRow);
                    //DataRow tempRow = dt.NewRow();

                    //for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    //{
                    //    tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                    //}

                    //dt.Rows.Add(tempRow);
                }
            }
            dt.Rows.RemoveAt(0); //...so i'm taking it out here.

            return dt;

        }
        /// <summary>
        /// Get the Cell Value of xl
        /// </summary>
        /// <param name="document"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;

            if (cell.CellValue == null)
            {
                return "";
            }

            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }
        /// <summary>
        /// Given just the column name (no row index), it will return the zero based column index.
        /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
        /// A length of three can be implemented when needed.
        /// </summary>
        /// <param name="columnName">Column Name (ie. A or AB)</param>
        /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
        public static int? GetColumnIndexFromName(string columnName)
        {
            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }

        #endregion

        /// <summary>
        /// Assign Course and Curriculum and drop course and curriculum
        /// </summary>
        /// <param name="dtMatrixAssignment"></param>
        private void AssignCourseCurriculum(DataTable dtMatrixAssignment)
        {
            DataTable dtAssignCourse = AssignCourse();
            DataTable dtAssignCurriculum = AssignCurriculum();
            DataTable dtDropCourse = DropCourse();
            DataTable dtDropCurriculum = DropCurriculum();
            DataTable dtCourse = new DataTable();
            try
            {
                dtCourse = SystemDataImportBLL.GetAllCourse_Id();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message);
                    }
                }
            }

            for (int i = 0; i < dtMatrixAssignment.Rows.Count; i++)
            {
                for (int j = 1; j < dtMatrixAssignment.Columns.Count; j++)
                {
                    if (Convert.ToString(dtMatrixAssignment.Rows[i][j]) == "X")
                    {
                        //Assign
                        string user_id = dtMatrixAssignment.Rows[i][0].ToString();
                        string course_curriculum_id = dtMatrixAssignment.Columns[j].ColumnName;
                        string find = "c_course_system_id_pk = '" + course_curriculum_id.ToUpper() + "'";
                        DataRow[] foundRows = dtCourse.Select(find);
                        if (foundRows.Length > 0)
                        {
                            AddDataForAssignCourse(user_id, course_curriculum_id, dtAssignCourse);
                        }
                        else
                        {
                            AddDataForAssignCurriculum(user_id, course_curriculum_id, dtAssignCurriculum);
                        }
                    }
                    else
                    {
                        //Drop
                        string user_id = dtMatrixAssignment.Rows[i][0].ToString();
                        string course_curriculum_id = dtMatrixAssignment.Columns[j].ColumnName;
                        string find = "c_course_system_id_pk = '" + course_curriculum_id.ToUpper() + "'";
                        DataRow[] foundRows = dtCourse.Select(find);
                        if (foundRows.Length > 0)
                        {
                            AddDataForDropCourse(user_id, course_curriculum_id, dtDropCourse);
                        }
                        else
                        {
                            AddDataForDropCurriculum(user_id, course_curriculum_id, dtDropCurriculum);
                        }
                    }
                }
            }
            //Do assign and drop functionality of course and curriculum
            ConvertDataTables convertToXML = new ConvertDataTables();
            try
            {
                //Course assign and curriculum assign
                string CourseAssign = string.Empty;
                string curriculum = string.Empty;
                if (dtAssignCourse.Rows.Count > 0)
                {
                    CourseAssign = convertToXML.ConvertDataTableToXml(dtAssignCourse);
                }
                if (dtAssignCurriculum.Rows.Count > 0)
                {
                    curriculum = convertToXML.ConvertDataTableToXml(dtAssignCurriculum);
                }
                DataSet ds = SystemDataImportBLL.AssignCourseCurriculum(CourseAssign, curriculum, SessionWrapper.u_userid);

                //Drop Course and Curriculum
                string dropCourse = string.Empty;
                string dropCurriculum = string.Empty;
                if(dtDropCourse.Rows.Count > 0)
                {
                    dropCourse = convertToXML.ConvertDataTableToXml(dtDropCourse);
                }
                if(dtDropCurriculum.Rows.Count>0)
                {
                    dropCurriculum =  convertToXML.ConvertDataTableToXml(dtDropCurriculum);
                }
                int result = SystemDataImportBLL.DropCourseCurriculum(dropCourse, dropCurriculum); 

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdimpmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Temp datatable for assign course
        /// </summary>
        /// <returns></returns>
        private DataTable AssignCourse()
        {
            DataTable dtAssignCourse = new DataTable();
            DataColumn dtAssignCourseColumn;

            dtAssignCourseColumn = new DataColumn();
            dtAssignCourseColumn.DataType = Type.GetType("System.String");
            dtAssignCourseColumn.ColumnName = "employeeID";
            dtAssignCourse.Columns.Add(dtAssignCourseColumn);

            dtAssignCourseColumn = new DataColumn();
            dtAssignCourseColumn.DataType = Type.GetType("System.String");
            dtAssignCourseColumn.ColumnName = "course_id";
            dtAssignCourse.Columns.Add(dtAssignCourseColumn);

            dtAssignCourseColumn = new DataColumn();
            dtAssignCourseColumn.DataType = Type.GetType("System.String");
            dtAssignCourseColumn.ColumnName = "course_assign_by_id";
            dtAssignCourse.Columns.Add(dtAssignCourseColumn);

            dtAssignCourseColumn = new DataColumn();
            dtAssignCourseColumn.DataType = Type.GetType("System.Boolean");
            dtAssignCourseColumn.ColumnName = "required";
            dtAssignCourse.Columns.Add(dtAssignCourseColumn);

            dtAssignCourseColumn = new DataColumn();
            dtAssignCourseColumn.DataType = Type.GetType("System.String");
            dtAssignCourseColumn.ColumnName = "DueDate";
            dtAssignCourse.Columns.Add(dtAssignCourseColumn);

            return dtAssignCourse;
        }
        /// <summary>
        /// Temp datatable for Drop Course
        /// </summary>
        /// <returns></returns>
        private DataTable DropCourse()
        {
            DataTable dtDropCourse = new DataTable();
            DataColumn dtDropCourseColumn;

            dtDropCourseColumn = new DataColumn();
            dtDropCourseColumn.DataType = Type.GetType("System.String");
            dtDropCourseColumn.ColumnName = "user_id";
            dtDropCourse.Columns.Add(dtDropCourseColumn);

            dtDropCourseColumn = new DataColumn();
            dtDropCourseColumn.DataType = Type.GetType("System.String");
            dtDropCourseColumn.ColumnName = "course_id";
            dtDropCourse.Columns.Add(dtDropCourseColumn);

            return dtDropCourse;
        }

        /// <summary>
        /// Temp datatable for drop curriculum
        /// </summary>
        /// <returns></returns>
        private DataTable DropCurriculum()
        {
            DataTable dtDropCurriculum = new DataTable();
            DataColumn dtDropCurriculumColumn;

            dtDropCurriculumColumn = new DataColumn();
            dtDropCurriculumColumn.DataType = Type.GetType("System.String");
            dtDropCurriculumColumn.ColumnName = "user_id";
            dtDropCurriculum.Columns.Add(dtDropCurriculumColumn);

            dtDropCurriculumColumn = new DataColumn();
            dtDropCurriculumColumn.DataType = Type.GetType("System.String");
            dtDropCurriculumColumn.ColumnName = "curriculum_id";
            dtDropCurriculum.Columns.Add(dtDropCurriculumColumn);

            return dtDropCurriculum;
        }

        /// <summary>
        /// Temp datatable for Assign Curriculum
        /// </summary>
        /// <returns></returns>
        private DataTable AssignCurriculum()
        {
            DataTable dtCurriculumAssign = new DataTable();
            DataColumn dtAssignCurriculumColumn;

            dtAssignCurriculumColumn = new DataColumn();
            dtAssignCurriculumColumn.DataType = Type.GetType("System.String");
            dtAssignCurriculumColumn.ColumnName = "employeeID";
            dtCurriculumAssign.Columns.Add(dtAssignCurriculumColumn);

            dtAssignCurriculumColumn = new DataColumn();
            dtAssignCurriculumColumn.DataType = Type.GetType("System.String");
            dtAssignCurriculumColumn.ColumnName = "curriculum_id";
            dtCurriculumAssign.Columns.Add(dtAssignCurriculumColumn);

            dtAssignCurriculumColumn = new DataColumn();
            dtAssignCurriculumColumn.DataType = Type.GetType("System.Boolean");
            dtAssignCurriculumColumn.ColumnName = "required";
            dtCurriculumAssign.Columns.Add(dtAssignCurriculumColumn);

            dtAssignCurriculumColumn = new DataColumn();
            dtAssignCurriculumColumn.DataType = Type.GetType("System.String");
            dtAssignCurriculumColumn.ColumnName = "DueDate";
            dtCurriculumAssign.Columns.Add(dtAssignCurriculumColumn);

            return dtCurriculumAssign;
        }
        /// <summary>
        /// Add Data For Assign Course
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="course_id"></param>
        /// <param name="dtAssignCourse"></param>
        private void AddDataForAssignCourse(string user_id, string course_id, DataTable dtAssignCourse)
        {
            DataRow row;

            row = dtAssignCourse.NewRow();
            row["employeeID"] = user_id;
            row["course_id"] = course_id;
            row["course_assign_by_id"] = SessionWrapper.u_userid;
            row["required"] = false;
            row["DueDate"] = string.Empty;

            dtAssignCourse.Rows.Add(row);
        }

        /// <summary>
        /// Add Data for curriculum assign
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="curriculum_id"></param>
        /// <param name="dtAssignCurriculum"></param>
        private void AddDataForAssignCurriculum(string user_id, string curriculum_id, DataTable dtAssignCurriculum)
        {
            DataRow row;

            row = dtAssignCurriculum.NewRow();
            row["employeeID"] = user_id;
            row["curriculum_id"] = curriculum_id;
            row["required"] = false;
            row["DueDate"] = string.Empty;

            dtAssignCurriculum.Rows.Add(row);
        }

        /// <summary>
        /// Add data for drop curriculum
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="course_curriculum_id"></param>
        /// <param name="dtDropCurriculum"></param>
        private void AddDataForDropCurriculum(string user_id, string course_curriculum_id, DataTable dtDropCurriculum)
        {
            DataRow row;
            row = dtDropCurriculum.NewRow();
            row["user_id"] = user_id;
            row["curriculum_id"] = course_curriculum_id;
            dtDropCurriculum.Rows.Add(row);
        }

        /// <summary>
        /// Add data for drop course
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="course_id"></param>
        /// <param name="dtDropCourse"></param>
        private void AddDataForDropCourse(string user_id, string course_id, DataTable dtDropCourse)
        {
            DataRow row;
            row = dtDropCourse.NewRow();
            row["user_id"] = user_id;
            row["course_id"] = course_id;
            dtDropCourse.Rows.Add(row);
        }

        /// <summary>
        /// Get Csv Data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable GetCSVData(string CSVFilePathName)
        {
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;

            Fields = Lines[0].TrimEnd(',').Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);

            DataTable dt = new DataTable();

            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;

            using (var sr = File.OpenText(CSVFilePathName))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        Fields = Lines[i].Split(new char[] { ',' });
                        Row = dt.NewRow();

                        for (int f = 0; f < Cols; f++)

                            Row[f] = Fields[f];

                        dt.Rows.Add(Row);
                        i = i + 1;
                    }
                }
            }
            dt.Rows.RemoveAt(0);
            return dt;
        }
    }
}