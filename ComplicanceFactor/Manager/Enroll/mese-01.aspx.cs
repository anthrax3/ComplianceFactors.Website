using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Configuration;
namespace ComplicanceFactor.Manager.Enroll
{
    public partial class mese_01 : System.Web.UI.Page
    {
        #region
        private string courseId;
        private string deliveryId;
        private string deliveryType;
        private string waitList;
        private bool c_course_approval;
        private bool c_delivery_approval;
        private bool isTrue;
        private string curriculumId;
        private string course_id_or_curriculum_id;
        private bool c_check;
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                curriculumId = Request.QueryString["id"];
                courseId = Request.QueryString["courseid"];
                if (Request.QueryString["check"] == "1")
                {
                    isTrue = true;
                    course_id_or_curriculum_id = courseId;
                }
                else
                {
                    isTrue = false;
                    course_id_or_curriculum_id = curriculumId;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ctype"]))
                {
                    //curriculumId = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(Request.QueryString["ca"]))
                    {
                        c_course_approval = Convert.ToBoolean(Request.QueryString["ca"]);
                    }
                    else
                    {
                        c_course_approval = false;
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["da"]))
                    {
                        c_delivery_approval = Convert.ToBoolean(Request.QueryString["da"]);
                    }
                    else
                    {
                        c_delivery_approval = false;
                    }
                }
                else
                {
                    //courseId = Request.QueryString["courseid"];
                    deliveryId = Request.QueryString["id"];
                    deliveryType = Request.QueryString["type"];
                    if (!string.IsNullOrEmpty(Request.QueryString["ca"]))
                    {
                        c_course_approval = Convert.ToBoolean(Request.QueryString["ca"]);
                    }
                    else
                    {
                        c_course_approval = false;
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["approval"]))
                    {
                        c_delivery_approval = Convert.ToBoolean(Request.QueryString["approval"]);
                    }
                    else
                    {
                        c_delivery_approval = false;
                    }
                }
                if (!IsPostBack)
                {
                    SearchResult();
                    //count page of page in search result
                    lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
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
                        Logger.WriteToErrorLog("mese-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mese-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderGoto_Click1(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;
            SearchResult();
            txtFooterPage.Text = txtHeaderPage.Text;
        }
        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterGoto_Click1(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;
            SearchResult();
            txtHeaderPage.Text = txtFooterPage.Text;
        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //search
            ViewState["SearchResult"] = "true";
            gvsearchDetails.PageIndex = 0;
            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }
        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ctype"]))
            {
                AddEmployee(SessionWrapper.Employee);
                //Close popup
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                Response.Redirect("~/Manager/Enroll/mesc-01.aspx?courseid=" + courseId + "&deliveryid=" + deliveryId + "&deliveryType=" + deliveryType + "&ca=" + c_course_approval + "&da=" + c_delivery_approval);
            }
            else
            {
                AddEmployee(SessionWrapper.Employee);
                //close popup
                Response.Redirect("~/Manager/Enroll/mescurr-01.aspx?id=" + curriculumId + "&ctype=" + Request.QueryString["ctype"] + "&ca=" + c_course_approval + "&da=" + c_delivery_approval);
            }
        }
        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }
        /// <summary>
        /// Search employee
        /// </summary>
        private void SearchResult()
        {
            try
            {
               
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    gvsearchDetails.DataSource = EmployeeBLL.GetEmployeeByManager(SessionWrapper.u_userid, txtEmployeeName.Text, course_id_or_curriculum_id, isTrue);
                    gvsearchDetails.DataBind();
                }
                else
                {
                    string strName = string.Empty;
                    if(!string.IsNullOrEmpty(Request.QueryString["search"]))
                    {
                    strName = Request.QueryString["search"];
                    }
                    gvsearchDetails.DataSource = EmployeeBLL.GetEmployeeByManager(SessionWrapper.u_userid, strName, course_id_or_curriculum_id, isTrue);
                    gvsearchDetails.DataBind();
                }

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mese-01.aspx (SearchResult) Error", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mese-01.aspx (SearchResult) Error", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
            }
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }


        }
        private void disable_enable(bool status)
        {
            btnHeaderFirst.Visible = status;
            btnHeaderPrevious.Visible = status;
            btnHeaderNext.Visible = status;
            btnHeaderLast.Visible = status;

            btnFooterFirst.Visible = status;
            btnFooterPrevious.Visible = status;
            btnFooterNext.Visible = status;
            btnFooterLast.Visible = status;

            ddlHeaderResultPerPage.Visible = status;
            ddlFooterResultPerPage.Visible = status;

            txtHeaderPage.Visible = status;
            lblHeaderPage.Visible = status;

            txtFooterPage.Visible = status;
            lblFooterPage.Visible = status;

            btnHeaderGoto.Visible = status;
            btnFooterGoto.Visible = status;


            lblHeaderResultPerPage.Visible = status;
            lblFooterResultPerPage.Visible = status;

            lblFooterPageOf.Visible = status;
            lblHeaderPageOf.Visible = status;
            btnSaveSelected.Visible = status;

        }
        private void AddEmployeeRow(string u_user_id_fk, string c_course_id_fk, string c_delivery_id_fk, string u_first_name, string u_last_name, string u_employee_number, DataTable dtEmployee)
        {
            // Add Category functiong
            DataRow row;
            row = dtEmployee.NewRow();
            row["u_user_id_fk"] = u_user_id_fk;
            row["id"] = c_course_id_fk;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["u_first_name"] = u_first_name;
            row["u_last_name"] = u_last_name;
            row["u_employee_number"] = u_employee_number;
            dtEmployee.Rows.Add(row);
        }
        /// <summary>
        /// add category
        /// </summary>
        /// <param name="dtEmployee"></param>
        /// <param name="s_category_system_id_pk"></param>
        /// <returns></returns>
        private DataTable AddEmployee(DataTable dtEmployee)
        {

            foreach (GridViewRow grdCategoryRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdCategoryRow.Cells[1].FindControl("chkSelect"));
                if (chkSelect.Checked == true)
                {
                    if (string.IsNullOrEmpty(Request.QueryString["ctype"]))
                    {
                        AddEmployeeRow(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), courseId, deliveryId, grdCategoryRow.Cells[0].Text, grdCategoryRow.Cells[1].Text, string.Empty, dtEmployee);
                    }
                    else
                    {
                        AddEmployeeRow(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), curriculumId, string.Empty, grdCategoryRow.Cells[0].Text, grdCategoryRow.Cells[1].Text, string.Empty, dtEmployee);
                    }
                }
            }
            //Remove duplicate employee
            ConvertDataTables removeDuplicateRows = new ConvertDataTables();
            dtEmployee = removeDuplicateRows.RemoveDuplicateRows(dtEmployee, "u_user_id_fk");
            return dtEmployee;

        }

        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string type = DataBinder.Eval(e.Row.DataItem, "type").ToString();
                if (type == "course")
                {
                    string enrollStatus = DataBinder.Eval(e.Row.DataItem, "enrollStatus").ToString();
                    string wailtListStatus = DataBinder.Eval(e.Row.DataItem, "wailtListStatus").ToString();
                    string assignStatus = DataBinder.Eval(e.Row.DataItem, "assignStatus").ToString();
                    if (enrollStatus == "Y")
                    {
                        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                        lblStatus.Visible = true;
                        CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                        lblStatus.Text = "Already Enrolled";
                        chkSelect.Visible = false;

                    }
                    if (wailtListStatus == "Y")
                    {
                        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                        lblStatus.Visible = true;
                        CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                        lblStatus.Text = "Already Waitlisted";
                        chkSelect.Visible = false;

                    }
                    if (assignStatus == "Y")
                    {
                        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                        lblStatus.Visible = true;
                        CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                        lblStatus.Text = "Already Assigned";
                        chkSelect.Visible = false;

                    }
                }
                else if (type == "curriculum")
                {
                    string curriculaStatus = DataBinder.Eval(e.Row.DataItem, "curriculaStatus").ToString();
                    if (curriculaStatus == "Y")
                    {
                        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                        lblStatus.Visible = true;
                        CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                        lblStatus.Text = "Already Assigned";
                        chkSelect.Visible = false;

                    }
                }
                
            }
        }
        
    }
}