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

namespace ComplicanceFactor.Administrator
{
    public partial class taddp_01 : System.Web.UI.Page
    {
        DataSet dsDelivery = new DataSet();
        private static string currentdeliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Administrator/tahp-01.aspx>" + LocalResources.GetGlobalLabel("app_administrator_text") + "</a>&nbsp;" + " >&nbsp;<a href=/Administrator/tahp-01.aspx>" + "Home" + "</a>&nbsp;>&nbsp;" + LocalResources.GetGlobalLabel("app_my_courses_text");

                try
                {
                    ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                    ddlDeliveryType.DataBind();
                    ddlDeliveryType.SelectedValue = "app_ddl_all_text";
                    SearchResult();

                    txtFooterPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
                    lblFooterPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();
                    txtHeaderPage.Text = (gvMyDeliveries.PageIndex + 1).ToString();
                    lblHeaderPageOf.Text = "of " + (gvMyDeliveries.PageCount).ToString();

                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("taddp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tamddp-01", ex.Message);
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

            course.c_course_id_pk = txtCourseId.Text;
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

                gvMyDeliveries.DataSource = AdministratorBLL.SearchMyCourseAdmin(course);
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
            
            DataSet dsMycourses = new DataSet();
            DataSet dsHeaderFooter = new DataSet();

            SystemCatalog course = new SystemCatalog();
            course = SearchPDFExcel();
          
            try
            {
                dsMyCourse = AdministratorBLL.GetCourseExcel(course);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("taddp-01.aspx (ExportExcel)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("taddp-01.aspx (ExportExcel)", ex.Message);
                    }
                }

            }           

            if (dsMyCourse.Tables[0].Rows.Count > 0)
            {
                exportDataTableToCsv(dsMyCourse.Tables[0], dsMyCourse.Tables[1]);
            }
        }
        /// <summary>
        /// Export Datatable to CSV
        /// </summary>
        /// <param name="dt"></param>
        private void exportDataTableToCsv(DataTable dt, DataTable dtcolumnName)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyLearningHistory.csv");
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtcolumnName.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtcolumnName.Rows[k]["columnName"].ToString() + ',');
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
            CultureInfo culture = new CultureInfo("en-US");
            DataSet dsMycourses = new DataSet();
            DataSet dsHeaderFooter = new DataSet();

            SystemCatalog course = new SystemCatalog();
            course = SearchPDFExcel();

            try
            {
                dsMycourses = AdministratorBLL.GetCoursePdf(course);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("taddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("taddp-01.aspx (PDF)", ex.Message);
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
                rvMyDelivery.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Administrator.PdfTemplate.MyCourse_Admin.rdlc";
                rvMyDelivery.LocalReport.DataSources.Add(new ReportDataSource("dsAdminCourse", dsMycourses.Tables[0]));
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

        private SystemCatalog SearchPDFExcel()
        {
            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog course = new SystemCatalog();
            course.c_course_title = txtCourseName.Text;

            course.c_course_id_pk = txtCourseId.Text;
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
            course.s_locale_culture = SessionWrapper.CultureName;
            return course;
        }

        protected void gvMyDeliveries_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Manage")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
                Response.Redirect("~/SystemHome/Catalog/Course/saetc-01.aspx?id=" + SecurityCenter.EncryptText(courseId), false);
            }
            //if (e.CommandName == "Completion")
            //{
            //    int rowIndex = int.Parse(e.CommandArgument.ToString());
            //    string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
            //    string deliveryId = gvMyDeliveries.DataKeys[rowIndex][1].ToString();
            //    string deliveryType = gvMyDeliveries.DataKeys[rowIndex][2].ToString();
            //    Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType), false);
            //}
            //else if (e.CommandName == "Print")
            //{
            //    int rowIndex = int.Parse(e.CommandArgument.ToString());
            //    string harmId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
            //    //Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            //    //int rowIndex = int.Parse(e.CommandArgument.ToString());
            //    string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
            //    string deliveryId = gvMyDeliveries.DataKeys[rowIndex][1].ToString();
            //    currentdeliveryId = deliveryId;
            //    string deliveryType = gvMyDeliveries.DataKeys[rowIndex][2].ToString();

            //    rvMySignUpSheet.LocalReport.DataSources.Clear();
            //    DataTable dtMySession = new DataTable();
            //    try
            //    {
            //        dtMySession = InstructorBLL.GetSessionForPdf(deliveryId, SessionWrapper.CultureName);

            //    }
            //    catch (Exception ex)
            //    {
            //        //TODO: Show user friendly error here
            //        //Log here
            //        if (ConfigurationWrapper.LogErrors == true)
            //        {
            //            if (ex.InnerException != null)
            //            {
            //                Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
            //            }
            //            else
            //            {
            //                Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
            //            }
            //        }

            //    }
            //    if (dtMySession.Rows.Count > 0)
            //    {
            //        Warning[] warnings;
            //        string[] streamIds;
            //        string mimeType = string.Empty;
            //        string encoding = string.Empty;
            //        string extension = string.Empty;
            //        rvMySignUpSheet.ProcessingMode = ProcessingMode.Local;
            //        rvMySignUpSheet.LocalReport.EnableExternalImages = true;
            //        rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpSheet.rdlc";
            //        rvMySignUpSheet.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);
            //        rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsSessionDetails", dtMySession));
            //        //rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
            //        byte[] bytes = rvMySignUpSheet.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //        Response.Buffer = true;
            //        Response.Clear();
            //        Response.ClearHeaders();
            //        Response.ContentType = mimeType;
            //        Response.AddHeader("content-disposition", "attachment; filename=\"" + "MySignUpSheet" + ".pdf" + "\"");
            //        Response.BinaryWrite(bytes); // create the file     
            //        Response.Flush(); // send it to the client to download  
            //        Response.End();
            //        Response.Close();
            //    }
            //}
        }
        void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtEnrolledUser = new DataTable();
            try
            {
                dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(currentdeliveryId, SessionWrapper.CultureName);
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
    }
}