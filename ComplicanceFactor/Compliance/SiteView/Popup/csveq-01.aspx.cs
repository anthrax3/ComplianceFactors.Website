using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.Compliance.SiteView.Popup
{
    public partial class csveq : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "csvanin")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            DataView dvQuestion = new DataView(SessionWrapper.session_Add_Questions);
                            dvQuestion.RowFilter = "sv_mi_templete_question_id_pk= '" + Request.QueryString["id"] + "'";
                            //Get Temp Question
                            TempGetQuestion(Request.QueryString["id"], dvQuestion.ToTable());
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "csvein")
                    {
                        SiteViewInspectionTemplate inspection = new SiteViewInspectionTemplate();
                        try
                        {
                            inspection = SiteViewInspectionBLL.GetSingleInspectionQuestion(Request.QueryString["editQuestionId"]);

                            txtQuestion.InnerText = inspection.sv_mi_templete_question;
                            txtQuestionOrder.Text = inspection.sv_mi_templete_question_display_order.ToString();
                            txtOption1.Text = inspection.sv_mi_templete_question_answer_optionsA;
                            txtOption2.Text = inspection.sv_mi_templete_question_answer_optionsB;
                            txtOption3.Text = inspection.sv_mi_templete_question_answer_optionsC;
                            txtOption4.Text = inspection.sv_mi_templete_question_answer_optionsD;
                            ddlQuestionType.SelectedValue = inspection.sv_mi_templete_question_type.ToString();
                            txtAnswer.Text = inspection.sv_mi_templete_question_answer;
                             
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("csveq-01.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("csveq-01.aspx", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TempGetQuestion(string str_sv_mi_templete_question_id_pk, DataTable dtLocale)
        {
            txtQuestion.InnerText = dtLocale.Rows[0]["sv_mi_templete_question"].ToString();
            txtQuestionOrder.Text = dtLocale.Rows[0]["sv_mi_templete_question_display_order"].ToString();
            txtOption1.Text = dtLocale.Rows[0]["sv_mi_templete_question_answer_optionsA"].ToString();
            txtOption2.Text = dtLocale.Rows[0]["sv_mi_templete_question_answer_optionsB"].ToString();
            txtOption3.Text = dtLocale.Rows[0]["sv_mi_templete_question_answer_optionsC"].ToString();
            txtOption4.Text = dtLocale.Rows[0]["sv_mi_templete_question_answer_optionsD"].ToString();
            ddlQuestionType.SelectedValue = dtLocale.Rows[0]["sv_mi_templete_question_type"].ToString();
            txtAnswer.Text = dtLocale.Rows[0]["sv_mi_templete_question_answer"].ToString();
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "csvanin")
                {
                    UpdateQuestion();                    
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "csvein")
                {
                    SiteViewInspectionTemplate updateQuestion = new SiteViewInspectionTemplate();
                    updateQuestion.sv_mi_templete_question_id_pk = Request.QueryString["editQuestionId"].ToString();
                    updateQuestion.sv_mi_templete_id_fk = Request.QueryString["edituserId"].ToString();   
                    updateQuestion.sv_mi_templete_question = txtQuestion.InnerText;
                    updateQuestion.sv_mi_templete_question_type = Convert.ToInt16(ddlQuestionType.SelectedValue);
                    updateQuestion.sv_mi_templete_question_answer_optionsA = txtOption1.Text;
                    updateQuestion.sv_mi_templete_question_answer_optionsB = txtOption2.Text;
                    updateQuestion.sv_mi_templete_question_answer_optionsC = txtOption3.Text;
                    updateQuestion.sv_mi_templete_question_answer_optionsD = txtOption4.Text;
                    updateQuestion.sv_mi_templete_question_answer = txtAnswer.Text;
                    updateQuestion.sv_mi_templete_question_display_order = Convert.ToInt16(txtQuestionOrder.Text);
                    try
                    {
                        int result = SiteViewInspectionBLL.UpdateSingleQuestion(updateQuestion);                         
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("csveq-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("csveq-01.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// Update Question
        /// </summary>
        private void UpdateQuestion()
        {
            var rows = SessionWrapper.session_Add_Questions.Select("sv_mi_templete_question_id_pk= '" + Request.QueryString["id"] + "'");
            var indexOfRow = SessionWrapper.session_Add_Questions.Rows.IndexOf(rows[0]);
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question"] = txtQuestion.InnerText;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_display_order"] = txtQuestionOrder.Text;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_answer_optionsA"] = txtOption1.Text;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_answer_optionsA"] = txtOption2.Text;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_answer_optionsA"] = txtOption3.Text;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_answer_optionsA"] = txtOption4.Text;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_type"] = ddlQuestionType.SelectedValue;
            SessionWrapper.session_Add_Questions.Rows[indexOfRow]["sv_mi_templete_question_answer"] = txtAnswer.Text;

            SessionWrapper.session_Add_Questions.AcceptChanges();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}