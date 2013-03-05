using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Configuration.Notifications.Locale
{
    public partial class saaloc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["editLocalepk"]) && !string.IsNullOrEmpty(Request.QueryString["editNotificationId"]))
                    {
                        string s_notification_locale_system_id_pk = Request.QueryString["editLocalepk"].ToString();
                        PopulateLocale(s_notification_locale_system_id_pk);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["editNotificationId"]))
                {
                    SystemNotification createLocale = new SystemNotification();
                    createLocale.s_notification_locale_system_id_pk = Guid.NewGuid().ToString();
                    createLocale.s_notification_locale_id_fk = Request.QueryString["editLocaleId"].ToString();
                    createLocale.s_notifications_id_fk = Request.QueryString["editNotificationId"].ToString();
                    createLocale.s_notication_locale_name = txtNotificationName.Text;
                    createLocale.s_notification_locale_desc = txtDescription.InnerText;
                    createLocale.s_notification_locale_email_content = txtEmailContent.InnerText;
                    createLocale.s_notification_locale_sms_content = txtSmsContent.InnerText;
                    try
                    {
                        int result = SystemNotificationBLL.CreateNotificationLocale(createLocale);
                        if (result == 0)
                        {
                            divSuccess.Style.Add("display", "block");
                            divSuccess.InnerHtml = "Notification Locales Inserted Successfully";
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message);
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["editLocalepk"]) && !string.IsNullOrEmpty(Request.QueryString["editNotificationId"]))
                {
                    SystemNotification updateLocale = new SystemNotification();
                    updateLocale.s_notication_locale_name = txtNotificationName.Text;
                    updateLocale.s_notification_locale_desc = txtDescription.InnerText;
                    updateLocale.s_notification_locale_email_content = txtEmailContent.InnerText;
                    updateLocale.s_notification_locale_sms_content = txtSmsContent.InnerText;
                    updateLocale.s_notification_locale_system_id_pk = Request.QueryString["editLocalepk"].ToString();

                    try
                    {
                        int result = SystemNotificationBLL.UpdateNotificationLocale(updateLocale);
                        if (result == 0)
                        {
                            divSuccess.Style.Add("display", "block");
                            divSuccess.InnerHtml = "Splash Page Locale Updated Successfully";
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message);
                            }
                        }
                    }
                }
            }
           Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// Populate Locale 
        /// </summary>
        /// <param name="s_notification_locale_system_id_pk"></param>
        private void PopulateLocale(string s_notification_locale_system_id_pk)
        {
            try
            {
                SystemNotification notification = new SystemNotification();
                notification = SystemNotificationBLL.GetSingleNotificationLocale(s_notification_locale_system_id_pk);

                txtNotificationName.Text = notification.s_notication_locale_name;
                txtDescription.InnerText = notification.s_notification_locale_desc;
                txtEmailContent.InnerText = notification.s_notification_locale_email_content;
                txtSmsContent.InnerText = notification.s_notification_locale_sms_content;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Notification Page)", ex.Message);
                    }
                }
            }
        }
    }
}