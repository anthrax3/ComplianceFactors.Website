using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses
{
    public partial class saucmcp_01 : System.Web.UI.Page
    {
        private static string editCurriculumId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.TempEmployeelist = null;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editCurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);

                }
                BindPathDetails(editCurriculumId);
            }
            //Bind the Employee
            gvEmployees.DataSource = SessionWrapper.TempEmployeelist;
            gvEmployees.DataBind();

        }

        private void BindPathDetails(string editCurriculumId)
        {
            gvPath.DataSource = SystemCurriculumBLL.GetCurriculumPathOnly(editCurriculumId);
            gvPath.DataBind();
            //GetCurriculumPathOnly
        }
        protected void gvPath_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                GridView gvSection = (GridView)e.Row.FindControl("gvSection");
                BindPathSection(gvSection, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString());

            }
        }

        private void BindPathSection(GridView GridView, string pathId, string curriculumId)
        {
            try
            {
                GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaPathSection(curriculumId, pathId);
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void gvSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                GridView gvCourse = (GridView)e.Row.FindControl("gvCourse");
                BindPathCourse(gvCourse, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString());
            }
        }

        private void BindPathCourse(GridView GridView, string c_curricula_path_system_id_pk, string c_curricula_path_section_id_pk)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                //DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
                DataView dvPathCourse = new DataView(EnrollmentBLL.EnrollGetSingleCurriculaPathCourse(editCurriculumId, c_curricula_path_system_id_pk));
                dvPathCourse.RowFilter = "c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_pk + "'";
                dvPathCourse.Sort = "c_curricula_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                GridView.DataSource = dtPathCourse;
                GridView.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvEmployees.Rows[index];

            if (e.CommandName == "Remove")
            {

            }
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void DeleteUser(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.TempEmployeelist.Select("u_user_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempEmployeelist.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                    }
                }
            }
        }
    }
}