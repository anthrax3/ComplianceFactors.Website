using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Locations
{
    public partial class saelin_01 : BasePage
    {
        string editLocationId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Edit
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editLocationId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            //set location id
            hdLocationId.Value = editLocationId;
            try
            {
                if (!IsPostBack)
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Locations/samlimp-01.aspx>" + LocalResources.GetLabel("app_manage_locations_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_location_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Locations/samlimp-01.aspx>" + LocalResources.GetLabel("app_manage_locations_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_location_text") + "</a>";

                    // bind the status
                    ddlStatus.DataSource = SystemLocationBLL.GetStatus(SessionWrapper.CultureName,"saelin-01");
                    ddlStatus.DataBind();

                    PopulateLocation(editLocationId);
                    //for reset to store resource locale in session
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = SystemLocationBLL.GetLocationLocale(editLocationId);
                    //Success Message
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
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
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate Location
        /// </summary>
        /// <param name="locationId"></param>
        private void PopulateLocation(string locationId)
        {
            SystemLocation location = new SystemLocation();
            DataSet dsLocation = SystemLocationBLL.GetLocation(locationId);
            try
            {
                location = SystemLocationBLL.GetSingleLocation(locationId, dsLocation.Tables[0]);
                txtLocationId.Text = location.c_location_id_pk;
                txtLocationName.Text = location.c_location_name;
                txtLocationDescription.InnerText = location.c_location_desc;
                ddlStatus.SelectedValue = location.c_location_status_id_fk;
                txtAirportCode.Text = location.c_location_airport_code;

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveLocation_Click(object sender, EventArgs e)
        {
            UpdateLocation();
        }

        protected void btnFooterSaveLocation_Click(object sender, EventArgs e)
        {
            UpdateLocation();
        }
        /// reset resource
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemLocationBLL.DeleteLocationLocale(editLocationId, ConvertDataTableToXml(SessionWrapper.TempLocale),string.Empty);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message);
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
        /// <summary>
        /// Update Location
        /// </summary>
        private void UpdateLocation()
        {
            SystemLocation updateLocation = new SystemLocation();

            updateLocation.c_location_system_id_pk = editLocationId;
            updateLocation.c_location_id_pk = txtLocationId.Text;
            updateLocation.c_location_name = txtLocationName.Text;
            updateLocation.c_location_desc = txtLocationDescription.InnerText;
            updateLocation.c_location_airport_code = txtAirportCode.Text;
            updateLocation.c_location_status_id_fk = ddlStatus.SelectedValue;

            try
            {
                int result = SystemLocationBLL.UpdateLocation(updateLocation);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
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
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saelin-01.aspx", ex.Message);
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

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Locations/samlimp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Locations/samlimp-01.aspx");
        }
    }
}