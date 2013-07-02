using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.Employee.Catalog
{
    public partial class qscr_01 : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);
            if (!IsPostBack)
            {


                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " > " + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_quicksearch_catalog_text") + "</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["Keyword"]))
                {

                    HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                    divsearch.Style.Add("display", "block");
                    SearchResult();
                    lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

                    ListItem liAll = new ListItem();
                    liAll.Text = "All";
                    liAll.Value = "1";
                    try
                    {
                        //type
                        ddlType.DataSource = EmployeeCatalogBLL.GetCatalogType(SessionWrapper.CultureName, "qscr-01");
                        ddlType.DataBind();
                        //delivery type
                        ddlDelivery.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                        ddlDelivery.DataBind();
                        //Language
                        ddlLanguage.DataSource = EmployeeCatalogBLL.GetLocalelist();
                        ddlLanguage.DataBind();
                        ddlLanguage.Items.Insert(0, liAll);
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("qscr-01.aspx (Dropdown DataBinding)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("qscr-01.aspx (Dropdown DataBinding)", ex.Message);
                            }
                        }
                    }
                }
            }
            //check enroll popup is view or not
            if (!string.IsNullOrEmpty(SessionWrapper.Active_Popup))
            {
                SessionWrapper.Active_Popup = string.Empty;
                Response.Redirect("~/Employee/Home/lhp-01.aspx", false);
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
        private void QuickSearchResult()
        {
            try
            {

                gvsearchDetails.DataSource = EmployeeCatalogBLL.QuickSearchResult(SecurityCenter.DecryptText(Request.QueryString["Keyword"]));
                gvsearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("qscr-01.aspx QuickSearchResult()", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("qscr-01.aspx QuickSearchResult()", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
            }
        }
        private void SearchResult()
        {
            try
            {

                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {

                    EmployeeCatalog catalog = new EmployeeCatalog();
                    catalog.c_course_title = txtTitle.Text;
                    catalog.c_course_id_pk = txtId.Text;
                    catalog.keyword = txtKeyword.Text;
                    catalog.c_type = ddlType.SelectedValue;
                    catalog.c_delivery_id_fk = ddlDelivery.SelectedValue;
                    catalog.c_language = ddlLanguage.SelectedValue;
                    gvsearchDetails.DataSource = EmployeeCatalogBLL.SearchCatalog(catalog);
                    gvsearchDetails.DataBind();

                }
                else
                {
                    gvsearchDetails.DataSource = EmployeeCatalogBLL.QuickSearchResult(SecurityCenter.DecryptText(Request.QueryString["Keyword"]));
                    gvsearchDetails.DataBind();
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
                        Logger.WriteToErrorLog("qscr-01.aspx (SearchResult())", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("qscr-01.aspx (SearchResult())", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
            }
        }
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;


            SearchResult();


        }
        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    //get system id (i.e course or curriculum or program)
                    string system_id = gvsearchDetails.DataKeys[e.Row.RowIndex].Value.ToString();
                    //get type (course,curriculum and program)
                    string type = gvsearchDetails.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    //approval required or not for course
                    string approvalCourse = gvsearchDetails.DataKeys[e.Row.RowIndex].Values[2].ToString();
                    //find controls
                    Button btnQuickLunch = (Button)e.Row.FindControl("btnQuickLaunch");
                    Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                    Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
                    Button btnAssign = (Button)e.Row.FindControl("btnAssign");
                    Button btnDownload = (Button)e.Row.FindControl("btnDownload");
                    Label lblAlreadyEnrollMessage = (Label)e.Row.FindControl("lblAlreadyEnrollMessage");
                    //check if the type is course or curriculum or program
                    if (type == "Course")
                    {
                        //Get "OLT" delivery 
                        DataSet dsDelivery = new DataSet();
                        dsDelivery = EmployeeCatalogBLL.GetOLT(system_id);
                        //get if "OLT" delivery exist or not
                        EmployeeCatalog getOLTDelivery = new EmployeeCatalog();
                        getOLTDelivery = EmployeeCatalogBLL.GetSingleOLTDelivery(system_id, dsDelivery.Tables[0]);
                        string strDeliveryType = getOLTDelivery.c_delivery_type_text;
                        //check delivery is already enrolled or not
                        BusinessComponent.DataAccessObject.Enrollment getEnrollDelivery = new BusinessComponent.DataAccessObject.Enrollment();
                        getEnrollDelivery = EnrollmentBLL.GetEnrollCourse(system_id, SessionWrapper.u_userid);
                        //approval required or not for delivery
                        bool approvDelivery = EmployeeCatalogBLL.GetApprovalDelivery(system_id, dsDelivery.Tables[1]);
                        //get enroll type
                        string strEnrollType = getEnrollDelivery.e_enroll_type_name;
                        if (strDeliveryType == "OLT" && approvalCourse == "False" && approvDelivery == false && getOLTDelivery.c_delivery_count == 1 && string.IsNullOrEmpty(strEnrollType))
                        {
                            btnQuickLunch.Style.Add("display", "inline");
                        }
                        else if (strDeliveryType == "OLT" && approvalCourse == "False" && approvDelivery == false && getOLTDelivery.c_delivery_count == 1 && !string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Self-enroll")
                        {
                            btnDrop.Style.Add("display", "inline");
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnEnroll.Style.Add("display", "none");
                        }
                        // Because this course is alredy enrolled and completed. see lerning history
                        else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Completed")
                        {
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnDrop.Style.Add("display", "none");
                            btnEnroll.Style.Add("display", "none");
                        }
                        // Because this course is alredy enrolled and not completed.

                        if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Self-enroll")
                        {

                            btnDrop.Style.Add("display", "inline");
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnEnroll.Style.Add("display", "none");

                        }
                        else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType == "Assigned")
                        {
                            lblAlreadyEnrollMessage.Text = "***Assigned***";
                            btnDrop.Style.Add("display", "none");
                            btnEnroll.Style.Add("display", "none");

                        }
                        else if (!string.IsNullOrEmpty(strEnrollType) && strEnrollType != "Self-enroll")
                        {
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnDrop.Style.Add("display", "none");
                            btnEnroll.Style.Add("display", "none");

                        }
                        else if (!string.IsNullOrEmpty(strEnrollType))
                        {
                            lblAlreadyEnrollMessage.Text = "***Already Enrolled***";
                            btnDrop.Style.Add("display", "none");
                            btnEnroll.Style.Add("display", "none");
                        }

                        else if (string.IsNullOrEmpty(strEnrollType))
                        {
                            btnDrop.Style.Add("display", "none");
                            lblAlreadyEnrollMessage.Text = string.Empty;
                        }
                    }
                    else if (type == "Curriculum")
                    {
                        Enrollment getAssignCurriculum = new Enrollment();
                        getAssignCurriculum = EnrollmentBLL.GetAssignCourse(system_id, SessionWrapper.u_userid);
                        btnDrop.Style.Add("display", "none");
                        btnEnroll.Style.Add("display", "none");

                        //if (!string.IsNullOrEmpty(getAssignCurriculum.e_curriculum_assign_curriculum_id_fk))
                        //{
                        //    lblAlreadyEnrollMessage.Text = "***Assigned***";
                        //}
                        //else
                        //{
                        //    lblAlreadyEnrollMessage.Text = string.Empty;
                        //    btnAssign.Style.Add("display", "inline");
                        //}
                        if (!string.IsNullOrEmpty(getAssignCurriculum.e_curriculum_assign_status) && getAssignCurriculum.e_curriculum_assign_status == "Assigned")
                        {
                            lblAlreadyEnrollMessage.Text = "***Assigned***";

                        }
                        else if (!string.IsNullOrEmpty(getAssignCurriculum.e_curriculum_assign_status) && getAssignCurriculum.e_curriculum_assign_status == "In Progress")
                        {
                            lblAlreadyEnrollMessage.Text = "***In Progress (" + getAssignCurriculum.e_curriculum_assign_percent_complete + ")***";
                        }
                        else if (!string.IsNullOrEmpty(getAssignCurriculum.e_curriculum_assign_status) && getAssignCurriculum.e_curriculum_assign_status == "Acquired")
                        {
                            lblAlreadyEnrollMessage.Text = "***Completed***";
                        }
                        else
                        {
                            lblAlreadyEnrollMessage.Text = string.Empty;
                            btnAssign.Style.Add("display", "inline");
                        }

                    }
                    else if (type == "Document")
                    {

                        btnDownload.Style.Add("display", "inline");
                        btnDrop.Style.Add("display", "none");
                        btnEnroll.Style.Add("display", "none");
                    }

                    string harmId = gvsearchDetails.DataKeys[e.Row.RowIndex][0].ToString();
                    btnDownload.OnClientClick = "window.open('ctdocv-01.aspx?View=" + SecurityCenter.EncryptText(system_id) + "','',''); return true;";
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("qscr-01.aspx (RowDataBound)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("qscr-01.aspx (RowDataBound)", ex.Message);
                        }
                    }
                }
            }

        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Detail"))
                {
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    string system_id = gvsearchDetails.DataKeys[index].Values[0].ToString();
                    string c_course_approve_req = gvsearchDetails.DataKeys[index].Values[2].ToString();
                    string c_type = gvsearchDetails.DataKeys[index].Values[1].ToString();
                    if (c_type == "Course")
                    {
                        Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(system_id) + "&ca=" + SecurityCenter.EncryptText(c_course_approve_req), false);
                    }
                    else if (c_type == "Curriculum")
                    {
                        Response.Redirect("~/Employee/Curricula/lvcure-01.aspx?id=" + SecurityCenter.EncryptText(system_id), false);
                    }
                    else if (c_type == "Document")
                    {
                        Response.Redirect("~/Employee/Catalog/ctdocp-01.aspx?id=" + SecurityCenter.EncryptText(system_id), false);
                    }

                }
                else if (e.CommandName.Equals("Assign"))
                {

                    //Assign Curricula
                    BusinessComponent.DataAccessObject.Enrollment assignCurricula = new BusinessComponent.DataAccessObject.Enrollment();
                    assignCurricula.e_curriculum_assign_user_id_fk = SessionWrapper.u_userid;
                    assignCurricula.e_curriculum_assign_curriculum_id_fk = e.CommandArgument.ToString();
                    assignCurricula.e_curriculum_assign_required_flag = true;
                    assignCurricula.e_curriculum_assign_target_due_date = DateTime.UtcNow; //set empty on EnrollmentBLL  for self assign
                    assignCurricula.e_curriculum_assign_recert_due_date = DateTime.UtcNow;
                    assignCurricula.e_curriculum_assign_recert_status_id_fk = string.Empty;
                    assignCurricula.e_curriculum_assign_status_id_fk = "Assigned";
                    assignCurricula.e_curriculum_assign_percent_complete = 0;
                    assignCurricula.e_curriculum_assign_active_flag = true;
                    EnrollmentBLL.AssignCurricula(assignCurricula);
                    Response.Redirect("~/Employee/Home/lhp-01.aspx", false);
                }
                else if (e.CommandName.Equals("QuickLaunch"))
                {

                    //insert enrollment
                    BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                    enrollOLT.e_enroll_system_id_pk = Guid.NewGuid().ToString();
                    enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
                    enrollOLT.e_enroll_course_id_fk = e.CommandArgument.ToString();
                    enrollOLT.e_enroll_required_flag = true;
                    enrollOLT.e_enroll_approval_required_flag = false;
                    enrollOLT.e_enroll_type_name = "Self-enroll";
                    enrollOLT.e_enroll_approval_status_name = "Pending";
                    enrollOLT.e_enroll_status_name = "Enrolled";

                    int result = EnrollmentBLL.QuickLaunchEnroll(enrollOLT);
                    if (result == 0)
                    {
                        string url = "/LMS/CoursePlayer.aspx?eid=" + enrollOLT.e_enroll_system_id_pk + "&AICC_SID=" + enrollOLT.e_enroll_system_id_pk + "&AICC_URL=compliancefactors.com.lavender.arvixe.com/LMS/HACP_Handler.aspx";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "windowopen", "window.open('" + url + "','_blank','height=' + screen.height + ',width=' + screen.width + ',location=0,menubar=0,status=0,toolbar=0,resizable=1')", true);
                    }
                    //Response.Redirect(Request.RawUrl);
                    SearchResult();


                }
                else if (e.CommandName.Equals("Drop"))
                {
                    BusinessComponent.DataAccessObject.Enrollment DropEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                    DropEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                    DropEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                    EnrollmentBLL.DropEnrollmentStatus(DropEnrollmentStatus);
                    Response.Redirect("~/Employee/Home/lhp-01.aspx", false);

                }

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("qscr-01.aspx (RowCommand)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("qscr-01.aspx (RowCommand)", ex.Message);
                    }
                }
            }

        }
        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void btnFirstHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnPreviousHeader_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnNextHeader_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();


        }
        protected void btnLastHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnGotoHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtPageHeader.Text) - 1;

            SearchResult();

            txtPageFooter.Text = txtPageHeader.Text;

        }
        protected void btnFirstFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnPreviousFooter_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnNextFooter_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnLastFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnGotoFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtPageFooter.Text) - 1;

            SearchResult();

            txtPageHeader.Text = txtPageFooter.Text;

        }
        protected void ddlResultPerPageHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlResultPerPageHeader.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlResultPerPageHeader.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlResultPerPageFooter.SelectedValue = ddlResultPerPageHeader.SelectedValue;

            SearchResult();

            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void ddlResultPerPageFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlResultPerPageFooter.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlResultPerPageFooter.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlResultPerPageHeader.SelectedValue = ddlResultPerPageFooter.SelectedValue;

            SearchResult();

            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {

            ViewState["SearchResult"] = "true";

            SearchResult();

            txtPageFooter.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageFooter.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPageHeader.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPageHeader.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlResultPerPageFooter.SelectedIndex = 0;
            ddlResultPerPageHeader.SelectedIndex = 0;



        }
        private void disable()
        {
            btnFirstHeader.Visible = false;
            btnPreviousHeader.Visible = false;
            btnNextHeader.Visible = false;
            btnLastHeader.Visible = false;

            btnFirstFooter.Visible = false;
            btnNextFooter.Visible = false;
            btnPreviousFooter.Visible = false;
            btnLastFooter.Visible = false;

            ddlResultPerPageHeader.Visible = false;
            ddlResultPerPageFooter.Visible = false;

            txtPageHeader.Visible = false;
            lblPageHeader.Visible = false;

            txtPageFooter.Visible = false;
            lblPageFooter.Visible = false;

            btnGotoHeader.Visible = false;
            btnGotoFooter.Visible = false;


            lblHeaderResultPerPage.Visible = false;
            lblResultPerPageFooter.Visible = false;


            lblPageOfPageFooter.Visible = false;
            lblPageOfPageHeader.Visible = false;
        }
        private void enable()
        {
            btnFirstHeader.Visible = true;
            btnPreviousHeader.Visible = true;
            btnNextHeader.Visible = true;
            btnLastHeader.Visible = true;

            btnFirstFooter.Visible = true;
            btnNextFooter.Visible = true;
            btnPreviousFooter.Visible = true;
            btnLastFooter.Visible = true;

            ddlResultPerPageHeader.Visible = true;
            ddlResultPerPageFooter.Visible = true;

            txtPageHeader.Visible = true;
            lblPageHeader.Visible = true;

            txtPageFooter.Visible = true;
            lblPageFooter.Visible = true;

            btnGotoHeader.Visible = true;
            btnGotoFooter.Visible = true;


            lblHeaderResultPerPage.Visible = true;
            lblResultPerPageFooter.Visible = true;

            lblPageOfPageFooter.Visible = true;
            lblPageOfPageHeader.Visible = true;
        }

    }
}