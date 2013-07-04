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
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComplicanceFactor.SystemHome.Configuration.HRISIntegration
{
    public partial class samhrismp_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Configuration/HRISIntegration/Uploaded/";
        private string _downloadpath = "~/SystemHome/Configuration/HRISIntegration/Sample/";
        private DateTime start;
        private static string hrisId;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_hris_integration_text") + "</a>";

                PopulateHRISIntegration();
            }
        }
        /// <summary>
        /// Populare HRIS Integration
        /// </summary>
        private void PopulateHRISIntegration()
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            try
            {
                hrisIntegration = SystemHRISIntegrationBLL.GetHRIS();
                if (!string.IsNullOrEmpty(hrisIntegration.u_sftp_id_pk))
                {
                    hrisId = hrisIntegration.u_sftp_id_pk;
                    txtSftpServerUrl.Text = hrisIntegration.u_sftp_URI;
                    txtUserName.Text = hrisIntegration.u_sftp_username;
                    txtSftpServerPort.Text = hrisIntegration.u_sftp_port;
                    txtOccursEvery.Text = hrisIntegration.u_sftp_occurs_every;
                    txtHrisCsvFileName.Text = hrisIntegration.u_sftp_hris_filename;
                    txtPassword.Value = hrisIntegration.u_sftp_password;
                    txtPassword.Attributes["type"] = "password";
                    string time = hrisIntegration.u_sftp_time_every;
                    int length = time.Length;
                    ddlTimeConversion.SelectedValue = time.Substring(length - 2, 2);
                    txtHours.Text = time.Remove(length - 2);
                    txtBegining.Text = Convert.ToDateTime(hrisIntegration.u_sftp_start_date).ToString("d");
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

        protected void btnUploadAttachements_Click(object sender, EventArgs e)
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
                    s_file_name = Path.GetFileName(file.FileName);
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension));
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");                   
                    txtHrisCsvFileName.Text = s_file_name;
                    //InsertIntoUserMaster(dtHRIS);
                }
            }
        }

        protected void btnDownloadSampleHrisCsvFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "HRIS_import_csv_example.xlsx";
            string filePath = Server.MapPath(_downloadpath + attachmentFileId);
            string attachmentFileName = "HRIS_import_csv_example.xlsx";

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

        protected void btnSaveHrisSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            //hrisIntegration.u_sftp_id_pk = hrisId;
            hrisIntegration.u_sftp_URI = txtSftpServerUrl.Text;
            hrisIntegration.u_sftp_port = txtSftpServerPort.Text;
            hrisIntegration.u_sftp_username = txtUserName.Text;
            hrisIntegration.u_sftp_password = txtPassword.Value;
            hrisIntegration.u_sftp_hris_filename = txtHrisCsvFileName.Text;
            hrisIntegration.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {                
                hrisIntegration.u_sftp_time_every = txtHours.Text;
            }
            else
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                hours = hours + 12;
                hrisIntegration.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
            }                     
            hrisIntegration.u_sftp_start_date = txtBegining.Text;

            try
            {
                if (!string.IsNullOrEmpty(hrisId))
                {
                    hrisIntegration.u_sftp_id_pk = hrisId;
                    int updateresult = SystemBackgroundJobsBLL.UpdateHRIS(hrisIntegration);
                    if (updateresult == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Updated Successfully";
                    }
                }
                else
                {
                    int result = SystemHRISIntegrationBLL.CreateHRIS(hrisIntegration);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
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
        /// Get Excel Data
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
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
                }

            }
            dt.Rows.RemoveAt(0); //...so i'm taking it out here.

            return dt;
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
        /// <summary>
        /// Get the Cell Value of xl
        /// </summary>
        /// <param name="document"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
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
        /// Insert/Update to usermaster table
        /// </summary>
        /// <param name="dtHRIS"></param>
        private void InsertIntoUserMaster(DataTable dtHRIS)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtHRIS.Columns.Add("Status", typeof(String));
            dtHRIS.Columns.Add("ErrorResult", typeof(String));
            dtHRIS.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtHRIS.Rows.Count; i++)
            {
                User addnewuser = new User();

                addnewuser.Userid = Guid.NewGuid().ToString();
                /// <summary>
                /// Hash encryption for username and password
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                addnewuser.Password_enc_ash = encHash.GenerateHashvalue(dtHRIS.Rows[i]["u_password_clear"].ToString(), true);
                addnewuser.Username_enc_ash = encHash.GenerateHashvalue(dtHRIS.Rows[i]["u_username_clear"].ToString(), true);
                /// <summary>
                /// Salt encryption for password
                /// </summary>
                //RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
                //addnewuser.Password_enc_salt = dtHRIS.Rows[i]["u_password_enc_ash"].ToString();
                //End
                addnewuser.Firstname = dtHRIS.Rows[i]["u_first_name"].ToString();
                addnewuser.Middlename = dtHRIS.Rows[i]["u_middle_name"].ToString();
                addnewuser.Lastname = dtHRIS.Rows[i]["u_last_name"].ToString();
                addnewuser.EmailId = dtHRIS.Rows[i]["u_email_address"].ToString();
                addnewuser.Mobiletype = dtHRIS.Rows[i]["u_mobile_type_fk"].ToString();
                addnewuser.MobileCarrier = dtHRIS.Rows[i]["u_mobile_carrier_fk"].ToString();
                addnewuser.MobileNumber = dtHRIS.Rows[i]["u_mobile_number"].ToString();
                addnewuser.WorkPhone = dtHRIS.Rows[i]["u_work_phone"].ToString();
                addnewuser.Workextension = dtHRIS.Rows[i]["u_work_extension"].ToString();
                addnewuser.Address1 = dtHRIS.Rows[i]["u_address_1"].ToString();
                addnewuser.Address2 = dtHRIS.Rows[i]["u_address_2"].ToString();
                addnewuser.Address3 = dtHRIS.Rows[i]["u_address_3"].ToString();
                addnewuser.City = dtHRIS.Rows[i]["u_city"].ToString();
                addnewuser.StateProvince = dtHRIS.Rows[i]["u_state_province_ddl"].ToString();
                addnewuser.ZipPostalcode = dtHRIS.Rows[i]["u_zip_postal_code_ddl"].ToString();
                addnewuser.Country = dtHRIS.Rows[i]["u_country_id_fk"].ToString();
                addnewuser.DomainId = dtHRIS.Rows[i]["u_domain_id_fk"].ToString();
                addnewuser.LocaleId = dtHRIS.Rows[i]["u_locale_id_fk"].ToString();
                addnewuser.TimezoneId = dtHRIS.Rows[i]["u_timezone_fk"].ToString();
                addnewuser.Usertype = dtHRIS.Rows[i]["u_user_type_id_fk"].ToString();

                //user creation type
                addnewuser.creation_type = dtHRIS.Rows[i]["u_creation_type_fk"].ToString();
                //End
                addnewuser.Active_status_flag = dtHRIS.Rows[i]["u_active_status_flag"].ToString();
                addnewuser.Active_Type = dtHRIS.Rows[i]["u_active_type_fk"].ToString();
                addnewuser.Hris_employeid = dtHRIS.Rows[i]["u_hris_employee_id"].ToString();
                addnewuser.Hris_employee_type = dtHRIS.Rows[i]["u_hris_employee_type_fk"].ToString();


                DateTime? dtHireDate = null;
                DateTime tempHiretDate;

                if (DateTime.TryParseExact(dtHRIS.Rows[i]["u_hris_hire_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out tempHiretDate))
                {
                    dtHireDate = tempHiretDate;
                }

                addnewuser.Hris_hire_date = dtHireDate;
                //}

                DateTime? txtLastrehiredate = null;
                DateTime tempEndDate;

                if (DateTime.TryParseExact(dtHRIS.Rows[i]["u_hris_last_rehire_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
                {
                    txtLastrehiredate = tempEndDate;
                }

                addnewuser.Hris_last_rehire_date = txtLastrehiredate;

                addnewuser.Hris_company = dtHRIS.Rows[i]["u_hris_company_fk"].ToString();
                addnewuser.Hris_region = dtHRIS.Rows[i]["u_hris_region_fk"].ToString();
                addnewuser.Hris_division = dtHRIS.Rows[i]["u_hris_division_fk"].ToString();
                addnewuser.Hris_department = dtHRIS.Rows[i]["u_hris_department_fk"].ToString();
                addnewuser.Hris_cost_center = dtHRIS.Rows[i]["u_hris_cost_center_fk"].ToString();
                addnewuser.Hris_job_group = dtHRIS.Rows[i]["u_hris_job_group_fk"].ToString();
                addnewuser.Hris_job_code = dtHRIS.Rows[i]["u_hris_job_code_fk"].ToString();
                addnewuser.Hris_job_title = dtHRIS.Rows[i]["u_hris_job_title_fk"].ToString();
                addnewuser.Hris_job_position = dtHRIS.Rows[i]["u_hris_job_position_fk"].ToString();
                addnewuser.Hris_pay_grade = dtHRIS.Rows[i]["u_hris_pay_grade_fk"].ToString();
                //questions
                addnewuser.Hris_manager_id = dtHRIS.Rows[i]["u_hris_manager_id_fk"].ToString();
                addnewuser.Hris_supervisor_id = dtHRIS.Rows[i]["u_hris_supervisor_id_fk"].ToString();
                addnewuser.Hris_Alternate_manager_id = dtHRIS.Rows[i]["u_hris_alternate_manager_id_fk"].ToString();
                addnewuser.Hris_alternate_supervisor_id = dtHRIS.Rows[i]["u_hris_alternate_supervisor_id_fk"].ToString();
                addnewuser.Hris_mentor_id = dtHRIS.Rows[i]["u_hris_mentor_id_fk"].ToString();
                addnewuser.Alternate_mentor_id = dtHRIS.Rows[i]["u_hris_alternate_mentor_id_fk"].ToString();
                //End

                addnewuser.sr_is_employee = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_employee"]));
                addnewuser.sr_is_manager = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_manager"]));
                addnewuser.sr_is_compliance = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_compliance"]));
                addnewuser.sr_is_instructor = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_instructor"]));
                addnewuser.sr_is_training = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_training"]));
                addnewuser.sr_is_administrator = Convert.ToBoolean(Convert.ToInt16(dtHRIS.Rows[i]["u_sr_is_administrator"]));
                //addnewuser.sr_is_system_admin = Convert.ToBoolean(dtHRIS.Rows[i][""]);
                //addnewuser.sr_is_compliance_approver = Convert.ToBoolean(dtHRIS.Rows[i][""]);


                addnewuser.Custom_01 = dtHRIS.Rows[i]["u_custom_01"].ToString();
                addnewuser.Custom_02 = dtHRIS.Rows[i]["u_custom_02"].ToString();
                addnewuser.Custom_03 = dtHRIS.Rows[i]["u_custom_03"].ToString();
                addnewuser.Custom_04 = dtHRIS.Rows[i]["u_custom_04"].ToString();
                addnewuser.Custom_05 = dtHRIS.Rows[i]["u_custom_05"].ToString();
                addnewuser.Custom_06 = dtHRIS.Rows[i]["u_custom_06"].ToString();
                addnewuser.Custom_07 = dtHRIS.Rows[i]["u_custom_07"].ToString();
                addnewuser.Custom_08 = dtHRIS.Rows[i]["u_custom_08"].ToString();
                addnewuser.Custom_09 = dtHRIS.Rows[i]["u_custom_09"].ToString();
                addnewuser.Custom_10 = dtHRIS.Rows[i]["u_custom_10"].ToString();
                addnewuser.Custom_11 = dtHRIS.Rows[i]["u_custom_11"].ToString();
                addnewuser.Custom_12 = dtHRIS.Rows[i]["u_custom_12"].ToString();
                addnewuser.Custom_13 = dtHRIS.Rows[i]["u_custom_13"].ToString();

                try
                {
                    //Insert into usermaster table
                    start = DateTime.Now;
                    int result = SystemHRISIntegrationBLL.insert_update_user(addnewuser);
                    if (result == 0)
                    {
                        dtHRIS.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtHRIS.Rows[i]["Status"] = "Failed";
                            dtHRIS.Rows[i]["RecordCount"] = i + 1;
                            dtHRIS.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtHRIS.Rows[i]["Status"] = "Failed";
                            dtHRIS.Rows[i]["RecordCount"] = i + 1;
                            dtHRIS.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }

            }
            CreateLogFile(dtHRIS);

        }
        /// <summary>
        /// Create Log File
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateLogFile(DataTable dtHris)
        {
            var loadedrows = dtHris.Select("Status='Passed'");
            var rejectedRows = dtHris.Select("Status='Failed'");
            DateTime endDate;
            string _logpath = "~/SystemHome/Configuration/HRISIntegration/Log/";
            string filename = "CF_HRIS_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString().Substring(0, 5) + ".txt";
            filename = filename.Replace("/", "_");
            filename = filename.Replace(":", "_");
            string path = Server.MapPath(_logpath);
            string filePath = Path.Combine(path, filename);
            FileStream fs1 = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("************************************");
            sb.AppendLine("CF HRIS Upload Job: ");
            sb.AppendLine("************************************");
            sb.AppendLine();
            sb.AppendLine("Started on:" + start.ToShortDateString() + " at " + start.ToShortTimeString());
            endDate = DateTime.Now;
            sb.AppendLine("Ended on:" + endDate.ToShortDateString() + " at " + endDate.ToShortTimeString());
            sb.AppendLine();
            sb.AppendLine("Initiated Job: Passed");
            sb.AppendLine("Connected to SFTP: Passed");
            sb.AppendLine("Downloaded HRIS CSV File: Passed");
            sb.AppendLine();
            sb.AppendLine("Read (" + dtHris.Rows.Count + ")records");
            sb.AppendLine("Loaded (" + loadedrows.Length + ")records");
            sb.AppendLine("Rejected (" + rejectedRows.Length + ")records");
            sb.AppendLine();
            if (rejectedRows.Length > 0)
            {
                sb.AppendLine("************************************");
                sb.AppendLine("Rejected Records Details: ");
                sb.AppendLine("************************************");
                foreach (var r in rejectedRows)
                {
                    sb.AppendLine("Record #" + r["RecordCount"].ToString() + ":" + r["ErrorResult"].ToString());
                }
                sb.AppendLine();
            }
            sb.AppendLine("************************************");
            sb.AppendLine("End of Report");
            sb.AppendLine("************************************");

            writer.Write(sb.ToString());
            writer.Close();

            //Insert sftp_run_log table

            SystemHRISIntegration hrisRunlog = new SystemHRISIntegration();
            hrisRunlog.u_sftp_run_date_time_start = start.ToString();
            hrisRunlog.u_sftp_run_date_time_end = endDate.ToString();
            if (rejectedRows.Length > 0)
            {
                hrisRunlog.u_sftp_run_result = "Errors";
            }
            else
            {
                hrisRunlog.u_sftp_run_result = "Success";
            }
            hrisRunlog.u_sftp_run_log_file_transfer = "Success";
            hrisRunlog.u_sftp_run_errors_details_filename = filename;
            string errorLog = sb.ToString();
            errorLog = errorLog.Replace("\r\n", "<br/>");
            hrisRunlog.u_sftp_run_errors_log = errorLog;
            hrisRunlog.u_sftp_run_records_processes = dtHris.Rows.Count;
            hrisRunlog.u_sftp_run_records_loaded = loadedrows.Length;
            hrisRunlog.u_sftp_run_records_rejected = rejectedRows.Length;

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
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message);
                    }
                }
            }
        } 
    }
}