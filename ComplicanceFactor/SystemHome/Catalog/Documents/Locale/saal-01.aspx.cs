using System;
using System.Web;
using System.Web.UI;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Documents.Locale
{
    public partial class saal_01 : System.Web.UI.Page
    {
        private string _pathIcon = "~/SystemHome/Catalog/Documents/Upload/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
             //Upload icon uri
            HttpPostedFile file = default(HttpPostedFile);

            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string file_name = null;
                string file_extension = null;
                string file_guid = Guid.NewGuid().ToString();
                string file_path = null;
                if (file != null && file.ContentLength > 0)
                {
                    file_name = Path.GetFileName(file.FileName);

                    file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathIcon + file_guid + file_extension));
                    file_path = _pathIcon + file_guid + file_extension;
                    SessionWrapper.file_guid = file_guid + file_extension;
                    SessionWrapper.file_name = file_name;
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        try
                        {
                            SystemDocumentsBLL.UpdateDocumentLocaleAttachment(Request.QueryString["id"], file_path, SessionWrapper.file_name);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("saal-01.aspx(Documents)", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("saal-01.aspx(Documents)", ex.Message);
                                }
                            }
                        }
                    }

                }


                /// <summary>
                //Close upload popup

                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
        }
    }
}