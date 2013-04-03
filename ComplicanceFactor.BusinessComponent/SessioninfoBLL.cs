using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;


namespace ComplicanceFactor.BusinessComponent
{
    public class SessioninfoBLL
    {
        public static int InsertSessionInfo(Sessioninfo sessioninfo)
        {

            Hashtable htInsertSession = new Hashtable();
            htInsertSession.Add("@GUID", sessioninfo.sessionguid);
            htInsertSession.Add("@userid", sessioninfo.userid);
            htInsertSession.Add("@sessionid", sessioninfo.sessionid);
            //htInsertSession.Add("@sessionstart_time", sessioninfo.sessionstart_time);
            htInsertSession.Add("@securityroles", sessioninfo.securityroles);
            htInsertSession.Add("@IPaddress", sessioninfo.IPaddress);
            htInsertSession.Add("@useragent", sessioninfo.useragent);
            try
            {
                return DataProxy.FetchSPOutput("app_session_insert_start_time", htInsertSession);
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static int InsertSessionEndTime(Sessioninfo sessioninfo)
        {
            Hashtable htInsertSessionEndTime = new Hashtable();
            //htInsertSessionEndTime.Add("@sessionend_time", sessioninfo.sessionend_time);
            htInsertSessionEndTime.Add("@GUID", sessioninfo.sessionguid);
            try
            {
                return DataProxy.FetchSPOutput("app_session_insert_end_time", htInsertSessionEndTime);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UnlockTimeout(string u_user_id_pk)
        {
            Hashtable htUnlockTimeout = new Hashtable();
            htUnlockTimeout.Add("@u_user_id_pk", u_user_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("app_user_sp_unlock_after_timeout", htUnlockTimeout);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ManageSession(string userId, string sessionId)
        {
            Hashtable htManageSession = new Hashtable();
            htManageSession.Add("@userid", userId);
            htManageSession.Add("@sessionid", sessionId);
            try
            {
                int res = DataProxy.FetchSPOutput("u_update_user_in_session", htManageSession);
                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
