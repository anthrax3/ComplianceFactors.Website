using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using System.IO;
using System.Data;

namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.Popup
{
    public partial class samhrismp_01 : System.Web.UI.Page
    {

        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Configuration/HRISIntegration/Uploaded/";
        private string _downloadpath = "~/SystemHome/Configuration/HRISIntegration/Sample/";
        private DateTime start;
        #endregion
        private static string hrisId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    hrisId = Request.QueryString["Id"].ToString();
                }

                PopulateHRIS(hrisId);
            }
        }
        /// <summary>
        /// Populate Hris
        /// </summary>
        /// <param name="hrisId"></param>
        private void PopulateHRIS(string hrisId)
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            try
            {
                hrisIntegration = SystemBackgroundJobsBLL.GetSingleHRIS(hrisId);

                txtSftpServerUrl.Text = hrisIntegration.u_sftp_URI;
                txtSftpServerPort.Text = hrisIntegration.u_sftp_port;
                txtUserName.Text = hrisIntegration.u_sftp_username;
                txtPassword.Value = hrisIntegration.u_sftp_password;
                txtPassword.Attributes["type"] = "password";
                txtHrisCsvFileName.Text = hrisIntegration.u_sftp_hris_filename;
                txtOccursEvery.Text = hrisIntegration.u_sftp_occurs_every;
                txtHours.Text = hrisIntegration.u_sftp_time_every.Substring(0,hrisIntegration.u_sftp_time_every.Length-2);
                txtBegining.Text = Convert.ToDateTime(hrisIntegration.u_sftp_start_date).ToString("d");
                string time = hrisIntegration.u_sftp_time_every;
                int length = time.Length;
                ddlTimeConversion.SelectedValue = time.Substring(length - 2, 2);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx(Background Popup)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx(Background Popup)", ex.Message);
                    }
                }
            }
        }

        protected void btnSaveHrisSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();
            hrisIntegration.u_sftp_id_pk = hrisId;
            hrisIntegration.u_sftp_URI = txtSftpServerUrl.Text;
            hrisIntegration.u_sftp_port = txtSftpServerPort.Text;
            hrisIntegration.u_sftp_username = txtUserName.Text;
            hrisIntegration.u_sftp_password = txtPassword.Value;
            hrisIntegration.u_sftp_hris_filename = txtHrisCsvFileName.Text;
            hrisIntegration.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {                
                hrisIntegration.u_sftp_time_every = txtHours.Text;
            }
            else
            {
                int hours = Convert.ToInt16(txtHours.Text.Substring(0,2));
                int minites = Convert.ToInt16(txtHours.Text.Substring(3, 2));
                hours = hours + 12;
                hrisIntegration.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
            }

                     
            hrisIntegration.u_sftp_start_date = txtBegining.Text;

            try
            {
                int result = SystemBackgroundJobsBLL.UpdateHRIS(hrisIntegration);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml ="Successfully Updated";             
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx(Background Popup)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samhrismp-01.aspx(Background Popup)", ex.Message);
                    }
                }
            }

        }
         

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
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
                    //DataTable dtHRIS = getExcelData(Server.MapPath(_attachmentpath + s_file_guid + s_file_extension), "HRIS");
                    txtHrisCsvFileName.Text = s_file_name;
                    //InsertIntoUserMaster(dtHRIS);
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
        
    }
}