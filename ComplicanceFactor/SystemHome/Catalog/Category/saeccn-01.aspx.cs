using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Category
{
    public partial class saeccn_01 : BasePage
    {
        private static string editCategoryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get category Id
            if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
            {
                editCategoryId = SecurityCenter.DecryptText(Request.QueryString["edt"]);
            }
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Category/samccmp-01.aspx>" + LocalResources.GetLabel("app_manage_category_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_category_text");

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                ///<summary>
                //Get Category id
                /// </summary>
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editCategoryId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdCategoryId.Value = editCategoryId;

                }
                // Bind Parent Category
                ddlParentCategory.DataSource = SystemCategoriesBLL.GetParentCategory(SessionWrapper.CultureName);
                ddlParentCategory.DataBind();
                ListItem itemToRemove = ddlParentCategory.Items.FindByValue("app_ddl_all_text");
                ddlParentCategory.Items.Remove(itemToRemove);
                // Bind Status
                ddlStatus.DataSource = SystemCategoriesBLL.GetStatus(SessionWrapper.CultureName,"saeccn-01");
                ddlStatus.DataBind();
                //Populate Categories
                PopulateCategories(editCategoryId);
                
            }
        }

        private void PopulateCategories(string CategoryId)
        {
            SystemCategories categories = new SystemCategories();
            categories = SystemCategoriesBLL.GetCategories(CategoryId);

            txtCategoryId.Text = categories.s_category_id;
            ddlStatus.SelectedValue = categories.s_category_status_id_fk;
            ddlParentCategory.SelectedValue = categories.s_parent_category_id;
            if (!string.IsNullOrEmpty(categories.s_parent_category_id))
            {
                chkParentCategory.Checked = true;
            }

            txtCategoryName.Text = categories.s_category_name_us_english;
            txtDescription.Value = categories.s_category_desc_us_english;
            txtCategoryNameUK.Text = categories.s_category_name_uk_english;
            txtDecriptionUK.Value = categories.s_category_desc_uk_english;
            txtCategoryNameCA.Text = categories.s_category_name_ca_french;
            txtDecriptionCA.Value = categories.s_category_desc_ca_french;
            txtCategoryNameFR.Text = categories.s_category_name_fr_french;
            txtDescriptionFR.Value = categories.s_category_desc_fr_french;
            txtCategoryNameMX.Text = categories.s_category_name_mx_spanish;
            txtDescriptionMX.Value = categories.s_category_desc_mx_spanish;
            txtCategoryNameSP.Text = categories.s_category_name_sp_spanish;
            txtDescriptionSP.Value = categories.s_category_desc_sp_spanish;
            txtCategoryNamePortuguse.Text = categories.s_category_name_portuguese;
            txtDescriptionPortuguese.Value = categories.s_category_desc_portuguese;
            txtCategoryNameGerman.Text = categories.s_category_name_german;
            txtDescriptionGerman.Value = categories.s_category_desc_german;
            txtCategoryNameJapanese.Text = categories.s_category_name_japanese;
            txtDescriptionJapanese.Value = categories.s_category_desc_japanese;
            txtCategoryNameRussian.Text = categories.s_category_name_russian;
            txtDescriptionRussian.Value = categories.s_category_desc_russian;
            txtCategoryNameDanish.Text = categories.s_category_name_danish;
            txtDescriptionDanish.Value = categories.s_category_desc_danish;
            txtCategoryNamePolish.Text = categories.s_category_name_polish;
            txtDescriptionPolish.Value = categories.s_category_desc_polish;
            txtCategoryNameSwedish.Text = categories.s_category_name_swedish;
            txtDescriptionSwedish.Value = categories.s_category_desc_swedish;
            txtCategoryNameFinnish.Text = categories.s_category_name_finnish;
            txtDescriptionFinnish.Value = categories.s_category_desc_finnish;
            txtCategoryNameKorean.Text = categories.s_category_name_korean;
            txtDescriptionKorian.Value = categories.s_category_desc_korean;
            txtCategoryNameItalian.Text = categories.s_category_name_italian;
            txtDescriptionItalian.Value = categories.s_category_desc_italian;
            txtCategoryNameDutch.Text = categories.s_category_name_dutch;
            txtDescriptionDutch.Value = categories.s_category_desc_dutch;
            txtCategoryNameIndonesian.Text = categories.s_category_name_indonesian;
            txtDescriptionIndonesian.Value = categories.s_category_desc_indonesian;
            txtCategoryNameGreek.Text = categories.s_category_name_greek;
            txtDescriptionGreek.Value = categories.s_category_desc_greek;
            txtCategoryNameHungarian.Text = categories.s_category_name_hungarian;
            txtDescriptionHungarian.Value = categories.s_category_desc_hungarian;
            txtCategoryNameNorwegian.Text = categories.s_category_name_norwegian;
            txtDescriptionNorwegian.Value = categories.s_category_desc_norwegian;
            txtCategoryNameTurkish.Text = categories.s_category_name_turkish;
            txtDescriptionTurkish.Value = categories.s_category_desc_turkish;
            txtCategoryNameArabic.Text = categories.s_category_name_arabic_rtl;
            txtDescriptionArabic.Value = categories.s_category_desc_arabic_rtl;
            txtCategoryNameCustom01.Text = categories.s_category_name_custom_01;
            txtDescriptionCustom01.Value = categories.s_category_desc_custom_01;
            txtCategoryNameCustom02.Text = categories.s_category_name_custom_01;
            txtDescriptionCustom02.Value = categories.s_category_desc_custom_02;
            txtCategoryNameCustom03.Text = categories.s_category_name_custom_03;
            txtDescriptionCustom03.Value = categories.s_category_desc_custom_03;
            txtCategoryNameCustom04.Text = categories.s_category_name_custom_04;
            txtDescriptionCustom04.Value = categories.s_category_desc_custom_04;
            txtCategoryNameCustom05.Text = categories.s_category_name_custom_05;
            txtDescriptionCustom05.Value = categories.s_category_desc_custom_05;
            txtCategoryNameCustom06.Text = categories.s_category_name_custom_06;
            txtDescriptionCustom06.Value = categories.s_category_desc_custom_06;
            txtCategoryNameCustom07.Text = categories.s_category_name_custom_07;
            txtDescriptionCustom07.Value = categories.s_category_desc_custom_07;
            txtCategoryNameCustom08.Text = categories.s_category_name_custom_08;
            txtDescriptionCustom08.Value = categories.s_category_name_custom_08;
            txtCategoryNameCustom09.Text = categories.s_category_name_custom_09;
            txtDescriptionCustom09.Value = categories.s_category_desc_custom_09;
            txtCategoryNameCustom10.Text = categories.s_category_name_custom_10;
            txtDescriptionCustom10.Value = categories.s_category_desc_custom_10;
            txtCategoryNameCustom11.Text = categories.s_category_name_custom_11;
            txtDescriptionCustom11.Value = categories.s_category_name_custom_11;
            txtCategoryNameCustom12.Text = categories.s_category_name_custom_12;
            txtDescriptionCustom12.Value = categories.s_category_desc_custom_12;
            txtCategoryNameCustom13.Text = categories.s_category_name_custom_13;
            txtDescriptionCustom13.Value = categories.s_category_desc_custom_13;
            txtCategoryNameChinese.Text = categories.s_category_name_simp_chinese;
            txtDescriptionChinese.Value = categories.s_category_desc_simp_chinese;

        
        }

        private void UpdateCategories()
        {
            SystemCategories Updatecategories = new SystemCategories();
            Updatecategories.s_category_system_id_pk = editCategoryId;
            Updatecategories.s_category_id = txtCategoryId.Text;
            
            Updatecategories.s_category_status_id_fk = ddlStatus.SelectedValue;
            if (chkParentCategory.Checked == true)
            {
                Updatecategories.s_parent_category_id = ddlParentCategory.SelectedValue;
                
            }
            else
            {
                Updatecategories.s_parent_category_id = string.Empty;
            }
            Updatecategories.s_category_name_us_english = txtCategoryName.Text;
            Updatecategories.s_category_desc_us_english = txtDescription.Value;

            Updatecategories.s_category_name_uk_english = txtCategoryNameUK.Text;
            Updatecategories.s_category_desc_uk_english = txtDecriptionUK.Value;
            Updatecategories.s_category_name_ca_french = txtCategoryNameCA.Text;
            Updatecategories.s_category_desc_ca_french = txtDecriptionCA.Value;
            Updatecategories.s_category_name_fr_french = txtCategoryNameFR.Text;
            Updatecategories.s_category_desc_fr_french = txtDescriptionFR.Value;
            Updatecategories.s_category_name_mx_spanish = txtCategoryNameMX.Text;
            Updatecategories.s_category_desc_mx_spanish = txtDescriptionMX.Value;
            Updatecategories.s_category_name_sp_spanish = txtCategoryNameSP.Text;
            Updatecategories.s_category_desc_sp_spanish = txtDescriptionSP.Value;
            Updatecategories.s_category_name_portuguese = txtCategoryNamePortuguse.Text;
            Updatecategories.s_category_desc_portuguese = txtDescriptionPortuguese.Value;
            Updatecategories.s_category_name_german = txtCategoryNameGerman.Text;
            Updatecategories.s_category_desc_german = txtDescriptionGerman.Value;
            Updatecategories.s_category_name_japanese = txtCategoryNameJapanese.Text;
            Updatecategories.s_category_desc_japanese = txtDescriptionJapanese.Value;
            Updatecategories.s_category_name_russian = txtCategoryNameRussian.Text;
            Updatecategories.s_category_desc_russian = txtDescriptionRussian.Value;
            Updatecategories.s_category_name_danish = txtCategoryNameDanish.Text;
            Updatecategories.s_category_desc_danish = txtDescriptionDanish.Value;
            Updatecategories.s_category_name_polish = txtCategoryNamePolish.Text;
            Updatecategories.s_category_desc_polish = txtDescriptionPolish.Value;
            Updatecategories.s_category_name_swedish = txtCategoryNameSwedish.Text;
            Updatecategories.s_category_desc_swedish = txtDescriptionSwedish.Value;
            Updatecategories.s_category_name_finnish = txtCategoryNameFinnish.Text;
            Updatecategories.s_category_desc_finnish = txtDescriptionFinnish.Value;
            Updatecategories.s_category_name_korean = txtCategoryNameKorean.Text;
            Updatecategories.s_category_desc_korean = txtDescriptionKorian.Value;
            Updatecategories.s_category_name_italian = txtCategoryNameItalian.Text;
            Updatecategories.s_category_desc_italian = txtDescriptionItalian.Value;
            Updatecategories.s_category_name_dutch = txtCategoryNameDutch.Text;
            Updatecategories.s_category_desc_dutch = txtDescriptionDutch.Value;
            Updatecategories.s_category_name_indonesian = txtCategoryNameIndonesian.Text;
            Updatecategories.s_category_desc_indonesian = txtDescriptionIndonesian.Value;
            Updatecategories.s_category_name_greek = txtCategoryNameGreek.Text;
            Updatecategories.s_category_desc_greek = txtDescriptionGreek.Value;
            Updatecategories.s_category_name_hungarian = txtCategoryNameHungarian.Text;
            Updatecategories.s_category_desc_hungarian = txtDescriptionHungarian.Value;
            Updatecategories.s_category_name_norwegian = txtCategoryNameNorwegian.Text;
            Updatecategories.s_category_desc_norwegian = txtDescriptionNorwegian.Value;
            Updatecategories.s_category_name_turkish = txtCategoryNameTurkish.Text;
            Updatecategories.s_category_desc_turkish = txtDescriptionTurkish.Value;
            Updatecategories.s_category_name_arabic_rtl = txtCategoryNameArabic.Text;
            Updatecategories.s_category_desc_arabic_rtl = txtDescriptionArabic.Value;
            Updatecategories.s_category_name_custom_01 = txtCategoryNameCustom01.Text;
            Updatecategories.s_category_desc_custom_01 = txtDescriptionCustom01.Value;
            Updatecategories.s_category_name_custom_02 = txtCategoryNameCustom02.Text;
            Updatecategories.s_category_desc_custom_02 = txtDescriptionCustom02.Value;
            Updatecategories.s_category_name_custom_03 = txtCategoryNameCustom03.Text;
            Updatecategories.s_category_desc_custom_03 = txtDescriptionCustom03.Value;
            Updatecategories.s_category_name_custom_04 = txtCategoryNameCustom04.Text;
            Updatecategories.s_category_desc_custom_04 = txtDescriptionCustom04.Value;
            Updatecategories.s_category_name_custom_05 = txtCategoryNameCustom05.Text;
            Updatecategories.s_category_desc_custom_05 = txtDescriptionCustom05.Value;
            Updatecategories.s_category_name_custom_06 = txtCategoryNameCustom06.Text;
            Updatecategories.s_category_desc_custom_06 = txtDescriptionCustom06.Value;
            Updatecategories.s_category_name_custom_07 = txtCategoryNameCustom07.Text;
            Updatecategories.s_category_desc_custom_07 = txtDescriptionCustom07.Value;
            Updatecategories.s_category_name_custom_08 = txtCategoryNameCustom08.Text;
            Updatecategories.s_category_desc_custom_08 = txtDescriptionCustom08.Value;
            Updatecategories.s_category_name_custom_09 = txtCategoryNameCustom09.Text;
            Updatecategories.s_category_desc_custom_09 = txtDescriptionCustom09.Value;
            Updatecategories.s_category_name_custom_10 = txtCategoryNameCustom10.Text;
            Updatecategories.s_category_desc_custom_10 = txtDescriptionCustom10.Value;
            Updatecategories.s_category_name_custom_11 = txtCategoryNameCustom11.Text;
            Updatecategories.s_category_desc_custom_11 = txtDescriptionCustom11.Value;
            Updatecategories.s_category_name_custom_12 = txtCategoryNameCustom12.Text;
            Updatecategories.s_category_desc_custom_12 = txtDescriptionCustom12.Value;
            Updatecategories.s_category_name_custom_13 = txtCategoryNameCustom13.Text;
            Updatecategories.s_category_desc_custom_13 = txtDescriptionCustom13.Value;
            Updatecategories.s_category_name_simp_chinese = txtCategoryNameChinese.Text;
            Updatecategories.s_category_desc_simp_chinese = txtDescriptionChinese.Value;

            int error;
            error = SystemCategoriesBLL.UpdateCategories(Updatecategories);
            if (error != -2)
            {
                //Show success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");


            }
            else
            {
                //Show error message 
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_category_id_already_exist_error_wrong");

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
            Response.Redirect("~/SystemHome/Catalog/Category/samccmp-01.aspx", false);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Category/samccmp-01.aspx", false);
        }

        protected void btnHeaderSaveNewCategory_Click(object sender, EventArgs e)
        {
            UpdateCategories();
        }

        protected void btnFooterSaveNewCategory_Click(object sender, EventArgs e)
        {
            UpdateCategories();
        }
    }
}