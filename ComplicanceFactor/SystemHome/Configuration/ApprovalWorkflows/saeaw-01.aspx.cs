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


namespace ComplicanceFactor.SystemHome.Configuration.ApprovalWorkflows
{
    public partial class saeaw_01 : System.Web.UI.Page
    {
        private static string editApprovalWorkflow;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Approval  Id
            if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
            {
                editApprovalWorkflow = SecurityCenter.DecryptText(Request.QueryString["edt"]);
            }
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_approval_workflow_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_approval_workflow_text") + "</a>";
                //Clear Session
                ClearCourseRelatedSession();
                if(!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"])== "true")
                {
                    divSuccess.Style.Add("display", "Block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editApprovalWorkflow = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdApprovalWorkflow.Value = editApprovalWorkflow;

                }
                try
                {
                    //Bind Approval
                    ddlFirstLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName,"saeaw-01");
                    ddlFirstLevelApprover.DataBind();
                    ddlSecondLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName, "saeaw-01");
                    ddlSecondLevelApprover.DataBind();
                    ddlThirdLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName, "saeaw-01");
                    ddlThirdLevelApprover.DataBind();
                    //Bind Status
                    ddlStatus.DataSource = SystemApprovalWorkflowBLL.GetApprovalWorkflowstatus(SessionWrapper.CultureName, "saeaw-01");
                    ddlStatus.DataBind();
                     

