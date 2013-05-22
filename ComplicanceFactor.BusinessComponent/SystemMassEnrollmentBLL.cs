using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
namespace ComplicanceFactor.BusinessComponent
{
    public  class SystemMassEnrollmentBLL
    {   
        /// <summary>
        /// Search course and curriculum
        /// </summary>
        /// <param name="course_curriculum"></param>
        /// <returns></returns>
        public static DataTable SearchCourseCurriculum(SystemMassEnrollment course_curriculum)
        {
            Hashtable htSearchCourseCurriculum = new Hashtable();
            htSearchCourseCurriculum.Add("@c_course_curriculum_id_pk", course_curriculum.c_course_curriculumId);
            htSearchCourseCurriculum.Add("@c_course_curriculum_title", course_curriculum.c_course_curriculum_title);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_curriculum_mass_enrollment", htSearchCourseCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        ///  Enroll course, course assign, curriculum assign
        /// </summary>
        /// <param name="CourseEnroll"></param>
        /// <param name="CourseAssign"></param>
        /// <param name="Curriculum"></param>
        /// <param name="course_assign_by_id"></param>
        /// <returns></returns>
        public static DataTable EnrollCourseAssignCurriculum(string CourseEnroll, string CourseAssign, string Curriculum, string course_assign_by_id)
        {
            Hashtable htEnrollCourseAssignCurriculum = new Hashtable();
            htEnrollCourseAssignCurriculum.Add("@CourseEnroll", CourseEnroll);
            htEnrollCourseAssignCurriculum.Add("@CourseAssign", CourseAssign);
            htEnrollCourseAssignCurriculum.Add("@Curriculum", Curriculum);
            htEnrollCourseAssignCurriculum.Add("@course_assign_by_id", course_assign_by_id);
            try
            {
                return DataProxy.FetchDataTable("s_sp_enroll_course_assign_curriculum_for_mass_enrollment", htEnrollCourseAssignCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
