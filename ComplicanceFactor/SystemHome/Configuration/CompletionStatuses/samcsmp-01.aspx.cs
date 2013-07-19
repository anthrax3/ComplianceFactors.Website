using System;
using System.Data;
using System.Data.SqlClient;
using ComplicanceFactor.BusinessComponent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Completion_Statuses
{
    public partial class samcsmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the values into the label values.
                bindLabels();
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/Configuration/sascmp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp; " + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_manage_completion_statuses_text") + "</a>";
                
               
            }

        }

        private void bindLabels()
        {
            DataSet dsCompletionStatuses = new DataSet();
            DataTable dtCompletionStatuses = new DataTable();
            DataTable dtCompletionsStatusesFlag = new DataTable();
           
            dsCompletionStatuses = SystemCompletionStatusesBLL.GetLocalCompletionStatuses();
            DataView dvCompletionStatuses = new DataView(dsCompletionStatuses.Tables[0]);

            dtCompletionStatuses =  dsCompletionStatuses.Tables[0];
            dtCompletionsStatusesFlag = dsCompletionStatuses.Tables[1];

            hfldAssignId.Value = dtCompletionStatuses.Rows[0]["s_ui_dropdown_id_pk"].ToString();
            txtlblAssigned.Text = dtCompletionStatuses.Rows[0]["s_ui_dropdown_us_english"].ToString();

            hfldAttended.Value = dtCompletionStatuses.Rows[1]["s_ui_dropdown_id_pk"].ToString();
            txtlblAttended.Text = dtCompletionStatuses.Rows[1]["s_ui_dropdown_us_english"].ToString();

            hfldAttendedWaikIn.Value = dtCompletionStatuses.Rows[2]["s_ui_dropdown_id_pk"].ToString();
            txtlblAttendedWaikIn.Text = dtCompletionStatuses.Rows[2]["s_ui_dropdown_us_english"].ToString();

            hfldBrowse.Value = dtCompletionStatuses.Rows[3]["s_ui_dropdown_id_pk"].ToString();
            txtlblBrowse.Text = dtCompletionStatuses.Rows[3]["s_ui_dropdown_us_english"].ToString();

            hfldCompleted.Value = dtCompletionStatuses.Rows[4]["s_ui_dropdown_id_pk"].ToString();
            txtlblCompleted.Text = dtCompletionStatuses.Rows[4]["s_ui_dropdown_us_english"].ToString();

            hfldDidNotAttend.Value = dtCompletionStatuses.Rows[5]["s_ui_dropdown_id_pk"].ToString();
            txtlblDidNotAttend.Text = dtCompletionStatuses.Rows[5]["s_ui_dropdown_us_english"].ToString();

            hfldEnrolled.Value = dtCompletionStatuses.Rows[6]["s_ui_dropdown_id_pk"].ToString();
            txtlblEnrolled.Text = dtCompletionStatuses.Rows[6]["s_ui_dropdown_us_english"].ToString();

            hfldExempt.Value = dtCompletionStatuses.Rows[7]["s_ui_dropdown_id_pk"].ToString();
            txtlblExempt.Text = dtCompletionStatuses.Rows[7]["s_ui_dropdown_us_english"].ToString();

            hfldFailed.Value = dtCompletionStatuses.Rows[8]["s_ui_dropdown_id_pk"].ToString();
            txtlblFailed.Text = dtCompletionStatuses.Rows[8]["s_ui_dropdown_us_english"].ToString();


            hfldIncomplete.Value = dtCompletionStatuses.Rows[9]["s_ui_dropdown_id_pk"].ToString();
            txtlblIncomplete.Text = dtCompletionStatuses.Rows[9]["s_ui_dropdown_us_english"].ToString();

            hfldNotScord.Value = dtCompletionStatuses.Rows[10]["s_ui_dropdown_id_pk"].ToString();
            txtlblNotScord.Text = dtCompletionStatuses.Rows[10]["s_ui_dropdown_us_english"].ToString();

            hfldOltPlayer.Value = dtCompletionStatuses.Rows[11]["s_ui_dropdown_id_pk"].ToString();
            txtlblOltPlayer.Text = dtCompletionStatuses.Rows[11]["s_ui_dropdown_us_english"].ToString();

            hfldPassed.Value = dtCompletionStatuses.Rows[12]["s_ui_dropdown_id_pk"].ToString();
            txtlblPassed.Text = dtCompletionStatuses.Rows[12]["s_ui_dropdown_us_english"].ToString();

            hfldPendingAssesmentSurvey.Value = dtCompletionStatuses.Rows[13]["s_ui_dropdown_id_pk"].ToString();
            txtlblPendingAssesmentSurvey.Text = dtCompletionStatuses.Rows[13]["s_ui_dropdown_us_english"].ToString();

            hfldUnknown.Value = dtCompletionStatuses.Rows[14]["s_ui_dropdown_id_pk"].ToString();
            txtlblUnknown.Text = dtCompletionStatuses.Rows[14]["s_ui_dropdown_us_english"].ToString();

            

            hfldVLSSystem.Value = dtCompletionStatuses.Rows[15]["s_ui_dropdown_id_pk"].ToString();
            txtlblVLSSystem.Text = dtCompletionStatuses.Rows[15]["s_ui_dropdown_us_english"].ToString();

            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_browse_enabled_flag"].ToString()))
            {
                chkBrowse.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_browse_enabled_flag"]);
            }
            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_olt_enabled_flag"].ToString()))
            {
                chkOLTPlayer.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_olt_enabled_flag"]);
            }
            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_vls_enabled_flag"].ToString()))
            {
                chkVLSSystem.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_vls_enabled_flag"]);
            }
            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_exempt_enabled_flag"].ToString()))
            {
                chkExempt.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_exempt_enabled_flag"]);
            }
            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_noscore_enabled_flag"].ToString()))
            {
                chkNotScored.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_noscore_enabled_flag"]);
            }
            if (!string.IsNullOrEmpty(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_pending_enabled_flag"].ToString()))
            {
                chkPending.Checked = Convert.ToBoolean(dtCompletionsStatusesFlag.Rows[0]["s_comp_status_pending_enabled_flag"]);
            }
            
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int result=SystemCompletionStatusesBLL.updateCompletionLocales(txtlblAssigned.Text, txtlblEnrolled.Text, txtlblIncomplete.Text, txtlblCompleted.Text, txtlblBrowse.Text, txtlblAttended.Text, txtlblDidNotAttend.Text, txtlblAttendedWaikIn.Text, txtlblUnknown.Text, txtlblOltPlayer.Text, txtlblVLSSystem.Text, txtlblPassed.Text, txtlblFailed.Text, txtlblExempt.Text, txtlblNotScord.Text, txtlblPendingAssesmentSurvey.Text, chkBrowse.Checked, chkUnknown.Checked, chkOLTPlayer.Checked, chkVLSSystem.Checked, chkExempt.Checked, chkNotScored.Checked, chkPending.Checked);
            if (result == 0)
            {
                divSuccess.Style.Add("display", "block");
                divSuccess.InnerText = LocalResources.GetText("app_succ_update_text");
            }
            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_date_not_updated_error_wrong");
            }
        }

        protected void chkBrowse_CheckedChanged(object sender, EventArgs e)
        {
          SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "browse");
        }

        protected void chkUnknown_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "unknown");
        }

        protected void chkOLTPlayer_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "olt");
        }

        protected void chkVLSSystem_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "vls");
        }

        protected void chkExempt_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "exempt");
        }

        protected void chkNotScored_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "notscore");
        }

        protected void chkPending_CheckedChanged(object sender, EventArgs e)
        {
            SystemCompletionStatusesBLL.UpdateCompletionLocaleVisibility(chkBrowse.Checked, "pending");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/sascmp-01.aspx", false);
        }

     

        //protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
            
        //}

        //protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    { 
        //     //txtlblAssigned
        //    }
        //}
    }
}