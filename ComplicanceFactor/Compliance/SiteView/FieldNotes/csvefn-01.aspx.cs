using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.Compliance.SiteView.FieldNotes
{
    public partial class csvefn : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/Compliance/SiteView/FieldNotes/Attachments/";
        #endregion

        private static string editFieldNoteId;
        //private static bool isReceived;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label Bread Crumb
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + "Compliance" + "</a>&nbsp;" + " >&nbsp;" + "<a href=../ccsv-01.aspx>" + "SiteView" + "</a>" + " >&nbsp;" + "Edit FieldNotes";
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editFieldNoteId = SecurityCenter.DecryptText(Request.QueryString["id"].ToString());
                    PopulateFieldNote(editFieldNoteId);
                }

                //Revert Back for reset

                RevertBack(editFieldNoteId);

                //session
                SessionWrapper.TempAttachment = tempAttachment();

                if (!string.IsNullOrEmpty(Request.QueryString["fieldNoteId"]))
                {
                    //isReceived = true;
                    lblFieldNotesId.Text = SecurityCenter.DecryptText(Request.QueryString["fieldNoteId"]);
                    SessionWrapper.TempAttachment = SiteViewFieldNotesBLL.GetFieldNotesAttachment(editFieldNoteId);
                    //editFieldNoteId = Guid.NewGuid().ToString();
                }

            }
            //gvFieldNotesAttachments.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAttachment(editFieldNoteId);
            //gvFieldNotesAttachments.DataBind();
        }

        /// <summary>
        /// Populate Field Notes
        /// </summary>
        /// <param name="fieldnotesId"></param>
        private void PopulateFieldNote(string fieldnotesId)
        {
            try
            {
                SiteViewFieldNotes fieldnotes = new SiteViewFieldNotes();
                fieldnotes = SiteViewFieldNotesBLL.GetSingleFieldNotes(fieldnotesId);

                lblFieldNotesId.Text = fieldnotes.sv_fieldnote_id;
                txtFieldDescription.InnerText = fieldnotes.sv_fieldnote_description;
                txtLocation.Text = fieldnotes.sv_fieldnote_location;
                txtTitle.Text = fieldnotes.sv_fieldnote_title;

                gvFieldNotesAttachments.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAttachment(fieldnotesId);
                gvFieldNotesAttachments.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvefn-01", ex.Message);
                    }
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
                    SiteViewFieldNotes fieldNotes = new SiteViewFieldNotes();
                    if (SessionWrapper.TempAttachment.Rows.Count > 0)
                    {
                        // Add attachment to Session 
                        AddDataToTempAttachment(s_file_guid + s_file_extension, s_file_extension, s_file_name, SessionWrapper.TempAttachment);
                        
                        gvFieldNotesAttachments.DataSource = SessionWrapper.TempAttachment;
                        gvFieldNotesAttachments.DataBind();
                    }
                    else
                    {
                        fieldNotes.sv_fieldnotes_attachments_id_pk = Guid.NewGuid().ToString();
                        fieldNotes.sv_fieldnotes_id_fk = editFieldNoteId;
                        fieldNotes.sv_file_path = s_file_guid + s_file_extension;
                        fieldNotes.sv_file_type = s_file_extension;
                        fieldNotes.sv_file_name = s_file_name;
                        fieldNotes.sv_fieldnote_is_save_sync = false;

                        try
                        {
                            int result = SiteViewFieldNotesBLL.InsertAttachment(fieldNotes);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("csvefn-01", ex.Message);
                                }
                            }
                        }
                        gvFieldNotesAttachments.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAttachment(editFieldNoteId);
                        gvFieldNotesAttachments.DataBind();
                    }
                }
            }
        }

        protected void gvFieldNotesAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvFieldNotesAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Remove"))
            {
                try
                {
                    if (SessionWrapper.TempAttachment.Rows.Count >0)
                    {
                        //Delete previous selected course
                        var rows = SessionWrapper.TempAttachment.Select("sv_fieldnotes_attachments_id_pk= '" + attachmentId + "'");
                        foreach (var row in rows)
                            row.Delete();
                        SessionWrapper.TempAttachment.AcceptChanges();

                        this.gvFieldNotesAttachments.DataSource = SessionWrapper.TempAttachment;
                        this.gvFieldNotesAttachments.DataBind();
                    }
                    else
                    {
                        SiteViewFieldNotesBLL.DeleteFieldNotesAttachment(attachmentId);
                        this.gvFieldNotesAttachments.DataSource = SystemNotificationBLL.GetNotificationAttchments(editFieldNoteId);
                        this.gvFieldNotesAttachments.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message);
                        }
                    }
                }
            }
            else if (e.CommandName.Equals("Download"))
            {
                string attachmentFileId = gvFieldNotesAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvFieldNotesAttachments.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_attachmentpath + attachmentFileId);

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
        }
       
        /// <summary>
        /// Add the attachment to the Session
        /// </summary>
        /// <param name="s_user_summary"></param>
        /// <param name="u_user_id_pk"></param>
        /// <param name="dtTempUser"></param>
        private void AddDataToTempAttachment(string sv_file_path, string sv_file_type, string sv_file_name, DataTable dtTempAttachment)
        {
            DataRow row;

            row = dtTempAttachment.NewRow();
            row["sv_fieldnotes_attachments_id_pk"] = Guid.NewGuid().ToString();
            row["sv_fieldnotes_id_fk"] = editFieldNoteId;
            row["sv_file_path"] = sv_file_path;
            row["sv_file_type"] = sv_file_type;
            row["sv_file_name"] = sv_file_name;
            row["sv_fieldnote_is_save_sync"] = true;

            dtTempAttachment.Rows.Add(row);
        }


        protected void btnHeaderSaveFieldNotes_Click(object sender, EventArgs e)
        {
            SaveFieldNote();
        }

        protected void btnFooterSaveFieldNotes_Click(object sender, EventArgs e)
        {
            SaveFieldNote();
        }

        /// <summary>
        /// SaveField Notes or Update Field Notes
        /// </summary>
        private void SaveFieldNote()
        {
            //update process when the field notes are saved 
            if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"].ToString() == "saved"))
            {
                SiteViewFieldNotes createField = new SiteViewFieldNotes();
                createField.sv_fieldnote_id_pk = editFieldNoteId;
                createField.sv_fieldnote_id = lblFieldNotesId.Text;
                createField.sv_fieldnote_description = txtFieldDescription.InnerText;
                createField.sv_fieldnote_location = txtLocation.Text;
                createField.sv_fieldnote_title = txtTitle.Text;
                createField.sv_fieldnote_created_by_fk = SessionWrapper.u_userid;
                createField.sv_fieldnote_is_save_sync = false;

                try
                {
                    int result = SiteViewFieldNotesBLL.UpdateFieldNotes(createField);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = "Field Notes are updated Successfully.";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message);
                        }
                    }
                }
            }
            //Create New Field Notes when the field Notes are Received
            else if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"].ToString() == "received"))
            {
                SiteViewFieldNotes createField = new SiteViewFieldNotes();
                createField.sv_fieldnote_id_pk = Guid.NewGuid().ToString();
                createField.sv_fieldnote_id = lblFieldNotesId.Text;
                createField.sv_fieldnote_description = txtFieldDescription.InnerText;
                createField.sv_fieldnote_location = txtLocation.Text;
                createField.sv_fieldnote_creation_date = DateTime.Now.ToShortDateString();
                createField.sv_fieldnote_title = txtTitle.Text;
                createField.sv_fieldnote_created_by_fk = SessionWrapper.u_userid;
                createField.sv_fieldnote_is_save_sync = false;

                createField.sv_fieldnote_attachment = ConvertDataTableToXml(SessionWrapper.TempAttachment);

                try
                {
                    int result = SiteViewFieldNotesBLL.InsertFieldNotes(createField);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = "Created New Field Notes Successfully.";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Convert Datatable to Xml for insert
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

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetFieldNotes();
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ccsv-01.aspx");
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetFieldNotes();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ccsv-01.aspx");
        }

        /// <summary>
        /// Revert Back for reset attachment
        /// </summary>
        /// <param name="fieldNotesId"></param>
        private void RevertBack(string fieldNotesId)
        {
            try
            {
                SessionWrapper.ResetFieldNotesAttachment = SiteViewFieldNotesBLL.GetFieldNotesAttachment(fieldNotesId);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvefn-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Reset field notes attachment
        /// </summary>
        private void ResetFieldNotes()
        {
            if (SessionWrapper.TempAttachment.Rows.Count > 0)
            {
                SessionWrapper.TempAttachment = SessionWrapper.ResetFieldNotesAttachment;
                gvFieldNotesAttachments.DataSource = SessionWrapper.TempAttachment;
                gvFieldNotesAttachments.DataBind();
            }
            else
            {
                try
                {
                    SiteViewFieldNotesBLL.ResetFieldNoteAttachment(ConvertDataTableToXml(SessionWrapper.ResetFieldNotesAttachment), editFieldNoteId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvefn-01", ex.Message);
                        }
                    }
                }
                gvFieldNotesAttachments.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAttachment(editFieldNoteId);
                gvFieldNotesAttachments.DataBind();
            }
        }

        /// <summary>
        /// TempAttachment for  table
        /// </summary>
        /// <returns></returns>
        private DataTable tempAttachment()
        {            
            DataTable dt = new DataTable();
            DataColumn dtUserColumn;
            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_fieldnotes_attachments_id_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_fieldnotes_id_fk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_file_path";
            dt.Columns.Add(dtUserColumn);


            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_file_type";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_file_name";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_fieldnote_is_save_sync";
            dt.Columns.Add(dtUserColumn);          

            return dt;
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