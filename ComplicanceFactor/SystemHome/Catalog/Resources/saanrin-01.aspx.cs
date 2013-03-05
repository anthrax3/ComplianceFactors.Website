using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Resources
{
    public partial class saanrin_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" +LocalResources.GetGlobalLabel("app_nav_system")+ "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Resources/samrimp-01.aspx>" + LocalResources.GetLabel("app_manage_resource_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_resource_text");
                //temp locale column
                SessionWrapper.Locale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                //bind status
                ddlStatus.DataSource = SystemResourceBLL.GetStatus(SessionWrapper.CultureName, "saanrin-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";
                //bind resource type
                ddlResourceType.DataSource = SystemResourceBLL.GetResourceType(SessionWrapper.CultureName);
                ddlResourceType.DataBind();
                ListItem itemRemove = ddlResourceType.Items.FindByValue("app_ddl_all_text");
                ddlResourceType.Items.Remove(itemRemove);
                //copy
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    PopulateResource(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                }



            }
        }
        protected void btnFooterSaveNewResource_Click(object sender, EventArgs e)
        {
            SaveResource();
        }

        protected void btnHeaderSaveNewResource_Click(object sender, EventArgs e)
        {
            SaveResource();
        }
        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
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
        /// Create Resource
        /// </summary>
        /// <param name="createResource"></param>
        private void SaveResource()
        {
            SystemResource createResource = new SystemResource();
            createResource.c_resource_system_id_pk = Guid.NewGuid().ToString();
            createResource.c_resource_id_pk = txtResourceId.Text;
            createResource.c_resource_name = txtResourceName.Text;
            createResource.c_resource_description = txtResourceDescription.InnerText;
            createResource.c_resource_serial_number = txtSerialNumber.Text;
            createResource.c_resource_status_id = ddlStatus.SelectedValue;
            createResource.c_resource_type_id_fk = ddlResourceType.SelectedValue;
            createResource.s_resource_locale = ConvertDataTableToXml(SessionWrapper.Locale);
            try
            {
                int result = SystemResourceBLL.CreateNewResource(createResource);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Resources/saerin-01.aspx?edit=" + SecurityCenter.EncryptText(createResource.c_resource_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("saanrin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanrin-01", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Copy the Resource , Populate values
        /// </summary>
        /// <param name="resourceId"></param>
        private void PopulateResource(string resourceId)
        {
            SystemResource resource = new SystemResource();
            try
            {
                DataSet dsResouce = SystemResourceBLL.GetResource(resourceId);
                resource = SystemResourceBLL.GetSingleResource(resourceId,dsResouce.Tables[0]);
                txtResourceId.Text = resource.c_resource_id_pk + "_copy";
                txtResourceName.Text = resource.c_resource_name;
                txtResourceDescription.InnerText = resource.c_resource_description;
                txtSerialNumber.Text = resource.c_resource_serial_number;
                ddlStatus.SelectedValue = resource.c_resource_status_id;
                ddlResourceType.SelectedValue = resource.c_resource_type_id_fk;
                SessionWrapper.Locale = dsResouce.Tables[1];
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanrin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanrin-01", ex.Message);
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
    }
}