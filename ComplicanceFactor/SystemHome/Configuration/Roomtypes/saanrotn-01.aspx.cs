using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.RoomTypes
{
    public partial class saanrotn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx>" + LocalResources.GetLabel("app_manage_Room_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_Room_type_text") + "</a>";
                    //Bind domain status
                    ddlStatus.DataSource = SystemRoomTypeBLL.GetStatus(SessionWrapper.CultureName, "saanrotn-01");
                    ddlStatus.DataBind();

                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                         PopulateRoom(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
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
                        Logger.WriteToErrorLog("saanrotn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanrotn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx");
        }

        protected void btnHeaderSaveNewRoomType_Click(object sender, EventArgs e)
        {
            SaveRoomType();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterSaveNewRoomType_Click(object sender, EventArgs e)
        {
            SaveRoomType();
        }
        /// <summary>
        /// Save the Room values
        /// </summary>
        private void SaveRoomType()
        {
            SystemRoomType createRoomType = new SystemRoomType();
            createRoomType.s_room_type_system_id_pk = Guid.NewGuid().ToString();
            createRoomType.s_room_type_id = txtRoomTypeId.Text;
            createRoomType.s_room_type_status_id_fk = ddlStatus.SelectedValue;
            createRoomType.s_room_type_name_us_english = txtRoomTypeName.Text;
            createRoomType.s_room_type_desc_us_english = txtDescriptionUS.Value;
            createRoomType.s_room_type_name_uk_english = txtRoomTypeNameUK.Text;
            createRoomType.s_room_type_desc_uk_english = txtDescriptionUK.Value;
            createRoomType.s_room_type_name_ca_french = txtRoomTypeNameCA.Text;
            createRoomType.s_room_type_desc_ca_french = txtDescriptionCA.Value;
            createRoomType.s_room_type_name_fr_french = txtRoomTypeNameFR.Text;
            createRoomType.s_room_type_desc_fr_french = txtDescriptionFR.Value;
            createRoomType.s_room_type_name_mx_spanish = txtRoomTypeNameMX.Text;
            createRoomType.s_room_type_desc_mx_spanish = txtDescriptionMX.Value;
            createRoomType.s_room_type_name_sp_spanish = txtRoomTypeNameSP.Text;
            createRoomType.s_room_type_desc_sp_spanish = txtDescriptionSP.Value;
            createRoomType.s_room_type_name_portuguese = txtRoomTypeNamePortuguse.Text;
            createRoomType.s_room_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createRoomType.s_room_type_name_german = txtRoomTypeNameGerman.Text;
            createRoomType.s_room_type_desc_german = txtDescriptionGerman.Value;
            createRoomType.s_room_type_name_japanese = txtRoomTypeNameJapanese.Text;
            createRoomType.s_room_type_desc_japanese = txtDescriptionJapanese.Value;
            createRoomType.s_room_type_name_russian = txtRoomTypeNameRussian.Text;
            createRoomType.s_room_type_desc_russian = txtDescriptionRussian.Value;
            createRoomType.s_room_type_name_danish = txtRoomTypeNameDanish.Text;
            createRoomType.s_room_type_desc_danish = txtDescriptionDanish.Value;
            createRoomType.s_room_type_name_polish = txtRoomTypeNamePolish.Text;
            createRoomType.s_room_type_desc_polish = txtDescriptionPolish.Value;
            createRoomType.s_room_type_name_swedish = txtRoomTypeNameSwedish.Text;
            createRoomType.s_room_type_desc_swedish = txtDescriptionSwedish.Value;
            createRoomType.s_room_type_name_finnish = txtRoomTypeNameFinnish.Text;
            createRoomType.s_room_type_desc_finnish = txtDescriptionFinnish.Value;
            createRoomType.s_room_type_name_korean = txtRoomTypeNameKorean.Text;
            createRoomType.s_room_type_desc_korean = txtDescriptionKorean.Value;
            createRoomType.s_room_type_name_italian = txtRoomTypeNameItalian.Text;
            createRoomType.s_room_type_desc_italian = txtDescriptionItalian.Value;
            createRoomType.s_room_type_name_dutch = txtRoomTypeNameDutch.Text;
            createRoomType.s_room_type_desc_dutch = txtDescriptionDutch.Value;
            createRoomType.s_room_type_name_indonesian = txtRoomTypeNameIndonesian.Text;
            createRoomType.s_room_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createRoomType.s_room_type_name_greek = txtRoomTypeNameGreek.Text;
            createRoomType.s_room_type_desc_greek = txtDescriptionGreek.Value;
            createRoomType.s_room_type_name_hungarian = txtRoomTypeNameHungarian.Text;
            createRoomType.s_room_type_desc_hungarian = txtDescriptionHungarian.Value;
            createRoomType.s_room_type_name_norwegian = txtRoomTypeNameNorwegian.Text;
            createRoomType.s_room_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createRoomType.s_room_type_name_turkish = txtRoomTypeNameTurkish.Text;
            createRoomType.s_room_type_desc_turkish = txtDescriptionTurkish.Value;
            createRoomType.s_room_type_name_arabic_rtl = txtRoomTypeNameArabic.Text;
            createRoomType.s_room_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createRoomType.s_room_type_name_custom_01 = txtRoomTypeNameCustom01.Text;
            createRoomType.s_room_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createRoomType.s_room_type_name_custom_02 = txtRoomTypeNameCustom02.Text;
            createRoomType.s_room_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createRoomType.s_room_type_name_custom_03 = txtRoomTypeNameCustom03.Text;
            createRoomType.s_room_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createRoomType.s_room_type_name_custom_04 = txtRoomTypeNameCustom04.Text;
            createRoomType.s_room_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createRoomType.s_room_type_name_custom_05 = txtRoomTypeNameCustom05.Text;
            createRoomType.s_room_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createRoomType.s_room_type_name_custom_06 = txtRoomTypeNameCustom06.Text;
            createRoomType.s_room_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createRoomType.s_room_type_name_custom_07 = txtRoomTypeNameCustom07.Text;
            createRoomType.s_room_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createRoomType.s_room_type_name_custom_08 = txtRoomTypeNameCustom08.Text;
            createRoomType.s_room_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createRoomType.s_room_type_name_custom_09 = txtRoomTypeNameCustom09.Text;
            createRoomType.s_room_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createRoomType.s_room_type_name_custom_10 = txtRoomTypeNameCustom10.Text;
            createRoomType.s_room_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createRoomType.s_room_type_name_custom_11 = txtRoomTypeNameCustom11.Text;
            createRoomType.s_room_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createRoomType.s_room_type_name_custom_12 = txtRoomTypeNameCustom12.Text;
            createRoomType.s_room_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createRoomType.s_room_type_name_custom_13 = txtRoomTypeNameCustom13.Text;
            createRoomType.s_room_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createRoomType.s_room_type_name_simp_chinese = txtRoomTypeNameChinese.Text;
            createRoomType.s_room_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {

                int result = SystemRoomTypeBLL.CreateRoomType(createRoomType);

                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/RoomTypes/saerotn-01.aspx?edit=" + SecurityCenter.EncryptText(createRoomType.s_room_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
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
                        Logger.WriteToErrorLog("sannrotn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sannrotn-01", ex.Message);
                    }
                }
            }
             

        }
        /// <summary>
        /// Populate the room for Copy
        /// </summary>
        /// <param name="editRoomId"></param>
        private void PopulateRoom(string editRoomId)
        {
            SystemRoomType roomType = new SystemRoomType();
            try
            {
                roomType = SystemRoomTypeBLL.GetRoomType(editRoomId);
                txtRoomTypeId.Text = roomType.s_room_type_id + "_Copy";
                ddlStatus.SelectedValue = roomType.s_room_type_status_id_fk;
                txtRoomTypeName.Text = roomType.s_room_type_name_us_english;
                txtDescriptionUS.Value = roomType.s_room_type_desc_us_english;
                txtRoomTypeNameUK.Text = roomType.s_room_type_name_uk_english;
                txtDescriptionUK.Value = roomType.s_room_type_desc_uk_english;
                txtRoomTypeNameCA.Text = roomType.s_room_type_name_ca_french;
                txtDescriptionCA.Value = roomType.s_room_type_desc_ca_french;
                txtRoomTypeNameFR.Text = roomType.s_room_type_name_fr_french;
                txtDescriptionFR.Value = roomType.s_room_type_desc_fr_french;
                txtRoomTypeNameMX.Text = roomType.s_room_type_name_mx_spanish;
                txtDescriptionMX.Value = roomType.s_room_type_desc_mx_spanish;
                txtRoomTypeNameSP.Text = roomType.s_room_type_name_sp_spanish;
                txtDescriptionSP.Value = roomType.s_room_type_desc_sp_spanish;
                txtRoomTypeNamePortuguse.Text = roomType.s_room_type_name_portuguese;
                txtDescriptionPortuguese.Value = roomType.s_room_type_desc_portuguese;
                txtRoomTypeNameGerman.Text = roomType.s_room_type_name_german;
                txtDescriptionGerman.Value = roomType.s_room_type_desc_german;
                txtRoomTypeNameJapanese.Text = roomType.s_room_type_name_japanese;
                txtDescriptionJapanese.Value = roomType.s_room_type_desc_japanese;
                txtRoomTypeNameRussian.Text = roomType.s_room_type_name_russian;
                txtDescriptionRussian.Value = roomType.s_room_type_desc_russian;
                txtRoomTypeNameDanish.Text = roomType.s_room_type_name_danish;
                txtDescriptionDanish.Value = roomType.s_room_type_desc_danish;
                txtRoomTypeNamePolish.Text = roomType.s_room_type_name_polish;
                txtDescriptionPolish.Value = roomType.s_room_type_desc_polish;
                txtRoomTypeNameSwedish.Text = roomType.s_room_type_name_swedish;
                txtDescriptionSwedish.Value = roomType.s_room_type_desc_swedish;
                txtRoomTypeNameFinnish.Text = roomType.s_room_type_name_finnish;
                txtDescriptionFinnish.Value = roomType.s_room_type_desc_finnish;
                txtRoomTypeNameKorean.Text = roomType.s_room_type_name_korean;
                txtDescriptionKorean.Value = roomType.s_room_type_desc_korean;
                txtRoomTypeNameItalian.Text = roomType.s_room_type_name_italian;
                txtDescriptionItalian.Value = roomType.s_room_type_desc_italian;
                txtRoomTypeNameDutch.Text = roomType.s_room_type_name_dutch;
                txtDescriptionDutch.Value = roomType.s_room_type_desc_dutch;
                txtRoomTypeNameIndonesian.Text = roomType.s_room_type_name_indonesian;
                txtDescriptionIndonesian.Value = roomType.s_room_type_desc_indonesian;
                txtRoomTypeNameGreek.Text = roomType.s_room_type_name_greek;
                txtDescriptionGreek.Value = roomType.s_room_type_desc_greek;
                txtRoomTypeNameHungarian.Text = roomType.s_room_type_name_hungarian;
                txtDescriptionHungarian.Value = roomType.s_room_type_desc_hungarian;
                txtRoomTypeNameNorwegian.Text = roomType.s_room_type_name_norwegian;
                txtDescriptionNorwegian.Value = roomType.s_room_type_desc_norwegian;
                txtRoomTypeNameTurkish.Text = roomType.s_room_type_name_turkish;
                txtDescriptionTurkish.Value = roomType.s_room_type_desc_turkish;
                txtRoomTypeNameArabic.Text = roomType.s_room_type_name_arabic_rtl;
                txtDescriptionArabic.Value = roomType.s_room_type_desc_arabic_rtl;
                txtRoomTypeNameCustom01.Text = roomType.s_room_type_name_custom_01;
                txtDescriptionCustom01.Value = roomType.s_room_type_desc_custom_01;
                txtRoomTypeNameCustom02.Text = roomType.s_room_type_name_custom_01;
                txtDescriptionCustom02.Value = roomType.s_room_type_desc_custom_02;
                txtRoomTypeNameCustom03.Text = roomType.s_room_type_name_custom_03;
                txtDescriptionCustom03.Value = roomType.s_room_type_desc_custom_03;
                txtRoomTypeNameCustom04.Text = roomType.s_room_type_name_custom_04;
                txtDescriptionCustom04.Value = roomType.s_room_type_desc_custom_04;
                txtRoomTypeNameCustom05.Text = roomType.s_room_type_name_custom_05;
                txtDescriptionCustom05.Value = roomType.s_room_type_desc_custom_05;
                txtRoomTypeNameCustom06.Text = roomType.s_room_type_name_custom_06;
                txtDescriptionCustom06.Value = roomType.s_room_type_desc_custom_06;
                txtRoomTypeNameCustom07.Text = roomType.s_room_type_name_custom_07;
                txtDescriptionCustom07.Value = roomType.s_room_type_desc_custom_07;
                txtRoomTypeNameCustom08.Text = roomType.s_room_type_name_custom_08;
                txtDescriptionCustom08.Value = roomType.s_room_type_name_custom_08;
                txtRoomTypeNameCustom09.Text = roomType.s_room_type_name_custom_09;
                txtDescriptionCustom09.Value = roomType.s_room_type_desc_custom_09;
                txtRoomTypeNameCustom10.Text = roomType.s_room_type_name_custom_10;
                txtDescriptionCustom10.Value = roomType.s_room_type_desc_custom_10;
                txtRoomTypeNameCustom11.Text = roomType.s_room_type_name_custom_11;
                txtDescriptionCustom11.Value = roomType.s_room_type_name_custom_11;
                txtRoomTypeNameCustom12.Text = roomType.s_room_type_name_custom_12;
                txtDescriptionCustom12.Value = roomType.s_room_type_desc_custom_12;
                txtRoomTypeNameCustom13.Text = roomType.s_room_type_name_custom_13;
                txtDescriptionCustom13.Value = roomType.s_room_type_desc_custom_13;
                txtRoomTypeNameChinese.Text = roomType.s_room_type_name_simp_chinese;
                txtDescriptionChinese.Value = roomType.s_room_type_desc_simp_chinese;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanrotn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanrotn-01", ex.Message);
                    }
                }
            }
        }
    }
}