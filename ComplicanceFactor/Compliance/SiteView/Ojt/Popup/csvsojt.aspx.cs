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

namespace ComplicanceFactor.Compliance.SiteView.Ojt.Popup
{
    public partial class csvsojt : System.Web.UI.Page
    {
        private static string strOjtId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "send")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        strOjtId = Request.QueryString["id"].ToString();
                    }
                }
                SessionWrapper.AddUserForSendOjt = null;
                SessionWrapper.AddUserForSendOjt = tempUser();
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

        private DataTable tempUser()
        {
            DataTable dt = new DataTable();
            DataColumn dtUserColumn;
            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_ojt_sent_to_id_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_ojt_id_fk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "s_user_summary";
            dt.Columns.Add(dtUserColumn);


            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "sv_ojt_sent_to_user_fk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_ojt_is_need_acknowledged";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_ojt_acknowledged_status";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_ojt_is_sync_mobile";
            dt.Columns.Add(dtUserColumn);

            return dt;
        }
        private void AddDataToTempUser(string s_user_summary, string u_user_id_pk, DataTable dtTempUser)
        {
            DataRow row;

            row = dtTempUser.NewRow();
            row["sv_ojt_sent_to_id_pk"] = Guid.NewGuid().ToString();
            row["sv_ojt_id_fk"] = strOjtId;
            row["sv_ojt_sent_to_user_fk"] = u_user_id_pk;
            row["s_user_summary"] = s_user_summary;
            row["sv_ojt_is_need_acknowledged"] = false;
            row["sv_ojt_acknowledged_status"] = false;
            row["sv_ojt_is_sync_mobile"] = true;

            dtTempUser.Rows.Add(row);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = new DataTable();
            dtUserInfo = SessionWrapper.AddUserForSendOjt;
            int i = 0;
            foreach (GridViewRow row in gvNewUser.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkIsAcknowledge");
                if (chkSelect.Checked == true)
                {
                    dtUserInfo.Rows[i]["sv_ojt_is_need_acknowledged"] = true; //sv_fieldnote_acknowledged_status
                }
                else
                {
                    dtUserInfo.Rows[i]["sv_ojt_is_need_acknowledged"] = false;
                }
                i = i + 1;
                dtUserInfo.AcceptChanges();
            }
            if (dtUserInfo.Rows.Count > 0)
            {
                //Get ojt and attachment      
                string sv_mi_ojt_sent_to_user = ConvertDataTableToXml(dtUserInfo);

                SiteViewOnJobTraining ojtId = new SiteViewOnJobTraining();
                ojtId = SiteViewOnJobTrainingBLL.GetOjtId();

                SiteViewOnJobTraining ojt = new SiteViewOnJobTraining();
                ojt = SiteViewOnJobTrainingBLL.GetSingleOjt(strOjtId);


                SiteViewOnJobTraining createOjt = new SiteViewOnJobTraining();
                createOjt.sv_ojt_id_pk = Guid.NewGuid().ToString();
                createOjt.sv_ojt_number = ojtId.sv_ojt_id_pk;
                createOjt.sv_ojt_description = ojt.sv_ojt_description;
                createOjt.sv_ojt_location = ojt.sv_ojt_location;
                createOjt.sv_ojt_creation_date_time = DateTime.Now.ToShortDateString();
                createOjt.sv_ojt_title = ojt.sv_ojt_title;
                createOjt.sv_ojt_created_by_fk = SessionWrapper.u_userid;
                createOjt.sv_ojt_date = ojt.sv_ojt_date;
                createOjt.sv_ojt_duration = ojt.sv_ojt_duration;
                createOjt.sv_ojt_start_time = ojt.sv_ojt_start_time;
                createOjt.sv_ojt_end_time = ojt.sv_ojt_end_time;
                createOjt.sv_ojt_type = ojt.sv_ojt_type;
                createOjt.sv_ojt_harm_title = ojt.sv_ojt_harm_title;
                createOjt.sv_ojt_harm_number = ojt.sv_ojt_harm_number;
                createOjt.sv_ojt_frequency = ojt.sv_ojt_frequency;
                createOjt.sv_ojt_other = ojt.sv_ojt_other;
                createOjt.sv_ojt_Trainer = ojt.sv_ojt_Trainer;
                createOjt.sv_ojt_issafty_brief = ojt.sv_ojt_issafty_brief;
                createOjt.sv_ojt_isharm_related = ojt.sv_ojt_isharm_related;
                createOjt.sv_ojt_iscertification_related = ojt.sv_ojt_iscertification_related;
                createOjt.sv_ojt_is_acknowledge = ojt.sv_ojt_is_acknowledge;
                createOjt.sv_ojt_harm_id_fk = ojt.sv_ojt_harm_id_fk;
                createOjt.sv_ojt_certify_filepath = ojt.sv_ojt_certify_filepath;
                createOjt.sv_ojt_certify_filename = ojt.sv_ojt_certify_filename;
                createOjt.sv_ojt_certify_fileExt = ojt.sv_ojt_certify_fileExt;
                //createOjt.sv_ojt_is_save_sync = false;

                DataTable dt = SiteViewOnJobTrainingBLL.GetOjtAttachment(strOjtId);
                createOjt.sv_ojt_attachment = ConvertDataTableToXml(dt);
                createOjt.sv_mi_ojt_sent_to_user = sv_mi_ojt_sent_to_user;
                try
                {
                    int result = SiteViewOnJobTrainingBLL.CreateOjtSent(createOjt);
                    if (result == 0)
                    {
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
                            Logger.WriteToErrorLog("csvsojt-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("csvsojt-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = CheckUser(txtUserName.Text);
            if (dtUserInfo.Rows.Count > 0)
            {
                AddDataToTempUser(txtUserName.Text, dtUserInfo.Rows[0]["u_user_id_pk"].ToString(), SessionWrapper.AddUserForSendOjt);
                gvNewUser.DataSource = SessionWrapper.AddUserForSendOjt;
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
        private DataTable CheckUser(string username)
        {
            DataTable dtUserInfo = new DataTable();
            HashEncryption encHash = new HashEncryption();
            string encHasusername = encHash.GenerateHashvalue(username, true);
            try
            {
                dtUserInfo = SiteViewOnJobTrainingBLL.GetUserId(encHasusername);
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
                        Logger.WriteToErrorLog("csvsojt-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvsojt-01", ex.Message);
                    }
                }
            }
            return dtUserInfo;
        }


        [System.Web.Services.WebMethod]
        public static void DeleteUser(string args)
        {
            try
            {
                //Delete selected  user
                var rows = SessionWrapper.AddUserForSendFieldNotes.Select("sv_ojt_sent_to_id_pk= '" + args.Trim() + "'");
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
                        Logger.WriteToErrorLog("csvsojt-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvsojt-01", ex.Message);
                    }
                }
            }
        }
    }
}