using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.ResourceTypes
{
    public partial class saanrtn_01 : BasePage
    {
        private static string copyResourceId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind resource type status
                ddlStatus.DataSource = SystemResourceTypeBLL.GetStatus(SessionWrapper.CultureName, "saanrtn-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";

                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyResourceId = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PoulateResource(copyResourceId);
                }

                //resource type bread crumbS
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx>" + LocalResources.GetLabel("app_manage_Resource_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_Resource_type_text");
                
               
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ResourceTypes/samrtmp-01.aspx");
        }

        protected void btnFooterSaveNewResourceType_Click(object sender, EventArgs e)
        {
            SaveResourceType();
        }

        protected void btnHeaderSaveNewResourceType_Click(object sender, EventArgs e)
        {
            SaveResourceType();
        }
        /// <summary>
        /// save resource type
        /// </summary>
        public void SaveResourceType()
        {
            SystemResourceType createResourceType = new SystemResourceType();
            createResourceType.s_resource_type_system_id_pk = Guid.NewGuid().ToString();
            createResourceType.s_resource_type_id = txtResourceTypeId.Text;
            createResourceType.s_resource_type_status_id_fk = ddlStatus.SelectedValue;
            createResourceType.s_resource_type_name_us_english = txtResourceTypeName.Text;
            createResourceType.s_resource_type_desc_us_english = txtDescriptionUS.Value;
            createResourceType.s_resource_type_name_uk_english = txtResourceTypeNameUK.Text;
            createResourceType.s_resource_type_desc_uk_english = txtDescriptionUK.Value;
            createResourceType.s_resource_type_name_ca_french = txtResourceTypeNameCA.Text;
            createResourceType.s_resource_type_desc_ca_french = txtDescriptionCA.Value;
            createResourceType.s_resource_type_name_fr_french = txtResourceTypeNameFR.Text;
            createResourceType.s_resource_type_desc_fr_french = txtDescriptionFR.Value;
            createResourceType.s_resource_type_name_mx_spanish = txtResourceTypeNameMX.Text;
            createResourceType.s_resource_type_desc_mx_spanish = txtDescriptionMX.Value;
            createResourceType.s_resource_type_name_sp_spanish = txtResourceTypeNameSP.Text;
            createResourceType.s_resource_type_desc_sp_spanish = txtDescriptionSP.Value;
            createResourceType.s_resource_type_name_portuguese = txtResourceTypeNamePortuguse.Text;
            createResourceType.s_resource_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createResourceType.s_resource_type_name_german = txtResourceTypeNameGerman.Text;
            createResourceType.s_resource_type_desc_german = txtDescriptionGerman.Value;
            createResourceType.s_resource_type_name_japanese = txtResourceTypeNameJapanese.Text;
            createResourceType.s_resource_type_desc_japanese = txtDescriptionJapanese.Value;
            createResourceType.s_resource_type_name_russian = txtResourceTypeNameRussian.Text;
            createResourceType.s_resource_type_desc_russian = txtDescriptionRussian.Value;
            createResourceType.s_resource_type_name_danish = txtResourceTypeNameDanish.Text;
            createResourceType.s_resource_type_desc_danish = txtDescriptionDanish.Value;
            createResourceType.s_resource_type_name_polish = txtResourceTypeNamePolish.Text;
            createResourceType.s_resource_type_desc_polish = txtDescriptionPolish.Value;
            createResourceType.s_resource_type_name_swedish = txtResourceTypeNameSwedish.Text;
            createResourceType.s_resource_type_desc_swedish = txtDescriptionSwedish.Value;
            createResourceType.s_resource_type_name_finnish = txtResourceTypeNameFinnish.Text;
            createResourceType.s_resource_type_desc_finnish = txtDescriptionFinnish.Value;
            createResourceType.s_resource_type_name_korean = txtResourceTypeNameKorean.Text;
            createResourceType.s_resource_type_desc_korean = txtDescriptionKorean.Value;
            createResourceType.s_resource_type_name_italian = txtResourceTypeNameItalian.Text;
            createResourceType.s_resource_type_desc_italian = txtDescriptionItalian.Value;
            createResourceType.s_resource_type_name_dutch = txtResourceTypeNameDutch.Text;
            createResourceType.s_resource_type_desc_dutch = txtDescriptionDutch.Value;
            createResourceType.s_resource_type_name_indonesian = txtResourceTypeNameIndonesian.Text;
            createResourceType.s_resource_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createResourceType.s_resource_type_name_greek = txtResourceTypeNameGreek.Text;
            createResourceType.s_resource_type_desc_greek = txtDescriptionGreek.Value;
            createResourceType.s_resource_type_name_hungarian = txtResourceTypeNameHungarian.Text;
            createResourceType.s_resource_type_desc_hungarian = txtDescriptionHungarian.Value;
            createResourceType.s_resource_type_name_norwegian = txtResourceTypeNameNorwegian.Text;
            createResourceType.s_resource_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createResourceType.s_resource_type_name_turkish = txtResourceTypeNameTurkish.Text;
            createResourceType.s_resource_type_desc_turkish = txtDescriptionTurkish.Value;
            createResourceType.s_resource_type_name_arabic_rtl = txtResourceTypeNameArabic.Text;
            createResourceType.s_resource_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createResourceType.s_resource_type_name_custom_01 = txtResourceTypeNameCustom01.Text;
            createResourceType.s_resource_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createResourceType.s_resource_type_name_custom_02 = txtResourceTypeNameCustom02.Text;
            createResourceType.s_resource_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createResourceType.s_resource_type_name_custom_03 = txtResourceTypeNameCustom03.Text;
            createResourceType.s_resource_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createResourceType.s_resource_type_name_custom_04 = txtResourceTypeNameCustom04.Text;
            createResourceType.s_resource_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createResourceType.s_resource_type_name_custom_05 = txtResourceTypeNameCustom05.Text;
            createResourceType.s_resource_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createResourceType.s_resource_type_name_custom_06 = txtResourceTypeNameCustom06.Text;
            createResourceType.s_resource_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createResourceType.s_resource_type_name_custom_07 = txtResourceTypeNameCustom07.Text;
            createResourceType.s_resource_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createResourceType.s_resource_type_name_custom_08 = txtResourceTypeNameCustom08.Text;
            createResourceType.s_resource_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createResourceType.s_resource_type_name_custom_09 = txtResourceTypeNameCustom09.Text;
            createResourceType.s_resource_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createResourceType.s_resource_type_name_custom_10 = txtResourceTypeNameCustom10.Text;
            createResourceType.s_resource_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createResourceType.s_resource_type_name_custom_11 = txtResourceTypeNameCustom11.Text;
            createResourceType.s_resource_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createResourceType.s_resource_type_name_custom_12 = txtResourceTypeNameCustom12.Text;
            createResourceType.s_resource_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createResourceType.s_resource_type_name_custom_13 = txtResourceTypeNameCustom13.Text;
            createResourceType.s_resource_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createResourceType.s_resource_type_name_simp_chinese = txtResourceTypeNameChinese.Text;
            createResourceType.s_resource_type_desc_simp_chinese = txtDescriptionChinese.Value;

            try
            {

                int result = SystemResourceTypeBLL.CreateResourceType(createResourceType);

                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/ResourceTypes/saertn-01.aspx?id=" + SecurityCenter.EncryptText(createResourceType.s_resource_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    
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
                        Logger.WriteToErrorLog("saanrtn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanrtn-01", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Populate the Resource values
        /// </summary>
        /// <param name="editResourceId"></param>
        void PoulateResource(string editResourceId)
        {
            SystemResourceType resourceTypes = new SystemResourceType();
            resourceTypes = SystemResourceTypeBLL.GetResourceTypesbyId(editResourceId);

            txtResourceTypeId.Text = resourceTypes.s_resource_type_id + "_Copy";
            ddlStatus.SelectedValue = resourceTypes.s_resource_type_status_id_fk;
            txtResourceTypeName.Text = resourceTypes.s_resource_type_name_us_english;
            txtDescriptionUS.Value = resourceTypes.s_resource_type_desc_us_english;
            txtResourceTypeNameUK.Text = resourceTypes.s_resource_type_name_uk_english;
            txtDescriptionUK.Value = resourceTypes.s_resource_type_desc_uk_english;
            txtResourceTypeNameCA.Text = resourceTypes.s_resource_type_name_ca_french;
            txtDescriptionCA.Value = resourceTypes.s_resource_type_desc_ca_french;
            txtResourceTypeNameFR.Text = resourceTypes.s_resource_type_name_fr_french;
            txtDescriptionFR.Value = resourceTypes.s_resource_type_desc_fr_french;
            txtResourceTypeNameMX.Text = resourceTypes.s_resource_type_name_mx_spanish;
            txtDescriptionMX.Value = resourceTypes.s_resource_type_desc_mx_spanish;
            txtResourceTypeNameSP.Text = resourceTypes.s_resource_type_name_sp_spanish;
            txtDescriptionSP.Value = resourceTypes.s_resource_type_desc_sp_spanish;
            txtResourceTypeNamePortuguse.Text = resourceTypes.s_resource_type_name_portuguese;
            txtDescriptionPortuguese.Value = resourceTypes.s_resource_type_desc_portuguese;
            txtResourceTypeNameGerman.Text = resourceTypes.s_resource_type_name_german;
            txtDescriptionGerman.Value = resourceTypes.s_resource_type_desc_german;
            txtResourceTypeNameJapanese.Text = resourceTypes.s_resource_type_name_japanese;
            txtDescriptionJapanese.Value = resourceTypes.s_resource_type_desc_japanese;
            txtResourceTypeNameRussian.Text = resourceTypes.s_resource_type_name_russian;
            txtDescriptionRussian.Value = resourceTypes.s_resource_type_desc_russian;
            txtResourceTypeNameDanish.Text = resourceTypes.s_resource_type_name_danish;
            txtDescriptionDanish.Value = resourceTypes.s_resource_type_desc_danish;
            txtResourceTypeNamePolish.Text = resourceTypes.s_resource_type_name_polish;
            txtDescriptionPolish.Value = resourceTypes.s_resource_type_desc_polish;
            txtResourceTypeNameSwedish.Text = resourceTypes.s_resource_type_name_swedish;
            txtDescriptionSwedish.Value = resourceTypes.s_resource_type_desc_swedish;
            txtResourceTypeNameFinnish.Text = resourceTypes.s_resource_type_name_finnish;
            txtDescriptionFinnish.Value = resourceTypes.s_resource_type_desc_finnish;
            txtResourceTypeNameKorean.Text = resourceTypes.s_resource_type_name_korean;
            txtDescriptionKorean.Value = resourceTypes.s_resource_type_desc_korean;
            txtResourceTypeNameItalian.Text = resourceTypes.s_resource_type_name_italian;
            txtDescriptionItalian.Value = resourceTypes.s_resource_type_desc_italian;
            txtResourceTypeNameDutch.Text = resourceTypes.s_resource_type_name_dutch;
            txtDescriptionDutch.Value = resourceTypes.s_resource_type_desc_dutch;
            txtResourceTypeNameIndonesian.Text = resourceTypes.s_resource_type_name_indonesian;
            txtDescriptionIndonesian.Value = resourceTypes.s_resource_type_desc_indonesian;
            txtResourceTypeNameGreek.Text = resourceTypes.s_resource_type_name_greek;
            txtDescriptionGreek.Value = resourceTypes.s_resource_type_desc_greek;
            txtResourceTypeNameHungarian.Text = resourceTypes.s_resource_type_name_hungarian;
            txtDescriptionHungarian.Value = resourceTypes.s_resource_type_desc_hungarian;
            txtResourceTypeNameNorwegian.Text = resourceTypes.s_resource_type_name_norwegian;
            txtDescriptionNorwegian.Value = resourceTypes.s_resource_type_desc_norwegian;
            txtResourceTypeNameTurkish.Text = resourceTypes.s_resource_type_name_turkish;
            txtDescriptionTurkish.Value = resourceTypes.s_resource_type_desc_turkish;
            txtResourceTypeNameArabic.Text = resourceTypes.s_resource_type_name_arabic_rtl;
            txtDescriptionArabic.Value = resourceTypes.s_resource_type_desc_arabic_rtl;
            txtResourceTypeNameCustom01.Text = resourceTypes.s_resource_type_name_custom_01;
            txtDescriptionCustom01.Value = resourceTypes.s_resource_type_desc_custom_01;
            txtResourceTypeNameCustom02.Text = resourceTypes.s_resource_type_name_custom_01;
            txtDescriptionCustom02.Value = resourceTypes.s_resource_type_desc_custom_02;
            txtResourceTypeNameCustom03.Text = resourceTypes.s_resource_type_name_custom_03;
            txtDescriptionCustom03.Value = resourceTypes.s_resource_type_desc_custom_03;
            txtResourceTypeNameCustom04.Text = resourceTypes.s_resource_type_name_custom_04;
            txtDescriptionCustom04.Value = resourceTypes.s_resource_type_desc_custom_04;
            txtResourceTypeNameCustom05.Text = resourceTypes.s_resource_type_name_custom_05;
            txtDescriptionCustom05.Value = resourceTypes.s_resource_type_desc_custom_05;
            txtResourceTypeNameCustom06.Text = resourceTypes.s_resource_type_name_custom_06;
            txtDescriptionCustom06.Value = resourceTypes.s_resource_type_desc_custom_06;
            txtResourceTypeNameCustom07.Text = resourceTypes.s_resource_type_name_custom_07;
            txtDescriptionCustom07.Value = resourceTypes.s_resource_type_desc_custom_07;
            txtResourceTypeNameCustom08.Text = resourceTypes.s_resource_type_name_custom_08;
            txtDescriptionCustom08.Value = resourceTypes.s_resource_type_name_custom_08;
            txtResourceTypeNameCustom09.Text = resourceTypes.s_resource_type_name_custom_09;
            txtDescriptionCustom09.Value = resourceTypes.s_resource_type_desc_custom_09;
            txtResourceTypeNameCustom10.Text = resourceTypes.s_resource_type_name_custom_10;
            txtDescriptionCustom10.Value = resourceTypes.s_resource_type_desc_custom_10;
            txtResourceTypeNameCustom11.Text = resourceTypes.s_resource_type_name_custom_11;
            txtDescriptionCustom11.Value = resourceTypes.s_resource_type_name_custom_11;
            txtResourceTypeNameCustom12.Text = resourceTypes.s_resource_type_name_custom_12;
            txtDescriptionCustom12.Value = resourceTypes.s_resource_type_desc_custom_12;
            txtResourceTypeNameCustom13.Text = resourceTypes.s_resource_type_name_custom_13;
            txtDescriptionCustom13.Value = resourceTypes.s_resource_type_desc_custom_13;
            txtResourceTypeNameChinese.Text = resourceTypes.s_resource_type_name_simp_chinese;
            txtDescriptionChinese.Value = resourceTypes.s_resource_type_desc_simp_chinese;
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }         
    }
}