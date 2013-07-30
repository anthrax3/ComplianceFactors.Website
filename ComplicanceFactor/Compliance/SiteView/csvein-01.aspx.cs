using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Compliance.SiteView
{
    public partial class csvein_01 : System.Web.UI.Page
    {
        private static string editInspectionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread Crumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_compliance_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=../SiteView/ccsv-01.aspx>" + LocalResources.GetGlobalLabel("app_compliance_pod_site_view_title") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_m_inspection_text") + "</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                //ddlStatus Bind
                ddlStatus.DataSource = SiteViewInspectionBLL.GetStatus(SessionWrapper.CultureName,"csvein-01");
                ddlStatus.DataBind();

                //Edit
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {                   
                    editInspectionId = SecurityCenter.DecryptText(Request.QueryString["id"].ToString());
                    hdQuestionId.Value = editInspectionId;
                }
                PopulateInspection(editInspectionId);
                RevertBack(editInspectionId);
            }
            gvQuestions.DataSource = SiteViewInspectionBLL.GetAllInspectionQuestion(editInspectionId);
            gvQuestions.DataBind();
        }
        private void PopulateInspection(string inspectionId)
        {
            DataTable dtInspection = new DataTable();
            try
            {
                dtInspection = SiteViewInspectionBLL.GetSingleInspection(inspectionId);               

                //SessionWrapper.session_Add_Questions = dtInspection;

                lblInspectionId.Text = dtInspection.Rows[0]["sv_mi_templete_id"].ToString();
                txtInspectionName.Text = dtInspection.Rows[0]["sv_mi_templete_title"].ToString();
                txtInspectionDescription.InnerText = dtInspection.Rows[0]["sv_mi_templete_description"].ToString();
                ddlStatus.SelectedValue = dtInspection.Rows[0]["sv_mi_templete_status"].ToString();
                chkIsDefault.Checked = Convert.ToBoolean(dtInspection.Rows[0]["sv_mi_templete_is_default"]);

                gvQuestions.DataSource = SiteViewInspectionBLL.GetAllInspectionQuestion(editInspectionId);
                gvQuestions.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message);
                    }
                }
            }
        }

        private void RevertBack(string questionId)
        {
            SessionWrapper.Reset_Questions = TempQuestions();
            try
            {
                SessionWrapper.Reset_Questions = SiteViewInspectionBLL.GetSingleInspection(questionId);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// create datatable for session
        /// </summary>
        /// <returns></returns>
        private DataTable TempQuestions()
        {
            DataTable dtTempQuestions = new DataTable();
            DataColumn dtTempQuestionsColumn;

            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_id_pk";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);

            //Id
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_display_order";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //Question
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //Question type
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_type";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //option1
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_answer_optionsA";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //option2
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_answer_optionsB";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //option3
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_answer_optionsC";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);
            //option4
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_answer_optionsD";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);

            //Answer
            dtTempQuestionsColumn = new DataColumn();
            dtTempQuestionsColumn.DataType = Type.GetType("System.String");
            dtTempQuestionsColumn.ColumnName = "sv_mi_templete_question_answer";
            dtTempQuestions.Columns.Add(dtTempQuestionsColumn);

            return dtTempQuestions;
        }

        protected void btnFooterSaveInspection_Click(object sender, EventArgs e)
        {
            UpdateInspectionTemplate();
        }
        /// <summary>
        /// Update Inspection
        /// </summary>
        private void UpdateInspectionTemplate()
        {
            SiteViewInspectionTemplate updateInspection = new SiteViewInspectionTemplate();
            updateInspection.sv_mi_templete_id_pk = editInspectionId;
            updateInspection.sv_mi_templete_id = lblInspectionId.Text;
            updateInspection.sv_mi_templete_description = txtInspectionDescription.InnerText;
            updateInspection.sv_mi_templete_status = ddlStatus.SelectedValue;
            updateInspection.sv_mi_templete_title = txtInspectionName.Text;
            if (chkIsDefault.Checked == true)
            {
                updateInspection.sv_mi_templete_is_default = true;
            }
            else
                updateInspection.sv_mi_templete_is_default = false;
            updateInspection.sv_mi_templete_last_modify_date = DateTime.Now;
            updateInspection.sv_mi_templete_created_by_fk = SessionWrapper.u_userid;

            try
            {
                int result = SiteViewInspectionBLL.UpdateInspection(updateInspection);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerText = LocalResources.GetText("app_succ_update_text");
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
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message);
                    }
                }
            }

        }
        ///<summary>
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
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
            SiteViewInspectionTemplate resetQuestions = new SiteViewInspectionTemplate();
            resetQuestions.sv_mi_templete_id_pk = editInspectionId;
            resetQuestions.sv_mi_questions = ConvertDataTableToXml(SessionWrapper.Reset_Questions);
            try
            {
                int result = SiteViewInspectionBLL.ResetQuestions(resetQuestions);
                if (result == 0)
                {
                    gvQuestions.DataSource = SiteViewInspectionBLL.GetSingleInspection(editInspectionId);
                    gvQuestions.DataBind();
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
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message);
                    }
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static void DeleteQuestion(string args)
        {
            try
            {
                int result = SiteViewInspectionBLL.DeleteSingleQuestion(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvein-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SiteView/ccsv-01.aspx");
        }     
    }
}