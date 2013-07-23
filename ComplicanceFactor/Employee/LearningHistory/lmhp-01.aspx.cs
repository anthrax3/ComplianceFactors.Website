using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Text;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.Common.Languages;
using System.Globalization;

namespace ComplicanceFactor.Employee.LearningHistory
{
    public partial class lmhp_01 : System.Web.UI.Page
    {
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_learning_history_text") + "</a>";

            if (!IsPostBack)
            {
                SearchResult();
                ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                ddlDeliveryType.DataBind();
                ddlStatus.DataSource = EnrollmentBLL.GetLearningHistoryStatus(SessionWrapper.CultureName,"lmhp-01");
                ddlStatus.DataBind();
            }
        }

       

        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }

        private void PrintPdf()
        {
            rvLearningHistory.LocalReport.DataSources.Clear();
            DataSet dsLearningHistory = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsLearningHistory = EnrollmentBLL.GetAllLearningHistory(SessionWrapper.u_userid,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            if (dsLearningHistory.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvLearningHistory.ProcessingMode = ProcessingMode.Local;
                rvLearningHistory.LocalReport.EnableExternalImages = true;
                rvLearningHistory.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Employee.LearningHistory.PdfTemplate.MyLearningHistory.rdlc";

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvLearningHistory.LocalReport.DataSources.Add(new ReportDataSource("MyLearningHistory", dsLearningHistory.Tables[0]));

                List<ReportParameter> param = new List<ReportParameter>();
                param.Add(new ReportParameter("s_theme_report_logo_file_name", protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_report_logo_file_name));
                param.Add(new ReportParameter("s_theme_css_tag_main_background_hex_value", "#" + userTheme.s_theme_css_tag_main_background_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_foot_top_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_top_line_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_foot_bot_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_bot_line_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_hex_value", "#" + userTheme.s_theme_css_tag_section_head_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_text_hex_value", "#" + userTheme.s_theme_css_tag_section_head_text_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_border_hex_value", "#" + userTheme.s_theme_css_tag_section_head_border_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_head_hex_value", "#" + userTheme.s_theme_css_tag_table_head_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_head_text_hex_value", "#" + userTheme.s_theme_css_tag_table_head_text_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_border_hex_value", "#" + userTheme.s_theme_css_tag_table_border_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_body_text_hex_value", "#" + userTheme.s_theme_css_tag_body_text_hex_value));
                this.rvLearningHistory.LocalReport.SetParameters(param);

                byte[] bytes = rvLearningHistory.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + LocalResources.GetLabel("app_my_learning_history_text") + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsLearningHistory = new DataSet();
            try
            {
                dsLearningHistory = EnrollmentBLL.GetAllLearningHistory(SessionWrapper.u_userid,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmhp-01.aspx (ExportExcel)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmhp-01.aspx (ExportExcel)", ex.Message);
                    }
                }

            }
            if (dsLearningHistory.Tables[0].Rows.Count > 0)
            {
                exportDataTableToCsv(dsLearningHistory.Tables[1],dsLearningHistory.Tables[2]);
            }
        }

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
                sb.Append(dtcolumnName.Rows[k]["columnName"].ToString()+ ',');
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

        protected void gvLearningHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnReview = (Button)e.Row.FindControl("btnReview");
                Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
                Button btnCertificate = (Button)e.Row.FindControl("btnCertificate");
                Button btnViewDetails = (Button)e.Row.FindControl("btnViewDetails");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                if (status == "Completed")
                {

                    btnReview.Style.Add("display", "inline");
                    btnCertificate.Style.Add("display", "none");
                }
                else if (status == "Passed")
                {

                    btnViewDetails.Style.Add("display", "Block");
                    btnCertificate.Style.Add("display", "Block");
                }
                else if (status == "Failed")
                {
                    btnEnroll.Style.Add("display", "Block");
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvLearningHistory.PageCount;
            if (gvLearningHistory.PageIndex > 0)
                gvLearningHistory.PageIndex = gvLearningHistory.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvLearningHistory.PageIndex + 1;
            if (i <= gvLearningHistory.PageCount)
                gvLearningHistory.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = gvLearningHistory.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();

        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvLearningHistory.PageSize = Convert.ToInt32(gvLearningHistory.PageCount * gvLearningHistory.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvLearningHistory.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();

        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvLearningHistory.PageCount;
            if (gvLearningHistory.PageIndex > 0)
                gvLearningHistory.PageIndex = gvLearningHistory.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvLearningHistory.PageIndex + 1;
            if (i <= gvLearningHistory.PageCount)
                gvLearningHistory.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = gvLearningHistory.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();

        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvLearningHistory.PageSize = Convert.ToInt32(gvLearningHistory.PageCount * gvLearningHistory.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvLearningHistory.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvLearningHistory.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        private void SearchResult()
        {
            Enrollment SearchlearningHistory = new Enrollment();

            if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
            {
                SearchlearningHistory.e_enroll_user_id_fk = SessionWrapper.u_userid;
                SearchlearningHistory.e_learning_keyword = txtKeyword.Text;
                DateTime? fromdate = null;
                DateTime tempfromdate;

                if (DateTime.TryParseExact(txtFromDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempfromdate))
                {
                    fromdate = tempfromdate;
                }
                SearchlearningHistory.e_learning_from_date = fromdate;
                DateTime? todate = null;
                DateTime temptodate;

                if (DateTime.TryParseExact(txtToDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temptodate))
                {
                    todate = temptodate;
                }
                SearchlearningHistory.e_learning_to_date = todate;

                SearchlearningHistory.e_learning_status = ddlStatus.SelectedValue.ToString();
                SearchlearningHistory.e_learning_deliveryType = ddlDeliveryType.SelectedValue.ToString();

            }
            else
            {
                SearchlearningHistory.e_enroll_user_id_fk = SessionWrapper.u_userid;
                SearchlearningHistory.e_learning_keyword = "";
                SearchlearningHistory.e_learning_from_date = null;
                SearchlearningHistory.e_learning_to_date = null;
                SearchlearningHistory.e_learning_status = "0";
                SearchlearningHistory.e_learning_deliveryType = "0";
            }


            gvLearningHistory.DataSource = EnrollmentBLL.SerchLearningHistory(SearchlearningHistory);
            gvLearningHistory.DataBind();

            gvLearningHistory.UseAccessibleHeader = true;
            if (gvLearningHistory.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvLearningHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvLearningHistory.Rows.Count == 0)
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

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //search

            ViewState["SearchResult"] = "true";
            gvLearningHistory.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            txtHeaderPage.Text = (gvLearningHistory.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvLearningHistory.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }

        protected void gvLearningHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string t_transcript_course_id_fk = gvLearningHistory.DataKeys[rowIndex][0].ToString();
            string title = gvLearningHistory.DataKeys[rowIndex][1].ToString();
            bool isEnroll;
            if (e.CommandName.Equals("Enroll"))
            {

                isEnroll = EnrollmentBLL.ChecReEnrollorNot(t_transcript_course_id_fk, SessionWrapper.u_userid);
                if (isEnroll == true)
                {
                    SessionWrapper.isLeraningHistory = true;
                }
                else
                {
                    SessionWrapper.isLeraningHistory = false;
                }
                Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);

            }
            else if (e.CommandName.Equals("Certificate"))
            {
                rvLearningHistory.LocalReport.DataSources.Clear();
                DataSet dsCertificate = new DataSet();
                try
                {
                    dsCertificate = EnrollmentBLL.GetCertificatePDF(SessionWrapper.u_userid, t_transcript_course_id_fk, SessionWrapper.CultureName);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("lmcurp-01.aspx (Certificate PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("lmcurp-01.aspx (Certificate PDF)", ex.Message);
                        }
                    }

                }
                if (dsCertificate.Tables[0].Rows.Count > 0)
                {
                    divError.Style.Add("display", "none");
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    rvLearningHistory.ProcessingMode = ProcessingMode.Local;
                    rvLearningHistory.LocalReport.EnableExternalImages = true;
                    rvLearningHistory.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Employee.LearningHistory.PdfTemplate.MyCertificate.rdlc";

                    SystemThemes userTheme = new SystemThemes();
                    userTheme = GetthemeforEmailandPdf();


                    string protocol = Request.Url.AbsoluteUri;
                    int len = protocol.IndexOf(':');
                    protocol = protocol.Substring(0, len);

                    rvLearningHistory.LocalReport.DataSources.Add(new ReportDataSource("dsCertificate", dsCertificate.Tables[0]));

                    List<ReportParameter> param = new List<ReportParameter>();
                    param.Add(new ReportParameter("s_theme_report_logo_file_name", protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_report_logo_file_name));
                    param.Add(new ReportParameter("s_theme_css_tag_main_background_hex_value", "#" + userTheme.s_theme_css_tag_main_background_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_foot_top_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_top_line_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_foot_bot_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_bot_line_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_section_head_hex_value", "#" + userTheme.s_theme_css_tag_section_head_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_section_head_text_hex_value", "#" + userTheme.s_theme_css_tag_section_head_text_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_section_head_border_hex_value", "#" + userTheme.s_theme_css_tag_section_head_border_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_table_head_hex_value", "#" + userTheme.s_theme_css_tag_table_head_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_table_head_text_hex_value", "#" + userTheme.s_theme_css_tag_table_head_text_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_table_border_hex_value", "#" + userTheme.s_theme_css_tag_table_border_hex_value));
                    param.Add(new ReportParameter("s_theme_css_tag_body_text_hex_value", "#" + userTheme.s_theme_css_tag_body_text_hex_value));
                    this.rvLearningHistory.LocalReport.SetParameters(param);

                    byte[] bytes = rvLearningHistory.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=\"" + "Certificate" + ".pdf" + "\"");
                    Response.BinaryWrite(bytes); // create the file     
                    Response.Flush(); // send it to the client to download  
                    Response.End();
                    Response.Close();
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_course_instructor_error_empty")+ title + ".";
                }
            }
        }

        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
            SystemThemes userTheme = new SystemThemes();
            userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
            return userTheme;
        }
    }
}