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
    public partial class csvack_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //View
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "acknowledge")
                {
                    PopulateFieldNotes(Request.QueryString["id"].ToString());
                }
            }
        }

        private void PopulateFieldNotes(string fieldNote)
        {
            try
            {
                SiteViewFieldNotes fieldnotes = new SiteViewFieldNotes();
                fieldnotes = SiteViewFieldNotesBLL.GetSingleFieldNotes(fieldNote);

                lblFieldNote.Text = fieldnotes.sv_fieldnote_id;
                lblFielNoteTitle.Text = fieldnotes.sv_fieldnote_title;
                lblLocation.Text = fieldnotes.sv_fieldnote_location;
                lblDescription.Text = fieldnotes.sv_fieldnote_description;
                lblDateTime.Text = fieldnotes.sv_fieldnote_creation_date;
                lblSendBy.Text = fieldnotes.sv_fieldnote_location;
                 
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvack-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvack-01", ex.Message);
                    }
                }
            }
        }

        protected void btnAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                int result = SiteViewFieldNotesBLL.UpdateAcknowledgement(SessionWrapper.u_userid, Request.QueryString["id"].ToString());
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerText = "Acknowledgement updated Successfully";
                }
                else
                {
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divSuccess.InnerText = "Acknowledgement not updated";
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvack-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvack-01", ex.Message);
                    }
                }
            }

        }

        protected void btnNoAcknowledge_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

    }
}