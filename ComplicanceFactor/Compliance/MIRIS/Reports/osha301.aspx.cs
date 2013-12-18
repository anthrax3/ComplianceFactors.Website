using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class osha301 : System.Web.UI.Page
    {
        private string caseid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["caseid"] == null)
            {
                //view last              
                if (Session["ReportConditions"] != null)
                {
                    DataTable dtParams = (DataTable)Session["ReportConditions"];

                    caseid = dtParams.Rows[0]["s_report_param_value"].ToString();

                }
            }
            else
            {
                //generate
                caseid = Request.Params["caseid"].ToString();
            }
            if (!IsPostBack)
            {
                rvMIRIS.ProcessingMode = ProcessingMode.Local;
                rvMIRIS.LocalReport.EnableExternalImages = true;
                rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.Reports.OSHA301.rdlc";

                rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", searchResult()));
                //if (Session["ReportConditions"] != null)
                //{
                //    dynamicsearch dySearch = new dynamicsearch();
                //    dySearch.RecordLastGenerate((DataTable)Session["ReportConditions"], caseid,Request.Params["id"].ToString(), Request.Params["suid"].ToString());
                //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.window.location.reload();", true);
                //}
            }
            
        }
    
        private DataTable searchResult()
        {
            try
            {
                DataTable dtSearchCase = new DataTable();
                ComplianceDAO miris = new ComplianceDAO();

                miris.c_case_number = "";
                miris.c_case_title = "";
               

                miris.c_case_date = null;
                miris.c_case_category_fk = "0";

                miris.c_case_type_fk = "0";
                miris.c_case_status = "0";

                dtSearchCase = ComplianceBLL.SearchCase(miris);
                DataRow[] rows = dtSearchCase.Select("c_case_id_pk='" + caseid + "'");
                DataTable newDt = dtSearchCase.Clone();
                foreach (DataRow row in rows)
                {
                    newDt.Rows.Add(row.ItemArray);
                }
                return newDt; 
                
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                    }
                }
                return null;
            }

        }
      
    }
}