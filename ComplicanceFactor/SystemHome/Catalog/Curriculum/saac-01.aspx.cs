using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class saac_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        private string _attachmentpath = "~/SystemHome/Catalog/Curriculum/Attachments/";
        #endregion
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Curriculum/sascp-01.aspx>" + "Manage Curriculum" + "</a>&nbsp;" + " >&nbsp;" + "Archive Curriculum";


                    ///<summary>
                    //Get Curriculum id
                    /// </summary>
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        string CurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        PopulateCurriculum(CurriculumId);
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
                            Logger.WriteToErrorLog("saac-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saac-01", ex.Message);
                        }
                    }
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
            lblCreatedBy.Text = Curriculum.c_created_name;
            //c_curriculum_cert_date
            lblCreatedOn.Text = Convert.ToDateTime(Curriculum.c_curriculum_cert_date).ToString("MM/dd/yyyy hh:mm tt");
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
                SessionWrapper.c_curriculum_icon_uri= Curriculum.c_curriculum_icon_uri;
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
            lblRecurrance.Text = Curriculum.c_curriculum_recurrences_text;


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
            //Get domain
            gvDomain.DataSource = SystemCurriculumBLL.GetCurriculumDomain(CurriculumId);
            gvDomain.DataBind();
            //Get Category
            gvCategory.DataSource = SystemCurriculumBLL.GetCurriculumCatgory(CurriculumId);
            gvCategory.DataBind();
            //Get Attcahments
            gvCurriculumAttachments.DataSource = SystemCurriculumBLL.GetCurriculumAttchments(CurriculumId);
            gvCurriculumAttachments.DataBind();
            DataSet dsCurriculumPath = SystemCurriculumBLL.GetCurriculumPathCourseSection(CurriculumId, string.Empty);
            gvPath.DataSource = dsCurriculumPath.Tables[0];
            gvPath.DataBind();
            //Get Recert Path Section
            DataSet dsCurriculumRecertPath = SystemCurriculumBLL.GetCurriculumRecertPathCourseSection(CurriculumId, string.Empty);
            gvRecertPath.DataSource = dsCurriculumRecertPath.Tables[0];
            gvRecertPath.DataBind();
            //using jquery hide the '-or-' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);



        }

        protected void btnHeaderArchiveCurriculum_Click(object sender, EventArgs e)
        {
            Archive();
        }
        private void Archive()
        {
            try
            {
                SystemCurriculum CurriculumArchive = new SystemCurriculum();
                CurriculumArchive.c_curriculum_system_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                CurriculumArchive.c_curriculum_active_flag = false;
                SystemCurriculumBLL.ArchiveParticularCurriculum(CurriculumArchive);
                SessionWrapper.c_curriculum_icon_uri = "";
                SessionWrapper.c_curriculum_icon_uri_file_name = "";
                Response.Redirect("~/SystemHome/Catalog/Curriculum/saec-01.aspx?arc=" + SecurityCenter.EncryptText("arc") + "&id=" + SecurityCenter.EncryptText(SecurityCenter.DecryptText(Request.QueryString["id"])), false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saac-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saac-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnFooterConfirmArchiveCurriculum_Click(object sender, EventArgs e)
        {
            Archive();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void gvCurriculumAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if( e.CommandName.Equals("Download"))
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
    }
}