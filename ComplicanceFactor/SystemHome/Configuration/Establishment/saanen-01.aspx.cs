using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Establishment
{
    public partial class saanen_01 : BasePage
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
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_establishment_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Establishment/samemp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_establishment_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_establishment_text") + "</a>";

                    //temp locale column
                    SessionWrapper.Locale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                  

                    //Bind Establishment Status
                    ddlStatus.DataSource = SystemEstablishmentBLL.GetStatus(SessionWrapper.CultureName,"saanfin-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind Establishment type
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
                        PopulateEstablishment(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                }
                // gvRooms.DataSource = SessionWrapper.Establishment_Rooms;
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
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message);
                    }
                }
            }
        }
      
        protected void btnHeaderSaveNewEstablishment_Click(object sender, EventArgs e)
        {
            SaveEstablishment();
        }

        protected void btnFooterSaveNewEstablishment_Click(object sender, EventArgs e)
        {
            SaveEstablishment();
        }
        /// <summary>
        /// Save the Establishment
        /// </summary>
        public void SaveEstablishment()
        {
            SystemEstablishment createEstablishment = new SystemEstablishment();

            createEstablishment.s_establishment_system_id_pk = Guid.NewGuid().ToString();
            createEstablishment.s_establishment_id_pk = txtEstablishmentId.Text;
            createEstablishment.s_establishment_name = txtEstablishmentName.Text;
            createEstablishment.s_establishment_desc = txtEstablishmentDescription.InnerText;
            createEstablishment.s_establishment_status_id_fk = ddlStatus.SelectedValue;
            createEstablishment.s_establishment_city = txtCity.Text;
            createEstablishment.s_establishment_state = txtState.Text;
            createEstablishment.s_establishment_zip_code = txtZipCode.Text;
            createEstablishment.s_establishment_country_id_fk = Convert.ToInt16(ddlCountry.SelectedValue);
            createEstablishment.s_establishment_locale_id_fk = ddlLocale.SelectedValue;
            createEstablishment.s_establishment_time_zone_id_fk = Convert.ToInt16(ddlTimezone.SelectedValue);
            createEstablishment.s_establishment_locale = ConvertDataTableToXml(SessionWrapper.Locale);
           // createEstablishment.s_room = ConvertDataTableToXml(SessionWrapper.Establishment_Rooms);
           // createEstablishment.s_room_resource = ConvertDataTableToXml(SessionWrapper.Establishment_Room_Resource);
          
            try
            {
                int result = SystemEstablishmentBLL.CreateNewEstablishment(createEstablishment);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/Establishment/saeen-01.aspx?edit=" + SecurityCenter.EncryptText(createEstablishment.s_establishment_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate the value for Copy
        /// </summary>
        /// <param name="EstablishmentId"></param>
        private void PopulateEstablishment(string EstablishmentId)
        {
            SystemEstablishment Establishment = new SystemEstablishment();

            try
            {
                DataSet dsEstablishment = SystemEstablishmentBLL.GetEstablishment(EstablishmentId);
                Establishment = SystemEstablishmentBLL.GetSingleLocation(EstablishmentId, dsEstablishment.Tables[0]);

                txtEstablishmentId.Text = Establishment.s_establishment_id_pk + "_Copy";
                txtEstablishmentName.Text = Establishment.s_establishment_name;
                txtEstablishmentDescription.InnerText = Establishment.s_establishment_desc;
                ddlStatus.SelectedValue = Establishment.s_establishment_status_id_fk;
                txtCity.Text = Establishment.s_establishment_city;
                txtState.Text = Establishment.s_establishment_state;
                txtZipCode.Text = Establishment.s_establishment_zip_code;
                ddlCountry.SelectedValue = Establishment.s_establishment_country_id_fk.ToString();
                ddlLocale.SelectedValue = Establishment.s_establishment_locale_id_fk;
                ddlTimezone.SelectedValue = Establishment.s_establishment_time_zone_id_fk.ToString();
                SessionWrapper.Locale = dsEstablishment.Tables[1];
                
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanen-01.aspx", ex.Message);
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
            Response.Redirect("~/SystemHome/Configuration/Establishment/samemp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Facilities/samemp-01.aspx");
        }
    }
}