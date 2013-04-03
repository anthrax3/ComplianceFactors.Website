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

namespace ComplicanceFactor.Manager.Catalog
{
    public partial class ctdp_01 : System.Web.UI.Page
    {
        private string c_course_approve;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            string brdCrumb = "<a href=/Manager/Catalog/qscr-01.aspx?keyword=" + SecurityCenter.EncryptText("") + ">" + " { " + LocalResources.GetGlobalLabel("app_quick_search_text") + "</a>" + " <a href=# > or </a>" + "<a href=/Manager/Catalog/ascp-01.aspx>" + LocalResources.GetGlobalLabel("app_advanced_search_text") + "</a>" + " <a href=# > or </a> " + "<a href=/Manager/Catalog/bchp-01.aspx>" + LocalResources.GetGlobalLabel("app_browse_text") + " } " + LocalResources.GetGlobalLabel("app_catalog_text") + "</a>";
            lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + " > " + brdCrumb + " > " + LocalResources.GetGlobalLabel("app_course_details_page_text");
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
            if (!IsPostBack)
            {
                try
                {
                    //temp datatable for employee 
                    TempDataTables dtEmployee = new TempDataTables();
                    SessionWrapper.Employee = dtEmployee.TempEmployee();
                    HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                    divsearch.Style.Add("display", "block");
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && SecurityCenter.DecryptText(Request.QueryString["id"]) != "")
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
                        gvDeliveries.DataSource = dsGetCourseDelivery.Tables[0];
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

            if (!string.IsNullOrEmpty(SessionWrapper.Active_Popup))
            {
                SessionWrapper.Active_Popup = string.Empty;
                Response.Redirect("~/Manager/Home/mhp-01.aspx", false);
            }

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Manager/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/ascp-01.aspx", false);
        }

        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/bchp-01.aspx", false);
        }
        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strDeliveryType = DataBinder.Eval(e.Row.DataItem, "c_delivery_type_text").ToString();
                int c_delivery_max_waitlist = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "c_delivery_max_waitlist_check"));
                string c_course_id_fk = DataBinder.Eval(e.Row.DataItem, "c_course_id_fk").ToString();
                string c_delivery_waitlist_flag = DataBinder.Eval(e.Row.DataItem, "c_delivery_waitlist_flag").ToString();
                Literal ltlEnroll = (Literal)e.Row.FindControl("ltlEnroll");
                Label lblAlreadyEnrollMessage = (Label)e.Row.FindControl("lblAlreadyEnrollMessage");
                //get delivery system id
                string e_enroll_delivery_id_fk = gvDeliveries.DataKeys[e.Row.RowIndex].Value.ToString();
                //approval required or not for course
                string approvalDelivery = gvDeliveries.DataKeys[e.Row.RowIndex].Values[1].ToString();
                //check delivery is already enrolled or not
                BusinessComponent.DataAccessObject.Enrollment getEnrollDelivery = new BusinessComponent.DataAccessObject.Enrollment();
                getEnrollDelivery = EnrollmentBLL.GetEnrollDeliveries(e_enroll_delivery_id_fk, SessionWrapper.u_userid);
                string strEnrollType = getEnrollDelivery.e_enroll_type_name;
                //it check whether the user is already in waitlist and wailist is full or not. if the user is not in waitlist and waitlist is not full, then user can view the "Enroll" button
                //Note: only when waiitlist flat is true.
                int waitlistCountIdentification = EnrollmentBLL.GetWaitListcount(e_enroll_delivery_id_fk, SessionWrapper.u_userid);
                ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + "," + 1 + " class='enroll' value= " + LocalResources.GetLabel("app_enroll_button_text") + " />";
                 //if (!string.IsNullOrEmpty(strDeliveryType) && strDeliveryType == "OLT" && approvalDelivery == "False" && string.IsNullOrEmpty(strEnrollType))
                 //   {

                 //       if (c_delivery_waitlist_flag == "True" && waitlistCountIdentification == 1)
                 //       {
                 //           lblAlreadyEnrollMessage.Text = "***Already in Waitlist**";
                 //       }
                 //       else
                 //       {
                 //           //btnQuickLunch.Style.Add("display", "inline");
                 //           ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve +","+ 1 + " class='enroll' value='Enroll !' />";
                 //       }
                 //   }
                 //   else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Self-enroll")
                 //   {
                 //       //btnDrop.Style.Add("display", "inline");
                 //       lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                 //       ltlEnroll.Text = "";
                 //       //btnQuickLunch.Style.Add("display", "none");
                 //   }
                 //   else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType != "Self-enroll")
                 //   {
                 //       lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                 //       //btnDrop.Style.Add("display", "none");
                 //       ltlEnroll.Text = "";
                 //       // btnQuickLunch.Style.Add("display", "none");
                 //   }
                 //   else if (string.IsNullOrEmpty(strEnrollType))
                 //   {
                 //       //btnDrop.Style.Add("display", "none");
                 //       lblAlreadyEnrollMessage.Text = string.Empty;
                 //       if (c_delivery_waitlist_flag == "True" && waitlistCountIdentification == 1)
                 //       {
                 //           // 0 out of 1
                 //           lblAlreadyEnrollMessage.Text = "***Already in Waitlist**";
                 //       }
                 //       else
                 //       {
                 //           ltlEnroll.Text = "<input type=button id=" + e_enroll_delivery_id_fk + "," + strDeliveryType + "," + c_course_id_fk + "," + c_delivery_waitlist_flag + "," + approvalDelivery + "," + c_course_approve + ","+ 1 +" class='enroll' value='Enroll !' />";
                 //       }
                 //   }
                
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




    }
}