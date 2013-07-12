using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.Popup
{
    public partial class samdexpmp_01 : System.Web.UI.Page
    {
        private static string dexpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    dexpId = Request.QueryString["Id"].ToString();
                }

                PopulateDataExport(dexpId);
            }
        }

        /// <summary>
        ///Populate Data Export
        /// </summary>
        private void PopulateDataExport(string dexpId)
        {
            SystemHRISIntegration dataExport = new SystemHRISIntegration();

            try
            {
                dataExport = SystemBackgroundJobsBLL.GetSingleDataExport(dexpId);
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
                        Logger.WriteToErrorLog("samdexpmp-01.aspx(Background Popup)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdexpmp-01.aspx(Background Popup)", ex.Message);
                    }
                }
            }
        }

        protected void btnSaveDataExportSftpInformation_Click(object sender, EventArgs e)
        {
            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            //hrisIntegration.u_sftp_id_pk = hrisId;
            dataImport.u_sftp_URI = txtSftpServerUrl.Text;
            dataImport.u_sftp_port = txtSftpServerPort.Text;
            dataImport.u_sftp_username = txtUserName.Text;
            dataImport.u_sftp_password = txtPassword.Value;

            dataImport.u_sftp_exp_is_hris = chkHris.Checked;
            dataImport.u_sftp_exp_hris_filename = txtHris.Text;
            dataImport.u_sftp_exp_is_catalog_offering = chkCatalogOfferings.Checked;
            dataImport.u_sftp_exp_catalog_offering_filename = txtCatalogOfferings.Text;
            dataImport.u_sftp_exp_is_learning_history = chkLearningHistory.Checked;
            dataImport.u_sftp_exp_learning_history_filename = txtLearningHistory.Text;

            dataImport.u_sftp_occurs_every = txtOccursEvery.Text;
            if (ddlTimeConversion.SelectedValue == "AM")
            {
                dataImport.u_sftp_time_every = txtHours.Text;
            }
            else
            {
                DateTime time = Convert.ToDateTime(txtHours.Text);
                string timeEvery = time.ToString("HH:mm");
                int hours = Convert.ToInt16(timeEvery.Substring(0, 2));
                int minites = Convert.ToInt16(timeEvery.Substring(3, 2));
                hours = hours + 12;
                dataImport.u_sftp_time_every = hours.ToString() + ":" + minites.ToString();
            }
            dataImport.u_sftp_start_date = txtBegining.Text;

            try
            {
                if (!string.IsNullOrEmpty(dexpId))
                {
                    dataImport.u_sftp_id_pk = dexpId;
                    int updateresult = SystemDataExportBLL.UpdateDataExport(dataImport);
                    if (updateresult == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = "Updated Successfully";
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

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}