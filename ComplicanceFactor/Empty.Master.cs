using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor
{
    public partial class Empty : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get dyanamic css color
            User usercss = new User();
            usercss = UserBLL.GetCss(SessionWrapper.u_userid);
            HtmlGenericControl style = new HtmlGenericControl();
            style.TagName = "style";
            style.Attributes.Add("type", "text/css");
            style.InnerHtml = usercss.css + usercss.popup_background; 
            Page.Header.Controls.Add(style);
        }
    }
}