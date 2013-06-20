using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.Training

{
    public partial class tcmddp_01 : System.Web.UI.Page
    {
        private static string currentdeliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_training";

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_training_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_deliveries_text") + "</a>";

                try
                {
                    ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                    ddlDeliveryType.DataBind();
                    ddlDeliveryType.SelectedValue = "app_ddl_all_text";

                    gvMyDeliveries.DataSource = AdministratorBLL.GetDelivery(SessionWrapper.u_userid,SessionWrapper.CultureName);
                    gvMyDeliveries.DataBind();

                    SearchResult();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("tcmddp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tcmddp-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvMyDeliveries.PageCount;
            if (gvMyDeliveries.PageIndex > 0)
                gvMyDeliveries.PageIndex = gvMyDeliveries.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvMyDeliveries.PageCount;
            if (gvMyDeliveries.PageIndex > 0)
                gvMyDeliveries.PageIndex = gvMyDeliveries.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvMyDeliveries.PageIndex + 1;
            if (i <= gvMyDeliveries.PageCount)
                gvMyDeliveries.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvMyDeliveries.PageIndex + 1;
            if (i <= gvMyDeliveries.PageCount)
                gvMyDeliveries.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = gvMyDeliveries.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = gvMyDeliveries.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvMyDeliveries.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvMyDeliveries.PageSize = Convert.ToInt32(gvMyDeliveries.PageCount * gvMyDeliveries.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvMyDeliveries.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvMyDeliveries.PageSize = Convert.ToInt32(gvMyDeliveries.PageCount * gvMyDeliveries.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvMyDeliveries.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
            txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        /// <summary>
        /// Search Result
        /// </summary>
        private void SearchResult()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog course = new SystemCatalog();
            course.c_course_title = txtCourseName.Text;

            course.c_delivery_id_pk = txtDeliveryId.Text;
            course.c_delivery_type_id_fk = ddlDeliveryType.SelectedValue;

            DateTime? seesionStartDate = null;
            DateTime tempStartDate;

            if (DateTime.TryParseExact(txtDateFrom.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempStartDate))
            {
                seesionStartDate = tempStartDate;

            }
            DateTime? seesionEndDate = null;
            DateTime tempEndDate;

            if (DateTime.TryParseExact(txtDateTo.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
            {
                seesionEndDate = tempEndDate;
            }

            course.c_session_start_date = seesionStartDate;
            course.c_session_end_date = seesionEndDate;

            course.c_course_coordinator_id_fk = SessionWrapper.u_userid;

            try
            {
                gvMyDeliveries.DataSource = TrainingBLL.SearchMyCourse(course);
                gvMyDeliveries.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmddp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmddp-01", ex.Message);
                    }
                }
            }


            if (gvMyDeliveries.Rows.Count > 0)
            {
                gvMyDeliveries.UseAccessibleHeader = true;
                if (gvMyDeliveries.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvMyDeliveries.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

            if (gvMyDeliveries.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
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


        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsMyCourse = new DataSet();
            SystemCatalog course = new SystemCatalog();
            course = searchPDFExcel();
            
            try
            {
                dsMyCourse = TrainingBLL.GetCoursePdf(course,"excel");
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (ExportExcel)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (ExportExcel)", ex.Message);
                    }
                }

            }
            if (dsMyCourse.Tables[1].Rows.Count > 0)
            {
                exportDataTableToCsv(dsMyCourse.Tables[0],dsMyCourse.Tables[1]);
            }
        }
        /// <summary>
        /// Export Datatable to CSV
        /// </summary>
        /// <param name="dt"></param>
        private void exportDataTableToCsv(DataTable dt,DataTable dtDelivery)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyCourses.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtDelivery.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtDelivery.Rows[k]["deliverycolumnName"].ToString() + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ",") + ',');
                }

                //append new line
                sb.Append("\r\n");

            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        /// <summary>
        /// Print PDF
        /// </summary>
        private void PrintPdf()
        {
            rvMyDelivery.LocalReport.DataSources.Clear();
            DataSet dsMycourses = new DataSet();
            SystemCatalog course = new SystemCatalog();
            course=searchPDFExcel();
            try
            {
                dsMycourses = TrainingBLL.GetCoursePdf(course, "pdf");
            }
   
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            if (dsMycourses.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvMyDelivery.ProcessingMode = ProcessingMode.Local;
                rvMyDelivery.LocalReport.EnableExternalImages = true;
                rvMyDelivery.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Training.PdfTemplate.MyCourse.rdlc";
                rvMyDelivery.LocalReport.DataSources.Add(new ReportDataSource("dsMyCourses", dsMycourses.Tables[0]));
                byte[] bytes = rvMyDelivery.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyCourses" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }

        protected void gvMyDeliveries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Completion")
            {               
                string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyDeliveries.DataKeys[rowIndex][1].ToString();
                string deliveryType = gvMyDeliveries.DataKeys[rowIndex][2].ToString();
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType), false);
            }
            else if (e.CommandName == "Print")
            {
                //int rowIndex = int.Parse(e.CommandArgument.ToString());
                string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyDeliveries.DataKeys[rowIndex][1].ToString();
                currentdeliveryId = deliveryId;
                string deliveryType = gvMyDeliveries.DataKeys[rowIndex][2].ToString();

                rvMySignUpSheet.LocalReport.DataSources.Clear();
                DataTable dtMySession = new DataTable();
                try
                {
                    dtMySession = InstructorBLL.GetSessionForPdf(deliveryId,SessionWrapper.CultureName);

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
                        }
                    }

                }
                if (dtMySession.Rows.Count > 0)
                {
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    rvMySignUpSheet.ProcessingMode = ProcessingMode.Local;
                    rvMySignUpSheet.LocalReport.EnableExternalImages = true;
                    rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpSheet.rdlc";
                    rvMySignUpSheet.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);
                    rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsSessionDetails", dtMySession));
                    //rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
                    byte[] bytes = rvMySignUpSheet.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=\"" + "MySignUpSheet" + ".pdf" + "\"");
                    Response.BinaryWrite(bytes); // create the file     
                    Response.Flush(); // send it to the client to download  
                    Response.End();
                    Response.Close();
                }

                //Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            }
        }
        void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtEnrolledUser = new DataTable();
            try
            {
                dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(currentdeliveryId,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            //rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpEmployeeList.rdlc";
            e.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
        }


        protected void gvMyDeliveries_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        private  SystemCatalog searchPDFExcel()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog course = new SystemCatalog();
            course.c_course_title = txtCourseName.Text;
            course.c_delivery_id_pk = txtDeliveryId.Text;
            course.c_delivery_type_id_fk = ddlDeliveryType.SelectedValue;

            DateTime? seesionStartDate = null;
            DateTime tempStartDate;

            if (DateTime.TryParseExact(txtDateFrom.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempStartDate))
            {
                seesionStartDate = tempStartDate;

            }
            DateTime? seesionEndDate = null;
            DateTime tempEndDate;

            if (DateTime.TryParseExact(txtDateTo.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
            {
                seesionEndDate = tempEndDate;
            }

            course.c_session_start_date = seesionStartDate;
            course.c_session_end_date = seesionEndDate;
            course.s_locale_culture = SessionWrapper.CultureName;
            course.c_course_coordinator_id_fk = SessionWrapper.u_userid;
            return course;
        }


    }
}