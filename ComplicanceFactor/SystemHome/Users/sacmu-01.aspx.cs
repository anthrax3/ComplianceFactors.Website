using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome
{
    public partial class sacmu_01 : BasePage
    {
        private string userid;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["merge"]))
            {
                userid = SecurityCenter.DecryptText(Request.QueryString["merge"]);
                SelectedUser(userid);

            }
            if (!IsPostBack)
            {
                try
                {

                    ddlUserstatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName,"sacmu-01");
                    ddlUserstatus.DataBind();
                    ddlUserstatus.SelectedValue = "app_ddl_all_text";

                    //ListItem lstStatus = new ListItem();
                    //lstStatus.Text = "All";
                    //lstStatus.Value = "0";

                    //ddlUserstatus.Items.Insert(0, lstStatus);

                    //ddlUserstatus.SelectedIndex = 0;



                    ddlUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sacmu-01");
                    ddlUserTypes.DataBind();
                    ddlUserdomain.DataSource = UserBLL.GetUserDomains();
                    ddlUserdomain.DataBind();

                    //ListItem lstUserType = new ListItem();
                    //lstUserType.Text = "All Types";
                    //lstUserType.Value = "0";

                    //ddlUserTypes.Items.Insert(0, lstUserType);
                    //ddlUserTypes.SelectedIndex = 0;
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

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sacmur-01.aspx?merge=" + SecurityCenter.EncryptText(userid) + "&lastname=" + SecurityCenter.EncryptText(txtLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtUsername.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlUserstatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlUserdomain.SelectedValue));


        }
        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUsername = (Label)e.Row.FindControl("lblUsername");
                /// <summary>
                /// decrypt hash  username
                /// </summary>
                HashEncryption encHash = new HashEncryption();
                lblUsername.Text = encHash.Decrypt(lblUsername.Text, true);


            }

        }
        public void SelectedUser(string userId)
        {


            User selectedUser = new User();
            selectedUser.Userid = userId;

            try
            {
                gvsearchDetails.DataSource = UserBLL.SelectedUser(selectedUser);
                gvsearchDetails.DataBind();




            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmu-01", ex.Message);
                    }
                }
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
        }
    }
}