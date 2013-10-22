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
    public partial class sarpp_01 : System.Web.UI.Page
    {
        private string ReportId
        {
            get
            {
                return (ViewState["ReportId"] == null) ? "" : ViewState["ReportId"].ToString();
            }
            set
            {
                ViewState["ReportId"] = value;
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                   
                    ReportId = SecurityCenter.DecryptText(Request.QueryString["id"]);

                }
              
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemReportParam param = new SystemReportParam()
            {
                s_report_param_system_id_pk = Guid.NewGuid().ToString(),
                s_report_param_description = txtDescription.InnerText,
                s_report_param_field_id_pk = "",
                s_report_param_id_pk = "",
                s_report_param_name = txtParameterName.Text,
                s_report_param_table_id_pk = "",
                s_report_param_type_id_fk = ddlType.SelectedValue,
                s_report_param_visible_flag = chkVisible.Checked,
                 s_report_param_label_name =txtLabelId.Text,
                
                s_report_system_id_fk = ReportId
            };
            try
            {
                if (Request.Params["mode"].ToString() == "create")
                {
                    AddParamDataToSession();
                }
                else
                {
                    SystemReportBLL.CreateParamOfReport(param);
                    
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
                        Logger.WriteToErrorLog("sarpp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sarpp-01", ex.Message);
                    }
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// add data to session
        /// </summary>
        
        private void AddParamDataToSession()
        {
            DataRow row;

            row = SessionWrapper.ReportParam.NewRow();
            row["s_report_param_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_report_system_id_fk"] = ReportId;           
            row["s_report_param_name"] = txtParameterName.Text;         
            row["s_report_param_type_id_fk"] = ddlType.SelectedValue;
            row["s_report_param_visible_flag"] = chkVisible.Checked;            
            row["s_report_param_label_name"] = txtLabelId.Text;
            //row["s_report_param_table_id_pk"] = s_locale_name;
            // row["s_report_param_field_id_pk"] = s_locale_description;
            // row["s_report_param_description"] = s_locale_text;
            //row["s_report_param_id_pk"] = s_locale_name;
            SessionWrapper.ReportParam.Rows.Add(row);
        }

    }
}