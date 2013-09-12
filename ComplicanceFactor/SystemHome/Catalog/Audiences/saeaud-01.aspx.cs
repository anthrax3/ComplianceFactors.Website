using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.Audiences
{
    public partial class saeaud_01 : System.Web.UI.Page
    {
        private static string editAudienceId;
        private static DataTable dtResetAudienceParameter;
        private static DataTable dtAudienceParam;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //<summary>
                ///Hide validation on postback (if user select AudienceValues)
                ///</summary>
                vs_saeaud.Style.Add("display", "none");

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Audiences/samaudmp-01.aspx>" + LocalResources.GetLabel("app_manage_audiences_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_audiences_text") + "</a>";
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    //TO-DO SHOW THE MESSAGE WHETHER 'SUCCESSFULLY INSERTED OR UPDATED IN A MESSAGE DIV'
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    //divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editAudienceId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdEditAudienceId.Value = editAudienceId;
                    hdEncryptAudienceId.Value = SecurityCenter.EncryptText(editAudienceId);
                }
                //Bind status
                ddlStatus.DataSource = SystemAudiencesBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();               
                //Populate audience
                PopulateAudience(editAudienceId);
                
                if (!string.IsNullOrEmpty(Request.QueryString["popup"]))
                {
                    if (Convert.ToBoolean(Request.QueryString["popup"].ToString()) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", "showParameterPopup('false');", true);//note:Popup will open from create page to edit page
                    }                    
                }
                if (string.IsNullOrEmpty(Request.QueryString["reset"]))
                {
                    //Using For rest
                    dtResetAudienceParameter = SystemAudiencesBLL.GetAudienceParameter(editAudienceId);
                }
                //Bind Parameter   //Because of using Row_Command
                BindAudienceParams();
            }
            if (hdStopRebind.Value == "0")
            {
                BindAudienceParams();
                hdStopRebind.Value = string.Empty;                
            }                       
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Audience", "lastEquivalenciesrow();", true);
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            UpdateAudience();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetAudiences();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Audiences/samaudmp-01.aspx");
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            UpdateAudience();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetAudiences(); 
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Audiences/samaudmp-01.aspx");
        }
        private void PopulateAudience(string gradingSchemeId)
        {

            SystemAudiences audience = new SystemAudiences();
            audience = SystemAudiencesBLL.GetAudience(editAudienceId);
            txtAudienceId.Text = audience.u_audience_id_pk;
            txtAudienceName.Text = audience.u_audience_name;
            txtAudienceDescription.Value = audience.u_audience_desc;
            ddlStatus.SelectedValue = audience.u_audience_status_id_fk;
            txtAudienceName_EnglishUk.Text = audience.u_audience_name_uk_english;
            txtDescription_EnglishUk.Value = audience.u_audience_desc_uk_english;
            txtAudienceName_FrenchCa.Text = audience.u_audience_name_ca_france;
            txtDescription_FrenchCa.Value = audience.u_audience_desc_ca_france;
            txtAudienceName_FrenchFr.Text = audience.u_audience_name_fr_french;
            txtDescription_FrenchFr.Value = audience.u_audience_desc_fr_french;
            txtAudienceName_SpanishMx.Text = audience.u_audience_name_mx_spanish;
            txtDescription_SpanishMx.Value = audience.u_audience_desc_mx_spanish;
            txtAudienceName_SpanishSp.Text = audience.u_audience_name_sp_spanish;
            txtDescription_SpanishSp.Value = audience.u_audience_desc_sp_spanish;
            txtAudienceName_Portuguese.Text = audience.u_audience_name_portuguse;
            txtDescription_Portuguese.Value = audience.u_audience_desc_portuguse;
            txtAudienceName_Chinese.Text = audience.u_audience_name_chinese;
            txtDescription_Chinese.Value = audience.u_audience_desc_chinese;
            txtAudienceName_German.Text = audience.u_audience_name_german;
            txtDescription_German.Value = audience.u_audience_desc_german;
            txtAudienceName_Japanese.Text = audience.u_audience_name_japanese;
            txtDescription_Japanese.Value = audience.u_audience_desc_japanese;
            txtAudienceName_Russian.Text = audience.u_audience_name_russian;
            txtDescription_Russian.Value = audience.u_audience_desc_russian;
            txtAudienceName_Danish.Text = audience.u_audience_name_danish;
            txtDescription_Danish.Value = audience.u_audience_desc_danish;
            txtAudienceName_Polish.Text = audience.u_audience_name_polish;
            txtDescription_Polish.Value = audience.u_audience_desc_polish;
            txtAudienceName_Swedish.Text = audience.u_audience_name_swedish;
            txtDescription_Swedish.Value = audience.u_audience_desc_swedish;
            txtAudienceName_Finnish.Text = audience.u_audience_name_finnish;
            txtDescription_Finnish.Value = audience.u_audience_desc_finnish;
            txtAudienceName_Korean.Text = audience.u_audience_name_korean;
            txtDescription_Korean.Value = audience.u_audience_desc_korean;
            txtAudienceName_Italian.Text = audience.u_audience_name_italian;
            txtDescription_Italian.Value = audience.u_audience_desc_italian;
            txtAudienceName_Dutch.Text = audience.u_audience_name_dutch;
            txtDescription_Dutch.Value = audience.u_audience_desc_dutch;
            txtAudienceName_Indonesian.Text = audience.u_audience_name_indonesian;
            txtDescription_Indonesian.Value = audience.u_audience_desc_indonesian;
            txtAudienceName_Greek.Text = audience.u_audience_name_greek;
            txtDescription_Greek.Value = audience.u_audience_desc_greek;
            txtAudienceName_Hungarian.Text = audience.u_audience_name_hungarian;
            txtDescription_Hungarian.Value = audience.u_audience_desc_hungarian;
            txtAudienceName_Norwegian.Text = audience.u_audience_name_norwegian;
            txtDescription_Norwegian.Value = audience.u_audience_desc_norwegian;
            txtAudienceName_Turkish.Text = audience.u_audience_name_turkish;
            txtDescription_Turkish.Value = audience.u_audience_desc_turkish;
            txtAudienceName_Arabic.Text = audience.u_audience_name_arabic;
            txtDescription_Arabic.Value = audience.u_audience_desc_arabic;
            txtAudienceName_Custom01.Text = audience.u_audience_name_custom_01;
            txtDescription_Custom01.Value = audience.u_audience_desc_custom_01;
            txtAudienceName_Custom02.Text = audience.u_audience_name_custom_02;
            txtDescription_Custom02.Value = audience.u_audience_desc_custom_02;
            txtAudienceName_Custom03.Text = audience.u_audience_name_custom_03;
            txtDescription_Custom03.Value = audience.u_audience_desc_custom_03;
            txtAudienceName_Custom04.Text = audience.u_audience_name_custom_04;
            txtDescription_Custom04.Value = audience.u_audience_desc_custom_04;
            txtAudienceName_Custom05.Text = audience.u_audience_name_custom_05;
            txtDescription_Custom05.Value = audience.u_audience_desc_custom_05;
            txtAudienceName_Custom06.Text = audience.u_audience_name_custom_06;
            txtDescription_Custom06.Value = audience.u_audience_desc_custom_06;
            txtAudienceName_Custom07.Text = audience.u_audience_name_custom_07;
            txtDescription_Custom07.Value = audience.u_audience_desc_custom_07;
            txtAudienceName_Custom08.Text = audience.u_audience_name_custom_08;
            txtDescription_Custom08.Value = audience.u_audience_desc_custom_08;
            txtAudienceName_Custom09.Text = audience.u_audience_name_custom_09;
            txtDescription_Custom09.Value = audience.u_audience_desc_custom_09;
            txtAudienceName_Custom10.Text = audience.u_audience_name_custom_10;
            txtDescription_Custom10.Value = audience.u_audience_desc_custom_10;
            txtAudienceName_Custom11.Text = audience.u_audience_name_custom_11;
            txtDescription_Custom11.Value = audience.u_audience_desc_custom_11;
            txtAudienceName_Custom12.Text = audience.u_audience_name_custom_12;
            txtDescription_Custom12.Value = audience.u_audience_desc_custom_12;
            txtAudienceName_Custom13.Text = audience.u_audience_name_custom_13;
            txtDescription_Custom13.Value = audience.u_audience_desc_custom_13;
        }
        private void BindAudienceParams()
        {
            dtAudienceParam = SystemAudiencesBLL.GetAudienceParameter(editAudienceId);
            gvAudienceParameters.DataSource = dtAudienceParam;
            gvAudienceParameters.DataBind();
        }
        protected void gvAudienceParameters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)e.Row.FindControl("txtValues");
                string element = DataBinder.Eval(e.Row.DataItem, "u_audiences_param_element_id_fk").ToString();
                string values = DataBinder.Eval(e.Row.DataItem, "u_audiences_param_values").ToString();
                ddlOperator.DataSource = SystemAudiencesBLL.GetAudienceOperator();
                ddlOperator.DataBind();
                ddlOperator.SelectedValue = gvAudienceParameters.DataKeys[e.Row.RowIndex][1].ToString();
                HashEncryption encHash = new HashEncryption();
                if (element == "Assigned" || element == "Enrolled" || element == "Completed" || element == "Passed" || element == "Failed")
                {
                    ddlOperator.Enabled = false;
                    txtValues.Enabled = false;
                }
                else
                {
                    if (element == "u_username_enc" && !string.IsNullOrEmpty(values))
                    {
                        string[] usernames = gvAudienceParameters.DataKeys[e.Row.RowIndex][2].ToString().Split(',');
                        for (int i = 0; i < usernames.Length; i++)
                        {
                            txtValues.Text += encHash.Decrypt(usernames[i], true) + ",";
                        }
                        txtValues.Text = txtValues.Text.TrimEnd(',');
                    }
                    else
                    {
                        txtValues.Text = gvAudienceParameters.DataKeys[e.Row.RowIndex][2].ToString();
                    }
                }
            }
        }

        private void UpdateAssignmentParameter()
        {

            foreach (GridViewRow row in gvAudienceParameters.Rows)
            {
                DropDownList ddlOperator = (DropDownList)row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)row.FindControl("txtValues");
                string u_audience_param_system_id_pk = gvAudienceParameters.DataKeys[row.RowIndex][0].ToString();
                var rows = dtAudienceParam.Select("u_audiences_param_system_id_pk='" + u_audience_param_system_id_pk + "'");
                var indexRow = dtAudienceParam.Rows.IndexOf(rows[0]);
                dtAudienceParam.Rows[indexRow]["u_audiences_param_operator_id_fk"] = ddlOperator.SelectedValue;

                if (dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "u_username_enc" && !string.IsNullOrEmpty(txtValues.Text))
                {
                    /// Hash encryption for username and password
                    /// </summary>
                    HashEncryption encHash = new HashEncryption();
                    string[] usernames = txtValues.Text.Split(',');
                    string encryptstring = string.Empty;
                    for (int i = 0; i < usernames.Length; i++)
                    {
                        encryptstring += (encHash.GenerateHashvalue(usernames[i], true) + ",").ToString();

                    }
                    dtAudienceParam.Rows[indexRow]["u_audiences_param_values"] = encryptstring.TrimEnd(',');
                }
                else if (!string.IsNullOrEmpty(txtValues.Text))
                {
                    dtAudienceParam.Rows[indexRow]["u_audiences_param_values"] = txtValues.Text;
                }
                else
                {
                    dtAudienceParam.Rows[indexRow]["u_audiences_param_values"] = DBNull.Value;
                }
                if (dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "Assigned" || dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "Enrolled" || dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "Completed" || dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "Passed" || dtAudienceParam.Rows[indexRow]["u_audiences_param_element_id_fk"].ToString() == "Failed")
                {
                    dtAudienceParam.Rows[indexRow]["u_audiences_param_operator_id_fk"] = DBNull.Value; //Because u_assignment_group_param_element_id_fk is eqaul to Assigned,Enrolled,Completed,Passed and Failed
                }
                dtAudienceParam.AcceptChanges();
            }
        }

        protected void gvAudienceParameters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                SystemAudiencesBLL.RemoveAudienceParameter(editAudienceId, e.CommandArgument.ToString());
                BindAudienceParams();
                //using jquery hide the '-or-' in last row                   
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
            }
        }

        //For Reset
        private void ResetAudiences()
        {
            ConvertDataTables ConvertXml = new ConvertDataTables();
            SystemAudiencesBLL.ResetAssignmentParameter(ConvertXml.ConvertDataTableToXml(dtResetAudienceParameter), editAudienceId);
            Response.Redirect(Request.RawUrl);
        }

        private void UpdateAudience()
        {
            SystemAudiences updateAudience = new SystemAudiences();
            updateAudience.u_audience_system_id_pk = editAudienceId;
            updateAudience.u_audience_id_pk = txtAudienceId.Text;
            updateAudience.u_audience_status_id_fk = ddlStatus.SelectedValue;
            updateAudience.u_audience_name = txtAudienceName.Text;
            updateAudience.u_audience_desc = txtAudienceDescription.Value;
            updateAudience.u_audience_name_uk_english = txtAudienceName_EnglishUk.Text;
            updateAudience.u_audience_desc_uk_english = txtDescription_EnglishUk.Value;
            updateAudience.u_audience_name_ca_france = txtAudienceName_FrenchCa.Text;
            updateAudience.u_audience_desc_ca_france = txtDescription_FrenchCa.Value;
            updateAudience.u_audience_name_fr_french = txtAudienceName_FrenchFr.Text;
            updateAudience.u_audience_desc_fr_french = txtDescription_FrenchFr.Value;
            updateAudience.u_audience_name_mx_spanish = txtAudienceName_SpanishMx.Text;
            updateAudience.u_audience_desc_mx_spanish = txtDescription_SpanishMx.Value;
            updateAudience.u_audience_name_sp_spanish = txtAudienceName_SpanishSp.Text;
            updateAudience.u_audience_desc_sp_spanish = txtDescription_SpanishSp.Value;
            updateAudience.u_audience_name_portuguse = txtAudienceName_Portuguese.Text;
            updateAudience.u_audience_desc_portuguse = txtDescription_Portuguese.Value;
            updateAudience.u_audience_name_chinese = txtAudienceName_Chinese.Text;
            updateAudience.u_audience_desc_chinese = txtDescription_Chinese.Value;
            updateAudience.u_audience_name_german = txtAudienceName_German.Text;
            updateAudience.u_audience_desc_german = txtDescription_German.Value;
            updateAudience.u_audience_name_japanese = txtAudienceName_Japanese.Text;
            updateAudience.u_audience_desc_japanese = txtDescription_Japanese.Value;
            updateAudience.u_audience_name_russian = txtAudienceName_Russian.Text;
            updateAudience.u_audience_desc_russian = txtDescription_Russian.Value;
            updateAudience.u_audience_name_danish = txtAudienceName_Danish.Text;
            updateAudience.u_audience_desc_danish = txtDescription_Danish.Value;
            updateAudience.u_audience_name_polish = txtAudienceName_Polish.Text;
            updateAudience.u_audience_desc_polish = txtDescription_Polish.Value;
            updateAudience.u_audience_name_swedish = txtAudienceName_Swedish.Text;
            updateAudience.u_audience_desc_swedish = txtDescription_Swedish.Value;
            updateAudience.u_audience_name_finnish = txtAudienceName_Finnish.Text;
            updateAudience.u_audience_desc_finnish = txtDescription_Finnish.Value;
            updateAudience.u_audience_name_korean = txtAudienceName_Korean.Text;
            updateAudience.u_audience_desc_korean = txtDescription_Korean.Value;
            updateAudience.u_audience_name_italian = txtAudienceName_Italian.Text;
            updateAudience.u_audience_desc_italian = txtDescription_Italian.Value;
            updateAudience.u_audience_name_dutch = txtAudienceName_Dutch.Text;
            updateAudience.u_audience_desc_dutch = txtDescription_Dutch.Value;
            updateAudience.u_audience_name_indonesian = txtAudienceName_Indonesian.Text;
            updateAudience.u_audience_desc_indonesian = txtDescription_Indonesian.Value;
            updateAudience.u_audience_name_greek = txtAudienceName_Greek.Text;
            updateAudience.u_audience_desc_greek = txtDescription_Greek.Value;
            updateAudience.u_audience_name_hungarian = txtAudienceName_Hungarian.Text;
            updateAudience.u_audience_desc_hungarian = txtDescription_Hungarian.Value;
            updateAudience.u_audience_name_norwegian = txtAudienceName_Norwegian.Text;
            updateAudience.u_audience_desc_norwegian = txtDescription_Norwegian.Value;
            updateAudience.u_audience_name_turkish = txtAudienceName_Turkish.Text;
            updateAudience.u_audience_desc_turkish = txtDescription_Turkish.Value;
            updateAudience.u_audience_name_arabic = txtAudienceName_Arabic.Text;
            updateAudience.u_audience_desc_arabic = txtDescription_Arabic.Value;
            updateAudience.u_audience_name_custom_01 = txtAudienceName_Custom01.Text;
            updateAudience.u_audience_desc_custom_01 = txtDescription_Custom01.Value;
            updateAudience.u_audience_name_custom_02 = txtAudienceName_Custom02.Text;
            updateAudience.u_audience_desc_custom_02 = txtDescription_Custom02.Value;
            updateAudience.u_audience_name_custom_03 = txtAudienceName_Custom03.Text;
            updateAudience.u_audience_desc_custom_03 = txtDescription_Custom03.Value;
            updateAudience.u_audience_name_custom_04 = txtAudienceName_Custom04.Text;
            updateAudience.u_audience_desc_custom_04 = txtDescription_Custom04.Value;
            updateAudience.u_audience_name_custom_05 = txtAudienceName_Custom05.Text;
            updateAudience.u_audience_desc_custom_05 = txtDescription_Custom05.Value;
            updateAudience.u_audience_name_custom_06 = txtAudienceName_Custom06.Text;
            updateAudience.u_audience_desc_custom_06 = txtDescription_Custom06.Value;
            updateAudience.u_audience_name_custom_07 = txtAudienceName_Custom07.Text;
            updateAudience.u_audience_desc_custom_07 = txtDescription_Custom07.Value;
            updateAudience.u_audience_name_custom_08 = txtAudienceName_Custom08.Text;
            updateAudience.u_audience_desc_custom_08 = txtDescription_Custom08.Value;
            updateAudience.u_audience_name_custom_09 = txtAudienceName_Custom09.Text;
            updateAudience.u_audience_desc_custom_09 = txtDescription_Custom09.Value;
            updateAudience.u_audience_name_custom_10 = txtAudienceName_Custom10.Text;
            updateAudience.u_audience_desc_custom_10 = txtDescription_Custom10.Value;
            updateAudience.u_audience_name_custom_11 = txtAudienceName_Custom11.Text;
            updateAudience.u_audience_desc_custom_11 = txtDescription_Custom11.Value;
            updateAudience.u_audience_name_custom_12 = txtAudienceName_Custom12.Text;
            updateAudience.u_audience_desc_custom_12 = txtDescription_Custom12.Value;
            updateAudience.u_audience_name_custom_13 = txtAudienceName_Custom13.Text;
            updateAudience.u_audience_desc_custom_13 = txtDescription_Custom13.Value;
            if (dtAudienceParam.Rows.Count > 0)
            {
                UpdateAssignmentParameter();
                ConvertDataTables Convertxml = new ConvertDataTables();
                updateAudience.audiences_parameters = Convertxml.ConvertDataTableToXml(dtAudienceParam);
            }

            int error = SystemAudiencesBLL.UpdateAudience(updateAudience);
            if (error != -2)
            {
                if (dtAudienceParam.Rows.Count > 0)
                {
                    DataTable dtUser = SystemAudiencesBLL.GetAudienceUser(editAudienceId, SessionWrapper.CultureName);
                    ConvertDataTables ConvertXml = new ConvertDataTables();
                    if (dtUser.Rows.Count > 0)
                    {
                        int result = SystemAudiencesBLL.InsertAudienceUser(editAudienceId, ConvertXml.ConvertDataTableToXml(dtUser));
                    }                    
                }
                //TO-DO show div with success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                //divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
            }
            else
            {
                //TO-DO show div with error message
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");                
                divError.InnerHtml = LocalResources.GetText("app_audience_id_already_exist_error_wrong");

            }
        }

        
    }
}