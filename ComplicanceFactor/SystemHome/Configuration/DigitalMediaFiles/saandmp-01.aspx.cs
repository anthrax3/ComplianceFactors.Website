using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles
{
    public partial class saandmp_01 : System.Web.UI.Page
    {
        private string _filePath = "~/SystemHome/Configuration/DigitalMediaFiles/Images/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                //hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_digital_media_files_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_create_new_media_files_text") + "</a>";
                ddlFileType.DataSource = SystemDigitalMediaFilesBLL.GetFileType(SessionWrapper.CultureName, "saandmp-01");
                ddlFileType.DataBind();
                SessionWrapper.s_digital_media_source_file_name = string.Empty;
            }




            Attachment();
        }

        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string m_file_name = null;
                string m_file_extension = null;
                
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

        protected void btnHeaderSaveDigitalMedia_Click(object sender, EventArgs e)
        {
             SaveDigitalMediaFiles();
        }

        protected void btnFooterSaveDigitalMedia_Click(object sender, EventArgs e)
        {
            SaveDigitalMediaFiles();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/samdmmp-01.aspx");
        }

        /// <summary>
        /// Save Digital Media Files
        /// </summary>
        private void SaveDigitalMediaFiles()
        {
            SystemDigitalMediaFiles digitalMedia = new SystemDigitalMediaFiles();
            digitalMedia.s_digital_media_file_system_id_pk = Guid.NewGuid().ToString();
            digitalMedia.s_digital_media_file_id_pk = txtDigitalMediaId.Text;
            digitalMedia.s_digital_media_file_name = txtDigitalMediaTitle.Text;
            digitalMedia.s_digital_media_file_description = txtDigitalMediaDescription.InnerText;
            digitalMedia.s_digital_media_file_type_id_fk = ddlFileType.SelectedValue;
            digitalMedia.s_digital_media_source_file_name = SessionWrapper.s_digital_media_source_file_name;

            try
            {
                int result = SystemDigitalMediaFilesBLL.InsertMediaFiles(digitalMedia);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/saedmp-01.aspx?mediaId=" + SecurityCenter.EncryptText(digitalMedia.s_digital_media_file_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
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
                        Logger.WriteToErrorLog("saandmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saandmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Extension
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

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.s_digital_media_source_file_name = string.Empty;            
            lnkFileName.Text = string.Empty;
            Attachment();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        /// <summary>
        /// Attachment Download
        /// </summary>
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
    }
}