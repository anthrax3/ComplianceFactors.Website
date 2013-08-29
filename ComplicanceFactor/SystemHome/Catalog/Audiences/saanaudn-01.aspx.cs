using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
namespace ComplicanceFactor.SystemHome.Catalog.Audiences
{
    public partial class saanaudn_01 : System.Web.UI.Page
    {
        private static string copyAudienceid;
        public static DataTable dtAudienceParam;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<summary>
            ///Hide validation on postback (if user select add parameter)
            ///</summary>
            vs_saanaudn.Style.Add("display", "none");
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Audiences/samaudmp-01.aspx>" + LocalResources.GetLabel("app_manage_audiences_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_audience_text") + "</a>";
                //Bind Status
                ddlStatus.DataSource = SystemAudiencesBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();
                //Clear Datatable
                dtAudienceParam = null;
                //Copy a single Audience
                dtAudienceParam = null;
                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyAudienceid = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PopulateAudience(copyAudienceid);
                    //Bind  Audience
                    dtAudienceParam = SystemAudiencesBLL.GetAudienceParameter(copyAudienceid);
                    BindAssignmentParam();
                }
            }
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Audience", "lastEquivalenciesrow();", true);
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            CreateAudiences(false);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Audiences/samaudmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Audiences/samaudmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            CreateAudiences(false);
        }
        //Create a Audience
        private void CreateAudiences(bool popupstatus)
        {
            SystemAudiences createAudience = new SystemAudiences();
            createAudience.u_audience_system_id_pk = Guid.NewGuid().ToString();
            createAudience.u_audience_id_pk = txtAudienceId.Text;
            createAudience.u_audience_status_id_fk = ddlStatus.SelectedValue;
            createAudience.u_audience_name = txtAudienceName.Text;
            createAudience.u_audience_desc = txtAudienceDescription.Value;
            createAudience.u_audience_name_uk_english = txtAudienceName_EnglishUk.Text;
            createAudience.u_audience_desc_uk_english = txtDescription_EnglishUk.Value;
            createAudience.u_audience_name_ca_france = txtAudienceName_FrenchCa.Text;
            createAudience.u_audience_desc_ca_france = txtDescription_FrenchCa.Value;
            createAudience.u_audience_name_fr_french = txtAudienceName_FrenchFr.Text;
            createAudience.u_audience_desc_fr_french = txtDescription_FrenchFr.Value;
            createAudience.u_audience_name_mx_spanish = txtAudienceName_SpanishMx.Text;
            createAudience.u_audience_desc_mx_spanish = txtDescription_SpanishMx.Value;
            createAudience.u_audience_name_sp_spanish = txtAudienceName_SpanishSp.Text;
            createAudience.u_audience_desc_sp_spanish = txtDescription_SpanishSp.Value;
            createAudience.u_audience_name_portuguse = txtAudienceName_Portuguese.Text;
            createAudience.u_audience_desc_portuguse = txtDescription_Portuguese.Value;
            createAudience.u_audience_name_chinese = txtAudienceName_Chinese.Text;
            createAudience.u_audience_desc_chinese = txtDescription_Chinese.Value;
            createAudience.u_audience_name_german = txtAudienceName_German.Text;
            createAudience.u_audience_desc_german = txtDescription_German.Value;
            createAudience.u_audience_name_japanese = txtAudienceName_Japanese.Text;
            createAudience.u_audience_desc_japanese = txtDescription_Japanese.Value;
            createAudience.u_audience_name_russian = txtAudienceName_Russian.Text;
            createAudience.u_audience_desc_russian = txtDescription_Russian.Value;
            createAudience.u_audience_name_danish = txtAudienceName_Danish.Text;
            createAudience.u_audience_desc_danish = txtDescription_Danish.Value;
            createAudience.u_audience_name_polish = txtAudienceName_Polish.Text;
            createAudience.u_audience_desc_polish = txtDescription_Polish.Value;
            createAudience.u_audience_name_swedish = txtAudienceName_Swedish.Text;
            createAudience.u_audience_desc_swedish = txtDescription_Swedish.Value;
            createAudience.u_audience_name_finnish = txtAudienceName_Finnish.Text;
            createAudience.u_audience_desc_finnish = txtDescription_Finnish.Value;
            createAudience.u_audience_name_korean = txtAudienceName_Korean.Text;
            createAudience.u_audience_desc_korean = txtDescription_Korean.Value;
            createAudience.u_audience_name_italian = txtAudienceName_Italian.Text;
            createAudience.u_audience_desc_italian = txtDescription_Italian.Value;
            createAudience.u_audience_name_dutch = txtAudienceName_Dutch.Text;
            createAudience.u_audience_desc_dutch = txtDescription_Dutch.Value;
            createAudience.u_audience_name_indonesian = txtAudienceName_Indonesian.Text;
            createAudience.u_audience_desc_indonesian = txtDescription_Indonesian.Value;
            createAudience.u_audience_name_greek = txtAudienceName_Greek.Text;
            createAudience.u_audience_desc_greek = txtDescription_Greek.Value;
            createAudience.u_audience_name_hungarian = txtAudienceName_Hungarian.Text;
            createAudience.u_audience_desc_hungarian = txtDescription_Hungarian.Value;
            createAudience.u_audience_name_norwegian = txtAudienceName_Norwegian.Text;
            createAudience.u_audience_desc_norwegian = txtDescription_Norwegian.Value;
            createAudience.u_audience_name_turkish = txtAudienceName_Turkish.Text;
            createAudience.u_audience_desc_turkish = txtDescription_Turkish.Value;
            createAudience.u_audience_name_arabic = txtAudienceName_Arabic.Text;
            createAudience.u_audience_desc_arabic = txtDescription_Arabic.Value;
            createAudience.u_audience_name_custom_01 = txtAudienceName_Custom01.Text;
            createAudience.u_audience_desc_custom_01 = txtDescription_Custom01.Value;
            createAudience.u_audience_name_custom_02 = txtAudienceName_Custom02.Text;
            createAudience.u_audience_desc_custom_02 = txtDescription_Custom02.Value;
            createAudience.u_audience_name_custom_03 = txtAudienceName_Custom03.Text;
            createAudience.u_audience_desc_custom_03 = txtDescription_Custom03.Value;
            createAudience.u_audience_name_custom_04 = txtAudienceName_Custom04.Text;
            createAudience.u_audience_desc_custom_04 = txtDescription_Custom04.Value;
            createAudience.u_audience_name_custom_05 = txtAudienceName_Custom05.Text;
            createAudience.u_audience_desc_custom_05 = txtDescription_Custom05.Value;
            createAudience.u_audience_name_custom_06 = txtAudienceName_Custom06.Text;
            createAudience.u_audience_desc_custom_06 = txtDescription_Custom06.Value;
            createAudience.u_audience_name_custom_07 = txtAudienceName_Custom07.Text;
            createAudience.u_audience_desc_custom_07 = txtDescription_Custom07.Value;
            createAudience.u_audience_name_custom_08 = txtAudienceName_Custom08.Text;
            createAudience.u_audience_desc_custom_08 = txtDescription_Custom08.Value;
            createAudience.u_audience_name_custom_09 = txtAudienceName_Custom09.Text;
            createAudience.u_audience_desc_custom_09 = txtDescription_Custom09.Value;
            createAudience.u_audience_name_custom_10 = txtAudienceName_Custom10.Text;
            createAudience.u_audience_desc_custom_10 = txtDescription_Custom10.Value;
            createAudience.u_audience_name_custom_11 = txtAudienceName_Custom11.Text;
            createAudience.u_audience_desc_custom_11 = txtDescription_Custom11.Value;
            createAudience.u_audience_name_custom_12 = txtAudienceName_Custom12.Text;
            createAudience.u_audience_desc_custom_12 = txtDescription_Custom12.Value;
            createAudience.u_audience_name_custom_13 = txtAudienceName_Custom13.Text;
            createAudience.u_audience_desc_custom_13 = txtDescription_Custom13.Value;

            if (dtAudienceParam != null)
            {
                UpdateAssignmentParameter(createAudience.u_audience_system_id_pk);
                ConvertDataTables Convertxml = new ConvertDataTables();
                createAudience.audiences_parameters = Convertxml.ConvertDataTableToXml(dtAudienceParam);
            }
            else
            {
                createAudience.audiences_parameters = null;
            }

            int error = SystemAudiencesBLL.CreateAudience(createAudience);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Catalog/Audiences/saeaud-01.aspx?id=" + SecurityCenter.EncryptText(createAudience.u_audience_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true") + "&popup=" + popupstatus, false);
            }

            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_audience_id_already_exist_error_wrong");
            }
        }

        //Populate Audience
        private void PopulateAudience(string CopyAudienceId)
        {

            SystemAudiences audience = new SystemAudiences();
            audience = SystemAudiencesBLL.GetAudience(CopyAudienceId);
            txtAudienceId.Text = audience.u_audience_id_pk + "_copy";
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

        protected void btnAddNewParameters_Click(object sender, EventArgs e)
        {
            CreateAudiences(true);
        }
        protected void gvAudienceParameters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)e.Row.FindControl("txtValues");
                ddlOperator.DataSource = SystemAudiencesBLL.GetAudienceOperator();
                ddlOperator.DataBind();
                ddlOperator.SelectedValue = gvAudienceParameters.DataKeys[e.Row.RowIndex][1].ToString();
                string element = DataBinder.Eval(e.Row.DataItem, "u_audiences_param_element_id_fk").ToString();
                string values = DataBinder.Eval(e.Row.DataItem, "u_audiences_param_values").ToString();
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

        private void UpdateAssignmentParameter(string u_audience_id_fk)
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
                else
                {
                    dtAudienceParam.Rows[indexRow]["u_audiences_param_values"] = DBNull.Value;
                }
                dtAudienceParam.Rows[indexRow]["u_audiences_id_fk"] = u_audience_id_fk;
                dtAudienceParam.AcceptChanges();
            }
        }

        protected void gvAudienceParameters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                var rows = dtAudienceParam.Select("u_audience_param_system_id_pk='" + e.CommandArgument.ToString() + "'");
                foreach (var row in rows)
                {
                    row.Delete();
                    dtAudienceParam.AcceptChanges();
                    BindAssignmentParam();
                }
                //using jquery hide the '-or-' in last row
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
            }
        }
        //Bind Audience parameter
        private void BindAssignmentParam()
        {
            gvAudienceParameters.DataSource = dtAudienceParam;
            gvAudienceParameters.DataBind();
        }
    }
}