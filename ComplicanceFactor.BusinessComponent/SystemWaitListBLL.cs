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
    public class SystemWaitListBLL
    {
        public static DataTable GetWaitList(SystemCatalog course)
        {
            Hashtable htGetWaitList = new Hashtable();
            htGetWaitList.Add("@c_course_id_pk", course.c_course_id_pk);
            htGetWaitList.Add("@c_course_title", course.c_course_title);
            htGetWaitList.Add("@c_delivery_id_pk", course.c_delivery_id_pk);
            htGetWaitList.Add("@c_delivery_title", course.c_delivery_title);
            htGetWaitList.Add("@u_hris_employee_id", course.u_hris_employee_id);
            htGetWaitList.Add("@c_employee_name", course.c_employee_name);
            htGetWaitList.Add("@c_course_coordinator_name", course.c_course_coordinator_name);
            if (!string.IsNullOrEmpty(course.c_session_start_date.ToString()))
            {
                htGetWaitList.Add("@c_session_start_date", course.c_session_start_date);
            }
            else
            {
                htGetWaitList.Add("@c_session_start_date", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_session_end_date.ToString()))
            {
                htGetWaitList.Add("@c_session_end_date", course.c_session_end_date);
            }
            else
            {
                htGetWaitList.Add("@c_session_end_date", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_waitlist", htGetWaitList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAllWaitList(string deliveryId)
        {
            Hashtable htGetAllWaitlist = new Hashtable();
            htGetAllWaitlist.Add("@e_enroll_waitlist_course_delivery_id_fk", deliveryId);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_all_wailist", htGetAllWaitlist);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static SystemCatalog GetDeliveryDetails(string deliveryId)
        {
            SystemCatalog cataog = new SystemCatalog();
            DataTable dtDeliveryDetails = new DataTable();
            Hashtable htGetDelivery = new Hashtable();
            htGetDelivery.Add("@c_delivery_system_id_pk", deliveryId);
            try
            {
                dtDeliveryDetails = DataProxy.FetchDataTable("s_sp_get_delivery_for_waitlist", htGetDelivery);
                if (dtDeliveryDetails.Rows.Count > 0)
                {
                    cataog.c_course_title = dtDeliveryDetails.Rows[0]["c_course_title"].ToString();
                    cataog.c_delivery_id_pk = dtDeliveryDetails.Rows[0]["c_delivery_id_pk"].ToString();
                    cataog.c_delivery_title = dtDeliveryDetails.Rows[0]["c_delivery_title"].ToString();

                    cataog.c_session_start_date_time = dtDeliveryDetails.Rows[0]["StartDate"].ToString();
                    cataog.c_session_end_date_time = dtDeliveryDetails.Rows[0]["EndDate"].ToString();

                    if (!string.IsNullOrEmpty(dtDeliveryDetails.Rows[0]["c_delivery_min_enroll"].ToString()))
                    {
                        cataog.c_delivery_min_enroll = Convert.ToInt16(dtDeliveryDetails.Rows[0]["c_delivery_min_enroll"]);
                    }

                    if (!string.IsNullOrEmpty(dtDeliveryDetails.Rows[0]["c_delivery_max_enroll"].ToString()))
                    {
                        cataog.c_delivery_max_enroll = Convert.ToInt16(dtDeliveryDetails.Rows[0]["c_delivery_max_enroll"]);
                    }
                    if (!string.IsNullOrEmpty(dtDeliveryDetails.Rows[0]["c_delivery_max_waitlist"].ToString()))
                    {
                        cataog.c_delivery_max_waitlist = Convert.ToInt16(dtDeliveryDetails.Rows[0]["c_delivery_max_waitlist"]);
                    }
                }
                return cataog;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateWaitListSeqNumberforUp(string currentId, string previousId)
        {
            Hashtable htUpdateSeqNumber = new Hashtable();
            htUpdateSeqNumber.Add("@currentId", currentId);
            htUpdateSeqNumber.Add("@previousId", previousId);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_waitlist_seq_number_for_up", htUpdateSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateWaitListSeqNumberforDown(string currentId, string nextId)
        {
            Hashtable htUpdateSeqNumber = new Hashtable();
            htUpdateSeqNumber.Add("@currentId", currentId);
            htUpdateSeqNumber.Add("@nextId", nextId);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_waitlist_seq_number_for_down", htUpdateSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchUser(User user)
        {
            Hashtable htSearchUser = new Hashtable();
            htSearchUser.Add("@courseId", user.courseId);
            htSearchUser.Add("@deliveryId", user.deliveryId);
            htSearchUser.Add("@employeename", user.Firstname);
            htSearchUser.Add("@employeeid", user.Hris_employeid);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_user_for_waitlist", htSearchUser);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetWaitlist(SystemCatalog waitlist)
        {
            Hashtable htResetWaitlist = new Hashtable();
            htResetWaitlist.Add("@c_course_id_pk", waitlist.c_course_id_pk);
            htResetWaitlist.Add("@c_delivery_id_pk", waitlist.c_delivery_id_pk);
            htResetWaitlist.Add("@s_reset_waitlist", waitlist.s_reset_waitlist);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_waitlist", htResetWaitlist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int SingleEnroll(Enrollment Enroll)
        {
            try
            {
                Hashtable htConfirmEnroll = new Hashtable();
                htConfirmEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                htConfirmEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                htConfirmEnroll.Add("@e_enroll_delivery_id_fk", Enroll.e_enroll_delivery_id_fk);
                htConfirmEnroll.Add("@e_enroll_required_flag", Enroll.e_enroll_required_flag);
                htConfirmEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                if (Enroll.e_enroll_target_due_date != null)
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", Enroll.e_enroll_target_due_date);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                }
                htConfirmEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);
                htConfirmEnroll.Add("@e_enroll_waitlist_system_id_pk", Enroll.e_course_waitlist_system_id_pk);

                return DataProxy.FetchSPOutput("s_sp_enrollment_from_waitlist", htConfirmEnroll);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetDeliveryType(string deliveryId)
        {
            Hashtable htGetDeliveryType = new Hashtable();
            htGetDeliveryType.Add("@c_delivery_system_id_pk", deliveryId);
            DataTable dtDeliveryType = new DataTable();
            string deliveryType;
            try
            {
                dtDeliveryType = DataProxy.FetchDataTable("s_sp_get_delivery_type", htGetDeliveryType);
                if (!string.IsNullOrEmpty(dtDeliveryType.Rows[0]["s_delivery_type_id"].ToString()))
                {
                    deliveryType = dtDeliveryType.Rows[0]["s_delivery_type_id"].ToString();
                    return deliveryType;
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePriority(string updatexml)
        {
            Hashtable htUpdatePriority = new Hashtable();
            htUpdatePriority.Add("@updatexml", updatexml);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_waitlist_priority", htUpdatePriority);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteWaitlist(string waitlistId, string courseId, string deliveryId)
        {
            Hashtable htDeleteWaitlist = new Hashtable();
            htDeleteWaitlist.Add("@e_enroll_waitlist_system_id_pk", waitlistId);
            htDeleteWaitlist.Add("@e_enroll_course_id_fk", courseId);
            htDeleteWaitlist.Add("@e_enroll_delivery_id_fk", deliveryId);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_waitlist", htDeleteWaitlist);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
