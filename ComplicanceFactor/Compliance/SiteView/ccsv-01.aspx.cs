using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;

namespace ComplicanceFactor.Compliance.SiteView
{
    public partial class ccsv_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.navigationText = "app_nav_compliance";
            if (!IsPostBack)
            {
                
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_compliance_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" +" >&nbsp;"+ LocalResources.GetGlobalLabel("app_siteview_text");
                BindFieldNotes();
                lblHeaderPageOf.Text = "of " + (gvFieldNoteDetails.PageCount).ToString();
                BindInspection();
                lblInspectionHeaderPageof.Text = "of " + (gvInspectionDetails.PageCount).ToString();
                BindJobTraining();
                lblTrainingPageOf.Text = "of " + (gvJobTrainingDetails.PageCount).ToString();
                
            }
           
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvFieldNoteDetails.PageSize = Convert.ToInt32(gvFieldNoteDetails.PageCount * gvFieldNoteDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvFieldNoteDetails.PageSize = selectedValue;
            }
            BindFieldNotes();
        }
        private void BindFieldNotes()
        {
            try
            {
                gvFieldNoteDetails.DataSource = SiteViewFieldNotesBLL.SearchFieldNotes(SessionWrapper.u_userid);
                gvFieldNoteDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                    }
                }
            }
            if (gvFieldNoteDetails.Rows.Count == 0)
            {
                disableFieldNotes();
            }
            else
            {
                enableFieldNotes();
            }
            if (gvFieldNoteDetails.Rows.Count > 0)
            {
                gvFieldNoteDetails.UseAccessibleHeader = true;
                if (gvFieldNoteDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvFieldNoteDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }

        private void disableFieldNotes()
        {
            btnHeaderFirst.Visible = false;
            btnHeaderPrevious.Visible = false;
            btnHeaderNext.Visible = false;
            btnHeaderLast.Visible = false;

            ddlHeaderResultPerPage.Visible = false;

            txtHeaderPage.Visible = false;
            lblHeaderPage.Visible = false;

            btnHeaderGoto.Visible = false;

            lblHeaderResultPerPage.Visible = false;

            lblHeaderPageOf.Visible = false;

        }
        private void enableFieldNotes()
        {
            btnHeaderFirst.Visible = true;
            btnHeaderPrevious.Visible = true;
            btnHeaderNext.Visible = true;
            btnHeaderLast.Visible = true;

            ddlHeaderResultPerPage.Visible = true;

            txtHeaderPage.Visible = true;
            lblHeaderPage.Visible = true;

            btnHeaderGoto.Visible = true;

            lblHeaderResultPerPage.Visible = true;

            lblHeaderPageOf.Visible = true;

        }
        private void BindInspection()
        {
            try
            {
                gvInspectionDetails.DataSource = SiteViewInspectionBLL.SearchInspectionTemplate();
                gvInspectionDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                    }
                }
            }
            if (gvInspectionDetails.Rows.Count == 0)
            {
                disable();
            }
            else
            {
                enable();
            }
            if (gvInspectionDetails.Rows.Count > 0)
            {
                gvInspectionDetails.UseAccessibleHeader = true;
                if (gvInspectionDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvInspectionDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        private void disable()
        {
            btnInspectionHeaderFirst.Visible = false;
            btnInspectionHeaderPrevious.Visible = false;
            btnInspectionHeaderNext.Visible = false;
            btnInspectionHeaderLast.Visible = false;

            ddlInspectionHeaderResultPerPage.Visible = false;

            txtInspectionHeaderPage.Visible = false;
            lblInspectionHeaderPage.Visible = false;

            btnInspectionGoTo.Visible = false;

            lblInspectionHeaderResultperPage.Visible = false;

            lblInspectionHeaderPageof.Visible = false;

        }
        private void enable()
        {
            btnInspectionHeaderFirst.Visible =  true;
            btnInspectionHeaderPrevious.Visible = true;
            btnInspectionHeaderNext.Visible = true;
            btnInspectionHeaderLast.Visible = true;

            ddlInspectionHeaderResultPerPage.Visible = true;

            txtInspectionHeaderPage.Visible = true;
            lblInspectionHeaderPage.Visible = true;

            btnInspectionGoTo.Visible = true;

            lblInspectionHeaderResultperPage.Visible = true;

            lblInspectionHeaderPageof.Visible = true;
        }

        protected void ddlInspectionHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInspectionHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvInspectionDetails.PageSize = Convert.ToInt32(gvInspectionDetails.PageCount * gvInspectionDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlInspectionHeaderResultPerPage.Text);
                gvInspectionDetails.PageSize = selectedValue;
            }
            BindInspection();
        }
        private void BindJobTraining()
        {
            try
            {
                gvJobTrainingDetails.DataSource = SiteViewOnJobTrainingBLL.SearchOnJobTraining(SessionWrapper.u_userid);
                gvJobTrainingDetails.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                    }
                }
            }
            if (gvJobTrainingDetails.Rows.Count == 0)
            {
                disableOJT();
            }
            else
            {
                enableOJT();
            }
            if (gvJobTrainingDetails.Rows.Count > 0)
            {
                gvJobTrainingDetails.UseAccessibleHeader = true;
                if (gvJobTrainingDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvJobTrainingDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
              
        }
        private void disableOJT()
        {
            btnTrainingHeaderFirst.Visible = false;
            btnTraningHeaderPrevious.Visible = false;
            btnTrainingHeaderNext.Visible = false;
            btnTrainingHeaderLast.Visible = false;

            ddlTrainingResultPerPage.Visible = false;

            txtTrainingPage.Visible = false;
            lblTraingPage.Visible = false;

            btnTrainingGoTo.Visible = false;

            lblTrainingResultPerPage.Visible = false;

            lblTrainingPageOf.Visible = false;

        }
        private void enableOJT()
        {
            btnTrainingHeaderFirst.Visible = true;
            btnTraningHeaderPrevious.Visible = true;
            btnTrainingHeaderNext.Visible = true;
            btnTrainingHeaderLast.Visible = true;

            ddlTrainingResultPerPage.Visible = true;

            txtTrainingPage.Visible = true;
            lblTraingPage.Visible = true;

            btnTrainingGoTo.Visible = true;

            lblTrainingResultPerPage.Visible = true;

            lblTrainingPageOf.Visible = true;
        }

        protected void ddlTrainingResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTrainingResultPerPage.SelectedValue == "Show All")
            {
                gvJobTrainingDetails.PageSize = Convert.ToInt32(gvJobTrainingDetails.PageCount * gvJobTrainingDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlTrainingResultPerPage.Text);
                gvJobTrainingDetails.PageSize = selectedValue;
            }
            BindJobTraining();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvFieldNoteDetails.PageIndex = gvFieldNoteDetails.PageCount;

            BindFieldNotes();
            txtHeaderPage.Text = (gvFieldNoteDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvFieldNoteDetails.PageCount).ToString();

        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvFieldNoteDetails.PageIndex + 1;
            if (i <= gvFieldNoteDetails.PageCount)
                gvFieldNoteDetails.PageIndex = i;
            BindFieldNotes();
            txtHeaderPage.Text = (gvFieldNoteDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvFieldNoteDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvFieldNoteDetails.PageCount;
            if (gvFieldNoteDetails.PageIndex > 0)
                gvFieldNoteDetails.PageIndex = gvFieldNoteDetails.PageIndex - 1;
            BindFieldNotes();
            txtHeaderPage.Text = (gvFieldNoteDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvFieldNoteDetails.PageCount).ToString();
        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvFieldNoteDetails.PageIndex = 0;
            BindFieldNotes();
            txtHeaderPage.Text = (gvFieldNoteDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvFieldNoteDetails.PageCount).ToString();
        }

        protected void btnInspectionHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvInspectionDetails.PageIndex + 1;
            if (i <= gvInspectionDetails.PageCount)
                gvInspectionDetails.PageIndex = i;
            BindInspection();
            txtInspectionHeaderPage.Text = (gvInspectionDetails.PageIndex + 1).ToString();
            lblInspectionHeaderPageof.Text = "of " + (gvInspectionDetails.PageCount).ToString();

        }

        protected void btnInspectionHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvInspectionDetails.PageCount;
            if (gvInspectionDetails.PageIndex > 0)
                gvInspectionDetails.PageIndex = gvInspectionDetails.PageIndex - 1;
            BindInspection();
            txtInspectionHeaderPage.Text = (gvInspectionDetails.PageIndex + 1).ToString();
            lblInspectionHeaderPageof.Text = "of " + (gvInspectionDetails.PageCount).ToString();
        }

        protected void btnInspectionHeaderLast_Click(object sender, EventArgs e)
        {
            gvInspectionDetails.PageIndex = gvFieldNoteDetails.PageCount;
            BindInspection();
            txtInspectionHeaderPage.Text = (gvInspectionDetails.PageIndex + 1).ToString();
            lblInspectionHeaderPageof.Text = "of " + (gvInspectionDetails.PageCount).ToString();
        }

        protected void btnInspectionHeaderFirst_Click(object sender, EventArgs e)
        {
            gvInspectionDetails.PageIndex = 0;
            BindInspection();
            txtInspectionHeaderPage.Text = (gvInspectionDetails.PageIndex + 1).ToString();
            lblInspectionHeaderPageof.Text = "of " + (gvInspectionDetails.PageCount).ToString();
        }

        protected void btnTrainingHeaderLast_Click(object sender, EventArgs e)
        {
            gvJobTrainingDetails.PageIndex = gvJobTrainingDetails.PageCount;
            BindJobTraining();
            txtTrainingPage.Text = (gvJobTrainingDetails.PageIndex + 1).ToString();
            lblTrainingPageOf.Text = "of " + (gvJobTrainingDetails.PageCount).ToString();
        }

        protected void btnTrainingHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvJobTrainingDetails.PageIndex + 1;
            if (i <= gvJobTrainingDetails.PageCount)
                gvJobTrainingDetails.PageIndex = i;
            BindJobTraining();
            txtTrainingPage.Text = (gvJobTrainingDetails.PageIndex + 1).ToString();
            lblTrainingPageOf.Text = "of " + (gvJobTrainingDetails.PageCount).ToString();
        }

        protected void btnTraningHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvJobTrainingDetails.PageCount;
            if (gvJobTrainingDetails.PageIndex > 0)
                gvJobTrainingDetails.PageIndex = gvInspectionDetails.PageIndex - 1;
            BindJobTraining();
            txtTrainingPage.Text = (gvJobTrainingDetails.PageIndex + 1).ToString();
            lblTrainingPageOf.Text = "of " + (gvJobTrainingDetails.PageCount).ToString();
        }

        protected void btnTrainingHeaderFirst_Click(object sender, EventArgs e)
        {
            gvJobTrainingDetails.PageIndex = 0;
            BindJobTraining();
            txtTrainingPage.Text = (gvJobTrainingDetails.PageIndex + 1).ToString();
            lblTrainingPageOf.Text = "of " + (gvJobTrainingDetails.PageCount).ToString();
        }



        protected void gvInspectionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvInspectionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/Compliance/SiteView/csvein-01.aspx?mode=edit&id=" + SecurityCenter.EncryptText(gvInspectionDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            if (e.CommandName.Equals("Archive"))
            {
                try
                {
                    SiteViewInspectionBLL.UpdateInspectionStatus(gvInspectionDetails.DataKeys[rowIndex].Values[0].ToString());
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                        }
                    }
                }
            }
            BindInspection();
        }

        protected void gvInspectionDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnInspectionGoTo_Click(object sender, EventArgs e)
        {
            gvInspectionDetails.PageIndex = Int32.Parse(txtInspectionHeaderPage.Text) - 1;
            BindInspection();
        }

        protected void btnAddInspection_Click(object sender, EventArgs e)
        {
            SiteViewInspection inspection = new SiteViewInspection();
            try
            {
                inspection = SiteViewInspectionBLL.GetInspectionId();
                string s = inspection.sv_inspection_id_pk;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                    }
                }
            }
            Response.Redirect("../SiteView/csvanin-01.aspx?InspectionId=" + SecurityCenter.EncryptText(inspection.sv_inspection_id_pk));

            //Response.Redirect("../SiteView/csvanin-01.aspx");
        }

        protected void gvFieldNoteDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Edit"))
            {
                //here we have to check the fieldnotes are saved or received.
                if (gvFieldNoteDetails.DataKeys[rowIndex].Values[1].ToString() == SessionWrapper.u_userid)
                {

                    Response.Redirect("~/Compliance/SiteView/FieldNotes/csvefn-01.aspx?mode=saved&id=" + SecurityCenter.EncryptText(gvFieldNoteDetails.DataKeys[rowIndex].Values[0].ToString()), false);
                }
                else
                {
                    SiteViewFieldNotes fieldNotesId = new SiteViewFieldNotes();
                    fieldNotesId = SiteViewFieldNotesBLL.GetFieldNoteId();
                    Response.Redirect("~/Compliance/SiteView/FieldNotes/csvefn-01.aspx?mode=received&fieldNoteId=" + SecurityCenter.EncryptText(fieldNotesId.sv_fieldnote_id) + "&id=" + SecurityCenter.EncryptText(gvFieldNoteDetails.DataKeys[rowIndex].Values[0].ToString()), false);
                }
            }
            if (e.CommandName.Equals("Archive"))
            {
                //here we have to check the fieldnotes are saved or received.
                string fieldnotesId = gvFieldNoteDetails.DataKeys[rowIndex].Values[0].ToString();
                string userId = gvFieldNoteDetails.DataKeys[rowIndex].Values[1].ToString();
                try
                {
                    if (gvFieldNoteDetails.DataKeys[rowIndex].Values[1].ToString() == SessionWrapper.u_userid)
                    {
                        SiteViewFieldNotesBLL.UpdateSavedFieldNotesStatus(SessionWrapper.u_userid, fieldnotesId);
                    }
                    else
                    {
                        SiteViewFieldNotesBLL.UpdateReceivedFieldNotesStatus(SessionWrapper.u_userid, fieldnotesId);
                    }

                    //SiteViewInspectionBLL.UpdateInspectionStatus(gvInspectionDetails.DataKeys[rowIndex].Values[0].ToString());
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                        }
                    }
                }
            }
            BindFieldNotes();
        }

        protected void gvFieldNoteDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

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

        protected void gvJobTrainingDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Edit"))
            {
                //here we have to check the fieldnotes are saved or received.
                if (gvJobTrainingDetails.DataKeys[rowIndex].Values[1].ToString() == SessionWrapper.u_userid)
                {
                    Response.Redirect("~/Compliance/SiteView/Ojt/csveojt-01.aspx?mode=saved&id=" + SecurityCenter.EncryptText(gvJobTrainingDetails.DataKeys[rowIndex].Values[0].ToString()), false);
                }
                else
                {
                    SiteViewOnJobTraining ojtId = new SiteViewOnJobTraining();
                    ojtId = SiteViewOnJobTrainingBLL.GetOjtId();
                    Response.Redirect("~/Compliance/SiteView/Ojt/csveojt-01.aspx?mode=received&OjtId=" + SecurityCenter.EncryptText(ojtId.sv_ojt_id_pk) + "&id=" + SecurityCenter.EncryptText(gvJobTrainingDetails.DataKeys[rowIndex].Values[0].ToString()), false);
                }
            }
            if (e.CommandName.Equals("Archive"))
            {
                //here we have to check the fieldnotes are saved or received.
                string ojtId = gvJobTrainingDetails.DataKeys[rowIndex].Values[0].ToString();
                string userId = gvJobTrainingDetails.DataKeys[rowIndex].Values[1].ToString();
                try
                {
                    if (gvJobTrainingDetails.DataKeys[rowIndex].Values[1].ToString() == SessionWrapper.u_userid)
                    {
                        SiteViewOnJobTrainingBLL.UpdateSavedOjtStatus(SessionWrapper.u_userid, ojtId);
                        //SiteViewFieldNotesBLL.UpdateSavedFieldNotesStatus(SessionWrapper.u_userid, ojtId);
                    }
                    else
                    {
                        SiteViewOnJobTrainingBLL.UpdateReceivedOjtStatus(SessionWrapper.u_userid, ojtId);
                        //SiteViewFieldNotesBLL.UpdateReceivedFieldNotesStatus(SessionWrapper.u_userid, ojtId);
                    }
                    //SiteViewInspectionBLL.UpdateInspectionStatus(gvInspectionDetails.DataKeys[rowIndex].Values[0].ToString());
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("ccsv-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }

        protected void gvJobTrainingDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

    }
}