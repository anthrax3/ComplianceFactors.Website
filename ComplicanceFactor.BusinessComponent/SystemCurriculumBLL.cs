using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data.SqlTypes;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemCurriculumBLL
    {
        /// <summary>
        /// Get Curriculum Status
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurriculumStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_curriculum_sp_get_status", htGetStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Get Curriculum All Status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_curriculum_sp_get_all_status", htGetStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Get Curriculum Type
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurriculumType()
        {
            try
            {
                return DataProxy.FetchDataTable("c_curriculum_sp_get_type");
            }
            catch (Exception)
            {
                throw;
            }
        }
       /// <summary>
       /// Get Cuuriculum Type Main
       /// </summary>
       /// <returns></returns>
        public static DataTable Getcurriculumtype(string s_ui_locale_name)
        {
            Hashtable htGetCurriculumType = new Hashtable();
            htGetCurriculumType.Add("@s_locale", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataTable("c_curriculum_sp_get_curriculum_type", htGetCurriculumType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Search Curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        public static DataTable SearchSystemCurriculum(SystemCurriculum curriculum)
        {
            Hashtable htSearchCurriculum = new Hashtable();
            htSearchCurriculum.Add("@c_curriculum_id_pk", curriculum.c_curriculum_id_pk);
            htSearchCurriculum.Add("@c_curriculum_title", curriculum.c_curriculum_title);
            htSearchCurriculum.Add("@c_curriculum_version", curriculum.c_curriculum_version);

            if (curriculum.c_curriculum_active_type_id_fk == "0")
                htSearchCurriculum.Add("@c_curriculum_active_type_id_fk", DBNull.Value);
            else
                htSearchCurriculum.Add("@c_curriculum_active_type_id_fk", curriculum.c_curriculum_active_type_id_fk);

            htSearchCurriculum.Add("@c_curriculum_owner_name", curriculum.c_curriculum_owner_name);
            htSearchCurriculum.Add("@c_curriculum_coordinator_name", curriculum.c_curriculum_coordinator_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_search_curriculum", htSearchCurriculum);
            }
            catch (Exception)
            {
                throw;
            }

        }
        ///// <summary>
        ///// Get Approval
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable dGetApproval()
        //{

        //    try
        //    {
        //        return DataProxy.FetchDataTable("c_curriculum_sp_get_approval");

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// Create Curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        public static int CreateCurriculum(SystemCurriculum curriculum)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Hashtable htNewCurriculum = new Hashtable();
            htNewCurriculum.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htNewCurriculum.Add("@c_curriculum_id_pk", curriculum.c_curriculum_id_pk);
            htNewCurriculum.Add("@c_curriculum_title", curriculum.c_curriculum_title);
            htNewCurriculum.Add("@c_curriculum_desc", curriculum.c_curriculum_desc);
            htNewCurriculum.Add("@c_curriculum_abstract", curriculum.c_curriculum_abstract);
            htNewCurriculum.Add("@c_curriculum_icon_uri", curriculum.c_curriculum_icon_uri);
            htNewCurriculum.Add("@c_curriculum_icon_uri_file_name", curriculum.c_curriculum_icon_uri_file_name);
            htNewCurriculum.Add("@c_curriculum_version", curriculum.c_curriculum_version);
            htNewCurriculum.Add("@c_curriculum_approval_req", curriculum.c_curriculum_approval_req);

            if (curriculum.c_curriculum_approval_id_fk != "0")
            {
                htNewCurriculum.Add("@c_curriculum_approval_id_fk", curriculum.c_curriculum_approval_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_approval_id_fk", DBNull.Value);
            }
            if (curriculum.c_curriculum_credit_hours != null)
            {
                htNewCurriculum.Add("@c_curriculum_credit_hours", curriculum.c_curriculum_credit_hours);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_credit_hours", DBNull.Value);
            }
            if (curriculum.c_curriculum_credit_units != null)
            {
                htNewCurriculum.Add("@c_curriculum_credit_units", curriculum.c_curriculum_credit_units);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_credit_units", DBNull.Value);
            }
            htNewCurriculum.Add("@c_curriculum_created_by_id_fk", curriculum.c_curriculum_created_by_id_fk);
            htNewCurriculum.Add("@c_curriculum_cert_flag", curriculum.c_curriculum_cert_flag);

            if (curriculum.c_curriculum_recurrance_grace_days != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_grace_days", curriculum.c_curriculum_recurrance_grace_days);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_owner_id_fk))
            {
                htNewCurriculum.Add("@c_curriculum_owner_id_fk", curriculum.c_curriculum_owner_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_owner_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_coordinator_id_fk))
            {
                htNewCurriculum.Add("@c_curriculum_coordinator_id_fk", curriculum.c_curriculum_coordinator_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_coordinator_id_fk", DBNull.Value);
            }

            htNewCurriculum.Add("@c_curriculum_active_flag", curriculum.c_curriculum_active_flag);
            htNewCurriculum.Add("@c_curriculum_active_type_id_fk", curriculum.c_curriculum_active_type_id_fk);
            htNewCurriculum.Add("@c_curriculum_visible_flag", curriculum.c_curriculum_visible_flag);

            if (curriculum.c_curriculum_available_from_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_available_from_date", curriculum.c_curriculum_available_from_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_available_from_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_available_to_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_available_to_date", curriculum.c_curriculum_available_to_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_available_to_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_effective_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_effective_date", curriculum.c_curriculum_effective_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_effective_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_cut_off_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_cut_off_date", curriculum.c_curriculum_cut_off_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_cut_off_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_cut_off_time != null)
            {
                htNewCurriculum.Add("@c_curriculum_cut_off_time", curriculum.c_curriculum_cut_off_time);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_cut_off_time", DBNull.Value);
            }

            htNewCurriculum.Add("@c_curriculum_custom_01", curriculum.c_curriculum_custom_01);
            htNewCurriculum.Add("@c_curriculum_custom_02", curriculum.c_curriculum_custom_02);
            htNewCurriculum.Add("@c_curriculum_custom_03", curriculum.c_curriculum_custom_03);
            htNewCurriculum.Add("@c_curriculum_custom_04", curriculum.c_curriculum_custom_04);
            htNewCurriculum.Add("@c_curriculum_custom_05", curriculum.c_curriculum_custom_05);
            htNewCurriculum.Add("@c_curriculum_custom_06", curriculum.c_curriculum_custom_06);
            htNewCurriculum.Add("@c_curriculum_custom_07", curriculum.c_curriculum_custom_07);
            htNewCurriculum.Add("@c_curriculum_custom_08", curriculum.c_curriculum_custom_08);
            htNewCurriculum.Add("@c_curriculum_custom_09", curriculum.c_curriculum_custom_09);
            htNewCurriculum.Add("@c_curriculum_custom_10", curriculum.c_curriculum_custom_10);
            htNewCurriculum.Add("@c_curriculum_custom_11", curriculum.c_curriculum_custom_11);
            htNewCurriculum.Add("@c_curriculum_custom_12", curriculum.c_curriculum_custom_12);
            htNewCurriculum.Add("@c_curriculum_custom_13", curriculum.c_curriculum_custom_13);


            htNewCurriculum.Add("@c_curriculum_prerequisite", curriculum.c_curriculum_Prerequistist);
            htNewCurriculum.Add("@c_curriculum_equivalencies", curriculum.c_curriculum_Equivalencies);
            htNewCurriculum.Add("@c_curriculum_fulfillments", curriculum.c_curriculum_Fulfillments);
            htNewCurriculum.Add("@c_curriculum_domain", curriculum.c_curriculum_domain);
            htNewCurriculum.Add("@c_curriculum_audience", curriculum.c_curriculum_audience);
            htNewCurriculum.Add("@c_curriculum_category", curriculum.c_curriculum_category);
            htNewCurriculum.Add("@c_curriculum_attachment", curriculum.c_curriculum_attachment);
            

            if (curriculum.c_curriculum_type_id_fk != null)
            {
                htNewCurriculum.Add("@c_curriculum_type_id_fk", curriculum.c_curriculum_type_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_type_id_fk", DBNull.Value);
            }




            if (curriculum.c_curriculum_recurrance_every != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_every", curriculum.c_curriculum_recurrance_every);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_every", DBNull.Value);
            }
            htNewCurriculum.Add("@c_curriculum_recurrance_period", curriculum.c_curriculum_recurrance_period);
            htNewCurriculum.Add("@c_curriculum_recurance_date_option", curriculum.c_curriculum_recurance_date_option);


            if (curriculum.c_curriculum_recurance_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurance_date", curriculum.c_curriculum_recurance_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurance_date", DBNull.Value);
            }
            if (curriculum.c_curriculum_cert_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_cert_date", curriculum.c_curriculum_cert_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_cert_date", DBNull.Value);
            }
            if (curriculum.c_curriculum_cost != null)
            {
                htNewCurriculum.Add("@c_curriculum_cost", curriculum.c_curriculum_cost);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_cost", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_insert_curriculum", htNewCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>

        public static int UpdateCurriculum(SystemCurriculum curriculum)
        {
            Hashtable htUpdateCurriculum = new Hashtable();
            htUpdateCurriculum.Add("@c_curriculum_id_pk", curriculum.c_curriculum_id_pk);
            htUpdateCurriculum.Add("@c_curriculum_desc", curriculum.c_curriculum_desc);
            htUpdateCurriculum.Add("@c_curriculum_abstract", curriculum.c_curriculum_abstract);
            htUpdateCurriculum.Add("@c_curriculum_icon_uri", curriculum.c_curriculum_icon_uri);
            htUpdateCurriculum.Add("@c_curriculum_version", curriculum.c_curriculum_version);
            htUpdateCurriculum.Add("@c_curriculum_approval_req", curriculum.c_curriculum_approval_req);
            if (curriculum.c_curriculum_approval_id_fk != "0")
            {
                htUpdateCurriculum.Add("@c_curriculum_approval_id_fk", curriculum.c_curriculum_approval_id_fk);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_approval_id_fk", DBNull.Value);
            }
            if (curriculum.c_curriculum_type_id_fk != "0")
            {
                htUpdateCurriculum.Add("@c_curriculum_type_id_fk", curriculum.c_curriculum_type_id_fk);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_type_id_fk", DBNull.Value);
            }
            if (curriculum.c_curriculum_credit_hours != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_credit_hours", curriculum.c_curriculum_credit_hours);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_credit_hours", DBNull.Value);

            }
            if (curriculum.c_curriculum_credit_units != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_credit_units", curriculum.c_curriculum_credit_units);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_credit_units", DBNull.Value);
            }
            htUpdateCurriculum.Add("@c_curriculum_cert_flag", curriculum.c_curriculum_cert_flag);

            if (curriculum.c_curriculum_recurrance_grace_days != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_recurrance_grace_days", curriculum.c_curriculum_recurrance_grace_days);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_recurrance_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_owner_id_fk))
            {
                htUpdateCurriculum.Add("@c_curriculum_owner_id_fk", curriculum.c_curriculum_owner_id_fk);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_owner_id_fk", DBNull.Value);
            }
            htUpdateCurriculum.Add("@c_curriculum_icon_uri_file_name", curriculum.c_curriculum_icon_uri_file_name);

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_coordinator_id_fk))
            {
                htUpdateCurriculum.Add("@c_curriculum_coordinator_id_fk", curriculum.c_curriculum_coordinator_id_fk);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_coordinator_id_fk", DBNull.Value);
            }
            htUpdateCurriculum.Add("@c_curriculum_active_flag", curriculum.c_curriculum_active_flag);
            htUpdateCurriculum.Add("@c_curriculum_active_type_id_fk", curriculum.c_curriculum_active_type_id_fk);
            htUpdateCurriculum.Add("@c_curriculum_visible_flag", curriculum.c_curriculum_visible_flag);

            if (curriculum.c_curriculum_available_from_date != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_available_from_date", curriculum.c_curriculum_available_from_date);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_available_from_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_available_to_date != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_available_to_date", curriculum.c_curriculum_available_to_date);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_available_to_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_effective_date != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_effective_date", curriculum.c_curriculum_effective_date);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_effective_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_cut_off_date != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_cut_off_date", curriculum.c_curriculum_cut_off_date);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_cut_off_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_cut_off_time != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_cut_off_time", curriculum.c_curriculum_cut_off_time);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_cut_off_time", DBNull.Value);
            }
            
            htUpdateCurriculum.Add("@c_curriculum_custom_01", curriculum.c_curriculum_custom_01);
            htUpdateCurriculum.Add("@c_curriculum_custom_02", curriculum.c_curriculum_custom_02);
            htUpdateCurriculum.Add("@c_curriculum_custom_03", curriculum.c_curriculum_custom_03);
            htUpdateCurriculum.Add("@c_curriculum_custom_04", curriculum.c_curriculum_custom_04);
            htUpdateCurriculum.Add("@c_curriculum_custom_05", curriculum.c_curriculum_custom_05);
            htUpdateCurriculum.Add("@c_curriculum_custom_06", curriculum.c_curriculum_custom_06);
            htUpdateCurriculum.Add("@c_curriculum_custom_07", curriculum.c_curriculum_custom_07);
            htUpdateCurriculum.Add("@c_curriculum_custom_08", curriculum.c_curriculum_custom_08);
            htUpdateCurriculum.Add("@c_curriculum_custom_09", curriculum.c_curriculum_custom_09);
            htUpdateCurriculum.Add("@c_curriculum_custom_10", curriculum.c_curriculum_custom_10);
            htUpdateCurriculum.Add("@c_curriculum_custom_11", curriculum.c_curriculum_custom_11);
            htUpdateCurriculum.Add("@c_curriculum_custom_12", curriculum.c_curriculum_custom_12);
            htUpdateCurriculum.Add("@c_curriculum_custom_13", curriculum.c_curriculum_custom_13);
            htUpdateCurriculum.Add("@c_curriculum_title", curriculum.c_curriculum_title);
            htUpdateCurriculum.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            

            if (curriculum.c_curriculum_recurrance_every != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_recurrance_every", curriculum.c_curriculum_recurrance_every);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_recurrance_every", DBNull.Value);
            }
            htUpdateCurriculum.Add("@c_curriculum_recurrance_period", curriculum.c_curriculum_recurrance_period);
            htUpdateCurriculum.Add("@c_curriculum_recurance_date_option", curriculum.c_curriculum_recurance_date_option);


            if (curriculum.c_curriculum_recurance_date != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_recurance_date", curriculum.c_curriculum_recurance_date);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_recurance_date", DBNull.Value);
            }

            if (curriculum.c_curriculum_cost != null)
            {
                htUpdateCurriculum.Add("@c_curriculum_cost", curriculum.c_curriculum_cost);
            }
            else
            {
                htUpdateCurriculum.Add("@c_curriculum_cost", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curricula_master", htUpdateCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Prerequisite Equivalencies and Fullfillments
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetprerequisiteEquivalenciesFullfillments(string c_curriculum_system_id_pk)
        {
            Hashtable htCurriculum = new Hashtable();
            htCurriculum.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
            try
            {
                return DataProxy.FetchDataSet("c_curriculum_sp_get_prerequisite_equivalencies_fullfillments", htCurriculum);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///// <summary>
        ///// UpdateSystemCurriculumPrerequistist
        ///// </summary>
        ///// <param name="curriculum"></param>
        ///// <returns></returns>
        public static int UpdateSystemCurriculumPrerequistist(SystemCurriculum curriculum)
        {
            Hashtable htUpdateCurriculumPrerequistist = new Hashtable();
            htUpdateCurriculumPrerequistist.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htUpdateCurriculumPrerequistist.Add("@c_curriculum_prerequistist", curriculum.c_curriculum_Prerequistist);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htUpdateCurriculumPrerequistist.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htUpdateCurriculumPrerequistist.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curriculum_prerequistist", htUpdateCurriculumPrerequistist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///// <summary>
        ///// UpdateSystemCurriculum Equivalencies
        ///// </summary>
        ///// <param name="curriculum"></param>
        ///// <returns></returns>
        public static int UpdateSystemCurriculumEquivalencies(SystemCurriculum curriculum)
        {
            Hashtable htUpdateCurriculumEquivalencies = new Hashtable();
            htUpdateCurriculumEquivalencies.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htUpdateCurriculumEquivalencies.Add("@c_curriculum_equivalencies", curriculum.c_curriculum_Equivalencies);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htUpdateCurriculumEquivalencies.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htUpdateCurriculumEquivalencies.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curriculum_equivalencies", htUpdateCurriculumEquivalencies);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateSystemCurriculum Fulfillments
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        public static int UpdateSystemCurriculumFulfillments(SystemCurriculum curriculum)
        {
            Hashtable htUpdateCurriculumFulfillments = new Hashtable();
            htUpdateCurriculumFulfillments.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htUpdateCurriculumFulfillments.Add("@c_curriculum_fulfillments", curriculum.c_curriculum_Fulfillments);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htUpdateCurriculumFulfillments.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htUpdateCurriculumFulfillments.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curriculum_fulfillments", htUpdateCurriculumFulfillments);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get Curriculum
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns>Single curriculum record</returns>
        public static DataTable GetCurriculumCatgory(string c_curriculum_system_id_pk)
        {
            try
            {
                Hashtable htGetCurriculumCategory = new Hashtable();
                htGetCurriculumCategory.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
                return DataProxy.FetchDataTable("c_curriculum_sp_get_categories", htGetCurriculumCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Curriculum Domain
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumDomain(string c_curriculum_system_id_pk)
        {
            try
            {
                Hashtable htGetCurriculumDomain = new Hashtable();
                htGetCurriculumDomain.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
                return DataProxy.FetchDataTable("c_curriculum_sp_get_domain", htGetCurriculumDomain);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Curriculum
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCurriculum GetCurriculum(string c_curriculum_system_id_pk, string s_ui_locale_name)
        {
            SystemCurriculum curriculum;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCurriculum = new Hashtable();
                htGetCurriculum.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
                htGetCurriculum.Add("@s_ui_locale_name", s_ui_locale_name);
                curriculum = new SystemCurriculum();
                DataTable dtGetCurriculum = DataProxy.FetchDataSet("c_get_Particular_curriculum_Master", htGetCurriculum).Tables[0];
                curriculum.c_curriculum_system_id_pk = dtGetCurriculum.Rows[0]["c_curriculum_system_id_pk"].ToString();
                curriculum.c_curriculum_id_pk = dtGetCurriculum.Rows[0]["c_curriculum_id_pk"].ToString();
                curriculum.c_curriculum_desc = dtGetCurriculum.Rows[0]["c_curriculum_desc"].ToString();
                curriculum.c_curriculum_abstract = dtGetCurriculum.Rows[0]["c_curriculum_abstract"].ToString();
                curriculum.c_curriculum_icon_uri = dtGetCurriculum.Rows[0]["c_curriculum_icon_uri"].ToString();
                curriculum.c_curriculum_version = dtGetCurriculum.Rows[0]["c_curriculum_version"].ToString();
                curriculum.c_curriculum_approval_req = Convert.ToBoolean(dtGetCurriculum.Rows[0]["c_curriculum_approval_req"]);
                curriculum.c_curriculum_approval_id_fk = dtGetCurriculum.Rows[0]["c_curriculum_approval_id_fk"].ToString();
                curriculum.c_curriculum_type_id_fk = dtGetCurriculum.Rows[0]["c_curriculum_type_id_fk"].ToString();

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_credit_hours"].ToString()))
                {
                    curriculum.c_curriculum_credit_hours = Convert.ToInt32(dtGetCurriculum.Rows[0]["c_curriculum_credit_hours"]);
                }
                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_credit_units"].ToString()))
                {
                    curriculum.c_curriculum_credit_units = Convert.ToInt32(dtGetCurriculum.Rows[0]["c_curriculum_credit_units"]);
                }

                curriculum.c_created_name = dtGetCurriculum.Rows[0]["c_created_name"].ToString();
                curriculum.c_curriculum_cert_flag = Convert.ToBoolean(dtGetCurriculum.Rows[0]["c_curriculum_cert_flag"]);

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_recurrance_grace_days"].ToString()))
                {
                    curriculum.c_curriculum_recurrance_grace_days = Convert.ToInt32(dtGetCurriculum.Rows[0]["c_curriculum_recurrance_grace_days"]);
                }
                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_cost"].ToString()))
                {
                    curriculum.c_curriculum_cost = Convert.ToInt32(dtGetCurriculum.Rows[0]["c_curriculum_cost"]);
                }
                curriculum.c_curriculum_owner_id_fk = dtGetCurriculum.Rows[0]["c_curriculum_owner_id_fk"].ToString();
                curriculum.c_curriculum_coordinator_id_fk = dtGetCurriculum.Rows[0]["c_curriculum_coordinator_id_fk"].ToString();

                curriculum.c_curriculum_active_flag = Convert.ToBoolean(dtGetCurriculum.Rows[0]["c_curriculum_active_flag"]);
                curriculum.c_curriculum_icon_uri_file_name = dtGetCurriculum.Rows[0]["c_curriculum_icon_uri_file_name"].ToString();
                curriculum.c_curriculum_active_type_id_fk = dtGetCurriculum.Rows[0]["c_curriculum_active_type_id_fk"].ToString();
                curriculum.c_curriculum_visible_flag = Convert.ToBoolean(dtGetCurriculum.Rows[0]["c_curriculum_visible_flag"]);

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_available_from_date"].ToString()))
                {
                    curriculum.c_curriculum_available_from_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_available_from_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_available_to_date"].ToString()))
                {
                    curriculum.c_curriculum_available_to_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_available_to_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_effective_date"].ToString()))
                {
                    curriculum.c_curriculum_effective_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_effective_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_cut_off_date"].ToString()))
                {
                    curriculum.c_curriculum_cut_off_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_cut_off_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_cut_off_time"].ToString()))
                {
                    //DateTime temprecurancedate;
                    //DateTime.TryParseExact(dtGetCurriculum.Rows[0]["c_curriculum_cut_off_time"].ToString(), "h:mm tt", culture, DateTimeStyles.None, out temprecurancedate);
                    //curriculum.c_curriculum_cut_off_time = temprecurancedate;
                    curriculum.c_curriculum_cut_off_time_string = dtGetCurriculum.Rows[0]["c_curriculum_cut_off_time"].ToString();
                }


                curriculum.c_curriculum_custom_01 = dtGetCurriculum.Rows[0]["c_curriculum_custom_01"].ToString();
                curriculum.c_curriculum_custom_02 = dtGetCurriculum.Rows[0]["c_curriculum_custom_02"].ToString();
                curriculum.c_curriculum_custom_03 = dtGetCurriculum.Rows[0]["c_curriculum_custom_03"].ToString();
                curriculum.c_curriculum_custom_04 = dtGetCurriculum.Rows[0]["c_curriculum_custom_04"].ToString();
                curriculum.c_curriculum_custom_05 = dtGetCurriculum.Rows[0]["c_curriculum_custom_05"].ToString();
                curriculum.c_curriculum_custom_06 = dtGetCurriculum.Rows[0]["c_curriculum_custom_06"].ToString();
                curriculum.c_curriculum_custom_07 = dtGetCurriculum.Rows[0]["c_curriculum_custom_07"].ToString();
                curriculum.c_curriculum_custom_08 = dtGetCurriculum.Rows[0]["c_curriculum_custom_08"].ToString();
                curriculum.c_curriculum_custom_09 = dtGetCurriculum.Rows[0]["c_curriculum_custom_09"].ToString();
                curriculum.c_curriculum_custom_10 = dtGetCurriculum.Rows[0]["c_curriculum_custom_10"].ToString();
                curriculum.c_curriculum_custom_11 = dtGetCurriculum.Rows[0]["c_curriculum_custom_11"].ToString();
                curriculum.c_curriculum_custom_12 = dtGetCurriculum.Rows[0]["c_curriculum_custom_12"].ToString();
                curriculum.c_curriculum_custom_13 = dtGetCurriculum.Rows[0]["c_curriculum_custom_13"].ToString();
                curriculum.c_curriculum_title = dtGetCurriculum.Rows[0]["c_curriculum_title"].ToString();

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_recurrance_every"].ToString()))
                {
                    curriculum.c_curriculum_recurrance_every = Convert.ToInt32(dtGetCurriculum.Rows[0]["c_curriculum_recurrance_every"]);
                }
                curriculum.c_curriculum_recurrance_period = dtGetCurriculum.Rows[0]["c_curriculum_recurrance_period"].ToString();
                curriculum.c_curriculum_recurance_date_option = dtGetCurriculum.Rows[0]["c_curriculum_recurance_date_option"].ToString();
                curriculum.c_curriculum_owner_name = dtGetCurriculum.Rows[0]["ownername"].ToString();
                curriculum.c_curriculum_coordinator_name = dtGetCurriculum.Rows[0]["coordinatorname"].ToString();

                curriculum.cost_text = dtGetCurriculum.Rows[0]["cost_text"].ToString();
                curriculum.c_curriculum_status_name = dtGetCurriculum.Rows[0]["c_curriculum_status_name"].ToString();
                curriculum.c_curriculum_visible_flag_text = dtGetCurriculum.Rows[0]["c_curriculum_visible_flag_text"].ToString();
                curriculum.c_curriculum_approval_name = dtGetCurriculum.Rows[0]["s_approval_workflow_name_us_english"].ToString();
                curriculum.c_curriculum_recurrences_text = dtGetCurriculum.Rows[0]["c_curriculum_recurrences_text"].ToString();
                curriculum.c_curriculum_approval_req_text = dtGetCurriculum.Rows[0]["c_curriculum_approval_req_text"].ToString();
                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_recurance_date"].ToString()))
                {
                    curriculum.c_curriculum_recurance_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_recurance_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCurriculum.Rows[0]["c_curriculum_cert_date"].ToString()))
                {
                    curriculum.c_curriculum_cert_date = Convert.ToDateTime(dtGetCurriculum.Rows[0]["c_curriculum_cert_date"], culture);
                }

                return curriculum;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Prerequisitie
        /// </summary>
        public static int DeletePrerequisite(SystemCurriculum curriculum)
        {
            Hashtable htDeletePrerequisite = new Hashtable();
            htDeletePrerequisite.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htDeletePrerequisite.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htDeletePrerequisite.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_prerequisite", htDeletePrerequisite);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Equivalencies
        /// </summary>
        public static int DeleteEquivalencies(SystemCurriculum curriculum)
        {
            Hashtable htDeleteEquivalencies = new Hashtable();
            htDeleteEquivalencies.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htDeleteEquivalencies.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htDeleteEquivalencies.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_equivalencies", htDeleteEquivalencies);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Fulfillments
        /// </summary>
        public static int DeleteFulfillments(SystemCurriculum curriculum)
        {
            Hashtable htDeleteFulfillments = new Hashtable();
            htDeleteFulfillments.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htDeleteFulfillments.Add("@c_related_curriculum_group_id", curriculum.c_related_curriculum_group_id);
            }
            else
            {
                htDeleteFulfillments.Add("@c_related_curriculum_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_fulfillments", htDeleteFulfillments);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///<summary>
        ///update icon uri
        ///</summary>
        public static int UpdateIcon(SystemCurriculum curriculum)
        {
            Hashtable htUpdateIcone = new Hashtable();
            htUpdateIcone.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htUpdateIcone.Add("@c_curriculum_icon_uri", curriculum.c_curriculum_icon_uri);
            htUpdateIcone.Add("@c_curriculum_icon_uri_file_name", curriculum.c_curriculum_icon_uri_file_name);
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_update_icon_uri", htUpdateIcone);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///<summary>
        ///Remove icon uri
        ///</summary>
        public static int RemoveIcon(SystemCurriculum curriculum)
        {
            Hashtable htUpdateIcone = new Hashtable();
            htUpdateIcone.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_icon_uri", htUpdateIcone);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Category
        /// </summary>
        public static int DeleteCategory(SystemCurriculum categories)
        {
            Hashtable htDeleteCategory = new Hashtable();
            htDeleteCategory.Add("@c_related_category_id_fk", categories.c_related_category_id_fk);
            htDeleteCategory.Add("@c_curriculum_id_fk", categories.c_curriculum_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_categories", htDeleteCategory);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Category
        /// </summary>
        public static int InsertCategory(string c_related_category_id_fk, string c_curriculum_system_id_pk)
        {
            Hashtable htInsertCategory = new Hashtable();

            htInsertCategory.Add("@c_related_category_id_fk", c_related_category_id_fk);
            htInsertCategory.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_insert_categories", htInsertCategory);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Domain
        /// </summary>
        public static int InsertDomain(string c_related_domain_id_fk, string c_curriculum_system_id_pk)
        {
            Hashtable htInsertDomain = new Hashtable();

            htInsertDomain.Add("@c_related_domain_id_fk", c_related_domain_id_fk);
            htInsertDomain.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_insert_domain", htInsertDomain);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get Attchments
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumAttchments(string c_curriculum_system_id_pk)
        {
            try
            {
                Hashtable htGetCurriculumAttachments = new Hashtable();
                htGetCurriculumAttachments.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
                return DataProxy.FetchDataTable("c_curriculum_sp_get_attachments", htGetCurriculumAttachments);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Attachments
        /// </summary>
        /// <param name="updateDeliveryAttachment"></param>
        /// <returns></returns>
        public static int UpdateCurriculumAttachment(SystemCurriculum updateDeliveryAttachment)
        {
            Hashtable htUpdateDeliveryAttachment = new Hashtable();

            htUpdateDeliveryAttachment.Add("@c_curriculum_attchments_system_id_pk", updateDeliveryAttachment.c_curriculum_attchments_system_id_pk);
            htUpdateDeliveryAttachment.Add("@c_curriculum_id_fk", updateDeliveryAttachment.c_curriculum_id_fk);
            htUpdateDeliveryAttachment.Add("@c_curriculum_attachment_file_guid", updateDeliveryAttachment.c_curriculum_attachment_file_guid);
            htUpdateDeliveryAttachment.Add("@c_curriculum_attachment_file_name", updateDeliveryAttachment.c_curriculum_attachment_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curriculum_attachment", htUpdateDeliveryAttachment);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert  Attchments
        /// </summary>
        /// <param name="insertCurriculumAttachment"></param>
        /// <returns></returns>
        public static int InsertCurriculumAttachment(SystemCurriculum insertCurriculumAttachment)
        {
            Hashtable htInsertcurriculumAttachment = new Hashtable();


            htInsertcurriculumAttachment.Add("@c_curriculum_id_fk", insertCurriculumAttachment.c_curriculum_id_fk);
            htInsertcurriculumAttachment.Add("@c_curriculum_attachment_file_guid", insertCurriculumAttachment.c_curriculum_attachment_file_guid);
            htInsertcurriculumAttachment.Add("@c_curriculum_attachment_file_name", insertCurriculumAttachment.c_curriculum_attachment_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_insert_curriculum_attachment", htInsertcurriculumAttachment);
            }
            catch
            {
                throw;
            }


        }
        /// <summary>
        /// Delete Attachment
        /// </summary>
        /// <param name="c_curriculum_attchments_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteCurriculumAttachment(string c_curriculum_attchments_system_id_pk)
        {
            Hashtable htDeleteCurriculumAttachment = new Hashtable();

            htDeleteCurriculumAttachment.Add("@c_curriculum_attchments_system_id_pk", c_curriculum_attchments_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_delete_curriculum_attachment", htDeleteCurriculumAttachment);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static int InsertCurriculumLocale(SystemCurriculum locale)
        {
            Hashtable htInsertCurriculumLocale = new Hashtable();
            htInsertCurriculumLocale.Add("@s_locale_id_fk", locale.s_locale_id_fk);
            htInsertCurriculumLocale.Add("@s_curriculum_system_id_fk", locale.s_curriculum_system_id_fk);
            htInsertCurriculumLocale.Add("@s_curriculum_locale_title", locale.s_curriculum_locale_title);
            htInsertCurriculumLocale.Add("@s_curriculum_locale_description", locale.s_curriculum_locale_description);
            htInsertCurriculumLocale.Add("@s_curriculum_locale_abstract", locale.s_curriculum_locale_abstract);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_curriculum_locale", htInsertCurriculumLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Locale
        /// </summary>
        /// <param name="s_curriculum_system_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumLocale(string s_curriculum_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_curriculum_system_id_fk", s_curriculum_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_curriculum_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Single Curriculum Locale
        /// </summary>
        /// <param name="s_curriculum_locales_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCurriculum GetSinglecurriculumLocale(string s_curriculum_locales_system_id_pk)
        {
            SystemCurriculum Locale;
            try
            {
                Locale = new SystemCurriculum();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_curriculum_locales_system_id_pk", s_curriculum_locales_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_curriculum_locale", htGetLocale);
                Locale.s_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_curriculum_locale_title = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_curriculum_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                Locale.s_curriculum_locale_abstract = dtGetLocale.Rows[0]["s_locale_abstract"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Update Curriculum Locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static int UpdateCurriculumLocale(SystemCurriculum locale)
        {
            Hashtable htUpdateCurriculumLocale = new Hashtable();
            htUpdateCurriculumLocale.Add("@s_curriculum_locales_system_id_pk", locale.s_curriculum_locales_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_curriculum_locale_title))
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_title", locale.s_curriculum_locale_title);
            }
            else
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_title", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_curriculum_locale_description))
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_description", locale.s_curriculum_locale_description);
            }
            else
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_curriculum_locale_abstract))
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_abstract", locale.s_curriculum_locale_abstract);
            }
            else
            {
                htUpdateCurriculumLocale.Add("@s_curriculum_locale_abstract", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_locale", htUpdateCurriculumLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Temp Get Locale
        /// </summary>
        /// <param name="s_curriculum_locales_system_id_pk"></param>
        /// <param name="dtTempLocale"></param>
        /// <returns></returns>
        public static SystemCurriculum TempGetOneLocale(string s_curriculum_locales_system_id_pk, DataTable dtTempLocale)
        {
            SystemCurriculum locale;
            try
            {
                locale = new SystemCurriculum();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_curriculum_locales_system_id_pk", s_curriculum_locales_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                locale.s_curriculum_locales_system_id_pk = dtGetLocale.Rows[0]["s_curriculum_locales_system_id_pk"].ToString();
                locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                locale.s_curriculum_locale_title = dtGetLocale.Rows[0]["s_curriculum_locale_title"].ToString();
                locale.s_curriculum_locale_description = dtGetLocale.Rows[0]["s_curriculum_locale_description"].ToString();
                locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                locale.s_curriculum_locale_abstract = dtGetLocale.Rows[0]["s_curriculum_locale_abstract"].ToString();
                return locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Delete Locale
        /// </summary>
        /// <param name="s_curriculum_system_id_fk"></param>
        /// <param name="s_curriculum_locale"></param>
        /// <param name="s_curriculum_locales_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteCurriculumLocale(string s_curriculum_system_id_fk, string s_curriculum_locale, string s_curriculum_locales_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_curriculum_system_id_fk))
            {
                htDeleteLocale.Add("@s_curriculum_system_id_fk", s_curriculum_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_curriculum_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_curriculum_locale))
            {
                htDeleteLocale.Add("@s_curriculum_locale", s_curriculum_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_curriculum_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_curriculum_locales_system_id_pk))
            {
                htDeleteLocale.Add("@s_curriculum_locales_system_id_pk", s_curriculum_locales_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_curriculum_locales_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_curriculum_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create Version
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        public static int CreateCurriculumNewVersion(SystemCurriculum curriculum)
        {
            Hashtable htNewVersion = new Hashtable();
            htNewVersion.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htNewVersion.Add("@c_new_curriculum_system_id_pk", curriculum.c_new_curriculum_system_id_pk);
            htNewVersion.Add("@c_curriculum_version", curriculum.c_curriculum_version);
            htNewVersion.Add("@c_category", curriculum.c_category);
            htNewVersion.Add("@c_domain", curriculum.c_domain);
            htNewVersion.Add("@c_audiences", curriculum.c_audiences);
            htNewVersion.Add("@c_recurrance", curriculum.c_recurrance);
            htNewVersion.Add("@c_prerequisite", curriculum.c_prerequisite);
            htNewVersion.Add("@c_equivalency", curriculum.c_equivalency);
            htNewVersion.Add("@c_fulfillment", curriculum.c_fulfillment);
            htNewVersion.Add("@c_attchment", curriculum.c_attchment);
            htNewVersion.Add("@c_path", curriculum.c_path);
            htNewVersion.Add("@c_recert_path", curriculum.c_recert_path);
            htNewVersion.Add("@c_curriculum_created_by_id_fk", curriculum.c_curriculum_created_by_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_new_version", htNewVersion);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get VersionList
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <param name="u_time_zone_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumVersionList(string c_curriculum_system_id_pk, int u_time_zone_id_pk)
        {
            Hashtable htGetVersionList = new Hashtable();
            htGetVersionList.Add("@u_time_zone_id_pk", u_time_zone_id_pk);
            htGetVersionList.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_curriculum_sp_get_version_list", htGetVersionList);

            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Delete Domain
        /// </summary>
        public static int DeleteDomain(SystemCurriculum curriculum)
        {
            Hashtable htDeleteDomain = new Hashtable();
            htDeleteDomain.Add("@c_domain_id_fk", curriculum.c_domain_id_fk);
            if (curriculum.c_related_curriculum_group_id != "")
            {
                htDeleteDomain.Add("@c_related_domain_id_fk", curriculum.c_related_domain_id_fk);
            }
            else
            {
                htDeleteDomain.Add("@c_related_domain_id_fk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_domain", htDeleteDomain);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Curriculum Related Data
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetCurriculumRelatedData(string c_curriculum_system_id_pk, string s_ui_locale_name)
        {
            Hashtable htGetCurriculum = new Hashtable();
            htGetCurriculum.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
            htGetCurriculum.Add("@s_ui_locale_name", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataSet("c_get_Particular_curriculum_Master", htGetCurriculum);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Reset Curriculum
        /// </summary>
        /// <param name="resetCurriculum"></param>
        /// <param name="c_curriculum_reset"></param>
        /// <returns></returns>
        public static int ResetCurriculum(SystemCurriculum resetCurriculum, bool c_curriculum_reset)
        {
            Hashtable htResetCurriculum = new Hashtable();
            htResetCurriculum.Add("@c_curriculum_system_id_pk", resetCurriculum.c_curriculum_system_id_pk);

            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_attachment))
            {
                htResetCurriculum.Add("@c_curriculum_attachment", resetCurriculum.c_curriculum_attachment);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_attachment", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_category))
            {
                htResetCurriculum.Add("@c_curriculum_category", resetCurriculum.c_curriculum_category);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_category", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_domain))
            {
                htResetCurriculum.Add("@c_curriculum_domain", resetCurriculum.c_curriculum_domain);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_domain", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_audience))
            {
                htResetCurriculum.Add("@c_curriculum_audience", resetCurriculum.c_curriculum_audience);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_audience", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(resetCurriculum.s_curriculum_locale))
            {
                htResetCurriculum.Add("@s_curriculum_locale", resetCurriculum.s_curriculum_locale);
            }
            else
            {
                htResetCurriculum.Add("@s_curriculum_locale", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_path))
            {
                htResetCurriculum.Add("@c_curriculum_path", resetCurriculum.c_curriculum_path);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_path", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_path_sections))
            {
                htResetCurriculum.Add("@c_curriculum_path_sections", resetCurriculum.c_curriculum_path_sections);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_path_sections", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_path_courses))
            {
                htResetCurriculum.Add("@c_curriculum_path_courses", resetCurriculum.c_curriculum_path_courses);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_path_courses", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_recert_path))
            {
                htResetCurriculum.Add("@c_curriculum_recert_path", resetCurriculum.c_curriculum_recert_path);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_recert_path", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_recert_path_sections))
            {
                htResetCurriculum.Add("@c_curriculum_recert_path_sections", resetCurriculum.c_curriculum_recert_path_sections);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_recert_path_sections", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resetCurriculum.c_curriculum_recert_path_courses))
            {
                htResetCurriculum.Add("@c_curriculum_recert_path_courses", resetCurriculum.c_curriculum_recert_path_courses);
            }
            else
            {
                htResetCurriculum.Add("@c_curriculum_recert_path_courses", DBNull.Value);
            }
            htResetCurriculum.Add("@c_curriculum_reset", c_curriculum_reset);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_reset_curriculum", htResetCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Curriculum Status
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateCurriculumStatus(string c_curriculum_system_id_pk)
        {
            Hashtable htUpdateDomainStatus = new Hashtable();
            htUpdateDomainStatus.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_curriculum_status", htUpdateDomainStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Archive Particular Curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        public static DataSet ArchiveParticularCurriculum(SystemCurriculum curriculum)
        {
            Hashtable htArchiveCurriculum = new Hashtable();
            htArchiveCurriculum.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htArchiveCurriculum.Add("@c_curriculum_active_flag", curriculum.c_curriculum_active_flag);
            try
            {
                return DataProxy.FetchDataSet("c_Archive_Particular_Curriculum_Master", htArchiveCurriculum);

            }
            catch (Exception)
            {
                throw;
            }
        }
        //path
        /// <summary>
        /// Get path section
        /// </summary>
        /// <returns></returns>
        //public static DataTable GetPathSection()
        //{
        //    try
        //    {
        //        return DataProxy.FetchDataTable("c_sp_get_curriculum_path_section");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// get path course
        /// </summary>
        /// <param name="c_curricula_path_section_id_pk"></param>
        /// <returns></returns>
        //public static DataTable GetPathCourse(string c_curricula_path_section_id_pk)
        //{
        //    Hashtable htGetPathCourse = new Hashtable();
        //    htGetPathCourse.Add("@c_curricula_path_section_id_pk", c_curricula_path_section_id_pk);
        //    try
        //    {
        //        return DataProxy.FetchDataTable("c_sp_get_curriculum_path_section", htGetPathCourse);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// Insert Curriculum Path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int InsertCurriculaPath(SystemCurriculum path)
        {
            try
            {
                Hashtable htPath = new Hashtable();
                htPath.Add("c_curricula_path_system_id_pk", path.c_curricula_path_system_id_pk);
                htPath.Add("c_curricula_id_fk", path.c_curricula_id_fk);
                htPath.Add("c_curricula_path_name", path.c_curricula_path_name);
                htPath.Add("c_curricula_path_Description", path.c_curricula_path_Description);
                htPath.Add("c_curricula_path_abstract", path.c_curricula_path_abstract);
                htPath.Add("c_curricula_path_enforce_section_seq_flag", path.c_curricula_path_enforce_section_seq_flag);
                htPath.Add("c_curricula_path_complete", path.c_curricula_path_complete);
                htPath.Add("c_curricula_path_sections", path.c_curricula_path_sections);
                htPath.Add("c_curricula_path_section", path.c_curricula_path_section);
                htPath.Add("c_curricula_path_courses", path.c_curricula_path_courses);
                return DataProxy.FetchSPOutput("c_sp_insert_curriculum_path", htPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get curriculum path
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_id_fk"></param>
        /// <returns></returns>
        public static SystemCurriculum GetCurriculumPath(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            SystemCurriculum GetCurriculamPath;
            try
            {
                Hashtable htGetCurriculumPath = new Hashtable();
                if (!string.IsNullOrEmpty(c_curricula_id_fk))
                {
                    htGetCurriculumPath.Add("@c_curricula_id_fk", c_curricula_id_fk);
                }
                else
                {
                    htGetCurriculumPath.Add("@c_curricula_id_fk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(c_curricula_path_id_fk))
                {
                    htGetCurriculumPath.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
                }
                else
                {
                    htGetCurriculumPath.Add("@c_curricula_path_id_fk", DBNull.Value);
                }
                DataTable dtGetCurriculumPath = DataProxy.FetchDataSet("c_sp_get_curriculum_path", htGetCurriculumPath).Tables[0];
                GetCurriculamPath = new SystemCurriculum();
                GetCurriculamPath.c_curricula_path_system_id_pk = dtGetCurriculumPath.Rows[0]["c_curricula_path_system_id_pk"].ToString();
                GetCurriculamPath.c_curricula_id_fk = dtGetCurriculumPath.Rows[0]["c_curricula_id_fk"].ToString();
                GetCurriculamPath.c_curricula_path_name = dtGetCurriculumPath.Rows[0]["c_curricula_path_name"].ToString();
                GetCurriculamPath.c_curricula_path_Description = dtGetCurriculumPath.Rows[0]["c_curricula_path_Description"].ToString();
                GetCurriculamPath.c_curricula_path_abstract = dtGetCurriculumPath.Rows[0]["c_curricula_path_abstract"].ToString();
                GetCurriculamPath.c_curricula_path_enforce_section_seq_flag = Convert.ToBoolean(dtGetCurriculumPath.Rows[0]["c_curricula_path_enforce_section_seq_flag"]);
                GetCurriculamPath.c_curricula_path_complete = Convert.ToInt16(dtGetCurriculumPath.Rows[0]["c_curricula_path_complete"]);
                GetCurriculamPath.c_curricula_path_sections = Convert.ToInt16(dtGetCurriculumPath.Rows[0]["c_curricula_path_sections"]);
                return GetCurriculamPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get curriculum Path section
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_id_fk"></param>
        /// <returns></returns>
        public static DataSet GetCurriculumPathCourseSection(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {

            Hashtable htGetCurriculumCourseSection = new Hashtable();
            htGetCurriculumCourseSection.Add("@c_curricula_id_fk", c_curricula_id_fk);
            if (!string.IsNullOrEmpty(c_curricula_path_id_fk))
            {
                htGetCurriculumCourseSection.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            }
            else
            {
                htGetCurriculumCourseSection.Add("@c_curricula_path_id_fk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchDataSet("c_sp_get_curriculum_path", htGetCurriculumCourseSection);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Delete single path course
        /// </summary>
        /// <param name="c_curricula_path_course_id_fk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int DeleteSinglePathcourse(string c_curricula_path_course_id_fk, string c_curricula_path_section_id_fk)
        {
            Hashtable htDeleteSinglePathcourse = new Hashtable();
            htDeleteSinglePathcourse.Add("@c_curricula_path_course_id_fk", c_curricula_path_course_id_fk);
            htDeleteSinglePathcourse.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_delete_single_curriculula_path_course", htDeleteSinglePathcourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update sequence number for UP
        /// </summary>
        /// <param name="c_current_curricula_path_course_id_fk"></param>
        /// <param name="c_previous_curricula_path_course_id_fk"></param>
        /// <param name="current_course_system_id_pk"></param>
        /// <param name="previous_course_system_id_pk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCurriculaPathCourseSeqNumberforUp(string c_current_curricula_path_course_id_fk, string c_previous_curricula_path_course_id_fk, string current_course_system_id_pk, string previous_course_system_id_pk, string c_curricula_path_section_id_fk)
        {
            Hashtable htCurriculaPathCourseSeqNumber = new Hashtable();
            htCurriculaPathCourseSeqNumber.Add("@c_current_curricula_path_course_id_fk", c_current_curricula_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@c_previous_curricula_path_course_id_fk", c_previous_curricula_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@current_course_system_id_pk", current_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@previous_course_system_id_pk", previous_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_path_course_seq_number_for_up", htCurriculaPathCourseSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update sequence number for down
        /// </summary>
        /// <param name="c_current_curricula_path_course_id_fk"></param>
        /// <param name="c_next_curricula_path_course_id_fk"></param>
        /// <param name="current_course_system_id_pk"></param>
        /// <param name="next_course_system_id_pk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCurriculaPathCourseSeqNumberforDown(string c_current_curricula_path_course_id_fk, string c_next_curricula_path_course_id_fk, string current_course_system_id_pk, string next_course_system_id_pk, string c_curricula_path_section_id_fk)
        {
            Hashtable htCurriculaPathCourseSeqNumber = new Hashtable();
            htCurriculaPathCourseSeqNumber.Add("@c_current_curricula_path_course_id_fk", c_current_curricula_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@c_next_curricula_path_course_id_fk", c_next_curricula_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@current_course_system_id_pk", current_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@next_course_system_id_pk", next_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_path_course_seq_number_for_down", htCurriculaPathCourseSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert curricula pathcourse
        /// </summary>
        /// <param name="c_curricula_path_courses"></param>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_id_fk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int InsertCurriculaPathCourse(string c_curricula_path_courses, string c_curricula_id_fk, string c_curricula_path_id_fk, string c_curricula_path_section_id_fk)
        {
            Hashtable htPathCourses = new Hashtable();
            htPathCourses.Add("@c_curricula_path_courses", c_curricula_path_courses);
            htPathCourses.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htPathCourses.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htPathCourses.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_insert_path_courses", htPathCourses);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert curricula path section
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_id_fk"></param>
        /// <param name="c_curricula_path_section_seq_number"></param>
        /// <returns></returns>
        public static int InsertCurrriculaPathSection(string c_curricula_id_fk, string c_curricula_path_id_fk, int c_curricula_path_section_seq_number)
        {
            try
            {
                Hashtable htInsertCurriculaPathSection = new Hashtable();
                htInsertCurriculaPathSection.Add("@c_curricula_id_fk", c_curricula_id_fk);
                htInsertCurriculaPathSection.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
                htInsertCurriculaPathSection.Add("@c_curricula_path_section_seq_number", c_curricula_path_section_seq_number);
                return DataProxy.FetchSPOutput("c_sp_curricula_insert_path_section", htInsertCurriculaPathSection);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete curricula path
        /// </summary>
        /// <param name="deletePath"></param>
        /// <returns></returns>
        public static int DeleteCurricilaPath(SystemCurriculum deletePath)
        {
            Hashtable htDeleteCurriculaPath = new Hashtable();
            htDeleteCurriculaPath.Add("@c_curricula_id_fk", deletePath.c_curricula_id_fk);
            htDeleteCurriculaPath.Add("@c_curricula_path_system_id_pk", deletePath.c_curricula_path_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_paths", htDeleteCurriculaPath);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update curricula path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int UpdateCurriculaPath(SystemCurriculum path)
        {
            Hashtable htPath = new Hashtable();
            htPath.Add("@c_curricula_path_system_id_pk", path.c_curricula_path_system_id_pk);
            htPath.Add("@c_curricula_id_fk", path.c_curricula_id_fk);
            htPath.Add("@c_curricula_path_name", path.c_curricula_path_name);
            htPath.Add("@c_curricula_path_Description", path.c_curricula_path_Description);
            htPath.Add("@c_curricula_path_abstract", path.c_curricula_path_abstract);
            htPath.Add("@c_curricula_path_enforce_section_seq_flag", path.c_curricula_path_enforce_section_seq_flag);
            htPath.Add("@c_curricula_path_complete", path.c_curricula_path_complete);
            htPath.Add("@c_curricula_path_sections", path.c_curricula_path_sections);
            try
            {

                return DataProxy.FetchSPOutput("c_sp_update_curriculum_path", htPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update checked course required field
        /// </summary>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <param name="c_curricula_path_course_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCheckedCourseRequiredField(string c_curricula_path_section_id_fk, string c_curricula_path_course_id_fk)
        {
            Hashtable htUpdatedCheckedRequiredField = new Hashtable();
            htUpdatedCheckedRequiredField.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            htUpdatedCheckedRequiredField.Add("@c_curricula_path_course_id_fk", c_curricula_path_course_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_checked_required_field", htUpdatedCheckedRequiredField);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update unchecked course required fileld
        /// </summary>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <param name="c_curricula_path_course_id_fk"></param>
        /// <returns></returns>
        public static int UpdateUnCheckedCourseRequiredField(string c_curricula_path_section_id_fk, string c_curricula_path_course_id_fk)
        {
            Hashtable htUpdatedUnCheckedRequiredField = new Hashtable();
            htUpdatedUnCheckedRequiredField.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);
            htUpdatedUnCheckedRequiredField.Add("@c_curricula_path_course_id_fk", c_curricula_path_course_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_Unchecked_required_field", htUpdatedUnCheckedRequiredField);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// check above section added with course or not
        /// </summary>
        /// <param name="c_curricula_path_section_id_pk"></param>
        /// <returns></returns>
        public static int checkPathsectioncourse(string c_curricula_path_section_id_pk)
        {
            Hashtable htcheckPathsectioncourse = new Hashtable();
            htcheckPathsectioncourse.Add("@c_curricula_path_section_id_pk", c_curricula_path_section_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_check_path_section_course", htcheckPathsectioncourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetApprovalForCurriculum(string s_ui_locale_name)
        {
            Hashtable htGetApproval = new Hashtable();
            htGetApproval.Add("@s_ui_locale_name", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_approval_name", htGetApproval);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert Recert Path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int InsertCurriculaRecertPath(SystemCurriculum path)
        {
            try
            {
                Hashtable htPath = new Hashtable();
                htPath.Add("c_curricula_recert_path_system_id_pk", path.c_curricula_recert_path_system_id_pk);
                htPath.Add("c_curricula_recert_id_fk", path.c_curricula_recert_id_fk);
                htPath.Add("c_curricula_recert_path_name", path.c_curricula_recert_path_name);
                htPath.Add("c_curricula_recert_path_Description", path.c_curricula_recert_path_Description);
                htPath.Add("c_curricula_recert_path_abstract", path.c_curricula_recert_path_abstract);
                htPath.Add("c_curricula_recert_path_enforce_section_seq_flag", path.c_curricula_recert_path_enforce_section_seq_flag);
                htPath.Add("c_curricula_recert_path_complete", path.c_curricula_recert_path_complete);
                htPath.Add("c_curricula_recert_path_sections", path.c_curricula_recert_path_sections);
                htPath.Add("c_curricula_recert_path_section", path.c_curricula_recert_path_section);
                htPath.Add("c_curricula_recert_path_courses", path.c_curricula_recert_path_courses);
                return DataProxy.FetchSPOutput("c_sp_insert_curriculum_recert_path", htPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Curriculum Recert Path
        /// </summary>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_id_fk"></param>
        /// <returns></returns>
        public static SystemCurriculum GetCurriculumRecertPath(string c_curricula_recert_id_fk, string c_curricula_recert_path_id_fk)
        {
            SystemCurriculum GetCurriculamPath;
            try
            {
                Hashtable htGetCurriculumPath = new Hashtable();
                if (!string.IsNullOrEmpty(c_curricula_recert_id_fk))
                {
                    htGetCurriculumPath.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
                }
                else
                {
                    htGetCurriculumPath.Add("@c_curricula_recert_id_fk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(c_curricula_recert_path_id_fk))
                {
                    htGetCurriculumPath.Add("@c_curricula_recert_path_id_fk", c_curricula_recert_path_id_fk);
                }
                else
                {
                    htGetCurriculumPath.Add("@c_curricula_recert_path_id_fk", DBNull.Value);
                }
                DataTable dtGetCurriculumPath = DataProxy.FetchDataSet("c_sp_get_curriculum_recert_path", htGetCurriculumPath).Tables[0];
                GetCurriculamPath = new SystemCurriculum();
                GetCurriculamPath.c_curricula_recert_path_system_id_pk = dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_system_id_pk"].ToString();
                GetCurriculamPath.c_curricula_recert_id_fk = dtGetCurriculumPath.Rows[0]["c_curricula_recert_id_fk"].ToString();
                GetCurriculamPath.c_curricula_recert_path_name = dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_name"].ToString();
                GetCurriculamPath.c_curricula_recert_path_Description = dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_Description"].ToString();
                GetCurriculamPath.c_curricula_recert_path_abstract = dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_abstract"].ToString();
                GetCurriculamPath.c_curricula_recert_path_enforce_section_seq_flag = Convert.ToBoolean(dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_enforce_section_seq_flag"]);
                GetCurriculamPath.c_curricula_recert_path_complete = Convert.ToInt16(dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_complete"]);
                GetCurriculamPath.c_curricula_recert_path_sections = Convert.ToInt16(dtGetCurriculumPath.Rows[0]["c_curricula_recert_path_sections"]);
                return GetCurriculamPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Curriculum recert path section
        /// </summary>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_id_fk"></param>
        /// <returns></returns>
        public static DataSet GetCurriculumRecertPathCourseSection(string c_curricula_recert_id_fk, string c_curricula_recert_path_id_fk)
        {

            Hashtable htGetCurriculumCourseSection = new Hashtable();
            htGetCurriculumCourseSection.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
            if (!string.IsNullOrEmpty(c_curricula_recert_path_id_fk))
            {
                htGetCurriculumCourseSection.Add("@c_curricula_recert_path_id_fk", c_curricula_recert_path_id_fk);
            }
            else
            {
                htGetCurriculumCourseSection.Add("@c_curricula_recert_path_id_fk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchDataSet("c_sp_get_curriculum_recert_path", htGetCurriculumCourseSection);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Delete single recert path course
        /// </summary>
        /// <param name="c_curricula_recert_path_course_id_fk"></param>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <returns></returns>
        public static int DeleteSingleRecertPathcourse(string c_curricula_recert_path_course_id_fk, string c_curricula_recert_path_section_id_fk)
        {
            Hashtable htDeleteSinglePathcourse = new Hashtable();
            htDeleteSinglePathcourse.Add("@c_curricula_recert_path_course_id_fk", c_curricula_recert_path_course_id_fk);
            htDeleteSinglePathcourse.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_delete_single_curriculula_recert_path_course", htDeleteSinglePathcourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update curriculum recert path seq no for up
        /// </summary>
        /// <param name="c_current_curricula_recert_path_course_id_fk"></param>
        /// <param name="c_previous_curricula_recert_path_course_id_fk"></param>
        /// <param name="current_course_system_id_pk"></param>
        /// <param name="previous_course_system_id_pk"></param>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCurriculaRecertPathCourseSeqNumberforUp(string c_current_curricula_recert_path_course_id_fk, string c_previous_curricula_recert_path_course_id_fk, string current_course_system_id_pk, string previous_course_system_id_pk, string c_curricula_recert_path_section_id_fk)
        {
            Hashtable htCurriculaPathCourseSeqNumber = new Hashtable();
            htCurriculaPathCourseSeqNumber.Add("@c_current_curricula_recert_path_course_id_fk", c_current_curricula_recert_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@c_previous_curricula_recert_path_course_id_fk", c_previous_curricula_recert_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@current_course_system_id_pk", current_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@previous_course_system_id_pk", previous_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_recert_path_course_seq_number_for_up", htCurriculaPathCourseSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        ///  Update curriculum recert path seq no for down
        /// </summary>
        /// <param name="c_current_curricula_recert_path_course_id_fk"></param>
        /// <param name="c_next_curricula_recert_path_course_id_fk"></param>
        /// <param name="current_course_system_id_pk"></param>
        /// <param name="next_course_system_id_pk"></param>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCurriculaRecertPathCourseSeqNumberforDown(string c_current_curricula_recert_path_course_id_fk, string c_next_curricula_recert_path_course_id_fk, string current_course_system_id_pk, string next_course_system_id_pk, string c_curricula_recert_path_section_id_fk)
        {
            Hashtable htCurriculaPathCourseSeqNumber = new Hashtable();
            htCurriculaPathCourseSeqNumber.Add("@c_current_curricula_recert_path_course_id_fk", c_current_curricula_recert_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@c_next_curricula_recert_path_course_id_fk", c_next_curricula_recert_path_course_id_fk);
            htCurriculaPathCourseSeqNumber.Add("@current_course_system_id_pk", current_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@next_course_system_id_pk", next_course_system_id_pk);
            htCurriculaPathCourseSeqNumber.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_recert_path_course_seq_number_for_down", htCurriculaPathCourseSeqNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        ///  Insert curriculum recert path Course
        /// </summary>
        /// <param name="c_curricula_recert_path_courses"></param>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_id_fk"></param>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <returns></returns>
        public static int InsertCurriculaRecertPathCourse(string c_curricula_recert_path_courses, string c_curricula_recert_id_fk, string c_curricula_recert_path_id_fk, string c_curricula_recert_path_section_id_fk)
        {
            Hashtable htPathCourses = new Hashtable();
            htPathCourses.Add("@c_curricula_recert_path_courses", c_curricula_recert_path_courses);
            htPathCourses.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
            htPathCourses.Add("@c_curricula_recert_path_id_fk", c_curricula_recert_path_id_fk);
            htPathCourses.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_curricula_insert_recert_path_courses", htPathCourses);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert curricula path  recert section
        /// </summary>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_id_fk"></param>
        /// <param name="c_curricula_recert_path_section_seq_number"></param>
        /// <returns></returns>
        public static int InsertCurrriculaRecertPathSection(string c_curricula_recert_id_fk, string c_curricula_recert_path_id_fk, int c_curricula_recert_path_section_seq_number)
        {
            try
            {
                Hashtable htInsertCurriculaPathSection = new Hashtable();
                htInsertCurriculaPathSection.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
                htInsertCurriculaPathSection.Add("@c_curricula_recert_path_id_fk", c_curricula_recert_path_id_fk);
                htInsertCurriculaPathSection.Add("@c_curricula_recert_path_section_seq_number", c_curricula_recert_path_section_seq_number);
                return DataProxy.FetchSPOutput("c_sp_curricula_insert_recert_path_section", htInsertCurriculaPathSection);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete curricula recert path
        /// </summary>
        /// <param name="deletePath"></param>
        /// <returns></returns>
        public static int DeleteCurricilaRecertPath(SystemCurriculum deletePath)
        {
            Hashtable htDeleteCurriculaPath = new Hashtable();
            htDeleteCurriculaPath.Add("@c_curricula_recert_id_fk", deletePath.c_curricula_recert_id_fk);
            htDeleteCurriculaPath.Add("@c_curricula_recert_path_system_id_pk", deletePath.c_curricula_recert_path_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_delete_recert_paths", htDeleteCurriculaPath);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update curricula recert path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int UpdateCurriculaRecertPath(SystemCurriculum path)
        {
            Hashtable htPath = new Hashtable();
            htPath.Add("@c_curricula_recert_path_system_id_pk", path.c_curricula_recert_path_system_id_pk);
            htPath.Add("@c_curricula_recert_id_fk", path.c_curricula_recert_id_fk);
            htPath.Add("@c_curricula_recert_path_name", path.c_curricula_recert_path_name);
            htPath.Add("@c_curricula_recert_path_Description", path.c_curricula_recert_path_Description);
            htPath.Add("@c_curricula_recert_path_abstract", path.c_curricula_recert_path_abstract);
            htPath.Add("@c_curricula_recert_path_enforce_section_seq_flag", path.c_curricula_recert_path_enforce_section_seq_flag);
            htPath.Add("@c_curricula_recert_path_complete", path.c_curricula_recert_path_complete);
            htPath.Add("@c_curricula_recert_path_sections", path.c_curricula_recert_path_sections);
            try
            {

                return DataProxy.FetchSPOutput("c_sp_update_curriculum_recert_path", htPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update checked course required field
        /// </summary>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <param name="c_curricula_recert_path_course_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCheckedRecertPathCourseRequiredField(string c_curricula_recert_path_section_id_fk, string c_curricula_recert_path_course_id_fk)
        {
            Hashtable htUpdatedCheckedRequiredField = new Hashtable();
            htUpdatedCheckedRequiredField.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            htUpdatedCheckedRequiredField.Add("@c_curricula_recert_path_course_id_fk", c_curricula_recert_path_course_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_recert_path_checked_required_field", htUpdatedCheckedRequiredField);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update unchecked course required fileld
        /// </summary>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <param name="c_curricula_recert_path_course_id_fk"></param>
        /// <returns></returns>
        public static int UpdateUnCheckedRecertPathCourseRequiredField(string c_curricula_recert_path_section_id_fk, string c_curricula_recert_path_course_id_fk)
        {
            Hashtable htUpdatedUnCheckedRequiredField = new Hashtable();
            htUpdatedUnCheckedRequiredField.Add("@c_curricula_recert_path_section_id_fk", c_curricula_recert_path_section_id_fk);
            htUpdatedUnCheckedRequiredField.Add("@c_curricula_recert_path_course_id_fk", c_curricula_recert_path_course_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_recert_path_Unchecked_required_field", htUpdatedUnCheckedRequiredField);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// check above section added with course or not
        /// </summary>
        /// <param name="c_curricula_recert_path_section_id_pk"></param>
        /// <returns></returns>
        public static int checkRecertPathsectioncourse(string c_curricula_recert_path_section_id_pk)
        {
            Hashtable htcheckPathsectioncourse = new Hashtable();
            htcheckPathsectioncourse.Add("@c_curricula_recert_path_section_id_pk", c_curricula_recert_path_section_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_check_recert_path_section_course", htcheckPathsectioncourse);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Update section complete andcourse
        /// </summary>
        /// <param name="c_curricula_path_section_id_pk"></param>
        /// <param name="c_curricula_id_fk"></param>
        /// <returns></returns>
        //public static int UpdateSectionCompleteAndCourse(string c_curricula_path_section_id_pk, string c_curricula_id_fk)
        //{
        //    Hashtable htUpdateSectionCompleteAndCourse = new Hashtable();
        //    htUpdateSectionCompleteAndCourse.Add("@c_curricula_path_section_id_pk", c_curricula_path_section_id_pk);
        //    htUpdateSectionCompleteAndCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
        //    try
        //    {
        //        return DataProxy.FetchSPOutput("c_sp_update_section_complete_and_course", htUpdateSectionCompleteAndCourse);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// Update  checked enforce course
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateCheckedEnforceCourse(string c_curricula_id_fk, string c_curricula_path_section_id_fk)
        {
            Hashtable htUpdateCheckedEnforceCourse = new Hashtable();
            htUpdateCheckedEnforceCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htUpdateCheckedEnforceCourse.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_checked_enforce_section", htUpdateCheckedEnforceCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update checked Enforce course
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateUnCheckedEnforceCourse(string c_curricula_id_fk, string c_curricula_path_section_id_fk)
        {
            Hashtable htUpdateCheckedEnforceCourse = new Hashtable();
            htUpdateCheckedEnforceCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htUpdateCheckedEnforceCourse.Add("@c_curricula_path_section_id_fk", c_curricula_path_section_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_Unchecked_enforce_section", htUpdateCheckedEnforceCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Recert checked enforce course
        /// </summary>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_section_id_pk"></param>
        /// <returns></returns>
        public static int UpdateRecertCheckedEnforceCourse(string c_curricula_recert_id_fk, string c_curricula_recert_path_section_id_pk)
        {
            Hashtable htUpdateCheckedEnforceCourse = new Hashtable();
            htUpdateCheckedEnforceCourse.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
            htUpdateCheckedEnforceCourse.Add("@c_curricula_recert_path_section_id_pk", c_curricula_recert_path_section_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_recert_checked_enforce_section", htUpdateCheckedEnforceCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Recert Unchecked Enforce course
        /// </summary>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <param name="c_curricula_recert_path_section_id_fk"></param>
        /// <returns></returns>
        public static int UpdateRecertUnCheckedEnforceCourse(string c_curricula_recert_id_fk, string c_curricula_recert_path_section_id_fk)
        {
            Hashtable htUpdateCheckedEnforceCourse = new Hashtable();
            htUpdateCheckedEnforceCourse.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
            htUpdateCheckedEnforceCourse.Add("@c_curricula_recert_path_section_id_pk", c_curricula_recert_path_section_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_recert_Unchecked_enforce_section", htUpdateCheckedEnforceCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Recert Section Complete and course
        /// </summary>
        /// <param name="c_curricula_recert_path_section_id_pk"></param>
        /// <param name="c_curricula_recert_id_fk"></param>
        /// <returns></returns>
        //public static int UpdateRecertSectionCompleteAndCourse(string c_curricula_recert_path_section_id_pk, string c_curricula_recert_id_fk)
        //{
        //    Hashtable htUpdateSectionCompleteAndCourse = new Hashtable();
        //    htUpdateSectionCompleteAndCourse.Add("@c_curricula_recert_path_section_id_pk", c_curricula_recert_path_section_id_pk);
        //    htUpdateSectionCompleteAndCourse.Add("@c_curricula_recert_id_fk", c_curricula_recert_id_fk);
        //    try
        //    {
        //        return DataProxy.FetchSPOutput("c_sp_update_recert_section_complete_and_course", htUpdateSectionCompleteAndCourse);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static DataTable GetSingleCurriculaPath(string c_curricula_id_fk, string u_user_id_pk)
        {
            Hashtable htGetSingleCurriculaPath = new Hashtable();
            htGetSingleCurriculaPath.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htGetSingleCurriculaPath.Add("@u_user_id_pk", u_user_id_pk);

            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_path", htGetSingleCurriculaPath);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleCurriculaPathSection(string c_curricula_id_fk, string c_curricula_path_id_fk, string u_user_id_pk)
        {
            Hashtable htGetSingleCurriculaPathSection = new Hashtable();
            htGetSingleCurriculaPathSection.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htGetSingleCurriculaPathSection.Add("@c_curricula_id_fk", c_curricula_id_fk);
            htGetSingleCurriculaPathSection.Add("@u_user_id_pk", u_user_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_path_section", htGetSingleCurriculaPathSection);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleCurriculaPathCourse(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            Hashtable htGetSingleCurriculaPathCourse = new Hashtable();
            htGetSingleCurriculaPathCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htGetSingleCurriculaPathCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_path_course", htGetSingleCurriculaPathCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleCurriculaRecertPath(string c_curricula_id_fk)
        {
            Hashtable htGetSingleCurriculaRecertPath = new Hashtable();
            htGetSingleCurriculaRecertPath.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_recert_path", htGetSingleCurriculaRecertPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleCurriculaRecertPathSection(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            Hashtable htGetSingleCurriculaRecertPathSection = new Hashtable();
            htGetSingleCurriculaRecertPathSection.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htGetSingleCurriculaRecertPathSection.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_recert_path_section", htGetSingleCurriculaRecertPathSection);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single 
        /// </summary>
        /// <param name="c_curricula_id_fk"></param>
        /// <param name="c_curricula_path_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetSingleCurriculaRecertPathCourse(string c_curricula_id_fk, string c_curricula_path_id_fk)
        {
            Hashtable htGetSingleCurriculaRecertPathCourse = new Hashtable();
            htGetSingleCurriculaRecertPathCourse.Add("@c_curricula_path_id_fk", c_curricula_path_id_fk);
            htGetSingleCurriculaRecertPathCourse.Add("@c_curricula_id_fk", c_curricula_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_single_curricula_recert_path_course", htGetSingleCurriculaRecertPathCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Curriculum type
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <returns></returns>
        public static DataTable GetCurriculumType(string s_ui_locale_name)
        {
            Hashtable htGetApproval = new Hashtable();
            htGetApproval.Add("@s_ui_locale_name", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_curriculum_type", htGetApproval);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Curriculum Path only
        /// </summary>
        /// <param name="c_curriculum_system_id_pk"></param>
        /// <returns></returns>

        public static DataTable GetCurriculumPathOnly(string c_curriculum_system_id_pk)
        {
            Hashtable htGetPath = new Hashtable();
            htGetPath.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_curriculum_path_only", htGetPath);

            }
            catch (Exception)
            {
                throw;
            }
        }


       /// <summary>
       /// Get Grading Schemes Values
       /// </summary>
       /// <returns></returns>
        public static DataTable GetGradingScheme(string s_locale)
        {

            try
            {
                Hashtable htGetGradingScheme = new Hashtable();
                htGetGradingScheme.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("c_get_grading_scheme", htGetGradingScheme);
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
                return DataProxy.FetchDataTable("s_sp_search_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int InsertAudience(string c_related_audience_id_fk, string c_curriculum_system_id_pk)
        {
            Hashtable htInsertAudience = new Hashtable();

            htInsertAudience.Add("@c_related_audience_id_fk", c_related_audience_id_fk);
            htInsertAudience.Add("@c_curriculum_system_id_pk", c_curriculum_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_curriculum_sp_insert_audience", htInsertAudience);
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetCurriculumAudiences(string c_curriculum_id_fk)
        {
            Hashtable htGetAudience = new Hashtable();
            htGetAudience.Add("@c_curriculum_id_fk", c_curriculum_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_curriculum_audience", htGetAudience);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteAudiences(string c_related_audience_id_fk, string c_curriculum_id_fk)
        {
            Hashtable htDeleteAudience = new Hashtable();
            htDeleteAudience.Add("@c_related_audience_id_fk", c_related_audience_id_fk);
            htDeleteAudience.Add("@c_curriculum_id_fk", c_curriculum_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_sp_delete_curriculum_audience", htDeleteAudience);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
