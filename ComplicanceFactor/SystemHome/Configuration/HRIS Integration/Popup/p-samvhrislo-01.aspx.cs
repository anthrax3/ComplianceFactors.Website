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

namespace ComplicanceFactor.SystemHome.Configuration.HRIS_Integration.Popup
{
    public partial class p_samvhrislo_01 : System.Web.UI.Page
    {
        private string _logpath = "~/SystemHome/Configuration/HRIS Integration/Log/";
        private static string logId;
        private static string filename; 
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
            string filePath = Server.MapPath(_logpath + filename);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename.Replace(".txt","") + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = "text/plain";
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

        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}