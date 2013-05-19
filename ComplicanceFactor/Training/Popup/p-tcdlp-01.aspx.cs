using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Text;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.Common.Languages;
using System.Globalization;

namespace ComplicanceFactor.Training
{
    public partial class p_tcdlp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 //Add column in delivery datatable
                SessionWrapper.Deliveries = TempDataTables.TempDeliveries();

                //Add column in delivery session datatable
                SessionWrapper.DeliverySessions = TempDataTables.TempDeliverySessions();

                //Add column in resource datatable
                SessionWrapper.DeliveryResource = TempDataTables.TempDeliveryResource();

                //Add column in material datatable
                SessionWrapper.DeliveryMaterial = TempDataTables.TempDeliveryMaterials();

                //Add column in delivery attachments
                SessionWrapper.DeliveryAttachments = TempDataTables.TempDeliveryattachments();
                
                hdCourseId.Value = Request.QueryString["id"].ToString();
                //Bind deliveries
                BindCourseDeliveries();
                //Get User Name
                hdUserName.Value = SessionWrapper.u_username;
                hdUserID.Value = SessionWrapper.u_userid;
            }
            if (hdAddNewDelivery.Value == "0")
            {
                BindCourseDeliveries();
                hdAddNewDelivery.Value = "1";
            }
           
                      
        }

        protected void gvCourseDeliveries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Copy"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string newDeliveryId = Guid.NewGuid().ToString();
                int error = TrainingBLL.CopyDelivery(gvCourseDeliveries.DataKeys[rowIndex][0].ToString(), gvCourseDeliveries.DataKeys[rowIndex][1].ToString(), newDeliveryId);
                
                if (error != -2)
                {
                    Response.Redirect("/SystemHome/Catalog/Course/Delivery/saed-02.aspx?editdelivery=" + newDeliveryId,false);
                }
                else
                {
                    divError.Style.Add("display", "Block");
                    divError.InnerText = LocalResources.GetText("app_data_not_copied_error_wrong");
                    //divSuccess.Style.Add("display", "none");
                }
            }
            BindCourseDeliveries();      
        }

        private void BindCourseDeliveries()
        {
            gvCourseDeliveries.DataSource = TrainingBLL.GetDeliveriesByCourseid(Request.QueryString["id"]);
            gvCourseDeliveries.DataBind(); 
        }

       

        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        private void PrintPdf()
        {
            rvDelivery.LocalReport.DataSources.Clear();
            DataSet dsDelivery = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsDelivery = TrainingBLL.GetDeliveriesPdf(hdCourseId.Value,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            if (dsDelivery.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvDelivery.ProcessingMode = ProcessingMode.Local;
                rvDelivery.LocalReport.EnableExternalImages = true;
                rvDelivery.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Training.Popup.PdfTemplate.MyDeliveries.rdlc";
                rvDelivery.LocalReport.DataSources.Add(new ReportDataSource("dsMydeliveries", dsDelivery.Tables[0]));
                byte[] bytes = rvDelivery.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyDeliveries" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
                
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsDelivery = new DataSet();
            try
            {
                dsDelivery = TrainingBLL.GetDeliveriesPdf(hdCourseId.Value,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmhp-01.aspx (ExportExcel)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmhp-01.aspx (ExportExcel)", ex.Message);
                    }
                }

            }
            if (dsDelivery.Tables[0].Rows.Count > 0)
            {
                exportDataTableToCsv(dsDelivery.Tables[1],dsDelivery.Tables[2]);
            }
        }
        private void exportDataTableToCsv(DataTable dt,DataTable dtDeliveries)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyDeliveries.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtDeliveries.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtDeliveries.Rows[k]["deliveryColumnName"].ToString() + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ",") + ',');
                }

                //append new line
                sb.Append("\r\n");

            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();


        }
    }
}