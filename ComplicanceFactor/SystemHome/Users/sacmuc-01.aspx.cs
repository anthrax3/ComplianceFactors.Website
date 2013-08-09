using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor
{
    public partial class sacmuc_01 : BasePage
    {
        private string user1;
        private string user2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["user1"]) && !string.IsNullOrEmpty(Request.QueryString["user2"]))
            {
                user1 = SecurityCenter.DecryptText(Request.QueryString["user1"]);
                user2 = SecurityCenter.DecryptText(Request.QueryString["user2"]);

                Users(user1,gvUser1);
                Users(user2, gvUser2);

            } 
        }
       
        protected void gvUser1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvUser2_RowDataBound(object sender, GridViewRowEventArgs e)
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

        public void Users(string userId, GridView gvUser)
        {
            User selectedUser = new User();
            selectedUser.Userid = userId;

            try
            {
                gvUser.DataSource = UserBLL.SelectedUser(selectedUser);
                gvUser.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmuc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmuc-01", ex.Message);
                    }
                }
            }
        }

        protected void btnConfirm_merge_user_Click(object sender, EventArgs e)
        {

            MergeUser();
             //string user2UserId=    gvUser2.DataKeys[0].Values[0].ToString();
             //Response.Redirect("~/SystemHome/Users/saeu-01.aspx?id=" + SecurityCenter.EncryptText(user2UserId) + "&succ=" + SecurityCenter.EncryptText("merge"));
        }

        protected void btnConfirm_merge_user_footer_Click(object sender, EventArgs e)
        {
            MergeUser();
            //string user2Username_enc = gvUser2.DataKeys[0].Values[0].ToString();
            //Response.Redirect("~/SystemHome/Users/saeu-01.aspx?id=" + SecurityCenter.EncryptText(user2Username_enc) + "&succ=" + SecurityCenter.EncryptText("merge"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");
        }

        protected void btnCancel_footer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/sasup-01.aspx");

        }
        private void MergeUser()
        {
            try
            {
                DataSet ds = UserBLL.MergeUser(user1, user2);
                //if (result == 0)
                //{
                    string user2Username_enc = gvUser2.DataKeys[0].Values[0].ToString();
                    Response.Redirect("~/SystemHome/Users/saeu-01.aspx?id=" + SecurityCenter.EncryptText(user2Username_enc) + "&succ=" + SecurityCenter.EncryptText("merge"));
                //}
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacmuc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacmuc-01", ex.Message);
                    }
                }
            }

        }
    }
}