using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.Compliance.SiteView.Ojt.Popup
{
    public partial class csvojtack : System.Web.UI.Page
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
        /// <summary>
        /// Populate Fieldnotes
        /// </summary>
        /// <param name="fieldNote"></param>
        private void PopulateFieldNotes(string ojtId)
        {
            try
            {
                SiteViewOnJobTraining ojtdetails = new SiteViewOnJobTraining();
                ojtdetails = SiteViewOnJobTrainingBLL.GetSingleOjt(ojtId);


                lblOJT.Text = ojtdetails.sv_ojt_number;
                lblOJTTitle.Text = ojtdetails.sv_ojt_title;
                lblLocation.Text = ojtdetails.sv_ojt_location;
                lblDescription.Text = ojtdetails.sv_ojt_description;
                lblDateTime.Text = ojtdetails.sv_ojt_creation_date_time;
                lblSendBy.Text = ojtdetails.sv_ojt_created_by;

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
                    SessionWrapper.isFieldNoteLoad = true;
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }


        protected void btnNoAcknowledge_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}