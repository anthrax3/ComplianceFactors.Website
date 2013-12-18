using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemEstablishmentBLL
    {
        public static int CreateNewEstablishment(SystemEstablishment createEstablishment)
        {
            Hashtable htcreateEstablishment = new Hashtable();
            htcreateEstablishment.Add("@s_establishment_system_id_pk", createEstablishment.s_establishment_system_id_pk);
            htcreateEstablishment.Add("@s_establishment_id_pk", createEstablishment.s_establishment_id_pk);
            htcreateEstablishment.Add("@s_establishment_name", createEstablishment.s_establishment_name);
            htcreateEstablishment.Add("@s_establishment_desc", createEstablishment.s_establishment_desc);
            htcreateEstablishment.Add("@s_establishment_status_id_fk", createEstablishment.s_establishment_status_id_fk);
         
            htcreateEstablishment.Add("@s_establishment_city", createEstablishment.s_establishment_city);
            htcreateEstablishment.Add("@s_establishment_state", createEstablishment.s_establishment_state);
            htcreateEstablishment.Add("@s_establishment_zip_code", createEstablishment.s_establishment_zip_code);
            htcreateEstablishment.Add("@s_establishment_country_id_fk", createEstablishment.s_establishment_country_id_fk);
            htcreateEstablishment.Add("@s_establishment_locale_id_fk", createEstablishment.s_establishment_locale_id_fk);
            htcreateEstablishment.Add("@s_establishment_time_zone_id_fk", createEstablishment.s_establishment_time_zone_id_fk);
            if (!string.IsNullOrEmpty(createEstablishment.s_establishment_locale))
            {
                htcreateEstablishment.Add("@s_establishment_locale", createEstablishment.s_establishment_locale);
            }
            else
            {
                htcreateEstablishment.Add("@s_establishment_locale", DBNull.Value);
            }
           
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_Establishment", htcreateEstablishment);
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
        public static SystemEstablishment TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemEstablishment reslocale;
            try
            {
                reslocale = new SystemEstablishment();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_establishment_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_establishment_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_establishment_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UpdateEstablishment(SystemEstablishment updateEstablishment)
        {
            Hashtable htupdateEstablishment = new Hashtable();
            htupdateEstablishment.Add("@s_establishment_system_id_pk", updateEstablishment.s_establishment_system_id_pk);
            htupdateEstablishment.Add("@s_establishment_id_pk", updateEstablishment.s_establishment_id_pk);
            htupdateEstablishment.Add("@s_establishment_name", updateEstablishment.s_establishment_name);
            htupdateEstablishment.Add("@s_establishment_desc", updateEstablishment.s_establishment_desc);
            htupdateEstablishment.Add("@s_establishment_status_id_fk", updateEstablishment.s_establishment_status_id_fk);
         
            htupdateEstablishment.Add("@s_establishment_city", updateEstablishment.s_establishment_city);
            htupdateEstablishment.Add("@s_establishment_state", updateEstablishment.s_establishment_state);
            htupdateEstablishment.Add("@s_establishment_zip_code", updateEstablishment.s_establishment_zip_code);
            htupdateEstablishment.Add("@s_establishment_country_id_fk", updateEstablishment.s_establishment_country_id_fk);
            htupdateEstablishment.Add("@s_establishment_locale_id_fk", updateEstablishment.s_establishment_locale_id_fk);
            htupdateEstablishment.Add("@s_establishment_time_zone_id_fk", updateEstablishment.s_establishment_time_zone_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_Establishment", htupdateEstablishment);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get all Status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetEstablishmentType(string s_locale)
        {
            try
            {
                Hashtable htGetEstablishmentType = new Hashtable();
                htGetEstablishmentType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_establishment_type", htGetEstablishmentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetCountry()
        {
            try
            {
                return DataProxy.FetchDataTable("u_sp_get_country");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetLocale()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_locale");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetTimeZone()
        {
            try
            {
                return DataProxy.FetchDataTable("app_sp_get_timezone");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get Establishment
        /// </summary>
        /// <param name="s_establishment_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetEstablishment(string s_establishment_system_id_pk)
        {
            try
            {
                Hashtable htGetEstablishment = new Hashtable();
                htGetEstablishment.Add("@s_establishment_system_id_pk", s_establishment_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_Establishment", htGetEstablishment);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemEstablishment GetSingleLocation(string s_establishment_system_id_pk, DataTable dtEstablishment)
        {
            SystemEstablishment getEstablishment = new SystemEstablishment();
            try
            {
                Hashtable htGetEstablishment = new Hashtable();
                htGetEstablishment.Add("@s_establishment_system_id_pk", s_establishment_system_id_pk);

                DataTable dtSingleEstablishment = dtEstablishment;

                getEstablishment.s_establishment_id_pk = dtSingleEstablishment.Rows[0]["s_establishment_id_pk"].ToString();
                getEstablishment.s_establishment_name = dtSingleEstablishment.Rows[0]["s_establishment_name"].ToString();
                getEstablishment.s_establishment_desc = dtSingleEstablishment.Rows[0]["s_establishment_desc"].ToString();
                if (!string.IsNullOrEmpty(dtSingleEstablishment.Rows[0]["s_establishment_status_id_fk"].ToString()))
                {
                    getEstablishment.s_establishment_status_id_fk = dtSingleEstablishment.Rows[0]["s_establishment_status_id_fk"].ToString();
                }
               
                getEstablishment.s_establishment_city = dtSingleEstablishment.Rows[0]["s_establishment_city"].ToString();
                getEstablishment.s_establishment_state = dtSingleEstablishment.Rows[0]["s_establishment_state"].ToString();
                getEstablishment.s_establishment_zip_code = dtSingleEstablishment.Rows[0]["s_establishment_zip_code"].ToString();

                if (!string.IsNullOrEmpty(dtSingleEstablishment.Rows[0]["s_establishment_country_id_fk"].ToString()))
                {
                    getEstablishment.s_establishment_country_id_fk = Convert.ToInt16(dtSingleEstablishment.Rows[0]["s_establishment_country_id_fk"]);
                }
                if (!string.IsNullOrEmpty(dtSingleEstablishment.Rows[0]["s_establishment_locale_id_fk"].ToString()))
                {
                    getEstablishment.s_establishment_locale_id_fk = dtSingleEstablishment.Rows[0]["s_establishment_locale_id_fk"].ToString();
                }
                if (!string.IsNullOrEmpty(dtSingleEstablishment.Rows[0]["s_establishment_time_zone_id_fk"].ToString()))
                {
                    getEstablishment.s_establishment_time_zone_id_fk = Convert.ToInt16(dtSingleEstablishment.Rows[0]["s_establishment_time_zone_id_fk"]);
                }




                return getEstablishment;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchEstablishment(SystemEstablishment Establishment)
        {
            Hashtable htSearchEstablishment = new Hashtable();
            htSearchEstablishment.Add("@s_establishment_id_pk", Establishment.s_establishment_id_pk);
            htSearchEstablishment.Add("@s_establishment_name", Establishment.s_establishment_name);
            htSearchEstablishment.Add("@s_establishment_city", Establishment.s_establishment_city);

            if (Establishment.s_establishment_status_id_fk == "0")
                htSearchEstablishment.Add("@s_establishment_status_id_fk", DBNull.Value);
            else
                htSearchEstablishment.Add("@s_establishment_status_id_fk", Establishment.s_establishment_status_id_fk);

          

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_Establishment", htSearchEstablishment);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateEstablishmentStatus(string s_establishment_system_id_pk)
        {
            Hashtable htUpdateEstablishmentStatus = new Hashtable();
            htUpdateEstablishmentStatus.Add("@s_establishment_system_id_pk", s_establishment_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_establishment_status", htUpdateEstablishmentStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single Establishment locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemEstablishment GetSingleEstablishmentLocale(string s_locale_system_id_pk)
        {
            SystemEstablishment Locale;
            try
            {
                Locale = new SystemEstablishment();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_establishment_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_establishment_locale", htGetLocale);
                Locale.s_establishment_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_establishment_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_establishment_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// update Establishment locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateEstablishmentLocale(SystemEstablishment resLocale)
        {
            Hashtable htUpdateEstablishmentLocale = new Hashtable();
            htUpdateEstablishmentLocale.Add("@s_establishment_locale_system_id_pk", resLocale.s_establishment_locale_system_id_pk);
            if (!string.IsNullOrEmpty(resLocale.s_establishment_locale_name))
            {
                htUpdateEstablishmentLocale.Add("@s_establishment_locale_name", resLocale.s_establishment_locale_name);
            }
            else
            {
                htUpdateEstablishmentLocale.Add("@s_establishment_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_establishment_locale_description))
            {
                htUpdateEstablishmentLocale.Add("@s_establishment_locale_description", resLocale.s_establishment_locale_description);
            }
            else
            {
                htUpdateEstablishmentLocale.Add("@s_establishment_locale_description", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_establishment_locale", htUpdateEstablishmentLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert Establishment locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int InsertEstablishmentLocale(SystemEstablishment resLocale)
        {
            Hashtable htInsertEstablishmentLocale = new Hashtable();
            htInsertEstablishmentLocale.Add("@s_establishment_system_id_fk", resLocale.s_establishment_system_id_fk);
            htInsertEstablishmentLocale.Add("@s_establishment_locale_name", resLocale.s_establishment_locale_name);
            htInsertEstablishmentLocale.Add("@s_establishment_locale_description", resLocale.s_establishment_locale_description);
            htInsertEstablishmentLocale.Add("@s_locale_id_fk", resLocale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_establishment_locale", htInsertEstablishmentLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get Establishment locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEstablishmentLocale(string s_establishment_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_establishment_system_id_fk", s_establishment_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_establishment_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Establishment locale
        /// </summary>
        /// <param name="s_establishment_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteEstablishmentLocale(string s_establishment_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            htDeleteLocale.Add("@s_establishment_locale_system_id_pk", s_establishment_locale_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_establishment_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemRoom TempGetEstablishmentRoom(string s_room_system_id_pk, DataTable dtRooms)
        {
            SystemRoom EstablishmentRoom;

            try
            {
                Hashtable htGetCourseDelivery = new Hashtable();
                htGetCourseDelivery.Add("@s_room_system_id_pk", s_room_system_id_pk);
                EstablishmentRoom = new SystemRoom();
                DataTable dtGetRoom = dtRooms;
                EstablishmentRoom.s_room_id_pk = dtGetRoom.Rows[0]["s_room_id_pk"].ToString();
                EstablishmentRoom.s_room_name = dtGetRoom.Rows[0]["s_room_name"].ToString();
                EstablishmentRoom.s_room_desc = dtGetRoom.Rows[0]["s_room_description"].ToString();
                EstablishmentRoom.s_room_status_id_fk = dtGetRoom.Rows[0]["s_room_status_id_fk"].ToString();
                EstablishmentRoom.s_room_type_id_fk = dtGetRoom.Rows[0]["s_room_type_id_fk"].ToString();

                return EstablishmentRoom;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Establishment room
        /// </summary>
        /// <param name="s_establishment_room_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteEstablishmentRoom(string s_room_system_id_pk)
        {
            Hashtable htDeleteEstablishmentRoom = new Hashtable();
            htDeleteEstablishmentRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_establishment_room", htDeleteEstablishmentRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Establishment room and resources
        /// </summary>
        /// <param name="s_establishment_system_id_pk"></param>
        /// <param name="s_establishment_room"></param>
        /// <param name="s_establishment_room_resource"></param>
        /// <returns></returns>
        public static int InsertRoomAndResource(string s_establishment_system_id_pk, string s_room, string s_room_resource)
        {
            Hashtable htInsertEstablishmentRoomAndResource = new Hashtable();
            if (!string.IsNullOrEmpty(s_establishment_system_id_pk))
            {
                htInsertEstablishmentRoomAndResource.Add("@s_establishment_system_id_pk", s_establishment_system_id_pk);
            }
            else
            {
                htInsertEstablishmentRoomAndResource.Add("@s_establishment_system_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room))
            {
                htInsertEstablishmentRoomAndResource.Add("@s_room", s_room);
            }
            else
            {
                htInsertEstablishmentRoomAndResource.Add("@s_room", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room_resource))
            {
                htInsertEstablishmentRoomAndResource.Add("@s_room_resource", s_room_resource);
            }
            else
            {
                htInsertEstablishmentRoomAndResource.Add("@s_room_resource", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room_resource", htInsertEstablishmentRoomAndResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Establishment resource
        /// </summary>
        /// <param name="s_establishment_room_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteRoomResource(string s_room_resource_system_id_pk)
        {
            Hashtable htDeleteEstablishmentResource = new Hashtable();
            htDeleteEstablishmentResource.Add("@s_room_resource_system_id_pk", s_room_resource_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_room_resource", htDeleteEstablishmentResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Establishment room and resource
        /// </summary>
        /// <param name="s_establishment_room_system_id_pk"></param>
        /// <returns></returns>
        //public static DataSet GetRoom(string s_room_system_id_pk)
        //{
        //    try
        //    {
        //        Hashtable htGetEstablishmentRoom = new Hashtable();
        //        htGetEstablishmentRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
        //        return DataProxy.FetchDataSet("s_sp_get_room", htGetEstablishmentRoom);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// update Establishment room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        //public static int UpdateEstablishmentRoom(SystemRoom room)
        //{
        //    try
        //    {
        //        Hashtable htUpdateEstablishmentRoom = new Hashtable();
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_system_id_pk", room.s_room_system_id_pk);
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_id_pk", room.s_room_id_pk);
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_name", room.s_room_name);
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_description", room.s_room_desc);
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_status_id_fk", room.s_room_status_id_fk);
        //        htUpdateEstablishmentRoom.Add("@s_establishment_room_type_id_fk", room.s_room_type_id_fk);
        //        return DataProxy.FetchSPOutput("s_sp_update_establishment_room", htUpdateEstablishmentRoom);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// Reset Establishment
        /// </summary>
        /// <param name="s_establishment_system_id_pk"></param>
        /// <param name="s_establishment_locale"></param>
        /// <param name="s_establishment_room"></param>
        /// <param name="s_establishment_room_resource"></param>
        /// <returns></returns>
        public static int ResetEstablishment(string s_establishment_system_id_pk, string s_establishment_locale, string s_room, string s_room_resource)
        {
            try
            {
                Hashtable htResetEstablishment = new Hashtable();
                if (!string.IsNullOrEmpty(s_establishment_system_id_pk))
                {
                    htResetEstablishment.Add("@s_establishment_system_id_pk", s_establishment_system_id_pk);
                }
                else
                {
                    htResetEstablishment.Add("@s_establishment_system_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_establishment_locale))
                {
                    htResetEstablishment.Add("@s_establishment_locale", s_establishment_locale);
                }
                else
                {
                    htResetEstablishment.Add("@s_establishment_locale", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_room))
                {
                    htResetEstablishment.Add("@s_room", s_room);
                }
                else
                {
                    htResetEstablishment.Add("@s_room", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_room_resource))
                {
                    htResetEstablishment.Add("@s_room_resource", s_room_resource);
                }
                else
                {
                    htResetEstablishment.Add("@s_room_resource", DBNull.Value);
                }
                return DataProxy.FetchSPOutput("s_sp_reset_Establishment", htResetEstablishment);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
