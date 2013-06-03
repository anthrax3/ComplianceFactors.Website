using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.MassEnrollment.Popup
{
    public partial class lvcure_01 : System.Web.UI.Page
    {
        private string curriculumId;
        protected void Page_Load(object sender, EventArgs e)
        {
            curriculumId = Request.QueryString["id"];
            if (!IsPostBack)
            {
                PopulateCurriculm(curriculumId);
            }
        }
        private void PopulateCurriculm(string curriculumId)
        {
            SystemCurriculum curriculum = new SystemCurriculum();
            curriculum = SystemCurriculumBLL.GetCurriculum(curriculumId, SessionWrapper.CultureName);
            lblCurriculumTitle.Text = curriculum.c_curriculum_title + "(" + curriculum.c_curriculum_id_pk + ")";
            lblVersion.Text = curriculum.c_curriculum_version;
            lblDescription.Text = curriculum.c_curriculum_desc;
            lblOwner.Text = curriculum.c_curriculum_owner_name;
            lblcoordinator.Text = curriculum.c_curriculum_coordinator_name;
            lblCost.Text = Convert.ToString(curriculum.cost_text);
            lblApprovalRequired.Text = curriculum.c_curriculum_approval_req_text;
            lblRecurrence.Text = curriculum.c_curriculum_recurrences_text;
            //lblDeliveryType.Text = curriculum.c_delivery_type_id;
            //lblCreditUnits.Text = Convert.ToString(Course.c_course_credit_units);
            lblCreditHours.Text = Convert.ToString(curriculum.c_curriculum_credit_hours);
            //Get Path
            dlPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaPath(curriculumId);
            dlPath.DataBind();
            //Store Prerequisites,Equivalencies and Fulfillments in dataset
            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(curriculumId);
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
        protected void dlPath_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvSection = (GridView)e.Item.FindControl("gvSection");
            Label lblCompleteSection = (Label)e.Item.FindControl("lblCompleteSection");
            BindPathSection(gvSection, dlPath.DataKeys[e.Item.ItemIndex].ToString());
            lblCompleteSection.Text = "Complete " + DataBinder.Eval(e.Item.DataItem, "c_curricula_path_complete") + " of " + DataBinder.Eval(e.Item.DataItem, "c_curricula_path_sections") + " Section(s) below to complete the requirements for this Curriculum.";
        }
        protected void gvSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                GridView gvCourses = (GridView)e.Row.FindControl("gvCourses");
                Label lblComplete = (Label)e.Row.FindControl("lblComplete");
                string str_path_section_complete = DataBinder.Eval(e.Row.DataItem, "c_curricula_path_section_complete").ToString();
                BindPathCourse(gvCourses, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString(), lblComplete, str_path_section_complete);

            }
        }
        private void BindPathCourse(GridView GridView, string c_curricula_path_system_id_pk, string c_curricula_path_section_id_pk, Label lblComplete, string path_section_complete)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                //DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
                DataView dvPathCourse = new DataView(SystemMassEnrollmentBLL.GetSingleCurriculaPathCourse(curriculumId, c_curricula_path_system_id_pk));
                dvPathCourse.RowFilter = "c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_pk + "'";
                dvPathCourse.Sort = "c_curricula_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                GridView.DataSource = dtPathCourse;
                GridView.DataBind();
                lblComplete.Text = "(Complete " + path_section_complete + " of " + dtPathCourse.Rows.Count.ToString() + " Courses)";
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        //Logger.WriteToErrorLog("p-lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        //Logger.WriteToErrorLog("p-lvcurd-01.aspx", ex.Message);
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
                else if (status == "Enrolled")
                {
                    btnDrop.Style.Add("display", "inline");
                }
            }
        }
        private void BindPathSection(GridView GridView, string c_curricula_path_system_id_pk)
        {
            try
            {
                GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaPathSection(curriculumId, c_curricula_path_system_id_pk);
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-lvcurd-01.aspx", ex.Message);
                    }
                }
            }

        }

    }
}