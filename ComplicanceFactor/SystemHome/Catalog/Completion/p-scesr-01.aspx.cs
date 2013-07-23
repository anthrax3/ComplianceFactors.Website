using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.Completion
{
    public partial class p_scesr_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.TempEmployeelist_delivery = TempDataTables.Employee();
                SearchResult();

                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            }
        }

        private void SearchResult()
        {
            try
            {
                string empName = string.Empty;
                string empId = string.Empty;
                string deliveryId = string.Empty;
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    empName = txtEmployeeName.Text;
                    empId = txtEmployeeNumber.Text;
                }
                else
                {
                    empName = SecurityCenter.DecryptText(Request.QueryString["ename"]);
                    empId = SecurityCenter.DecryptText(Request.QueryString["eno"]);

                }
                deliveryId = SecurityCenter.DecryptText(Request.QueryString["editDeliveryId"]);
                //curriculumId

                gvsearchDetails.DataSource = ManageCompletionBLL.GetDeliveryEmployee(empName, empId, deliveryId);
                gvsearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-scesr.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-scesr.aspx", ex.Message);
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

        protected void btnFooterFirst_Click(object sender, EventArgs e)
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

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

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

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
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

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
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
            string employeeNumber = string.Empty;
            string lastName = string.Empty;
            foreach (GridViewRow grdEmployeeRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdEmployeeRow.Cells[2].FindControl("chkSelect"));
                if (chkSelect.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(grdEmployeeRow.Cells[2].Text) || grdEmployeeRow.Cells[2].Text.Contains("&nbsp;"))
                    {
                        employeeNumber = string.Empty;
                    }
                    else
                    {
                        employeeNumber = grdEmployeeRow.Cells[2].Text;
                    }
                    if (string.IsNullOrWhiteSpace(grdEmployeeRow.Cells[0].Text) || grdEmployeeRow.Cells[0].Text.Contains("&nbsp;"))
                    {
                        lastName = string.Empty;
                    }
                    else
                    {
                        lastName = grdEmployeeRow.Cells[0].Text;
                    }

                    AddDataToEmployee(gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[0].ToString(), grdEmployeeRow.Cells[1].Text, lastName, employeeNumber,gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[1].ToString(),gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[2].ToString(),gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[3].ToString(),gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[4].ToString(),gvsearchDetails.DataKeys[grdEmployeeRow.RowIndex].Values[5].ToString(),SessionWrapper.TempEmployeelist_delivery);
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        //private DataTable Employee()
        //{
        //    DataTable dtTempEmployee = new DataTable();
        //    DataColumn dtTempEmployeeColumn;

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "u_user_id_pk";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "u_first_name";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "u_last_name";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "u_hris_employee_id";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "t_transcript_attendance_id_fk";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "t_transcript_passing_status_id_fk";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "t_transcript_grade_id_fk";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.Boolean");
        //    dtTempEmployeeColumn.ColumnName = "isSaved";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

        //    dtTempEmployeeColumn = new DataColumn();
        //    dtTempEmployeeColumn.DataType = Type.GetType("System.String");
        //    dtTempEmployeeColumn.ColumnName = "t_transcript_id_pk";
        //    dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
        //    return dtTempEmployee;

        //}

        private void AddDataToEmployee(string u_user_id_pk, string firstName, string lastName, string employeeId, string attendence,string passingstatus,string grade,string issaved,string transcriptid, DataTable dtTempEmployee)
        {
            DataRow row;
            row = dtTempEmployee.NewRow();
            row["u_user_id_pk"] = u_user_id_pk;
            row["u_first_name"] = firstName;
            row["u_last_name"] = lastName;
            row["u_hris_employee_id"] = employeeId;
            row["t_transcript_attendance_id_fk"] = attendence;
            row["t_transcript_passing_status_id_fk"] = passingstatus;
            row["t_transcript_grade_id_fk"] = grade;
            row["isSaved"] = Convert.ToBoolean(issaved);
            row["t_transcript_id_pk"] = transcriptid;
            dtTempEmployee.Rows.Add(row);
        }

    }
}