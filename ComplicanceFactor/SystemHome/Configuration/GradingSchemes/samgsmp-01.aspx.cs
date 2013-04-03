using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//to use userdefined BAL's functions
using ComplicanceFactor.BusinessComponent;
//to use logger class to record errors
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class samgsmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" +"System" + "</a>&nbsp;" + " >&nbsp;" + "Manage Delivery Types";
                SearchResults();
            }
        }

        private void SearchResults()
        {
            try
            {
                //gvgradingSchemes.DataSource = GradingSchemesBLL.SearchGradingSchemes();
                //gvgradingSchemes.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samgsmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samgsmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnAddNewCurriculum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/GradingSchemes/saangsn-01.aspx");
        }
    }
}