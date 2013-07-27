using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.Manager.Popup
{
    public partial class p_lvcurd_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        private string _attachmentpath = "~/SystemHome/Catalog/Curriculum/Attachments/";
        #endregion
        private string CurriculumId;
        private string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //CurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    userId = Request.QueryString["userid"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CurriculumId = Request.QueryString["id"];
                    PopulateCurriculum(CurriculumId);
                    dlPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaPath(CurriculumId, userId);
                    dlPath.DataBind();
                    // dlRecertPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaRecertPath(CurriculumId);
                    //dlRecertPath.DataBind();
                    gvRecertPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaRecertPath(CurriculumId);
                    gvRecertPath.DataBind();
                }               
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_pathIcon + SessionWrapper.c_curriculum_icon_uri);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.c_curriculum_icon_uri_file_name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = ReturnExtension(file.Extension.ToLower());
                        Response.WriteFile(file.FullName);
                        Response.End();
                        //if file does not exist
                    }
                    else
                    {
                        Response.Write("This file does not exist.");
                    }
                    //nothing in the URL as HTTP GET
                }
                else
                {
                    Response.Write("Please provide a file to download.");
                }
            }
        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {

                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":

                    return "image/png";


                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";

            }
        }
        //Populate Curriculum
        private void PopulateCurriculum(string CurriculumId)
        {
            SystemCurriculum Curriculum = new SystemCurriculum();
            Curriculum = SystemCurriculumBLL.GetCurriculum(CurriculumId, SessionWrapper.CultureName);
            lblCurriculumId.Text = Curriculum.c_curriculum_id_pk;
            lblCurriculumTitle.Text = Curriculum.c_curriculum_title;
            lblDescription.Text = Curriculum.c_curriculum_desc;
            lblAbstract.Text = Curriculum.c_curriculum_abstract;
            lblVersion.Text = Curriculum.c_curriculum_version;
            lblOwner.Text = Curriculum.c_curriculum_owner_name;
            lblcoordinator.Text = Curriculum.c_curriculum_coordinator_name;
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_icon_uri))
            {
                lnkDownload.Text = Curriculum.c_curriculum_icon_uri_file_name;
                SessionWrapper.c_curriculum_icon_uri = Curriculum.c_curriculum_icon_uri;
                SessionWrapper.c_curriculum_icon_uri_file_name = Curriculum.c_curriculum_icon_uri_file_name;
            }
            else
            {
                lnkDownload.Text = "Not defined";
                lnkDownload.OnClientClick = "return false;";
            }
            lblStatus.Text = Curriculum.c_curriculum_status_name;
            lblCost.Text = Convert.ToString(Curriculum.cost_text);
            lblVisible.Text = Curriculum.c_curriculum_visible_flag_text;
            lblApprovalRequired.Text = Curriculum.c_curriculum_approval_name;
            lblChkApprovalRequired.Text = Curriculum.c_curriculum_approval_req_text;
            if (string.IsNullOrEmpty(Curriculum.c_curriculum_recurrences_text))
            {
                lblRecurrance.Text = "None";
            }
            else
            {
                lblRecurrance.Text = Curriculum.c_curriculum_recurrences_text;
            }
            lblCreditUnits.Text = Convert.ToString(Curriculum.c_curriculum_credit_units);
            lblCreditHours.Text = Convert.ToString(Curriculum.c_curriculum_credit_hours);
            //custom section
            lblCustom01.Text = Curriculum.c_curriculum_custom_01;
            lblCustom02.Text = Curriculum.c_curriculum_custom_02;
            lblCustom03.Text = Curriculum.c_curriculum_custom_03;
            lblCustom04.Text = Curriculum.c_curriculum_custom_04;
            lblCustom05.Text = Curriculum.c_curriculum_custom_05;
            lblCustom06.Text = Curriculum.c_curriculum_custom_06;
            lblCustom07.Text = Curriculum.c_curriculum_custom_07;
            lblCustom08.Text = Curriculum.c_curriculum_custom_08;
            lblCustom09.Text = Curriculum.c_curriculum_custom_09;
            lblCustom10.Text = Curriculum.c_curriculum_custom_10;
            lblCustom11.Text = Curriculum.c_curriculum_custom_11;
            lblCustom12.Text = Curriculum.c_curriculum_custom_12;
            lblCustom13.Text = Curriculum.c_curriculum_custom_13;
            //Store Prerequisites,Equivalencies and Fulfillments in dataset
            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(CurriculumId);
            //Get Prerequisites session
            gvPrerequisites.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[3];
            gvPrerequisites.DataBind();
            //Get Equivalencies session
            gvEquivalencies.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[4];
            gvEquivalencies.DataBind();
            //Get Fulfillments session
            gvFulfillments.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[5];
            gvFulfillments.DataBind();
            //Get Attcahments
            gvCurriculumAttachments.DataSource = SystemCurriculumBLL.GetCurriculumAttchments(CurriculumId);
            gvCurriculumAttachments.DataBind();
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
            if (gvPrerequisites.Rows.Count == 0)
            {
                lblEmptyPrerequisites.Text = "None";
            }
            if (gvEquivalencies.Rows.Count == 0)
            {
                lblEmptyEquivalencies.Text = "None";
            }
            if (gvFulfillments.Rows.Count == 0)
            {
                lblEmptyFulfillments.Text = "None";
            }
        }
        protected void gvCurriculumAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string attachmentFileId = gvCurriculumAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvCurriculumAttachments.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_attachmentpath + attachmentFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }

            }
        }
        protected void dlPath_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvSection = (GridView)e.Item.FindControl("gvSection");
            Label lblCompleteSection = (Label)e.Item.FindControl("lblCompleteSection");
            BindPathSection(gvSection, dlPath.DataKeys[e.Item.ItemIndex].ToString());
            lblCompleteSection.Text = "Complete " + DataBinder.Eval(e.Item.DataItem, "sectionComplete") + " of " + DataBinder.Eval(e.Item.DataItem, "c_curricula_path_sections") + " Section(s) below to complete the requirements for this Curriculum.";

            Label lblPathCompletionPercentage = (Label)e.Item.FindControl("lblPathCompletionPercentage");
            lblPathCompletionPercentage.Text = "Completed " + DataBinder.Eval(e.Item.DataItem, "percentage") + " Completed";
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
                Label lblCompletedCoursePercentage = (Label)e.Row.FindControl("lblCompletedCoursePercentage");
                lblComplete.Text = "(Complete " + DataBinder.Eval(e.Row.DataItem, "completedcourse").ToString() + ")";
                lblCompletedCoursePercentage.Text = "Completed " + DataBinder.Eval(e.Row.DataItem, "percentage").ToString(); 
                string str_path_section_complete = DataBinder.Eval(e.Row.DataItem, "c_curricula_path_section_complete").ToString();
                BindPathCourse(gvCourses, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString(), lblComplete, str_path_section_complete);

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
                else if (status == "Pending")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Denied")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Approved")
                {
                    btnEnroll.Style.Add("display", "inline");
                }
            }
        }
        private void BindPathSection(GridView GridView, string c_curricula_path_system_id_pk)
        {
            try
            {
                GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaPathSection(CurriculumId, c_curricula_path_system_id_pk, userId);
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message);
                    }
                }
            }

        }
        private void BindPathCourse(GridView GridView, string c_curricula_path_system_id_pk, string c_curricula_path_section_id_pk, Label lblComplete, string path_section_complete)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                //DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
                DataView dvPathCourse = new DataView(EnrollmentBLL.EnrollGetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk, userId));
                dvPathCourse.RowFilter = "c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_pk + "'";
                dvPathCourse.Sort = "c_curricula_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                GridView.DataSource = dtPathCourse;
                GridView.DataBind();
                //lblComplete.Text = "(Complete " + path_section_complete + " of " + dtPathCourse.Rows.Count.ToString() + " Courses)";
                //lblComplete.Text = "(Complete " + GridView.Rows.Count + " of " + GridView.Rows.Count + " Courses)";
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message);
                    }
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
                string url = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    if (!url.Contains("http"))
                        url = "http://" + url;
                    ClientScript.RegisterStartupScript(GetType(), "Navigate", "window.open( '" + url + "', '_blank' );", true);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Navigate", "alert(Could not find the ScromURl....);", true);
                    string str = "<script>alert(\"Could not find the ScromURl....\");</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
                }

                //ClientScript.RegisterStartupScript(GetType(), "Navigate", "window.open( 'www.google.com', '_blank' );", true);

                //string url = e.CommandArgument.ToString();
                //System.Diagnostics.Process.Start(url);
                //insert enrollment
                //BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                //enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
                //enrollOLT.e_enroll_course_id_fk = e.CommandArgument.ToString();
                //enrollOLT.e_enroll_required_flag = true;
                //enrollOLT.e_enroll_approval_required_flag = true;
                //enrollOLT.e_enroll_type_name = "Self-enroll";
                //enrollOLT.e_enroll_approval_status_name = "Pending";
                //enrollOLT.e_enroll_status_name = "Enrolled";
                //EnrollmentBLL.QuickLaunchEnroll(enrollOLT);
                //Response.Redirect("~/Employee/Curricula/lvcurd-01.aspx?id=" + SecurityCenter.EncryptText(CurriculumId), false);

            }
            else if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment DropEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                DropEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                DropEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                EnrollmentBLL.DropEnrollmentStatus(DropEnrollmentStatus);
                Response.Redirect("~/Employee/Curricula/lvcurd-01.aspx?id=" + SecurityCenter.EncryptText(CurriculumId), false);
            }
        }
        //protected void dlRecertPath_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    GridView gvRecertSection = (GridView)e.Item.FindControl("gvRecertSection");
        //    Label lblCompleteSection = (Label)e.Item.FindControl("lblCompleteSection");
        //    BindRecertPathSection(gvRecertSection, dlPath.DataKeys[e.Item.ItemIndex].ToString());
        //    lblCompleteSection.Text = "Complete " + DataBinder.Eval(e.Item.DataItem, "c_curricula_recert_path_complete") + " of " + DataBinder.Eval(e.Item.DataItem, "c_curricula_recert_path_sections") + " Section(s) below to complete the requirements for this Curriculum.";
        //}
        //protected void gvRecertSection_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView GridView1 = (GridView)sender;
        //        DataListItem dlItem = (DataListItem)GridView1.Parent;
        //        DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
        //        GridView gvRecertCourses = (GridView)e.Row.FindControl("gvRecertCourses");
        //        Label lblComplete = (Label)e.Row.FindControl("lblComplete");
        //        string str_path_section_complete = DataBinder.Eval(e.Row.DataItem, "c_curricula_recert_path_section_complete").ToString();
        //        BindRecertPathCourse(gvRecertCourses, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString(), lblComplete, str_path_section_complete);

        //    }
        //}
        //protected void gvRecertCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
        //        Button btnLaunch = (Button)e.Row.FindControl("btnLaunch");
        //        Button btnDrop = (Button)e.Row.FindControl("btnDrop");
        //        string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
        //        if (status == "Assigned")
        //        {
        //            btnEnroll.Style.Add("display", "inline");
        //        }
        //        else if (status == "Enrolled")
        //        {
        //            btnDrop.Style.Add("display", "inline");
        //        }
        //    }
        //}
        //private void BindRecertPathSection(GridView GridView, string c_curricula_recert_path_system_id_pk)
        //{
        //    try
        //    {
        //        GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaRecertPathSection(CurriculumId, c_curricula_recert_path_system_id_pk);
        //        GridView.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ConfigurationWrapper.LogErrors == true)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
        //            }
        //            else
        //            {
        //                Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message);
        //            }
        //        }
        //    }

        //}
        //private void BindRecertPathCourse(GridView GridView, string c_curricula_recert_path_system_id_pk, string c_curricula_recert_path_section_id_pk, Label lblComplete, string path_section_complete)
        //{
        //    try
        //    {
        //        DataTable dtPathCourse = new DataTable();
        //        //DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
        //        DataView dvPathCourse = new DataView(EnrollmentBLL.EnrollGetSingleCurriculaRecertPathCourse(CurriculumId, c_curricula_recert_path_system_id_pk));
        //        dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_pk + "'";
        //        dvPathCourse.Sort = "c_curricula_recert_path_course_seq_number ASC";
        //        dtPathCourse = dvPathCourse.ToTable();
        //        GridView.DataSource = dtPathCourse;
        //        GridView.DataBind();
        //        lblComplete.Text = "(Complete " + path_section_complete + " of " + dtPathCourse.Rows.Count.ToString() + " Courses)";
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ConfigurationWrapper.LogErrors == true)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message, ex.InnerException.Message);
        //            }
        //            else
        //            {
        //                Logger.WriteToErrorLog("lvcurd-01.aspx", ex.Message);
        //            }
        //        }
        //    }

        //}
        //protected void gvRecertCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("Enroll"))
        //    {
        //        Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
        //    }
        //}
    }
}