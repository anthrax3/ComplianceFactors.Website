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

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.Locale
{
    public partial class saeloc_011 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
 
                    SystemCurriculum Locale = new SystemCurriculum();
                    Locale = SystemCurriculumBLL.GetSinglecurriculumLocale(Request.QueryString["id"]);
                    txtTitle.Text = Locale.s_curriculum_locale_title;
                    txtDescriptoin.Value = Locale.s_curriculum_locale_description;
                    txtAbstract.Value = Locale.s_curriculum_locale_abstract;
                    lblLocaleHeading.Text = "Curriculum Information" + " (" + Locale.s_locale_text + ")";
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(Curriculum locale)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(Curriculum locale)", ex.Message);
                        }
                    }
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            SystemCurriculum updatecurriculum = new SystemCurriculum();
            updatecurriculum.s_curriculum_locales_system_id_pk = Request.QueryString["id"];
            updatecurriculum.s_curriculum_locale_title = txtTitle.Text;
            updatecurriculum.s_curriculum_locale_description = txtDescriptoin.Value;
            updatecurriculum.s_curriculum_locale_abstract = txtAbstract.Value;
            try
            {
                SystemCurriculumBLL.UpdateCurriculumLocale(updatecurriculum);
           
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeloc-01.aspx(course locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeloc-01.aspx(course locale)", ex.Message);
                    }
                }
            }

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            SystemCurriculum Locale = new SystemCurriculum();
            Locale = SystemCurriculumBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtTitle.Text = Locale.s_curriculum_locale_title;
            txtDescriptoin.Value = Locale.s_curriculum_locale_description;
            txtAbstract.Value = Locale.s_curriculum_locale_abstract;
            lblLocaleHeading.Text = "Curriculum Information" + " (" + Locale.s_locale_text + ")";
        }
    }
}