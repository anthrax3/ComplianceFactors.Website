using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Web.UI.HtmlControls;
using System.Data;

namespace ComplicanceFactor
{
    public partial class lhp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = LocalResources.GetGlobalLabel("app_nav_employee") + " > Home";
                // GetAllCourse();
                //set courses recored display pref
                if (SessionWrapper.u_profile_my_courses_records_display_pref != 0)
                {
                    gvCourses.AllowPaging = true;
                    gvCourses.PageSize = SessionWrapper.u_profile_my_courses_records_display_pref;
                }

                GetAllEmployee();
                //expand and collapsed based on user for course
                if (SessionWrapper.u_profile_my_courses_collapse_pref == "app_ddl_collapsed")
                {
                    div_course.Style.Add("display", "none");
                    imgCourse.ImageUrl = "~/Images/addplus-sm.gif";
                    imgCourse.AlternateText = "plus";
                }
                else
                {
                    div_course.Style.Add("display", "block");
                    imgCourse.ImageUrl = "~/Images/addminus-sm.gif";
                    imgCourse.AlternateText = "minus";
                }
                //expand and collapsed based on user for curriculum
                if (SessionWrapper.u_profile_my_curricula_collapse_pref == "app_ddl_collapsed")
                {
                    div_curriculum.Style.Add("display", "none");
                    imgCurriculum.ImageUrl = "~/Images/addplus-sm.gif";
                    imgCurriculum.AlternateText = "plus";
                }
                else
                {
                    div_course.Style.Add("display", "block");
                    imgCurriculum.ImageUrl = "~/Images/addminus-sm.gif";
                    imgCurriculum.AlternateText = "minus";
                }
            }

            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);

        }
        private void GetAllEmployee()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(SessionWrapper.u_userid);
            //bind course
            gvCourses.DataSource = dsEmployee.Tables[0];
            gvCourses.DataBind();
            //bind curriculum
            gvCurriculum.DataSource = dsEmployee.Tables[1];
            gvCurriculum.DataBind();
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
            if (gvCurriculum.Rows.Count > 0)
            {
                gvCurriculum.UseAccessibleHeader = true;
                if (gvCurriculum.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCurriculum.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        private void GetAllCourse()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(SessionWrapper.u_userid);
            //bind course
            gvCourses.DataSource = dsEmployee.Tables[0];
            gvCourses.DataBind();
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
        private void GetAllCurriculum()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(SessionWrapper.u_userid);
            //bind curriculum
            gvCurriculum.DataSource = dsEmployee.Tables[1];
            gvCurriculum.DataBind();
            if (gvCurriculum.Rows.Count > 0)
            {
                gvCurriculum.UseAccessibleHeader = true;
                if (gvCurriculum.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCurriculum.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Employee/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/ascp-01.aspx", false);
        }
        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/bchp-01.aspx", false);
        }
        protected void lnkViewAllCourses_Click(object sender, EventArgs e)
        {
            if (gvCourses.Rows.Count > 0)
            {
                gvCourses.PageSize = Convert.ToInt32(gvCourses.PageCount * gvCourses.PageSize);
            }
            GetAllCourse();
            div_course.Style.Add("display", "block");
            imgCourse.ImageUrl = "~/Images/addminus-sm.gif";
            imgCourse.AlternateText = "minus";

        }
        protected void lnkViewAllCurriculum_Click(object sender, EventArgs e)
        {
            if (gvCurriculum.Rows.Count > 0)
            {
                gvCurriculum.PageSize = Convert.ToInt32(gvCurriculum.PageCount * gvCurriculum.PageSize);
            }
            GetAllCurriculum();
            div_curriculum.Style.Add("display", "block");
            imgCurriculum.ImageUrl = "~/Images/addminus-sm.gif";
            imgCurriculum.AlternateText = "minus";

        }
        protected void gvCurriculum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("View"))
                {
                    Response.Redirect("~/Employee/Curricula/lvcurd-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);

                }
                else if (e.CommandName.Equals("Enroll"))
                {
                    Response.Redirect("~/Employee/Curricula/lvcure-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lhp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lhp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
                Button btnLaunch = (Button)e.Row.FindControl("btnLaunch");
                Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                string deliveryType = DataBinder.Eval(e.Row.DataItem, "deliveryType").ToString();
                if (status == "Assigned")
                {
                    btnEnroll.Style.Add("display", "inline");
                }
                else if (status == "Enrolled" && deliveryType == "OLT")
                {
                    btnLaunch.Style.Add("display", "inline");
                }
                else if(status == "Enrolled")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Canceled")
                {
                    btnDrop.Style.Add("display", "inline");
                }

            }
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Enroll"))
            {
                Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);

            }
            else if (e.CommandName.Equals("Launch"))
            {
                //Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
                //insert enrollment
                BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_course_id_fk = e.CommandArgument.ToString();
                enrollOLT.e_enroll_required_flag = true;
                enrollOLT.e_enroll_approval_required_flag = true;
                enrollOLT.e_enroll_type_name = "Self-enroll";
                enrollOLT.e_enroll_approval_status_name = "Pending";
                enrollOLT.e_enroll_status_name = "Enrolled";
                EnrollmentBLL.QuickLaunchEnroll(enrollOLT);
                Response.Redirect("~/Employee/Home/lhp-01.aspx", false);
            }
            else if (e.CommandName.Equals("Details"))
            {
                //Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment UpdateEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                UpdateEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                UpdateEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                EnrollmentBLL.UpdateEnrollmentStatus(UpdateEnrollmentStatus);
                Response.Redirect("~/Employee/Home/lhp-01.aspx", false);
             }
        }


    }
}