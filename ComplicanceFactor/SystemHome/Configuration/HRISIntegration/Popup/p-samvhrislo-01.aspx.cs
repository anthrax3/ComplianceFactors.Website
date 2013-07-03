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
using System.Net;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace ComplicanceFactor.SystemHome.Configuration.HRIS_Integration.Popup
{
    public partial class p_samvhrislo_01 : System.Web.UI.Page
    {

        #region Private member varables
        private string _logpath = "~/SystemHome/Configuration/HRISIntegration/Log/";
        private static string logId;
        private static string filename;      
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["logid"]))
                {
                    logId = Request.QueryString["logid"].ToString();
                }
                PopulateLogDetails(logId);
            }
        }

        private void PopulateLogDetails(string logId)
        {
            SystemHRISIntegration hrisLogDetails = new SystemHRISIntegration();
            try
            {
                hrisLogDetails = SystemHRISIntegrationBLL.GetSingleErrorLog(logId);
                LogDetails.InnerHtml = hrisLogDetails.u_sftp_run_errors_log;
                filename = hrisLogDetails.u_sftp_run_errors_details_filename;                 
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnDownloadLog_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();
           
            try
            {
                hrisIntegration = SystemHRISIntegrationBLL.GetHRIS();                 
            }
            catch(Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message);
                    }
                }
            }


            string localPath = @"C:\Users\Windows\Downloads\";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(hrisIntegration.u_sftp_URI + filename);
            request.Credentials = new NetworkCredential(hrisIntegration.u_sftp_username, hrisIntegration.u_sftp_password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());
            request = null;

            string fileName = streamReader.ReadLine();

            if (fileName != null)
            {

                FtpWebRequest requestFileDownload = null;
                FtpWebResponse responseFileDownload = null;

                try
                {
                    requestFileDownload = (FtpWebRequest)WebRequest.Create(hrisIntegration.u_sftp_URI + filename);
                    requestFileDownload.Credentials = new NetworkCredential(hrisIntegration.u_sftp_username, hrisIntegration.u_sftp_password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                    responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(localPath + fileName, FileMode.Create);

                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    writeStream.Close();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-samvhrislo-01.aspx", ex.Message);
                        }
                    }
                }
                divSuccess.Style.Add("display", "block");
                divSuccess.InnerHtml =  "File downloaded successfully , please find file in your downloads folder";   

            }

                //string filePath = Server.MapPath(_logpath + filename);

                //if (System.IO.File.Exists(filePath))
                //{
                //    string strRequest = filePath;
                //    if (!string.IsNullOrEmpty(strRequest))
                //    {
                //        FileInfo file = new System.IO.FileInfo(strRequest);
                //        if (file.Exists)
                //        {
                //            Response.Clear();
                //            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename.Replace(".txt","") + "\"");
                //            Response.AddHeader("Content-Length", file.Length.ToString());
                //            Response.ContentType = "text/plain";
                //            Response.WriteFile(file.FullName);
                //            Response.End();
                //            //if file does not exist
                //        }
                //        else
                //        {
                //            Response.Write("This file does not exist.");
                //        }
                //        //nothing in the URL as HTTP GET
                //    }
                //    else
                //    {
                //        Response.Write("Please provide a file to download.");
                //    }
                //}
           
        }

        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            rvErrorLog.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();

            try
            {
                dsPdf = SystemHRISIntegrationBLL.CreatePDF(logId,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.aspx", ex.Message);
                    }
                }
            }  


            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvErrorLog.ProcessingMode = ProcessingMode.Local;
            rvErrorLog.LocalReport.EnableExternalImages = true;
            rvErrorLog.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.SystemHome.Configuration.HRISIntegration.PdfTemplate.ErrorLog.rdlc";
            rvErrorLog.LocalReport.DataSources.Add(new ReportDataSource("dsErrorLogDetails", dsPdf.Tables[0]));
                         

            byte[] bytes = rvErrorLog.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + filename.Remove(filename.Length-4,4) + ".pdf" + "\"");
            Response.BinaryWrite(bytes); // create the file     
            Response.Flush(); // send it to the client to download  
            Response.End();
            Response.Close();
        }


    }
}