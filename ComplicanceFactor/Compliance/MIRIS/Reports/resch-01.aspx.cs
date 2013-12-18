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
          
            if (Request.Params["suid"] != null)
            {
                suid = Request.Params["suid"].ToString();
            }
            if (!IsPostBack)
            {
                SessionWrapper.TempEmployeelist_mail = TempDataTables.TempUser();
                txtReportName.Text = Request.Params["name"].ToString();
                LoadData();
            }
            if (SessionWrapper.TempEmployeelist_mail != null)
            {
                if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                {
                    //gvsearchDetails.DataSource = SessionWrapper.TempEmployeelist_mail;
                    //gvsearchDetails.DataBind();
                    foreach (DataRow row in SessionWrapper.TempEmployeelist_mail.Rows)
                    {
                        if (txtMail.Text.IndexOf(row["u_email_address"].ToString().Trim()) == -1)
                        {
                            txtMail.Text += row["u_email_address"].ToString() + ";";
                        }
                    }
                    
                }
            }
            
        }
       
        private void PopulateControls(Control pcon,DataTable dtParams)
        {
            
          
            foreach (Control con in pcon.Controls)
            {
                string id = con.ID;
                if (IsGuid(id))
                {
                    DataRow rowNew;
                    rowNew = dtParams.NewRow();
                    rowNew["s_report_users_params_system_id_pk"] = Guid.NewGuid().ToString();
                    rowNew["s_report_users_params_param_id_fk"] = id;
                    if (con.GetType().Name == "TextBox")
                    {
                        rowNew["s_report_users_params_param_value"] = ((TextBox)con).Text;
                    }
                    else if (con.GetType().Name == "DropDownList")
                    {
                        rowNew["s_report_users_params_param_value"] = ((DropDownList)con).Text;
                    }
                    else
                    {
                        rowNew["s_report_users_params_param_value"] = ((TextBox)con).Text;
                    }
                    dtParams.Rows.Add(rowNew);
                }
                PopulateControls(con, dtParams);
            }
        }
        private void SetControls(Control pcon, DataTable dtParams)
        {


            foreach (Control con in pcon.Controls)
            {
                string id = con.ID;
                if (IsGuid(id))
                {
                    DataRow rowNew;
                    rowNew = dtParams.NewRow();
                    rowNew["s_report_users_params_system_id_pk"] = Guid.NewGuid().ToString();
                    rowNew["s_report_users_params_param_id_fk"] = id;
                    if (con.GetType().Name == "TextBox")
                    {
                        rowNew["s_report_users_params_param_value"] = ((TextBox)con).Text;
                    }
                    else if (con.GetType().Name == "DropDownList")
                    {
                        rowNew["s_report_users_params_param_value"] = ((DropDownList)con).Text;
                    }
                    else
                    {
                        rowNew["s_report_users_params_param_value"] = ((TextBox)con).Text;
                    }
                    dtParams.Rows.Add(rowNew);
                }
                SetControls(con, dtParams);
            }
        }
        static bool IsGuid(string str)
        {
            try
            {
                Guid guid = new Guid(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected void btnScheduleNew_Click(object sender, EventArgs e)
        {
            DataTable dtParams = new DataTable();
            dtParams.Columns.Add("s_report_users_params_system_id_pk");
            dtParams.Columns.Add("s_report_users_params_param_id_fk");
            dtParams.Columns.Add("s_report_users_params_param_value");
            PopulateControls(this, dtParams);
            MyReport myReport = null;
            if (ddlWhentorun.SelectedValue == "-1")
            {
                txtDateFrom.Text = string.Empty;
                txtDateTo.Text = string.Empty;
            }
            if (string.IsNullOrEmpty(suid))
            {
                myReport = new MyReport()
                {
                    s_report_id_fk = Request.Params["id"].ToString(),
                    s_report_users_report_name = txtReportName.Text,
                    s_report_users_system_id_pk = Guid.NewGuid().ToString(),
                    u_user_id_fk = SessionWrapper.u_userid,
                    s_report_users_when_to_run = ddlWhentorun.SelectedValue,
                    s_report_users_when_to_run_from = txtDateFrom.Text,
                    s_report_users_when_to_run_to = txtDateTo.Text,
                    s_report_users_mails = txtMail.Text,
                    s_report_users_params = ConvertDataTableToXml(dtParams)

                };
                if (SessionWrapper.TempEmployeelist_mail != null)
                {
                    if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                    {
                        myReport.s_report_users_mailto = ConvertDataTableToXml(SessionWrapper.TempEmployeelist_mail);
                    }
                    else
                    {
                        if (Source != null)
                        {
                            if (Source.Rows.Count > 0)
                            {
                                foreach (DataRow row in Source.Rows)
                                {
                                    row["s_report_users_mailto_system_id_pk"] = Guid.NewGuid().ToString();
                                }
                                myReport.s_report_users_mailto = ConvertDataTableToXml(Source);
                            }
                        }
                    }
                }
                MyReportBLL.CreateNewReport(myReport);
            }
            else
            {


                DataTable dtMailUsers = new DataTable();
                DataTable dtTemp = new DataTable();
                myReport = MyReportBLL.SearchReportById(suid, out dtMailUsers, out dtTemp);
                myReport.s_report_users_report_name = txtReportName.Text;
                myReport.s_report_users_when_to_run = ddlWhentorun.SelectedValue;
                myReport.s_report_users_when_to_run_from = txtDateFrom.Text;
                myReport.s_report_users_when_to_run_to = txtDateTo.Text;
                myReport.s_report_users_mails = txtMail.Text;
                if (SessionWrapper.TempEmployeelist_mail != null)
                {
                    if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                    {
                        myReport.s_report_users_mailto = ConvertDataTableToXml(SessionWrapper.TempEmployeelist_mail);
                    }
                }
                myReport.s_report_users_params = ConvertDataTableToXml(dtParams);
                MyReportBLL.UpdateReport(myReport);
            }
            dynamicsearch1.PopulateCondition(Request.Params["id"].ToString(), myReport.s_report_users_system_id_pk);
            dynamicsearch1.RecordLastGenerate((DataTable)Session["ReportConditions"], "", Request.Params["id"].ToString(), myReport.s_report_users_system_id_pk);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:reloadWin();", true);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MyReportBLL.DeleteByMyReportId(suid);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.window.location.reload();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("resch-01 (Remove My Report)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("resch-01 (Remove My Report)", ex.Message);
                    }
                }
            }
        }
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(suid))
            {
                DataTable dtMailUsers = new DataTable();
                DataTable dtParams = new DataTable();
                MyReport myReport = MyReportBLL.SearchReportById(suid, out dtMailUsers, out dtParams);
                dynamicsearch1.dtResult = dtParams;
                txtReportName.Text = myReport.s_report_users_report_name;
                ddlWhentorun.SelectedValue = myReport.s_report_users_when_to_run;
             
                txtDateFrom.Text = myReport.s_report_users_when_to_run_from;
                txtDateTo.Text = myReport.s_report_users_when_to_run_to;
                txtMail.Text = myReport.s_report_users_mails;              

            }
            else
            {
                txtDateFrom.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtDateTo.Text = "";
            }
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

        protected void btnSaveNewUsers_Click(object sender, EventArgs e)
        {
            AddDataToEmployee(null, txtFirstName.Text, txtLastName.Text, null, txtMail.Text, SessionWrapper.TempEmployeelist_mail);
            if (SessionWrapper.TempEmployeelist_mail != null)
            {
                if (SessionWrapper.TempEmployeelist_mail.Rows.Count > 0)
                {
                    gvsearchDetails.DataSource = SessionWrapper.TempEmployeelist_mail;
                    gvsearchDetails.DataBind();
                }
            }
        }
        private void AddDataToEmployee(string u_user_id_pk, string firstName, string lastName, string employeeId, string mail, DataTable dtTempUser)
        {
            DataRow row;
            row = dtTempUser.NewRow();
            row["s_report_users_mailto_system_id_pk"] = Guid.NewGuid();
            if (string.IsNullOrEmpty(u_user_id_pk))
            {
             row["u_user_id_pk"] =  DBNull.Value ;
            }
            else
            {
                 row["u_user_id_pk"] =   u_user_id_pk;
            }
           
            row["u_first_name"] = firstName;
            row["u_last_name"] = lastName;
            row["u_hris_employee_id"] = employeeId;
            row["u_email_address"] = mail;
            dtTempUser.Rows.Add(row);
        }
    }
}