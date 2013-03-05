using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.DomainPopup
{
    public partial class sasdn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/DomainSearch/sasrdn-01.aspx?name=" + SecurityCenter.EncryptText(txtDomainName.Text) + "&id=" + SecurityCenter.EncryptText(txtDomainId.Text) + "&page=saantc" , false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/DomainSearch/sasrdn-01.aspx?name=" + SecurityCenter.EncryptText(txtDomainName.Text) + "&id=" + SecurityCenter.EncryptText(txtDomainId.Text) + "&page=saetc" + "&editCourseId=" + Request.QueryString["editCourseId"], false);
            }
        }
    }
}