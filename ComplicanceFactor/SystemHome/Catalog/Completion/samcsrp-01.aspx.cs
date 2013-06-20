using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;


namespace ComplicanceFactor.SystemHome.Catalog.Completion
{
    public partial class samcsrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Completion/samcsp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_completion_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_search_results_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Completion/samcsp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_completion_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_search_results_text") + "</a>";



                ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                ddlDeliveryType.DataBind();
                ddlDeliveryType.SelectedValue = "app_ddl_all_text";

                ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName, "saantc-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";

                SearchResult();

                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            }
        }
        private void SearchResult()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog course = new SystemCatalog();
            try
            {               
                string startdate = string.Empty;
                string enddate = string.Empty;
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    course.c_course_id_pk = txtCourseId.Text;
                    course.c_course_title = txtCourseTitle.Text;
                    course.c_course_version = txtVersion.Text;
                    course.c_delivery_id_pk = txtDeliveryId.Text;
                    course.c_delivery_title = txtDeliveryTitle.Text;
                    course.c_delivery_type_id_fk = ddlDeliveryType.SelectedValue;
                    course.c_instructor_name = txtInstructor.Text;
                    course.c_course_active_type_id_fk = ddlStatus.SelectedValue;
                    course.c_course_owner_name = txtOwner.Text;
                    course.c_course_coordinator_name = txtCoordinator.Text;
                    course.c_session_location_names = txtLocation.Text;
                    course.c_session_facility_names = txtFacility.Text;
                    course.c_session_room_names = txtRoom.Text;
                    startdate = txtDateFrom.Text;
                    enddate = txtDateTo.Text;

                }
                else
                {
                    course.c_course_id_pk = SecurityCenter.DecryptText(Request.QueryString["CourseId"]);
                    course.c_course_title = SecurityCenter.DecryptText(Request.QueryString["courseTitle"]);
                    course.c_course_version = SecurityCenter.DecryptText(Request.QueryString["version"]);
                    course.c_delivery_id_pk = SecurityCenter.DecryptText(Request.QueryString["deliveryId"]);
                    course.c_delivery_title = SecurityCenter.DecryptText(Request.QueryString["deliveryTitle"]);
                    course.c_delivery_type_id_fk = SecurityCenter.DecryptText(Request.QueryString["deliveryType"]);
                    course.c_instructor_name = SecurityCenter.DecryptText(Request.QueryString["InstructorName"]);
                    course.c_course_active_type_id_fk = SecurityCenter.DecryptText(Request.QueryString["status"]);
                    course.c_course_owner_name = SecurityCenter.DecryptText(Request.QueryString["Owner"]);
                    course.c_course_coordinator_name = SecurityCenter.DecryptText(Request.QueryString["coowner"]);
                    course.c_session_location_names = SecurityCenter.DecryptText(Request.QueryString["locationName"]);
                    course.c_session_facility_names = SecurityCenter.DecryptText(Request.QueryString["facilityName"]);
                    course.c_session_room_names = SecurityCenter.DecryptText(Request.QueryString["roomName"]);
                    startdate = SecurityCenter.DecryptText(Request.QueryString["startdate"]);
                    enddate = SecurityCenter.DecryptText(Request.QueryString["enddate"]);

                }               
                //course.c_course_id_pk = CourseId;
                //course.c_course_title = courseTitle;
                //course.c_delivery_id_pk = deliveryId;
                //course.c_delivery_title = deliveryTitle;
                //course.c_delivery_type_id_fk = deliveryType;
                //course.c_course_active_type_id_fk = status;
                //course.c_course_version = version;
                //course.c_instructor_name = InstructorName;
                //course.c_course_owner_name = Owner;
                //course.c_course_coordinator_name = coowner;
                //course.c_session_location_names = locationName;
                //course.c_session_facility_names = facilityName;
                //course.c_session_room_names = roomName;

                DateTime? seesionStartDate = null;
                DateTime tempStartDate;

                if (DateTime.TryParseExact(startdate, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempStartDate))
                {
                    seesionStartDate = tempStartDate;

                }
                DateTime? seesionEndDate = null;
                DateTime tempEndDate;

                if (DateTime.TryParseExact(enddate, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
                {
                    seesionEndDate = tempEndDate;
                }             

                course.c_session_start_date = seesionStartDate;
                course.c_session_end_date = seesionEndDate;

                gvsearchDetails.DataSource = ManageCompletionBLL.SearchSystemCatalog(course);
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
                        Logger.WriteToErrorLog("samcsrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcsrp-01.aspx", ex.Message);
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
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        private void disable()
        {
            btnHeaderFirst.Visible = false;
            btnHeaderPrevious.Visible = false;
            btnHeaderNext.Visible = false;
            btnHeaderLast.Visible = false;

            btnFooterFirst.Visible = false;
            btnFooterPrevious.Visible = false;
            btnFooterNext.Visible = false;
            btnFooterLast.Visible = false;

            ddlHeaderResultPerPage.Visible = false;
            ddlFooterResultPerPage.Visible = false;

            txtHeaderPage.Visible = false;
            lblHeaderPage.Visible = false;

            txtFooterPage.Visible = false;
            lblFooterPage.Visible = false;

            btnHeaderGoto.Visible = false;
            btnFooterGoto.Visible = false;


            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;

            lblFooterPageOf.Visible = false;
            lblHeaderPageOf.Visible = false;

        }
        private void enable()
        {
            btnHeaderFirst.Visible = true;
            btnHeaderPrevious.Visible = true;
            btnHeaderNext.Visible = true;
            btnHeaderLast.Visible = true;

            btnFooterFirst.Visible = true;
            btnFooterPrevious.Visible = true;
            btnFooterNext.Visible = true;
            btnFooterLast.Visible = true;

            ddlHeaderResultPerPage.Visible = true;
            ddlFooterResultPerPage.Visible = true;

            txtHeaderPage.Visible = true;
            lblHeaderPage.Visible = true;

            txtFooterPage.Visible = true;
            lblFooterPage.Visible = true;

            btnHeaderGoto.Visible = true;
            btnFooterGoto.Visible = true;


            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;

            lblFooterPageOf.Visible = true;
            lblHeaderPageOf.Visible = true;

        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string courseId = gvsearchDetails.DataKeys[rowIndex].Values[0].ToString();
            string deliveryId = gvsearchDetails.DataKeys[rowIndex].Values[1].ToString();
            string deliveryType = gvsearchDetails.DataKeys[rowIndex].Values[2].ToString();
            if (e.CommandName == "Select")
            {
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType), false);
            }
        }

        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchResult"] = "true";
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}