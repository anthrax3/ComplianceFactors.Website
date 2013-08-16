using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.ViewLogs
{
    public partial class p_samddcublo_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLogFiles();
            }
        }
        private void BindLogFiles()
        {
            try
            {
                gvDataCurriculumStatus.DataSource = SystemHRISIntegrationBLL.GetLogDetails("DCUB");
                gvDataCurriculumStatus.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p_samddcublo-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p_samddcublo-01.aspx", ex.Message);
                    }
                }
            }
        }         
    }
}