using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels
{
    public partial class samuiltdp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_ui_labels_texts_dropdowns_text") + "</a>";

                //bind language
                ddlLanguages.DataSource = SystemLocaleBLL.GetLocaleList();
                ddlLanguages.DataBind();
            }

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/UI Texts and Labels/samuiltdr-01.aspx?uid=" + SecurityCenter.EncryptText(txtUiId.Text)+"&uipage="+SecurityCenter.EncryptText(txtUiPages.Text)+"&keyword=" +SecurityCenter.EncryptText(txtKeyWord.Text)+"&uitype="+SecurityCenter.EncryptText(ddlUiTypes.SelectedValue)+"&language="+SecurityCenter.EncryptText(ddlLanguages.SelectedValue)+"&native="+SecurityCenter.EncryptText(txtNativeLabel.Text), false);

        }
    }
}