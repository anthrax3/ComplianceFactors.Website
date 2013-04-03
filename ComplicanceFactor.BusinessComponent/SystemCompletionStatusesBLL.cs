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

namespace ComplicanceFactor.BusinessComponent
{
  public class SystemCompletionStatusesBLL
    {

            public static DataTable GetLocalCompletionStatuses()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_locale_completion_statuses");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
