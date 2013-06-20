using System;
using System.Web;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class saad_01 : System.Web.UI.Page
    {
        string strdocumentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>" + "&nbsp;>&nbsp;" + "<a href=/SystemHome/Catalog/Documents/samdimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_documents_text") + "</a>" + "&nbsp;>&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_view_version_information_text") + "</a>";
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    strdocumentId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    PopulateVersionInfo();
                }
            }
        }
        private void PopulateVersionInfo()
        {
            SystemDocuments document = new SystemDocuments();
            DataSet dsDocument = SystemDocumentsBLL.GetDocument(strdocumentId);
            try
            {
                document = SystemDocumentsBLL.GetSingleDocument(strdocumentId, dsDocument.Tables[0]);
                lblDocumentId.Text = document.s_document_id_pk;
                lblDocumentName.Text = document.s_document_name;
                lblDocumentDesc.Text = document.s_document_description;
                lblVersionNo.Text = document.s_document_version;
                if (!string.IsNullOrEmpty(document.s_document_status_id_fk))
                {
                    if (document.s_document_status_id_fk == "app_ddl_active_text")
                    {
                        lblStatus.Text = "Active";
                    }
                    else if (document.s_document_status_id_fk == "app_ddl_inactive_text")
                    {
                        lblStatus.Text="InActive";
                    }
                    else{}
                }
                if (!string.IsNullOrEmpty(Request.QueryString["type"]))
                {
                    lblDocumentType.Text = SecurityCenter.DecryptText( Request.QueryString["type"]).ToString();
                }
                lblDocumentFileName.Text = document.s_document_attachment_file_name.ToString();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saad-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saad-01.aspx", ex.Message);
                    }
                }
            }
        }
    }
}