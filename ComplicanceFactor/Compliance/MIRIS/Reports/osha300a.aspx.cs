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
    public partial class osha300a : System.Web.UI.Page
    {
        private string startDate = "";
        private string endDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["startDate"] != null)
                startDate = Request.Params["startDate"].ToString();
            if (Request.Params["endDate"] != null)
                endDate = Request.Params["endDate"].ToString();
            if (!IsPostBack)
            {
                rvMIRIS.ProcessingMode = ProcessingMode.Local;
                rvMIRIS.LocalReport.EnableExternalImages = true;
                rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.Reports.OSHA300A.rdlc";

                rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", searchResult()));
                //if (Session["ReportConditions"] != null)
                //{
                //    dynamicsearch dySearch = new dynamicsearch();
                //    dySearch.RecordLastGenerate((DataTable)Session["ReportConditions"], "", Request.Params["id"].ToString(), Request.Params["suid"].ToString());
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

                dynamicsearch dySearch = new dynamicsearch();
              
                dtSearchCase = ComplianceBLL.SearchCaseOSHA300A(dySearch.GetCondition((DataTable)Session["ReportConditions"]));

                return dtSearchCase;

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