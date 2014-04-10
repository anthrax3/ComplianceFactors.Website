using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Compliance.MIRIS.Reports
{

    public partial class mrp_01 : System.Web.UI.UserControl
    {
        public ReportEnum flag;
        public ComplicanceFactor.Compliance.MIRIS.Reports.dynamicsearch dynamicsearch1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_compliance";
                // Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //  lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>" + " > " + "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_my_reports_text") + "</a>";

                BindGrid();
            }


        }
        private void BindGrid()
        {

            SystemReport report = new SystemReport();
            report.s_report_id_pk = "";
            report.s_report_name = "";
            report.s_report_type_id_fk = "";
            try
            {
                DataTable dtReport = new DataTable();
                report.s_report_on_off_flag = true;
                dtReport = MyReportBLL.SearchReport(SessionWrapper.u_userid);
                DataView dv = dtReport.DefaultView;



                dtReport.Columns.Add("s_report_name_id");
                dtReport.Columns.Add("s_report_users_when_to_run_text");
                foreach (DataRow row in dtReport.Rows)
                {

                    row["s_report_name_id"] = row["s_report_name"] + " (" + row["s_report_id_pk"] + ")";
                    switch (row["s_report_users_when_to_run"].ToString())
                    {
                        case "-1":
                            row["s_report_users_when_to_run_text"] = "";
                            break;
                        case "0":
                            row["s_report_users_when_to_run_text"] = "Every Day";
                            break;
                        case "1":
                            row["s_report_users_when_to_run_text"] = "Every Week";
                            break;
                        case "2":
                            row["s_report_users_when_to_run_text"] = "Every Month";
                            break;
                        case "3":
                            row["s_report_users_when_to_run_text"] = "Every Year";
                            break;
                        default:
                            break;
                    }
                }
                switch (flag)
                {
                    case ReportEnum.Administrator:
                        dv.RowFilter = "s_report_admin_flag = 1";
                        break;
                    case ReportEnum.Compliance:
                        dv.RowFilter = "s_report_compliance_flag = 1";
                        break;
                    case ReportEnum.Coordinator:
                        dv.RowFilter = "s_report_coordinator_flag = 1";
                        break;
                    case ReportEnum.Instructor:
                        dv.RowFilter = "s_report_instructor_flag = 1";
                        break;
                    case ReportEnum.Manager:
                        dv.RowFilter = "s_report_manager_flag = 1";
                        break;
                    case ReportEnum.Employee:
                        dv.RowFilter = "s_report_employee_flag = 1";
                        break;
                    default:
                        dv.RowFilter = "1<>1";
                        break;
                }
                gvMyReports.DataSource = dv;
                gvMyReports.DataBind();
                gvMyReports.UseAccessibleHeader = true;
                if (gvMyReports.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //gvMyReports instead of the simple <tr>
                    gvMyReports.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        Logger.WriteToErrorLog("ccmrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccmrp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void gvMyReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "viewlast")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string reportSystemId = gvMyReports.DataKeys[rowIndex][2].ToString();
                string reportUserId = gvMyReports.DataKeys[rowIndex][1].ToString();
                string reportId = gvMyReports.DataKeys[rowIndex][0].ToString();
                DataTable dtLastGenerate = MyReportBLL.SearchLastGenerate(reportUserId, reportSystemId);
                Session["ReportConditions"] = dtLastGenerate;
                switch (reportId)
                {
                    case "CF-STD-OSHA-301":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:lastview('/Compliance/MIRIS/Reports/saressr-01.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-OSHA-300A":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
               "javascript:lastview('/Compliance/MIRIS/Reports/osha300a.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-OSHA-300":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:lastview('/Compliance/MIRIS/Reports/osha300.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-COURSE-COMP":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:lastview('/Compliance/MIRIS/Reports/CompletionofCourses.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-COURSE-ASSIGN/ENROLL-COMP":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:lastview('/Compliance/MIRIS/Reports/LearningReport.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    default:
                        break;
                }
            }
            if (e.CommandName == "generate")
            {
                SessionWrapper.selectedUserId_learningReport = string.Empty;
                SessionWrapper.selectedUserName_learningReport = string.Empty;
                SessionWrapper.selectedCourseId_learningReport = string.Empty;
                SessionWrapper.selectedCourseName_learningReport = string.Empty;
                SessionWrapper.selectedDeliveryTypeId_learningReport = string.Empty;
                SessionWrapper.selectedDeliveryTypeName_learningReport = string.Empty;
                SessionWrapper.selectedStatusName_learningReport = string.Empty;
                SessionWrapper.selectedStatusNameText_learningReport = string.Empty;

                int rowIndex = int.Parse(e.CommandArgument.ToString());

                string reportUserId = gvMyReports.DataKeys[rowIndex][1].ToString();
                string reportId = gvMyReports.DataKeys[rowIndex][0].ToString();
                string reportSystemId = gvMyReports.DataKeys[rowIndex][2].ToString();

                switch (reportId)
                {
                    case "CF-STD-OSHA-301":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                 "javascript:generate('/Compliance/MIRIS/Reports/reemp-01.aspx?id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-OSHA-300A":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                "javascript:generate('/Compliance/MIRIS/Reports/osha300_condition.aspx?page=300a&id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-OSHA-300":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:generate('/Compliance/MIRIS/Reports/osha300_condition.aspx?page=300&id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-COURSE-COMP":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:generate('/Compliance/MIRIS/Reports/osha300_condition.aspx?page=completionCourse&id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    case "CF-STD-COURSE-ASSIGN/ENROLL-COMP":
                         Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:generate('/Compliance/MIRIS/Reports/osha300_condition.aspx?page=LearningReport&id=" + reportSystemId + "&suid=" + reportUserId + "');", true);
                        break;
                    default:
                        break;
                }

            }
            if (e.CommandName == "schedule")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                string reportUserId = gvMyReports.DataKeys[rowIndex][1].ToString();
                string reportId = gvMyReports.DataKeys[rowIndex][0].ToString();
                string reportSystemId = gvMyReports.DataKeys[rowIndex][2].ToString();
                string reportName = gvMyReports.DataKeys[rowIndex][3].ToString();
                switch (reportId)
                {
                    case "CF-STD-OSHA-301":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                 "javascript:schedule('/Compliance/MIRIS/Reports/resch-01.aspx?pagetype=" + ((Button)e.CommandSource).Text.ToLower().Trim() + "&id=" + reportSystemId + "&suid=" + reportUserId + "&name=" + reportName + "');", true);
                        break;
                    case "CF-STD-OSHA-300A":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                "javascript:schedule('/Compliance/MIRIS/Reports/resch-01.aspx?pagetype=" + ((Button)e.CommandSource).Text.ToLower().Trim() + "&page=300a&id=" + reportSystemId + "&suid=" + reportUserId + "&name=" + reportName + "');", true);
                        break;
                    case "CF-STD-OSHA-300":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose",
                  "javascript:schedule('/Compliance/MIRIS/Reports/resch-01.aspx?pagetype=" + ((Button)e.CommandSource).Text.ToLower().Trim() + "&page=300&id=" + reportSystemId + "&suid=" + reportUserId + "&name=" + reportName + "');", true);
                        break;
                    default:
                        break;
                }

            }
        }

        protected void gvMyReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button viewbutton = (Button)e.Row.FindControl("btnViewLast");
                Button schedulebutton = (Button)e.Row.FindControl("btnSchedule");
                string myReportId = DataBinder.Eval(e.Row.DataItem, "s_report_users_system_id_pk").ToString();

                if (string.IsNullOrEmpty(myReportId))
                {
                    schedulebutton.Text = "Schedule It";
                    viewbutton.Style.Add("display", "none");
                }
                else
                {
                    schedulebutton.Text = "Edit";
                    viewbutton.Style.Add("display", "inline");
                }


            }
        }


    }
}