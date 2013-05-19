using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities
{
    public partial class saanfin_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //hide validation summary for room popup
                vs_saanfin.Style.Add("display", "none");
                if (!IsPostBack)
                {
                    //Label BreadCrumb
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_facility_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_facility_text");

                    //temp locale column
                    SessionWrapper.Locale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    //temp column for room and resource
                    SessionWrapper.Facility_Room_Resource = TempDataTables.TempResource();
                    SessionWrapper.Facility_Rooms = TempDataTables.TempRoom();
                    SessionWrapper.Reset_Facility_Rooms = TempDataTables.TempRoom();
                    SessionWrapper.Reset_Facility_Room_Resource = TempDataTables.TempResource();
                   

                    //Bind facility Status
                    ddlStatus.DataSource = SystemFacilityBLL.GetStatus(SessionWrapper.CultureName,"saanfin-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind Facility type
                    ddlFacilityType.DataSource = SystemFacilityBLL.GetFacilityType(SessionWrapper.CultureName);
                    ddlFacilityType.DataBind();
                    ListItem itemToRemove = ddlFacilityType.Items.FindByValue("app_ddl_all_text");
                    ddlFacilityType.Items.Remove(itemToRemove);
                    //Bind Country
                    ddlCountry.DataSource = SystemFacilityBLL.GetCountry();
                    ddlCountry.DataBind();
                    //Bind Locale
                    ddlLocale.DataSource = SystemFacilityBLL.GetLocale();
                    ddlLocale.DataBind();
                    //Bind TimeZone
                    ddlTimezone.DataSource = SystemFacilityBLL.GetTimeZone();
                    ddlTimezone.DataBind();

                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateFacility(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                }
                // gvRooms.DataSource = SessionWrapper.Facility_Rooms;
                // gvRooms.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// delete room
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteRoom(string args)
        {

            try
            {
                //Delete previous selected course
                if (SessionWrapper.Facility_Rooms.Rows.Count > 0)
                {
                    var rows = SessionWrapper.Facility_Rooms.Select("s_room_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Facility_Rooms.AcceptChanges();
                    if (SessionWrapper.Facility_Room_Resource.Rows.Count > 0)
                    {
                        var rowsResource = SessionWrapper.Facility_Room_Resource.Select("s_facility_room_id_fk= '" + args.Trim() + "'");
                        foreach (var row in rowsResource)
                            row.Delete();
                        SessionWrapper.Facility_Room_Resource.AcceptChanges();
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
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
                    }
                }
            }


        }
        protected void btnHeaderSaveNewFacility_Click(object sender, EventArgs e)
        {
            SaveFacility();
        }

        protected void btnFooterSaveNewFacility_Click(object sender, EventArgs e)
        {
            SaveFacility();
        }
        /// <summary>
        /// Save the Facility
        /// </summary>
        public void SaveFacility()
        {
            SystemFacility createFacility = new SystemFacility();

            createFacility.s_facility_system_id_pk = Guid.NewGuid().ToString();
            createFacility.s_facility_id_pk = txtFacilityId.Text;
            createFacility.s_facility_name = txtFacilityName.Text;
            createFacility.s_facility_desc = txtFacilityDescription.InnerText;
            createFacility.s_facility_status_id_fk = ddlStatus.SelectedValue;
            createFacility.s_facility_type_id_fk = ddlFacilityType.SelectedValue;
            createFacility.s_facility_contact = txtContact.Text;
            createFacility.s_facility_email_address = txtEmailAddress.Text;
            createFacility.s_facility_phone = txtPhone.Text;
            createFacility.s_facility_address = txtAddress1.Text;
            createFacility.s_facility_address1 = txtAddress2.Text;
            createFacility.s_facility_address2 = txtAddress3.Text;
            createFacility.s_facility_city = txtCity.Text;
            createFacility.s_facility_state = txtState.Text;
            createFacility.s_facility_zip_code = txtZipCode.Text;
            createFacility.s_facility_country_id_fk = Convert.ToInt16(ddlCountry.SelectedValue);
            createFacility.s_facility_locale_id_fk = ddlLocale.SelectedValue;
            createFacility.s_facility_time_zone_id_fk = Convert.ToInt16(ddlTimezone.SelectedValue);
            createFacility.s_facility_locale = ConvertDataTableToXml(SessionWrapper.Locale);
           // createFacility.s_room = ConvertDataTableToXml(SessionWrapper.Facility_Rooms);
           // createFacility.s_room_resource = ConvertDataTableToXml(SessionWrapper.Facility_Room_Resource);
          
            try
            {
                int result = SystemFacilityBLL.CreateNewFacility(createFacility);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Facilities/saefin-01.aspx?edit=" + SecurityCenter.EncryptText(createFacility.s_facility_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate the value for Copy
        /// </summary>
        /// <param name="facilityId"></param>
        private void PopulateFacility(string facilityId)
        {
            SystemFacility facility = new SystemFacility();

            try
            {
                DataSet dsFacility = SystemFacilityBLL.GetFacility(facilityId);
                facility = SystemFacilityBLL.GetSingleLocation(facilityId, dsFacility.Tables[0]);

                txtFacilityId.Text = facility.s_facility_id_pk + "_Copy";
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
                SessionWrapper.Locale = dsFacility.Tables[1];
                //Copy room
                //DataTable dtRooms = new DataTable();
                //dtRooms = dsFacility.Tables[2];
                //DataTable dtResource = new DataTable();
                //dtResource = dsFacility.Tables[3];

                //for (int i = 0; i <= dtRooms.Rows.Count - 1; i++)
                //{

                //    string s_facility_room_id_pk = Guid.NewGuid().ToString();
                //    //room
                //    var roomRows = dtRooms.Select("s_facility_id_fk= '" + facilityId + "'");
                //    int rowDeliveryLength = roomRows.Length;
                //    if (rowDeliveryLength > 0)
                //    {
                //        var indexOfRow = dtRooms.Rows.IndexOf(roomRows[i]);

                //        //resources
                //        for (int j = 0; j <= dtResource.Rows.Count - 1; j++)
                //        {

                //            var resourceRows = dtResource.Select("s_facility_room_id_fk= '" + dtRooms.Rows[indexOfRow]["s_room_system_id_pk"] + "'");
                //            int rowResourceLength = resourceRows.Length;
                //            if (rowResourceLength > 0)
                //            {
                //                var resourceindexOfRow = dtResource.Rows.IndexOf(resourceRows[0]);
                //                if (dtRooms.Rows[indexOfRow]["s_room_system_id_pk"].ToString().Trim() == dtResource.Rows[resourceindexOfRow]["s_facility_room_id_fk"].ToString().Trim())
                //                {
                //                    dtResource.Rows[resourceindexOfRow]["s_facility_room_id_fk"] = s_facility_room_id_pk;
                //                    dtResource.AcceptChanges();
                //                }
                //            }
                //        }
                //        dtRooms.Rows[indexOfRow]["s_room_system_id_pk"] = s_facility_room_id_pk;
                //        dtRooms.AcceptChanges();
                //    }


                //}

                //room
                //SessionWrapper.Reset_Facility_Rooms = dtRooms;
                //SessionWrapper.Facility_Rooms = dtRooms;
                //resource
                //SessionWrapper.Reset_Facility_Room_Resource = dtResource;
                //SessionWrapper.Facility_Room_Resource = dtResource;

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanfin-01.aspx", ex.Message);
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
        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Facilities/samfimp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Facilities/samfimp-01.aspx");
        }
    }
}