using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Globalization;
using ComplicanceFactor.Common;
using System.IO;
using System.Net;
using System.Text;

namespace ComplicanceFactor.SystemHome.Configuration.Data_Imports
{
    public partial class TestDataImport : System.Web.UI.Page
    {
        private string _attachmentpath = "~/SystemHome/Configuration/Data Imports/Upload/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDataImport_Click(object sender, EventArgs e)
        {
            //TODO: Set Stored Procedure.
            string dtTime = String.Format("{0:HH:mm}", DateTime.Now);
            dtTime = "11:50";
            DateTime dtCurrentTime = DateTime.Now;
            string date = dtCurrentTime.ToShortDateString();

            SystemHRISIntegration dataImport = new SystemHRISIntegration();
            try
            {
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
                                if (string.IsNullOrEmpty(dtDataBackground.Rows[i]["NeedToRun"].ToString()))
                                {

                                    //Do Hris background process
                                }
                            }
                            else if (u_sftp_id_pk.Contains("DIMP"))
                            {
                                if (string.IsNullOrEmpty(dtDataBackground.Rows[i]["NeedToRun"].ToString()))
                                {
                                    //do Data Import Hris Background Process
                                    DataTable dtFacility = GetCSVData(Server.MapPath(_attachmentpath + dtDataBackground.Rows[i]["u_sftp_imp_facility_filename"].ToString()));
                                    if (dtFacility.Rows.Count > 0)
                                    {
                                        InsertIntoFacility(dtFacility, dataImport.u_sftp_URI, dataImport.u_sftp_username, dataImport.u_sftp_password);
                                        //Insert/Update Facility 
                                    }

                                    //DataTable dtRoom = getExcelData(Server.MapPath(_attachmentpath + dataImport.u_sftp_imp_room_filename), "room");
                                    //if (dtRoom.Rows.Count > 0)
                                    //{
                                        //Insert/Update Room 
                                    //}

                                    DataTable dtCourse = GetCSVData(Server.MapPath(_attachmentpath + dtDataBackground.Rows[i]["u_sftp_imp_course_filename"].ToString()));
                                    if (dtCourse.Rows.Count > 0)
                                    {
                                        //Insert/Update Course 
                                        //InsertIntoCourse(dtCourse, dataImport.u_sftp_URI, dataImport.u_sftp_username, dataImport.u_sftp_password);
                                    }

                                    DataTable dtCurrriculum = GetCSVData(Server.MapPath(_attachmentpath + dtDataBackground.Rows[i]["u_sftp_imp_base_curricula_filename"].ToString()));
                                    if (dtCurrriculum.Rows.Count > 0)
                                    {
                                        //Insert/Update Curriculum 
                                        InsertIntoCurriculum(dtCurrriculum, dataImport.u_sftp_URI, dataImport.u_sftp_username, dataImport.u_sftp_password);
                                    }

                                    if (dataImport.u_sftp_imp_is_enrollment == true)
                                    {
                                        //DataTable dtEnrollment = getExcelData(Server.MapPath(_attachmentpath + dataImport.u_sftp_imp_enrollment_filename), "enrollment");
                                        //if (dtEnrollment.Rows.Count > 0)
                                        //{
                                        //    //Insert/Update Enrollment 
                                        //}
                                    }

                                    if (dataImport.u_sftp_imp_is_learning_history == true)
                                    {
                                        //DataTable dtLearningHistory = getExcelData(Server.MapPath(_attachmentpath + dataImport.u_sftp_imp_learning_history_filename), "learningHistory");
                                        //if (dtLearningHistory.Rows.Count > 0)
                                        //{
                                        //    //Insert/Update Learning History 
                                        //}
                                    }
                                }

                            }
                            else if (u_sftp_id_pk.Contains("DEXP"))
                            {
                                //do Data Export Background Process
                            }
                        }

                    }
                }
                ////dataImport = SystemBackgroundJobsBLL.GetBackgroundInformation(dtTime, date);
                //if (!string.IsNullOrEmpty(dataImport.u_sftp_URI))
                //{

                //}
            }
            catch (Exception ex)
            {

            }
        }

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
                CreateLogFile(dtFacility, sftp_URI, userName, password,"Facility");
                //Create Log File For Facility
            }
        }

        private void InsertIntoRoom(DataTable dtRoom, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtRoom.Columns.Add("Status", typeof(String));
            dtRoom.Columns.Add("ErrorResult", typeof(String));
            dtRoom.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtRoom.Rows.Count; i++)
            {
                SystemRoom createRoom = new SystemRoom();
                //createRoom.s_room_system_id_pk = dtRoom.Rows[i]["s_room_system_id_pk"].ToString();
                createRoom.s_room_id_pk = dtRoom.Rows[i]["c_room_id_pk"].ToString();
                createRoom.s_room_name = dtRoom.Rows[i]["c_room_name"].ToString();
                createRoom.s_room_desc = dtRoom.Rows[i]["c_room_desc"].ToString();
                createRoom.s_room_status_id_fk = dtRoom.Rows[i]["c_room_status_id_fk"].ToString();
                createRoom.s_room_type_id_fk = dtRoom.Rows[i]["c_room_type_id_fk"].ToString();
                createRoom.s_room_facility_id_fk = dtRoom.Rows[i]["c_room_facility_id_fk"].ToString();

                try
                {
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
                //Create Log File For Room                
            }
        }

        private void InsertIntoCourse(DataTable dtCourse, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtCourse.Columns.Add("Status", typeof(String));
            dtCourse.Columns.Add("ErrorResult", typeof(String));
            dtCourse.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtCourse.Rows.Count; i++)
            {
                SystemCatalog CreateCourse = new SystemCatalog();
                 
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

                try
                {
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
        }

        private void InsertIntoCurriculum(DataTable dtCurriculum, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtCurriculum.Columns.Add("Status", typeof(String));
            dtCurriculum.Columns.Add("ErrorResult", typeof(String));
            dtCurriculum.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtCurriculum.Rows.Count; i++)
            {
                SystemCurriculum CreateCurriculum = new SystemCurriculum();
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

                try
                {
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
        }

        private void InsertIntoEnrollment(DataTable dtEnrollment, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtEnrollment.Columns.Add("Status", typeof(String));
            dtEnrollment.Columns.Add("ErrorResult", typeof(String));
            dtEnrollment.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtEnrollment.Rows.Count; i++)
            {
                Enrollment enrollOLT = new Enrollment();

                enrollOLT.e_enroll_user_id_fk = dtEnrollment.Rows[i]["u_user_id_pk"].ToString();
                enrollOLT.e_enroll_delivery_id_fk = dtEnrollment.Rows[i]["e_enroll_delivery_id_fk"].ToString();
                enrollOLT.e_enroll_course_id_fk = dtEnrollment.Rows[i]["e_enroll_course_id_fk"].ToString();
                enrollOLT.e_enroll_required_flag = Convert.ToBoolean(dtEnrollment.Rows[i]["e_enroll_required_flag"]);
                //enrollOLT.e_enroll_approval_required_flag = false;
                enrollOLT.e_enroll_type_name = dtEnrollment.Rows[i]["e_enroll_type_name"].ToString();
                //enrollOLT.e_enroll_approval_status_name = dtEnrollment.Rows[i]["u_user_id_pk"].ToString();
                enrollOLT.e_enroll_status_name = dtEnrollment.Rows[i]["e_enroll_status_name"].ToString();
                enrollOLT.e_enroll_target_due_date = Convert.ToDateTime(dtEnrollment.Rows[i]["e_enroll_target_due_date"]);

                try
                {

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void InsertIntoLearningHistory(DataTable dtLearningHistory, string sftp_URI, string userName, string password)
        {
            CultureInfo culture = new CultureInfo("en-US");
            dtLearningHistory.Columns.Add("Status", typeof(String));
            dtLearningHistory.Columns.Add("ErrorResult", typeof(String));
            dtLearningHistory.Columns.Add("RecordCount", typeof(Int32));

            for (int i = 0; i < dtLearningHistory.Rows.Count; i++)
            {

            }
        }

        public static DataTable GetCSVData(string fileName)
        {
            string CSVFilePathName = fileName;
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols - 1; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;
            for (int i = 0; i <= Lines.GetLength(0) - 2; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols - 1; f++)
                    Row[f] = Fields[f];
                dt.Rows.Add(Row);
            }

            dt.Rows.RemoveAt(0);

            return dt;
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


        /// <summary>
        /// Create Log File
        /// </summary>
        /// <param name="dtHris"></param>
        private void CreateLogFile(DataTable dtHris, string uri, string userName, string password,string process)
        {
            DateTime start = DateTime.Now;
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
            sb.AppendLine("Downloaded " + process + " CSV File: Passed");
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

            //CreateLogFileInFTP(filename, uri, userName, password, sb.ToString(), filePath);//filePath           

            //Insert sftp_run_log table

            SystemHRISIntegration hrisRunlog = new SystemHRISIntegration();
            hrisRunlog.u_sftp_run_date_time_start = DateTime.Now.ToString();
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
        private void CreateLogFileInFTP(string filename, string uri, string userName, string password, string text, string path)
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
    }
}