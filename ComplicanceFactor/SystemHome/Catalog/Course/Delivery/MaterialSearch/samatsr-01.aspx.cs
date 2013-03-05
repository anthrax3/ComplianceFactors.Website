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
using System.Collections;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class samatsr_01 : BasePage
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

        private void SearchResult()
        {
            try
            {

                SystemCatalog catalog = new SystemCatalog();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    catalog.c_material_id_pk = txtMaterialId.Text;
                    catalog.c_material_name = txtMaterialName.Text;

                }
                else
                {
                    catalog.c_material_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    catalog.c_material_name = SecurityCenter.DecryptText(Request.QueryString["name"]);


                }

                gvsearchDetails.DataSource = SystemCatalogBLL.MaterialSearch(catalog);
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
                        Logger.WriteToErrorLog("samatsr-01-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samatsr-01-01.aspx", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
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

        private void disable()
        {
            btnHeaderFirst.Visible = false;
            btnHeaderPrevious.Visible = false;
            btnHeaderNext.Visible = false;
            btnHeaderLast.Visible = false;

            btnFooterFirst.Visible = false;
            btnFooterPrevious.Visible = false;
            btnFooterNext.Visible = false;
            btnFooterLast.Visible = false;

            ddlHeaderResultPerPage.Visible = false;
            ddlFooterResultPerPage.Visible = false;

            txtHeaderPage.Visible = false;
            lblHeaderPage.Visible = false;

            txtFooterPage.Visible = false;
            lblFooterPage.Visible = false;

            btnHeaderGoto.Visible = false;
            btnFooterGoto.Visible = false;


            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;

            lblFooterPageOf.Visible = false;
            lblHeaderPageOf.Visible = false;

        }


        private void enable()
        {
            btnHeaderFirst.Visible = true;
            btnHeaderPrevious.Visible = true;
            btnHeaderNext.Visible = true;
            btnHeaderLast.Visible = true;

            btnFooterFirst.Visible = true;
            btnFooterPrevious.Visible = true;
            btnFooterNext.Visible = true;
            btnFooterLast.Visible = true;

            ddlHeaderResultPerPage.Visible = true;
            ddlFooterResultPerPage.Visible = true;

            txtHeaderPage.Visible = true;
            lblHeaderPage.Visible = true;

            txtFooterPage.Visible = true;
            lblFooterPage.Visible = true;

            btnHeaderGoto.Visible = true;
            btnFooterGoto.Visible = true;


            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;

            lblFooterPageOf.Visible = true;
            lblHeaderPageOf.Visible = true;

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
        /// Save selected Material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand")
            {
                MaterialAddEditMode(SessionWrapper.TempDeliveryMaterial, SessionWrapper.c_delivery_system_id_pk);
               
            }
            else if ( !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                DataView dvMaterials = new DataView(SessionWrapper.DeliveryMaterial);
                dvMaterials.RowFilter = "c_delivery_id_fk= '" + SessionWrapper.c_delivery_system_id_pk + "'";
                DataTable dtMaterials = new DataTable();
                dtMaterials = MaterialAddEditMode(dvMaterials.ToTable(), SessionWrapper.c_delivery_system_id_pk);
                var resRows = SessionWrapper.DeliveryMaterial.Select("c_delivery_id_fk= '" + SessionWrapper.c_delivery_system_id_pk + "'");
                foreach (var row in resRows)
                    row.Delete();
                SessionWrapper.DeliveryMaterial.Merge(dtMaterials);
               // MaterialAddEditMode(SessionWrapper.DeliveryMaterial, SessionWrapper.c_delivery_system_id_pk);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02" && !string.IsNullOrEmpty(Request.QueryString["editdelivery"]))
            {
                string editDelivery = Request.QueryString["editdelivery"];
                DataTable dtMaterial = new DataTable();
                dtMaterial = TempDeliveryMaterials();
                dtMaterial = MaterialAddEditMode(dtMaterial, editDelivery);
                try
                {
                    SystemCatalogBLL.InsertDeliveryMaterial(ConvertDataTableToXml(dtMaterial));
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samatsr-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samatsr-01", ex.Message);
                        }
                    }
                }

            }

            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
        /// <summary>
        /// Material add and edit
        /// </summary>
        /// <param name="dtMaterials"></param>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <returns></returns>
        private DataTable  MaterialAddEditMode(DataTable dtMaterials, string c_delivery_system_id_pk)
        {
            foreach (GridViewRow grdMaterialRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdMaterialRow.Cells[1].FindControl("chkSelect"));
                HiddenField hdnDescription = (HiddenField)(grdMaterialRow.Cells[1].FindControl("hdnDescription"));

                if (chkSelect.Checked == true)
                {

                    AddDataToDeliveryMaterial(gvsearchDetails.DataKeys[grdMaterialRow.RowIndex].Values[0].ToString(), grdMaterialRow.Cells[1].Text, grdMaterialRow.Cells[0].Text, hdnDescription.Value, c_delivery_system_id_pk, dtMaterials);

                }
            }

            //Remove duplicate Material
            dtMaterials = RemoveDuplicateRows(dtMaterials, "c_material_system_id_pk");
            return dtMaterials;
        }
        /// <summary>
        /// Add data to delivery material datatable
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        /// <param name="c_material_id_pk"></param>
        /// <param name="c_material_name"></param>
        /// <param name="c_material_description"></param>
        /// <param name="c_delivery_id_fk"></param>
        /// <param name="dtTempDeliveryMaterial"></param>
        private void AddDataToDeliveryMaterial(string c_material_system_id_pk, string c_material_id_pk, string c_material_name, string c_material_description,string c_delivery_id_fk,  DataTable dtTempDeliveryMaterial)
        {
            // Add Material functiong
            DataRow row;
            row = dtTempDeliveryMaterial.NewRow();
            row["c_material_system_id_pk"] = c_material_system_id_pk;
            row["c_material_id_pk"] = c_material_id_pk;
            row["c_material_name"] = c_material_name;
            row["c_material_description"] = c_material_description;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            
            dtTempDeliveryMaterial.Rows.Add(row);
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
        /// Add temp columns for materials
        /// </summary>
        /// <returns></returns>
        private DataTable TempDeliveryMaterials()
        {
            DataTable dtTempDeliveryMaterials = new DataTable();
            DataColumn dtTempDeliveryMaterialsColumn;

            /// <summary>
            /// temp c_material_system_id_pk 


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_system_id_pk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_id_pk


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_id_pk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_nam


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_name";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_description

            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_description";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);


            //c_delivery_id_fk
            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);



            return dtTempDeliveryMaterials;

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