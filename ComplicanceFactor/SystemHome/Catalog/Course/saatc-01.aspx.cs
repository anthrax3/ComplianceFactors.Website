using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog
{
    public partial class saatc_01 : BasePage
    {
        #region "Private Member Variables"


        private string _pathIcon = "~/SystemHome/Catalog/Icon/";


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/sastcp-01.aspx>" + LocalResources.GetLabel("app_manage_training_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_archive_course");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + LocalResources.GetLabel("app_manage_training_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_archive_course") + "</a>";

                    ///<summary>
                    //Get course id
                    /// </summary>
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        string courseId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        PopulateCourse(courseId);
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
                            Logger.WriteToErrorLog("saatc-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saatc-01", ex.Message);
                        }
                    }
                }
            }
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_pathIcon + SessionWrapper.iconUri);

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.iconUrifilename + "\"");
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
        private void PopulateCourse(string courseId)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetCourse(courseId,SessionWrapper.CultureName);
            lblCreatedBy.Text = Course.c_created_name;
            //c_course_cert_date
            lblCreatedOn.Text = Convert.ToDateTime(Course.c_course_cert_date).ToString("MM/dd/yyyy hh:mm tt");
            lblCourseId.Text = Course.c_course_id_pk;
            lblCourseTitle.Text = Course.c_course_title;
            lblDescription.Text = Course.c_course_desc;
            lblAbstract.Text = Course.c_course_abstract;
            lblVersion.Text = Course.c_course_version;
            lblOwner.Text = Course.c_course_owner_name;
            lblcoordinator.Text = Course.c_course_coordinator_name;

            if (!string.IsNullOrEmpty(Course.c_course_icon_uri))
            {
                lnkDownload.Text = Course.c_course_icon_uri_file_name;
                SessionWrapper.iconUri = Course.c_course_icon_uri;
                SessionWrapper.iconUrifilename = Course.c_course_icon_uri_file_name;
            }
            else
            {
                lnkDownload.Text = "Not defined";
                lnkDownload.OnClientClick = "return false;";
            }

            lblStatus.Text = Course.c_course_status_name;
            lblCost.Text = Convert.ToString(Course.cost_text);
            lblVisible.Text = Course.c_course_visible_flag_text;
            lblApprovalRequired.Text = Course.c_course_approval_name;
            lblChkApprovalRequired.Text = Course.c_course_approval_req_text;
            lblRecurrance.Text = Course.c_course_recurrences_text;


            lblCreditUnits.Text = Convert.ToString(Course.c_course_credit_units);
            lblCreditHours.Text = Convert.ToString(Course.c_course_credit_hours);
            //custom section

            if (!string.IsNullOrEmpty(Course.c_course_available_from_date.ToString()))
            {
                lblAvailableFrom.Text = Convert.ToDateTime(Course.c_course_available_from_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(Course.c_course_available_to_date.ToString()))
            {
                lblAvailableTo.Text = Convert.ToDateTime(Course.c_course_available_to_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(Course.c_course_effective_date.ToString()))
            {
                lblEffectiveDate.Text = Convert.ToDateTime(Course.c_course_effective_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(Course.c_course_cut_off_date.ToString()))
            {
                lblCutOffDate.Text = Convert.ToDateTime(Course.c_course_cut_off_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(Course.c_course_cut_off_time_string.ToString()))
            {
                lblCutoffTime.Text = Convert.ToDateTime(Course.c_course_cut_off_time_string).ToShortTimeString();                
            }



            lblCustom01.Text = Course.c_course_custom_01;
            lblCustom02.Text = Course.c_course_custom_02;
            lblCustom03.Text = Course.c_course_custom_03;
            lblCustom04.Text = Course.c_course_custom_04;
            lblCustom05.Text = Course.c_course_custom_05;
            lblCustom06.Text = Course.c_course_custom_06;
            lblCustom07.Text = Course.c_course_custom_07;
            lblCustom08.Text = Course.c_course_custom_08;
            lblCustom09.Text = Course.c_course_custom_09;
            lblCustom10.Text = Course.c_course_custom_10;
            lblCustom11.Text = Course.c_course_custom_11;
            lblCustom12.Text = Course.c_course_custom_12;
            lblCustom13.Text = Course.c_course_custom_13;
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
            //Get delivery(ies)
            DataSet dsGetcourseDelivery = new DataSet();
            dsGetcourseDelivery = SystemCatalogBLL.GetCourseDelivery(courseId);
            gvDeliveries.DataSource = dsGetcourseDelivery.Tables[0];
            //Get domain
            gvDomain.DataSource = SystemCatalogBLL.GetCourseDomain(courseId);
            gvDomain.DataBind();
            //Get Category
            gvCategory.DataSource = SystemCategoriesBLL.GetCourseCategory(courseId);
            gvCategory.DataBind();
            //Get Audiences
            gvAudience.DataSource = SystemCatalogBLL.GetCourseAudiences(courseId);
            gvAudience.DataBind();
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);



        }
        protected void btnHeaderArchiveCourse_Click(object sender, EventArgs e)
        {
            Archive();
        }
        private void Archive()
        {
            try
            {
                SystemCatalog courseArchive = new SystemCatalog();
                courseArchive.c_course_system_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                courseArchive.c_course_active_flag = false;
                SystemCatalogBLL.ArchiveParticularCourse(courseArchive);
                SessionWrapper.iconUri = "";
                SessionWrapper.iconUrifilename = "";
                Response.Redirect("~/SystemHome/Catalog/Course/saetc-01.aspx?arc="+ SecurityCenter.EncryptText("arc")+"&id=" + SecurityCenter.EncryptText(SecurityCenter.DecryptText(Request.QueryString["id"])),false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saatc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saatc-01.aspx", ex.Message);
                    }
                }
            }
           
        }
        protected void btnFooterConfirmArchiveCourse_Click(object sender, EventArgs e)
        {
            Archive();
        }
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");
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
        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = gvDeliveries.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    Label lblSession = (Label)e.Row.FindControl("lblSession");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    if (!string.IsNullOrEmpty(sessionDate.c_session_date_format))
                    {
                        lblSession.Text = sessionDate.c_session_date_format;
                    }
                    else
                    {
                        lblSession.Text = "(Self-paced - Anytime/Anywhere)";
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saatc-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saatc-01", ex.Message);
                }
            }

        }
    }

}