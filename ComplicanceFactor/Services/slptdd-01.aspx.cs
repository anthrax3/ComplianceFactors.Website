using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.Services
{
    public partial class slptdd_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/glp-01.aspx>" + LocalResources.GetLocaleResourceString("wp_nav_home") + "</a>&nbsp; " + ">" + "&nbsp;<a href=/Services/serp-01.aspx>" + LocalResources.GetLocaleResourceString("wp_nav_services") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLocaleResourceText("wp_slptdd_pagename");


        }
    }
}