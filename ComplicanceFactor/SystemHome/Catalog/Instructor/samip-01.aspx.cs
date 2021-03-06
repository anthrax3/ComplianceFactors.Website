﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Instructor
{
    public partial class samip_01 : BasePage
    {
        string navigationText;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["page"] == "training")
            //{
            //    hdNav_selected.Value = "#app_nav_training";
            //    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            //    lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + "Training" + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_instructors_text");
            //}
            //else
            //{
            //    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            //    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_instructors_text");
            //}             
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
            hdNav_selected.Value = "#"+SessionWrapper.navigationText;
            lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_instructors_text") + "</a>";
            if (!IsPostBack)
            {
                try
                {

                    ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName,"samip-01");
                    ddlUserstatus.DataBind();
                    ddlUserstatus.SelectedValue = "app_ddl_all_text";
                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "samip-01");
                    ddlUserTypes.DataBind();
                    ddlUserdomain.DataSource = UserBLL.GetUserDomains();
                    ddlUserdomain.DataBind();
                    ListItem lstUserDomain = new ListItem();
                    lstUserDomain.Text = "All";
                    lstUserDomain.Value = "0";
                    ddlUserdomain.Items.Insert(0, lstUserDomain);
                    ddlUserdomain.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samip-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samip-01", ex.Message);
                        }
                    }

                }
            }
        }

        protected void btnAddnewuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/saau-01.aspx");

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Instructor/samir-01.aspx?lastname=" + SecurityCenter.EncryptText(txtLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtUsername.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlUserstatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlUserdomain.SelectedValue));

        }
    }
}