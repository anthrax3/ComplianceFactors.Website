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
using System.Globalization;
using ComplicanceFactor.Common.Languages;


namespace ComplicanceFactor.Compliance.SiteView.Ojt
{
    public partial class csveojt_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/Compliance/SiteView/Ojt/Attachments/";
        //private string _attachmentpath = "~/Compliance/SiteView/Ojt/Attachments/";
        private static string editOjtId;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label Bread Crumb
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_compliance_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=../ccsv-01.aspx>" + LocalResources.GetGlobalLabel("app_compliance_pod_site_view_title") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_ojt_text") + "</a>";
            if (!IsPostBack)
            {
                SessionWrapper.ojt_upload_certification_file_name = string.Empty;
                SessionWrapper.ojt_upload_certification_file_path = string.Empty;
                SessionWrapper.ojt_upload_certification_file_extension = string.Empty;
                SessionWrapper.ojt_upload_certification_check_file_name = string.Empty;

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editOjtId = SecurityCenter.DecryptText(Request.QueryString["id"].ToString());
                    PopulateOjt(editOjtId);
                }

                RevertBack(editOjtId);

                SessionWrapper.TempAttachment = tempAttachment();

                if (!string.IsNullOrEmpty(Request.QueryString["OjtId"]))
                {
                    //isReceived = true;
                    lblOjtNumber.Text = SecurityCenter.DecryptText(Request.QueryString["OjtId"]);
                    SessionWrapper.TempAttachment = SiteViewOnJobTrainingBLL.GetOjtAttachment(editOjtId);//.GetFieldNotesAttachment(editOjtId);                     
                }

                Attachment();

                ddlHarm.DataSource = SiteViewOnJobTrainingBLL.GetHarmDetails();
                ddlHarm.DataBind();
            }
        }
        private void PopulateOjt(string OjtId)
        {
            try
            {
                SiteViewOnJobTraining ojt = new SiteViewOnJobTraining();
                ojt = SiteViewOnJobTrainingBLL.GetSingleOjt(OjtId);
                lblId.Text = ojt.sv_ojt_id_pk;
                txtTitle.Text = ojt.sv_ojt_title;
                txtLocation.Text = ojt.sv_ojt_location;
                txtFieldDescription.InnerText = ojt.sv_ojt_description;
                lblOjtNumber.Text = ojt.sv_ojt_number;
                txtDate.Text = ojt.sv_ojt_date.ToString("d");
                ddlDuration.SelectedValue = ojt.sv_ojt_duration;
                if (!string.IsNullOrEmpty(ojt.sv_ojt_start_time.ToString()))
                {
                    txtStartTime.Text = Convert.ToDateTime(ojt.sv_ojt_start_time).ToShortTimeString();
                }
                if (!string.IsNullOrEmpty(ojt.sv_ojt_end_time.ToString()))
                {
                    txtEndTime.Text = Convert.ToDateTime(ojt.sv_ojt_end_time).ToShortTimeString();
                }
                ddlType.SelectedValue = ojt.sv_ojt_type;
                //txtHarmTitle.Text = ojt.sv_ojt_harm_title;
                //txtHarmNumber.Text = ojt.sv_ojt_harm_number;
                ddlFrequency.SelectedValue = ojt.sv_ojt_frequency;
                txtOthers.Text = ojt.sv_ojt_other;
                txtTrainer.Text = ojt.sv_ojt_Trainer;
                if (ojt.sv_ojt_issafty_brief == true)
                {
                    chkIsSafety.Checked = true;
                }
                else
                {
                    ddlFrequency.Attributes.Add("disabled", "true");
                }
                if (ojt.sv_ojt_isharm_related == true)
                {
                    chkIsHarm.Checked = true;
                }
                else
                {
                    ddlHarm.Attributes.Add("disabled", "true");
                }
                if (ojt.sv_ojt_iscertification_related == true)
                {
                    chkIsCertification.Checked = true;
                }
                else
                {
                    btnUploadCeritification.Attributes.Add("disabled", "true");
                    txtOthers.Attributes.Add("disabled", "true");
                }
                if (ojt.sv_ojt_is_acknowledge == true)
                {
                    chkIsAcknowledge.Checked = true;
                }
                else
                {                    
                    chkIsAcknowledge.Checked = false;
                }

                ddlHarm.SelectedValue = ojt.sv_ojt_harm_id_fk;
                SessionWrapper.ojt_upload_certification_check_file_name = ojt.sv_ojt_certify_filename;
                SessionWrapper.ojt_upload_certification_file_name = ojt.sv_ojt_certify_filename;
                SessionWrapper.ojt_upload_certification_file_path = ojt.sv_ojt_certify_filepath;
                SessionWrapper.ojt_upload_certification_file_extension = ojt.sv_ojt_certify_fileExt;
 
                gvOjtAttachments.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(OjtId);
                gvOjtAttachments.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csveojt-01", ex.Message);
                    }
                }
            }
        }
        private DataTable tempAttachment()
        {
            DataTable dt = new DataTable();
            DataColumn dtUserColumn;
            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_ojt_attachments_id_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_ojt_id_fk";
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
            dtUserColumn.ColumnName = "sv_ojt_is_save_sync";
            dt.Columns.Add(dtUserColumn);

            return dt;
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
                    SiteViewOnJobTraining ojt = new SiteViewOnJobTraining();
                    if (SessionWrapper.TempAttachment.Rows.Count > 0)
                    {
                        // Add attachment to Session 
                        AddDataToTempAttachment(s_file_guid + s_file_extension, s_file_extension, s_file_name, SessionWrapper.TempAttachment);

                        gvOjtAttachments.DataSource = SessionWrapper.TempAttachment;
                        gvOjtAttachments.DataBind();
                    }
                    else
                    {
                        ojt.sv_ojt_attachments_id_pk = Guid.NewGuid().ToString();
                        ojt.sv_ojt_id_fk = editOjtId;
                        ojt.sv_file_path = s_file_guid + s_file_extension;
                        ojt.sv_file_type = s_file_extension;
                        ojt.sv_file_name = s_file_name;
                        ojt.sv_ojt_is_save_sync = false;

                        try
                        {
                            int result = SiteViewOnJobTrainingBLL.InsertAttachment(ojt);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("csveojt-01", ex.Message);
                                }
                            }
                        }
                        gvOjtAttachments.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(editOjtId);
                        gvOjtAttachments.DataBind();
                    }
                }
            }
        }
        /// <summary>
        /// To add the attachment
        /// </summary>
        /// <param name="sv_file_path"></param>
        /// <param name="sv_file_type"></param>
        /// <param name="sv_file_name"></param>
        /// <param name="dtTempAttachment"></param>
        private void AddDataToTempAttachment(string sv_file_path, string sv_file_type, string sv_file_name, DataTable dtTempAttachment)
        {
            DataRow row;

            row = dtTempAttachment.NewRow();
            row["sv_ojt_attachments_id_pk"] = Guid.NewGuid().ToString();
            row["sv_ojt_id_fk"] = editOjtId;
            row["sv_file_path"] = sv_file_path;
            row["sv_file_type"] = sv_file_type;
            row["sv_file_name"] = sv_file_name;
            row["sv_ojt_is_save_sync"] = true;
            dtTempAttachment.Rows.Add(row);
        }

        protected void gvOltAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvOjtAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Remove"))
            {
                try
                {
                    if (SessionWrapper.TempAttachment.Rows.Count > 0)
                    {
                        //Delete previous selected course
                        var rows = SessionWrapper.TempAttachment.Select("sv_ojt_attachments_id_pk= '" + attachmentId + "'");
                        foreach (var row in rows)
                            row.Delete();
                        SessionWrapper.TempAttachment.AcceptChanges();

                        this.gvOjtAttachments.DataSource = SessionWrapper.TempAttachment;
                        this.gvOjtAttachments.DataBind();
                    }
                    else
                    {
                        SiteViewOnJobTrainingBLL.DeleteOjtAttachment(attachmentId);
                        gvOjtAttachments.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(editOjtId);
                        gvOjtAttachments.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message);
                        }
                    }
                }
            }
            else if (e.CommandName.Equals("Download"))
            {
                string attachmentFileId = gvOjtAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvOjtAttachments.DataKeys[rowIndex][1].ToString();
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
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        /// <summary>
        /// Return Extension for File  
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
        /// <summary>
        /// Convert Datatable to XML
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
        /// <summary>
        /// Revert Back function for Reset
        /// </summary>
        /// <param name="OjtId"></param>
        private void RevertBack(string OjtId)
        {
            try
            {
                SessionWrapper.ResetOjtAttachment = SiteViewOnJobTrainingBLL.GetOjtAttachment(OjtId);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csveojt-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Reset Functionality
        /// </summary>
        private void ResetOjt()
        {
            if (SessionWrapper.TempAttachment.Rows.Count > 0)
            {
                SessionWrapper.TempAttachment = SessionWrapper.ResetOjtAttachment;
                gvOjtAttachments.DataSource = SessionWrapper.TempAttachment;
                gvOjtAttachments.DataBind();
            }
            else
            {
                try
                {
                    SiteViewOnJobTrainingBLL.ResetOjtAttachment(ConvertDataTableToXml(SessionWrapper.ResetOjtAttachment), editOjtId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message);
                        }
                    }
                }
                gvOjtAttachments.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(editOjtId);
                gvOjtAttachments.DataBind();
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetOjt();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetOjt();
        }

        protected void btnHeaderSaveOJT_Click(object sender, EventArgs e)
        {
            SaveOjt();
        }

        protected void btnFooterSaveOJT_Click(object sender, EventArgs e)
        {
            SaveOjt();
        }
        /// <summary>
        /// Insert / Update OJT
        /// </summary>
        private void SaveOjt()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SiteViewOnJobTraining createOjt = new SiteViewOnJobTraining();
            createOjt.sv_ojt_title = txtTitle.Text;
            createOjt.sv_ojt_location = txtLocation.Text;
            createOjt.sv_ojt_description = txtFieldDescription.InnerText;
            createOjt.sv_ojt_number = lblOjtNumber.Text;
            createOjt.sv_ojt_date = Convert.ToDateTime(txtDate.Text);
            createOjt.sv_ojt_duration = ddlDuration.SelectedValue;

            //DateTime? sv_ojt_start_time = null;
            //DateTime temptimeofday;
            //if (DateTime.TryParseExact(txtStartTime.Text, "h:mm tt", culture, DateTimeStyles.None, out temptimeofday))
            //{
            //    sv_ojt_start_time = temptimeofday;
            //}

            createOjt.sv_ojt_start_time = txtStartTime.Text;


            //DateTime? sv_ojt_end_time = null;
            //DateTime tempendtimeofday;
            //if (DateTime.TryParseExact(txtEndTime.Text, "h:mm tt", culture, DateTimeStyles.None, out tempendtimeofday))
            //{
            //    sv_ojt_end_time = tempendtimeofday;
            //}

            createOjt.sv_ojt_end_time = txtEndTime.Text;             
            createOjt.sv_ojt_type = ddlType.SelectedValue;
            //createOjt.sv_ojt_harm_title = txtHarmTitle.Text;
            //createOjt.sv_ojt_harm_number = txtHarmNumber.Text;
            
            createOjt.sv_ojt_other = txtOthers.Text;
            createOjt.sv_ojt_Trainer = txtTrainer.Text;
            createOjt.sv_ojt_is_save_sync = false;

            if (chkIsSafety.Checked == true)
            {
                createOjt.sv_ojt_issafty_brief = true;
                createOjt.sv_ojt_frequency = ddlFrequency.SelectedValue;
            }
            else
            {
                createOjt.sv_ojt_frequency = string.Empty;
                createOjt.sv_ojt_issafty_brief = false;
            }
            if (chkIsHarm.Checked == true)
            {
                createOjt.sv_ojt_isharm_related = true;
                createOjt.sv_ojt_harm_id_fk = ddlHarm.SelectedValue;
            }
            else
            {
                createOjt.sv_ojt_isharm_related = false;
                createOjt.sv_ojt_harm_id_fk = string.Empty;
            }
            if (chkIsCertification.Checked == true)
            {
                createOjt.sv_ojt_iscertification_related = true;
            }
            else
            {
                createOjt.sv_ojt_iscertification_related = false;
            }
            if (chkIsAcknowledge.Checked == true)
            {
                createOjt.sv_ojt_is_acknowledge = true;
            }
            else
            {
                createOjt.sv_ojt_is_acknowledge = false;
            }

            createOjt.sv_ojt_certify_filepath = SessionWrapper.ojt_upload_certification_file_path;
            createOjt.sv_ojt_certify_filename =SessionWrapper.ojt_upload_certification_file_name;
            createOjt.sv_ojt_certify_fileExt = SessionWrapper.ojt_upload_certification_file_extension;  



            if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"].ToString() == "saved"))
            {
                createOjt.sv_ojt_id_pk = editOjtId;
                if (SessionWrapper.ojt_upload_certification_check_file_name != SessionWrapper.ojt_upload_certification_file_name)
                {
                    createOjt.sv_ojt_certify_file_isUpdate = true;
                    createOjt.sv_ojt_certify_file_Update_sync = false;
                }
                else
                {
                    createOjt.sv_ojt_certify_file_isUpdate = false;
                    createOjt.sv_ojt_certify_file_Update_sync = false;
                }
                try
                {
                    int result = SiteViewOnJobTrainingBLL.UpdateOjt(createOjt);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = "OJT updated Successfully.";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message);
                        }
                    }
                }
            }
            else if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"].ToString() == "received"))
            {
                createOjt.sv_ojt_id_pk = Guid.NewGuid().ToString();
                createOjt.sv_ojt_created_by_fk = SessionWrapper.u_userid;
                createOjt.sv_ojt_attachment = ConvertDataTableToXml(SessionWrapper.TempAttachment);
                try
                {
                    int result = SiteViewOnJobTrainingBLL.InsertOJT(createOjt);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = "OJT Insered Successfully.";
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csveojt-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ccsv-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ccsv-01.aspx");
        }

        protected void btnUploadCertificate_Click(object sender, EventArgs e)
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
                    file.SaveAs(Server.MapPath(_attachmentpath + m_file_guid + m_file_extension));
                    SessionWrapper.ojt_upload_certification_file_path = m_file_guid + m_file_extension;
                    SessionWrapper.ojt_upload_certification_file_name = m_file_name;
                    SessionWrapper.ojt_upload_certification_file_extension = m_file_extension;
                    //SessionWrapper.ojt_upload_certification = m_file_name + m_file_extension;
                }
            }
            Attachment();
        }
        /// <summary>
        /// To show the Linkbutton and Edit and Remove button for certificate attachment
        /// </summary>
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.ojt_upload_certification_file_name))
            {
                lnkFileName.Text = SessionWrapper.ojt_upload_certification_file_name;
                btnUploadCeritification.Style.Add("display", "none");
                btnEdit.Style.Add("display", "inline");
                btnRemove.Style.Add("display", "inline");
                //btnView.Style.Add("display", "inline");
            }
            else
            {
                lnkFileName.Text = string.Empty;
                btnUploadCeritification.Style.Add("display", "inline");
                btnEdit.Style.Add("display", "none");
                btnRemove.Style.Add("display", "none");
               // btnView.Style.Add("display", "none");
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.ojt_upload_certification_file_name = string.Empty;
            SessionWrapper.ojt_upload_certification_file_path = string.Empty;
            SessionWrapper.ojt_upload_certification_file_extension = string.Empty;

            lnkFileName.Text = string.Empty;
            Attachment();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_attachmentpath + SessionWrapper.ojt_upload_certification_file_path);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.ojt_upload_certification_file_name + "\"");
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
}