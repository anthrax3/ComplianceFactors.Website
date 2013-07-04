using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using ComplicanceFactor.Common.Languages;
using System.Text.RegularExpressions;

namespace ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles
{
    public partial class saedmp_01 : System.Web.UI.Page
    {
        private static string mediaId;
        private string _filePath = "~/SystemHome/Configuration/DigitalMediaFiles/Images/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.s_digital_media_source_file_name = string.Empty;

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                //hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_digital_media_files_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_media_files_text") + "</a>";

                ddlFileType.DataSource = SystemDigitalMediaFilesBLL.GetFileType(SessionWrapper.CultureName, "saandmp-01");
                ddlFileType.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
                }

                if (!string.IsNullOrEmpty(Request.QueryString["mediaId"]))
                {
                    mediaId = SecurityCenter.DecryptText(Request.QueryString["mediaId"]).ToString();
                }

                RevertBack(mediaId);

                PopulateMediaFile();
                Attachment();
            }
        }
        /// <summary>
        /// Attachment
        /// </summary>
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.s_digital_media_source_file_name))
            {
                lnkFileName.Text = SessionWrapper.s_digital_media_source_file_name;
                btnAttachment.Style.Add("display", "none");
                btnEdit.Style.Add("display", "inline");
                btnRemove.Style.Add("display", "inline");
                btnView.Style.Add("display", "inline");
            }
            else
            {
                lnkFileName.Text = string.Empty;
                btnAttachment.Style.Add("display", "inline");
                btnEdit.Style.Add("display", "none");
                btnRemove.Style.Add("display", "none");
                btnView.Style.Add("display", "none");

            }
        }

        private void PopulateMediaFile()
        {
            SystemDigitalMediaFiles digitalMedia = new SystemDigitalMediaFiles();
            try
            {
                digitalMedia = SystemDigitalMediaFilesBLL.GetSingleDigitalMedia(mediaId);

                txtDigitalMediaId.Text = digitalMedia.s_digital_media_file_id_pk;
                txtDigitalMediaTitle.Text = digitalMedia.s_digital_media_file_name;
                txtDigitalMediaDescription.InnerText = digitalMedia.s_digital_media_file_description;
                ddlFileType.SelectedValue = digitalMedia.s_digital_media_file_type_id_fk;
                SessionWrapper.s_digital_media_source_file_name = digitalMedia.s_digital_media_source_file_name;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedmp-01", ex.Message);
                    }
                }
            }
        }

        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string m_file_name = null;
                string m_file_extension = null;
                //string m_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    m_file_name = Path.GetFileName(file.FileName);
                    m_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_filePath + m_file_name));
                    SessionWrapper.s_digital_media_source_file_name = m_file_name;

                }
            }
            Attachment();

        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.s_digital_media_source_file_name = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();
        }

        private void AttachmentDownload()
        {

            string filePath = Server.MapPath(_filePath + SessionWrapper.s_digital_media_source_file_name);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.s_digital_media_source_file_name + "\"");
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
        /// <summary>
        /// Return Extension
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

        protected void btnHeaderUpdateeDigitalMedia_Click(object sender, EventArgs e)
        {
             UpdateDigitalMedia();
        }

        protected void btnFooterUpdateDigitalMedia_Click(object sender, EventArgs e)
        {
            UpdateDigitalMedia();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetDigitalMediaFiles();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetDigitalMediaFiles();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx");
        }

        private void UpdateDigitalMedia()
        {
            SystemDigitalMediaFiles digitalMedia = new SystemDigitalMediaFiles();
            digitalMedia.s_digital_media_file_system_id_pk = mediaId;
            digitalMedia.s_digital_media_file_id_pk = txtDigitalMediaId.Text;
            digitalMedia.s_digital_media_file_name = txtDigitalMediaTitle.Text;
            digitalMedia.s_digital_media_file_description = txtDigitalMediaDescription.InnerText;
            digitalMedia.s_digital_media_file_type_id_fk = ddlFileType.SelectedValue;
            digitalMedia.s_digital_media_source_file_name = Regex.Replace(SessionWrapper.s_digital_media_source_file_name, " ", "_");

            try
            {
                int result = SystemDigitalMediaFilesBLL.UpdateMediaFiles(digitalMedia);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerText = LocalResources.GetText("app_succ_update_text");
                }
                else
                {
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_media_id_already_exist_error_wrong");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Revert Back for reset
        /// </summary>
        /// <param name="mediaId"></param>
        private void RevertBack(string mediaId)
        {
            try
            {
                SessionWrapper.session_reset_DigitalMediaFiles = SystemDigitalMediaFilesBLL.GetResetValues(mediaId);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Reset Digital Media Files
        /// </summary>
        private void ResetDigitalMediaFiles()
        {
            try
            {
                ConvertDataTables cv = new ConvertDataTables();
                string newID = Guid.NewGuid().ToString();
                int result = SystemDigitalMediaFilesBLL.ResetDigitalmediaFiles(cv.ConvertDataTableToXml(SessionWrapper.session_reset_DigitalMediaFiles), mediaId, newID);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/saedmp-01.aspx?mediaId=" + SecurityCenter.EncryptText(newID), false);
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedmp-01", ex.Message);
                    }
                }
            }
        }       
    }
}