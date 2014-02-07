using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemMassRemovalBLL
    {
        public static int CourseCurriculumRemoval(string s_drop_course_delivery, string s_drop_course, string Curriculum)
        {
            Hashtable htCourseCurriculumRemoval = new Hashtable();
            if (!string.IsNullOrEmpty(s_drop_course_delivery))
            {
                htCourseCurriculumRemoval.Add("@s_drop_course_delivery", s_drop_course_delivery);
            }
            else
            {
                htCourseCurriculumRemoval.Add("@s_drop_course_delivery", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_drop_course))
            {
                htCourseCurriculumRemoval.Add("@s_drop_course", s_drop_course);
            }
            else
            {
                htCourseCurriculumRemoval.Add("@s_drop_course", DBNull.Value);
            }            
           
            if (!string.IsNullOrEmpty(Curriculum))
            {
                htCourseCurriculumRemoval.Add("@Curriculum", Curriculum);
            }
            else
            {
                htCourseCurriculumRemoval.Add("@Curriculum", DBNull.Value);
            }
             
            try
            {
                return DataProxy.FetchSPOutput("s_sp_remove_course_assign_curriculum_for_mass_removal", htCourseCurriculumRemoval);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
