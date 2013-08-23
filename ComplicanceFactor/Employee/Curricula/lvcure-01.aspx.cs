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
namespace ComplicanceFactor.Employee.Curricula
{
    public partial class lvcure_01 : System.Web.UI.Page
    {

        private string CurriculumId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = LocalResources.GetGlobalLabel("app_nav_employee") + " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a href=/Employee/Curricula/lmcurp-01.aspx>" + LocalResources.GetLabel("app_my_curricula_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_enrollment_wizard_text") + "</a>";

                ///<summary>
                //Get Curriculum id
                /// </summary>
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //Session["hi"].ToString();
                    PopulateCurriculum(CurriculumId);
                    dlPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaPath(CurriculumId,SessionWrapper.u_userid);
                    dlPath.DataBind();
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
            lblStatus.Text = Curriculum.c_curriculum_status_name;
            lblCost.Text = Convert.ToString(Curriculum.cost_text);
            lblVisible.Text = Curriculum.c_curriculum_visible_flag_text;
            lblApprovalRequired.Text = Curriculum.c_curriculum_approval_name;
            lblChkApprovalRequired.Text = Curriculum.c_curriculum_approval_req_text;
            lblCreditUnits.Text = Convert.ToString(Curriculum.c_curriculum_credit_units);
            lblCreditHours.Text = Convert.ToString(Curriculum.c_curriculum_credit_hours);


        }

