using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class osha300_condition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            dynamicsearch1.PopulateCondition(Request.Params["id"].ToString(), Request.Params["suid"].ToString());
            switch (Request.Params["page"])
            { 
                case "300":
                    Response.Redirect("~/Compliance/MIRIS/Reports/osha300.aspx?id=" + Request.Params["id"].ToString() + "&suid=" + Request.Params["suid"].ToString());
                    break;
                case "300a":
                    Response.Redirect("~/Compliance/MIRIS/Reports/osha300a.aspx?id=" + Request.Params["id"].ToString() + "&suid=" + Request.Params["suid"].ToString());
                    break;
                case "completionCourse":
                    Response.Redirect("~/Compliance/MIRIS/Reports/CompletionofCourses.aspx?id=" + Request.Params["id"].ToString() + "&suid=" + Request.Params["suid"].ToString());
                    break;
                default:
                    break;
            }
           
        }

       
    }
}