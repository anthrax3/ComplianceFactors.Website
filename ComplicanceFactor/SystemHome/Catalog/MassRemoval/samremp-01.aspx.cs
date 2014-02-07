using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.MassRemoval
{
    public partial class samremp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_training_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_mass_enrollment_text");
                SessionWrapper.Enrollment_courses_curriculum = TempDataTables.TempEnrollmentCourseCurriculum();
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + " Mass Removal" + "</a>";

                SessionWrapper.Enrollment_courses_curriculum.Clear();
                SessionWrapper.MassEnrollment_employees.Clear();
            }

            if (SessionWrapper.Enrollment_courses_curriculum.Rows.Count > 0 && (hdCheckdelivery.Value != "1" || string.IsNullOrEmpty(hdCheckdelivery.Value)))
            {
                gvCatalog.DataSource = SessionWrapper.Enrollment_courses_curriculum;
                gvCatalog.DataBind();
                hdCheckdelivery.Value = "1";
            }
            if (SessionWrapper.MassEnrollment_employees.Rows.Count > 0)
            {
                gvEmployee.DataSource = SessionWrapper.MassEnrollment_employees;
                gvEmployee.DataBind();
            }
        }

        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sysId = DataBinder.Eval(e.Row.DataItem, "sysId").ToString();
                string type = DataBinder.Eval(e.Row.DataItem, "type").ToString();
                CheckBox chkSelectDelivery = (CheckBox)e.Row.FindControl("chkSelectDelivery");
                DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                //Button btnViewDetails = (Button)e.Row.FindControl("btnViewDetails");
                Literal ltlViewDetails = (Literal)e.Row.FindControl("ltlViewDetails");
                if (type == "Course")
                {
                    chkSelectDelivery.Style.Add("display", "inline");
                    ddlDelivery.Style.Add("display", "inline");
                    //btnViewDetails.Style.Add("display", "none");
                }
                else
                {
                    chkSelectDelivery.Style.Add("display", "none");
                    ddlDelivery.Style.Add("display", "none");
                    //btnViewDetails.Style.Add("display", "inline"); Style='float:left;margin-left:70px;'
                    ltlViewDetails.Text = "<input type= 'button' id =" + sysId + " value='" + LocalResources.GetGlobalLabel("app_view_details_button_text") + "' class='viewdetails cursor_hand'  align='center'/> ";
                }
                try
                {
                    ddlDelivery.DataSource = SystemMassCompletionBLL.GetDelivery(sysId);
                    ddlDelivery.DataBind();
                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "Select a Delivery";
                    
                    ddlDelivery.Items.Insert(0, liFirstItem);
                    ddlDelivery.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samremp-01 (Remove Course/Curriculum)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samremp-01 (Remove Course/Curriculum)", ex.Message);
                        }
                    }
                }
            }
        }

        //Delete courseCurriculum
        [System.Web.Services.WebMethod]
        public static void DeleteCourseCurriculum(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.Enrollment_courses_curriculum.Select("sysId= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Enrollment_courses_curriculum.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samremp-01 (Remove Course/Curriculum)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samremp-01 (Remove Course/Curriculum)", ex.Message);
                    }
                }
            }

        }

        //Delete Prerequisites
        [System.Web.Services.WebMethod]
        public static void DeleteEmployee(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.MassEnrollment_employees.Select("u_user_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.MassEnrollment_employees.AcceptChanges();
            }
            catch (Exception ex)
            {                
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samremp-01 (Remove Employee)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samremp-01 (Remove Employee)", ex.Message);
                    }
                }
            }

        }

        protected void btnProcessMassRemoval_Click(object sender, EventArgs e)
        {
            MassRemovalCourseCurriculum();
            if (SessionWrapper.Enrollment_courses_curriculum.Rows.Count > 0 && SessionWrapper.MassEnrollment_employees.Rows.Count > 0)
            {
                divSuccess.Style.Add("display", "block");
                divSuccess.InnerText = "Mass Removal was done sucessfully";
            }
        }

        private DataTable TempCourseWithDeliveryDatatable()
        {
            DataTable dt = new DataTable();
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "course_id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "deliveryID";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        private DataTable TempCourseDatatable()
        {
            DataTable dt = new DataTable();
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "course_id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        private DataTable TempCurriculumDatatable()
        {
            DataTable dt = new DataTable();
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "curriculum_id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }

        private void MassRemovalCourseCurriculum()
        {
            DataTable dtCourseDeliveryRemoval = TempCourseWithDeliveryDatatable();
            DataTable dtCourseRemoval = TempCourseDatatable();
            DataTable dtCurriculumRemoval = TempCurriculumDatatable();
            for (int i = 0; i < SessionWrapper.Enrollment_courses_curriculum.Rows.Count; i++)
            {
                CheckBox chkSelectDelivery = (CheckBox)gvCatalog.Rows[i].FindControl("chkSelectDelivery");
                DropDownList ddlDelivery = (DropDownList)gvCatalog.Rows[i].FindControl("ddlDelivery");

                for (int k = 0; SessionWrapper.MassEnrollment_employees.Rows.Count > k; k++)
                {
                    if (SessionWrapper.Enrollment_courses_curriculum.Rows[i]["type"].ToString() == "Course" && chkSelectDelivery.Checked == true)
                    {
                        DataRow courserow;
                        courserow = dtCourseDeliveryRemoval.NewRow();
                        courserow["course_id"] = SessionWrapper.Enrollment_courses_curriculum.Rows[i]["sysId"].ToString();
                        courserow["deliveryID"] = ddlDelivery.SelectedValue;
                        courserow["employeeID"] = SessionWrapper.MassEnrollment_employees.Rows[k]["u_user_id_pk"].ToString();
                        dtCourseDeliveryRemoval.Rows.Add(courserow);
                    }
                    else if (SessionWrapper.Enrollment_courses_curriculum.Rows[i]["type"].ToString() == "Course" && chkSelectDelivery.Checked == false)
                    {
                        DataRow courserow;
                        courserow = dtCourseRemoval.NewRow();
                        courserow["course_id"] = SessionWrapper.Enrollment_courses_curriculum.Rows[i]["sysId"].ToString();
                        courserow["employeeID"] = SessionWrapper.MassEnrollment_employees.Rows[k]["u_user_id_pk"].ToString();
                        dtCourseRemoval.Rows.Add(courserow);
                    }
                    else
                    {
                        DataRow curriculumrow;
                        curriculumrow = dtCurriculumRemoval.NewRow();
                        curriculumrow["curriculum_id"] = SessionWrapper.Enrollment_courses_curriculum.Rows[i]["sysId"].ToString();
                        curriculumrow["employeeID"] = SessionWrapper.MassEnrollment_employees.Rows[k]["u_user_id_pk"].ToString();
                        dtCurriculumRemoval.Rows.Add(curriculumrow);
                    }
                }
            }
            ConvertDataTables ConvertToXml = new ConvertDataTables();
            try
            {
                int result = 1;
                string coursewithdelivery = string.Empty;
                string courseonly = string.Empty;
                string curriculum = string.Empty;
                if (dtCourseDeliveryRemoval.Rows.Count > 0)
                {
                    coursewithdelivery = ConvertToXml.ConvertDataTableToXml(dtCourseDeliveryRemoval);
                }
                if (dtCourseRemoval.Rows.Count > 0)
                {
                    courseonly = ConvertToXml.ConvertDataTableToXml(dtCourseRemoval);
                }
                if (dtCurriculumRemoval.Rows.Count > 0)
                {
                    curriculum = ConvertToXml.ConvertDataTableToXml(dtCurriculumRemoval);                    
                }
                result = SystemMassRemovalBLL.CourseCurriculumRemoval(coursewithdelivery, courseonly, curriculum);                
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samremp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samremp-01", ex.Message);
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemHome/Catalog/samcmp-01.aspx");
        }
    }
}