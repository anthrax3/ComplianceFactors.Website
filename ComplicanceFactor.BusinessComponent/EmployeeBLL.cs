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
    public class EmployeeBLL
    {
       

        public static DataSet GetAllEmployee(string user_id_fk)
        {
            try
            {
                Hashtable htGetAllEmployee = new Hashtable();

                if (user_id_fk != null)
                {
                    htGetAllEmployee.Add("@e_user_id_fk", user_id_fk);
                }
                else
                {
                    htGetAllEmployee.Add("@e_user_id_fk", DBNull.Value);
                }
                return DataProxy.FetchDataSet("e_sp_get_all_employee",htGetAllEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataSet GetCoursePDFExcel(string e_user_id_fk, string s_locale_culture)
        {
            try
            {
                Hashtable htGetCoursePDFExcel = new Hashtable();

                htGetCoursePDFExcel.Add("@e_user_id_fk", e_user_id_fk);
                htGetCoursePDFExcel.Add("@s_locale_culture", s_locale_culture);

                return DataProxy.FetchDataSet("e_sp_create_course_pdf", htGetCoursePDFExcel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// it get the employee based on the manager user id
        /// </summary>
        /// <param name="user_id_fk"></param>
        /// <returns>u_user_id_pk,u_firstname and u_last_name</returns>
        public static DataSet GetEmployeeByManager(string user_id_fk, string u_name, string course_id_or_curriculum_id, bool check_id)
        {
            try
            {
                Hashtable htGetEmployeeByManager = new Hashtable();
                htGetEmployeeByManager.Add("@u_user_id_fk", user_id_fk);
                if (!string.IsNullOrEmpty(u_name))
                {
                    htGetEmployeeByManager.Add("@u_name", u_name);
                }
                else
                {
                    htGetEmployeeByManager.Add("@u_name", DBNull.Value);
                }
                htGetEmployeeByManager.Add("@course_id_or_curriculum_id", course_id_or_curriculum_id);
                htGetEmployeeByManager.Add("@check_id", check_id);
                return DataProxy.FetchDataSet("e_sp_get_employee_list_by_manager", htGetEmployeeByManager);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
