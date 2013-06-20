using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities
{
    public partial class saefin_01 : BasePage
    {
        string editFacilityId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Edit
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editFacilityId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            //get facility id using jquery
            hdFacilityId.Value = editFacilityId;
            try
            {
                if (!IsPostBack)
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_facility_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_facility_text") + "</a>";

                    //Status Bind
                    ddlStatus.DataSource = SystemFacilityBLL.GetStatus(SessionWrapper.CultureName, "saefin-01");
                    ddlStatus.DataBind();
                    //FacilityType Bind
                    ddlFacilityType.DataSource = SystemFacilityBLL.GetFacilityType(SessionWrapper.CultureName);
                    ddlFacilityType.DataBind();
                    ListItem itemToRemove = ddlFacilityType.Items.FindByValue("app_ddl_all_text");
                    ddlFacilityType.Items.Remove(itemToRemove);
                    //Country
                    ddlCountry.DataSource = SystemFacilityBLL.GetCountry();
                    ddlCountry.DataBind();
                    //Bind Locale
                    ddlLocale.DataSource = SystemFacilityBLL.GetLocale();
                    ddlLocale.DataBind();
                    //Bind TimeZone
                    ddlTimezone.DataSource = SystemFacilityBLL.GetTimeZone();
                    ddlTimezone.DataBind();
                    //clear facility session
                    ClearFacilitySession();
                    //Populate facility
                    PopulateFacility(editFacilityId);
                   
                    //Success Message
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetGlobalLabel("app_insert_sucess_msg_text");
                    }
                }

                //Bind room
                DataSet dsFacility = SystemFacilityBLL.GetFacility(editFacilityId);
                gvRooms.DataSource = dsFacility.Tables[2];
                gvRooms.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void ArchiveRoom(string args)
        {

            try
            {
                SystemRoomBLL.UpdateRoomStatus(args.Trim());

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefin-01", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Populate Facility
        /// </summary>
        /// <param name="facilityId"></param>
        private void PopulateFacility(string facilityId)
        {
            SystemFacility facility = new SystemFacility();
          
            try
            {
                DataSet dsFacility = SystemFacilityBLL.GetFacility(facilityId);
                facility = SystemFacilityBLL.GetSingleLocation(facilityId,dsFacility.Tables[0]);
                txtFacilityId.Text = facility.s_facility_id_pk;
                txtFacilityName.Text = facility.s_facility_name;
                txtFacilityDescription.InnerText = facility.s_facility_desc;
                ddlStatus.SelectedValue = facility.s_facility_status_id_fk;
                ddlFacilityType.SelectedValue = facility.s_facility_type_id_fk;
                txtContact.Text = facility.s_facility_contact;
                txtEmailAddress.Text = facility.s_facility_email_address;
                txtPhone.Text = facility.s_facility_phone;
                txtAddress1.Text = facility.s_facility_address;
                txtAddress2.Text = facility.s_facility_address1;
                txtAddress3.Text = facility.s_facility_address2;
                txtCity.Text = facility.s_facility_city;
                txtState.Text = facility.s_facility_state;
                txtZipCode.Text = facility.s_facility_zip_code;
                ddlCountry.SelectedValue = facility.s_facility_country_id_fk.ToString();
                ddlLocale.SelectedValue = facility.s_facility_locale_id_fk;
                ddlTimezone.SelectedValue = facility.s_facility_time_zone_id_fk.ToString();
                //for reset to store resource locale in session
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = SystemFacilityBLL.GetFacilityLocale(editFacilityId);
                SessionWrapper.Facility_Room_Resource = TempDataTables.TempResource();
                SessionWrapper.Facility_Rooms = TempDataTables.TempRoom();
                //for reset
                SessionWrapper.Reset_Rooms = dsFacility.Tables[2];
                SessionWrapper.Reset_Room_Resource = dsFacility.Tables[3];
                SessionWrapper.Reset_Facility_Rooms = dsFacility.Tables[2];
                SessionWrapper.Reset_Facility_Room_Resource = dsFacility.Tables[3];

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnFooterSaveFacility_Click(object sender, EventArgs e)
        {
            UpdateFacility();
        }
        protected void btnHeaderSaveFacility_Click(object sender, EventArgs e)
        {
            UpdateFacility();
        }
        /// <summary>
        /// Update Facility
        /// </summary>
        private void UpdateFacility()
        {
            SystemFacility updateFacility = new SystemFacility();

            updateFacility.s_facility_system_id_pk = editFacilityId;
            updateFacility.s_facility_id_pk = txtFacilityId.Text;
            updateFacility.s_facility_name = txtFacilityName.Text;
            updateFacility.s_facility_desc = txtFacilityDescription.InnerText;
            updateFacility.s_facility_status_id_fk = ddlStatus.SelectedValue;
            updateFacility.s_facility_type_id_fk = ddlFacilityType.SelectedValue;
            updateFacility.s_facility_contact = txtContact.Text;
            updateFacility.s_facility_email_address = txtEmailAddress.Text;
            updateFacility.s_facility_phone = txtPhone.Text;
            updateFacility.s_facility_address = txtAddress1.Text;
            updateFacility.s_facility_address1 = txtAddress2.Text;
            updateFacility.s_facility_address2 = txtAddress3.Text;
            updateFacility.s_facility_city = txtCity.Text;
            updateFacility.s_facility_state = txtState.Text;
            updateFacility.s_facility_zip_code = txtZipCode.Text;
            updateFacility.s_facility_country_id_fk = Convert.ToInt16(ddlCountry.SelectedValue);
            updateFacility.s_facility_locale_id_fk = ddlLocale.SelectedValue;
            updateFacility.s_facility_time_zone_id_fk = Convert.ToInt16(ddlTimezone.SelectedValue);

            try
            {
                int result = SystemFacilityBLL.UpdateFacility(updateFacility);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerText = LocalResources.GetLabel("app_update_sucess_msg_text");
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
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }
        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }
        /// <summary>
        /// reset facility
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemFacilityBLL.ResetFacility(editFacilityId, ConvertDataTableToXml(SessionWrapper.TempLocale), ConvertDataTableToXml(SessionWrapper.Reset_Rooms), ConvertDataTableToXml(SessionWrapper.Reset_Room_Resource));
               // SystemFacilityBLL.DeleteFacilityLocale(editFacilityId, ConvertDataTableToXml(SessionWrapper.TempLocale));
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefin-01.aspx", ex.Message);
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
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Facilities/samfimp-01.aspx");
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Facilities/samfimp-01.aspx");
        }
        private void ClearFacilitySession()
        {
            SessionWrapper.s_room_system_id_pk = string.Empty;
            SessionWrapper.Reset_Facility_Rooms.Clear();
            SessionWrapper.Reset_Facility_Room_Resource.Clear();
            SessionWrapper.Reset_Rooms.Clear();
            SessionWrapper.Reset_Room_Resource.Clear();
        }
    }
}