using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Caching;
using System.Net.Mail;
using System.Configuration;

namespace ComplicanceFactor
{
    public class Global : System.Web.HttpApplication
    {
        private DateTime start;
        public static string APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/HRISIntegration/Uploaded/");
        public static string APP_PATH_DIMP = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/Data Imports/Upload/");
        public static string TEMP_PATH_DEXP = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/TempExport_CSV/");
        public static string TEMP_APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/HRISIntegration/TempLogFiles/");
        public static string TEMP_DIMP_APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/Data Imports/TempLogFiles/");
        public static string TEMP_DEXP_APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/TempLogFiles/");

        public static string LOGGER_APP_PATH = HttpContext.Current.Server.MapPath("~/Logs/");
        public static string ERROR_LOG_FILE_PATH = LOGGER_APP_PATH + "ErrorLog.txt";
        public static string NEW_LINE = "\r\n";
        private const string DummyCacheItemKey = "Background";
       // private static readonly string DummyPageUrl = "http://compliancefactors.com.lavender.arvixe.com/SystemHome/sahp-01.aspx"; //"~/Default2.aspx";
        private static readonly string DummyPageUrl = HttpContext.Current.Server.MapPath("~/SystemHome/sahp-01.aspx");
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        protected void Application_Start(object sender, EventArgs e)
        {
            BackgroundProcess();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.ToString() == DummyPageUrl)
            {
               BackgroundProcess();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // look if any security information exists for this request
            if (HttpContext.Current.User != null)
            {
                // see if this user is authenticated, any authenticated cookie (ticket) exists for this user
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // see if the authentication is done using FormsAuthentication
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        // Get the roles stored for this request from the ticket
                        // get the identity of the user
                        FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                        // get the forms authetication ticket of the user
                        FormsAuthenticationTicket ticket = identity.Ticket;
                        // get the roles stored as UserData into the ticket 
                        string[] roles = ticket.UserData.Split(',');
                        // create generic principal and assign it to the current request
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                    }
                }
            }
        }

        private void BackgroundProcess()
        {
            // Prevent duplicate key addition
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Background", null, DateTime.MaxValue,
                TimeSpan.FromMinutes(1), CacheItemPriority.NotRemovable,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            //TODO: Set Stored Procedure.
            string dtTime = String.Format("{0:HH:mm}", DateTime.Now);
            //dtTime = "11:50";
            DateTime dtCurrentTime = DateTime.Now;
            string date = dtCurrentTime.ToShortDateString();

            SystemHRISIntegration getDetails = new SystemHRISIntegration();
            try
            {
                string u_sftp_URI = string.Empty;
                string u_sftp_username = string.Empty;
                string u_sftp_password = string.Empty;

                DataTable dtDataBackground = new DataTable();
                dtDataBackground = SystemBackgroundJobsBLL.GetBackgroundInformation(dtTime, date);
                if (dtDataBackground.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDataBackground.Rows.Count; i++)
                    {
                        string u_sftp_id_pk = dtDataBackground.Rows[i]["u_sftp_id_pk"].ToString();

                        if (!string.IsNullOrEmpty(u_sftp_id_pk))
                        {
                            if (u_sftp_id_pk.Contains("HRIS"))
                            {
                                //if (string.IsNullOrEmpty(dtDataBackground.Rows[i]["NeedToRun"].ToString()))
                                //{
                                u_sftp_URI = dtDataBackground.Rows[i]["u_sftp_URI"].ToString();
                                u_sftp_username = dtDataBackground.Rows[i]["u_sftp_username"].ToString();
                                u_sftp_password = dtDataBackground.Rows[i]["u_sftp_password"].ToString();
                                //Do Hris background process
                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_hris_filename"].ToString()))
                                {
                                    string hrisPath = APP_PATH + dtDataBackground.Rows[i]["u_sftp_hris_filename"].ToString(); //getDetails.u_sftp_hris_filename; //Hard coded(extension),need to change any time.
                                    if (File.Exists(hrisPath))
                                    {
                                        DataTable dtHRIS = GetCSVData(hrisPath);
                                        if (dtHRIS.Rows.Count > 0)
                                        {
                                            //BackgroundJobs.InsertIntoUserMaster(dtHRIS, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            InsertIntoUserMaster(dtHRIS, u_sftp_URI, u_sftp_username, u_sftp_password);

                                            //Insert Groups user from Assignment Groups
                                            SystemAssingnmentGroup group = new SystemAssingnmentGroup();
                                            group.u_assignment_group_id_pk = string.Empty;
                                            group.u_assignment_group_name = string.Empty;

                                            group.u_assignment_group_status_id_fk = "0";

                                            DataTable dtAssignmentGroup = SystemAssignmentGroupBLL.GetSearchAssignmentGroup(group);

                                            for (int j = 0; j < dtAssignmentGroup.Rows.Count; j++)
                                            {
                                                //Pass the group Id for populate the group users
                                                InsertGroupUser(dtAssignmentGroup.Rows[j]["u_assignment_group_system_id_pk"].ToString());
                                            }                                           

                                            //Audience.
                                            SystemAudiences audience = new SystemAudiences();
                                            audience.u_audience_id_pk = string.Empty;
                                            audience.u_audience_name = string.Empty;
                                            audience.u_audience_status_id_fk = "0";
                                            DataTable dtAudience = SystemAudiencesBLL.GetSearchAudience(audience);

                                            for (int k = 0; k < dtAudience.Rows.Count; k++)
                                            {
                                                InsertAudienceUser(dtAudience.Rows[k]["u_audience_system_id_pk"].ToString());
                                            }

                                            //Assign the course and curriculum from assignment groups.
                                            SystemAssignmentRules rule = new SystemAssignmentRules();
                                            rule.u_assignment_rules_id_pk = string.Empty;
                                            rule.u_assignment_rules_name = string.Empty;
                                            rule.u_assignment_rules_status_id_fk = "0";
                                            DataTable dtAssignmentRule = SystemAssignmentRuleBLL.SearchAssignmentRule(rule);

                                            for (int l = 0; l < dtAssignmentRule.Rows.Count; l++)
                                            {
                                                AssignCourseCurriculum(dtAssignmentRule.Rows[l]["u_assignment_rules_system_id_pk"].ToString());
                                            }
                                        }
                                    }
                                }
                                //}
                            }
                            else if (u_sftp_id_pk.Contains("DIMP"))
                            {
                                //if (string.IsNullOrEmpty(dtDataBackground.Rows[i]["NeedToRun"].ToString()))
                                //{
                                u_sftp_URI = dtDataBackground.Rows[i]["u_sftp_URI"].ToString();
                                u_sftp_username = dtDataBackground.Rows[i]["u_sftp_username"].ToString();
                                u_sftp_password = dtDataBackground.Rows[i]["u_sftp_password"].ToString();

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_facility_filename"].ToString()))
                                {
                                    //do Data Import Hris Background Process
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_facility_filename"].ToString()))
                                    {
                                        DataTable dtFacility = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_facility_filename"].ToString());
                                        if (dtFacility.Rows.Count > 0)
                                        {
                                            //Insert/Update Facility 
                                            //BackgroundJobs.InsertIntoFacility(dtFacility, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            InsertIntoFacility(dtFacility, u_sftp_URI, u_sftp_username, u_sftp_password);
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_room_filename"].ToString()))
                                {
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_room_filename"].ToString()))
                                    {
                                        DataTable dtRoom = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_room_filename"].ToString());
                                        if (dtRoom.Rows.Count > 0)
                                        {
                                            //BackgroundJobs.InsertIntoRoom(dtRoom, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            InsertIntoRoom(dtRoom, u_sftp_URI, u_sftp_username, u_sftp_password);
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_course_filename"].ToString()))
                                {
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_course_filename"].ToString()))
                                    {
                                        DataTable dtCourse = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_course_filename"].ToString());
                                        if (dtCourse.Rows.Count > 0)
                                        {
                                            //Insert/Update Course 
                                            //BackgroundJobs.InsertIntoCourse(dtCourse, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            InsertIntoCourse(dtCourse, u_sftp_URI, u_sftp_username, u_sftp_password);
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_base_curricula_filename"].ToString()))
                                {
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_base_curricula_filename"].ToString()))
                                    {
                                        DataTable dtCurrriculum = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_base_curricula_filename"].ToString());
                                        if (dtCurrriculum.Rows.Count > 0)
                                        {
                                            //Insert/Update Curriculum 
                                            //BackgroundJobs.InsertIntoCurriculum(dtCurrriculum, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            InsertIntoCurriculum(dtCurrriculum, u_sftp_URI, u_sftp_username, u_sftp_password);
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_enrollment_filename"].ToString()))
                                {
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_enrollment_filename"].ToString()))
                                    {
                                        if (Convert.ToBoolean(dtDataBackground.Rows[i]["u_sftp_imp_is_enrollment"]) == true)
                                        {
                                            DataTable dtEnrollment = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_enrollment_filename"].ToString());
                                            if (dtEnrollment.Rows.Count > 0)
                                            {
                                                //Insert/Update Enrollment 
                                                //BackgroundJobs.InsertIntoEnrollment(dtEnrollment, u_sftp_URI, u_sftp_username, u_sftp_password);
                                                InsertIntoEnrollment(dtEnrollment, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            }
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(dtDataBackground.Rows[i]["u_sftp_imp_learning_history_filename"].ToString()))
                                {
                                    if (File.Exists(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_learning_history_filename"].ToString()))
                                    {
                                        if (Convert.ToBoolean(dtDataBackground.Rows[i]["u_sftp_imp_is_learning_history"]) == true)
                                        {
                                            DataTable dtLearningHistory = GetCSVData(APP_PATH_DIMP + dtDataBackground.Rows[i]["u_sftp_imp_learning_history_filename"].ToString());
                                            if (dtLearningHistory.Rows.Count > 0)
                                            {
                                                //Insert/Update Learning History 
                                                //BackgroundJobs.InsertIntoLearningHistory(dtLearningHistory, u_sftp_URI, u_sftp_username, u_sftp_password);
                                                InsertIntoLearningHistory(dtLearningHistory, u_sftp_URI, u_sftp_username, u_sftp_password);
                                            }
                                        }
                                    }
                                }
                                //}
                            }
                            else if (u_sftp_id_pk.Contains("DEXP"))
                            {
                                u_sftp_URI = dtDataBackground.Rows[i]["u_sftp_URI"].ToString();
                                u_sftp_username = dtDataBackground.Rows[i]["u_sftp_username"].ToString();
                                u_sftp_password = dtDataBackground.Rows[i]["u_sftp_password"].ToString();

                                if (Convert.ToBoolean(dtDataBackground.Rows[i]["u_sftp_exp_is_catalog_offering"]) == true)
                                {
                                    DataTable dtFacilities = new DataTable();
                                    dtFacilities = SystemDataExportBLL.GetFacilities();
                                    //DateTime facilitiyStartDate = DateTime.Now;
                                    GetDatatableToCsv(dtFacilities, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Facilities.csv");
                                    CreateLogFile(dtFacilities, u_sftp_URI, u_sftp_username, u_sftp_password, "Facility", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtFacilities, u_sftp_URI, u_sftp_username, u_sftp_password, "Facility", "DEXP");

                                    DataTable dtCourses = new DataTable();
                                    dtCourses = SystemDataExportBLL.GetCourses();
                                    //string CourseStartDate = DateTime.Now.ToString();
                                    GetDatatableToCsv(dtCourses, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Courses.csv");
                                    CreateLogFile(dtCourses, u_sftp_URI, u_sftp_username, u_sftp_password, "Courses", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtCourses, u_sftp_URI, u_sftp_username, u_sftp_password, "Courses", "DEXP");

                                    DataTable dtCurriculum = new DataTable();
                                    dtCurriculum = SystemDataExportBLL.GetCurriculum();
                                    //string CurriculumStartDate = DateTime.Now.ToString();
                                    GetDatatableToCsv(dtCurriculum, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Curriculum.csv");
                                    CreateLogFile(dtCurriculum, u_sftp_URI, u_sftp_username, u_sftp_password, "Curriculum", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtCurriculum, u_sftp_URI, u_sftp_username, u_sftp_password, "Curriculum", "DEXP");

                                    DataTable dtRooms = new DataTable();
                                    dtRooms = SystemDataExportBLL.GetRooms();
                                    //string roomStartDate = DateTime.Now.ToString();
                                    GetDatatableToCsv(dtRooms, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Rooms.csv");
                                    CreateLogFile(dtRooms, u_sftp_URI, u_sftp_username, u_sftp_password, "Rooms", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtRooms, u_sftp_URI, u_sftp_username, u_sftp_password, "Rooms", "DEXP");
                                }

                                DataTable dtEnrollments = new DataTable();
                                dtEnrollments = SystemDataExportBLL.GetEnrollments();
                                //string EnrollmentStartDate = DateTime.Now.ToString();
                                GetDatatableToCsv(dtEnrollments, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Enrollment.csv");
                                CreateLogFile(dtEnrollments, u_sftp_URI, u_sftp_username, u_sftp_password, "Enrollment", "DEXP");
                                //BackgroundJobs.CreateLogFile(dtEnrollments, u_sftp_URI, u_sftp_username, u_sftp_password, "Enrollment", "DEXP");

                                if (Convert.ToBoolean(dtDataBackground.Rows[i]["u_sftp_exp_is_learning_history"]) == true)
                                {
                                    DataTable dtLearningHistory = new DataTable();
                                    dtLearningHistory = SystemDataExportBLL.GetLearningHisory();
                                    //string LearningHistoryStartDate = DateTime.Now.ToString();
                                    GetDatatableToCsv(dtLearningHistory, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Learning_History.csv");
                                    CreateLogFile(dtLearningHistory, u_sftp_URI, u_sftp_username, u_sftp_password, "Learning_History", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtLearningHistory, u_sftp_URI, u_sftp_username, u_sftp_password, "Learning_History", "DEXP");
                                }

                                if (Convert.ToBoolean(dtDataBackground.Rows[i]["u_sftp_exp_is_hris"]) == true)
                                {
                                    DataTable dtHris = new DataTable();
                                    dtHris = SystemDataExportBLL.GetHris();
                                    //string hrisStartDate = DateTime.Now.ToString();
                                    GetDatatableToCsv(dtHris, TEMP_PATH_DEXP, u_sftp_URI, u_sftp_username, u_sftp_password, "Hris.csv");
                                    CreateLogFile(dtHris, u_sftp_URI, u_sftp_username, u_sftp_password, "Hris", "DEXP");
                                    //BackgroundJobs.CreateLogFile(dtHris, u_sftp_URI, u_sftp_username, u_sftp_password, "Hris", "DEXP");
                                }
                            }
                            //Daily Curriculum Update Background Job 
                            else if (u_sftp_id_pk.Contains("DCUB"))
                            {
                                DateTime starttime = DateTime.Now;
                                DataSet dsCurriculum = new DataSet();
                                dsCurriculum = SystemBackgroundJobsBLL.GetWarningOverDue();
                                //To use for loops 

                                DataTable dtWarning = dsCurriculum.Tables[0];
                                if (dtWarning.Rows.Count > 0)
                                {
                                    //BackgroundJobs.SendWarnigNotification(dtWarning);
                                    SendWarnigNotification(dtWarning);
                                }

                                DataTable dtOverDue = dsCurriculum.Tables[1];

                                if (dtOverDue.Rows.Count > 0)
                                {
                                    //BackgroundJobs.SendOverdueNotification(dtOverDue);
                                    SendOverdueNotification(dtOverDue);
                                }

                                DataTable dtCourseWarning = dsCurriculum.Tables[2];
                                if (dtWarning.Rows.Count > 0)
                                {
                                    //BackgroundJobs.SendWarnigNotification(dtCourseWarning);
                                    SendWarnigNotification(dtCourseWarning);
                                }
                                DataTable dtCourseOverDue = dsCurriculum.Tables[3];
                                if (dtOverDue.Rows.Count > 0)
                                {
                                    //BackgroundJobs.SendOverdueNotification(dtCourseOverDue);
                                    SendOverdueNotification(dtCourseOverDue);
                                }
                                // Have to insert in Run log 
                                InsertRunLogDetails(starttime, "DCUB");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    LogErrorMessage(ex.Message);
                }
            }
            // We need to register another cache item which will expire again in one
            // minute. However, as this callback occurs without any HttpContext, we do not
            // have access to HttpContext and thus cannot access the Cache object. The
            // only way we can access HttpContext is when a request is being processed which
            // means a webpage is hit. So, we need to simulate a web page hit and then 
            // add the cache item.
            HitPage();
        }

        private void HitPage()
        {
            WebClient client = new WebClient();
            //WebProxy proxyObject = new WebProxy("http://localhost:2663", true);
            //client.Proxy = proxyObject;
            //var url = new Uri(Request.Url, DummyPageUrl).AbsoluteUri;
            //client.DownloadData(VirtualPathUtility.ToAbsolute(url));
            client.DownloadData(DummyPageUrl);
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                if (Session["u_userid"] != null && (string)Session["u_userid"] != string.Empty)
                {
                    Sessioninfo sessioninfo = new Sessioninfo();

                    sessioninfo.sessionguid = Session["sessionguid"].ToString();
                    SessioninfoBLL.InsertSessionEndTime(sessioninfo);

                    User userinfo = new User();
                    userinfo.u_is_active = false;
                    userinfo.Userid = Session["u_userid"].ToString();
                    UserBLL.UpdateLock(userinfo);
                    Session.Abandon();
                }
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

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public void LogErrorMessage(string errorMessage)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(ERROR_LOG_FILE_PATH, true);
            writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " : " + "Global.asax : " + errorMessage.ToString() + NEW_LINE);
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;
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

        /// <summary>
        /// Convert DataTable to CSV
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        private void GetDatatableToCsv(DataTable dt, string path, string sftp_uri, string userName, string password, string fileName)
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

            FileInfo file = new System.IO.FileInfo(path + fileName);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path + fileName, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;

            System.Threading.Thread.Sleep(8000);

            CreateCSVFile(sftp_uri, userName, password, path, fileName);

        }

        /// <summary>
        /// Create Log File For HRIS
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateCSVFile(string uri, string userName, string password, string path, string filename)
        {

            FileInfo toUpload = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();

            FileStream file = File.OpenRead(path + filename);

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




        public static void SendWarnigNotification(DataTable dtWarning)
        {
            SystemNotification notification = new SystemNotification();
            notification = SystemNotificationBLL.GetSingleNotificationbyId("CURR-DUE-DATE-WARNING", "en-US");
            if (notification.s_notification_on_off_flag == true)
            {
                for (int j = 0; j < dtWarning.Rows.Count; j++)
                {
                    try
                    {
                        StringBuilder sbEnrolledReminder = new StringBuilder();

                        string reminderSubjectMananger = string.Empty;
                        reminderSubjectMananger = notification.s_notification_email_subject;
                        reminderSubjectMananger = reminderSubjectMananger.Replace("@$&Curriculum Title&$@", dtWarning.Rows[j]["CurriculumName"].ToString());
                        reminderSubjectMananger = reminderSubjectMananger.Replace("@$&User First Name&$@", dtWarning.Rows[j]["u_first_name"].ToString());

                        string EnrollTextManager = string.Empty;
                        EnrollTextManager = notification.s_notification_email_text;
                        EnrollTextManager = EnrollTextManager.Replace("@$&User First Name&$@", dtWarning.Rows[j]["u_first_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&User Last Name&$@", dtWarning.Rows[j]["u_last_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Curriculum Name&$@(@$&Curriculum ID&$@)", dtWarning.Rows[j]["CurriculumName"].ToString());
                        //EnrollTextManager = EnrollTextManager.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", dtWarning.Rows[j]["deliveryName"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Target Due Date&$@", dtWarning.Rows[j]["e_curriculum_assign_target_due_date"].ToString());
                        //e_enroll_target_due_date
                        sbEnrolledReminder.Append(EnrollTextManager);

                        string toEmailid = dtWarning.Rows[j]["u_email_address"].ToString();
                        string[] toaddress = toEmailid.Split(',');
                        List<MailAddress> mailAddresses = new List<MailAddress>();
                        foreach (string recipient in toaddress)
                        {
                            if (recipient.Trim() != string.Empty)
                            {
                                mailAddresses.Add(new MailAddress(recipient));
                            }
                        }

                        string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                        //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                        if (mailAddresses.Count > 0)
                        {
                            Utility.SendEMailMessages(mailAddresses, fromAddress, reminderSubjectMananger, sbEnrolledReminder.ToString());
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtWarning.Rows[j]["u_mobile_number"].ToString()))
                            {
                                StringBuilder smsText = new StringBuilder();
                                string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                string username = HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                string passwd = HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                string messagetext = notification.s_notification_SMS_text;
                                //messagetext = messagetext.Replace("", "");
                                //messagetext = messagetext.Replace("", "");
                                if (messagetext.Length > 180)
                                {
                                    messagetext = messagetext.Substring(0, 179);
                                }
                                messagetext = messagetext.Replace("@$&Status&$@", "REMIND");
                                messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", dtWarning.Rows[j]["CurriculumName"].ToString());
                                Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                            }
                        }
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
            }
        }
        /// <summary>
        /// Send Overdue Notificication
        /// </summary>
        /// <param name="dtOverDue"></param>
        public static void SendOverdueNotification(DataTable dtOverDue)
        {
            //dtEnrolledWarning = SystemBackgroundJobsBLL.GetEnrollWarning("ENROLL-DUE-DATE-WARNING");
            SystemNotification notificationOverDue = new SystemNotification();
            notificationOverDue = SystemNotificationBLL.GetSingleNotificationbyId("CURR-EXPIRED", "en-US");
            if (notificationOverDue.s_notification_on_off_flag == true)
            {
                for (int j = 0; j < dtOverDue.Rows.Count; j++)
                {
                    try
                    {
                        StringBuilder sbEnrolledWarning = new StringBuilder();

                        string warningrSubjectMananger = string.Empty;
                        warningrSubjectMananger = notificationOverDue.s_notification_email_subject;
                        warningrSubjectMananger = warningrSubjectMananger.Replace("@$&Curriculum Title&$@", dtOverDue.Rows[j]["CurriculumName"].ToString());
                        warningrSubjectMananger = warningrSubjectMananger.Replace("@$&User First Name&$@", dtOverDue.Rows[j]["u_first_name"].ToString());

                        string EnrollTextManager = string.Empty;
                        EnrollTextManager = notificationOverDue.s_notification_email_text;
                        EnrollTextManager = EnrollTextManager.Replace("@$&User First Name&$@", dtOverDue.Rows[j]["u_first_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&User Last Name&$@", dtOverDue.Rows[j]["u_last_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Curriculum Name&$@(@$&Curriculum ID&$@)", dtOverDue.Rows[j]["CurriculumName"].ToString());
                        //EnrollTextManager = EnrollTextManager.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", dtOverDue.Rows[j]["deliveryName"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Target Due Date&$@", dtOverDue.Rows[j]["e_curriculum_assign_target_due_date"].ToString());
                        //e_enroll_target_due_date
                        sbEnrolledWarning.Append(EnrollTextManager);

                        string toEmailid = dtOverDue.Rows[j]["u_email_address"].ToString();
                        string[] toaddress = toEmailid.Split(',');
                        List<MailAddress> mailAddresses = new List<MailAddress>();
                        foreach (string recipient in toaddress)
                        {
                            if (recipient.Trim() != string.Empty)
                            {
                                mailAddresses.Add(new MailAddress(recipient));
                            }
                        }

                        string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                        //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                        if (mailAddresses.Count > 0)
                        {
                            Utility.SendEMailMessages(mailAddresses, fromAddress, warningrSubjectMananger, sbEnrolledWarning.ToString());
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtOverDue.Rows[j]["u_mobile_number"].ToString()))
                            {
                                StringBuilder smsText = new StringBuilder();
                                string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                string username = HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                string passwd = HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                string messagetext = notificationOverDue.s_notification_SMS_text;
                                //messagetext = messagetext.Replace("", "");
                                //messagetext = messagetext.Replace("", "");
                                if (messagetext.Length > 180)
                                {
                                    messagetext = messagetext.Substring(0, 179);
                                }
                                messagetext = messagetext.Replace("@$&Status&$@", "OverDue");
                                messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", dtOverDue.Rows[j]["courseName"].ToString());
                                Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                            }
                        }
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
            }
        }

        // Insert Into user master table: HRIS

        private void InsertIntoUserMaster(DataTable dtHRIS, string sftp_URI, string userName, string password)
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
                    RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
                    addnewuser.Password_enc_salt = rijndaelKey.Encrypt(dtHRIS.Rows[i]["u_password_clear"].ToString());
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
            //Create Log File 
            CreateLogFile(dtHRIS, sftp_URI, userName, password, "HRIS", "HRIS");
        }

        /// <summary>
        /// Create Log File For HRIS
        /// </summary>
        /// <param name="dtHris"></param>
        public static void CreateLogFile(DataTable dtHris, string uri, string userName, string password, string processName, string runlogType)
        {
            DateTime startTime = DateTime.Now;
            string filePath = string.Empty;
            string filename = string.Empty;
            DateTime endDate;
            //string _logpath = "~/SystemHome/Configuration/HRIS Integration/Log/";
            FileStream fs1;
            //HRIS
            if (runlogType == "HRIS")
            {
                filename = "CF_HRIS_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToString("HH:mm:ss") + ".txt";
                filename = filename.Replace("/", "_");
                filename = filename.Replace(":", "_");
                filePath = TEMP_APP_PATH + filename.TrimEnd();
                fs1 = new FileStream(TEMP_APP_PATH + filename.TrimEnd(), FileMode.OpenOrCreate, FileAccess.Write);
            }
            else if (runlogType == "DIMP")
            {
                filename = "CF_Data_Import_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToString("HH:mm:ss") + ".txt";
                filename = filename.Replace("/", "_");
                filename = filename.Replace(":", "_");
                filePath = TEMP_DIMP_APP_PATH + filename.TrimEnd();
                fs1 = new FileStream(TEMP_DIMP_APP_PATH + filename.TrimEnd(), FileMode.OpenOrCreate, FileAccess.Write);
            }
            else
            {
                filename = "CF_Data_Export_SFTP_Job_Run_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToString("HH:mm:ss") + ".txt";
                filename = filename.Replace("/", "_");
                filename = filename.Replace(":", "_");
                filePath = TEMP_DEXP_APP_PATH + filename.TrimEnd();
                fs1 = new FileStream(TEMP_DEXP_APP_PATH + filename.TrimEnd(), FileMode.OpenOrCreate, FileAccess.Write);
            }
            StreamWriter writer = new StreamWriter(fs1);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("************************************");
            if (runlogType == "HRIS")
            {
                sb.AppendLine("CF HRIS Upload Job: ");
            }
            else if (runlogType == "DIMP")
            {
                sb.AppendLine("CF Data Import Upload Job: ");
            }
            else
            {
                sb.AppendLine("CF Data Export Upload Job: ");
            }
            sb.AppendLine("************************************");
            sb.AppendLine();
            sb.AppendLine("Started on:" + startTime.ToShortDateString() + " at " + startTime.ToShortTimeString());
            endDate = DateTime.Now;
            sb.AppendLine("Ended on:" + endDate.ToShortDateString() + " at " + endDate.ToShortTimeString());
            sb.AppendLine();
            sb.AppendLine("Initiated Job: Passed");
            sb.AppendLine("Connected to SFTP: Passed");
            sb.AppendLine("Downloaded " + processName + " CSV File: Passed");
            sb.AppendLine();
            if (runlogType != "DEXP")
            {
                var loadedrows = dtHris.Select("Status='Passed'");
                var rejectedRows = dtHris.Select("Status='Failed'");
                sb.AppendLine("Read (" + dtHris.Rows.Count + ") records");
                sb.AppendLine("Loaded (" + loadedrows.Length + ") records");
                sb.AppendLine("Rejected (" + rejectedRows.Length + ") records");
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
            }
            else
            {
                sb.AppendLine("Loaded (" + dtHris.Rows.Count + ") records");
            }
            sb.AppendLine();

            sb.AppendLine("************************************");
            sb.AppendLine("End of Report");
            sb.AppendLine("************************************");

            writer.Write(sb.ToString());
            writer.Close();

            //Create Log File In FTP

            System.Threading.Thread.Sleep(8000);

            bool ftpResult = CreateLogFileInFTP(filename, uri, userName, password, sb.ToString(), filePath);//filePath           

            //Insert sftp_run_log table

            SystemHRISIntegration hrisRunlog = new SystemHRISIntegration();
            hrisRunlog.u_sftp_run_date_time_start = startTime.ToString();
            hrisRunlog.u_sftp_run_date_time_end = endDate.ToString();
            if (runlogType != "DEXP")
            {
                var loadedrows = dtHris.Select("Status='Passed'");
                var rejectedRows = dtHris.Select("Status='Failed'");
                hrisRunlog.u_sftp_run_records_loaded = loadedrows.Length;
                hrisRunlog.u_sftp_run_records_rejected = rejectedRows.Length;
                if (rejectedRows.Length > 0)
                {
                    hrisRunlog.u_sftp_run_result = "Errors";
                }
                else
                {
                    hrisRunlog.u_sftp_run_result = "Success";
                }
            }
            else
            {
                hrisRunlog.u_sftp_run_result = "Success";
                hrisRunlog.u_sftp_run_records_loaded = dtHris.Rows.Count;
                hrisRunlog.u_sftp_run_records_rejected = 0;
            }
            hrisRunlog.u_sftp_run_log_file_transfer = "Success";
            hrisRunlog.u_sftp_run_errors_details_filename = filename;
            string errorLog = sb.ToString();
            if (ftpResult == true)
            {
                errorLog = errorLog.Replace("\r\n", "<br/>");
            }
            else
            {
                errorLog = "The process was completed but the log file was not uploaded to FTP Server<br/> Bacause it failed to connect the FTP Server <br/> Please specify the correct username and password";
            }
            hrisRunlog.u_sftp_run_errors_log = errorLog;
            hrisRunlog.u_sftp_run_records_processes = dtHris.Rows.Count;
            hrisRunlog.u_sftp_run_log_type = runlogType;

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


        /// <summary>
        /// Create Log File In FTP Server
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="uri"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="text"></param>
        public static bool CreateLogFileInFTP(string filename, string uri, string userName, string password, string text, string path)
        {
            bool IsExists = true;
            try
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
            catch (Exception)
            {
                IsExists = false;
            }
            return IsExists;
        }


        /////Data Import
        //////////

        /// <summary>
        /// Insert Facility ( Data Import )
        /// </summary>
        /// <param name="dtFacility"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoFacility(DataTable dtFacility, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtFacility.Columns.Add("Status", typeof(String));
            dtFacility.Columns.Add("ErrorResult", typeof(String));
            dtFacility.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtFacility.Rows.Count; i++)
            {
                SystemFacility createFacility = new SystemFacility();
                try
                {
                    if (string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_id_pk"].ToString()) || string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_name"].ToString()) || string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_desc"].ToString()) || string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_status_id_fk"].ToString()) || string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_type_id_fk"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }
                    //createFacility.s_facility_system_id_pk = dtFacility.Rows[i]["s_facility_system_id_pk"].ToString();
                    createFacility.s_facility_id_pk = dtFacility.Rows[i]["c_facility_id_pk"].ToString();
                    createFacility.s_facility_name = dtFacility.Rows[i]["c_facility_name"].ToString();
                    createFacility.s_facility_desc = dtFacility.Rows[i]["c_facility_desc"].ToString();
                    createFacility.s_facility_status_id_fk = dtFacility.Rows[i]["c_facility_status_id_fk"].ToString();
                    createFacility.s_facility_type_id_fk = dtFacility.Rows[i]["c_facility_type_id_fk"].ToString();
                    createFacility.s_facility_contact = dtFacility.Rows[i]["c_facility_contact"].ToString();
                    createFacility.s_facility_email_address = dtFacility.Rows[i]["c_facility_email_address"].ToString();
                    createFacility.s_facility_phone = dtFacility.Rows[i]["c_facility_phone"].ToString();
                    createFacility.s_facility_address = dtFacility.Rows[i]["c_facility_address"].ToString();
                    createFacility.s_facility_address1 = dtFacility.Rows[i]["c_facility_address1"].ToString();
                    createFacility.s_facility_address2 = dtFacility.Rows[i]["c_facility_address2"].ToString();
                    createFacility.s_facility_city = dtFacility.Rows[i]["c_facility_city"].ToString();
                    createFacility.s_facility_state = dtFacility.Rows[i]["c_facility_state"].ToString();
                    createFacility.s_facility_zip_code = dtFacility.Rows[i]["c_facility_zip_code"].ToString();
                    if (!string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_country_id_fk"].ToString()))
                    {
                        createFacility.s_facility_country_id_fk = Convert.ToInt16(dtFacility.Rows[i]["c_facility_country_id_fk"]);
                    }
                    else
                    {
                        createFacility.s_facility_country_id_fk = 0;
                    }
                    createFacility.s_facility_locale_id_fk = dtFacility.Rows[i]["c_facility_locale_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtFacility.Rows[i]["c_facility_time_zone_id_fk"].ToString()))
                    {
                        createFacility.s_facility_time_zone_id_fk = Convert.ToInt16(dtFacility.Rows[i]["c_facility_time_zone_id_fk"]);
                    }
                    else
                    {
                        createFacility.s_facility_time_zone_id_fk = 0;
                    }
                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.CreateNewFacility(createFacility);
                    if (result == 0)
                    {
                        dtFacility.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtFacility.Rows[i]["Status"] = "Failed";
                            dtFacility.Rows[i]["RecordCount"] = i + 1;
                            dtFacility.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtFacility.Rows[i]["Status"] = "Failed";
                            dtFacility.Rows[i]["RecordCount"] = i + 1;
                            dtFacility.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
                CreateLogFile(dtFacility, sftp_URI, userName, password, "Facility", "DIMP");
                //Create Log File For Facility
            }
        }
        /// <summary>
        /// Insert Room ( Data Import )
        /// </summary>
        /// <param name="dtRoom"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoRoom(DataTable dtRoom, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtRoom.Columns.Add("Status", typeof(String));
            dtRoom.Columns.Add("ErrorResult", typeof(String));
            dtRoom.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtRoom.Rows.Count; i++)
            {
                SystemRoom createRoom = new SystemRoom();
                try
                {
                    if (string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_id_pk"].ToString()) || string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_name"].ToString()) || string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_desc"].ToString())
                         || string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_status_id_fk"].ToString()) || string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_type_id_fk"].ToString()) || string.IsNullOrEmpty(dtRoom.Rows[i]["c_room_facility_id_fk"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }
                    //createRoom.s_room_system_id_pk = dtRoom.Rows[i]["s_room_system_id_pk"].ToString();
                    createRoom.s_room_id_pk = dtRoom.Rows[i]["c_room_id_pk"].ToString();
                    createRoom.s_room_name = dtRoom.Rows[i]["c_room_name"].ToString();
                    createRoom.s_room_desc = dtRoom.Rows[i]["c_room_desc"].ToString();
                    createRoom.s_room_status_id_fk = dtRoom.Rows[i]["c_room_status_id_fk"].ToString();
                    createRoom.s_room_type_id_fk = dtRoom.Rows[i]["c_room_type_id_fk"].ToString();
                    createRoom.s_room_facility_id_fk = dtRoom.Rows[i]["c_room_facility_id_fk"].ToString();

                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.CreateNewRoom(createRoom);
                    if (result == 0)
                    {
                        dtRoom.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtRoom.Rows[i]["Status"] = "Failed";
                            dtRoom.Rows[i]["RecordCount"] = i + 1;
                            dtRoom.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtRoom.Rows[i]["Status"] = "Failed";
                            dtRoom.Rows[i]["RecordCount"] = i + 1;
                            dtRoom.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
            }
            //Create Log File For Room   
            CreateLogFile(dtRoom, sftp_URI, userName, password, "Room", "DIMP");
        }

        /// <summary>
        /// Insert Course ( Data Import )
        /// </summary>
        /// <param name="dtCourse"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoCourse(DataTable dtCourse, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtCourse.Columns.Add("Status", typeof(String));
            dtCourse.Columns.Add("ErrorResult", typeof(String));
            dtCourse.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtCourse.Rows.Count; i++)
            {
                SystemCatalog CreateCourse = new SystemCatalog();
                try
                {
                    if (string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_id_pk"].ToString()) || string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_title"].ToString()) || string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_desc"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }

                    CreateCourse.c_course_id_pk = dtCourse.Rows[i]["c_course_id_pk"].ToString();
                    CreateCourse.c_course_title = dtCourse.Rows[i]["c_course_title"].ToString();
                    CreateCourse.c_course_desc = dtCourse.Rows[i]["c_course_desc"].ToString();
                    CreateCourse.c_course_abstract = dtCourse.Rows[i]["c_course_abstract"].ToString();
                    CreateCourse.c_course_version = dtCourse.Rows[i]["c_course_version"].ToString();
                    CreateCourse.c_course_owner_id_fk = dtCourse.Rows[i]["c_course_owner_id_fk"].ToString();
                    CreateCourse.c_course_coordinator_id_fk = dtCourse.Rows[i]["c_course_coordinator_id_fk"].ToString();
                    int tempCost;
                    if (int.TryParse(dtCourse.Rows[i]["c_course_cost"].ToString(), out tempCost))
                    {
                        CreateCourse.c_course_cost = tempCost;
                    }
                    else
                    {
                        CreateCourse.c_course_cost = null;
                    }

                    int tempCreditUnits;
                    if (int.TryParse(dtCourse.Rows[i]["c_course_credit_units"].ToString(), out tempCreditUnits))
                    {
                        CreateCourse.c_course_credit_units = tempCreditUnits;
                    }
                    else
                    {
                        CreateCourse.c_course_credit_units = null;
                    }
                    int tempCreditHours;
                    if (int.TryParse(dtCourse.Rows[i]["c_course_credit_hours"].ToString(), out tempCreditHours))
                    {
                        CreateCourse.c_course_credit_hours = tempCreditHours;
                    }
                    else
                    {
                        CreateCourse.c_course_credit_hours = null;
                    }
                    CreateCourse.c_course_icon_uri = dtCourse.Rows[i]["c_course_icon_uri"].ToString();

                    //CreateCourse.c_course_icon_uri_file_name = dtCourse.Rows[i]["c_course_icon_uri_file_name"].ToString();
                    //CreateCourse.c_course_active_type_id_fk = dtCourse.Rows[i]["c_course_active_type_id_fk"].ToString();

                    if (!string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_visible_flag"].ToString()))
                    {
                        CreateCourse.c_course_visible_flag = Convert.ToBoolean(dtCourse.Rows[i]["c_course_visible_flag"]);
                    }
                    else
                    {
                        CreateCourse.c_course_visible_flag = false;
                    }
                    if (!string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_approval_req"].ToString()))
                    {
                        CreateCourse.c_course_approval_req = Convert.ToBoolean(dtCourse.Rows[i]["c_course_approval_req"]);
                    }
                    else
                    {
                        CreateCourse.c_course_approval_req = false;
                    }
                    CreateCourse.c_course_approval_id_fk = dtCourse.Rows[i]["c_course_approval_id_fk"].ToString();

                    //recurrance
                    int tempEvery;
                    if (int.TryParse(dtCourse.Rows[i]["c_course_recurrence_every"].ToString(), out tempEvery))
                    {
                        CreateCourse.c_course_recurrence_every = tempEvery;
                    }
                    else
                    {
                        CreateCourse.c_course_recurrence_every = null;
                    }
                    CreateCourse.c_course_recurrence_period = dtCourse.Rows[i]["c_course_recurrence_period"].ToString();
                    CreateCourse.c_course_recurrence_date_option = dtCourse.Rows[i]["c_course_recurrence_date_option"].ToString();
                    DateTime? recurancedate = null;
                    DateTime temprecurancedate;
                    if (DateTime.TryParseExact(dtCourse.Rows[i]["c_course_recurrence_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                    {
                        recurancedate = temprecurancedate;
                    }
                    CreateCourse.c_course_recurrence_date = recurancedate;
                    CreateCourse.c_course_custom_01 = dtCourse.Rows[i]["c_course_custom_01"].ToString();
                    CreateCourse.c_course_custom_02 = dtCourse.Rows[i]["c_course_custom_02"].ToString();
                    CreateCourse.c_course_custom_03 = dtCourse.Rows[i]["c_course_custom_03"].ToString();
                    CreateCourse.c_course_custom_04 = dtCourse.Rows[i]["c_course_custom_04"].ToString();
                    CreateCourse.c_course_custom_05 = dtCourse.Rows[i]["c_course_custom_05"].ToString();
                    CreateCourse.c_course_custom_06 = dtCourse.Rows[i]["c_course_custom_06"].ToString();
                    CreateCourse.c_course_custom_07 = dtCourse.Rows[i]["c_course_custom_07"].ToString();
                    CreateCourse.c_course_custom_08 = dtCourse.Rows[i]["c_course_custom_08"].ToString();
                    CreateCourse.c_course_custom_09 = dtCourse.Rows[i]["c_course_custom_09"].ToString();
                    CreateCourse.c_course_custom_10 = dtCourse.Rows[i]["c_course_custom_10"].ToString();
                    CreateCourse.c_course_custom_11 = dtCourse.Rows[i]["c_course_custom_11"].ToString();
                    CreateCourse.c_course_custom_12 = dtCourse.Rows[i]["c_course_custom_12"].ToString();
                    CreateCourse.c_course_custom_13 = dtCourse.Rows[i]["c_course_custom_13"].ToString();

                    //c_course_cert_flag
                    //if (!string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_cert_date"].ToString()))
                    //{
                    //   CreateCourse.c_course_cert_date = Convert.ToDateTime(dtCourse.Rows[i]["c_course_cert_date"]);
                    //}

                    CreateCourse.c_course_cert_flag = false;

                    //c_course_recurrence_grace_days
                    int tempGraceDays;
                    if (int.TryParse(dtCourse.Rows[i]["c_course_recurrence_grace_days"].ToString(), out tempGraceDays))
                    {
                        CreateCourse.c_course_recurrence_grace_days = tempGraceDays;
                    }
                    else
                    {
                        CreateCourse.c_course_recurrence_grace_days = null;
                    }

                    if (!string.IsNullOrEmpty(dtCourse.Rows[i]["c_course_active_flag"].ToString()))
                    {
                        CreateCourse.c_course_active_flag = Convert.ToBoolean(dtCourse.Rows[i]["c_course_active_flag"]);
                    }
                    else
                    {
                        CreateCourse.c_course_active_flag = false;
                    }

                    //CreateCourse.c_course_created_by_id_fk = dtCourse.Rows[i]["c_course_created_by_id_fk"].ToString();  

                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.CreateCourse(CreateCourse);
                    if (result == 0)
                    {
                        dtCourse.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtCourse.Rows[i]["Status"] = "Failed";
                            dtCourse.Rows[i]["RecordCount"] = i + 1;
                            dtCourse.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtCourse.Rows[i]["Status"] = "Failed";
                            dtCourse.Rows[i]["RecordCount"] = i + 1;
                            dtCourse.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
            }
            CreateLogFile(dtCourse, sftp_URI, userName, password, "Course", "DIMP");
        }

        /// <summary>
        /// Insert Curriculum ( Data Import )Insert Learning History ( Data Import )
        /// </summary>
        /// <param name="dtCurriculum"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoCurriculum(DataTable dtCurriculum, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtCurriculum.Columns.Add("Status", typeof(String));
            dtCurriculum.Columns.Add("ErrorResult", typeof(String));
            dtCurriculum.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtCurriculum.Rows.Count; i++)
            {
                SystemCurriculum CreateCurriculum = new SystemCurriculum();
                try
                {
                    if (string.IsNullOrEmpty(dtCurriculum.Rows[i]["c_curriculum_id_pk"].ToString()) || string.IsNullOrEmpty(dtCurriculum.Rows[i]["c_curriculum_title"].ToString()) || string.IsNullOrEmpty(dtCurriculum.Rows[i]["c_curriculum_desc"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }

                    //CreateCurriculum.c_curriculum_system_id_pk = dtCurriculum.Rows[i]["c_curriculum_system_id_pk"].ToString();
                    CreateCurriculum.c_curriculum_id_pk = dtCurriculum.Rows[i]["c_curriculum_id_pk"].ToString();
                    CreateCurriculum.c_curriculum_title = dtCurriculum.Rows[i]["c_curriculum_title"].ToString();
                    CreateCurriculum.c_curriculum_desc = dtCurriculum.Rows[i]["c_curriculum_desc"].ToString();
                    CreateCurriculum.c_curriculum_abstract = dtCurriculum.Rows[i]["c_curriculum_abstract"].ToString();
                    CreateCurriculum.c_curriculum_version = dtCurriculum.Rows[i]["c_curriculum_version"].ToString();
                    CreateCurriculum.c_curriculum_owner_id_fk = dtCurriculum.Rows[i]["c_curriculum_owner_id_fk"].ToString();
                    CreateCurriculum.c_curriculum_coordinator_id_fk = dtCurriculum.Rows[i]["c_curriculum_coordinator_id_fk"].ToString();
                    //int tempCost;
                    //if (int.TryParse(dtCurriculum.Rows[i]["c_curriculum_cost"].ToString(), out tempCost))
                    //{
                    //    CreateCurriculum.c_curriculum_cost = tempCost;
                    //}
                    //else
                    //{
                    //    CreateCurriculum.c_curriculum_cost = null;
                    //}

                    int tempCreditUnits;
                    if (int.TryParse(dtCurriculum.Rows[i]["c_curriculum_credit_units"].ToString(), out tempCreditUnits))
                    {
                        CreateCurriculum.c_curriculum_credit_units = tempCreditUnits;
                    }
                    else
                    {
                        CreateCurriculum.c_curriculum_credit_units = null;
                    }
                    int tempCreditHours;
                    if (int.TryParse(dtCurriculum.Rows[i]["c_curriculum_credit_hours"].ToString(), out tempCreditHours))
                    {
                        CreateCurriculum.c_curriculum_credit_hours = tempCreditHours;
                    }
                    else
                    {
                        CreateCurriculum.c_curriculum_credit_hours = null;
                    }
                    CreateCurriculum.c_curriculum_icon_uri = dtCurriculum.Rows[i]["c_curriculum_icon_uri"].ToString();
                    //CreateCurriculum.c_curriculum_icon_uri_file_name = dtCurriculum.Rows[i]["c_curriculum_icon_uri_file_name"].ToString();
                    //CreateCurriculum.c_curriculum_active_type_id_fk = dtCurriculum.Rows[i]["c_curriculum_active_type_id_fk"].ToString();
                    CreateCurriculum.c_curriculum_visible_flag = Convert.ToBoolean(dtCurriculum.Rows[i]["c_curriculum_visible_flag"]);
                    CreateCurriculum.c_curriculum_approval_req = Convert.ToBoolean(dtCurriculum.Rows[i]["c_curriculum_approval_req"]);
                    CreateCurriculum.c_curriculum_approval_id_fk = dtCurriculum.Rows[i]["c_curriculum_approval_id_fk"].ToString();
                    //recurrance
                    int tempEvery;
                    if (int.TryParse(dtCurriculum.Rows[i]["c_curriculum_recurrance_every"].ToString(), out tempEvery))
                    {
                        CreateCurriculum.c_curriculum_recurrance_every = tempEvery;
                    }
                    else
                    {
                        CreateCurriculum.c_curriculum_recurrance_every = null;
                    }
                    CreateCurriculum.c_curriculum_recurrance_period = dtCurriculum.Rows[i]["c_curriculum_recurrance_period"].ToString();
                    CreateCurriculum.c_curriculum_recurance_date_option = dtCurriculum.Rows[i]["c_curriculum_recurance_date_option"].ToString();
                    DateTime? recurancedate = null;
                    DateTime temprecurancedate;

                    if (DateTime.TryParseExact(dtCurriculum.Rows[i]["c_curriculum_recurance_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                    {
                        recurancedate = temprecurancedate;
                    }
                    CreateCurriculum.c_curriculum_recurance_date = recurancedate;
                    //custom section
                    CreateCurriculum.c_curriculum_custom_01 = dtCurriculum.Rows[i]["c_curriculum_custom_01"].ToString();
                    CreateCurriculum.c_curriculum_custom_02 = dtCurriculum.Rows[i]["c_curriculum_custom_02"].ToString();
                    CreateCurriculum.c_curriculum_custom_03 = dtCurriculum.Rows[i]["c_curriculum_custom_03"].ToString();
                    CreateCurriculum.c_curriculum_custom_04 = dtCurriculum.Rows[i]["c_curriculum_custom_04"].ToString();
                    CreateCurriculum.c_curriculum_custom_05 = dtCurriculum.Rows[i]["c_curriculum_custom_05"].ToString();
                    CreateCurriculum.c_curriculum_custom_06 = dtCurriculum.Rows[i]["c_curriculum_custom_06"].ToString();
                    CreateCurriculum.c_curriculum_custom_07 = dtCurriculum.Rows[i]["c_curriculum_custom_07"].ToString();
                    CreateCurriculum.c_curriculum_custom_08 = dtCurriculum.Rows[i]["c_curriculum_custom_08"].ToString();
                    CreateCurriculum.c_curriculum_custom_09 = dtCurriculum.Rows[i]["c_curriculum_custom_09"].ToString();
                    CreateCurriculum.c_curriculum_custom_10 = dtCurriculum.Rows[i]["c_curriculum_custom_10"].ToString();
                    CreateCurriculum.c_curriculum_custom_11 = dtCurriculum.Rows[i]["c_curriculum_custom_11"].ToString();
                    CreateCurriculum.c_curriculum_custom_12 = dtCurriculum.Rows[i]["c_curriculum_custom_12"].ToString();
                    CreateCurriculum.c_curriculum_custom_13 = dtCurriculum.Rows[i]["c_curriculum_custom_13"].ToString();
                    //c_curriculum_cert_flag
                    //CreateCurriculum.c_curriculum_cert_date = Convert.ToDateTime(dtCurriculum.Rows[i][""]);
                    CreateCurriculum.c_curriculum_cert_flag = false;
                    //c_curriculum_recurrance_grace_days
                    int tempGraceDays;
                    if (int.TryParse(dtCurriculum.Rows[i]["c_curriculum_recurrance_grace_days"].ToString(), out tempGraceDays))
                    {
                        CreateCurriculum.c_curriculum_recurrance_grace_days = tempGraceDays;
                    }
                    else
                    {
                        CreateCurriculum.c_curriculum_recurrance_grace_days = null;
                    }

                    CreateCurriculum.c_curriculum_active_flag = Convert.ToBoolean(dtCurriculum.Rows[i]["c_curriculum_active_flag"]);

                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.CreateCurriculum(CreateCurriculum);
                    if (result == 0)
                    {
                        dtCurriculum.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtCurriculum.Rows[i]["Status"] = "Failed";
                            dtCurriculum.Rows[i]["RecordCount"] = i + 1;
                            dtCurriculum.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtCurriculum.Rows[i]["Status"] = "Failed";
                            dtCurriculum.Rows[i]["RecordCount"] = i + 1;
                            dtCurriculum.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
            }

            CreateLogFile(dtCurriculum, sftp_URI, userName, password, "Curriculum", "DIMP");
        }

        /// <summary>
        /// Insert Enrollment ( Data Import )
        /// </summary>
        /// <param name="dtEnrollment"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoEnrollment(DataTable dtEnrollment, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtEnrollment.Columns.Add("Status", typeof(String));
            dtEnrollment.Columns.Add("ErrorResult", typeof(String));
            dtEnrollment.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtEnrollment.Rows.Count; i++)
            {
                Enrollment enroll = new Enrollment();
                try
                {
                    if (string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_user_id_fk"].ToString()) || string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_course_id_fk"].ToString()) || string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_delivery_id_fk"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }

                    enroll.e_enroll_user_id_fk = dtEnrollment.Rows[i]["e_enroll_user_id_fk"].ToString();
                    enroll.e_enroll_course_id_fk = dtEnrollment.Rows[i]["e_enroll_course_id_fk"].ToString();
                    enroll.e_enroll_delivery_id_fk = dtEnrollment.Rows[i]["e_enroll_delivery_id_fk"].ToString();

                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_enroll_date_time"].ToString()))
                    {
                        enroll.e_enroll_enroll_date_time_background = Convert.ToDateTime(dtEnrollment.Rows[i]["e_enroll_enroll_date_time"]);
                    }
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_expire_date"].ToString()))
                    {
                        enroll.e_enroll_expire_date_background = Convert.ToDateTime(dtEnrollment.Rows[i]["e_enroll_expire_date"]);
                    }
                    enroll.e_enroll_enroll_type_id_fk = dtEnrollment.Rows[i]["e_enroll_enroll_type_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_required_flag"].ToString()))
                    {
                        enroll.e_enroll_required_flag = Convert.ToBoolean(dtEnrollment.Rows[i]["e_enroll_required_flag"]);
                    }
                    else
                    {
                        enroll.e_enroll_required_flag = false;
                    }
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_approval_required_flag"].ToString()))
                    {
                        enroll.e_enroll_approval_required_flag = Convert.ToBoolean(dtEnrollment.Rows[i]["e_enroll_approval_required_flag"]);
                    }
                    else
                    {
                        enroll.e_enroll_approval_required_flag = false;
                    }
                    enroll.e_enroll_approval_status_id_fk = dtEnrollment.Rows[i]["e_enroll_approval_status_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_approval_date"].ToString()))
                    {
                        enroll.e_enroll_approval_date_background = Convert.ToDateTime(dtEnrollment.Rows[i]["e_enroll_approval_date"]);
                    }
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_target_due_date"].ToString()))
                    {
                        enroll.e_enroll_target_due_date = Convert.ToDateTime(dtEnrollment.Rows[i]["e_enroll_target_due_date"]);
                    }
                    enroll.e_enroll_status_id_fk = dtEnrollment.Rows[i]["e_enroll_status_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_time_spent"].ToString()))
                    {
                        enroll.e_enroll_time_spent = Convert.ToInt16(dtEnrollment.Rows[i]["e_enroll_time_spent"]);
                    }
                    else
                    {
                        enroll.e_enroll_time_spent = 0;
                    }
                    enroll.e_enroll_lesson_location = dtEnrollment.Rows[i]["e_enroll_lesson_location"].ToString();
                    enroll.e_enroll_suspend_data = dtEnrollment.Rows[i]["e_enroll_suspend_data"].ToString();
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_score"].ToString()))
                    {
                        enroll.e_enroll_score = Convert.ToInt16(dtEnrollment.Rows[i]["e_enroll_score"]);
                    }
                    if (!string.IsNullOrEmpty(dtEnrollment.Rows[i]["e_enroll_active_flag"].ToString()))
                    {
                        enroll.e_enroll_active_flag = Convert.ToBoolean(dtEnrollment.Rows[i]["e_enroll_active_flag"]);
                    }
                    else
                    {
                        enroll.e_enroll_active_flag = false;
                    }
                    //enroll.e_enroll_lesson_status=dtEnrollment.Rows[i][""].ToString();
                    //enroll.e_enroll_completion_date=dtEnrollment.Rows[i][""].ToString();
                    //enroll.e_transcript_id_fk = dtEnrollment.Rows[i][""].ToString();                 

                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.InsertUpdateEnrollment(enroll);
                    if (result == 0)
                    {
                        dtEnrollment.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtEnrollment.Rows[i]["Status"] = "Failed";
                            dtEnrollment.Rows[i]["RecordCount"] = i + 1;
                            dtEnrollment.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtEnrollment.Rows[i]["Status"] = "Failed";
                            dtEnrollment.Rows[i]["RecordCount"] = i + 1;
                            dtEnrollment.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
            }
            CreateLogFile(dtEnrollment, sftp_URI, userName, password, "Enrollment", "DIMP");
        }

        /// <summary>
        /// Insert Learning History ( Data Import )
        /// </summary>
        /// <param name="dtLearningHistory"></param>
        /// <param name="sftp_URI"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void InsertIntoLearningHistory(DataTable dtLearningHistory, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtLearningHistory.Columns.Add("Status", typeof(String));
            dtLearningHistory.Columns.Add("ErrorResult", typeof(String));
            dtLearningHistory.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtLearningHistory.Rows.Count; i++)
            {
                SystemTranscripts transcripts = new SystemTranscripts();
                try
                {
                    if (string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_user_id_fk"].ToString()) || string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_course_id_fk"].ToString()) || string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_delivery_id_fk"].ToString()))
                    {
                        throw new System.ArgumentException("Required Field not present");
                    }

                    transcripts.t_transcript_user_id_fk = dtLearningHistory.Rows[i]["t_transcript_user_id_fk"].ToString();
                    transcripts.t_transcript_course_id_fk = dtLearningHistory.Rows[i]["t_transcript_course_id_fk"].ToString();
                    transcripts.t_transcript_delivery_id_fk = dtLearningHistory.Rows[i]["t_transcript_delivery_id_fk"].ToString();
                    transcripts.t_transcript_assign_id_fk = dtLearningHistory.Rows[i]["t_transcript_assign_id_fk"].ToString();
                    transcripts.t_transcript_enroll_id_fk = dtLearningHistory.Rows[i]["t_transcript_enroll_id_fk"].ToString();

                    transcripts.t_transcript_attendance_id_fk = dtLearningHistory.Rows[i]["t_transcript_attendance_id_fk"].ToString();
                    transcripts.t_transcript_passing_status_id_fk = dtLearningHistory.Rows[i]["t_transcript_passing_status_id_fk"].ToString();
                    transcripts.t_transcript_grade_id_fk = dtLearningHistory.Rows[i]["t_transcript_grade_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_completion_score"].ToString()))
                    {
                        transcripts.t_transcript_completion_score = Convert.ToInt32(dtLearningHistory.Rows[i]["t_transcript_completion_score"].ToString());
                    }
                    else
                    {
                        transcripts.t_transcript_completion_score = 0;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_completion_date_time"].ToString()))
                    {
                        transcripts.t_transcript_completion_date_time = Convert.ToDateTime(dtLearningHistory.Rows[i]["t_transcript_completion_date_time"]);
                    }
                    transcripts.t_transcript_completion_type_id_fk = dtLearningHistory.Rows[i]["t_transcript_completion_type_id_fk"].ToString();
                    transcripts.t_transcript_marked_by_user_id_fk = dtLearningHistory.Rows[i]["t_transcript_marked_by_user_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_required_flag"].ToString()))
                    {
                        transcripts.t_transcript_required_flag = Convert.ToBoolean(dtLearningHistory.Rows[i]["t_transcript_required_flag"]);
                    }
                    else
                    {
                        transcripts.t_transcript_required_flag = false;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_target_due_date"].ToString()))
                    {
                        transcripts.t_transcript_target_due_date_background = Convert.ToDateTime(dtLearningHistory.Rows[i]["t_transcript_target_due_date"]);//Target date
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_actual_date"].ToString()))
                    {
                        transcripts.t_transcript_actual_date_background = Convert.ToDateTime(dtLearningHistory.Rows[i]["t_transcript_actual_date"]); //Actual date 
                    }
                    transcripts.t_transcript_status_id_fk = dtLearningHistory.Rows[i]["t_transcript_status_id_fk"].ToString();//doubt //enroll.e_enroll_status_id_fk;
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_time_spent"].ToString()))
                    {
                        transcripts.t_transcript_time_spent = Convert.ToInt16(dtLearningHistory.Rows[i]["t_transcript_time_spent"]);
                    }
                    else
                    {
                        transcripts.t_transcript_time_spent = 0;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_score"].ToString()))
                    {
                        transcripts.t_transcript_score = Convert.ToInt16(dtLearningHistory.Rows[i]["t_transcript_score"]);
                    }
                    else
                    {
                        transcripts.t_transcript_score = 0;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_credits"].ToString()))
                    {
                        transcripts.t_transcript_credits = Convert.ToInt16(dtLearningHistory.Rows[i]["t_transcript_credits"]);
                    }
                    else
                    {
                        transcripts.t_transcript_credits = 0;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_hours"].ToString()))
                    {
                        transcripts.t_transcript_hours = Convert.ToInt16(dtLearningHistory.Rows[i]["t_transcript_hours"]);
                    }
                    else
                    {
                        transcripts.t_transcript_hours = 0;
                    }
                    if (!string.IsNullOrEmpty(dtLearningHistory.Rows[i]["t_transcript_active_flag"].ToString()))
                    {
                        transcripts.t_transcript_active_flag = Convert.ToBoolean(dtLearningHistory.Rows[i]["t_transcript_active_flag"]);
                    }
                    else
                    {
                        transcripts.t_transcript_active_flag = false;
                    }

                    start = DateTime.Now;
                    int result = SystemBackgroundJobsBLL.InsertUpdateTranscripts(transcripts);
                    if (result == 0)
                    {
                        dtLearningHistory.Rows[i]["Status"] = "Passed";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            dtLearningHistory.Rows[i]["Status"] = "Failed";
                            dtLearningHistory.Rows[i]["RecordCount"] = i + 1;
                            dtLearningHistory.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                        else
                        {
                            dtLearningHistory.Rows[i]["Status"] = "Failed";
                            dtLearningHistory.Rows[i]["RecordCount"] = i + 1;
                            dtLearningHistory.Rows[i]["ErrorResult"] = ex.Message;
                            continue;
                        }
                    }
                }
            }
            CreateLogFile(dtLearningHistory, sftp_URI, userName, password, "Learning History", "DIMP");
        }


        // Insert Run log Details for Update Curriculum status

        /// <summary>
        /// Inser Run Log Details
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="runlogType"></param>
        private void InsertRunLogDetails(DateTime starttime, string runlogType)
        {
            StringBuilder sb = new StringBuilder();
            DateTime endDate;
            sb.AppendLine("************************************");
            sb.AppendLine("CF Curriculum Update Background Job: ");
            sb.AppendLine("************************************");
            sb.AppendLine();
            sb.AppendLine("Started on:" + starttime.ToShortDateString() + " at " + starttime.ToShortTimeString());
            endDate = DateTime.Now;
            sb.AppendLine("Ended on:" + endDate.ToShortDateString() + " at " + endDate.ToShortTimeString());
            sb.AppendLine();
            sb.AppendLine("Initiated Job: Passed");
            //sb.AppendLine("Connected to SFTP: Passed");
            //sb.AppendLine("Downloaded " + processName + " CSV File: Passed");
            sb.AppendLine();
            sb.AppendLine("Daily Curriculum Update Background Job was execcuted successfully");
            sb.AppendLine();

            sb.AppendLine("************************************");
            sb.AppendLine("End of Report");
            sb.AppendLine("************************************");


            SystemHRISIntegration hrisRunlog = new SystemHRISIntegration();
            hrisRunlog.u_sftp_run_date_time_start = starttime.ToShortDateString();
            hrisRunlog.u_sftp_run_date_time_end = endDate.ToShortDateString();
            hrisRunlog.u_sftp_run_result = "Success";
            hrisRunlog.u_sftp_run_records_loaded = 0;
            hrisRunlog.u_sftp_run_records_rejected = 0;
            hrisRunlog.u_sftp_run_log_file_transfer = "Success";
            hrisRunlog.u_sftp_run_errors_details_filename = string.Empty;
            string errorLog = sb.ToString();
            errorLog = errorLog.Replace("\r\n", "<br/>");
            hrisRunlog.u_sftp_run_errors_log = errorLog;
            hrisRunlog.u_sftp_run_records_processes = 0;
            hrisRunlog.u_sftp_run_log_type = runlogType;

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

        /// <summary>
        /// Assign Course and Curriculum 
        /// </summary>
        private void AssignCourseCurriculum(string editassignmentRuleId)
        {
            SystemAssignmentRules rule = new SystemAssignmentRules();

            rule = SystemAssignmentRuleBLL.GetAssignmentRule(editassignmentRuleId);

            string assign_user_id_pk = UserBLL.GetSystemUser("SystemUser");

            DataTable dtCatalogItems = new DataTable();
            DataTable dtGroupUsers = new DataTable();

            DataTable dtCourse = TempDataTables.TempCourseAssignDatatable();
            DataTable dtCurriculum = TempDataTables.TempCurriculumDatatable();

            dtCatalogItems = SystemAssignmentRuleBLL.GetCatalogItems(editassignmentRuleId);
            dtGroupUsers = SystemAssignmentRuleBLL.GetUsersAssignmentGroups(editassignmentRuleId);

            if (dtCatalogItems.Rows.Count > 0)
            {
                for (int i = 0; i < dtCatalogItems.Rows.Count; i++)
                {
                    for (int j = 0; j < dtGroupUsers.Rows.Count; j++)
                    {
                        if (dtCatalogItems.Rows[i]["type"].ToString() == "Course")
                        {
                            DataRow courserow;
                            courserow = dtCourse.NewRow();
                            courserow["course_id"] = dtCatalogItems.Rows[i]["u_assignment_rule_item_id_fk"].ToString();
                            courserow["checked"] = rule.u_assignment_rules_required_flag;
                            courserow["employeeID"] = dtGroupUsers.Rows[j]["u_assignment_group_user_id_fk"].ToString();
                            courserow["required"] = rule.u_assignment_rules_required_flag;
                            if (!string.IsNullOrEmpty(rule.u_assignment_rules_fix_date_param.ToString()))
                            {
                                courserow["DueDate"] = rule.u_assignment_rules_fix_date_param;
                            }
                            dtCourse.Rows.Add(courserow);
                        }
                        else if (dtCatalogItems.Rows[i]["type"].ToString() == "Curriculum")
                        {
                            DataRow curriculumrow;
                            curriculumrow = dtCurriculum.NewRow();
                            curriculumrow["curriculum_id"] = dtCatalogItems.Rows[i]["u_assignment_rule_curriculum_item_id_fk"].ToString();
                            curriculumrow["employeeID"] = dtGroupUsers.Rows[j]["u_assignment_group_user_id_fk"].ToString();
                            curriculumrow["required"] = rule.u_assignment_rules_required_flag;
                            if (!string.IsNullOrEmpty(rule.u_assignment_rules_fix_date_param.ToString()))
                            {
                                curriculumrow["DueDate"] = rule.u_assignment_rules_fix_date_param;
                            }
                            dtCurriculum.Rows.Add(curriculumrow);
                        }
                    }
                }
                ConvertDataTables ConvertToXml = new ConvertDataTables();
                DataTable dtSingleOLTCourseFromCurriculum = SystemAssignmentRuleBLL.CourseCurriculumAssign(ConvertToXml.ConvertDataTableToXml(dtCourse), ConvertToXml.ConvertDataTableToXml(dtCurriculum), assign_user_id_pk, editassignmentRuleId);
            }
        }
        private void InsertGroupUser(string assignmentGroupId)
        {
            DataTable dtUser = SystemAssignmentGroupBLL.GetAssignmentRuleUser(assignmentGroupId,"us_english");
            ConvertDataTables ConvertXml = new ConvertDataTables();
            if (dtUser.Rows.Count > 0)
            {
                int result = SystemAssignmentGroupBLL.InsertGroupUser(assignmentGroupId, ConvertXml.ConvertDataTableToXml(dtUser));
            }
        }
        // Insert Audience
        private void InsertAudienceUser(string audienceId)
        {
            DataTable dtAudienceUser = SystemAudiencesBLL.GetAudienceUser(audienceId, "us_english");
            ConvertDataTables ConvertXml = new ConvertDataTables();
            if (dtAudienceUser.Rows.Count > 0)
            {
                int result = SystemAudiencesBLL.InsertAudienceUser(audienceId, ConvertXml.ConvertDataTableToXml(dtAudienceUser));
            }
        }

    }
}