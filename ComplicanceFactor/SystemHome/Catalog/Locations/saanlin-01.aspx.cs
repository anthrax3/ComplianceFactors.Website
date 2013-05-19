using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Locations
{
    public partial class saanlin_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Label BreadCrumb
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Locations/samlimp-01.aspx>" +LocalResources.GetLabel("app_manage_locations_text")  + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_location_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Locations/samlimp-01.aspx>" + LocalResources.GetLabel("app_manage_locations_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_location_text");


                   

                    //temp locale column
                    SessionWrapper.Locale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    // bind the status
                    ddlStatus.DataSource = SystemLocationBLL.GetStatus(SessionWrapper.CultureName,"saanlin-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";

                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateLocation(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
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
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Save Location 
        /// </summary>
        private void SaveLocation()
        {
            SystemLocation createLocation = new SystemLocation();
            createLocation.c_location_system_id_pk = Guid.NewGuid().ToString();
            createLocation.c_location_id_pk = txtLocationId.Text;
            createLocation.c_location_name = txtLocationName.Text;
            createLocation.c_location_desc = txtLocationDescription.InnerText;
            createLocation.c_location_airport_code = txtAirportCode.Text;
            createLocation.c_location_status_id_fk = ddlStatus.SelectedValue;
            createLocation.s_location_locale = ConvertDataTableToXml(SessionWrapper.Locale);
            try
            {
                int result = SystemLocationBLL.CreateNewLocation(createLocation);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Locations/saelin-01.aspx?edit=" + SecurityCenter.EncryptText(createLocation.c_location_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message);
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
                txtLocationId.Text = location.c_location_id_pk + "_copy";
                txtLocationName.Text = location.c_location_name;
                txtLocationDescription.InnerText = location.c_location_desc;
                ddlStatus.SelectedValue = location.c_location_status_id_fk;
                txtAirportCode.Text = location.c_location_airport_code;
                SessionWrapper.Locale = dsLocation.Tables[1];
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanlin-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveNewLocation_Click(object sender, EventArgs e)
        {
            SaveLocation();
        }

        protected void btnFooterSaveNewLocation_Click(object sender, EventArgs e)
        {
            SaveLocation();
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
            Response.Redirect("~/SystemHome/Catalog/Locations/samlimp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Locations/samlimp-01.aspx");
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
    }
}