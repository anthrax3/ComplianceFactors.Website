using System;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses
{
   
    public partial class p_sase : System.Web.UI.Page
    {
        //public static string curriculumid;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]))
            //    {
            //        curriculumid = Request.QueryString["editCurriculumId"].ToString();
            //    }
            //}
        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/UpdateCurriculumStatuses/p-sausr.aspx?eno=" + SecurityCenter.EncryptText(txtEmployeeNumber.Text) + "&ename=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&curriculumId=" + SecurityCenter.EncryptText(Request.QueryString["editCurriculumId"].ToString()), false);
        }

        
    }
}