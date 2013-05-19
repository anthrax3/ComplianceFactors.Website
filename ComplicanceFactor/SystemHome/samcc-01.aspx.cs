﻿using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.SystemHome
{
    public partial class samcc_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLocaleResourceText("app_sahp_pagename") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLocaleResourceText("app_samcc_pagename");
        }
    }
}