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
    public class SystemAudiencesBLL
    {

        /// <summary>
        /// Get status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get all status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetAllStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create Audience
        /// </summary>
        /// <param name="createAudience"></param>
        /// <returns></returns>
        public static int CreateAudience(SystemAudiences createAudience)
        {
            Hashtable htCreateAudience = new Hashtable();
            htCreateAudience.Add("@u_audience_system_id_pk", createAudience.u_audience_system_id_pk);
            htCreateAudience.Add("@u_audience_id_pk", createAudience.u_audience_id_pk);
            if (createAudience.u_audience_status_id_fk == "0")
            {
                htCreateAudience.Add("@u_audience_status_id_fk", DBNull.Value);
            }
            else
            {
                htCreateAudience.Add("@u_audience_status_id_fk", createAudience.u_audience_status_id_fk);
            }
            htCreateAudience.Add("@u_audience_name", createAudience.u_audience_name);
            htCreateAudience.Add("@u_audience_desc", createAudience.u_audience_desc);
            htCreateAudience.Add("u_audience_name_uk_english", createAudience.u_audience_name_uk_english);
            htCreateAudience.Add("@u_audience_desc_uk_english", createAudience.u_audience_desc_uk_english);
            htCreateAudience.Add("@u_audience_name_ca_france", createAudience.u_audience_name_ca_france);
            htCreateAudience.Add("@u_audience_desc_ca_france", createAudience.u_audience_desc_ca_france);
            htCreateAudience.Add("@u_audience_name_fr_french", createAudience.u_audience_name_fr_french);
            htCreateAudience.Add("@u_audience_desc_fr_french", createAudience.u_audience_desc_fr_french);
            htCreateAudience.Add("@u_audience_name_mx_spanish", createAudience.u_audience_name_mx_spanish);
            htCreateAudience.Add("@u_audience_desc_mx_spanish", createAudience.u_audience_desc_mx_spanish);
            htCreateAudience.Add("@u_audience_name_sp_spanish", createAudience.u_audience_name_sp_spanish);
            htCreateAudience.Add("@u_audience_desc_sp_spanish", createAudience.u_audience_desc_sp_spanish);
            htCreateAudience.Add("@u_audience_name_portuguse", createAudience.u_audience_name_portuguse);
            htCreateAudience.Add("@u_audience_desc_portuguse", createAudience.u_audience_desc_portuguse);
            htCreateAudience.Add("@u_audience_name_chinese", createAudience.u_audience_name_chinese);
            htCreateAudience.Add("@u_audience_desc_chinese", createAudience.u_audience_desc_chinese);
            htCreateAudience.Add("@u_audience_name_german", createAudience.u_audience_name_german);
            htCreateAudience.Add("@u_audience_desc_german", createAudience.u_audience_desc_german);
            htCreateAudience.Add("@u_audience_name_japanese", createAudience.u_audience_name_japanese);
            htCreateAudience.Add("@u_audience_desc_japanese", createAudience.u_audience_desc_japanese);
            htCreateAudience.Add("@u_audience_name_russian", createAudience.u_audience_name_russian);
            htCreateAudience.Add("@u_audience_desc_russian", createAudience.u_audience_desc_russian);
            htCreateAudience.Add("@u_audience_name_danish", createAudience.u_audience_name_danish);
            htCreateAudience.Add("@u_audience_desc_danish", createAudience.u_audience_desc_danish);
            htCreateAudience.Add("@u_audience_name_polish", createAudience.u_audience_name_polish);
            htCreateAudience.Add("@u_audience_desc_polish", createAudience.u_audience_desc_polish);
            htCreateAudience.Add("@u_audience_name_swedish", createAudience.u_audience_name_swedish);
            htCreateAudience.Add("@u_audience_desc_swedish", createAudience.u_audience_desc_swedish);
            htCreateAudience.Add("@u_audience_name_finnish", createAudience.u_audience_name_finnish);
            htCreateAudience.Add("@u_audience_desc_finnish", createAudience.u_audience_desc_finnish);
            htCreateAudience.Add("@u_audience_name_korean", createAudience.u_audience_name_korean);
            htCreateAudience.Add("@u_audience_desc_korean", createAudience.u_audience_desc_korean);
            htCreateAudience.Add("@u_audience_name_italian", createAudience.u_audience_name_italian);
            htCreateAudience.Add("@u_audience_desc_italian", createAudience.u_audience_desc_italian);
            htCreateAudience.Add("@u_audience_name_dutch", createAudience.u_audience_name_dutch);
            htCreateAudience.Add("@u_audience_desc_dutch", createAudience.u_audience_desc_dutch);
            htCreateAudience.Add("@u_audience_name_indonesian", createAudience.u_audience_name_indonesian);
            htCreateAudience.Add("@u_audience_desc_indonesian", createAudience.u_audience_desc_indonesian);
            htCreateAudience.Add("@u_audience_name_greek", createAudience.u_audience_name_greek);
            htCreateAudience.Add("@u_audience_desc_greek", createAudience.u_audience_desc_greek);
            htCreateAudience.Add("@u_audience_name_hungarian", createAudience.u_audience_name_hungarian);
            htCreateAudience.Add("@u_audience_desc_hungarian", createAudience.u_audience_desc_hungarian);
            htCreateAudience.Add("@u_audience_name_norwegian", createAudience.u_audience_name_norwegian);
            htCreateAudience.Add("@u_audience_desc_norwegian", createAudience.u_audience_desc_norwegian);
            htCreateAudience.Add("@u_audience_name_turkish", createAudience.u_audience_name_turkish);
            htCreateAudience.Add("@u_audience_desc_turkish", createAudience.u_audience_desc_turkish);
            htCreateAudience.Add("@u_audience_name_arabic", createAudience.u_audience_name_arabic);
            htCreateAudience.Add("@u_audience_desc_arabic", createAudience.u_audience_desc_arabic);
            htCreateAudience.Add("@u_audience_name_custom_01", createAudience.u_audience_name_custom_01);
            htCreateAudience.Add("@u_audience_desc_custom_01", createAudience.u_audience_desc_custom_01);
            htCreateAudience.Add("@u_audience_name_custom_02", createAudience.u_audience_name_custom_02);
            htCreateAudience.Add("@u_audience_desc_custom_02", createAudience.u_audience_desc_custom_02);
            htCreateAudience.Add("@u_audience_name_custom_03", createAudience.u_audience_name_custom_03);
            htCreateAudience.Add("@u_audience_desc_custom_03", createAudience.u_audience_desc_custom_03);
            htCreateAudience.Add("@u_audience_name_custom_04", createAudience.u_audience_name_custom_04);
            htCreateAudience.Add("@u_audience_desc_custom_04", createAudience.u_audience_desc_custom_04);
            htCreateAudience.Add("@u_audience_name_custom_05", createAudience.u_audience_name_custom_05);
            htCreateAudience.Add("@u_audience_desc_custom_05", createAudience.u_audience_desc_custom_05);
            htCreateAudience.Add("@u_audience_name_custom_06", createAudience.u_audience_name_custom_06);
            htCreateAudience.Add("@u_audience_desc_custom_06", createAudience.u_audience_desc_custom_06);
            htCreateAudience.Add("@u_audience_name_custom_07", createAudience.u_audience_name_custom_07);
            htCreateAudience.Add("@u_audience_desc_custom_07", createAudience.u_audience_desc_custom_07);
            htCreateAudience.Add("@u_audience_name_custom_08", createAudience.u_audience_name_custom_08);
            htCreateAudience.Add("@u_audience_desc_custom_08", createAudience.u_audience_desc_custom_08);
            htCreateAudience.Add("@u_audience_name_custom_09", createAudience.u_audience_name_custom_09);
            htCreateAudience.Add("@u_audience_desc_custom_09", createAudience.u_audience_desc_custom_09);
            htCreateAudience.Add("@u_audience_name_custom_10", createAudience.u_audience_name_custom_10);
            htCreateAudience.Add("@u_audience_desc_custom_10", createAudience.u_audience_desc_custom_10);
            htCreateAudience.Add("@u_audience_name_custom_11", createAudience.u_audience_name_custom_11);
            htCreateAudience.Add("@u_audience_desc_custom_11", createAudience.u_audience_desc_custom_11);
            htCreateAudience.Add("@u_audience_name_custom_12", createAudience.u_audience_name_custom_12);
            htCreateAudience.Add("@u_audience_desc_custom_12", createAudience.u_audience_desc_custom_12);
            htCreateAudience.Add("@u_audience_name_custom_13", createAudience.u_audience_name_custom_13);
            htCreateAudience.Add("@u_audience_desc_custom_13", createAudience.u_audience_name_custom_13);
            if (createAudience.audiences_parameters != null)
            {
                htCreateAudience.Add("@audiences_parameters", createAudience.audiences_parameters);
            }
            else
            {
                htCreateAudience.Add("@audiences_parameters", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("e_sp_insert_audience", htCreateAudience);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get audience
        /// </summary>
        /// <param name="u_audience_system_id_pk"></param>
        /// <returns></returns>
        public static SystemAudiences GetAudience(string u_audience_system_id_pk)
        {
            SystemAudiences Audience;
            try
            {
                Hashtable htGetAudience = new Hashtable();
                htGetAudience.Add("@u_audience_system_id_pk", u_audience_system_id_pk);
                Audience = new SystemAudiences();

                DataTable dtGetAudience = DataProxy.FetchDataTable("e_sp_get_audience", htGetAudience);
                Audience.u_audience_system_id_pk = dtGetAudience.Rows[0]["u_audience_system_id_pk"].ToString();
                Audience.u_audience_id_pk = dtGetAudience.Rows[0]["u_audience_id_pk"].ToString();
                Audience.u_audience_status_id_fk = dtGetAudience.Rows[0]["u_audience_status_id_fk"].ToString();
                Audience.u_audience_name = dtGetAudience.Rows[0]["u_audience_name"].ToString();
                Audience.u_audience_desc = dtGetAudience.Rows[0]["u_audience_desc"].ToString();
                Audience.u_audience_name_uk_english = dtGetAudience.Rows[0]["u_audience_name_uk_english"].ToString();
                Audience.u_audience_desc_uk_english = dtGetAudience.Rows[0]["u_audience_desc_uk_english"].ToString();
                Audience.u_audience_name_ca_france = dtGetAudience.Rows[0]["u_audience_name_ca_france"].ToString();
                Audience.u_audience_desc_ca_france = dtGetAudience.Rows[0]["u_audience_desc_ca_france"].ToString();
                Audience.u_audience_name_fr_french = dtGetAudience.Rows[0]["u_audience_name_fr_french"].ToString();
                Audience.u_audience_desc_fr_french = dtGetAudience.Rows[0]["u_audience_desc_fr_french"].ToString();
                Audience.u_audience_name_mx_spanish = dtGetAudience.Rows[0]["u_audience_name_mx_spanish"].ToString();
                Audience.u_audience_desc_mx_spanish = dtGetAudience.Rows[0]["u_audience_desc_mx_spanish"].ToString();
                Audience.u_audience_name_sp_spanish = dtGetAudience.Rows[0]["u_audience_name_sp_spanish"].ToString();
                Audience.u_audience_desc_sp_spanish = dtGetAudience.Rows[0]["u_audience_desc_sp_spanish"].ToString();
                Audience.u_audience_name_portuguse = dtGetAudience.Rows[0]["u_audience_name_portuguse"].ToString();
                Audience.u_audience_desc_portuguse = dtGetAudience.Rows[0]["u_audience_desc_portuguse"].ToString();
                Audience.u_audience_name_chinese = dtGetAudience.Rows[0]["u_audience_name_chinese"].ToString();
                Audience.u_audience_desc_chinese = dtGetAudience.Rows[0]["u_audience_desc_chinese"].ToString();
                Audience.u_audience_name_german = dtGetAudience.Rows[0]["u_audience_name_german"].ToString();
                Audience.u_audience_desc_german = dtGetAudience.Rows[0]["u_audience_desc_german"].ToString();
                Audience.u_audience_name_japanese = dtGetAudience.Rows[0]["u_audience_name_japanese"].ToString();
                Audience.u_audience_desc_japanese = dtGetAudience.Rows[0]["u_audience_desc_japanese"].ToString();
                Audience.u_audience_name_russian = dtGetAudience.Rows[0]["u_audience_name_russian"].ToString();
                Audience.u_audience_desc_russian = dtGetAudience.Rows[0]["u_audience_desc_russian"].ToString();
                Audience.u_audience_name_danish = dtGetAudience.Rows[0]["u_audience_name_danish"].ToString();
                Audience.u_audience_desc_danish = dtGetAudience.Rows[0]["u_audience_desc_danish"].ToString();
                Audience.u_audience_name_polish = dtGetAudience.Rows[0]["u_audience_name_polish"].ToString();
                Audience.u_audience_desc_polish = dtGetAudience.Rows[0]["u_audience_desc_polish"].ToString();
                Audience.u_audience_name_swedish = dtGetAudience.Rows[0]["u_audience_name_swedish"].ToString();
                Audience.u_audience_desc_swedish = dtGetAudience.Rows[0]["u_audience_desc_swedish"].ToString();
                Audience.u_audience_name_finnish = dtGetAudience.Rows[0]["u_audience_name_finnish"].ToString();
                Audience.u_audience_desc_finnish = dtGetAudience.Rows[0]["u_audience_desc_finnish"].ToString();
                Audience.u_audience_name_korean = dtGetAudience.Rows[0]["u_audience_name_korean"].ToString();
                Audience.u_audience_desc_korean = dtGetAudience.Rows[0]["u_audience_desc_korean"].ToString();
                Audience.u_audience_name_italian = dtGetAudience.Rows[0]["u_audience_name_italian"].ToString();
                Audience.u_audience_desc_italian = dtGetAudience.Rows[0]["u_audience_desc_italian"].ToString();
                Audience.u_audience_name_dutch = dtGetAudience.Rows[0]["u_audience_name_dutch"].ToString();
                Audience.u_audience_desc_dutch = dtGetAudience.Rows[0]["u_audience_desc_dutch"].ToString();
                Audience.u_audience_name_indonesian = dtGetAudience.Rows[0]["u_audience_name_indonesian"].ToString();
                Audience.u_audience_desc_indonesian = dtGetAudience.Rows[0]["u_audience_desc_indonesian"].ToString();
                Audience.u_audience_name_greek = dtGetAudience.Rows[0]["u_audience_name_greek"].ToString();
                Audience.u_audience_desc_greek = dtGetAudience.Rows[0]["u_audience_desc_greek"].ToString();
                Audience.u_audience_name_hungarian = dtGetAudience.Rows[0]["u_audience_name_hungarian"].ToString();
                Audience.u_audience_desc_hungarian = dtGetAudience.Rows[0]["u_audience_desc_hungarian"].ToString();
                Audience.u_audience_name_norwegian = dtGetAudience.Rows[0]["u_audience_name_norwegian"].ToString();
                Audience.u_audience_desc_norwegian = dtGetAudience.Rows[0]["u_audience_desc_norwegian"].ToString();
                Audience.u_audience_name_turkish = dtGetAudience.Rows[0]["u_audience_name_turkish"].ToString();
                Audience.u_audience_desc_turkish = dtGetAudience.Rows[0]["u_audience_desc_turkish"].ToString();
                Audience.u_audience_name_arabic = dtGetAudience.Rows[0]["u_audience_name_arabic"].ToString();
                Audience.u_audience_desc_arabic = dtGetAudience.Rows[0]["u_audience_desc_arabic"].ToString();
                Audience.u_audience_name_custom_01 = dtGetAudience.Rows[0]["u_audience_name_custom_01"].ToString();
                Audience.u_audience_desc_custom_01 = dtGetAudience.Rows[0]["u_audience_desc_custom_01"].ToString();
                Audience.u_audience_name_custom_02 = dtGetAudience.Rows[0]["u_audience_name_custom_02"].ToString();
                Audience.u_audience_desc_custom_02 = dtGetAudience.Rows[0]["u_audience_desc_custom_02"].ToString();
                Audience.u_audience_name_custom_03 = dtGetAudience.Rows[0]["u_audience_name_custom_03"].ToString();
                Audience.u_audience_desc_custom_03 = dtGetAudience.Rows[0]["u_audience_desc_custom_03"].ToString();
                Audience.u_audience_name_custom_04 = dtGetAudience.Rows[0]["u_audience_name_custom_04"].ToString();
                Audience.u_audience_desc_custom_04 = dtGetAudience.Rows[0]["u_audience_desc_custom_04"].ToString();
                Audience.u_audience_name_custom_05 = dtGetAudience.Rows[0]["u_audience_name_custom_05"].ToString();
                Audience.u_audience_desc_custom_05 = dtGetAudience.Rows[0]["u_audience_desc_custom_05"].ToString();
                Audience.u_audience_name_custom_06 = dtGetAudience.Rows[0]["u_audience_name_custom_06"].ToString();
                Audience.u_audience_desc_custom_06 = dtGetAudience.Rows[0]["u_audience_desc_custom_06"].ToString();
                Audience.u_audience_name_custom_07 = dtGetAudience.Rows[0]["u_audience_name_custom_07"].ToString();
                Audience.u_audience_desc_custom_07 = dtGetAudience.Rows[0]["u_audience_desc_custom_07"].ToString();
                Audience.u_audience_name_custom_08 = dtGetAudience.Rows[0]["u_audience_name_custom_08"].ToString();
                Audience.u_audience_desc_custom_08 = dtGetAudience.Rows[0]["u_audience_desc_custom_08"].ToString();
                Audience.u_audience_name_custom_09 = dtGetAudience.Rows[0]["u_audience_name_custom_09"].ToString();
                Audience.u_audience_desc_custom_09 = dtGetAudience.Rows[0]["u_audience_desc_custom_09"].ToString();
                Audience.u_audience_name_custom_10 = dtGetAudience.Rows[0]["u_audience_name_custom_10"].ToString();
                Audience.u_audience_desc_custom_10 = dtGetAudience.Rows[0]["u_audience_desc_custom_10"].ToString();
                Audience.u_audience_name_custom_11 = dtGetAudience.Rows[0]["u_audience_name_custom_11"].ToString();
                Audience.u_audience_desc_custom_11 = dtGetAudience.Rows[0]["u_audience_desc_custom_11"].ToString();
                Audience.u_audience_name_custom_12 = dtGetAudience.Rows[0]["u_audience_name_custom_12"].ToString();
                Audience.u_audience_desc_custom_12 = dtGetAudience.Rows[0]["u_audience_desc_custom_12"].ToString();
                Audience.u_audience_name_custom_13 = dtGetAudience.Rows[0]["u_audience_name_custom_13"].ToString();
                return Audience;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Audience
        /// </summary>
        /// <param name="updateAudience"></param>
        /// <returns></returns>
        public static int UpdateAudience(SystemAudiences updateAudience)
        {
            Hashtable htUpdateAudience = new Hashtable();
            htUpdateAudience.Add("@u_audience_system_id_pk", updateAudience.u_audience_system_id_pk);
            htUpdateAudience.Add("@u_audience_id_pk", updateAudience.u_audience_id_pk);
            htUpdateAudience.Add("@u_audience_status_id_fk", updateAudience.u_audience_status_id_fk);
            htUpdateAudience.Add("@u_audience_name", updateAudience.u_audience_name);
            htUpdateAudience.Add("@u_audience_desc", updateAudience.u_audience_desc);
            htUpdateAudience.Add("@u_audience_name_uk_english", updateAudience.u_audience_name_uk_english);
            htUpdateAudience.Add("@u_audience_desc_uk_english", updateAudience.u_audience_desc_uk_english);
            htUpdateAudience.Add("@u_audience_name_ca_france", updateAudience.u_audience_name_ca_france);
            htUpdateAudience.Add("@u_audience_desc_ca_france", updateAudience.u_audience_desc_ca_france);
            htUpdateAudience.Add("@u_audience_name_fr_french", updateAudience.u_audience_name_fr_french);
            htUpdateAudience.Add("@u_audience_desc_fr_french", updateAudience.u_audience_desc_fr_french);
            htUpdateAudience.Add("@u_audience_name_mx_spanish", updateAudience.u_audience_name_mx_spanish);
            htUpdateAudience.Add("@u_audience_desc_mx_spanish", updateAudience.u_audience_desc_mx_spanish);
            htUpdateAudience.Add("@u_audience_name_sp_spanish", updateAudience.u_audience_name_sp_spanish);
            htUpdateAudience.Add("@u_audience_desc_sp_spanish", updateAudience.u_audience_desc_sp_spanish);
            htUpdateAudience.Add("@u_audience_name_portuguse", updateAudience.u_audience_name_portuguse);
            htUpdateAudience.Add("@u_audience_desc_portuguse", updateAudience.u_audience_desc_portuguse);
            htUpdateAudience.Add("@u_audience_name_chinese", updateAudience.u_audience_name_chinese);
            htUpdateAudience.Add("@u_audience_desc_chinese", updateAudience.u_audience_desc_chinese);
            htUpdateAudience.Add("@u_audience_name_german", updateAudience.u_audience_name_german);
            htUpdateAudience.Add("@u_audience_desc_german", updateAudience.u_audience_desc_german);
            htUpdateAudience.Add("@u_audience_name_japanese", updateAudience.u_audience_name_japanese);
            htUpdateAudience.Add("@u_audience_desc_japanese", updateAudience.u_audience_desc_japanese);
            htUpdateAudience.Add("@u_audience_name_russian", updateAudience.u_audience_name_russian);
            htUpdateAudience.Add("@u_audience_desc_russian", updateAudience.u_audience_desc_russian);
            htUpdateAudience.Add("@u_audience_name_danish", updateAudience.u_audience_name_danish);
            htUpdateAudience.Add("@u_audience_desc_danish", updateAudience.u_audience_desc_danish);
            htUpdateAudience.Add("@u_audience_name_polish", updateAudience.u_audience_name_polish);
            htUpdateAudience.Add("@u_audience_desc_polish", updateAudience.u_audience_desc_polish);
            htUpdateAudience.Add("@u_audience_name_swedish", updateAudience.u_audience_name_swedish);
            htUpdateAudience.Add("@u_audience_desc_swedish", updateAudience.u_audience_desc_swedish);
            htUpdateAudience.Add("@u_audience_name_finnish", updateAudience.u_audience_name_finnish);
            htUpdateAudience.Add("@u_audience_desc_finnish", updateAudience.u_audience_desc_finnish);
            htUpdateAudience.Add("@u_audience_name_korean", updateAudience.u_audience_name_korean);
            htUpdateAudience.Add("@u_audience_desc_korean", updateAudience.u_audience_desc_korean);
            htUpdateAudience.Add("@u_audience_name_italian", updateAudience.u_audience_name_italian);
            htUpdateAudience.Add("@u_audience_desc_italian", updateAudience.u_audience_desc_italian);
            htUpdateAudience.Add("@u_audience_name_dutch", updateAudience.u_audience_name_dutch);
            htUpdateAudience.Add("@u_audience_desc_dutch", updateAudience.u_audience_desc_dutch);
            htUpdateAudience.Add("@u_audience_name_indonesian", updateAudience.u_audience_name_indonesian);
            htUpdateAudience.Add("@u_audience_desc_indonesian", updateAudience.u_audience_desc_indonesian);
            htUpdateAudience.Add("@u_audience_name_greek", updateAudience.u_audience_name_greek);
            htUpdateAudience.Add("@u_audience_desc_greek", updateAudience.u_audience_desc_greek);
            htUpdateAudience.Add("@u_audience_name_hungarian", updateAudience.u_audience_name_hungarian);
            htUpdateAudience.Add("@u_audience_desc_hungarian", updateAudience.u_audience_desc_hungarian);
            htUpdateAudience.Add("@u_audience_name_norwegian", updateAudience.u_audience_name_norwegian);
            htUpdateAudience.Add("@u_audience_desc_norwegian", updateAudience.u_audience_desc_norwegian);
            htUpdateAudience.Add("@u_audience_name_turkish", updateAudience.u_audience_name_turkish);
            htUpdateAudience.Add("@u_audience_desc_turkish", updateAudience.u_audience_desc_turkish);
            htUpdateAudience.Add("@u_audience_name_arabic", updateAudience.u_audience_name_arabic);
            htUpdateAudience.Add("@u_audience_desc_arabic", updateAudience.u_audience_desc_arabic);
            htUpdateAudience.Add("@u_audience_name_custom_01", updateAudience.u_audience_name_custom_01);
            htUpdateAudience.Add("@u_audience_desc_custom_01", updateAudience.u_audience_desc_custom_01);
            htUpdateAudience.Add("@u_audience_name_custom_02", updateAudience.u_audience_name_custom_02);
            htUpdateAudience.Add("@u_audience_desc_custom_02", updateAudience.u_audience_desc_custom_02);
            htUpdateAudience.Add("@u_audience_name_custom_03", updateAudience.u_audience_name_custom_03);
            htUpdateAudience.Add("@u_audience_desc_custom_03", updateAudience.u_audience_desc_custom_03);
            htUpdateAudience.Add("@u_audience_name_custom_04", updateAudience.u_audience_name_custom_04);
            htUpdateAudience.Add("@u_audience_desc_custom_04", updateAudience.u_audience_desc_custom_04);
            htUpdateAudience.Add("@u_audience_name_custom_05", updateAudience.u_audience_name_custom_05);
            htUpdateAudience.Add("@u_audience_desc_custom_05", updateAudience.u_audience_desc_custom_05);
            htUpdateAudience.Add("@u_audience_name_custom_06", updateAudience.u_audience_name_custom_06);
            htUpdateAudience.Add("@u_audience_desc_custom_06", updateAudience.u_audience_desc_custom_06);
            htUpdateAudience.Add("@u_audience_name_custom_07", updateAudience.u_audience_name_custom_07);
            htUpdateAudience.Add("@u_audience_desc_custom_07", updateAudience.u_audience_desc_custom_07);
            htUpdateAudience.Add("@u_audience_name_custom_08", updateAudience.u_audience_name_custom_08);
            htUpdateAudience.Add("@u_audience_desc_custom_08", updateAudience.u_audience_desc_custom_08);
            htUpdateAudience.Add("@u_audience_name_custom_09", updateAudience.u_audience_name_custom_09);
            htUpdateAudience.Add("@u_audience_desc_custom_09", updateAudience.u_audience_desc_custom_09);
            htUpdateAudience.Add("@u_audience_name_custom_10", updateAudience.u_audience_name_custom_10);
            htUpdateAudience.Add("@u_audience_desc_custom_10", updateAudience.u_audience_desc_custom_10);
            htUpdateAudience.Add("@u_audience_name_custom_11", updateAudience.u_audience_name_custom_11);
            htUpdateAudience.Add("@u_audience_desc_custom_11", updateAudience.u_audience_desc_custom_11);
            htUpdateAudience.Add("@u_audience_name_custom_12", updateAudience.u_audience_name_custom_12);
            htUpdateAudience.Add("@u_audience_desc_custom_12", updateAudience.u_audience_desc_custom_12);
            htUpdateAudience.Add("@u_audience_name_custom_13", updateAudience.u_audience_name_custom_13);
            htUpdateAudience.Add("@u_audience_desc_custom_13", updateAudience.u_audience_desc_custom_13);

            if (!string.IsNullOrEmpty(updateAudience.audiences_parameters))
            {
                htUpdateAudience.Add("@audiences_parameters", updateAudience.audiences_parameters);
            }
            else
            {
                htUpdateAudience.Add("@audiences_parameters", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("e_sp_update_audience", htUpdateAudience);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Serach Audience
        /// </summary>
        /// <param name="serachAudience"></param>
        /// <returns></returns>
        public static DataTable GetSearchAudience(SystemAudiences serachAudience)
        {
            try
            {
                Hashtable htGetSearchAudience = new Hashtable();
                htGetSearchAudience.Add("@u_audience_id_pk", serachAudience.u_audience_id_pk);
                htGetSearchAudience.Add("@u_audience_name", serachAudience.u_audience_name);
                if (serachAudience.u_audience_status_id_fk == "0")
                {
                    htGetSearchAudience.Add("@u_audience_status_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchAudience.Add("@u_audience_status_id_fk", serachAudience.u_audience_status_id_fk);
                }

                return DataProxy.FetchDataTable("e_sp_search_audience", htGetSearchAudience);
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update audience status
        /// </summary>
        /// <param name="u_audience_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateAudiencestatus(string u_audience_system_id_pk)
        {
            Hashtable htUpdateAudiencetatus = new Hashtable();
            htUpdateAudiencetatus.Add("@u_audience_system_id_pk", u_audience_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_update_audience_status", htUpdateAudiencetatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
       /// <summary>
        /// Audience Parameter
       /// </summary>
       /// <param name="addparam"></param>
       /// <returns></returns>
        public static int AddAudienceParameter(SystemAudiences addparam)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("@u_audience_id_fk", addparam.u_audience_id_fk);
            htParameter.Add("@u_audience_param_element_id_fk", addparam.u_audience_param_element_id_fk);
            if (!string.IsNullOrEmpty(addparam.u_audience_param_operator_id_fk))
            {
                htParameter.Add("@u_audience_param_operator_id_fk", addparam.u_audience_param_operator_id_fk);
            }
            else
            {
                htParameter.Add("@u_audience_param_operator_id_fk", DBNull.Value);
            }
           
            if (!string.IsNullOrEmpty(addparam.u_audience_param_values))
            {
                htParameter.Add("@u_audience_param_values", addparam.u_audience_param_values);
            }
            else
            {
                htParameter.Add("@u_audience_param_values", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("e_sp_add_audience_parameter", htParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove audience parameter
        /// </summary>
        /// <param name="u_audience_id_fk"></param>
        /// <param name="u_audience_param_system_id_pk"></param>
        /// <returns></returns>
        public static int RemoveAudienceParameter(string u_audience_id_fk, string u_audience_param_system_id_pk)
        {
            Hashtable htRemoveParameter = new Hashtable();
            htRemoveParameter.Add("@u_audience_id_fk",u_audience_id_fk);
            htRemoveParameter.Add("@u_audience_param_system_id_pk",u_audience_param_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_remove_audience_parameter",htRemoveParameter);
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get assignment Parameter
        /// </summary>
        /// <param name="u_audience_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetAudienceParameter(string u_audience_id_fk)
        {
            Hashtable htGetAssignmentParameter = new Hashtable();
            htGetAssignmentParameter.Add("@u_audience_id_fk", u_audience_id_fk);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_audience_parameter_using_group_id", htGetAssignmentParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Reset Assignment Parameter
        /// </summary>
        /// <param name="audiences_parameters"></param>
        /// <param name="u_audience_id_fk"></param>
        /// <returns></returns>
        public static int ResetAssignmentParameter(string audiences_parameters,string u_audience_id_fk)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("@u_audience_id_fk", u_audience_id_fk);
            htParameter.Add("@audiences_parameters", audiences_parameters);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_reset_audience_parameter", htParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Start


        /// <summary>
        /// Get Audience Element
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAudienceElement()
        {
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_assignment_element");
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Assignment Operator
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAudienceOperator()
        {
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_assignment_operator");
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Audience User
        /// </summary>
        /// <param name="u_audience_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetAudienceUser(string u_audience_system_id_pk, string u_locale)
        {
            Hashtable htUser = new Hashtable();
            htUser.Add("@u_audience_system_id_pk", u_audience_system_id_pk);
            htUser.Add("@locale", u_locale);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_audience_dynamic_query", htUser);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //END


        /// <summary>
        /// Get Audience user details
        /// </summary>
        /// <param name="u_audience_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetUserDetails(string u_audience_system_id_pk,string u_locale)
        {
            Hashtable htUser = new Hashtable();
            htUser.Add("@u_audience_system_id_pk", u_audience_system_id_pk);
            htUser.Add("@locale", u_locale);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_audience_user_details", htUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Audience User
        /// </summary>
        /// <param name="u_audience_id_fk"></param>
        /// <param name="audience_user"></param>
        /// <returns></returns>
        public static int InsertAudienceUser(string u_audience_id_fk, string audience_user)
        {
            Hashtable htInsertUser = new Hashtable();
            htInsertUser.Add("@u_audience_id_fk", u_audience_id_fk);
            htInsertUser.Add("@audience_user", audience_user);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_insert_audience_users", htInsertUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get User PDF EXCEL
        /// </summary>
        /// <param name="u_audience_system_id_pk"></param>
        /// <param name="s_locale_culture"></param>
        /// <returns></returns>
        public static DataSet GetAudienceUserPDFExcel(string u_audience_system_id_pk, string s_locale_culture)
        {
            Hashtable htGetAudience = new Hashtable();
            htGetAudience.Add("@u_audience_system_id_pk", u_audience_system_id_pk);
            htGetAudience.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("e_sp_get_audience_preview_pdf", htGetAudience);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
