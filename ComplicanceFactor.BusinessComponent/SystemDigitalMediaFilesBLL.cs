using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDigitalMediaFilesBLL
    {
        public static int InsertMediaFiles(SystemDigitalMediaFiles mediaFile)
        {
            Hashtable htInsertMedia = new Hashtable();
            htInsertMedia.Add("@s_digital_media_file_system_id_pk",mediaFile.s_digital_media_file_system_id_pk);
			htInsertMedia.Add("@s_digital_media_file_id_pk",mediaFile.s_digital_media_file_id_pk);
			htInsertMedia.Add("@s_digital_media_file_name",mediaFile.s_digital_media_file_name);
			htInsertMedia.Add("@s_digital_media_file_description",mediaFile.s_digital_media_file_description);
			htInsertMedia.Add("@s_digital_media_file_type_id_fk",mediaFile.s_digital_media_file_type_id_fk);  
			//htInsertMedia.Add("@s_digital_media_file_date_time",mediaFile.s_digital_media_file_date_time);
            htInsertMedia.Add("@s_digital_media_source_file_name", mediaFile.s_digital_media_source_file_name);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_digital_media_files", htInsertMedia);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateMediaFiles(SystemDigitalMediaFiles mediaFile)
        {
            Hashtable htUpdateMedia = new Hashtable();
            htUpdateMedia.Add("@s_digital_media_file_system_id_pk", mediaFile.s_digital_media_file_system_id_pk);
            htUpdateMedia.Add("@s_digital_media_file_id_pk", mediaFile.s_digital_media_file_id_pk);
            htUpdateMedia.Add("@s_digital_media_file_name", mediaFile.s_digital_media_file_name);
            htUpdateMedia.Add("@s_digital_media_file_description", mediaFile.s_digital_media_file_description);
            htUpdateMedia.Add("@s_digital_media_file_type_id_fk", mediaFile.s_digital_media_file_type_id_fk);
            //htUpdateMedia.Add("@s_digital_media_file_date_time", mediaFile.s_digital_media_file_date_time);
            htUpdateMedia.Add("@s_digital_media_source_file_name", mediaFile.s_digital_media_source_file_name);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_digital_media_files", htUpdateMedia);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemDigitalMediaFiles GetSingleDigitalMedia(string s_digital_media_file_system_id_pk)
        {
            Hashtable htGetSingle = new Hashtable();
            htGetSingle.Add("@s_digital_media_file_system_id_pk", s_digital_media_file_system_id_pk);
            SystemDigitalMediaFiles mediaFiles = new SystemDigitalMediaFiles();
            DataTable dtMediaFile = new DataTable();

            try
            {
                dtMediaFile = DataProxy.FetchDataTable("s_sp_get_single_digital_media_files", htGetSingle);
                if (dtMediaFile.Rows.Count > 0)
                {
                    mediaFiles.s_digital_media_file_system_id_pk = dtMediaFile.Rows[0]["s_digital_media_file_system_id_pk"].ToString();
                    mediaFiles.s_digital_media_file_id_pk = dtMediaFile.Rows[0]["s_digital_media_file_id_pk"].ToString();
                    mediaFiles.s_digital_media_file_name = dtMediaFile.Rows[0]["s_digital_media_file_name"].ToString();
                    mediaFiles.s_digital_media_file_description = dtMediaFile.Rows[0]["s_digital_media_file_description"].ToString();
                    mediaFiles.s_digital_media_file_type_id_fk = dtMediaFile.Rows[0]["s_digital_media_file_type_id_fk"].ToString();
                    mediaFiles.s_digital_media_file_date_time = dtMediaFile.Rows[0]["s_digital_media_file_date_time"].ToString();
                    mediaFiles.s_digital_media_source_file_name = dtMediaFile.Rows[0]["s_digital_media_source_file_name"].ToString();
                }            
           
                return mediaFiles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchMediaFiles(SystemDigitalMediaFiles mediaFiles)
        {
            Hashtable htSearchMediaFiles = new Hashtable();
            htSearchMediaFiles.Add("@s_digital_media_file_id_pk", mediaFiles.s_digital_media_file_id_pk);
            htSearchMediaFiles.Add("@s_digital_media_file_name", mediaFiles.s_digital_media_file_name);
            if (mediaFiles.s_digital_media_file_type_id_fk == "app_ddl_all_text")
            {
                htSearchMediaFiles.Add("@s_digital_media_file_type_id_fk", DBNull.Value);
            }
            else
            {
                htSearchMediaFiles.Add("@s_digital_media_file_type_id_fk", mediaFiles.s_digital_media_file_type_id_fk);
            }

            if (!string.IsNullOrEmpty(mediaFiles.s_digital_media_file_date_time))
            {
                htSearchMediaFiles.Add("@s_digital_media_file_date_time", mediaFiles.s_digital_media_file_date_time);
            }
            else
            {
                htSearchMediaFiles.Add("@s_digital_media_file_date_time", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_digital_media_files", htSearchMediaFiles);
            }
            catch (Exception)
            {
                throw;
            }
        }       

        public static DataTable GetFileType(string s_ui_locale_name, string s_ui_page_name)
        {
            Hashtable htFileType = new Hashtable();
            htFileType.Add("@s_ui_locale_name", s_ui_locale_name);
            htFileType.Add("@s_ui_page_name", s_ui_page_name);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_media_file_types", htFileType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetResetValues(string s_digital_media_file_system_id_pk)
        {
            Hashtable htGetSingle = new Hashtable();
            htGetSingle.Add("@s_digital_media_file_system_id_pk", s_digital_media_file_system_id_pk);
            try
            {
                 return DataProxy.FetchDataTable("s_sp_get_single_digital_media_files", htGetSingle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetDigitalmediaFiles(string mediafiles, string s_digital_media_file_system_id_pk,string newId)
        {
            Hashtable htReset = new Hashtable();
            htReset.Add("@mediafiles", mediafiles);
            htReset.Add("@new_system_id", newId);
            htReset.Add("@s_digital_media_file_system_id_pk", s_digital_media_file_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_mediafiles", htReset);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int RemoveMediaFiles(string s_digital_media_file_system_id_pk)
        {
            Hashtable htRemoveMedia = new Hashtable();
            htRemoveMedia.Add("@s_digital_media_file_system_id_pk", s_digital_media_file_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_mediafiles", htRemoveMedia);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
