using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
namespace ComplicanceFactor.Administrator
{
    public partial class tahp_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           // btnGo.Text = LocalResources.GetLocaleResourceString("app_lh_pod_quicksearch_button_text");
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = LocalResources.GetGlobalLabel("app_nav_admin") + " > ...";


        }
    }
}