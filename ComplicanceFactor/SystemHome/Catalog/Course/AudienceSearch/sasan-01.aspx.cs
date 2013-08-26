using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Course.AudienceSearch
{
    public partial class sasan_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/AudienceSearch/sasran-01.aspx?name=" + SecurityCenter.EncryptText(txtAudienceName.Text) + "&id=" + SecurityCenter.EncryptText(txtAudienceId.Text) + "&page=saantc", false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/AudienceSearch/sasran-01.aspx?name=" + SecurityCenter.EncryptText(txtAudienceName.Text) + "&id=" + SecurityCenter.EncryptText(txtAudienceId.Text) + "&page=saetc" + "&editCourseId=" + Request.QueryString["editCourseId"], false);
            }
        }
    }
}