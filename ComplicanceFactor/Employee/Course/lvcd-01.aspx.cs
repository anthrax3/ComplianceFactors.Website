using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;


namespace ComplicanceFactor.Employee.Course
{
    public partial class lvcd_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCourse(Request.QueryString["id"]);
            }
        }
        private void PopulateCourse(string courseId)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetCourse(courseId, SessionWrapper.CultureName);
            lblCourseTitle.Text = Course.c_course_title + "(" + Course.c_course_id_pk + ")";
            lblRevision.Text = Course.c_course_version;
            lblDescription.Text = Course.c_course_desc;
            lblOwner.Text = Course.c_course_owner_name;
            lblCoordinator.Text = Course.c_course_coordinator_name;
            lblCost.Text = Convert.ToString(Course.cost_text);
            lblApproval.Text = Course.c_course_approval_req_text;
            lblRecurrence.Text = Course.c_course_recurrences_text;
            lblDeliveryType.Text = Course.c_delivery_type_id;
            //lblCreditUnits.Text = Convert.ToString(Course.c_course_credit_units);
            lblCEU.Text = Convert.ToString(Course.c_course_credit_hours);
            //Store Prerequisites,Equivalencies and Fulfillments in dataset
            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(courseId);
            //Get Prerequisites session
            gvPrerequisites.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[3];
            gvPrerequisites.DataBind();
            //Get Equivalencies session
            gvEquivalencies.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[4];
            gvEquivalencies.DataBind();
            //Get Fulfillments session
            gvFulfillments.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[5];
            gvFulfillments.DataBind();
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RemoveCel", "RemoveLastTableCell();", true);
        }
    }
}