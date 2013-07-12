using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDataImportExportBLL
    {
        /// <summary>
        /// Get facilitis DataTable
        /// </summary>
        /// <returns></returns>
        /// 
        public static DataTable GetFacilities()
        {
            return DataProxy.FetchDataTable("s_sp_get_facilities");
        }

        /// <summary>
        /// Get Hris DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHris()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms");
        }

        /// <summary>
        /// Get Rooms DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRooms()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms");
        }

        /// <summary>
        /// Get Courses DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCourses()
        {
            return DataProxy.FetchDataTable("s_sp_get_course");
        }

        /// <summary>
        /// Get Curriculum DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurriculum()
        {
            return DataProxy.FetchDataTable("s_sp_get_curriculum");
        }
        /// <summary>
        /// Get Enrollments DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEnrollments()
        {
            return DataProxy.FetchDataTable("s_sp_get_enrollments");
        }
        /// <summary>
        /// Get LearningHistory DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLearningHisory()
        {
            return DataProxy.FetchDataTable("s_sp_get_learning_history");
        }
    }
}
