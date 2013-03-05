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
    public partial class saefrm_02 : BasePage
    {
        private string editRoomId;
        protected void Page_Load(object sender, EventArgs e)
        {      //Get room id
            editRoomId = Request.QueryString["editRoomId"];
            //create object for room dataset
            DataSet dsRoom = new DataSet();
            //get room and resources
            dsRoom = SystemRoomBLL.GetRoom(editRoomId);
            if (!IsPostBack)
            {
                ClearFacilitySession();
                //Bind status
                ddlStatus.DataSource = SystemRoomBLL.GetStatus(SessionWrapper.CultureName, "saefrm-02");
                ddlStatus.DataBind();
                //Bind room type
                ddlRoomType.DataSource = SystemRoomBLL.GetRoomType(SessionWrapper.CultureName);
                ddlRoomType.DataBind();
                ListItem itemRemove = ddlRoomType.Items.FindByValue("app_ddl_all_text");
                ddlRoomType.Items.Remove(itemRemove);
                if (!string.IsNullOrEmpty(Request.QueryString["editRoomId"]))
                {
                    GetRoom(dsRoom.Tables[0]);
                }
            }
            //set edit room id in sessin
            SessionWrapper.s_room_system_id_pk = editRoomId;
            //Bind resoruces
            gvResources.DataSource = dsRoom.Tables[1];
            gvResources.DataBind();

        }
        //clear facility session
        private void ClearFacilitySession()
        {
            SessionWrapper.s_room_system_id_pk = string.Empty;
            SessionWrapper.Temp_Facility_Room_Resource.Clear();

        }
        /// <summary>
        /// get particular room from session on create facility
        /// </summary>
        /// <param name="dtRoom"></param>
        private void GetRoom(DataTable dtRoom)
        {
            SystemRoom room = new SystemRoom();
            room = SystemFacilityBLL.TempGetFacilityRoom(editRoomId, dtRoom);
            txtRoomId.Text = room.s_room_id_pk;
            txtRoomName.Text = room.s_room_name;
            txtRoomDescription.Value = room.s_room_desc;
            ddlStatus.SelectedValue = room.s_room_status_id_fk;
            ddlRoomType.SelectedValue = room.s_room_type_id_fk;

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
                        Logger.WriteToErrorLog("saefrm-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefrm-02.aspx", ex.Message);
                    }
                }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemRoom room = new SystemRoom();
            room.s_room_system_id_pk = editRoomId;
            room.s_room_id_pk = txtRoomId.Text;
            room.s_room_name = txtRoomName.Text;
            room.s_room_desc = txtRoomDescription.Value;
            room.s_room_status_id_fk = ddlStatus.SelectedValue;
            room.s_room_type_id_fk = ddlRoomType.SelectedValue;
            room.s_room_facility_id_fk = Request.QueryString["editFacilityId"];
            try
            {
                SystemRoomBLL.UpdateRoom(room);
                //for reset
                DataSet dsFacility = SystemFacilityBLL.GetFacility(Request.QueryString["editFacilityId"]);
                SessionWrapper.Reset_Facility_Rooms = dsFacility.Tables[2];
                SessionWrapper.Reset_Facility_Room_Resource = dsFacility.Tables[3];
                //SystemFacilityBLL.UpdateFacilityRoom(room);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefrm-02", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefrm-02", ex.Message);
                    }
                }
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                SystemFacilityBLL.ResetFacility(Request.QueryString["editFacilityId"], string.Empty, ConvertDataTableToXml(SessionWrapper.Reset_Facility_Rooms), ConvertDataTableToXml(SessionWrapper.Reset_Facility_Room_Resource));
                Response.Redirect(Request.RawUrl,false);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saefrm-02", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saefrm-02", ex.Message);
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
       
    }
}