using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class resch_01 : System.Web.UI.Page
    {
        private string suid = "";
        private DataTable Source
        {
            set 
            {
                ViewState["Source"] = value;
            }
            get
            {
                if (ViewState["Source"] == null)
                {
                    return null;
                }
                else
                {
                    return (DataTable)ViewState["Source"];
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadConditions();
            if (Request.Params["suid"] != null)
            {
                suid = Request.Params["suid"].ToString();
            }
            if (!IsPostBack)
            {
                SessionWrapper.TempEmployeelist_mail = null;
                txtReportName.Text = Request.Params["name"].ToString();
                LoadData();
            }
            if (SessionWrapper.TempEmployeelist_mail != null)
            {
                if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                {
                    gvsearchDetails.DataSource = SessionWrapper.TempEmployeelist_mail;
                    gvsearchDetails.DataBind();
                }
            }
            
        }
        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(suid))
            {
                MyReport myReport = new MyReport()
                {
                    s_report_id_fk = Request.Params["id"].ToString(),
                    s_report_users_report_name = txtReportName.Text,
                    s_report_users_system_id_pk = Guid.NewGuid().ToString(),
                    u_user_id_fk = SessionWrapper.u_userid,
                    s_report_users_when_to_run = ddlWhentorun.SelectedValue,

                };

                MyReportBLL.CreateNewReport(myReport);
            }
            else
            {
                DataTable dtMailUsers = new DataTable();
                MyReport myReport = MyReportBLL.SearchReportById(suid, out dtMailUsers);
                myReport.s_report_users_report_name = txtReportName.Text;
                myReport.s_report_users_when_to_run = ddlWhentorun.SelectedValue;
                if (SessionWrapper.TempEmployeelist_mail != null)
                {
                    if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                    {
                        myReport.s_report_users_mailto = ConvertDataTableToXml(SessionWrapper.TempEmployeelist_mail);
                    }
                }
                MyReportBLL.UpdateReport(myReport);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.window.location.reload();parent.jQuery.fancybox.close();", true);
        }
        protected void btnScheduleNew_Click(object sender, EventArgs e)
        {
            MyReport myReport = new MyReport()
            {
                s_report_id_fk = Request.Params["id"].ToString(),
                s_report_users_report_name = txtReportName.Text,
                s_report_users_system_id_pk = Guid.NewGuid().ToString(),
                u_user_id_fk = SessionWrapper.u_userid,
                s_report_users_when_to_run = ddlWhentorun.SelectedValue,

            };
            if (SessionWrapper.TempEmployeelist_mail != null)
            {
                if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                {
                    myReport.s_report_users_mailto = ConvertDataTableToXml(SessionWrapper.TempEmployeelist_mail);
                }
                else
                {
                    myReport.s_report_users_mailto = ConvertDataTableToXml(Source);
                }
            }
            MyReportBLL.CreateNewReport(myReport);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(suid))
            {
                DataTable dtMailUsers = new DataTable();
                MyReport myReport = MyReportBLL.SearchReportById(suid, out dtMailUsers);
                txtReportName.Text = myReport.s_report_users_report_name;
                ddlWhentorun.SelectedValue = myReport.s_report_users_when_to_run;
                gvsearchDetails.DataSource = dtMailUsers;
                gvsearchDetails.DataBind();
                Source = dtMailUsers;
            }
        }
        private void LoadConditions()
        {
            DataTable dtParams = SystemReportBLL.GetParamsOfReport(Request.Params["id"].ToString());
            
        }
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        [System.Web.Services.WebMethod]
        public static void Delete(string args)
        {

            try
            {
                if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                {
                    var rows = SessionWrapper.TempEmployeelist_mail.Select("s_report_users_mailto_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.TempEmployeelist_mail.AcceptChanges();
                }
                MyReportBLL.DeleteById(args);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerp-01 (Remove Param)", ex.Message);
                    }
                }
            }


        }
    }
}