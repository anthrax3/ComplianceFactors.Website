using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Net.Mail;
using System.Configuration;

namespace ComplicanceFactor.Manager.Enroll
{
    public partial class mescurr_01 : System.Web.UI.Page
    {
        private string id;
        private string ctype;
        private bool ca;
        private bool da;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            ctype = Request.QueryString["ctype"];
            //course approval 
            ca = Convert.ToBoolean(Request.QueryString["ca"]);
            //delivery approval
            da = Convert.ToBoolean(Request.QueryString["da"]);
            if (!IsPostBack)
            {
                try
                {
                    gvsearchDetails.DataSource = SessionWrapper.Employee;
                    gvsearchDetails.DataBind();
                    PopulateCurriculum();
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("mesc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("mesc-01.aspx", ex.Message);
                        }
                    }
                }

            }

        }
        private void PopulateCurriculum()
        {
            SystemCurriculum curriculum = new SystemCurriculum();
            curriculum = SystemCurriculumBLL.GetCurriculum(id, SessionWrapper.CultureName);
            lblTitle.Text = curriculum.c_curriculum_title + "(" + curriculum.c_curriculum_id_pk + ")";
            lblRevision.Text = curriculum.c_curriculum_version;
            lblDescription.Text = curriculum.c_curriculum_desc;
            lblOwner.Text = curriculum.c_curriculum_owner_name;
            lblCoordinator.Text = curriculum.c_curriculum_coordinator_name;
            lblCost.Text = Convert.ToString(curriculum.c_curriculum_cost);
            lblApproval.Text = curriculum.c_curriculum_approval_req_text;
            lblCEU.Text = Convert.ToString(curriculum.c_curriculum_credit_hours);
        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Enroll/mese-01.aspx?id=" + id + "&ctype=" + ctype +  "&ca=" + ca + "&approval=" + da +"&search=" + txtEmployeeName.Text);
        }

        protected void btnConfirmAssignMent(object sender, EventArgs e)
        {
            try
            {
                ConvertDataTables dataTableToXml = new ConvertDataTables();
                DataTable dtEmployees = new DataTable();
                TempDataTables dtTables = new TempDataTables();
                dtEmployees = dtTables.TempEmployee();

                Enrollment assign = new Enrollment();
                assign.e_assign_course = dataTableToXml.ConvertDataTableToXml(AddEmployee(dtEmployees));
                assign.e_course_assign_by_id_fk = SessionWrapper.u_userid;
                assign.e_course_assign_required_flag = chkRequired.Checked;
                DateTime? targetDueDate = null;
                DateTime tempTargetDueDate;
                if (DateTime.TryParse(txtTargetDueDate.Text, out tempTargetDueDate))
                {
                    targetDueDate = Convert.ToDateTime(txtTargetDueDate.Text);
                }
                DateTime? recertDueDate = null;
                assign.e_course_assign_target_due_date = targetDueDate;
                assign.e_course_assign_recert_due_date = recertDueDate;
                assign.e_course_assign_percent_complete = 0;
                assign.e_course_assign_active_flag = true;
                EnrollmentBLL.AssignCourse(assign);
                //close popup
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Catalog/ctdp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx", ex.Message);
                    }
                }
            }
        }

        //protected void btnConfirmEnrollment_Click(object sender, EventArgs e)
        //{
        //    DataTable dtEmployees = new DataTable();
        //    TempDataTables dtTables = new TempDataTables();
        //    dtEmployees = dtTables.TempEmployee();
        //    DataTable dtEmployeeSelecteList = AddEmployee(dtEmployees);
        //    for (int i = 0; i < dtEmployeeSelecteList.Rows.Count; i++)
        //    {
        //        //Enrollment without approval
        //        Enrollment(false, c_course_approval, c_delivery_approval, dtEmployeeSelecteList.Rows[i]["u_user_id_fk"].ToString());
        //        SendConfirmationEmail();
        //    }
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/mhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);
        //}
        private void AddEmployeeRow(string u_user_id_fk, string id,  string u_employee_number, DataTable dtEmployee)
        {
            // Add Category functiong
            DataRow row;
            row = dtEmployee.NewRow();
            row["u_user_id_fk"] = u_user_id_fk;
            row["id"] = id;
            row["u_employee_number"] = u_employee_number;
            dtEmployee.Rows.Add(row);
        }
        private DataTable AddEmployee(DataTable dtEmployee)
        {

            foreach (GridViewRow grdCategoryRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdCategoryRow.Cells[1].FindControl("chkSelect"));
                if (chkSelect.Checked == true)
                {
                    AddEmployeeRow(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), id, string.Empty, dtEmployee);
                }
            }
            //Remove duplicate employee
            ConvertDataTables removeDuplicateRows = new ConvertDataTables();
            dtEmployee = removeDuplicateRows.RemoveDuplicateRows(dtEmployee, "u_user_id_fk");
            return dtEmployee;

        }
        private void CurriculumAssign(string u_user_id_fk, string c_curriculum_id_fk)
        {
            BusinessComponent.DataAccessObject.Enrollment assignCurricula = new BusinessComponent.DataAccessObject.Enrollment();
            assignCurricula.e_curriculum_assign_user_id_fk = u_user_id_fk;
            assignCurricula.e_curriculum_assign_curriculum_id_fk = c_curriculum_id_fk;
            assignCurricula.e_curriculum_assign_required_flag = chkRequired.Checked;                
            DateTime? target_due_date = null;
            DateTime temp_target_due_date;
            if (DateTime.TryParse(txtTargetDueDate.Text, out temp_target_due_date))
            {
                target_due_date = Convert.ToDateTime(txtTargetDueDate.Text);
            }

            assignCurricula.e_curriculum_assign_target_due_date = target_due_date;
            DateTime? recertDueDate = null;
            assignCurricula.e_curriculum_assign_recert_due_date = recertDueDate;
            assignCurricula.e_curriculum_assign_recert_status_id_fk = string.Empty;
            assignCurricula.e_curriculum_assign_status_id_fk = "Assigned";
            assignCurricula.e_curriculum_assign_percent_complete = 0;
            assignCurricula.e_curriculum_assign_active_flag = true;
            EnrollmentBLL.AssignCurricula(assignCurricula);
        }
        protected void btnConfirmAssignment_Click(object sender, EventArgs e)
        {
            DataTable dtEmployees = new DataTable();
            TempDataTables dtTables = new TempDataTables();
            dtEmployees = dtTables.TempEmployee();
            DataTable dtEmployeeSelecteList = AddEmployee(dtEmployees);
            for (int i = 0; i < dtEmployeeSelecteList.Rows.Count; i++)
            {
                //curriculum assignment
                CurriculumAssign(dtEmployeeSelecteList.Rows[i]["u_user_id_fk"].ToString(), dtEmployeeSelecteList.Rows[i]["id"].ToString());
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/mhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);
        }
    }
}