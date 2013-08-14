using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentRules
{
    public partial class saear_01 : System.Web.UI.Page
    {
        private static string editassignmentRuleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/AssignmentRules/samarmp-01.aspx>" + "Manage Training" + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Edit Assignment Rule" + "</a>";


                SessionWrapper.AssignmentRule_CatalogItem = TempDataTables.TempAssignmentRuleCatalogItem();
                SessionWrapper.AssignmentRule_Group = TempDataTables.TempAssignmentRuleGroup();
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    //TO-DO SHOW THE MESSAGE WHETHER 'SUCCESSFULLY INSERTED OR UPDATED IN A MESSAGE DIV'
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Inserted Successfully";//LocalResources.GetText("app_succ_insert_text");                     
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editassignmentRuleId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdnEditAssignmentRule.Value = editassignmentRuleId;
                }
                //Bind status
                ddlStatus.DataSource = SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName, "saegs-01");
                ddlStatus.DataBind();

                SessionWrapper.Reset_AssignmentRule_CatalogItem = SystemAssignmentRuleBLL.GetCatalogItems(editassignmentRuleId);
                SessionWrapper.Reset_AssignmentRule_Group = SystemAssignmentRuleBLL.GetAssignmentGroups(editassignmentRuleId);

                PopulateAssignmentRule(editassignmentRuleId);

                if (!string.IsNullOrEmpty(Request.QueryString["process"]) && SecurityCenter.DecryptText(Request.QueryString["process"]) == "catalog")
                {

                }
                else if (!string.IsNullOrEmpty(Request.QueryString["process"]) && SecurityCenter.DecryptText(Request.QueryString["process"]) == "group")
                {

                }
            }
            gvCatalogItems.DataSource = SystemAssignmentRuleBLL.GetCatalogItems(editassignmentRuleId);
            gvCatalogItems.DataBind();

            gvAssignmentGroups.DataSource = SystemAssignmentRuleBLL.GetAssignmentGroups(editassignmentRuleId);
            gvAssignmentGroups.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CatalogItemsgroups", "lastCatalogItemsrow();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Assignmentgroups", "lastGroupItemsrow();", true);

        }
        /// <summary>
        /// PopulateAssignmentRule
        /// </summary>
        /// <param name="assignmentRuleId"></param>
        private void PopulateAssignmentRule(string assignmentRuleId)
        {
            SystemAssignmentRules assignmentRule = new SystemAssignmentRules();
            assignmentRule = SystemAssignmentRuleBLL.GetAssignmentRule(assignmentRuleId);

            txtAssignmentRuleId_EnglishUs.Text = assignmentRule.u_assignment_rules_id_pk;
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

            gvCatalogItems.DataSource = SystemAssignmentRuleBLL.GetCatalogItems(assignmentRuleId);
            gvCatalogItems.DataBind();

            gvAssignmentGroups.DataSource = SystemAssignmentRuleBLL.GetAssignmentGroups(assignmentRuleId);
            gvAssignmentGroups.DataBind();



            //SessionWrapper.AssignmentRule_CatalogItem = SystemAssignmentRuleBLL.GetCatalogItems(assignmentRuleId);
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            UpdateAssignmentRule();
        }

        protected void btnFooterSaveAssignmentRule_Click(object sender, EventArgs e)
        {
            UpdateAssignmentRule();
        }
        /// <summary>
        /// Update Assignment Rule
        /// </summary>
        private void UpdateAssignmentRule()
        {
            SystemAssignmentRules updateAssignmentRules = new SystemAssignmentRules();
            updateAssignmentRules.u_assignment_rules_system_id_pk = editassignmentRuleId;
            updateAssignmentRules.u_assignment_rules_id_pk = txtAssignmentRuleId_EnglishUs.Text;
            updateAssignmentRules.u_assignment_rules_name = txtAssignmentRuleName_EnglishUs.Text;
            updateAssignmentRules.u_assignment_rules_status_id_fk = ddlStatus.SelectedValue;

            updateAssignmentRules.u_assignment_rules_desc = txtAssignmentDescriptionUS.Text;

            updateAssignmentRules.u_assignment_rules_required_flag = chkRequired.Checked;
            if (rbtTagetduedate.Checked == true)
            {
                updateAssignmentRules.u_assignment_rules_due_select_param = "1";
            }
            else
            {
                updateAssignmentRules.u_assignment_rules_due_select_param = "2";
            }
            if (!string.IsNullOrEmpty(txtTargetduedate.Text))
            {
                updateAssignmentRules.u_assignment_rules_fix_date_param = Convert.ToDateTime(txtTargetduedate.Text);
            }
            if (!string.IsNullOrEmpty(txtDue.Text))
            {
                updateAssignmentRules.u_assignment_rules_days_param = Convert.ToInt16(txtDue.Text);
            }

            updateAssignmentRules.u_assignment_rules_name_uk_english = txtAssignmentRuleUk.Text;
            updateAssignmentRules.u_assignment_rules_desc_uk_english = txtDescriptionUk.Text;
            updateAssignmentRules.u_assignment_rules_name_ca_french = txtAssignmentRuleName_FrenchCa.Text;
            updateAssignmentRules.u_assignment_rules_desc_ca_french = txtDescription_FrenchCa.Text;
            updateAssignmentRules.u_assignment_rules_name_fr_french = txtAssignmentRuleName_FrenchFr.Text;
            updateAssignmentRules.u_assignment_rules_desc_fr_french = txtDescription_FrenchFr.Text;
            updateAssignmentRules.u_assignment_rules_name_mx_spanish = txtAssignmentRuleName_SpanishMx.Text;
            updateAssignmentRules.u_assignment_rules_desc_mx_spanish = txtDescription_SpanishMx.Text;
            updateAssignmentRules.u_assignment_rules_name_sp_spanish = txtAssignmentRuleName_SpanishSp.Text;
            updateAssignmentRules.u_assignment_rules_desc_sp_spanish = txtDescription_SpanishSp.Text;
            updateAssignmentRules.u_assignment_rules_name_portuguese = txtAssignmentRuleName_Portuguese.Text;
            updateAssignmentRules.u_assignment_rules_desc_portuguese = txtDescription_Portuguese.Text;
            updateAssignmentRules.u_assignment_rules_name_simp_chinese = txtAssignmentRuleName_Chinese.Text;
            updateAssignmentRules.u_assignment_rules_desc_simp_chinese = txtDescription_Chinese.Text;
            updateAssignmentRules.u_assignment_rules_name_german = txtAssignmentRuleName_German.Text;
            updateAssignmentRules.u_assignment_rules_desc_german = txtDescription_German.Text;
            updateAssignmentRules.u_assignment_rules_name_japanese = txtAssignmentRuleName_Japanese.Text;
            updateAssignmentRules.u_assignment_rules_desc_japanese = txtDescription_Japanese.Text;
            updateAssignmentRules.u_assignment_rules_name_russian = txtAssignmentRuleName_Russian.Text;
            updateAssignmentRules.u_assignment_rules_desc_russian = txtDescription_Russian.Text;
            updateAssignmentRules.u_assignment_rules_name_danish = txtAssignmentRuleName_Danish.Text;
            updateAssignmentRules.u_assignment_rules_desc_danish = txtDescription_Danish.Text;
            updateAssignmentRules.u_assignment_rules_name_polish = txtAssignmentRuleName_Polish.Text;
            updateAssignmentRules.u_assignment_rules_desc_polish = txtDescription_Polish.Text;
            updateAssignmentRules.u_assignment_rules_name_swedish = txtAssignmentRuleName_Swedish.Text;
            updateAssignmentRules.u_assignment_rules_desc_swedish = txtDescription_Swedish.Text;
            updateAssignmentRules.u_assignment_rules_name_finnish = txtAssignmentRuleName_Finnish.Text;
            updateAssignmentRules.u_assignment_rules_desc_finnish = txtDescription_Finnish.Text;
            updateAssignmentRules.u_assignment_rules_name_korean = txtAssignmentRuleName_Korean.Text;
            updateAssignmentRules.u_assignment_rules_desc_korean = txtDescription_Korean.Text;
            updateAssignmentRules.u_assignment_rules_name_italian = txtAssignmentRuleName_Italian.Text;
            updateAssignmentRules.u_assignment_rules_desc_italian = txtDescription_Italian.Text;
            updateAssignmentRules.u_assignment_rules_name_dutch = txtAssignmentRuleName_Dutch.Text;
            updateAssignmentRules.u_assignment_rules_desc_dutch = txtDescription_Dutch.Text;
            updateAssignmentRules.u_assignment_rules_name_indonesian = txtAssignmentRuleName_Indonesian.Text;
            updateAssignmentRules.u_assignment_rules_desc_indonesian = txtDescription_Indonesian.Text;
            updateAssignmentRules.u_assignment_rules_name_greek = txtAssignmentRuleName_Greek.Text;
            updateAssignmentRules.u_assignment_rules_desc_greek = txtDescription_Greek.Text;
            updateAssignmentRules.u_assignment_rules_name_hungarian = txtAssignmentRuleName_Hungarian.Text;
            updateAssignmentRules.u_assignment_rules_desc_hungarian = txtDescription_Hungarian.Text;
            updateAssignmentRules.u_assignment_rules_name_norwegian = txtAssignmentRuleName_Norwegian.Text;
            updateAssignmentRules.u_assignment_rules_desc_norwegian = txtDescription_Norwegian.Text;
            updateAssignmentRules.u_assignment_rules_name_turkish = txtAssignmentRuleName_Turkish.Text;
            updateAssignmentRules.u_assignment_rules_desc_turkish = txtDescription_Turkish.Text;
            updateAssignmentRules.u_assignment_rules_name_arabic = txtAssignmentRuleName_Arabic.Text;
            updateAssignmentRules.u_assignment_rules_desc_arabic = txtDescription_Arabic.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_01 = txtAssignmentRuleName_Custom01.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_01 = txtDescription_Custom01.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_02 = txtAssignmentRuleName_Custom02.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_02 = txtDescription_Custom02.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_03 = txtAssignmentRuleName_Custom03.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_03 = txtDescription_Custom03.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_04 = txtAssignmentRuleName_Custom04.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_04 = txtDescription_Custom04.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_05 = txtAssignmentRuleName_Custom05.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_05 = txtDescription_Custom05.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_06 = txtAssignmentRuleName_Custom06.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_06 = txtDescription_Custom06.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_07 = txtAssignmentRuleName_Custom07.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_07 = txtDescription_Custom07.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_08 = txtAssignmentRuleName_Custom08.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_08 = txtDescription_Custom08.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_09 = txtAssignmentRuleName_Custom09.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_09 = txtDescription_Custom09.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_10 = txtAssignmentRuleName_Custom10.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_10 = txtDescription_Custom10.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_11 = txtAssignmentRuleName_Custom11.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_11 = txtDescription_Custom11.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_12 = txtAssignmentRuleName_Custom12.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_12 = txtDescription_Custom12.Text;
            updateAssignmentRules.u_assignment_rules_name_custom_13 = txtAssignmentRuleName_Custom13.Text;
            updateAssignmentRules.u_assignment_rules_desc_custom_13 = txtDescription_Custom13.Text;

            int error = SystemAssignmentRuleBLL.UpdateAssignmentRule(updateAssignmentRules);
            if (error != -2)
            {
                AssignCourseCurriculum();
                //TO-DO show div with success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = "Updated Successfully";//LocalResources.GetText("app_succ_update_text");

            }
            else
            {
                //TO-DO show div with error message                 
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerHtml = "Assignment Rule Id already Exists";//LocalResources.GetText("app_grading_scheme_id_already_exists_error_text");

            }


        }

        //Delete Course
        [System.Web.Services.WebMethod]
        public static void DeleteCatalog(string args)
        {
            try
            {
                int result = SystemAssignmentRuleBLL.DeleteCatalog(args.Trim());

                //Delete previous selected course
                //var rows = SessionWrapper.AssignmentRule_CatalogItem.Select("u_assignment_rule_item_system_id_pk= '" + args.Trim() + "'");
                //foreach (var row in rows)
                //    row.Delete();
                //SessionWrapper.AssignmentRule_CatalogItem.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message);
                    }
                }
            }

        }

        //Delete Group
        [System.Web.Services.WebMethod]
        public static void DeleteGroup(string args)
        {
            try
            {
                int result = SystemAssignmentRuleBLL.DeleteGroup(args.Trim());

                //Delete previous selected course
                //var rows = SessionWrapper.AssignmentRule_CatalogItem.Select("u_assignment_rule_item_system_id_pk= '" + args.Trim() + "'");
                //foreach (var row in rows)
                //    row.Delete();
                //SessionWrapper.AssignmentRule_CatalogItem.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Reset
        /// </summary>
        private void Reset()
        {
            ConvertDataTables cv = new ConvertDataTables();

            try
            {
                int result = SystemAssignmentRuleBLL.ResetCatalogItemForRule(cv.ConvertDataTableToXml(SessionWrapper.Reset_AssignmentRule_CatalogItem), editassignmentRuleId);

                int groupResult = SystemAssignmentRuleBLL.ResetGroupsForRule(cv.ConvertDataTableToXml(SessionWrapper.Reset_AssignmentRule_Group), editassignmentRuleId);

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saear-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Assign Course and Curriculum 
        /// </summary>
        private void AssignCourseCurriculum()
        {
            DataTable dtCatalogItems = new DataTable();
            DataTable dtGroupUsers = new DataTable();

            DataTable dtCourse = TempDataTables.TempCourseAssignDatatable();
            DataTable dtCurriculum = TempDataTables.TempCurriculumDatatable();

            dtCatalogItems = SystemAssignmentRuleBLL.GetCatalogItems(editassignmentRuleId);
            dtGroupUsers = SystemAssignmentRuleBLL.GetUsersAssignmentGroups(editassignmentRuleId);

            if (dtCatalogItems.Rows.Count > 0)
            {
                for (int i = 0; i < dtCatalogItems.Rows.Count; i++)
                {
                    for (int j = 0; j < dtGroupUsers.Rows.Count; j++)
                    {
                        if (dtCatalogItems.Rows[i]["type"].ToString() == "Course")
                        {
                            DataRow courserow;
                            courserow = dtCourse.NewRow();
                            courserow["course_id"] = dtCatalogItems.Rows[i]["u_assignment_rule_item_id_fk"].ToString();
                            courserow["checked"] = chkRequired.Checked;
                            courserow["employeeID"] = dtGroupUsers.Rows[j]["u_assignment_group_user_id_fk"].ToString();
                            courserow["required"] = chkRequired.Checked;
                            if (!string.IsNullOrEmpty(txtTargetduedate.Text))
                            {
                                courserow["DueDate"] = txtTargetduedate.Text;
                            }
                            dtCourse.Rows.Add(courserow);
                        }
                        else if (dtCatalogItems.Rows[i]["type"].ToString() == "Curriculum")
                        {
                            DataRow curriculumrow;
                            curriculumrow = dtCurriculum.NewRow();
                            curriculumrow["curriculum_id"] = dtCatalogItems.Rows[i]["u_assignment_rule_curriculum_item_id_fk"].ToString();
                            curriculumrow["employeeID"] = dtGroupUsers.Rows[j]["u_assignment_group_user_id_fk"].ToString();
                            curriculumrow["required"] = chkRequired.Checked;
                            if (!string.IsNullOrEmpty(txtTargetduedate.Text))
                            {
                                curriculumrow["DueDate"] = txtTargetduedate.Text;
                            }
                            dtCurriculum.Rows.Add(curriculumrow);
                        }
                    }
                }
                ConvertDataTables ConvertToXml = new ConvertDataTables();
                DataTable dtSingleOLTCourseFromCurriculum = SystemAssignmentRuleBLL.CourseCurriculumAssign(ConvertToXml.ConvertDataTableToXml(dtCourse), ConvertToXml.ConvertDataTableToXml(dtCurriculum), SessionWrapper.u_userid);         
            }
        }
    }
}