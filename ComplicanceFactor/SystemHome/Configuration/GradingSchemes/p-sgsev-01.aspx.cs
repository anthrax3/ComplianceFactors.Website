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

namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class edit_grading_value : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPassingStatus.DataSource = SystemGradingSchemesBLL.GetPassingStatus(SessionWrapper.CultureName, "saegs-01");
                ddlPassingStatus.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saangsn")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            DataView dvGradingSchemeValues = new DataView(SessionWrapper.GradingSchemeValues);
                            dvGradingSchemeValues.RowFilter = "s_grading_scheme_system_value_id_pk= '" + Request.QueryString["id"] + "'";
                            //Get Temp Question
                            TempGradingScheme(Request.QueryString["id"], dvGradingSchemeValues.ToTable());
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saegs")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        SystemGradingSchemes getSingleGradingSchemes = new SystemGradingSchemes();

                        try
                        {
                            getSingleGradingSchemes = SystemGradingSchemesBLL.GetSingleGradingSchemesValue(Request.QueryString["id"]);
                            txtId.Text = getSingleGradingSchemes.s_grading_scheme_value_id;
                            txtName.Text = getSingleGradingSchemes.s_grading_scheme_value_name;
                            txtDescription.InnerText = getSingleGradingSchemes.s_grading_scheme_value_description;
                            txtMinScore_InPercentage.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_min_score);
                            txtMaxScore_InPercentage.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_max_score);
                            txtGrade.Text = getSingleGradingSchemes.s_grading_scheme_value_grade;
                            txtMinScore_InNumbers.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_min_num);
                            txtMaxScore_InNumbers.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_max_num);
                            txtGpa.Text = getSingleGradingSchemes.s_grading_scheme_value_gpa;
                            txtDescriptor.Text = getSingleGradingSchemes.s_grading_scheme_value_descriptior;
                            txtQualification.Text = getSingleGradingSchemes.s_grading_scheme_value_qualification;
                            ddlPassingStatus.SelectedValue = getSingleGradingSchemes.s_grading_scheme_value_pass_status_id_fk;

                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message);
                                }
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "copy")
                    {
                        SystemGradingSchemes getSingleGradingSchemes = new SystemGradingSchemes();

                        try
                        {
                            getSingleGradingSchemes = SystemGradingSchemesBLL.GetSingleGradingSchemesValue(Request.QueryString["id"]);
                            txtId.Text = getSingleGradingSchemes.s_grading_scheme_value_id+"_copy";
                            txtName.Text = getSingleGradingSchemes.s_grading_scheme_value_name;
                            txtDescription.InnerText = getSingleGradingSchemes.s_grading_scheme_value_description;
                            txtMinScore_InPercentage.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_min_score);
                            txtMaxScore_InPercentage.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_max_score);
                            txtGrade.Text = getSingleGradingSchemes.s_grading_scheme_value_grade;
                            txtMinScore_InNumbers.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_min_num);
                            txtMaxScore_InNumbers.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_max_num);
                            txtGpa.Text = getSingleGradingSchemes.s_grading_scheme_value_gpa;
                            txtDescriptor.Text = getSingleGradingSchemes.s_grading_scheme_value_descriptior;
                            txtQualification.Text = getSingleGradingSchemes.s_grading_scheme_value_qualification;
                            ddlPassingStatus.SelectedValue = getSingleGradingSchemes.s_grading_scheme_value_pass_status_id_fk;

                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
         }

        private void TempGradingScheme(string s_grading_scheme_system_value_id_pk, DataTable dtGradingSchemeValues)
        {
            txtId.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_id"].ToString();
            txtName.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_name"].ToString();
            txtDescription.InnerText = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_description"].ToString();
            txtMinScore_InPercentage.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_min_score"].ToString();
            txtMaxScore_InPercentage.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_max_score"].ToString();
            txtGrade.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_grade"].ToString();
            txtMinScore_InNumbers.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_min_num"].ToString();
            txtMaxScore_InNumbers.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_max_num"].ToString();
            txtGpa.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_gpa"].ToString();
            txtDescriptor.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_descriptior"].ToString();
            txtQualification.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_qualification"].ToString();
            ddlPassingStatus.SelectedValue = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_pass_status_id_fk"].ToString();
        }

        protected void btnSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saangsn")
            {
                UpdateGradingSchemeValues();
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saegs")
            {
                SystemGradingSchemes updateGradingSchemeValues = new SystemGradingSchemes();
                updateGradingSchemeValues.s_grading_scheme_system_value_id_pk = Request.QueryString["id"].ToString();
                updateGradingSchemeValues.s_grading_scheme_value_id = txtId.Text;
                updateGradingSchemeValues.s_grading_scheme_system_id_fk = Request.QueryString["GradingSchemesId"].ToString();  
                updateGradingSchemeValues.s_grading_scheme_value_name = txtName.Text;
                updateGradingSchemeValues.s_grading_scheme_value_description = txtDescription.InnerText;
                updateGradingSchemeValues.s_grading_scheme_value_min_score =  Convert.ToInt16(txtMinScore_InPercentage.Text);
                updateGradingSchemeValues.s_grading_scheme_value_max_score = Convert.ToInt16(txtMaxScore_InPercentage.Text);
                updateGradingSchemeValues.s_grading_scheme_value_grade = txtGrade.Text;
                updateGradingSchemeValues.s_grading_scheme_value_min_num = Convert.ToInt16(txtMinScore_InNumbers.Text);
                updateGradingSchemeValues.s_grading_scheme_value_max_num = Convert.ToInt16(txtMaxScore_InNumbers.Text);
                updateGradingSchemeValues.s_grading_scheme_value_gpa =txtGpa.Text;
                updateGradingSchemeValues.s_grading_scheme_value_descriptior = txtDescriptor.Text;
                updateGradingSchemeValues.s_grading_scheme_value_qualification = txtQualification.Text;
                updateGradingSchemeValues.s_grading_scheme_value_pass_status_id_fk = ddlPassingStatus.SelectedValue;
                try
                {
                    int result = SystemGradingSchemesBLL.UpdateGradingSchemesValues(updateGradingSchemeValues);
                    
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-sgsev-01.aspx", ex.Message);
                        }
                    }
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        private void UpdateGradingSchemeValues()
        {
            var rows = SessionWrapper.GradingSchemeValues.Select("s_grading_scheme_system_value_id_pk= '" + Request.QueryString["id"] + "'");
            var indexOfRow = SessionWrapper.GradingSchemeValues.Rows.IndexOf(rows[0]);
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_id"] = txtId.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_name"] = txtName.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_description"] = txtDescription.InnerText;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_min_score"] = txtMinScore_InPercentage.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_max_score"] = txtMaxScore_InPercentage.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_grade"] = txtGrade.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_min_num"] = txtMinScore_InNumbers.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_max_num"] = txtMaxScore_InNumbers.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_gpa"] = txtGpa.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_descriptior"] = txtDescriptor.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_qualification"] = txtQualification.Text;
            SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_pass_status_id_fk"] = ddlPassingStatus.SelectedValue;
            SessionWrapper.GradingSchemeValues.AcceptChanges();
        }
        
    }
}