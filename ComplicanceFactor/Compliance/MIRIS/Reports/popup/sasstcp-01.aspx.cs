using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance.MIRIS.Reports.popup
{
    public partial class sasstcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/Reports/popup/sastcrr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&select=prerequisites&page=saetc" + "&editCourseId=" + Request.QueryString["editCourseId"], false);
        }
    }
}