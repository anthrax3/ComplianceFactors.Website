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
    public class EnrollmentBLL
    {
        public static Enrollment GetEnrollDeliveries(string e_enroll_delivery_id_fk, string e_enroll_user_id_fk)
        {
            try
            {

                Hashtable htGetEnrollDeliveries = new Hashtable();
                htGetEnrollDeliveries.Add("@e_enroll_delivery_id_fk", e_enroll_delivery_id_fk);
                htGetEnrollDeliveries.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
                DataTable dtGetEnrollDeliveries = DataProxy.FetchDataTable("e_sp_get_delivery", htGetEnrollDeliveries);

                Enrollment getEnrollDeliveries = new Enrollment();
                if (dtGetEnrollDeliveries.Rows.Count > 0)
                {
                    getEnrollDeliveries.e_enroll_user_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_user_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_course_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_course_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_delivery_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_delivery_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_enroll_type_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_enroll_type_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_required_flag = Convert.ToBoolean(dtGetEnrollDeliveries.Rows[0]["e_enroll_required_flag"]);
                    getEnrollDeliveries.e_enroll_approval_required_flag = Convert.ToBoolean(dtGetEnrollDeliveries.Rows[0]["e_enroll_approval_required_flag"]);
                    getEnrollDeliveries.e_enroll_approval_status_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_approval_status_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_status_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_status_id_fk"].ToString();
                    getEnrollDeliveries.e_enroll_type_name = dtGetEnrollDeliveries.Rows[0]["e_enroll_type_name"].ToString();

                }
                return getEnrollDeliveries;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Enrollment GetEnrollCourse(string e_enroll_course_id_fk, string e_enroll_user_id_fk)
        {
            try
            {

                Hashtable htGetEnrollCourse = new Hashtable();
                htGetEnrollCourse.Add("@e_enroll_course_id_fk", e_enroll_course_id_fk);
                htGetEnrollCourse.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
                DataTable dtGetEnrollCourse = DataProxy.FetchDataTable("e_sp_get_course", htGetEnrollCourse);

                Enrollment getEnrollCourse = new Enrollment();
                if (dtGetEnrollCourse.Rows.Count > 0)
                {
                    getEnrollCourse.e_enroll_user_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_user_id_fk"].ToString();
                    getEnrollCourse.e_enroll_course_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_course_id_fk"].ToString();
                    getEnrollCourse.e_enroll_delivery_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_delivery_id_fk"].ToString();
                    //getEnrollDeliveries.e_enroll_enroll_date_time = dtGetEnrollDeliveries.Rows[0]["e_enroll_enroll_date_time"].ToString();
                    //getEnrollDeliveries.e_enroll_expire_date = dtGetEnrollDeliveries.Rows[0]["e_enroll_expire_date"].ToString();
                    getEnrollCourse.e_enroll_enroll_type_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_enroll_type_id_fk"].ToString();
                    if (!string.IsNullOrEmpty(dtGetEnrollCourse.Rows[0]["e_enroll_required_flag"].ToString()))
                    {
                        getEnrollCourse.e_enroll_required_flag = Convert.ToBoolean(dtGetEnrollCourse.Rows[0]["e_enroll_required_flag"]);
                    }
                    if (!string.IsNullOrEmpty(dtGetEnrollCourse.Rows[0]["e_enroll_approval_required_flag"].ToString()))
                    {
                        getEnrollCourse.e_enroll_approval_required_flag = Convert.ToBoolean(dtGetEnrollCourse.Rows[0]["e_enroll_approval_required_flag"]);
                    }
                    getEnrollCourse.e_enroll_approval_status_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_approval_status_id_fk"].ToString();
                    //getEnrollDeliveries.e_enroll_approval_date = dtGetEnrollDeliveries.Rows[0]["e_enroll_approval_date"].ToString();
                    //getEnrollDeliveries.e_enroll_target_due_date = dtGetEnrollDeliveries.Rows[0]["e_enroll_target_due_date"].ToString();
                    getEnrollCourse.e_enroll_status_id_fk = dtGetEnrollCourse.Rows[0]["e_enroll_status_id_fk"].ToString();
                    //getEnrollDeliveries.e_enroll_assign_recert_due_date = dtGetEnrollDeliveries.Rows[0]["e_enroll_assign_recert_due_date"].ToString();
                    //getEnrollDeliveries.e_enroll_assign_recert_status_id_fk = dtGetEnrollDeliveries.Rows[0]["e_enroll_assign_recert_status_id_fk"].ToString();
                    //getEnrollDeliveries.e_enroll_time_spent = dtGetEnrollDeliveries.Rows[0]["e_enroll_time_spent"].ToString();
                    //getEnrollDeliveries.e_enroll_lesson_location = dtGetEnrollDeliveries.Rows[0]["e_enroll_lesson_location"].ToString();
                    //getEnrollDeliveries.e_enroll_suspend_data = dtGetEnrollDeliveries.Rows[0]["e_enroll_suspend_data"].ToString();
                    //getEnrollDeliveries.e_enroll_score = dtGetEnrollDeliveries.Rows[0]["e_enroll_score"].ToString();
                    //getEnrollDeliveries.e_enroll_active_flag = dtGetEnrollDeliveries.Rows[0]["e_enroll_active_flag"].ToString();
                    getEnrollCourse.e_enroll_type_name = dtGetEnrollCourse.Rows[0]["e_enroll_type_name"].ToString();
                }
                return getEnrollCourse;
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
                    if (!string.IsNullOrEmpty((dtGetAssignCourse.Rows[0]["e_curriculum_assign_target_due_date"]).ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_target_due_date = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_target_due_date"]);
                    }
                    if (!string.IsNullOrEmpty((dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_due_date"]).ToString()))
                    {
                        getAssignCourse.e_curriculum_assign_recert_due_date = Convert.ToDateTime(dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_due_date"]);
                    }
                    getAssignCourse.e_curriculum_assign_recert_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_recert_status_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_status_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_percent_complete = Convert.ToInt32(dtGetAssignCourse.Rows[0]["e_curriculum_assign_percent_complete"]);
                    getAssignCourse.e_curriculum_assign_status_id_fk = dtGetAssignCourse.Rows[0]["e_curriculum_assign_status_id_fk"].ToString();
                    getAssignCourse.e_curriculum_assign_active_flag = Convert.ToBoolean(dtGetAssignCourse.Rows[0]["e_curriculum_assign_active_flag"].ToString());
                    getAssignCourse.e_curriculum_assign_status = dtGetAssignCourse.Rows[0]["e_curriculum_assign_status"].ToString(); 
                }
                return getAssignCourse;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int SingleEnroll(Enrollment Enroll, bool e_check_enroll)
        {
            try
            {
                Hashtable htConfirmEnroll = new Hashtable();
                Hashtable htReEnroll = new Hashtable();

                if (Enroll.e_re_enroll == true)
                {
                    htReEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                    htReEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                    htReEnroll.Add("@e_enroll_delivery_id_fk", Enroll.e_enroll_delivery_id_fk);
                    htReEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                    htReEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);
                    if (Enroll.e_enroll_target_due_date != null)
                    {
                        htReEnroll.Add("@e_enroll_target_due_date", Enroll.e_enroll_target_due_date);
                    }
                    else
                    {
                        htReEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                    }
                    return DataProxy.FetchSPOutput("e_sp_insert_reenrollment", htReEnroll);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                    htConfirmEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                    htConfirmEnroll.Add("@e_enroll_delivery_id_fk", Enroll.e_enroll_delivery_id_fk);
                    htConfirmEnroll.Add("@e_enroll_required_flag", Enroll.e_enroll_required_flag);
                    htConfirmEnroll.Add("@e_enroll_approval_required_flag", Enroll.e_enroll_approval_required_flag);
                    htConfirmEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                    htConfirmEnroll.Add("@e_enroll_approval_status_name", Enroll.e_enroll_approval_status_name);
                    htConfirmEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);
                    htConfirmEnroll.Add("@e_check_enroll", e_check_enroll);
                    htConfirmEnroll.Add("@e_enroll_level_1_req_flag", Enroll.e_enroll_level_1_req_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_1_type", Enroll.e_enroll_approver_1_type);
                    if (Enroll.e_enroll_target_due_date != null)
                    {
                        htConfirmEnroll.Add("@e_enroll_target_due_date", Enroll.e_enroll_target_due_date);
                    }
                    else
                    {
                        htConfirmEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_1_id_fk))
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_1_id_fk", Enroll.e_enroll_approver_1_id_fk);
                    }
                    else
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_1_id_fk", DBNull.Value);
                    }

                    htConfirmEnroll.Add("@e_enroll_approver_1_decision_flag", Enroll.e_enroll_approver_1_decision_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_1_decision_date", Enroll.e_enroll_approver_1_decision_date);
                    htConfirmEnroll.Add("@e_enroll_level_2_req_flag", Enroll.e_enroll_level_2_req_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_2_type", Enroll.e_enroll_approver_2_type);
                    if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_2_id_fk))
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_2_id_fk", Enroll.e_enroll_approver_2_id_fk);
                    }
                    else
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_2_id_fk", DBNull.Value);
                    }
                    htConfirmEnroll.Add("@e_enroll_approver_2_decision_flag", Enroll.e_enroll_approver_2_decision_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_2_decision_date", Enroll.e_enroll_approver_2_decision_date);
                    htConfirmEnroll.Add("@e_enroll_level_3_req_flag", Enroll.e_enroll_level_3_req_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_3_type", Enroll.e_enroll_approver_3_type);
                    if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_3_id_fk))
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_3_id_fk", Enroll.e_enroll_approver_3_id_fk);
                    }
                    else
                    {
                        htConfirmEnroll.Add("@e_enroll_approver_3_id_fk", DBNull.Value);
                    }
                    htConfirmEnroll.Add("@e_enroll_approver_3_decision_flag", Enroll.e_enroll_approver_3_decision_flag);
                    htConfirmEnroll.Add("@e_enroll_approver_3_decision_date", Enroll.e_enroll_approver_3_decision_date);
                    htConfirmEnroll.Add("@e_enroll_approval_final_decision_date", Enroll.e_enroll_approval_final_decision_date);
                    htConfirmEnroll.Add("@e_check_course_approval", Enroll.e_check_course_approval);
                    htConfirmEnroll.Add("@e_check_delivery_approval", Enroll.e_check_delivery_approval);
                    if (!string.IsNullOrEmpty(Enroll.e_enroll_manger_id_fk))
                    {
                        htConfirmEnroll.Add("@e_enroll_manger_id_fk", Enroll.e_enroll_manger_id_fk);
                    }
                    else
                    {
                        htConfirmEnroll.Add("@e_enroll_manger_id_fk", DBNull.Value);
                    }
                    return DataProxy.FetchSPOutput("e_sp_insert_enrollment", htConfirmEnroll);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int EnrollmentApproval(Enrollment Enroll, bool e_check_enroll)
        {
            try
            {
                Hashtable htConfirmEnroll = new Hashtable();
                htConfirmEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                htConfirmEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                htConfirmEnroll.Add("@e_enroll_delivery_id_fk", Enroll.e_enroll_delivery_id_fk);
                htConfirmEnroll.Add("@e_enroll_required_flag", Enroll.e_enroll_required_flag);
                htConfirmEnroll.Add("@e_enroll_approval_required_flag", Enroll.e_enroll_approval_required_flag);
                htConfirmEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                htConfirmEnroll.Add("@e_enroll_approval_status_name", Enroll.e_enroll_approval_status_name);
                htConfirmEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);
                htConfirmEnroll.Add("@e_check_enroll", e_check_enroll);
                htConfirmEnroll.Add("@e_enroll_level_1_req_flag", Enroll.e_enroll_level_1_req_flag);
                htConfirmEnroll.Add("@e_enroll_approver_1_type", Enroll.e_enroll_approver_1_type);
                if (Enroll.e_enroll_target_due_date != null)
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", Enroll.e_enroll_target_due_date);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_1_id_fk))
                {
                    htConfirmEnroll.Add("@e_enroll_approver_1_id_fk", Enroll.e_enroll_approver_1_id_fk);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_approver_1_id_fk", DBNull.Value);
                }

                htConfirmEnroll.Add("@e_enroll_approver_1_decision_flag", Enroll.e_enroll_approver_1_decision_flag);
                htConfirmEnroll.Add("@e_enroll_approver_1_decision_date", Enroll.e_enroll_approver_1_decision_date);
                htConfirmEnroll.Add("@e_enroll_level_2_req_flag", Enroll.e_enroll_level_2_req_flag);
                htConfirmEnroll.Add("@e_enroll_approver_2_type", Enroll.e_enroll_approver_2_type);
                if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_2_id_fk))
                {
                    htConfirmEnroll.Add("@e_enroll_approver_2_id_fk", Enroll.e_enroll_approver_2_id_fk);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_approver_2_id_fk", DBNull.Value);
                }
                htConfirmEnroll.Add("@e_enroll_approver_2_decision_flag", Enroll.e_enroll_approver_2_decision_flag);
                htConfirmEnroll.Add("@e_enroll_approver_2_decision_date", Enroll.e_enroll_approver_2_decision_date);
                htConfirmEnroll.Add("@e_enroll_level_3_req_flag", Enroll.e_enroll_level_3_req_flag);
                htConfirmEnroll.Add("@e_enroll_approver_3_type", Enroll.e_enroll_approver_3_type);
                if (!string.IsNullOrEmpty(Enroll.e_enroll_approver_3_id_fk))
                {
                    htConfirmEnroll.Add("@e_enroll_approver_3_id_fk", Enroll.e_enroll_approver_3_id_fk);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_approver_3_id_fk", DBNull.Value);
                }
                htConfirmEnroll.Add("@e_enroll_approver_3_decision_flag", Enroll.e_enroll_approver_3_decision_flag);
                htConfirmEnroll.Add("@e_enroll_approver_3_decision_date", Enroll.e_enroll_approver_3_decision_date);
                htConfirmEnroll.Add("@e_enroll_approval_final_decision_date", Enroll.e_enroll_approval_final_decision_date);
                htConfirmEnroll.Add("@e_check_course_approval", Enroll.e_check_course_approval);
                htConfirmEnroll.Add("@e_check_delivery_approval", Enroll.e_check_delivery_approval);
                if (!string.IsNullOrEmpty(Enroll.e_enroll_manger_id_fk))
                {
                    htConfirmEnroll.Add("@e_enroll_manger_id_fk", Enroll.e_enroll_manger_id_fk);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_manger_id_fk", DBNull.Value);
                }
                return DataProxy.FetchSPOutput("e_sp_insert_enrollment_approval", htConfirmEnroll);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int QuickLaunchEnroll(Enrollment Enroll)
        {
            try
            {
                Hashtable htEnroll = new Hashtable();
                htEnroll.Add("@e_enroll_system_id_pk", Enroll.e_enroll_system_id_pk);
                htEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                htEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                htEnroll.Add("@e_enroll_required_flag", Enroll.e_enroll_required_flag);
                htEnroll.Add("@e_enroll_approval_required_flag", Enroll.e_enroll_approval_required_flag);
                htEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                htEnroll.Add("@e_enroll_approval_status_name", Enroll.e_enroll_approval_status_name);
                htEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);
                return DataProxy.FetchSPOutput("e_sp_enroll_quick_launch", htEnroll);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int AssignCurricula(Enrollment assignCurricula)
        {
            try
            {
                Hashtable htAssignCurricula = new Hashtable();
                htAssignCurricula.Add("@e_curriculum_assign_user_id_fk", assignCurricula.e_curriculum_assign_user_id_fk);
                htAssignCurricula.Add("@e_curriculum_assign_curriculum_id_fk", assignCurricula.e_curriculum_assign_curriculum_id_fk);
                htAssignCurricula.Add("@e_curriculum_assign_required_flag", assignCurricula.e_curriculum_assign_required_flag);
                if (assignCurricula.e_curriculum_assign_target_due_date == null)
                {
                    htAssignCurricula.Add("@e_curriculum_assign_target_due_date", DBNull.Value);
                }
                else
                {
                    htAssignCurricula.Add("@e_curriculum_assign_target_due_date", assignCurricula.e_curriculum_assign_target_due_date);
                }
                if (assignCurricula.e_curriculum_assign_recert_due_date == null)
                {
                    htAssignCurricula.Add("@e_curriculum_assign_recert_due_date", DBNull.Value);
                }
                else
                {
                    htAssignCurricula.Add("@e_curriculum_assign_recert_due_date", assignCurricula.e_curriculum_assign_recert_due_date);
                }
                htAssignCurricula.Add("@e_curriculum_assign_recert_status_id_fk", DBNull.Value);
                htAssignCurricula.Add("@e_curriculum_assign_status_id_fk", assignCurricula.e_curriculum_assign_status_id_fk);
                htAssignCurricula.Add("@e_curriculum_assign_percent_complete", assignCurricula.e_curriculum_assign_percent_complete);
                htAssignCurricula.Add("@e_curriculum_assign_active_flag", assignCurricula.e_curriculum_assign_active_flag);
                htAssignCurricula.Add("@e_enroll_required_flag", assignCurricula.e_enroll_required_flag);
                return DataProxy.FetchSPOutput("e_sp_assign_curricula", htAssignCurricula);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertWaitList(Enrollment waitlist)
        {
            try
            {
                Hashtable htInsertWaitList = new Hashtable();
                htInsertWaitList.Add("@e_enroll_waitlist_course_id_fk", waitlist.e_enroll_waitlist_course_id_fk);
                htInsertWaitList.Add("@e_enroll_waitlist_course_delivery_id_fk", waitlist.e_enroll_waitlist_course_delivery_id_fk);
                htInsertWaitList.Add("@e_enroll_waitlist_user_id_fk", waitlist.e_enroll_waitlist_user_id_fk);
                return DataProxy.FetchSPOutput("e_sp_enroll_waitlist", htInsertWaitList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable EnrollGetSingleCurriculaPathCourse(string c_curricula_id_fk, string c_curricula_path_id_fk, string e_enroll_user_id_fk)
        {
            Hashtable htEnrollGetSingleCurriculaPathCourse = new Hashtable();
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htEnrollGetSingleCurriculaPathCourse.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
            try
            {
                return DataProxy.FetchDataTable("e_sp_single_curricula_path_course", htEnrollGetSingleCurriculaPathCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable EnrollGetSingleCurriculaRecertPathCourse(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            Hashtable htEnrollGetSingleCurriculaPathCourse = new Hashtable();
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("e_sp_single_curricula_recert_path_course", htEnrollGetSingleCurriculaPathCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int GetWaitListcount(string e_waitlist_delivery_id_fk, string e_waitlist_user_id_fk)
        {
            try
            {
                Hashtable htWaitListCount = new Hashtable();
                htWaitListCount.Add("@e_waitlist_delivery_id_fk", e_waitlist_delivery_id_fk);
                htWaitListCount.Add("@e_waitlist_user_id_fk", e_waitlist_user_id_fk);
                return DataProxy.FetchSPOutput("e_sp_get_waitlist_count", htWaitListCount);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetAllCurricula(string e_user_id_fk)
        {
            Hashtable htGetAllCurricula = new Hashtable();
            htGetAllCurricula.Add("@e_user_id_fk", e_user_id_fk);
            try
            {
                return DataProxy.FetchDataSet("e_sp_get_all_curricula", htGetAllCurricula);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int AssignCourse(Enrollment assign)
        {
            try
            {
                Hashtable htAssignCourse = new Hashtable();
                htAssignCourse.Add("@e_assign_course", assign.e_assign_course);
                htAssignCourse.Add("@e_course_assign_by_id_fk",assign.e_course_assign_by_id_fk);
                htAssignCourse.Add("@e_course_assign_required_flag",assign.e_course_assign_required_flag);
                if (assign.e_course_assign_target_due_date == null)
                {
                    htAssignCourse.Add("@e_course_assign_target_due_date", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_course_assign_target_due_date", assign.e_course_assign_target_due_date);
                }
                htAssignCourse.Add("@e_course_assign_recert_due_date",DBNull.Value);
                htAssignCourse.Add("@e_course_assign_percent_complete",assign.e_course_assign_percent_complete);
                htAssignCourse.Add("@e_course_assign_active_flag", assign.e_course_assign_active_flag);
                return DataProxy.FetchSPOutput("e_sp_assign_course", htAssignCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetToDos(string s_todo_user_id_fk)
        {
            try
            {
                Hashtable htGetToDos = new Hashtable();
                htGetToDos.Add("@s_todo_user_id_fk", s_todo_user_id_fk);
                return DataProxy.FetchDataSet("e_sp_get_all_todo_team_report", htGetToDos);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ApprovalCount(string c_course_id)
        {
            try
            {
                Hashtable htApprovalCount = new Hashtable();
                htApprovalCount.Add("@c_course_id", c_course_id);
                return DataProxy.FetchSPOutput("e_sp_approval_count", htApprovalCount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Newly created function 11 Feb
        public static int UpdateApprovalsTodos(string e_enroll_approval_system_id_pk, string s_todo_system_id_pk)
        {
            try
            {
                Hashtable htApprovalsTodos = new Hashtable();
                //htApprovalsTodos.Add("@e_approvar_id", e_approvar_id);
                htApprovalsTodos.Add("@e_enroll_approval_system_id_pk",e_enroll_approval_system_id_pk);
                htApprovalsTodos.Add("@s_todo_system_id_pk", s_todo_system_id_pk);

                return DataProxy.FetchSPOutput("e_sp_update_todo_enrollment_approvals", htApprovalsTodos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DenyEnrollment(string e_enroll_approval_system_id_pk, string s_todo_system_id_pk)
        {
            try
            {
                Hashtable htDeny = new Hashtable();
                htDeny.Add("@e_enroll_approval_system_id_pk", e_enroll_approval_system_id_pk);
                htDeny.Add("@s_todo_system_id_pk", s_todo_system_id_pk);

                return DataProxy.FetchSPOutput("e_deny_todo_enrollment_approvals", htDeny);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemCatalog GetCourseDetails(string deliveryId)
        {
            try
            {

                Hashtable htGetCourseDetails = new Hashtable();
                htGetCourseDetails.Add("@c_delivery_system_id_pk", deliveryId);

                DataTable dtGetCourse = DataProxy.FetchDataTable("e_sp_get_course_details", htGetCourseDetails);
                SystemCatalog getCourse = new SystemCatalog();
                if (dtGetCourse.Rows.Count > 0)
                {
                    getCourse.c_course_id_pk = dtGetCourse.Rows[0]["c_course_id_pk"].ToString();
                    getCourse.c_course_title = dtGetCourse.Rows[0]["c_course_title"].ToString();
                    getCourse.c_delivery_id_pk = dtGetCourse.Rows[0]["c_delivery_id_pk"].ToString();
                    getCourse.c_delivery_title = dtGetCourse.Rows[0]["c_delivery_title"].ToString();
                     
                }
                return getCourse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetApproverEmailAddress(string e_enroll_user_id_fk)
        {
            try
            {
                Hashtable htGetApproverEmailAddress = new Hashtable();
                htGetApproverEmailAddress.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
                DataTable dtVal = DataProxy.FetchDataTable("e_sp_get_approver_mail_id", htGetApproverEmailAddress);
                return dtVal.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// upadte enrollment status
        /// </summary>
        /// <param name="Enroll"></param>
        /// <returns></returns>
        public static int UpdateEnrollmentStatus(Enrollment enroll)
        {
            try
            {
                Hashtable htUpdateEnrollmentStatus = new Hashtable();
                htUpdateEnrollmentStatus.Add("@e_enroll_user_id_fk", enroll.e_enroll_user_id_fk);
                htUpdateEnrollmentStatus.Add("@e_enroll_course_id_fk", enroll.e_enroll_course_id_fk);
                return DataProxy.FetchSPOutput("e_sp_update_enrollment_status", htUpdateEnrollmentStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// delete enrollment 
        /// </summary>
        /// <param name="Enroll"></param>
        /// <returns></returns>
        public static int DropEnrollmentStatus(Enrollment enroll)
        {
            try
            {
                Hashtable htDropEnrollmentStatus = new Hashtable();
                htDropEnrollmentStatus.Add("@e_enroll_user_id_fk", enroll.e_enroll_user_id_fk);
                htDropEnrollmentStatus.Add("@e_enroll_course_id_fk", enroll.e_enroll_course_id_fk);
                return DataProxy.FetchSPOutput("e_sp_drop_enrollment", htDropEnrollmentStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static bool CheckDeliveryEnrollorNot(string e_enroll_course_id_fk, string e_enroll_user_id_fk)
        {
            try
            {
                Hashtable htGetDelieryenroll = new Hashtable();
                htGetDelieryenroll.Add("@e_enroll_course_id_fk", e_enroll_course_id_fk);
                htGetDelieryenroll.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
                int res= DataProxy.FetchSPOutput("e_sp_check_delivery_enroll_or_not", htGetDelieryenroll);
                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        /// <summary>
        /// Get all learning History
        /// </summary>
        /// <param name="e_user_id_fk"></param>
        /// <returns></returns>
        public static DataSet GetAllLearningHistory(string e_user_id_fk, string s_locale_culture)
        {
            Hashtable htGetAllLearningHistory = new Hashtable();
            htGetAllLearningHistory.Add("@e_user_id_fk", e_user_id_fk);
            htGetAllLearningHistory.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("e_sp_get_all_Learning_History", htGetAllLearningHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///<summary>
        ///Get status
        ///</summary>
        public static DataTable GetLearningHistoryStatus(string s_locale, string s_ui_page_name)
        {
            Hashtable htDeliveryType = new Hashtable();
            if (!string.IsNullOrEmpty(s_locale))
            {
                htDeliveryType.Add("@s_ui_locale_name", s_locale);
            }
            else
            {
                htDeliveryType.Add("@s_ui_locale_name", "us_english");
            }
            htDeliveryType.Add("@s_ui_page_name", s_ui_page_name);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_learning_history_status", htDeliveryType);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Search learning History
        /// </summary>
        /// <param name="learningHistory"></param>
        /// <returns></returns>
        public static DataTable SerchLearningHistory(Enrollment learningHistory)
        {
            Hashtable htLearningHistory = new Hashtable();
            htLearningHistory.Add("@e_enroll_user_id_fk", learningHistory.e_enroll_user_id_fk);

            if (!string.IsNullOrEmpty(learningHistory.e_learning_keyword))
            {
                htLearningHistory.Add("@e_learning_keyword", learningHistory.e_learning_keyword);
            }
            else
            {
                htLearningHistory.Add("@e_learning_keyword", DBNull.Value);
            }

            if (learningHistory.e_learning_from_date!=null)
            {
                htLearningHistory.Add("@e_learning_from_date", learningHistory.e_learning_from_date);
            }
            else
            {
                htLearningHistory.Add("@e_learning_from_date", DBNull.Value);
            }
            if (learningHistory.e_learning_to_date != null)
            {
                htLearningHistory.Add("@e_learning_to_date", learningHistory.e_learning_to_date);
            }
            else
            {
                htLearningHistory.Add("@e_learning_to_date", DBNull.Value);
            }
            if (learningHistory.e_learning_status == "0" || learningHistory.e_learning_status == "app_ddl_all_text")
            {
                htLearningHistory.Add("@e_learning_status", DBNull.Value);
            }
            else
            {
                htLearningHistory.Add("@e_learning_status", learningHistory.e_learning_status);
            }
            if (learningHistory.e_learning_deliveryType == "0" || learningHistory.e_learning_deliveryType == "app_ddl_all_text")
            {
                htLearningHistory.Add("@e_learning_deliveryType", DBNull.Value);
            }
            else
            {
               htLearningHistory.Add("@e_learning_deliveryType", learningHistory.e_learning_deliveryType);
            }
            

            return DataProxy.FetchDataTable("e_sp_search_learning_history", htLearningHistory);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e_user_id_fk"></param>
        /// <returns></returns>
        public static DataSet GetCertificatePDF(string e_user_id_fk,string e_course_id_fk,string s_locale_culture)
        {
            Hashtable htGetCertificatePDF = new Hashtable();
            htGetCertificatePDF.Add("@e_user_id_fk", e_user_id_fk);
            htGetCertificatePDF.Add("@e_course_id_fk", e_course_id_fk);
            htGetCertificatePDF.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("e_sp_certificate_pdf", htGetCertificatePDF);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetCurriculaPdf(string user_id_fk, string s_locale_culture)
        {
            try
            {
                Hashtable htGetCurriculaPdf = new Hashtable();

                if (user_id_fk != null)
                {
                    htGetCurriculaPdf.Add("@e_user_id_fk", user_id_fk);
                }
                else
                {
                    htGetCurriculaPdf.Add("@e_user_id_fk", DBNull.Value);
                }
                htGetCurriculaPdf.Add("@s_locale_culture", s_locale_culture);
                return DataProxy.FetchDataSet("e_sp_create_curricula_pdf", htGetCurriculaPdf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ChecReEnrollorNot(string e_enroll_course_id_fk, string e_enroll_user_id_fk)
        {
            try
            {
                Hashtable htChecReEnrollorNot = new Hashtable();
                htChecReEnrollorNot.Add("@e_enroll_course_id_fk", e_enroll_course_id_fk);
                htChecReEnrollorNot.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
                int res = DataProxy.FetchSPOutput("e_sp_check_re_enroll_or_not", htChecReEnrollorNot);
                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Single re-enroll from leraning history(employee/manager)
        public static int SingleReEnroll(Enrollment Enroll)
        {
                Hashtable htConfirmEnroll = new Hashtable();
                htConfirmEnroll.Add("@e_enroll_user_id_fk",Enroll.e_enroll_user_id_fk);
	            htConfirmEnroll.Add("@e_enroll_course_id_fk",Enroll.e_enroll_course_id_fk);
	            htConfirmEnroll.Add("@e_enroll_delivery_id_fk",Enroll.e_enroll_delivery_id_fk);
	            htConfirmEnroll.Add("@e_enroll_type_name",Enroll.e_enroll_type_name);
	            htConfirmEnroll.Add("@e_enroll_status_name",Enroll.e_enroll_status_name);
                htConfirmEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                try
                {
                    return DataProxy.FetchSPOutput("e_sp_insert_reenrollment", htConfirmEnroll);
                }
                catch (Exception)
                {
                    throw;
                }
        }
        //Get Completion details
        public static Enrollment GetCompletionDetails(string t_transcript_user_id_fk, string t_transcript_course_id_fk)
        {
            try
            {
                Hashtable htCompletion = new Hashtable();
                htCompletion.Add("@t_transcript_user_id_fk", t_transcript_user_id_fk);
                htCompletion.Add("@t_transcript_course_id_fk", t_transcript_course_id_fk);
                Enrollment enroll = new Enrollment();
                DataTable dtCompletionDetails = DataProxy.FetchDataTable("e_sp_get_completion_details", htCompletion);
                if (dtCompletionDetails.Rows.Count > 0)
                {
                    enroll.t_transcript_completion_date_time = dtCompletionDetails.Rows[0]["t_transcript_completion_date_time"].ToString();
                    enroll.t_transcript_score = dtCompletionDetails.Rows[0]["t_transcript_score"].ToString();
                    enroll.t_transcript_passing_status_id_fk = dtCompletionDetails.Rows[0]["status"].ToString();    
                }
                return enroll;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //Newly added functions
        public static int UpdateCourseDetailsFromUser(string s_update_course_details)
        {
            Hashtable htUpdateCourse = new Hashtable();
            htUpdateCourse.Add("@s_update_course_details", s_update_course_details);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_courses_from_user", htUpdateCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DropCourseFromUser(string s_drop_course)
        {
            Hashtable htUpdateCourse = new Hashtable();
            htUpdateCourse.Add("@s_drop_course", s_drop_course);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_drop_course_from_user", htUpdateCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCurriculumDetailsFromUser(string s_update_curriculum_details)
        {
            Hashtable htUpdateCurriculum= new Hashtable();
            htUpdateCurriculum.Add("@s_update_curriculum_details", s_update_curriculum_details);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_from_user", htUpdateCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DropCurriculumFromUser(string s_drop_curriculum_details)
        {
            Hashtable htdropCurriculum = new Hashtable();
            htdropCurriculum.Add("@s_drop_curriculum_details", s_drop_curriculum_details);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_drop_curriculum_from_user", htdropCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }   
}
