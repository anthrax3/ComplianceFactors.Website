using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDocumentTypesBLL
    {
        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmStatus = new Hashtable();
                htGetHarmStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetSearchDocumentTypes(SystemDocumentTypes searchDocumentTypes)
        {

            try
            {
                Hashtable htGetSearchDocumentTypes = new Hashtable();
                htGetSearchDocumentTypes.Add("@s_document_type_id", searchDocumentTypes.s_document_type_id);
                htGetSearchDocumentTypes.Add("@s_document_type_name_us_english", searchDocumentTypes.s_document_type_name_us_english);
                if (searchDocumentTypes.s_document_type_status_id_fk == "0")
                {
                    htGetSearchDocumentTypes.Add("@s_document_type_status_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchDocumentTypes.Add("@s_document_type_status_id_fk", searchDocumentTypes.s_document_type_status_id_fk);
                }
                return DataProxy.FetchDataTable("s_sp_search_document_types", htGetSearchDocumentTypes);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static int CreateDocumentType(SystemDocumentTypes createDocumentType)
        {
            Hashtable htCreateDocumentType = new Hashtable();
            htCreateDocumentType.Add("@s_document_type_system_id_pk", createDocumentType.s_document_type_system_id_pk);
            htCreateDocumentType.Add("@s_document_type_id", createDocumentType.s_document_type_id);
            if (createDocumentType.s_document_type_status_id_fk == "0")
            {
                htCreateDocumentType.Add("@s_document_type_status_id_fk", DBNull.Value);
            }
            else
            {
                htCreateDocumentType.Add("@s_document_type_status_id_fk", createDocumentType.s_document_type_status_id_fk);
            }
            htCreateDocumentType.Add("@s_document_type_name_us_english", createDocumentType.s_document_type_name_us_english);
            htCreateDocumentType.Add("@s_document_type_desc_us_english", createDocumentType.s_document_type_desc_us_english);
            htCreateDocumentType.Add("@s_document_type_name_uk_english", createDocumentType.s_document_type_name_uk_english);
            htCreateDocumentType.Add("@s_document_type_desc_uk_english", createDocumentType.s_document_type_desc_uk_english);
            htCreateDocumentType.Add("@s_document_type_name_ca_french", createDocumentType.s_document_type_name_ca_french);
            htCreateDocumentType.Add("@s_document_type_desc_ca_french", createDocumentType.s_document_type_desc_ca_french);
            htCreateDocumentType.Add("@s_document_type_name_fr_french", createDocumentType.s_document_type_name_fr_french);
            htCreateDocumentType.Add("@s_document_type_desc_fr_french", createDocumentType.s_document_type_desc_fr_french);
            htCreateDocumentType.Add("@s_document_type_name_mx_spanish", createDocumentType.s_document_type_name_mx_spanish);
            htCreateDocumentType.Add("@s_document_type_desc_mx_spanish", createDocumentType.s_document_type_desc_mx_spanish);
            htCreateDocumentType.Add("@s_document_type_name_sp_spanish", createDocumentType.s_document_type_name_sp_spanish);
            htCreateDocumentType.Add("@s_document_type_desc_sp_spanish", createDocumentType.s_document_type_desc_sp_spanish);
            htCreateDocumentType.Add("@s_document_type_name_portuguese", createDocumentType.s_document_type_name_portuguese);
            htCreateDocumentType.Add("@s_document_type_desc_portuguese", createDocumentType.s_document_type_desc_portuguese);
            htCreateDocumentType.Add("@s_document_type_name_simp_chinese", createDocumentType.s_document_type_name_simp_chinese);
            htCreateDocumentType.Add("@s_document_type_desc_simp_chinese", createDocumentType.s_document_type_desc_simp_chinese);
            htCreateDocumentType.Add("@s_document_type_name_german", createDocumentType.s_document_type_name_german);
            htCreateDocumentType.Add("@s_document_type_desc_german", createDocumentType.s_document_type_desc_german);
            htCreateDocumentType.Add("@s_document_type_name_japanese", createDocumentType.s_document_type_name_japanese);
            htCreateDocumentType.Add("@s_document_type_desc_japanese", createDocumentType.s_document_type_desc_japanese);
            htCreateDocumentType.Add("@s_document_type_name_russian", createDocumentType.s_document_type_name_russian);
            htCreateDocumentType.Add("@s_document_type_desc_russian", createDocumentType.s_document_type_desc_russian);
            htCreateDocumentType.Add("@s_document_type_name_danish", createDocumentType.s_document_type_name_danish);
            htCreateDocumentType.Add("@s_document_type_desc_danish", createDocumentType.s_document_type_desc_danish);
            htCreateDocumentType.Add("@s_document_type_name_polish", createDocumentType.s_document_type_name_polish);
            htCreateDocumentType.Add("@s_document_type_desc_polish", createDocumentType.s_document_type_desc_polish);
            htCreateDocumentType.Add("@s_document_type_name_swedish", createDocumentType.s_document_type_name_swedish);
            htCreateDocumentType.Add("@s_document_type_desc_swedish", createDocumentType.s_document_type_desc_swedish);
            htCreateDocumentType.Add("@s_document_type_name_finnish", createDocumentType.s_document_type_name_finnish);
            htCreateDocumentType.Add("@s_document_type_desc_finnish", createDocumentType.s_document_type_desc_finnish);
            htCreateDocumentType.Add("@s_document_type_name_korean", createDocumentType.s_document_type_name_korean);
            htCreateDocumentType.Add("@s_document_type_desc_korean", createDocumentType.s_document_type_desc_korean);
            htCreateDocumentType.Add("@s_document_type_name_italian", createDocumentType.s_document_type_name_italian);
            htCreateDocumentType.Add("@s_document_type_desc_italian", createDocumentType.s_document_type_desc_italian);
            htCreateDocumentType.Add("@s_document_type_name_dutch", createDocumentType.s_document_type_name_dutch);
            htCreateDocumentType.Add("@s_document_type_desc_dutch", createDocumentType.s_document_type_desc_dutch);
            htCreateDocumentType.Add("@s_document_type_name_indonesian", createDocumentType.s_document_type_name_indonesian);
            htCreateDocumentType.Add("@s_document_type_desc_indonesian", createDocumentType.s_document_type_desc_indonesian);
            htCreateDocumentType.Add("@s_document_type_name_greek", createDocumentType.s_document_type_name_greek);
            htCreateDocumentType.Add("@s_document_type_desc_greek", createDocumentType.s_document_type_desc_greek);
            htCreateDocumentType.Add("@s_document_type_name_hungarian", createDocumentType.s_document_type_name_hungarian);
            htCreateDocumentType.Add("@s_document_type_desc_hungarian", createDocumentType.s_document_type_desc_hungarian);
            htCreateDocumentType.Add("@s_document_type_name_norwegian", createDocumentType.s_document_type_name_norwegian);
            htCreateDocumentType.Add("@s_document_type_desc_norwegian", createDocumentType.s_document_type_desc_norwegian);
            htCreateDocumentType.Add("@s_document_type_name_turkish", createDocumentType.s_document_type_name_turkish);
            htCreateDocumentType.Add("@s_document_type_desc_turkish", createDocumentType.s_document_type_desc_turkish);
            htCreateDocumentType.Add("@s_document_type_name_arabic_rtl", createDocumentType.s_document_type_name_arabic_rtl);
            htCreateDocumentType.Add("@s_document_type_desc_arabic_rtl", createDocumentType.s_document_type_desc_arabic_rtl);
            htCreateDocumentType.Add("@s_document_type_name_custom_01", createDocumentType.s_document_type_name_custom_01);
            htCreateDocumentType.Add("@s_document_type_desc_custom_01", createDocumentType.s_document_type_desc_custom_01);
            htCreateDocumentType.Add("@s_document_type_name_custom_02", createDocumentType.s_document_type_name_custom_02);
            htCreateDocumentType.Add("@s_document_type_desc_custom_02", createDocumentType.s_document_type_desc_custom_02);
            htCreateDocumentType.Add("@s_document_type_name_custom_03", createDocumentType.s_document_type_name_custom_03);
            htCreateDocumentType.Add("@s_document_type_desc_custom_03", createDocumentType.s_document_type_desc_custom_03);
            htCreateDocumentType.Add("@s_document_type_name_custom_04", createDocumentType.s_document_type_name_custom_04);
            htCreateDocumentType.Add("@s_document_type_desc_custom_04", createDocumentType.s_document_type_desc_custom_04);
            htCreateDocumentType.Add("@s_document_type_name_custom_05", createDocumentType.s_document_type_name_custom_05);
            htCreateDocumentType.Add("@s_document_type_desc_custom_05", createDocumentType.s_document_type_desc_custom_05);
            htCreateDocumentType.Add("@s_document_type_name_custom_06", createDocumentType.s_document_type_name_custom_06);
            htCreateDocumentType.Add("@s_document_type_desc_custom_06", createDocumentType.s_document_type_desc_custom_06);
            htCreateDocumentType.Add("@s_document_type_name_custom_07", createDocumentType.s_document_type_name_custom_07);
            htCreateDocumentType.Add("@s_document_type_desc_custom_07", createDocumentType.s_document_type_desc_custom_07);
            htCreateDocumentType.Add("@s_document_type_name_custom_08", createDocumentType.s_document_type_name_custom_08);
            htCreateDocumentType.Add("@s_document_type_desc_custom_08", createDocumentType.s_document_type_desc_custom_08);
            htCreateDocumentType.Add("@s_document_type_name_custom_09", createDocumentType.s_document_type_name_custom_09);
            htCreateDocumentType.Add("@s_document_type_desc_custom_09", createDocumentType.s_document_type_desc_custom_09);
            htCreateDocumentType.Add("@s_document_type_name_custom_10", createDocumentType.s_document_type_name_custom_10);
            htCreateDocumentType.Add("@s_document_type_desc_custom_10", createDocumentType.s_document_type_desc_custom_10);
            htCreateDocumentType.Add("@s_document_type_name_custom_11", createDocumentType.s_document_type_name_custom_11);
            htCreateDocumentType.Add("@s_document_type_desc_custom_11", createDocumentType.s_document_type_desc_custom_11);
            htCreateDocumentType.Add("@s_document_type_name_custom_12", createDocumentType.s_document_type_name_custom_12);
            htCreateDocumentType.Add("@s_document_type_desc_custom_12", createDocumentType.s_document_type_desc_custom_12);
            htCreateDocumentType.Add("@s_document_type_name_custom_13", createDocumentType.s_document_type_name_custom_13);
            htCreateDocumentType.Add("@s_document_type_desc_custom_13", createDocumentType.s_document_type_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_document_types", htCreateDocumentType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemDocumentTypes GetDocumentTypeInfo(string s_document_type_system_id_pk)
        {
            SystemDocumentTypes DocumentType;
            try
            {
                Hashtable htGetDocumentType = new Hashtable();
                htGetDocumentType.Add("@s_document_type_system_id_pk", s_document_type_system_id_pk);
                DocumentType = new SystemDocumentTypes();

                DataTable dtGetDocumentType = DataProxy.FetchDataTable("s_sp_get_single_document_type", htGetDocumentType);

                //DocumentType.s_grading_scheme_system_id_pk = dtGetGradingSchemes.Rows[0]["s_grading_scheme_system_id_pk"].ToString();
                DocumentType.s_document_type_id = dtGetDocumentType.Rows[0]["s_document_type_id"].ToString();
                DocumentType.s_document_type_status_id_fk = dtGetDocumentType.Rows[0]["s_document_type_status_id_fk"].ToString();
                DocumentType.s_document_type_name_us_english = dtGetDocumentType.Rows[0]["s_document_type_name_us_english"].ToString();
                DocumentType.s_document_type_desc_us_english = dtGetDocumentType.Rows[0]["s_document_type_desc_us_english"].ToString();
                DocumentType.s_document_type_name_uk_english = dtGetDocumentType.Rows[0]["s_document_type_name_uk_english"].ToString();
                DocumentType.s_document_type_desc_uk_english = dtGetDocumentType.Rows[0]["s_document_type_desc_uk_english"].ToString();
                DocumentType.s_document_type_name_ca_french = dtGetDocumentType.Rows[0]["s_document_type_name_ca_french"].ToString();
                DocumentType.s_document_type_desc_ca_french = dtGetDocumentType.Rows[0]["s_document_type_desc_ca_french"].ToString();
                DocumentType.s_document_type_name_fr_french = dtGetDocumentType.Rows[0]["s_document_type_name_fr_french"].ToString();
                DocumentType.s_document_type_desc_fr_french = dtGetDocumentType.Rows[0]["s_document_type_desc_fr_french"].ToString();
                DocumentType.s_document_type_name_mx_spanish = dtGetDocumentType.Rows[0]["s_document_type_name_mx_spanish"].ToString();
                DocumentType.s_document_type_desc_mx_spanish = dtGetDocumentType.Rows[0]["s_document_type_desc_mx_spanish"].ToString();
                DocumentType.s_document_type_name_sp_spanish = dtGetDocumentType.Rows[0]["s_document_type_name_sp_spanish"].ToString();
                DocumentType.s_document_type_desc_sp_spanish = dtGetDocumentType.Rows[0]["s_document_type_desc_sp_spanish"].ToString();
                DocumentType.s_document_type_name_portuguese = dtGetDocumentType.Rows[0]["s_document_type_name_portuguese"].ToString();
                DocumentType.s_document_type_desc_portuguese = dtGetDocumentType.Rows[0]["s_document_type_desc_portuguese"].ToString();
                DocumentType.s_document_type_name_simp_chinese = dtGetDocumentType.Rows[0]["s_document_type_name_simp_chinese"].ToString();
                DocumentType.s_document_type_desc_simp_chinese = dtGetDocumentType.Rows[0]["s_document_type_desc_simp_chinese"].ToString();
                DocumentType.s_document_type_name_german = dtGetDocumentType.Rows[0]["s_document_type_name_german"].ToString();
                DocumentType.s_document_type_desc_german = dtGetDocumentType.Rows[0]["s_document_type_desc_german"].ToString();
                DocumentType.s_document_type_name_japanese = dtGetDocumentType.Rows[0]["s_document_type_name_japanese"].ToString();
                DocumentType.s_document_type_desc_japanese = dtGetDocumentType.Rows[0]["s_document_type_desc_japanese"].ToString();
                DocumentType.s_document_type_name_russian = dtGetDocumentType.Rows[0]["s_document_type_name_russian"].ToString();
                DocumentType.s_document_type_desc_russian = dtGetDocumentType.Rows[0]["s_document_type_desc_russian"].ToString();
                DocumentType.s_document_type_name_danish = dtGetDocumentType.Rows[0]["s_document_type_name_danish"].ToString();
                DocumentType.s_document_type_desc_danish = dtGetDocumentType.Rows[0]["s_document_type_desc_danish"].ToString();
                DocumentType.s_document_type_name_polish = dtGetDocumentType.Rows[0]["s_document_type_name_polish"].ToString();
                DocumentType.s_document_type_desc_polish = dtGetDocumentType.Rows[0]["s_document_type_desc_polish"].ToString();
                DocumentType.s_document_type_name_swedish = dtGetDocumentType.Rows[0]["s_document_type_name_swedish"].ToString();
                DocumentType.s_document_type_desc_swedish = dtGetDocumentType.Rows[0]["s_document_type_desc_swedish"].ToString();
                DocumentType.s_document_type_name_finnish = dtGetDocumentType.Rows[0]["s_document_type_name_finnish"].ToString();
                DocumentType.s_document_type_desc_finnish = dtGetDocumentType.Rows[0]["s_document_type_desc_finnish"].ToString();
                DocumentType.s_document_type_name_korean = dtGetDocumentType.Rows[0]["s_document_type_name_korean"].ToString();
                DocumentType.s_document_type_desc_korean = dtGetDocumentType.Rows[0]["s_document_type_desc_korean"].ToString();
                DocumentType.s_document_type_name_italian = dtGetDocumentType.Rows[0]["s_document_type_name_italian"].ToString();
                DocumentType.s_document_type_desc_italian = dtGetDocumentType.Rows[0]["s_document_type_desc_italian"].ToString();
                DocumentType.s_document_type_name_dutch = dtGetDocumentType.Rows[0]["s_document_type_name_dutch"].ToString();
                DocumentType.s_document_type_desc_dutch = dtGetDocumentType.Rows[0]["s_document_type_desc_dutch"].ToString();
                DocumentType.s_document_type_name_indonesian = dtGetDocumentType.Rows[0]["s_document_type_name_indonesian"].ToString();
                DocumentType.s_document_type_desc_indonesian = dtGetDocumentType.Rows[0]["s_document_type_desc_indonesian"].ToString();
                DocumentType.s_document_type_name_greek = dtGetDocumentType.Rows[0]["s_document_type_name_greek"].ToString();
                DocumentType.s_document_type_desc_greek = dtGetDocumentType.Rows[0]["s_document_type_desc_greek"].ToString();
                DocumentType.s_document_type_name_hungarian = dtGetDocumentType.Rows[0]["s_document_type_name_hungarian"].ToString();
                DocumentType.s_document_type_desc_hungarian = dtGetDocumentType.Rows[0]["s_document_type_desc_hungarian"].ToString();
                DocumentType.s_document_type_name_norwegian = dtGetDocumentType.Rows[0]["s_document_type_name_norwegian"].ToString();
                DocumentType.s_document_type_desc_norwegian = dtGetDocumentType.Rows[0]["s_document_type_desc_norwegian"].ToString();
                DocumentType.s_document_type_name_turkish = dtGetDocumentType.Rows[0]["s_document_type_name_turkish"].ToString();
                DocumentType.s_document_type_desc_turkish = dtGetDocumentType.Rows[0]["s_document_type_desc_turkish"].ToString();
                DocumentType.s_document_type_name_arabic_rtl = dtGetDocumentType.Rows[0]["s_document_type_name_arabic_rtl"].ToString();
                DocumentType.s_document_type_desc_arabic_rtl = dtGetDocumentType.Rows[0]["s_document_type_desc_arabic_rtl"].ToString();
                DocumentType.s_document_type_name_custom_01 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_01"].ToString();
                DocumentType.s_document_type_desc_custom_01 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_01"].ToString();
                DocumentType.s_document_type_name_custom_02 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_02"].ToString();
                DocumentType.s_document_type_desc_custom_02 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_02"].ToString();
                DocumentType.s_document_type_name_custom_03 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_03"].ToString();
                DocumentType.s_document_type_desc_custom_03 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_03"].ToString();
                DocumentType.s_document_type_name_custom_04 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_04"].ToString();
                DocumentType.s_document_type_desc_custom_04 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_04"].ToString();
                DocumentType.s_document_type_name_custom_05 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_05"].ToString();
                DocumentType.s_document_type_desc_custom_05 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_05"].ToString();
                DocumentType.s_document_type_name_custom_06 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_06"].ToString();
                DocumentType.s_document_type_desc_custom_06 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_06"].ToString();
                DocumentType.s_document_type_name_custom_07 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_07"].ToString();
                DocumentType.s_document_type_desc_custom_07 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_07"].ToString();
                DocumentType.s_document_type_name_custom_08 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_08"].ToString();
                DocumentType.s_document_type_desc_custom_08 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_08"].ToString();
                DocumentType.s_document_type_name_custom_09 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_09"].ToString();
                DocumentType.s_document_type_desc_custom_09 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_09"].ToString();
                DocumentType.s_document_type_name_custom_10 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_10"].ToString();
                DocumentType.s_document_type_desc_custom_10 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_10"].ToString();
                DocumentType.s_document_type_name_custom_11 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_11"].ToString();
                DocumentType.s_document_type_desc_custom_11 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_11"].ToString();
                DocumentType.s_document_type_name_custom_12 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_12"].ToString();
                DocumentType.s_document_type_desc_custom_12 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_12"].ToString();
                DocumentType.s_document_type_name_custom_13 = dtGetDocumentType.Rows[0]["s_document_type_name_custom_13"].ToString();
                DocumentType.s_document_type_desc_custom_13 = dtGetDocumentType.Rows[0]["s_document_type_desc_custom_13"].ToString();
                return DocumentType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateDocumentType(SystemDocumentTypes updateDocumentType)
        {
            Hashtable htUpdateDocumentType = new Hashtable();
            htUpdateDocumentType.Add("@s_document_type_system_id_pk", updateDocumentType.s_document_type_system_id_pk);
            htUpdateDocumentType.Add("@s_document_type_id", updateDocumentType.s_document_type_id);
            htUpdateDocumentType.Add("@s_document_type_status_id_fk", updateDocumentType.s_document_type_status_id_fk);
            htUpdateDocumentType.Add("@s_document_type_name_us_english", updateDocumentType.s_document_type_name_us_english);
            htUpdateDocumentType.Add("@s_document_type_desc_us_english", updateDocumentType.s_document_type_desc_us_english);
            htUpdateDocumentType.Add("@s_document_type_name_uk_english", updateDocumentType.s_document_type_name_uk_english);
            htUpdateDocumentType.Add("@s_document_type_desc_uk_english", updateDocumentType.s_document_type_desc_uk_english);
            htUpdateDocumentType.Add("@s_document_type_name_ca_french", updateDocumentType.s_document_type_name_ca_french);
            htUpdateDocumentType.Add("@s_document_type_desc_ca_french", updateDocumentType.s_document_type_desc_ca_french);
            htUpdateDocumentType.Add("@s_document_type_name_fr_french", updateDocumentType.s_document_type_name_fr_french);
            htUpdateDocumentType.Add("@s_document_type_desc_fr_french", updateDocumentType.s_document_type_desc_fr_french);
            htUpdateDocumentType.Add("@s_document_type_name_mx_spanish", updateDocumentType.s_document_type_name_mx_spanish);
            htUpdateDocumentType.Add("@s_document_type_desc_mx_spanish", updateDocumentType.s_document_type_desc_mx_spanish);
            htUpdateDocumentType.Add("@s_document_type_name_sp_spanish", updateDocumentType.s_document_type_name_sp_spanish);
            htUpdateDocumentType.Add("@s_document_type_desc_sp_spanish", updateDocumentType.s_document_type_desc_sp_spanish);
            htUpdateDocumentType.Add("@s_document_type_name_portuguese", updateDocumentType.s_document_type_name_portuguese);
            htUpdateDocumentType.Add("@s_document_type_desc_portuguese", updateDocumentType.s_document_type_desc_portuguese);
            htUpdateDocumentType.Add("@s_document_type_name_simp_chinese", updateDocumentType.s_document_type_name_simp_chinese);
            htUpdateDocumentType.Add("@s_document_type_desc_simp_chinese", updateDocumentType.s_document_type_desc_simp_chinese);
            htUpdateDocumentType.Add("@s_document_type_name_german", updateDocumentType.s_document_type_name_german);
            htUpdateDocumentType.Add("@s_document_type_desc_german", updateDocumentType.s_document_type_desc_german);
            htUpdateDocumentType.Add("@s_document_type_name_japanese", updateDocumentType.s_document_type_name_japanese);
            htUpdateDocumentType.Add("@s_document_type_desc_japanese", updateDocumentType.s_document_type_desc_japanese);
            htUpdateDocumentType.Add("@s_document_type_name_russian", updateDocumentType.s_document_type_name_russian);
            htUpdateDocumentType.Add("@s_document_type_desc_russian", updateDocumentType.s_document_type_desc_russian);
            htUpdateDocumentType.Add("@s_document_type_name_danish", updateDocumentType.s_document_type_name_danish);
            htUpdateDocumentType.Add("@s_document_type_desc_danish", updateDocumentType.s_document_type_desc_danish);
            htUpdateDocumentType.Add("@s_document_type_name_polish", updateDocumentType.s_document_type_name_polish);
            htUpdateDocumentType.Add("@s_document_type_desc_polish", updateDocumentType.s_document_type_desc_polish);
            htUpdateDocumentType.Add("@s_document_type_name_swedish", updateDocumentType.s_document_type_name_swedish);
            htUpdateDocumentType.Add("@s_document_type_desc_swedish", updateDocumentType.s_document_type_desc_swedish);
            htUpdateDocumentType.Add("@s_document_type_name_finnish", updateDocumentType.s_document_type_name_finnish);
            htUpdateDocumentType.Add("@s_document_type_desc_finnish", updateDocumentType.s_document_type_desc_finnish);
            htUpdateDocumentType.Add("@s_document_type_name_korean", updateDocumentType.s_document_type_name_korean);
            htUpdateDocumentType.Add("@s_document_type_desc_korean", updateDocumentType.s_document_type_desc_korean);
            htUpdateDocumentType.Add("@s_document_type_name_italian", updateDocumentType.s_document_type_name_italian);
            htUpdateDocumentType.Add("@s_document_type_desc_italian", updateDocumentType.s_document_type_desc_italian);
            htUpdateDocumentType.Add("@s_document_type_name_dutch", updateDocumentType.s_document_type_name_dutch);
            htUpdateDocumentType.Add("@s_document_type_desc_dutch", updateDocumentType.s_document_type_desc_dutch);
            htUpdateDocumentType.Add("@s_document_type_name_indonesian", updateDocumentType.s_document_type_name_indonesian);
            htUpdateDocumentType.Add("@s_document_type_desc_indonesian", updateDocumentType.s_document_type_desc_indonesian);
            htUpdateDocumentType.Add("@s_document_type_name_greek", updateDocumentType.s_document_type_name_greek);
            htUpdateDocumentType.Add("@s_document_type_desc_greek", updateDocumentType.s_document_type_desc_greek);
            htUpdateDocumentType.Add("@s_document_type_name_hungarian", updateDocumentType.s_document_type_name_hungarian);
            htUpdateDocumentType.Add("@s_document_type_desc_hungarian", updateDocumentType.s_document_type_desc_hungarian);
            htUpdateDocumentType.Add("@s_document_type_name_norwegian", updateDocumentType.s_document_type_name_norwegian);
            htUpdateDocumentType.Add("@s_document_type_desc_norwegian", updateDocumentType.s_document_type_desc_norwegian);
            htUpdateDocumentType.Add("@s_document_type_name_turkish", updateDocumentType.s_document_type_name_turkish);
            htUpdateDocumentType.Add("@s_document_type_desc_turkish", updateDocumentType.s_document_type_desc_turkish);
            htUpdateDocumentType.Add("@s_document_type_name_arabic_rtl", updateDocumentType.s_document_type_name_arabic_rtl);
            htUpdateDocumentType.Add("@s_document_type_desc_arabic_rtl", updateDocumentType.s_document_type_desc_arabic_rtl);
            htUpdateDocumentType.Add("@s_document_type_name_custom_01", updateDocumentType.s_document_type_name_custom_01);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_01", updateDocumentType.s_document_type_desc_custom_01);
            htUpdateDocumentType.Add("@s_document_type_name_custom_02", updateDocumentType.s_document_type_name_custom_02);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_02", updateDocumentType.s_document_type_desc_custom_02);
            htUpdateDocumentType.Add("@s_document_type_name_custom_03", updateDocumentType.s_document_type_name_custom_03);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_03", updateDocumentType.s_document_type_desc_custom_03);
            htUpdateDocumentType.Add("@s_document_type_name_custom_04", updateDocumentType.s_document_type_name_custom_04);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_04", updateDocumentType.s_document_type_desc_custom_04);
            htUpdateDocumentType.Add("@s_document_type_name_custom_05", updateDocumentType.s_document_type_name_custom_05);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_05", updateDocumentType.s_document_type_desc_custom_05);
            htUpdateDocumentType.Add("@s_document_type_name_custom_06", updateDocumentType.s_document_type_name_custom_06);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_06", updateDocumentType.s_document_type_desc_custom_06);
            htUpdateDocumentType.Add("@s_document_type_name_custom_07", updateDocumentType.s_document_type_name_custom_07);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_07", updateDocumentType.s_document_type_desc_custom_07);
            htUpdateDocumentType.Add("@s_document_type_name_custom_08", updateDocumentType.s_document_type_name_custom_08);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_08", updateDocumentType.s_document_type_desc_custom_08);
            htUpdateDocumentType.Add("@s_document_type_name_custom_09", updateDocumentType.s_document_type_name_custom_09);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_09", updateDocumentType.s_document_type_desc_custom_09);
            htUpdateDocumentType.Add("@s_document_type_name_custom_10", updateDocumentType.s_document_type_name_custom_10);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_10", updateDocumentType.s_document_type_desc_custom_10);
            htUpdateDocumentType.Add("@s_document_type_name_custom_11", updateDocumentType.s_document_type_name_custom_11);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_11", updateDocumentType.s_document_type_desc_custom_11);
            htUpdateDocumentType.Add("@s_document_type_name_custom_12", updateDocumentType.s_document_type_name_custom_12);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_12", updateDocumentType.s_document_type_desc_custom_12);
            htUpdateDocumentType.Add("@s_document_type_name_custom_13", updateDocumentType.s_document_type_name_custom_13);
            htUpdateDocumentType.Add("@s_document_type_desc_custom_13", updateDocumentType.s_document_type_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document_types", htUpdateDocumentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateDocumentTypeStatus(string documentTypeId)
        {
            Hashtable htUpdateDocumentTypeStatus = new Hashtable();
            htUpdateDocumentTypeStatus.Add("@s_document_type_system_id_pk", documentTypeId);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document_type_status", htUpdateDocumentTypeStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
