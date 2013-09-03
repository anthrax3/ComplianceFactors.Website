using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog.Course.AudienceSearch
{
    public partial class sasran_01 : System.Web.UI.Page
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
                        Logger.WriteToErrorLog("(course) sasran-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(course) sasran-01.aspx", ex.Message);
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
                SystemAudiences audience = new SystemAudiences();

                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    audience.u_audience_id_pk = txtAudienceId.Text;
                    audience.u_audience_name = txtAudienceName.Text;
                    audience.u_audience_status_id_fk = "0";
                }
                else
                {
                    audience.u_audience_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    audience.u_audience_name = SecurityCenter.DecryptText(Request.QueryString["name"]);
                    audience.u_audience_status_id_fk = "0";
                }
                gvsearchDetails.DataSource = SystemAudiencesBLL.GetSearchAudience(audience);
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
                        Logger.WriteToErrorLog("(course) sasran-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(course) sasran-01.aspx", ex.Message);
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
        /// Disable/Enable Buttons
        /// </summary>
        /// <param name="status"></param>
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

        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
            {
                AudienceAddEditMode(SessionWrapper.CourseAudience, string.Empty);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
            {

                string editCourseId = Request.QueryString["editCourseId"];
                DataTable dtAudience = new DataTable();
                dtAudience = dtTempAudience();
                dtAudience = AudienceAddEditMode(dtAudience, editCourseId);
                try
                {
                    SystemCatalogBLL.InsertAudience(ConvertDataTableToXml(dtAudience), editCourseId);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("(course) sasran-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("(course) sasran-01", ex.Message);
                        }
                    }
                }

            }
            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        private DataTable AudienceAddEditMode(DataTable dtAudience, string c_course_system_id_pk)
        {
            foreach (GridViewRow grdAudienceRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdAudienceRow.Cells[1].FindControl("chkSelect"));

                if (chkSelect.Checked == true)
                {
                    AddDataToAudience(gvsearchDetails.DataKeys[grdAudienceRow.RowIndex].Values[0].ToString(), grdAudienceRow.Cells[1].Text, grdAudienceRow.Cells[0].Text, c_course_system_id_pk, dtAudience);
                }
            }

            //Remove duplicate Audience
            dtAudience = RemoveDuplicateRows(dtAudience, "c_related_audience_id_fk");
            return dtAudience;

        }
        private void AddDataToAudience(string c_related_audience_id_fk, string u_audience_id_pk, string u_audience_name, string c_course_id_fk, DataTable dtTempAudience)
        {
            // Add Audience function
            DataRow row;
            row = dtTempAudience.NewRow();
            row["c_related_audience_id_fk"] = c_related_audience_id_fk;
            row["u_audience_id_pk"] = u_audience_id_pk;
            row["u_audience_name"] = u_audience_name;
            if (!string.IsNullOrEmpty(c_course_id_fk))
            {
                row["c_course_id_fk"] = c_course_id_fk;

            }
            else
            {
                row["c_course_id_fk"] = DBNull.Value;
            }
            dtTempAudience.Rows.Add(row);
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
        /// Add temp columns for Audience
        /// </summary>
        /// <returns></returns>
        private DataTable dtTempAudience()
        {
            DataTable dtTempAudience = new DataTable();
            DataColumn dtTempAudienceColumn;
            /// <summary>
            /// temp u_audience_system_id_pk 
            dtTempAudienceColumn = new DataColumn();
            dtTempAudienceColumn.DataType = Type.GetType("System.String");
            dtTempAudienceColumn.ColumnName = "c_related_audience_id_fk";
            dtTempAudience.Columns.Add(dtTempAudienceColumn);
            /// <summary>
            /// u_audience_id_pk
            dtTempAudienceColumn = new DataColumn();
            dtTempAudienceColumn.DataType = Type.GetType("System.String");
            dtTempAudienceColumn.ColumnName = "u_audience_id_pk";
            dtTempAudience.Columns.Add(dtTempAudienceColumn);
            /// <summary>
            /// u_audience_name
            dtTempAudienceColumn = new DataColumn();
            dtTempAudienceColumn.DataType = Type.GetType("System.String");
            dtTempAudienceColumn.ColumnName = "u_audience_name";
            dtTempAudience.Columns.Add(dtTempAudienceColumn);
            //c_course_id_pk
            dtTempAudienceColumn = new DataColumn();
            dtTempAudienceColumn.DataType = Type.GetType("System.String");
            dtTempAudienceColumn.ColumnName = "c_course_id_fk";
            dtTempAudience.Columns.Add(dtTempAudienceColumn);
            /// <summary>
            /// u_audience_desc
            //dtTempAudienceColumn = new DataColumn();
            //dtTempAudienceColumn.DataType = Type.GetType("System.String");
            //dtTempAudienceColumn.ColumnName = "u_audience_desc";
            //dtTempAudience.Columns.Add(dtTempAudienceColumn);
            return dtTempAudience;

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