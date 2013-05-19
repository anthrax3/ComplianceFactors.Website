using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance.SiteView.FieldNotes.Popup
{
    public partial class csvvfn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //View
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "view")
                {
                    PopulateFieldNotes(Request.QueryString["id"].ToString());
                }
            }
        }
        /// <summary>
        /// Populate Field Notes
        /// </summary>
        /// <param name="fieldNote"></param>
        private void PopulateFieldNotes(string fieldNote)
        {
            try
            {
                SiteViewFieldNotes fieldnotes = new SiteViewFieldNotes();
                fieldnotes = SiteViewFieldNotesBLL.GetSingleFieldNotes(fieldNote);

                lblFieldNote.Text = fieldnotes.sv_fieldnote_id;
                 lblDescription.Text = fieldnotes.sv_fieldnote_description;
                 lblLocation.Text = fieldnotes.sv_fieldnote_location;
                 lblTitle.Text = fieldnotes.sv_fieldnote_title;

                 gvAttachment.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAttachment(fieldNote);
                 gvAttachment.DataBind();

                 gvAcknowledgement.DataSource = SiteViewFieldNotesBLL.GetFieldNotesAcknowledge(fieldNote);
                 gvAcknowledgement.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvvfn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvvfn-01", ex.Message);
                    }
                }
            }
        }

       
         
    }
}