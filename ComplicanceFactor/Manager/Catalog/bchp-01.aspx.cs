using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.Manager.Catalog
{
    public partial class bchp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + " > " + LocalResources.GetGlobalLabel("app_browse_catalog_text");
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

                SessionWrapper.brwcatalog_bredcrumb = "";
                ListItem liAll = new ListItem();
                liAll.Text = "All";
                liAll.Value = "1";

                try
                {
                    //type
                    ddlType.DataSource = EmployeeCatalogBLL.GetCatalogType(SessionWrapper.CultureName, "bchp-01");
                    ddlType.DataBind();
                    //delivery type
                    ddlDelivery.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                    ddlDelivery.DataBind();
                    ddlLanguage.DataSource = EmployeeCatalogBLL.GetLocalelist();
                    ddlLanguage.DataBind();
                    ddlLanguage.Items.Insert(0, liAll);
                    //EmployeeCatalogBLL.GetMainCategory();
                    lstCatalogCategories.DataSource = EmployeeCatalogBLL.GetParentCategory(SessionWrapper.CultureName);
                    lstCatalogCategories.DataBind();
                }

                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("bchp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("bchp-01", ex.Message);
                        }
                    }
                }
            }


        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Manager/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/ascp-01.aspx", false);
        }

        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/bchp-01.aspx", false);
        }
        protected void lstCatalogCategories_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                string parentcategoryId = Convert.ToString(lstCatalogCategories.DataKeys[dataItem.DataItemIndex].Value);
                GridView gvSubCategories = new GridView();
                gvSubCategories = (GridView)e.Item.FindControl("gvSubCategories");
                try
                {
                    //Get child category
                    gvSubCategories.DataSource = EmployeeCatalogBLL.GetChildCategory(parentcategoryId, SessionWrapper.CultureName);
                    gvSubCategories.DataBind();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("bchp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("bchp-01", ex.Message);
                        }
                    }
                }


            }
        }

        protected void lstCatalogCategories_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //GridView gvSubCategories = default(GridView);
            //gvSubCategories = (GridView)e.Item.FindControl("gvSubCategories");

            // LinkButton lnkCategoryName = (LinkButton)e.Item.FindControl("lnkCategoryName");

            if (e.CommandName.Equals("MainCategory"))
            {

                Response.Redirect("~/Manager/Catalog/bcdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()));


            }

        }
        protected void gvSubCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SubCategory"))
            {

                GridView GridView1 = (GridView)sender;
                string subCategoryId = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values["s_category_system_id_pk"].ToString();
                string parentCategoryId = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values["s_parent_category_id"].ToString();

                Response.Redirect("~/Manager/Catalog/bcdp-01.aspx?id=" + SecurityCenter.EncryptText(subCategoryId) + "&pid=" + SecurityCenter.EncryptText(parentCategoryId));

            }
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/bcdp-01.aspx?adv=" + SecurityCenter.EncryptText("true") + "&cid=" + SecurityCenter.EncryptText(txtId.Text) + "&title=" + SecurityCenter.EncryptText(txtTitle.Text) + "&keyword=" + SecurityCenter.EncryptText(txtKeyword.Text) + "&type=" + SecurityCenter.EncryptText(ddlType.SelectedValue) + "&deliverytype=" + SecurityCenter.EncryptText(ddlDelivery.SelectedValue) + "&language=" + SecurityCenter.EncryptText(ddlLanguage.SelectedValue) + "&typeval=" + SecurityCenter.EncryptText(ddlType.SelectedValue), false);

        }
    }
}