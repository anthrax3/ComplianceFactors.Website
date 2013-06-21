using System;
using System.Web;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class saedin_01 : System.Web.UI.Page
    {
        private string _filePath = "~/SystemHome/Catalog/Documents/Upload/";
        string editDocument;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    editDocument = SecurityCenter.DecryptText(Request.QueryString["edit"]);
                }
                //set Document id
                hdDocumentId.Value = editDocument;
                if (!IsPostBack)
                {
                    vssaedin.Style.Add("display", "none");
                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Documents/samdimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_documents_text") + "</a>" + "&nbsp;>&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_document_text") + "</a>";


                    //clear attachment session
                    SessionWrapper.Attachment_file_name = string.Empty;
                    SessionWrapper.Attachment_guid = string.Empty;
                    // bind the status
                    ddlStatus.DataSource = SystemDocumentsBLL.GetStatus(SessionWrapper.CultureName, "saedin-01");
                    ddlStatus.DataBind();

                    //bind Document type
                    ddlDocumentType.DataSource = SystemDocumentsBLL.GetDocumentTypes(SessionWrapper.CultureName);
                    ddlDocumentType.DataBind();
                    ListItem itemToRemove = ddlDocumentType.Items.FindByValue("app_ddl_all_text");
                    ddlDocumentType.Items.Remove(itemToRemove);
                    PopulateDocument();

                    Attachment();
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message);
                    }
                }
            }
            gvVersionList.DataSource = SystemDocumentsBLL.GetDocumentsVersionList(editDocument);
            gvVersionList.DataBind();
        }

        //TO-DO
        private void PopulateDocument()
        {
            SystemDocuments document = new SystemDocuments();
            DataSet dsDocument = SystemDocumentsBLL.GetDocument(editDocument);
            try
            {
                document = SystemDocumentsBLL.GetSingleDocument(editDocument, dsDocument.Tables[0]);
                txtDocumentId.Text = document.s_document_id_pk;
                txtDocumentName.Text = document.s_document_name;
                txtDescription.Text = document.s_document_description;
                txtVersion.Text = document.s_document_version;
                ddlStatus.SelectedValue = document.s_document_status_id_fk;
                ddlDocumentType.SelectedValue = document.s_document_type_fk;
                SessionWrapper.Attachment_guid = document.s_documnet_attachment_file_guid;
                SessionWrapper.Attachment_file_name = document.s_document_attachment_file_name;
                //for reset to store resource locale in session
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = dsDocument.Tables[1];
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message);
                    }
                }
            }
        }
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.Attachment_file_name))
            {
                lnkFileName.Text = SessionWrapper.Attachment_file_name;                
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.Attachment_file_name = string.Empty;
            SessionWrapper.Attachment_guid = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();
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

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            UpdateDocument();
        }
        private void UpdateDocument()
        {
            SystemDocuments updateDocument = new SystemDocuments();

            updateDocument.s_document_system_id_pk = editDocument;
            updateDocument.s_document_id_pk = txtDocumentId.Text;
            updateDocument.s_document_name = txtDocumentName.Text;
            updateDocument.s_document_description = txtDescription.Text;
            updateDocument.s_document_status_id_fk = ddlStatus.SelectedValue;
            updateDocument.s_document_type_fk = ddlDocumentType.SelectedValue;
            updateDocument.s_documnet_attachment_file_guid = SessionWrapper.Attachment_guid;
            updateDocument.s_document_attachment_file_name = SessionWrapper.Attachment_file_name;
            try
            {
                int result = SystemDocumentsBLL.UpdateDocument(updateDocument);
                if (result == 0)
                {
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message);
                    }
                }
            }
        }
        private DataTable tempAttachment()
        {
            DataTable dtTempAttachment = new DataTable();
            DataColumn dtTempAttachmentColumn;

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "s_documnet_attachment_file_guid";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "s_document_attachment_file_name";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);
            return dtTempAttachment;
        }
        private void Reset()
        {
            try
            {
                SystemDocumentsBLL.DeleteDocumentLocale(editDocument, ConvertDataTableToXml(SessionWrapper.TempLocale), string.Empty);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedin-01.aspx", ex.Message);
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
        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string m_file_name = null;
                string m_file_extension = null;
                string m_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    m_file_name = Path.GetFileName(file.FileName);
                    m_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_filePath + m_file_guid + m_file_extension));
                    SessionWrapper.Attachment_file_name = m_file_name;
                    SessionWrapper.Attachment_guid = m_file_guid + m_file_extension;
                }
            }
            Attachment();

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
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
        protected void btnSaveNewVersion_Click(object sender, EventArgs e)
        {
            try
            {
                SystemDocuments document = new SystemDocuments();
                document.s_document_system_id_pk = editDocument;
                document.s_new_document_system_id_pk = Guid.NewGuid().ToString();
                document.s_document_version = txtNewVersionNumber.Text;
                document.s_copy_document = chkCopyDocuments.Checked;
                document.s_copy_locale = chkCopyLocale.Checked;
               // document.c_course_created_by_id_fk = SessionWrapper.u_userid;
                SystemDocumentsBLL.CreateCourseNewVersion(document);
                Response.Redirect("~/SystemHome/Catalog/Documents/saedin-01.aspx?edit=" + SecurityCenter.EncryptText(document.s_document_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saedin-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saedin-01", ex.Message);
                }

            }
        }

        protected void gvVersionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewVersion = (Button)e.Row.FindControl("btnViewVersion");
                LinkButton lnkViewVersion = (LinkButton)e.Row.FindControl("lnkViewVersion");
                lnkViewVersion.OnClientClick = "window.open('saad-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) +"&type="+ SecurityCenter.EncryptText( ddlDocumentType.SelectedItem.Text)+ "','',''); return false;";
                btnViewVersion.OnClientClick = "window.open('saad-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) + "&type=" + SecurityCenter.EncryptText( ddlDocumentType.SelectedItem.Text) + "','',''); return false;";
            }
        }


    }
}