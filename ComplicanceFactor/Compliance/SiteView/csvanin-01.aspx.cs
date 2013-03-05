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

namespace ComplicanceFactor.Compliance.SiteView
{
    public partial class csvanin_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread Crumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=../SiteView/ccsv-01.aspx>" + "SiteView" + "</a>" + " >&nbsp;" + "Create New M-Inspection";

                SessionWrapper.session_Add_Questions = TempQuestions();
                //ddlStatus Bind
                ddlStatus.DataSource = SiteViewInspectionBLL.GetStatus(SessionWrapper.CultureName, "csvanin-01");
                ddlStatus.DataBind();

                //To bind Inspection Id
                if (!string.IsNullOrEmpty(Request.QueryString["InspectionId"]))
                {
                    lblInspectionId.Text = SecurityCenter.DecryptText(Request.QueryString["InspectionId"]);
                }                
            }
            // to bind the session values in grid
            if (SessionWrapper.session_Add_Questions.Rows.Count > 0)
            {
                gvQuestions.DataSource = SessionWrapper.session_Add_Questions;
                gvQuestions.DataBind();
            }
        }

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

        protected void btnFooterSaveNewInspection_Click(object sender, EventArgs e)
        {
            SiteViewInspectionTemplate inspection = new SiteViewInspectionTemplate();
            inspection.sv_mi_templete_id_pk = Guid.NewGuid().ToString();
            inspection.sv_mi_templete_id = lblInspectionId.Text;
            inspection.sv_mi_templete_description = txtInspectionDescription.InnerText;
            inspection.sv_mi_templete_created_date = DateTime.UtcNow;
            inspection.sv_mi_templete_status = ddlStatus.SelectedValue;
            inspection.sv_mi_templete_title = txtInspectionName.Text;
            if (chkIsDefault.Checked == true)
            {
                inspection.sv_mi_templete_is_default = true;
            }
            else
            {
                inspection.sv_mi_templete_is_default = false;
            }
            inspection.sv_mi_templete_last_modify_date = DateTime.Now;
            inspection.sv_mi_templete_created_by_fk = SessionWrapper.u_userid;
            inspection.sv_mi_questions = ConvertDataTableToXml(SessionWrapper.session_Add_Questions);

            try
            {
                int result = SiteViewInspectionBLL.CreateNewInspectionTemplate(inspection);
                if (result == 0)
                {
                    Response.Redirect("~/Compliance/SiteView/csvein-01.aspx?mode=edit&id=" + SecurityCenter.EncryptText(inspection.sv_mi_templete_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("csvanin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvanin-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SiteView/ccsv-01.aspx");
        }       

        /// <summary>
        /// Web Method for delete
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteQuestion(string args)
        {
            //SessionWrapper.session_Add_Questions
            try
            {
                //Delete previous selected  question
                var rows = SessionWrapper.session_Add_Questions.Select("sv_mi_templete_question_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.session_Add_Questions.AcceptChanges();

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvanin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvanin-01", ex.Message);
                    }
                }
            }
        }
    }
}