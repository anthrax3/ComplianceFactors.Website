using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Rooms.Facility
{
    public partial class safs_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SystemHome/Catalog/Rooms/Facility/safsr-01.aspx?&id=" + SecurityCenter.EncryptText(txtFacilityId.Text) + "&name=" + SecurityCenter.EncryptText(txtFacilityName.Text));

        }
    }
}