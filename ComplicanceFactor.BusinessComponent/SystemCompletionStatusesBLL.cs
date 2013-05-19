using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.DataAccessLayer;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
  public class SystemCompletionStatusesBLL
    {

            public static DataSet GetLocalCompletionStatuses()
            {
            try
            {
                return DataProxy.FetchDataSet("s_sp_get_locale_completion_statuses");
            }
            catch (Exception)
            {
                throw;
            }
        }

            public static int updateCompletionLocales(string assigned, string enrolled, string incomplete, string completed, string browse, string attended, string didNotAttend, string attendedwalkin, string unknown, string oltplayer, string vlssystem, string passed, string failed, string exempt, string notScored, string pendingAssesment, bool enableBrowse, bool enableUnknown, bool enableOLTPlayer, bool enableVLSSystem, bool enableExempt, bool enableNotScored, bool enablePendingAssesment)
            {
                Hashtable htLocaleVisibility = new Hashtable();
                htLocaleVisibility.Add("@assigned", assigned);
                htLocaleVisibility.Add("@enrolled", enrolled);
                htLocaleVisibility.Add("@incomplete", incomplete);
                htLocaleVisibility.Add("@completed", completed);
                htLocaleVisibility.Add("@browse", browse);
                htLocaleVisibility.Add("@attended", attended);
                htLocaleVisibility.Add("@didNotAttend", didNotAttend);
                htLocaleVisibility.Add("@attendedwalkin", attendedwalkin);
                htLocaleVisibility.Add("@unknown", unknown);
                htLocaleVisibility.Add("@oltplayer", oltplayer);
                htLocaleVisibility.Add("@vlssystem", vlssystem);
                htLocaleVisibility.Add("@passed", passed);
                htLocaleVisibility.Add("@failed", failed);
                htLocaleVisibility.Add("@exempt", exempt);
                htLocaleVisibility.Add("@notScored", notScored);
                htLocaleVisibility.Add("@pendingAssesment", pendingAssesment);

                htLocaleVisibility.Add("@enableBrowse", enableBrowse);
                htLocaleVisibility.Add("@enableUnknown", enableUnknown);
                htLocaleVisibility.Add("@enableOLTPlayer", enableOLTPlayer);
                htLocaleVisibility.Add("@enableVLSSystem", enableVLSSystem);
                htLocaleVisibility.Add("@enableExempt", enableExempt);
                htLocaleVisibility.Add("@enableNotScored", enableNotScored);
                htLocaleVisibility.Add("@enablePendingAssesment", enablePendingAssesment);
                try
                {
                    return DataProxy.FetchSPOutput("s_sp_update_completion_statuses", htLocaleVisibility);
                }

                catch (Exception)
                {
                    throw;
                }

            }

            public static int UpdateCompletionLocaleVisibility(bool enablestatus, string statusField)
            {
                Hashtable htLocaleVisibility = new Hashtable();
                htLocaleVisibility.Add("@enablestatus", enablestatus);
                htLocaleVisibility.Add("@statusField", statusField);
                try
                {
                    return DataProxy.FetchSPOutput("s_sp_update_enable_completion_statuses", htLocaleVisibility);
                }

                catch (Exception)
                {
                    throw;
                }

            }

            //public static void UpdateCompletionLocaleVisibility(bool p, string p_2)
            //{
            //    Hashtable htLocaleVisibility = new Hashtable();
            //    htLocaleVisibility.Add("@s_locale_active_flag", enablestatus);
            //    htLocaleVisibility.Add("@s_locale_description", statusField);
            //    try
            //    {
            //        return DataProxy.FetchSPOutput("s_sp_update_enable_completion_statuses", htLocaleVisibility);
            //    }

            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
    }
}
