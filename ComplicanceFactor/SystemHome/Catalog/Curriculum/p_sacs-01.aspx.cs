using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class p_sacs_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=prerequisites&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Equivalencies&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Fulfillments&page=saec" + "&editCurriculumId=" + Request.QueryString["editCurriculumId"], false);
                }

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=prerequisites&page=saanc", false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Equivalencies&page=saanc", false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/p_sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculimId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Fulfillments&page=saanc", false);
                }
            }

        }
    }
}