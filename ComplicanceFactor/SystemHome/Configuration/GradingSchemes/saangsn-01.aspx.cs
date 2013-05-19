using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class saangsn_01 : System.Web.UI.Page
    {
        private static string copyGradingScheme;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///<summary>
                ///Hide validation on postback (if user select GradingSchemeValues)
                ///</summary>
                vs_saangsn.Style.Add("display", "none");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/GradingSchemes/samgsmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_grading_schemes_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_grading_scheme_text");
                // Add grading schemes Table structure
                SessionWrapper.GradingSchemeValues = TempDataTables.GradingSchemeValues();
                //Bind Status
                ddlStatus.DataSource = SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName, "saangsn-01");
                ddlStatus.DataBind();
                //Bind Type
                ddlType.DataSource = SystemGradingSchemesBLL.GetGradingSchemeType(SessionWrapper.CultureName, "saangsn-01");
                ddlType.DataBind();
                ClearCourseRelatedSession();

                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyGradingScheme = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PopulateGradingScheme(copyGradingScheme);
                    hdUpdateValue.Value = copyGradingScheme;
                }
            }
            //Bind Grading Scheme Value
            if (hdUpdateValue.Value == "0" || string.IsNullOrEmpty(hdUpdateValue.Value))
            {

                DataView dvGradingSchemes = SessionWrapper.GradingSchemeValues.DefaultView;
                dvGradingSchemes.Sort = "s_grading_scheme_value_max_score DESC";
                gvGradingSchemeValues.DataSource = dvGradingSchemes.ToTable();
                gvGradingSchemeValues.DataBind();
                if (gvGradingSchemeValues.Rows.Count == 0)
                {
                    btnUpdateValue.Visible = false;
                }
                else
                {
                    btnUpdateValue.Visible = true;
                }

            }
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            // check atleast one pass one fail in grading scheme values
            DataRow[] rowpass = SessionWrapper.GradingSchemeValues.Select("s_grading_scheme_value_pass_status_id_fk = 'app_ddl_pass_text'");
            DataRow[] rowfail = SessionWrapper.GradingSchemeValues.Select("s_grading_scheme_value_pass_status_id_fk = 'app_ddl_fail_text'");


            if (rowpass.Length > 0 && rowfail.Length > 0)
            {
                SaveGradingScheme();
            }
            else
            {
                
                divError.Style.Add("display", "Block");
                divError.InnerText = LocalResources.GetText("app_select_atleast_one_pass_fail_valid_error");
            }
        }

        private void SaveGradingScheme()
        {
            
            int error;
            SystemGradingSchemes createGradingScheme = new SystemGradingSchemes();
            createGradingScheme.s_grading_scheme_system_id_pk = Guid.NewGuid().ToString();
            createGradingScheme.s_grading_scheme_id = txtGradingSchemeId_EnglishUs.Text;
            createGradingScheme.s_grading_scheme_status_id_fk = ddlStatus.SelectedValue;
            createGradingScheme.s_grading_scheme_type_id_fk = ddlType.SelectedValue;
            createGradingScheme.s_grading_scheme_name_us_english = txtGradingSchmeName_EnglishUs.Text;
            createGradingScheme.s_grading_scheme_desc_us_english = txtGradingDescription_EnglishUs.Text;
            createGradingScheme.s_grading_scheme_name_uk_english = txtGradingSchemeName_EnglishUk.Text;
            createGradingScheme.s_grading_scheme_desc_uk_english = txtDescription_EnglishUk.Text;
            createGradingScheme.s_grading_scheme_name_ca_france = txtGradingSchemeName_FrenchCa.Text;
            createGradingScheme.s_grading_scheme_desc_ca_france = txtDescription_FrenchCa.Text;
            createGradingScheme.s_grading_scheme_name_fr_french = txtGradingSchemeName_FrenchFr.Text;
            createGradingScheme.s_grading_scheme_desc_fr_french = txtDescription_FrenchFr.Text;
            createGradingScheme.s_grading_scheme_name_mx_spanish = txtGradingSchemeName_SpanishMx.Text;
            createGradingScheme.s_grading_scheme_desc_mx_spanish = txtDescription_SpanishMx.Text;
            createGradingScheme.s_grading_scheme_name_sp_spanish = txtGradingSchemeName_SpanishSp.Text;
            createGradingScheme.s_grading_scheme_desc_sp_spanish = txtDescription_SpanishSp.Text;
            createGradingScheme.s_grading_scheme_name_portuguse = txtGradingSchemeName_Portuguese.Text;
            createGradingScheme.s_grading_scheme_desc_portuguse = txtDescription_Portuguese.Text;
            createGradingScheme.s_grading_scheme_name_chinese = txtGradingSchemeName_Chinese.Text;
            createGradingScheme.s_grading_scheme_desc_chinese = txtDescription_Chinese.Text;
            createGradingScheme.s_grading_scheme_name_german = txtGradingSchemeName_German.Text;
            createGradingScheme.s_grading_scheme_desc_german = txtDescription_German.Text;
            createGradingScheme.s_grading_scheme_name_japanese = txtGradingSchemeName_Japanese.Text;
            createGradingScheme.s_grading_scheme_desc_japanese = txtDescription_Japanese.Text;
            createGradingScheme.s_grading_scheme_name_russian = txtGradingSchemeName_Russian.Text;
            createGradingScheme.s_grading_scheme_desc_russian = txtDescription_Russian.Text;
            createGradingScheme.s_grading_scheme_name_danish = txtGradingSchemeName_Danish.Text;
            createGradingScheme.s_grading_scheme_desc_danish = txtDescription_Danish.Text;
            createGradingScheme.s_grading_scheme_name_polish = txtGradingSchemeName_Polish.Text;
            createGradingScheme.s_grading_scheme_desc_polish = txtDescription_Polish.Text;
            createGradingScheme.s_grading_scheme_name_swedish = txtGradingSchemeName_Swedish.Text;
            createGradingScheme.s_grading_scheme_desc_swedish = txtDescription_Swedish.Text;
            createGradingScheme.s_grading_scheme_name_finnish = txtGradingSchemeName_Finnish.Text;
            createGradingScheme.s_grading_scheme_desc_finnish = txtDescription_Finnish.Text;
            createGradingScheme.s_grading_scheme_name_korean = txtGradingSchemeName_Korean.Text;
            createGradingScheme.s_grading_scheme_desc_korean = txtDescription_Korean.Text;
            createGradingScheme.s_grading_scheme_name_italian = txtGradingSchemeName_Italian.Text;
            createGradingScheme.s_grading_scheme_desc_italian = txtDescription_Italian.Text;
            createGradingScheme.s_grading_scheme_name_dutch = txtGradingSchemeName_Dutch.Text;
            createGradingScheme.s_grading_scheme_desc_dutch = txtDescription_Dutch.Text;
            createGradingScheme.s_grading_scheme_name_indonesian = txtGradingSchemeName_Indonesian.Text;
            createGradingScheme.s_grading_scheme_desc_indonesian = txtDescription_Indonesian.Text;
            createGradingScheme.s_grading_scheme_name_greek = txtGradingSchemeName_Greek.Text;
            createGradingScheme.s_grading_scheme_desc_greek = txtDescription_Greek.Text;
            createGradingScheme.s_grading_scheme_name_hungarian = txtGradingSchemeName_Hungarian.Text;
            createGradingScheme.s_grading_scheme_desc_hungarian = txtDescription_Hungarian.Text;
            createGradingScheme.s_grading_scheme_name_norwegian = txtGradingSchemeName_Norwegian.Text;
            createGradingScheme.s_grading_scheme_desc_norwegian = txtDescription_Norwegian.Text;
            createGradingScheme.s_grading_scheme_name_turkish = txtGradingSchemeName_Turkish.Text;
            createGradingScheme.s_grading_scheme_desc_turkish = txtDescription_Turkish.Text;
            createGradingScheme.s_grading_scheme_name_arabic = txtGradingSchemeName_Arabic.Text;
            createGradingScheme.s_grading_scheme_desc_arabic = txtDescription_Arabic.Text;
            createGradingScheme.s_grading_scheme_name_custom_01 = txtGradingSchemeName_Custom01.Text;
            createGradingScheme.s_grading_scheme_desc_custom_01 = txtDescription_Custom01.Text;
            createGradingScheme.s_grading_scheme_name_custom_02 = txtGradingSchemeName_Custom02.Text;
            createGradingScheme.s_grading_scheme_desc_custom_02 = txtDescription_Custom02.Text;
            createGradingScheme.s_grading_scheme_name_custom_03 = txtGradingSchemeName_Custom03.Text;
            createGradingScheme.s_grading_scheme_desc_custom_03 = txtDescription_Custom03.Text;
            createGradingScheme.s_grading_scheme_name_custom_04 = txtGradingSchemeName_Custom04.Text;
            createGradingScheme.s_grading_scheme_desc_custom_04 = txtDescription_Custom04.Text;
            createGradingScheme.s_grading_scheme_name_custom_05 = txtGradingSchemeName_Custom05.Text;
            createGradingScheme.s_grading_scheme_desc_custom_05 = txtDescription_Custom05.Text;
            createGradingScheme.s_grading_scheme_name_custom_06 = txtGradingSchemeName_Custom06.Text;
            createGradingScheme.s_grading_scheme_desc_custom_06 = txtDescription_Custom06.Text;
            createGradingScheme.s_grading_scheme_name_custom_07 = txtGradingSchemeName_Custom07.Text;
            createGradingScheme.s_grading_scheme_desc_custom_07 = txtDescription_Custom07.Text;
            createGradingScheme.s_grading_scheme_name_custom_08 = txtGradingSchemeName_Custom08.Text;
            createGradingScheme.s_grading_scheme_desc_custom_08 = txtDescription_Custom08.Text;
            createGradingScheme.s_grading_scheme_name_custom_09 = txtGradingSchemeName_Custom09.Text;
            createGradingScheme.s_grading_scheme_desc_custom_09 = txtDescription_Custom09.Text;
            createGradingScheme.s_grading_scheme_name_custom_10 = txtGradingSchemeName_Custom10.Text;
            createGradingScheme.s_grading_scheme_desc_custom_10 = txtDescription_Custom10.Text;
            createGradingScheme.s_grading_scheme_name_custom_11 = txtGradingSchemeName_Custom11.Text;
            createGradingScheme.s_grading_scheme_desc_custom_11 = txtDescription_Custom11.Text;
            createGradingScheme.s_grading_scheme_name_custom_12 = txtGradingSchemeName_Custom12.Text;
            createGradingScheme.s_grading_scheme_desc_custom_12 = txtDescription_Custom12.Text;
            createGradingScheme.s_grading_scheme_name_custom_13 = txtGradingSchemeName_Custom13.Text;
            createGradingScheme.s_grading_scheme_desc_custom_13 = txtDescription_Custom13.Text;
            ConvertDataTables dtConvertDataToXml = new ConvertDataTables();
            createGradingScheme.s_grading_scheme_values = dtConvertDataToXml.ConvertDataTableToXml(SessionWrapper.GradingSchemeValues);
            error = SystemGradingSchemesBLL.CreateGradingSchemes(createGradingScheme);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/GradingSchemes/saegs-01.aspx?id=" + SecurityCenter.EncryptText(createGradingScheme.s_grading_scheme_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }

            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = "GradingScheme Already Exists";


            }
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            SaveGradingScheme();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/GradingSchemes/samgsmp-01.aspx", false);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/GradingSchemes/samgsmp-01.aspx", false);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        private void ClearCourseRelatedSession()
        {
            SessionWrapper.GradingSchemeValues.Clear();
        }

        protected void gvGradingSchemes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string s_grading_scheme_system_value_id_pk = gvGradingSchemeValues.DataKeys[e.Row.RowIndex][0].ToString();
                TextBox txtMinscore = (TextBox)e.Row.FindControl("txtMinscore");
                TextBox txtMaxscore = (TextBox)e.Row.FindControl("txtMaxscore");
                TextBox txtGpa = (TextBox)e.Row.FindControl("txtGpa");
                DropDownList ddlPassingStatus = (DropDownList)e.Row.FindControl("ddlPassingStatus");
                txtMinscore.Text = DataBinder.Eval(e.Row.DataItem, "s_grading_scheme_value_min_score").ToString();
                txtMaxscore.Text = DataBinder.Eval(e.Row.DataItem, "s_grading_scheme_value_max_score").ToString();
                txtGpa.Text = DataBinder.Eval(e.Row.DataItem, "s_grading_scheme_value_gpa").ToString();
                ddlPassingStatus.DataSource = SystemGradingSchemesBLL.GetPassingStatus(SessionWrapper.CultureName, "saangsn-01");
                ddlPassingStatus.DataBind();
                ddlPassingStatus.SelectedValue = DataBinder.Eval(e.Row.DataItem, "s_grading_scheme_value_pass_status_id_fk").ToString();

            }
        }

        [System.Web.Services.WebMethod]
        public static void DeleteGradingSchemes(string args)
        {
            try
            {

                //Delete previous selected gradingSchemes
                var rows = SessionWrapper.GradingSchemeValues.Select("s_grading_scheme_system_value_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.GradingSchemeValues.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saangsn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saangsn-01", ex.Message);
                    }
                }
            }
        }

        protected void btnUpdateValue_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gvGradingSchemeValues.Rows)
            {


                TextBox txtMinscore = (TextBox)row.FindControl("txtMinscore");
                TextBox txtMaxscore = (TextBox)row.FindControl("txtMaxscore");
                TextBox txtGpa = (TextBox)row.FindControl("txtGpa");
                DropDownList ddlPassingStatus = (DropDownList)row.FindControl("ddlPassingStatus");
                string s_grading_scheme_system_value_id_pk = gvGradingSchemeValues.DataKeys[row.RowIndex].Value.ToString();
                var rows = SessionWrapper.GradingSchemeValues.Select("s_grading_scheme_system_value_id_pk= '" + s_grading_scheme_system_value_id_pk + "'");
                var indexOfRow = SessionWrapper.GradingSchemeValues.Rows.IndexOf(rows[0]);
                SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_min_score"] = txtMinscore.Text;
                SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_max_score"] = txtMaxscore.Text;
                SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_gpa"] = txtGpa.Text;
                SessionWrapper.GradingSchemeValues.Rows[indexOfRow]["s_grading_scheme_value_pass_status_id_fk"] = ddlPassingStatus.SelectedValue;
                SessionWrapper.GradingSchemeValues.AcceptChanges();


            }

        }


        private void PopulateGradingScheme(string editGradingSchemeId)
        {
            SystemGradingSchemes gradingScheme = new SystemGradingSchemes();
            gradingScheme = SystemGradingSchemesBLL.GetGradingSchemes(editGradingSchemeId);
            txtGradingSchemeId_EnglishUs.Text = gradingScheme.s_grading_scheme_id + "_copy";
            txtGradingSchmeName_EnglishUs.Text = gradingScheme.s_grading_scheme_name_us_english;
            txtGradingDescription_EnglishUs.Text = gradingScheme.s_grading_scheme_desc_us_english;
            ddlStatus.SelectedValue = gradingScheme.s_grading_scheme_status_id_fk;
            ddlType.SelectedValue = gradingScheme.s_grading_scheme_type_id_fk;
            txtGradingSchemeName_EnglishUk.Text = gradingScheme.s_grading_scheme_name_uk_english;
            txtDescription_EnglishUk.Text = gradingScheme.s_grading_scheme_desc_uk_english;
            txtGradingSchemeName_FrenchCa.Text = gradingScheme.s_grading_scheme_name_ca_france;
            txtDescription_FrenchCa.Text = gradingScheme.s_grading_scheme_desc_ca_france;
            txtGradingSchemeName_FrenchFr.Text = gradingScheme.s_grading_scheme_name_fr_french;
            txtDescription_FrenchFr.Text = gradingScheme.s_grading_scheme_desc_fr_french;
            txtGradingSchemeName_SpanishMx.Text = gradingScheme.s_grading_scheme_name_mx_spanish;
            txtDescription_SpanishMx.Text = gradingScheme.s_grading_scheme_desc_mx_spanish;
            txtGradingSchemeName_SpanishSp.Text = gradingScheme.s_grading_scheme_name_sp_spanish;
            txtDescription_SpanishSp.Text = gradingScheme.s_grading_scheme_desc_sp_spanish;
            txtGradingSchemeName_Portuguese.Text = gradingScheme.s_grading_scheme_name_portuguse;
            txtDescription_Portuguese.Text = gradingScheme.s_grading_scheme_desc_portuguse;
            txtGradingSchemeName_Chinese.Text = gradingScheme.s_grading_scheme_name_chinese;
            txtDescription_Chinese.Text = gradingScheme.s_grading_scheme_desc_chinese;
            txtGradingSchemeName_German.Text = gradingScheme.s_grading_scheme_name_german;
            txtDescription_German.Text = gradingScheme.s_grading_scheme_desc_german;
            txtGradingSchemeName_Japanese.Text = gradingScheme.s_grading_scheme_name_japanese;
            txtDescription_Japanese.Text = gradingScheme.s_grading_scheme_desc_japanese;
            txtGradingSchemeName_Russian.Text = gradingScheme.s_grading_scheme_name_russian;
            txtDescription_Russian.Text = gradingScheme.s_grading_scheme_desc_russian;
            txtGradingSchemeName_Danish.Text = gradingScheme.s_grading_scheme_name_danish;
            txtDescription_Danish.Text = gradingScheme.s_grading_scheme_desc_danish;
            txtGradingSchemeName_Polish.Text = gradingScheme.s_grading_scheme_name_polish;
            txtDescription_Polish.Text = gradingScheme.s_grading_scheme_desc_polish;
            txtGradingSchemeName_Swedish.Text = gradingScheme.s_grading_scheme_name_swedish;
            txtDescription_Swedish.Text = gradingScheme.s_grading_scheme_desc_swedish;
            txtGradingSchemeName_Finnish.Text = gradingScheme.s_grading_scheme_name_finnish;
            txtDescription_Finnish.Text = gradingScheme.s_grading_scheme_desc_finnish;
            txtGradingSchemeName_Korean.Text = gradingScheme.s_grading_scheme_name_korean;
            txtDescription_Korean.Text = gradingScheme.s_grading_scheme_desc_korean;
            txtGradingSchemeName_Italian.Text = gradingScheme.s_grading_scheme_name_italian;
            txtDescription_Italian.Text = gradingScheme.s_grading_scheme_desc_italian;
            txtGradingSchemeName_Dutch.Text = gradingScheme.s_grading_scheme_name_dutch;
            txtDescription_Dutch.Text = gradingScheme.s_grading_scheme_desc_dutch;
            txtGradingSchemeName_Indonesian.Text = gradingScheme.s_grading_scheme_name_indonesian;
            txtDescription_Indonesian.Text = gradingScheme.s_grading_scheme_desc_indonesian;
            txtGradingSchemeName_Greek.Text = gradingScheme.s_grading_scheme_name_greek;
            txtDescription_Greek.Text = gradingScheme.s_grading_scheme_desc_greek;
            txtGradingSchemeName_Hungarian.Text = gradingScheme.s_grading_scheme_name_hungarian;
            txtDescription_Hungarian.Text = gradingScheme.s_grading_scheme_desc_hungarian;
            txtGradingSchemeName_Norwegian.Text = gradingScheme.s_grading_scheme_name_norwegian;
            txtDescription_Norwegian.Text = gradingScheme.s_grading_scheme_desc_norwegian;
            txtGradingSchemeName_Turkish.Text = gradingScheme.s_grading_scheme_name_turkish;
            txtDescription_Turkish.Text = gradingScheme.s_grading_scheme_desc_turkish;
            txtGradingSchemeName_Arabic.Text = gradingScheme.s_grading_scheme_name_arabic;
            txtDescription_Arabic.Text = gradingScheme.s_grading_scheme_desc_arabic;
            txtGradingSchemeName_Custom01.Text = gradingScheme.s_grading_scheme_name_custom_01;
            txtDescription_Custom01.Text = gradingScheme.s_grading_scheme_desc_custom_01;
            txtGradingSchemeName_Custom02.Text = gradingScheme.s_grading_scheme_name_custom_02;
            txtDescription_Custom02.Text = gradingScheme.s_grading_scheme_desc_custom_02;
            txtGradingSchemeName_Custom03.Text = gradingScheme.s_grading_scheme_name_custom_03;
            txtDescription_Custom03.Text = gradingScheme.s_grading_scheme_desc_custom_03;
            txtGradingSchemeName_Custom04.Text = gradingScheme.s_grading_scheme_name_custom_04;
            txtDescription_Custom04.Text = gradingScheme.s_grading_scheme_desc_custom_04;
            txtGradingSchemeName_Custom05.Text = gradingScheme.s_grading_scheme_name_custom_05;
            txtDescription_Custom05.Text = gradingScheme.s_grading_scheme_desc_custom_05;
            txtGradingSchemeName_Custom06.Text = gradingScheme.s_grading_scheme_name_custom_06;
            txtDescription_Custom06.Text = gradingScheme.s_grading_scheme_desc_custom_06;
            txtGradingSchemeName_Custom07.Text = gradingScheme.s_grading_scheme_name_custom_07;
            txtDescription_Custom07.Text = gradingScheme.s_grading_scheme_desc_custom_07;
            txtGradingSchemeName_Custom08.Text = gradingScheme.s_grading_scheme_name_custom_08;
            txtDescription_Custom08.Text = gradingScheme.s_grading_scheme_desc_custom_08;
            txtGradingSchemeName_Custom09.Text = gradingScheme.s_grading_scheme_name_custom_09;
            txtDescription_Custom09.Text = gradingScheme.s_grading_scheme_desc_custom_09;
            txtGradingSchemeName_Custom10.Text = gradingScheme.s_grading_scheme_name_custom_10;
            txtDescription_Custom10.Text = gradingScheme.s_grading_scheme_desc_custom_10;
            txtGradingSchemeName_Custom11.Text = gradingScheme.s_grading_scheme_name_custom_11;
            txtDescription_Custom11.Text = gradingScheme.s_grading_scheme_desc_custom_11;
            txtGradingSchemeName_Custom12.Text = gradingScheme.s_grading_scheme_name_custom_12;
            txtDescription_Custom12.Text = gradingScheme.s_grading_scheme_desc_custom_12;
            txtGradingSchemeName_Custom13.Text = gradingScheme.s_grading_scheme_name_custom_13;
            txtDescription_Custom13.Text = gradingScheme.s_grading_scheme_desc_custom_13;

            //bind 
            gvGradingSchemeValues.DataSource = SystemGradingSchemesBLL.GetGradingSchemesValue(gradingScheme.s_grading_scheme_system_id_pk);
            gvGradingSchemeValues.DataBind();

            SessionWrapper.GradingSchemeValues = SystemGradingSchemesBLL.GetGradingSchemesValue(gradingScheme.s_grading_scheme_system_id_pk);
        }
    }
}
