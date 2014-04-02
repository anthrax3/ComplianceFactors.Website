using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text.RegularExpressions;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Compliance.MIRIS.Controls;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance.MIRIS
{
    public partial class cmv_01 : System.Web.UI.Page
    {
        public urc_01 urc;
        private string caseId;
        private bool isApprover;
        private static string copyCaseId;
        
        private int vCount = 0;
        #region "Private Member Variables"
        private string _path = "~/Compliance/MIRIS/Upload/Witness/";
        private string _pathPolice = "~/Compliance/MIRIS/Upload/Police/";
        private string _pathPhoto = "~/Compliance/MIRIS/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/MIRIS/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/MIRIS/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/MIRIS/Upload/EmployeeInterview/";

        #endregion
        private DataTable dtTempWitness = null;
        private DataTable dtTempPhoto = null;
        private DataTable dtTempPolice = null;
        private DataTable dtTempSceneSketch = null;
        private DataTable dtTempExtenautingcond = null;
        private DataTable dtTempEmployeeInterview = null;

        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {

            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;<a href=/Compliance/MIRIS/cccmiris-01.aspx>" + LocalResources.GetGlobalLabel("app_giris_text") + "</a>&nbsp;" + ">&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_motor_vehicle_incident_text") + "</a>";
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                trAddEstablishment.Visible = true;

            }
            if (!IsPostBack)
            {
                PopulateYearDropDown();
                //vehicleId = 0;
                imgCourse.AlternateText = "plus";
                imgdamagedesc.AlternateText = "plus";
                imgPublicVehicle.AlternateText = "plus";
                imgpublicdamage.AlternateText = "plus";
                imgPedestrain.AlternateText = "plus";
                imgBicycleIncident.AlternateText = "plus";
                imgfixedobject.AlternateText = "plus";
                imganimalincident.AlternateText = "plus";
                imgadditionalinfo.AlternateText = "plus";
                imgcustomfilds.AlternateText = "plus";
                //clear session
                copyCaseId = string.Empty;
                SessionWrapper.session_witness = null;
                SessionWrapper.session_EmployeeInterview = null;
                SessionWrapper.session_ExtenuatingCondition = null;
                SessionWrapper.session_Photo = null;
                SessionWrapper.session_PoliceReport = null;
                SessionWrapper.session_SceneSketch = null;

                try
                {
                    //case category
                    ddlCaseCategory.DataSource = ComplianceBLL.GetMirisCaseCategory(SessionWrapper.CultureName, "ccamiris-01");
                    ddlCaseCategory.DataBind();

                    //case Type
                    ddlCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                    ddlCaseTypes.DataBind();


                    //case status
                    ddlCaseStatus.DataSource = ComplianceBLL.GetMirisCaseStatus(SessionWrapper.CultureName, "ccamiris-01");
                    ddlCaseStatus.DataBind();
                    ddlCaseStatus.SelectedValue = "app_ddl_open_text";

                    //Compliance Approver
                    ddlComplianceApprover.DataSource = UserBLL.GetComplianceApproverList();
                    ddlComplianceApprover.DataBind();

                 
                
                    ddlEmployeeReportLocation.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                    {
                        s_establishment_id_pk = "",
                        s_establishment_city = "",
                        s_establishment_name = "",
                        s_establishment_status_id_fk = "app_ddl_active_text"
                    });

                    ddlEmployeeReportLocation.DataTextField = "s_establishment_name";
                    ddlEmployeeReportLocation.DataValueField = "s_establishment_system_id_pk";
                    ddlEmployeeReportLocation.DataBind();
                    ddlEmployeeReportLocation.Items.Insert(0, new ListItem("", ""));
                   
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message);
                        }
                    }

                }
                //IncidentTime.Date = Convert.ToDateTime("2012-06-10 17:25:04");
                //WorkStartTime.Date = Convert.ToDateTime(DateTime.Now.ToString());
                try
                {

                    // DateTime currentDt = DateTime.Now.ToUniversalTime();//Current Converted to UTC
                    // currentDt = DateTime.SpecifyKind(currentDt, DateTimeKind.Utc);//Say to runtime that this date is UTC date.
                    // SessionWrapper.casedate = currentDt;
                    // lblCaseDate.Text = currentDt.ToString("MM/dd/yyyy hh:mm tt");

                    ddlTimezone.DataSource = UserBLL.GetUserTimeZone();
                    ddlTimezone.DataBind();

                    ComplianceDAO miris = new ComplianceDAO();
                    miris = ComplianceBLL.GetTimeZoneDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
                    IncidentTime.Date = DateTime.Now;
                    //WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                    SessionWrapper.casedate = miris.c_temp_case_date;
                    lblCaseDate.Text = SessionWrapper.casedate.ToString("MM/dd/yyyy hh:mm tt");
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message);
                        }
                    }

                }

                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    caseId = SecurityCenter.DecryptText(Request.QueryString["Copy"]);
                    copyCaseId = caseId;
                    IncidentTime.Date = Convert.ToDateTime(DateTime.Now.ToString());
                    populatecase(caseId);
                    if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                    {
                        if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["cid"])))
                        {
                            ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["cid"]);
                        }
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["id"])))
                        {
                            lblCaseNumber.Text = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        }
                    }

                    ComplianceDAO miris = new ComplianceDAO();
                    miris.c_case_id_pk = caseId;
                    miris.s_locale_culture = SessionWrapper.CultureName;

                    //witness
                    DataTable dtGetWitness = new DataTable();
                    dtGetWitness = ComplianceBLL.GetWitness(miris);
                    dtTempWitness = new DataTable();
                    dtTempWitness = dtGetWitness;
                    SessionWrapper.session_witness = dtTempWitness;
                    this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                    this.gvAddWitness.DataBind();

                    //photo
                    DataTable dtGetPhoto = new DataTable();
                    dtGetPhoto = ComplianceBLL.Getphoto(miris);
                    dtTempPhoto = new DataTable();
                    dtTempPhoto = dtGetPhoto;
                    SessionWrapper.session_Photo = dtTempPhoto;
                    this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                    this.gvPhoto.DataBind();

                    //police report
                    DataTable dtGetPoliceReport = new DataTable();
                    dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                    dtTempPolice = new DataTable();
                    dtTempPolice = dtGetPoliceReport;
                    SessionWrapper.session_PoliceReport = dtTempPolice;
                    this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                    this.gvPoliceReport.DataBind();

                    //SceneSketch
                    DataTable dtGetSceneSketch = new DataTable();
                    dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                    dtTempSceneSketch = new DataTable();
                    dtTempSceneSketch = dtGetSceneSketch;
                    SessionWrapper.session_SceneSketch = dtTempSceneSketch;
                    this.gvSceneSketch.DataSource = (SessionWrapper.session_SceneSketch).DefaultView;
                    this.gvSceneSketch.DataBind();

                    //Extenautingcondition
                    DataTable dtGetExtenautingCondition = new DataTable();
                    dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                    dtTempExtenautingcond = new DataTable();
                    dtTempExtenautingcond = dtGetExtenautingCondition;
                    SessionWrapper.session_ExtenuatingCondition = dtTempExtenautingcond;
                    this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                    this.gvExtenuatingcondition.DataBind();

                    //EmployeeInterview
                    DataTable dtGetEmployeeInterview = new DataTable();
                    dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                    dtTempEmployeeInterview = new DataTable();
                    dtTempEmployeeInterview = dtGetEmployeeInterview;
                    SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                    this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                    this.gvEmployeeInterview.DataBind();

                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["id"])))
                        {
                            lblCaseNumber.Text = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        }
                    }
                }
                else
                {
                    try
                    {
                        ddlTimezone.SelectedValue = SessionWrapper.u_timezone;
                        ddlCaseCategory.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["cid"]);

                        txtCaseTitle.Text = SecurityCenter.DecryptText(Request.QueryString["title"]);

                        ComplianceDAO miris = new ComplianceDAO();
                        DataTable dtCaseId = new DataTable();
                        miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);

                        ddlCaseTypes.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["type"]);
                        lblCaseNumber.Text = miris.c_case_number;

                        //witenss
                        dtTempWitness = new DataTable();
                        dtTempWitness = tempWitness();
                        SessionWrapper.session_witness = dtTempWitness;
                        this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
                        this.gvAddWitness.DataBind();

                        //photo
                        dtTempPhoto = new DataTable();
                        dtTempPhoto = tempPhoto();
                        SessionWrapper.session_Photo = dtTempPhoto;
                        this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
                        this.gvPhoto.DataBind();

                        //Police report
                        dtTempPolice = new DataTable();
                        dtTempPolice = tempPolice();
                        SessionWrapper.session_PoliceReport = dtTempPolice;

                        this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
                        this.gvPoliceReport.DataBind();

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
                        this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
                        this.gvExtenuatingcondition.DataBind();

                        //EmployeeInterview
                        dtTempEmployeeInterview = new DataTable();
                        dtTempEmployeeInterview = tempEmployeeInterview();
                        SessionWrapper.session_EmployeeInterview = dtTempEmployeeInterview;
                        this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
                        this.gvEmployeeInterview.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cmv-01", ex.Message);
                            }
                        }
                    }
                }
            }
            AddAndRemoveVehicle();
            if (Session["Case_Employee"] != null)
            {
                User user = (User)Session["Case_Employee"];
                txtEmployeeName.Text = user.Lastname;
                if (!string.IsNullOrEmpty(user.u_social_security_no))
                {
                    txtLastFourDigitOfSSN.Text = user.u_social_security_no.Substring(user.u_social_security_no.Length - 4, 4);

                }
                else
                {
                    txtLastFourDigitOfSSN.Text = "";
                }
                ddlHireMonth.SelectedValue = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Month.ToString() : "";
                ddlHireYear.SelectedValue = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Year.ToString() : "-1";
                doh_hire_day.SelectedIndex = (user.Hris_hire_date.HasValue) ? user.Hris_hire_date.Value.Day : 0;
                txtEmployeeId.Text = user.Hris_employeid;
                Session["Case_Employee"] = null;
            }
        }
        /// <summary>
        /// Add or remove the vehicle user control
        /// </summary>
        private void AddAndRemoveVehicle()
        {
            int vehicleCount = Convert.ToInt16(ltlVehicleCount.Text);
            if (vehicleCount >= 8)
            {
                int ControlID = 0;
                for (int i = 1; i <= 8; i++)
                {
                    ucmv_01 vehicleUserControl = (ucmv_01)LoadControl("../MIRIS/Controls/ucmv-01.ascx");
                    string vehicleNumber = string.Empty;
                    if (i == 8)
                    {
                        vehicleNumber = "10";
                    }
                    else
                    {
                        vehicleNumber = "0" + Convert.ToString(i + 2);
                    }
                    if (!string.IsNullOrEmpty(copyCaseId))
                    {
                        List<ComplainceVehicle> compliance = ComplianceBLL.GetVehicle(copyCaseId, vehicleNumber);

                        vehicleUserControl.ddlVehicle = compliance[0].vehicle_fk.ToString();
                        vehicleUserControl.VechicleId = compliance[0].vehicle_id.ToString();
                        vehicleUserControl.VehicleMake = compliance[0].vehicle_make.ToString();
                        vehicleUserControl.VehicleModel = compliance[0].vehicle_model.ToString();
                        vehicleUserControl.VIN = compliance[0].vehicle_vin.ToString();
                        vehicleUserControl.ddlType = compliance[0].vehicle_type.ToString();
                        vehicleUserControl.Year = compliance[0].vehicle_year.ToString();
                        vehicleUserControl.State = compliance[0].vehicle_state.ToString();
                        vehicleUserControl.LicenseNumber = compliance[0].vehicle_licence.ToString();
                    }

                    vehicleUserControl.lblVechicle = "Vehicle " + vehicleNumber;

                    while (InDeletedVechicleControl("ucVehicleUserControl" + ControlID) == true)
                    {
                        ControlID += 1;
                    }
                    vehicleUserControl.ID = "ucVehicleUserControl" + ControlID;
                    //Add an event handler to this control to raise an event when the delete button is clicked
                    //on the user control
                    vehicleUserControl.RemoveVehicleUserControl += new EventHandler(HandleRemoveUserControl);
                    //Finally, add the user control to the panel
                    VehiclePanel.Controls.Add(vehicleUserControl);
                    //Increment the control id for the next round through the loop
                    ControlID += 1;
                }
            }
            else
            {
                Control c = GetPostBackControl(Page);
                if ((c != null))
                {
                    //If the add button was clicked, increase the count to let the page know we want
                    //to display an additional user control
                    if (c.ID.ToString() == "btnAddVechicle")
                    {
                        vehicleCount = Convert.ToInt16(ltlVehicleCount.Text);
                        ltlVehicleCount.Text = Convert.ToString(vehicleCount + 1);
                    }
                }
                int ControlID = 0;

                vCount = (Convert.ToInt16(ltlVehicleCount.Text)) + Convert.ToInt32(vCount);
                for (int i = 1; i <= (vCount); i++)
                {
                    ucmv_01 vehicleUserControl = (ucmv_01)LoadControl("../MIRIS/Controls/ucmv-01.ascx");
                    string vehicleNumber = string.Empty;
                    if (i == 8)
                    {
                        vehicleNumber = "10";
                    }
                    else
                    {
                        vehicleNumber = "0" + Convert.ToString(i + 2);
                    }
                    if (!string.IsNullOrEmpty(copyCaseId))
                    {
                        List<ComplainceVehicle> compliance = ComplianceBLL.GetVehicle(copyCaseId, vehicleNumber);

                        vehicleUserControl.ddlVehicle = compliance[0].vehicle_fk.ToString();
                        vehicleUserControl.VechicleId = compliance[0].vehicle_id.ToString();
                        vehicleUserControl.VehicleMake = compliance[0].vehicle_make.ToString();
                        vehicleUserControl.VehicleModel = compliance[0].vehicle_model.ToString();
                        vehicleUserControl.VIN = compliance[0].vehicle_vin.ToString();
                        vehicleUserControl.ddlType = compliance[0].vehicle_type.ToString();
                        vehicleUserControl.Year = compliance[0].vehicle_year.ToString();
                        vehicleUserControl.State = compliance[0].vehicle_state.ToString();
                        vehicleUserControl.LicenseNumber = compliance[0].vehicle_licence.ToString();
                    }
                    vehicleUserControl.lblVechicle = "Vehicle " + vehicleNumber;
                    while (InDeletedVechicleControl("ucVehicleUserControl" + ControlID) == true)
                    {
                        ControlID += 1;
                    }
                    vehicleUserControl.ID = "ucVehicleUserControl" + ControlID;

                    //Add an event handler to this control to raise an event when the delete button is clicked
                    //on the user control
                    vehicleUserControl.RemoveVehicleUserControl += new EventHandler(HandleRemoveUserControl);
                    //Finally, add the user control to the panel
                    VehiclePanel.Controls.Add(vehicleUserControl);
                    //Increment the control id for the next round through the loop
                    ControlID += 1;
                }
            }

        }
        /// <summary>
        ///  Check the user control was deleted
        /// </summary>
        /// <param name="ControlID"></param>
        /// <returns></returns>
        private bool InDeletedVechicleControl(string ControlID)
        {
            //Determine if the passed in user control id has been stored in the list of controls that
            //were previously deleted off the page
            string[] DeletedList = ltlRemoved.Text.Split('|');
            for (int i = 0; i <= DeletedList.GetLength(0) - 1; i++)
            {
                if (ControlID.ToLower() == DeletedList[i].ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get Post Back Control for add vehicle button was clicked
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public Control GetPostBackControl(Page page)
        {
            Control control = null;
            foreach (string ctl in page.Request.Form)
            {
                if (ctl != null)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            return control;
        }
        public void HandleRemoveUserControl(object sender, EventArgs e)
        {
            Button but = sender as Button;
            ucmv_01 DynamicUserControl = (ucmv_01)but.Parent;
            VehiclePanel.Controls.Remove(DynamicUserControl);

            string lblValue = DynamicUserControl.lblVechicle;
            string countvalue = lblValue.Substring(lblValue.Length - 2, 2);
            //lblValue = lblValue.Replace("Vehicle", "");
            lblValue = lblValue.Replace(countvalue, "");
            int count = Convert.ToInt16(countvalue) - 3;             
            if (count == 0)
            {
                count = 1;
            }
            for (int i = count; i < VehiclePanel.Controls.Count; i++)
            {
                ucmv_01 ucvehicle = (ucmv_01)VehiclePanel.Controls[i];
                if (i == 8)
                {
                    ucvehicle.lblVechicle =  lblValue+" 10";
                }
                else
                {
                    ucvehicle.lblVechicle = lblValue+" 0" + Convert.ToInt16(i + 2);
                }
            }

            ltlRemoved.Text += DynamicUserControl.ID + "|";
            ltlVehicleCount.Text = (Convert.ToInt16(ltlVehicleCount.Text) - 1).ToString();
        }

        protected void btnCancel_header_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }

        protected void btnCancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
        }

        protected void btnUploadWitness_Click(object sender, EventArgs e)
        {
            btnUploadWitness.Enabled = false;
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_path + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdWitness.Value))
                    {
                        EditDataToTempWitness(Convert.ToInt32(hdWitness.Value), c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_witness);
                        hdWitness.Value = "";

                    }
                    else
                    {
                        AddDataToTempWitness(c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_witness);

                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }
            btnUploadWitness.Enabled = true;
            this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
            this.gvAddWitness.DataBind();
        }

        protected void btnUploadPolice_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathPolice + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdPolice.Value))
                    {
                        EditDataToTempPolice(Convert.ToInt32(hdPolice.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_PoliceReport);
                        hdPolice.Value = "";
                    }
                    else
                    {
                        AddDataToTempPolice(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_PoliceReport);
                    }
                }
            }
            this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
            this.gvPoliceReport.DataBind();
        }

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathPhoto + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdPhoto.Value))
                    {
                        EditDataToTempPhoto(Convert.ToInt32(hdPhoto.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_Photo);
                        hdPhoto.Value = "";
                    }
                    else
                    {
                        AddDataToTempPhoto(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_Photo);
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
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathSceneSketch + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdSceneSketch.Value))
                    {
                        EditDataToTempSceneSketch(Convert.ToInt32(hdSceneSketch.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_SceneSketch);
                        hdSceneSketch.Value = "";
                    }
                    else
                    {
                        AddDataToTempSceneSketch(c_file_guid + c_file_extension, c_file_name, SessionWrapper.session_SceneSketch);
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
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathExtenuatingcondition + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdExtenautingcond.Value))
                    {
                        EditDataToTempExtenautingcondition(Convert.ToInt32(hdExtenautingcond.Value), c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_ExtenuatingCondition);
                        hdExtenautingcond.Value = "";

                    }
                    else
                    {
                        AddDataToTempExtenautingcondition(c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_ExtenuatingCondition);
                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }
            this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenuatingcondition.DataBind();
        }

        protected void btnUploadEmployeeInterview_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                string c_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathEmployeeInterview + c_file_guid + c_file_extension));
                    if (!string.IsNullOrEmpty(hdEmployeeInterview.Value))
                    {
                        EditDataToTempEmployeeInterview(Convert.ToInt32(hdEmployeeInterview.Value), c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                        hdEmployeeInterview.Value = "";
                    }
                    else
                    {
                        AddDataToTempEmployeeInterview(c_file_guid + c_file_extension, c_file_name, txtName.Text, txtContactInfo.Value, SessionWrapper.session_EmployeeInterview);
                    }
                    txtName.Text = string.Empty;
                    txtContactInfo.Value = string.Empty;
                }
            }

            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }

        //witenss
        private DataTable tempWitness()
        {
            DataTable dtTempWitness = new DataTable();
            DataColumn dtTempWitnessColumn;
            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_witness_id_pk";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_case_id_fk";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_file_guid";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_file_name";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_name";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            dtTempWitnessColumn = new DataColumn();
            dtTempWitnessColumn.DataType = Type.GetType("System.String");
            dtTempWitnessColumn.ColumnName = "c_contact_info";
            dtTempWitness.Columns.Add(dtTempWitnessColumn);

            return dtTempWitness;
        }
        private void AddDataToTempWitness(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempWitness)
        {
            DataRow row;
            row = dtTempWitness.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempWitness.Rows.Add(row);
        }
        private void EditDataToTempWitness(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempWitness)
        {
            dtTempWitness.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempWitness.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempWitness.Rows[rowIndex]["c_name"] = c_name;
            dtTempWitness.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempWitness.AcceptChanges();
        }
        private void DeleteDataToTempWitness(int rowIndex, DataTable dtTempWitness)
        {
            dtTempWitness.Rows[rowIndex].Delete();
            dtTempWitness.AcceptChanges();
            this.gvAddWitness.DataSource = (SessionWrapper.session_witness).DefaultView;
            this.gvAddWitness.DataBind();
        }

        //photo
        private DataTable tempPhoto()
        {
            DataTable dtTempPhoto = new DataTable();
            DataColumn dtTempPhotoColumn;
            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_photo_id_pk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_case_id_fk";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_file_guid";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);

            dtTempPhotoColumn = new DataColumn();
            dtTempPhotoColumn.DataType = Type.GetType("System.String");
            dtTempPhotoColumn.ColumnName = "c_file_name";
            dtTempPhoto.Columns.Add(dtTempPhotoColumn);
            return dtTempPhoto;
        }
        private void AddDataToTempPhoto(string c_file_guid, string c_file_name, DataTable dtTempPhoto)
        {
            DataRow row;
            row = dtTempPhoto.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempPhoto.Rows.Add(row);
        }
        private void EditDataToTempPhoto(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempPhoto.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempPhoto.AcceptChanges();
        }
        private void DeleteDataToTempPhoto(int rowIndex, DataTable dtTempPhoto)
        {
            dtTempPhoto.Rows[rowIndex].Delete();
            dtTempPhoto.AcceptChanges();
            this.gvPhoto.DataSource = (SessionWrapper.session_Photo).DefaultView;
            this.gvPhoto.DataBind();
        }

        //policereport
        private DataTable tempPolice()
        {
            DataTable dtTempPoliceReport = new DataTable();
            DataColumn dtTempPoliceReportColumn;
            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_police_report_id_pk";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_case_id_fk";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_file_guid";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);

            dtTempPoliceReportColumn = new DataColumn();
            dtTempPoliceReportColumn.DataType = Type.GetType("System.String");
            dtTempPoliceReportColumn.ColumnName = "c_file_name";
            dtTempPoliceReport.Columns.Add(dtTempPoliceReportColumn);
            return dtTempPoliceReport;
        }

        private void AddDataToTempPolice(string c_file_guid, string c_file_name, DataTable dtTempPoliceReport)
        {
            DataRow row;
            row = dtTempPoliceReport.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempPoliceReport.Rows.Add(row);
        }
        private void EditDataToTempPolice(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempPoliceReport)
        {
            dtTempPoliceReport.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempPoliceReport.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempPoliceReport.AcceptChanges();
        }
        private void DeleteDataToTempPolice(int rowIndex, DataTable dtTempPoliceReport)
        {
            dtTempPoliceReport.Rows[rowIndex].Delete();
            dtTempPoliceReport.AcceptChanges();
            this.gvPoliceReport.DataSource = (SessionWrapper.session_PoliceReport).DefaultView;
            this.gvPoliceReport.DataBind();
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
            dtTempSceneSketchColumn.ColumnName = "c_case_id_fk";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_file_guid";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            dtTempSceneSketchColumn = new DataColumn();
            dtTempSceneSketchColumn.DataType = Type.GetType("System.String");
            dtTempSceneSketchColumn.ColumnName = "c_file_name";
            dtTempSceneSketch.Columns.Add(dtTempSceneSketchColumn);

            return dtTempSceneSketch;
        }
        private void AddDataToTempSceneSketch(string c_file_guid, string c_file_name, DataTable dtTempSceneSketch)
        {
            DataRow row;
            row = dtTempSceneSketch.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            dtTempSceneSketch.Rows.Add(row);
        }
        private void EditDataToTempSceneSketch(int rowIndex, string c_file_guid, string c_file_name, DataTable dtTempSceneSketch)
        {
            dtTempSceneSketch.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempSceneSketch.Rows[rowIndex]["c_file_name"] = c_file_name;
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
            dtTempExtenautingconditionColumn.ColumnName = "c_case_id_fk";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_file_guid";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_file_name";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_name";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            dtTempExtenautingconditionColumn = new DataColumn();
            dtTempExtenautingconditionColumn.DataType = Type.GetType("System.String");
            dtTempExtenautingconditionColumn.ColumnName = "c_contact_info";
            dtTempExtenautingcondition.Columns.Add(dtTempExtenautingconditionColumn);

            return dtTempExtenautingcondition;
        }
        private void AddDataToTempExtenautingcondition(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempExtenautingcondition)
        {
            DataRow row;
            row = dtTempExtenautingcondition.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempExtenautingcondition.Rows.Add(row);
        }
        private void EditDataToTempExtenautingcondition(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempExtenautingcondition.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempExtenautingcondition.Rows[rowIndex]["c_name"] = c_name;
            dtTempExtenautingcondition.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempExtenautingcondition.AcceptChanges();
        }
        private void DeleteDataToTempExtenautingcondition(int rowIndex, DataTable dtTempExtenautingcondition)
        {
            dtTempExtenautingcondition.Rows[rowIndex].Delete();
            dtTempExtenautingcondition.AcceptChanges();
            this.gvExtenuatingcondition.DataSource = (SessionWrapper.session_ExtenuatingCondition).DefaultView;
            this.gvExtenuatingcondition.DataBind();
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
            dtTempEmployeeInterviewColumn.ColumnName = "c_case_id_fk";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_file_guid";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_file_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_name";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            dtTempEmployeeInterviewColumn = new DataColumn();
            dtTempEmployeeInterviewColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeInterviewColumn.ColumnName = "c_contact_info";
            dtTempEmployeeInterview.Columns.Add(dtTempEmployeeInterviewColumn);

            return dtTempEmployeeInterview;
        }
        private void AddDataToTempEmployeeInterview(string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempEmployeeInterview)
        {
            DataRow row;
            row = dtTempEmployeeInterview.NewRow();
            row["c_file_guid"] = c_file_guid;
            row["c_file_name"] = c_file_name;
            row["c_name"] = c_name;
            row["c_contact_info"] = c_contact_info;
            dtTempEmployeeInterview.Rows.Add(row);
        }
        private void EditDataToTempEmployeeInterview(int rowIndex, string c_file_guid, string c_file_name, string c_name, string c_contact_info, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex]["c_file_guid"] = c_file_guid;
            dtTempEmployeeInterview.Rows[rowIndex]["c_file_name"] = c_file_name;
            dtTempEmployeeInterview.Rows[rowIndex]["c_name"] = c_name;
            dtTempEmployeeInterview.Rows[rowIndex]["c_contact_info"] = c_contact_info;
            dtTempEmployeeInterview.AcceptChanges();
        }
        private void DeleteDataToTempEmployeeInterview(int rowIndex, DataTable dtTempEmployeeInterview)
        {
            dtTempEmployeeInterview.Rows[rowIndex].Delete();
            dtTempEmployeeInterview.AcceptChanges();
            this.gvEmployeeInterview.DataSource = (SessionWrapper.session_EmployeeInterview).DefaultView;
            this.gvEmployeeInterview.DataBind();
        }

        protected void gvAddWitness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvAddWitness.DataKeys[rowIndex][0].ToString();
                hdWitness.Value = e.CommandArgument.ToString();
                txtName.Text = gvAddWitness.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvAddWitness.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "witness", "Showeditpopup('witness');", true);
                mpeWitness.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string witnessFileId = gvAddWitness.DataKeys[rowIndex][0].ToString();
                string witnessFileName = gvAddWitness.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_path + witnessFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + witnessFileName + "\"");
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
                DeleteDataToTempWitness(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_witness);
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

        protected void gvPoliceReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvPoliceReport.DataKeys[rowIndex][0].ToString();
                hdPolice.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "policereport", "Showeditpopup('policereport');", true);
                mpePoliceReport.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string policeFileId = gvPoliceReport.DataKeys[rowIndex][0].ToString();
                string policeFileName = gvPoliceReport.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPolice + policeFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + policeFileName + "\"");
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
                DeleteDataToTempPolice(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.session_PoliceReport);
            }
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

        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                hdSceneSketch.Value = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scenesketch", "Showeditpopup('scenesketch');", true);
                mpeSceneSketch.Show();
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

        protected void gvExtenuatingcondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                hdExtenautingcond.Value = e.CommandArgument.ToString();
                txtName.Text = gvExtenuatingcondition.DataKeys[rowIndex][2].ToString();
                txtContactInfo.Value = gvExtenuatingcondition.DataKeys[rowIndex][3].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "extenuatingcondition", "Showeditpopup('extenuatingcondition');", true);
                mpeExtenautingCondition.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingconditionFileId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                string extenuatingConditionFileName = gvExtenuatingcondition.DataKeys[rowIndex][1].ToString();
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
        private string GetBracketText(string strCaseCategory)
        {
            string regularExpressionPattern = @"\((.*?)\)";
            string inputText = strCaseCategory;
            Regex re = new Regex(regularExpressionPattern);
            string strresult = string.Empty;
            foreach (Match m in re.Matches(inputText))
            {
                strresult = m.Value;
            }
            strresult = strresult.Replace("(", "").Replace(")", "");
            return strresult;
        }

        protected void gvAddWitness_RowEditing(object sender, GridViewEditEventArgs e)
        {

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
        protected void gvPoliceReport_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPhoto_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSceneSketch_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvExtenuatingcondition_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvEmployeeInterview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        /// <summary>
        /// on save case
        /// </summary>
        private void CreateNewCase()
        {
            try
            {
                ComplianceDAO insertCase = new ComplianceDAO();

                insertCase.c_case_id_pk = Guid.NewGuid().ToString();
                insertCase.u_user_id_fk = SessionWrapper.u_userid;
                //insertCase.c_case_number = lblCaseNumber.Text;
                insertCase.c_case_title = txtCaseTitle.Text;
                insertCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
                insertCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                insertCase.c_case_status = ddlCaseStatus.SelectedValue;
                insertCase.c_employee_name = txtEmployeeName.Text;

                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                insertCase.c_employee_dob = birthDate;

                insertCase.c_date_in_title =  Convert.ToDateTime(txtDateInTitle.Text,culture);

                int hireday = Convert.ToInt32(doh_hire_day.Items[doh_hire_day.SelectedIndex].Value);
                int hiremonth = Convert.ToInt16(ddlHireMonth.SelectedValue);
                int hireyear = Convert.ToInt32(ddlHireYear.SelectedValue);
                DateTime hireDate = new DateTime(hireyear, hiremonth, hireday);
                insertCase.c_employee_hire_date = hireDate;


                //insertCase.c_employee_dob = Convert.ToDateTime(txtDateOfBirth.Text, culture);
                //insertCase.c_employee_hire_date = Convert.ToDateTime(txtEmployeHireDate.Text, culture);
                insertCase.c_employee_id = txtEmployeeId.Text;
                insertCase.c_ssn = txtLastFourDigitOfSSN.Text;
                insertCase.c_supervisor = txtSupervisor.Text;
                insertCase.c_incident_location = txtIncidentLocation.Text;
                insertCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                insertCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                insertCase.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                insertCase.c_note = txtNote.Text;
                //insertCase.c_root_cause_analysic_info = txtRootCauseAnalysisDetails.Text;
                //insertCase.c_corrective_action_info = txtCorrectiveActionDetails.Text;

                insertCase.c_custom_01 = txtCustom01.Text;
                insertCase.c_custom_02 = txtCustom02.Text;
                insertCase.c_custom_03 = txtCustom03.Text;
                insertCase.c_custom_04 = txtCustom04.Text;
                insertCase.c_custom_05 = txtCustom05.Text;
                insertCase.c_custom_06 = txtCustom06.Text;
                insertCase.c_custom_07 = txtCustom07.Text;
                insertCase.c_custom_08 = txtCustom08.Text;
                insertCase.c_custom_09 = txtCustom09.Text;
                insertCase.c_custom_10 = txtCustom10.Text;
                insertCase.c_custom_11 = txtCustom11.Text;
                insertCase.c_custom_12 = txtCustom12.Text;
                insertCase.c_custom_13 = txtCustom13.Text;
                insertCase.c_timezoneId = ddlTimezone.SelectedValue;
                insertCase.c_case_date = (DateTime)SessionWrapper.casedate;
                insertCase.c_miris_witness = ConvertDataTableToXml(SessionWrapper.session_witness);
                insertCase.c_miris_photo = ConvertDataTableToXml(SessionWrapper.session_Photo);
                insertCase.c_miris_police_report = ConvertDataTableToXml(SessionWrapper.session_PoliceReport);
                insertCase.c_miris_scene_sketch = ConvertDataTableToXml(SessionWrapper.session_SceneSketch);
                insertCase.c_miris_employee_interview = ConvertDataTableToXml(SessionWrapper.session_EmployeeInterview);
                insertCase.c_miris_extenuating_condition = ConvertDataTableToXml(SessionWrapper.session_ExtenuatingCondition);

                //newly added columns

                insertCase.c_case_desc_vehicle_01_fk = ddlVehicle01.SelectedValue;
                insertCase.c_case_desc_vehicle_02_fk = ddlVehicle02.SelectedValue;

                insertCase.c_case_desc_vehicle_id = txtVehicleId.Text;
                insertCase.c_case_desc_vehicle_vin = txtVIN.Text;
                insertCase.c_case_desc_licence_number = txtLicenseNumber.Text;
                insertCase.c_case_desc_vehicle_make = txtVehicleMake.Text;
                insertCase.c_case_desc_vehicle_model = txtVehicleModel.Text;
                insertCase.c_case_desc_vehicle_type_fk = ddlVehicleType.Text;
                insertCase.c_case_desc_year = txtYear.Text;
                insertCase.c_case_desc_state = txtState.Text;
                insertCase.c_case_desc_company_vehicle_struck_fk = ddlCompanyVehicleStruck.SelectedValue;
                insertCase.c_case_desc_company_vehicle_struck_by_fk = ddlCompanyVehicleStruckBy.SelectedValue;
                insertCase.c_case_desc_non_collision = chkNonCollision.Checked;
                insertCase.c_case_desc_non_collision_text = txtNonCollision.Text;

                insertCase.c_case_desc_vehicle_02_id = txtVehicleId02.Text;
                insertCase.c_case_desc_vehicle_02_vin = txtVin02.Text;
                insertCase.c_case_desc_licence_02_number = txtLicenseNumber02.Text;
                insertCase.c_case_desc_vehicle_02_make = txtVehicleMake02.Text;
                insertCase.c_case_desc_vehicle_02_model = txtModel02.Text;
                insertCase.c_case_desc_vehicle_02_type_fk = ddlVehicleType02.SelectedValue;
                insertCase.c_case_desc_vehicle_02_year = txtYear02.Text;
                insertCase.c_case_desc_vehicle_02_state = txtState02.Text;


                if (VehiclePanel.Controls.Count > 1)
                {
                    ucmv_01 vehicle03 = (ucmv_01)VehiclePanel.Controls[1];
                    if (vehicle03 != null)
                    {
                        insertCase.c_case_desc_vehicle_03_fk = vehicle03.ddlVehicle;
                        insertCase.c_case_desc_vehicle_03_id = vehicle03.VechicleId;
                        insertCase.c_case_desc_vehicle_03_vin = vehicle03.VIN;
                        insertCase.c_case_desc_licence_03_number = vehicle03.LicenseNumber;
                        insertCase.c_case_desc_vehicle_03_make = vehicle03.VehicleMake;
                        insertCase.c_case_desc_vehicle_03_model = vehicle03.VehicleModel;
                        insertCase.c_case_desc_vehicle_03_type_fk = vehicle03.ddlType;
                        insertCase.c_case_desc_vehicle_03_year = vehicle03.Year;
                        insertCase.c_case_desc_vehicle_03_state = vehicle03.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_03_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_03_id = string.Empty;
                    insertCase.c_case_desc_vehicle_03_vin = string.Empty;
                    insertCase.c_case_desc_licence_03_number = string.Empty;
                    insertCase.c_case_desc_vehicle_03_make = string.Empty;
                    insertCase.c_case_desc_vehicle_03_model = string.Empty;
                    insertCase.c_case_desc_vehicle_03_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_03_year = string.Empty;
                    insertCase.c_case_desc_vehicle_03_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 2)
                {
                    ucmv_01 vehicle04 = (ucmv_01)VehiclePanel.Controls[2];
                    if (vehicle04 != null)
                    {
                        insertCase.c_case_desc_vehicle_04_fk = vehicle04.ddlVehicle;
                        insertCase.c_case_desc_vehicle_04_id = vehicle04.VechicleId;
                        insertCase.c_case_desc_vehicle_04_vin = vehicle04.VIN;
                        insertCase.c_case_desc_licence_04_number = vehicle04.LicenseNumber;
                        insertCase.c_case_desc_vehicle_04_make = vehicle04.VehicleMake;
                        insertCase.c_case_desc_vehicle_04_model = vehicle04.VehicleModel;
                        insertCase.c_case_desc_vehicle_04_type_fk = vehicle04.ddlType;
                        insertCase.c_case_desc_vehicle_04_year = vehicle04.Year;
                        insertCase.c_case_desc_vehicle_04_state = vehicle04.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_04_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_04_id = string.Empty;
                    insertCase.c_case_desc_vehicle_04_vin = string.Empty;
                    insertCase.c_case_desc_licence_04_number = string.Empty;
                    insertCase.c_case_desc_vehicle_04_make = string.Empty;
                    insertCase.c_case_desc_vehicle_04_model = string.Empty;
                    insertCase.c_case_desc_vehicle_04_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_04_year = string.Empty;
                    insertCase.c_case_desc_vehicle_04_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 3)
                {
                    ucmv_01 vehicle05 = (ucmv_01)VehiclePanel.Controls[3];
                    if (vehicle05 != null)
                    {
                        insertCase.c_case_desc_vehicle_05_fk = vehicle05.ddlVehicle;
                        insertCase.c_case_desc_vehicle_05_id = vehicle05.VechicleId;
                        insertCase.c_case_desc_vehicle_05_vin = vehicle05.VIN;
                        insertCase.c_case_desc_licence_05_number = vehicle05.LicenseNumber;
                        insertCase.c_case_desc_vehicle_05_make = vehicle05.VehicleMake;
                        insertCase.c_case_desc_vehicle_05_model = vehicle05.VehicleModel;
                        insertCase.c_case_desc_vehicle_05_type_fk = vehicle05.ddlType;
                        insertCase.c_case_desc_vehicle_05_year = vehicle05.Year;
                        insertCase.c_case_desc_vehicle_05_state = vehicle05.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_05_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_05_id = string.Empty;
                    insertCase.c_case_desc_vehicle_05_vin = string.Empty;
                    insertCase.c_case_desc_licence_05_number = string.Empty;
                    insertCase.c_case_desc_vehicle_05_make = string.Empty;
                    insertCase.c_case_desc_vehicle_05_model = string.Empty;
                    insertCase.c_case_desc_vehicle_05_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_05_year = string.Empty;
                    insertCase.c_case_desc_vehicle_05_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 4)
                {
                    ucmv_01 vehicle06 = (ucmv_01)VehiclePanel.Controls[4];
                    if (vehicle06 != null)
                    {
                        insertCase.c_case_desc_vehicle_06_fk = vehicle06.ddlVehicle;
                        insertCase.c_case_desc_vehicle_06_id = vehicle06.VechicleId;
                        insertCase.c_case_desc_vehicle_06_vin = vehicle06.VIN;
                        insertCase.c_case_desc_licence_06_number = vehicle06.LicenseNumber;
                        insertCase.c_case_desc_vehicle_06_make = vehicle06.VehicleMake;
                        insertCase.c_case_desc_vehicle_06_model = vehicle06.VehicleModel;
                        insertCase.c_case_desc_vehicle_06_type_fk = vehicle06.ddlType;
                        insertCase.c_case_desc_vehicle_06_year = vehicle06.Year;
                        insertCase.c_case_desc_vehicle_06_state = vehicle06.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_06_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_06_id = string.Empty;
                    insertCase.c_case_desc_vehicle_06_vin = string.Empty;
                    insertCase.c_case_desc_licence_06_number = string.Empty;
                    insertCase.c_case_desc_vehicle_06_make = string.Empty;
                    insertCase.c_case_desc_vehicle_06_model = string.Empty;
                    insertCase.c_case_desc_vehicle_06_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_06_year = string.Empty;
                    insertCase.c_case_desc_vehicle_06_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 5)
                {
                    ucmv_01 vehicle07 = (ucmv_01)VehiclePanel.Controls[5];
                    if (vehicle07 != null)
                    {
                        insertCase.c_case_desc_vehicle_07_fk = vehicle07.ddlVehicle;
                        insertCase.c_case_desc_vehicle_07_id = vehicle07.VechicleId;
                        insertCase.c_case_desc_vehicle_07_vin = vehicle07.VIN;
                        insertCase.c_case_desc_licence_07_number = vehicle07.LicenseNumber;
                        insertCase.c_case_desc_vehicle_07_make = vehicle07.VehicleMake;
                        insertCase.c_case_desc_vehicle_07_model = vehicle07.VehicleModel;
                        insertCase.c_case_desc_vehicle_07_type_fk = vehicle07.ddlType;
                        insertCase.c_case_desc_vehicle_07_year = vehicle07.Year;
                        insertCase.c_case_desc_vehicle_07_state = vehicle07.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_07_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_07_id = string.Empty;
                    insertCase.c_case_desc_vehicle_07_vin = string.Empty;
                    insertCase.c_case_desc_licence_07_number = string.Empty;
                    insertCase.c_case_desc_vehicle_07_make = string.Empty;
                    insertCase.c_case_desc_vehicle_07_model = string.Empty;
                    insertCase.c_case_desc_vehicle_07_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_07_year = string.Empty;
                    insertCase.c_case_desc_vehicle_07_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 6)
                {
                    ucmv_01 vehicle08 = (ucmv_01)VehiclePanel.Controls[6];
                    if (vehicle08 != null)
                    {
                        insertCase.c_case_desc_vehicle_08_fk = vehicle08.ddlVehicle;
                        insertCase.c_case_desc_vehicle_08_id = vehicle08.VechicleId;
                        insertCase.c_case_desc_vehicle_08_vin = vehicle08.VIN;
                        insertCase.c_case_desc_licence_08_number = vehicle08.LicenseNumber;
                        insertCase.c_case_desc_vehicle_08_make = vehicle08.VehicleMake;
                        insertCase.c_case_desc_vehicle_08_model = vehicle08.VehicleModel;
                        insertCase.c_case_desc_vehicle_08_type_fk = vehicle08.ddlType;
                        insertCase.c_case_desc_vehicle_08_year = vehicle08.Year;
                        insertCase.c_case_desc_vehicle_08_state = vehicle08.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_08_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_08_id = string.Empty;
                    insertCase.c_case_desc_vehicle_08_vin = string.Empty;
                    insertCase.c_case_desc_licence_08_number = string.Empty;
                    insertCase.c_case_desc_vehicle_08_make = string.Empty;
                    insertCase.c_case_desc_vehicle_08_model = string.Empty;
                    insertCase.c_case_desc_vehicle_08_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_08_year = string.Empty;
                    insertCase.c_case_desc_vehicle_08_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 7)
                {
                    ucmv_01 vehicle09 = (ucmv_01)VehiclePanel.Controls[7];
                    if (vehicle09 != null)
                    {
                        insertCase.c_case_desc_vehicle_09_fk = vehicle09.ddlVehicle;
                        insertCase.c_case_desc_vehicle_09_id = vehicle09.VechicleId;
                        insertCase.c_case_desc_vehicle_09_vin = vehicle09.VIN;
                        insertCase.c_case_desc_licence_09_number = vehicle09.LicenseNumber;
                        insertCase.c_case_desc_vehicle_09_make = vehicle09.VehicleMake;
                        insertCase.c_case_desc_vehicle_09_model = vehicle09.VehicleModel;
                        insertCase.c_case_desc_vehicle_09_type_fk = vehicle09.ddlType;
                        insertCase.c_case_desc_vehicle_09_year = vehicle09.Year;
                        insertCase.c_case_desc_vehicle_09_state = vehicle09.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_09_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_09_id = string.Empty;
                    insertCase.c_case_desc_vehicle_09_vin = string.Empty;
                    insertCase.c_case_desc_licence_09_number = string.Empty;
                    insertCase.c_case_desc_vehicle_09_make = string.Empty;
                    insertCase.c_case_desc_vehicle_09_model = string.Empty;
                    insertCase.c_case_desc_vehicle_09_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_09_year = string.Empty;
                    insertCase.c_case_desc_vehicle_09_state = string.Empty;
                }
                if (VehiclePanel.Controls.Count > 8)
                {
                    ucmv_01 vehicle10 = (ucmv_01)VehiclePanel.Controls[8];
                    if (vehicle10 != null)
                    {
                        insertCase.c_case_desc_vehicle_10_fk = vehicle10.ddlVehicle;
                        insertCase.c_case_desc_vehicle_10_id = vehicle10.VechicleId;
                        insertCase.c_case_desc_vehicle_10_vin = vehicle10.VIN;
                        insertCase.c_case_desc_licence_10_number = vehicle10.LicenseNumber;
                        insertCase.c_case_desc_vehicle_10_make = vehicle10.VehicleMake;
                        insertCase.c_case_desc_vehicle_10_model = vehicle10.VehicleModel;
                        insertCase.c_case_desc_vehicle_10_type_fk = vehicle10.ddlType;
                        insertCase.c_case_desc_vehicle_10_year = vehicle10.Year;
                        insertCase.c_case_desc_vehicle_10_state = vehicle10.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_10_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_10_id = string.Empty;
                    insertCase.c_case_desc_vehicle_10_vin = string.Empty;
                    insertCase.c_case_desc_licence_10_number = string.Empty;
                    insertCase.c_case_desc_vehicle_10_make = string.Empty;
                    insertCase.c_case_desc_vehicle_10_model = string.Empty;
                    insertCase.c_case_desc_vehicle_10_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_10_year = string.Empty;
                    insertCase.c_case_desc_vehicle_10_state = string.Empty;
                }

                insertCase.c_case_detail_drivers_lic = txtDriversLic.Text;
                insertCase.c_case_detail_state_and_class = txtStateandClass.Text;
                DateTime? expiredate = null;
                DateTime tempexpiredate;
                if (DateTime.TryParseExact(txtExpireDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempexpiredate))
                {
                    expiredate = tempexpiredate;
                }
                insertCase.c_case_detail_expire_date = expiredate;
                insertCase.c_case_detail_address = txtAddress.Text;
                insertCase.c_case_detail_city = txtCity.Text;
                insertCase.c_case_detail_state = txtCaseState.Text;
                insertCase.c_case_detail_nearest_cross_street = txtNearestCrossStreet.Text;
                insertCase.c_case_detail_type_of_roadway = txtTypeofRoadway.Text;
                insertCase.c_case_detail_road_condition_fk = ddlRoadCondition.SelectedValue;

                DateTime? timeofday = null;
                DateTime temptimeofday;
                if (DateTime.TryParseExact(txtTimeofDay.Text, "h:mm tt", culture, DateTimeStyles.None, out temptimeofday))
                {
                    timeofday = temptimeofday;
                }

                insertCase.c_case_detail_time_of_day = timeofday;

                // here we need to add one column
                insertCase.c_case_detail_weather_fk = ddlWeather.SelectedValue;
                insertCase.c_case_detail_traffic_condition_fk = ddlTrafficCondition.SelectedValue;
                insertCase.c_case_detail_traffic_controls_fk = ddlTrafficControls.SelectedValue;
                insertCase.c_case_detail_oprating_speed = txtOperatingSpeed.Text;  //doubt
                insertCase.c_case_detail_speed_limit = txtSpeedLimit.Text;  //doubt
                insertCase.c_case_detail_vehicle_struck_fk = ddlVehicleStruck.SelectedValue;
                insertCase.c_case_detail_vehicle_struck_by_fk = ddlVehicleStruckBy.SelectedValue;
                insertCase.c_case_detail_collision_type_fk = ddlCollisionType.SelectedValue;
                insertCase.c_case_detail_collision_location_fk = ddlCollisionLocation.SelectedValue;
                insertCase.c_case_detail_collision_direction_fk = ddlCollisionDirection.SelectedValue;
                insertCase.c_case_detail_non_collision_type_fk = ddlNonCollisionType.SelectedValue;
                insertCase.c_case_detail_number_of_vehicle_involved = txtNumberofVehicleInvolved.Text;
                insertCase.c_case_detail_number_of_vehicle_towed = txtNumberofVehicletowed.Text;
                insertCase.c_case_detail_number_of_people_injured = txtNoofPeopleInjured.Text;
                insertCase.c_case_detail_number_of_people_killed = txtNoofPeopleKilled.Text;
                if (rblCituationIssued.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_cituation_issued = true;
                }
                else
                {
                    insertCase.c_case_detail_cituation_issued = false;
                }
                insertCase.c_case_detail_at_whom = txtAtWhom.Text;
                if (rblAtfault.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_at_fault = true;
                }
                else
                {
                    insertCase.c_case_detail_at_fault = false;
                }
                if (rblContributory.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_contributory = true;
                }
                else
                {
                    insertCase.c_case_detail_contributory = false;
                }

                insertCase.c_case_detail_gross_vehicle_weight = txtGrossVehicleWeight.Text;
                insertCase.c_case_detail_combined_gross_vehicle_weight = txtCombinedGrossVehicleWeight.Text;
                if (rblDotVehicle.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_dot_vehicle = true;
                }
                else
                {
                    insertCase.c_case_detail_dot_vehicle = false;
                }
                if (rblDotDriver.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_dot_driver = true;
                }
                else
                {
                    insertCase.c_case_detail_dot_driver = false;
                }
                if (rblSeatBeltUsed.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_seat_belt_used = true;
                }
                else
                {
                    insertCase.c_case_detail_seat_belt_used = false;
                }
                if (rblAirbagEquipped.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_air_bag_eqiupped = true;
                }
                else
                {
                    insertCase.c_case_detail_air_bag_eqiupped = false;
                }
                if (rblAirBagDeployed.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_air_bag_deployed = true;
                }
                else
                {
                    insertCase.c_case_detail_air_bag_deployed = false;
                }
                if (rblCellphoneinUse.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_cellphone_in_use = true;
                }
                else
                {
                    insertCase.c_case_detail_cellphone_in_use = false;
                }
                if (rblComputerInUse.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_computer_in_use = true;
                }
                else
                {
                    insertCase.c_case_detail_computer_in_use = false;
                }
                if (rblSpecialEquipment.SelectedValue == "Yes")
                {

                    insertCase.c_case_detail_special_equipment = true;
                }
                else
                {
                    insertCase.c_case_detail_special_equipment = false;
                }

                insertCase.c_case_detail_special_equipment_text = txtSpecialEquibment.Text;
                insertCase.c_case_detail_location_of_impact_fk = ddlLocationofImpact.SelectedValue;
                if (rblDriverInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    insertCase.c_case_detail_driver_injured = true;
                }
                else
                {
                    insertCase.c_case_detail_driver_injured = false;
                }
                if (rblPassengerInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    insertCase.c_case_detail_passenger_injured = true;
                }
                else
                {
                    insertCase.c_case_detail_passenger_injured = false;
                }

                if (rblFatality.SelectedValue == "Yes")
                {
                    insertCase.c_case_desc_was_fatality = true;
                }
                else
                {
                    insertCase.c_case_desc_was_fatality = false;
                }
                if (rblPublicVehicleInvolved.SelectedValue == "Yes")
                {
                    insertCase.c_case_desc_public_vehicle_involved = true;
                }
                else
                {
                    insertCase.c_case_desc_public_vehicle_involved = false;
                }

                insertCase.c_case_detail_damage_heavy = txtHeavyDamage.InnerText;
                insertCase.c_case_detail_damage_moderate = txtModerateDamage.InnerText;
                insertCase.c_case_detail_damage_light = txtLightDamage.InnerText;
                //Public Vehicle Information
                insertCase.c_pub_vehicle_driver_name = txtDriverName.Text;
                insertCase.c_pub_vehicle_driver_address = txtDriverAddress.Text;
                insertCase.c_pub_vehicle_driver_contact = txtDriverContact.Text;
                insertCase.c_pub_vehicle_owner_name = txtOwnerName.Text;
                insertCase.c_pub_vehicle_owner_address = txtOwnerAddress.Text;
                insertCase.c_pub_vehicle_owner_contact = txtOwnerContact.Text;
                insertCase.c_pub_vehicle_vehicle_id = txtPublicVehicleID.Text;
                insertCase.c_pub_vehicle_vehicle_vin = txtPublicVehicleVIN.Text;
                insertCase.c_pub_vehicle_licence_number = txtPublicLicenseNumber.Text;
                insertCase.c_pub_vehicle_vehicle_make = txtPublicVehicleMake.Text;
                insertCase.c_pub_vehicle_vehicle_model = txtPublicVehicleModel.Text;
                insertCase.c_pub_vehicle_vehicle_type_fk = ddlPublicVehicleType.SelectedValue;
                insertCase.c_pub_vehicle_year = txtPublicYear.Text;
                insertCase.c_pub_vehicle_state = txtPublicState.Text;
                insertCase.c_pub_vehicle_gross_vehicle_weight = txtPublicGrossWeight.Text;
                insertCase.c_pub_vehicle_combined_gross_vehicle_weight = txtPublicCombinedVehicleWeight.Text;
                if (rblPublicDotVehicle.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_dot_vehicle = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_dot_vehicle = false;
                }
                if (rblPublicDotDriver.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_dot_driver = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_dot_driver = false;
                }
                if (rblPublicSeatBeltUsed.SelectedValue == "Yes")
                {

                    insertCase.c_pub_vehicle_seat_belt_used = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_seat_belt_used = false;
                }
                if (rblPublicAirBagEquipped.SelectedValue == "Yes")
                {

                    insertCase.c_pub_vehicle_air_bag_eqiupped = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_air_bag_eqiupped = false;
                }
                if (rblPublicAirBagDeployed.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_air_bag_deployed = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_air_bag_deployed = false;
                }
                if (rblPublicCellphoneinUse.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_cellphone_in_use = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_cellphone_in_use = false;
                }
                if (rblPublicComputerInUse.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_computer_in_use = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_computer_in_use = false;
                }
                if (rblPublicSpecialEquipment.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_special_equipment = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_special_equipment = false;
                }

                insertCase.c_pub_vehicle_passenger_injured_text = txtPublicPassengerInjured.Text;
                insertCase.c_pub_vehicle_driver_injured_text = txtPublicDriverInjured.Text;


                insertCase.c_pub_vehicle_special_equipment_text = txtPublicSpecialEquipment.Text;
                insertCase.c_pub_vehicle_location_of_impact_fk = ddlPublicLocationOfImpact.SelectedValue;
                if (rblPublicDriverInjured.SelectedValue == "Yes")// need to add some fields
                {
                    insertCase.c_pub_vehicle_driver_injured = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_driver_injured = false;
                }
                if (rblPublicPassengerInjured.SelectedValue == "Yes")// need to add some fields
                {
                    insertCase.c_pub_vehicle_passenger_injured = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_passenger_injured = false;
                }


                insertCase.c_pub_vehicle_number_of_total_vehicle_injured = txtTotalvehicleOccupant.Text;
                insertCase.c_pub_vehicle_damage_heavy = txtPublicHeavyDamage.InnerText;
                insertCase.c_pub_vehicle_damage_moderate = txtPublicModerateDamage.InnerText;
                insertCase.c_pub_vehicle_damage_light = txtPubliclightDamage.InnerText;
                //Pedestrain Incident
                insertCase.c_pedestrain_name = txtNameofPedestrian.Text;
                insertCase.c_pedestrain_address = txtPedestrianAddress.Text;
                insertCase.c_pedestrain_phone = txtPedestrianPhone.Text;
                insertCase.c_pedestrain_sex = txtPedestrianSex.Text;
                insertCase.c_pedestrain_age = txtPedestrainAge.Text;
                insertCase.c_pedestrain_collision_type_fk = ddlPedestrainCollisionType.SelectedValue;
                insertCase.c_pedestrain_description = txtPedestrianDescription.InnerText;
                //BICycle Incident
                insertCase.c_bicycle_person_name = txtBicycleNameofPerson.Text;
                insertCase.c_bicycle_person_address = txtBicyclePersonAddress.Text;
                insertCase.c_bicycle_person_phone = txtBicyclePersonPhone.Text;
                insertCase.c_bicycle_person_sex = txtBicyblePersonSex.Text;
                insertCase.c_bicycle_person_age = txtBicycleAge.Text;
                insertCase.c_bicycle_person_collision_type_fk = ddlBicycleCollisionType.SelectedValue;
                insertCase.c_bicycle_person_description = txtBicycleIncidentDesc.InnerText;
                //Animal Incident
                insertCase.c_animal_name = txtAnimalName.Text;
                insertCase.c_animal_place = txtPlace.Text;
                insertCase.c_animal_collision_type_fk = ddlAnimalCollisionType.SelectedValue;
                insertCase.c_animal_description = txtAnimalDescription.InnerText;
                //Fixed Object Incident
                insertCase.c_fixed_object_property_name = txtPropertyOwner.Text;
                insertCase.c_fixed_object_address = txtPropertyAddress.Text;
                insertCase.c_fixed_object_contact_info = txtContactInformation.Text;
                insertCase.c_fixed_object_collision_type_fk = ddlPropertyCollisionType.SelectedValue;
                insertCase.c_fixed_object_description = txtPropertyDesc.InnerText;
                insertCase.c_fixed_object_property_description = txtPhysicalPropertyDesc.InnerText;


                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    DataTable dtCaseId = new DataTable();
                    miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                    insertCase.c_case_number = miris.c_case_number;

                    
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message);
                        }
                    }
                }

                int error = ComplianceBLL.InsertCaseMV(insertCase);
                urc1.UpdateRac(insertCase.c_case_id_pk);
                if (error != -1)
                {
                    Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(insertCase.c_case_id_pk) + "&Succ=" + SecurityCenter.EncryptText("insert"), false);
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_date_not_inserted_error_wrong");
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
                        Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message);
                    }
                }
            }

        }

        protected void btnSavenewcase_header_Click(object sender, EventArgs e)
        {
            CreateNewCase();
        }

        protected void btnSaveNewCase_footer_Click(object sender, EventArgs e)
        {
            CreateNewCase();
        }

        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCaseMV(caseid);
                txtDateInTitle.Text = miris.c_date_in_title == null ? "" : miris.c_date_in_title.Value.ToString("MM/dd/yyyy");
                ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(miris.c_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblCaseNumber.Text = miris.c_case_number;
                txtCaseTitle.Text = miris.c_case_title + "_copy";
                ddlCaseCategory.SelectedValue = miris.c_case_category_value;
                //ViewState["CaseCategory"] = ddlCaseCategory.SelectedValue;
                ddlCaseTypes.SelectedValue = miris.c_case_type_value;
                ddlCaseStatus.SelectedValue = miris.c_case_status_value;
                txtEmployeeName.Text = miris.c_employee_name;

                dob_day.SelectedIndex = miris.c_employee_dob.Day;
                ddlMonth.SelectedValue = miris.c_employee_dob.Month.ToString();
                ddlYear.SelectedValue = miris.c_employee_dob.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "dob", "checkdateofbirth();", true);

                doh_hire_day.SelectedIndex = miris.c_employee_hire_date.Day;
                ddlHireMonth.SelectedValue = miris.c_employee_hire_date.Month.ToString();
                ddlHireYear.SelectedValue = miris.c_employee_hire_date.Year.ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "hiredate", "checkhiredate();", true);

                //txtDateOfBirth.Text = Convert.ToDateTime(miris.c_employee_dob, culture).ToString("MM/dd/yyyy");
                //txtEmployeHireDate.Text = Convert.ToDateTime(miris.c_employee_hire_date, culture).ToString("MM/dd/yyyy");
                txtEmployeeId.Text = miris.c_employee_id;
                txtLastFourDigitOfSSN.Text = miris.c_ssn;
                txtSupervisor.Text = miris.c_supervisor;
               txtIncidentLocation.Text = miris.c_incident_location;
                txtIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date, culture).ToString("MM/dd/yyyy");
                IncidentTime.Date = miris.c_incident_time;
                IncidentTime.SetTime(miris.incident_HH, miris.incident_MM, IncidentTime.AmPm);
                ddlEmployeeReportLocation.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                {
                    s_establishment_id_pk = "",
                    s_establishment_city = "",
                    s_establishment_name = "",
                    s_establishment_status_id_fk = "app_ddl_active_text"
                });

                ddlEmployeeReportLocation.DataTextField = "s_establishment_name";
                ddlEmployeeReportLocation.DataValueField = "s_establishment_system_id_pk";
                ddlEmployeeReportLocation.DataBind();
                ddlEmployeeReportLocation.Items.Insert(0, new ListItem("", ""));
                ddlEmployeeReportLocation.SelectedValue = miris.c_employee_report_location;
                txtNote.Text = miris.c_note;
                //txtRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                //txtCorrectiveActionDetails.Text = miris.c_corrective_action_info;
                //ddlCaseOutCome.SelectedValue = miris.c_osha_300_case_outcome_value;
                //txtDaysAwayFromWork.Text = Convert.ToInt32(miris.c_osha_300_days_away_from_work).ToString();
                //if (!string.IsNullOrEmpty(miris.c_osha_300_date_of_death.ToString()))
                //{
                //    txtDateOfDeath.Text = Convert.ToDateTime(miris.c_osha_300_date_of_death, culture).ToString("MM/dd/yyyy");
                //}
                //ddlTypeOfIllness.SelectedValue = miris.c_osha_300_type_of_illness_value;
                //txtDaysOfRestrictions.Text = Convert.ToInt32(miris.c_osha_300_days_of_restriction).ToString();
                //txtOSHA300info.Text = miris.c_osha_300_info;
                //ddlWorkerGender.SelectedValue = miris.c_osha_301_worker_gender;
                //if (!string.IsNullOrEmpty(miris.c_osha_301_work_start_time.ToString()))
                //{
                //    WorkStartTime.Date = Convert.ToDateTime(miris.c_osha_301_work_start_time);
                //    WorkStartTime.SetTime(miris.workstart_HH, miris.workstart_MM, WorkStartTime.AmPm);
                //    //txtWorkStartTime.Text= Convert.ToDateTime(miris.c_osha_301_work_start_time).ToShortDateString();
                //}
                //txtPhysician.Text = miris.c_osha_301_physician;
                //txtTreatMentFacility.Text = miris.c_osha_301_treatment_facilities;
                //chkEmergencyRoom.Checked = miris.c_osha_301_emergency_room;
                //chkHospitalized.Checked = miris.c_osha_301_hospitalized;
                //txtAddress1.Text = miris.c_osha_301_address1;
                //txtAddress2.Text = miris.c_osha_301_address2;
                //txtAddress3.Text = miris.c_osha_301_address3;
                //txtCity.Text = miris.c_osha_301_city;
                //txtState.Text = miris.c_osha_301_state;
                //txtZip.Text = miris.c_osha_301_zip;
                //txtOSHA301Info1.Text = miris.c_osha_301_info_1;
                //txtOSHA301Info2.Text = miris.c_osha_301_info_2;
                //txtOSHA301Info3.Text = miris.c_osha_301_info_3;
                //txtOSHA301Info4.Text = miris.c_osha_301_info_4;
                txtCustom01.Text = miris.c_custom_01;
                txtCustom02.Text = miris.c_custom_02;
                txtCustom03.Text = miris.c_custom_03;
                txtCustom04.Text = miris.c_custom_04;
                txtCustom05.Text = miris.c_custom_05;
                txtCustom06.Text = miris.c_custom_06;
                txtCustom07.Text = miris.c_custom_07;
                txtCustom08.Text = miris.c_custom_08;
                txtCustom09.Text = miris.c_custom_09;
                txtCustom10.Text = miris.c_custom_10;
                txtCustom11.Text = miris.c_custom_11;
                txtCustom12.Text = miris.c_custom_12;
                txtCustom13.Text = miris.c_custom_13;


                ddlVehicle01.SelectedValue = miris.c_case_desc_vehicle_01_fk;
                ddlVehicle02.SelectedValue = miris.c_case_desc_vehicle_02_fk;

                txtVehicleId.Text = miris.c_case_desc_vehicle_id;
                txtVIN.Text = miris.c_case_desc_vehicle_vin;
                txtLicenseNumber.Text = miris.c_case_desc_licence_number;
                txtVehicleMake.Text = miris.c_case_desc_vehicle_make;
                txtVehicleModel.Text = miris.c_case_desc_vehicle_model;
                ddlVehicleType.Text = miris.c_case_desc_vehicle_type_fk;
                txtYear.Text = miris.c_case_desc_year;
                txtState.Text = miris.c_case_desc_state;

                txtVehicleId02.Text = miris.c_case_desc_vehicle_02_id;
                txtVin02.Text = miris.c_case_desc_vehicle_02_vin;
                txtLicenseNumber02.Text = miris.c_case_desc_licence_02_number;
                txtVehicleMake02.Text = miris.c_case_desc_vehicle_02_make;
                txtModel02.Text = miris.c_case_desc_vehicle_02_model;
                ddlVehicleType02.Text = miris.c_case_desc_vehicle_02_type_fk;
                txtYear02.Text = miris.c_case_desc_vehicle_02_year;
                txtState02.Text = miris.c_case_desc_vehicle_02_state;


                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_03_type_fk))
                {
                    ltlVehicleCount.Text = "1";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_04_type_fk))
                {
                    ltlVehicleCount.Text = "2";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_05_type_fk))
                {
                    ltlVehicleCount.Text = "3";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_06_type_fk))
                {
                    ltlVehicleCount.Text = "4";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_07_type_fk))
                {
                    ltlVehicleCount.Text = "5";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_08_type_fk))
                {
                    ltlVehicleCount.Text = "6";
                }

                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_09_type_fk))
                {
                    ltlVehicleCount.Text = "7";
                }


                if (!string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_fk) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_id) && !string.IsNullOrEmpty(miris.c_case_desc_vehicle_10_type_fk))
                {
                    ltlVehicleCount.Text = "8";
                }


                ddlCompanyVehicleStruck.SelectedValue = miris.c_case_desc_company_vehicle_struck_fk;
                ddlCompanyVehicleStruckBy.SelectedValue = miris.c_case_desc_company_vehicle_struck_by_fk;
                chkNonCollision.Checked = miris.c_case_desc_non_collision;
                txtNonCollision.Text = miris.c_case_desc_non_collision_text;

                txtDriversLic.Text = miris.c_case_detail_drivers_lic;
                txtStateandClass.Text = miris.c_case_detail_state_and_class;
                if (!string.IsNullOrEmpty(miris.c_case_detail_expire_date.ToString()))
                {
                    txtExpireDate.Text = Convert.ToDateTime(miris.c_case_detail_expire_date).ToShortDateString();
                }
                //txtExpireDate.Text = miris.c_case_detail_expire_date.ToShortDateString();
                txtAddress.Text = miris.c_case_detail_address;
                txtCity.Text = miris.c_case_detail_city;
                txtCaseState.Text = miris.c_case_detail_state;
                txtNearestCrossStreet.Text = miris.c_case_detail_nearest_cross_street;
                txtTypeofRoadway.Text = miris.c_case_detail_type_of_roadway;
                ddlRoadCondition.SelectedValue = miris.c_case_detail_road_condition_fk;
                if (!string.IsNullOrEmpty(miris.c_case_detail_time_of_day.ToString()))
                {
                    txtTimeofDay.Text = Convert.ToDateTime(miris.c_case_detail_time_of_day).ToShortTimeString();
                }
                //txtTimeofDay.Text = miris.c_case_detail_time_of_day.ToShortTimeString();
                // here we need to add one column
                ddlWeather.SelectedValue = miris.c_case_detail_weather_fk;
                ddlTrafficCondition.SelectedValue = miris.c_case_detail_traffic_condition_fk;
                ddlTrafficControls.SelectedValue = miris.c_case_detail_traffic_controls_fk;
                txtOperatingSpeed.Text = miris.c_case_detail_oprating_speed;
                txtSpeedLimit.Text = miris.c_case_detail_speed_limit;
                ddlVehicleStruck.SelectedValue = miris.c_case_detail_vehicle_struck_fk;
                ddlVehicleStruckBy.SelectedValue = miris.c_case_detail_vehicle_struck_by_fk;
                ddlCollisionType.SelectedValue = miris.c_case_detail_collision_type_fk;
                ddlCollisionLocation.SelectedValue = miris.c_case_detail_collision_location_fk;
                ddlCollisionDirection.SelectedValue = miris.c_case_detail_collision_direction_fk;
                ddlNonCollisionType.SelectedValue = miris.c_case_detail_non_collision_type_fk;
                txtNumberofVehicleInvolved.Text = miris.c_case_detail_number_of_vehicle_involved;
                txtNumberofVehicletowed.Text = miris.c_case_detail_number_of_vehicle_towed;
                txtNoofPeopleInjured.Text = miris.c_case_detail_number_of_people_injured;
                txtNoofPeopleInjured.Text = miris.c_case_detail_number_of_people_killed;
                if (miris.c_case_detail_cituation_issued == true)
                {
                    rblCituationIssued.SelectedValue = "Yes";
                }
                else
                {
                    rblCituationIssued.SelectedValue = "No";
                }
                txtAtWhom.Text = miris.c_case_detail_at_whom;
                if (miris.c_case_detail_at_fault == true)
                {

                    rblAtfault.SelectedValue = "Yes";
                }
                else
                {
                    rblAtfault.SelectedValue = "No";
                }
                if (miris.c_case_detail_contributory == true)
                {

                    rblContributory.SelectedValue = "Yes";
                }
                else
                {
                    rblContributory.SelectedValue = "No";
                }

                miris.c_case_detail_gross_vehicle_weight = txtGrossVehicleWeight.Text;
                miris.c_case_detail_combined_gross_vehicle_weight = txtCombinedGrossVehicleWeight.Text;
                if (miris.c_case_detail_dot_vehicle == true)
                {
                    rblDotVehicle.SelectedValue = "Yes";

                }
                else
                {
                    rblDotVehicle.SelectedValue = "No";
                }
                if (miris.c_case_detail_dot_driver == true)
                {
                    rblDotDriver.SelectedValue = "Yes";
                }
                else
                {
                    rblDotDriver.SelectedValue = "No";
                }
                if (miris.c_case_detail_seat_belt_used == true)
                {
                    rblSeatBeltUsed.SelectedValue = "Yes";
                }
                else
                {
                    rblSeatBeltUsed.SelectedValue = "No";
                }
                if (miris.c_case_detail_air_bag_eqiupped == true)
                {
                    rblAirbagEquipped.SelectedValue = "Yes";
                }
                else
                {
                    rblAirbagEquipped.SelectedValue = "No";
                }
                if (miris.c_case_detail_air_bag_deployed == true)
                {
                    rblAirBagDeployed.SelectedValue = "Yes";
                }
                else
                {
                    rblAirBagDeployed.SelectedValue = "No";
                }
                if (miris.c_case_detail_cellphone_in_use == true)
                {
                    rblCellphoneinUse.SelectedValue = "Yes";
                }
                else
                {
                    rblCellphoneinUse.SelectedValue = "No";
                }
                if (miris.c_case_detail_computer_in_use == true)
                {
                    rblComputerInUse.SelectedValue = "Yes";
                }
                else
                {
                    rblComputerInUse.SelectedValue = "No";
                }
                if (miris.c_case_detail_special_equipment == true)
                {
                    rblSpecialEquipment.SelectedValue = "Yes";
                }
                else
                {
                    rblSpecialEquipment.SelectedValue = "No";
                }



                txtSpecialEquibment.Text = miris.c_case_detail_special_equipment_text;
                ddlLocationofImpact.SelectedValue = miris.c_case_detail_location_of_impact_fk;
                if (miris.c_case_detail_driver_injured == true)    // need to add some fields
                {
                    rblDriverInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblDriverInjured.SelectedValue = "No";
                }
                if (miris.c_case_detail_passenger_injured == true)    // need to add some fields
                {
                    rblPassengerInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                }

                txtHeavyDamage.InnerText = miris.c_case_detail_damage_heavy;
                txtModerateDamage.InnerText = miris.c_case_detail_damage_moderate;
                txtLightDamage.InnerText = miris.c_case_detail_damage_light;

                if (miris.c_case_desc_was_fatality == true)
                {
                    rblFatality.SelectedValue = "Yes";
                    lblNumberofFatilities.Attributes.Add("style", "display:block");
                    txtNoofPeopleKilled.Attributes.Add("style", "display:block");
                    txtNoofPeopleKilled.Text = miris.c_case_detail_number_of_people_killed;
                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                }
                if (miris.c_case_desc_public_vehicle_involved == true)
                {
                    rblPublicVehicleInvolved.SelectedValue = "Yes";

                }
                else
                {
                    rblPassengerInjured.SelectedValue = "No";
                }


                txtDriverName.Text = miris.c_pub_vehicle_driver_name;
                txtDriverAddress.Text = miris.c_pub_vehicle_driver_address;
                txtDriverContact.Text = miris.c_pub_vehicle_driver_contact;
                txtOwnerName.Text = miris.c_pub_vehicle_owner_name;
                txtOwnerAddress.Text = miris.c_pub_vehicle_owner_address;
                txtOwnerContact.Text = miris.c_pub_vehicle_owner_contact;
                txtPublicVehicleID.Text = miris.c_pub_vehicle_vehicle_id;
                txtPublicVehicleVIN.Text = miris.c_pub_vehicle_vehicle_vin;
                txtPublicLicenseNumber.Text = miris.c_pub_vehicle_licence_number;
                txtPublicVehicleMake.Text = miris.c_pub_vehicle_vehicle_make;
                txtPublicVehicleModel.Text = miris.c_pub_vehicle_vehicle_model;
                ddlPublicVehicleType.SelectedValue = miris.c_pub_vehicle_vehicle_type_fk;
                txtPublicYear.Text = miris.c_pub_vehicle_year;
                txtPublicState.Text = miris.c_pub_vehicle_state;
                txtPublicGrossWeight.Text = miris.c_pub_vehicle_gross_vehicle_weight;
                txtPublicCombinedVehicleWeight.Text = miris.c_pub_vehicle_combined_gross_vehicle_weight;
                if (miris.c_pub_vehicle_dot_vehicle == true)
                {
                    rblPublicDotVehicle.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicDotVehicle.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_dot_driver == true)
                {
                    rblPublicDotDriver.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicDotDriver.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_seat_belt_used == true)
                {

                    rblPublicSeatBeltUsed.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicSeatBeltUsed.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_air_bag_eqiupped == true)
                {
                    rblPublicAirBagEquipped.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicAirBagEquipped.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_air_bag_deployed == true)
                {
                    rblPublicAirBagDeployed.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicAirBagDeployed.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_cellphone_in_use == true)
                {
                    rblPublicCellphoneinUse.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicCellphoneinUse.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_computer_in_use == true)
                {
                    rblPublicComputerInUse.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicComputerInUse.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_special_equipment == true)
                {
                    rblPublicSpecialEquipment.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicSpecialEquipment.SelectedValue = "No";
                }

                txtPublicSpecialEquipment.Text = miris.c_pub_vehicle_special_equipment_text;
                ddlPublicLocationOfImpact.SelectedValue = miris.c_pub_vehicle_location_of_impact_fk;
                if (miris.c_pub_vehicle_driver_injured == true)// need to add some fields
                {
                    rblPublicDriverInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicDriverInjured.SelectedValue = "No";
                }
                if (miris.c_pub_vehicle_passenger_injured == true)// need to add some fields
                {
                    rblPublicPassengerInjured.SelectedValue = "Yes";
                }
                else
                {
                    rblPublicPassengerInjured.SelectedValue = "No";
                }

                txtPublicPassengerInjured.Text = miris.c_pub_vehicle_passenger_injured_text;
                txtPublicDriverInjured.Text = miris.c_pub_vehicle_driver_injured_text;

                txtTotalvehicleOccupant.Text = miris.c_pub_vehicle_number_of_total_vehicle_injured;
                txtPublicHeavyDamage.InnerText = miris.c_pub_vehicle_damage_heavy; //doubt
                txtPublicModerateDamage.InnerText = miris.c_pub_vehicle_damage_moderate;//doubt
                txtPubliclightDamage.InnerText = miris.c_pub_vehicle_damage_light;//doubt
                //Pedestrain Incident
                txtNameofPedestrian.Text = miris.c_pedestrain_name;
                txtPedestrianAddress.Text = miris.c_pedestrain_address;
                txtPedestrianPhone.Text = miris.c_pedestrain_phone;
                txtPedestrianSex.Text = miris.c_pedestrain_sex;
                txtPedestrainAge.Text = miris.c_pedestrain_age;
                ddlPedestrainCollisionType.SelectedValue = miris.c_pedestrain_collision_type_fk;
                txtPedestrianDescription.InnerText = miris.c_pedestrain_description;
                //BICycle Incident
                txtBicycleNameofPerson.Text = miris.c_bicycle_person_name;
                txtBicyclePersonAddress.Text = miris.c_bicycle_person_address;
                txtBicyclePersonPhone.Text = miris.c_bicycle_person_phone;
                txtBicyblePersonSex.Text = miris.c_bicycle_person_sex;
                txtBicycleAge.Text = miris.c_bicycle_person_age;
                ddlBicycleCollisionType.SelectedValue = miris.c_bicycle_person_collision_type_fk;
                txtBicycleIncidentDesc.InnerText = miris.c_bicycle_person_description;
                //Animal Incident
                txtAnimalName.Text = miris.c_animal_name;
                txtPlace.Text = miris.c_animal_place;
                ddlAnimalCollisionType.SelectedValue = miris.c_animal_collision_type_fk;
                txtAnimalDescription.InnerText = miris.c_animal_description;
                //Fixed Object Incident
                txtPropertyOwner.Text = miris.c_fixed_object_property_name;
                txtPropertyAddress.Text = miris.c_fixed_object_address;
                txtContactInformation.Text = miris.c_fixed_object_contact_info;
                ddlPropertyCollisionType.SelectedValue = miris.c_fixed_object_collision_type_fk;
                txtPropertyDesc.InnerText = miris.c_fixed_object_description;
                txtPhysicalPropertyDesc.InnerText = miris.c_fixed_object_property_description;

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message);
                    }
                }
            }
        }

        protected void btnReset_Header_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnReset_Footer_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO miris = new ComplianceDAO();
                DataTable dtCaseId = new DataTable();
                string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
                miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);

                if (!string.IsNullOrEmpty(copyCaseId))
                {
                    if (caseCategory == "MV")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else if (caseCategory == "OI")
                    {
                        Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(copyCaseId) + "&cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                }
                else
                {
                    if (caseCategory == "MV")
                    {
                        Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else if (caseCategory == "OI")
                    {
                        Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                    }
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
                        Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message);
                    }
                }
            }

        }

        protected void btnHeaderCompleteCase_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                isApprover = true;
                CompleteCase(ddlCaseStatus.Items.FindByText("Closed").Value);
            }
            else
            {
                isApprover = false;
                CompleteCase(ddlCaseStatus.Items.FindByText("Open").Value);
                if (isApprover == true)
                {
                    mpCompleteCase.Show();
                }
            }
        }

        protected void btnFooterCompleteCase_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
            {
                isApprover = true;
                CompleteCase(ddlCaseStatus.Items.FindByText("Closed").Value);
            }
            else
            {
                isApprover = false;
                CompleteCase(ddlCaseStatus.Items.FindByText("Open").Value);
                if (isApprover == true)
                {
                    mpCompleteCase.Show();
                }
            }
        }

        /// <summary>
        /// On Complete Case
        /// </summary>
        /// <param name="CaseStatus"></param>
        private void CompleteCase(string CaseStatus)
        {
            try
            {
                ComplianceDAO insertCase = new ComplianceDAO();
                insertCase.c_case_id_pk = Guid.NewGuid().ToString();
                insertCase.u_user_id_fk = SessionWrapper.u_userid;
                //insertCase.c_case_number = lblCaseNumber.Text;
                insertCase.c_case_title = txtCaseTitle.Text;
                insertCase.c_case_category_fk = ddlCaseCategory.SelectedValue;
                insertCase.c_case_type_fk = ddlCaseTypes.SelectedValue;
                insertCase.c_case_status = CaseStatus;
                insertCase.c_employee_name = txtEmployeeName.Text;
                insertCase.c_date_in_title = Convert.ToDateTime(txtDateInTitle.Text, culture);
                int day = Convert.ToInt32(dob_day.Items[dob_day.SelectedIndex].Value);
                int month = Convert.ToInt16(ddlMonth.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                DateTime birthDate = new DateTime(year, month, day);
                insertCase.c_employee_dob = birthDate;

                int hireday = Convert.ToInt32(doh_hire_day.Items[doh_hire_day.SelectedIndex].Value);
                int hiremonth = Convert.ToInt16(ddlHireMonth.SelectedValue);
                int hireyear = Convert.ToInt32(ddlHireYear.SelectedValue);
                DateTime hireDate = new DateTime(hireyear, hiremonth, hireday);
                insertCase.c_employee_hire_date = hireDate;

                //insertCase.c_employee_dob = Convert.ToDateTime(txtDateOfBirth.Text, culture);
                //insertCase.c_employee_hire_date = Convert.ToDateTime(txtEmployeHireDate.Text, culture);
                insertCase.c_employee_id = txtEmployeeId.Text;
                insertCase.c_ssn = txtLastFourDigitOfSSN.Text;
                insertCase.c_supervisor = txtSupervisor.Text;
                insertCase.c_incident_location = txtIncidentLocation.Text;
                insertCase.c_incident_date = Convert.ToDateTime(txtIncidentDate.Text, culture);
                insertCase.c_incident_time = Convert.ToDateTime(IncidentTime.Date, culture);
                insertCase.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                insertCase.c_note = txtNote.Text;
                //insertCase.c_root_cause_analysic_info = txtRootCauseAnalysisDetails.Text;
                //insertCase.c_corrective_action_info = txtCorrectiveActionDetails.Text;

                insertCase.c_custom_01 = txtCustom01.Text;
                insertCase.c_custom_02 = txtCustom02.Text;
                insertCase.c_custom_03 = txtCustom03.Text;
                insertCase.c_custom_04 = txtCustom04.Text;
                insertCase.c_custom_05 = txtCustom05.Text;
                insertCase.c_custom_06 = txtCustom06.Text;
                insertCase.c_custom_07 = txtCustom07.Text;
                insertCase.c_custom_08 = txtCustom08.Text;
                insertCase.c_custom_09 = txtCustom09.Text;
                insertCase.c_custom_10 = txtCustom10.Text;
                insertCase.c_custom_11 = txtCustom11.Text;
                insertCase.c_custom_12 = txtCustom12.Text;
                insertCase.c_custom_13 = txtCustom13.Text;
                insertCase.c_timezoneId = ddlTimezone.SelectedValue;
                insertCase.c_case_date = (DateTime)SessionWrapper.casedate;
                insertCase.c_miris_witness = ConvertDataTableToXml(SessionWrapper.session_witness);
                insertCase.c_miris_photo = ConvertDataTableToXml(SessionWrapper.session_Photo);
                insertCase.c_miris_police_report = ConvertDataTableToXml(SessionWrapper.session_PoliceReport);
                insertCase.c_miris_scene_sketch = ConvertDataTableToXml(SessionWrapper.session_SceneSketch);
                insertCase.c_miris_employee_interview = ConvertDataTableToXml(SessionWrapper.session_EmployeeInterview);
                insertCase.c_miris_extenuating_condition = ConvertDataTableToXml(SessionWrapper.session_ExtenuatingCondition);

                //newly added columns

                insertCase.c_case_desc_vehicle_01_fk = ddlVehicle01.SelectedValue;
                insertCase.c_case_desc_vehicle_02_fk = ddlVehicle02.SelectedValue;

                insertCase.c_case_desc_vehicle_id = txtVehicleId.Text;
                insertCase.c_case_desc_vehicle_vin = txtVIN.Text;
                insertCase.c_case_desc_licence_number = txtLicenseNumber.Text;
                insertCase.c_case_desc_vehicle_make = txtVehicleMake.Text;
                insertCase.c_case_desc_vehicle_model = txtVehicleModel.Text;
                insertCase.c_case_desc_vehicle_type_fk = ddlVehicleType.Text;
                insertCase.c_case_desc_year = txtYear.Text;
                insertCase.c_case_desc_state = txtState.Text;
                insertCase.c_case_desc_company_vehicle_struck_fk = ddlCompanyVehicleStruck.SelectedValue;
                insertCase.c_case_desc_company_vehicle_struck_by_fk = ddlCompanyVehicleStruckBy.SelectedValue;
                insertCase.c_case_desc_non_collision = chkNonCollision.Checked;
                insertCase.c_case_desc_non_collision_text = txtNonCollision.Text;

                insertCase.c_case_desc_vehicle_02_id = txtVehicleId02.Text;
                insertCase.c_case_desc_vehicle_02_vin = txtVin02.Text;
                insertCase.c_case_desc_licence_02_number = txtLicenseNumber02.Text;
                insertCase.c_case_desc_vehicle_02_make = txtVehicleMake02.Text;
                insertCase.c_case_desc_vehicle_02_model = txtModel02.Text;
                insertCase.c_case_desc_vehicle_02_type_fk = ddlVehicleType02.SelectedValue;
                insertCase.c_case_desc_vehicle_02_year = txtYear02.Text;
                insertCase.c_case_desc_vehicle_02_state = txtState02.Text;

                if (VehiclePanel.Controls.Count > 1)
                {
                    ucmv_01 vehicle03 = (ucmv_01)VehiclePanel.Controls[1];
                    if (vehicle03 != null)
                    {
                        insertCase.c_case_desc_vehicle_03_fk = vehicle03.ddlVehicle;
                        insertCase.c_case_desc_vehicle_03_id = vehicle03.VechicleId;
                        insertCase.c_case_desc_vehicle_03_vin = vehicle03.VIN;
                        insertCase.c_case_desc_licence_03_number = vehicle03.LicenseNumber;
                        insertCase.c_case_desc_vehicle_03_make = vehicle03.VehicleMake;
                        insertCase.c_case_desc_vehicle_03_model = vehicle03.VehicleModel;
                        insertCase.c_case_desc_vehicle_03_type_fk = vehicle03.ddlType;
                        insertCase.c_case_desc_vehicle_03_year = vehicle03.Year;
                        insertCase.c_case_desc_vehicle_03_state = vehicle03.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_03_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_03_id = string.Empty;
                    insertCase.c_case_desc_vehicle_03_vin = string.Empty;
                    insertCase.c_case_desc_licence_03_number = string.Empty;
                    insertCase.c_case_desc_vehicle_03_make = string.Empty;
                    insertCase.c_case_desc_vehicle_03_model = string.Empty;
                    insertCase.c_case_desc_vehicle_03_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_03_year = string.Empty;
                    insertCase.c_case_desc_vehicle_03_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 2)
                {
                    ucmv_01 vehicle04 = (ucmv_01)VehiclePanel.Controls[2];
                    if (vehicle04 != null)
                    {
                        insertCase.c_case_desc_vehicle_04_fk = vehicle04.ddlVehicle;
                        insertCase.c_case_desc_vehicle_04_id = vehicle04.VechicleId;
                        insertCase.c_case_desc_vehicle_04_vin = vehicle04.VIN;
                        insertCase.c_case_desc_licence_04_number = vehicle04.LicenseNumber;
                        insertCase.c_case_desc_vehicle_04_make = vehicle04.VehicleMake;
                        insertCase.c_case_desc_vehicle_04_model = vehicle04.VehicleModel;
                        insertCase.c_case_desc_vehicle_04_type_fk = vehicle04.ddlType;
                        insertCase.c_case_desc_vehicle_04_year = vehicle04.Year;
                        insertCase.c_case_desc_vehicle_04_state = vehicle04.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_04_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_04_id = string.Empty;
                    insertCase.c_case_desc_vehicle_04_vin = string.Empty;
                    insertCase.c_case_desc_licence_04_number = string.Empty;
                    insertCase.c_case_desc_vehicle_04_make = string.Empty;
                    insertCase.c_case_desc_vehicle_04_model = string.Empty;
                    insertCase.c_case_desc_vehicle_04_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_04_year = string.Empty;
                    insertCase.c_case_desc_vehicle_04_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 3)
                {
                    ucmv_01 vehicle05 = (ucmv_01)VehiclePanel.Controls[3];
                    if (vehicle05 != null)
                    {
                        insertCase.c_case_desc_vehicle_05_fk = vehicle05.ddlVehicle;
                        insertCase.c_case_desc_vehicle_05_id = vehicle05.VechicleId;
                        insertCase.c_case_desc_vehicle_05_vin = vehicle05.VIN;
                        insertCase.c_case_desc_licence_05_number = vehicle05.LicenseNumber;
                        insertCase.c_case_desc_vehicle_05_make = vehicle05.VehicleMake;
                        insertCase.c_case_desc_vehicle_05_model = vehicle05.VehicleModel;
                        insertCase.c_case_desc_vehicle_05_type_fk = vehicle05.ddlType;
                        insertCase.c_case_desc_vehicle_05_year = vehicle05.Year;
                        insertCase.c_case_desc_vehicle_05_state = vehicle05.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_05_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_05_id = string.Empty;
                    insertCase.c_case_desc_vehicle_05_vin = string.Empty;
                    insertCase.c_case_desc_licence_05_number = string.Empty;
                    insertCase.c_case_desc_vehicle_05_make = string.Empty;
                    insertCase.c_case_desc_vehicle_05_model = string.Empty;
                    insertCase.c_case_desc_vehicle_05_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_05_year = string.Empty;
                    insertCase.c_case_desc_vehicle_05_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 4)
                {
                    ucmv_01 vehicle06 = (ucmv_01)VehiclePanel.Controls[4];
                    if (vehicle06 != null)
                    {
                        insertCase.c_case_desc_vehicle_06_fk = vehicle06.ddlVehicle;
                        insertCase.c_case_desc_vehicle_06_id = vehicle06.VechicleId;
                        insertCase.c_case_desc_vehicle_06_vin = vehicle06.VIN;
                        insertCase.c_case_desc_licence_06_number = vehicle06.LicenseNumber;
                        insertCase.c_case_desc_vehicle_06_make = vehicle06.VehicleMake;
                        insertCase.c_case_desc_vehicle_06_model = vehicle06.VehicleModel;
                        insertCase.c_case_desc_vehicle_06_type_fk = vehicle06.ddlType;
                        insertCase.c_case_desc_vehicle_06_year = vehicle06.Year;
                        insertCase.c_case_desc_vehicle_06_state = vehicle06.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_06_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_06_id = string.Empty;
                    insertCase.c_case_desc_vehicle_06_vin = string.Empty;
                    insertCase.c_case_desc_licence_06_number = string.Empty;
                    insertCase.c_case_desc_vehicle_06_make = string.Empty;
                    insertCase.c_case_desc_vehicle_06_model = string.Empty;
                    insertCase.c_case_desc_vehicle_06_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_06_year = string.Empty;
                    insertCase.c_case_desc_vehicle_06_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 5)
                {
                    ucmv_01 vehicle07 = (ucmv_01)VehiclePanel.Controls[5];
                    if (vehicle07 != null)
                    {
                        insertCase.c_case_desc_vehicle_07_fk = vehicle07.ddlVehicle;
                        insertCase.c_case_desc_vehicle_07_id = vehicle07.VechicleId;
                        insertCase.c_case_desc_vehicle_07_vin = vehicle07.VIN;
                        insertCase.c_case_desc_licence_07_number = vehicle07.LicenseNumber;
                        insertCase.c_case_desc_vehicle_07_make = vehicle07.VehicleMake;
                        insertCase.c_case_desc_vehicle_07_model = vehicle07.VehicleModel;
                        insertCase.c_case_desc_vehicle_07_type_fk = vehicle07.ddlType;
                        insertCase.c_case_desc_vehicle_07_year = vehicle07.Year;
                        insertCase.c_case_desc_vehicle_07_state = vehicle07.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_07_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_07_id = string.Empty;
                    insertCase.c_case_desc_vehicle_07_vin = string.Empty;
                    insertCase.c_case_desc_licence_07_number = string.Empty;
                    insertCase.c_case_desc_vehicle_07_make = string.Empty;
                    insertCase.c_case_desc_vehicle_07_model = string.Empty;
                    insertCase.c_case_desc_vehicle_07_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_07_year = string.Empty;
                    insertCase.c_case_desc_vehicle_07_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 6)
                {
                    ucmv_01 vehicle08 = (ucmv_01)VehiclePanel.Controls[6];
                    if (vehicle08 != null)
                    {
                        insertCase.c_case_desc_vehicle_08_fk = vehicle08.ddlVehicle;
                        insertCase.c_case_desc_vehicle_08_id = vehicle08.VechicleId;
                        insertCase.c_case_desc_vehicle_08_vin = vehicle08.VIN;
                        insertCase.c_case_desc_licence_08_number = vehicle08.LicenseNumber;
                        insertCase.c_case_desc_vehicle_08_make = vehicle08.VehicleMake;
                        insertCase.c_case_desc_vehicle_08_model = vehicle08.VehicleModel;
                        insertCase.c_case_desc_vehicle_08_type_fk = vehicle08.ddlType;
                        insertCase.c_case_desc_vehicle_08_year = vehicle08.Year;
                        insertCase.c_case_desc_vehicle_08_state = vehicle08.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_08_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_08_id = string.Empty;
                    insertCase.c_case_desc_vehicle_08_vin = string.Empty;
                    insertCase.c_case_desc_licence_08_number = string.Empty;
                    insertCase.c_case_desc_vehicle_08_make = string.Empty;
                    insertCase.c_case_desc_vehicle_08_model = string.Empty;
                    insertCase.c_case_desc_vehicle_08_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_08_year = string.Empty;
                    insertCase.c_case_desc_vehicle_08_state = string.Empty;
                }

                if (VehiclePanel.Controls.Count > 7)
                {
                    ucmv_01 vehicle09 = (ucmv_01)VehiclePanel.Controls[7];
                    if (vehicle09 != null)
                    {
                        insertCase.c_case_desc_vehicle_09_fk = vehicle09.ddlVehicle;
                        insertCase.c_case_desc_vehicle_09_id = vehicle09.VechicleId;
                        insertCase.c_case_desc_vehicle_09_vin = vehicle09.VIN;
                        insertCase.c_case_desc_licence_09_number = vehicle09.LicenseNumber;
                        insertCase.c_case_desc_vehicle_09_make = vehicle09.VehicleMake;
                        insertCase.c_case_desc_vehicle_09_model = vehicle09.VehicleModel;
                        insertCase.c_case_desc_vehicle_09_type_fk = vehicle09.ddlType;
                        insertCase.c_case_desc_vehicle_09_year = vehicle09.Year;
                        insertCase.c_case_desc_vehicle_09_state = vehicle09.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_09_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_09_id = string.Empty;
                    insertCase.c_case_desc_vehicle_09_vin = string.Empty;
                    insertCase.c_case_desc_licence_09_number = string.Empty;
                    insertCase.c_case_desc_vehicle_09_make = string.Empty;
                    insertCase.c_case_desc_vehicle_09_model = string.Empty;
                    insertCase.c_case_desc_vehicle_09_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_09_year = string.Empty;
                    insertCase.c_case_desc_vehicle_09_state = string.Empty;
                }
                if (VehiclePanel.Controls.Count > 8)
                {
                    ucmv_01 vehicle10 = (ucmv_01)VehiclePanel.Controls[8];
                    if (vehicle10 != null)
                    {
                        insertCase.c_case_desc_vehicle_10_fk = vehicle10.ddlVehicle;
                        insertCase.c_case_desc_vehicle_10_id = vehicle10.VechicleId;
                        insertCase.c_case_desc_vehicle_10_vin = vehicle10.VIN;
                        insertCase.c_case_desc_licence_10_number = vehicle10.LicenseNumber;
                        insertCase.c_case_desc_vehicle_10_make = vehicle10.VehicleMake;
                        insertCase.c_case_desc_vehicle_10_model = vehicle10.VehicleModel;
                        insertCase.c_case_desc_vehicle_10_type_fk = vehicle10.ddlType;
                        insertCase.c_case_desc_vehicle_10_year = vehicle10.Year;
                        insertCase.c_case_desc_vehicle_10_state = vehicle10.State;
                    }
                }
                else
                {
                    insertCase.c_case_desc_vehicle_10_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_10_id = string.Empty;
                    insertCase.c_case_desc_vehicle_10_vin = string.Empty;
                    insertCase.c_case_desc_licence_10_number = string.Empty;
                    insertCase.c_case_desc_vehicle_10_make = string.Empty;
                    insertCase.c_case_desc_vehicle_10_model = string.Empty;
                    insertCase.c_case_desc_vehicle_10_type_fk = string.Empty;
                    insertCase.c_case_desc_vehicle_10_year = string.Empty;
                    insertCase.c_case_desc_vehicle_10_state = string.Empty;
                }



                insertCase.c_case_detail_drivers_lic = txtDriversLic.Text;
                insertCase.c_case_detail_state_and_class = txtStateandClass.Text;
                DateTime? expiredate = null;
                DateTime tempexpiredate;
                if (DateTime.TryParseExact(txtExpireDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempexpiredate))
                {
                    expiredate = tempexpiredate;
                }
                insertCase.c_case_detail_expire_date = expiredate;
                insertCase.c_case_detail_address = txtAddress.Text;
                insertCase.c_case_detail_city = txtCity.Text;
                insertCase.c_case_detail_state = txtCaseState.Text;
                insertCase.c_case_detail_nearest_cross_street = txtNearestCrossStreet.Text;
                insertCase.c_case_detail_type_of_roadway = txtTypeofRoadway.Text;
                insertCase.c_case_detail_road_condition_fk = ddlRoadCondition.SelectedValue;
                DateTime? timeofday = null;
                DateTime temptimeofday;
                if (DateTime.TryParseExact(txtTimeofDay.Text, "hh:mm tt", culture, DateTimeStyles.None, out temptimeofday))
                {
                    timeofday = temptimeofday;
                }

                insertCase.c_case_detail_time_of_day = timeofday;

                // here we need to add one column
                insertCase.c_case_detail_weather_fk = ddlWeather.SelectedValue;
                insertCase.c_case_detail_traffic_condition_fk = ddlTrafficCondition.SelectedValue;
                insertCase.c_case_detail_traffic_controls_fk = ddlTrafficControls.SelectedValue;
                insertCase.c_case_detail_oprating_speed = txtOperatingSpeed.Text;  //doubt
                insertCase.c_case_detail_speed_limit = txtSpeedLimit.Text;   //doubt
                insertCase.c_case_detail_vehicle_struck_fk = ddlVehicleStruck.SelectedValue;
                insertCase.c_case_detail_vehicle_struck_by_fk = ddlVehicleStruckBy.SelectedValue;
                insertCase.c_case_detail_collision_type_fk = ddlCollisionType.SelectedValue;
                insertCase.c_case_detail_collision_location_fk = ddlCollisionLocation.SelectedValue;
                insertCase.c_case_detail_collision_direction_fk = ddlCollisionDirection.SelectedValue;
                insertCase.c_case_detail_non_collision_type_fk = ddlNonCollisionType.SelectedValue;
                insertCase.c_case_detail_number_of_vehicle_involved = txtNumberofVehicleInvolved.Text;
                insertCase.c_case_detail_number_of_vehicle_towed = txtNumberofVehicletowed.Text;
                insertCase.c_case_detail_number_of_people_injured = txtNoofPeopleInjured.Text;
                insertCase.c_case_detail_number_of_people_killed = txtNoofPeopleKilled.Text;
                if (rblCituationIssued.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_cituation_issued = true;
                }
                else
                {
                    insertCase.c_case_detail_cituation_issued = false;
                }
                insertCase.c_case_detail_at_whom = txtAtWhom.Text;
                if (rblAtfault.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_at_fault = true;
                }
                else
                {
                    insertCase.c_case_detail_at_fault = false;
                }
                if (rblContributory.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_contributory = true;
                }
                else
                {
                    insertCase.c_case_detail_contributory = false;
                }

                insertCase.c_case_detail_gross_vehicle_weight = txtGrossVehicleWeight.Text;
                insertCase.c_case_detail_combined_gross_vehicle_weight = txtCombinedGrossVehicleWeight.Text;
                if (rblDotVehicle.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_dot_vehicle = true;
                }
                else
                {
                    insertCase.c_case_detail_dot_vehicle = false;
                }
                if (rblDotDriver.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_dot_driver = true;
                }
                else
                {
                    insertCase.c_case_detail_dot_driver = false;
                }
                if (rblSeatBeltUsed.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_seat_belt_used = true;
                }
                else
                {
                    insertCase.c_case_detail_seat_belt_used = false;
                }
                if (rblAirbagEquipped.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_air_bag_eqiupped = true;
                }
                else
                {
                    insertCase.c_case_detail_air_bag_eqiupped = false;
                }
                if (rblAirBagDeployed.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_air_bag_deployed = true;
                }
                else
                {
                    insertCase.c_case_detail_air_bag_deployed = false;
                }
                if (rblCellphoneinUse.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_cellphone_in_use = true;
                }
                else
                {
                    insertCase.c_case_detail_cellphone_in_use = false;
                }
                if (rblComputerInUse.SelectedValue == "Yes")
                {
                    insertCase.c_case_detail_computer_in_use = true;
                }
                else
                {
                    insertCase.c_case_detail_computer_in_use = false;
                }
                if (rblSpecialEquipment.SelectedValue == "Yes")
                {

                    insertCase.c_case_detail_special_equipment = true;
                }
                else
                {
                    insertCase.c_case_detail_special_equipment = false;
                }

                insertCase.c_case_detail_special_equipment_text = txtSpecialEquibment.Text;
                insertCase.c_case_detail_location_of_impact_fk = ddlLocationofImpact.SelectedValue;
                if (rblDriverInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    insertCase.c_case_detail_driver_injured = true;
                }
                else
                {
                    insertCase.c_case_detail_driver_injured = false;
                }
                if (rblPassengerInjured.SelectedValue == "Yes")    // need to add some fields
                {

                    insertCase.c_case_detail_passenger_injured = true;
                }
                else
                {
                    insertCase.c_case_detail_passenger_injured = false;
                }

                insertCase.c_case_detail_damage_heavy = txtHeavyDamage.InnerText;
                insertCase.c_case_detail_damage_moderate = txtModerateDamage.InnerText;
                insertCase.c_case_detail_damage_light = txtLightDamage.InnerText;
                //Public Vehicle Information
                insertCase.c_pub_vehicle_driver_name = txtDriverName.Text;
                insertCase.c_pub_vehicle_driver_address = txtDriverAddress.Text;
                insertCase.c_pub_vehicle_driver_contact = txtDriverContact.Text;
                insertCase.c_pub_vehicle_owner_name = txtOwnerName.Text;
                insertCase.c_pub_vehicle_owner_address = txtOwnerAddress.Text;
                insertCase.c_pub_vehicle_owner_contact = txtOwnerContact.Text;
                insertCase.c_pub_vehicle_vehicle_id = txtPublicVehicleID.Text;
                insertCase.c_pub_vehicle_vehicle_vin = txtPublicVehicleVIN.Text;
                insertCase.c_pub_vehicle_licence_number = txtPublicLicenseNumber.Text;
                insertCase.c_pub_vehicle_vehicle_make = txtPublicVehicleMake.Text;
                insertCase.c_pub_vehicle_vehicle_model = txtPublicVehicleModel.Text;
                insertCase.c_pub_vehicle_vehicle_type_fk = ddlPublicVehicleType.SelectedValue;
                insertCase.c_pub_vehicle_year = txtPublicYear.Text;
                insertCase.c_pub_vehicle_state = txtPublicState.Text;
                insertCase.c_pub_vehicle_gross_vehicle_weight = txtPublicGrossWeight.Text;
                insertCase.c_pub_vehicle_combined_gross_vehicle_weight = txtPublicCombinedVehicleWeight.Text;
                if (rblPublicDotVehicle.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_dot_vehicle = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_dot_vehicle = false;
                }
                if (rblPublicDotDriver.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_dot_driver = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_dot_driver = false;
                }
                if (rblPublicSeatBeltUsed.SelectedValue == "Yes")
                {

                    insertCase.c_pub_vehicle_seat_belt_used = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_seat_belt_used = false;
                }
                if (rblPublicAirBagEquipped.SelectedValue == "Yes")
                {

                    insertCase.c_pub_vehicle_air_bag_eqiupped = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_air_bag_eqiupped = false;
                }
                if (rblPublicAirBagDeployed.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_air_bag_deployed = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_air_bag_deployed = false;
                }
                if (rblPublicCellphoneinUse.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_cellphone_in_use = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_cellphone_in_use = false;
                }
                if (rblPublicComputerInUse.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_computer_in_use = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_computer_in_use = false;
                }
                if (rblPublicSpecialEquipment.SelectedValue == "Yes")
                {
                    insertCase.c_pub_vehicle_special_equipment = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_special_equipment = false;
                }

                insertCase.c_pub_vehicle_passenger_injured_text = txtPublicPassengerInjured.Text;
                insertCase.c_pub_vehicle_driver_injured_text = txtPublicDriverInjured.Text;


                insertCase.c_pub_vehicle_special_equipment_text = txtPublicSpecialEquipment.Text;
                insertCase.c_pub_vehicle_location_of_impact_fk = ddlPublicLocationOfImpact.SelectedValue;
                if (rblPublicDriverInjured.SelectedValue == "Yes")// need to add some fields
                {
                    insertCase.c_pub_vehicle_driver_injured = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_driver_injured = false;
                }
                if (rblPublicPassengerInjured.SelectedValue == "Yes")// need to add some fields
                {
                    insertCase.c_pub_vehicle_passenger_injured = true;
                }
                else
                {
                    insertCase.c_pub_vehicle_passenger_injured = false;
                }


                insertCase.c_pub_vehicle_number_of_total_vehicle_injured = txtTotalvehicleOccupant.Text;
                insertCase.c_pub_vehicle_damage_heavy = txtPublicHeavyDamage.InnerText;
                insertCase.c_pub_vehicle_damage_moderate = txtPublicModerateDamage.InnerText;
                insertCase.c_pub_vehicle_damage_light = txtPubliclightDamage.InnerText;
                //Pedestrain Incident
                insertCase.c_pedestrain_name = txtNameofPedestrian.Text;
                insertCase.c_pedestrain_address = txtPedestrianAddress.Text;
                insertCase.c_pedestrain_phone = txtPedestrianPhone.Text;
                insertCase.c_pedestrain_sex = txtPedestrianSex.Text;
                insertCase.c_pedestrain_age = txtPedestrainAge.Text;
                insertCase.c_pedestrain_collision_type_fk = ddlPedestrainCollisionType.SelectedValue;
                insertCase.c_pedestrain_description = txtPedestrianDescription.InnerText;
                //BICycle Incident
                insertCase.c_bicycle_person_name = txtBicycleNameofPerson.Text;
                insertCase.c_bicycle_person_address = txtBicyclePersonAddress.Text;
                insertCase.c_bicycle_person_phone = txtBicyclePersonPhone.Text;
                insertCase.c_bicycle_person_sex = txtBicyblePersonSex.Text;
                insertCase.c_bicycle_person_age = txtBicycleAge.Text;
                insertCase.c_bicycle_person_collision_type_fk = ddlBicycleCollisionType.SelectedValue;
                insertCase.c_bicycle_person_description = txtBicycleIncidentDesc.InnerText;
                //Animal Incident
                insertCase.c_animal_name = txtAnimalName.Text;
                insertCase.c_animal_place = txtPlace.Text;
                insertCase.c_animal_collision_type_fk = ddlAnimalCollisionType.SelectedValue;
                insertCase.c_animal_description = txtAnimalDescription.InnerText;
                //Fixed Object Incident
                insertCase.c_fixed_object_property_name = txtPropertyOwner.Text;
                insertCase.c_fixed_object_address = txtPropertyAddress.Text;
                insertCase.c_fixed_object_contact_info = txtContactInformation.Text;
                insertCase.c_fixed_object_collision_type_fk = ddlPropertyCollisionType.SelectedValue;
                insertCase.c_fixed_object_description = txtPropertyDesc.InnerText;
                insertCase.c_fixed_object_property_description = txtPhysicalPropertyDesc.InnerText;


                try
                {
                    ComplianceDAO miris = new ComplianceDAO();
                    DataTable dtCaseId = new DataTable();
                    miris = ComplianceBLL.GetCaseId(GetBracketText(ddlCaseCategory.SelectedItem.Text), string.Empty);
                    insertCase.c_case_number = miris.c_case_number;
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cmv-01", ex.Message);
                        }
                    }
                }

                int error = ComplianceBLL.InsertCaseMV(insertCase);
                if (error != -1)
                {
                    if (isApprover != false)
                    {
                        Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx", false);
                    }
                    else
                    {
                        isApprover = true;
                    }
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_date_not_inserted_error_wrong");
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
                        Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message);
                    }
                }
            }
        }

        private void PopulateYearDropDown()
        {
            int startYear = 1900;
            int endYear = DateTime.Now.Year;
            ddlYear.Items.Clear();
            ddlHireYear.Items.Clear();
            ListItem li = new ListItem("Year:", "-1");
            li.Selected = true;
            ddlYear.Items.Add(li);
            ddlHireYear.Items.Add(li);
            for (int i = endYear; i >= startYear; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlHireYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User approverInfo = new User();
            approverInfo = UserBLL.GetApprovalNameandEmail(ddlComplianceApprover.SelectedValue.ToString());

            string toEmailid = approverInfo.EmailId;
            toEmailid = "compliancefactor.project@gmail.com";
            //"compliancefactor.project@gmail.com";
            string[] toaddress = toEmailid.Split(',');
            List<MailAddress> mailAddresses = new List<MailAddress>();
            foreach (string recipient in toaddress)
            {
                if (recipient.Trim() != string.Empty)
                {
                    mailAddresses.Add(new MailAddress(recipient));
                }
            }
            try
            {
                StringBuilder sbCompleteCase = new StringBuilder();
                sbCompleteCase.Append("Hello " + approverInfo.Username + ",");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("This email is to change the case as completed case.");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("I sent the request to you for change this " + lblCaseNumber.Text + " to Complete Case.");
                sbCompleteCase.Append("<br><br>");
                sbCompleteCase.Append("by");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append(SessionWrapper.u_username);
                Utility.SendEMailMessage(mailAddresses, "***Request for Complete Case***", sbCompleteCase.ToString());
                success_msg.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "Send Successfully" + " " + toEmailid;

                Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx?Succ=" + SecurityCenter.EncryptText("insert"), false);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cmv-01", ex.Message);
                    }
                }
            }
        }

    }
}