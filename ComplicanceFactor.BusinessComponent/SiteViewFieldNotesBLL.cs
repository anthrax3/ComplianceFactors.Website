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
    public class SiteViewFieldNotesBLL
    {
        //Field Notes

        public static DataTable SearchFieldNotes(string userid)
        {
            Hashtable htSearchFieldNotes = new Hashtable();
            htSearchFieldNotes.Add("@sv_fieldnote_created_by_fk", userid);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_field_notes", htSearchFieldNotes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SiteViewFieldNotes GetSingleFieldNotes(string sv_fieldnote_id_pk)
        {
            SiteViewFieldNotes fieldNotes;
            try
            {
                fieldNotes = new SiteViewFieldNotes();
                Hashtable htGetFieldNotes = new Hashtable();
                htGetFieldNotes.Add("@sv_fieldnote_id_pk", sv_fieldnote_id_pk);
                DataTable dtGetFieldNotes = DataProxy.FetchDataTable("s_sp_get_single_field_note", htGetFieldNotes);
                fieldNotes.sv_fieldnote_created_by_fk = dtGetFieldNotes.Rows[0]["sv_fieldnote_created_by_fk"].ToString();
                fieldNotes.sv_fieldnote_title = dtGetFieldNotes.Rows[0]["sv_fieldnote_title"].ToString();
                fieldNotes.sv_fieldnote_description = dtGetFieldNotes.Rows[0]["sv_fieldnote_description"].ToString();
                fieldNotes.sv_fieldnote_id = dtGetFieldNotes.Rows[0]["sv_fieldnote_id"].ToString();
                fieldNotes.sv_fieldnote_location = dtGetFieldNotes.Rows[0]["sv_fieldnote_location"].ToString();
                fieldNotes.sv_fieldnote_creation_date = dtGetFieldNotes.Rows[0]["sv_fieldnote_creation_date"].ToString();
                fieldNotes.sv_fieldnote_is_save_sync = Convert.ToBoolean(dtGetFieldNotes.Rows[0]["sv_fieldnote_is_save_sync"]);

                return fieldNotes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetFieldNotesAttachment(string sv_fieldnote_id_pk)
        {
            Hashtable htgetFieldNotesAttachment = new Hashtable();
            htgetFieldNotesAttachment.Add("@sv_fieldnotes_id_fk", sv_fieldnote_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_field_note_attachment", htgetFieldNotesAttachment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //s_sp_insert_field_notes_attachment

        public static int InsertAttachment(SiteViewFieldNotes fieldNotes)
        {
            Hashtable htInsertAttachment = new Hashtable();
            htInsertAttachment.Add("@sv_fieldnotes_attachments_id_pk", fieldNotes.sv_fieldnotes_attachments_id_pk);
            htInsertAttachment.Add("@sv_fieldnotes_id_fk", fieldNotes.sv_fieldnotes_id_fk);
            htInsertAttachment.Add("@sv_file_path", fieldNotes.sv_file_path);
            htInsertAttachment.Add("@sv_file_type", fieldNotes.sv_file_type);
            htInsertAttachment.Add("@sv_file_name", fieldNotes.sv_file_name);
            htInsertAttachment.Add("@sv_fieldnote_is_save_sync", fieldNotes.sv_fieldnote_is_save_sync);

            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_field_notes_attachment", htInsertAttachment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteFieldNotesAttachment(string sv_fieldnotes_attachments_id_pk)
        {
            try
            {
                Hashtable htDeleteNotificationAttchments = new Hashtable();
                htDeleteNotificationAttchments.Add("@sv_fieldnotes_attachments_id_pk", sv_fieldnotes_attachments_id_pk);
                DataProxy.FetchDataTable("s_sp_delete_field_notes_attachment", htDeleteNotificationAttchments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateFieldNotesSent(SiteViewFieldNotes fieldNotes)
        {
            Hashtable htInsertFieldNotesSent = new Hashtable();            
            htInsertFieldNotesSent.Add("@sv_fieldnote_id_pk", fieldNotes.sv_fieldnote_id_pk);
            htInsertFieldNotesSent.Add("@sv_fieldnote_created_by_fk", fieldNotes.sv_fieldnote_created_by_fk);
            htInsertFieldNotesSent.Add("@sv_fieldnote_title", fieldNotes.sv_fieldnote_title);
            htInsertFieldNotesSent.Add("@sv_fieldnote_creation_date", fieldNotes.sv_fieldnote_creation_date);
            htInsertFieldNotesSent.Add("@sv_fieldnote_description", fieldNotes.sv_fieldnote_description);
            htInsertFieldNotesSent.Add("@sv_fieldnote_location", fieldNotes.sv_fieldnote_location);
            htInsertFieldNotesSent.Add("@sv_fieldnote_is_save_sync", fieldNotes.sv_fieldnote_is_save_sync);
            htInsertFieldNotesSent.Add("@sv_fieldnote_id", fieldNotes.sv_fieldnote_id);
            htInsertFieldNotesSent.Add("@sv_fieldnote_attachment", fieldNotes.sv_fieldnote_attachment);
            htInsertFieldNotesSent.Add("@sv_mi_fieldnote_sent_to_user", fieldNotes.sv_mi_fieldnote_sent_to_user);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_field_note_sent_user", htInsertFieldNotesSent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SiteViewFieldNotes GetFieldNoteId()
        {
            SiteViewFieldNotes fieldNotes = new SiteViewFieldNotes();

            DataTable dtfieldNotesId = new DataTable();

            try
            {
                dtfieldNotesId = DataProxy.FetchDataTable("s_sp_get_field_notes_id");
                fieldNotes.sv_fieldnote_id = dtfieldNotesId.Rows[0]["FieldNoteId"].ToString();
            }

            catch (Exception)
            {
                throw;
            }

            return fieldNotes;
        }

        public static int  UpdateFieldNotes(SiteViewFieldNotes fieldNotes)
        {
            Hashtable htUpdateFieldNotes = new Hashtable();
            htUpdateFieldNotes.Add("@sv_fieldnote_id_pk", fieldNotes.sv_fieldnote_id_pk);
            htUpdateFieldNotes.Add("@sv_fieldnote_created_by_fk", fieldNotes.sv_fieldnote_created_by_fk);
            htUpdateFieldNotes.Add("@sv_fieldnote_title", fieldNotes.sv_fieldnote_title);
            htUpdateFieldNotes.Add("@sv_fieldnote_description", fieldNotes.sv_fieldnote_description);
            htUpdateFieldNotes.Add("@sv_fieldnote_location", fieldNotes.sv_fieldnote_location);
            htUpdateFieldNotes.Add("@sv_fieldnote_is_save_sync", fieldNotes.sv_fieldnote_is_save_sync);
            htUpdateFieldNotes.Add("@sv_fieldnote_id", fieldNotes.sv_fieldnote_id);      

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_field_notes", htUpdateFieldNotes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertFieldNotes(SiteViewFieldNotes fieldNotes)
        {
            Hashtable htInsertFieldNotes = new Hashtable();
            htInsertFieldNotes.Add("@sv_fieldnote_id_pk", fieldNotes.sv_fieldnote_id_pk);
            htInsertFieldNotes.Add("@sv_fieldnote_created_by_fk", fieldNotes.sv_fieldnote_created_by_fk);
            htInsertFieldNotes.Add("@sv_fieldnote_title", fieldNotes.sv_fieldnote_title);
            htInsertFieldNotes.Add("@sv_fieldnote_creation_date", fieldNotes.sv_fieldnote_creation_date);
            htInsertFieldNotes.Add("@sv_fieldnote_description", fieldNotes.sv_fieldnote_description);
            htInsertFieldNotes.Add("@sv_fieldnote_location", fieldNotes.sv_fieldnote_location);
            htInsertFieldNotes.Add("@sv_fieldnote_is_save_sync", fieldNotes.sv_fieldnote_is_save_sync);
            htInsertFieldNotes.Add("@sv_fieldnote_id", fieldNotes.sv_fieldnote_id);
            htInsertFieldNotes.Add("@sv_fieldnote_attachment", fieldNotes.sv_fieldnote_attachment);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_field_notes", htInsertFieldNotes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateSavedFieldNotesStatus(string sv_fieldnote_user_archive_id_pk, string sv_fieldnote_id_pk)
        {
            Hashtable htupdateSavedfield = new Hashtable();
            htupdateSavedfield.Add("@sv_fieldnote_user_id_pk", sv_fieldnote_user_archive_id_pk);
            htupdateSavedfield.Add("@sv_fieldnote_id_pk", sv_fieldnote_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_saved_fieldnotes_user_archive", htupdateSavedfield);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateReceivedFieldNotesStatus(string sv_fieldnote_user_id_pk, string sv_fieldnote_id_pk)
        {
            Hashtable htupdateSavedfield = new Hashtable();
            htupdateSavedfield.Add("@sv_fieldnote_user_id_pk", sv_fieldnote_user_id_pk);
            htupdateSavedfield.Add("@sv_fieldnote_id_pk", sv_fieldnote_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_received_fieldnotes_user_archive", htupdateSavedfield);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetFieldNoteAttachment(string sv_fieldnote_attachment, string sv_fieldnotes_id_fk)
        {
            Hashtable htResetAttachment = new Hashtable();
            htResetAttachment.Add("@sv_fieldnote_attachment", sv_fieldnote_attachment);
            htResetAttachment.Add("@sv_fieldnotes_id_fk", sv_fieldnotes_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_fieldnote_attachment", htResetAttachment);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertFieldNotesSentUser(string sv_mi_fieldnote_sent_to_user)
        {
            Hashtable htInsertFieldNotesSent = new Hashtable();       
            htInsertFieldNotesSent.Add("@sv_mi_fieldnote_sent_to_user", sv_mi_fieldnote_sent_to_user);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_sent_user", htInsertFieldNotesSent);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get User id for Send the Inspection to user 
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
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
    }
}
