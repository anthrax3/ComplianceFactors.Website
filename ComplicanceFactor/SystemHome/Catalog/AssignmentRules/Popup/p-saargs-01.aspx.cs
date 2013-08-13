using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentRules.Popup
{
    public partial class p_saargs_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentRules/Popup/p-saargsr-01.aspx?id=" + SecurityCenter.EncryptText(txtGroupId.Text) + "&name=" + SecurityCenter.EncryptText(txtGroupName.Text) + "&ruleId=" + Request.QueryString["ruleId"].ToString());
        }
    }
}