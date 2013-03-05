using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Web;

namespace ComplicanceFactor.BusinessComponent
{
    public class LanguageBLL
    {
        public static DataTable GetAvailableCulture()
        {

            try
            {
                return DataProxy.FetchDataTable("app_sp_available_culture");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetResourceValue(string s_ui_locale_id_fk, string s_ui_label_Name)
        {


            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_ui_locale_id_fk", s_ui_locale_id_fk);
                htGetResource.Add("@s_ui_label_Name", s_ui_label_Name);

                DataTable dtVal = DataProxy.FetchDataTable("app_sp_resource_label", htGetResource);
                if (dtVal.Rows.Count > 0)
                {
                    return dtVal.Rows[0][0].ToString();
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_id_fk", "en-US");
                    htGetResource1.Add("@s_ui_label_Name", s_ui_label_Name);

                    DataTable dtVal1 = DataProxy.FetchDataTable("app_sp_resource_label", htGetResource1);
                    return dtVal1.Rows[0][0].ToString();

                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetResourceText(string s_ui_locale_id_fk, string s_ui_text_Name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_ui_locale_id_fk", s_ui_locale_id_fk);
                htGetResource.Add("@s_ui_text_Name", s_ui_text_Name);

                DataTable dtVal = DataProxy.FetchDataTable("app_sp_resource_text", htGetResource);
                if (dtVal.Rows.Count > 0)
                {
                    return dtVal.Rows[0][0].ToString();
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_id_fk", "en-US");
                    htGetResource1.Add("@s_ui_text_Name", s_ui_text_Name);

                    DataTable dtVal1 = DataProxy.FetchDataTable("app_sp_resource_text", htGetResource1);
                    return dtVal1.Rows[0][0].ToString();
                }


            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetLocalizationLabel(string s_ui_locale_id_fk, string s_ui_label_Name, string s_ui_page_id_fk)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_ui_locale_id_fk", s_ui_locale_id_fk);
                htGetResource.Add("@s_ui_label_Name", s_ui_label_Name);
                htGetResource.Add("@s_ui_page_id_fk", s_ui_page_id_fk);

                DataTable dtVal = DataProxy.FetchDataTable("app_sp_localization_label", htGetResource);
                if (dtVal.Rows.Count > 0)
                {
                    return dtVal.Rows[0][0].ToString();
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_id_fk", "en-US");
                    htGetResource1.Add("@s_ui_label_Name", s_ui_label_Name);
                    htGetResource1.Add("@s_ui_page_id_fk", s_ui_page_id_fk);
                    DataTable dtVal1 = DataProxy.FetchDataTable("app_sp_localization_label", htGetResource1);
                    return dtVal1.Rows[0][0].ToString();

                }

            }

            catch (Exception)
            {
                throw;
            }
        }

        //New localization
        public static string GetLabel(string s_ui_locale_name, string s_ui_label_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetResource.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetResource.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetResource.Add("@s_ui_label_name", s_ui_label_name);
                htGetResource.Add("@s_ui_page_name", s_ui_page_name);

                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_ui_label", htGetResource);
                if (dtVal.Rows.Count > 0 && !string.IsNullOrEmpty(dtVal.Rows[0][0].ToString()))
                {
                    return SafeString(dtVal.Rows[0][0].ToString());
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_name", "us_english");
                    htGetResource1.Add("@s_ui_label_name", s_ui_label_name);
                    htGetResource1.Add("@s_ui_page_name", s_ui_page_name);
                    DataTable dtVal1 = DataProxy.FetchDataTable("s_sp_get_ui_label", htGetResource1);
                    return SafeString( dtVal1.Rows[0][0].ToString());
                    
                    //return System.Web.HttpUtility.HtmlEncode(dtVal1.Rows[0][0].ToString());

                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetText(string s_ui_locale_name, string s_ui_text_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetResource.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetResource.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetResource.Add("@s_ui_text_name", s_ui_text_name);
                htGetResource.Add("@s_ui_page_name", s_ui_page_name);

                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_ui_text", htGetResource);
                if (dtVal.Rows.Count > 0 && !string.IsNullOrEmpty(dtVal.Rows[0][0].ToString()))
                {
                    return SafeString(dtVal.Rows[0][0].ToString());
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_name", "us_english");
                    htGetResource1.Add("@s_ui_text_name", s_ui_text_name);
                    htGetResource1.Add("@s_ui_page_name", s_ui_page_name);
                    DataTable dtVal1 = DataProxy.FetchDataTable("s_sp_get_ui_text", htGetResource1);
                    return SafeString(dtVal1.Rows[0][0].ToString());

                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetGlobalLabel(string s_ui_locale_name, string s_ui_label_name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetResource.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetResource.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetResource.Add("@s_ui_label_name", s_ui_label_name);
                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_ui_master_label", htGetResource);
                if (dtVal.Rows.Count > 0 && !string.IsNullOrEmpty(dtVal.Rows[0][0].ToString()))
                {
                    return SafeString(dtVal.Rows[0][0].ToString());
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_name", "us_english");
                    htGetResource1.Add("@s_ui_label_name", s_ui_label_name);
                    DataTable dtVal1 = DataProxy.FetchDataTable("s_sp_get_ui_master_label", htGetResource1);
                    return SafeString( dtVal1.Rows[0][0].ToString());

                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static string GetGlobalText(string s_ui_locale_name, string s_ui_text_name)
        {

            try
            {
                Hashtable htGetResource = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetResource.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetResource.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetResource.Add("@s_ui_text_name", s_ui_text_name);
                DataTable dtVal = DataProxy.FetchDataTable("s_sp_get_ui_master_text", htGetResource);
                if (dtVal.Rows.Count > 0 && !string.IsNullOrEmpty(dtVal.Rows[0][0].ToString()))
                {
                    return SafeString(dtVal.Rows[0][0].ToString());
                }
                else
                {
                    Hashtable htGetResource1 = new Hashtable();
                    htGetResource1.Add("@s_ui_locale_name", "us_english");
                    htGetResource1.Add("@s_ui_text_name", s_ui_text_name);
                    DataTable dtVal1 = DataProxy.FetchDataTable("s_sp_get_ui_master_text", htGetResource1);
                    return SafeString(dtVal1.Rows[0][0].ToString());

                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        private static string SafeString(string p)
        {

            return p.Replace("&amp;", "&")

                           .Replace("&lt;", "<")

                           .Replace("&gt;", ">")

                           .Replace("&quot;", "\"")

                           .Replace("&apos;", "'");

        }
    }
}
