using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.DomainSearch
{
    public partial class sasdn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/DomainSearch/sasrdn-01.aspx?name=" + SecurityCenter.EncryptText(txtDomainName.Text) + "&id=" + SecurityCenter.EncryptText(txtDomainId.Text) + "&page=saanc", false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/DomainSearch/sasrdn-01.aspx?name=" + SecurityCenter.EncryptText(txtDomainName.Text) + "&id=" + SecurityCenter.EncryptText(txtDomainId.Text) + "&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
            }
        }
    }
}