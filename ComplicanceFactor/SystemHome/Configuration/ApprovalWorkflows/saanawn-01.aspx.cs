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
    public partial class saanawn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_approval_workflow_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_approval_workflow_text");

                ClearCourseRelatedSession();


                try
                {
                    lblApprovalWorkflowId.Text = GetsequenceId();
                    //Bind Status
                    ddlStatus.DataSource = SystemApprovalWorkflowBLL.GetApprovalWorkflowstatus(SessionWrapper.CultureName, "saanawn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind Approval
                    ddlFirstLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName, "saanawn-01");
                    ddlFirstLevelApprover.DataBind();
                    ddlSecondLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName, "saanawn-01");
                    ddlSecondLevelApprover.DataBind();
                    ddlThirdLevelApprover.DataSource = SystemApprovalWorkflowBLL.GetApproval(SessionWrapper.CultureName, "saanawn-01");
                    ddlThirdLevelApprover.DataBind();
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateApprovalWorkflow(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
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
                            Logger.WriteToErrorLog("saanawn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saanawn-01", ex.Message);
                        }
                    }

                }
            }
            try
            {
                lblFirstLevelApprover.Text = SessionWrapper.s_specific_user_for_first_level_text;
                lblSecondLevelApprover.Text = SessionWrapper.s_specific_user_for_second_level_text;
                lblThirdLevelApprover.Text = SessionWrapper.s_specific_user_for_third_level_text;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanawn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanawn-01", ex.Message);
                    }
                }
            }
        }

        private void SaveApprovalWorkflow()
        {
            SystemApprovalWorkflow createApprovalWorkFlow = new SystemApprovalWorkflow();
            createApprovalWorkFlow.s_approval_workflow_system_id_pk = Guid.NewGuid().ToString();

            //ComplianceDAO miris = new ComplianceDAO();
            //miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
            //IncidentTime.Date = DateTime.Now;
            //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
           // SessionWrapper.casedate = miris.c_temp_case_date;
            //lblCaseDate.Text = SessionWrapper.casedate.ToString("MM/dd/yyyy hh:mm tt");
            lblApprovalWorkflowId.Text = GetsequenceId();
            createApprovalWorkFlow.s_approval_workflow_id = lblApprovalWorkflowId.Text;
            createApprovalWorkFlow.s_approval_workflow_status_id_fk = ddlStatus.SelectedValue;
            createApprovalWorkFlow.s_first_level_status = chkFirstLevelApprover.Checked;
            createApprovalWorkFlow.s_second_level_status = chkSecondLevelApprover.Checked;
            createApprovalWorkFlow.s_third_level_status = chkThirdLevelApprover.Checked;
            if (chkFirstLevelApprover.Checked == true)
            {
                createApprovalWorkFlow.s_first_level_approver_id_fk = ddlFirstLevelApprover.SelectedValue;
                createApprovalWorkFlow.s_first_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_first_level_id_fk;
                
            }
            else
            {
                createApprovalWorkFlow.s_first_level_approver_id_fk = string.Empty;
                createApprovalWorkFlow.s_first_level_approver_user_id_fk = string.Empty;
            }
            if (chkSecondLevelApprover.Checked == true)
            {
                createApprovalWorkFlow.s_second_level_approver_id_fk = ddlSecondLevelApprover.SelectedValue;
                createApprovalWorkFlow.s_second_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_second_level_id_fk;
            }
            else
            {
                createApprovalWorkFlow.s_second_level_approver_id_fk = string.Empty;
                createApprovalWorkFlow.s_second_level_approver_user_id_fk = string.Empty;
            }
            if (chkThirdLevelApprover.Checked == true)
            {
                createApprovalWorkFlow.s_third_level_approver_id_fk = ddlThirdLevelApprover.SelectedValue;
                createApprovalWorkFlow.s_third_level_approver_user_id_fk = SessionWrapper.s_specific_user_for_third_level_id_fk;
            }
            else
            {
                createApprovalWorkFlow.s_third_level_approver_id_fk = string.Empty;
                createApprovalWorkFlow.s_third_level_approver_user_id_fk = string.Empty;
            }
            createApprovalWorkFlow.s_approval_workflow_name_us_english = txtApprovalWorkflowName.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_us_english = txtDescriptionUS.Value;
            createApprovalWorkFlow.s_approval_workflow_name_uk_english = txtApprovalWorkflowNameUK.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_uk_english = txtDecriptionUK.Value;
            createApprovalWorkFlow.s_approval_workflow_name_ca_french = txtApprovalWorkflowNameCA.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_ca_french = txtDecriptionCA.Value;
            createApprovalWorkFlow.s_approval_workflow_name_fr_french = txtApprovalWorkflowNameFR.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_fr_french = txtDescriptionFR.Value;
            createApprovalWorkFlow.s_approval_workflow_name_mx_spanish = txtApprovalWorkflowNameMX.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_mx_spanish = txtDescriptionMX.Value;
            createApprovalWorkFlow.s_approval_workflow_name_sp_spanish = txtApprovalWorkflowNameSP.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_sp_spanish = txtDescriptionSP.Value;
            createApprovalWorkFlow.s_approval_workflow_name_portuguese = txtApprovalWorkflowNamePortuguse.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_portuguese = txtDescriptionPortuguese.Value;
            createApprovalWorkFlow.s_approval_workflow_name_german = txtApprovalWorkflowNameGerman.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_german = txtDescriptionGerman.Value;
            createApprovalWorkFlow.s_approval_workflow_name_japanese = txtApprovalWorkflowNameJapanese.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_japanese = txtDescriptionJapanese.Value;
            createApprovalWorkFlow.s_approval_workflow_name_russian = txtApprovalWorkflowNameRussian.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_russian = txtDescriptionRussian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_danish = txtApprovalWorkflowNameDanish.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_danish = txtDescriptionDanish.Value;
            createApprovalWorkFlow.s_approval_workflow_name_polish = txtApprovalWorkflowNamePolish.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_polish = txtDescriptionPolish.Value;
            createApprovalWorkFlow.s_approval_workflow_name_swedish = txtApprovalWorkflowNameSwedish.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_swedish = txtDescriptionSwedish.Value;
            createApprovalWorkFlow.s_approval_workflow_name_finnish = txtApprovalWorkflowNameFinnish.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_finnish = txtDescriptionFinnish.Value;
            createApprovalWorkFlow.s_approval_workflow_name_korean = txtApprovalWorkflowNameKorean.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_korean = txtDescriptionKorian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_italian = txtApprovalWorkflowNameItalian.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_italian = txtDescriptionItalian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_dutch = txtApprovalWorkflowNameDutch.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_dutch = txtDescriptionDutch.Value;
            createApprovalWorkFlow.s_approval_workflow_name_indonesian = txtApprovalWorkflowNameIndonesian.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_indonesian = txtDescriptionIndonesian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_greek = txtApprovalWorkflowNameGreek.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_greek = txtDescriptionGreek.Value;
            createApprovalWorkFlow.s_approval_workflow_name_hungarian = txtApprovalWorkflowNameHungarian.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_hungarian = txtDescriptionHungarian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_norwegian = txtApprovalWorkflowNameNorwegian.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_norwegian = txtDescriptionNorwegian.Value;
            createApprovalWorkFlow.s_approval_workflow_name_turkish = txtApprovalWorkflowNameTurkish.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_turkish = txtDescriptionTurkish.Value;
            createApprovalWorkFlow.s_approval_workflow_name_arabic_rtl = txtApprovalWorkflowNameArabic.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_arabic_rtl = txtDescriptionArabic.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_01 = txtApprovalWorkflowNameCustom01.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_01 = txtDescriptionCustom01.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_02 = txtApprovalWorkflowNameCustom02.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_02 = txtDescriptionCustom02.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_03 = txtApprovalWorkflowNameCustom03.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_03 = txtDescriptionCustom03.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_04 = txtApprovalWorkflowNameCustom04.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_04 = txtDescriptionCustom04.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_05 = txtApprovalWorkflowNameCustom05.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_05 = txtDescriptionCustom05.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_06 = txtApprovalWorkflowNameCustom06.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_06 = txtDescriptionCustom06.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_07 = txtApprovalWorkflowNameCustom07.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_07 = txtDescriptionCustom07.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_08 = txtApprovalWorkflowNameCustom08.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_08 = txtDescriptionCustom08.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_09 = txtApprovalWorkflowNameCustom09.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_09 = txtDescriptionCustom09.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_10 = txtApprovalWorkflowNameCustom10.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_10 = txtDescriptionCustom10.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_11 = txtApprovalWorkflowNameCustom11.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_11 = txtDescriptionCustom11.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_12 = txtApprovalWorkflowNameCustom12.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_12 = txtDescriptionCustom12.Value;
            createApprovalWorkFlow.s_approval_workflow_name_custom_13 = txtApprovalWorkflowNameCustom13.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_custom_13 = txtDescriptionCustom13.Value;
            createApprovalWorkFlow.s_approval_workflow_name_simp_chinese = txtApprovalWorkflowNameChinese.Text;
            createApprovalWorkFlow.s_approval_workflow_desc_simp_chinese = txtDescriptionChinese.Value;
            
            int error;
            error = SystemApprovalWorkflowBLL.CreateApprovalWorkflow(createApprovalWorkFlow);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/ApprovalWorkflows/saeaw-01.aspx?id=" + SecurityCenter.EncryptText(createApprovalWorkFlow.s_approval_workflow_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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

        private void PopulateApprovalWorkflow(string approvalWorkflowId)
        {
            ClearCourseRelatedSession();

            SystemApprovalWorkflow approvalWorkFlow = new SystemApprovalWorkflow();
            approvalWorkFlow = SystemApprovalWorkflowBLL.GetApprovalWorkflow(approvalWorkflowId);
            lblApprovalWorkflowId.Text = GetsequenceId();
            //txtApprovalWorkflowId.Text = approvalWorkFlow.s_approval_workflow_id + "_Copy";
            ddlStatus.SelectedValue = approvalWorkFlow.s_approval_workflow_status_id_fk;
            ddlFirstLevelApprover.SelectedValue = approvalWorkFlow.s_first_level_approver_id_fk;
            ddlSecondLevelApprover.SelectedValue = approvalWorkFlow.s_second_level_approver_id_fk;
            ddlThirdLevelApprover.SelectedValue = approvalWorkFlow.s_third_level_approver_id_fk;
            lblFirstLevelApprover.Text = approvalWorkFlow.first_level_user_name;
            lblSecondLevelApprover.Text = approvalWorkFlow.second_level_user_name;
            lblThirdLevelApprover.Text = approvalWorkFlow.third_level_user_name;
            chkFirstLevelApprover.Checked = approvalWorkFlow.s_first_level_status;
            chkSecondLevelApprover.Checked = approvalWorkFlow.s_second_level_status;
            chkThirdLevelApprover.Checked = approvalWorkFlow.s_third_level_status;
            txtApprovalWorkflowName.Text = approvalWorkFlow.s_approval_workflow_name_us_english;
            txtDescriptionUS.Value = approvalWorkFlow.s_approval_workflow_desc_us_english;
            txtApprovalWorkflowNameUK.Text = approvalWorkFlow.s_approval_workflow_name_uk_english;
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
            SessionWrapper.s_specific_user_for_first_level_text = approvalWorkFlow.first_level_user_name;
            // set s_specific_user_for_first_level_approver
            SessionWrapper.s_specific_user_for_second_level_id_fk = approvalWorkFlow.s_second_level_approver_user_id_fk;
            SessionWrapper.s_specific_user_for_second_level_text = approvalWorkFlow.second_level_user_name;
            // set s_specific_user_for_first_level_approver
            SessionWrapper.s_specific_user_for_third_level_id_fk = approvalWorkFlow.s_third_level_approver_user_id_fk;
            SessionWrapper.s_specific_user_for_third_level_text = approvalWorkFlow.third_level_user_name;

        }

        protected void btnHeaderSaveNewApprovalWorkflow_Click(object sender, EventArgs e)
        {
            SaveApprovalWorkflow();
        }

        protected void btnFooterSaveNewApprovalWorkflow_Click(object sender, EventArgs e)
        {
            SaveApprovalWorkflow();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx", false);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ApprovalWorkflows/samawmp-01.aspx", false);
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

        private static string GetsequenceId()
        {
            SystemApprovalWorkflow approval= new SystemApprovalWorkflow();
            approval = SystemApprovalWorkflowBLL.GetApprovalWorkflowId();
            return approval.s_approval_workflow_id;
        }
    }
}