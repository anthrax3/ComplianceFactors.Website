using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Compliance.SiteView.FieldNotes.Popup
{
    public partial class csvsfn_01 : System.Web.UI.Page
    {
        private static string fielsnotesId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "send")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        fielsnotesId = Request.QueryString["id"].ToString();
                    }
                }
                PopulateFieldNoteHeader();
                SessionWrapper.AddUserForSendFieldNotes = null;
                SessionWrapper.AddUserForSendFieldNotes = tempUser();
            }
        }
        /// <summary>
        /// Populate Header
        /// </summary>
        /// <param name="fieldnoteId"></param>
        private void PopulateFieldNoteHeader()
        {
            SiteViewFieldNotes fieldnotes = new SiteViewFieldNotes();
            try
            {
                SiteViewFieldNotes fieldNotesId = new SiteViewFieldNotes();
                fieldNotesId = SiteViewFieldNotesBLL.GetFieldNoteId();
                lblFieldNoteHeader.Text = LocalResources.GetLabel("app_field_note_text")+ "[" + fieldNotesId.sv_fieldnote_id + "]";
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Convert Datatable to xml 
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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = new DataTable();
            dtUserInfo = SessionWrapper.AddUserForSendFieldNotes;
            int i = 0;
            foreach (GridViewRow row in gvNewUser.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkIsAcknowledge");
                if (chkSelect.Checked == true)
                {
                    dtUserInfo.Rows[i]["sv_fieldnote_is_need_acknowledged"] = true; //sv_fieldnote_acknowledged_status
                }
                else
                {
                    dtUserInfo.Rows[i]["sv_fieldnote_is_need_acknowledged"] = false;
                }
                i = i + 1;
                dtUserInfo.AcceptChanges();
            }
            if (dtUserInfo.Rows.Count > 0)
            {
                //if (Request.QueryString["CreatedBy"] == SessionWrapper.u_userid)
                //{
                //    try
                //    {
                //        string sv_mi_fieldnote_sent_to_user = ConvertDataTableToXml(dtUserInfo);
                //        int result = SiteViewFieldNotesBLL.InsertFieldNotesSentUser(sv_mi_fieldnote_sent_to_user);
                //        if (result == 0)
                //        {
                //            divSuccess.Style.Add("display", "block");
                //            divError.Style.Add("display", "none");
                //            divSuccess.InnerText = "Send Successfully";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        if (ConfigurationWrapper.LogErrors == true)
                //        {
                //            if (ex.InnerException != null)
                //            {
                //                Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message, ex.InnerException.Message);
                //            }
                //            else
                //            {
                //                Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message);
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //Get Fieldnote and attachment      
                string sv_mi_fieldnotes_sent_to_user = ConvertDataTableToXml(dtUserInfo);

                SiteViewFieldNotes fieldNotesId = new SiteViewFieldNotes();
                fieldNotesId = SiteViewFieldNotesBLL.GetFieldNoteId();

                SiteViewFieldNotes fieldnotes = new SiteViewFieldNotes();
                fieldnotes = SiteViewFieldNotesBLL.GetSingleFieldNotes(fielsnotesId);

                //Create New Field Notes
                SiteViewFieldNotes createField = new SiteViewFieldNotes();
                createField.sv_fieldnote_id_pk = Guid.NewGuid().ToString();
                createField.sv_fieldnote_id = fieldNotesId.sv_fieldnote_id;
                createField.sv_fieldnote_description = fieldnotes.sv_fieldnote_description;
                createField.sv_fieldnote_location = fieldnotes.sv_fieldnote_location;
                createField.sv_fieldnote_creation_date = DateTime.Now.ToShortDateString();
                createField.sv_fieldnote_title = fieldnotes.sv_fieldnote_title;
                createField.sv_fieldnote_created_by_fk = SessionWrapper.u_userid;
                createField.sv_fieldnote_is_save_sync = false;
                createField.sv_fieldnote_is_acknowledge = fieldnotes.sv_fieldnote_is_acknowledge;

                DataTable dt = SiteViewFieldNotesBLL.GetFieldNotesAttachment(fielsnotesId);
                createField.sv_fieldnote_attachment = ConvertDataTableToXml(dt);
                createField.sv_mi_fieldnote_sent_to_user = sv_mi_fieldnotes_sent_to_user;
                try
                {

                    int result = SiteViewFieldNotesBLL.CreateFieldNotesSent(createField);
                    if (result == 0)
                    {
                        SessionWrapper.isFieldNoteLoad = true;
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_send_text"); 
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvsfn-01.aspx", ex.Message);
                        }
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                //}
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = CheckUser(txtUserName.Text);
            if (dtUserInfo.Rows.Count > 0)
            {
                AddDataToTempUser(txtUserName.Text, dtUserInfo.Rows[0]["u_user_id_pk"].ToString(), SessionWrapper.AddUserForSendFieldNotes);
                gvNewUser.DataSource = SessionWrapper.AddUserForSendFieldNotes;
                gvNewUser.DataBind();

                divError.Style.Add("display", "none");
            }
            else
            {
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_username_mismatched_error_wrong"); 
            }
            txtUserName.Text = string.Empty;
        }
        /// <summary>
        /// TempUser for create user table
        /// </summary>
        /// <returns></returns>
        private DataTable tempUser()
        {
            DataTable dt = new DataTable();
            DataColumn dtUserColumn;
            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_fieldnote_sent_to_id_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_fieldnote_id_fk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "s_user_summary";
            dt.Columns.Add(dtUserColumn);


            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_fieldnote_sent_to_user_fk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_fieldnote_is_need_acknowledged";
            dt.Columns.Add(dtUserColumn);


            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_fieldnote_acknowledged_status";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_fieldnote_is_sync_mobile";
            dt.Columns.Add(dtUserColumn);

            return dt;
        }
        /// <summary>
        /// To add the datas to the Sent to user table
        /// </summary>
        /// <param name="s_user_summary"></param>
        /// <param name="u_user_id_pk"></param>
        /// <param name="dtTempUser"></param>
        private void AddDataToTempUser(string s_user_summary, string u_user_id_pk, DataTable dtTempUser)
        {
            DataRow row;

            row = dtTempUser.NewRow();
            row["sv_fieldnote_sent_to_id_pk"] = Guid.NewGuid().ToString();
            row["sv_fieldnote_id_fk"] = fielsnotesId;
            row["sv_fieldnote_sent_to_user_fk"] = u_user_id_pk;
            row["s_user_summary"] = s_user_summary;
            row["sv_fieldnote_is_need_acknowledged"] = false;
            row["sv_fieldnote_acknowledged_status"] = false;
            row["sv_fieldnote_is_sync_mobile"] = true;

            dtTempUser.Rows.Add(row);
        }

        [System.Web.Services.WebMethod]
        public static void DeleteUser(string args)
        {
            try
            {
                //Delete selected  user
                var rows = SessionWrapper.AddUserForSendFieldNotes.Select("sv_fieldnote_sent_to_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.AddUserForSendFieldNotes.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvsq-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvsq-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// To check user to find the user is availableor not
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private DataTable CheckUser(string username)
        {
            DataTable dtUserInfo = new DataTable();
            HashEncryption encHash = new HashEncryption();
            string encHasusername = encHash.GenerateHashvalue(username, true);
            try
            {
                dtUserInfo = SiteViewFieldNotesBLL.GetUserId(encHasusername);
                if (dtUserInfo.Rows[0]["u_user_id_pk"].ToString() == SessionWrapper.u_userid)
                {
                    dtUserInfo.Clear();
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvsq-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvsq-01", ex.Message);
                    }
                }
            }
            return dtUserInfo;
        }
    }
}