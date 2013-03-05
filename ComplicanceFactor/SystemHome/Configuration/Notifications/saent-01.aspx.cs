using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.IO;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Notification
{
    public partial class saent_01 : System.Web.UI.Page
    {

        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Configuration/Notifications/Attachments/";
        #endregion

        private static string notificationId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                //Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Notifications/samntmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_notifications_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_notification_text");

                //bind locale
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["Edit"]))
                {
                    notificationId = SecurityCenter.DecryptText(Request.QueryString["Edit"]);
                    hdNotificationId.Value = notificationId;
                    PopulateNotification(notificationId);
                }
                gvNotificationAttachments.DataSource = SystemNotificationBLL.GetNotificationAttchments(notificationId);
                gvNotificationAttachments.DataBind();

                gvNotificationLocales.DataSource = SystemNotificationBLL.GetNotificationLocale(notificationId);
                gvNotificationLocales.DataBind();

                RevertBack(notificationId);
            }

            DataTable dtLocale = SystemNotificationBLL.GetNotificationLocale(notificationId);
            gvNotificationLocales.DataSource = dtLocale;
            gvNotificationLocales.DataBind();

            foreach (DataRow dtrow in dtLocale.Rows)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_notification_locale_id_fk"], "RemoveLocale('" + dtrow["s_notification_locale_id_fk"] + "');", true);
            }

            ddlLocale.SelectedIndex = 0;

        }
        /// <summary>
        /// Populate Notification for Edit
        /// </summary>
        /// <param name="notificationId"></param>
        private void PopulateNotification(string notificationId)
        {
            SystemNotification notification = new SystemNotification();

            try
            {
                notification = SystemNotificationBLL.GetSingleNotification(notificationId);
                lblNotificationId.Text = notification.s_notification_id_pk;
                txtNotificationName.Text = notification.s_notification_name;
                txtDescription.InnerText = notification.s_notification_Description;
                txtCC.Text = notification.s_notification_email_cc;
                txtBCC.Text = notification.s_notification_email_bcc;
                txtSubject.Text = notification.s_notification_email_subject;
                txtEmailContent.InnerText = notification.s_notification_email_text;
                txtSmsContent.InnerText = notification.s_notification_SMS_text;
                lblType.Text = notification.s_notification_type_id_fk;
                txtScheduleDays.Text = notification.s_notification_periods;

                if (notification.s_notification_type_id_fk == "Triggered")
                {
                    Scheduledays.Style.Add("display", "none");
                    //txtScheduleDays.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterSaveNotification_Click(object sender, EventArgs e)
        {
            UpdateNotification();
        }

        protected void btnHeaderSaveNotification_Click(object sender, EventArgs e)
        {
            UpdateNotification();
        }
        /// <summary>
        /// Update Notification 
        /// </summary>
        private void UpdateNotification()
        {
            SystemNotification notification = new SystemNotification();
            try
            {
                notification.s_notification_system_id_pk = notificationId;
                //notification.s_notification_id_pk = txtNotificationTypeId.Text;
                notification.s_notification_name = txtNotificationName.Text;
                notification.s_notification_Description = txtDescription.InnerText;
                notification.s_notification_email_cc = txtCC.Text;
                notification.s_notification_email_bcc = txtBCC.Text;
                notification.s_notification_email_subject = txtSubject.Text;
                notification.s_notification_email_text = txtEmailContent.InnerText;
                notification.s_notification_SMS_text = txtSmsContent.InnerText;
                //notification.s_notification_type_id_fk = txtType.Text;
                notification.s_notification_periods = txtScheduleDays.Text;
                notification.s_notification_on_off_flag = true;
                notification.s_notification_plain_text_flag = false;


                int result = SystemNotificationBLL.UpdateNotification(notification);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetNotification();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetNotification();
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Notifications/samntmp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Notifications/samntmp-01.aspx");
        }

        protected void btnUploadAttachements_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string s_file_name = null;
                string s_file_extension = null;
                string s_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    s_file_name = Path.GetFileName(file.FileName);
                    s_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension));

                    SystemNotification notification = new SystemNotification();
                    notification.s_notifications_attachment_file_guid = s_file_guid + s_file_extension;
                    notification.s_notifications_id_fk = hdNotificationId.Value;
                    notification.s_notifications_attachment_file_name = s_file_name;

                    if (!string.IsNullOrEmpty(hdNotificationId.Value))
                    {
                        int result = SystemNotificationBLL.InsertAttachment(notification);
                    }
                }
            }
            gvNotificationAttachments.DataSource = SystemNotificationBLL.GetNotificationAttchments(notificationId);
            gvNotificationAttachments.DataBind();
        }

        protected void gvNotificationAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvNotificationAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Remove"))
            {
                try
                {
                    SystemNotificationBLL.DeleteNotificationAttachment(attachmentId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saent-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saent-01", ex.Message);
                        }
                    }
                }
                this.gvNotificationAttachments.DataSource = SystemNotificationBLL.GetNotificationAttchments(notificationId);
                this.gvNotificationAttachments.DataBind();
            }
            else if (e.CommandName.Equals("Download"))
            {
                string attachmentFileId = gvNotificationAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvNotificationAttachments.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_attachmentpath + attachmentFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }


        }

        protected void gvNotificationAttachments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1)
        {
            try
            {
                SystemNotificationBLL.DeleteNotificationLocale(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Convert the datatable to Xml
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns></returns>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }

        /// <summary>
        /// Revert Back for the reset process
        /// </summary>
        /// <param name="notificationId"></param>
        private void RevertBack(string notificationId)
        {
            try
            {
                SessionWrapper.session_notification_locale = SystemNotificationBLL.GetNotificationLocale(notificationId);
                SessionWrapper.session_notification_attachment = SystemNotificationBLL.GetNotificationAttchments(notificationId);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Reset Notification
        /// </summary>
        private void ResetNotification()
        {
            SystemNotification notification = new SystemNotification();

            notification.s_notification_system_id_pk = notificationId;
            notification.s_notification_locale_xml = ConvertDataTableToXml(SessionWrapper.session_notification_locale);
            notification.s_notification_attachment_xml = ConvertDataTableToXml(SessionWrapper.session_notification_attachment);

            try
            {
                int result = SystemNotificationBLL.ResetNotification(notification);
                if (result == 0)
                {
                    gvNotificationAttachments.DataSource = SystemNotificationBLL.GetNotificationAttchments(notificationId);
                    gvNotificationAttachments.DataBind();

                    //gvNotificationLocales.DataSource = SystemNotificationBLL.GetNotificationLocale(notificationId);
                    //gvNotificationLocales.DataBind();
                }

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saent-01.aspx", ex.Message);
                    }
                }
            }
            DataTable dtLocale = SystemNotificationBLL.GetNotificationLocale(notificationId);
            gvNotificationLocales.DataSource = dtLocale;
            gvNotificationLocales.DataBind();

            foreach (DataRow dtrow in dtLocale.Rows)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_notification_locale_id_fk"], "RemoveLocale('" + dtrow["s_notification_locale_id_fk"] + "');", true);
            }

            ddlLocale.SelectedIndex = 0;
        }
        /// <summary>
        /// Extensions
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
      
    }
}