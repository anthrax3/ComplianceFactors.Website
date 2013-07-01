using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.BusinessComponent.DataAccessObject;


namespace ComplicanceFactor.Instructor
{
    public partial class timcalendarp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_instructor";

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_instructor") + "</a>" + " >&nbsp;" + "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_calendar_text") + "</a>";
                
                Calendar1.EventDateColumnName = "c_session_start_date";
                Calendar1.EventDescriptionColumnName = "c_delivery_system_id_pk";
                Calendar1.EventHeaderColumnName = "DeliveryTitle";               

                PopulateYearDropDown();
                //To set the Month and Year as current Date
                ddlFooterYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlHeaderYear.SelectedValue = DateTime.Now.Year.ToString();

                ddlHeaderMonth.SelectedValue = DateTime.Now.Month.ToString();
                ddlFooterMonth.SelectedValue = DateTime.Now.Month.ToString();

                //Calendar1.EventSource = InstructorBLL.GetDeliveries(SessionWrapper.u_userid);
                Calendar1.VisibleDate = DateTime.Now;
            }
            //DateTime ds = Calendar1.VisibleDate;
        }

        //private DataTable GetEvents()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("EventDate", Type.GetType("System.DateTime"));
        //    dt.Columns.Add("EventHeader", Type.GetType("System.String"));
        //    dt.Columns.Add("EventDescription", Type.GetType("System.String"));

        //    DataRow dr;

        //    // Last Week's Events
        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now.AddDays(-7);
        //    dr["EventHeader"] = "My Last Week's Event 1";
        //    dr["EventDescription"] = "My Last Week's Event 1 Description";
        //    dt.Rows.Add(dr);

        //    // Yesterday's Events
        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now.AddDays(-1);
        //    dr["EventHeader"] = "My Yesterday's Event 1";
        //    dr["EventDescription"] = "My Yesterday's Event 1 Description";
        //    dt.Rows.Add(dr);

        //    // Todays Events
        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now.AddMonths(-1);
        //    dr["EventHeader"] = "My Todays Event 1";
        //    dr["EventDescription"] = "My Todays Event 1 Description";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now.AddMonths(-1).AddDays(2);
        //    dr["EventHeader"] = "My Todays Event 1.1";
        //    dr["EventDescription"] = "My Todays Event 1.1 Description";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now;
        //    dr["EventHeader"] = "My Todays Event 2";
        //    dr["EventDescription"] = "My Todays Event 2 Description";
        //    dt.Rows.Add(dr);

        //    // Tomorrow's Events
        //    dr = dt.NewRow();
        //    dr["EventDate"] = DateTime.Now.AddDays(1);
        //    dr["EventHeader"] = "My Tomorrow's Event 1";
        //    dr["EventDescription"] = "My Tomorrow's Event 1 Description";
        //    dt.Rows.Add(dr);

        //    return dt;
        //}

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = ((DayRenderEventArgs)e).Day;
            TableCell c = ((DayRenderEventArgs)e).Cell;

            // If there is nothing to bind
            //if (this.GetEvents() == null)
            //    return;

            if (d.IsOtherMonth)
            {
                e.Cell.Text = "";
            }

            DataTable dt = InstructorBLL.GetDeliveries(SessionWrapper.u_userid);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["DeliveryTitle"].ToString() == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventDateColumnName property when EventSource is specified");
                if (dr["c_session_start_date"].ToString() == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventHeaderColumnName property when EventSource is specified");


                if (dr["c_session_start_date"].ToString() != string.Empty
                    && !d.IsOtherMonth
                    && Convert.ToDateTime(dr["c_session_start_date"]).ToShortDateString() == d.Date.ToShortDateString())
                {

                    LinkButton link = new LinkButton();
                    string strID = dr["c_delivery_system_id_pk"].ToString() + "&courseId=" + dr["c_course_system_id_pk"].ToString();
                    link.ID = strID;
                    link.CommandName = "ViewEvent";
                    //link.CommandArgument = dr["DeliveryTitle"].ToString();
                    link.Text = "- " + dr["DeliveryTitle"].ToString().Trim();
                    //link.ToolTip = dr["DeliveryTitle"].ToString().Trim();
                    link.CssClass = "baselink cursor_hand";
                    //link.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Handle_EventLink);
                    c.Controls.Add(link);
                }              
            }
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            DateTime dtCurrentDate = Calendar1.VisibleDate;
            Calendar1.VisibleDate = dtCurrentDate.AddMonths(-1);

            //To set the Month and Year as current Date
            ddlFooterYear.SelectedValue = dtCurrentDate.AddMonths(-1).Year.ToString();
            ddlHeaderYear.SelectedValue = dtCurrentDate.AddMonths(-1).Year.ToString();

            ddlHeaderMonth.SelectedValue = dtCurrentDate.AddMonths(-1).Month.ToString();
            ddlFooterMonth.SelectedValue = dtCurrentDate.AddMonths(-1).Month.ToString();

        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            DateTime dtCurrentDate = Calendar1.VisibleDate;
            Calendar1.VisibleDate = dtCurrentDate.AddMonths(1);

            //To set the Month and Year as current Date
            ddlFooterYear.SelectedValue = dtCurrentDate.AddMonths(1).Year.ToString();
            ddlHeaderYear.SelectedValue = dtCurrentDate.AddMonths(1).Year.ToString();

            ddlHeaderMonth.SelectedValue = dtCurrentDate.AddMonths(1).Month.ToString();
            ddlFooterMonth.SelectedValue = dtCurrentDate.AddMonths(1).Month.ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            DateTime dtCurrentDate = Calendar1.VisibleDate;
            Calendar1.VisibleDate = dtCurrentDate.AddMonths(-1);

            //To set the Month and Year as current Date
            ddlFooterYear.SelectedValue = dtCurrentDate.AddMonths(-1).Year.ToString();
            ddlHeaderYear.SelectedValue = dtCurrentDate.AddMonths(-1).Year.ToString();

            ddlHeaderMonth.SelectedValue = dtCurrentDate.AddMonths(-1).Month.ToString();
            ddlFooterMonth.SelectedValue = dtCurrentDate.AddMonths(-1).Month.ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            DateTime dtCurrentDate = Calendar1.VisibleDate;
            Calendar1.VisibleDate = dtCurrentDate.AddMonths(1);

            //To set the Month and Year as current Date
            ddlFooterYear.SelectedValue = dtCurrentDate.AddMonths(1).Year.ToString();
            ddlHeaderYear.SelectedValue = dtCurrentDate.AddMonths(1).Year.ToString();

            ddlHeaderMonth.SelectedValue = dtCurrentDate.AddMonths(1).Month.ToString();
            ddlFooterMonth.SelectedValue = dtCurrentDate.AddMonths(1).Month.ToString();
        }

        private void PopulateYearDropDown()
        {
            int startYear = 1900;
            int endYear = DateTime.Now.Year;
            ddlFooterYear.Items.Clear();
            ddlHeaderYear.Items.Clear();
             
            for (int i = endYear; i >= startYear; i--)
            {
                ddlFooterYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlHeaderYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btnHeaderGo_Click(object sender, EventArgs e)
        {
            int month =Convert.ToInt16(ddlHeaderMonth.SelectedValue);
            int year =Convert.ToInt32( ddlHeaderYear.SelectedValue);
            int day = 1;

            DateTime dtSelectedTime = new DateTime(year, month, day);
            Calendar1.VisibleDate = dtSelectedTime;

            ddlFooterYear.SelectedValue = dtSelectedTime.Year.ToString();
            ddlFooterMonth.SelectedValue = dtSelectedTime.Month.ToString();

        }

        protected void btnFooterGo_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt16(ddlFooterMonth.SelectedValue);
            int year = Convert.ToInt32(ddlFooterYear.SelectedValue);
            int day = 1;

            DateTime dtSelectedTime = new DateTime(year, month, day);
            Calendar1.VisibleDate = dtSelectedTime;

            ddlHeaderMonth.SelectedValue = dtSelectedTime.Month.ToString();
            ddlHeaderYear.SelectedValue = dtSelectedTime.Year.ToString();
        }

        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            rvMyCalendar.LocalReport.DataSources.Clear();

            int month = Convert.ToInt16(ddlFooterMonth.SelectedValue);
            int year = Convert.ToInt32(ddlFooterYear.SelectedValue);
            int day = 1;             
            int lastDay = DateTime.DaysInMonth(year, month);
            DateTime dtStartdate = new DateTime(year, month, day);

            string monthName = dtStartdate.Month.ToString();            

            DataTable dtCalendarDetails = new DataTable();

            try
            {
                dtCalendarDetails = InstructorBLL.GetCalendarDetails_pdf(dtStartdate,SessionWrapper.u_userid);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("timcalendarp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("timcalendarp-01.aspx (PDF)", ex.Message);
                    }
                }
            }

            if (dtCalendarDetails.Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvMyCalendar.ProcessingMode = ProcessingMode.Local;
                rvMyCalendar.LocalReport.EnableExternalImages = true;
                rvMyCalendar.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.MyCalendar.rdlc";

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvMyCalendar.LocalReport.DataSources.Add(new ReportDataSource("dsMyCalendar", dtCalendarDetails));
                ReportParameter[] myparams = new ReportParameter[1];
                myparams[0] = new ReportParameter("monthName", monthName, false);
                rvMyCalendar.LocalReport.SetParameters(myparams);

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
                param.Add(new ReportParameter("s_theme_css_tag_body_link_hex_value", "#" + userTheme.s_theme_css_tag_body_link_hex_value));
                this.rvMyCalendar.LocalReport.SetParameters(param);

                //rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
                byte[] bytes = rvMyCalendar.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyCalendar" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
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