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


namespace ComplicanceFactor.Compliance.SiteView.Ojt
{
    public partial class csveojt_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/Compliance/SiteView/Ojt/Attachments/";
        private static string editOjtId;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label Bread Crumb
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + "Compliance" + "</a>&nbsp;" + " >&nbsp;" + "<a href=../ccsv-01.aspx>" + "SiteView" + "</a>" + " >&nbsp;" + "Edit OJT";
            if (!IsPostBack)
            {
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
                    //editFieldNoteId = Guid.NewGuid().ToString();
                }
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
                txtDate.Text = ojt.sv_ojt_date.ToString();
                txtDuration.Text = ojt.sv_ojt_duration;
                if (!string.IsNullOrEmpty(ojt.sv_ojt_start_time.ToString()))
                {
                    txtStartTime.Text = Convert.ToDateTime(ojt.sv_ojt_start_time).ToShortTimeString();
                }
                if (!string.IsNullOrEmpty(ojt.sv_ojt_end_time.ToString()))
                {
                    txtEndTime.Text = Convert.ToDateTime(ojt.sv_ojt_end_time).ToShortTimeString();
                }
                txtType.Text = ojt.sv_ojt_type;
                txtHarmTitle.Text = ojt.sv_ojt_harm_title;
                txtHarmNumber.Text = ojt.sv_ojt_harm_number;
                txtFrequency.Text = ojt.sv_ojt_frequency;
                txtOthers.Text = ojt.sv_ojt_other;
                txtTrainer.Text = ojt.sv_ojt_Trainer;
                if (ojt.sv_ojt_issafty_brief == true)
                {
                    chkIsSafety.Checked = true;
                }
                if (ojt.sv_ojt_isharm_related == true)
                {
                    chkIsHarm.Checked = true;
                }
                if (ojt.sv_ojt_iscertification_related == true)
                {
                    chkIsCertification.Checked = true;
                }
                if (ojt.sv_ojt_is_acknowledge == true)
                {
                    chkIsAcknowledge.Checked = true;
                }
                else
                {
                    chkIsAcknowledge.Checked = false;
                }
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

        protected void btnHeaderSaveFieldNotes_Click(object sender, EventArgs e)
        {
            SaveOjt();
        }

        protected void btnFooterSaveFieldNotes_Click(object sender, EventArgs e)
        {
            SaveOjt();
        }
        private void SaveOjt()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SiteViewOnJobTraining createOjt = new SiteViewOnJobTraining();
            createOjt.sv_ojt_title = txtTitle.Text;
            createOjt.sv_ojt_location = txtLocation.Text;
            createOjt.sv_ojt_description = txtFieldDescription.InnerText;
            createOjt.sv_ojt_number = lblOjtNumber.Text;
            createOjt.sv_ojt_date = Convert.ToDateTime(txtDate.Text);
            createOjt.sv_ojt_duration = txtDuration.Text;

            DateTime? sv_ojt_start_time = null;
            DateTime temptimeofday;
            if (DateTime.TryParseExact(txtStartTime.Text, "h:mm tt", culture, DateTimeStyles.None, out temptimeofday))
            {
                sv_ojt_start_time = temptimeofday;
            }

            createOjt.sv_ojt_start_time = sv_ojt_start_time;


            DateTime? sv_ojt_end_time = null;
            DateTime tempendtimeofday;
            if (DateTime.TryParseExact(txtEndTime.Text, "h:mm tt", culture, DateTimeStyles.None, out tempendtimeofday))
            {
                sv_ojt_end_time = tempendtimeofday;
            }

            createOjt.sv_ojt_end_time = sv_ojt_end_time;


            //createOjt.sv_ojt_start_time =Convert.ToDateTime(StartTime.Date);
            //createOjt.sv_ojt_end_time =Convert.ToDateTime(EndTime.Date);
            createOjt.sv_ojt_type = txtType.Text;
            createOjt.sv_ojt_harm_title = txtHarmTitle.Text;
            createOjt.sv_ojt_harm_number = txtHarmNumber.Text;
            createOjt.sv_ojt_frequency = txtFrequency.Text;
            createOjt.sv_ojt_other = txtOthers.Text;
            createOjt.sv_ojt_Trainer = txtTrainer.Text;
            createOjt.sv_ojt_is_save_sync = false;
            if (chkIsSafety.Checked == true)
            {
                createOjt.sv_ojt_issafty_brief = true;
            }
            else
            {
                createOjt.sv_ojt_issafty_brief = false;
            }
            if (chkIsHarm.Checked == true)
            {
                createOjt.sv_ojt_isharm_related = true;
            }
            else
            {
                createOjt.sv_ojt_isharm_related = false;
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

            if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"].ToString() == "saved"))
            {
               
                createOjt.sv_ojt_id_pk = editOjtId;          
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
    }
}