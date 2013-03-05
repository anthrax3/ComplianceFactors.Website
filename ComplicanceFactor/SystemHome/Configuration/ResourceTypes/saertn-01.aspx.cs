using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.ResourceTypes
{
    public partial class saertn_01 : BasePage
    {
        private static string editResourceId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind resource type status
                ddlStatus.DataSource = SystemResourceTypeBLL.GetStatus(SessionWrapper.CultureName, "saertn-01");
                ddlStatus.DataBind();
                
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editResourceId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    PoulateResource(editResourceId);
                }
                //Label BreadCrumb 
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx>" + LocalResources.GetLabel("app_manage_Resource_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_resource_type_text");
                ///Show success message
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
            }
        }
        /// <summary>
        /// Populate value from Resource type (table)
        /// </summary>
        /// <param name="editResourceId"></param>
        void PoulateResource(string editResourceId)
        {
            SystemResourceType resourceType = new SystemResourceType();
            resourceType = SystemResourceTypeBLL.GetResourceTypesbyId(editResourceId);

            txtResourceTypeId.Text = resourceType.s_resource_type_id;
            ddlStatus.SelectedValue = resourceType.s_resource_type_status_id_fk;
            txtResourceTypeName.Text = resourceType.s_resource_type_name_us_english;
            txtDescriptionUS.Value = resourceType.s_resource_type_desc_us_english;
            txtResourceTypeNameUK.Text = resourceType.s_resource_type_name_uk_english;
            txtDescriptionUK.Value = resourceType.s_resource_type_desc_uk_english;
            txtResourceTypeNameCA.Text = resourceType.s_resource_type_name_ca_french;
            txtDescriptionCA.Value = resourceType.s_resource_type_desc_ca_french;
            txtResourceTypeNameFR.Text = resourceType.s_resource_type_name_fr_french;
            txtDescriptionFR.Value = resourceType.s_resource_type_desc_fr_french;
            txtResourceTypeNameMX.Text = resourceType.s_resource_type_name_mx_spanish;
            txtDescriptionMX.Value = resourceType.s_resource_type_desc_mx_spanish;
            txtResourceTypeNameSP.Text = resourceType.s_resource_type_name_sp_spanish;
            txtDescriptionSP.Value = resourceType.s_resource_type_desc_sp_spanish;
            txtResourceTypeNamePortuguse.Text = resourceType.s_resource_type_name_portuguese;
            txtDescriptionPortuguese.Value = resourceType.s_resource_type_desc_portuguese;
            txtResourceTypeNameGerman.Text = resourceType.s_resource_type_name_german;
            txtDescriptionGerman.Value = resourceType.s_resource_type_desc_german;
            txtResourceTypeNameJapanese.Text = resourceType.s_resource_type_name_japanese;
            txtDescriptionJapanese.Value = resourceType.s_resource_type_desc_japanese;
            txtResourceTypeNameRussian.Text = resourceType.s_resource_type_name_russian;
            txtDescriptionRussian.Value = resourceType.s_resource_type_desc_russian;
            txtResourceTypeNameDanish.Text = resourceType.s_resource_type_name_danish;
            txtDescriptionDanish.Value = resourceType.s_resource_type_desc_danish;
            txtResourceTypeNamePolish.Text = resourceType.s_resource_type_name_polish;
            txtDescriptionPolish.Value = resourceType.s_resource_type_desc_polish;
            txtResourceTypeNameSwedish.Text = resourceType.s_resource_type_name_swedish;
            txtDescriptionSwedish.Value = resourceType.s_resource_type_desc_swedish;
            txtResourceTypeNameFinnish.Text = resourceType.s_resource_type_name_finnish;
            txtDescriptionFinnish.Value = resourceType.s_resource_type_desc_finnish;
            txtResourceTypeNameKorean.Text = resourceType.s_resource_type_name_korean;
            txtDescriptionKorean.Value = resourceType.s_resource_type_desc_korean;
            txtResourceTypeNameItalian.Text = resourceType.s_resource_type_name_italian;
            txtDescriptionItalian.Value = resourceType.s_resource_type_desc_italian;
            txtResourceTypeNameDutch.Text = resourceType.s_resource_type_name_dutch;
            txtDescriptionDutch.Value = resourceType.s_resource_type_desc_dutch;
            txtResourceTypeNameIndonesian.Text = resourceType.s_resource_type_name_indonesian;
            txtDescriptionIndonesian.Value = resourceType.s_resource_type_desc_indonesian;
            txtResourceTypeNameGreek.Text = resourceType.s_resource_type_name_greek;
            txtDescriptionGreek.Value = resourceType.s_resource_type_desc_greek;
            txtResourceTypeNameHungarian.Text = resourceType.s_resource_type_name_hungarian;
            txtDescriptionHungarian.Value = resourceType.s_resource_type_desc_hungarian;
            txtResourceTypeNameNorwegian.Text = resourceType.s_resource_type_name_norwegian;
            txtDescriptionNorwegian.Value = resourceType.s_resource_type_desc_norwegian;
            txtResourceTypeNameTurkish.Text = resourceType.s_resource_type_name_turkish;
            txtDescriptionTurkish.Value = resourceType.s_resource_type_desc_turkish;
            txtResourceTypeNameArabic.Text = resourceType.s_resource_type_name_arabic_rtl;
            txtDescriptionArabic.Value = resourceType.s_resource_type_desc_arabic_rtl;
            txtResourceTypeNameCustom01.Text = resourceType.s_resource_type_name_custom_01;
            txtDescriptionCustom01.Value = resourceType.s_resource_type_desc_custom_01;
            txtResourceTypeNameCustom02.Text = resourceType.s_resource_type_name_custom_01;
            txtDescriptionCustom02.Value = resourceType.s_resource_type_desc_custom_02;
            txtResourceTypeNameCustom03.Text = resourceType.s_resource_type_name_custom_03;
            txtDescriptionCustom03.Value = resourceType.s_resource_type_desc_custom_03;
            txtResourceTypeNameCustom04.Text = resourceType.s_resource_type_name_custom_04;
            txtDescriptionCustom04.Value = resourceType.s_resource_type_desc_custom_04;
            txtResourceTypeNameCustom05.Text = resourceType.s_resource_type_name_custom_05;
            txtDescriptionCustom05.Value = resourceType.s_resource_type_desc_custom_05;
            txtResourceTypeNameCustom06.Text = resourceType.s_resource_type_name_custom_06;
            txtDescriptionCustom06.Value = resourceType.s_resource_type_desc_custom_06;
            txtResourceTypeNameCustom07.Text = resourceType.s_resource_type_name_custom_07;
            txtDescriptionCustom07.Value = resourceType.s_resource_type_desc_custom_07;
            txtResourceTypeNameCustom08.Text = resourceType.s_resource_type_name_custom_08;
            txtDescriptionCustom08.Value = resourceType.s_resource_type_name_custom_08;
            txtResourceTypeNameCustom09.Text = resourceType.s_resource_type_name_custom_09;
            txtDescriptionCustom09.Value = resourceType.s_resource_type_desc_custom_09;
            txtResourceTypeNameCustom10.Text = resourceType.s_resource_type_name_custom_10;
            txtDescriptionCustom10.Value = resourceType.s_resource_type_desc_custom_10;
            txtResourceTypeNameCustom11.Text = resourceType.s_resource_type_name_custom_11;
            txtDescriptionCustom11.Value = resourceType.s_resource_type_name_custom_11;
            txtResourceTypeNameCustom12.Text = resourceType.s_resource_type_name_custom_12;
            txtDescriptionCustom12.Value = resourceType.s_resource_type_desc_custom_12;
            txtResourceTypeNameCustom13.Text = resourceType.s_resource_type_name_custom_13;
            txtDescriptionCustom13.Value = resourceType.s_resource_type_desc_custom_13;
            txtResourceTypeNameChinese.Text = resourceType.s_resource_type_name_simp_chinese;
            txtDescriptionChinese.Value = resourceType.s_resource_type_desc_simp_chinese;
        }

        protected void btnHeaderSaveNewResourceType_Click(object sender, EventArgs e)
        {
            UpdateResource();
        }

        protected void btnFooterSaveNewResourceType_Click(object sender, EventArgs e)
        {
            UpdateResource();
        }
        /// <summary>
        /// Update Resource or Edit Resource
        /// </summary>
        void UpdateResource()
        {
            SystemResourceType updateResourceType = new SystemResourceType();
            updateResourceType.s_resource_type_system_id_pk = editResourceId;
            updateResourceType.s_resource_type_id = txtResourceTypeId.Text;
            updateResourceType.s_resource_type_status_id_fk = ddlStatus.SelectedValue;
            updateResourceType.s_resource_type_name_us_english = txtResourceTypeName.Text;
            updateResourceType.s_resource_type_desc_us_english = txtDescriptionUS.Value;
            updateResourceType.s_resource_type_name_uk_english = txtResourceTypeNameUK.Text;
            updateResourceType.s_resource_type_desc_uk_english = txtDescriptionUK.Value;
            updateResourceType.s_resource_type_name_ca_french = txtResourceTypeNameCA.Text;
            updateResourceType.s_resource_type_desc_ca_french = txtDescriptionCA.Value;
            updateResourceType.s_resource_type_name_fr_french = txtResourceTypeNameFR.Text;
            updateResourceType.s_resource_type_desc_fr_french = txtDescriptionFR.Value;
            updateResourceType.s_resource_type_name_mx_spanish = txtResourceTypeNameMX.Text;
            updateResourceType.s_resource_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateResourceType.s_resource_type_name_sp_spanish = txtResourceTypeNameSP.Text;
            updateResourceType.s_resource_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateResourceType.s_resource_type_name_portuguese = txtResourceTypeNamePortuguse.Text;
            updateResourceType.s_resource_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateResourceType.s_resource_type_name_german = txtResourceTypeNameGerman.Text;
            updateResourceType.s_resource_type_desc_german = txtDescriptionGerman.Value;
            updateResourceType.s_resource_type_name_japanese = txtResourceTypeNameJapanese.Text;
            updateResourceType.s_resource_type_desc_japanese = txtDescriptionJapanese.Value;
            updateResourceType.s_resource_type_name_russian = txtResourceTypeNameRussian.Text;
            updateResourceType.s_resource_type_desc_russian = txtDescriptionRussian.Value;
            updateResourceType.s_resource_type_name_danish = txtResourceTypeNameDanish.Text;
            updateResourceType.s_resource_type_desc_danish = txtDescriptionDanish.Value;
            updateResourceType.s_resource_type_name_polish = txtResourceTypeNamePolish.Text;
            updateResourceType.s_resource_type_desc_polish = txtDescriptionPolish.Value;
            updateResourceType.s_resource_type_name_swedish = txtResourceTypeNameSwedish.Text;
            updateResourceType.s_resource_type_desc_swedish = txtDescriptionSwedish.Value;
            updateResourceType.s_resource_type_name_finnish = txtResourceTypeNameFinnish.Text;
            updateResourceType.s_resource_type_desc_finnish = txtDescriptionFinnish.Value;
            updateResourceType.s_resource_type_name_korean = txtResourceTypeNameKorean.Text;
            updateResourceType.s_resource_type_desc_korean = txtDescriptionKorean.Value;
            updateResourceType.s_resource_type_name_italian = txtResourceTypeNameItalian.Text;
            updateResourceType.s_resource_type_desc_italian = txtDescriptionItalian.Value;
            updateResourceType.s_resource_type_name_dutch = txtResourceTypeNameDutch.Text;
            updateResourceType.s_resource_type_desc_dutch = txtDescriptionDutch.Value;
            updateResourceType.s_resource_type_name_indonesian = txtResourceTypeNameIndonesian.Text;
            updateResourceType.s_resource_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateResourceType.s_resource_type_name_greek = txtResourceTypeNameGreek.Text;
            updateResourceType.s_resource_type_desc_greek = txtDescriptionGreek.Value;
            updateResourceType.s_resource_type_name_hungarian = txtResourceTypeNameHungarian.Text;
            updateResourceType.s_resource_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateResourceType.s_resource_type_name_norwegian = txtResourceTypeNameNorwegian.Text;
            updateResourceType.s_resource_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateResourceType.s_resource_type_name_turkish = txtResourceTypeNameTurkish.Text;
            updateResourceType.s_resource_type_desc_turkish = txtDescriptionTurkish.Value;
            updateResourceType.s_resource_type_name_arabic_rtl = txtResourceTypeNameArabic.Text;
            updateResourceType.s_resource_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateResourceType.s_resource_type_name_custom_01 = txtResourceTypeNameCustom01.Text;
            updateResourceType.s_resource_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateResourceType.s_resource_type_name_custom_02 = txtResourceTypeNameCustom02.Text;
            updateResourceType.s_resource_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateResourceType.s_resource_type_name_custom_03 = txtResourceTypeNameCustom03.Text;
            updateResourceType.s_resource_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateResourceType.s_resource_type_name_custom_04 = txtResourceTypeNameCustom04.Text;
            updateResourceType.s_resource_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateResourceType.s_resource_type_name_custom_05 = txtResourceTypeNameCustom05.Text;
            updateResourceType.s_resource_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateResourceType.s_resource_type_name_custom_06 = txtResourceTypeNameCustom06.Text;
            updateResourceType.s_resource_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateResourceType.s_resource_type_name_custom_07 = txtResourceTypeNameCustom07.Text;
            updateResourceType.s_resource_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateResourceType.s_resource_type_name_custom_08 = txtResourceTypeNameCustom08.Text;
            updateResourceType.s_resource_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateResourceType.s_resource_type_name_custom_09 = txtResourceTypeNameCustom09.Text;
            updateResourceType.s_resource_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateResourceType.s_resource_type_name_custom_10 = txtResourceTypeNameCustom10.Text;
            updateResourceType.s_resource_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateResourceType.s_resource_type_name_custom_11 = txtResourceTypeNameCustom11.Text;
            updateResourceType.s_resource_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateResourceType.s_resource_type_name_custom_12 = txtResourceTypeNameCustom12.Text;
            updateResourceType.s_resource_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateResourceType.s_resource_type_name_custom_13 = txtResourceTypeNameCustom13.Text;
            updateResourceType.s_resource_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateResourceType.s_resource_type_name_simp_chinese = txtResourceTypeNameChinese.Text;
            updateResourceType.s_resource_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int result = SystemResourceTypeBLL.UpdateResourceType(updateResourceType);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text"); 
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saertn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saertn-01", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx");
        }
    }
}