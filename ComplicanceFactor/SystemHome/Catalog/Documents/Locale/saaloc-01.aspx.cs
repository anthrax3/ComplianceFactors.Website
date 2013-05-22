using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class add_document_locale : System.Web.UI.Page
    {
        private string _pathDocument = "~/SystemHome/Catalog/Documents/Upload/";
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide validation summary
            vssaaloc.Style.Add("display", "none");
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = LocalResources.GetGlobalLabel("app_document_information_text") + " (" + Request.QueryString["localeText"] + ")";
                }
                //clear attachment session
                SessionWrapper.file_name = string.Empty;
                SessionWrapper.file_guid = string.Empty;

            }

            Attachment();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.file_name = string.Empty;
            SessionWrapper.file_guid = string.Empty;
            Attachment();
        }
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.file_name))
            {
                divAttachment.Style.Add("display", "inline");
                btnAttachment.Style.Add("display", "none");
                lnkDownload.Text = SessionWrapper.file_name;
            }
            else
            {
                //show and hide view,edit,attchment and remove button
                divAttachment.Style.Add("display", "none");
                btnAttachment.Style.Add("display", "inline");
                lnkDownload.Text = string.Empty;
            }
        }
        private void AddDataToLocale(string s_locale_id_fk, string s_locale_name, string s_locale_description, string s_locale_text, string s_locale_file_guid, string s_locale_file_name, DataTable dtTempLocale)
        {
            DataRow row;
            row = dtTempLocale.NewRow();
            row["s_locale_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_locale_id_fk"] = s_locale_id_fk;
            row["s_locale_name"] = s_locale_name;
            row["s_locale_description"] = s_locale_description;
            row["s_locale_text"] = s_locale_text;
            row["s_locale_file_guid"] = s_locale_file_guid;
            row["s_locale_file_name"] = s_locale_file_name;

            dtTempLocale.Rows.Add(row);
        }

        protected void btnSaveLocale_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                AddDataToLocale(Request.QueryString["localeid"], txtDocumentName.Text, txtDescription.Text, Request.QueryString["localeText"], SessionWrapper.file_guid, SessionWrapper.file_name, SessionWrapper.Locale);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemDocuments InsertLocale = new SystemDocuments();
                InsertLocale.s_document_locale_name = txtDocumentName.Text;
                InsertLocale.s_document_locale_description = txtDescription.Text;
                InsertLocale.s_document_locale_id_fk = Request.QueryString["localeid"];
                InsertLocale.s_document_system_id_pk = Request.QueryString["editDocumentId"];

                try
                {
                    SystemDocumentsBLL.InsertDocumentLocale(InsertLocale);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx(Documents)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx(Documents)", ex.Message);
                        }
                    }
                }

            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnAttachmentView_Click(object sender, EventArgs e)
        {
            Download();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

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
        private void Download()
        {
            string filePath = Server.MapPath(_pathDocument + SessionWrapper.file_guid);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.file_name + "\"");
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

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            Download();
        }

    }
}