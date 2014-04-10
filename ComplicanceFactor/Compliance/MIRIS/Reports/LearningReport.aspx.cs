using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using Microsoft.Reporting.WebForms;

namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class LearningReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rvLearningReport.ProcessingMode = ProcessingMode.Local;
                rvLearningReport.LocalReport.EnableExternalImages = true;
                rvLearningReport.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.Reports.LearningReportDetails.rdlc";

                rvLearningReport.LocalReport.DataSources.Add(new ReportDataSource("LearningReport", searchResult()));

                SessionWrapper.selectedUserId_learningReport = string.Empty;
                SessionWrapper.selectedUserName_learningReport = string.Empty;
                SessionWrapper.selectedCourseId_learningReport = string.Empty;
                SessionWrapper.selectedCourseName_learningReport = string.Empty;
                SessionWrapper.selectedDeliveryTypeId_learningReport = string.Empty;
                SessionWrapper.selectedDeliveryTypeName_learningReport = string.Empty;
                SessionWrapper.selectedStatusName_learningReport = string.Empty;
                SessionWrapper.selectedStatusNameText_learningReport = string.Empty;                 
            }
        }

        private DataTable searchResult()
        {
            try
            {
                DataTable dtSearchCase = new DataTable();

                dtSearchCase = MyReportBLL.GetAllLearningReport();


                if (Session["ReportConditions"] != null)
                {
                    dynamicsearch dySearch = new dynamicsearch();
                    string condition = dySearch.GetCondition((DataTable)Session["ReportConditions"]);
                    if(!string.IsNullOrEmpty(SessionWrapper.selectedUserId_learningReport))
                    {
                        if (!string.IsNullOrEmpty(condition))
                        {
                            condition = condition + "and ";
                        }
                        condition = condition + "u_user_id_pk in (" + SessionWrapper.selectedUserId_learningReport+")";
                    }
                    if (!string.IsNullOrEmpty(SessionWrapper.selectedCourseId_learningReport))
                    {
                        if (!string.IsNullOrEmpty(condition))
                        {
                            condition = condition + "and ";
                        }
                        condition = condition + "CourseId in (" + SessionWrapper.selectedCourseId_learningReport + ")";
                    }
                    if (!string.IsNullOrEmpty(SessionWrapper.selectedDeliveryTypeId_learningReport))
                    {
                        if (!string.IsNullOrEmpty(condition))
                        {
                            condition = condition + "and ";
                        }
                        condition = condition + "DeliveryType in (" + SessionWrapper.selectedDeliveryTypeId_learningReport + ")";
                    }
                    if (!string.IsNullOrEmpty(SessionWrapper.selectedStatusName_learningReport))
                    {
                        if (!string.IsNullOrEmpty(condition))
                        {
                            condition = condition + "and ";
                        }
                        condition = condition + "Completionstatus in (" + SessionWrapper.selectedStatusName_learningReport + ")";
                    }
                    DataRow[] rows = dtSearchCase.Select(condition);
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