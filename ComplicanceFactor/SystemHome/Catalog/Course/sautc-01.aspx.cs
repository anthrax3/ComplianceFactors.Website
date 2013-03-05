using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Popup
{
    public partial class sautc_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Course/Icons/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc" || Request.QueryString["page"] == "saantc")
            {
                //Upload icon uri
                HttpPostedFile file = default(HttpPostedFile);

                foreach (string files in Request.Files)
                {
                    file = Request.Files[files];
                    string icon_name = null;
                    string icon_extension = null;
                    string icon_guid = Guid.NewGuid().ToString();
                    if (file != null && file.ContentLength > 0)
                    {
                        icon_name = Path.GetFileName(file.FileName);

                        icon_extension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath(_pathIcon + icon_guid + icon_extension));
                        SessionWrapper.iconUri = icon_guid + icon_extension;
                        SessionWrapper.iconUrifilename = icon_name;
                        if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc" && !string.IsNullOrEmpty(Request.QueryString["editCourseId"]))
                        {
                            SystemCatalog course = new SystemCatalog();
                            course.c_course_system_id_pk = Request.QueryString["editCourseId"];
                            course.c_course_icon_uri = SessionWrapper.iconUri;
                            course.c_course_icon_uri_file_name = SessionWrapper.iconUrifilename;
                            SystemCatalogBLL.UpdateIcon(course);
                        }

                    }

                }
                /// <summary>
                //Close upload popup

                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

            }
        }


    }
}