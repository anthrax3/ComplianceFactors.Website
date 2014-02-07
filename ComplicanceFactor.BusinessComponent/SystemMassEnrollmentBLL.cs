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
        public static DataTable GetSingleCurriculaPathCourse(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            Hashtable htEnrollGetSingleCurriculaPathCourse = new Hashtable();
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htEnrollGetSingleCurriculaPathCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_single_curricula_path_course_for_mass_enrollment", htEnrollGetSingleCurriculaPathCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Newly added
        public static DataTable SearchCourse(string courseid, string coursetitle)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", courseid);
            htSearchCourse.Add("@c_course_title", coursetitle);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_mass_enrollment_from_user", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchCurriculum(string curriculumid, string curriculumtitle)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_curriculum_id_pk", curriculumid);
            htSearchCourse.Add("@c_curriculum_title", curriculumtitle);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_curriculum_mass_enrollment_from_user", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //s_sp_course_enroll_assign_mass_enrollment_from_user

        public static DataTable Course_Enroll_Assign(string CourseEnroll, string CourseAssign, string course_assign_by_id)
        {
            Hashtable htEnrollCourseAssign = new Hashtable();
            htEnrollCourseAssign.Add("@CourseEnroll", CourseEnroll);
            htEnrollCourseAssign.Add("@CourseAssign", CourseAssign);
            htEnrollCourseAssign.Add("@course_assign_by_id", course_assign_by_id);
            try
            {
                return DataProxy.FetchDataTable("s_sp_course_enroll_assign_mass_enrollment_from_user", htEnrollCourseAssign);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet Curriculum_Assign(string Curriculum, string course_assign_by_id)
        {
            Hashtable htCurriculumAssign = new Hashtable();
            htCurriculumAssign.Add("@Curriculum", Curriculum);
            htCurriculumAssign.Add("@course_assign_by_id", course_assign_by_id);
            try
            {
                return DataProxy.FetchDataSet("s_sp_curriculum_assign_mass_enrollment_from_user", htCurriculumAssign);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
