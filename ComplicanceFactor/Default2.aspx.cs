using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] cookies = Request.Cookies.AllKeys;
                foreach (string cookie in cookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }

                if (string.IsNullOrEmpty(SessionWrapper.CultureName))
                {
                    SessionWrapper.CultureName = "us_english";
                }
                if (!string.IsNullOrEmpty(Request.QueryString["out"]))
                {
                    SessionWrapper.CultureName = SecurityCenter.DecryptText(Request.QueryString["locale"]);
                    Response.Redirect("~/glp-01.aspx?out=" + SecurityCenter.EncryptText("success") + "&locale=" + Request.QueryString["locale"]);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["expire"]))
                {
                    Response.Redirect("~/glp-01.aspx?expire=" + SecurityCenter.EncryptText("true"));
                }
                else
                {
                    Response.Redirect("glp-01.aspx");
                }
            }

        }
    }
}