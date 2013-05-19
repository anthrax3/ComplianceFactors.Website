using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using System.Text;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Instructor
{
    public partial class timrostersp_01 : System.Web.UI.Page
    {
        private static string currentdeliveryId;
        DataSet dsSearch = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_instructor";
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_instructor") + "</a>" + " >&nbsp;" + "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_my_rosters_text");


                BindRoaster();
            }
        }
        private void BindRoaster()
        {
            try
            {
                dsSearch = InstructorBLL.GetTodoRoasterReport(SessionWrapper.u_userid);

                gvMyRosters.DataSource = dsSearch.Tables[1];
                gvMyRosters.DataBind();

                if (gvMyRosters.Rows.Count > 0)
                {
                    gvMyRosters.UseAccessibleHeader = true;
                    if (gvMyRosters.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvMyRosters.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message);
                    }
                }
            }
        }

        protected void gvMyRosters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Completion")
            {
               
                string courseId = gvMyRosters.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyRosters.DataKeys[rowIndex][1].ToString();
                string deliveryType = gvMyRosters.DataKeys[rowIndex][2].ToString();
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType), false);
            }
            else if (e.CommandName == "Print")
            {
                //int rowIndex = int.Parse(e.CommandArgument.ToString());
                string courseId = gvMyRosters.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyRosters.DataKeys[rowIndex][1].ToString();
                currentdeliveryId = deliveryId;
                string deliveryType = gvMyRosters.DataKeys[rowIndex][2].ToString();

                rvMySignUpSheet.LocalReport.DataSources.Clear();
                DataTable dtMySession = new DataTable();                 
                try
                {
                    dtMySession = InstructorBLL.GetSessionForPdf(deliveryId,SessionWrapper.CultureName);
                    
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("timroastersp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("timroastersp-01.aspx (PDF)", ex.Message);
                        }
                    }

                }
                if (dtMySession.Rows.Count > 0)
                {
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    rvMySignUpSheet.ProcessingMode = ProcessingMode.Local;
                    rvMySignUpSheet.LocalReport.EnableExternalImages = true;
                    rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpSheet.rdlc";
                    rvMySignUpSheet.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);
                    rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsSessionDetails", dtMySession));
                    //rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
                    byte[] bytes = rvMySignUpSheet.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=\"" + "MySignUpSheet" + ".pdf" + "\"");
                    Response.BinaryWrite(bytes); // create the file     
                    Response.Flush(); // send it to the client to download  
                    Response.End();
                    Response.Close();
                }

                //Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            }
        }
        void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtEnrolledUser = new DataTable();
            try
            {
                dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(currentdeliveryId,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("timroastersp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("timroastersp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            //rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpEmployeeList.rdlc";
            e.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
        }


        protected void gvMyRosters_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        private void exportDataTableToCsv(DataTable dt, DataTable dtGetRosterColumnName)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyRoaster.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtGetRosterColumnName.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtGetRosterColumnName.Rows[k]["rosterColumnName"].ToString() + ',');
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

        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsMyCourse = new DataSet();
            try
            {
                dsMyCourse = InstructorBLL.GetRoasterforPdfExcel(SessionWrapper.u_userid,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            if (dsMyCourse.Tables[1].Rows.Count > 0)
            {
                exportDataTableToCsv(dsMyCourse.Tables[1],dsMyCourse.Tables[2]);
            }
        }

        /// <summary>
        /// Print PDF
        /// </summary>
        private void PrintPdf()
        {
            rvMyRoaster.LocalReport.DataSources.Clear();
            DataSet dsMycourses = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsMycourses = InstructorBLL.GetRoasterforPdfExcel(SessionWrapper.u_userid,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmrosterp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            if (dsMycourses.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvMyRoaster.ProcessingMode = ProcessingMode.Local;
                rvMyRoaster.LocalReport.EnableExternalImages = true;
                rvMyRoaster.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.MyRoasters.rdlc";
                rvMyRoaster.LocalReport.DataSources.Add(new ReportDataSource("dsMyRoasters", dsMycourses.Tables[0]));
                byte[] bytes = rvMyRoaster.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyRoasters" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }
    }
}