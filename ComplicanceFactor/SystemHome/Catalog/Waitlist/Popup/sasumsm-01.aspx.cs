using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Waitlist.Popup
{
    public partial class sasumsm_01 : System.Web.UI.Page
    {
        private static string courseId;
        private static string deliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
                    {
                        courseId = Request.QueryString["courseId"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["deliveryId"]))
                    {
                        deliveryId = Request.QueryString["deliveryId"].ToString();
                    }

                    ddlSearchUserStatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName, "sasumsm-01");
                    ddlSearchUserStatus.DataBind();
                    ddlSearchUserStatus.SelectedValue = "app_ddl_all_text";
                    //ListItem lstStatus = new ListItem();
                    //lstStatus.Text = "All";
                    //lstStatus.Value = "0";
                    //ddlSearchUserStatus.Items.Insert(0, lstStatus);

                    //ddlSearchUserStatus.SelectedIndex = 0;


                    ddlSearchUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sasumsm-01");
                    ddlSearchUserTypes.DataBind();
                    ddlSearchUserDomain.DataSource = UserBLL.GetUserDomains();
                    ddlSearchUserDomain.DataBind();

                    ListItem lstAll = new ListItem();
                    lstAll.Text = "All Types";
                    lstAll.Value = "0";

                    //ddlSearchUserTypes.Items.Insert(0, lstAll);
                    //ddlSearchUserTypes.SelectedIndex = 0;
                    ddlSearchUserDomain.Items.Insert(0, lstAll);
                    ddlSearchUserDomain.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sasumsm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sasumsm-01", ex.Message);
                        }
                    }

                }
            }
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Waitlist/Popup/sasumsmr-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue));

        }


    }
}