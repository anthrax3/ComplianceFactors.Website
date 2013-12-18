using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Compliance
{
    public partial class ccmrp_01 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

       
          
        }
        [System.Web.Services.WebMethod]
        public static void Reload(string args)
        {
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

      

      
    }
}