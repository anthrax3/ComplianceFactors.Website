using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.MassCompletions
{
    public partial class samcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "Mass Completion";

            }
            if (SessionWrapper.Compltion_courses.Rows.Count > 0)
            {
                gvCatalog.DataSource = SessionWrapper.Compltion_courses;
                gvCatalog.DataBind();
            }
            if (SessionWrapper.Compltion_employees.Rows.Count > 0)
            {
                gvEmployee.DataSource = SessionWrapper.Compltion_employees;
                gvEmployee.DataBind();
            }

        }

        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string courseId = GridView1.DataKeys[e.Row.RowIndex][0].ToString();

                try
                {

                    DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                    ddlDelivery.DataSource = SystemMassCompletionBLL.GetDelivery(courseId);
                    ddlDelivery.DataBind();

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}