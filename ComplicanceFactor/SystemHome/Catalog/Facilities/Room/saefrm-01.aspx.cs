using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities.Room
{
    public partial class saefrm_01 : BasePage
    {
        private string editRoomId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get edit delivery id
            editRoomId = Request.QueryString["editRoom"];
           //SessionWrapper.Edit_delivery_id_fk = editRoomId;
            ClearFacilityRoomSession();
            if (!IsPostBack)
            {
                //Bind status
                ddlStatus.DataSource = SystemRoomBLL.GetStatus(SessionWrapper.CultureName, "saefrm-01");
                ddlStatus.DataBind();
                //Bind room type
                ddlRoomType.DataSource = SystemRoomBLL.GetRoomType(SessionWrapper.CultureName);
                ddlRoomType.DataBind();
                ListItem itemRemove = ddlRoomType.Items.FindByValue("app_ddl_all_text");
                ddlRoomType.Items.Remove(itemRemove);
                if (!string.IsNullOrEmpty(Request.QueryString["editRoom"]))
                {
                    //Get particular delivery from session
                    DataView dvRooms = new DataView(SessionWrapper.Facility_Rooms);
                    dvRooms.RowFilter = "s_room_system_id_pk= '" + editRoomId + "'";
                    //Get Temp delivery
                    TempGetFacilityRoom(dvRooms.ToTable());
                }
                //for restore
                RevertBack();
            }
            //set edit room id in sessin
            SessionWrapper.s_room_system_id_pk = editRoomId;
            //Get particular room
            DataView dvResources = new DataView(SessionWrapper.Facility_Room_Resource);
            dvResources.RowFilter = "s_facility_room_id_fk= '" + editRoomId + "'";
            //Bind resources
            gvResources.DataSource = dvResources.ToTable();
            gvResources.DataBind();

        }
        /// <summary>
        /// get particular room from session on create facility
        /// </summary>
        /// <param name="dtRoom"></param>
        private void TempGetFacilityRoom(DataTable dtRoom)
        {
            SystemRoom room = new SystemRoom();
            room = SystemFacilityBLL.TempGetFacilityRoom(editRoomId,dtRoom);
            txtRoomId.Text = room.s_room_id_pk;
            txtRoomName.Text = room.s_room_name;
            txtRoomDescription.Value = room.s_room_desc;
            ddlStatus.SelectedValue = room.s_room_status_id_fk;
            ddlRoomType.SelectedValue = room.s_room_type_id_fk;
           
        }
        private void ClearFacilityRoomSession()
        {
            SessionWrapper.s_room_system_id_pk = string.Empty;

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
                var rows = SessionWrapper.Facility_Room_Resource.Select("s_resource_system_id_pk= '" + args.Trim() + "' and s_facility_room_id_fk= '" + SessionWrapper.s_room_system_id_pk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Facility_Room_Resource.AcceptChanges();

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefrm-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefrm-01.aspx", ex.Message);
                    }
                }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }
        private void UpdateRoom()
        {
            var rows = SessionWrapper.Facility_Rooms.Select("s_room_system_id_pk= '" + editRoomId + "'");
            var indexOfRow = SessionWrapper.Facility_Rooms.Rows.IndexOf(rows[0]);
            SessionWrapper.Facility_Rooms.Rows[indexOfRow]["s_room_id_pk"] = txtRoomId.Text;
            SessionWrapper.Facility_Rooms.Rows[indexOfRow]["s_room_name"] = txtRoomName.Text;
            SessionWrapper.Facility_Rooms.Rows[indexOfRow]["s_room_description"] = txtRoomDescription.Value;
            SessionWrapper.Facility_Rooms.Rows[indexOfRow]["s_room_status_id_fk"] = ddlStatus.SelectedValue;
            SessionWrapper.Facility_Rooms.Rows[indexOfRow]["s_room_type_id_fk"] = ddlRoomType.SelectedValue;
            SessionWrapper.Facility_Rooms.AcceptChanges();
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            RestoreRoom();
            Response.Redirect(Request.RawUrl);
        }
        private void RevertBack()
        {
            //Room
            DataTable dtRoom_1 = new DataTable();
            DataTable dtRoom_2 = (DataTable)SessionWrapper.Facility_Rooms;
            dtRoom_1 = dtRoom_2.Copy();
            SessionWrapper.Reset_Facility_Rooms = dtRoom_1;
            //resource
            DataTable dtResource_1 = new DataTable();
            DataTable dtResoruce_2 = (DataTable)SessionWrapper.Facility_Room_Resource;
            dtResource_1 = dtResoruce_2.Copy();
            SessionWrapper.Reset_Facility_Room_Resource = dtResource_1;
        }
        private void RestoreRoom()
        {
            //Room
            DataTable dtRoom_1 = new DataTable();
            DataTable dtRoom_2 = (DataTable)SessionWrapper.Reset_Facility_Rooms;
            dtRoom_1 = dtRoom_2.Copy();
            SessionWrapper.Facility_Rooms = dtRoom_1;
            //Resource
            DataTable dtResource_1 = new DataTable();
            DataTable dtResoruce_2 = (DataTable)SessionWrapper.Reset_Facility_Room_Resource;
            dtResource_1 = dtResoruce_2.Copy();
            SessionWrapper.Facility_Room_Resource = dtResource_1;
        }
    }
}