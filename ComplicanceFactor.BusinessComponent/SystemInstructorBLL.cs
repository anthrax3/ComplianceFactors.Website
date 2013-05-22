using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemInstructorBLL
    {
        /// <summary>
        /// Insert instructor course
        /// </summary>
        /// <param name="c_instructor_course"></param>
        /// <returns></returns>
        public static int InsertInstructorCourse(string c_instructor_course)
        {
            Hashtable htInsertInstructorCourse = new Hashtable();
            htInsertInstructorCourse.Add("@c_instructor_course", c_instructor_course);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_insert_instructor_courses", htInsertInstructorCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Get instructor course
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInstructorCourse(string c_instructor_id_fk)
        {
            Hashtable htGetInstructorCourse = new Hashtable();
            htGetInstructorCourse.Add("@c_instructor_id_fk", c_instructor_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_instructor_course",htGetInstructorCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete instructor course
        /// </summary>
        /// <param name="c_instructor_course_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteInstructorCourse(string c_instructor_course_system_id_pk)
        {
            Hashtable htDeleteInstructorCourse = new Hashtable();
            htDeleteInstructorCourse.Add("@c_instructor_course_system_id_pk", c_instructor_course_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_delete_instructor_course", htDeleteInstructorCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchSystemCatalog(ManageCourse course)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", course.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", course.c_course_title);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_for_instructor", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
