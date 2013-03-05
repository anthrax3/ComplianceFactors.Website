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
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome
{
    public partial class sasup_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_Manage_users_text");
            if (!IsPostBack)
            {
                try
                {
                    ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName,"sasup-01");
                    ddlUserstatus.DataBind();
                    ddlUserstatus.SelectedValue = "app_ddl_all_text";
                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sasup-01");
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
                            Logger.WriteToErrorLog("saau-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saau-01", ex.Message);
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
            Response.Redirect("~/SystemHome/Users/sasur-01.aspx?lastname=" + SecurityCenter.EncryptText(txtLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtUsername.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlUserstatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlUserdomain.SelectedValue));

        }
    }
}