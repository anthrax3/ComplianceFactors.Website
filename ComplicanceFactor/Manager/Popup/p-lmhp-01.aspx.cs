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

namespace ComplicanceFactor.Manager.Popup
{
    public partial class p_lmhp_01 : System.Web.UI.Page
    {
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchResult();
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
                dsLearningHistory = EnrollmentBLL.GetAllLearningHistory(Request.QueryString["id"],SessionWrapper.CultureName);
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
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyLearningHistory" + ".pdf" + "\"");
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
                dsLearningHistory = EnrollmentBLL.GetAllLearningHistory(Request.QueryString["id"],SessionWrapper.CultureName);
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
            if (dsLearningHistory.Tables[1].Rows.Count > 0)
            {
                exportDataTableToCsv(dsLearningHistory.Tables[1], dsLearningHistory.Tables[2]);
            }
        }

        private void exportDataTableToCsv(DataTable dt, DataTable dtcolumnName)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyLearningHistory.csv");
            Response.ContentEncoding = Encoding.Unicode;
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



        private void SearchResult()
        {
            Enrollment SearchlearningHistory = new Enrollment();


            SearchlearningHistory.e_enroll_user_id_fk = Request.QueryString["id"];
            SearchlearningHistory.e_learning_keyword = "";
            SearchlearningHistory.e_learning_from_date = null;
            SearchlearningHistory.e_learning_to_date = null;
            SearchlearningHistory.e_learning_status = "0";
            SearchlearningHistory.e_learning_deliveryType = "0";



            gvLearningHistory.DataSource = EnrollmentBLL.SerchLearningHistory(SearchlearningHistory);
            gvLearningHistory.DataBind();

            gvLearningHistory.UseAccessibleHeader = true;
            if (gvLearningHistory.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvLearningHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void gvLearningHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Certificate"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string t_transcript_course_id_fk = gvLearningHistory.DataKeys[rowIndex][1].ToString();
                string t_transcript_user_id_fk = gvLearningHistory.DataKeys[rowIndex][0].ToString();
                rvLearningHistory.LocalReport.DataSources.Clear();
                DataSet dsCertificate = new DataSet();
                try
                {
                    dsCertificate = EnrollmentBLL.GetCertificatePDF(t_transcript_user_id_fk, t_transcript_course_id_fk, SessionWrapper.CultureName);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("lmhp-01.aspx (Certificate PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("lmhp-01.aspx (Certificate PDF)", ex.Message);
                        }
                    }

                }
                if (dsCertificate.Tables[0].Rows.Count>0)
                {
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    rvLearningHistory.ProcessingMode = ProcessingMode.Local;
                    rvLearningHistory.LocalReport.EnableExternalImages = true;
                    rvLearningHistory.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Employee.LearningHistory.PdfTemplate.MyCertificate.rdlc";
                    rvLearningHistory.LocalReport.DataSources.Add(new ReportDataSource("dsCertificate", dsCertificate.Tables[0]));
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