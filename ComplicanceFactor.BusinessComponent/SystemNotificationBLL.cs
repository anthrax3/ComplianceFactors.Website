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
    public class SystemNotificationBLL
    {
        public static int UpdateNotification(SystemNotification updateNotification)
        {
            Hashtable htupdateNotification = new Hashtable();
            htupdateNotification.Add("@s_notification_system_id_pk", updateNotification.s_notification_system_id_pk);
            //htupdateNotification.Add("@s_notification_id_pk", updateNotification.s_notification_id_pk);
            htupdateNotification.Add("@s_notification_name", updateNotification.s_notification_name);
            htupdateNotification.Add("@s_notification_Description", updateNotification.s_notification_Description);
            htupdateNotification.Add("@s_notification_email_cc", updateNotification.s_notification_email_cc);
            htupdateNotification.Add("@s_notification_email_bcc", updateNotification.s_notification_email_bcc);
            htupdateNotification.Add("@s_notification_email_subject", updateNotification.s_notification_email_subject);
            htupdateNotification.Add("@s_notification_email_text", updateNotification.s_notification_email_text);
            htupdateNotification.Add("@s_notification_SMS_text", updateNotification.s_notification_SMS_text);
            //htupdateNotification.Add("@s_notification_type_id_fk", updateNotification.s_notification_type_id_fk);
            htupdateNotification.Add("@s_notification_periods", updateNotification.s_notification_periods);
            htupdateNotification.Add("@s_notification_plain_text_flag", updateNotification.s_notification_plain_text_flag);
            htupdateNotification.Add("@s_notification_on_off_flag", updateNotification.s_notification_on_off_flag);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_notification", htupdateNotification);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchNotification(SystemNotification notification)
        {
            Hashtable htNotification = new Hashtable();
            htNotification.Add("@s_notification_id_pk", notification.s_notification_id_pk);
            htNotification.Add("@s_notification_name", notification.s_notification_name);
            //htNotification.Add("@s_notification_on_off_flag", notification.s_notification_on_off_flag);

            //htNotification.Add("@s_notification_type_id_fk", notification.s_notification_type_id_fk);

            if (notification.s_notification_type_id_fk == "0")
                htNotification.Add("@s_notification_type_id_fk", DBNull.Value);
            else
                htNotification.Add("@s_notification_type_id_fk", notification.s_notification_type_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_notification", htNotification);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemNotification GetSingleNotification(string s_notification_system_id_pk)
        {
            SystemNotification notification;
            try
            {
                Hashtable htGetNotification = new Hashtable();
                htGetNotification.Add("@s_notification_system_id_pk", s_notification_system_id_pk);
                notification = new SystemNotification();
                DataTable dtGetNotification = DataProxy.FetchDataTable("s_sp_get_single_notification", htGetNotification);

                notification.s_notification_system_id_pk = dtGetNotification.Rows[0]["s_notification_system_id_pk"].ToString();
                notification.s_notification_id_pk = dtGetNotification.Rows[0]["s_notification_id_pk"].ToString();
                notification.s_notification_name = dtGetNotification.Rows[0]["s_notification_name"].ToString();
                notification.s_notification_Description = dtGetNotification.Rows[0]["s_notification_Description"].ToString();
                notification.s_notification_type_id_fk = dtGetNotification.Rows[0]["s_notification_type_id_fk"].ToString();
                notification.s_notification_on_off_flag = Convert.ToBoolean(dtGetNotification.Rows[0]["s_notification_on_off_flag"]);
                if (dtGetNotification.Rows[0]["s_notification_plain_text_flag"].ToString() != string.Empty)
                {
                    notification.s_notification_plain_text_flag = Convert.ToBoolean(dtGetNotification.Rows[0]["s_notification_plain_text_flag"]);
                }
                notification.s_notification_periods = dtGetNotification.Rows[0]["s_notification_periods"].ToString();
                notification.s_notification_email_cc = dtGetNotification.Rows[0]["s_notification_email_cc"].ToString();
                notification.s_notification_email_bcc = dtGetNotification.Rows[0]["s_notification_email_bcc"].ToString();
                notification.s_notification_email_subject = dtGetNotification.Rows[0]["s_notification_email_subject"].ToString();
                notification.s_notification_email_text = dtGetNotification.Rows[0]["s_notification_email_text"].ToString();
                notification.s_notification_SMS_text = dtGetNotification.Rows[0]["s_notification_SMS_text"].ToString();

                return notification;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_status");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertAttachment(SystemNotification notification)
        {
            Hashtable htInsertAttachment = new Hashtable();
            htInsertAttachment.Add("@s_notifications_id_fk", notification.s_notifications_id_fk);
            htInsertAttachment.Add("@s_notifications_attachment_file_guid", notification.s_notifications_attachment_file_guid);
            htInsertAttachment.Add("@s_notifications_attachment_file_name", notification.s_notifications_attachment_file_name);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_notification_attachments", htInsertAttachment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetNotificationAttchments(string s_notifications_id_fk)
        {
            try
            {
                Hashtable htGetNotificationAttchments = new Hashtable();
                htGetNotificationAttchments.Add("@s_notifications_id_fk", s_notifications_id_fk);
                return DataProxy.FetchDataTable("s_sp_get_notification_attachment", htGetNotificationAttchments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteNotificationAttachment(string s_notifications_attchments_system_id_pk)
        {
            try
            {
                Hashtable htDeleteNotificationAttchments = new Hashtable();
                htDeleteNotificationAttchments.Add("@s_notifications_attchments_system_id_pk", s_notifications_attchments_system_id_pk);
                DataProxy.FetchDataTable("s_sp_delete_notification_attachment", htDeleteNotificationAttchments);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int CreateNotificationLocale(SystemNotification createLocale)
        {
            Hashtable htcreateLocale = new Hashtable();
            htcreateLocale.Add("@s_notification_locale_system_id_pk", createLocale.s_notification_locale_system_id_pk);
            htcreateLocale.Add("@s_notification_locale_id_fk", createLocale.s_notification_locale_id_fk);
            htcreateLocale.Add("@s_notifications_id_fk", createLocale.s_notifications_id_fk);
            htcreateLocale.Add("@s_notication_locale_name", createLocale.s_notication_locale_name);
            htcreateLocale.Add("@s_notification_locale_desc", createLocale.s_notification_locale_desc);
            htcreateLocale.Add("@s_notification_locale_email_content", createLocale.s_notification_locale_email_content);
            htcreateLocale.Add("@s_notification_locale_sms_content", createLocale.s_notification_locale_sms_content);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_notification_locale", htcreateLocale);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateNotificationLocale(SystemNotification updateLocale)
        {
            Hashtable htupdateLocale = new Hashtable();
            htupdateLocale.Add("@s_notification_locale_system_id_pk", updateLocale.s_notification_locale_system_id_pk);
            htupdateLocale.Add("@s_notication_locale_name", updateLocale.s_notication_locale_name);
            htupdateLocale.Add("@s_notification_locale_desc", updateLocale.s_notification_locale_desc);
            htupdateLocale.Add("@s_notification_locale_email_content", updateLocale.s_notification_locale_email_content);
            htupdateLocale.Add("@s_notification_locale_sms_content", updateLocale.s_notification_locale_sms_content);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_notification_locale", htupdateLocale);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetNotificationLocale(string s_notifications_id_fk)
        {
            Hashtable htNotificationLocale = new Hashtable();
            htNotificationLocale.Add("@s_notifications_id_fk", s_notifications_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_notification_locales", htNotificationLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemNotification GetSingleNotificationLocale(string s_notification_locale_system_id_pk)
        {
            SystemNotification notification;
            try
            {
                Hashtable htGetNotificationLocale = new Hashtable();
                htGetNotificationLocale.Add("@s_notification_locale_system_id_pk", s_notification_locale_system_id_pk);
                notification = new SystemNotification();
                DataTable dtGetNotificationLocale = DataProxy.FetchDataTable("s_sp_get_single_notification_locale", htGetNotificationLocale);

                notification.s_notification_locale_id_fk = dtGetNotificationLocale.Rows[0]["s_notification_locale_id_fk"].ToString();
                notification.s_notication_locale_name = dtGetNotificationLocale.Rows[0]["s_notication_locale_name"].ToString();
                notification.s_notification_locale_desc = dtGetNotificationLocale.Rows[0]["s_notification_locale_desc"].ToString();
                notification.s_notification_locale_email_content = dtGetNotificationLocale.Rows[0]["s_notification_locale_email_content"].ToString();
                notification.s_notification_locale_sms_content = dtGetNotificationLocale.Rows[0]["s_notification_locale_sms_content"].ToString();

                return notification;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteNotificationLocale(string s_notification_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            htDeleteLocale.Add("@s_notification_locale_system_id_pk", s_notification_locale_system_id_pk);

            try
            {
                DataProxy.FetchSPOutput("s_sp_delete_single_notification_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetNotification(SystemNotification resetLocale)
        {
            Hashtable htResetLocale = new Hashtable();
            htResetLocale.Add("@s_notification_system_id_pk", resetLocale.s_notification_system_id_pk);
            htResetLocale.Add("@s_notification_locale_xml", resetLocale.s_notification_locale_xml);
            htResetLocale.Add("@s_notification_attachment_xml", resetLocale.s_notification_attachment_xml);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_notifications", htResetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateNotificationStatus(string s_notification_system_id_pk ,bool status)
        {
            Hashtable htUpdateNotificationStatus = new Hashtable();
            htUpdateNotificationStatus.Add("@s_notification_system_id_pk", s_notification_system_id_pk);
            htUpdateNotificationStatus.Add("@s_notification_on_off_flag", status);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_notification_status", htUpdateNotificationStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemNotification GetSingleNotificationbyId(string s_notification_system_id_pk)
        {
            SystemNotification notification;
            try
            {
                Hashtable htGetNotification = new Hashtable();
                htGetNotification.Add("@s_notification_id_pk", s_notification_system_id_pk);
                notification = new SystemNotification();
                DataTable dtGetNotification = DataProxy.FetchDataTable("s_sp_get_notification_on_off", htGetNotification);

                notification.s_notification_system_id_pk = dtGetNotification.Rows[0]["s_notification_system_id_pk"].ToString();
                notification.s_notification_id_pk = dtGetNotification.Rows[0]["s_notification_id_pk"].ToString();
                notification.s_notification_name = dtGetNotification.Rows[0]["s_notification_name"].ToString();
                notification.s_notification_Description = dtGetNotification.Rows[0]["s_notification_Description"].ToString();
                notification.s_notification_type_id_fk = dtGetNotification.Rows[0]["s_notification_type_id_fk"].ToString();
                notification.s_notification_on_off_flag = Convert.ToBoolean(dtGetNotification.Rows[0]["s_notification_on_off_flag"]);
                notification.s_notification_plain_text_flag = Convert.ToBoolean(dtGetNotification.Rows[0]["s_notification_plain_text_flag"]);
                notification.s_notification_periods = dtGetNotification.Rows[0]["s_notification_periods"].ToString();
                notification.s_notification_email_cc = dtGetNotification.Rows[0]["s_notification_email_cc"].ToString();
                notification.s_notification_email_bcc = dtGetNotification.Rows[0]["s_notification_email_bcc"].ToString();
                notification.s_notification_email_subject = dtGetNotification.Rows[0]["s_notification_email_subject"].ToString();
                notification.s_notification_email_text = dtGetNotification.Rows[0]["s_notification_email_text"].ToString();
                notification.s_notification_SMS_text = dtGetNotification.Rows[0]["s_notification_SMS_text"].ToString();

                return notification;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
