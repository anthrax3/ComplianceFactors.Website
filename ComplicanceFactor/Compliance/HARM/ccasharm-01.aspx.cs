using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Globalization;
using System.Threading;
namespace ComplicanceFactor.Compliance
{
    public partial class ccasharm_01 : BasePage
    {
        //CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_harm_text");
            //Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            if (!IsPostBack)
            {
                try
                {
                    ddlCategeory.DataSource = ComplianceBLL.GetHarmCategory(SessionWrapper.CultureName,"ccasharm-01");
                    ddlCategeory.DataBind();
                    ddlSearchCategory.DataSource = ComplianceBLL.GetHarmAllCategory(SessionWrapper.CultureName, "ccasharm-01");
                    ddlSearchCategory.DataBind();
                    //ListItem liAll = new ListItem();
                    //liAll.Text = "All";
                    //liAll.Value = "0";
                    //ddlSearchCategory.Items.Insert(0, liAll);
                    ddlSearchStatus.DataSource = ComplianceBLL.GetHarmAllStatus(SessionWrapper.CultureName, "ccasharm-01");
                    ddlSearchStatus.DataBind();
                    //ddlSearchStatus.Items.Insert(0, liAll);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccasharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccasharm-01", ex.Message);
                        }
                    }
                }
                searchResult();
                lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
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

        protected void btnFirstHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnPreviousHeader_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnNextHeader_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }

        protected void btnLastHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnGotoHeader_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtPage.Text) - 1;
            searchResult();
            txtdownpage.Text = txtPage.Text;
        }

        protected void btnFirstFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnPreviousFooter_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnNextFooter_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnLastFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnGotoFooter_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtdownpage.Text) - 1;
            searchResult();
            txtPage.Text = txtdownpage.Text;
        }
       
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlPerPage_header.SelectedIndex = 0;
            ddlPerPage_footer.SelectedIndex = 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO harm = new ComplianceDAO();
                DataTable dtHarmNumber = new DataTable();
                harm = ComplianceBLL.GetHarmNumber(ddlCategeory.SelectedValue);
                Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?category=" + SecurityCenter.EncryptText(ddlCategeory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(harm.h_harm_number) + "&title=" + SecurityCenter.EncryptText(txtTitle.Text), false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccasharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccasharm-01", ex.Message);
                    }
                }
            }
        }

        private void searchResult()
        {
            try
            {
                CultureInfo culture = new CultureInfo("en-US");
                DataTable dtSearchHarm = new DataTable();
                ComplianceDAO harm = new ComplianceDAO();

                harm.h_harm_number = txtSearchHarmNumber.Text;
                harm.h_case_title = txtSearchTitle.Text;
                DateTime? harmCaseDate = null;
                DateTime tempHarmCaseDate;

                if (DateTime.TryParseExact(txtSearchDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempHarmCaseDate))
                {
                    harmCaseDate = tempHarmCaseDate;

                }
                //if (DateTime.TryParse(txtSearchDate.Text, out tempHarmCaseDate))
                //{
                //    harmCaseDate = tempHarmCaseDate;
                //}
                harm.h_case_date = harmCaseDate;
                if (ddlSearchCategory.SelectedValue == "app_ddl_all_text")
                {
                    harm.h_case_category_fk = "0";
                }
                else
                {
                    harm.h_case_category_fk = ddlSearchCategory.SelectedValue;
                }
                if (ddlSearchStatus.SelectedValue == "app_ddl_all_text")
                {
                    harm.h_status = "0";
                }
                else
                {
                    harm.h_status = ddlSearchStatus.SelectedValue;
                }
                dtSearchHarm = ComplianceBLL.SearchHarm(harm);
                gvsearchDetails.DataSource = dtSearchHarm;
                gvsearchDetails.DataBind();
                if (dtSearchHarm.Rows.Count == 0)
                {
                    disable();
                }
                else
                {
                    enable();
                }
                if (dtSearchHarm.Rows.Count > 0)
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
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccasharm-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccasharm-01", ex.Message);
                    }
                }
            }
        }
        private void disable()
        {
            btnFirstHeader.Visible = false;
            btnPreviousHeader.Visible = false;
            btnNextHeader.Visible = false;
            btnLastHeader.Visible = false;
            btnFirstFooter.Visible = false;
            btnNextFooter.Visible = false;
            btnPreviousFooter.Visible = false;
            btnLastFooter.Visible = false;
            ddlPerPage_footer.Visible = false;
            ddlPerPage_header.Visible = false;
            txtPage.Visible = false;
            lblPage.Visible = false;
            txtdownpage.Visible = false;
            lbldownPage.Visible = false;
            btnGotoHeader.Visible = false;
            btnGotoFooter.Visible = false;
            lblHeaderPage.Visible = false;
            lblFooterPage.Visible = false;
            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;
        }

        private void enable()
        {
            btnFirstHeader.Visible = true;
            btnPreviousHeader.Visible = true;
            btnNextHeader.Visible = true;
            btnLastHeader.Visible = true;
            btnFirstFooter.Visible = true;
            btnNextFooter.Visible = true;
            btnPreviousFooter.Visible = true;
            btnLastFooter.Visible = true;
            ddlPerPage_footer.Visible = true;
            ddlPerPage_header.Visible = true;
            txtPage.Visible = true;
            lblPage.Visible = true;
            txtdownpage.Visible = true;
            lbldownPage.Visible = true;
            btnGotoFooter.Visible = true;
            btnGotoHeader.Visible = true;
            lblHeaderPage.Visible = true;
            lblFooterPage.Visible = true;
            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;
        }

        protected void ddlPerPage_header_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPerPage_header.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlPerPage_header.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            searchResult();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlPerPage_footer.SelectedValue = ddlPerPage_header.SelectedValue;
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void ddlPerPage_footer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPerPage_footer.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlPerPage_footer.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlPerPage_header.SelectedValue = ddlPerPage_footer.SelectedValue;
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;
            searchResult();
        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                Response.Redirect("~/Compliance/HARM/cceharm-01.aspx?Edit=" + SecurityCenter.EncryptText(harmId));
            }
            else if (e.CommandName == "Copy")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            }

            else if (e.CommandName == "Approve")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_harm_id_pk = harmId;
                   ComplianceBLL.UpdateHarmStatus(harm);
                    searchResult();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccasharm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccasharm-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewCaseDescription = (Button)e.Row.FindControl("btnView");
                string harmId = gvsearchDetails.DataKeys[e.Row.RowIndex][0].ToString();
                btnViewCaseDescription.OnClientClick = "window.open('ccvharm-01.aspx?View=" + SecurityCenter.EncryptText(harmId) + "','',''); return true;";
            }
        }
    }
}