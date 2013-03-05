using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class sarms_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/Session/RoomSearch/sarmsr-01.aspx?page=sand&id=" + SecurityCenter.EncryptText(txtRoomId.Text) + "&name=" + SecurityCenter.EncryptText(txtRoomName.Text));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/Session/RoomSearch/sarmsr-01.aspx?page=saed&id=" + SecurityCenter.EncryptText(txtRoomId.Text) + "&name=" + SecurityCenter.EncryptText(txtRoomName.Text));
            }

        }
    }
}