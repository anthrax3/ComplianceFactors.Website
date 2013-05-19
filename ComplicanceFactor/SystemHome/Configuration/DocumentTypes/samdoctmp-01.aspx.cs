using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.DocumentTypes
{
    public partial class samdoctmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>" + "&nbsp;>&nbsp" + LocalResources.GetGlobalLabel("app_manage_document_types");
                SearchResults();
                lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
                lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();

                //Bind Status
                ddlStatus.DataSource = SystemDocumentTypesBLL.GetAllStatus(SessionWrapper.CultureName, "samdoctmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DocumentTypes/saandoctn-01.aspx");
        }
        private void SearchResults()
        {
            try
            {
                SystemDocumentTypes searchDocumentTypes = new SystemDocumentTypes();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {

                    searchDocumentTypes.s_document_type_id = txtDocumentTypeId.Text;
                    searchDocumentTypes.s_document_type_name_us_english = txtName.Text;
                    if (ddlStatus.SelectedValue == "app_ddl_all_text")
                    {
                        searchDocumentTypes.s_document_type_status_id_fk = "0";
                    }
                    else
                    {
                        searchDocumentTypes.s_document_type_status_id_fk = ddlStatus.SelectedValue;
                    }
                }
                else
                {
                    searchDocumentTypes.s_document_type_id = txtDocumentTypeId.Text;
                    searchDocumentTypes.s_document_type_name_us_english = txtName.Text;
                    searchDocumentTypes.s_document_type_status_id_fk = "0";
                }
                gvDocumentSearchResults.DataSource = SystemDocumentTypesBLL.GetSearchDocumentTypes(searchDocumentTypes);
                gvDocumentSearchResults.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samdoctmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samdoctmp-01.aspx", ex.Message);
                    }
                }
            }
            if (gvDocumentSearchResults.Rows.Count == 0)
            {
                div_HeaderPaging.Visible = false;
                div_FooterPaging.Visible = false;
            }
            else
            {
                div_HeaderPaging.Visible = true;
                div_FooterPaging.Visible = true;
            }

        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            SearchResults();
        }

        protected void gvDocumentSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/SystemHome/Configuration/DocumentTypes/saedoctn-01.aspx?id=" + SecurityCenter.EncryptText(gvDocumentSearchResults.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName == "Copy")
            {
                Response.Redirect("~/SystemHome/Configuration/DocumentTypes/saandoctn-01.aspx?copy=" + SecurityCenter.EncryptText(gvDocumentSearchResults.DataKeys[rowIndex].Values[0].ToString()), false);
            }

            else if (e.CommandName == "Archive")
            {
                string documentTypeId = gvDocumentSearchResults.DataKeys[rowIndex][0].ToString();
                try
                {
                    //    SystemDocumentTypes documentType = new SystemDocumentTypes();
                    //    documentType.s_document_type_system_id_pk = documentTypeId;
                    int result = SystemDocumentTypesBLL.UpdateDocumentTypeStatus(documentTypeId);
                    SearchResults();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samdoctmp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samdoctmp-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void gvDocumentSearchResults_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvDocumentSearchResults.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
            txtHeaderPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvDocumentSearchResults.PageCount;
            if (gvDocumentSearchResults.PageIndex > 0)
                gvDocumentSearchResults.PageIndex = gvDocumentSearchResults.PageIndex - 1;

            SearchResults();
            txtFooterPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
            txtHeaderPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvDocumentSearchResults.PageIndex + 1;
            if (i <= gvDocumentSearchResults.PageCount)
                gvDocumentSearchResults.PageIndex = i;


            SearchResults();
            txtFooterPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
            txtHeaderPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvDocumentSearchResults.PageIndex = gvDocumentSearchResults.PageCount;

            SearchResults();
            txtFooterPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
            txtHeaderPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvDocumentSearchResults.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResults();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvDocumentSearchResults.PageSize = Convert.ToInt32(gvDocumentSearchResults.PageCount * gvDocumentSearchResults.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvDocumentSearchResults.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResults();

            txtFooterPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
            txtHeaderPage.Text = (gvDocumentSearchResults.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvDocumentSearchResults.PageCount).ToString();
        }
    }
}