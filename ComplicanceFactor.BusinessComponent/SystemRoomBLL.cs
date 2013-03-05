using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemRoomBLL
    {
        public static int CreateNewRoom(SystemRoom createRoom)
        {
            Hashtable htcreateRoom = new Hashtable();

            htcreateRoom.Add("@c_room_system_id_pk", createRoom.s_room_system_id_pk);
            htcreateRoom.Add("@c_room_id_pk", createRoom.s_room_id_pk);
            htcreateRoom.Add("@c_room_name", createRoom.s_room_name);
            htcreateRoom.Add("@c_room_desc", createRoom.s_room_desc);
            htcreateRoom.Add("@c_room_status_id_fk", createRoom.s_room_status_id_fk);
            htcreateRoom.Add("@c_room_type_id_fk", createRoom.s_room_type_id_fk);
            htcreateRoom.Add("@c_room_facility_id_fk", createRoom.s_room_facility_id_fk);
            if (!string.IsNullOrEmpty(createRoom.s_room_locale))
            {
                htcreateRoom.Add("@s_room_locale", createRoom.s_room_locale);
            }
            else
            {
                htcreateRoom.Add("@s_room_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createRoom.s_room_resource))
            {
                htcreateRoom.Add("@s_room_resource", createRoom.s_room_resource);
            }
            else
            {
                htcreateRoom.Add("@s_room_resource", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room", htcreateRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateRoom(SystemRoom updateRoom)
        {
            Hashtable htupdateRoom = new Hashtable();

            htupdateRoom.Add("@c_room_system_id_pk", updateRoom.s_room_system_id_pk);
            htupdateRoom.Add("@c_room_id_pk", updateRoom.s_room_id_pk);
            htupdateRoom.Add("@c_room_name", updateRoom.s_room_name);
            htupdateRoom.Add("@c_room_desc", updateRoom.s_room_desc);
            htupdateRoom.Add("@c_room_status_id_fk", updateRoom.s_room_status_id_fk);
            htupdateRoom.Add("@c_room_type_id_fk", updateRoom.s_room_type_id_fk);
            //htupdateRoom.Add("@c_room_facility", updateRoom.c_room_facility);

            if (updateRoom.s_room_facility_id_fk != null)
            {
                htupdateRoom.Add("@c_room_facility_id_fk", updateRoom.s_room_facility_id_fk);
            }
            else
            {
                htupdateRoom.Add("@c_room_facility_id_fk", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_room", htupdateRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status",htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetAllStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetRoomType(string s_locale)
        {
            try
            {
                Hashtable htGetRoomType = new Hashtable();
                htGetRoomType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_room_type", htGetRoomType);
            }
            catch (Exception)
            {
                throw;
            }
        }        
        /// <summary>
        /// get location
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        /// <returns></returns>
        //public static DataSet GetRoom(string s_room_system_id_pk)
        //{
        //    try
        //    {
        //        Hashtable htGetRoom = new Hashtable();
        //        htGetRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
        //        return DataProxy.FetchDataSet("s_sp_get_single_room", htGetRoom);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
       /// <summary>
       /// get room and resource
       /// </summary>
       /// <param name="s_room_system_id_pk"></param>
       /// <returns></returns>
        public static DataSet GetRoom(string s_room_system_id_pk)
        {
            try
            {
                Hashtable htGetFacilityRoom = new Hashtable();
                htGetFacilityRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_room", htGetFacilityRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemRoom GetSingleRoom(string c_room_system_id_pk, DataTable dtRoom)
        {
            SystemRoom getRoom = new SystemRoom();

            try
            {
                Hashtable htGetRoom = new Hashtable();
                htGetRoom.Add("@s_room_system_id_pk", c_room_system_id_pk);

                DataTable dtSingleRoom = dtRoom;
                getRoom.s_room_id_pk = dtSingleRoom.Rows[0]["s_room_id_pk"].ToString();
                getRoom.s_room_name = dtSingleRoom.Rows[0]["s_room_name"].ToString();
                getRoom.s_room_desc = dtSingleRoom.Rows[0]["s_room_description"].ToString();
                getRoom.s_room_status_id_fk = dtSingleRoom.Rows[0]["s_room_status_id_fk"].ToString();
                getRoom.s_room_type_id_fk = dtSingleRoom.Rows[0]["s_room_type_id_fk"].ToString();
                getRoom.s_room_facility_id_fk = dtSingleRoom.Rows[0]["s_room_facility_id_fk"].ToString();
                getRoom.s_facility_name = dtSingleRoom.Rows[0]["s_facility_name"].ToString();

                return getRoom;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchRoom(SystemRoom room)
        {
            Hashtable htSearchRoom = new Hashtable();
            htSearchRoom.Add("@c_room_id_pk", room.s_room_id_pk);
            htSearchRoom.Add("@c_room_name", room.s_room_name);
            //htSearchRoom.Add("@c_room_facility_id_fk ", room.c_room_facility_id_fk);

            if (room.s_room_status_id_fk == "0")
                htSearchRoom.Add("@c_room_status_id_fk", DBNull.Value);
            else
                htSearchRoom.Add("@c_room_status_id_fk", room.s_room_status_id_fk);

            if (room.s_room_type_id_fk == "0")
                htSearchRoom.Add("@c_room_type_id_fk", DBNull.Value);
            else
                htSearchRoom.Add("@c_room_type_id_fk", room.s_room_type_id_fk);

            if (room.s_room_facility_id_fk != null)
                htSearchRoom.Add("@c_room_facility_id_fk", room.s_room_facility_id_fk);
            else
                htSearchRoom.Add("@c_room_facility_id_fk", DBNull.Value);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_room", htSearchRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateRoomStatus(string c_room_system_id_pk)
        {
            Hashtable htUpdateRoomStatus = new Hashtable();
            htUpdateRoomStatus.Add("@c_room_system_id_pk", c_room_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_room_status", htUpdateRoomStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get single room locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemRoom GetSingleRoomLocale(string s_locale_system_id_pk)
        {
            SystemRoom Locale;
            try
            {
                Locale = new SystemRoom();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_room_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_room_locale", htGetLocale);
                Locale.s_room_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_room_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_room_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// update room locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateRoomLocale(SystemRoom locale)
        {
            Hashtable htUpdateroomLocale = new Hashtable();
            htUpdateroomLocale.Add("@s_room_locale_system_id_pk", locale.s_room_locale_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_room_locale_name))
            {
                htUpdateroomLocale.Add("@s_room_locale_name", locale.s_room_locale_name);
            }
            else
            {
                htUpdateroomLocale.Add("@s_room_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_room_locale_description))
            {
                htUpdateroomLocale.Add("@s_room_locale_description", locale.s_room_locale_description);
            }
            else
            {
                htUpdateroomLocale.Add("@s_room_locale_description", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_room_locale", htUpdateroomLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertRoomLocale(SystemRoom locale)
        {
            Hashtable htInsertroomLocale = new Hashtable();
            htInsertroomLocale.Add("@s_room_system_id_fk", locale.s_room_system_id_fk);
            htInsertroomLocale.Add("@s_room_locale_name", locale.s_room_locale_name);
            htInsertroomLocale.Add("@s_room_locale_description", locale.s_room_locale_description);
            htInsertroomLocale.Add("@s_locale_id_fk", locale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room_locale", htInsertroomLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get room locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRoomLocale(string s_room_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_room_system_id_fk", s_room_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_room_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete room locale
        /// </summary>
        /// <param name="s_room_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteRoomLocale(string s_room_system_id_fk, string s_room_locale, string s_room_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_room_system_id_fk))
            {
                htDeleteLocale.Add("@s_room_system_id_fk", s_room_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_room_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room_locale))
            {
                htDeleteLocale.Add("@s_room_locale", s_room_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_room_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_room_locale_system_id_pk", s_room_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_room_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_room_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// get one locale from temp locale datatable
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <param name="dtTempLocale"></param>
        /// <returns></returns>
        public static SystemRoom TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemRoom reslocale;
            try
            {
                reslocale = new SystemRoom();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_room_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_room_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_room_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// reset room
        /// </summary>
        /// <param name="s_room_system_id_pk"></param>
        /// <param name="s_room_locale"></param>
        /// <param name="s_room_resource"></param>
        /// <returns></returns>
        public static int ResetRoom(string s_room_system_id_pk, string s_room_locale, string s_room_resource)
        {
            Hashtable htResetRoom = new Hashtable();
            htResetRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
            htResetRoom.Add("@s_room_locale", s_room_locale);
            htResetRoom.Add("@s_room_resource", s_room_resource);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_room", htResetRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
