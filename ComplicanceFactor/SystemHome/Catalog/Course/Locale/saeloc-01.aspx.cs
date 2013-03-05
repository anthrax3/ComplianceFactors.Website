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

namespace ComplicanceFactor.SystemHome.Catalog.Course.Locale
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
                    Locale = ManageCourseBLL.GetSinglecourseLocale(Request.QueryString["id"]);
                    txtTitle.Text = Locale.s_course_locale_name;
                    txtDescriptoin.Value = Locale.s_course_locale_description;
                    txtAbstract.Value = Locale.s_course_locale_abstract;
                    lblLocaleHeading.Text = LocalResources.GetLabel("app_course_information_text") + " (" + Locale.s_locale_text + ")";
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

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManageCourse updatecourse = new ManageCourse();
            updatecourse.s_course_locale_system_id_pk = Request.QueryString["id"];
            updatecourse.s_course_locale_name = txtTitle.Text;
            updatecourse.s_course_locale_description = txtDescriptoin.Value;
            updatecourse.s_course_locale_abstract = txtAbstract.Value;
            try
            {
                ManageCourseBLL.UpdateCourseLocale(updatecourse);
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
            lblLocaleHeading.Text = LocalResources.GetLabel("app_course_information_text") + " (" + Locale.s_locale_text + ")";
        }
    }
}