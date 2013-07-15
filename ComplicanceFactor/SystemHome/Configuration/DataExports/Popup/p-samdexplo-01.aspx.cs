using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.DataExports.Popup
{
    public partial class p_samdexplo_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLogFiles();
            }
        }
        /// <summary>
        /// Bind Log Files
        /// </summary>
        private void BindLogFiles()
        {
            try
            {
                gvExportJobRun.DataSource = SystemDataExportBLL.GetLogDetails("DEXP");
                gvExportJobRun.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-samdexplo-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-samdexplo-01.aspx", ex.Message);
                    }
                }
            }
        }

        
    }
}