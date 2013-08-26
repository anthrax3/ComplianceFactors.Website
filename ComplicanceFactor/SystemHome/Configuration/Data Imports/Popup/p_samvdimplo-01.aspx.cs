using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Net;

namespace ComplicanceFactor.SystemHome.Configuration.Data_Imports.Popup
{
    public partial class p_samvdimplo_01 : System.Web.UI.Page
    {

        #region Private member varables
        //private string _logpath = "~/SystemHome/Configuration/Data Imports/TempLogFiles/";
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
                 hrisIntegration = SystemHRISIntegrationBLL.GetHRIS_DIMP_DEXP("DIMP");
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
             //Here I can'y download the error log from ftp,
             //Now it download the error log from server with out connecting the server using username and password
             //string localPath ="~/SystemHome/Configuration/Data Imports/TempLogFiles/" + filename;


             //if (System.IO.File.Exists(localPath))
             //{
             //    string strRequest = localPath;
             //    if (!string.IsNullOrEmpty(strRequest))
             //    {
             //        FileInfo file = new System.IO.FileInfo(strRequest);
             //        if (file.Exists)
             //        {
             //            Response.Clear();
             //            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename.Remove(filename.Length - 4, 4) + "\"");
             //            Response.AddHeader("Content-Length", file.Length.ToString());
             //            Response.ContentType = ".txt";
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

             try
             {
                 FtpWebRequest request = (FtpWebRequest)WebRequest.Create(hrisIntegration.u_sftp_URI + filename);
                 request.Method = WebRequestMethods.Ftp.DownloadFile;

                 // This example assumes the FTP site uses anonymous logon.
                 request.Credentials = new NetworkCredential(hrisIntegration.u_sftp_username, hrisIntegration.u_sftp_password);

                 FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                 Stream responseStream = response.GetResponseStream();
                 //StreamReader reader = new StreamReader(responseStream);
                 StringBuilder sb = new StringBuilder();
                 using (StreamReader reader = new StreamReader(responseStream))
                 {
                     String line;
                     while ((line = reader.ReadLine()) != null)
                     {
                         sb.AppendLine(line);
                     }
                 }
                 string allines = sb.ToString();

                 byte[] stringAsBytes = Encoding.UTF8.GetBytes(allines);

                 string mimeType = string.Empty;
                 Response.Buffer = true;
                 Response.Clear();
                 Response.ClearHeaders();
                 Response.ContentType = mimeType;
                 Response.AddHeader("content-disposition", "attachment; filename=\"" + filename + "\"");
                 Response.BinaryWrite(stringAsBytes); // create the file     
                 Response.Flush(); // send it to the client to download  
                 Response.End();
                 Response.Close();
             }
             catch (Exception)
             {
                 divError.Style.Add("display", "block");
                 divError.InnerText = "File was not found";
             }
         }        

         protected void btnPrint_Click(object sender, EventArgs e)
         {
             rvErrorLog.LocalReport.DataSources.Clear();
             DataSet dsPdf = new DataSet();

             try
             {
                 dsPdf = SystemHRISIntegrationBLL.CreatePDF(logId, SessionWrapper.CultureName);
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
             Response.AddHeader("content-disposition", "attachment; filename=\"" + filename.Remove(filename.Length - 4, 4) + ".pdf" + "\"");
             Response.BinaryWrite(bytes); // create the file     
             Response.Flush(); // send it to the client to download  
             Response.End();
             Response.Close();
         }
    }
}