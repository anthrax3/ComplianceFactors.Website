using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saress_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/ResourseSearch/saressr-01.aspx?page="+ Request.QueryString["page"] +"&id=" + SecurityCenter.EncryptText(txtResourceId.Text) + "&name=" + SecurityCenter.EncryptText(txtResourceName.Text));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/ResourseSearch/saressr-01.aspx?editdelivery="+Request.QueryString["editdelivery"] +"&page=" + Request.QueryString["page"] + "&id=" + SecurityCenter.EncryptText(txtResourceId.Text) + "&name=" + SecurityCenter.EncryptText(txtResourceName.Text));
            }
           
        }
    }
}