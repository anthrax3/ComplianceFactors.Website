using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemNotification
    {
        public string s_notification_system_id_pk { get; set; }
        public string s_notification_id_pk { get; set; }
        public string s_notification_name { get; set; }
        public string s_notification_Description { get; set; }
        public string s_notification_type_id_fk { get; set; }
        public bool s_notification_on_off_flag { get; set; }
        public bool s_notification_plain_text_flag { get; set; }
        public string s_notification_periods { get; set; }
        public string s_notification_email_cc { get; set; }
        public string s_notification_email_bcc { get; set; }
        public string s_notification_email_subject { get; set; }
        public string s_notification_email_text { get; set; }
        public string s_notification_SMS_text { get; set; }
        //xml
        public string s_notification_locale_xml { get; set; }
        public string s_notification_attachment_xml { get; set; }
        //Attachment
        //public string s_notifications_attchments_system_id_pk { get; set; }
        public string s_notifications_id_fk { get; set; }
        public string s_notifications_attachment_file_guid { get; set; }
        public string s_notifications_attachment_file_name { get; set; }
        //Locale
        public string s_notification_locale_system_id_pk{ get; set; }
		public string s_notification_locale_id_fk{ get; set; }		 
		public string s_notication_locale_name{ get; set; }
		public string s_notification_locale_desc{ get; set; }
		public string s_notification_locale_email_content{ get; set; }
        public string s_notification_locale_sms_content { get; set; }

      
    }
}
