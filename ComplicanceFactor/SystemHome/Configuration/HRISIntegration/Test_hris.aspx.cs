using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.IO;
using System.Net;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using System.Text;
using ComplicanceFactor.BusinessComponent;
using System.Text.RegularExpressions;

namespace ComplicanceFactor.SystemHome.Configuration.HRIS_Integration
{
    public partial class Test_hris : System.Web.UI.Page
    {
        private string _attachmentpath = "~/SystemHome/Configuration/HRISIntegration/Uploaded/";
        private DateTime start;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            //Check the time and date
            //pass the current time to sftp table and get the records of HRIS

            string dtTime = String.Format("{0:HH:mm}", DateTime.Now);
            dtTime = "21:50";
            DateTime dtCurrentTime =   DateTime.Now;
            string date = dtCurrentTime.ToShortDateString();          

            SystemHRISIntegration getDetails = new SystemHRISIntegration();
            try
            {
                getDetails = SystemHRISIntegrationBLL.GetHRISDetailsForBackground(dtTime, date);
                if (!string.IsNullOrEmpty(getDetails.u_sftp_URI))
                {
                    DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + getDetails.u_sftp_hris_filename + ".xlsx"), "HRIS");
                    InsertIntoUserMaster(dtHRIS, getDetails.u_sftp_URI,getDetails.u_sftp_username,getDetails.u_sftp_password);
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
        /// Insert/Update to usermaster table
        /// </summary>
        /// <param name="dtHRIS"></param>
        private void InsertIntoUserMaster(DataTable dtHRIS,string sftp_URI,string userName,string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtHRIS.Columns.Add("Status", typeof(String));
            dtHRIS.Columns.Add("ErrorResult", typeof(String));
            dtHRIS.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtHRIS.Rows.Count; i++)
            {
                User addnewuser = new User();

                try
                {
                    addnewuser.Userid = Guid.NewGuid().ToString();
                    /// <summary>
                    /// Hash encryption for username and password
                    /// </summary>
                    /// 
                    if (string.IsNullOrEmpty(dtHRIS.Rows[i]["u_username_clear"].ToString()) || string.IsNullOrEmpty(dtHRIS.Rows[i]["u_password_clear"].ToString()) || string.IsNullOrEmpty(dtHRIS.Rows[i]["u_last_name"].ToString()) || string.IsNullOrEmpty(dtHRIS.Rows[i]["u_first_name"].ToString()))
                    {                         
                        throw new System.ArgumentException("Required Field not present");
                    }

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
            CreateLogFile(dtHRIS, sftp_URI, userName,password);

        }
        /// <summary>
        /// Create Log File
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateLogFile(DataTable dtHris,string uri,string userName,string password)
        {
            var loadedrows = dtHris.Select("Status='Passed'");
            var rejectedRows = dtHris.Select("Status='Failed'");
            DateTime endDate;
            //string _logpath = "~/SystemHome/Configuration/HRIS Integration/Log/";
            string filename = "CF_HRIS_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString().Substring(0, 5) + ".txt";
            filename = filename.Replace("/", "_");
            filename = filename.Replace(":", "_");
            //string path = Server.MapPath(_logpath);
            string filePath = @"C:\Users\Windows\Downloads\" + filename;
            FileStream fs1 = new FileStream(@"C:\Users\Windows\Downloads\" + filename, FileMode.OpenOrCreate, FileAccess.Write);
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
            sb.AppendLine("Read (" + dtHris.Rows.Count + ") records");
            sb.AppendLine("Loaded (" + loadedrows.Length + ") records");
            sb.AppendLine("Rejected (" + rejectedRows.Length + ") records");
            sb.AppendLine();
            if (rejectedRows.Length > 0)
            {
                sb.AppendLine("************************************");
                sb.AppendLine("Rejected Records Details: ");
                sb.AppendLine("************************************");
                sb.AppendLine();
                foreach (var r in rejectedRows)
                {
                    sb.AppendLine("Record #" + r["RecordCount"].ToString() + ": " + r["ErrorResult"].ToString());
                }
                sb.AppendLine();
            }
            sb.AppendLine("************************************");
            sb.AppendLine("End of Report");
            sb.AppendLine("************************************");

            writer.Write(sb.ToString());
            writer.Close();

            CreateLogFileInFTP(filename, uri, userName, password, sb.ToString(), filePath);//filePath           

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
        /// <summary>
        /// Create Log File In FTP Server
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="uri"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="text"></param>
        private void CreateLogFileInFTP(string filename, string uri, string userName, string password, string text,string path)
        {
            FileInfo toUpload = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();

            //string path = @"D:\Staff\GuruPraveen\Web Project\WorkingCopy2\ComplianceFactors_GitHub\ComplianceFactors.Website\ComplicanceFactor\SystemHome\Configuration\HRIS Integration\Log\CF_HRIS_SFTP_Job_Run_6_29_2013_11_11.txt";

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
        /// Get File From FTP
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool GetFileFromFTP(string hostName, string port, string userName, string password, string filename)
        {
            bool result = false;
            string localPath = @"E:\";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(hostName);
            request.Credentials = new NetworkCredential(userName, password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());
            request = null;

            string fileName = streamReader.ReadLine();

            if (fileName != null)
            {

                FtpWebRequest requestFileDownload = null;
                FtpWebResponse responseFileDownload = null;

                try
                {
                    requestFileDownload = (FtpWebRequest)WebRequest.Create(hostName);
                    requestFileDownload.Credentials = new NetworkCredential(userName, password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                    responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(localPath + fileName, FileMode.Create);

                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }

                    writeStream.Close();
                    result = true;
                    return result;
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
                    return result = false;
                }
            }
            return result;
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
    }
}