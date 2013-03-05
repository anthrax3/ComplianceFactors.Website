using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.HRIS_Integration
{
    public partial class samhrismp_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Configuration/HRIS Integration/Uploaded/";
        private string _downloadpath = "~/SystemHome/Configuration/HRIS Integration/Sample/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // Label BreadCrumb
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_hris_integration_text");

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

                    txtHrisCsvFileName.Text = s_file_name;
                }
            }
        }

        protected void btnDownloadSampleHrisCsvFile_Click(object sender, EventArgs e)
        {
            string attachmentFileId = "HRIS_import_csv_example.xlsx";
            string filePath = Server.MapPath(_downloadpath + attachmentFileId);
            string attachmentFileName = "HRIS_import_csv_example.xlsx";

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

        protected void btnSaveHrisSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            hrisIntegration.u_sftp_URI = txtSftpServerUrl.Text;
            hrisIntegration.u_sftp_port = txtSftpServerPort.Text;
            hrisIntegration.u_sftp_username = txtUserName.Text;
            hrisIntegration.u_sftp_password = txtPassword.Text;
            hrisIntegration.u_sftp_hris_filename = txtHrisCsvFileName.Text;
            hrisIntegration.u_sftp_occurs_every = txtOccursEvery.Text;             
            hrisIntegration.u_sftp_time_every = txtHours.Text;          
            hrisIntegration.u_sftp_start_date = txtBegining.Text;

            try
            {
                int result = SystemHRISIntegrationBLL.CreateHRIS(hrisIntegration);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");             
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx", ex.Message);
                    }
                }
            }

        }
    }
}