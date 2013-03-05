using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;


namespace ComplicanceFactor.SystemHome.Users.ChangePassword
{
    public partial class sacpu_01 : System.Web.UI.Page
    {
        #region Private member variable
        private string plainText = "";    // original plaintext
        private string cipherText = "";                 // encrypted text
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtNewPassWord.Value != "")
            {
               
            }
        }

        
        public bool Passwordvalidate(string enteredPwd, string dbpwd)
        {
            //get current user password from database
            User userLogin = new User();
            userLogin = UserBLL.GetUserInfo_by_id(SessionWrapper.u_userid);
            dbpwd = userLogin.Password_enc_salt;
            HashEncryption encHash = new HashEncryption();
            //convert new passwrd to hash encryption
            //get hash value for new password
            string encHashpwd = encHash.GenerateHashvalue(enteredPwd, true);
            // Encrypt password with salt and validation
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
            cipherText = rijndaelKey.Encrypt(enteredPwd);
            plainText = rijndaelKey.Decrypt(cipherText);
            dbpwd = rijndaelKey.Decrypt(dbpwd);
            //plainText - user enter password it converted into salt encryption
            //dbpwd - current user password from database
            //Password_enc_ash - get hash encryption password from database
            //encHashpwd -  user enter password it converted into the hash encryption
            if (plainText == dbpwd && (string)userLogin.Password_enc_ash == encHashpwd)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool pwd = Passwordvalidate(txtCurrentPassword.Value, txtNewPassWord.Value);
                if (pwd == true)
                { 
                    // Hash encryption for username and password
                    HashEncryption encHash = new HashEncryption();
                    // Salt encryption for password
                    RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);
                    UserBLL.ResetPassword(SessionWrapper.u_userid,encHash.GenerateHashvalue(txtNewPassWord.Value, true), rijndaelKey.Encrypt(txtNewPassWord.Value));
                    div_error.Style.Add("display", "none");
                    div_success.Style.Add("display", "block");
                }
                else
                {
                    div_error.Style.Add("display", "block");
                    div_error.InnerHtml = "Please enter the valid current password.";
                    div_success.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                div_error.Style.Add("display", "block");
                div_error.InnerHtml = "Error: Updating data." ;
                div_success.Style.Add("display", "none");
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sacpu-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacpu-01", ex.Message);
                    }
                }
            }
        }
    }
}