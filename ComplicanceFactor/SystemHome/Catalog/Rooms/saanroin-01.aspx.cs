using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Rooms
{
    public partial class saanroin_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //hide validation summary for popups
                vs_saanroin.Style.Add("display", "none");
                if (!IsPostBack)
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Rooms/samroimp-01.aspx>" + LocalResources.GetLabel("app_manage_rooms_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_room_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Rooms/samroimp-01.aspx>" + LocalResources.GetLabel("app_manage_rooms_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_room_text");


                    //temp locale column
                    SessionWrapper.Locale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    SessionWrapper.Facility_Room_Resource = TempDataTables.TempResource();
                    SessionWrapper.Reset_Facility_Room_Resource = TempDataTables.TempResource();
                    SessionWrapper.c_facility_name = string.Empty;
                    SessionWrapper.c_facility_system_id_pk = string.Empty;
                    //Bind Status
                    ddlStatus.DataSource = SystemRoomBLL.GetStatus(SessionWrapper.CultureName,"saanroin-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    // Bind RoomType
                    ddlRoomType.DataSource = SystemRoomBLL.GetRoomType(SessionWrapper.CultureName);
                    ddlRoomType.DataBind();

                    ListItem itemToRemove = ddlRoomType.Items.FindByValue("app_ddl_all_text");
                    ddlRoomType.Items.Remove(itemToRemove);

                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateRoom(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                    //set room system id
                    SessionWrapper.s_room_system_id_pk = Guid.NewGuid().ToString();

                }
                //bind room resource
                gvResources.DataSource = SessionWrapper.Facility_Room_Resource;
                gvResources.DataBind();
                //get facility name
                lblFacility.Text = SessionWrapper.c_facility_name;
                if (!string.IsNullOrEmpty(lblFacility.Text))
                {
                    btnFacility.Text = LocalResources.GetLabel("app_change_button_text");
                }
                else
                {
                    btnFacility.Text = LocalResources.GetLabel("app_select_button_text");
                }
                txtTempFacility.Text = lblFacility.Text;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Delete resource
        /// </summary>
        /// <param name="s_resource_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteResource(string args)
        {

            try
            {
                var rows = SessionWrapper.Facility_Room_Resource.Select("s_resource_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Facility_Room_Resource.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saafrm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saafrm-01.aspx", ex.Message);
                    }
                }
            }


        }
        protected void btnHeaderSaveNewRoom_Click(object sender, EventArgs e)
        {
            SaveRoom();
        }

        protected void btnFooterSaveNewRoom_Click(object sender, EventArgs e)
        {
            SaveRoom();
        }
        /// <summary>
        /// Save Room Value
        /// </summary>
        private void SaveRoom()
        {
            SystemRoom createRoom = new SystemRoom();
            createRoom.s_room_system_id_pk = SessionWrapper.s_room_system_id_pk;
            createRoom.s_room_id_pk = txtRoomId.Text;
            createRoom.s_room_name = txtRoomName.Text;
            createRoom.s_room_desc = txtRoomDescription.InnerText;
            createRoom.s_room_status_id_fk = ddlStatus.SelectedValue;
            createRoom.s_room_type_id_fk = ddlRoomType.SelectedValue;
            createRoom.s_room_facility_id_fk = SessionWrapper.c_facility_system_id_pk;
            createRoom.s_room_locale = ConvertDataTableToXml(SessionWrapper.Locale);
            createRoom.s_room_resource = ConvertDataTableToXml(SessionWrapper.Facility_Room_Resource);

            try
            {
                int result = SystemRoomBLL.CreateNewRoom(createRoom);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Rooms/saeroin-01.aspx?edit=" + SecurityCenter.EncryptText(createRoom.s_room_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate the values for copy
        /// </summary>
        /// <param name="editRoomId"></param>
        private void PopulateRoom(string editRoomId)
        {
            SystemRoom room = new SystemRoom();
            DataSet dsRoom = SystemRoomBLL.GetRoom(editRoomId);
            DataTable dtResource = new DataTable();
            dtResource = dsRoom.Tables[1];
            try
            {
                room = SystemRoomBLL.GetSingleRoom(editRoomId, dsRoom.Tables[0]);
                txtRoomId.Text = room.s_room_id_pk + "_copy";
                txtRoomName.Text = room.s_room_name;
                txtRoomDescription.InnerText = room.s_room_desc;
                ddlRoomType.SelectedValue = room.s_room_type_id_fk;
                ddlStatus.SelectedValue = room.s_room_status_id_fk;
                SessionWrapper.c_facility_name = room.s_facility_name;
                SessionWrapper.c_facility_system_id_pk = room.s_room_facility_id_fk;
                SessionWrapper.Locale = dsRoom.Tables[2];

                //change the room id for resource
                //for (int j = 0; j <= dtResource.Rows.Count - 1; j++)
                //{

                //    var resourceRows = dtResource.Select("s_facility_room_id_fk= '" + SecurityCenter.DecryptText(Request.QueryString["Copy"]) + "'");
                //    int rowResourceLength = resourceRows.Length;
                //    if (rowResourceLength > 0)
                //    {
                //        var resourceindexOfRow = dtResource.Rows.IndexOf(resourceRows[j]);

                //        dtResource.Rows[resourceindexOfRow]["s_facility_room_id_fk"] = SessionWrapper.s_room_system_id_pk;
                //        dtResource.AcceptChanges();

                //    }
                //}
                SessionWrapper.Facility_Room_Resource = dtResource;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanroin-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Rooms/samroimp-01.aspx");
        }
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Rooms/samroimp-01.aspx");
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