using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.RoomTypes
{
    public partial class saerotn_01 : BasePage
    {
        string editRoom;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //set edit domain id
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    editRoom = SecurityCenter.DecryptText(Request.QueryString["edit"]);
                }
                if (!IsPostBack)
                {
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx>" + LocalResources.GetLabel("app_manage_Room_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_room_type_text") + "</a>";

                    //Bind domain status
                    ddlStatus.DataSource = SystemRoomTypeBLL.GetStatus(SessionWrapper.CultureName, "saerotn-01");
                    ddlStatus.DataBind();
                     

                    PopulateRoom(editRoom);
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
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
                        Logger.WriteToErrorLog("saerotn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerotn-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnHeaderSaveNewRoomType_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }

        protected void btnFooterSaveNewRoomType_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RoomTypes/samrotmp-01.aspx");
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// Populate value from Room type (table)
        /// </summary>
        /// <param name="editRoomId"></param>
        private void PopulateRoom(string editRoomId)
        {
            SystemRoomType roomType = new SystemRoomType();
            try
            {
                roomType = SystemRoomTypeBLL.GetRoomType(editRoomId);
                txtRoomTypeId.Text = roomType.s_room_type_id;
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
                        Logger.WriteToErrorLog("saerotn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerotn-01", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Update the Room 
        /// </summary>
        private void UpdateRoom()
        {
            SystemRoomType updateRoomType = new SystemRoomType();
            updateRoomType.s_room_type_system_id_pk = editRoom.ToString();
            updateRoomType.s_room_type_id = txtRoomTypeId.Text;
            updateRoomType.s_room_type_status_id_fk = ddlStatus.SelectedValue;
            updateRoomType.s_room_type_name_us_english = txtRoomTypeName.Text;
            updateRoomType.s_room_type_desc_us_english = txtDescriptionUS.Value;
            updateRoomType.s_room_type_name_uk_english = txtRoomTypeNameUK.Text;
            updateRoomType.s_room_type_desc_uk_english = txtDescriptionUK.Value;
            updateRoomType.s_room_type_name_ca_french = txtRoomTypeNameCA.Text;
            updateRoomType.s_room_type_desc_ca_french = txtDescriptionCA.Value;
            updateRoomType.s_room_type_name_fr_french = txtRoomTypeNameFR.Text;
            updateRoomType.s_room_type_desc_fr_french = txtDescriptionFR.Value;
            updateRoomType.s_room_type_name_mx_spanish = txtRoomTypeNameMX.Text;
            updateRoomType.s_room_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateRoomType.s_room_type_name_sp_spanish = txtRoomTypeNameSP.Text;
            updateRoomType.s_room_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateRoomType.s_room_type_name_portuguese = txtRoomTypeNamePortuguse.Text;
            updateRoomType.s_room_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateRoomType.s_room_type_name_german = txtRoomTypeNameGerman.Text;
            updateRoomType.s_room_type_desc_german = txtDescriptionGerman.Value;
            updateRoomType.s_room_type_name_japanese = txtRoomTypeNameJapanese.Text;
            updateRoomType.s_room_type_desc_japanese = txtDescriptionJapanese.Value;
            updateRoomType.s_room_type_name_russian = txtRoomTypeNameRussian.Text;
            updateRoomType.s_room_type_desc_russian = txtDescriptionRussian.Value;
            updateRoomType.s_room_type_name_danish = txtRoomTypeNameDanish.Text;
            updateRoomType.s_room_type_desc_danish = txtDescriptionDanish.Value;
            updateRoomType.s_room_type_name_polish = txtRoomTypeNamePolish.Text;
            updateRoomType.s_room_type_desc_polish = txtDescriptionPolish.Value;
            updateRoomType.s_room_type_name_swedish = txtRoomTypeNameSwedish.Text;
            updateRoomType.s_room_type_desc_swedish = txtDescriptionSwedish.Value;
            updateRoomType.s_room_type_name_finnish = txtRoomTypeNameFinnish.Text;
            updateRoomType.s_room_type_desc_finnish = txtDescriptionFinnish.Value;
            updateRoomType.s_room_type_name_korean = txtRoomTypeNameKorean.Text;
            updateRoomType.s_room_type_desc_korean = txtDescriptionKorean.Value;
            updateRoomType.s_room_type_name_italian = txtRoomTypeNameItalian.Text;
            updateRoomType.s_room_type_desc_italian = txtDescriptionItalian.Value;
            updateRoomType.s_room_type_name_dutch = txtRoomTypeNameDutch.Text;
            updateRoomType.s_room_type_desc_dutch = txtDescriptionDutch.Value;
            updateRoomType.s_room_type_name_indonesian = txtRoomTypeNameIndonesian.Text;
            updateRoomType.s_room_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateRoomType.s_room_type_name_greek = txtRoomTypeNameGreek.Text;
            updateRoomType.s_room_type_desc_greek = txtDescriptionGreek.Value;
            updateRoomType.s_room_type_name_hungarian = txtRoomTypeNameHungarian.Text;
            updateRoomType.s_room_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateRoomType.s_room_type_name_norwegian = txtRoomTypeNameNorwegian.Text;
            updateRoomType.s_room_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateRoomType.s_room_type_name_turkish = txtRoomTypeNameTurkish.Text;
            updateRoomType.s_room_type_desc_turkish = txtDescriptionTurkish.Value;
            updateRoomType.s_room_type_name_arabic_rtl = txtRoomTypeNameArabic.Text;
            updateRoomType.s_room_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateRoomType.s_room_type_name_custom_01 = txtRoomTypeNameCustom01.Text;
            updateRoomType.s_room_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateRoomType.s_room_type_name_custom_02 = txtRoomTypeNameCustom02.Text;
            updateRoomType.s_room_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateRoomType.s_room_type_name_custom_03 = txtRoomTypeNameCustom03.Text;
            updateRoomType.s_room_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateRoomType.s_room_type_name_custom_04 = txtRoomTypeNameCustom04.Text;
            updateRoomType.s_room_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateRoomType.s_room_type_name_custom_05 = txtRoomTypeNameCustom05.Text;
            updateRoomType.s_room_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateRoomType.s_room_type_name_custom_06 = txtRoomTypeNameCustom06.Text;
            updateRoomType.s_room_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateRoomType.s_room_type_name_custom_07 = txtRoomTypeNameCustom07.Text;
            updateRoomType.s_room_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateRoomType.s_room_type_name_custom_08 = txtRoomTypeNameCustom08.Text;
            updateRoomType.s_room_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateRoomType.s_room_type_name_custom_09 = txtRoomTypeNameCustom09.Text;
            updateRoomType.s_room_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateRoomType.s_room_type_name_custom_10 = txtRoomTypeNameCustom10.Text;
            updateRoomType.s_room_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateRoomType.s_room_type_name_custom_11 = txtRoomTypeNameCustom11.Text;
            updateRoomType.s_room_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateRoomType.s_room_type_name_custom_12 = txtRoomTypeNameCustom12.Text;
            updateRoomType.s_room_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateRoomType.s_room_type_name_custom_13 = txtRoomTypeNameCustom13.Text;
            updateRoomType.s_room_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateRoomType.s_room_type_name_simp_chinese = txtRoomTypeNameChinese.Text;
            updateRoomType.s_room_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int result = SystemRoomTypeBLL.UpdateRoomType(updateRoomType);
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
                        Logger.WriteToErrorLog("saerotn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saerotn-01", ex.Message);
                    }
                }
            }
        }
    }
}