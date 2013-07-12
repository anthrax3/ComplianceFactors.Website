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
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message);
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

        protected void btnSampleFacilitiesFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "Facility_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_facilitypath + attachmentFileId);
            string attachmentFileName = "Facility_import_csv_sample.xlsx";

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
            string attachmentFileId = "Room_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_roompath + attachmentFileId);
            string attachmentFileName = "Room_import_csv_sample.xlsx";

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
            string attachmentFileId = "Course_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_coursespath + attachmentFileId);
            string attachmentFileName = "Course_import_csv_sample.xlsx";

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
            string attachmentFileId = "Curriculum_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_curriculumpath + attachmentFileId);
            string attachmentFileName = "Curriculum_import_csv_sample.xlsx";

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
            string attachmentFileId = "Enrollment_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_enrollmentpath + attachmentFileId);
            string attachmentFileName = "Enrollment_import_csv_sample.xlsx";

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
            string attachmentFileId = "LearningHistory_import_csv_sample.xlsx";
            string filePath = Server.MapPath(_learninghistorypath + attachmentFileId);
            string attachmentFileName = "LearningHistory_import_csv_sample.xlsx";

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
                        divSuccess.InnerHtml =  "Inserted Successfully";
                    }
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message);
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
    }
}