using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Reflection;
using System.Security;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using System.Web.Security;
using ComplicanceFactor.Common;
using System.Data;

namespace ComplicanceFactor.Compliance.SiteView.Popup
{
    public partial class csvsq_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "send")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        string inspectionId = Request.QueryString["id"].ToString();
                    }
                }
                SessionWrapper.AddUserForSendInspection = null;
                SessionWrapper.AddUserForSendInspection = tempUser();
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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = new DataTable();
            dtUserInfo = SessionWrapper.AddUserForSendInspection;
            if (dtUserInfo.Rows.Count > 0)
            {                
                //Get Inspection and Question            
                DataTable dtInspectionQuestion = SiteViewInspectionBLL.GetAllInspectionQuestion(Request.QueryString["id"].ToString());
                DataTable dtInspectionTemplate = SiteViewInspectionBLL.GetSingleInspectionTemplate(Request.QueryString["id"].ToString());


                string sv_mi_inspection = ConvertDataTableToXml(dtInspectionTemplate);
                string sv_mi_inspection_questions = ConvertDataTableToXml(dtInspectionQuestion);
                string sv_mi_inspection_sent_to_user = ConvertDataTableToXml(dtUserInfo);

                try
                {
                    int result = SiteViewInspectionBLL.CreateInspectionSent(sv_mi_inspection, sv_mi_inspection_questions, sv_mi_inspection_sent_to_user, SessionWrapper.u_userid);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = "Send Successfully";
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
            }
        }        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtUserInfo = CheckUser(txtUserName.Text);
            if (dtUserInfo.Rows.Count > 0)
            {
                AddDataToTempUser(txtUserName.Text, dtUserInfo.Rows[0]["u_user_id_pk"].ToString(), SessionWrapper.AddUserForSendInspection);
                gvNewUser.DataSource = SessionWrapper.AddUserForSendInspection;
                gvNewUser.DataBind();
            }
            else
            {
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = "User name is mismatched.";
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
            dtUserColumn.ColumnName = "s_send_user_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "u_user_id_pk";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.String");
            dtUserColumn.ColumnName = "s_user_summary";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_is_acknowledged";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_acknowledged_status";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_is_completed";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_is_completed_sync";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_is_sync_mobile";
            dt.Columns.Add(dtUserColumn);

            dtUserColumn = new DataColumn();
            dtUserColumn.DataType = Type.GetType("System.Boolean");
            dtUserColumn.ColumnName = "sv_inspection_is_archive";
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
            row["s_send_user_pk"] = Guid.NewGuid().ToString();
            row["u_user_id_pk"] = u_user_id_pk;
            row["s_user_summary"] = s_user_summary;

            row["sv_inspection_is_acknowledged"] = true;
            row["sv_inspection_acknowledged_status"] = true;
            row["sv_inspection_is_completed"] = true;
            row["sv_inspection_is_completed_sync"] = true;
            row["sv_inspection_is_sync_mobile"] = true;
            row["sv_inspection_is_archive"] = true;
            dtTempUser.Rows.Add(row);
        }

        [System.Web.Services.WebMethod]
        public static void DeleteUser(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.AddUserForSendInspection.Select("s_send_user_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.AddUserForSendInspection.AcceptChanges();


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
            HashEncryption encHash = new HashEncryption();
            string encHasusername = encHash.GenerateHashvalue(username, true);            
            DataTable dtUserInfo = new DataTable();
            try
            {

                dtUserInfo = SiteViewFieldNotesBLL.GetUserId(encHasusername);
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