using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.Employee.Catalog
{
    public partial class ctdp_01 : BasePage
    {
        private string c_course_approve;
        private string courseId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            string brdCrumb = "<a href=/Employee/Catalog/qscr-01.aspx?keyword=" + SecurityCenter.EncryptText("") + ">" + " { " + LocalResources.GetGlobalLabel("app_quick_search_text") + "</a>" + " <a href=# > or </a>" + "<a href=/Employee/Catalog/ascp-01.aspx>" + LocalResources.GetGlobalLabel("app_advanced_search_text") + "</a>" + " <a href=# > or </a> " + "<a href=/Employee/Catalog/bchp-01.aspx>" + LocalResources.GetGlobalLabel("app_browse_text") + " } " + LocalResources.GetGlobalLabel("app_catalog_text") + "</a>";
            lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " > " + brdCrumb + " > " + LocalResources.GetGlobalLabel("app_course_details_page_text");
            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);
            //store approval or not (true or false)
            if (!string.IsNullOrEmpty(Request.QueryString["ca"]))
            {
                c_course_approve = SecurityCenter.DecryptText(Request.QueryString["ca"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                courseId = SecurityCenter.DecryptText(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                try
                {
                    
                    HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                    divsearch.Style.Add("display", "block");
                    if (!string.IsNullOrEmpty(courseId))
                    {
                        DataTable dtGetCourse = new DataTable();
                        dtGetCourse = EmployeeCatalogBLL.GetCourse(SecurityCenter.DecryptText(Request.QueryString["id"]));
                        gvsearchDetails.DataSource = dtGetCourse;
                        gvsearchDetails.DataBind();
                        EmployeeCatalog catalog = new EmployeeCatalog();
                        catalog = EmployeeCatalogBLL.GetCourseDetails(SecurityCenter.DecryptText(Request.QueryString["id"]));
                        lblCourseTitleId.Text = "{" + catalog.c_course_title + "}" + " " + "({" + catalog.c_course_id_pk + "})";
                        lblRecurrences.Text = catalog.c_course_recurrences_text;
                        DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(SecurityCenter.DecryptText(Request.QueryString["id"]));
                        //Get Prerequisites
                        gvPrerequisites.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[3];
                        gvPrerequisites.DataBind();
                        //Get Equivalencies 
                        gvEquivalencies.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[4];
                        gvEquivalencies.DataBind();
                        //Get Fulfilments
                        gvFulfillments.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[5];
                        gvFulfillments.DataBind();
                        //using jquery hide the '-or-' in last row
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
                        //Get delivery(ies)
                        DataSet dsGetCourseDelivery = new DataSet();
                        dsGetCourseDelivery = SystemCatalogBLL.GetCourseDelivery(SecurityCenter.DecryptText(Request.QueryString["id"]));
                        gvDeliveries.DataSource = dsGetCourseDelivery.Tables[1];
                        gvDeliveries.DataBind();
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
                            Logger.WriteToErrorLog("ctdp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ctdp-01.aspx", ex.Message);
                        }
                    }
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
        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strDeliveryType = DataBinder.Eval(e.Row.DataItem, "c_delivery_type_text").ToString();
                int delivery_count = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "delivery_count"));
                int c_delivery_max_waitlist = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "c_delivery_max_waitlist_check"));
                string c_course_id_fk = DataBinder.Eval(e.Row.DataItem,"c_course_id_fk").ToString();
                string c_delivery_waitlist_flag = DataBinder.Eval(e.Row.DataItem, "c_delivery_waitlist_flag").ToString();
                Button btnQuickLunch = (Button)e.Row.FindControl("btnQuickLunch");
                Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                Literal ltlEnroll = (Literal)e.Row.FindControl("ltlEnroll");
                Label lblAlreadyEnrollMessage = (Label)e.Row.FindControl("lblAlreadyEnrollMessage");
                //get delivery system id
                string e_enroll_delivery_id_fk = gvDeliveries.DataKeys[e.Row.RowIndex].Value.ToString();
                //approval required or not for course
                string approvalDelivery = gvDeliveries.DataKeys[e.Row.RowIndex].Values[1].ToString();
                //check delivery is already enrolled or not
                BusinessComponent.DataAccessObject.Enrollment getEnrollDelivery = new BusinessComponent.DataAccessObject.Enrollment();
                bool isEnroll = false;
                getEnrollDelivery = EnrollmentBLL.GetEnrollDeliveries(e_enroll_delivery_id_fk, SessionWrapper.u_userid);
                
                string strEnrollType = getEnrollDelivery.e_enroll_type_name;
                //it check whether the user is already in waitlist and wailist is full or not. if the user is not in waitlist and waitlist is not full, then user can view the "Enroll" button
                //Note: only when waiitlist flat is true.
                int waitlistCountIdentification = EnrollmentBLL.GetWaitListcount(e_enroll_delivery_id_fk, SessionWrapper.u_userid);

                isEnroll = EnrollmentBLL.CheckDeliveryEnrollorNot(c_course_id_fk, SessionWrapper.u_userid);
                //
                //Call the BL for is Enroll 

                if (SessionWrapper.isLeraningHistory == false)
                {
                    //if (!string.IsNullOrEmpty(strEnrollType))
                    if (isEnroll && string.IsNullOrEmpty(strEnrollType))
                    {
                        //btnDrop.Style.Add("display", "inline");
                        lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                        ltlEnroll.Text = "";
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(strDeliveryType) && strDeliveryType == "OLT" 
                                && approvalDelivery == "False" && 
                                    (string.IsNullOrEmpty(strEnrollType) || strEnrollType == "Completed"))
                        {

                            if (c_delivery_waitlist_flag == "True" && waitlistCountIdentification == 1)
                            {

                                lblAlreadyEnrollMessage.Text = "***Already in Waitlist**";

                            }
                            else
                            {
                                if (delivery_count == 0)
                                {
                                    btnQuickLunch.Style.Add("display", "inline");
                                }


                                ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + "  class='enroll cursor_hand' value= " + LocalResources.GetLabel("app_enroll_button_text") + " />";

                            }
                        }
                        else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Self-enroll")
                        {

                            btnDrop.Style.Add("display", "inline");
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            ltlEnroll.Text = "";

                            //btnQuickLunch.Style.Add("display", "none");
                        }
                        else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType != "Self-enroll" && strEnrollType != "Completed")
                        {

                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnDrop.Style.Add("display", "none");
                            ltlEnroll.Text = "";

                            // btnQuickLunch.Style.Add("display", "none");
                        }
                        else if (string.IsNullOrEmpty(strEnrollType) || strEnrollType == "Completed")
                        {

                            btnDrop.Style.Add("display", "none");
                            lblAlreadyEnrollMessage.Text = string.Empty;
                            if (c_delivery_waitlist_flag == "True" && waitlistCountIdentification == 1)
                            {
                                // 0 out of 1
                                lblAlreadyEnrollMessage.Text = "***Already in Waitlist**";

                            }
                            else
                            {

                                ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + " class='enroll cursor_hand' value= " + LocalResources.GetLabel("app_enroll_button_text") + " />";
                                

                            }
                        }
                    }
                }
                else
                {
                    ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + "  class='enroll cursor_hand' value= " + LocalResources.GetLabel("app_enroll_button_text") + " />";

                      if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Self-enroll")
                        {

                            ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + "  class='reenroll cursor_hand' value='Re-Enroll' />";
                            
                        }
                }
                //session date and time
                Label lblSession = (Label)e.Row.FindControl("lblSession");
                SystemCatalog sessionDate = new SystemCatalog();
                sessionDate = SystemCatalogBLL.GetSessionDate(e_enroll_delivery_id_fk);
                if (!string.IsNullOrEmpty(sessionDate.c_session_date_format))
                {
                    lblSession.Text = sessionDate.c_session_date_format;
                }
                else
                {
                    //this for if session time is empty
                    lblSession.Text = "(Self-paced - Anytime/Anywhere)";
                }
            }
        }

        protected void gvDeliveries_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment DropEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                DropEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                DropEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                EnrollmentBLL.DropEnrollmentStatus(DropEnrollmentStatus);
                Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(courseId), false);
                //Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(courseId) + "&ca=" + SecurityCenter.EncryptText(c_course_approve), false);
                
            }
        }




    }
}