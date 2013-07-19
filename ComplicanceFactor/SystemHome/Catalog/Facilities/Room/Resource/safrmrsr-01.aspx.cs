using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog.Facilities.Room.Resource
{
    public partial class safrmrsr_01 : BasePage
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
            Response.Redirect("~/SystemHome/Catalog/saantc-01.aspx");
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
                txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("safrmrsr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("safrmrsr-01.aspx", ex.Message);
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
        /// disable and disable search result section
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
            btnSaveSelected.Visible = status;

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
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {

                ResourceAddEditMode(SessionWrapper.Temp_Facility_Room_Resource, SessionWrapper.s_room_system_id_pk);

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && string.IsNullOrEmpty(Request.QueryString["editRoomId"]))
            {
                DataView dvResources = new DataView(SessionWrapper.Facility_Room_Resource);
                dvResources.RowFilter = "s_facility_room_id_fk= '" + SessionWrapper.s_room_system_id_pk + "'";
                DataTable dtResoruces = new DataTable();
                dtResoruces = ResourceAddEditMode(dvResources.ToTable(), SessionWrapper.s_room_system_id_pk);
                var resRows = SessionWrapper.Facility_Room_Resource.Select("s_facility_room_id_fk= '" + SessionWrapper.s_room_system_id_pk + "'");
                foreach (var row in resRows)
                    row.Delete();
                SessionWrapper.Facility_Room_Resource.Merge(dtResoruces);

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["editRoomId"]))
            {
                string editRoom = Request.QueryString["editRoomId"];
                DataTable dtResources = new DataTable();
                dtResources = TempDataTables.TempResource();
                dtResources = ResourceAddEditMode(dtResources, editRoom);
                try
                {
                    SystemFacilityBLL.InsertRoomAndResource(string.Empty, string.Empty, ConvertDataTableToXml(dtResources));
                    //SystemCatalogBLL.InsertDeliveryResources(ConvertDataTableToXml(dtResources));
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("safrmrsr-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("safrmrsr-01", ex.Message);
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
        private DataTable ResourceAddEditMode(DataTable dtResources, string s_facility_room_resource_id_pk)
        {
            foreach (GridViewRow grdResourceRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdResourceRow.Cells[1].FindControl("chkSelect"));
                HiddenField hdnDescription = (HiddenField)(grdResourceRow.Cells[1].FindControl("hdnDescription"));
                HiddenField hdSerialNumber = (HiddenField)(grdResourceRow.Cells[1].FindControl("hdSerialNumber"));
                if (chkSelect.Checked == true)
                {

                    AddDataToDeliveryResource(gvsearchDetails.DataKeys[grdResourceRow.RowIndex].Values[0].ToString(), grdResourceRow.Cells[1].Text, grdResourceRow.Cells[0].Text, hdnDescription.Value, hdSerialNumber.Value, s_facility_room_resource_id_pk, dtResources);

                }
            }
            //Remove duplicate resource
            dtResources = RemoveDuplicateRows(dtResources, "s_resource_system_id_pk");
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
        private void AddDataToDeliveryResource(string s_resource_system_id_pk, string s_resource_id_pk, string s_resource_name, string s_resource_description, string s_resource_serial_number, string s_facility_room_id_fk, DataTable dtTempDeliveryresource)
        {
            // Add resource function
            DataRow row;
            row = dtTempDeliveryresource.NewRow();
            row["s_resource_system_id_pk"] = s_resource_system_id_pk;
            row["s_resource_id_pk"] = s_resource_id_pk;
            row["s_resource_name"] = s_resource_name;
            row["s_resource_description"] = s_resource_description;
            row["s_resource_serial_number"] = s_resource_serial_number;
            row["s_facility_room_id_fk"] = s_facility_room_id_fk;
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
       
      

    }
}