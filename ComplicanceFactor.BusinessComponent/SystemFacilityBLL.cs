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
    public class SystemFacilityBLL
    {
        public static int CreateNewFacility(SystemFacility createFacility)
        {
            Hashtable htcreateFacility = new Hashtable();
            htcreateFacility.Add("@c_facility_system_id_pk", createFacility.s_facility_system_id_pk);
            htcreateFacility.Add("@c_facility_id_pk", createFacility.s_facility_id_pk);
            htcreateFacility.Add("@c_facility_name", createFacility.s_facility_name);
            htcreateFacility.Add("@c_facility_desc", createFacility.s_facility_desc);
            htcreateFacility.Add("@c_facility_status_id_fk", createFacility.s_facility_status_id_fk);
            htcreateFacility.Add("@c_facility_type_id_fk", createFacility.s_facility_type_id_fk);
            htcreateFacility.Add("@c_facility_contact", createFacility.s_facility_contact);
            htcreateFacility.Add("@c_facility_email_address", createFacility.s_facility_email_address);
            htcreateFacility.Add("@c_facility_phone", createFacility.s_facility_phone);
            htcreateFacility.Add("@c_facility_address", createFacility.s_facility_address);
            htcreateFacility.Add("@c_facility_address1", createFacility.s_facility_address1);
            htcreateFacility.Add("@c_facility_address2", createFacility.s_facility_address2);
            htcreateFacility.Add("@c_facility_city", createFacility.s_facility_city);
            htcreateFacility.Add("@c_facility_state", createFacility.s_facility_state);
            htcreateFacility.Add("@c_facility_zip_code", createFacility.s_facility_zip_code);
            htcreateFacility.Add("@c_facility_country_id_fk", createFacility.s_facility_country_id_fk);
            htcreateFacility.Add("@c_facility_locale_id_fk", createFacility.s_facility_locale_id_fk);
            htcreateFacility.Add("@c_facility_time_zone_id_fk", createFacility.s_facility_time_zone_id_fk);
            if (!string.IsNullOrEmpty(createFacility.s_facility_locale))
            {
                htcreateFacility.Add("@s_facility_locale", createFacility.s_facility_locale);
            }
            else
            {
                htcreateFacility.Add("@s_facility_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createFacility.s_room))
            {
                htcreateFacility.Add("@s_room", createFacility.s_room);
            }
            else
            {
                htcreateFacility.Add("@s_room", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createFacility.s_room_resource))
            {
                htcreateFacility.Add("@s_room_resource", createFacility.s_room_resource);
            }
            else
            {
                htcreateFacility.Add("@s_room_resource", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_facility", htcreateFacility);
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
        public static SystemFacility TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemFacility reslocale;
            try
            {
                reslocale = new SystemFacility();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_facility_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_facility_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_facility_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UpdateFacility(SystemFacility updateFacility)
        {
            Hashtable htupdateFacility = new Hashtable();
            htupdateFacility.Add("@c_facility_system_id_pk", updateFacility.s_facility_system_id_pk);
            htupdateFacility.Add("@c_facility_id_pk", updateFacility.s_facility_id_pk);
            htupdateFacility.Add("@c_facility_name", updateFacility.s_facility_name);
            htupdateFacility.Add("@c_facility_desc", updateFacility.s_facility_desc);
            htupdateFacility.Add("@c_facility_status_id_fk", updateFacility.s_facility_status_id_fk);
            htupdateFacility.Add("@c_facility_type_id_fk", updateFacility.s_facility_type_id_fk);
            htupdateFacility.Add("@c_facility_contact", updateFacility.s_facility_contact);
            htupdateFacility.Add("@c_facility_email_address", updateFacility.s_facility_email_address);
            htupdateFacility.Add("@c_facility_phone", updateFacility.s_facility_phone);
            htupdateFacility.Add("@c_facility_address", updateFacility.s_facility_address);
            htupdateFacility.Add("@c_facility_address1", updateFacility.s_facility_address1);
            htupdateFacility.Add("@c_facility_address2", updateFacility.s_facility_address2);
            htupdateFacility.Add("@c_facility_city", updateFacility.s_facility_city);
            htupdateFacility.Add("@c_facility_state", updateFacility.s_facility_state);
            htupdateFacility.Add("@c_facility_zip_code", updateFacility.s_facility_zip_code);
            htupdateFacility.Add("@c_facility_country_id_fk", updateFacility.s_facility_country_id_fk);
            htupdateFacility.Add("@c_facility_locale_id_fk", updateFacility.s_facility_locale_id_fk);
            htupdateFacility.Add("@c_facility_time_zone_id_fk", updateFacility.s_facility_time_zone_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_facility", htupdateFacility);
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
        public static DataTable GetAllStatus(string s_ui_locale_name,string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status",htGetStatus);
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
        public static DataTable GetFacilityType(string s_locale)
        {
            try
            {
                Hashtable htGetFacilityType = new Hashtable();
                htGetFacilityType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_facility_type",htGetFacilityType);
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
        /// get facility
        /// </summary>
        /// <param name="c_facility_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetFacility(string c_facility_system_id_pk)
        {
            try
            {
                Hashtable htGetfacility = new Hashtable();
                htGetfacility.Add("@c_facility_system_id_pk", c_facility_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_facility", htGetfacility);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemFacility GetSingleLocation(string c_facility_system_id_pk, DataTable dtFacility)
        {
            SystemFacility getFacility = new SystemFacility();
            try
            {
                Hashtable htGetFacility = new Hashtable();
                htGetFacility.Add("@c_facility_system_id_pk", c_facility_system_id_pk);

                DataTable dtSingleFacility = dtFacility;

                getFacility.s_facility_id_pk = dtSingleFacility.Rows[0]["c_facility_id_pk"].ToString();
                getFacility.s_facility_name = dtSingleFacility.Rows[0]["c_facility_name"].ToString();
                getFacility.s_facility_desc = dtSingleFacility.Rows[0]["c_facility_desc"].ToString();
                if (!string.IsNullOrEmpty(dtSingleFacility.Rows[0]["c_facility_status_id_fk"].ToString()))
                {
                    getFacility.s_facility_status_id_fk = dtSingleFacility.Rows[0]["c_facility_status_id_fk"].ToString();
                }
                if (!string.IsNullOrEmpty(dtSingleFacility.Rows[0]["c_facility_type_id_fk"].ToString()))
                {
                    getFacility.s_facility_type_id_fk = dtSingleFacility.Rows[0]["c_facility_type_id_fk"].ToString();
                }
                getFacility.s_facility_contact = dtSingleFacility.Rows[0]["c_facility_contact"].ToString();
                getFacility.s_facility_email_address = dtSingleFacility.Rows[0]["c_facility_email_address"].ToString();
                getFacility.s_facility_phone = dtSingleFacility.Rows[0]["c_facility_phone"].ToString();
                getFacility.s_facility_address = dtSingleFacility.Rows[0]["c_facility_address"].ToString();
                getFacility.s_facility_address1 = dtSingleFacility.Rows[0]["c_facility_address1"].ToString();
                getFacility.s_facility_address2 = dtSingleFacility.Rows[0]["c_facility_address2"].ToString();
                getFacility.s_facility_city = dtSingleFacility.Rows[0]["c_facility_city"].ToString();
                getFacility.s_facility_state = dtSingleFacility.Rows[0]["c_facility_state"].ToString();
                getFacility.s_facility_zip_code = dtSingleFacility.Rows[0]["c_facility_zip_code"].ToString();

                if (!string.IsNullOrEmpty(dtSingleFacility.Rows[0]["c_facility_country_id_fk"].ToString()))
                {
                    getFacility.s_facility_country_id_fk = Convert.ToInt16(dtSingleFacility.Rows[0]["c_facility_country_id_fk"]);
                }
                if (!string.IsNullOrEmpty(dtSingleFacility.Rows[0]["c_facility_locale_id_fk"].ToString()))
                {
                    getFacility.s_facility_locale_id_fk = dtSingleFacility.Rows[0]["c_facility_locale_id_fk"].ToString();
                }
                if (!string.IsNullOrEmpty(dtSingleFacility.Rows[0]["c_facility_time_zone_id_fk"].ToString()))
                {
                    getFacility.s_facility_time_zone_id_fk = Convert.ToInt16(dtSingleFacility.Rows[0]["c_facility_time_zone_id_fk"]);
                }




                return getFacility;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchFacility(SystemFacility facility)
        {
            Hashtable htSearchfacility = new Hashtable();
            htSearchfacility.Add("@c_facility_id_pk", facility.s_facility_id_pk);
            htSearchfacility.Add("@c_facility_name", facility.s_facility_name);
            htSearchfacility.Add("@c_facility_city", facility.s_facility_city);

            if (facility.s_facility_status_id_fk == "0")
                htSearchfacility.Add("@c_facility_status_id_fk", DBNull.Value);
            else
                htSearchfacility.Add("@c_facility_status_id_fk", facility.s_facility_status_id_fk);

            if (facility.s_facility_type_id_fk == "0")
                htSearchfacility.Add("@c_facility_type_id_fk", DBNull.Value);
            else
                htSearchfacility.Add("@c_facility_type_id_fk", facility.s_facility_type_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_facility", htSearchfacility);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateFacilityStatus(string c_facility_system_id_pk)
        {
            Hashtable htUpdateFacilityStatus = new Hashtable();
            htUpdateFacilityStatus.Add("@c_facility_system_id_pk", c_facility_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_facility_status", htUpdateFacilityStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single facility locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemFacility GetSingleFacilityLocale(string s_locale_system_id_pk)
        {
            SystemFacility Locale;
            try
            {
                Locale = new SystemFacility();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_facility_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_facility_locale", htGetLocale);
                Locale.s_facility_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_facility_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_facility_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// update facility locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateFacilityLocale(SystemFacility resLocale)
        {
            Hashtable htUpdateFacilityLocale = new Hashtable();
            htUpdateFacilityLocale.Add("@s_facility_locale_system_id_pk", resLocale.s_facility_locale_system_id_pk);
            if (!string.IsNullOrEmpty(resLocale.s_facility_locale_name))
            {
                htUpdateFacilityLocale.Add("@s_facility_locale_name", resLocale.s_facility_locale_name);
            }
            else
            {
                htUpdateFacilityLocale.Add("@s_facility_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_facility_locale_description))
            {
                htUpdateFacilityLocale.Add("@s_facility_locale_description", resLocale.s_facility_locale_description);
            }
            else
            {
                htUpdateFacilityLocale.Add("@s_facility_locale_description", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_facility_locale", htUpdateFacilityLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert facility locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int InsertFacilityLocale(SystemFacility resLocale)
        {
            Hashtable htInsertfacilityLocale = new Hashtable();
            htInsertfacilityLocale.Add("@s_facility_system_id_fk", resLocale.s_facility_system_id_fk);
            htInsertfacilityLocale.Add("@s_facility_locale_name", resLocale.s_facility_locale_name);
            htInsertfacilityLocale.Add("@s_facility_locale_description", resLocale.s_facility_locale_description);
            htInsertfacilityLocale.Add("@s_locale_id_fk", resLocale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_facility_locale", htInsertfacilityLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get facility locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFacilityLocale(string s_facility_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_facility_system_id_fk", s_facility_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_facility_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete facility locale
        /// </summary>
        /// <param name="s_facility_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteFacilityLocale(string s_facility_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            htDeleteLocale.Add("@s_facility_locale_system_id_pk", s_facility_locale_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_facility_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemRoom TempGetFacilityRoom(string s_room_system_id_pk, DataTable dtRooms)
        {
            SystemRoom facilityRoom;

            try
            {
                Hashtable htGetCourseDelivery = new Hashtable();
                htGetCourseDelivery.Add("@s_room_system_id_pk", s_room_system_id_pk);
                facilityRoom = new SystemRoom();
                DataTable dtGetRoom = dtRooms;
                facilityRoom.s_room_id_pk = dtGetRoom.Rows[0]["s_room_id_pk"].ToString();
                facilityRoom.s_room_name = dtGetRoom.Rows[0]["s_room_name"].ToString();
                facilityRoom.s_room_desc = dtGetRoom.Rows[0]["s_room_description"].ToString();
                facilityRoom.s_room_status_id_fk = dtGetRoom.Rows[0]["s_room_status_id_fk"].ToString();
                facilityRoom.s_room_type_id_fk = dtGetRoom.Rows[0]["s_room_type_id_fk"].ToString();

                return facilityRoom;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete facility room
        /// </summary>
        /// <param name="s_facility_room_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteFacilityRoom(string s_room_system_id_pk)
        {
            Hashtable htDeleteFacilityRoom = new Hashtable();
            htDeleteFacilityRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_facility_room", htDeleteFacilityRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert facility room and resources
        /// </summary>
        /// <param name="s_facility_system_id_pk"></param>
        /// <param name="s_facility_room"></param>
        /// <param name="s_facility_room_resource"></param>
        /// <returns></returns>
        public static int InsertRoomAndResource(string s_facility_system_id_pk, string s_room, string s_room_resource)
        {
            Hashtable htInsertFacilityRoomAndResource = new Hashtable();
            if (!string.IsNullOrEmpty(s_facility_system_id_pk))
            {
                htInsertFacilityRoomAndResource.Add("@s_facility_system_id_pk", s_facility_system_id_pk);
            }
            else
            {
                htInsertFacilityRoomAndResource.Add("@s_facility_system_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room))
            {
                htInsertFacilityRoomAndResource.Add("@s_room", s_room);
            }
            else
            {
                htInsertFacilityRoomAndResource.Add("@s_room", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_room_resource))
            {
                htInsertFacilityRoomAndResource.Add("@s_room_resource", s_room_resource);
            }
            else
            {
                htInsertFacilityRoomAndResource.Add("@s_room_resource", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room_resource", htInsertFacilityRoomAndResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete facility resource
        /// </summary>
        /// <param name="s_facility_room_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteRoomResource(string s_room_resource_system_id_pk)
        {
            Hashtable htDeleteFacilityResource = new Hashtable();
            htDeleteFacilityResource.Add("@s_room_resource_system_id_pk", s_room_resource_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_room_resource", htDeleteFacilityResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get facility room and resource
        /// </summary>
        /// <param name="s_facility_room_system_id_pk"></param>
        /// <returns></returns>
        //public static DataSet GetRoom(string s_room_system_id_pk)
        //{
        //    try
        //    {
        //        Hashtable htGetFacilityRoom = new Hashtable();
        //        htGetFacilityRoom.Add("@s_room_system_id_pk", s_room_system_id_pk);
        //        return DataProxy.FetchDataSet("s_sp_get_room", htGetFacilityRoom);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// update facility room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        //public static int UpdateFacilityRoom(SystemRoom room)
        //{
        //    try
        //    {
        //        Hashtable htUpdateFacilityRoom = new Hashtable();
        //        htUpdateFacilityRoom.Add("@s_facility_room_system_id_pk", room.s_room_system_id_pk);
        //        htUpdateFacilityRoom.Add("@s_facility_room_id_pk", room.s_room_id_pk);
        //        htUpdateFacilityRoom.Add("@s_facility_room_name", room.s_room_name);
        //        htUpdateFacilityRoom.Add("@s_facility_room_description", room.s_room_desc);
        //        htUpdateFacilityRoom.Add("@s_facility_room_status_id_fk", room.s_room_status_id_fk);
        //        htUpdateFacilityRoom.Add("@s_facility_room_type_id_fk", room.s_room_type_id_fk);
        //        return DataProxy.FetchSPOutput("s_sp_update_facility_room", htUpdateFacilityRoom);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// Reset facility
        /// </summary>
        /// <param name="s_facility_system_id_pk"></param>
        /// <param name="s_facility_locale"></param>
        /// <param name="s_facility_room"></param>
        /// <param name="s_facility_room_resource"></param>
        /// <returns></returns>
        public static int ResetFacility(string s_facility_system_id_pk, string s_facility_locale, string s_room, string s_room_resource)
        {
            try
            {
                Hashtable htResetFacility = new Hashtable();
                if (!string.IsNullOrEmpty(s_facility_system_id_pk))
                {
                    htResetFacility.Add("@s_facility_system_id_pk", s_facility_system_id_pk);
                }
                else
                {
                    htResetFacility.Add("@s_facility_system_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_facility_locale))
                {
                    htResetFacility.Add("@s_facility_locale", s_facility_locale);
                }
                else
                {
                    htResetFacility.Add("@s_facility_locale", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_room))
                {
                    htResetFacility.Add("@s_room", s_room);
                }
                else
                {
                    htResetFacility.Add("@s_room", DBNull.Value);
                }
                if(!string.IsNullOrEmpty(s_room_resource))
                {
                htResetFacility.Add("@s_room_resource", s_room_resource);
                }
                else
                {
                      htResetFacility.Add("@s_room_resource", DBNull.Value);
                }
                return DataProxy.FetchSPOutput("s_sp_reset_facility", htResetFacility);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
