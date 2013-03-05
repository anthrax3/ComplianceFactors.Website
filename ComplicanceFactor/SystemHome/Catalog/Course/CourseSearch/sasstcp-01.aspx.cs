using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Popup
{
    public partial class sasstcp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=prerequisites&page=saetc" + "&editCourseId="+ Request.QueryString["editCourseId"], false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Equivalencies&page=saetc" + "&editCourseId=" + Request.QueryString["editCourseId"], false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Fulfillments&page=saetc" + "&editCourseId=" + Request.QueryString["editCourseId"], false);
                }

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=prerequisites&page=saantc", false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Equivalencies&page=saantc", false);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    Response.Redirect("~/SystemHome/Catalog/Course/CourseSearch/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=Fulfillments&page=saantc", false);
                }
            }

        }
    }
}