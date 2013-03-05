using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;

namespace ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels
{

    public partial class Add_text_Locale : System.Web.UI.Page
    {
        private string type;
        private string editTextId;
        private string localeid;
        private string app_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ui type
            type = Request.QueryString["type"];
           
            //ui text id (unique)
            if (!string.IsNullOrEmpty(Request.QueryString["editTextId"]))
            {
                editTextId = Request.QueryString["editTextId"];
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
            {
                //ui_text_name
                app_name = Request.QueryString["appname"];
            }
            //locale id
            localeid = Request.QueryString["localeid"];
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    DataTable dtText = new DataTable();
                    dtText = SystemUI_Texts_Labels_DropdownBLL.GetSingleUIText(editTextId, localeid,app_name);
                    if (dtText.Rows.Count > 0)
                    {
                        txtUiText.Value = dtText.Rows[0]["ui_text"].ToString();
                    }
                }
            }
        }

        protected void btnSaveUiText_Click(object sender, EventArgs e)
        {
            try
            {
                string strReplace = txtUiText.Value.Replace("'", "''");
                SystemUI_Texts_Labels_DropdownBLL.UpdateUiText(editTextId, localeid, strReplace,app_name);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-satl-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-satl-01.aspx", ex.Message);
                    }
                }
            }

        }
    }
}