using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class p_sgscv_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Add column in GradingSchemeValues datatable
            
            if (!IsPostBack)
            {
                
                ddlPassingStatus.DataSource = SystemGradingSchemesBLL.GetPassingStatus(SessionWrapper.CultureName, "saangsn-01");
                ddlPassingStatus.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                       PopulateGradingSchemes(Request.QueryString["id"]);
                }
            }
        }

        protected void btnSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saegs")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    string editGradingSchemesId = Request.QueryString["GradingSchemesId"].ToString();

                    SystemGradingSchemes getSingleGradingSchemes = new SystemGradingSchemes();
                    getSingleGradingSchemes.s_grading_scheme_system_value_id_pk = Guid.NewGuid().ToString();
                    getSingleGradingSchemes.s_grading_scheme_value_id = txtId.Text;
                    getSingleGradingSchemes.s_grading_scheme_system_id_fk = editGradingSchemesId;
                    getSingleGradingSchemes.s_grading_scheme_value_name = txtName.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_description = txtDescription.InnerText;
                    getSingleGradingSchemes.s_grading_scheme_value_min_score = txtMinScore_InPercentage.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_max_score = Convert.ToInt32(txtMaxScore_InPercentage.Text);
                    getSingleGradingSchemes.s_grading_scheme_value_grade = txtGrade.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_min_num = txtMinScore_InNumbers.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_max_num = txtMaxScore_InNumbers.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_gpa = txtGpa.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_descriptior = txtDescriptor.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_qualification = txtQualification.Text;
                    getSingleGradingSchemes.s_grading_scheme_value_pass_status_id_fk = ddlPassingStatus.SelectedValue;


                    try
                    {
                        int result = SystemGradingSchemesBLL.InsertGradingSchemeValues(getSingleGradingSchemes);
                       
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("p-sgscv-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("p-sgscv-01.aspx", ex.Message);
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "copy")
                {
                    
                    SystemGradingSchemes createSingleGradingSchemes = new SystemGradingSchemes();
                    createSingleGradingSchemes.s_grading_scheme_system_value_id_pk = Guid.NewGuid().ToString();
                    createSingleGradingSchemes.s_grading_scheme_value_id = txtId.Text;
                    createSingleGradingSchemes.s_grading_scheme_system_id_fk = Request.QueryString["GradingSchemesId"].ToString();
                    createSingleGradingSchemes.s_grading_scheme_value_name = txtName.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_description = txtDescription.InnerText;
                    createSingleGradingSchemes.s_grading_scheme_value_min_score = txtMinScore_InPercentage.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_max_score = Convert.ToInt32(txtMaxScore_InPercentage.Text);
                    createSingleGradingSchemes.s_grading_scheme_value_grade = txtGrade.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_min_num = txtMinScore_InNumbers.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_max_num = txtMaxScore_InNumbers.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_gpa = txtGpa.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_descriptior = txtDescriptor.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_qualification = txtQualification.Text;
                    createSingleGradingSchemes.s_grading_scheme_value_pass_status_id_fk = ddlPassingStatus.SelectedValue;
                    try
                    {
                        int result = SystemGradingSchemesBLL.InsertGradingSchemeValues(createSingleGradingSchemes);
                        
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("p-sgscv-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("p-sgscv-01.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                AddDataToGradingScheme(txtId.Text, txtName.Text, txtDescription.InnerText, txtMinScore_InPercentage.Text, txtMaxScore_InPercentage.Text, txtGrade.Text, txtMinScore_InNumbers.Text, txtMaxScore_InNumbers.Text, txtGpa.Text, txtDescriptor.Text, txtQualification.Text, ddlPassingStatus.SelectedValue, SessionWrapper.GradingSchemeValues);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        private  DataTable AddDataToGradingScheme(string s_grading_scheme_value_id,string s_grading_scheme_value_name, string s_grading_scheme_value_description, string s_grading_scheme_value_min_score, string s_grading_scheme_value_max_score, string s_grading_scheme_value_grade, string s_grading_scheme_value_min_num, string s_grading_scheme_value_max_num, string s_grading_scheme_value_gpa, string s_grading_scheme_value_descriptior, string s_grading_scheme_value_qualification, string s_grading_scheme_value_pass_status_id_fk, DataTable dtGradingscheme)
        {
            // Add GradingScheme function
            
            DataRow row;
            row = dtGradingscheme.NewRow();
            row["s_grading_scheme_system_value_id_pk"] = Guid.NewGuid().ToString();
            row["s_grading_scheme_value_id"] = s_grading_scheme_value_id;
            row["s_grading_scheme_system_id_fk"] = DBNull.Value;
            row["s_grading_scheme_value_name"] = s_grading_scheme_value_name;
            row["s_grading_scheme_value_description"] = s_grading_scheme_value_description;
            row["s_grading_scheme_value_min_score"] = s_grading_scheme_value_min_score;
            row["s_grading_scheme_value_max_score"] = Convert.ToInt32(s_grading_scheme_value_max_score);
            row["s_grading_scheme_value_grade"] = s_grading_scheme_value_grade;
            row["s_grading_scheme_value_min_num"] = s_grading_scheme_value_min_num;
            row["s_grading_scheme_value_max_num"] = s_grading_scheme_value_max_num;
            row["s_grading_scheme_value_gpa"] = s_grading_scheme_value_gpa;
            row["s_grading_scheme_value_descriptior"] = s_grading_scheme_value_descriptior;
            row["s_grading_scheme_value_qualification"] = s_grading_scheme_value_qualification;
            row["s_grading_scheme_value_pass_status_id_fk"] = s_grading_scheme_value_pass_status_id_fk;

            dtGradingscheme.Rows.Add(row);
            dtGradingscheme = RemoveDuplicateRows(dtGradingscheme, "s_grading_scheme_system_value_id_pk");
            return dtGradingscheme;
           
        }
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
        private void PopulateGradingSchemes(string s_grading_scheme_system_value_id_pk)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saangsn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "copy")
                {
                    DataView dvGradingSchemeValues = new DataView(SessionWrapper.GradingSchemeValues);
                    dvGradingSchemeValues.RowFilter = "s_grading_scheme_system_value_id_pk= '" + Request.QueryString["id"] + "'";
                    TempGradingSchemeValues(Request.QueryString["id"], dvGradingSchemeValues.ToTable());
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saegs")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "copy")
                {
                    SystemGradingSchemes getSingleGradingSchemes = new SystemGradingSchemes();
                    getSingleGradingSchemes.s_grading_scheme_system_value_id_pk = Guid.NewGuid().ToString();
                    getSingleGradingSchemes = SystemGradingSchemesBLL.GetSingleGradingSchemesValue(Request.QueryString["id"]);
                    txtId.Text = getSingleGradingSchemes.s_grading_scheme_value_id + "_copy";
                    txtName.Text = getSingleGradingSchemes.s_grading_scheme_value_name;
                    txtDescription.InnerText = getSingleGradingSchemes.s_grading_scheme_value_description;
                    txtMinScore_InPercentage.Text = getSingleGradingSchemes.s_grading_scheme_value_min_score;
                    txtMaxScore_InPercentage.Text = Convert.ToString(getSingleGradingSchemes.s_grading_scheme_value_max_score);
                    txtGrade.Text = getSingleGradingSchemes.s_grading_scheme_value_grade;
                    txtMinScore_InNumbers.Text = getSingleGradingSchemes.s_grading_scheme_value_min_num;
                    txtMaxScore_InNumbers.Text = getSingleGradingSchemes.s_grading_scheme_value_max_num;
                    txtGpa.Text = getSingleGradingSchemes.s_grading_scheme_value_gpa;
                    txtDescriptor.Text = getSingleGradingSchemes.s_grading_scheme_value_descriptior;
                    txtQualification.Text = getSingleGradingSchemes.s_grading_scheme_value_qualification;
                    ddlPassingStatus.SelectedValue = getSingleGradingSchemes.s_grading_scheme_value_pass_status_id_fk;
                }
            }
        }
        private void TempGradingSchemeValues(string s_grading_scheme_system_value_id_pk, DataTable dtGradingSchemeValues)
        {
            txtId.Text = dtGradingSchemeValues.Rows[0]["s_grading_scheme_value_id"].ToString()+"_copy";
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
    }
}