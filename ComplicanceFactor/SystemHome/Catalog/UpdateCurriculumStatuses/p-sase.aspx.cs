using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses
{
    public partial class p_sase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/UpdateCurriculumStatuses/p-sausr.aspx?eno=" + SecurityCenter.EncryptText(txtEmployeeNumber.Text) + "&ename=" + SecurityCenter.EncryptText(txtEmployeeName.Text), false);
        }

        
    }
}