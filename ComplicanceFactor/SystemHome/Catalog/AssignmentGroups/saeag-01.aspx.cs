using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups
{
    public partial class saeag_01 : System.Web.UI.Page
    {
        private static string editAssignmentGroupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //<summary>
                ///Hide validation on postback (if user select AssignmentGroupValues)
                ///</summary>
                vs_saeag.Style.Add("display", "none");

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx>"+"Manage Assignment Groups"+ "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Edit Assignment Groups" + "</a>";
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    //TO-DO SHOW THE MESSAGE WHETHER 'SUCCESSFULLY INSERTED OR UPDATED IN A MESSAGE DIV'
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "SuccessFully Inserted";
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editAssignmentGroupId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdEditAssignmentId.Value = editAssignmentGroupId;
                }
                //Bind status
                ddlStatus.DataSource = SystemAssignmentGroupBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();

                PopulateAssignmentGroup(editAssignmentGroupId);
                if (!string.IsNullOrEmpty(Request.QueryString["popup"]))
                {
                    if (Convert.ToBoolean(Request.QueryString["popup"].ToString()) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", "showParameterPopup();", true);
                    }
                }
                //using jquery hide the '-or-' in last row
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Assignmentgroups", "lastEquivalenciesrow();", true);
            }
            //Bind Parameter
            BindAssignmentParams();

        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            UpdateAssignmentGroup();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            UpdateAssignmentGroup();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }
        /// <summary>
        /// Populate Assignment Group
        /// </summary>
        /// <param name="gradingSchemeId"></param>
        private void PopulateAssignmentGroup(string gradingSchemeId)
        {
            SystemAssingnmentGroup assignmentGroup = new SystemAssingnmentGroup();
            assignmentGroup = SystemAssignmentGroupBLL.GetAssignmentGroup(editAssignmentGroupId);
            txtAssignmentGroupId.Text = assignmentGroup.u_assignment_group_id_pk;
            txtAssignmentGroupName.Text = assignmentGroup.u_assignment_group_name;
            txtAssignmentGroupDescription.Value = assignmentGroup.u_assignment_group_desc;
            ddlStatus.SelectedValue = assignmentGroup.u_assignment_group_status_id_fk;
            txtAssignmentGroupName_EnglishUk.Text = assignmentGroup.u_assignment_group_name_uk_english;
            txtDescription_EnglishUk.Value = assignmentGroup.u_assignment_group_desc_uk_english;
            txtAssignmentGroupName_FrenchCa.Text = assignmentGroup.u_assignment_group_name_ca_france;
            txtDescription_FrenchCa.Value = assignmentGroup.u_assignment_group_desc_ca_france;
            txtAssignmentGroupName_FrenchFr.Text = assignmentGroup.u_assignment_group_name_fr_french;
            txtDescription_FrenchFr.Value = assignmentGroup.u_assignment_group_desc_fr_french;
            txtAssignmentGroupName_SpanishMx.Text = assignmentGroup.u_assignment_group_name_mx_spanish;
            txtDescription_SpanishMx.Value = assignmentGroup.u_assignment_group_desc_mx_spanish;
            txtAssignmentGroupName_SpanishSp.Text = assignmentGroup.u_assignment_group_name_sp_spanish;
            txtDescription_SpanishSp.Value = assignmentGroup.u_assignment_group_desc_sp_spanish;
            txtAssignmentGroupName_Portuguese.Text = assignmentGroup.u_assignment_group_name_portuguse;
            txtDescription_Portuguese.Value = assignmentGroup.u_assignment_group_desc_portuguse;
            txtAssignmentGroupName_Chinese.Text = assignmentGroup.u_assignment_group_name_chinese;
            txtDescription_Chinese.Value = assignmentGroup.u_assignment_group_desc_chinese;
            txtAssignmentGroupName_German.Text = assignmentGroup.u_assignment_group_name_german;
            txtDescription_German.Value = assignmentGroup.u_assignment_group_desc_german;
            txtAssignmentGroupName_Japanese.Text = assignmentGroup.u_assignment_group_name_japanese;
            txtDescription_Japanese.Value = assignmentGroup.u_assignment_group_desc_japanese;
            txtAssignmentGroupName_Russian.Text = assignmentGroup.u_assignment_group_name_russian;
            txtDescription_Russian.Value = assignmentGroup.u_assignment_group_desc_russian;
            txtAssignmentGroupName_Danish.Text = assignmentGroup.u_assignment_group_name_danish;
            txtDescription_Danish.Value = assignmentGroup.u_assignment_group_desc_danish;
            txtAssignmentGroupName_Polish.Text = assignmentGroup.u_assignment_group_name_polish;
            txtDescription_Polish.Value = assignmentGroup.u_assignment_group_desc_polish;
            txtAssignmentGroupName_Swedish.Text = assignmentGroup.u_assignment_group_name_swedish;
            txtDescription_Swedish.Value = assignmentGroup.u_assignment_group_desc_swedish;
            txtAssignmentGroupName_Finnish.Text = assignmentGroup.u_assignment_group_name_finnish;
            txtDescription_Finnish.Value = assignmentGroup.u_assignment_group_desc_finnish;
            txtAssignmentGroupName_Korean.Text = assignmentGroup.u_assignment_group_name_korean;
            txtDescription_Korean.Value = assignmentGroup.u_assignment_group_desc_korean;
            txtAssignmentGroupName_Italian.Text = assignmentGroup.u_assignment_group_name_italian;
            txtDescription_Italian.Value = assignmentGroup.u_assignment_group_desc_italian;
            txtAssignmentGroupName_Dutch.Text = assignmentGroup.u_assignment_group_name_dutch;
            txtDescription_Dutch.Value = assignmentGroup.u_assignment_group_desc_dutch;
            txtAssignmentGroupName_Indonesian.Text = assignmentGroup.u_assignment_group_name_indonesian;
            txtDescription_Indonesian.Value = assignmentGroup.u_assignment_group_desc_indonesian;
            txtAssignmentGroupName_Greek.Text = assignmentGroup.u_assignment_group_name_greek;
            txtDescription_Greek.Value = assignmentGroup.u_assignment_group_desc_greek;
            txtAssignmentGroupName_Hungarian.Text = assignmentGroup.u_assignment_group_name_hungarian;
            txtDescription_Hungarian.Value = assignmentGroup.u_assignment_group_desc_hungarian;
            txtAssignmentGroupName_Norwegian.Text = assignmentGroup.u_assignment_group_name_norwegian;
            txtDescription_Norwegian.Value = assignmentGroup.u_assignment_group_desc_norwegian;
            txtAssignmentGroupName_Turkish.Text = assignmentGroup.u_assignment_group_name_turkish;
            txtDescription_Turkish.Value = assignmentGroup.u_assignment_group_desc_turkish;
            txtAssignmentGroupName_Arabic.Text = assignmentGroup.u_assignment_group_name_arabic;
            txtDescription_Arabic.Value = assignmentGroup.u_assignment_group_desc_arabic;
            txtAssignmentGroupName_Custom01.Text = assignmentGroup.u_assignment_group_name_custom_01;
            txtDescription_Custom01.Value = assignmentGroup.u_assignment_group_desc_custom_01;
            txtAssignmentGroupName_Custom02.Text = assignmentGroup.u_assignment_group_name_custom_02;
            txtDescription_Custom02.Value = assignmentGroup.u_assignment_group_desc_custom_02;
            txtAssignmentGroupName_Custom03.Text = assignmentGroup.u_assignment_group_name_custom_03;
            txtDescription_Custom03.Value = assignmentGroup.u_assignment_group_desc_custom_03;
            txtAssignmentGroupName_Custom04.Text = assignmentGroup.u_assignment_group_name_custom_04;
            txtDescription_Custom04.Value = assignmentGroup.u_assignment_group_desc_custom_04;
            txtAssignmentGroupName_Custom05.Text = assignmentGroup.u_assignment_group_name_custom_05;
            txtDescription_Custom05.Value = assignmentGroup.u_assignment_group_desc_custom_05;
            txtAssignmentGroupName_Custom06.Text = assignmentGroup.u_assignment_group_name_custom_06;
            txtDescription_Custom06.Value = assignmentGroup.u_assignment_group_desc_custom_06;
            txtAssignmentGroupName_Custom07.Text = assignmentGroup.u_assignment_group_name_custom_07;
            txtDescription_Custom07.Value = assignmentGroup.u_assignment_group_desc_custom_07;
            txtAssignmentGroupName_Custom08.Text = assignmentGroup.u_assignment_group_name_custom_08;
            txtDescription_Custom08.Value = assignmentGroup.u_assignment_group_desc_custom_08;
            txtAssignmentGroupName_Custom09.Text = assignmentGroup.u_assignment_group_name_custom_09;
            txtDescription_Custom09.Value = assignmentGroup.u_assignment_group_desc_custom_09;
            txtAssignmentGroupName_Custom10.Text = assignmentGroup.u_assignment_group_name_custom_10;
            txtDescription_Custom10.Value = assignmentGroup.u_assignment_group_desc_custom_10;
            txtAssignmentGroupName_Custom11.Text = assignmentGroup.u_assignment_group_name_custom_11;
            txtDescription_Custom11.Value = assignmentGroup.u_assignment_group_desc_custom_11;
            txtAssignmentGroupName_Custom12.Text = assignmentGroup.u_assignment_group_name_custom_12;
            txtDescription_Custom12.Value = assignmentGroup.u_assignment_group_desc_custom_12;
            txtAssignmentGroupName_Custom13.Text = assignmentGroup.u_assignment_group_name_custom_13;
            txtDescription_Custom13.Value = assignmentGroup.u_assignment_group_desc_custom_13;
        }
        /// <summary>
        /// Update assignment group
        /// </summary>
        private void UpdateAssignmentGroup()
        {
            SystemAssingnmentGroup updateAssignmentGroup = new SystemAssingnmentGroup();
            updateAssignmentGroup.u_assignment_group_system_id_pk = editAssignmentGroupId;
            updateAssignmentGroup.u_assignment_group_id_pk = txtAssignmentGroupId.Text;
            updateAssignmentGroup.u_assignment_group_status_id_fk = ddlStatus.SelectedValue;
            updateAssignmentGroup.u_assignment_group_name = txtAssignmentGroupName.Text;
            updateAssignmentGroup.u_assignment_group_desc = txtAssignmentGroupDescription.Value;
            updateAssignmentGroup.u_assignment_group_name_uk_english = txtAssignmentGroupName_EnglishUk.Text;
            updateAssignmentGroup.u_assignment_group_desc_uk_english = txtDescription_EnglishUk.Value;
            updateAssignmentGroup.u_assignment_group_name_ca_france = txtAssignmentGroupName_FrenchCa.Text;
            updateAssignmentGroup.u_assignment_group_desc_ca_france = txtDescription_FrenchCa.Value;
            updateAssignmentGroup.u_assignment_group_name_fr_french = txtAssignmentGroupName_FrenchFr.Text;
            updateAssignmentGroup.u_assignment_group_desc_fr_french = txtDescription_FrenchFr.Value;
            updateAssignmentGroup.u_assignment_group_name_mx_spanish = txtAssignmentGroupName_SpanishMx.Text;
            updateAssignmentGroup.u_assignment_group_desc_mx_spanish = txtDescription_SpanishMx.Value;
            updateAssignmentGroup.u_assignment_group_name_sp_spanish = txtAssignmentGroupName_SpanishSp.Text;
            updateAssignmentGroup.u_assignment_group_desc_sp_spanish = txtDescription_SpanishSp.Value;
            updateAssignmentGroup.u_assignment_group_name_portuguse = txtAssignmentGroupName_Portuguese.Text;
            updateAssignmentGroup.u_assignment_group_desc_portuguse = txtDescription_Portuguese.Value;
            updateAssignmentGroup.u_assignment_group_name_chinese = txtAssignmentGroupName_Chinese.Text;
            updateAssignmentGroup.u_assignment_group_desc_chinese = txtDescription_Chinese.Value;
            updateAssignmentGroup.u_assignment_group_name_german = txtAssignmentGroupName_German.Text;
            updateAssignmentGroup.u_assignment_group_desc_german = txtDescription_German.Value;
            updateAssignmentGroup.u_assignment_group_name_japanese = txtAssignmentGroupName_Japanese.Text;
            updateAssignmentGroup.u_assignment_group_desc_japanese = txtDescription_Japanese.Value;
            updateAssignmentGroup.u_assignment_group_name_russian = txtAssignmentGroupName_Russian.Text;
            updateAssignmentGroup.u_assignment_group_desc_russian = txtDescription_Russian.Value;
            updateAssignmentGroup.u_assignment_group_name_danish = txtAssignmentGroupName_Danish.Text;
            updateAssignmentGroup.u_assignment_group_desc_danish = txtDescription_Danish.Value;
            updateAssignmentGroup.u_assignment_group_name_polish = txtAssignmentGroupName_Polish.Text;
            updateAssignmentGroup.u_assignment_group_desc_polish = txtDescription_Polish.Value;
            updateAssignmentGroup.u_assignment_group_name_swedish = txtAssignmentGroupName_Swedish.Text;
            updateAssignmentGroup.u_assignment_group_desc_swedish = txtDescription_Swedish.Value;
            updateAssignmentGroup.u_assignment_group_name_finnish = txtAssignmentGroupName_Finnish.Text;
            updateAssignmentGroup.u_assignment_group_desc_finnish = txtDescription_Finnish.Value;
            updateAssignmentGroup.u_assignment_group_name_korean = txtAssignmentGroupName_Korean.Text;
            updateAssignmentGroup.u_assignment_group_desc_korean = txtDescription_Korean.Value;
            updateAssignmentGroup.u_assignment_group_name_italian = txtAssignmentGroupName_Italian.Text;
            updateAssignmentGroup.u_assignment_group_desc_italian = txtDescription_Italian.Value;
            updateAssignmentGroup.u_assignment_group_name_dutch = txtAssignmentGroupName_Dutch.Text;
            updateAssignmentGroup.u_assignment_group_desc_dutch = txtDescription_Dutch.Value;
            updateAssignmentGroup.u_assignment_group_name_indonesian = txtAssignmentGroupName_Indonesian.Text;
            updateAssignmentGroup.u_assignment_group_desc_indonesian = txtDescription_Indonesian.Value;
            updateAssignmentGroup.u_assignment_group_name_greek = txtAssignmentGroupName_Greek.Text;
            updateAssignmentGroup.u_assignment_group_desc_greek = txtDescription_Greek.Value;
            updateAssignmentGroup.u_assignment_group_name_hungarian = txtAssignmentGroupName_Hungarian.Text;
            updateAssignmentGroup.u_assignment_group_desc_hungarian = txtDescription_Hungarian.Value;
            updateAssignmentGroup.u_assignment_group_name_norwegian = txtAssignmentGroupName_Norwegian.Text;
            updateAssignmentGroup.u_assignment_group_desc_norwegian = txtDescription_Norwegian.Value;
            updateAssignmentGroup.u_assignment_group_name_turkish = txtAssignmentGroupName_Turkish.Text;
            updateAssignmentGroup.u_assignment_group_desc_turkish = txtDescription_Turkish.Value;
            updateAssignmentGroup.u_assignment_group_name_arabic = txtAssignmentGroupName_Arabic.Text;
            updateAssignmentGroup.u_assignment_group_desc_arabic = txtDescription_Arabic.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_01 = txtAssignmentGroupName_Custom01.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_01 = txtDescription_Custom01.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_02 = txtAssignmentGroupName_Custom02.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_02 = txtDescription_Custom02.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_03 = txtAssignmentGroupName_Custom03.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_03 = txtDescription_Custom03.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_04 = txtAssignmentGroupName_Custom04.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_04 = txtDescription_Custom04.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_05 = txtAssignmentGroupName_Custom05.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_05 = txtDescription_Custom05.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_06 = txtAssignmentGroupName_Custom06.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_06 = txtDescription_Custom06.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_07 = txtAssignmentGroupName_Custom07.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_07 = txtDescription_Custom07.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_08 = txtAssignmentGroupName_Custom08.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_08 = txtDescription_Custom08.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_09 = txtAssignmentGroupName_Custom09.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_09 = txtDescription_Custom09.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_10 = txtAssignmentGroupName_Custom10.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_10 = txtDescription_Custom10.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_11 = txtAssignmentGroupName_Custom11.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_11 = txtDescription_Custom11.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_12 = txtAssignmentGroupName_Custom12.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_12 = txtDescription_Custom12.Value;
            updateAssignmentGroup.u_assignment_group_name_custom_13 = txtAssignmentGroupName_Custom13.Text;
            updateAssignmentGroup.u_assignment_group_desc_custom_13 = txtDescription_Custom13.Value;

            int error = SystemAssignmentGroupBLL.UpdateAssignmentGroup(updateAssignmentGroup);
            if (error != -2)
            {
                //TO-DO show div with success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = "Successfully Updated";
            }
            else
            {
                //TO-DO show div with error message
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('the given scheme id already exists');", true);
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerHtml = "Assignment Group already exist";

            }
        }

        private void BindAssignmentParams()
        {
            gvAssignmentGroupParameters.DataSource = SystemAssignmentGroupBLL.GetAssignmentParameter(editAssignmentGroupId);
            gvAssignmentGroupParameters.DataBind();
        }
        //Delete Param
        [System.Web.Services.WebMethod]
        public static void DeleteParam(string args)
        {
            try
            {
                SystemAssignmentGroupBLL.RemoveParameter(editAssignmentGroupId, args.Trim());
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeag-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeag-01", ex.Message);
                    }
                }
            }

        }

        protected void gvAssignmentGroupParameters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)e.Row.FindControl("txtValues");
                ddlOperator.SelectedValue = gvAssignmentGroupParameters.DataKeys[e.Row.RowIndex][1].ToString();
                txtValues.Text = gvAssignmentGroupParameters.DataKeys[e.Row.RowIndex][2].ToString();                
            }
        }
    }
}