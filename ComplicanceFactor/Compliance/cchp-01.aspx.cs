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
namespace ComplicanceFactor.Compliance
{
    public partial class cchp_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
           // lblBreadCrumb.Text = "<a href=/Employee/lhp-01.aspx>" + LocalResources.GetLocaleResourceString("app_nav_employee") + "</a>" + " > " + LocalResources.GetLocaleResourceText("app_cchp_pagename");


        }
    }
}