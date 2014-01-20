using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Documents.CategorySearch
{
    public partial class sasrcn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SearchResult();
                    //count page of page in search result
                    lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
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
                        Logger.WriteToErrorLog("sasrcn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasrcn-01.aspx", ex.Message);
                    }
                }
            }
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

        protected void btnHeaderGoto_Click1(object sender, EventArgs e)
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

        protected void btnFooterGoto_Click1(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
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




        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saandin")
            {
                CategoryAddEditMode(SessionWrapper.DocumentCategory, string.Empty);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saedin")
            {                

            }
            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
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
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }
        /// <summary>
        /// Search categories
        /// </summary>
        private void SearchResult()
        {
            try
            {

                SystemCategories categories = new SystemCategories();

                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    categories.s_category_id = txtCategoryId.Text;
                    categories.s_category_name_us_english = txtCategoryName.Text;
                    categories.s_category_status_id_fk = null;
                    categories.s_parent_category_id = null;


                }
                else
                {
                    categories.s_category_id = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    categories.s_category_name_us_english = SecurityCenter.DecryptText(Request.QueryString["name"]);
                    categories.s_category_status_id_fk = "0";
                    categories.s_parent_category_id = "0";



                }

                gvsearchDetails.DataSource = SystemCategoriesBLL.SearchCategories(categories);
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
                        Logger.WriteToErrorLog("sasrcn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasrcn-01.aspx", ex.Message);
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


        private DataTable CategoryAddEditMode(DataTable dtCategory, string s_category_system_id_pk)
        {
            foreach (GridViewRow grdCategoryRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdCategoryRow.Cells[1].FindControl("chkSelect"));

                if (chkSelect.Checked == true)
                {
                    AddDataToCategory(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), grdCategoryRow.Cells[1].Text, grdCategoryRow.Cells[0].Text, s_category_system_id_pk, dtCategory);

                }
            }

            //Remove duplicate Category
            dtCategory = RemoveDuplicateRows(dtCategory, "CategoryID");
            return dtCategory;

        }

        private void AddDataToCategory(string CategoryID, string s_category_id, string s_category_name, string c_document_id_fk, DataTable dtTempCategory)
        {
            // Add Category functiong

            DataRow row;
            row = dtTempCategory.NewRow();
            row["CategoryID"] = CategoryID;
            row["s_category_id"] = s_category_id;
            row["s_category_name_us_english"] = s_category_name;
            //row["s_category_description"] = s_category_description;
            if (!string.IsNullOrEmpty(c_document_id_fk))
            {
                row["c_document_id_fk"] = c_document_id_fk;

            }
            else
            {
                row["c_document_id_fk"] = DBNull.Value;
            }
            dtTempCategory.Rows.Add(row);
        }
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
        /// Add temp columns for Category
        /// </summary>
        /// <returns></returns>
        private DataTable dtTempCategory()
        {
            DataTable dtTempCategory = new DataTable();
            DataColumn dtTempCategoryColumn;

            /// <summary>
            /// temp s_category_system_id_pk 


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "CategoryID";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_id


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_id";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_name


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_name_us_english";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);



            //c_course_id_pk
            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "c_document_id_fk";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_description

            //dtTempCategoryColumn = new DataColumn();
            //dtTempCategoryColumn.DataType = Type.GetType("System.String");
            //dtTempCategoryColumn.ColumnName = "s_category_description";
            //dtTempCategory.Columns.Add(dtTempCategoryColumn);


            return dtTempCategory;

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