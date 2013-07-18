using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Text;
using System.IO;
using System.Globalization;
using System.Net;

namespace ComplicanceFactor.SystemHome.Configuration.DataExports
{
    public partial class samdexpmp_01 : System.Web.UI.Page
    {
        private static string dexpId;
        public static string APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/TempExport_CSV/");
        public static string TEMP_APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/DataExports/TempLogFiles/");   

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + "Manage Data Exports" + "</a>";
                PopulateDataExport();
                //FTP_Upload();
            }
        }

        /// <summary>
        ///Populate Data Export
        /// </summary>
        private void PopulateDataExport()
        {
            SystemHRISIntegration dataExport = new SystemHRISIntegration();

            try
            {
                dataExport = SystemDataExportBLL.GetSingleDataExport();
                if (!string.IsNullOrEmpty(dataExport.u_sftp_id_pk))
                {
                    dexpId = dataExport.u_sftp_id_pk;
                    txtSftpServerUrl.Text = dataExport.u_sftp_URI;
                    txtUserName.Text = dataExport.u_sftp_username;
                    txtSftpServerPort.Text = dataExport.u_sftp_port;
                    txtOccursEvery.Text = dataExport.u_sftp_occurs_every;
                    txtLearningHistory.Text = dataExport.u_sftp_exp_learning_history_filename;
                    if (dataExport.u_sftp_exp_is_learning_history == true)
                    {
                        chkLearningHistory.Checked = true;
                    }
                    else
                    {
                        chkLearningHistory.Checked = false;
                    }

                    if (dataExport.u_sftp_exp_is_catalog_offering == true)
                    {
                        chkCatalogOfferings.Checked = true;
                    }
                    else
                    {
                        chkCatalogOfferings.Checked = false;
                    }

                    if (dataExport.u_sftp_exp_is_hris == true)
                    {
                        chkHris.Checked = true;
                    }
                    else
                    {
                        chkHris.Checked = false;
                    }
                    txtCatalogOfferings.Text = dataExport.u_sftp_exp_catalog_offering_filename;
                    txtHris.Text = dataExport.u_sftp_exp_hris_filename;

                    txtPassword.Value = dataExport.u_sftp_password;
                    txtPassword.Attributes["type"] = "password";
                    string time = dataExport.u_sftp_time_every;
                    int length = time.Length;
                    ddlTimeConversion.SelectedValue = time.Substring(length - 2, 2);
                    txtHours.Text = time.Remove(length - 2);
                    txtBegining.Text = Convert.ToDateTime(dataExport.u_sftp_start_date).ToString("d");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnSaveDataExportSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration dataExport = new SystemHRISIntegration();

            //hrisIntegration.u_sftp_id_pk = hrisId;
            dataExport.u_sftp_URI = txtSftpServerUrl.Text;
            dataExport.u_sftp_port = txtSftpServerPort.Text;
            dataExport.u_sftp_username = txtUserName.Text;
            dataExport.u_sftp_password = txtPassword.Value;

            dataExport.u_sftp_exp_is_hris = chkHris.Checked;
            dataExport.u_sftp_exp_hris_filename = txtHris.Text;
            dataExport.u_sftp_exp_is_catalog_offering = chkCatalogOfferings.Checked;
            dataExport.u_sftp_exp_catalog_offering_filename = txtCatalogOfferings.Text;
            dataExport.u_sftp_exp_is_learning_history = chkLearningHistory.Checked;
            dataExport.u_sftp_exp_learning_history_filename = txtLearningHistory.Text;

            dataExport.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                if (hours == 12)
                {
                    dataExport.u_sftp_time_every = "00:" + minites;
                }
                else
                {
                    dataExport.u_sftp_time_every = txtHours.Text;
                }
            }
            else
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                if (hours == 12)
                {
                    dataExport.u_sftp_time_every = txtHours.Text;
                }
                else
                {
                    hours = hours + 12;
                    dataExport.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
                }
            }
            dataExport.u_sftp_start_date = txtBegining.Text;

            try
            {
                if (!string.IsNullOrEmpty(dexpId))
                {
                    dataExport.u_sftp_id_pk = dexpId;
                    int updateresult = SystemDataExportBLL.UpdateDataExport(dataExport);
                    if (updateresult == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Updated Successfully";
                    }
                }
                else
                {
                    int result = SystemDataExportBLL.InsertDataExport(dataExport);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Inserted Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx", ex.Message);
                    }
                }
            }
        }      
        protected void btnDownloadFacilitiesCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Facilities.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Rooms CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadRoomsCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Rooms.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Course CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadCoursesCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Course.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Curriculum CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadBaseCurriculamCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Curriculum.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Enrollments CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadEnrollmentsCsvFile_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Enrollments.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
        /// Download Leraning History CSV from FTP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadLearningHistory_Click(object sender, EventArgs e)
        {
            string filePath = APP_PATH + "Learning_History.csv";

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file.Name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        //Response.ContentType = ReturnExtension(file.Extension.ToLower());
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
}