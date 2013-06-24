using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Configuration.Themes.Popup
{
    public partial class p_satim_01 : System.Web.UI.Page
    {
        public static string logoUpload;
        public static string _path = "~/SystemHome/Configuration/Themes/Logo/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uploadedImage"]))
            {
                logoUpload = Request.QueryString["uploadedImage"].ToString();
            }
        }

        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_path + c_file_name));

                    var rows = SessionWrapper.defaults_theme_logo.Select("keyvalue= '" + logoUpload + "'");
                    foreach (var currentrow in rows)
                        currentrow["FileName"] = c_file_name;
                    SessionWrapper.defaults_theme_logo.AcceptChanges();


                    //if (!string.IsNullOrEmpty(Request.QueryString["editThemeId"]))
                    //{
                    //    //Update
                    //    //string themeId = Request.QueryString["editThemeId"].ToString();
                    //    //int result = SystemThemeBLL.UpdateLogo(logoUpload, themeId, c_file_name);
                    //    var rows = SessionWrapper.defaults_theme_logo.Select("keyvalue= '" + logoUpload + "'");
                    //    foreach (var currentrow in rows)
                    //        currentrow["FileName"] = c_file_name;
                    //    SessionWrapper.defaults_theme_logo.AcceptChanges();
                    //}
                    //else
                    //{
                    //    var rows = SessionWrapper.defaults_theme_logo.Select("keyvalue= '" + logoUpload + "'");
                    //    foreach (var currentrow in rows)
                    //        currentrow["FileName"] = c_file_name;
                    //    SessionWrapper.defaults_theme_logo.AcceptChanges();
                    //}
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}