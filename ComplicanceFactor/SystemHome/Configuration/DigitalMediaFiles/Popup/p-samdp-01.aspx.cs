using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.Popup
{
    public partial class p_samdp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.paramMediaPath.Attributes.Add("value", "");
            //string VideoPath = "";
            //this.paramMediaPath.Attributes.Add("value", VideoPath);

            EmbedSrc = "../Images/1919b655-81f7-4840-b3e3-85acf64ecf82.jpg";

        }

        public string EmbedSrc{get;set;}

        
    }
}