using System;
using System.Web;
using System.Web.UI;
using System.IO;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class sautc_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec" || Request.QueryString["page"] == "saanc")
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
                        SessionWrapper.c_curriculum_icon_uri = icon_guid + icon_extension;
                        SessionWrapper.c_curriculum_icon_uri_file_name = icon_name;
                        if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec" && !string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]))
                        {
                            SystemCurriculum insertIcon = new SystemCurriculum();

                            insertIcon.c_curriculum_system_id_pk = Request.QueryString["editCurriculumId"];
                            insertIcon.c_curriculum_icon_uri = SessionWrapper.c_curriculum_icon_uri;
                            insertIcon.c_curriculum_icon_uri_file_name = SessionWrapper.c_curriculum_icon_uri_file_name;
                            SystemCurriculumBLL.UpdateIcon(insertIcon);
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