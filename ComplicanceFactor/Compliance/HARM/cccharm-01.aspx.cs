using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Globalization;
using System.Threading;
using ComplicanceFactor.Compliance.HARM;
using System.Collections;

namespace ComplicanceFactor.Compliance
{
    public partial class cccharm_01 : BasePage
    {
        private string harmId;
        #region "Private Member Variables"

        private string _pathCustomCustomer = "~/Compliance/HARM/Upload/CustomCustomer/";
        private string _pathPhoto = "~/Compliance/HARM/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/HARM/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/HARM/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/HARM/Upload/EmployeeInterview/";

        #endregion
        private DataTable dtTempCustomCustomer = null;
        private DataTable dtTempPhoto = null;
        private DataTable dtTempSceneSketch = null;
        private DataTable dtTempExtenautingcond = null;
        private DataTable dtTempEmployeeInterview = null;
        private DataTable dtTempHazard = null;
        private DataTable dtTempControlMeasure = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Compliance/HARM/ccasharm-01.aspx>" + LocalResources.GetLabel("app_harm_text") + "</a>&nbsp;> " + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_harm_text") + "</a>";
           // txtEditJobTitle.Text = SessionWrapper.h_job_title;
            if (!IsPostBack)
            {
                try
                {
                    ddlCaseCategory.DataSource = ComplianceBLL.GetHarmCategory(SessionWrapper.CultureName,"cccharm-01");
                    ddlCaseCategory.DataBind();
                    ddlCasestatus.DataSource = ComplianceBLL.GetHarmStatus(SessionWrapper.CultureName, "cccharm-01");
                    ddlCasestatus.DataBind();
                    ddlCasestatus.SelectedValue = "app_ddl_approved_text";
                    ddlControlMeasure.DataSource = ComplianceBLL.GetControlMeasure(SessionWrapper.CultureName, "cccharm-01");
                    ddlControlMeasure.DataBind();
                    //Add and edit control measure
                    ddlAddEditControlMeasure.DataSource = ComplianceBLL.GetControlMeasure(SessionWrapper.CultureName, "cccharm-01");
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
                            Logger.WriteToErrorLog("cccharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cccharm-01", ex.Message);
                        }
                    }
                }

                //clear session
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
                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
                    //DateTime currentDt = DateTime.Now.ToUniversalTime();//Current Converted to UTC
                    //currentDt = DateTime.SpecifyKind(currentDt, DateTimeKind.Utc);//Say to runtime that this date is UTC date.
                    SessionWrapper.HarmCaseDate = miris.c_temp_case_date;
                    lblCaseDate.Text = SessionWrapper.HarmCaseDate.ToString("MM/dd/yyyy hh:mm tt");
                }
                catch (Exception ex)
                {
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
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    //TODO: 
                    harmId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);
                    PopulateHarm(harmId);
                    ComplianceDAO harm = new ComplianceDAO();
                    try
                    {
                        DataTable dtHarmNumber = new DataTable();
                        harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                        lblHarmNumber.Text = harm.h_harm_number;
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
                    harm.h_harm_id_pk = harmId;
                    //Hazard and control measure
                    try
                    {
                        SessionWrapper.Hazard = tempHazard();
                        SessionWrapper.ControlMeasure = TempHarmDataTable.tempControlMeasure();
                        DataTable dtCopyHazard = ComplianceBLL.GetAllHazard(harm);
                        if (dtCopyHazard.Rows.Count > 0)
                        {
                            lblJobTitle.Text = dtCopyHazard.Rows[0]["h_job_title"].ToString();
                            txtEditJobTitle.Text = dtCopyHazard.Rows[0]["h_job_title"].ToString();
                        }
                        foreach (DataRow drCopyHazard in dtCopyHazard.Rows)
                        {
                            string hazardId = Guid.NewGuid().ToString();
                            AddDataToTempHazard(hazardId, drCopyHazard["h_hazard_description"].ToString(), drCopyHazard["h_program_compliance_value"].ToString(), drCopyHazard["h_permit_compliance_value"].ToString(), SessionWrapper.Hazard);

                            harm.h_hazard_id_pk = drCopyHazard["h_hazard_id_pk"].ToString();
                            //Get control measure
                            DataTable dtCopyControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);

                            foreach (DataRow drCopyControlmeasure in dtCopyControlMeasure.Rows)
                            {
                                AddDataToTempControlMeasure(hazardId, drCopyControlmeasure["h_control_measure_summary"].ToString(), drCopyControlmeasure["h_control_measure_id_fk"].ToString(), drCopyControlmeasure["h_control_measure_text"].ToString(), SessionWrapper.ControlMeasure);
                            }
                        }
                        dlHazard.DataSource = SessionWrapper.Hazard;
                        dlHazard.DataBind();
                        ViewState["ControlCategory"] = string.Empty;
                        ViewState["hazard_id_fk"] = string.Empty;
                        dlHazardSummary.DataSource = SessionWrapper.Hazard;
                        dlHazardSummary.DataBind();
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
                                Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cceharm-01(GetAllHazard-Load)", ex.Message);
                            }
                        }
                    }
                    //Custom customer
                    DataTable dtGetCustomCustomer = new DataTable();
                    dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
                    dtTempCustomCustomer = new DataTable();
                    dtTempCustomCustomer = dtGetCustomCustomer;
                    SessionWrapper.session_Custom_Customer = dtTempCustomCustomer;
                    this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
                    this.gvCustomForm.DataBind();
                    //photo
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.GetHarmPhoto(harm);
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = dtGetPhoto;
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();
                    //SceneSketch
                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = dtGetSceneSketch;
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();
                    //Extenautingcondition
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = dtGetExtenautingCondition;
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenautingCondition.DataBind();
                    //EmployeeInterview
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = dtGetEmployeeInterview;
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                    this.gvEmployeeInterview.DataBind();
                }
                else
                {
                    lblHarmNumber.Text = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["category"]);
                    txtCaseTitle.Text = SecurityCenter.DecryptText(Request.QueryString["title"]);
                    //witenss
                    dtTempCustomCustomer = new DataTable();
                    dtTempCustomCustomer = tempCustomCustomer();
                    SessionWrapper.session_Custom_Customer = dtTempCustomCustomer;
                    this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
                    this.gvCustomForm.DataBind();
                    //photo
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = tempPhoto();
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();
                    //SceneSketch
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = tempSceneSketch();
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();
                    //ExtenuatingCondition
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = tempExtenautingcondition();
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenautingCondition.DataBind();
                    //EmployeeInterview
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = tempEmployeeInterview();
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                    this.gvEmployeeInterview.DataBind();
                    //Hazard
                    dtTempHazard = new DataTable();
                    dtTempHazard = tempHazard();
                    SessionWrapper.Hazard = dtTempHazard;
                    //control measure
                    dtTempControlMeasure = new DataTable();
                    dtTempControlMeasure = TempHarmDataTable.tempControlMeasure();
                    SessionWrapper.ControlMeasure = dtTempControlMeasure;
                    this.dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
                    this.dlHazard.DataBind();
                }
            }
        }


        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO harm = new ComplianceDAO();
                DataTable dtHarmNumber = new DataTable();
                harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                lblHarmNumber.Text = harm.h_harm_number;
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
                    if (!string.IsNullOrEmpty(hdAddForm.Value))
                    {
                        EditDataToTempCustomCustomer(Convert.ToInt32(hdAddForm.Value), h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_Custom_Customer);
                        hdAddForm.Value = "";
                    }
                    else
                    {
                        AddDataToTempCustomCustomer(h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_Custom_Customer);
                    }
                }
            }
            this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
            this.gvCustomForm.DataBind();
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
                    if (!string.IsNullOrEmpty(hdPhoto.Value))
                    {
                        EditDataToTempPhoto(Convert.ToInt32(hdPhoto.Value), h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_Photo);
                        hdPhoto.Value = "";
                    }
                    else
                    {
                        AddDataToTempPhoto(h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_Photo);
                    }
                }
            }
            this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
            this.gvPhoto.DataBind();
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
                    if (!string.IsNullOrEmpty(hdSceneSketch.Value))
                    {
                        EditDataToTempSceneSketch(Convert.ToInt32(hdSceneSketch.Value), h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_SceneSketch);
                        hdSceneSketch.Value = "";
                    }
                    else
                    {
                        AddDataToTempSceneSketch(h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_SceneSketch);
                    }
                }
            }
            this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
            this.gvSceneSketch.DataBind();
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
                    if (!string.IsNullOrEmpty(hdExtenautingcond.Value))
                    {
                        EditDataToTempExtenautingcondition(Convert.ToInt32(hdExtenautingcond.Value), h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_ExtenuatingCondition);
                        hdExtenautingcond.Value = "";
                    }
                    else
                    {
                        AddDataToTempExtenautingcondition(h_file_guid + h_file_extension, h_file_name, SessionWrapper.session_ExtenuatingCondition);
                    }
                }
            }
            this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenautingCondition.DataBind();
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
                    if (!string.IsNullOrEmpty(hdEmployeeInterview.Value))
                    {
                        EditDataToTempEmployeeInterview(Convert.ToInt32(hdEmployeeInterview.Value), h_file_guid + h_file_extension, h_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                        hdEmployeeInterview.Value = "";
                    }
                    else
                    {
                        AddDataToTempEmployeeInterview(h_file_guid + h_file_extension, h_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                    }
                }
            }
            txtName.Text = string.Empty;
            txtContactInfo.Value = string.Empty;
            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }
        //Custom customer
        private DataTable tempCustomCustomer()
        {
            DataTable dtTempCustomCustomer = new DataTable();
            DataColumn dtTempCustomCustomeColumn;
            dtTempCustomCustomeColumn = new DataColumn();
            dtTempCustomCustomeColumn.DataType = Type.GetType("System.String");
            dtTempCustomCustomeColumn.ColumnName = "c_custom_customer_form_id_pk";
            dtTempCustomCustomer.Columns.Add(dtTempCustomCustomeColumn);

            dtTempCustomCustomeColumn = new DataColumn();
            dtTempCustomCustomeColumn.DataType = Type.GetType("System.String");
            dtTempCustomCustomeColumn.ColumnName = "h_harm_id_fk";
            dtTempCustomCustomer.Columns.Add(dtTempCustomCustomeColumn);

            dtTempCustomCustomeColumn = new DataColumn();
            dtTempCustomCustomeColumn.DataType = Type.GetType("System.String");
            dtTempCustomCustomeColumn.ColumnName = "h_file_guid";
            dtTempCustomCustomer.Columns.Add(dtTempCustomCustomeColumn);

            dtTempCustomCustomeColumn = new DataColumn();
            dtTempCustomCustomeColumn.DataType = Type.GetType("System.String");
            dtTempCustomCustomeColumn.ColumnName = "h_file_name";
            dtTempCustomCustomer.Columns.Add(dtTempCustomCustomeColumn);
            return dtTempCustomCustomer;
        }
        private void AddDataToTempCustomCustomer(string h_file_guid, string h_file_name, DataTable dtTempCustomCustome)
        {
            DataRow row;
            row = dtTempCustomCustome.NewRow();
            row["h_file_guid"] = h_file_guid;
            row["h_file_name"] = h_file_name;
            dtTempCustomCustome.Rows.Add(row);
        }
        private void EditDataToTempCustomCustomer(int rowIndex, string h_file_guid, string h_file_name, DataTable dtTempCustomCustome)
        {
            dtTempCustomCustome.Rows[rowIndex]["h_file_guid"] = h_file_guid;
            dtTempCustomCustome.Rows[rowIndex]["h_file_name"] = h_file_name;
            dtTempCustomCustome.AcceptChanges();
        }
        private void DeleteDataToTempCustomCustomer(int rowIndex, DataTable dtTempCustomCustome)
        {
            dtTempCustomCustome.Rows[rowIndex].Delete();
            dtTempCustomCustome.AcceptChanges();
            this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
            this.gvCustomForm.DataBind();
        }
        //photo
        private DataTable tempPhoto()
        {
            DataTable dtTempPhoto = new DataTable();
            DataColumn dtTempPhotoColumn;
            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "h_photo_id_pk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "h_harm_id_fk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "h_file_guid";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "h_file_name";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);
            return dtTempPhoto;
        }
        private void AddDataToTempPhoto(string h_file_guid, string h_file_name, DataTable dtTempPhoto)
        {
            DataRow row;
            row = dtTempPhoto.NewRow();
            row["h_file_guid"] = h_file_guid;
            row["h_file_name"] = h_file_name;
            dtTempPhoto.Rows.Add(row);
        }
        private void EditDataToTempPhoto(int rowIndex, string h_file_guid, string h_file_name, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex]["h_file_guid"] = h_file_guid;
            dtTempPhoto.Rows[rowIndex]["h_file_name"] = h_file_name;
            dtTempPhoto.AcceptChanges();
        }
        private void DeleteDataToTempPhoto(int rowIndex, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex].Delete();
            dtTempPhoto.AcceptChanges();
            this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
            this.gvPhoto.DataBind();
        }

        //scence sketch
        private DataTable tempSceneSketch()
        {
            DataTable dtTempSceneSketch = new DataTable();
            DataColumn dtTempSceneSketchColumn;
            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_scene_sketch_id_pk";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "h_harm_id_fk";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "h_file_guid";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "h_file_name";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            return dtTempSceneSketch;
        }
        private void AddDataToTempSceneSketch(string h_file_guid, string h_file_name, DataTable dtTempSceneSketch)
        {
            DataRow row;
            row = dtTempSceneSketch.NewRow();
            row["h_file_guid"] = h_file_guid;
            row["h_file_name"] = h_file_name;
            dtTempSceneSketch.Rows.Add(row);
        }
        private void EditDataToTempSceneSketch(int rowIndex, string h_file_guid, string h_file_name, DataTable dtTempSceneSketch)
        {
            dtTempSceneSketch.Rows[rowIndex]["h_file_guid"] = h_file_guid;
            dtTempSceneSketch.Rows[rowIndex]["h_file_name"] = h_file_name;
            dtTempSceneSketch.AcceptChanges();
        }
        private void DeleteDataToTempSceneSketch(int rowIndex, DataTable dtTempSceneSketch)
        {
            dtTempSceneSketch.Rows[rowIndex].Delete();
            dtTempSceneSketch.AcceptChanges();
            this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
            this.gvSceneSketch.DataBind();
        }
        //Extenautingcondition
        private DataTable tempExtenautingcondition()
        {
            DataTable dtTempExtenautingcondition = new DataTable();
            DataColumn dtTempExtenautingconditionColumn;
            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_extenauting_id_pk";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "h_harm_id_fk";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "h_file_guid";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "h_file_name";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);
            return dtTempExtenautingcondition;
        }
        private void AddDataToTempExtenautingcondition(string h_file_guid, string h_file_name, DataTable dtTempExtenautingcondition)
        {
            DataRow row;
            row = dtTempExtenautingcondition.NewRow();
            row["h_file_guid"] = h_file_guid;
            row["h_file_name"] = h_file_name;
            dtTempExtenautingcondition.Rows.Add(row);
        }
        private void EditDataToTempExtenautingcondition(int rowIndex, string h_file_guid, string h_file_name, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex]["h_file_guid"] = h_file_guid;
            dtTempExtenautingcondition.Rows[rowIndex]["h_file_name"] = h_file_name;
            dtTempExtenautingcondition.AcceptChanges();
        }
        private void DeleteDataToTempExtenautingcondition(int rowIndex, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex].Delete();
            dtTempExtenautingcondition.AcceptChanges();
            this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenautingCondition.DataBind();
        }
        //EmployeeInterview
        private DataTable tempEmployeeInterview()
        {
            DataTable dtTempEmployeeInterview = new DataTable();
            DataColumn dtTempEmployeeInterviewColumn;
            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_employee_interivew_id_pk";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "h_harm_id_fk";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "h_file_guid";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "h_file_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);


            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "h_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "h_contact_info";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            return dtTempEmployeeInterview;
        }
        private void AddDataToTempEmployeeInterview(string h_file_guid, string h_file_name, string h_name, string h_contact_info, DataTable dtTempEmployeeInterview)
        {
            DataRow row;
            row = dtTempEmployeeInterview.NewRow();
            row["h_file_guid"] = h_file_guid;
            row["h_file_name"] = h_file_name;
            row["h_name"] = h_name;
            row["h_contact_info"] = h_contact_info;
            dtTempEmployeeInterview.Rows.Add(row);
        }
        private void EditDataToTempEmployeeInterview(int rowIndex, string h_file_guid, string h_file_name, string h_name, string h_contact_info, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex]["h_file_guid"] = h_file_guid;
            dtTempEmployeeInterview.Rows[rowIndex]["h_file_name"] = h_file_name;
            dtTempEmployeeInterview.Rows[rowIndex]["h_name"] = h_name;
            dtTempEmployeeInterview.Rows[rowIndex]["h_contact_info"] = h_contact_info;
            dtTempEmployeeInterview.AcceptChanges();
        }
        private void DeleteDataToTempEmployeeInterview(int rowIndex, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex].Delete();
            dtTempEmployeeInterview.AcceptChanges();
            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }

        protected void gvCustomForm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvCustomForm.DataKeys[rowIndex][0].ToString();
                hdAddForm.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "customcustomer", "Showeditpopup('customcustomer');", true);
                mpeCustomCustomer.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            
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
                DeleteDataToTempCustomCustomer(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_Custom_Customer);
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
                string caseId = gvPhoto.DataKeys[rowIndex][0].ToString();
                hdPhoto.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photo", "Showeditpopup('photo');", true);
                mpePhoto.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            

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
                DeleteDataToTempPhoto(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_Photo);
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
                string caseId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                hdSceneSketch.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scenesketch", "Showeditpopup('scenesketch');", true);
                mpeSceneSketch.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            

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
                DeleteDataToTempSceneSketch(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_SceneSketch);
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
                string caseId = gvExtenautingCondition.DataKeys[rowIndex][0].ToString();
                hdExtenautingcond.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "extenuatingcondition", "Showeditpopup('extenuatingcondition');", true);
                mpeExtenautingCondition.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            

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
                DeleteDataToTempExtenautingcondition(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_ExtenuatingCondition);
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
                string caseId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                hdEmployeeInterview.Value = e.CommandArgument.ToString();
                txtName.Text = gvEmployeeInterview.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvEmployeeInterview.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "employeeinterview", "Showeditpopup('employeeinterview');", true);
                mpeEmployeeInterview.Show();
                // Response.Redirect("~/Compliance/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId));            

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
                DeleteDataToTempEmployeeInterview(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_EmployeeInterview);
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
            SaveHARM();
        }
        private void SaveHARM()
        {
            try
            {
                ComplianceDAO insertHarm = new ComplianceDAO();


                insertHarm.u_user_id_fk = SessionWrapper.u_userid;
                insertHarm.h_harm_id_pk = Guid.NewGuid().ToString();
                insertHarm.h_harm_number = lblHarmNumber.Text;
                insertHarm.h_case_title = txtCaseTitle.Text;
                insertHarm.h_case_date = (DateTime)SessionWrapper.HarmCaseDate;
                insertHarm.h_case_category_fk = ddlCaseCategory.SelectedValue;
                insertHarm.h_status = ddlCasestatus.SelectedValue;
                //insertHarm.h_employee_report_location = txtEmployeeReportLocation.Text;
                insertHarm.h_custom_01 = txtCustom01.Text;
                insertHarm.h_custom_02 = txtCustom02.Text;
                insertHarm.h_custom_03 = txtCustom03.Text;
                insertHarm.h_custom_04 = txtCustom04.Text;
                insertHarm.h_custom_05 = txtCustom05.Text;
                insertHarm.h_custom_06 = txtCustom06.Text;
                insertHarm.h_custom_07 = txtCustom07.Text;
                insertHarm.h_custom_08 = txtCustom08.Text;
                insertHarm.h_custom_09 = txtCustom09.Text;
                insertHarm.h_custom_10 = txtCustom10.Text;
                insertHarm.h_custom_11 = txtCustom11.Text;
                insertHarm.h_custom_12 = txtCustom12.Text;
                insertHarm.h_custom_13 = txtCustom13.Text;

                ComplianceDAO harm = new ComplianceDAO();

                DataTable dtCaseId = new DataTable();
                harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                insertHarm.h_harm_number = harm.h_harm_number;
                int errorMsg = ComplianceBLL.InsertHarm(insertHarm);



                if (errorMsg != -1)
                {
                    //insert hazard

                    foreach (DataRow dr in SessionWrapper.Hazard.Rows)
                    {
                        harm.h_hazard_id_pk = dr["h_hazard_id_pk"].ToString();
                        harm.h_hazard_description = dr["h_hazard_description"].ToString();
                        harm.h_harm_id_pk = insertHarm.h_harm_id_pk;
                        harm.h_permit_compliance_value = dr["h_permit_compliance_value"].ToString();
                        harm.h_program_compliance_value = dr["h_program_compliance_value"].ToString();
                        harm.h_job_title = SessionWrapper.h_job_title;
                        ComplianceBLL.InsertHazard(harm);

                        DataTable dtFilterControlMeasure = new DataTable();
                        dtFilterControlMeasure = SessionWrapper.ControlMeasure;
                        DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
                        dvControlMeasure.RowFilter = "h_hazard_id_fk= '" + harm.h_hazard_id_pk + "'";
                        foreach (DataRowView drView in dvControlMeasure)
                        {
                            harm.h_hazard_control_meausre_id_pk = drView["h_hazard_control_meausre_id_pk"].ToString();
                            harm.h_control_measure_summary = drView["h_control_measure_summary"].ToString();
                            harm.h_control_measure_id_fk = drView["h_control_measure_id_fk"].ToString();
                            harm.h_hazard_id_pk = harm.h_hazard_id_pk;
                            ComplianceBLL.InsertControlMeasure(harm);

                        }


                    }


                    //Custom Customer
                    foreach (DataRow dr in SessionWrapper.session_Custom_Customer.Rows)
                    {

                        insertHarm.h_file_guid = dr["h_file_guid"].ToString();
                        insertHarm.h_file_name = dr["h_file_name"].ToString();

                        ComplianceBLL.InserHarmCustomCustomer(insertHarm);


                    }





                    //Photo


                    foreach (DataRow dr in SessionWrapper.session_Photo.Rows)
                    {

                        insertHarm.h_file_guid = dr["h_file_guid"].ToString();
                        insertHarm.h_file_name = dr["h_file_name"].ToString();

                        ComplianceBLL.InsertHarmPhoto(insertHarm);


                    }
                    //SceneSketch

                    foreach (DataRow dr in SessionWrapper.session_SceneSketch.Rows)
                    {

                        insertHarm.h_file_guid = dr["h_file_guid"].ToString();
                        insertHarm.h_file_name = dr["h_file_name"].ToString();

                        ComplianceBLL.InsertHarmSceneSketch(insertHarm);


                    }



                    //ExtenuatingCondition
                    foreach (DataRow dr in SessionWrapper.session_ExtenuatingCondition.Rows)
                    {

                        insertHarm.h_file_guid = dr["h_file_guid"].ToString();
                        insertHarm.h_file_name = dr["h_file_name"].ToString();

                        ComplianceBLL.InsertHarmExtenuatingCondition(insertHarm);


                    }

                    //EmployeeInterview

                    foreach (DataRow dr in SessionWrapper.session_EmployeeInterview.Rows)
                    {

                        insertHarm.h_file_guid = dr["h_file_guid"].ToString();
                        insertHarm.h_file_name = dr["h_file_name"].ToString();
                        insertHarm.h_name = dr["h_name"].ToString();
                        insertHarm.h_contact_info = dr["h_contact_info"].ToString();
                        ComplianceBLL.InsertHarmEmployeeInterview(insertHarm);


                    }

                    Response.Redirect("~/Compliance/HARM/cceharm-01.aspx?Edit=" + SecurityCenter.EncryptText(insertHarm.h_harm_id_pk) + "&Succ=" + SecurityCenter.EncryptText("save"), false);
                }
                else
                {
                    error_msg.Style.Add("display", "block");


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
                        Logger.WriteToErrorLog("cccharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cccharm-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSave_Footer_Click(object sender, EventArgs e)
        {
            SaveHARM();
        }

        protected void btnCancel_footer_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/HARM/ccasharm-01.aspx");

        }

        protected void btnCancel_header_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/HARM/ccasharm-01.aspx");

        }
        private void PopulateHarm(string harmId)
        {
            ComplianceDAO harm = new ComplianceDAO();
            try
            {
                harm = ComplianceBLL.GetHarm(harmId);




                txtCaseTitle.Text = harm.h_case_title + "_Copy";
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

                DataTable dtCaseId = new DataTable();
                harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                lblHarmNumber.Text =  harm.h_harm_number;

            }
            catch (Exception ex)
            {
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



        protected void gvControlMeasureSummary_RowCommand(object sender, GridViewCommandEventArgs e)
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
        }



        private void BindControlMeasure(GridView GridView, string h_hazard_id_pk)
        {
            DataTable dtFilterControlMeasure = new DataTable();
            dtFilterControlMeasure = SessionWrapper.ControlMeasure;
            DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
            dvControlMeasure.RowFilter = "h_hazard_id_fk= '" + h_hazard_id_pk + "'";
            dvControlMeasure.Sort = "h_control_measure_text ASC";
            GridView.DataSource = dvControlMeasure;
            GridView.DataBind();



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
                emptyrow.Style.Add("display", "none");
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlPermitCompliance = (DropDownList)e.Item.FindControl("ddlPermitCompliance");
                HiddenField hdnPermitCompliance = (HiddenField)e.Item.FindControl("hdnPermitCompliance");

                if (ddlPermitCompliance != null)
                {
                    ddlPermitCompliance.DataSource = ComplianceBLL.GetPermitCompliance(SessionWrapper.CultureName,"cccharm-01");
                    ddlPermitCompliance.DataBind();
                }
                ddlPermitCompliance.SelectedValue = hdnPermitCompliance.Value;
                if (hdnPermitCompliance.Value == "")
                {
                    EditDataToPermitCompliance(e.Item.ItemIndex, ddlPermitCompliance.SelectedValue, SessionWrapper.Hazard);
                }
                DropDownList ddlPrgCompliance = (DropDownList)e.Item.FindControl("ddlPrgCompliance");
                HiddenField hdnPrgCompliance = (HiddenField)e.Item.FindControl("hdnPrgCompliance");

                if (ddlPrgCompliance != null)
                {
                    ddlPrgCompliance.DataSource = ComplianceBLL.GetProgramCompliance(SessionWrapper.CultureName,"cccharm-01");
                    ddlPrgCompliance.DataBind();
                }
                ddlPrgCompliance.SelectedValue = hdnPrgCompliance.Value;
                if (hdnPrgCompliance.Value == "")
                {
                    EditDataToProgramCompliance(e.Item.ItemIndex, ddlPrgCompliance.SelectedValue, SessionWrapper.Hazard);
                }
            }


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
            //gvcontrol measure



        }
        protected void gvControlMeasure_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = SessionWrapper.ControlMeasure;
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
                //lblControlMeasure.Text = "<b>" + LocalResources.GetLocaleResourceString("app_control_measure_text") + " " + seq + ":</b>&nbsp;&nbsp&nbsp&nbsp" + lblControlMeasure.Text;
            }
        }
        private DataTable tempHazard()
        {
            DataTable dtTempHazard = new DataTable();

            DataColumn dtTempHazardColumn;

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_id_pk";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_description";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_name";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_inactive";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_harm_id_fk";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_program_compliance_value";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_permit_compliance_value";
            dtTempHazard.Columns.Add(dtTempHazardColumn);



            return dtTempHazard;
        }
        private void AddDataToTempHazard(string h_hazard_id_pk, string h_hazard_description, string h_program_compliance_value, string h_permit_compliance_value, DataTable dtTempHazard)
        {
            DataRow row;

            row = dtTempHazard.NewRow();
            row["h_hazard_id_pk"] = h_hazard_id_pk;
            //row["h_harm_id_fk"] = h_harm_id_fk;
            row["h_hazard_description"] = h_hazard_description;
            row["h_program_compliance_value"] = h_program_compliance_value;
            row["h_permit_compliance_value"] = h_permit_compliance_value;

            dtTempHazard.Rows.Add(row);
        }
        private void EditDataToTempHazard(int rowIndex, string h_hazard_description, DataTable dtTempHazard)
        {


            dtTempHazard.Rows[rowIndex]["h_hazard_description"] = h_hazard_description;

            dtTempHazard.AcceptChanges();

        }
        private void DeleteDataToTempHazard(int rowIndex, DataTable dtTempHazard)
        {
            dtTempHazard.Rows[rowIndex].Delete();
            dtTempHazard.AcceptChanges();
            this.dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
            this.dlHazard.DataBind();

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
        private void EditDataToTempControlMeasure(int rowIndex, string h_control_measure_summary, DataTable dtTempControlMeasure)
        {

            dtTempControlMeasure.Rows[rowIndex]["h_control_measure_summary"] = h_control_measure_summary;

            dtTempControlMeasure.AcceptChanges();

        }
        private void DeleteDataToTempControlMeasure(int rowIndex, DataTable dtTempControlMeasure)
        {
            dtTempControlMeasure.Rows[rowIndex].Delete();
            dtTempControlMeasure.AcceptChanges();


        }



        protected void gvControlMeasureSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
           
           
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

        protected void btnReset_header_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);

        }

        protected void btnReset_Footer_Click(object sender, EventArgs e)
        {

            Response.Redirect(Request.RawUrl);

        }

        private void Reset()
        {
            //clear session
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

            hdAddForm.Value = "";
            hdControlMeasure.Value = "";
            hdEmployeeInterview.Value = "";
            hdExtenautingcond.Value = "";
            hdHazard.Value = "";
            hdPhoto.Value = "";
            hdSceneSketch.Value = "";

            if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
            {
                //TODO: 

                harmId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);
                PopulateHarm(harmId);
                ComplianceDAO harm = new ComplianceDAO();
                try
                {


                    DataTable dtHarmNumber = new DataTable();
                    harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                    lblHarmNumber.Text = ddlCaseCategory.SelectedValue.ToUpper() + harm.h_harm_number;

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

                harm.h_harm_id_pk = harmId;

                //Hazard and control measure
                try
                {
                    SessionWrapper.Hazard = tempHazard();
                    SessionWrapper.ControlMeasure = TempHarmDataTable.tempControlMeasure();


                    DataTable dtCopyHazard = ComplianceBLL.GetAllHazard(harm);
                    foreach (DataRow drCopyHazard in dtCopyHazard.Rows)
                    {
                        string hazardId = Guid.NewGuid().ToString();
                        AddDataToTempHazard(hazardId, drCopyHazard["h_hazard_description"].ToString(), "", "", SessionWrapper.Hazard);

                        harm.h_hazard_id_pk = drCopyHazard["h_hazard_id_pk"].ToString();
                        //Get control measure
                        DataTable dtCopyControlMeasure = ComplianceBLL.GetAllControlMeasure(harm);

                        foreach (DataRow drCopyControlmeasure in dtCopyControlMeasure.Rows)
                        {
                            AddDataToTempControlMeasure(hazardId, drCopyControlmeasure["h_control_measure_summary"].ToString(), drCopyControlmeasure["h_control_measure_id_fk"].ToString(), drCopyControlmeasure["h_control_measure_text"].ToString(), SessionWrapper.ControlMeasure);

                        }



                    }

                    dlHazard.DataSource = SessionWrapper.Hazard;
                    dlHazard.DataBind();
                    ViewState["ControlCategory"] = string.Empty;
                    ViewState["hazard_id_fk"] = string.Empty;
                    dlHazardSummary.DataSource = SessionWrapper.Hazard;
                    dlHazardSummary.DataBind();



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

                //Custom customer

                DataTable dtGetCustomCustomer = new DataTable();
                dtGetCustomCustomer = ComplianceBLL.GetHarmCustomCustomer(harm);
                dtTempCustomCustomer = new DataTable();
                dtTempCustomCustomer = dtGetCustomCustomer;
                SessionWrapper.session_Custom_Customer = dtTempCustomCustomer;
                this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
                this.gvCustomForm.DataBind();

                //photo

                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.GetHarmPhoto(harm);
                dtTempPhoto = new DataTable();
                dtTempPhoto = dtGetPhoto;
                SessionWrapper.session_Photo = dtTempPhoto;
                this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                this.gvPhoto.DataBind();


                //SceneSketch

                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetHarmSceneSketch(harm);
                dtTempSceneSketch = new DataTable();
                dtTempSceneSketch = dtGetSceneSketch;
                SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                this.gvSceneSketch.DataBind();

                //Extenautingcondition

                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetHarmExtenuatingCondition(harm);
                dtTempExtenautingcond = new DataTable();
                dtTempExtenautingcond = dtGetExtenautingCondition;
                SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                this.gvExtenautingCondition.DataBind();

                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetHarmEmployeeInterview(harm);
                dtTempEmployeeInterview = new DataTable();
                dtTempEmployeeInterview = dtGetEmployeeInterview;
                SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                this.gvEmployeeInterview.DataBind();
            }
            else
            {

                ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["category"]);
                txtCaseTitle.Text = SecurityCenter.DecryptText(Request.QueryString["title"]);

                ComplianceDAO harm = new ComplianceDAO();

                DataTable dtHarmNumber = new DataTable();
                harm = ComplianceBLL.GetHarmNumber(ddlCaseCategory.SelectedValue);
                lblHarmNumber.Text = harm.h_harm_number;

                //witenss
                dtTempCustomCustomer = new DataTable();
                dtTempCustomCustomer = tempCustomCustomer();
                SessionWrapper.session_Custom_Customer = dtTempCustomCustomer;


                this.gvCustomForm.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
                this.gvCustomForm.DataBind();


                //photo

                dtTempPhoto = new DataTable();
                dtTempPhoto = tempPhoto();
                SessionWrapper.session_Photo = dtTempPhoto;


                this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                this.gvPhoto.DataBind();


                //SceneSketch

                dtTempSceneSketch = new DataTable();
                dtTempSceneSketch = tempSceneSketch();
                SessionWrapper.session_SceneSketch = dtTempSceneSketch;


                this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                this.gvSceneSketch.DataBind();

                //ExtenuatingCondition

                dtTempExtenautingcond = new DataTable();
                dtTempExtenautingcond = tempExtenautingcondition();
                SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;


                this.gvExtenautingCondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                this.gvExtenautingCondition.DataBind();


                //EmployeeInterview

                dtTempEmployeeInterview = new DataTable();
                dtTempEmployeeInterview = tempEmployeeInterview();
                SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;


                this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                this.gvEmployeeInterview.DataBind();

                //Hazard

                dtTempHazard = new DataTable();
                dtTempHazard = tempHazard();
                SessionWrapper.Hazard = dtTempHazard;

                //control measure
                dtTempControlMeasure = new DataTable();
                dtTempControlMeasure = TempHarmDataTable.tempControlMeasure();
                SessionWrapper.ControlMeasure = dtTempControlMeasure;



                dlHazard.DataSource = null;
                dlHazard.DataBind();


                dlHazardSummary.DataSource = null;
                dlHazardSummary.DataBind();
                emptyrow.Style.Add("display", "block");
                txtCustom01.Text = "";
                txtCustom02.Text = "";
                txtCustom03.Text = "";
                txtCustom04.Text = "";
                txtCustom05.Text = "";
                txtCustom06.Text = "";
                txtCustom07.Text = "";
                txtCustom08.Text = "";
                txtCustom09.Text = "";
                txtCustom10.Text = "";
                txtCustom11.Text = "";
                txtCustom12.Text = "";
                txtCustom13.Text = "";
                //txtEmployeeReportLocation.Text = "";

            }


        }
        protected void ddlPrgCompliance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlPrgCompliance = (DropDownList)sender;
            DataListItem item = (DataListItem)ddlPrgCompliance.NamingContainer;

            int strHazardId = item.ItemIndex;
            //dlHazard.DataKeys[item.ItemIndex].ToString();
            DataTable dtHazard = SessionWrapper.Hazard;
            EditDataToProgramCompliance(strHazardId, ddlPrgCompliance.SelectedValue, SessionWrapper.Hazard);

            DataTable dt = SessionWrapper.Hazard;
        }
        protected void ddlPermitCompliance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlPermitCompliance = (DropDownList)sender;
            DataListItem item = (DataListItem)ddlPermitCompliance.NamingContainer;

            int strHazardId = item.ItemIndex;
            //dlHazard.DataKeys[item.ItemIndex].ToString();
            DataTable dtHazard = SessionWrapper.Hazard;
            EditDataToPermitCompliance(strHazardId, ddlPermitCompliance.SelectedValue, SessionWrapper.Hazard);

            DataTable dt = SessionWrapper.Hazard;

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
        protected void btnNewControlMeasure_Click(object sender, EventArgs e)
        {
            cvOneControlMeasure.Style.Add("display", "none");
            cvControlMeasure.Style.Add("display", "block");
            cvControlMeasure.Enabled = true;

            AddControlMeasure();
            AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlControlMeasure.SelectedValue, ddlControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
            gvNewControlMeasure.DataSource = SessionWrapper.h_control_measure;
            gvNewControlMeasure.DataBind();
            mpHazard.Show();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "HazardNew", "ShowDialog(true);", true);
        }
        /// <summary>
        /// Delete control measure
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteControlmeasure(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.h_control_measure.Select("h_hazard_control_meausre_id_pk= '" + args.Trim() + "'");
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

        private void AddControlMeasure()
        {
            SessionWrapper.h_control_measure = null;
            SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();

            foreach (GridViewRow grdRow in gvNewControlMeasure.Rows)
            {
                Label lblControlMeasureText = default(Label);
                lblControlMeasureText = (Label)grdRow.Cells[0].FindControl("lblControlMeasureText");
                HiddenField hdnControlMeasureValue = default(HiddenField);
                hdnControlMeasureValue = (HiddenField)grdRow.Cells[0].FindControl("hdnControlMeasureValue");
                TextBox txtAddControlMeasure = default(TextBox);
                txtAddControlMeasure = (TextBox)grdRow.Cells[0].FindControl("txtAddControlMeasure");
                //AddDataToAddNewControlMeasure(hdnControlMeasureValue.Value, lblControlMeasureText.Text, txtAddControlMeasure.Text, SessionWrapper.h_control_measure);
                AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtAddControlMeasure.Text, hdnControlMeasureValue.Value, lblControlMeasureText.Text, SessionWrapper.h_control_measure);
            }
            var rows = SessionWrapper.h_control_measure.Select("h_control_measure_summary= '" + string.Empty + "'");
            foreach (var row in rows)
                row.Delete();
            SessionWrapper.h_control_measure.AcceptChanges();
        }
        private void AddEditControlMeasure()
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
                AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, txtAddControlMeasure.Text, hdnControlMeasureValue.Value, lblControlMeasureText.Text, SessionWrapper.h_control_measure);
            }
            var rows = SessionWrapper.h_control_measure.Select("h_control_measure_summary= '" + string.Empty + "'");
            foreach (var row in rows)
                row.Delete();
            SessionWrapper.h_control_measure.AcceptChanges();
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
        protected void btnSaveHazardControlMeausre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdHazard.Value))
            {
                EditDataToTempHazard(Convert.ToInt32(hdHazard.Value), txtHazardName.Value, SessionWrapper.Hazard);
                hdHazard.Value = "";
                AddControlMeasure();
                // AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlControlMeasure.SelectedValue, ddlControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
                var rows = SessionWrapper.ControlMeasure.Select("h_hazard_id_fk= '" + SessionWrapper.temp_h_hazard_id_pk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.ControlMeasure.AcceptChanges();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtJobTitle.Text))
                {
                    SessionWrapper.h_job_title = txtJobTitle.Text;
                    lblJobTitle.Text = SessionWrapper.h_job_title;
                    txtEditJobTitle.Text = SessionWrapper.h_job_title;
                }
                //SessionWrapper.temp_h_hazard_id_pk = Guid.NewGuid().ToString();
                AddDataToTempHazard(SessionWrapper.temp_h_hazard_id_pk, txtHazardName.Value, "", "", SessionWrapper.Hazard);
                AddControlMeasure();
                //AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlControlMeasure.SelectedValue, ddlControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);

            }
            SessionWrapper.ControlMeasure.Merge(SessionWrapper.h_control_measure);
            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;

            dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazard.DataBind();

            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;
            dlHazardSummary.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazardSummary.DataBind();
            //txtControlMeasureName.Text = "";
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
        protected void dlHazard_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditHazard"))
            {
                ddlControlMeasure.SelectedIndex = 0;
                string strHazardId = dlHazard.DataKeys[e.Item.ItemIndex].ToString();
                DataTable dtHazard = SessionWrapper.Hazard;
                var rows = dtHazard.Select("h_hazard_id_pk= '" + strHazardId + "'");
                var indexofRow = dtHazard.Rows.IndexOf(rows[0]);
                //control measure
                SessionWrapper.h_control_measure = null;
                SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();
                DataTable dtFilterControlMeasure = new DataTable();
                dtFilterControlMeasure = SessionWrapper.ControlMeasure;
                DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
                dvControlMeasure.RowFilter = "h_hazard_id_fk= '" + strHazardId + "'";
                SessionWrapper.h_control_measure = dvControlMeasure.ToTable();
                gvNewControlMeasure.DataSource = SessionWrapper.h_control_measure;
                gvNewControlMeasure.DataBind();
                //store edit hazard id
                SessionWrapper.temp_h_hazard_id_pk = strHazardId;

                txtHazardName.Value = rows[0]["h_hazard_description"].ToString();
                hdHazard.Value = indexofRow.ToString();
                mpHazard.Show();
               // Page.ClientScript.RegisterStartupScript(this.GetType(), "Hazard", "showHazardDialog();", true);
            }
            else if (e.CommandName.Equals("RemoveHazard"))
            {
                string strHazardId = dlHazard.DataKeys[e.Item.ItemIndex].ToString();
                DataTable dtHazard = SessionWrapper.Hazard;
                var rows = dtHazard.Select("h_hazard_id_pk= '" + strHazardId + "'");
                var indexofRow = dtHazard.Rows.IndexOf(rows[0]);

                DeleteDataToTempHazard(indexofRow, SessionWrapper.Hazard);

                //delete control measure
                DataTable dtControlMeasure = SessionWrapper.ControlMeasure;
                DataRow[] rowControlMeasure = dtControlMeasure.Select("h_hazard_id_fk= '" + strHazardId + "'");
                foreach (DataRow thisrow in rowControlMeasure)
                {
                    var indexOfControlMeasure = dtControlMeasure.Rows.IndexOf(thisrow);
                    DeleteDataToTempControlMeasure(indexOfControlMeasure, SessionWrapper.ControlMeasure);
                }
                //end

                dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
                dlHazard.DataBind();
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazardSummary.DataSource = (SessionWrapper.Hazard).DefaultView;
                dlHazardSummary.DataBind();

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

                if (dlHazardSummary.Items.Count == 0)
                {
                    emptyrow.Style.Add("display", "block");
                }
            }

        }
        /// <summary>
        /// Remove duplicate rows
        /// </summary>
        /// <param name="dTable"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
        //btnAddEditControlMeasure_Click
        protected void btnAddEditControlMeasure_Click(object sender, EventArgs e)
        {
            cvOneAddEditControlMeasure.Style.Add("display", "none");
            cvAddEditControlMeasure.Style.Add("display", "block");
            cvAddEditControlMeasure.Enabled = true;

            AddEditControlMeasure();
            AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlAddEditControlMeasure.SelectedValue, ddlAddEditControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
            gvAddEditControlMeasure.DataSource = SessionWrapper.h_control_measure;
            gvAddEditControlMeasure.DataBind();
            mpControlMeasure.Show();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);
        }

        protected void btnSaveControlMeausre_Click(object sender, EventArgs e)
        {
            if (hdControlMeasure.Value == "AddControlMeasure")
            {
                AddEditControlMeasure();
                // AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, string.Empty, string.Empty, SessionWrapper.ControlMeasure);
            }
            else
            {
                var rows = SessionWrapper.ControlMeasure.Select("h_hazard_control_meausre_id_pk= '" + SessionWrapper.temp_h_control_measure_id_pk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.ControlMeasure.AcceptChanges();
                AddEditControlMeasure();

                // AddDataToTempControlMeasure(SessionWrapper.temp_h_hazard_id_pk, string.Empty, ddlControlMeasure.SelectedValue, ddlControlMeasure.SelectedItem.Text, SessionWrapper.h_control_measure);
                //var rows = SessionWrapper.ControlMeasure.Select("h_hazard_control_meausre_id_pk= '" + SessionWrapper.temp_h_hazard_id_pk + "'");
                //foreach (var row in rows)
                //    row.Delete();
                //SessionWrapper.ControlMeasure.AcceptChanges();


                //EditDataToTempControlMeasure(Convert.ToInt32(hdControlMeasure.Value), string.Empty, SessionWrapper.ControlMeasure);
                hdControlMeasure.Value = "";
            }
            SessionWrapper.ControlMeasure.Merge(SessionWrapper.h_control_measure);
            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;

            dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazard.DataBind();
            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;
            dlHazardSummary.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazardSummary.DataBind();

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
            //txtAddControlMeasure.Text = "";

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
                DataTable dtControlMeasure = SessionWrapper.ControlMeasure;
                var rows = dtControlMeasure.Select("h_hazard_control_meausre_id_pk= '" + strControlMeasureId + "'");
                var indexOfRow = dtControlMeasure.Rows.IndexOf(rows[0]);
                // txtAddControlMeasure.Text = rows[0]["h_control_measure_summary"].ToString();
                hdControlMeasure.Value = indexOfRow.ToString();

                //string str_h_hazard_control_meausre_id_pk = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[1].ToString();

                //control measure
                SessionWrapper.h_control_measure = null;
                SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();
                DataTable dtFilterControlMeasure = new DataTable();
                dtFilterControlMeasure = SessionWrapper.ControlMeasure;
                DataView dvControlMeasure = new DataView(dtFilterControlMeasure);
                dvControlMeasure.RowFilter = "h_hazard_control_meausre_id_pk= '" + strControlMeasureId + "'";
                SessionWrapper.h_control_measure = dvControlMeasure.ToTable();
                gvAddEditControlMeasure.DataSource = SessionWrapper.h_control_measure;
                gvAddEditControlMeasure.DataBind();
                //store edit hazard id
                SessionWrapper.temp_h_hazard_id_pk = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[0].ToString();
                SessionWrapper.temp_h_control_measure_id_pk = strControlMeasureId;
                mpControlMeasure.Show();
               // Page.ClientScript.RegisterStartupScript(this.GetType(), "controlmeasure", "showControlMeasureDialog();", true);

            }
            else if (e.CommandName.Equals("RemoveControlMeasure"))
            {

                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string strControlMeasureId = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values[1].ToString();
                DataTable dtControlMeasure = SessionWrapper.ControlMeasure;
                var rows = dtControlMeasure.Select("h_hazard_control_meausre_id_pk= '" + strControlMeasureId + "'");
                var indexOfRow = dtControlMeasure.Rows.IndexOf(rows[0]);

                DeleteDataToTempControlMeasure(indexOfRow, SessionWrapper.ControlMeasure);

                //Button btnRemoveControlMeasure = (Button)GridView1.Rows[0].FindControl("btnRemoveControlMeasure");


                dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
                dlHazard.DataBind();
                ViewState["ControlCategory"] = string.Empty;
                ViewState["hazard_id_fk"] = string.Empty;
                dlHazardSummary.DataSource = (SessionWrapper.Hazard).DefaultView;
                dlHazardSummary.DataBind();

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

        protected void btnEditJobTitle_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemoveJobTitle_Click(object sender, EventArgs e)
        {
            lblJobTitle.Text = string.Empty;
            SessionWrapper.h_job_title = string.Empty;
            divAddJobTitle.Style.Add("display", "none");
            SessionWrapper.h_control_measure.Clear();
            SessionWrapper.ControlMeasure.Clear();
            SessionWrapper.Hazard.Clear();
           // SessionWrapper.Hazard = TempHarmDataTable.tempHazard();
            //SessionWrapper.h_control_measure = TempHarmDataTable.tempControlMeasure();
            dlHazard.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazard.DataBind();
            ViewState["ControlCategory"] = string.Empty;
            ViewState["hazard_id_fk"] = string.Empty;
            dlHazardSummary.DataSource = (SessionWrapper.Hazard).DefaultView;
            dlHazardSummary.DataBind();
        }
        protected void btnSaveJobTitle_Click(object sender, EventArgs e)
        {
            SessionWrapper.h_job_title = txtEditJobTitle.Text;
            lblJobTitle.Text = SessionWrapper.h_job_title;
        }
    }
}