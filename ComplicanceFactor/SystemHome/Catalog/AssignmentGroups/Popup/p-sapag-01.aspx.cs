using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using System.Text;
using System.Data;
using ComplicanceFactor.Common;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.Popup
{
    public partial class p_sapag_01 : System.Web.UI.Page
    {
        private static string editId;
        private static string filenameOfPDFandEXCEL;
        private static string previewTille;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editId = Request.QueryString["id"].ToString();
                }
                SearchResult();
                //count page of page in search result
                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            }
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

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

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

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
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

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

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

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        private void SearchResult()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                if (Request.QueryString["page"].ToString() == "rule")
                {
                    lblPreviewTitle.Text = LocalResources.GetLabel("app_assignment_rule_preview_text");
                    gvsearchDetails.DataSource = SystemAssignmentRuleBLL.GetUsersDetailsAssignmentRule(editId);
                    gvsearchDetails.DataBind();
                }
                else if (Request.QueryString["page"].ToString() == "group")
                {
                    lblPreviewTitle.Text = LocalResources.GetLabel("app_assignment_group_preview_text");
                    gvsearchDetails.DataSource = SystemAssignmentGroupBLL.GetUsersDetailsAssignmentGroup(editId, SessionWrapper.CultureName);
                    gvsearchDetails.DataBind();
                }
                else if (Request.QueryString["page"].ToString() == "audience")
                {
                    lblPreviewTitle.Text = LocalResources.GetLabel("app_audience_preview_text");
                    gvsearchDetails.DataSource = SystemAudiencesBLL.GetUsersDetailsAudience(editId, SessionWrapper.CultureName);
                    gvsearchDetails.DataBind(); 
                }
            }
    
            gvsearchDetails.UseAccessibleHeader = true;
            if (gvsearchDetails.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
            }
        }

        private void disable_enable(bool status)
        {
            btnHeaderFirst.Visible = status;
            btnHeaderPrevious.Visible = status;
            btnHeaderNext.Visible = status;
            btnHeaderLast.Visible = status;

            btnFooterFirst.Visible = status;
            btnFooterPrevious.Visible = status;
            btnFooterNext.Visible = status;
            btnFooterLast.Visible = status;

            ddlHeaderResultPerPage.Visible = status;
            ddlFooterResultPerPage.Visible = status;

            txtHeaderPage.Visible = status;
            lblHeaderPage.Visible = status;

            txtFooterPage.Visible = status;
            lblFooterPage.Visible = status;

            btnHeaderGoto.Visible = status;
            btnFooterGoto.Visible = status;


            lblHeaderResultPerPage.Visible = status;
            lblFooterResultPerPage.Visible = status;

            lblFooterPageOf.Visible = status;
            lblHeaderPageOf.Visible = status;

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //search

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

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsEmployee = new DataSet();
            try
            {                            
                
                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    if (Request.QueryString["page"].ToString() == "rule")
                    {
                        dsEmployee = SystemAssignmentRuleBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);
                        filenameOfPDFandEXCEL = LocalResources.GetLabel("app_assignment_rule_preview_text");
                    }
                    else if (Request.QueryString["page"].ToString() == "group")
                    {
                        dsEmployee = SystemAssignmentGroupBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);
                        filenameOfPDFandEXCEL = LocalResources.GetLabel("app_assignment_group_preview_text");
                    }
                    else if (Request.QueryString["page"].ToString() == "audience")
                    {
                        dsEmployee = SystemAudiencesBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);
                        filenameOfPDFandEXCEL = LocalResources.GetLabel("app_audience_preview_text");
                    }
                    filenameOfPDFandEXCEL = filenameOfPDFandEXCEL.Replace(" ", "_");
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
                        Logger.WriteToErrorLog("p-sapag-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sapag-01.aspx", ex.Message);
                    }
                }

            }
            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                exportDataTableToCsv(dsEmployee.Tables[1], dsEmployee.Tables[2], filenameOfPDFandEXCEL);
            }
        }

        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            rvAssignmentUser.LocalReport.DataSources.Clear();
            DataSet dsAssignentUser = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
 
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    if (Request.QueryString["page"].ToString() == "rule")
                    {
                        dsAssignentUser = SystemAssignmentRuleBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);                        
                        previewTille = LocalResources.GetLabel("app_assignment_rule_preview_text");                        
                    }
                    else if (Request.QueryString["page"].ToString() == "group")
                    {
                        dsAssignentUser = SystemAssignmentGroupBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);
                        previewTille = LocalResources.GetLabel("app_assignment_group_preview_text");                       
                        
                    }
                    else if (Request.QueryString["page"].ToString() == "audience")
                    {
                        dsAssignentUser = SystemAudiencesBLL.GetUserPDFExcel(editId, SessionWrapper.CultureName);                        
                        previewTille = LocalResources.GetLabel("app_audience_preview_text");                        
                    }
                    filenameOfPDFandEXCEL = previewTille.Replace(" ", "_");
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
                        Logger.WriteToErrorLog("p-sapag-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sapag-01.aspx", ex.Message);
                    }
                }

            }
            if (dsAssignentUser.Tables[0].Rows.Count > 0)
            {

                DataTable dtAssignentUser = GetDataFrrmDecrypt(dsAssignentUser.Tables[0]);
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvAssignmentUser.ProcessingMode = ProcessingMode.Local;
                rvAssignmentUser.LocalReport.EnableExternalImages = true;
                rvAssignmentUser.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.PdfTemplate.PreviewAssignment.rdlc";

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvAssignmentUser.LocalReport.DataSources.Add(new ReportDataSource("dsAssignment", dtAssignentUser));
                //rvAssignmentUser.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsAssignentUser.Tables[1]));

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
                param.Add(new ReportParameter("header_title", previewTille));
                this.rvAssignmentUser.LocalReport.SetParameters(param);

                byte[] bytes = rvAssignmentUser.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + filenameOfPDFandEXCEL + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }

        private void exportDataTableToCsv(DataTable dt, DataTable dtCourseColumnName, string filenameOfPDFandEXCEL)
        {
            dt = GetDataFrrmDecrypt(dt);
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filenameOfPDFandEXCEL + ".csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtCourseColumnName.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtCourseColumnName.Rows[k]["columnName"].ToString() + ',');
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

        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
            SystemThemes userTheme = new SystemThemes();
            userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
            return userTheme;
        }
        /// <summary>
        /// Decrypt Username then get datatable
        /// </summary>
        /// <param name="dtUserMaster"></param>
        /// <returns></returns>
        private  DataTable GetDataFrrmDecrypt(DataTable dtUserMaster)
        {
            foreach (DataRow row in dtUserMaster.Rows)
            {
                /// Hash encryption for username and password
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                row["u_username_enc"] = encHash.Decrypt(row["u_username_enc"].ToString(), true);
                //row.EndEdit();
                dtUserMaster.AcceptChanges();

            }
            return dtUserMaster;
        }
 
        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /// Hash encryption for username and password
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                string username = gvsearchDetails.DataKeys[e.Row.RowIndex]["u_username_enc"].ToString();
                Label lblUsername = (Label)e.Row.FindControl("lblUsername");
                lblUsername.Text = encHash.Decrypt(username, true);
            }
        }

    }
}