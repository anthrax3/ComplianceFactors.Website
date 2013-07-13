using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;
using ComplicanceFactor.Common;
using System.Globalization;

namespace ComplicanceFactor.Compliance.SiteView.Ojt
{
    public partial class csvvojt : System.Web.UI.Page
    {
        private string _filePath = "~/Compliance/SiteView/Ojt/CertificateAttachments/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.ojt_upload_certification_file_path = null;
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "view")
                {
                    PopulateOjt(Request.QueryString["id"].ToString());
                }
            }
        }
        private void PopulateOjt(string ojtId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            SiteViewOnJobTraining ojt;
            ojt = SiteViewOnJobTrainingBLL.GetSingleOjt(ojtId);
            lblOjtNumber.Text = ojt.sv_ojt_number;
            lblOjtTitle.Text = ojt.sv_ojt_title;
            lblOjtDescription.Text = ojt.sv_ojt_description;
            lblOjtLocation.Text = ojt.sv_ojt_location;
            lblOjtTrainer.Text = ojt.sv_ojt_Trainer;

            lblOjtDate.Text = ojt.sv_ojt_date.ToString("MM/dd/yyyy");           

            if (!string.IsNullOrEmpty(ojt.sv_ojt_start_time))
            {
                lblOjtStartTime.Text = Convert.ToDateTime(ojt.sv_ojt_start_time).ToString("t");
            }

            if (!string.IsNullOrEmpty(ojt.sv_ojt_end_time))
            {
                lblOjtEndTime.Text = Convert.ToDateTime(ojt.sv_ojt_end_time).ToString("t");
            }           
            
            //lblOjtStartTime.Text = ojt.sv_ojt_start_time;
            //lblOjtEndTime.Text = ojt.sv_ojt_end_time;

            lblOjtDuration.Text = ojt.sv_ojt_duration;
            lblOjtType.Text = ojt.sv_ojt_type;
            if (ojt.sv_ojt_issafty_brief == true)
            {
                chkOjtIsSafety.Checked = true;
            }
            lblOjtFrequency.Text = ojt.sv_ojt_frequency;
            if (ojt.sv_ojt_isharm_related == true)
            {
                chkOjtIsHarm.Checked = true;
            }
            lblOjtHarmDetail.Text = ojt.harmTitle;
            lbtnCertificationFile.Text = ojt.sv_ojt_certify_filepath;
            SessionWrapper.ojt_upload_certification_file_path = ojt.sv_ojt_certify_filepath;

            if (ojt.sv_ojt_iscertification_related == true)
            {
                chkIsCertRelated.Checked = true;
            }
            lblOthers.Text = ojt.sv_ojt_other;


            gvAttachment.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(ojtId);
            gvAttachment.DataBind();

            gvAcknowledgement.DataSource = SiteViewOnJobTrainingBLL.GetOjtAcknowledge(ojtId);
            gvAcknowledgement.DataBind();
        }

        protected void lbtnCertificationFile_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_filePath + SessionWrapper.ojt_upload_certification_file_path);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.ojt_upload_certification_file_name + "\"");
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

        /// <summary>
        /// Return Extension for File  
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
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


        
    }
}