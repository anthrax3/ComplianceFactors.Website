using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class SiteViewOnJobTrainingBLL
    {
        public static DataTable SearchOnJobTraining(string userid)
        {
            Hashtable htSearchOnJobTraining = new Hashtable();
            htSearchOnJobTraining.Add("@sv_ojt_created_by_fk", userid);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_on_job_training", htSearchOnJobTraining);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SiteViewOnJobTraining GetSingleOjt(string sv_ojt_id_pk)
        {
            SiteViewOnJobTraining ojt;
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                ojt = new SiteViewOnJobTraining();
                Hashtable htGetFieldNotes = new Hashtable();
                htGetFieldNotes.Add("@sv_ojt_id_pk", sv_ojt_id_pk);
                DataTable dtGetOjt = DataProxy.FetchDataTable("s_sp_get_single_ojt", htGetFieldNotes);
                ojt.sv_ojt_id_pk = dtGetOjt.Rows[0]["sv_ojt_id_pk"].ToString();
                ojt.sv_ojt_number = dtGetOjt.Rows[0]["sv_ojt_number"].ToString();
                ojt.sv_ojt_title = dtGetOjt.Rows[0]["sv_ojt_title"].ToString();
                ojt.sv_ojt_description = dtGetOjt.Rows[0]["sv_ojt_description"].ToString();
                ojt.sv_ojt_location = dtGetOjt.Rows[0]["sv_ojt_location"].ToString();
                ojt.sv_ojt_Trainer = dtGetOjt.Rows[0]["sv_ojt_Trainer"].ToString();

                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_date"].ToString()))
                {
                    ojt.sv_ojt_date =Convert.ToDateTime(dtGetOjt.Rows[0]["sv_ojt_date"]);
                }

                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_start_time"].ToString()))
                {
                    ojt.sv_ojt_start_time = dtGetOjt.Rows[0]["sv_ojt_start_time"].ToString();
                }
                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_end_time"].ToString()))
                {
                    ojt.sv_ojt_end_time = dtGetOjt.Rows[0]["sv_ojt_end_time"].ToString();
                }              

                ojt.sv_ojt_duration = dtGetOjt.Rows[0]["sv_ojt_duration"].ToString();
                ojt.sv_ojt_type = dtGetOjt.Rows[0]["sv_ojt_type"].ToString();
                if(!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_issafty_brief"].ToString()))
                {
                    ojt.sv_ojt_issafty_brief = Convert.ToBoolean(dtGetOjt.Rows[0]["sv_ojt_issafty_brief"]);
                }

                ojt.sv_ojt_frequency = dtGetOjt.Rows[0]["sv_ojt_frequency"].ToString();
                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_isharm_related"].ToString()))
                {
                    ojt.sv_ojt_isharm_related = Convert.ToBoolean(dtGetOjt.Rows[0]["sv_ojt_isharm_related"]);
                }
                //ojt.sv_ojt_harm_title = dtGetOjt.Rows[0]["sv_ojt_harm_title"].ToString();
                //ojt.sv_ojt_harm_number = dtGetOjt.Rows[0]["sv_ojt_harm_number"].ToString();
                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_iscertification_related"].ToString()))
                {
                    ojt.sv_ojt_iscertification_related = Convert.ToBoolean(dtGetOjt.Rows[0]["sv_ojt_iscertification_related"]);
                }
                ojt.sv_ojt_other = dtGetOjt.Rows[0]["sv_ojt_other"].ToString();
                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_is_acknowledge"].ToString()))
                {
                    ojt.sv_ojt_is_acknowledge = Convert.ToBoolean(dtGetOjt.Rows[0]["sv_ojt_is_acknowledge"]);
                }
                if (!string.IsNullOrEmpty(dtGetOjt.Rows[0]["sv_ojt_harm_id_fk"].ToString()))
                {
                    ojt.sv_ojt_harm_id_fk = dtGetOjt.Rows[0]["sv_ojt_harm_id_fk"].ToString();
                }

                ojt.sv_ojt_certify_filepath = dtGetOjt.Rows[0]["sv_ojt_certify_filepath"].ToString();
                ojt.sv_ojt_certify_filename = dtGetOjt.Rows[0]["sv_ojt_certify_filename"].ToString();
                ojt.sv_ojt_certify_fileExt = dtGetOjt.Rows[0]["sv_ojt_certify_fileExt"].ToString();

                ojt.harmTitle = dtGetOjt.Rows[0]["harmTitle"].ToString();

                ojt.sv_ojt_created_by = dtGetOjt.Rows[0]["CreatedBy"].ToString();

                return ojt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetOjtAttachment(string sv_ojt_id_pk)
        {
            Hashtable htgetOjtAttachment = new Hashtable();
            htgetOjtAttachment.Add("@sv_ojt_id_pk", sv_ojt_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_ojt_attachment", htgetOjtAttachment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SiteViewOnJobTraining GetOjtId()
        {
            SiteViewOnJobTraining ojt = new SiteViewOnJobTraining();
            DataTable dtojt = new DataTable();
            try
            {
                dtojt = DataProxy.FetchDataTable("s_sp_get_ojt_id");
                ojt.sv_ojt_id_pk = dtojt.Rows[0]["OjtId"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return ojt;
        }

        public static int InsertAttachment(SiteViewOnJobTraining ojt)
        {
            Hashtable htInsertAttachment = new Hashtable();
            htInsertAttachment.Add("@sv_ojt_attachments_id_pk", ojt.sv_ojt_attachments_id_pk);
            htInsertAttachment.Add("@sv_ojt_id_fk", ojt.sv_ojt_id_fk);
            htInsertAttachment.Add("@sv_file_path", ojt.sv_file_path);
            htInsertAttachment.Add("@sv_file_type", ojt.sv_file_type);
            htInsertAttachment.Add("@sv_file_name", ojt.sv_file_name);
            htInsertAttachment.Add("@sv_ojt_is_save_sync", ojt.sv_ojt_is_save_sync);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_ojt_attachment", htInsertAttachment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateOjt(SiteViewOnJobTraining newOjt)
        {
            Hashtable htNewOjt = new Hashtable();
            htNewOjt.Add("@sv_ojt_id_pk", newOjt.sv_ojt_id_pk);
            //htNewOjt.Add("@sv_ojt_created_by_fk",newOjt.sv_ojt_created_by_fk);
            htNewOjt.Add("@sv_ojt_number", newOjt.sv_ojt_number);
            htNewOjt.Add("@sv_ojt_title", newOjt.sv_ojt_title);
            htNewOjt.Add("@sv_ojt_description", newOjt.sv_ojt_description);
            htNewOjt.Add("@sv_ojt_location", newOjt.sv_ojt_location);
            htNewOjt.Add("@sv_ojt_Trainer", newOjt.sv_ojt_Trainer);
            htNewOjt.Add("@sv_ojt_date", newOjt.sv_ojt_date);
            htNewOjt.Add("@sv_ojt_start_time", newOjt.sv_ojt_start_time);
            htNewOjt.Add("@sv_ojt_end_time", newOjt.sv_ojt_end_time);
            htNewOjt.Add("@sv_ojt_duration", newOjt.sv_ojt_duration);
            htNewOjt.Add("@sv_ojt_type", newOjt.sv_ojt_type);
            htNewOjt.Add("@sv_ojt_issafty_brief", newOjt.sv_ojt_issafty_brief);
            htNewOjt.Add("@sv_ojt_frequency", newOjt.sv_ojt_frequency);
            htNewOjt.Add("@sv_ojt_isharm_related", newOjt.sv_ojt_isharm_related);
            //htNewOjt.Add("@sv_ojt_harm_title", newOjt.sv_ojt_harm_title);
            //htNewOjt.Add("@sv_ojt_harm_number", newOjt.sv_ojt_harm_number);
            htNewOjt.Add("@sv_ojt_iscertification_related", newOjt.sv_ojt_iscertification_related);
            htNewOjt.Add("@sv_ojt_other", newOjt.sv_ojt_other);
            htNewOjt.Add("@sv_ojt_is_save_sync", newOjt.sv_ojt_is_save_sync);
            htNewOjt.Add("@sv_ojt_is_acknowledge", newOjt.sv_ojt_is_acknowledge);
            if (!string.IsNullOrEmpty(newOjt.sv_ojt_harm_id_fk))
            {
                htNewOjt.Add("@sv_ojt_harm_id_fk", newOjt.sv_ojt_harm_id_fk);
            }
            else
            {
                htNewOjt.Add("@sv_ojt_harm_id_fk", DBNull.Value);
            }
            htNewOjt.Add("@sv_ojt_certify_filepath", newOjt.sv_ojt_certify_filepath);
            htNewOjt.Add("@sv_ojt_certify_filename", newOjt.sv_ojt_certify_filename);
            htNewOjt.Add("@sv_ojt_certify_fileExt", newOjt.sv_ojt_certify_fileExt);
            htNewOjt.Add("@sv_ojt_certify_file_isUpdate", newOjt.sv_ojt_certify_file_isUpdate);
            htNewOjt.Add("@sv_ojt_certify_file_Update_sync", newOjt.sv_ojt_certify_file_Update_sync);  
            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_ojt", htNewOjt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteOjtAttachment(string sv_ojt_attachments_id_pk)
        {
            try
            {
                Hashtable htDeleteNotificationAttchments = new Hashtable();
                htDeleteNotificationAttchments.Add("@sv_ojt_attachments_id_pk", sv_ojt_attachments_id_pk);
                DataProxy.FetchDataTable("s_sp_delete_ojt_attachment", htDeleteNotificationAttchments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateSavedOjtStatus(string sv_ojt_user_archive_id_pk, string sv_ojt_id_pk)
        {
            Hashtable htupdateSavedfield = new Hashtable();
            htupdateSavedfield.Add("@sv_ojt_user_id_pk", sv_ojt_user_archive_id_pk);
            htupdateSavedfield.Add("@sv_ojt_id_pk", sv_ojt_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_saved_ojt_user_archive", htupdateSavedfield);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateReceivedOjtStatus(string sv_ojt_user_id_pk, string sv_ojt_id_pk)
        {
            Hashtable htupdateSavedfield = new Hashtable();
            htupdateSavedfield.Add("@sv_ojt_user_id_pk", sv_ojt_user_id_pk);
            htupdateSavedfield.Add("@sv_ojt_id_pk", sv_ojt_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_received_ojt_user_archive", htupdateSavedfield);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateOjtSent(SiteViewOnJobTraining newOjt)
        {
            Hashtable htInsertOjtSent = new Hashtable();
            htInsertOjtSent.Add("@sv_ojt_id_pk", newOjt.sv_ojt_id_pk);
            htInsertOjtSent.Add("@sv_ojt_created_by_fk", newOjt.sv_ojt_created_by_fk);
            htInsertOjtSent.Add("@sv_ojt_number", newOjt.sv_ojt_number);
            htInsertOjtSent.Add("@sv_ojt_title", newOjt.sv_ojt_title);
            htInsertOjtSent.Add("@sv_ojt_description", newOjt.sv_ojt_description);
            htInsertOjtSent.Add("@sv_ojt_location", newOjt.sv_ojt_location);
            htInsertOjtSent.Add("@sv_ojt_Trainer", newOjt.sv_ojt_Trainer);
            htInsertOjtSent.Add("@sv_ojt_date", newOjt.sv_ojt_date);
            htInsertOjtSent.Add("@sv_ojt_start_time", newOjt.sv_ojt_start_time);
            htInsertOjtSent.Add("@sv_ojt_end_time", newOjt.sv_ojt_end_time);
            htInsertOjtSent.Add("@sv_ojt_duration", newOjt.sv_ojt_duration);
            htInsertOjtSent.Add("@sv_ojt_type", newOjt.sv_ojt_type);
            htInsertOjtSent.Add("@sv_ojt_issafty_brief", newOjt.sv_ojt_issafty_brief);
            htInsertOjtSent.Add("@sv_ojt_frequency", newOjt.sv_ojt_frequency);
            htInsertOjtSent.Add("@sv_ojt_isharm_related", newOjt.sv_ojt_isharm_related);
            //htInsertOjtSent.Add("@sv_ojt_harm_title", newOjt.sv_ojt_harm_title);
            //htInsertOjtSent.Add("@sv_ojt_harm_number", newOjt.sv_ojt_harm_number);
            htInsertOjtSent.Add("@sv_ojt_iscertification_related", newOjt.sv_ojt_iscertification_related);
            htInsertOjtSent.Add("@sv_ojt_other", newOjt.sv_ojt_other);
            htInsertOjtSent.Add("@sv_ojt_is_acknowledge", newOjt.sv_ojt_is_acknowledge);
            if (!string.IsNullOrEmpty(newOjt.sv_ojt_harm_id_fk))
            {
                htInsertOjtSent.Add("@sv_ojt_harm_id_fk", newOjt.sv_ojt_harm_id_fk);
            }
            else
            {
                htInsertOjtSent.Add("@sv_ojt_harm_id_fk", DBNull.Value);
            }
            htInsertOjtSent.Add("@sv_ojt_certify_filepath", newOjt.sv_ojt_certify_filepath);
            htInsertOjtSent.Add("@sv_ojt_certify_filename", newOjt.sv_ojt_certify_filename);
            htInsertOjtSent.Add("@sv_ojt_certify_fileExt", newOjt.sv_ojt_certify_fileExt);
            htInsertOjtSent.Add("@sv_ojt_attachment", newOjt.sv_ojt_attachment);
            htInsertOjtSent.Add("@sv_mi_ojt_sent_to_user", newOjt.sv_mi_ojt_sent_to_user);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_ojt_sent_user", htInsertOjtSent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetUserId(string username)
        {
            Hashtable htGetId = new Hashtable();
            htGetId.Add("@Username", username);

            try
            {
                return DataProxy.FetchDataTable("u_sp_get_user_id", htGetId);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertOJT(SiteViewOnJobTraining newOjt)
        {
            Hashtable htNewOjt = new Hashtable();
            htNewOjt.Add("@sv_ojt_id_pk", newOjt.sv_ojt_id_pk);
            htNewOjt.Add("@sv_ojt_created_by_fk",newOjt.sv_ojt_created_by_fk);
            htNewOjt.Add("@sv_ojt_number", newOjt.sv_ojt_number);
            htNewOjt.Add("@sv_ojt_title", newOjt.sv_ojt_title);
            htNewOjt.Add("@sv_ojt_description", newOjt.sv_ojt_description);
            htNewOjt.Add("@sv_ojt_location", newOjt.sv_ojt_location);
            htNewOjt.Add("@sv_ojt_Trainer", newOjt.sv_ojt_Trainer);
            htNewOjt.Add("@sv_ojt_date", newOjt.sv_ojt_date);
            htNewOjt.Add("@sv_ojt_start_time", newOjt.sv_ojt_start_time);
            htNewOjt.Add("@sv_ojt_end_time", newOjt.sv_ojt_end_time);
            htNewOjt.Add("@sv_ojt_duration", newOjt.sv_ojt_duration);
            htNewOjt.Add("@sv_ojt_type", newOjt.sv_ojt_type);
            htNewOjt.Add("@sv_ojt_issafty_brief", newOjt.sv_ojt_issafty_brief);
            htNewOjt.Add("@sv_ojt_frequency", newOjt.sv_ojt_frequency);
            htNewOjt.Add("@sv_ojt_isharm_related", newOjt.sv_ojt_isharm_related);
            //htNewOjt.Add("@sv_ojt_harm_title", newOjt.sv_ojt_harm_title);
            //htNewOjt.Add("@sv_ojt_harm_number", newOjt.sv_ojt_harm_number);
            htNewOjt.Add("@sv_ojt_iscertification_related", newOjt.sv_ojt_iscertification_related);
            htNewOjt.Add("@sv_ojt_is_acknowledge", newOjt.sv_ojt_is_acknowledge);
            htNewOjt.Add("@sv_ojt_other", newOjt.sv_ojt_other);
            if (!string.IsNullOrEmpty(newOjt.sv_ojt_harm_id_fk))
            {
                htNewOjt.Add("@sv_ojt_harm_id_fk", newOjt.sv_ojt_harm_id_fk);
            }
            else
            {
                htNewOjt.Add("@sv_ojt_harm_id_fk", DBNull.Value);
            }
            htNewOjt.Add("@sv_ojt_certify_filepath", newOjt.sv_ojt_certify_filepath);
            htNewOjt.Add("@sv_ojt_certify_filename", newOjt.sv_ojt_certify_filename);
            htNewOjt.Add("@sv_ojt_certify_fileExt", newOjt.sv_ojt_certify_fileExt);
            htNewOjt.Add("@sv_ojt_attachment",newOjt.sv_ojt_attachment);  

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_ojt", htNewOjt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetOjtAcknowledge(string sv_ojt_id_pk)
        {
            Hashtable htGetOjtAcknowledge = new Hashtable();
            htGetOjtAcknowledge.Add("@sv_ojt_id_pk", sv_ojt_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_ojt_acknowledge", htGetOjtAcknowledge);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetOjtAttachment(string sv_ojt_attachment, string sv_ojt_id_fk)
        {
            Hashtable htResetAttachment = new Hashtable();
            htResetAttachment.Add("@sv_ojt_attachment", sv_ojt_attachment);
            htResetAttachment.Add("@sv_ojt_id_fk", sv_ojt_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_ojt_attachment", htResetAttachment);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetHarmDetails()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_harm_details_for_ojt");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateAcknowledgement(string u_user_id_pk, string sv_ojt_id_pk)
        {
            Hashtable htUpdateAcknowledgement = new Hashtable();
            htUpdateAcknowledgement.Add("@sv_ojt_id_fk", sv_ojt_id_pk);
            htUpdateAcknowledgement.Add("@sv_ojt_sent_to_user_fk", u_user_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_ojt_acknowledgement", htUpdateAcknowledgement);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
