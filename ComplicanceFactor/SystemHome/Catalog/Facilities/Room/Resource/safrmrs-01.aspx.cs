using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities.Room.Resource
{
    public partial class safrmrs_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create" || Request.QueryString["mode"] == "edit") && string.IsNullOrEmpty(Request.QueryString["editRoomId"]))
            {
                Response.Redirect("~/SystemHome/Catalog/Facilities/Room/Resource/safrmrsr-01.aspx?mode="+Request.QueryString["mode"]+"&id=" + SecurityCenter.EncryptText(txtResourceId.Text) + "&name=" + SecurityCenter.EncryptText(txtResourceName.Text));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["editRoomId"]))
            {
                Response.Redirect("~/SystemHome/Catalog/Facilities/Room/Resource/safrmrsr-01.aspx?editRoomId=" + Request.QueryString["editRoomId"] + "&mode=" + Request.QueryString["mode"] + "&id=" + SecurityCenter.EncryptText(txtResourceId.Text) + "&name=" + SecurityCenter.EncryptText(txtResourceName.Text));
            }

        }
    }
}