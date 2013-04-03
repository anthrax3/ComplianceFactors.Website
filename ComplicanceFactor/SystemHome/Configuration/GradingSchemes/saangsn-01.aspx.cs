using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Configuration.GradingSchemes
{
    public partial class saangsn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb =(Label) Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/GradingSchemes/samgsmp-01.aspx>" + "Manage Grading Schemes" + "</a>&nbsp;" + " >&nbsp;" +"Create New Grading Schemes";

                //Bind Status
                ddlStatus.DataSource = SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName,"saangsn-01");
                ddlStatus.DataBind();

                //Bind Type
                ddlType.DataSource =SystemGradingSchemesBLL.GetGradingSchemeType(SessionWrapper.CultureName,"saangsn-01" );
                ddlType.DataBind();

            }
        }
    }
}

//SystemGradingSchemesBLL.GetStatus(SessionWrapper.CultureName, "saangsn-01")
//SystemGradingSchemesBLL.GetGradingSchemeType(SessionWrapper.CultureName, "saangsn-01");