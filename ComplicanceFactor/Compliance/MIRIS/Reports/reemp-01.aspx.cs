using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class reemp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            dynamicsearch1.PopulateCondition(Request.Params["id"].ToString(), Request.Params["suid"].ToString());
            Response.Redirect("~/Compliance/MIRIS/Reports/saressr-01.aspx?id=" + Request.Params["id"].ToString() + "&suid=" + Request.Params["suid"].ToString());
        }
        
    }
}