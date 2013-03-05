using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemLocationBLL
    {
        public static int CreateNewLocation(SystemLocation createLocation)
        {
            Hashtable htcreateLocation = new Hashtable();
            htcreateLocation.Add("@c_location_system_id_pk", createLocation.c_location_system_id_pk);
            htcreateLocation.Add("@c_location_id_pk", createLocation.c_location_id_pk);
            htcreateLocation.Add("@c_location_name", createLocation.c_location_name);
            htcreateLocation.Add("@c_location_desc", createLocation.c_location_desc);
            htcreateLocation.Add("@c_location_airport_code", createLocation.c_location_airport_code);
            htcreateLocation.Add("@c_location_status_id_fk", createLocation.c_location_status_id_fk);
            if (!string.IsNullOrEmpty(createLocation.s_location_locale))
            {
                htcreateLocation.Add("@s_location_locale", createLocation.s_location_locale);
            }
            else
            {
                htcreateLocation.Add("@s_location_locale", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_location", htcreateLocation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateLocation(SystemLocation updateLocation)
        {
            Hashtable htupdateLocation = new Hashtable();
            htupdateLocation.Add("@c_location_system_id_pk", updateLocation.c_location_system_id_pk);
            htupdateLocation.Add("@c_location_id_pk", updateLocation.c_location_id_pk);
            htupdateLocation.Add("@c_location_name", updateLocation.c_location_name);
            htupdateLocation.Add("@c_location_desc", updateLocation.c_location_desc);
            htupdateLocation.Add("@c_location_airport_code", updateLocation.c_location_airport_code);
            htupdateLocation.Add("@c_location_status_id_fk", updateLocation.c_location_status_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_location", htupdateLocation);
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
        public static SystemLocation GetSingleLocation(string c_location_system_id_pk, DataTable dtLocation)
        {
            SystemLocation getLocation = new SystemLocation();
            try
            {
                Hashtable htGetLocation = new Hashtable();
                htGetLocation.Add("@c_location_system_id_pk", c_location_system_id_pk);
                DataTable dtSingleLocation = dtLocation;
                getLocation.c_location_id_pk = dtSingleLocation.Rows[0]["c_location_id_pk"].ToString();
                getLocation.c_location_name = dtSingleLocation.Rows[0]["c_location_name"].ToString();
                getLocation.c_location_desc = dtSingleLocation.Rows[0]["c_location_desc"].ToString();
                getLocation.c_location_airport_code = dtSingleLocation.Rows[0]["c_location_airport_code"].ToString();
                getLocation.c_location_status_id_fk = dtSingleLocation.Rows[0]["c_location_status_id_fk"].ToString();

                return getLocation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchLocations(SystemLocation location)
        {
            Hashtable htSearchlocation = new Hashtable();
            htSearchlocation.Add("@c_location_id_pk", location.c_location_id_pk);
            htSearchlocation.Add("@c_location_name", location.c_location_name);
            htSearchlocation.Add("@c_location_airport_code", location.c_location_airport_code);
            if (location.c_location_status_id_fk == "0")
                htSearchlocation.Add("@c_location_status_id_fk", DBNull.Value);
            else
                htSearchlocation.Add("@c_location_status_id_fk", location.c_location_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_location", htSearchlocation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateLocationStatus(string c_location_system_id_pk)
        {
            Hashtable htUpdateLocationStatus = new Hashtable();
            htUpdateLocationStatus.Add("@c_location_system_id_pk", c_location_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_location_status", htUpdateLocationStatus);
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
        public static DataSet GetLocation(string c_location_system_id_pk)
        {
            try
            {
                Hashtable htGetlocation = new Hashtable();
                htGetlocation.Add("@c_location_system_id_pk", c_location_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_location", htGetlocation);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertLocationLocale(SystemLocation locale)
        {
            Hashtable htInsertlocationLocale = new Hashtable();
            htInsertlocationLocale.Add("@s_location_system_id_fk", locale.s_location_system_id_fk);
            htInsertlocationLocale.Add("@s_location_locale_name", locale.s_location_locale_name);
            htInsertlocationLocale.Add("@s_location_locale_description", locale.s_location_locale_description);
            htInsertlocationLocale.Add("@s_location_airport_code", locale.s_location_airport_code);
            htInsertlocationLocale.Add("@s_locale_id_fk", locale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_location_locale", htInsertlocationLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update location locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateLocationLocale(SystemLocation locale)
        {
            Hashtable htUpdatelocationLocale = new Hashtable();
            htUpdatelocationLocale.Add("@s_location_locale_system_id_pk", locale.s_location_locale_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_location_locale_name))
            {
                htUpdatelocationLocale.Add("@s_location_locale_name", locale.s_location_locale_name);
            }
            else
            {
                htUpdatelocationLocale.Add("@s_location_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_location_locale_description))
            {
                htUpdatelocationLocale.Add("@s_location_locale_description", locale.s_location_locale_description);
            }
            else
            {
                htUpdatelocationLocale.Add("@s_location_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_location_airport_code))
            {
                htUpdatelocationLocale.Add("@s_location_airport_code", locale.s_location_airport_code);
            }
            else
            {
                htUpdatelocationLocale.Add("@s_location_airport_code", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_location_locale", htUpdatelocationLocale);
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
        public static SystemLocation TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemLocation reslocale;
            try
            {
                reslocale = new SystemLocation();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_location_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_location_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_location_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                reslocale.s_location_airport_code = dtGetLocale.Rows[0]["s_locale_airport_code"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Get single location locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemLocation GetSingleLocationLocale(string s_locale_system_id_pk)
        {
            SystemLocation Locale;
            try
            {
                Locale = new SystemLocation();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_location_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_location_locale", htGetLocale);
                Locale.s_location_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_location_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_location_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                Locale.s_location_airport_code = dtGetLocale.Rows[0]["s_locale_airport_code"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// get location locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLocationLocale(string s_location_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_location_system_id_fk", s_location_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_location_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete location locale
        /// </summary>
        /// <param name="s_location_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteLocationLocale(string s_location_system_id_fk, string s_location_locale, string s_location_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_location_system_id_fk))
            {
                htDeleteLocale.Add("@s_location_system_id_fk", s_location_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_location_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_location_locale))
            {
                htDeleteLocale.Add("@s_location_locale", s_location_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_location_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_location_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_location_locale_system_id_pk", s_location_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_location_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_location_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
