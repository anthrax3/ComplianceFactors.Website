using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;

namespace ComplicanceFactor.SystemHome.Users.ManageLearningHistory
{
    public partial class p_mlhp_01 : System.Web.UI.Page
    {
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchResult();
            }
        }
        /// <summary>
        /// Search Results
        /// </summary>
        private void SearchResult()
        {
            Enrollment SearchlearningHistory = new Enrollment();

            SearchlearningHistory.e_enroll_user_id_fk = Request.QueryString["id"];
            hdEditUser.Value = Request.QueryString["id"];
            SearchlearningHistory.e_learning_keyword = "";
            SearchlearningHistory.e_learning_from_date = null;
            SearchlearningHistory.e_learning_to_date = null;
            SearchlearningHistory.e_learning_status = "0";
            SearchlearningHistory.e_learning_deliveryType = "0";
            try
            {              
                gvLearningHistory.DataSource = EnrollmentBLL.SerchLearningHistory(SearchlearningHistory);
                gvLearningHistory.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mlhp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mlhp-01", ex.Message);
                    }
                }
            }

            gvLearningHistory.UseAccessibleHeader = true;
            if (gvLearningHistory.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvLearningHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvLearningHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string t_transcript_course_id_fk = gvLearningHistory.DataKeys[e.Row.RowIndex][1].ToString();
                string t_transcript_user_id_fk = gvLearningHistory.DataKeys[e.Row.RowIndex][0].ToString();
                string t_transcript_delivery_id_fk = gvLearningHistory.DataKeys[e.Row.RowIndex][2].ToString();

                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                ddlStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                ddlStatus.DataBind();

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = Convert.ToString(drv["status"]);
                ddlStatus.SelectedItem.Text = status;
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataTable dtUpdateLearningHistory = TempUpdateMyLearningHistory();
            string deliveryType = string.Empty;
            string deliveryID = string.Empty;
            string passingStatus = string.Empty;
            string grade = string.Empty;
            int score = 0;
            foreach (GridViewRow row in gvLearningHistory.Rows)
            {
                string c_delivery_id_pk = gvLearningHistory.DataKeys[row.RowIndex][2].ToString();
                string t_transcript_course_id_fk = gvLearningHistory.DataKeys[row.RowIndex][1].ToString();
                DropDownList ddlPassignStatus = (DropDownList)row.FindControl("ddlStatus");
                TextBox txtCompletionDate = (TextBox)row.FindControl("txtCompletionDate");
                TextBox txtscore = (TextBox)row.FindControl("txtScore");

                if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                {
                    //do calculation and change the Passing status Grading Scheme
                    string scorestrValue = txtscore.Text.Replace("%","");
                    Decimal scoreValue = Convert.ToDecimal(scorestrValue);
                    score = Convert.ToInt32(scoreValue);
                    SystemGradingSchemes gradevalues = new SystemGradingSchemes();
                    gradevalues = ManageCompletionBLL.GetGradeByScore(c_delivery_id_pk, score);
                    if (!string.IsNullOrEmpty(gradevalues.s_grading_scheme_value_pass_status_id_fk))
                    {
                        if (gradevalues.s_grading_scheme_value_pass_status_id_fk == "app_ddl_pass_text")
                        {
                            passingStatus = "app_ddl_passed_text";
                        }
                        else
                        {
                            passingStatus = "app_ddl_failed_text";
                        }
                        grade = gradevalues.s_grading_scheme_system_value_id_pk;
                    }
                    else
                    {
                        passingStatus = ddlPassignStatus.SelectedValue;
                    }
                }
                else
                {
                    passingStatus = ddlPassignStatus.SelectedValue;
                }

                DataRow learningHistoryrow;
                learningHistoryrow = dtUpdateLearningHistory.NewRow();
                learningHistoryrow["t_transcript_course_id_fk"] = t_transcript_course_id_fk;
                learningHistoryrow["t_transcript_user_id_fk"] = Convert.ToString(Request.QueryString["id"]);
                learningHistoryrow["t_transcript_delivery_id_fk"] = c_delivery_id_pk;
                learningHistoryrow["s_status_id_pk"] = passingStatus;
                if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                {
                    learningHistoryrow["t_transcript_completion_score"] = score;
                }
                else
                {
                    learningHistoryrow["t_transcript_completion_score"] = 0;
                }

                if (!string.IsNullOrEmpty(txtCompletionDate.Text))
                {
                    learningHistoryrow["t_transcript_completion_date_time"] = txtCompletionDate.Text;
                }
                else
                {
                    learningHistoryrow["t_transcript_completion_date_time"] = DateTime.Now;
                }
                //learningHistoryrow["completiondate"] = Convert.ToString(Request.QueryString["id"]);
                dtUpdateLearningHistory.Rows.Add(learningHistoryrow);

                
            }
            //Update Process
            ConvertDataTables convertdt = new ConvertDataTables();
            try
            {
                int result = SystemMassCompletionBLL.UpdateLearningHistory(convertdt.ConvertDataTableToXml(dtUpdateLearningHistory));
                if (result == 1)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Learning History records updated successfully";
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mlhp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mlhp-01", ex.Message);
                    }
                }
            }
            SearchResult();
            divSuccess.Style.Add("display", "block");
            divSuccess.InnerHtml = "Learning History records updated successfully";
        }

        /// <summary>
        /// Temp Datatable for Learning History
        /// </summary>
        /// <returns></returns>
        public static DataTable TempUpdateMyLearningHistory()
        {
            DataTable dtTempUpdateMyCourse = new DataTable();
            DataColumn dtUpdateMyCourseColumn;

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCourseColumn.ColumnName = "t_transcript_course_id_fk";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCourseColumn.ColumnName = "t_transcript_user_id_fk";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCourseColumn.ColumnName = "t_transcript_delivery_id_fk";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCourseColumn.ColumnName = "s_status_id_pk";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.Int16");
            dtUpdateMyCourseColumn.ColumnName = "t_transcript_completion_score";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            dtUpdateMyCourseColumn = new DataColumn();
            dtUpdateMyCourseColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCourseColumn.ColumnName = "t_transcript_completion_date_time";
            dtTempUpdateMyCourse.Columns.Add(dtUpdateMyCourseColumn);

            return dtTempUpdateMyCourse;
        }
    }
}