using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.AudienceSearch
{
    public partial class sasan_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/AudienceSearch/sasran-01.aspx?name=" + SecurityCenter.EncryptText(txtAudienceName.Text) + "&id=" + SecurityCenter.EncryptText(txtAudienceId.Text) + "&page=saanc", false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/AudienceSearch/sasran-01.aspx?name=" + SecurityCenter.EncryptText(txtAudienceName.Text) + "&id=" + SecurityCenter.EncryptText(txtAudienceId.Text) + "&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
            }
        }
    }
}