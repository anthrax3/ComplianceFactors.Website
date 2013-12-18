using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Establishment
{
    public partial class saeen_01 : BasePage
    {
        string editEstablishmentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Edit
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editEstablishmentId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            //get Establishment id using jquery
            hdEstablishmentId.Value = editEstablishmentId;
            try
            {
                if (!IsPostBack)
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Facilities/samfimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_facilities_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_establishment_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Establishment/samemp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_establishment_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_establishment_text") + "</a>";

                    //Status Bind
                    ddlStatus.DataSource = SystemEstablishmentBLL.GetStatus(SessionWrapper.CultureName, "saefin-01");
                    ddlStatus.DataBind();
                 
                    //Country
                    ddlCountry.DataSource = SystemEstablishmentBLL.GetCountry();
                    ddlCountry.DataBind();
                    //Bind Locale
                    ddlLocale.DataSource = SystemEstablishmentBLL.GetLocale();
                    ddlLocale.DataBind();
                    //Bind TimeZone
                    ddlTimezone.DataSource = SystemEstablishmentBLL.GetTimeZone();
                    ddlTimezone.DataBind();
                    //clear Establishment session
                    ClearEstablishmentSession();
                    //Populate Establishment
                    PopulateEstablishment(editEstablishmentId);
                   
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
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message);
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
                        Logger.WriteToErrorLog("saeen-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeen-01", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Populate Establishment
        /// </summary>
        /// <param name="EstablishmentId"></param>
        private void PopulateEstablishment(string EstablishmentId)
        {
            SystemEstablishment Establishment = new SystemEstablishment();
          
            try
            {
                DataSet dsEstablishment = SystemEstablishmentBLL.GetEstablishment(EstablishmentId);
                Establishment = SystemEstablishmentBLL.GetSingleLocation(EstablishmentId,dsEstablishment.Tables[0]);
                txtEstablishmentId.Text = Establishment.s_establishment_id_pk;
                txtEstablishmentName.Text = Establishment.s_establishment_name;
                txtEstablishmentDescription.InnerText = Establishment.s_establishment_desc;
                ddlStatus.SelectedValue = Establishment.s_establishment_status_id_fk;
              
                txtCity.Text = Establishment.s_establishment_city;
                txtState.Text = Establishment.s_establishment_state;
                txtZipCode.Text = Establishment.s_establishment_zip_code;
                ddlCountry.SelectedValue = Establishment.s_establishment_country_id_fk.ToString();
                ddlLocale.SelectedValue = Establishment.s_establishment_locale_id_fk;
                ddlTimezone.SelectedValue = Establishment.s_establishment_time_zone_id_fk.ToString();
                //for reset to store resource locale in session
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = SystemEstablishmentBLL.GetEstablishmentLocale(editEstablishmentId);
              

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnFooterSaveEstablishment_Click(object sender, EventArgs e)
        {
            UpdateEstablishment();
        }
        protected void btnHeaderSaveEstablishment_Click(object sender, EventArgs e)
        {
            UpdateEstablishment();
        }
        /// <summary>
        /// Update Establishment
        /// </summary>
        private void UpdateEstablishment()
        {
            SystemEstablishment updateEstablishment = new SystemEstablishment();

            updateEstablishment.s_establishment_system_id_pk = editEstablishmentId;
            updateEstablishment.s_establishment_id_pk = txtEstablishmentId.Text;
            updateEstablishment.s_establishment_name = txtEstablishmentName.Text;
            updateEstablishment.s_establishment_desc = txtEstablishmentDescription.InnerText;
            updateEstablishment.s_establishment_status_id_fk = ddlStatus.SelectedValue;
          
            updateEstablishment.s_establishment_city = txtCity.Text;
            updateEstablishment.s_establishment_state = txtState.Text;
            updateEstablishment.s_establishment_zip_code = txtZipCode.Text;
            updateEstablishment.s_establishment_country_id_fk = Convert.ToInt16(ddlCountry.SelectedValue);
            updateEstablishment.s_establishment_locale_id_fk = ddlLocale.SelectedValue;
            updateEstablishment.s_establishment_time_zone_id_fk = Convert.ToInt16(ddlTimezone.SelectedValue);

            try
            {
                int result = SystemEstablishmentBLL.UpdateEstablishment(updateEstablishment);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerText = LocalResources.GetText("app_succ_update_text");
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
        /// reset Establishment
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemEstablishmentBLL.ResetEstablishment(editEstablishmentId, ConvertDataTableToXml(SessionWrapper.TempLocale), ConvertDataTableToXml(SessionWrapper.Reset_Rooms), ConvertDataTableToXml(SessionWrapper.Reset_Room_Resource));
               // SystemEstablishmentBLL.DeleteEstablishmentLocale(editEstablishmentId, ConvertDataTableToXml(SessionWrapper.TempLocale));
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeen-01.aspx", ex.Message);
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
            Response.Redirect("~/SystemHome/Configuration/Establishment/samemp-01.aspx");
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Establishment/samemp-01.aspx");
        }
        private void ClearEstablishmentSession()
        {
            SessionWrapper.s_room_system_id_pk = string.Empty;
         
           // SessionWrapper.Reset_Rooms.Clear();
          //  SessionWrapper.Reset_Room_Resource.Clear();
        }
    }
}