using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Course.Delivery.Locale
{
    public partial class saaloc_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = LocalResources.GetLabel("app_delivery_information_text") + " (" + Request.QueryString["localeText"] + ")";
                    lblNonConformantHeading.Text = " (" + Request.QueryString["localeText"] + ")";
                    lblScormHeading.Text = " (" + Request.QueryString["localeText"] + ")";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManageCourse InsertLocale = new ManageCourse();
            InsertLocale.s_delivery_locale_name = txtTitle.Text;
            InsertLocale.s_delivery_locale_description = txtDescriptoin.Value;
            InsertLocale.s_locale_id_fk = Request.QueryString["localeid"];
            InsertLocale.s_delivery_system_id_fk = Request.QueryString["editdeliveryId"];
            InsertLocale.s_delivery_locale_abstract = txtAbstract.Value;
            InsertLocale.s_delivery_aicc_url = txtAiccUrl.Text;
            InsertLocale.s_delivery_scorm_url = txtScormUrl.Text;
            try
            {
                ManageCourseBLL.InsertDeliveryLocale(InsertLocale);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Delivery locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Delivery locale)", ex.Message);
                    }
                }
            }

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}