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
    public partial class CompletionofCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rvCourses.ProcessingMode = ProcessingMode.Local;
                rvCourses.LocalReport.EnableExternalImages = true;
                rvCourses.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.Reports.CompletionofCourses.rdlc";

                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", searchResult()));
               
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

                if (SessionWrapper.u_sr_is_system_admin || SessionWrapper.u_sr_is_administrator)
                {
                    dtSearchCase = ComplianceBLL.SearchCompletionofCourses("");
                }
                else
                {
                    dtSearchCase = ComplianceBLL.SearchCompletionofCourses(SessionWrapper.u_userid);
                }
               

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