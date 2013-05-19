using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Rooms
{
    public partial class saeroin_01 : BasePage
    {
        string editRoomId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide summary
            vs_saeroin.Style.Add("display", "none");
            //Edit
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editRoomId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            //set location id
            hdRoomId.Value = editRoomId;
            //create object for room dataset
            DataSet dsRoom = new DataSet();
            //get room and resources
            dsRoom = SystemRoomBLL.GetRoom(editRoomId);
            try
            {
                if (!IsPostBack)
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Rooms/samroimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_rooms_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_room_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Rooms/samroimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_rooms_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_room_text");


                    //clear room session
                    ClearRoomSession();
                    //Bind Status
                    ddlStatus.DataSource = SystemRoomBLL.GetStatus(SessionWrapper.CultureName, "saeroin-01");
                    ddlStatus.DataBind();
                    // Bind RoomType
                    ddlRoomType.DataSource = SystemRoomBLL.GetRoomType(SessionWrapper.CultureName);
                    ddlRoomType.DataBind();
                    ListItem itemToRemove = ddlRoomType.Items.FindByValue("app_ddl_all_text");
                    ddlRoomType.Items.Remove(itemToRemove);
                    //popuplate room
                    PopulateRoom(editRoomId,dsRoom.Tables[0]);
                    //for reset to store resource locale in session
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = SystemRoomBLL.GetRoomLocale(editRoomId);
                    //add temp datatable for resource
                    SessionWrapper.Facility_Room_Resource = TempDataTables.TempResource();
                    //for reset
                    SessionWrapper.Reset_Facility_Room_Resource = TempDataTables.TempResource();
                    SessionWrapper.Reset_Facility_Room_Resource = dsRoom.Tables[1];
                    //Success Message
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetGlobalLabel("app_insert_sucess_msg_text");
                    }
                }
                //get facility name
                lblFacility.Text = SessionWrapper.c_facility_name;
                if (!string.IsNullOrEmpty(lblFacility.Text))
                {
                    btnFacility.Text = LocalResources.GetGlobalLabel("app_change_button_text");
                }
                else
                {
                    btnFacility.Text = LocalResources.GetGlobalLabel("app_select_button_text");
                }
                //set edit room id in sessin
                SessionWrapper.s_room_system_id_pk = editRoomId;
                //Bind resoruces
                gvResources.DataSource = dsRoom.Tables[1];
                gvResources.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message);
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
                SystemFacilityBLL.DeleteRoomResource(args.Trim());

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message);
                    }
                }
            }


        }
        //clear facility session
        private void ClearRoomSession()
        {
            SessionWrapper.s_room_system_id_pk = string.Empty;
            SessionWrapper.Facility_Room_Resource.Clear();

        }
        /// <summary>
        /// Populate Room value for Edit
        /// </summary>
        /// <param name="editRoomId"></param>
        private void PopulateRoom(string editRoomId,DataTable dtRoom)
        {
            SystemRoom room = new SystemRoom();
          
            try
            {
                room = SystemRoomBLL.GetSingleRoom(editRoomId, dtRoom);
                txtRoomId.Text = room.s_room_id_pk;
                txtRoomName.Text = room.s_room_name;
                txtRoomDescription.InnerText = room.s_room_desc;
                ddlRoomType.SelectedValue = room.s_room_type_id_fk;
                ddlStatus.SelectedValue = room.s_room_status_id_fk;
                SessionWrapper.c_facility_name = room.s_facility_name;
                SessionWrapper.c_facility_system_id_pk = room.s_room_facility_id_fk;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Update Room value
        /// </summary>
        private void  UpdateRoom()
        {
            SystemRoom  updateRoom = new SystemRoom();

            updateRoom.s_room_system_id_pk = editRoomId;
            updateRoom.s_room_id_pk = txtRoomId.Text;
            updateRoom.s_room_name = txtRoomName.Text;
            updateRoom.s_room_desc = txtRoomDescription.InnerText;
            updateRoom.s_room_status_id_fk = ddlStatus.SelectedValue;
            updateRoom.s_room_type_id_fk = ddlRoomType.SelectedValue;
            updateRoom.s_room_facility_id_fk = SessionWrapper.c_facility_system_id_pk;

            try
            {
                int result = SystemRoomBLL.UpdateRoom(updateRoom);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerText = LocalResources.GetGlobalLabel("app_update_sucess_msg_text"); 
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
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message);
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
        protected void btnFooterSaveRoom_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }

        protected void btnHeaderSaveRoom_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }
        /// <summary>
        /// Reset
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemRoomBLL.ResetRoom(editRoomId, ConvertDataTableToXml(SessionWrapper.TempLocale), ConvertDataTableToXml(SessionWrapper.Reset_Facility_Room_Resource));
                //SystemRoomBLL.DeleteRoomLocale(editRoomId, ConvertDataTableToXml(SessionWrapper.TempLocale));
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeroin-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Rooms/samroimp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Rooms/samroimp-01.aspx");
        }
    }
}