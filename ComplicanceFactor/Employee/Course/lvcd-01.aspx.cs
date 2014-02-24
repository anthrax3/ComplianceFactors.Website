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
            try
            {

                if (!IsPostBack)
                {
                    PopulateCourse(Request.QueryString["id"]);
                    PopulateEnrollment(Request.QueryString["eid"]);
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
                        Logger.WriteToErrorLog("lvcd.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcd.aspx", ex.Message);
                    }
                }
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
            //Bind  session Details
            gvSession.DataSource = SystemCatalogBLL.GetSessionByCourseID(courseId);
            gvSession.DataBind();
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
        private void PopulateEnrollment(string enrollId)
        {
            DataTable dtEnroll = EnrollmentBLL.GetEnrollmentbyId(enrollId);
            if (dtEnroll != null)
            {
                if (dtEnroll.Rows.Count > 0)
                {
                    if (dtEnroll.Rows[0]["e_enroll_first_attempt_date_time"] != null)
                    {
                        lblFirstAttepmt.Text = dtEnroll.Rows[0]["e_enroll_first_attempt_date_time"].ToString();
                    }
                    if (dtEnroll.Rows[0]["e_enroll_last_attempt_date_time"] != null)
                    {
                        lblLastAttempt.Text = dtEnroll.Rows[0]["e_enroll_last_attempt_date_time"].ToString();
                    }
                }
            }
        }
        protected void gvSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSession1 = (Label)e.Row.FindControl("lblSession1");
                Label lblSession2 = (Label)e.Row.FindControl("lblSession2");
                lblSession1.Text = DataBinder.Eval(e.Row.DataItem, "c_session_title").ToString() + "<br>" + "(" + DataBinder.Eval(e.Row.DataItem, "c_session_id_pk").ToString() + ")";
                //Get Instructors
                DataTable dtInstructors = new DataTable();
                dtInstructors = SystemCatalogBLL.GetSessionInstructor(gvSession.DataKeys[e.Row.RowIndex].Values[0].ToString());
                string strInstructors = string.Empty;
                for (int i = 0; i < dtInstructors.Rows.Count; i++)
                {
                    strInstructors = strInstructors + dtInstructors.Rows[i]["c_instructor_name"].ToString();
                    strInstructors += (i < dtInstructors.Rows.Count - 1) ? " - " : string.Empty;

                }

                lblSession2.Text = DataBinder.Eval(e.Row.DataItem, "c_session_date")
                                       + AddLocationFacilityRoomDelimiters(DataBinder.Eval(e.Row.DataItem, "c_location_name").ToString(),
                                       DataBinder.Eval(e.Row.DataItem, "c_facility_name").ToString(), DataBinder.Eval(e.Row.DataItem, "c_room_name").ToString())
                                        + AddInstructorDelimiters(strInstructors);


            }
        }

        /// <summary>
        /// add session delimiters
        /// </summary>
        /// <param name="location"></param>
        /// <param name="facility"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        private string AddLocationFacilityRoomDelimiters(string location, string facility, string room)
        {
            string strLocationFacilityRoom = string.Empty;

            if (location != "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "]";
            }
            else if (location == "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + room + "]";
            }
            else if (location != "" && facility != "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "]";
            }
            else if (location == "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + room + "]";
            }
            else
            {
                strLocationFacilityRoom = string.Empty;
            }
            return strLocationFacilityRoom;

        }

        /// <summary>
        /// AddInstructorDelimiters
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        private string AddInstructorDelimiters(string instructor)
        {
            string strInstructor = string.Empty;

            if (instructor != "")
            {
                strInstructor = "<br> (" + instructor + ")";
            }
            else
            {
                strInstructor = string.Empty;
            }
            return strInstructor;
        }
    }
}