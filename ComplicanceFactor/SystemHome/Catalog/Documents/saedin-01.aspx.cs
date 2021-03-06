﻿using System;
using System.Web;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.DocumentstoCatalog;
using System.Xml;
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

                gvCategory.DataSource = SystemDocumentsBLL.GetDocumentCategory(editDocument);
                gvCategory.DataBind();
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
                SessionWrapper.Reset_DocumentCategory = dsDocument.Tables[2];
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
            string[] fileNames = SessionWrapper.Attachment_file_name.Split(new char[] { '.' });
            using (var client = new ListsSoapClient())
            {
                client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential("darrick", "A1b2c3d4", "U17216392");

                XmlDocument camlDocument = new XmlDocument();
                XmlNode queryNode = camlDocument.CreateElement("Query");
                queryNode.InnerXml = "<Where>"
                + "<Eq><FieldRef Name='FileLeafRef' /><Value Type='Text'>" + fileNames[0] + "_" + SessionWrapper.Attachment_guid + "</Value></Eq>"
                + "</Where>";


                XmlNode resultNode = client.GetListItems("Documents to Catalog", "",
                queryNode, null, "1500", null, null);

                XmlTextReader xr = new XmlTextReader(resultNode.OuterXml, XmlNodeType.Element, null);
                DataTable returnDT = null;
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(xr);
                    if (ds.Tables.Count == 2)
                    {
                        returnDT = ds.Tables[1];
                    }
                }
                if (returnDT != null)
                {


                    string strBatch = "<Method ID='1' Cmd='Delete'>" +
                        "<Field Name='ID'>" + returnDT.Rows[0]["ows_ID"] + "</Field>" +
                        "<Field Name='FileRef'>" + SharePointBLL.spServicesUrl + fileNames[0] + "_" + SessionWrapper.Attachment_guid + "</Field>" +
                        "</Method>";

                    XmlDocument xmlDoc = new System.Xml.XmlDocument();

                    System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

                    elBatch.SetAttribute("OnError", "Continue");

                    elBatch.SetAttribute("PreCalc", "TRUE");

                    //elBatch.SetAttribute("ViewName", System.Guid.NewGuid().ToString());

                    elBatch.InnerXml = strBatch;

                    client.UpdateListItems("Documents to Catalog", elBatch);
                }

            }
            SessionWrapper.Attachment_file_name = string.Empty;
            SessionWrapper.Attachment_guid = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();
        }
        /// <summary>
        /// Attachment Download
        /// </summary>
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
        /// <summary>
        /// Update Document
        /// </summary>
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
        /// <summary>
        /// Attachment
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Reset 
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemDocumentsBLL.DeleteDocumentLocale(editDocument, ConvertDataTableToXml(SessionWrapper.TempLocale), string.Empty);
                ResetCategories();
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
        /// <summary>
        /// ResetCategories()
        /// </summary>
        private void ResetCategories()
        {
            try
            {
                SystemDocumentsBLL.ResetCategory(editDocument, ConvertDataTableToXml(SessionWrapper.Reset_DocumentCategory));                
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

        /// <summary>
        /// Convert DataTable To Xml
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns></returns>
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
                string fileName = null;
                string fileExtension = null;
                string file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    fileExtension = Path.GetExtension(file.FileName);
                    string phyPath = Server.MapPath(_filePath + file_guid + fileExtension);
                    file.SaveAs(phyPath);

                    SessionWrapper.Attachment_file_name = fileName;
                    SessionWrapper.Attachment_guid = file_guid + fileExtension;
                    SharePointBLL.UploadFileToSharePoint(phyPath, SharePointBLL.spServicesUrl + fileName.Replace(fileExtension, "") + "_" + file_guid + fileExtension);
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

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteCategory(string args)
        {
            try
            {
                SystemDocumentsBLL.DeleteCategory(args.Trim());
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }


        }


    }
}