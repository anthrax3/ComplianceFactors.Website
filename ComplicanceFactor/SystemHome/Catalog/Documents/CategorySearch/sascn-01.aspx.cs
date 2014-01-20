using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Documents.CategorySearch
{
    public partial class sascn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saandin")
            {
                Response.Redirect("~/SystemHome/Catalog/Documents/CategorySearch/sasrcn-01.aspx?name=" + SecurityCenter.EncryptText(txtCategoryName.Text) + "&id=" + SecurityCenter.EncryptText(txtCategoryId.Text) + "&page=saandin", false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saedin")
            {
                string s = Request.QueryString["editDocumentId"];
                Response.Redirect("~/SystemHome/Catalog/Documents/CategorySearch/sasrcn-01.aspx?name=" + SecurityCenter.EncryptText(txtCategoryName.Text) + "&id=" + SecurityCenter.EncryptText(txtCategoryId.Text) + "&page=saedin" + "&editDocumentId=" + Request.QueryString["editDocumentId"], false);
            }
        }
    }
}