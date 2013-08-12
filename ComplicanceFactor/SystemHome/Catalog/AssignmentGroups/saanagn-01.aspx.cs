using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using System.Data;
namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups
{
    public partial class saanagn_01 : System.Web.UI.Page
    {
        private static string copyAssignmentGroupid;
        public static DataTable dtAssignmentParam;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx>" + LocalResources.GetLabel("app_manage_assignment_groups_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_assignment_groups_text") + "</a>";
                //Bind Status
                ddlStatus.DataSource = SystemAssignmentGroupBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();
                //Clear Datatable
                dtAssignmentParam = null;
                //Copy a single Assignment groups
                dtAssignmentParam = null;
                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    
                    copyAssignmentGroupid = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PopulateassignmentGroup(copyAssignmentGroupid);
                    //Bind  Assignment group Parameter
                    dtAssignmentParam = SystemAssignmentGroupBLL.GetAssignmentParameter(copyAssignmentGroupid); 
                    BindAssignmentParam();
                }
            }
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            CreateAssignmentGroups(false);
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
            CreateAssignmentGroups(false);//false means popup does't open
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }
        //Create a Assignment group
        private void CreateAssignmentGroups(bool popupstatus)
        {
            SystemAssingnmentGroup createAssignmentGroup = new SystemAssingnmentGroup();
            createAssignmentGroup.u_assignment_group_system_id_pk = Guid.NewGuid().ToString();
            createAssignmentGroup.u_assignment_group_id_pk = txtAssignmentGroupId.Text;
            createAssignmentGroup.u_assignment_group_status_id_fk = ddlStatus.SelectedValue;
            createAssignmentGroup.u_assignment_group_name = txtAssignmentGroupName.Text;
            createAssignmentGroup.u_assignment_group_desc = txtAssignmentGroupDescription.Value;
            createAssignmentGroup.u_assignment_group_name_uk_english = txtAssignmentGroupName_EnglishUk.Text;
            createAssignmentGroup.u_assignment_group_desc_uk_english = txtDescription_EnglishUk.Value;
            createAssignmentGroup.u_assignment_group_name_ca_france = txtAssignmentGroupName_FrenchCa.Text;
            createAssignmentGroup.u_assignment_group_desc_ca_france = txtDescription_FrenchCa.Value;
            createAssignmentGroup.u_assignment_group_name_fr_french = txtAssignmentGroupName_FrenchFr.Text;
            createAssignmentGroup.u_assignment_group_desc_fr_french = txtDescription_FrenchFr.Value;
            createAssignmentGroup.u_assignment_group_name_mx_spanish = txtAssignmentGroupName_SpanishMx.Text;
            createAssignmentGroup.u_assignment_group_desc_mx_spanish = txtDescription_SpanishMx.Value;
            createAssignmentGroup.u_assignment_group_name_sp_spanish = txtAssignmentGroupName_SpanishSp.Text;
            createAssignmentGroup.u_assignment_group_desc_sp_spanish = txtDescription_SpanishSp.Value;
            createAssignmentGroup.u_assignment_group_name_portuguse = txtAssignmentGroupName_Portuguese.Text;
            createAssignmentGroup.u_assignment_group_desc_portuguse = txtDescription_Portuguese.Value;
            createAssignmentGroup.u_assignment_group_name_chinese = txtAssignmentGroupName_Chinese.Text;
            createAssignmentGroup.u_assignment_group_desc_chinese = txtDescription_Chinese.Value;
            createAssignmentGroup.u_assignment_group_name_german = txtAssignmentGroupName_German.Text;
            createAssignmentGroup.u_assignment_group_desc_german = txtDescription_German.Value;
            createAssignmentGroup.u_assignment_group_name_japanese = txtAssignmentGroupName_Japanese.Text;
            createAssignmentGroup.u_assignment_group_desc_japanese = txtDescription_Japanese.Value;
            createAssignmentGroup.u_assignment_group_name_russian = txtAssignmentGroupName_Russian.Text;
            createAssignmentGroup.u_assignment_group_desc_russian = txtDescription_Russian.Value;
            createAssignmentGroup.u_assignment_group_name_danish = txtAssignmentGroupName_Danish.Text;
            createAssignmentGroup.u_assignment_group_desc_danish = txtDescription_Danish.Value;
            createAssignmentGroup.u_assignment_group_name_polish = txtAssignmentGroupName_Polish.Text;
            createAssignmentGroup.u_assignment_group_desc_polish = txtDescription_Polish.Value;
            createAssignmentGroup.u_assignment_group_name_swedish = txtAssignmentGroupName_Swedish.Text;
            createAssignmentGroup.u_assignment_group_desc_swedish = txtDescription_Swedish.Value;
            createAssignmentGroup.u_assignment_group_name_finnish = txtAssignmentGroupName_Finnish.Text;
            createAssignmentGroup.u_assignment_group_desc_finnish = txtDescription_Finnish.Value;
            createAssignmentGroup.u_assignment_group_name_korean = txtAssignmentGroupName_Korean.Text;
            createAssignmentGroup.u_assignment_group_desc_korean = txtDescription_Korean.Value;
            createAssignmentGroup.u_assignment_group_name_italian = txtAssignmentGroupName_Italian.Text;
            createAssignmentGroup.u_assignment_group_desc_italian = txtDescription_Italian.Value;
            createAssignmentGroup.u_assignment_group_name_dutch = txtAssignmentGroupName_Dutch.Text;
            createAssignmentGroup.u_assignment_group_desc_dutch = txtDescription_Dutch.Value;
            createAssignmentGroup.u_assignment_group_name_indonesian = txtAssignmentGroupName_Indonesian.Text;
            createAssignmentGroup.u_assignment_group_desc_indonesian = txtDescription_Indonesian.Value;
            createAssignmentGroup.u_assignment_group_name_greek = txtAssignmentGroupName_Greek.Text;
            createAssignmentGroup.u_assignment_group_desc_greek = txtDescription_Greek.Value;
            createAssignmentGroup.u_assignment_group_name_hungarian = txtAssignmentGroupName_Hungarian.Text;
            createAssignmentGroup.u_assignment_group_desc_hungarian = txtDescription_Hungarian.Value;
            createAssignmentGroup.u_assignment_group_name_norwegian = txtAssignmentGroupName_Norwegian.Text;
            createAssignmentGroup.u_assignment_group_desc_norwegian = txtDescription_Norwegian.Value;
            createAssignmentGroup.u_assignment_group_name_turkish = txtAssignmentGroupName_Turkish.Text;
            createAssignmentGroup.u_assignment_group_desc_turkish = txtDescription_Turkish.Value;
            createAssignmentGroup.u_assignment_group_name_arabic = txtAssignmentGroupName_Arabic.Text;
            createAssignmentGroup.u_assignment_group_desc_arabic = txtDescription_Arabic.Value;
            createAssignmentGroup.u_assignment_group_name_custom_01 = txtAssignmentGroupName_Custom01.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_01 = txtDescription_Custom01.Value;
            createAssignmentGroup.u_assignment_group_name_custom_02 = txtAssignmentGroupName_Custom02.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_02 = txtDescription_Custom02.Value;
            createAssignmentGroup.u_assignment_group_name_custom_03 = txtAssignmentGroupName_Custom03.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_03 = txtDescription_Custom03.Value;
            createAssignmentGroup.u_assignment_group_name_custom_04 = txtAssignmentGroupName_Custom04.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_04 = txtDescription_Custom04.Value;
            createAssignmentGroup.u_assignment_group_name_custom_05 = txtAssignmentGroupName_Custom05.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_05 = txtDescription_Custom05.Value;
            createAssignmentGroup.u_assignment_group_name_custom_06 = txtAssignmentGroupName_Custom06.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_06 = txtDescription_Custom06.Value;
            createAssignmentGroup.u_assignment_group_name_custom_07 = txtAssignmentGroupName_Custom07.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_07 = txtDescription_Custom07.Value;
            createAssignmentGroup.u_assignment_group_name_custom_08 = txtAssignmentGroupName_Custom08.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_08 = txtDescription_Custom08.Value;
            createAssignmentGroup.u_assignment_group_name_custom_09 = txtAssignmentGroupName_Custom09.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_09 = txtDescription_Custom09.Value;
            createAssignmentGroup.u_assignment_group_name_custom_10 = txtAssignmentGroupName_Custom10.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_10 = txtDescription_Custom10.Value;
            createAssignmentGroup.u_assignment_group_name_custom_11 = txtAssignmentGroupName_Custom11.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_11 = txtDescription_Custom11.Value;
            createAssignmentGroup.u_assignment_group_name_custom_12 = txtAssignmentGroupName_Custom12.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_12 = txtDescription_Custom12.Value;
            createAssignmentGroup.u_assignment_group_name_custom_13 = txtAssignmentGroupName_Custom13.Text;
            createAssignmentGroup.u_assignment_group_desc_custom_13 = txtDescription_Custom13.Value;

            if (dtAssignmentParam != null)
            {
                UpdateAssignmentParameter(createAssignmentGroup.u_assignment_group_system_id_pk);
                ConvertDataTables Convertxml = new ConvertDataTables();
                createAssignmentGroup.assignment_parameters = Convertxml.ConvertDataTableToXml(dtAssignmentParam);
            }
            else
            {
                createAssignmentGroup.assignment_parameters = null;
            }
            
            int error = SystemAssignmentGroupBLL.CreateAssignmentGroup(createAssignmentGroup);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/saeag-01.aspx?id=" + SecurityCenter.EncryptText(createAssignmentGroup.u_assignment_group_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true") + "&popup=" + popupstatus, false);
            }

            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_assignment_group_id_already_exist_error_wrong");
            }
        }

        //Populate Assignment group
        private void PopulateassignmentGroup(string CopyassignmentGroupId)
        {
            SystemAssingnmentGroup assignmentGroup = new SystemAssingnmentGroup();
            assignmentGroup = SystemAssignmentGroupBLL.GetAssignmentGroup(CopyassignmentGroupId);
            txtAssignmentGroupId.Text = assignmentGroup.u_assignment_group_id_pk + "_copy";
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

        protected void btnAddNewParameters_Click(object sender, EventArgs e)
        {
            CreateAssignmentGroups(true);
        }
        protected void gvAssignmentGroupParameters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)e.Row.FindControl("txtValues");
                ddlOperator.DataSource = SystemAssignmentGroupBLL.GetAssignmentOperator();
                ddlOperator.DataBind();
                ddlOperator.SelectedValue = gvAssignmentGroupParameters.DataKeys[e.Row.RowIndex][1].ToString();
                string element = DataBinder.Eval(e.Row.DataItem, "u_assignment_group_param_element_id_fk").ToString();
                HashEncryption encHash = new HashEncryption();
                if (element == "u_username_enc")
                {
                    string[] usernames = gvAssignmentGroupParameters.DataKeys[e.Row.RowIndex][2].ToString().Split(',');
                    for (int i = 0; i < usernames.Length; i++)
                    {
                        txtValues.Text += encHash.Decrypt(usernames[i], true) + ",";
                    }
                    txtValues.Text = txtValues.Text.TrimEnd(',');
                }
                else
                {
                    txtValues.Text = gvAssignmentGroupParameters.DataKeys[e.Row.RowIndex][2].ToString();
                }
            }
        }
        ////Delete Param
        //[System.Web.Services.WebMethod]
        //public static void DeleteParam(string args)
        //{
        //    try
        //    {
        //        var rows = SessionWrapper.AssignmentGroupsParam.Select("u_assignment_group_param_system_id_pk='" + args.Trim() + "'");
        //        foreach (var row in rows)
        //        {
        //            row.Delete();
        //            SessionWrapper.AssignmentGroupsParam.AcceptChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO: Show user friendly error here
        //        //Log here
        //        if (ConfigurationWrapper.LogErrors == true)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                Logger.WriteToErrorLog("saanagn-01", ex.Message, ex.InnerException.Message);
        //            }
        //            else
        //            {
        //                Logger.WriteToErrorLog("saanagn-01", ex.Message);
        //            }
        //        }
        //    }

        //}

        private void UpdateAssignmentParameter(string u_assignment_group_id_fk)
        {
            foreach (GridViewRow row in gvAssignmentGroupParameters.Rows)
            {
                DropDownList ddlOperator = (DropDownList)row.FindControl("ddlOperator");
                TextBox txtValues = (TextBox)row.FindControl("txtValues");
                string u_assignment_group_param_system_id_pk = gvAssignmentGroupParameters.DataKeys[row.RowIndex][0].ToString();
                var rows = dtAssignmentParam.Select("u_assignment_group_param_system_id_pk='" + u_assignment_group_param_system_id_pk + "'");
                var indexRow = dtAssignmentParam.Rows.IndexOf(rows[0]);

                dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_operator_id_fk"] = ddlOperator.SelectedValue;
                if (dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_element_id_fk"].ToString() == "u_username_enc")
                {
                    /// Hash encryption for username and password
                    /// </summary>
                    HashEncryption encHash = new HashEncryption();

                    string[] usernames = txtValues.Text.Split(',');
                    for (int i = 0; i < usernames.Length; i++)
                    {
                        dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_values"] += encHash.GenerateHashvalue(usernames[i], true) + ",";
                    }
                    dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_values"] = dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_values"].ToString().TrimEnd(',');
                }
                else
                {
                    dtAssignmentParam.Rows[indexRow]["u_assignment_group_param_values"] = txtValues.Text;
                }           
                dtAssignmentParam.Rows[indexRow]["u_assignment_group_id_fk"] = u_assignment_group_id_fk;
                dtAssignmentParam.AcceptChanges();
            }
        }

        protected void gvAssignmentGroupParameters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                var rows = dtAssignmentParam.Select("u_assignment_group_param_system_id_pk='" + e.CommandArgument.ToString() + "'");
                foreach (var row in rows)
                {
                    row.Delete();
                    dtAssignmentParam.AcceptChanges();
                    BindAssignmentParam();
                }
                //using jquery hide the '-or-' in last row
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
            }
        }
        //Bind Assignment group parameter
        private void BindAssignmentParam()
        {
            gvAssignmentGroupParameters.DataSource = dtAssignmentParam;
            gvAssignmentGroupParameters.DataBind(); 
        }
    }
}