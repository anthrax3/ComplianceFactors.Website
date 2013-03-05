using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;

namespace ComplicanceFactor.SystemHome.Catalog.DomainPopup
{
    public partial class sasrdn_01 : BasePage
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
                        Logger.WriteToErrorLog("sasrdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasrdn-01.aspx", ex.Message);
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



        protected void btnFooterGoto_Click1(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
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
        protected void dlstDomainSelected_ItemCommand(object source, DataListCommandEventArgs e)
        {
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
        private void SearchResult()
        {
            try
            {
                SystemDomain domain = new SystemDomain();

                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    domain.u_domain_id_pk = txtDomainId.Text;
                    domain.u_domain_name = txtDomainName.Text;
                    domain.u_domain_theme_id_fk = "0";
                    domain.u_domain_status_id_fk = "0";
                    domain.u_domain_owner_text = "";
                    domain.u_domain_coordinator_text = "";

                }
                else
                {
                    domain.u_domain_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    domain.u_domain_name = SecurityCenter.DecryptText(Request.QueryString["name"]);
                    domain.u_domain_theme_id_fk = "0";
                    domain.u_domain_status_id_fk = "0";
                    domain.u_domain_owner_text = "";
                    domain.u_domain_coordinator_text = "";


                }

                gvsearchDetails.DataSource = SystemDomainBLL.SearchDomains(domain);
                gvsearchDetails.DataBind();

                //gvsearchDetails is empty then visible false for save selected button
                if (gvsearchDetails.Rows.Count == 0)
                {
                    btnSaveSelected.Visible = false;
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
                        Logger.WriteToErrorLog("sasrdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasrdn-01.aspx", ex.Message);
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

        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
            {
                DomainAddEditMode(SessionWrapper.CourseDomain, string.Empty);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
            {

                string editCourseId = Request.QueryString["editCourseId"];
                DataTable dtDomain = new DataTable();
                dtDomain = dtTempDomain();
                dtDomain = DomainAddEditMode(dtDomain, editCourseId);
                try
                {
                    SystemCatalogBLL.InsertDomain(ConvertDataTableToXml(dtDomain), editCourseId);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sasrdn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sasrdn-01", ex.Message);
                        }
                    }
                }

            }
            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        private DataTable DomainAddEditMode(DataTable dtDomain, string c_course_system_id_pk)
        {
            foreach (GridViewRow grdDomainRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdDomainRow.Cells[1].FindControl("chkSelect"));

                if (chkSelect.Checked == true)
                {
                    AddDataToDomain(gvsearchDetails.DataKeys[grdDomainRow.RowIndex].Values[0].ToString(), grdDomainRow.Cells[1].Text, grdDomainRow.Cells[0].Text, c_course_system_id_pk, dtDomain);

                }
            }

            //Remove duplicate Domain
            dtDomain = RemoveDuplicateRows(dtDomain, "c_related_domain_id_fk");
            return dtDomain;

        }
        private void AddDataToDomain(string c_related_domain_id_fk, string u_domain_id_pk, string u_domain_name, string c_course_id_fk, DataTable dtTempDomain)
        {
            // Add Domain functiong

            DataRow row;
            row = dtTempDomain.NewRow();
            row["c_related_domain_id_fk"] = c_related_domain_id_fk;
            row["u_domain_id_pk"] = u_domain_id_pk;
            row["u_domain_name"] = u_domain_name;
            //row["u_domain_desc"] = u_domain_desc;
            if (!string.IsNullOrEmpty(c_course_id_fk))
            {
                row["c_course_id_fk"] = c_course_id_fk;

            }
            else
            {
                row["c_course_id_fk"] = DBNull.Value;
            }
            dtTempDomain.Rows.Add(row);
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
        /// Add temp columns for Domain
        /// </summary>
        /// <returns></returns>
        private DataTable dtTempDomain()
        {
            DataTable dtTempDomain = new DataTable();
            DataColumn dtTempDomainColumn;

            /// <summary>
            /// temp u_domain_system_id_pk 


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_related_domain_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            /// u_domain_id_pk


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_id_pk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            /// u_domain_name


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_name";
            dtTempDomain.Columns.Add(dtTempDomainColumn);



            //c_course_id_pk
            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_course_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            /// u_domain_desc

            //dtTempDomainColumn = new DataColumn();
            //dtTempDomainColumn.DataType = Type.GetType("System.String");
            //dtTempDomainColumn.ColumnName = "u_domain_desc";
            //dtTempDomain.Columns.Add(dtTempDomainColumn);








            return dtTempDomain;

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