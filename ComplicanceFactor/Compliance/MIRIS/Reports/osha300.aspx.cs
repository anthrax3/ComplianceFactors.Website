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
    public partial class WebForm1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                rvMIRIS.ProcessingMode = ProcessingMode.Local;
                rvMIRIS.LocalReport.EnableExternalImages = true;
                rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.Reports.OSHA.rdlc";

                rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", searchResult()));

                if (Session["ReportConditions"] != null)
                {
                    dynamicsearch dySearch = new dynamicsearch();
                    dySearch.RecordLastGenerate((DataTable)Session["ReportConditions"], "", Request.Params["id"].ToString(),Request.Params["suid"].ToString());
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.window.location.reload();", true);
                }
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
               
                dtSearchCase = ComplianceBLL.SearchCaseOSHA(miris);
                if (Session["ReportConditions"] != null)
                {
                    dynamicsearch dySearch = new dynamicsearch();
                    DataRow[] rows = dtSearchCase.Select(dySearch.GetCondition((DataTable)Session["ReportConditions"]));
                    DataTable newDt = dtSearchCase.Clone();
                    foreach (DataRow row in rows)
                    {
                        newDt.Rows.Add(row.ItemArray);
                    }
                    return newDt;
                }
                else
                {
                    return dtSearchCase;
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