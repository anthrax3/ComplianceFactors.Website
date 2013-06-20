using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Resources
{
    public partial class saerin_01 : BasePage
    {
        string editResource;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //set edit Resource id
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    editResource = SecurityCenter.DecryptText(Request.QueryString["edit"]);
                }
                //get resource id using jquery
                hdResourceId.Value = editResource;
                if (!IsPostBack)
                {
                    // bind status
                    ddlStatus.DataSource = SystemResourceBLL.GetStatus(SessionWrapper.CultureName, "saerin-01");
                    ddlStatus.DataBind();
                    // bind Resource Type
                    ddlResourceType.DataSource = SystemResourceBLL.GetResourceType(SessionWrapper.CultureName);
                    ddlResourceType.DataBind();
                    ListItem itemRemove = ddlResourceType.Items.FindByValue("app_ddl_all_text");
                    ddlResourceType.Items.Remove(itemRemove);
                    //populate resource
                    PopulateResource(editResource);
                    //for reset to store resource locale in session
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = SystemResourceBLL.GetResourceLocale(editResource);
                    //breadcrumb
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Resources/samrimp-01.aspx>" + LocalResources.GetLabel("app_manage_resource_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_resource_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Resources/samrimp-01.aspx>" + LocalResources.GetLabel("app_manage_resource_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_resource_text") + "</a>";


                    //success message after insert
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text"); 
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveNewResource_Click(object sender, EventArgs e)
        {
            UpdateResource();
        }

        protected void btnFooterSaveNewResource_Click(object sender, EventArgs e)
        {
            UpdateResource();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
            
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
           
        }
        /// <summary>
        /// reset resource
        /// </summary>
        private void Reset()
        {
            try
            {
                SystemResourceBLL.DeleteResourceLocale(editResource, ConvertDataTableToXml(SessionWrapper.TempLocale),string.Empty);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerin-01.aspx", ex.Message);
                    }
                }
            }
        }
        ///<summary>
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Resources/samrimp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Resources/samrimp-01.aspx");
        }
        /// <summary>
        /// Populate Resource
        /// </summary>
        /// <param name="resourceId"></param>
        private void PopulateResource(string resourceId)
        {
            SystemResource resource = new SystemResource();
            DataSet dsResource = SystemResourceBLL.GetResource(resourceId);
            try
            {
                resource = SystemResourceBLL.GetSingleResource(resourceId,dsResource.Tables[0]);
                txtResourceId.Text = resource.c_resource_id_pk;
                txtResourceName.Text = resource.c_resource_name;
                txtResourceDescription.InnerText = resource.c_resource_description;
                txtSerialNumber.Text = resource.c_resource_serial_number;
                ddlStatus.SelectedValue = resource.c_resource_status_id;
                ddlResourceType.SelectedValue = resource.c_resource_type_id_fk;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Update Resource 
        /// </summary>
        private void UpdateResource()
        {
            SystemResource updateResource = new SystemResource();
            updateResource.c_resource_system_id_pk = editResource;
            updateResource.c_resource_id_pk = txtResourceId.Text;
            updateResource.c_resource_name = txtResourceName.Text;
            updateResource.c_resource_description = txtResourceDescription.InnerText;
            updateResource.c_resource_serial_number = txtSerialNumber.Text;
            updateResource.c_resource_status_id = ddlStatus.SelectedValue;
            updateResource.c_resource_type_id_fk = ddlResourceType.SelectedValue;

            try
            {
                int result = SystemResourceBLL.UpdateResource(updateResource);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text"); ;
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerin-01", ex.Message);
                    }
                }
            }
        }
    }
}