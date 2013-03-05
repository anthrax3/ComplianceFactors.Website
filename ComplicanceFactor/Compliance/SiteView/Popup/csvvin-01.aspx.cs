using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance.SiteView.Popup
{
    public partial class csvvin_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //View
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "view")
                {                     
                    PopulateInspection(Request.QueryString["id"].ToString());
                }
            }
        }

        private void PopulateInspection(string inspectionId)
        {
            DataTable dtInspection = new DataTable();
            try
            {
                dtInspection = SiteViewInspectionBLL.GetSingleInspection(inspectionId);

                gvQuestions.DataSource = dtInspection;
                gvQuestions.DataBind();              

                lblInspectionId.Text = dtInspection.Rows[0]["sv_mi_templete_id"].ToString();
                lblInspectionName.Text = dtInspection.Rows[0]["sv_mi_templete_title"].ToString();
                lblDescription.Text = dtInspection.Rows[0]["sv_mi_templete_description"].ToString();
                lblStatus.Text = dtInspection.Rows[0]["s_status_name"].ToString();
                chkIsDefault.Checked = Convert.ToBoolean(dtInspection.Rows[0]["sv_mi_templete_is_default"]);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("csvvin-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("csvvin-01", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}