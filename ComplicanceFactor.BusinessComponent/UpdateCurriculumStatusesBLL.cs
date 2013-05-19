using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;


namespace ComplicanceFactor.BusinessComponent
{
    public class UpdateCurriculumStatusesBLL
    {
        public static DataTable GetCurriculumEmployee(string u_first_name, string u_hris_employee_id,string e_curriculum_assign_curriculum_id_fk)
        {
            try
            {
                Hashtable htGetAllEmployee = new Hashtable();
                htGetAllEmployee.Add("@u_first_name", u_first_name);
                htGetAllEmployee.Add("@u_hris_employee_id", u_hris_employee_id);
                htGetAllEmployee.Add("@e_curriculum_assign_curriculum_id_fk", e_curriculum_assign_curriculum_id_fk);

                return DataProxy.FetchDataTable("c_curriculum_sp_search_employee", htGetAllEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCurriculumStatuses(string curriculumId, string userId, DateTime? dueDate, string statusId, string typeId, string currentUserId)
        {
            try
            {
                Hashtable htUpdateCurricula = new Hashtable();
                htUpdateCurricula.Add("@e_currriculum_id", curriculumId);
                htUpdateCurricula.Add("@e_curriculum_assign_user_id", userId);

                if (dueDate != null)
                {
                    htUpdateCurricula.Add("@e_curriculum_assign_target_due_date", dueDate);
                }
                else
                {
                    htUpdateCurricula.Add("@e_curriculum_assign_target_due_date", DBNull.Value);
                }

                //htUpdateCurricula.Add("@e_curriculum_assign_target_due_date", dueDate);
                htUpdateCurricula.Add("@e_curriculum_assign_status_id_fk", statusId);
                if (typeId == string.Empty)
                    htUpdateCurricula.Add("@e_curriculum_assign_recert_status_change_type_id_fk", DBNull.Value);
                else
                    htUpdateCurricula.Add("@e_curriculum_assign_recert_status_change_type_id_fk", typeId);
                //htUpdateCurricula.Add("@e_curriculum_assign_recert_status_change_type_id_fk", typeId);
                htUpdateCurricula.Add("@e_curriculum_assign_recert_status_change_user_id_fk", currentUserId);

                return DataProxy.FetchSPOutput("e_sp_update_curriculum_statuses", htUpdateCurricula);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus(string s_locale)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_curr_statuses", htGetStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }

        public static DataTable GetCourse(string c_curricula_path_id_fk, string c_curricula_section_fk)
        {
            try
            {
                Hashtable htGetCourse = new Hashtable();
                htGetCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
                htGetCourse.Add("@c_curricula_section_fk", c_curricula_section_fk);

                return DataProxy.FetchDataTable("e_sp_get_course_name_title", htGetCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Enrollment GetAssignCourse(string e_curriculum_assign_curriculum_id_fk, string e_curriculum_assign_user_id_fk)
        {
            try
            {

                Hashtable htGetAssignCourse = new Hashtable();
                htGetAssignCourse.Add("@e_curriculum_assign_curriculum_id_fk", e_curriculum_assign_curriculum_id_fk);
                htGetAssignCourse.Add("@e_curriculum_assign_user_id_fk", e_curriculum_assign_user_id_fk);
                DataTable dtGetAssignCourse = DataProxy.FetchDataTable("e_sp_get_single_curriculum", htGetAssignCourse);
                Enrollment getAssignCourse = new Enrollment();
                if (dtGetAssignCourse.Rows.Count > 0)
                {
                    getAssignCourse.e_curriculum_assign_system_id_pk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_system_id_pk"].ToString();
                    getAssignCourse.e_curriculum_assign_user_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_user_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_curriculum_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_curriculum_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_date_time = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_date_time"].ToString());
                    getAssignCourse.e_curriculum_assign_required_flag = Convert.ToBoolean(dtGetAssignCourse.Rows[0]["e_curriculum_assign_required_flag"]);
                    if (!string.IsNullOrEmpty(dtGetAssignCourse.Rows[0]["e_curriculum_assign_target_due_date"].ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_target_due_date = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_target_due_date"]);
                    }

                    if (!string.IsNullOrEmpty(dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_due_date"].ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_recert_due_date = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_due_date"]);
                    }
                    //getAssignCourse.e_curriculum_assign_recert_due_date = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_due_date"]);
                    getAssignCourse.e_curriculum_assign_recert_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_status_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_status_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtGetAssignCourse.Rows[0]["e_curriculum_assign_percent_complete"].ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_percent_complete = Convert.ToInt32(dtGetAssignCourse.Rows[0]["e_curriculum_assign_percent_complete"]);
                    }
                    getAssignCourse.e_curriculum_assign_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_status_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtGetAssignCourse.Rows[0]["e_curriculum_assign_active_flag"].ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_active_flag = Convert.ToBoolean(dtGetAssignCourse.Rows[0]["e_curriculum_assign_active_flag"].ToString());
                    }
                }
                return getAssignCourse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertHistory(CurriculumStatus status)
        {
            try
            {
                Hashtable htAssignCourse = new Hashtable();


                htAssignCourse.Add("@e_curriculum_assign_system_id_pk", status.e_curriculum_assign_system_id_pk);
                htAssignCourse.Add("@e_curriculum_assign_user_id_fk", status.e_curriculum_assign_user_id_fk);
                htAssignCourse.Add("@e_curriculum_assign_curriculum_id_fk", status.e_curriculum_assign_curriculum_id_fk);
                htAssignCourse.Add("@e_curriculum_assign_date_time", status.e_curriculum_assign_date_time);
                htAssignCourse.Add("@e_curriculum_assign_required_flag", status.e_curriculum_assign_required_flag);
                if (status.e_curriculum_assign_original_target_due_date == null)
                {
                    htAssignCourse.Add("@e_curriculum_assign_original_target_due_date", DBNull.Value);
                }
                else
                {

                    htAssignCourse.Add("@e_curriculum_assign_original_target_due_date", status.e_curriculum_assign_original_target_due_date);
                }
                htAssignCourse.Add("@e_curriculum_assign_status_change_date_time", status.e_curriculum_assign_status_change_date_time);
                htAssignCourse.Add("@e_curriculum_assign_after_status_id_fk", status.e_curriculum_assign_after_status_id_fk);
                if (status.e_curriculum_assign_cert_date == null)
                {
                    htAssignCourse.Add("@e_curriculum_assign_cert_date", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_curriculum_assign_cert_date", status.e_curriculum_assign_cert_date);
                }
                if (status.e_curriculum_assign_recert_due_date == null)
                {
                    htAssignCourse.Add("@e_curriculum_assign_recert_due_date", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_curriculum_assign_recert_due_date", status.e_curriculum_assign_recert_due_date);
                }
                //htAssignCourse.Add("@e_curriculum_assign_recert_due_date", status.e_curriculum_assign_recert_due_date);
                //need to change this
                if (status.e_curriculum_assign_recert_status_change_type_id_fk == string.Empty)
                {
                    htAssignCourse.Add("@e_curriculum_assign_recert_status_change_type_id_fk", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_curriculum_assign_recert_status_change_type_id_fk", status.e_curriculum_assign_recert_status_change_type_id_fk);
                }

                htAssignCourse.Add("@e_curriculum_assign_recert_status_change_user_id_fk", status.e_curriculum_assign_recert_status_change_user_id_fk);
                if (string.IsNullOrEmpty(status.e_curriculum_before_status_id_fk))
                {
                    htAssignCourse.Add("@e_curriculum_before_status_id_fk", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_curriculum_before_status_id_fk", status.e_curriculum_before_status_id_fk);
                }


                //htAssignCourse.Add("@e_curriculum_before_status_id_fk", status.e_curriculum_before_status_id_fk);
                htAssignCourse.Add("@e_curriculum_assign_percent_complete", status.e_curriculum_assign_percent_complete);
                htAssignCourse.Add("@e_curriculum_assign_active_flag", status.e_curriculum_assign_active_flag);
                htAssignCourse.Add("@e_curriculum_status_change_notes", status.e_curriculum_status_change_notes);


                //htAssignCourse.Add("@e_assign_course", assign.e_assign_course);
                //htAssignCourse.Add("@e_course_assign_by_id_fk", assign.e_course_assign_by_id_fk);
                //htAssignCourse.Add("@e_course_assign_required_flag", assign.e_course_assign_required_flag);
                //if (assign.e_course_assign_target_due_date == null)
                //{
                //    htAssignCourse.Add("@e_course_assign_target_due_date", DBNull.Value);
                //}
                //else
                //{
                //    htAssignCourse.Add("@e_course_assign_target_due_date", assign.e_course_assign_target_due_date);
                //}
                //htAssignCourse.Add("@e_course_assign_recert_due_date", DBNull.Value);
                //htAssignCourse.Add("@e_course_assign_percent_complete", assign.e_course_assign_percent_complete);
                //htAssignCourse.Add("@e_course_assign_active_flag", assign.e_course_assign_active_flag);
                return DataProxy.FetchSPOutput("e_sp_insert_status_history", htAssignCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUserPIN(string userName, string password, string pinNumber)
        {
            Hashtable htupdateuser = new Hashtable();
            htupdateuser.Add("@u_user_name", userName);
            htupdateuser.Add("@u_user_password", password);
            htupdateuser.Add("@u_user_esig_pin", pinNumber);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_user_pin_number", htupdateuser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetStatusTypeId(string status_change_type)
        {
            string statusTypeId = string.Empty;
            try
            {
                Hashtable htStatusType = new Hashtable();
                htStatusType.Add("@status_change_type", status_change_type);
                DataTable dtStatusTypeId = DataProxy.FetchDataTable("e_sp_get_status_type_id", htStatusType);
                if (dtStatusTypeId.Rows.Count > 0)
                {
                    statusTypeId = dtStatusTypeId.Rows[0]["e_curriculum_status_change_type_system_id_pk"].ToString();
                }
                return statusTypeId;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