                    //Populate Approval workflow
                    PopulateApprovalWorkflow(editApprovalWorkflow);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeaw-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeaw-01", ex.Message);
                        }
                    }
                }

                
               
            }
            try
            {
                //Get Specific User first level
                if (!string.IsNullOrEmpty(SessionWrapper.s_specific_user_for_first_level_text))
                {
                    lblFirstLevelApprover.Text = SessionWrapper.s_specific_user_for_first_level_text;
                }
                // Get Specific User Second level
                if (!string.IsNullOrEmpty(SessionWrapper.s_specific_user_for_second_level_text))
                {
                    lblSecondLevelApprover.Text = SessionWrapper.s_specific_user_for_second_level_text;
                }
                //Get Specific User Third level
                if (!string.IsNullOrEmpty(SessionWrapper.s_specific_user_for_third_level_text))
                {
                    lblThirdLevelApprover.Text = SessionWrapper.s_specific_user_for_third_level_text;
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeaw-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeaw-01", ex.Message);
                    }
                }
            }
           

        }
        /// <summary>
        /// Populate Approval Workflow
        /// </summary>
        /// <param name="editApprovalWorkflow"></param>
        private void PopulateApprovalWorkflow(string editApprovalWorkflow)
        {
            SystemApprovalWorkflow approvalWorkFlow = new SystemApprovalWorkflow();
            approvalWorkFlow = SystemApprovalWorkflowBLL.GetApprovalWorkflow(editApprovalWorkflow);
            lblApprovalWorkflowId.Text = approvalWorkFlow.s_approval_workflow_id;
            ddlStatus.SelectedValue = approvalWorkFlow.s_approval_workflow_status_id_fk;
            ddlFirstLevelApprover.SelectedValue = approvalWorkFlow.s_first_level_approver_id_fk;
            ddlSecondLevelApprover.SelectedValue = approvalWorkFlow.s_second_level_approver_id_fk;
            ddlThirdLevelApprover.SelectedValue = approvalWorkFlow.s_third_level_approver_id_fk;
            chkFirstLevelApprover.Checked = approvalWorkFlow.s_first_level_status;
            chkSecondLevelApprover.Checked = approvalWorkFlow.s_second_level_status;
            chkThirdLevelApprover.Checked = approvalWorkFlow.s_third_level_status;
            txtApprovalWorkflowName.Text = approvalWorkFlow.s_approval_workflow_name_us_english;
            txtDescriptionUS.Value = approvalWorkFlow.s_approval_workflow_desc_us_english;
            txtApprovalWorkfkowNameUK.Text = approvalWorkFlow.s_approval_workflow_name_uk_english;
            txtDecriptionUK.Value = approvalWorkFlow.s_approval_workflow_desc_uk_english;
            txtApprovalWorkflowNameCA.Text = approvalWorkFlow.s_approval_workflow_name_ca_french;
            txtDecriptionCA.Value = approvalWorkFlow.s_approval_workflow_desc_ca_french;
            txtApprovalWorkflowNameFR.Text = approvalWorkFlow.s_approval_workflow_name_fr_french;
            txtDescriptionFR.Value = approvalWorkFlow.s_approval_workflow_desc_fr_french;
            txtApprovalWorkflowNameMX.Text = approvalWorkFlow.s_approval_workflow_name_mx_spanish;
            txtDescriptionMX.Value = approvalWorkFlow.s_approval_workflow_desc_mx_spanish;
            txtApprovalWorkflowNameSP.Text = approvalWorkFlow.s_approval_workflow_name_sp_spanish;
            txtDescriptionSP.Value = approvalWorkFlow.s_approval_workflow_desc_sp_spanish;
            txtApprovalWorkflowNamePortuguse.Text = approvalWorkFlow.s_approval_workflow_name_portuguese;
            txtDescriptionPortuguese.Value = approvalWorkFlow.s_approval_workflow_desc_portuguese;
            txtApprovalWorkflowNameGerman.Text = approvalWorkFlow.s_approval_workflow_name_german;
            txtDescriptionGerman.Value = approvalWorkFlow.s_approval_workflow_desc_german;
            txtApprovalWorkflowNameJapanese.Text = approvalWorkFlow.s_approval_workflow_name_japanese;
            txtDescriptionJapanese.Value = approvalWorkFlow.s_approval_workflow_desc_japanese;
            txtApprovalWorkflowNameRussian.Text = approvalWorkFlow.s_approval_workflow_name_russian;
            txtDescriptionRussian.Value = approvalWorkFlow.s_approval_workflow_desc_russian;
            txtApprovalWorkflowNameDanish.Text = approvalWorkFlow.s_approval_workflow_name_danish;
            txtDescriptionDanish.Value = approvalWorkFlow.s_approval_workflow_desc_danish;
            txtApprovalWorkflowNamePolish.Text = approvalWorkFlow.s_approval_workflow_name_polish;
            txtDescriptionPolish.Value = approvalWorkFlow.s_approval_workflow_desc_polish;
            txtApprovalWorkflowNameSwedish.Text = approvalWorkFlow.s_approval_workflow_name_swedish;
            txtDescriptionSwedish.Value = approvalWorkFlow.s_approval_workflow_desc_swedish;
            txtApprovalWorkflowNameFinnish.Text = approvalWorkFlow.s_approval_workflow_name_finnish;
            txtDescriptionFinnish.Value = approvalWorkFlow.s_approval_workflow_desc_finnish;
            txtApprovalWorkflowNameKorean.Text = approvalWorkFlow.s_approval_workflow_name_korean;
            txtDescriptionKorian.Value = approvalWorkFlow.s_approval_workflow_desc_korean;
            txtApprovalWorkflowNameItalian.Text = approvalWorkFlow.s_approval_workflow_name_italian;
            txtDescriptionItalian.Value = approvalWorkFlow.s_approval_workflow_desc_italian;
            txtApprovalWorkflowNameDutch.Text = approvalWorkFlow.s_approval_workflow_name_dutch;
            txtDescriptionDutch.Value = approvalWorkFlow.s_approval_workflow_desc_dutch;
            txtApprovalWorkflowNameIndonesian.Text = approvalWorkFlow.s_approval_workflow_name_indonesian;
            txtDescriptionIndonesian.Value = approvalWorkFlow.s_approval_workflow_desc_indonesian;
            txtApprovalWorkflowNameGreek.Text = approvalWorkFlow.s_approval_workflow_name_greek;
            txtDescriptionGreek.Value = approvalWorkFlow.s_approval_workflow_desc_greek;
            txtApprovalWorkflowNameHungarian.Text = approvalWorkFlow.s_approval_workflow_name_hungarian;
            txtDescriptionHungarian.Value = approvalWorkFlow.s_approval_workflow_desc_hungarian;
            txtApprovalWorkflowNameNorwegian.Text = approvalWorkFlow.s_approval_workflow_name_norwegian;
            txtDescriptionNorwegian.Value = approvalWorkFlow.s_approval_workflow_desc_norwegian;
            txtApprovalWorkflowNameTurkish.Text = approvalWorkFlow.s_approval_workflow_name_turkish;
            txtDescriptionTurkish.Value = approvalWorkFlow.s_approval_workflow_desc_turkish;
            txtApprovalWorkflowNameArabic.Text = approvalWorkFlow.s_approval_workflow_name_arabic_rtl;
            txtDescriptionArabic.Value = approvalWorkFlow.s_approval_workflow_desc_arabic_rtl;
            txtApprovalWorkflowNameCustom01.Text = approvalWorkFlow.s_approval_workflow_name_custom_01;
            txtDescriptionCustom01.Value = approvalWorkFlow.s_approval_workflow_desc_custom_01;
            txtApprovalWorkflowNameCustom02.Text = approvalWorkFlow.s_approval_workflow_name_custom_01;
            txtDescriptionCustom02.Value = approvalWorkFlow.s_approval_workflow_desc_custom_02;
            txtApprovalWorkflowNameCustom03.Text = approvalWorkFlow.s_approval_workflow_name_custom_03;
            txtDescriptionCustom03.Value = approvalWorkFlow.s_approval_workflow_desc_custom_03;
            txtApprovalWorkflowNameCustom04.Text = approvalWorkFlow.s_approval_workflow_name_custom_04;
            txtDescriptionCustom04.Value = approvalWorkFlow.s_approval_workflow_desc_custom_04;
            txtApprovalWorkflowNameCustom05.Text = approvalWorkFlow.s_approval_workflow_name_custom_05;
            txtDescriptionCustom05.Value = approvalWorkFlow.s_approval_workflow_desc_custom_05;
            txtApprovalWorkflowNameCustom06.Text = approvalWorkFlow.s_approval_workflow_name_custom_06;
            txtDescriptionCustom06.Value = approvalWorkFlow.s_approval_workflow_desc_custom_06;
            txtApprovalWorkflowNameCustom07.Text = approvalWorkFlow.s_approval_workflow_name_custom_07;
            txtDescriptionCustom07.Value = approvalWorkFlow.s_approval_workflow_desc_custom_07;
            txtApprovalWorkflowNameCustom08.Text = approvalWorkFlow.s_approval_workflow_name_custom_08;
            txtDescriptionCustom08.Value = approvalWorkFlow.s_approval_workflow_name_custom_08;
            txtApprovalWorkflowNameCustom09.Text = approvalWorkFlow.s_approval_workflow_name_custom_09;
            txtDescriptionCustom09.Value = approvalWorkFlow.s_approval_workflow_desc_custom_09;
            txtApprovalWorkflowNameCustom10.Text = approvalWorkFlow.s_approval_workflow_name_custom_10;
            txtDescriptionCustom10.Value = approvalWorkFlow.s_approval_workflow_desc_custom_10;
            txtApprovalWorkflowNameCustom11.Text = approvalWorkFlow.s_approval_workflow_name_custom_11;
            txtDescriptionCustom11.Value = approvalWorkFlow.s_approval_workflow_name_custom_11;
            txtApprovalWorkflowNameCustom12.Text = approvalWorkFlow.s_approval_workflow_name_custom_12;
            txtDescriptionCustom12.Value = approvalWorkFlow.s_approval_workflow_desc_custom_12;
            txtApprovalWorkflowNameCustom13.Text = approvalWorkFlow.s_approval_workflow_name_custom_13;
            txtDescriptionCustom13.Value = approvalWorkFlow.s_approval_workflow_desc_custom_13;
            txtApprovalWorkflowNameChinese.Text = approvalWorkFlow.s_approval_workflow_name_simp_chinese;
            txtDescriptionChinese.Value = approvalWorkFlow.s_approval_workflow_desc_simp_chinese;
            // set s_specific_user_for_first_level_approver
            SessionWrapper.s_specific_user_for_first_level_id_fk = approvalWorkFlow.s_first_level_approver_user_id_fk;
            lblFirstLevelApprover.Text = approvalWorkFlow.first_level_user_name;
            // set s_specific_user_for_first_level_approver
            SessionWrapper.s_specific_user_for_second_level_id_fk = approvalWorkFlow.s_second_level_approver_user_id_fk;
            lblSecondLevelApprover.Text = approvalWorkFlow.second_level_user_name;
            // set s_specific_user_for_first_level_approver
            SessionWrapper.s_specific_user_for_third_level_id_fk = approvalWorkFlow.s_third_level_approver_user_id_fk;
            lblThirdLevelApprover.Text = approvalWorkFlow.third_level_user_name;


        }
        /// <summary>
        /// Update Approval Workflow
        /// </summary>
        private void UpdateApprovalWorkflow()
        {
            SystemApprovalWorkflow updateApprovalWorkFlow = new SystemApprovalWorkflow();
            updateApprovalWorkFlow.s_approval_workflow_system_id_pk = editApprovalWorkflow;
            updateApprovalWorkFlow.s_approval_workflow_id = lblApprovalWorkflowId.Text;
            updateApprovalWorkFlow.s_approval_workflow_status_id_fk = ddlStatus.SelectedValue;
            updateApprovalWorkFlow.s_first_level_status = chkFirstLevelApprover.Checked;
            updateApprovalWorkFlow.s_second_level_status = chkSecondLevelApprover.Checked;
            updateApprovalWorkFlow.s_third_level_status = chkThirdLevelApprover.Checked;
            if (chkFirstLevelApprover.Checked == true)
            {
                updateApprovalWorkFlow.s_first_level_approver_id_fk = ddlFirstLevelApprover.SelectedValue;
                updateApprovalWorkFlow.s_first_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_first_level_id_fk;

            }
            else
            {
                updateApprovalWorkFlow.s_first_level_approver_id_fk = string.Empty;
                updateApprovalWorkFlow.s_first_level_approver_user_id_fk = string.Empty;
            }
            if (chkSecondLevelApprover.Checked == true)
            {
                updateApprovalWorkFlow.s_second_level_approver_id_fk = ddlSecondLevelApprover.SelectedValue;
                updateApprovalWorkFlow.s_second_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_second_level_id_fk;
            }
            else
            {
                updateApprovalWorkFlow.s_second_level_approver_id_fk = string.Empty;
                updateApprovalWorkFlow.s_second_level_approver_user_id_fk = string.Empty;
            }
            if (chkThirdLevelApprover.Checked == true)
            {
                updateApprovalWorkFlow.s_third_level_approver_id_fk = ddlThirdLevelApprover.SelectedValue;
                updateApprovalWorkFlow.s_third_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_third_level_id_fk;
            }
            else
            {
                updateApprovalWorkFlow.s_third_level_approver_id_fk = string.Empty;
                updateApprovalWorkFlow.s_third_level_approver_user_id_fk = string.Empty;
            }
            updateApprovalWorkFlow.s_approval_workflow_name_us_english = txtApprovalWorkflowName.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_us_english = txtDescriptionUS.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_uk_english = txtApprovalWorkfkowNameUK.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_uk_english = txtDecriptionUK.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_ca_french = txtApprovalWorkflowNameCA.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_ca_french = txtDecriptionCA.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_fr_french = txtApprovalWorkflowNameFR.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_fr_french = txtDescriptionFR.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_mx_spanish = txtApprovalWorkflowNameMX.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_mx_spanish = txtDescriptionMX.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_sp_spanish = txtApprovalWorkflowNameSP.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_sp_spanish = txtDescriptionSP.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_portuguese = txtApprovalWorkflowNamePortuguse.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_portuguese = txtDescriptionPortuguese.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_german = txtApprovalWorkflowNameGerman.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_german = txtDescriptionGerman.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_japanese = txtApprovalWorkflowNameJapanese.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_japanese = txtDescriptionJapanese.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_russian = txtApprovalWorkflowNameRussian.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_russian = txtDescriptionRussian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_danish = txtApprovalWorkflowNameDanish.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_danish = txtDescriptionDanish.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_polish = txtApprovalWorkflowNamePolish.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_polish = txtDescriptionPolish.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_swedish = txtApprovalWorkflowNameSwedish.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_swedish = txtDescriptionSwedish.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_finnish = txtApprovalWorkflowNameFinnish.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_finnish = txtDescriptionFinnish.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_korean = txtApprovalWorkflowNameKorean.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_korean = txtDescriptionKorian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_italian = txtApprovalWorkflowNameItalian.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_italian = txtDescriptionItalian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_dutch = txtApprovalWorkflowNameDutch.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_dutch = txtDescriptionDutch.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_indonesian = txtApprovalWorkflowNameIndonesian.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_indonesian = txtDescriptionIndonesian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_greek = txtApprovalWorkflowNameGreek.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_greek = txtDescriptionGreek.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_hungarian = txtApprovalWorkflowNameHungarian.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_hungarian = txtDescriptionHungarian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_norwegian = txtApprovalWorkflowNameNorwegian.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_norwegian = txtDescriptionNorwegian.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_turkish = txtApprovalWorkflowNameTurkish.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_turkish = txtDescriptionTurkish.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_arabic_rtl = txtApprovalWorkflowNameArabic.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_01 = txtApprovalWorkflowNameCustom01.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_01 = txtDescriptionCustom01.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_02 = txtApprovalWorkflowNameCustom02.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_02 = txtDescriptionCustom02.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_03 = txtApprovalWorkflowNameCustom03.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_03 = txtDescriptionCustom03.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_04 = txtApprovalWorkflowNameCustom04.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_04 = txtDescriptionCustom04.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_05 = txtApprovalWorkflowNameCustom05.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_05 = txtDescriptionCustom05.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_06 = txtApprovalWorkflowNameCustom06.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_06 = txtDescriptionCustom06.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_07 = txtApprovalWorkflowNameCustom07.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_07 = txtDescriptionCustom07.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_08 = txtApprovalWorkflowNameCustom08.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_08 = txtDescriptionCustom08.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_09 = txtApprovalWorkflowNameCustom09.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_09 = txtDescriptionCustom09.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_10 = txtApprovalWorkflowNameCustom10.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_10 = txtDescriptionCustom10.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_11 = txtApprovalWorkflowNameCustom11.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_11 = txtDescriptionCustom11.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_12 = txtApprovalWorkflowNameCustom12.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_12 = txtDescriptionCustom12.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_custom_13 = txtApprovalWorkflowNameCustom13.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_custom_13 = txtDescriptionCustom13.Value;
            updateApprovalWorkFlow.s_approval_workflow_name_simp_chinese = txtApprovalWorkflowNameChinese.Text;
            updateApprovalWorkFlow.s_approval_workflow_desc_simp_chinese = txtDescriptionChinese.Value;
            int error;
            error = SystemApprovalWorkflowBLL.UpdateApprovalWorkflow(updateApprovalWorkFlow);
            if (error != -2)
            {
                //Show success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
            }
            else
            {
                ///<summary>
                ///Show error message 
                ///</summary>
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_approval_workflow_id_already_exist_error_wrong");
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx", false);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx", false);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderSaveNewApprovalWorkflow_Click(object sender, EventArgs e)
        {
            UpdateApprovalWorkflow();
        }

        protected void btnFooterSaveNewApprovalWorkflow_Click(object sender, EventArgs e)
        {
            UpdateApprovalWorkflow();
        }
        private void ClearCourseRelatedSession()
        {
            SessionWrapper.s_specific_user_for_first_level_id_fk = "";
            SessionWrapper.s_specific_user_for_first_level_text = "";

            SessionWrapper.s_specific_user_for_second_level_id_fk = "";
            SessionWrapper.s_specific_user_for_second_level_text = "";

            SessionWrapper.s_specific_user_for_third_level_id_fk = "";
            SessionWrapper.s_specific_user_for_third_level_text = "";
        }
    }
}