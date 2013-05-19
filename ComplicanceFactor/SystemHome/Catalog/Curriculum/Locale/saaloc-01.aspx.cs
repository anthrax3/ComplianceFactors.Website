using System;
using System.Web.UI;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.Locale
{
    public partial class saaloc_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = "Curriculum Information" + " (" + Request.QueryString["localeText"] + ")";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemCurriculum InsertLocale = new SystemCurriculum();
            InsertLocale.s_curriculum_locale_title = txtTitle.Text;
            InsertLocale.s_curriculum_locale_description = txtDescriptoin.Value;
            InsertLocale.s_locale_id_fk = Request.QueryString["localeid"];
            InsertLocale.s_curriculum_system_id_fk = Request.QueryString["editCurriculumId"];
            InsertLocale.s_curriculum_locale_abstract = txtAbstract.Value;

            try
            {
                SystemCurriculumBLL.InsertCurriculumLocale(InsertLocale);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Curriculum locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Curriculum locale)", ex.Message);
                    }
                }
            }

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
    }
}