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
    public class AuditlogBLL
    {
        public static int InsertAudit(Auditlog auditlog)
        {
            
            Hashtable htInsertAudit = new Hashtable();
            htInsertAudit.Add("@GUID", auditlog.Guid);
            htInsertAudit.Add("@a_audit_log_id_pk", auditlog.Auditid);
            htInsertAudit.Add("@a_user_id_fk", auditlog.Userid);
            htInsertAudit.Add("@a_user_type_fk", auditlog.user_type);
            htInsertAudit.Add("@a_user_details", auditlog.user_detail);
            htInsertAudit.Add("@a_action_desc", auditlog.action_desc);
           // htInsertAudit.Add("@a_date_time", auditlog.u_datetime);
            htInsertAudit.Add("@a_ip_address ", auditlog.ipaddress);
            htInsertAudit.Add("@a_device_used", auditlog.device);
            try
            {
                return DataProxy.FetchSPOutput("app_audit_insert_log", htInsertAudit);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
