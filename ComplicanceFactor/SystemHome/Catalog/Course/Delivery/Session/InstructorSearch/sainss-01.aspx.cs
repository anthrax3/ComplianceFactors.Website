using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class sainss_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/Session/InstructorSearch/sainssr-01.aspx?page="+Request.QueryString["page"]+"&lastname=" + SecurityCenter.EncryptText(txtLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtFirstName.Text));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02" && !string.IsNullOrEmpty(Request.QueryString["editsession"]))
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/Session/InstructorSearch/sainssr-01.aspx?editsession="+Request.QueryString["editsession"]+"&editdelivery="+ Request.QueryString["editdelivery"]+"&page=" + Request.QueryString["page"] + "&lastname=" + SecurityCenter.EncryptText(txtLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtFirstName.Text));
            }
           
        }
    }
}