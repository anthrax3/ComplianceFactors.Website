using System;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;


namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class saandin_01 : System.Web.UI.Page
    {
        private string _filePath = "~/SystemHome/Catalog/Documents/Upload/";
        private DataTable dtTempAttachment = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>" + "&nbsp;>&nbsp;" + "<a href=/SystemHome/Catalog/Documents/samdimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_documents_text") + "</a>" + "&nbsp;>&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_document_text") + "</a>";
                
                //clear attachment session
                SessionWrapper.Attachment_file_name = string.Empty;
                SessionWrapper.Attachment_guid = string.Empty;
                //to bind the Attachment
                dtTempAttachment = new DataTable();
                dtTempAttachment = tempAttachment();
                SessionWrapper.session_Attachment = dtTempAttachment;
                //temp locale column
                SessionWrapper.Locale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                // bind the status
                ddlStatus.DataSource = SystemDocumentsBLL.GetStatus(SessionWrapper.CultureName, "saandin-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";

                //bind Document type
                ddlDocumentType.DataSource = SystemDocumentsBLL.GetDocumentTypes(SessionWrapper.CultureName);
                ddlDocumentType.DataBind();
                ListItem itemToRemove = ddlDocumentType.Items.FindByValue("app_ddl_all_text");
                ddlDocumentType.Items.Remove(itemToRemove);
                //copy
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    PopulateDocument(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                }
                Attachment();
            }
        }
        private void PopulateDocument(string documentId)
        {
            SystemDocuments document = new SystemDocuments();
            DataSet dsDocument = SystemDocumentsBLL.GetDocument(documentId);
            try
            {
                document = SystemDocumentsBLL.GetSingleDocument(documentId, dsDocument.Tables[0]);
                txtDocumentId.Text = document.s_document_id_pk + "_copy";
                txtDocumentName.Text = document.s_document_name;
                txtDescription.Text = document.s_document_description;
                ddlStatus.SelectedValue = document.s_document_status_id_fk;
                txtVersion.Text = document.s_document_version;
                ddlDocumentType.SelectedValue = document.s_document_type_fk;
                SessionWrapper.Attachment_guid = document.s_documnet_attachment_file_guid;
                SessionWrapper.Attachment_file_name = document.s_document_attachment_file_name;
                SessionWrapper.Locale = dsDocument.Tables[1];
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saandin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saandin-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnUploadDocument_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string fileName = null;
                string fileExtension = null;
                string file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    fileExtension = Path.GetExtension(file.FileName);

                    file.SaveAs(Server.MapPath(_filePath + file_guid + fileExtension));

                    SessionWrapper.Attachment_file_name = fileName;
                    SessionWrapper.Attachment_guid = file_guid + fileExtension;
                }
            }
            Attachment();
        }
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.Attachment_file_name))
            {
                lnkFileName.Text = SessionWrapper.Attachment_file_name;
                btnUploadDocument.Style.Add("display", "none");
                btnEdit.Style.Add("display", "inline");
                btnRemove.Style.Add("display", "inline");
                btnView.Style.Add("display", "inline");
            }
            else
            {
                lnkFileName.Text = string.Empty;
                btnUploadDocument.Style.Add("display", "inline");
                btnEdit.Style.Add("display", "none");
                btnRemove.Style.Add("display", "none");
                btnView.Style.Add("display", "none");

            }
        }
        //Attachment 
        private DataTable tempAttachment()
        {
            DataTable dtTempAttachment = new DataTable();
            DataColumn dtTempAttachmentColumn;

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "c_document_file_guid";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "c_document_file_name";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);
            return dtTempAttachment;
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.Attachment_file_name = string.Empty;
            SessionWrapper.Attachment_guid = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            SaveNewDocument();
        }
        private void SaveNewDocument()
        {
            SystemDocuments createDocument = new SystemDocuments();

            createDocument.s_document_system_id_pk = Guid.NewGuid().ToString();
            createDocument.s_document_id_pk = txtDocumentId.Text;
            createDocument.s_document_name = txtDocumentName.Text;
            createDocument.s_document_description = txtDescription.Text;
            createDocument.s_document_version = txtVersion.Text;
            createDocument.s_document_status_id_fk = ddlStatus.SelectedValue;
            createDocument.s_document_type_fk = ddlDocumentType.SelectedValue;
            createDocument.s_documnet_attachment_file_guid = SessionWrapper.Attachment_guid;
            createDocument.s_document_attachment_file_name = SessionWrapper.Attachment_file_name;
            createDocument.s_document_locale = ConvertDataTableToXml(SessionWrapper.Locale);
            try
            {
                int result = SystemDocumentsBLL.CreateNewDocument(createDocument);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Documents/saedin-01.aspx?edit=" + SecurityCenter.EncryptText(createDocument.s_document_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saandin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saandin-01.aspx", ex.Message);
                    }
                }
            }
        }
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Documents/samdimp-01.aspx");
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }
        private void AttachmentDownload()
        {

            string filePath = Server.MapPath(_filePath + SessionWrapper.Attachment_guid);

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