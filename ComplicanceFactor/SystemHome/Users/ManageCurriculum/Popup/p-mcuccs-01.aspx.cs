using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor.SystemHome.Users.ManageCurriculum.Popup
{
    public partial class p_mcuccs_01 : System.Web.UI.Page
    {
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request.QueryString["curriculumid"]))
                {
                    BindCurriculumDetails(Request.QueryString["curriculumid"]);
                }

                try
                {
                    ddlChangeStatus.DataSource = UpdateCurriculumStatusesBLL.GetStatus(SessionWrapper.CultureName);
                    ddlChangeStatus.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-mcuccs-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-mcuccs-01", ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editCurriculumId"></param>
        private void BindCurriculumDetails(string editCurriculumId)
        {
            SystemCurriculum curriculum = new SystemCurriculum();
            try
            {
                curriculum = SystemCurriculumBLL.GetCurriculum(editCurriculumId, string.Empty);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcuccs-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcuccs-01", ex.Message);
                    }
                }
            }
            lblCurriculumTitle.Text = curriculum.c_curriculum_title + "(" + curriculum.c_curriculum_id_pk + ")";
            lblDescription.Text = curriculum.c_curriculum_desc;             
            lblRevision.Text = curriculum.c_curriculum_version;        
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Enrollment curriculum = new Enrollment();
            CurriculumStatus statusHistory = new CurriculumStatus();

            string statustypeId = UpdateCurriculumStatusesBLL.GetStatusTypeId("User Manual Change");
            string curriculumId= Request.QueryString["curriculumid"];
            string userId =Request.QueryString["userid"];
            curriculum = UpdateCurriculumStatusesBLL.GetAssignCourse(curriculumId, userId);

            statusHistory.e_curriculum_assign_system_id_pk = Guid.NewGuid().ToString();
            statusHistory.e_curriculum_assign_user_id_fk = userId;
            statusHistory.e_curriculum_assign_curriculum_id_fk = curriculumId;
            statusHistory.e_curriculum_assign_date_time = curriculum.e_curriculum_assign_date_time;
            statusHistory.e_curriculum_assign_required_flag = curriculum.e_curriculum_assign_required_flag;
            DateTime? duedate = null;
            DateTime tempexpiredate;
            if (DateTime.TryParseExact(txtDueDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempexpiredate))
            {
                duedate = tempexpiredate;
            }
            statusHistory.e_curriculum_assign_original_target_due_date = duedate;

            statusHistory.e_curriculum_assign_status_change_date_time = DateTime.UtcNow;
            statusHistory.e_curriculum_assign_after_status_id_fk = ddlChangeStatus.SelectedValue;
            statusHistory.e_curriculum_assign_cert_date = duedate;
            statusHistory.e_curriculum_assign_recert_due_date = duedate;
            statusHistory.e_curriculum_assign_recert_status_change_type_id_fk = statustypeId;
            statusHistory.e_curriculum_assign_recert_status_change_user_id_fk = SessionWrapper.u_userid;
            statusHistory.e_curriculum_before_status_id_fk = string.Empty;
            statusHistory.e_curriculum_assign_percent_complete = curriculum.e_curriculum_assign_percent_complete;
            statusHistory.e_curriculum_assign_active_flag = curriculum.e_curriculum_assign_active_flag;
            statusHistory.e_curriculum_status_change_notes = txtNotes.Text;

            try
            {
                int resultvalue = UpdateCurriculumStatusesBLL.InsertHistory(statusHistory);
                int result = UpdateCurriculumStatusesBLL.UpdateCurriculumStatuses(curriculumId, Request.QueryString["userid"], duedate, ddlChangeStatus.SelectedValue, statustypeId, SessionWrapper.u_userid);
                if (resultvalue == 0 && result == 0)
                {
                    divSuccess.InnerText = "Curriculum status updated successfully.";
                    divSuccess.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcuccs-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcuccs-01", ex.Message);
                    }
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}