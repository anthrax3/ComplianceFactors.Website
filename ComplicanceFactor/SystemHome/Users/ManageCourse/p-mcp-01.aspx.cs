using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Users.ManageCourse
{
    public partial class p_mcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCourse();
            }
            if (hdIsCourseBind.Value == "1")
            {
                GetAllCourse();
            }
        }

        private void GetAllCourse()
        {
            //bind curriculum
            try
            {
                DataSet dsEmployee = EmployeeBLL.GetAllEmployeeFromUser(Request.QueryString["id"]);
                hdEditUser.Value = Request.QueryString["id"];
                //bind course
                gvCourses.DataSource = dsEmployee.Tables[0];
                gvCourses.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcp-01", ex.Message);
                    }
                }
            }           

            if (gvCourses.Rows.Count > 0)
            {
                gvCourses.UseAccessibleHeader = true;
                if (gvCourses.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCourses.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string e_enroll_course_id_fk = gvCourses.DataKeys[e.Row.RowIndex]["e_enroll_course_id_fk"].ToString();
                string e_enroll_delivery_id_fk = gvCourses.DataKeys[e.Row.RowIndex]["e_enroll_delivery_id_fk"].ToString();                

                DropDownList ddlRequired = (DropDownList)e.Row.FindControl("ddlRequired");
                Literal ltlMarkCompletion = (Literal)e.Row.FindControl("ltlMarkCompletion");

                ltlMarkCompletion.Text = "<input type='button' id=" + e_enroll_course_id_fk + ',' + e_enroll_delivery_id_fk + " value='Mark Completion'    class='markcompletion' />";

                ddlRequired.Items.Insert(0, new ListItem("Required", "1"));
                ddlRequired.Items.Insert(1, new ListItem("Optional", "0"));               

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string required = Convert.ToString(drv["required"]);
                ddlRequired.SelectedItem.Text = required;
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataTable dtUpdateCourse = TempDataTables.TempUpdateMyCourse();
            DataTable dtRemoveCourse = TempDataTables.TempRemoveCourse();

            foreach (GridViewRow row in gvCourses.Rows)
            {
                CheckBox chkRemove = (CheckBox)row.FindControl("chkRemove");
                if (chkRemove.Checked == true)
                {
                    string c_course_id_pk = gvCourses.DataKeys[row.RowIndex][0].ToString();
                    DataRow courserow;
                    courserow = dtRemoveCourse.NewRow();
                    courserow["course_id"] = c_course_id_pk;
                    courserow["user_id"] = Convert.ToString(Request.QueryString["id"]);
                    dtRemoveCourse.Rows.Add(courserow);
                }
                else
                {
                    DropDownList ddlRequired = (DropDownList)row.FindControl("ddlRequired");
                    TextBox txtduedate = (TextBox)row.FindControl("txtduedate");
                    string c_course_id_pk = gvCourses.DataKeys[row.RowIndex][0].ToString();
                    DataRow courserow;
                    courserow = dtUpdateCourse.NewRow();
                    courserow["course_id"] = c_course_id_pk;
                    courserow["user_id"] = Convert.ToString(Request.QueryString["id"]);
                    courserow["required"] = Convert.ToBoolean(Convert.ToInt16(ddlRequired.SelectedValue));
                    if (!string.IsNullOrEmpty(txtduedate.Text))
                    {
                        courserow["duedate"] = txtduedate.Text;
                    }
                    else
                    {
                        courserow["duedate"] = DBNull.Value;
                    }
                    dtUpdateCourse.Rows.Add(courserow);
                }
            }
            ConvertDataTables convert = new ConvertDataTables();

            try
            {
                //Update Course Details
                int result = EnrollmentBLL.UpdateCourseDetailsFromUser(convert.ConvertDataTableToXml(dtUpdateCourse));
                if (result == 1)
                {
                    //Drop Courses
                    EnrollmentBLL.DropCourseFromUser(convert.ConvertDataTableToXml(dtRemoveCourse));
                    GetAllCourse();
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Course Updated Successfully";
                }                
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcp-01", ex.Message);
                    }
                }
            }           
        }     
    }
}