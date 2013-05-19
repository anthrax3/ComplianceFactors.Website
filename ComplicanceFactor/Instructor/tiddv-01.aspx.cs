using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace ComplicanceFactor.Instructor
{
    public partial class tiddv_01 : System.Web.UI.Page
    {
        private static string delliveryId;
        private static string courseId;
        private string _path = "~/SystemHome/Catalog/Course/Delivery/Attachments/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                delliveryId = Request.QueryString["deliveryId"];
                courseId = Request.QueryString["courseId"];
                hdnCourseId.Value = SecurityCenter.EncryptText(courseId);
                hdnDeliveryId.Value = SecurityCenter.EncryptText(delliveryId);
                PopulateDelivery();
            }
        }
        private void PopulateDelivery()
        {
            DataSet dsDelivery = new DataSet();
            SystemCatalog courseDelivery = new SystemCatalog();
            try
            {
                courseDelivery = InstructorBLL.GetDelivery(delliveryId);
                lblDeliveryId.Text = courseDelivery.c_delivery_id_pk;
                lblDeliverTitle.Text = courseDelivery.c_delivery_title;
                lblDeliveryType.Text = courseDelivery.c_delivery_type_id;
                hdnDeliveryType.Value = SecurityCenter.EncryptText(courseDelivery.c_delivery_type_id);
                lblDescription.Text = courseDelivery.c_delivery_desc;
                lblAbstract.Text = courseDelivery.c_delivery_abstract;
                lblApprovalRequired.Text = courseDelivery.c_delivery_approval_req_text;
                lblCurrentlyEnrolled.Text = courseDelivery.c_enroll_delivery_count;
                lblCreditHours.Text = courseDelivery.c_delivery_credit_units.ToString();
                lblCreditUnits.Text = courseDelivery.c_delivery_credit_units.ToString();
                lblMinEnroll.Text = courseDelivery.c_delivery_min_enroll.ToString();
                lblOwner.Text = courseDelivery.c_delivery_owner_name;
                lblCoordinator.Text = courseDelivery.c_delivery_coordinator_name;
                lblMaxEnroll.Text = courseDelivery.c_delivery_max_enroll.ToString();
                lblLocation.Text = courseDelivery.c_session_location_name;
                lblAirportCode.Text = courseDelivery.c_location_airport_code;
                lblCustomField01.Text = courseDelivery.c_delivery_custom_01;
                lblCustomField02.Text = courseDelivery.c_delivery_custom_02;
                lblCustomField03.Text = courseDelivery.c_delivery_custom_03;
                lblCustomField04.Text = courseDelivery.c_delivery_custom_04;
                lblCustomField05.Text = courseDelivery.c_delivery_custom_05;
                lblCustomField06.Text = courseDelivery.c_delivery_custom_06;
                lblCustomField07.Text = courseDelivery.c_delivery_custom_07;
                lblCustomField08.Text = courseDelivery.c_delivery_custom_08;
                lblCustomField09.Text = courseDelivery.c_delivery_custom_09;
                lblCustomField10.Text = courseDelivery.c_delivery_custom_10;
                lblCustomField11.Text = courseDelivery.c_delivery_custom_11;
                lblCustomField12.Text = courseDelivery.c_delivery_custom_12;
                lblCustomField13.Text = courseDelivery.c_delivery_custom_13;


                dsDelivery = InstructorBLL.GetSession_Attachment_Enrollments(delliveryId);

                gvAttachments.DataSource = dsDelivery.Tables[1];
                gvAttachments.DataBind();

                gvSessionDetails.DataSource = dsDelivery.Tables[0];
                gvSessionDetails.DataBind();

                gvEnrolledEmployees.DataSource = dsDelivery.Tables[2];
                gvEnrolledEmployees.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message);
                    }
                }
            }
        }

        protected void gvAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Download"))
            {
                string attachmentFileId = gvAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvAttachments.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_path + attachmentFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        protected void btnUpperPrint_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }

        private void PrintPdf()
        {
            rvMySignUpSheet.LocalReport.DataSources.Clear();
            DataTable dtMySession = new DataTable();
            //DataTable dtEnrolledUser = new DataTable();
            try
            {
                dtMySession = InstructorBLL.GetSessionForPdf(delliveryId,SessionWrapper.CultureName);
                //dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(delliveryId); 
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message);
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
        }

        void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtEnrolledUser = new DataTable();
            try
            {
               
                dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(delliveryId,SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tiddv-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            //rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpEmployeeList.rdlc";
            e.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
        }

        protected void btnFooterPrint_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
    }
}