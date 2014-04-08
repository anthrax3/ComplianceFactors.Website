using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance.MIRIS.Reports.popup
{
    public partial class sasumsm_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/Reports/popup/sasumsmr-01.aspx?employeeName=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&employeeId=" + SecurityCenter.EncryptText(txtEmployeeId.Text));

            //Response.Redirect("~/SystemHome/Catalog/MassCompletions/sasumsmr-01.aspx?employeeName=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&employeeId=" + SecurityCenter.EncryptText(txtEmployeeId.Text));
        }
    }
}