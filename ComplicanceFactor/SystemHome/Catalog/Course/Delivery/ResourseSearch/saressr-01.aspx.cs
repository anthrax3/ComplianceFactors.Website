using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saressr_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Search result
                SearchResult();


            }
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //search

            ViewState["SearchResult"] = "true";
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }
        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }
        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }
        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }
        protected void btnAddNewCourse_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SystemHome/Catalog/Course/saantc-01.aspx");

        }
        /// <summary>
        /// search result
        /// </summary>
        private void SearchResult()
        {
            try
            {

                SystemCatalog catalog = new SystemCatalog();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    catalog.c_resource_id_pk = txtResourceId.Text;
                    catalog.c_resource_name = txtResourceName.Text;

                }
                else
                {
                    catalog.c_resource_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    catalog.c_resource_name = SecurityCenter.DecryptText(Request.QueryString["name"]);


                }

                gvsearchDetails.DataSource = SystemCatalogBLL.ResourceSearch(catalog);
                gvsearchDetails.DataBind();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saressr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saressr-01.aspx", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
            }
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }


        }

        /// <summary>
        /// disable enable search result section
        /// </summary>
        private void disable_enable(bool status)
        {
            btnHeaderFirst.Visible = status;
            btnHeaderPrevious.Visible = status;
            btnHeaderNext.Visible = status;
            btnHeaderLast.Visible = status;

            btnFooterFirst.Visible = status;
            btnFooterPrevious.Visible = status;
            btnFooterNext.Visible = status;
            btnFooterLast.Visible = status;

            ddlHeaderResultPerPage.Visible = status;
            ddlFooterResultPerPage.Visible = status;

            txtHeaderPage.Visible = status;
            lblHeaderPage.Visible = status;

            txtFooterPage.Visible = status;
            lblFooterPage.Visible = status;

            btnHeaderGoto.Visible = status;
            btnFooterGoto.Visible = status;


            lblHeaderResultPerPage.Visible = status;
            lblFooterResultPerPage.Visible = status;

            lblFooterPageOf.Visible = status;
            lblHeaderPageOf.Visible = status;

        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }
        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        /// <summary>
        /// Save selected resource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand")
            {

                ResourceAddEditMode(SessionWrapper.TempDeliveryResource, SessionWrapper.c_delivery_system_id_pk);

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                DataView dvResources = new DataView(SessionWrapper.DeliveryResource);
                dvResources.RowFilter = "c_delivery_id_fk= '" + SessionWrapper.c_delivery_system_id_pk + "'";
                DataTable dtResoruces = new DataTable();
                dtResoruces = ResourceAddEditMode(dvResources.ToTable(), SessionWrapper.c_delivery_system_id_pk);


                var resRows = SessionWrapper.DeliveryResource.Select("c_delivery_id_fk= '" + SessionWrapper.c_delivery_system_id_pk + "'");
                foreach (var row in resRows)
                    row.Delete();
                SessionWrapper.DeliveryResource.Merge(dtResoruces);

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02" && !string.IsNullOrEmpty(Request.QueryString["editdelivery"]))
            {
                string editDelivery = Request.QueryString["editdelivery"];
                DataTable dtResources = new DataTable();
                dtResources = TempDeliveryResource();
                dtResources = ResourceAddEditMode(dtResources, editDelivery);
                try
                {
                    SystemCatalogBLL.InsertDeliveryResources(ConvertDataTableToXml(dtResources));
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saressr-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saressr-01", ex.Message);
                        }
                    }
                }

            }

            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

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
        /// <summary>
        /// Add and edit resoruces
        /// </summary>
        /// <param name="dtResources"></param>
        private DataTable ResourceAddEditMode(DataTable dtResources, string c_delivery_system_id_pk)
        {
            foreach (GridViewRow grdResourceRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdResourceRow.Cells[1].FindControl("chkSelect"));
                HiddenField hdnDescription = (HiddenField)(grdResourceRow.Cells[1].FindControl("hdnDescription"));
                HiddenField hdSerialNumber = (HiddenField)(grdResourceRow.Cells[1].FindControl("hdSerialNumber"));
                if (chkSelect.Checked == true)
                {

                    AddDataToDeliveryResource(gvsearchDetails.DataKeys[grdResourceRow.RowIndex].Values[0].ToString(), grdResourceRow.Cells[1].Text, grdResourceRow.Cells[0].Text, hdnDescription.Value, hdSerialNumber.Value, c_delivery_system_id_pk, dtResources);

                }
            }

            //Remove duplicate resource
            dtResources = RemoveDuplicateRows(dtResources, "c_resource_system_id_pk");
            return dtResources;

        }
        /// <summary>
        /// AddDataToDeliveryResource
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        /// <param name="c_resource_id_pk"></param>
        /// <param name="c_resource_name"></param>
        /// <param name="c_resource_description"></param>
        /// <param name="c_resource_serial_number"></param>
        /// <param name="c_delivery_id_fk"></param>
        /// <param name="dtTempDeliveryresource"></param>
        private void AddDataToDeliveryResource(string c_resource_system_id_pk, string c_resource_id_pk, string c_resource_name, string c_resource_description, string c_resource_serial_number, string c_delivery_id_fk, DataTable dtTempDeliveryresource)
        {
            // Add resource function
            DataRow row;
            row = dtTempDeliveryresource.NewRow();
            row["c_resource_system_id_pk"] = c_resource_system_id_pk;
            row["c_resource_id_pk"] = c_resource_id_pk;
            row["c_resource_name"] = c_resource_name;
            row["c_resource_description"] = c_resource_description;
            row["c_resource_serial_number"] = c_resource_serial_number;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            dtTempDeliveryresource.Rows.Add(row);
        }
        /// <summary>
        /// Remove duplicate rows
        /// </summary>
        /// <param name="dTable"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
        /// <summary>
        /// Temp table structure for delivery resources
        /// </summary>
        /// <returns></returns>
        private DataTable TempDeliveryResource()
        {
            DataTable dtTempDeliveryResource = new DataTable();
            DataColumn dtTempDeliveryResourceColumn;

            /// <summary>
            /// c_resource_system_id_pk

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_system_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);




            /// <summary>
            /// c_resource_id_pk

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_name

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_name";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_description

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_description";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_serial_number

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_serial_number";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);


            //c_delivery_id_fk
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            return dtTempDeliveryResource;

        }




    }
}