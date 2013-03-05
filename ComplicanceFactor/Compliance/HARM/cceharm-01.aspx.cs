using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using ComplicanceFactor.Common.Languages;
using System.Threading;
using System.Globalization;

namespace ComplicanceFactor.Compliance.HARM
{
    public partial class cceharm_01 : BasePage
    {
        private string harmId;
        #region "Private Member Variables"

        private string _pathCustomCustomer = "~/Compliance/HARM/Upload/CustomCustomer/";
        private string _pathPhoto = "~/Compliance/HARM/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/HARM/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/HARM/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/HARM/Upload/EmployeeInterview/";

        #endregion
        //CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Compliance/HARM/ccasharm-01.aspx>" + LocalResources.GetLabel("app_harm_text") + "</a>&nbsp;> " + LocalResources.GetLabel("app_edit_harm_text");

            //Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["Edit"])))
            {
                harmId = SecurityCenter.DecryptText(Request.QueryString["Edit"]);

            }
            btnView_header.OnClientClick = "window.open('ccvharm-01.aspx?View=" + SecurityCenter.EncryptText(harmId) + "','',''); return true;";
            btnView_Footer.OnClientClick = "window.open('ccvharm-01.aspx?View=" + SecurityCenter.EncryptText(harmId) + "','',''); return true;";
            if (!IsPostBack)
            {

                try
                {
                    ddlCaseCategory.DataSource = ComplianceBLL.GetHarmCategory(SessionWrapper.CultureName, "cceharm-01");
                    ddlCaseCategory.DataBind();

                    ddlCasestatus.DataSource = ComplianceBLL.GetHarmStatus(SessionWrapper.CultureName, "cceharm-01");
                    ddlCasestatus.DataBind();

                    ddlControlMeasure.DataSource = ComplianceBLL.GetControlMeasure(SessionWrapper.CultureName, "cceharm-01");
                    ddlControlMeasure.DataBind();
                    //Add and edit control measure
                    ddlAddEditControlMeasure.DataSource = ComplianceBLL.GetControlMeasure(SessionWrapper.CultureName, "cceharm-01");
                    ddlAddEditControlMeasure.DataBind();

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }


                }

                if (!string.IsNullOrEmpty(Request.QueryString["Succ"]))
                {
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_create_succ_text");
                }

                //clear session
                ClearHarmSession();
                PopulateHarm(harmId);

                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_harm_id_pk = harmId;

