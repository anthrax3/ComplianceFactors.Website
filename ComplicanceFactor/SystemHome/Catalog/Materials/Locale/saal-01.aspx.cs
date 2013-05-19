using System;
using System.Web;
using System.Web.UI;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Materials.Locale
{
    public partial class saal_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Materials/Upload/";
        #endregion
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
                if (file != null && file.ContentLength > 0)
                {
                    file_name = Path.GetFileName(file.FileName);

                    file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_pathIcon + file_guid + file_extension));
                    SessionWrapper.file_guid = file_guid + file_extension;
                    SessionWrapper.file_name = file_name;
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        try
                        {
                            SystemMaterialBLL.UpdateMaterialLocaleAttachment(Request.QueryString["id"], SessionWrapper.file_guid, SessionWrapper.file_name);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("saal-01.aspx(material)", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("saal-01.aspx(material)", ex.Message);
                                }
                            }
                        }
                        // SystemCatalog course = new SystemCatalog();
                        //course.c_course_system_id_pk = Request.QueryString["editCourseId"];
                        //course.c_course_icon_uri = SessionWrapper.iconUri;
                        //course.c_course_icon_uri_file_name = SessionWrapper.iconUrifilename;
                        // SystemCatalogBLL.UpdateIcon(course);
                    }

                }


                /// <summary>
                //Close upload popup

                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

            }
        }


    }
}