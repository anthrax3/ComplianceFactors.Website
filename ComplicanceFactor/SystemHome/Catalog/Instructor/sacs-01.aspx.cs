using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Instructor
{
    public partial class sacs_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Instructor/sacsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&name=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&uid=" + SecurityCenter.EncryptText(Request.QueryString["uid"]));
        }
    }
}