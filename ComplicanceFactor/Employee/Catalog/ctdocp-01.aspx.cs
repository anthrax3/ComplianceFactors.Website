using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.IO;

namespace ComplicanceFactor.Employee.Catalog
{
    public partial class ctdocp_01 : System.Web.UI.Page
    {
        private static string s_documnet_attachment_file_guid;
        private string _filePath = "~/SystemHome/Catalog/Documents/Upload/";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            string brdCrumb = "<a href=/Employee/Catalog/qscr-01.aspx?keyword=" + SecurityCenter.EncryptText("") + ">" + " { " + LocalResources.GetGlobalLabel("app_quick_search_text") + "</a>" + " <a href=# > or </a>" + "<a href=/Employee/Catalog/ascp-01.aspx>" + LocalResources.GetGlobalLabel("app_advanced_search_text") + "</a>" + " <a href=# > or </a> " + "<a href=/Employee/Catalog/bchp-01.aspx>" + LocalResources.GetGlobalLabel("app_browse_text") + " } " + "Catalog" + "</a>";
            lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " > " + brdCrumb + " > " + LocalResources.GetGlobalLabel("app_document_details_page_text");
            if (!IsPostBack)
            {
                DataSet dsDocument = new DataSet();
                dsDocument = SystemDocumentsBLL.GetDocument(SecurityCenter.DecryptText(Request.QueryString["id"]));
                gvsearchDetails.DataSource = dsDocument.Tables[0];
                gvsearchDetails.DataBind();
                SystemDocuments document = new SystemDocuments();
                document = SystemDocumentsBLL.GetSingleDocument(SecurityCenter.DecryptText(Request.QueryString["id"]), dsDocument.Tables[0]);
                lblDocumentDetails.Text = "{" + document.s_document_name + "}" + " " + "({" + document.s_document_id_pk + "})";
                s_documnet_attachment_file_guid = document.s_documnet_attachment_file_guid;
            }
        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                string downloadId = e.CommandArgument.ToString();
                string filePath = Server.MapPath(_filePath + s_documnet_attachment_file_guid);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.Attachment_file_name + "\"");
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