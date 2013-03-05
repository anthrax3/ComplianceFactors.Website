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
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Course.Delivery.Locale
{
    public partial class saeloc_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ManageCourse Locale = new ManageCourse();
                    Locale = ManageCourseBLL.GetSingleDeliveryLocale(Request.QueryString["id"]);
                    txtTitle.Text = Locale.s_delivery_locale_name;
                    txtDescriptoin.Value = Locale.s_delivery_locale_description;
                    txtAbstract.Value = Locale.s_delivery_locale_abstract;
                    txtAiccUrl.Text = Locale.s_delivery_aicc_url;
                    txtScormUrl.Text = Locale.s_delivery_scorm_url;
                    lblLocaleHeading.Text = LocalResources.GetLabel("app_delivery_information_text") + " (" + Locale.s_locale_text + ")";
                    lblNonConformantHeading.Text = " (" + Locale.s_locale_text + ")";
                    lblScormHeading.Text = " (" + Locale.s_locale_text + ")";
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(delivery locale)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(delivery locale)", ex.Message);
                        }
                    }
                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManageCourse UpdateDeliveryLocale = new ManageCourse();
            UpdateDeliveryLocale.s_delivery_locale_system_id_pk = Request.QueryString["id"];
            UpdateDeliveryLocale.s_delivery_locale_name = txtTitle.Text;
            UpdateDeliveryLocale.s_delivery_locale_description = txtDescriptoin.Value;
            UpdateDeliveryLocale.s_delivery_locale_abstract = txtAbstract.Value;
            UpdateDeliveryLocale.s_delivery_aicc_url = txtAiccUrl.Text;
            UpdateDeliveryLocale.s_delivery_scorm_url = txtScormUrl.Text;
            try
            {
              ManageCourseBLL.UpdateDeliveryLocale(UpdateDeliveryLocale);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeloc-01.aspx(delivery locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeloc-01.aspx(delivery locale)", ex.Message);
                    }
                }
            }

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// get locale from session
        /// </summary>
        /// <param name="str_s_locale_system_id_pk"></param>
        /// <param name="dtLocale"></param>
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            ManageCourse Locale = new ManageCourse();
            Locale = ManageCourseBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtTitle.Text = Locale.s_course_locale_name;
            txtDescriptoin.Value = Locale.s_course_locale_description;
            txtAbstract.Value = Locale.s_course_locale_abstract;
            lblLocaleHeading.Text = "Course Information" + " (" + Locale.s_locale_text + ")";
        }
    }
}