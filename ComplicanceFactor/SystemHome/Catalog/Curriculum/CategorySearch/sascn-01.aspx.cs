using System;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.CategorySearch
{
    public partial class sascn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CategorySearch/sasrcn-01.aspx?name=" + SecurityCenter.EncryptText(txtCategoryName.Text) + "&id=" + SecurityCenter.EncryptText(txtCategoryId.Text) + "&page=saanc", false);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CategorySearch/sasrcn-01.aspx?name=" + SecurityCenter.EncryptText(txtCategoryName.Text) + "&id=" + SecurityCenter.EncryptText(txtCategoryId.Text) + "&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
            }
        }
    }
}