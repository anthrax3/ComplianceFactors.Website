using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities.Room
{
    public partial class saafrm_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide validation summary for resource popup
            vs_saafrm.Style.Add("display", "none");
            if (!IsPostBack)
            {
                //Bind status
                ddlStatus.DataSource = SystemRoomBLL.GetStatus(SessionWrapper.CultureName, "saafrm-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";
                //Bind room type
                ddlRoomType.DataSource = SystemRoomBLL.GetRoomType(SessionWrapper.CultureName);
                ddlRoomType.DataBind();
                ListItem itemRemove = ddlRoomType.Items.FindByValue("app_ddl_all_text");
                ddlRoomType.Items.Remove(itemRemove);
                //set room system id
                SessionWrapper.s_room_system_id_pk = Guid.NewGuid().ToString();
                //Add column in resource datatable
                SessionWrapper.Temp_Facility_Room_Resource = TempDataTables.TempResource();
                if (Request.QueryString["mode"] == "copy")
                {
                    //copyroom
                    CopyRoom(Request.QueryString["editFacilityId"], Request.QueryString["copyRoomId"]);
                }
            }
            //bind room resource
            gvResources.DataSource = SessionWrapper.Temp_Facility_Room_Resource;
            gvResources.DataBind();

        }
        /// <summary>
        /// get particular room from session on create facility
        /// </summary>
        /// <param name="dtRoom"></param>
        private void GetRoom(DataTable dtRoom, string copyRoomId)
        {
            SystemRoom room = new SystemRoom();
            room = SystemFacilityBLL.TempGetFacilityRoom(copyRoomId, dtRoom);
            txtRoomId.Text = room.s_room_id_pk + "_Copy";
            txtRoomName.Text = room.s_room_name;
            txtRoomDescription.Value = room.s_room_desc;
            ddlStatus.SelectedValue = room.s_room_status_id_fk;
            ddlRoomType.SelectedValue = room.s_room_type_id_fk;

        }
        /// <summary>
        /// copy room
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="roomId"></param>
        private void CopyRoom(string facilityId, string roomId)
        {
            //create object for room dataset
            DataSet dsRoom = new DataSet();
            //get room and resources
            dsRoom = SystemRoomBLL.GetRoom(roomId);
            //Copy room
            DataTable dtRooms = new DataTable();
            dtRooms = dsRoom.Tables[0];
            GetRoom(dtRooms, roomId);
            DataTable dtResource = new DataTable();
            dtResource = dsRoom.Tables[1];

            for (int i = 0; i <= dtRooms.Rows.Count - 1; i++)
            {
                string s_facility_room_id_pk = SessionWrapper.s_room_system_id_pk;
                //room
                var roomRows = dtRooms.Select("s_facility_id_fk= '" + facilityId + "'");
                int rowDeliveryLength = roomRows.Length;
                if (rowDeliveryLength > 0)
                {
                    var indexOfRow = dtRooms.Rows.IndexOf(roomRows[i]);

                    //resources
                    for (int j = 0; j <= dtResource.Rows.Count - 1; j++)
                    {

                        var resourceRows = dtResource.Select("s_facility_room_id_fk= '" + dtRooms.Rows[indexOfRow]["s_room_system_id_pk"] + "'");
                        int rowResourceLength = resourceRows.Length;
                        if (rowResourceLength > 0)
                        {
                            var resourceindexOfRow = dtResource.Rows.IndexOf(resourceRows[0]);
                            if (dtRooms.Rows[indexOfRow]["s_room_system_id_pk"].ToString().Trim() == dtResource.Rows[resourceindexOfRow]["s_facility_room_id_fk"].ToString().Trim())
                            {
                                dtResource.Rows[resourceindexOfRow]["s_facility_room_id_fk"] = s_facility_room_id_pk;
                                dtResource.AcceptChanges();
                            }
                        }
                    }
                    dtRooms.Rows[indexOfRow]["s_room_system_id_pk"] = s_facility_room_id_pk;
                    dtRooms.AcceptChanges();
                }
            }
            //room
            //SessionWrapper.Reset_Facility_Rooms = dtRooms;
            // SessionWrapper.Facility_Rooms = dtRooms;
            // resource
            //SessionWrapper.Reset_Facility_Room_Resource = dtResource;
            //SessionWrapper.Facility_Room_Resource = dtResource;
            SessionWrapper.Temp_Facility_Room_Resource = dtResource;

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
                var rows = SessionWrapper.Temp_Facility_Room_Resource.Select("s_resource_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Temp_Facility_Room_Resource.AcceptChanges();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveRoom();
            //close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        private void SaveRoom()
        {
            try
            {
                AddDataToResource(txtRoomId.Text, txtRoomName.Text, txtRoomDescription.Value, ddlStatus.SelectedValue, ddlRoomType.SelectedValue, ddlRoomType.SelectedItem.Text, SessionWrapper.Facility_Rooms);
                //use can add multiple room, so each room have multiple resource
                SessionWrapper.Facility_Room_Resource.Merge(SessionWrapper.Temp_Facility_Room_Resource, true, MissingSchemaAction.Ignore);
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create" && !string.IsNullOrEmpty(Request.QueryString["editFacilityId"]) || Request.QueryString["mode"] == "copy")
                {
                    SystemFacilityBLL.InsertRoomAndResource(Request.QueryString["editFacilityId"], ConvertDataTableToXml(SessionWrapper.Facility_Rooms), ConvertDataTableToXml(SessionWrapper.Temp_Facility_Room_Resource));
                }
                //for reset
                DataSet dsFacility = SystemFacilityBLL.GetFacility(Request.QueryString["editFacilityId"]);
                SessionWrapper.Reset_Facility_Rooms = dsFacility.Tables[2];
                SessionWrapper.Reset_Facility_Room_Resource = dsFacility.Tables[3];

            }
            catch (Exception ex)
            {
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
        /// <summary>
        /// AddDataToFacilityResource
        /// </summary>
        /// <param name="s_room_system_id_pk"></param>
        /// <param name="s_room_id_pk"></param>
        /// <param name="s_room_name"></param>
        /// <param name="s_room_description"></param>
        /// <param name="s_room_status_id_fk"></param>
        /// <param name="s_room_type_id_fk"></param>
        /// <param name="dtFacilityRoom"></param>
        private void AddDataToResource(string s_room_id_pk, string s_room_name, string s_room_description, string s_room_status_id_fk, string s_room_type_id_fk, string s_room_type_text, DataTable dtFacilityRoom)
        {
            DataRow row;
            row = dtFacilityRoom.NewRow();
            row["s_room_system_id_pk"] = SessionWrapper.s_room_system_id_pk;
            row["s_room_id_pk"] = s_room_id_pk;
            row["s_room_name"] = s_room_name;
            row["s_room_description"] = s_room_description;
            row["s_room_status_id_fk"] = s_room_status_id_fk;
            row["s_room_type_id_fk"] = s_room_type_id_fk;
            row["s_room_type_text"] = s_room_type_text;
            dtFacilityRoom.Rows.Add(row);
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);

        }
    }
}