        protected void dlPath_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvSection = (GridView)e.Item.FindControl("gvSection");
            BindPathSection(gvSection, dlPath.DataKeys[e.Item.ItemIndex].ToString());
            Label lblCompleteSection = (Label)e.Item.FindControl("lblCompleteSection");
            lblCompleteSection.Text = "Completed " + DataBinder.Eval(e.Item.DataItem, "sectionComplete") + " of " + DataBinder.Eval(e.Item.DataItem, "c_curricula_path_sections") + " Section(s) below to complete the requirements for this Curriculum.";

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
                Label lblMessage = (Label)e.Row.FindControl("lblMessage");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                //string e_enroll_user_id_fk = DataBinder.Eval(e.Row.DataItem, "e_enroll_user_id_fk").ToString();
                GridView GridView1 = (GridView)sender;
                //if (SessionWrapper.u_userid == e_enroll_user_id_fk)
                //{
                //    lblMessage.Text = "Already Enrolled";
                //}
                //else if(SessionWrapper.u_userid != e_enroll_user_id_fk)
                //{
                //    GridView gvDelivery = (GridView)e.Row.FindControl("gvDeliveries");
                //    GridView gvLocation = (GridView)e.Row.FindControl("gvLocation");
                //    GridView gvFacility = (GridView)e.Row.FindControl("gvFacility");
                //    GridView gvRoom = (GridView)e.Row.FindControl("gvRoom");
                //    GridView gvEnroll = (GridView)e.Row.FindControl("gvEnroll");
                //    GridView gvViewDetails = (GridView)e.Row.FindControl("gvViewDetails");
                //    BindCourseDelivery(gvDelivery, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //    BindCourseDelivery(gvLocation, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //    BindCourseDelivery(gvFacility, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //    BindCourseDelivery(gvRoom, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //    BindCourseDelivery(gvEnroll, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //    BindCourseDelivery(gvViewDetails, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                //}
                if (status == "Enrolled")// && SessionWrapper.u_userid == e_enroll_user_id_fk)
                {
                    lblMessage.Text = "Already Enrolled";
                }
                else if (status == "Assigned")
                {
                    GridView gvDelivery = (GridView)e.Row.FindControl("gvDeliveries");
                    GridView gvLocation = (GridView)e.Row.FindControl("gvLocation");
                    GridView gvFacility = (GridView)e.Row.FindControl("gvFacility");
                    GridView gvRoom = (GridView)e.Row.FindControl("gvRoom");
                    GridView gvEnroll = (GridView)e.Row.FindControl("gvEnroll");
                    BindCourseDelivery(gvDelivery, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                    BindCourseDelivery(gvLocation, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                    BindCourseDelivery(gvFacility, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                    BindCourseDelivery(gvRoom, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                    BindCourseDelivery(gvEnroll, GridView1.DataKeys[e.Row.RowIndex][0].ToString());
                    
                }
                
                
                
            }
        }
        private void BindCourseDelivery(GridView gridview, string c_curricula_path_course_id_fk)
        {
            try
            {
                DataSet dsGetCourseDelivery = new DataSet();
                dsGetCourseDelivery = SystemCatalogBLL.GetCourseDelivery(c_curricula_path_course_id_fk);
                gridview.DataSource = dsGetCourseDelivery.Tables[1];
                gridview.DataBind();
            }
            catch (Exception ex)
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
        private void BindPathSection(GridView GridView, string c_curricula_path_system_id_pk)
        {
            try
            {
                GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaPathSection(CurriculumId, c_curricula_path_system_id_pk, SessionWrapper.u_userid);
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
        private void BindPathCourse(GridView GridView, string c_curricula_path_system_id_pk, string c_curricula_path_section_id_pk, Label lblComplete, string path_section_complete)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                //DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
                DataView dvPathCourse = new DataView(EnrollmentBLL.EnrollGetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk,SessionWrapper.u_userid));
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
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lvcure-01.aspx", ex.Message);
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
        }
        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
                    string c_delivery_type_text = DataBinder.Eval(e.Row.DataItem, "c_delivery_type_text").ToString();
                    Label lblDelivery = (Label)e.Row.FindControl("lblDelivery");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    if (!string.IsNullOrEmpty(sessionDate.c_session_date_format))
                    {
                        lblDelivery.Text = "> " + c_delivery_type_text + " (" + sessionDate.c_session_date_format + ")";
                    }
                    else
                    {
                        if (c_delivery_type_text == "OLT")
                        {
                            lblDelivery.Text = "> " + c_delivery_type_text + " (Self-paced - Anytime/Anywhere)";
                        }
                        else
                        {
                            lblDelivery.Text = "> " + c_delivery_type_text + " (No Session)";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message);
                }
            }

        }
        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
                    Label lblLocation = (Label)e.Row.FindControl("lblLocation");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    lblLocation.Text = sessionDate.c_session_location_names;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message);
                }
            }
        }
        protected void gvFacility_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
                    Label lblFacility = (Label)e.Row.FindControl("lblFacility");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    lblFacility.Text = sessionDate.c_session_facility_names;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message);
                }
            }
        }
        protected void gvRoom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
                    Label lblRoom = (Label)e.Row.FindControl("lblRoom");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    lblRoom.Text = sessionDate.c_session_room_names;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("lvcure-01", ex.Message);
                }
            }
        }
        protected void btnEnrollInSelected_Click(object sender, EventArgs e)
        {
            EnrollInselected();
            dlPath.DataSource = SystemCurriculumBLL.GetSingleCurriculaPath(CurriculumId, SessionWrapper.u_userid);
            dlPath.DataBind();
        }
        private void EnrollInselected()
        {
            
            string[] getEnollmentId = hdGetEnrollvalue.Value.Split(','); // splid delivery id,course Id
            int count = Convert.ToInt32(getEnollmentId.Length.ToString()); // Get Array length
            for (int i = 0; i <= count-1; i+=2)
            {
                if(i != count-1)
                {
                    string c_delivery_system_id_pk = getEnollmentId[i].ToString();
                    string c_course_id_fk = getEnollmentId[i+1].ToString();
                   
                    Enrollment(c_course_id_fk, c_delivery_system_id_pk, false);
                }
            }
            




             

            //for (int i = 0; i < dlPath.Items.Count; i++)
            //{
            //    DataListItem dlItem = dlPath.Items[i];
            //    int dlIndex = dlItem.ItemIndex;
            //    GridView gvSection = (GridView)dlPath.Items[i].FindControl("gvSection");
            //    for (int j = 0; j < gvSection.Rows.Count; j++)
            //    {
            //        GridView gvCourses = (GridView)gvSection.Rows[j].FindControl("gvCourses");
            //        for (int k = 0; k < gvCourses.Rows.Count; k++)
            //        {
            //            GridView gvEnroll = (GridView)gvCourses.Rows[k].FindControl("gvEnroll");
            //            for (int l = 0; l < gvEnroll.Rows.Count; l++)
            //            {
            //                //GroupRadioButton g = gvEnroll.Rows[l].Cells[0].Controls[0].Controls[l] as GroupRadioButton;
            //                //string s = g.ID.ToString();
                            

            //                //foreach (Control ctrl in gvEnroll.Controls)
            //                //{
            //                //    //if (ctrl is GroupRadioButton)
            //                //    //{
            //                //    //    string id = ctrl.ID;
            //                //    //}
            //                //    //string g = ctrl.GetType().Name;
                                
            //                //    if (ctrl.GetType().ToString().Equals("Vladsm.Web.UI.WebControls.GroupRadioButton"))
            //                //    {
            //                //        if (((GroupRadioButton)ctrl).Checked)
            //                //        {
            //                //            //...Do your Stuff..
            //                //        }
            //                //    }
            //                //}

            //                //foreach (GroupRadioButton rButton in gvEnroll.Controls)
            //                //{
            //                //    if (rButton.Checked == true)
            //                //    {
            //                //        //Do something
            //                //    }
            //                //}
                            
            //                //CheckBox chkEnroll = (CheckBox)gvEnroll.Rows[l].FindControl("chkEnroll");
                            
            //                //string test = ltlCheck.Text;
            //                //if (rdbEnroll.Checked == true)
            //                //{
                            //string c_delivery_system_id_pk = gvEnroll.DataKeys[k]["c_delivery_system_id_pk"].ToString();
                            //string c_course_id_fk = gvEnroll.DataKeys[k].Values["c_course_id_fk"].ToString();
                            //enroll selected delivery
                            //Enrollment(c_course_id_fk, c_delivery_system_id_pk, false);
                            // }
            //            }
            //        }
            //    }
            //    // TextBox txtParentNativeLabe = (TextBox)dlPath.Items[i].FindControl("txtNativeLabel");
                // CheckBox chkVisible = (CheckBox)dlPath.Items[i].FindControl("chkVisible");

                //for (int j = 0; j < gvWebSubMenus.Rows.Count; j++)
                //{
                //    TextBox txtChildNativeLabel = (TextBox)gvWebSubMenus.Rows[j].FindControl("txtNativeLabel");
                //    if (txtChildNativeLabel.Text != "None")
                //    {
                //        string s_web_nav_id = gvWebSubMenus.DataKeys[j]["s_web_nav_id"].ToString();
                //        CheckBox chkVisible1 = (CheckBox)gvWebSubMenus.Rows[j].FindControl("chkVisible");
                //        //update child menu
                //        NavigationBLL.UpdateWebChildNavigation(chkVisible1.Checked, txtChildNativeLabel.Text, s_web_nav_id);
                //    }

                //}
            //}
        }
        private void Enrollment(string courseid,string deliveryId, bool check_enroll)
        {
            try
            {
                //insert enrollment
                BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_delivery_id_fk = deliveryId;
                enrollOLT.e_enroll_course_id_fk = courseid;
                enrollOLT.e_enroll_required_flag = false;
                enrollOLT.e_enroll_approval_required_flag = false;
                enrollOLT.e_enroll_type_name = "Self-enroll";
                enrollOLT.e_enroll_approval_status_name = "Pending";
                enrollOLT.e_enroll_status_name = "Enrolled";
                //for approval
                enrollOLT.e_enroll_level_1_req_flag = false;
                enrollOLT.e_enroll_approver_1_type = true;
                enrollOLT.e_enroll_approver_1_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_approver_1_decision_flag = false;
                enrollOLT.e_enroll_approver_1_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_2_req_flag = false;
                enrollOLT.e_enroll_approver_2_type = false;
                enrollOLT.e_enroll_approver_2_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_2_decision_flag = false;
                enrollOLT.e_enroll_approver_2_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_3_req_flag = false;
                enrollOLT.e_enroll_approver_3_type = false;
                enrollOLT.e_enroll_approver_3_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_3_decision_flag = false;
                enrollOLT.e_enroll_approver_3_decision_date = DateTime.Now;
                enrollOLT.e_enroll_enroll_approval_status_id_fk = string.Empty;
                enrollOLT.e_enroll_approval_final_decision_date = DateTime.Now;
                EnrollmentBLL.SingleEnroll(enrollOLT, check_enroll);
             
            }
            catch (Exception ex)
            {
                //Log here
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


        protected void gvEnroll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal ltlCheck = (Literal)e.Row.FindControl("ltlCheck");
                    string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
                    string c_course_id_fk = DataBinder.Eval(e.Row.DataItem, "c_course_id_fk").ToString();
                    ltlCheck.Text = "<input type= 'radio' id =" + c_delivery_id_pk + ',' +c_course_id_fk+" onclick='javascript:getDeliveryCourseId(this.id)' name =" + c_course_id_fk + " class='cursor_hand'/> ";
                    //ltlcheckSection.Text = "<input id=" + editCurriculumId + ',' + c_curricula_path_section_id_fk + " class='sectionnotrequired cursor_hand' type='checkbox' />";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("lvcure-01 (gvEnroll)", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("lvcure-01 (gvEnroll)", ex.Message);
                }
            }
        }

        protected void gvEnroll_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        string c_delivery_id_pk = DataBinder.Eval(e.Row.DataItem, "c_delivery_system_id_pk").ToString();
            //        string c_course_id_fk = DataBinder.Eval(e.Row.DataItem, "c_course_id_fk").ToString();

            //        GroupRadioButton rdbCheck = new GroupRadioButton();
            //        rdbCheck.ID = c_delivery_id_pk;
            //        rdbCheck.GroupName = c_course_id_fk;
            //        rdbCheck.Checked = false;
                    
            //        e.Row.Cells[0].Controls.Add(rdbCheck);

            //        if (rdbCheck.Checked == true)
            //        {
            //            string id = rdbCheck.ID;
            //        }

            //        rdbCheck.CheckedChanged += new System.EventHandler(RadioButtonCheckedChanged); 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.InnerException != null)
            //    {
            //        Logger.WriteToErrorLog("lvcure-01 (gvEnroll)", ex.Message, ex.InnerException.Message);
            //    }
            //    else
            //    {
            //        Logger.WriteToErrorLog("lvcure-01 (gvEnroll)", ex.Message);
            //    }
            //}
        }


        

    }
}