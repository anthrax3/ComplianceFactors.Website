using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.Compliance.SiteView.Popup
{
    public partial class csvanq_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            

        }
        // Edit the session (or) datatable values        
        private void EditDataToTempQuestions(int rowIndex, string question_Id, string question_Name, string question_Type, string option1, string option2, string option3, string option4, DataTable dtTempQuestions)
        {
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question"] = question_Name;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_type"] = question_Type;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsA"] = option1;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsB"] = option2;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsC"] = option3;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsD"] = option4;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_display_order"] = question_Id;

            dtTempQuestions.AcceptChanges();
        }
        // Add Question to the session       
        private void AddDataToTempQuestions(string question_Id, string question_Name, string question_Type, string option1, string option2, string option3, string option4, string answer, DataTable dtTempQuestions)
        {
            DataRow row;
            row = dtTempQuestions.NewRow();
            row["sv_mi_templete_question_id_pk"] = Guid.NewGuid().ToString();
            row["sv_mi_templete_question"] = question_Name;
            row["sv_mi_templete_question_type"] = question_Type;
            row["sv_mi_templete_question_answer_optionsA"] = option1;
            row["sv_mi_templete_question_answer_optionsB"] = option2;
            row["sv_mi_templete_question_answer_optionsC"] = option3;
            row["sv_mi_templete_question_answer_optionsD"] = option4;
            row["sv_mi_templete_question_display_order"] = question_Id;
            row["sv_mi_templete_question_answer"] = answer;
            dtTempQuestions.Rows.Add(row);
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "csvein")
                {
                    string idValue = Request.QueryString["editquestionId"].ToString();
                    SiteViewInspectionTemplate createQuestion = new SiteViewInspectionTemplate();
                    createQuestion.sv_mi_templete_question_id_pk = Guid.NewGuid().ToString();
                    createQuestion.sv_mi_templete_id_fk = idValue;
                    createQuestion.sv_mi_templete_question = txtQuestion.InnerText;
                    createQuestion.sv_mi_templete_question_type = Convert.ToInt16(ddlQuestionType.SelectedValue);
                    createQuestion.sv_mi_templete_question_answer_optionsA = txtOption1.Text;
                    createQuestion.sv_mi_templete_question_answer_optionsB = txtOption2.Text;
                    createQuestion.sv_mi_templete_question_answer_optionsC = txtOption3.Text;
                    createQuestion.sv_mi_templete_question_answer_optionsD = txtOption4.Text;
                    createQuestion.sv_mi_templete_question_display_order = Convert.ToInt16(txtQuestionOrder.Text);
                    createQuestion.sv_mi_templete_question_answer = txtAnswer.Text;
                    try
                    {
                        int result = SiteViewInspectionBLL.InsertQuestions(createQuestion);
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("csvanq-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("csvanq-01.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                AddDataToTempQuestions(txtQuestionOrder.Text, txtQuestion.InnerText, ddlQuestionType.SelectedValue, txtOption1.Text, txtOption2.Text, txtOption3.Text, txtOption4.Text,txtAnswer.Text, SessionWrapper.session_Add_Questions);
            }
            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}