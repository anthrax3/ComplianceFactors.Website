using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.IO;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Reports
{
    public partial class sarpl_01 : System.Web.UI.Page
    {
        public string localeText = "";
        private List<string> labelnames
        {
            get
            {
                if (ViewState["labelnames"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<string>)ViewState["labelnames"];
                }
            }
            set
            {
                ViewState["labelnames"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                localeText = Request.Params["editLocaleText"].ToString();
                DataTable table = new DataTable();
                if (Request.Params["mode"].ToString() == "create")
                {
                    foreach(DataRow row in SessionWrapper.ReportParam.Rows)
                    {
                        
                        DataRow[] rowsExist = SessionWrapper.ReportLabelLocale.Select("s_report_param_label_name='" + row["s_report_param_label_name"] + "' and s_locale_id_pk='" + Request.Params["editLocaleId"].ToString() + "'");
                        if (rowsExist.Length==0)
                        {
                         DataRow newRow = SessionWrapper.ReportLabelLocale.NewRow();
                            newRow["s_report_param_label_name"] = row["s_report_param_label_name"];
                            newRow["s_report_param_name"] = row["s_report_param_name"];
                             newRow["s_report_label"] = row["s_report_label"];
                            newRow["s_locale_id_pk"] =Request.Params["editLocaleId"].ToString();
                            newRow["s_locale_description"] = localeText;
                            SessionWrapper.ReportLabelLocale.Rows.Add(newRow);
                        }
                    }
                    foreach (DataRow row in SessionWrapper.ReportColumn.Rows)
                    {
                        DataRow[] rowsExist = SessionWrapper.ReportLabelLocale.Select("s_report_param_label_name='" + row["s_report_column_label_name"] + "' and s_locale_id_pk='" + Request.Params["editLocaleId"].ToString() + "'");
                        if (rowsExist.Length == 0)
                        {
                            DataRow newRow = SessionWrapper.ReportLabelLocale.NewRow();
                            newRow["s_report_param_label_name"] = row["s_report_column_label_name"];
                            newRow["s_report_param_name"] = row["s_report_column_name"];
                            newRow["s_report_label"] = row["s_report_label"];
                            newRow["s_locale_id_pk"] = Request.Params["editLocaleId"].ToString();
                            newRow["s_locale_description"] = localeText;
                            SessionWrapper.ReportLabelLocale.Rows.Add(newRow);
                        }
                    }
                    DataTable copyTable = SessionWrapper.ReportLabelLocale.Copy();
                    if (copyTable.Rows.Count > 0)
                    {
                        
                        var rows = copyTable.Select("s_locale_id_pk<>'" + Request.Params["editLocaleId"].ToString() + "'");
                        foreach (var row in rows)
                            row.Delete();
                        copyTable.AcceptChanges();
                    }
                    table = copyTable;
                     
                }
                else
                {
                    if (Request.Params["localeMode"].ToString() == "create")
                    {

                        table = SystemReportBLL.GetLocalesOfReport(SecurityCenter.DecryptText(Request.Params["Id"].ToString()));
                    }
                    else
                    {
                        table = SystemReportBLL.GetLocalesOfReport(SecurityCenter.DecryptText(Request.Params["Id"].ToString()), Request.Params["editLocaleId"].ToString());
                    }
                }
                
                List<string> lbls = new List<string>();
                rpLocles.DataSource = table;
                foreach (DataRow row in table.Rows)
                {
                    lbls.Add(row["s_report_param_label_name"].ToString());
                }
                labelnames = lbls;
                rpLocles.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] language_text = Request.Params["language_value"].ToString().Split(new char[]{','});
            int i = 0;
            if (Request.Params["mode"].ToString() == "create")
            {
                foreach (DataRow row in SessionWrapper.ReportLabelLocale.Rows)
                {
                    if (row["s_locale_id_pk"].ToString() == Request.Params["editLocaleId"].ToString())
                    {
                        row["s_report_label"] = language_text[i];
                        i++;
                    }
                }
            }
            else
            {
                
                foreach (string lbl in labelnames)
                {
                    SystemReportBLL.UpdateLocalesOfReport(Request.Params["editLocaleId"].ToString(), language_text[i], lbl, SecurityCenter.DecryptText(Request.Params["Id"].ToString()));
                    i++;
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.jQuery.fancybox.close();", true);
        }
    }
}