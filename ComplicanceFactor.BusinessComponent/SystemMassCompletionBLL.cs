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
    public class SystemMassCompletionBLL
    {
        public static DataTable GetDelivery(string courseId)
        {
            Hashtable htGetDelivery = new Hashtable();
            htGetDelivery.Add("@c_course_id_fk", courseId);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_delivery_by_course", htGetDelivery);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchCourse(ManageCourse catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_mass_completion", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchUser(User user)
        {
            Hashtable htSearchUser = new Hashtable();
            htSearchUser.Add("@EmployeeName", user.Firstname);
            htSearchUser.Add("@EmployeeId", user.Hris_employeid);            
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_user_for_mass_completion", htSearchUser);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
