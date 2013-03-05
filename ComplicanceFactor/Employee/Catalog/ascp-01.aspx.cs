using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.Employee.Catalog
{
    public partial class ascp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " > " + LocalResources.GetGlobalLabel("app_advanced_search_catalog_text");
            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);
            if (!IsPostBack)
            {
                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");

                ListItem liAll = new ListItem();
                liAll.Text = "All";
                liAll.Value = "1";

                try
                {
                    //type

                    ddlType.DataSource = EmployeeCatalogBLL.GetCatalogType(SessionWrapper.CultureName,"ascp-01");
                    ddlType.DataBind();
                    //delivery type
                    ddlDelivery.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                    ddlDelivery.DataBind();

                    ddlLanguage.DataSource = EmployeeCatalogBLL.GetLocalelist();
                    ddlLanguage.DataBind();
                    ddlLanguage.Items.Insert(0, liAll);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ascp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ascp-01.aspx", ex.Message);
                        }
                    }
                }
            }

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Employee/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/ascp-01.aspx", false);
        }

        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/bchp-01.aspx", false);
        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Employee/Catalog/ascr-01.aspx?id="+ SecurityCenter.EncryptText(txtId.Text)+"&title="+SecurityCenter.EncryptText(txtTitle.Text)+"&keyword="+SecurityCenter.EncryptText(txtKeyword.Text)+"&type="+SecurityCenter.EncryptText(ddlType.SelectedItem.Text)+"&deliverytype="+ SecurityCenter.EncryptText(ddlDelivery.SelectedValue)+"&language="+SecurityCenter.EncryptText(ddlLanguage.SelectedValue)+"&typeval=" + SecurityCenter.EncryptText(ddlType.SelectedValue),false);

        }
    }
}