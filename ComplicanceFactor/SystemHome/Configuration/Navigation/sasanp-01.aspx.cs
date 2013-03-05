using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;

namespace ComplicanceFactor.SystemHome.Configuration.Navigation
{
    public partial class sasanp_01 : System.Web.UI.Page
    {
        private string id;
        String pagename = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];

        }

        protected void btnGeneratePage_Click(object sender, EventArgs e)
        {
            DataTable dtNav = NavigationBLL.GetAllWebNavigation(id);
            string path = dtNav.Rows[0]["s_web_nav_url"].ToString();
            string root = Path.GetDirectoryName(path);
            root = root.Replace("\\", "/");
            root = root + "/";
            String physicalPath = Server.MapPath(root);
            String root1 = Server.MapPath("~/SystemHome/Configuration/Navigation/");
            String pgTemplate = root1 + "myPageTemplate.tmp";
            StringBuilder line = new StringBuilder();
            using (StreamReader rwOpenTemplate = new StreamReader(pgTemplate))
            {
                while (!rwOpenTemplate.EndOfStream)
                {
                    line.Append(rwOpenTemplate.ReadToEnd());
                }
            }
            string SaveFilePath = "";
            string SaveFileName = "";
            string native = string.Empty;
            pagename = txtPageURI.Text.Replace(' ', '-').Replace('#', '-').Replace('%', '-').Replace('&', '-').Replace('*', '-').Replace('@', '-').Replace('!', '-').Replace('|', '-').Replace(':', '-').Replace(';', '-').Replace(',', '-').Replace("/", "").Replace("\\", "").Replace('?', '-').Replace('<', '-').Replace('>', '-').Replace('"', '-').Replace('“', '-').Replace('”', '-').Trim();
            SaveFileName = pagename;
            SaveFilePath = physicalPath + SaveFileName;
            FileStream fsSave = File.Create(SaveFilePath);
            native = txtNativeLabel.Text.Replace(' ', '_').Replace('#', '_').Replace('%', '_').Replace('&', '_').Replace('*', '_').Replace('@', '_').Replace('!', '_').Replace('|', '_').Replace(':', '_').Replace(';', '_').Replace(',', '_').Replace('/', '_').Replace('\\', '_').Replace('?', '_').Replace('<', '_').Replace('>', '_').Replace('"', '_').Replace('“', '_').Replace('”', '_').Trim();
            string strPageName = pagename.Replace(".aspx", "");
            NavigationBLL.InsertWebNewPage(id, root + pagename, "wp_nav_" + native, strPageName, txtNativeLabel.Text);
            if (line != null)
            {
                string wpnav = '"' + "wp_nav_" + native +"_content"+ '"';
                string cmgsoon = '"' + "app_coming_soon" + '"';
                line.Replace("[PageContent]", "<%=LocalResources.GetText(" + wpnav + ")%> -  <%=LocalResources.GetGlobalLabel(" + cmgsoon + ")%>");
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(fsSave);
                    sw.Write(line);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sasanp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sasanp-01", ex.Message);
                        }
                    }
                }
                finally
                {
                    sw.Close();
                }
            }
            SessionWrapper.Active_Popup = "true";
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
    }
}