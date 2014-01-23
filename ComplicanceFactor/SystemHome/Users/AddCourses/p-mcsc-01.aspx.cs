using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Users.AddCourses
{
    public partial class p_mcsc_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Users/AddCourses/p-mcsr-01.aspx?id=" + SecurityCenter.EncryptText(txtCatalogId.Text) + "&name=" + SecurityCenter.EncryptText(txtCatalogName.Text));
        }
    }
}