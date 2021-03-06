﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.EmployeeTypes
{
    public partial class saanetn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/EmployeeTypes/sametmp-01.aspx>" + LocalResources.GetLabel("app_manage_employee_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_employee_type_text") + "</a>";


                try
                {
                    ddlStatus.DataSource = SystemEmployeeTypesBLL.GetEmployeeStatus(SessionWrapper.CultureName, "saanetn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateEmployeeType(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
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
                            Logger.WriteToErrorLog("saanetn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saanetn-01", ex.Message);
                        }
                    }

                }
            }
        }
        private void SaveEmployeeTypes()
        {
            SystemEmployeeType createEmployee = new SystemEmployeeType();
            createEmployee.s_employee_type_system_id_pk = Guid.NewGuid().ToString();
            createEmployee.s_employee_type_id = txtEmployeeTypeId.Text;
            createEmployee.s_employee_type_status_id_fk = ddlStatus.SelectedValue;
            createEmployee.s_employee_type_name_us_english = txtEmployeeTypeName.Text;
            createEmployee.s_employee_type_desc_us_english = txtDescriptionUS.Value;
            createEmployee.s_employee_type_name_uk_english = txtEmployeetypeNameUK.Text;
            createEmployee.s_employee_type_desc_uk_english = txtDecriptionUK.Value;
            createEmployee.s_employee_type_name_ca_french = txtEmployeeTypeNameCA.Text;
            createEmployee.s_employee_type_desc_ca_french = txtDecriptionCA.Value;
            createEmployee.s_employee_type_name_fr_french = txtEmployeeTypeNameFR.Text;
            createEmployee.s_employee_type_desc_fr_french = txtDescriptionFR.Value;
            createEmployee.s_employee_type_name_mx_spanish = txtEmployeetypeNameMX.Text;
            createEmployee.s_employee_type_desc_mx_spanish = txtDescriptionMX.Value;
            createEmployee.s_employee_type_name_sp_spanish = txtEmployeetypeNameSP.Text;
            createEmployee.s_employee_type_desc_sp_spanish = txtDescriptionSP.Value;
            createEmployee.s_employee_type_name_portuguese = txtEmployeetypeNamePortuguse.Text;
            createEmployee.s_employee_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createEmployee.s_employee_type_name_german = txtEmployeetypeNameGerman.Text;
            createEmployee.s_employee_type_desc_german = txtDescriptionGerman.Value;
            createEmployee.s_employee_type_name_japanese = txtEmployeetypeNameJapanese.Text;
            createEmployee.s_employee_type_desc_japanese = txtDescriptionJapanese.Value;
            createEmployee.s_employee_type_name_russian = txtEmployeetypeNameRussian.Text;
            createEmployee.s_employee_type_desc_russian = txtDescriptionRussian.Value;
            createEmployee.s_employee_type_name_danish = txtEmployeetypeNameDanish.Text;
            createEmployee.s_employee_type_desc_danish = txtDescriptionDanish.Value;
            createEmployee.s_employee_type_name_polish = txtEmployeetypeNamePolish.Text;
            createEmployee.s_employee_type_desc_polish = txtDescriptionPolish.Value;
            createEmployee.s_employee_type_name_swedish = txtEmployeetypeNameSwedish.Text;
            createEmployee.s_employee_type_desc_swedish = txtDescriptionSwedish.Value;
            createEmployee.s_employee_type_name_finnish = txtEmployeetypeNameFinnish.Text;
            createEmployee.s_employee_type_desc_finnish = txtDescriptionFinnish.Value;
            createEmployee.s_employee_type_name_korean = txtEmployeetypeNameKorean.Text;
            createEmployee.s_employee_type_desc_korean = txtDescriptionKorian.Value;
            createEmployee.s_employee_type_name_italian = txtEmployeetypeNameItalian.Text;
            createEmployee.s_employee_type_desc_italian = txtDescriptionItalian.Value;
            createEmployee.s_employee_type_name_dutch = txtEmployeetypeNameDutch.Text;
            createEmployee.s_employee_type_desc_dutch = txtDescriptionDutch.Value;
            createEmployee.s_employee_type_name_indonesian = txtEmployeetypeNameIndonesian.Text;
            createEmployee.s_employee_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createEmployee.s_employee_type_name_greek = txtEmployeetypeNameGreek.Text;
            createEmployee.s_employee_type_desc_greek = txtDescriptionGreek.Value;
            createEmployee.s_employee_type_name_hungarian = txtEmployeetypeNameHungarian.Text;
            createEmployee.s_employee_type_desc_hungarian = txtDescriptionHungarian.Value;
            createEmployee.s_employee_type_name_norwegian = txtEmployeetypeNameNorwegian.Text;
            createEmployee.s_employee_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createEmployee.s_employee_type_name_turkish = txtEmployeetypeNameTurkish.Text;
            createEmployee.s_employee_type_desc_turkish = txtDescriptionTurkish.Value;
            createEmployee.s_employee_type_name_arabic_rtl = txtEmployeetypeNameArabic.Text;
            createEmployee.s_employee_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createEmployee.s_employee_type_name_custom_01 = txtEmployeetypeNameCustom01.Text;
            createEmployee.s_employee_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createEmployee.s_employee_type_name_custom_02 = txtEmployeetypeNameCustom02.Text;
            createEmployee.s_employee_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createEmployee.s_employee_type_name_custom_03 = txtEmployeetypeNameCustom03.Text;
            createEmployee.s_employee_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createEmployee.s_employee_type_name_custom_04 = txtEmployeetypeNameCustom04.Text;
            createEmployee.s_employee_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createEmployee.s_employee_type_name_custom_05 = txtEmployeetypeNameCustom05.Text;
            createEmployee.s_employee_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createEmployee.s_employee_type_name_custom_06 = txtEmployeetypeNameCustom06.Text;
            createEmployee.s_employee_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createEmployee.s_employee_type_name_custom_07 = txtEmployeetypeNameCustom07.Text;
            createEmployee.s_employee_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createEmployee.s_employee_type_name_custom_08 = txtEmployeetypeNameCustom08.Text;
            createEmployee.s_employee_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createEmployee.s_employee_type_name_custom_09 = txtEmployeetypeNameCustom09.Text;
            createEmployee.s_employee_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createEmployee.s_employee_type_name_custom_10 = txtEmployeetypeNameCustom10.Text;
            createEmployee.s_employee_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createEmployee.s_employee_type_name_custom_11 = txtEmployeetypeNameCustom11.Text;
            createEmployee.s_employee_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createEmployee.s_employee_type_name_custom_12 = txtEmployeetypeNameCustom12.Text;
            createEmployee.s_employee_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createEmployee.s_employee_type_name_custom_13 = txtEmployeetypeNameCustom13.Text;
            createEmployee.s_employee_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createEmployee.s_employee_type_name_simp_chinese = txtEmployeetypeNameChinese.Text;
            createEmployee.s_employee_type_desc_simp_chinese = txtDescriptionChinese.Value;
            int error;
            error = SystemEmployeeTypesBLL.CreateEmployeeTypes(createEmployee);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/EmployeeTypes/saeetn-01.aspx?id=" + SecurityCenter.EncryptText(createEmployee.s_employee_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            else
            {
                ///<summary>
                ///Show error message 
                ///</summary>
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_emp_type_id_already_exists_error_text");
            }


        }

        protected void btnFooterSaveNewEmployeeType_Click(object sender, EventArgs e)
        {
            SaveEmployeeTypes();
        }

        protected void btnHeaderSaveNewEmployeeType_Click(object sender, EventArgs e)
        {
            SaveEmployeeTypes();
        }

        private void PopulateEmployeeType(string EmployeeTypesId)
        {
            SystemEmployeeType employeeTypes = new SystemEmployeeType();
            employeeTypes = SystemEmployeeTypesBLL.GetEmployeeType(EmployeeTypesId);
            txtEmployeeTypeId.Text = employeeTypes.s_employee_type_id + "_Copy";
            ddlStatus.SelectedValue = employeeTypes.s_employee_type_status_id_fk;
            txtEmployeeTypeName.Text = employeeTypes.s_employee_type_name_us_english;
            txtDescriptionUS.Value = employeeTypes.s_employee_type_desc_us_english;
            txtEmployeetypeNameUK.Text = employeeTypes.s_employee_type_name_uk_english;
            txtDecriptionUK.Value = employeeTypes.s_employee_type_desc_uk_english;
            txtEmployeeTypeNameCA.Text = employeeTypes.s_employee_type_name_ca_french;
            txtDecriptionCA.Value = employeeTypes.s_employee_type_desc_ca_french;
            txtEmployeeTypeNameFR.Text = employeeTypes.s_employee_type_name_fr_french;
            txtDescriptionFR.Value = employeeTypes.s_employee_type_desc_fr_french;
            txtEmployeetypeNameMX.Text = employeeTypes.s_employee_type_name_mx_spanish;
            txtDescriptionMX.Value = employeeTypes.s_employee_type_desc_mx_spanish;
            txtEmployeetypeNameSP.Text = employeeTypes.s_employee_type_name_sp_spanish;
            txtDescriptionSP.Value = employeeTypes.s_employee_type_desc_sp_spanish;
            txtEmployeetypeNamePortuguse.Text = employeeTypes.s_employee_type_name_portuguese;
            txtDescriptionPortuguese.Value = employeeTypes.s_employee_type_desc_portuguese;
            txtEmployeetypeNameGerman.Text = employeeTypes.s_employee_type_name_german;
            txtDescriptionGerman.Value = employeeTypes.s_employee_type_desc_german;
            txtEmployeetypeNameJapanese.Text = employeeTypes.s_employee_type_name_japanese;
            txtDescriptionJapanese.Value = employeeTypes.s_employee_type_desc_japanese;
            txtEmployeetypeNameRussian.Text = employeeTypes.s_employee_type_name_russian;
            txtDescriptionRussian.Value = employeeTypes.s_employee_type_desc_russian;
            txtEmployeetypeNameDanish.Text = employeeTypes.s_employee_type_name_danish;
            txtDescriptionDanish.Value = employeeTypes.s_employee_type_desc_danish;
            txtEmployeetypeNamePolish.Text = employeeTypes.s_employee_type_name_polish;
            txtDescriptionPolish.Value = employeeTypes.s_employee_type_desc_polish;
            txtEmployeetypeNameSwedish.Text = employeeTypes.s_employee_type_name_swedish;
            txtDescriptionSwedish.Value = employeeTypes.s_employee_type_desc_swedish;
            txtEmployeetypeNameFinnish.Text = employeeTypes.s_employee_type_name_finnish;
            txtDescriptionFinnish.Value = employeeTypes.s_employee_type_desc_finnish;
            txtEmployeetypeNameKorean.Text = employeeTypes.s_employee_type_name_korean;
            txtDescriptionKorian.Value = employeeTypes.s_employee_type_desc_korean;
            txtEmployeetypeNameItalian.Text = employeeTypes.s_employee_type_name_italian;
            txtDescriptionItalian.Value = employeeTypes.s_employee_type_desc_italian;
            txtEmployeetypeNameDutch.Text = employeeTypes.s_employee_type_name_dutch;
            txtDescriptionDutch.Value = employeeTypes.s_employee_type_desc_dutch;
            txtEmployeetypeNameIndonesian.Text = employeeTypes.s_employee_type_name_indonesian;
            txtDescriptionIndonesian.Value = employeeTypes.s_employee_type_desc_indonesian;
            txtEmployeetypeNameGreek.Text = employeeTypes.s_employee_type_name_greek;
            txtDescriptionGreek.Value = employeeTypes.s_employee_type_desc_greek;
            txtEmployeetypeNameHungarian.Text = employeeTypes.s_employee_type_name_hungarian;
            txtDescriptionHungarian.Value = employeeTypes.s_employee_type_desc_hungarian;
            txtEmployeetypeNameNorwegian.Text = employeeTypes.s_employee_type_name_norwegian;
            txtDescriptionNorwegian.Value = employeeTypes.s_employee_type_desc_norwegian;
            txtEmployeetypeNameTurkish.Text = employeeTypes.s_employee_type_name_turkish;
            txtDescriptionTurkish.Value = employeeTypes.s_employee_type_desc_turkish;
            txtEmployeetypeNameArabic.Text = employeeTypes.s_employee_type_name_arabic_rtl;
            txtDescriptionArabic.Value = employeeTypes.s_employee_type_desc_arabic_rtl;
            txtEmployeetypeNameCustom01.Text = employeeTypes.s_employee_type_name_custom_01;
            txtDescriptionCustom01.Value = employeeTypes.s_employee_type_desc_custom_01;
            txtEmployeetypeNameCustom02.Text = employeeTypes.s_employee_type_name_custom_01;
            txtDescriptionCustom02.Value = employeeTypes.s_employee_type_desc_custom_02;
            txtEmployeetypeNameCustom03.Text = employeeTypes.s_employee_type_name_custom_03;
            txtDescriptionCustom03.Value = employeeTypes.s_employee_type_desc_custom_03;
            txtEmployeetypeNameCustom04.Text = employeeTypes.s_employee_type_name_custom_04;
            txtDescriptionCustom04.Value = employeeTypes.s_employee_type_desc_custom_04;
            txtEmployeetypeNameCustom05.Text = employeeTypes.s_employee_type_name_custom_05;
            txtDescriptionCustom05.Value = employeeTypes.s_employee_type_desc_custom_05;
            txtEmployeetypeNameCustom06.Text = employeeTypes.s_employee_type_name_custom_06;
            txtDescriptionCustom06.Value = employeeTypes.s_employee_type_desc_custom_06;
            txtEmployeetypeNameCustom07.Text = employeeTypes.s_employee_type_name_custom_07;
            txtDescriptionCustom07.Value = employeeTypes.s_employee_type_desc_custom_07;
            txtEmployeetypeNameCustom08.Text = employeeTypes.s_employee_type_name_custom_08;
            txtDescriptionCustom08.Value = employeeTypes.s_employee_type_name_custom_08;
            txtEmployeetypeNameCustom09.Text = employeeTypes.s_employee_type_name_custom_09;
            txtDescriptionCustom09.Value = employeeTypes.s_employee_type_desc_custom_09;
            txtEmployeetypeNameCustom10.Text = employeeTypes.s_employee_type_name_custom_10;
            txtDescriptionCustom10.Value = employeeTypes.s_employee_type_desc_custom_10;
            txtEmployeetypeNameCustom11.Text = employeeTypes.s_employee_type_name_custom_11;
            txtDescriptionCustom11.Value = employeeTypes.s_employee_type_name_custom_11;
            txtEmployeetypeNameCustom12.Text = employeeTypes.s_employee_type_name_custom_12;
            txtDescriptionCustom12.Value = employeeTypes.s_employee_type_desc_custom_12;
            txtEmployeetypeNameCustom13.Text = employeeTypes.s_employee_type_name_custom_13;
            txtDescriptionCustom13.Value = employeeTypes.s_employee_type_desc_custom_13;
            txtEmployeetypeNameChinese.Text = employeeTypes.s_employee_type_name_simp_chinese;
            txtDescriptionChinese.Value = employeeTypes.s_employee_type_desc_simp_chinese;

        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/EmployeeTypes/sametmp-01.aspx", false);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/EmployeeTypes/sametmp-01.aspx", false);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}