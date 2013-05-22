using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;
using ComplicanceFactor.Common.Languages;
using System.Net;

namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class edit_document_locale : System.Web.UI.Page
    {
        private string _pathDocument = "~/SystemHome/Catalog/Documents/Upload/";
        protected void Page_Load(object sender, EventArgs e)
        {
            vssaeloc.Style.Add("display", "none");
            if (!IsPostBack)
            {
                //clear attachment session
                //SessionWrapper.file_name = string.Empty;
                //SessionWrapper.file_guid = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
                {
                    DataView dvLocale = new DataView(SessionWrapper.Locale);
                    dvLocale.RowFilter = "s_locale_system_id_pk= '" + Request.QueryString["id"] + "'";
                    //Get Temp locale
                    TempGetLocale(Request.QueryString["id"], dvLocale.ToTable());
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemDocuments Locale = new SystemDocuments();
                    Locale = SystemDocumentsBLL.GetSingleDocumentLocale(Request.QueryString["id"]);
                    txtName.Text = Locale.s_document_locale_name;
                    txtDescriptoin.Value = Locale.s_document_locale_description;
                    lblLocaleHeading.Text = "Document Information" + " (" + Locale.s_locale_text + ")";
                    //SessionWrapper.file_guid = Locale.s_document_locale_file_path;
                    //SessionWrapper.file_name = Locale.s_document_locale_file_name;
                }
            }
            Attachment();
        }
        private void UpdateLocale()
        {
            var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + Request.QueryString["id"] + "'");
            var indexOfRow = SessionWrapper.Locale.Rows.IndexOf(rows[0]);
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_name"] = txtName.Text;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_description"] = txtDescriptoin.Value;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_file_guid"] = SessionWrapper.file_guid;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_file_name"] = SessionWrapper.file_name;
            SessionWrapper.Locale.AcceptChanges();
        }
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            SystemDocuments Locale = new SystemDocuments();
            Locale = SystemDocumentsBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtName.Text = Locale.s_document_locale_name;
            txtDescriptoin.Value = Locale.s_document_locale_description;
            lblLocaleHeading.Text = "Document Information" + " (" + Locale.s_locale_text + ")";
            SessionWrapper.file_guid = Locale.s_document_locale_file_path;
            SessionWrapper.file_name = Locale.s_document_locale_file_name;
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

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.file_name = string.Empty;
            SessionWrapper.file_guid = string.Empty;
            Attachment();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                UpdateLocale();

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemDocuments updatedocument = new SystemDocuments();
                updatedocument.s_document_locale_system_id_pk = Request.QueryString["id"];
                updatedocument.s_document_locale_name = txtName.Text;
                updatedocument.s_document_locale_description = txtDescriptoin.Value;
                updatedocument.s_document_locale_file_path = SessionWrapper.file_guid;
                updatedocument.s_document_locale_file_name = SessionWrapper.file_name;

                try
                {
                    SystemDocumentsBLL.UpdateDocumentLocale(updatedocument);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(Document)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(Document)", ex.Message);
                        }
                    }
                }
            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);


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

        protected void btnAttachmentView_Click(object sender, EventArgs e)
        {
            Download();
        }
        private void Download()
        {
            string filePath = Server.MapPath(_pathDocument +  SessionWrapper.file_guid);

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

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

    }
}