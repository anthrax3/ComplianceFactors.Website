using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;
using System.Data;
namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class saegs_01 : System.Web.UI.Page
    {
        private static string editGradingSchemeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //<summary>
                ///Hide validation on postback (if user select GradingSchemeValues)
                ///</summary>
                vs_saegs.Style.Add("display", "none");

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/GradingSchemes/samgsmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_grading_schemes_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_grading_scheme_text");
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    //TO-DO SHOW THE MESSAGE WHETHER 'SUCCESSFULLY INSERTED OR UPDATED IN A MESSAGE DIV'
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('grading scheme successfully inserted');", true);
                }               
                //Checks whether querystring contains the uniqueidentifier of the gradingscheme
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editGradingSchemeId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdGradingSchemeId.Value = editGradingSchemeId;
                }
                //Bind status
                ddlStatus.DataSource = SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName, "saegs-01");
                ddlStatus.DataBind();
                
                //Bind grading scheme type
                ddlType.DataSource = SystemGradingSchemesBLL.GetGradingSchemeType(SessionWrapper.CultureName, "saegs-01");
                ddlType.DataBind();
                PopulateGradingScheme(editGradingSchemeId);
            }

            
            //Bind Grading Schemes Values
            if (!string.IsNullOrEmpty(editGradingSchemeId) && (hdUpdateValue.Value == "0" || string.IsNullOrEmpty(hdUpdateValue.Value)))
            {

                gvGradingSchemes.DataSource = SystemGradingSchemesBLL.GetGradingSchemesValue(editGradingSchemeId);
                gvGradingSchemes.DataBind();

                if (gvGradingSchemes.Rows.Count == 0)
                {
                    btnUpdateValue.Visible = false;
                }
                else
                {
                    btnUpdateValue.Visible = true;
                }
                
            }
        }
        private void PopulateGradingScheme(string gradingSchemeId)
        {
            SystemGradingSchemes gradingScheme = new SystemGradingSchemes();
            gradingScheme = SystemGradingSchemesBLL.GetGradingSchemes(gradingSchemeId);
            txtGradingSchemeId.Text=gradingScheme.s_grading_scheme_id;
            txtGradingSchemeName_EnglishUs.Text=gradingScheme.s_grading_scheme_name_us_english;
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

            gvGradingSchemes.DataSource = SystemGradingSchemesBLL.GetGradingSchemesValue(editGradingSchemeId);
            gvGradingSchemes.DataBind();
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            DataTable dtGradingSchemesValues = new DataTable();
            dtGradingSchemesValues = SystemGradingSchemesBLL.GetGradingSchemesValue(editGradingSchemeId);
            DataRow[] rowpass = dtGradingSchemesValues.Select("s_grading_scheme_value_pass_status_id_fk = 'app_ddl_pass_text'");
            DataRow[] rowfail = dtGradingSchemesValues.Select("s_grading_scheme_value_pass_status_id_fk = 'app_ddl_fail_text'");


            if (rowpass.Length > 0 && rowfail.Length > 0)
            {
                UpdateGradingScheme();
            }
            else
            {
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "Block");
                divError.InnerText = LocalResources.GetText("app_select_atleast_one_pass_fail_valid_error");
            }
            
        }
        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            UpdateGradingScheme();
        }
        private void UpdateGradingScheme()
        {
            int error;
            SystemGradingSchemes updateGradingScheme = new SystemGradingSchemes();
            updateGradingScheme.s_grading_scheme_system_id_pk = editGradingSchemeId;
            updateGradingScheme.s_grading_scheme_id = txtGradingSchemeId.Text;
            updateGradingScheme.s_grading_scheme_status_id_fk = ddlStatus.SelectedValue;
            updateGradingScheme.s_grading_scheme_type_id_fk = ddlType.SelectedValue;
            updateGradingScheme.s_grading_scheme_name_us_english = txtGradingSchemeName_EnglishUs.Text;
            updateGradingScheme.s_grading_scheme_desc_us_english = txtGradingDescription_EnglishUs.Text;
            updateGradingScheme.s_grading_scheme_name_uk_english = txtGradingSchemeName_EnglishUk.Text;
            updateGradingScheme.s_grading_scheme_desc_uk_english = txtDescription_EnglishUk.Text;
            updateGradingScheme.s_grading_scheme_name_ca_france = txtGradingSchemeName_FrenchCa.Text;
            updateGradingScheme.s_grading_scheme_desc_ca_france = txtDescription_FrenchCa.Text;
            updateGradingScheme.s_grading_scheme_name_fr_french = txtGradingSchemeName_FrenchFr.Text;
            updateGradingScheme.s_grading_scheme_desc_fr_french = txtDescription_FrenchFr.Text;
            updateGradingScheme.s_grading_scheme_name_mx_spanish = txtGradingSchemeName_SpanishMx.Text;
            updateGradingScheme.s_grading_scheme_desc_mx_spanish = txtDescription_SpanishMx.Text;
            updateGradingScheme.s_grading_scheme_name_sp_spanish = txtGradingSchemeName_SpanishSp.Text;
            updateGradingScheme.s_grading_scheme_desc_sp_spanish = txtDescription_SpanishSp.Text;
            updateGradingScheme.s_grading_scheme_name_portuguse = txtGradingSchemeName_Portuguese.Text;
            updateGradingScheme.s_grading_scheme_desc_portuguse = txtDescription_Portuguese.Text;
            updateGradingScheme.s_grading_scheme_name_chinese = txtGradingSchemeName_Chinese.Text;
            updateGradingScheme.s_grading_scheme_desc_chinese = txtDescription_Chinese.Text;
            updateGradingScheme.s_grading_scheme_name_german = txtGradingSchemeName_German.Text;
            updateGradingScheme.s_grading_scheme_desc_german = txtDescription_German.Text;
            updateGradingScheme.s_grading_scheme_name_japanese = txtGradingSchemeName_Japanese.Text;
            updateGradingScheme.s_grading_scheme_desc_japanese = txtDescription_Japanese.Text;
            updateGradingScheme.s_grading_scheme_name_russian = txtGradingSchemeName_Russian.Text;
            updateGradingScheme.s_grading_scheme_desc_russian = txtDescription_Russian.Text;
            updateGradingScheme.s_grading_scheme_name_danish = txtGradingSchemeName_Danish.Text;
            updateGradingScheme.s_grading_scheme_desc_danish = txtDescription_Danish.Text;
            updateGradingScheme.s_grading_scheme_name_polish = txtGradingSchemeName_Polish.Text;
            updateGradingScheme.s_grading_scheme_desc_polish = txtDescription_Polish.Text;
            updateGradingScheme.s_grading_scheme_name_swedish = txtGradingSchemeName_Swedish.Text;
            updateGradingScheme.s_grading_scheme_desc_swedish = txtDescription_Swedish.Text;
            updateGradingScheme.s_grading_scheme_name_finnish = txtGradingSchemeName_Finnish.Text;
            updateGradingScheme.s_grading_scheme_desc_finnish = txtDescription_Finnish.Text;
            updateGradingScheme.s_grading_scheme_name_korean = txtGradingSchemeName_Korean.Text;
            updateGradingScheme.s_grading_scheme_desc_korean = txtDescription_Korean.Text;
            updateGradingScheme.s_grading_scheme_name_italian = txtGradingSchemeName_Italian.Text;
            updateGradingScheme.s_grading_scheme_desc_italian = txtDescription_Italian.Text;
            updateGradingScheme.s_grading_scheme_name_dutch = txtGradingSchemeName_Dutch.Text;
            updateGradingScheme.s_grading_scheme_desc_dutch = txtDescription_Dutch.Text;
            updateGradingScheme.s_grading_scheme_name_indonesian = txtGradingSchemeName_Indonesian.Text;
            updateGradingScheme.s_grading_scheme_desc_indonesian = txtDescription_Indonesian.Text;
            updateGradingScheme.s_grading_scheme_name_greek = txtGradingSchemeName_Greek.Text;
            updateGradingScheme.s_grading_scheme_desc_greek = txtDescription_Greek.Text;
            updateGradingScheme.s_grading_scheme_name_hungarian = txtGradingSchemeName_Hungarian.Text;
            updateGradingScheme.s_grading_scheme_desc_hungarian = txtDescription_Hungarian.Text;
            updateGradingScheme.s_grading_scheme_name_norwegian = txtGradingSchemeName_Norwegian.Text;
            updateGradingScheme.s_grading_scheme_desc_norwegian = txtDescription_Norwegian.Text;
            updateGradingScheme.s_grading_scheme_name_turkish = txtGradingSchemeName_Turkish.Text;
            updateGradingScheme.s_grading_scheme_desc_turkish = txtDescription_Turkish.Text;
            updateGradingScheme.s_grading_scheme_name_arabic = txtGradingSchemeName_Arabic.Text;
            updateGradingScheme.s_grading_scheme_desc_arabic = txtDescription_Arabic.Text;
            updateGradingScheme.s_grading_scheme_name_custom_01 = txtGradingSchemeName_Custom01.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_01 = txtDescription_Custom01.Text;
            updateGradingScheme.s_grading_scheme_name_custom_02 = txtGradingSchemeName_Custom02.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_02 = txtDescription_Custom02.Text;
            updateGradingScheme.s_grading_scheme_name_custom_03 = txtGradingSchemeName_Custom03.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_03 = txtDescription_Custom03.Text;
            updateGradingScheme.s_grading_scheme_name_custom_04 = txtGradingSchemeName_Custom04.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_04 = txtDescription_Custom04.Text;
            updateGradingScheme.s_grading_scheme_name_custom_05 = txtGradingSchemeName_Custom05.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_05 = txtDescription_Custom05.Text;
            updateGradingScheme.s_grading_scheme_name_custom_06 = txtGradingSchemeName_Custom06.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_06 = txtDescription_Custom06.Text;
            updateGradingScheme.s_grading_scheme_name_custom_07 = txtGradingSchemeName_Custom07.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_07 = txtDescription_Custom07.Text;
            updateGradingScheme.s_grading_scheme_name_custom_08 = txtGradingSchemeName_Custom08.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_08 = txtDescription_Custom08.Text;
            updateGradingScheme.s_grading_scheme_name_custom_09 = txtGradingSchemeName_Custom09.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_09 = txtDescription_Custom09.Text;
            updateGradingScheme.s_grading_scheme_name_custom_10 = txtGradingSchemeName_Custom10.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_10 = txtDescription_Custom10.Text;
            updateGradingScheme.s_grading_scheme_name_custom_11 = txtGradingSchemeName_Custom11.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_11 = txtDescription_Custom11.Text;
            updateGradingScheme.s_grading_scheme_name_custom_12 = txtGradingSchemeName_Custom12.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_12 = txtDescription_Custom12.Text;
            updateGradingScheme.s_grading_scheme_name_custom_13 = txtGradingSchemeName_Custom13.Text;
            updateGradingScheme.s_grading_scheme_desc_custom_13 = txtDescription_Custom13.Text;

            error = SystemGradingSchemesBLL.UpdateGradingSchemes(updateGradingScheme);
            if (error != -2)
            {
                //TO-DO show div with success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Successfully Updated');", true);
            }
            else
            {
                //TO-DO show div with error message
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('the given scheme id already exists');", true);
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerHtml = LocalResources.GetText("app_grading_scheme_id_already_exists_error_text");

            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/GradingSchemes/saangsn-01.aspx", false);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/GradingSchemes/saangsn-01.aspx", false);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void gvGradingSchemes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string s_grading_scheme_system_value_id_pk = gvGradingSchemes.DataKeys[e.Row.RowIndex][0].ToString();
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
                int result = SystemGradingSchemesBLL.DeleteGradingSchemesValues(args.Trim());


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saegs-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saegs-01", ex.Message);
                    }
                }
            }
        }

        protected void btnUpdateValue_Click(object sender, EventArgs e)
        {
            DataTable dtGetGradingschemeValue = new DataTable();
            dtGetGradingschemeValue = SystemGradingSchemesBLL.GetGradingSchemesValue(editGradingSchemeId);
            foreach (GridViewRow row in gvGradingSchemes.Rows)
            {
                TextBox txtMinscore = (TextBox)row.FindControl("txtMinscore");
                TextBox txtMaxscore = (TextBox)row.FindControl("txtMaxscore");
                TextBox txtGpa = (TextBox)row.FindControl("txtGpa");
                DropDownList ddlPassingStatus = (DropDownList)row.FindControl("ddlPassingStatus");
                string s_grading_scheme_system_value_id_pk = gvGradingSchemes.DataKeys[row.RowIndex].Value.ToString();
                var rows = dtGetGradingschemeValue.Select("s_grading_scheme_system_value_id_pk= '" + s_grading_scheme_system_value_id_pk + "'");
                var indexOfRow = dtGetGradingschemeValue.Rows.IndexOf(rows[0]);
                dtGetGradingschemeValue.Rows[indexOfRow]["s_grading_scheme_value_min_score"] = txtMinscore.Text;
                dtGetGradingschemeValue.Rows[indexOfRow]["s_grading_scheme_value_max_score"] = txtMaxscore.Text;
                dtGetGradingschemeValue.Rows[indexOfRow]["s_grading_scheme_value_gpa"] = txtGpa.Text;
                dtGetGradingschemeValue.Rows[indexOfRow]["s_grading_scheme_value_pass_status_id_fk"] = ddlPassingStatus.SelectedValue;
                dtGetGradingschemeValue.AcceptChanges();
                
            }
            
            ConvertDataTables convert = new ConvertDataTables();
            string UpdateGradingSchemesValues = convert.ConvertDataTableToXml(dtGetGradingschemeValue);
            int result = SystemGradingSchemesBLL.UpdateallGradingSchemeValue(UpdateGradingSchemesValues);
            hdUpdateValue.Value = "0";
        }
        

        


    }
}