                    //Hazard and control measure
                    DataTable dtHazard = new DataTable();
                    try
                    {
                        dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                        dlHazard.DataBind();

                        dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                        dlHazardSummary.DataBind();

                        SessionWrapper.Hazard = ComplianceBLL.GetAllHazard(harm);
                        SessionWrapper.ControlMeasure = TempHarmDataTable.tempControlMeasure();
                        DataTable dtCopyHazard = ComplianceBLL.GetAllHazard(harm);
                        if (dtCopyHazard.Rows.Count > 0)
                        {
                            lblJobTitle.Text = dtCopyHazard.Rows[0]["h_job_title"].ToString();
                            txtEditJobTitle.Text = dtCopyHazard.Rows[0]["h_job_title"].ToString();
                        }
                        SessionWrapper.h_job_title = lblJobTitle.Text;
                        foreach (DataRow drCopyHazard in dtCopyHazard.Rows)
                        {
                            //string hazardId = Guid.NewGuid().ToString();
                            harm.h_hazard_id_pk = drCopyHazard["h_hazard_id_pk"].ToString();
                            //Get control measure
                            DataTable dtCopyControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);

                            foreach (DataRow drCopyControlmeasure in dtCopyControlMeasure.Rows)
                            {
                                AddDataToTempControlMeasure(harm.h_hazard_id_pk, drCopyControlmeasure["h_control_measure_summary"].ToString(), drCopyControlmeasure["h_control_measure_id_fk"].ToString(), drCopyControlmeasure["h_control_measure_text"].ToString(), SessionWrapper.ControlMeasure);

                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message);
                            }
                        }

                    }

                    //End

                    //
                    DataTable dtGetHarmCustomCustomer = new DataTable();
                    dtGetHarmCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);

                    this.gvCustomForm.DataSource = dtGetHarmCustomCustomer;
                    this.gvCustomForm.DataBind();

                    //photo

                    DataTable dtGetHarmPhoto = new DataTable();
                    dtGetHarmPhoto = ComplianceBLL.GetHarmPhoto(harm);

                    this.gvPhoto.DataSource = dtGetHarmPhoto;
                    this.gvPhoto.DataBind();



                    //SceneSketch

                    DataTable dtGetHarmSceneSketch = new DataTable();
                    dtGetHarmSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);

                    this.gvSceneSketch.DataSource = dtGetHarmSceneSketch;
                    this.gvSceneSketch.DataBind();

                    //Extenautingcondition

                    DataTable dtGetHarmExtenautingCondition = new DataTable();
                    dtGetHarmExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);

                    this.gvExtenautingCondition.DataSource = dtGetHarmExtenautingCondition;
                    this.gvExtenautingCondition.DataBind();

                    //EmployeeInterview
                    DataTable dtGetHarmEmployeeInterview = new DataTable();
                    dtGetHarmEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);

                    this.gvEmployeeInterview.DataSource = dtGetHarmEmployeeInterview;
                    this.gvEmployeeInterview.DataBind();

                    SessionWrapper.session_Custom_Customer = dtGetHarmCustomCustomer;
                    SessionWrapper.session_Photo = dtGetHarmPhoto;

                    SessionWrapper.session_SceneSketch = dtGetHarmSceneSketch;

                    SessionWrapper.session_ExtenuatingCondition = dtGetHarmExtenautingCondition;
                    SessionWrapper.session_EmployeeInterview = dtGetHarmEmployeeInterview;


                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                for (int i = 0; i < dlHazard.Items.Count; i++)
                {
                    DataListItem dlItem = dlHazard.Items[i];
                    GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                    if (gvControlmeasure.Rows.Count == 1)
                    {
                        Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                        btnRemoveControlMeasure.Style.Add("display", "none");
                    }

                }
            }

        }
        private void PopulateHarm(string harmId)
        {
            ComplianceDAO harm = new ComplianceDAO();
            try
            {
                harm = ComplianceBLL.GetHarm(harmId);



                lblCaseDate.Text = Convert.ToDateTime(harm.h_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblHarmNumber.Text = harm.h_harm_number;
                txtCaseTitle.Text = harm.h_case_title;
                ddlCaseCategory.SelectedValue = harm.h_case_category_fk;
                ddlCasestatus.SelectedValue = harm.h_status_id;
                //txtEmployeeReportLocation.Text = harm.h_employee_report_location;
                txtCustom01.Text = harm.h_custom_01;
                txtCustom02.Text = harm.h_custom_02;
                txtCustom03.Text = harm.h_custom_03;
                txtCustom04.Text = harm.h_custom_04;
                txtCustom05.Text = harm.h_custom_05;
                txtCustom06.Text = harm.h_custom_06;
                txtCustom07.Text = harm.h_custom_07;
                txtCustom08.Text = harm.h_custom_08;
                txtCustom09.Text = harm.h_custom_09;
                txtCustom10.Text = harm.h_custom_10;
                txtCustom11.Text = harm.h_custom_11;
                txtCustom12.Text = harm.h_custom_12;
                txtCustom13.Text = harm.h_custom_13;


            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }
            }

        }
        protected void btnUploadCustomCustomer_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string h_file_name = null;
                string h_file_extension = null;
                string h_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    h_file_name = Path.GetFileName(file.FileName);

                    h_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathCustomCustomer + h_file_guid + h_file_extension));
                    try
                    {
                        ComplianceDAO customCustomer = new ComplianceDAO();
                        customCustomer.h_file_guid = h_file_guid + h_file_extension;
                        customCustomer.h_file_name = h_file_name;
                        customCustomer.h_harm_id_pk = harmId;

                        if (!string.IsNullOrEmpty(hdAddForm.Value))
                        {
                            customCustomer.h_file_id = hdAddForm.Value;
                            ComplianceBLL.UpdateHarmCustomCustomer(customCustomer);

                            //ComplianceBLL.UpdatePhotoFile(customCustomer);

                            hdAddForm.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InserHarmCustomCustomer(customCustomer);

                        }


                        DataTable dtGetCustomCustomer = new DataTable();
                        dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(customCustomer);
                        this.gvCustomForm.DataSource = dtGetCustomCustomer;
                        this.gvCustomForm.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }
                    }

                }

            }
           

        }
        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string h_file_name = null;
                string h_file_extension = null;
                string h_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    h_file_name = Path.GetFileName(file.FileName);

                    h_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathPhoto + h_file_guid + h_file_extension));
                    try
                    {
                        ComplianceDAO photo = new ComplianceDAO();
                        photo.h_file_guid = h_file_guid + h_file_extension;
                        photo.h_file_name = h_file_name;
                        photo.h_harm_id_pk = harmId;

                        if (!string.IsNullOrEmpty(hdPhoto.Value))
                        {
                            photo.h_file_id = hdPhoto.Value;
                            ComplianceBLL.UpdateHarmPhotoFile(photo);
                            //ComplianceBLL.UpdatePhotoFile(photo);

                            hdPhoto.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertHarmPhoto(photo);

                        }


                        DataTable dtGetPhoto = new DataTable();
                        dtGetPhoto = ComplianceBLL.GetHarmPhoto(photo);
                        this.gvPhoto.DataSource = dtGetPhoto;
                        this.gvPhoto.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }
                    }

                }

            }


        }
        protected void btnUploadSceneSketch_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string h_file_name = null;
                string h_file_extension = null;
                string h_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    h_file_name = Path.GetFileName(file.FileName);

                    h_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathSceneSketch + h_file_guid + h_file_extension));
                    try
                    {
                        ComplianceDAO sceneSketch = new ComplianceDAO();
                        sceneSketch.h_file_guid = h_file_guid + h_file_extension;
                        sceneSketch.h_file_name = h_file_name;
                        sceneSketch.h_harm_id_pk = harmId;

                        if (!string.IsNullOrEmpty(hdSceneSketch.Value))
                        {
                            sceneSketch.h_file_id = hdSceneSketch.Value;
                            ComplianceBLL.UpdateHarmSceneSketchFile(sceneSketch);

                            //ComplianceBLL.UpdateSceneSketchFile(sceneSketch);

                            hdSceneSketch.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertHarmSceneSketch(sceneSketch);

                        }
                        //scenesketch
                        DataTable dtGetSceneSketch = new DataTable();
                        dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(sceneSketch);
                        this.gvSceneSketch.DataSource = dtGetSceneSketch;
                        this.gvSceneSketch.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }
                    }

                }

            }
        }
        protected void btnUploadExtenautingcond_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string h_file_name = null;
                string h_file_extension = null;
                string h_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    h_file_name = Path.GetFileName(file.FileName);

                    h_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathExtenuatingcondition + h_file_guid + h_file_extension));
                    try
                    {
                        ComplianceDAO extenautingcond = new ComplianceDAO();
                        extenautingcond.h_file_guid = h_file_guid + h_file_extension;
                        extenautingcond.h_file_name = h_file_name;


                        extenautingcond.h_harm_id_pk = harmId;
                        if (!string.IsNullOrEmpty(hdExtenautingcond.Value))
                        {
                            extenautingcond.h_file_id = hdExtenautingcond.Value;
                            ComplianceBLL.UpdateHarmExtenautingConditionFile(extenautingcond);

                            // ComplianceBLL.UpdateExtenautingConditionFile(extenautingcond);

                            hdExtenautingcond.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertHarmExtenuatingCondition(extenautingcond);

                        }
                        //Extenautingcondition
                        DataTable dtGetExtenautingcondition = new DataTable();
                        dtGetExtenautingcondition = ComplianceBLL.GetHarmExtenuatingCondition(extenautingcond);

                        this.gvExtenautingCondition.DataSource = dtGetExtenautingcondition;
                        this.gvExtenautingCondition.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }
                    }
                }

            }


        }
        protected void btnUploadEmployeeInterview_Click(object sender, EventArgs e)
        {

            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string h_file_name = null;
                string h_file_extension = null;
                string h_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    h_file_name = Path.GetFileName(file.FileName);

                    h_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathEmployeeInterview + h_file_guid + h_file_extension));
                    try
                    {
                        ComplianceDAO employeeInterview = new ComplianceDAO();
                        employeeInterview.h_file_guid = h_file_guid + h_file_extension;
                        employeeInterview.h_file_name = h_file_name;
                        employeeInterview.h_name = txtName.Text;
                        employeeInterview.h_contact_info = txtContactInfo.Value;
                        employeeInterview.h_harm_id_pk = harmId;
                        if (!string.IsNullOrEmpty(hdEmployeeInterview.Value))
                        {
                            employeeInterview.h_file_id = hdEmployeeInterview.Value;
                            ComplianceBLL.UpdateHarmEmployeeInterviewFile(employeeInterview);
                            hdEmployeeInterview.Value = "";
                        }
                        else
                        {
                            ComplianceBLL.InsertHarmEmployeeInterview(employeeInterview);

                        }
                        txtName.Text = string.Empty;
                        txtContactInfo.Value = string.Empty;
                        //Employee interview
                        DataTable dtGetEmployeeInterview = new DataTable();
                        dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(employeeInterview);

                        this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                        this.gvEmployeeInterview.DataBind();

                    }
                    //TODO: Show user friendly error here
                    //Log here
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }
                    }
                }

            }

        }
        protected void gvCustomForm_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvCustomForm.DataKeys[rowIndex][2].ToString();
                hdAddForm.Value = harmFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "customcustomer", "Showeditpopup('customcustomer');", true);
                mpeCustomCustomer.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?harmId=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string customCustomerFileId = gvCustomForm.DataKeys[rowIndex][0].ToString();
                string customCustomerFileName = gvCustomForm.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathCustomCustomer + customCustomerFileId);

                if (System.IO.File.Exists(filePath))
                {


                    string strRequest = filePath;

                    if (!string.IsNullOrEmpty(strRequest))
                    {

                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + customCustomerFileName + "\"");
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
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvCustomForm.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_file_id = harmFileId;
                    ComplianceBLL.DeleteHarmCustomCustomerFile(harm);

                    harm.h_harm_id_pk = harmId;
                    DataTable dtGetCustomCustomer = new DataTable();
                    dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);

                    this.gvCustomForm.DataSource = dtGetCustomCustomer;
                    this.gvCustomForm.DataBind();
                }
                catch (Exception ex)
                {

                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempEmployeeInterview(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_EmployeeInterview);
            }

        }
        protected void gvCustomForm_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvPhoto.DataKeys[rowIndex][2].ToString();
                hdPhoto.Value = harmFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photo", "Showeditpopup('photo');", true);
                mpePhoto.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?harmId=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string PhotoFileId = gvPhoto.DataKeys[rowIndex][0].ToString();
                string photoFileName = gvPhoto.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPhoto + PhotoFileId);

                if (System.IO.File.Exists(filePath))
                {


                    string strRequest = filePath;

                    if (!string.IsNullOrEmpty(strRequest))
                    {

                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + photoFileName + "\"");
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
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvPhoto.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_file_id = harmFileId;
                    ComplianceBLL.DeleteHarmPhotoFile(harm);
                    //photo
                    harm.h_harm_id_pk = harmId;
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.GetHarmPhoto(harm);

                    this.gvPhoto.DataSource = dtGetPhoto;
                    this.gvPhoto.DataBind();

                }
                catch (Exception ex)
                {

                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempPhoto(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_Photo);
            }


        }
        protected void gvPhoto_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvSceneSketch.DataKeys[rowIndex][2].ToString();
                hdSceneSketch.Value = harmFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scenesketch", "Showeditpopup('scenesketch');", true);
                mpeSceneSketch.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?harmId=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string SceneSketchFileId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                string sceneSketchFileName = gvSceneSketch.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathSceneSketch + SceneSketchFileId);

                if (System.IO.File.Exists(filePath))
                {


                    string strRequest = filePath;

                    if (!string.IsNullOrEmpty(strRequest))
                    {

                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + sceneSketchFileName + "\"");
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
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvSceneSketch.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_file_id = harmFileId;
                    ComplianceBLL.DeleteHarmSceneSketchFile(harm);

                    harm.h_harm_id_pk = harmId;
                    //SceneSketch

                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);

                    this.gvSceneSketch.DataSource = dtGetSceneSketch;
                    this.gvSceneSketch.DataBind();

                }
                catch (Exception ex)
                {

                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                // DeleteDataToTempSceneSketch(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_SceneSketch);
            }

        }
        protected void gvSceneSketch_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvExtenautingCondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvExtenautingCondition.DataKeys[rowIndex][2].ToString();
                hdExtenautingcond.Value = harmFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "extenuatingcondition", "Showeditpopup('extenuatingcondition');", true);
                mpeExtenautingCondition.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?harmId=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingconditionFileId = gvExtenautingCondition.DataKeys[rowIndex][0].ToString();
                string extenuatingConditionFileName = gvExtenautingCondition.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathExtenuatingcondition + ExtenuatingconditionFileId);

                if (System.IO.File.Exists(filePath))
                {


                    string strRequest = filePath;

                    if (!string.IsNullOrEmpty(strRequest))
                    {

                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + extenuatingConditionFileName + "\"");
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
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvExtenautingCondition.DataKeys[rowIndex][2].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_file_id = harmFileId;
                    ComplianceBLL.DeleteHarmExtenautingConditionFile(harm);

                    //Extenautingcondition
                    harm.h_harm_id_pk = harmId;
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);

                    this.gvExtenautingCondition.DataSource = dtGetExtenautingCondition;
                    this.gvExtenautingCondition.DataBind();

                }
                catch (Exception ex)
                {

                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempExtenautingcondition(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_ExtenuatingCondition);
            }


        }
        protected void gvExtenautingCondition_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvEmployeeInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmFileId = gvEmployeeInterview.DataKeys[rowIndex][4].ToString();
                txtName.Text = gvEmployeeInterview.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvEmployeeInterview.DataKeys[rowIndex][3].ToString();
                hdEmployeeInterview.Value = harmFileId;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "employeeinterview", "Showeditpopup('employeeinterview');", true);
                mpeEmployeeInterview.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?harmId=" + SecurityCenter.EncryptText(caseId));            

            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string EmployeeInterviewFileId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                string employeeInterviewFileName = gvEmployeeInterview.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathEmployeeInterview + EmployeeInterviewFileId);

                if (System.IO.File.Exists(filePath))
                {


                    string strRequest = filePath;

                    if (!string.IsNullOrEmpty(strRequest))
                    {

                        FileInfo file = new System.IO.FileInfo(strRequest);

                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + employeeInterviewFileName + "\"");
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
            else if (e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                string harmFileId = gvEmployeeInterview.DataKeys[rowIndex][4].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_file_id = harmFileId;
                    ComplianceBLL.DeleteHarmEmployeeInterviewFile(harm);

                    harm.h_harm_id_pk = harmId;
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);

                    this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                    this.gvEmployeeInterview.DataBind();
                }
                catch (Exception ex)
                {

                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }
                }
                //DeleteDataToTempEmployeeInterview(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_EmployeeInterview);
            }

        }
        protected void gvEmployeeInterview_RowEditing(object sender, GridViewEditEventArgs e)
        {

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
        protected void btnSave_header_Click(object sender, EventArgs e)
        {

            UpdateHARM();

        }
        private void UpdateHARM()
        {
            try
            {
                ComplianceDAO updateHarm = new ComplianceDAO();
                updateHarm.u_user_id_fk = SessionWrapper.u_userid;
                updateHarm.h_harm_id_pk = harmId;
                // updateHarm.h_harm_number = lblHarmNumber.Text;
                updateHarm.h_case_title = txtCaseTitle.Text;
                updateHarm.h_case_category_fk = ddlCaseCategory.SelectedValue;
                updateHarm.h_status = ddlCasestatus.SelectedValue;
                //updateHarm.h_employee_report_location = txtEmployeeReportLocation.Text;
                updateHarm.h_custom_01 = txtCustom01.Text;
                updateHarm.h_custom_02 = txtCustom02.Text;
                updateHarm.h_custom_03 = txtCustom03.Text;
                updateHarm.h_custom_04 = txtCustom04.Text;
                updateHarm.h_custom_05 = txtCustom05.Text;
                updateHarm.h_custom_06 = txtCustom06.Text;
                updateHarm.h_custom_07 = txtCustom07.Text;
                updateHarm.h_custom_08 = txtCustom08.Text;
                updateHarm.h_custom_09 = txtCustom09.Text;
                updateHarm.h_custom_10 = txtCustom10.Text;
                updateHarm.h_custom_11 = txtCustom11.Text;
                updateHarm.h_custom_12 = txtCustom12.Text;
                updateHarm.h_custom_13 = txtCustom13.Text;
                if (!string.IsNullOrEmpty((string)ViewState["CaseCategory"]))
                {
                    updateHarm.h_harm_number = (string)ViewState["CaseCategory"];
                }
                else
                {
                    updateHarm.h_harm_number = lblHarmNumber.Text;
                }
                int errorMsg = ComplianceBLL.UpdateHarm(updateHarm);

                if (errorMsg == -1)
                {
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                }
                else
                {
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_update_succ_text");
                }


                //Response.Redirect("~/Compliance/HARM/cceharm-01.aspx?harmId=" + SecurityCenter.EncryptText(updateHarm.h_harm_id_pk), false);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSave_Footer_Click(object sender, EventArgs e)
        {
            UpdateHARM();
        }
        protected void btnCancel_footer_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/HARM/ccasharm-01.aspx");

        }
        protected void btnCancel_header_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/HARM/ccasharm-01.aspx");

        }
        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO harmNumber = new ComplianceDAO();
                DataTable dtCaseId = new DataTable();
                harmNumber = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                lblHarmNumber.Text = harmNumber.h_harm_number;
                ViewState["CaseCategory"] = lblHarmNumber.Text;


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }
            }

        }
        protected void gvControlMeasure_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddControlMeasure"))
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);
                ddlAddEditControlMeasure.SelectedIndex = 0;
                gvAddEditControlMeasure.DataSource = null;
                gvAddEditControlMeasure.DataBind();
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                SessionWrapper.temp_h_hazard_id_pk = dlHazard.DataKeys[dle.Item.ItemIndex].ToString();
                hdControlMeasure.Value = "AddControlMeasure";
                mpControlMeasure.Show();
            }
            else if (e.CommandName.Equals("EditControlMeasure"))
            {

                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string strControlMeasureId = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[1].ToString();

                ComplianceDAO harm = new ComplianceDAO();
                try
                {
                    gvAddEditControlMeasure.DataSource = ComplianceBLL.GetControlMeasure(strControlMeasureId);
                    gvAddEditControlMeasure.DataBind();

                    // harm = ComplianceBLL.GetControlMeasure(strControlMeasureId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(GetControlMeasure)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(GetControlMeasure)", ex.Message);
                        }
                    }

                }
                SessionWrapper.temp_h_hazard_id_pk = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[0].ToString();
                hdControlMeasure.Value = strControlMeasureId;
                mpControlMeasure.Show();
                //txtAddControlMeasure.Text = harm.h_control_measure_summary;

                // Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);


            }
            else if (e.CommandName.Equals("RemoveControlMeasure"))
            {

                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string strControlMeasureId = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[1].ToString();

                ComplianceDAO harm = new ComplianceDAO();
                harm.h_hazard_control_meausre_id_pk = strControlMeasureId;
                harm.h_harm_id_pk = harmId;

                ComplianceBLL.DeleteControlMeasure(harm);

                try
                {
                    dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazard.DataBind();
                    ViewState["ControlCategory"] = string.Empty;
                    ViewState["hazard_id_fk"] = string.Empty;
                    dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazardSummary.DataBind();
                }

                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01", ex.Message);
                        }
                    }

                }
                for (int i = 0; i < dlHazard.Items.Count; i++)
                {
                    DataListItem dlItems = dlHazard.Items[i];
                    GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                    if (gvControlmeasure.Rows.Count == 1)
                    {
                        Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                        btnRemoveControlMeasure.Style.Add("display", "none");
                    }

                }


            }

        }
        private void BindControlMeasure(GridView GridView, string h_hazard_id_pk)
        {
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_hazard_id_pk = h_hazard_id_pk;
            DataTable dtControlMeasure = new DataTable();
            dtControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);
            GridView.DataSource = dtControlMeasure;
            GridView.DataBind();
            //AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtAddControlMeasure.Text, SessionWrapper.ControlMeasure);
            //SessionWrapper.ControlMeasure = dtControlMeasure;

        }
        protected void dlHazard_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvControlMeasure = (GridView)e.Item.FindControl("gvControlMeasure");

            BindControlMeasure(gvControlMeasure, dlHazard.DataKeys[e.Item.ItemIndex].ToString());

            Label lblHazard = e.Item.FindControl("lblHazard") as Label;
            int seqHazard = Convert.ToInt32(e.Item.ItemIndex) + 1;
            lblHazard.Text = "<b>" + LocalResources.GetLabel("app_hazard_text") + ": " + "</b>&nbsp;&nbsp&nbsp&nbsp" + lblHazard.Text;

            Label lblHazardNumber = e.Item.FindControl("lblHazardNumber") as Label;
            lblHazardNumber.Text = Convert.ToString(seqHazard);


        }
        protected void gvControlMeasureSummary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName.Equals("AddControlMeasure"))
            //{
            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);
            //    ddlAddEditControlMeasure.SelectedIndex = 0;
            //    gvAddEditControlMeasure.DataSource = null;
            //    gvAddEditControlMeasure.DataBind();
            //    GridView GridView1 = (GridView)sender;
            //    DataListItem dlItem = (DataListItem)GridView1.Parent;
            //    DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
            //    SessionWrapper.temp_h_hazard_id_pk = dlHazard.DataKeys[dle.Item.ItemIndex].ToString();
            //    hdControlMeasure.Value = "AddControlMeasure";
            //    mpControlMeasure.Show();
            //}
            if (e.CommandName.Equals("AddControlMeasure"))
            {

                ddlAddEditControlMeasure.SelectedIndex = 0;
                gvAddEditControlMeasure.DataSource = null;
                gvAddEditControlMeasure.DataBind();
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                SessionWrapper.temp_h_hazard_id_pk = dlHazard.DataKeys[dle.Item.ItemIndex].ToString();
                hdControlMeasure.Value = "AddControlMeasure";
                mpControlMeasure.Show();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);

            }
        }
        protected void btnSaveHazardControlMeausre_Click(object sender, EventArgs e)
        {
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = harmId;
            if (!string.IsNullOrEmpty(hdHazard.Value))
            {

                harm.h_hazard_id_pk = hdHazard.Value;
                harm.h_hazard_description = txtHazardName.Value;
                try
                {
                    ComplianceBLL.UpdateHazard(harm);
                    AddControlMeasure(hdHazard.Value);
                    ComplianceBLL.InsertAllControlMeasure(ConvertDataTableToXml(SessionWrapper.h_control_measure), true, hdHazard.Value, string.Empty);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(update hazard)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(update hazard)", ex.Message);
                        }
                    }

                }
                // EditDataToTempHazard(Convert.ToInt32(hdHazard.Value), txtHazardName.Text, SessionWrapper.Hazard);
                hdHazard.Value = "";

            }
            else
            {
                if (!string.IsNullOrEmpty(txtJobTitle.Text))
                {
                    SessionWrapper.h_job_title = txtJobTitle.Text;
                    lblJobTitle.Text = txtJobTitle.Text; ;
                    txtEditJobTitle.Text = txtJobTitle.Text;
                }

                //ComplianceDAO harm = new ComplianceDAO();
                // harm.h_hazard_id_pk = hdHazard.Value;
                harm.h_hazard_description = txtHazardName.Value;
                harm.h_job_title = SessionWrapper.h_job_title;
                // harm.h_control_measure_summary = txtControlMeasureName.Text;
                SessionWrapper.temp_h_hazard_id_pk = Guid.NewGuid().ToString();
                harm.h_hazard_id_pk = SessionWrapper.temp_h_hazard_id_pk;
                // harm.h_hazard_control_meausre_id_pk = Guid.NewGuid().ToString();

                harm.h_permit_compliance_value = "";
                harm.h_program_compliance_value = "";

                try
                {
                    ComplianceBLL.InsertHazard(harm);
                    AddControlMeasure(SessionWrapper.temp_h_hazard_id_pk);
                    ComplianceBLL.InsertAllControlMeasure(ConvertDataTableToXml(SessionWrapper.h_control_measure), false, SessionWrapper.temp_h_hazard_id_pk, string.Empty);
                    //ComplianceBLL.InsertControlMeasure(harm);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(insert hazard and control measure)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(insert hazard and control measure)", ex.Message);
                        }
                    }

                }

                // AddDataToTempHazard(SessionWrapper.temp_h_hazard_id_pk, txtHazardName.Text, SessionWrapper.Hazard);
                // AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtControlMeasureName.Text, SessionWrapper.ControlMeasure);
            }


            try
            {
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                dlHazard.DataBind();
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                dlHazardSummary.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }

            }

            txtHazardName.Value = "";

            for (int i = 0; i < dlHazard.Items.Count; i++)
            {
                DataListItem dlItem = dlHazard.Items[i];
                GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                if (gvControlmeasure.Rows.Count == 1)
                {
                    Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                    btnRemoveControlMeasure.Style.Add("display", "none");
                }

            }

        }
        private void AddControlMeasure(string hazard_id_pk)
        {
            try
            {
                ComplianceDAO harm = new ComplianceDAO();
                SessionWrapper.h_control_measure.Clear();
                foreach (GridViewRow grdRow in gvNewControlMeasure.Rows)
                {
                    Label lblControlMeasureText = default(Label);
                    lblControlMeasureText = (Label)grdRow.Cells[0].FindControl("lblControlMeasureText");
                    HiddenField hdnControlMeasureValue = default(HiddenField);
                    hdnControlMeasureValue = (HiddenField)grdRow.Cells[0].FindControl("hdnControlMeasureValue");
                    TextBox txtAddControlMeasure = default(TextBox);
                    txtAddControlMeasure = (TextBox)grdRow.Cells[0].FindControl("txtAddControlMeasure");
                    // harm.h_control_measure_summary = txtAddControlMeasure.Text;
                    // harm.h_hazard_id_pk =hazard_id_pk;
                    // harm.h_hazard_control_meausre_id_pk = Guid.NewGuid().ToString();
                    // harm.h_control_measure_id_fk = hdnControlMeasureValue.Value;
                    // harm.h_permit_compliance_value = "";
                    // harm.h_program_compliance_value = "";
                    //ComplianceBLL.InsertControlMeasure(harm);
                    AddDataToTempControlMeasure(hazard_id_pk, txtAddControlMeasure.Text, hdnControlMeasureValue.Value, lblControlMeasureText.Text, SessionWrapper.h_control_measure);

                }
                var rows = SessionWrapper.h_control_measure.Select("h_control_measure_summary= '" + string.Empty + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.h_control_measure.AcceptChanges();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01(AddControlMeasure function)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01(AddControlMeasure function)", ex.Message);
                    }
                }
            }
        }
        protected void btnAddEditControlMeasure_Click(object sender, EventArgs e)
        {
            cvOneAddEditControlMeasure.Style.Add("display", "none");
            cvAddEditControlMeasure.Style.Add("display", "block");
            cvAddEditControlMeasure.Enabled = true;

            AddEditControlMeasure(SessionWrapper.temp_h_hazard_id_pk);
            AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlAddEditControlMeasure.SelectedValue, ddlAddEditControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
            gvAddEditControlMeasure.DataSource = SessionWrapper.h_control_measure;
            gvAddEditControlMeasure.DataBind();
            mpControlMeasure.Show();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);
        }
        protected void btnSaveControlMeausre_Click(object sender, EventArgs e)
        {
            ComplianceDAO harm = new ComplianceDAO();
            if (hdControlMeasure.Value == "AddControlMeasure")
            {
                //harm.h_hazard_control_meausre_id_pk = Guid.NewGuid().ToString();
                //harm.h_hazard_id_pk = SessionWrapper.temp_h_hazard_id_pk;
                //harm.h_control_measure_summary = txtAddControlMeasure.Text;
                AddEditControlMeasure(SessionWrapper.temp_h_hazard_id_pk);
                try
                {
                    ComplianceBLL.InsertAllControlMeasure(ConvertDataTableToXml(SessionWrapper.h_control_measure), false, SessionWrapper.temp_h_hazard_id_pk, string.Empty);
                    //ComplianceBLL.InsertControlMeasure(harm);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(insert control measure)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(insert control measure)", ex.Message);
                        }
                    }

                }
                // AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtAddControlMeasure.Text, SessionWrapper.ControlMeasure);


            }
            else
            {
                harm.h_hazard_control_meausre_id_pk = hdControlMeasure.Value;
                // harm.h_control_measure_summary = txtAddControlMeasure.Text;

                AddEditControlMeasure(SessionWrapper.temp_h_hazard_id_pk);
                try
                {

                    ComplianceBLL.InsertAllControlMeasure(ConvertDataTableToXml(SessionWrapper.h_control_measure), true, SessionWrapper.temp_h_hazard_id_pk, hdControlMeasure.Value);
                    //ComplianceBLL.UpdateControlMeasure(harm);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(update control measure)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(update control measure)", ex.Message);
                        }
                    }

                }
                //EditDataToTempControlMeasure(Convert.ToInt32(hdControlMeasure.Value), txtAddControlMeasure.Text, SessionWrapper.ControlMeasure);
                hdControlMeasure.Value = "";
                //DataTable dtFilterControlMeasure = new DataTable();
                //dtFilterControlMeasure = SessionWrapper.ControlMeasure;
                ////DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
                ////dvControlMeasure.RowFilter = "h_hazard_control_meausre_id_pk= '" + SessionWrapper.temp_h_control_measure_id_pk + "'";
                ////dvControlMeasure
                //var rows = dtFilterControlMeasure.Select("h_hazard_control_meausre_id_pk= '" + SessionWrapper.temp_h_control_measure_id_pk + "'");
                //foreach (var row in rows)
                //    row.Delete();

                //DataTable dt = dtFilterControlMeasure;


            }
            harm.h_harm_id_pk = harmId;
            try
            {
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                dlHazard.DataBind();
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                dlHazardSummary.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01 (load hazard save control measure hit button)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01 (load hazard save control measure hit button)", ex.Message);
                    }
                }

            }
            for (int i = 0; i < dlHazard.Items.Count; i++)
            {
                DataListItem dlItem = dlHazard.Items[i];
                GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                if (gvControlmeasure.Rows.Count == 1)
                {
                    Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                    btnRemoveControlMeasure.Style.Add("display", "none");
                }

            }

            // txtAddControlMeasure.Text = "";

        }
        protected void gvControlMeasure_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                Label lblControlMeasure = (Label)e.Row.FindControl("lblControlMeasure");
                Label lblControlCategory = (Label)e.Row.FindControl("lblControlCategory");
                string hazard_id_fk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                int seqHazard = dle.Item.ItemIndex + 1;
                int seqContrlMeasure = e.Row.RowIndex + 1;
                string seq = seqHazard + "." + seqContrlMeasure;

                string strval = ((Label)(lblControlCategory)).Text;
                string title = (string)ViewState["ControlCategory"];
                string strHazardId = hazard_id_fk;
                string strhazard_id_fk = (string)ViewState["hazard_id_fk"];

                if (title == strval && strHazardId == strhazard_id_fk)
                {
                    lblControlCategory.Visible = false;
                    lblControlCategory.Text = string.Empty;

                }
                else
                {
                    title = strval;
                    strhazard_id_fk = strHazardId;
                    ViewState["ControlCategory"] = title;
                    ViewState["hazard_id_fk"] = strhazard_id_fk;
                    lblControlCategory.Visible = true;
                    lblControlCategory.Text = title;
                }
                lblControlMeasure.Text = seq + ":&nbsp;&nbsp&nbsp&nbsp" + lblControlMeasure.Text;



            }
        }
        private void AddDataToTempControlMeasure(string h_hazard_id_fk, string h_control_measure_summary, string h_control_measure_id_fk, string h_control_measure_text, DataTable dtTempControlMeasure)
        {
            DataRow row;

            row = dtTempControlMeasure.NewRow();
            row["h_hazard_control_meausre_id_pk"] = Guid.NewGuid().ToString();
            row["h_hazard_id_fk"] = h_hazard_id_fk;
            row["h_control_measure_summary"] = h_control_measure_summary;
            row["h_control_measure_id_fk"] = h_control_measure_id_fk;
            row["h_control_measure_text"] = h_control_measure_text;


            dtTempControlMeasure.Rows.Add(row);
        }
        protected void dlHazardSummary_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView gvControlMeasureSummary = (GridView)e.Item.FindControl("gvControlMeasureSummary");

            BindControlMeasure(gvControlMeasureSummary, dlHazardSummary.DataKeys[e.Item.ItemIndex].ToString());
            Label lblHazard = e.Item.FindControl("lblHazard") as Label;
            int seqHazard = Convert.ToInt32(e.Item.ItemIndex) + 1;
            lblHazard.Text = "<b>" + LocalResources.GetLabel("app_hazard_text") + ":" + "</b>&nbsp;&nbsp&nbsp&nbsp" + lblHazard.Text;

            Label lblHazardNumber = e.Item.FindControl("lblHazardNumber") as Label;
            lblHazardNumber.Text = Convert.ToString(seqHazard);

            if (e.Item.ItemIndex == 0)
            {
                divEmptyRow.Style.Add("display", "none");
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlPermitCompliance = (DropDownList)e.Item.FindControl("ddlPermitCompliance");
                HiddenField hdnPermitCompliance = (HiddenField)e.Item.FindControl("hdnPermitCompliance");

                if (ddlPermitCompliance != null)
                {
                    ddlPermitCompliance.DataSource = ComplianceBLL.GetPermitCompliance(SessionWrapper.CultureName,"cceharm-01");
                    ddlPermitCompliance.DataBind();
                }
                ddlPermitCompliance.SelectedValue = hdnPermitCompliance.Value;

                if (hdnPermitCompliance.Value == "")
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_permit_compliance_value = ddlPermitCompliance.SelectedValue;
                    harm.h_hazard_id_pk = dlHazardSummary.DataKeys[e.Item.ItemIndex].ToString();

                    try
                    {
                        ComplianceBLL.UpdatePermitCompliance(harm);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }

                    }
                }

                DropDownList ddlPrgCompliance = (DropDownList)e.Item.FindControl("ddlPrgCompliance");
                HiddenField hdnPrgCompliance = (HiddenField)e.Item.FindControl("hdnPrgCompliance");

                if (ddlPrgCompliance != null)
                {
                    ddlPrgCompliance.DataSource = ComplianceBLL.GetProgramCompliance(SessionWrapper.CultureName,"cceharm-01");
                    ddlPrgCompliance.DataBind();
                }
                ddlPrgCompliance.SelectedValue = hdnPrgCompliance.Value;

                if (hdnPrgCompliance.Value == "")
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_program_compliance_value = ddlPrgCompliance.SelectedValue;
                    harm.h_hazard_id_pk = dlHazardSummary.DataKeys[e.Item.ItemIndex].ToString();
                    try
                    {
                        ComplianceBLL.UpdateProgramCompliance(harm);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01", ex.Message);
                            }
                        }

                    }
                }

            }
        }
        protected void btnRemoveJobTitle_Click(object sender, EventArgs e)
        {
            lblJobTitle.Text = string.Empty;
            SessionWrapper.h_job_title = string.Empty;
            divAddJobTitle.Style.Add("display", "none");
            SessionWrapper.h_control_measure.Clear();
            SessionWrapper.temp_h_hazard_id_pk = string.Empty;
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = harmId;
            ComplianceBLL.DeleteAddInfoHazardControlMeasure(harm);
            dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
            dlHazard.DataBind();
            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;
            dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
            dlHazardSummary.DataBind();
            divEmptyRow.Style.Add("display", "block");

        }
        protected void btnNewControlMeasure_Click(object sender, EventArgs e)
        {
            cvOneControlMeasure.Style.Add("display", "none");
            cvControlMeasure.Style.Add("display", "block");
            cvControlMeasure.Enabled = true;
            AddControlMeasure(SessionWrapper.temp_h_hazard_id_pk);
            AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlControlMeasure.SelectedValue, ddlControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
            gvNewControlMeasure.DataSource = SessionWrapper.h_control_measure;
            gvNewControlMeasure.DataBind();
            mpHazard.Show();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "HazardNew", "ShowDialog(true);", true);
        }
        protected void btnAddHazard_Click(object sender, EventArgs e)
        {
            txtJobTitle.Text = string.Empty;
            txtEditJobTitle.Text = string.Empty;
            SessionWrapper.temp_h_hazard_id_pk = Guid.NewGuid().ToString();
            ddlControlMeasure.SelectedIndex = 0;
            gvNewControlMeasure.DataSource = null;
            gvNewControlMeasure.DataBind();
            mpHazard.Show();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "HazardNew", "ShowDialog(true);", true);
        }
        protected void dlHazard_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ComplianceDAO harm = new ComplianceDAO();
            if (e.CommandName.Equals("EditHazard"))
            {
                ddlControlMeasure.SelectedIndex = 0;
                string strHazardId = dlHazard.DataKeys[e.Item.ItemIndex].ToString();
                try
                {
                    harm = ComplianceBLL.GetHazard(strHazardId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01 (edit hazard)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01 (edit hazard)", ex.Message);
                        }
                    }

                }
                // DataTable dtHazard = SessionWrapper.Hazard;
                // var rows = dtHazard.Select("h_hazard_id_pk= '" + strHazardId + "'");
                // var indexofRow = dtHazard.Rows.IndexOf(rows[0]);
                //txtHazardName.Text = rows[0]["h_hazard_description"].ToString();
                txtHazardName.Value = harm.h_hazard_description;
                hdHazard.Value = strHazardId;
                harm.h_hazard_id_pk = strHazardId;

                gvNewControlMeasure.DataSource = ComplianceBLL.GetAllControlMeasure(harm);
                gvNewControlMeasure.DataBind();
                mpHazard.Show();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Hazard", "showHazardDialog();", true);
            }
            else if (e.CommandName.Equals("RemoveHazard"))
            {
                string strHazardId = dlHazard.DataKeys[e.Item.ItemIndex].ToString();
                harm.h_hazard_id_pk = strHazardId;
                try
                {
                    ComplianceBLL.DeleteHazardControlMeasure(harm);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01 (delete hazard)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01 (delete hazard)", ex.Message);
                        }
                    }

                }
                harm.h_harm_id_pk = harmId;
                try
                {
                    dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazard.DataBind();
                    ViewState["ControlCategory"] = string.Empty;
                    ViewState["hazard_id_fk"] = string.Empty;
                    dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazardSummary.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01 (load hazard save control measure hit button)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01 (load hazard save control measure hit button)", ex.Message);
                        }
                    }

                }

                for (int i = 0; i < dlHazard.Items.Count; i++)
                {
                    DataListItem dlItems = dlHazard.Items[i];
                    GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                    if (gvControlmeasure.Rows.Count == 1)
                    {
                        Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                        btnRemoveControlMeasure.Style.Add("display", "none");
                    }

                }
            }
            if (dlHazardSummary.Items.Count == 0)
            {
                divEmptyRow.Style.Add("display", "block");
            }

        }
        protected void gvControlMeasureSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Button btnAddControlMeasure = (Button)e.Row.FindControl("btnAddControlMeasure");
            //if (e.Row.RowIndex == 0)
            //{
            //    btnAddControlMeasure.Style.Add("display", "block");

            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                Label lblControlMeasure = (Label)e.Row.FindControl("lblControlMeasure");
                int seqHazard = dle.Item.ItemIndex + 1;
                int seqContrlMeasure = e.Row.RowIndex + 1;
                string seq = seqHazard + "." + seqContrlMeasure;


                Label lblControlCategory = (Label)e.Row.FindControl("lblControlCategory");
                string hazard_id_fk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                string strval = ((Label)(lblControlCategory)).Text;
                string title = (string)ViewState["ControlCategory"];
                string strHazardId = hazard_id_fk;
                string strhazard_id_fk = (string)ViewState["hazard_id_fk"];
                if (title == strval && strHazardId == strhazard_id_fk)
                {
                    lblControlCategory.Visible = false;
                    lblControlCategory.Text = string.Empty;

                }
                else
                {
                    title = strval;
                    strhazard_id_fk = strHazardId;
                    ViewState["ControlCategory"] = title;
                    ViewState["hazard_id_fk"] = strhazard_id_fk;
                    lblControlCategory.Visible = true;
                    lblControlCategory.Text = title;
                }


                lblControlMeasure.Text = seq + "&nbsp;&nbsp&nbsp&nbsp" + lblControlMeasure.Text;



            }

        }
        protected void btnReset_Footer_Click(object sender, EventArgs e)
        {

            reset();



        }
        protected void btnReset_Header_Click(object sender, EventArgs e)
        {

            reset();

        }
        private void reset()
        {

            success_msg.Style.Add("display", "none");
            error_msg.Style.Add("display", "none");

            SessionWrapper.temp_h_control_measure_id_pk = "";
            SessionWrapper.temp_h_hazard_id_pk = "";

            hdAddForm.Value = "";
            hdControlMeasure.Value = "";
            hdEmployeeInterview.Value = "";
            hdExtenautingcond.Value = "";
            hdHazard.Value = "";
            hdPhoto.Value = "";
            hdSceneSketch.Value = "";
            PopulateHarm(harmId);
            try
            {
                ComplianceDAO resetHarm = new ComplianceDAO();
                resetHarm.h_harm_id_pk = harmId;
                ComplianceBLL.DeleteAddInfoHazardControlMeasure(resetHarm);

                //insert hazard

                foreach (DataRow dr in SessionWrapper.Hazard.Rows)
                {
                    resetHarm.h_hazard_id_pk = dr["h_hazard_id_pk"].ToString();
                    resetHarm.h_hazard_description = dr["h_hazard_description"].ToString();
                    resetHarm.h_program_compliance_value = dr["h_program_compliance_value"].ToString();
                    resetHarm.h_permit_compliance_value = dr["h_permit_compliance_value"].ToString();
                    resetHarm.h_job_title = dr["h_job_title"].ToString();
                    resetHarm.h_harm_id_pk = harmId;
                    ComplianceBLL.InsertHazard(resetHarm);

                    DataTable dtFilterControlMeasure = new DataTable();
                    dtFilterControlMeasure = SessionWrapper.ControlMeasure;
                    DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
                    dvControlMeasure.RowFilter = "h_hazard_id_fk= '" + resetHarm.h_hazard_id_pk + "'";
                    foreach (DataRowView drView in dvControlMeasure)
                    {
                        resetHarm.h_hazard_control_meausre_id_pk = drView["h_hazard_control_meausre_id_pk"].ToString();
                        resetHarm.h_control_measure_summary = drView["h_control_measure_summary"].ToString();
                        resetHarm.h_control_measure_id_fk = drView["h_control_measure_id_fk"].ToString();
                        resetHarm.h_hazard_id_fk = resetHarm.h_hazard_id_pk;
                        ComplianceBLL.InsertControlMeasure(resetHarm);

                    }


                }

                //Custom Customer
                foreach (DataRow dr in SessionWrapper.session_Custom_Customer.Rows)
                {

                    resetHarm.h_file_guid = dr["h_file_guid"].ToString();
                    resetHarm.h_file_name = dr["h_file_name"].ToString();

                    ComplianceBLL.InserHarmCustomCustomer(resetHarm);


                }

                //Photo


                foreach (DataRow dr in SessionWrapper.session_Photo.Rows)
                {

                    resetHarm.h_file_guid = dr["h_file_guid"].ToString();
                    resetHarm.h_file_name = dr["h_file_name"].ToString();

                    ComplianceBLL.InsertHarmPhoto(resetHarm);


                }
                //SceneSketch

                foreach (DataRow dr in SessionWrapper.session_SceneSketch.Rows)
                {

                    resetHarm.h_file_guid = dr["h_file_guid"].ToString();
                    resetHarm.h_file_name = dr["h_file_name"].ToString();

                    ComplianceBLL.InsertHarmSceneSketch(resetHarm);


                }



                //ExtenuatingCondition
                foreach (DataRow dr in SessionWrapper.session_ExtenuatingCondition.Rows)
                {

                    resetHarm.h_file_guid = dr["h_file_guid"].ToString();
                    resetHarm.h_file_name = dr["h_file_name"].ToString();

                    ComplianceBLL.InsertHarmExtenuatingCondition(resetHarm);


                }

                //EmployeeInterview

                foreach (DataRow dr in SessionWrapper.session_EmployeeInterview.Rows)
                {

                    resetHarm.h_file_guid = dr["h_file_guid"].ToString();
                    resetHarm.h_file_name = dr["h_file_name"].ToString();

                    ComplianceBLL.InsertHarmEmployeeInterview(resetHarm);


                }

                ComplianceDAO harm = new ComplianceDAO();
                harm.h_harm_id_pk = harmId;

                //Hazard and control measure
                DataTable dtHazard = new DataTable();
                try
                {
                    dlHazard.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazard.DataBind();

                    dlHazardSummary.DataSource = ComplianceBLL.GetAllHazard(harm);
                    dlHazardSummary.DataBind();

                    //SessionWrapper.Hazard = ComplianceBLL.GetAllHazard(harm);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message);
                        }
                    }

                }

                //End

                //



                DataTable dtGetHarmCustomCustomer = new DataTable();
                dtGetHarmCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);

                this.gvCustomForm.DataSource = dtGetHarmCustomCustomer;
                this.gvCustomForm.DataBind();

                //photo

                DataTable dtGetHarmPhoto = new DataTable();
                dtGetHarmPhoto = ComplianceBLL.GetHarmPhoto(harm);

                this.gvPhoto.DataSource = dtGetHarmPhoto;
                this.gvPhoto.DataBind();



                //SceneSketch

                DataTable dtGetHarmSceneSketch = new DataTable();
                dtGetHarmSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);

                this.gvSceneSketch.DataSource = dtGetHarmSceneSketch;
                this.gvSceneSketch.DataBind();

                //Extenautingcondition

                DataTable dtGetHarmExtenautingCondition = new DataTable();
                dtGetHarmExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);

                this.gvExtenautingCondition.DataSource = dtGetHarmExtenautingCondition;
                this.gvExtenautingCondition.DataBind();

                //EmployeeInterview
                DataTable dtGetHarmEmployeeInterview = new DataTable();
                dtGetHarmEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
                this.gvEmployeeInterview.DataSource = dtGetHarmEmployeeInterview;
                this.gvEmployeeInterview.DataBind();

                SessionWrapper.session_Custom_Customer = dtGetHarmCustomCustomer;
                SessionWrapper.session_Photo = dtGetHarmPhoto;

                SessionWrapper.session_SceneSketch = dtGetHarmSceneSketch;

                SessionWrapper.session_ExtenuatingCondition = dtGetHarmExtenautingCondition;
                SessionWrapper.session_EmployeeInterview = dtGetHarmEmployeeInterview;

                //Response.Redirect("~/Compliance/HARM/cceharm-01.aspx?Edit=" + SecurityCenter.EncryptText(harmId), false);


                for (int i = 0; i < dlHazard.Items.Count; i++)
                {
                    DataListItem dlItem = dlHazard.Items[i];
                    GridView gvControlmeasure = (GridView)dlHazard.Items[i].FindControl("gvControlMeasure");

                    if (gvControlmeasure.Rows.Count == 1)
                    {
                        Button btnRemoveControlMeasure = (Button)gvControlmeasure.Rows[0].FindControl("btnRemoveControlMeasure");
                        btnRemoveControlMeasure.Style.Add("display", "none");
                    }

                }

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01 (edit hazard)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01 (edit hazard)", ex.Message);
                    }
                }

            }
            Response.Redirect(Request.RawUrl);
          
        }
        private DataTable tempControlMeasure()
        {
            DataTable dtTempControlMeasure = new DataTable();

            DataColumn dtTempControlMeasureColumn;




            dtTempControlMeasureColumn = new DataColumn();
            dtTempControlMeasureColumn.DataType = Type.GetType("System.String");
            dtTempControlMeasureColumn.ColumnName = "h_hazard_control_meausre_id_pk";
            dtTempControlMeasure.Columns.Add(dtTempControlMeasureColumn);

            dtTempControlMeasureColumn = new DataColumn();
            dtTempControlMeasureColumn.DataType = Type.GetType("System.String");
            dtTempControlMeasureColumn.ColumnName = "h_hazard_id_fk";
            dtTempControlMeasure.Columns.Add(dtTempControlMeasureColumn);



            dtTempControlMeasureColumn = new DataColumn();
            dtTempControlMeasureColumn.DataType = Type.GetType("System.String");
            dtTempControlMeasureColumn.ColumnName = "h_control_measure_summary";
            dtTempControlMeasure.Columns.Add(dtTempControlMeasureColumn);

            return dtTempControlMeasure;
        }
        private void EditDataToProgramCompliance(int rowIndex, string h_program_compliance_value, DataTable dtTempHazard)
        {

            dtTempHazard.Rows[rowIndex]["h_program_compliance_value"] = h_program_compliance_value;
            dtTempHazard.AcceptChanges();

        }
        private void EditDataToPermitCompliance(int rowIndex, string h_permit_compliance_value, DataTable dtTempHazard)
        {
            dtTempHazard.Rows[rowIndex]["h_permit_compliance_value"] = h_permit_compliance_value;
            dtTempHazard.AcceptChanges();

        }
        protected void ddlPrgCompliance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlPrgCompliance = (DropDownList)sender;
            DataListItem item = (DataListItem)ddlPrgCompliance.NamingContainer;

            int strHazardIndex = item.ItemIndex;
            string strHazardId = dlHazardSummary.DataKeys[strHazardIndex].ToString();

            ComplianceDAO harm = new ComplianceDAO();
            harm.h_program_compliance_value = ddlPrgCompliance.SelectedValue;
            harm.h_hazard_id_pk = strHazardId;

            try
            {
                ComplianceBLL.UpdateProgramCompliance(harm);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }

            }

        }
        protected void ddlPermitCompliance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlPermitCompliance = (DropDownList)sender;
            DataListItem item = (DataListItem)ddlPermitCompliance.NamingContainer;

            int strHazardIndex = item.ItemIndex;
            string strHazardId = dlHazardSummary.DataKeys[strHazardIndex].ToString();

            ComplianceDAO harm = new ComplianceDAO();
            harm.h_permit_compliance_value = ddlPermitCompliance.SelectedValue;
            harm.h_hazard_id_pk = strHazardId;

            try
            {
                ComplianceBLL.UpdatePermitCompliance(harm);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01", ex.Message);
                    }
                }

            }

        }
        ///<summary>
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        private void AddEditControlMeasure(string hazard_id)
        {
            SessionWrapper.h_control_measure = null;
            SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();
            foreach (GridViewRow grdRow in gvAddEditControlMeasure.Rows)
            {
                Label lblControlMeasureText = default(Label);
                lblControlMeasureText = (Label)grdRow.Cells[0].FindControl("lblControlMeasureText");
                HiddenField hdnControlMeasureValue = default(HiddenField);
                hdnControlMeasureValue = (HiddenField)grdRow.Cells[0].FindControl("hdnControlMeasureValue");
                TextBox txtAddControlMeasure = default(TextBox);
                txtAddControlMeasure = (TextBox)grdRow.Cells[0].FindControl("txtAddControlMeasure");
                //AddDataToAddNewControlMeasure(hdnControlMeasureValue.Value, lblControlMeasureText.Text, txtAddControlMeasure.Text, SessionWrapper.h_control_measure);
                AddDataToTempControlMeasure(hazard_id, txtAddControlMeasure.Text, hdnControlMeasureValue.Value, lblControlMeasureText.Text, SessionWrapper.h_control_measure);
            }
            var rows = SessionWrapper.h_control_measure.Select("h_control_measure_summary= '" + string.Empty + "'");
            foreach (var row in rows)
                row.Delete();
            SessionWrapper.h_control_measure.AcceptChanges();
        }
        /// <summary>
        /// Delete control measure
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteControlmeasure(string parm)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.h_control_measure.Select("h_hazard_control_meausre_id_pk= '" + parm.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.h_control_measure.AcceptChanges();
                
               
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cccharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cccharm-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSaveJobTitle_Click(object sender, EventArgs e)
        {
            SessionWrapper.h_job_title = txtEditJobTitle.Text;
            lblJobTitle.Text = SessionWrapper.h_job_title;
            ComplianceDAO harm = new ComplianceDAO();
            harm.h_harm_id_pk = harmId;
            harm.h_job_title = SessionWrapper.h_job_title;
            try
            {
                ComplianceBLL.UpadateHARMJobTitle(harm);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cceharm-01 (update job title)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cceharm-01 (update job title)", ex.Message);
                    }
                }
            }
        }
        private void ClearHarmSession()
        {
            SessionWrapper.session_Custom_Customer = null;
            SessionWrapper.session_witness = null;
            SessionWrapper.session_EmployeeInterview = null;
            SessionWrapper.session_ExtenuatingCondition = null;
            SessionWrapper.session_Photo = null;
            SessionWrapper.session_PoliceReport = null;
            SessionWrapper.session_SceneSketch = null;

            SessionWrapper.temp_h_control_measure_id_pk = "";
            SessionWrapper.temp_h_hazard_id_pk = "";
            SessionWrapper.Hazard = null;
            SessionWrapper.ControlMeasure = null;
            SessionWrapper.h_control_measure.Clear();
            SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();
            SessionWrapper.ControlMeasure = TempHarmDataTable.tempControlMeasure();
        }
        protected void gvNewControlMeasure_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Remove"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string controlMeasureID = gvNewControlMeasure.DataKeys[rowIndex][0].ToString();
                var rows = SessionWrapper.h_control_measure.Select("h_hazard_control_meausre_id_pk= '" + controlMeasureID + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.h_control_measure.AcceptChanges();

                gvNewControlMeasure.DataSource = SessionWrapper.h_control_measure;
                gvNewControlMeasure.DataBind();
            }
        }
    }
}

