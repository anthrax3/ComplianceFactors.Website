using System;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.CourseSearch
{
    public partial class p_spcs_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "add" && Request.QueryString["page"] == "p-sacp-01")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CourseSearch/p-spcsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&name=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&sec=" + SecurityCenter.EncryptText(Request.QueryString["sec"]) + "&mode=" + (Request.QueryString["mode"])+"&page="+(Request.QueryString["page"]));
            }
            else if (Request.QueryString["mode"] == "edit" && Request.QueryString["page"] == "p-secp-01")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CourseSearch/p-spcsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&name=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&sec=" + SecurityCenter.EncryptText(Request.QueryString["sec"]) + "&mode=" + (Request.QueryString["mode"]) + "&editcurriculumId=" + (Request.QueryString["editcurriculumId"] + "&editCurriculumpathId=" + (Request.QueryString["editCurriculumpathId"]) + "&page=" + (Request.QueryString["page"])));
            }
            else if (Request.QueryString["mode"] == "add" && Request.QueryString["page"] == "p-sacrp-01")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CourseSearch/p-spcsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&name=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&sec=" + SecurityCenter.EncryptText(Request.QueryString["sec"]) + "&mode=" + (Request.QueryString["mode"]) + "&page="+(Request.QueryString["page"]));
            }
            else if (Request.QueryString["mode"] == "edit" && Request.QueryString["page"] == "p-secrp-01")
            {
                Response.Redirect("~/SystemHome/Catalog/Curriculum/CourseSearch/p-spcsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&name=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&sec=" + SecurityCenter.EncryptText(Request.QueryString["sec"]) + "&mode=" + (Request.QueryString["mode"]) + "&editcurriculumId=" + (Request.QueryString["editcurriculumId"] + "&editCurriculumpathId=" + (Request.QueryString["editCurriculumpathId"]) + "&page=" + (Request.QueryString["page"])));
            }
        }
    }
}