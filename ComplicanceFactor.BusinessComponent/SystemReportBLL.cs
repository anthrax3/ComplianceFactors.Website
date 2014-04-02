using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemReportBLL
    {
        public static DataTable SearchReport(SystemReport report)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_id_pk", report.s_report_id_pk);
            htReport.Add("@s_report_name", report.s_report_name);
            htReport.Add("@s_report_type_id_fk",report.s_report_type_id_fk);
            if (report.s_report_on_off_flag == null)
                htReport.Add("@s_report_on_off_flag", DBNull.Value);
            else
            {
                htReport.Add("@s_report_on_off_flag", report.s_report_on_off_flag);
            }

            //htNotification.Add("@s_notification_type_id_fk", notification.s_notification_type_id_fk);

           // if (report.s_report_on_off_flag == "0")
           //     htNotification.Add("@s_notification_type_id_fk", DBNull.Value);
            //else
           //    htNotification.Add("@s_notification_type_id_fk", notification.s_notification_type_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create the Report
        /// </summary>
        /// <param name="createMaterial"></param>
        /// <returns></returns>
        public static int CreateNewReport(SystemReport report)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_system_id_pk", report.s_report_system_id_pk);
            htReport.Add("@s_report_id_pk", report.s_report_id_pk);
            htReport.Add("@s_report_name", report.s_report_name);
            htReport.Add("@s_report_description", report.s_report_description);
            htReport.Add("@s_report_type_id_fk", report.s_report_type_id_fk);
            htReport.Add("@s_report_on_off_flag", report.s_report_on_off_flag);
            htReport.Add("@s_report_manager_flag", report.s_report_manager_flag);
            htReport.Add("@s_report_employee_flag", report.s_report_employee_flag);
            htReport.Add("@s_report_compliance_flag", report.s_report_admin_flag);
            htReport.Add("@s_report_instructor_flag", report.s_report_instructor_flag);
            htReport.Add("@s_report_coordinator_flag", report.s_report_coordinator_flag);
            htReport.Add("@s_report_admin_flag", report.s_report_admin_flag);
           
            if (!string.IsNullOrEmpty(report.s_report_source_file_name))
            {
                htReport.Add("@s_report_source_file_name", report.s_report_source_file_name);
            }
            else
            {
                htReport.Add("@s_report_source_file_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(report.s_report_locale))
            {
                htReport.Add("@s_report_locale", report.s_report_locale);
            }
            else
            {
                htReport.Add("@s_report_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(report.s_report_param))
            {
                htReport.Add("@s_report_param", report.s_report_param);
            }
            else
            {
                htReport.Add("@s_report_param", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(report.s_report_label_locale))
            {
                htReport.Add("@s_report_label_locale", report.s_report_label_locale);
            }
            else
            {
                htReport.Add("@s_report_label_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(report.s_report_column))
            {
                htReport.Add("@s_report_column", report.s_report_column);
            }
            else
            {
                htReport.Add("@s_report_column", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update the Report
        /// </summary>
        /// <param name="createMaterial"></param>
        /// <returns></returns>
        public static int UpdateReport(SystemReport report)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_system_id_pk", report.s_report_system_id_pk);
            htReport.Add("@s_report_id_pk", report.s_report_id_pk);
            htReport.Add("@s_report_name", report.s_report_name);
            htReport.Add("@s_report_description", report.s_report_description);
            htReport.Add("@s_report_type_id_fk", report.s_report_type_id_fk);
            htReport.Add("@s_report_on_off_flag", report.s_report_on_off_flag);
            htReport.Add("@s_report_manager_flag", report.s_report_manager_flag);
            htReport.Add("@s_report_employee_flag", report.s_report_employee_flag);
            htReport.Add("@s_report_compliance_flag", report.s_report_compliance_flag);
            htReport.Add("@s_report_instructor_flag", report.s_report_instructor_flag);
            htReport.Add("@s_report_coordinator_flag", report.s_report_coordinator_flag);
            htReport.Add("@s_report_admin_flag", report.s_report_admin_flag);
            if (!string.IsNullOrEmpty(report.s_report_source_file_name))
            {
                htReport.Add("@s_report_source_file_name", report.s_report_source_file_name);
            }
            else
            {
                htReport.Add("@s_report_source_file_name", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemReport GetSingleReport(string s_report_system_id_pk,DataTable locale)
        {
            SystemReport report;
            try
            {
                Hashtable htGetReport = new Hashtable();
                htGetReport.Add("@s_report_system_id_pk", s_report_system_id_pk);

                DataSet dsGetReport = DataProxy.FetchDataSet("s_sp_get_single_report", htGetReport);
                DataTable dtGetReport = dsGetReport.Tables[0];
                locale = dsGetReport.Tables[1];
                report = new SystemReport()
                {
                    s_report_admin_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_admin_flag"].ToString()) ? false :
                    Convert.ToBoolean(dtGetReport.Rows[0]["s_report_admin_flag"].ToString()),
                    s_report_compliance_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_compliance_flag"].ToString()) ? false :
                   Convert.ToBoolean(dtGetReport.Rows[0]["s_report_compliance_flag"].ToString()),
                    s_report_coordinator_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_coordinator_flag"].ToString()) ? false :
                    Convert.ToBoolean(dtGetReport.Rows[0]["s_report_coordinator_flag"].ToString()),
                    s_report_instructor_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_instructor_flag"].ToString()) ? false :
                   Convert.ToBoolean(dtGetReport.Rows[0]["s_report_instructor_flag"].ToString()),
                    s_report_manager_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_manager_flag"].ToString()) ? false :
                    Convert.ToBoolean(dtGetReport.Rows[0]["s_report_manager_flag"].ToString()),

                    s_report_on_off_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_on_off_flag"].ToString()) ? false :
                   Convert.ToBoolean(dtGetReport.Rows[0]["s_report_on_off_flag"].ToString()),

                    s_report_employee_flag = string.IsNullOrEmpty(dtGetReport.Rows[0]["s_report_employee_flag"].ToString()) ? false :
                   Convert.ToBoolean(dtGetReport.Rows[0]["s_report_employee_flag"].ToString()),



                    s_report_description = dtGetReport.Rows[0]["s_report_description"].ToString(),
                    s_report_type_id_fk = dtGetReport.Rows[0]["s_report_type_id_fk"].ToString(),
                    s_report_name = dtGetReport.Rows[0]["s_report_name"].ToString(),
                    s_report_id_pk = dtGetReport.Rows[0]["s_report_id_pk"].ToString(),
                    s_report_source_file_name = dtGetReport.Rows[0]["s_report_source_file_name"].ToString(),
                    s_report_system_id_pk = dtGetReport.Rows[0]["s_report_system_id_pk"].ToString()
                  
                };
               

                return report;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateReportStatus(string s_report_system_id_pk, bool status)
        {
            Hashtable htUpdateNotificationStatus = new Hashtable();
            htUpdateNotificationStatus.Add("@s_report_system_id_pk", s_report_system_id_pk);
            htUpdateNotificationStatus.Add("@s_report_on_off_flag", status);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_report_status", htUpdateNotificationStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Params of a Report
        /// </summary>
        /// <param name="reportId">Report ID</param>
        /// <returns></returns>
        public static DataTable GetParamsOfReport(string reportId)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_system_id_fk", reportId);
           

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_report_params", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete a Param of a Report
        /// </summary>
        /// <param name="reportParamId"></param>
        /// <returns></returns>
        public static DataTable DeleteParamOfReport(string reportParamId, string s_report_system_id_fk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_param_system_id_pk", reportParamId);
            htReport.Add("@s_report_system_id_fk", s_report_system_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_delete_report_param", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create a Parameter of the Report
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int CreateParamOfReport(SystemReportParam param)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@s_report_param_system_id_pk", param.s_report_param_system_id_pk);
            htParam.Add("@s_report_system_id_fk", param.s_report_system_id_fk);
            htParam.Add("@s_report_param_id_pk", param.s_report_param_id_pk);
            htParam.Add("@s_report_param_name", param.s_report_param_name);
            htParam.Add("@s_report_param_description", param.s_report_param_description);
            htParam.Add("@s_report_param_type_id_fk", param.s_report_param_type_id_fk);
            htParam.Add("@s_report_param_visible_flag", param.s_report_param_visible_flag);
            htParam.Add("@s_report_param_table_id_pk", param.s_report_param_table_id_pk);
            htParam.Add("@s_report_param_field_id_pk", param.s_report_param_field_id_pk);
            htParam.Add("@s_report_param_label_name", param.s_report_param_label_name);
            htParam.Add("@s_report_param_items", param.s_report_param_items);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_report_param", htParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Columns of a Report
        /// </summary>
        /// <param name="reportId">Report ID</param>
        /// <returns></returns>
        public static DataTable GetColumnsOfReport(string reportId)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_system_id_fk", reportId);


            try
            {
                return DataProxy.FetchDataTable("s_sp_get_report_columns", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete a Column of a Report
        /// </summary>
        /// <param name="reportParamId"></param>
        /// <returns></returns>
        public static DataTable DeleteColumnOfReport(string reportParamId, string s_report_system_id_fk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_column_system_id_pk", reportParamId);
            htReport.Add("@s_report_system_id_fk", s_report_system_id_fk);

            try
            {
               
                return DataProxy.FetchDataTable("s_sp_delete_report_column", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create a Column of the Report
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int CreateColumnOfReport(SystemReportColumn column)
        {
            Hashtable htParam = new Hashtable();
            
            htParam.Add("@s_report_column_system_id_pk", column.s_report_column_system_id_pk);
            htParam.Add("@s_report_system_id_fk", column.s_report_system_id_fk);
            htParam.Add("@s_report_column_id_pk", column.s_report_column_id_pk);
            htParam.Add("@s_report_column_name", column.s_report_column_name);
            htParam.Add("@s_report_column_description", column.s_report_column_description);
            htParam.Add("@s_report_column_type_id_fk", column.s_report_column_type_id_fk);
            htParam.Add("@s_report_column_visible_flag", column.s_report_column_visible_flag);
            htParam.Add("@s_report_column_table_id_pk", column.s_report_column_table_id_pk);
            htParam.Add("@s_report_column_field_id_pk", column.s_report_column_field_id_pk);
            htParam.Add("@s_report_column_label_name", column.s_report_column_label_name);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_report_column", htParam);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Create param label of the Report
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int CreateParamLabelOfReport(SystemUI_Texts_Labels_Dropdown label)
        {
            Hashtable htParamLabel = new Hashtable();

            htParamLabel.Add("@s_ui_label_id_pk", label.s_ui_label_id_pk);
            htParamLabel.Add("@s_ui_label_name", label.s_ui_label_name);
            htParamLabel.Add("@s_ui_page_name", "");
            htParamLabel.Add("@s_ui_label_native", label.s_ui_label_native);
        
           


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_report_param_label", htParamLabel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update param label of the Report
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int UpdateParamLabelOfReport(SystemUI_Texts_Labels_Dropdown label)
        {
            Hashtable htParamLabel = new Hashtable();
           
            htParamLabel.Add("@s_ui_label_name", label.s_ui_label_name);
            htParamLabel.Add("@s_ui_label_native", label.s_ui_label_native);
           



            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_report_param_label", htParamLabel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetParamLabelOfReport(string s_ui_locale_name, string s_ui_label_name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_ui_locale_name", "us_english");
                htGetResource.Add("@s_ui_label_name", s_ui_label_name);
                htGetResource.Add("@s_ui_page_name", "");

                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_ui_label", htGetResource);
                if (dtVal == null)
                {
                    return string.Empty;
                }
                else
                {
                    if (dtVal.Rows.Count > 0)
                        return dtVal.Rows[0][0].ToString();
                    else
                    {
                        return string.Empty;

                    }

                }
               
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetLocalesOfReport(string s_report_system_id_pk, string s_locale_id_pk)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_report_system_id_pk", s_report_system_id_pk);
                htGetResource.Add("@s_locale_id_pk", s_locale_id_pk);
               


                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_report_locales", htGetResource);
                
                return dtVal;

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetLocalesOfReport(string s_report_system_id_pk)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_report_system_id_pk", s_report_system_id_pk);




                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_all_report_locales", htGetResource);

                return dtVal;

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateLocalesOfReport(string s_locale_id_fk, string s_report_label, string s_report_label_name, string s_report_system_id_fk)
        {

            try
            {
                Hashtable htUpdateLocale = new Hashtable();
                htUpdateLocale.Add("@s_locale_id_fk", s_locale_id_fk);
                htUpdateLocale.Add("@s_report_label", s_report_label);
                htUpdateLocale.Add("@s_report_label_name", s_report_label_name);
                htUpdateLocale.Add("@s_report_system_id_fk", s_report_system_id_fk);


                return DataProxy.FetchSPOutput("s_sp_update_report_locales", htUpdateLocale);
               

            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete a Param of a Report
        /// </summary>
        /// <param name="reportParamId"></param>
        /// <returns></returns>
        public static DataTable DeleteLabelLocaleOfReport(string s_report_system_id_fk, string s_locale_id_fk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_system_id_fk", s_report_system_id_fk);
            htReport.Add("@s_locale_id_fk", s_locale_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_delete_report_label_locale", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetLanguagesOfReport(string s_report_system_id_pk)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_report_system_id_pk", s_report_system_id_pk);
                IList<string> language = new List<string>();

                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_report_all_locales", htGetResource);


                return dtVal;
                // dtVal;

            }

            catch (Exception)
            {
                throw;
            }
        }





        /// <summary>
        /// get one locale from temp locale datatable
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <param name="dtTempLocale"></param>
        /// <returns></returns>
        public static SystemReportLocale TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemReportLocale reslocale;
            try
            {
                reslocale = new SystemReportLocale();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_pk = dtGetLocale.Rows[0]["s_locale_id_pk"].ToString();
                reslocale.s_locale_title = dtGetLocale.Rows[0]["s_locale_title"].ToString();
                reslocale.s_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
              
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Get single Report locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemReportLocale GetSingleReportLocale(string s_locale_system_id_pk)
        {
            SystemReportLocale Locale;
            try
            {
                Locale = new SystemReportLocale();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_report_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_report_locale", htGetLocale);
                Locale.s_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_pk = dtGetLocale.Rows[0]["s_locale_id_pk"].ToString();
                Locale.s_locale_title = dtGetLocale.Rows[0]["s_locale_title"].ToString();
                Locale.s_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
              
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// get Report locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetReportLocale(string s_report_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_report_system_id_fk", s_report_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_report_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete report locale
        /// </summary>
        /// <param name="s_report_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteReportLocale(string s_report_system_id_fk, string s_report_locale, string s_report_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_report_system_id_fk))
            {
                htDeleteLocale.Add("@s_report_system_id_fk", s_report_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_report_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_report_locale))
            {
                htDeleteLocale.Add("@s_report_locale", s_report_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_report_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_report_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_report_locale_system_id_pk", s_report_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_report_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_report_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update report locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateReportLocale(SystemReportLocale locale)
        {
            Hashtable htUpdateReportLocale = new Hashtable();
            htUpdateReportLocale.Add("@s_locale_system_id_pk", locale.s_locale_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_locale_title))
            {
                htUpdateReportLocale.Add("@s_locale_title", locale.s_locale_title);
            }
            else
            {
                htUpdateReportLocale.Add("@s_locale_title", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_locale_description))
            {
                htUpdateReportLocale.Add("@s_locale_description", locale.s_locale_description);
            }
            else
            {
                htUpdateReportLocale.Add("@s_locale_description", DBNull.Value);
            }
           
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_report_locale", htUpdateReportLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertReportLocale(SystemReportLocale locale)
        {
            Hashtable htInsertreportLocale = new Hashtable();
            htInsertreportLocale.Add("@s_locale_system_id_pk", Guid.NewGuid());
            htInsertreportLocale.Add("@s_locale_title", locale.s_locale_title);
            htInsertreportLocale.Add("@s_locale_description", locale.s_locale_description);          
            htInsertreportLocale.Add("@s_locale_id_fk", locale.s_locale_id_pk);
            htInsertreportLocale.Add("@s_report_system_id_fk", locale.s_report_system_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_report_locale", htInsertreportLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetReportFields(string s_report_param_field_id_pk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_param_field_id_pk", s_report_param_field_id_pk);
           

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_report_table_field", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
