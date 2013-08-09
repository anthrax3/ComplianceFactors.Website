using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentRules
{
    public partial class saanarn_01 : System.Web.UI.Page
    {
        private static string copyassignmentRule;
        private static DataTable dtTempCatalogItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + "Manage Training" + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Create New Assignment Rule" + "</a>";

                //Bind Status
                ddlStatus.DataSource = SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName, "saangsn-01");
                ddlStatus.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyassignmentRule = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PopulateAssignmentRule(copyassignmentRule);                   
                }
            }
            //if (hdnIsDeleteCatalog.Value == "0")
            //{
            //    gvCatalogItems.DataSource = dtTempCatalogItem;
            //    gvCatalogItems.DataBind();

            //    hdnIsDeleteCatalog.Value = "1";
            //}
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            SaveNewAssignmentRule(string.Empty);
        }

        protected void btnFooterSaveNewAssignmentRule_Click(object sender, EventArgs e)
        {
            SaveNewAssignmentRule(string.Empty);
        }

        private void SaveNewAssignmentRule(string process)
        {
            SystemAssignmentRules createAssignmentRules = new SystemAssignmentRules();
            createAssignmentRules.u_assignment_rules_system_id_pk = Guid.NewGuid().ToString();
            createAssignmentRules.u_assignment_rules_id_pk = txtAssignmentRuleId_EnglishUs.Text;
            createAssignmentRules.u_assignment_rules_name = txtAssignmentRuleName_EnglishUs.Text;
            createAssignmentRules.u_assignment_rules_status_id_fk = ddlStatus.SelectedValue;

            createAssignmentRules.u_assignment_rules_desc = txtAssignmentDescriptionUS.Text;

            createAssignmentRules.u_assignment_rules_required_flag = chkRequired.Checked;
            if (rbtTagetduedate.Checked == true)
            {
                createAssignmentRules.u_assignment_rules_due_select_param = "1";
            }
            else
            {
                createAssignmentRules.u_assignment_rules_due_select_param = "2";
            }
            if (!string.IsNullOrEmpty(txtTargetduedate.Text))
            {
                createAssignmentRules.u_assignment_rules_fix_date_param = Convert.ToDateTime(txtTargetduedate.Text);
            }
            if (!string.IsNullOrEmpty(txtDue.Text))
            {
                createAssignmentRules.u_assignment_rules_days_param = Convert.ToInt16(txtDue.Text);
            }

            createAssignmentRules.u_assignment_rules_name_uk_english = txtAssignmentRuleUk.Text;
            createAssignmentRules.u_assignment_rules_desc_uk_english = txtDescriptionUk.Text;
            createAssignmentRules.u_assignment_rules_name_ca_french = txtAssignmentRuleName_FrenchCa.Text;
            createAssignmentRules.u_assignment_rules_desc_ca_french = txtDescription_FrenchCa.Text;
            createAssignmentRules.u_assignment_rules_name_fr_french = txtAssignmentRuleName_FrenchFr.Text;
            createAssignmentRules.u_assignment_rules_desc_fr_french = txtDescription_FrenchFr.Text;
            createAssignmentRules.u_assignment_rules_name_mx_spanish = txtAssignmentRuleName_SpanishMx.Text;
            createAssignmentRules.u_assignment_rules_desc_mx_spanish = txtDescription_SpanishMx.Text;
            createAssignmentRules.u_assignment_rules_name_sp_spanish = txtAssignmentRuleName_SpanishSp.Text;
            createAssignmentRules.u_assignment_rules_desc_sp_spanish = txtDescription_SpanishSp.Text;
            createAssignmentRules.u_assignment_rules_name_portuguese = txtAssignmentRuleName_Portuguese.Text;
            createAssignmentRules.u_assignment_rules_desc_portuguese = txtDescription_Portuguese.Text;
            createAssignmentRules.u_assignment_rules_name_simp_chinese = txtAssignmentRuleName_Chinese.Text;
            createAssignmentRules.u_assignment_rules_desc_simp_chinese = txtDescription_Chinese.Text;
            createAssignmentRules.u_assignment_rules_name_german = txtAssignmentRuleName_German.Text;
            createAssignmentRules.u_assignment_rules_desc_german = txtDescription_German.Text;
            createAssignmentRules.u_assignment_rules_name_japanese = txtAssignmentRuleName_Japanese.Text;
            createAssignmentRules.u_assignment_rules_desc_japanese = txtDescription_Japanese.Text;
            createAssignmentRules.u_assignment_rules_name_russian = txtAssignmentRuleName_Russian.Text;
            createAssignmentRules.u_assignment_rules_desc_russian = txtDescription_Russian.Text;
            createAssignmentRules.u_assignment_rules_name_danish = txtAssignmentRuleName_Danish.Text;
            createAssignmentRules.u_assignment_rules_desc_danish = txtDescription_Danish.Text;
            createAssignmentRules.u_assignment_rules_name_polish = txtAssignmentRuleName_Polish.Text;
            createAssignmentRules.u_assignment_rules_desc_polish = txtDescription_Polish.Text;
            createAssignmentRules.u_assignment_rules_name_swedish = txtAssignmentRuleName_Swedish.Text;
            createAssignmentRules.u_assignment_rules_desc_swedish = txtDescription_Swedish.Text;
            createAssignmentRules.u_assignment_rules_name_finnish = txtAssignmentRuleName_Finnish.Text;
            createAssignmentRules.u_assignment_rules_desc_finnish = txtDescription_Finnish.Text;
            createAssignmentRules.u_assignment_rules_name_korean = txtAssignmentRuleName_Korean.Text;
            createAssignmentRules.u_assignment_rules_desc_korean = txtDescription_Korean.Text;
            createAssignmentRules.u_assignment_rules_name_italian = txtAssignmentRuleName_Italian.Text;
            createAssignmentRules.u_assignment_rules_desc_italian = txtDescription_Italian.Text;
            createAssignmentRules.u_assignment_rules_name_dutch = txtAssignmentRuleName_Dutch.Text;
            createAssignmentRules.u_assignment_rules_desc_dutch = txtDescription_Dutch.Text;
            createAssignmentRules.u_assignment_rules_name_indonesian = txtAssignmentRuleName_Indonesian.Text;
            createAssignmentRules.u_assignment_rules_desc_indonesian = txtDescription_Indonesian.Text;
            createAssignmentRules.u_assignment_rules_name_greek = txtAssignmentRuleName_Greek.Text;
            createAssignmentRules.u_assignment_rules_desc_greek = txtDescription_Greek.Text;
            createAssignmentRules.u_assignment_rules_name_hungarian = txtAssignmentRuleName_Hungarian.Text;
            createAssignmentRules.u_assignment_rules_desc_hungarian = txtDescription_Hungarian.Text;
            createAssignmentRules.u_assignment_rules_name_norwegian = txtAssignmentRuleName_Norwegian.Text;
            createAssignmentRules.u_assignment_rules_desc_norwegian = txtDescription_Norwegian.Text;
            createAssignmentRules.u_assignment_rules_name_turkish = txtAssignmentRuleName_Turkish.Text;
            createAssignmentRules.u_assignment_rules_desc_turkish = txtDescription_Turkish.Text;
            createAssignmentRules.u_assignment_rules_name_arabic = txtAssignmentRuleName_Arabic.Text;
            createAssignmentRules.u_assignment_rules_desc_arabic = txtDescription_Arabic.Text;
            createAssignmentRules.u_assignment_rules_name_custom_01 = txtAssignmentRuleName_Custom01.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_01 = txtDescription_Custom01.Text;
            createAssignmentRules.u_assignment_rules_name_custom_02 = txtAssignmentRuleName_Custom02.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_02 = txtDescription_Custom02.Text;
            createAssignmentRules.u_assignment_rules_name_custom_03 = txtAssignmentRuleName_Custom03.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_03 = txtDescription_Custom03.Text;
            createAssignmentRules.u_assignment_rules_name_custom_04 = txtAssignmentRuleName_Custom04.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_04 = txtDescription_Custom04.Text;
            createAssignmentRules.u_assignment_rules_name_custom_05 = txtAssignmentRuleName_Custom05.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_05 = txtDescription_Custom05.Text;
            createAssignmentRules.u_assignment_rules_name_custom_06 = txtAssignmentRuleName_Custom06.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_06 = txtDescription_Custom06.Text;
            createAssignmentRules.u_assignment_rules_name_custom_07 = txtAssignmentRuleName_Custom07.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_07 = txtDescription_Custom07.Text;
            createAssignmentRules.u_assignment_rules_name_custom_08 = txtAssignmentRuleName_Custom08.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_08 = txtDescription_Custom08.Text;
            createAssignmentRules.u_assignment_rules_name_custom_09 = txtAssignmentRuleName_Custom09.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_09 = txtDescription_Custom09.Text;
            createAssignmentRules.u_assignment_rules_name_custom_10 = txtAssignmentRuleName_Custom10.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_10 = txtDescription_Custom10.Text;
            createAssignmentRules.u_assignment_rules_name_custom_11 = txtAssignmentRuleName_Custom11.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_11 = txtDescription_Custom11.Text;
            createAssignmentRules.u_assignment_rules_name_custom_12 = txtAssignmentRuleName_Custom12.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_12 = txtDescription_Custom12.Text;
            createAssignmentRules.u_assignment_rules_name_custom_13 = txtAssignmentRuleName_Custom13.Text;
            createAssignmentRules.u_assignment_rules_desc_custom_13 = txtDescription_Custom13.Text;

            int error = SystemAssignmentRuleBLL.InsertAssignmentRule(createAssignmentRules);

            if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
            {
                //Catalog Item
                ConvertDataTables cv = new ConvertDataTables();
                int result = SystemAssignmentRuleBLL.InsertCatalogItemForRuleFromCopy(cv.ConvertDataTableToXml(dtTempCatalogItem), createAssignmentRules.u_assignment_rules_system_id_pk);

                //Add Groups
            }
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Catalog/AssignmentRules/saear-01.aspx?id=" + SecurityCenter.EncryptText(createAssignmentRules.u_assignment_rules_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true") + "&process=" + SecurityCenter.EncryptText(process), false);
            }
            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = "Assignment rules already exists";
            }
        }

        /// <summary>
        /// PopulateAssignmentRule
        /// </summary>
        /// <param name="assignmentRuleId"></param>
        private void PopulateAssignmentRule(string assignmentRuleId)
        {
            SystemAssignmentRules assignmentRule = new SystemAssignmentRules();
            assignmentRule = SystemAssignmentRuleBLL.GetAssignmentRule(assignmentRuleId);

            txtAssignmentRuleId_EnglishUs.Text = assignmentRule.u_assignment_rules_id_pk + "_copy";
            txtAssignmentRuleName_EnglishUs.Text = assignmentRule.u_assignment_rules_name;
            ddlStatus.SelectedValue = assignmentRule.u_assignment_rules_status_id_fk;

            txtAssignmentDescriptionUS.Text = assignmentRule.u_assignment_rules_desc;

            chkRequired.Checked = assignmentRule.u_assignment_rules_required_flag;
            if (assignmentRule.u_assignment_rules_due_select_param == "1")
            {
                rbtTagetduedate.Checked = true;
            }
            else
            {
                rbtTagetduedate.Checked = false;
            }
            txtTargetduedate.Text = assignmentRule.u_assignment_rules_fix_date_param.ToShortDateString();
            txtDue.Text = assignmentRule.u_assignment_rules_days_param.ToString();

            txtAssignmentRuleUk.Text = assignmentRule.u_assignment_rules_name_uk_english;
            txtDescriptionUk.Text = assignmentRule.u_assignment_rules_desc_uk_english;

            txtAssignmentRuleName_FrenchCa.Text = assignmentRule.u_assignment_rules_name_ca_french;
            txtDescription_FrenchCa.Text = assignmentRule.u_assignment_rules_desc_ca_french;
            txtAssignmentRuleName_FrenchFr.Text = assignmentRule.u_assignment_rules_name_fr_french;
            txtDescription_FrenchFr.Text = assignmentRule.u_assignment_rules_desc_fr_french;
            txtAssignmentRuleName_SpanishMx.Text = assignmentRule.u_assignment_rules_name_mx_spanish;
            txtDescription_SpanishMx.Text = assignmentRule.u_assignment_rules_desc_mx_spanish;
            txtAssignmentRuleName_SpanishSp.Text = assignmentRule.u_assignment_rules_name_sp_spanish;
            txtDescription_SpanishSp.Text = assignmentRule.u_assignment_rules_desc_sp_spanish;
            txtAssignmentRuleName_Portuguese.Text = assignmentRule.u_assignment_rules_name_portuguese;
            txtDescription_Portuguese.Text = assignmentRule.u_assignment_rules_desc_portuguese;
            txtAssignmentRuleName_Chinese.Text = assignmentRule.u_assignment_rules_name_simp_chinese;
            txtDescription_Chinese.Text = assignmentRule.u_assignment_rules_desc_simp_chinese;
            txtAssignmentRuleName_German.Text = assignmentRule.u_assignment_rules_name_german;
            txtDescription_German.Text = assignmentRule.u_assignment_rules_desc_german;
            txtAssignmentRuleName_Japanese.Text = assignmentRule.u_assignment_rules_name_japanese;
            txtDescription_Japanese.Text = assignmentRule.u_assignment_rules_desc_japanese;
            txtAssignmentRuleName_Russian.Text = assignmentRule.u_assignment_rules_name_russian;
            txtDescription_Russian.Text = assignmentRule.u_assignment_rules_desc_russian;
            txtAssignmentRuleName_Danish.Text = assignmentRule.u_assignment_rules_name_danish;
            txtDescription_Danish.Text = assignmentRule.u_assignment_rules_desc_danish;
            txtAssignmentRuleName_Polish.Text = assignmentRule.u_assignment_rules_name_polish;
            txtDescription_Polish.Text = assignmentRule.u_assignment_rules_desc_polish;
            txtAssignmentRuleName_Swedish.Text = assignmentRule.u_assignment_rules_name_swedish;
            txtDescription_Swedish.Text = assignmentRule.u_assignment_rules_desc_swedish;
            txtAssignmentRuleName_Finnish.Text = assignmentRule.u_assignment_rules_name_finnish;
            txtDescription_Finnish.Text = assignmentRule.u_assignment_rules_desc_finnish;
            txtAssignmentRuleName_Korean.Text = assignmentRule.u_assignment_rules_name_korean;
            txtDescription_Korean.Text = assignmentRule.u_assignment_rules_desc_korean;
            txtAssignmentRuleName_Italian.Text = assignmentRule.u_assignment_rules_name_italian;
            txtDescription_Italian.Text = assignmentRule.u_assignment_rules_desc_italian;
            txtAssignmentRuleName_Dutch.Text = assignmentRule.u_assignment_rules_name_dutch;
            txtDescription_Dutch.Text = assignmentRule.u_assignment_rules_desc_dutch;
            txtAssignmentRuleName_Indonesian.Text = assignmentRule.u_assignment_rules_name_indonesian;
            txtDescription_Indonesian.Text = assignmentRule.u_assignment_rules_desc_indonesian;
            txtAssignmentRuleName_Greek.Text = assignmentRule.u_assignment_rules_name_greek;
            txtDescription_Greek.Text = assignmentRule.u_assignment_rules_desc_greek;
            txtAssignmentRuleName_Hungarian.Text = assignmentRule.u_assignment_rules_name_hungarian;
            txtDescription_Hungarian.Text = assignmentRule.u_assignment_rules_desc_hungarian;
            txtAssignmentRuleName_Norwegian.Text = assignmentRule.u_assignment_rules_name_norwegian;
            txtDescription_Norwegian.Text = assignmentRule.u_assignment_rules_desc_norwegian;
            txtAssignmentRuleName_Turkish.Text = assignmentRule.u_assignment_rules_name_turkish;
            txtDescription_Turkish.Text = assignmentRule.u_assignment_rules_desc_turkish;
            txtAssignmentRuleName_Arabic.Text = assignmentRule.u_assignment_rules_name_arabic;
            txtDescription_Arabic.Text = assignmentRule.u_assignment_rules_desc_arabic;
            txtAssignmentRuleName_Custom01.Text = assignmentRule.u_assignment_rules_name_custom_01;
            txtDescription_Custom01.Text = assignmentRule.u_assignment_rules_desc_custom_01;
            txtAssignmentRuleName_Custom02.Text = assignmentRule.u_assignment_rules_name_custom_02;
            txtDescription_Custom02.Text = assignmentRule.u_assignment_rules_desc_custom_02;
            txtAssignmentRuleName_Custom03.Text = assignmentRule.u_assignment_rules_name_custom_03;
            txtDescription_Custom03.Text = assignmentRule.u_assignment_rules_desc_custom_03;
            txtAssignmentRuleName_Custom04.Text = assignmentRule.u_assignment_rules_name_custom_04;
            txtDescription_Custom04.Text = assignmentRule.u_assignment_rules_desc_custom_04;
            txtAssignmentRuleName_Custom05.Text = assignmentRule.u_assignment_rules_name_custom_05;
            txtDescription_Custom05.Text = assignmentRule.u_assignment_rules_desc_custom_05;
            txtAssignmentRuleName_Custom06.Text = assignmentRule.u_assignment_rules_name_custom_06;
            txtDescription_Custom06.Text = assignmentRule.u_assignment_rules_desc_custom_06;
            txtAssignmentRuleName_Custom07.Text = assignmentRule.u_assignment_rules_name_custom_07;
            txtDescription_Custom07.Text = assignmentRule.u_assignment_rules_desc_custom_07;
            txtAssignmentRuleName_Custom08.Text = assignmentRule.u_assignment_rules_name_custom_08;
            txtDescription_Custom08.Text = assignmentRule.u_assignment_rules_desc_custom_08;
            txtAssignmentRuleName_Custom09.Text = assignmentRule.u_assignment_rules_name_custom_09;
            txtDescription_Custom09.Text = assignmentRule.u_assignment_rules_desc_custom_09;
            txtAssignmentRuleName_Custom10.Text = assignmentRule.u_assignment_rules_name_custom_10;
            txtDescription_Custom10.Text = assignmentRule.u_assignment_rules_desc_custom_10;
            txtAssignmentRuleName_Custom11.Text = assignmentRule.u_assignment_rules_name_custom_11;
            txtDescription_Custom11.Text = assignmentRule.u_assignment_rules_desc_custom_11;
            txtAssignmentRuleName_Custom12.Text = assignmentRule.u_assignment_rules_name_custom_12;
            txtDescription_Custom12.Text = assignmentRule.u_assignment_rules_desc_custom_12;
            txtAssignmentRuleName_Custom13.Text = assignmentRule.u_assignment_rules_name_custom_13;
            txtDescription_Custom13.Text = assignmentRule.u_assignment_rules_desc_custom_13;

            dtTempCatalogItem = SystemAssignmentRuleBLL.GetCatalogItems(assignmentRuleId);

            gvCatalogItems.DataSource = dtTempCatalogItem;
            gvCatalogItems.DataBind();

        }

        //Delete Course
        [System.Web.Services.WebMethod]
        public static void DeleteCatalog(string args)
        {
            try
            {           
                //Delete previous selected course
                var rows = dtTempCatalogItem.Select("u_assignment_rule_item_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                dtTempCatalogItem.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanarn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanarn-01", ex.Message);
                    }
                }
            }

        }

        protected void btnCatalogItems_Click(object sender, EventArgs e)
        {
            SaveNewAssignmentRule("catalog");
        }

        protected void btnNewGroups_Click(object sender, EventArgs e)
        {
            SaveNewAssignmentRule("group");
        }
    }
}