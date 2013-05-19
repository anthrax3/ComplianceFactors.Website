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

namespace ComplicanceFactor.SystemHome.Configuration.DocumentTypes
{
    public partial class saedoctn_01 : System.Web.UI.Page
    {
        private static string editDocumentTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vs_saedoctn.Style.Add("display", "none");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>" + "&nbsp;>&nbsp;" + "<a href=/SystemHome/Configuration/DocumentTypes/samdoctmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_document_types") + "</a>" + "&nbsp;>&nbsp;" + LocalResources.GetGlobalLabel("app_edit_document_type_text");
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editDocumentTypeId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                }
                ddlStatus.DataSource = SystemDocumentTypesBLL.GetStatus(SessionWrapper.CultureName, "saedoctn-01");
                ddlStatus.DataBind();
                PopulateDocumentId(editDocumentTypeId);
            }
        }
        private void PopulateDocumentId(string DocumentTypeId)
        {
            SystemDocumentTypes documentType = new SystemDocumentTypes();
            documentType = SystemDocumentTypesBLL.GetDocumentTypeInfo(DocumentTypeId);

            txtDocumentTypeId_EnglishUS.Text = documentType.s_document_type_id;
            txtDocumentTypeName_EnglishUs.Text = documentType.s_document_type_name_us_english;
            txtDocumentTypeDescription_EnglishUs.Text = documentType.s_document_type_desc_us_english;

            ddlStatus.SelectedValue = documentType.s_document_type_status_id_fk;

            txtDocumentTypeName_EnglishUk.Text = documentType.s_document_type_name_uk_english;
            txtDescription_EnglishUk.Text = documentType.s_document_type_desc_uk_english;

            txtDocumentTypeName_FrenchCa.Text = documentType.s_document_type_name_ca_french;
            txtDescription_FrenchCa.Text = documentType.s_document_type_desc_ca_french;

            txtDocumentTypeName_FrenchFr.Text = documentType.s_document_type_name_fr_french;
            txtDescription_FrenchFr.Text = documentType.s_document_type_desc_fr_french;

            txtDocumentTypeName_SpanishMx.Text = documentType.s_document_type_name_mx_spanish;
            txtDescription_SpanishMx.Text = documentType.s_document_type_desc_mx_spanish;

            txtDocumentTypeName_SpanishSp.Text = documentType.s_document_type_name_sp_spanish;
            txtDescription_SpanishSp.Text = documentType.s_document_type_desc_sp_spanish;

            txtDocumentTypeName_Portuguese.Text = documentType.s_document_type_name_portuguese;
            txtDescription_Portuguese.Text = documentType.s_document_type_desc_portuguese;

            txtDocumentTypeName_Chinese.Text = documentType.s_document_type_name_simp_chinese;
            txtDescription_Chinese.Text = documentType.s_document_type_desc_simp_chinese;

            txtDocumentTypeName_German.Text = documentType.s_document_type_name_german;
            txtDescription_German.Text = documentType.s_document_type_desc_german;

            txtDocumentTypeName_Japanese.Text = documentType.s_document_type_name_japanese;
            txtDescription_Japanese.Text = documentType.s_document_type_desc_japanese;

            txtDocumentTypeName_Russian.Text = documentType.s_document_type_name_russian;
            txtDescription_Russian.Text = documentType.s_document_type_desc_russian;

            txtDocumentTypeName_Danish.Text = documentType.s_document_type_name_danish;
            txtDescription_Danish.Text = documentType.s_document_type_desc_danish;

            txtDocumentTypeName_Polish.Text = documentType.s_document_type_name_polish;
            txtDescription_Polish.Text = documentType.s_document_type_desc_polish;

            txtDocumentTypeName_Swedish.Text = documentType.s_document_type_name_swedish;
            txtDescription_Swedish.Text = documentType.s_document_type_desc_swedish;

            txtDocumentTypeName_Finnish.Text = documentType.s_document_type_name_finnish;
            txtDescription_Finnish.Text = documentType.s_document_type_desc_finnish;

            txtDocumentTypeName_Korean.Text = documentType.s_document_type_name_korean;
            txtDescription_Korean.Text = documentType.s_document_type_desc_korean;

            txtDocumentTypeName_Italian.Text = documentType.s_document_type_name_italian;
            txtDescription_Italian.Text = documentType.s_document_type_desc_italian;

            txtDocumentTypeName_Dutch.Text = documentType.s_document_type_name_dutch;
            txtDescription_Dutch.Text = documentType.s_document_type_desc_dutch;

            txtDocumentTypeName_Indonesian.Text = documentType.s_document_type_name_indonesian;
            txtDescription_Indonesian.Text = documentType.s_document_type_desc_indonesian;

            txtDocumentTypeName_Greek.Text = documentType.s_document_type_name_greek;
            txtDescription_Greek.Text = documentType.s_document_type_desc_greek;

            txtDcoumentTypeName_Hungarian.Text = documentType.s_document_type_name_hungarian;
            txtDescription_Hungarian.Text = documentType.s_document_type_desc_hungarian;

            txtDocumentTypeName_Norwegian.Text = documentType.s_document_type_name_norwegian;
            txtDescription_Norwegian.Text = documentType.s_document_type_desc_norwegian;

            txtDocumentTypeName_Turkish.Text = documentType.s_document_type_name_turkish;
            txtDescription_Turkish.Text = documentType.s_document_type_desc_turkish;

            txtDocumentTypeName_Arabic.Text = documentType.s_document_type_name_arabic_rtl;
            txtDescription_Arabic.Text = documentType.s_document_type_desc_arabic_rtl;

            txtDocumentTypeName_Custom01.Text = documentType.s_document_type_name_custom_01;
            txtDescription_Custom01.Text = documentType.s_document_type_desc_custom_01;

            txtDocumentTypeName_Custom02.Text = documentType.s_document_type_name_custom_02;
            txtDescription_Custom02.Text = documentType.s_document_type_desc_custom_02;

            txtDocumentTypeName_Custom03.Text = documentType.s_document_type_name_custom_03;
            txtDescription_Custom03.Text = documentType.s_document_type_desc_custom_03;

            txtDocumentTypeName_Custom04.Text = documentType.s_document_type_name_custom_04;
            txtDescription_Custom04.Text = documentType.s_document_type_desc_custom_04;

            txtDocumentTypeName_Custom05.Text = documentType.s_document_type_name_custom_05;
            txtDescription_Custom05.Text = documentType.s_document_type_desc_custom_05;

            txtDocumentTypeName_Custom06.Text = documentType.s_document_type_name_custom_06;
            txtDescription_Custom06.Text = documentType.s_document_type_desc_custom_06;

            txtDocumentTypeName_Custom07.Text = documentType.s_document_type_name_custom_07;
            txtDescription_Custom07.Text = documentType.s_document_type_desc_custom_07;

            txtDocumentTypeName_Custom08.Text = documentType.s_document_type_name_custom_08;
            txtDescription_Custom08.Text = documentType.s_document_type_desc_custom_08;

            txtDocumentTypeName_Custom09.Text = documentType.s_document_type_name_custom_09;
            txtDescription_Custom09.Text = documentType.s_document_type_desc_custom_09;

            txtDocumentTypeName_Custom10.Text = documentType.s_document_type_name_custom_10;
            txtDescription_Custom10.Text = documentType.s_document_type_desc_custom_10;

            txtDocumentTypeName_Custom11.Text = documentType.s_document_type_name_custom_11;
            txtDescription_Custom11.Text = documentType.s_document_type_desc_custom_11;

            txtDocumentTypeName_Custom12.Text = documentType.s_document_type_name_custom_12;
            txtDescription_Custom12.Text = documentType.s_document_type_desc_custom_12;

            txtDocumentTypeName_Custom13.Text = documentType.s_document_type_name_custom_13;
            txtDescription_Custom13.Text = documentType.s_document_type_desc_custom_13;

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DocumentTypes/samdoctmp-01.aspx");
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            UpdateDocumentType();
        }

        private void UpdateDocumentType()
        {
            int error;
            SystemDocumentTypes updateDocumentType = new SystemDocumentTypes();
            updateDocumentType.s_document_type_system_id_pk = editDocumentTypeId;
            updateDocumentType.s_document_type_id = txtDocumentTypeId_EnglishUS.Text;
            updateDocumentType.s_document_type_status_id_fk = ddlStatus.SelectedItem.Value;
            updateDocumentType.s_document_type_name_us_english = txtDocumentTypeName_EnglishUs.Text;
            updateDocumentType.s_document_type_desc_us_english = txtDocumentTypeDescription_EnglishUs.Text;
            updateDocumentType.s_document_type_name_uk_english = txtDocumentTypeName_EnglishUk.Text;
            updateDocumentType.s_document_type_desc_uk_english = txtDescription_EnglishUk.Text;
            updateDocumentType.s_document_type_name_ca_french = txtDocumentTypeName_FrenchCa.Text;
            updateDocumentType.s_document_type_desc_ca_french = txtDescription_FrenchCa.Text;
            updateDocumentType.s_document_type_name_fr_french = txtDocumentTypeName_FrenchFr.Text;
            updateDocumentType.s_document_type_desc_fr_french = txtDescription_FrenchFr.Text;
            updateDocumentType.s_document_type_name_mx_spanish = txtDocumentTypeName_SpanishMx.Text;
            updateDocumentType.s_document_type_desc_mx_spanish = txtDescription_SpanishMx.Text;
            updateDocumentType.s_document_type_name_sp_spanish = txtDocumentTypeName_SpanishSp.Text;
            updateDocumentType.s_document_type_desc_sp_spanish = txtDescription_SpanishSp.Text;
            updateDocumentType.s_document_type_name_portuguese = txtDocumentTypeName_Portuguese.Text;
            updateDocumentType.s_document_type_desc_portuguese = txtDescription_Portuguese.Text;
            updateDocumentType.s_document_type_name_simp_chinese = txtDocumentTypeName_Chinese.Text;
            updateDocumentType.s_document_type_desc_simp_chinese = txtDescription_Chinese.Text;
            updateDocumentType.s_document_type_name_german = txtDocumentTypeName_German.Text;
            updateDocumentType.s_document_type_desc_german = txtDescription_German.Text;
            updateDocumentType.s_document_type_name_japanese = txtDocumentTypeName_Japanese.Text;
            updateDocumentType.s_document_type_desc_japanese = txtDescription_Japanese.Text;
            updateDocumentType.s_document_type_name_russian = txtDocumentTypeName_Russian.Text;
            updateDocumentType.s_document_type_desc_russian = txtDescription_Russian.Text;
            updateDocumentType.s_document_type_name_danish = txtDocumentTypeName_Danish.Text;
            updateDocumentType.s_document_type_desc_danish = txtDescription_Danish.Text;
            updateDocumentType.s_document_type_name_polish = txtDocumentTypeName_Polish.Text;
            updateDocumentType.s_document_type_desc_polish = txtDescription_Polish.Text;
            updateDocumentType.s_document_type_name_swedish = txtDocumentTypeName_Swedish.Text;
            updateDocumentType.s_document_type_desc_swedish = txtDescription_Swedish.Text;
            updateDocumentType.s_document_type_name_finnish = txtDocumentTypeName_Finnish.Text;
            updateDocumentType.s_document_type_desc_finnish = txtDescription_Finnish.Text;
            updateDocumentType.s_document_type_name_korean = txtDocumentTypeName_Korean.Text;
            updateDocumentType.s_document_type_desc_korean = txtDescription_Korean.Text;
            updateDocumentType.s_document_type_name_italian = txtDocumentTypeName_Italian.Text;
            updateDocumentType.s_document_type_desc_italian = txtDescription_Italian.Text;
            updateDocumentType.s_document_type_name_dutch = txtDocumentTypeName_Dutch.Text;
            updateDocumentType.s_document_type_desc_dutch = txtDescription_Dutch.Text;
            updateDocumentType.s_document_type_name_indonesian = txtDocumentTypeName_Indonesian.Text;
            updateDocumentType.s_document_type_desc_indonesian = txtDescription_Indonesian.Text;
            updateDocumentType.s_document_type_name_greek = txtDocumentTypeName_Greek.Text;
            updateDocumentType.s_document_type_desc_greek = txtDescription_Greek.Text;
            updateDocumentType.s_document_type_name_hungarian = txtDcoumentTypeName_Hungarian.Text;
            updateDocumentType.s_document_type_desc_hungarian = txtDescription_Hungarian.Text;
            updateDocumentType.s_document_type_name_norwegian = txtDocumentTypeName_Norwegian.Text;
            updateDocumentType.s_document_type_desc_norwegian = txtDescription_Norwegian.Text;
            updateDocumentType.s_document_type_name_turkish = txtDocumentTypeName_Turkish.Text;
            updateDocumentType.s_document_type_desc_turkish = txtDescription_Turkish.Text;
            updateDocumentType.s_document_type_name_arabic_rtl = txtDocumentTypeName_Arabic.Text;
            updateDocumentType.s_document_type_desc_arabic_rtl = txtDescription_Arabic.Text;
            updateDocumentType.s_document_type_name_custom_01 = txtDocumentTypeName_Custom01.Text;
            updateDocumentType.s_document_type_desc_custom_01 = txtDescription_Custom01.Text;
            updateDocumentType.s_document_type_name_custom_02 = txtDocumentTypeName_Custom02.Text;
            updateDocumentType.s_document_type_desc_custom_02 = txtDescription_Custom02.Text;
            updateDocumentType.s_document_type_name_custom_03 = txtDocumentTypeName_Custom03.Text;
            updateDocumentType.s_document_type_desc_custom_03 = txtDescription_Custom03.Text;
            updateDocumentType.s_document_type_name_custom_04 = txtDocumentTypeName_Custom04.Text;
            updateDocumentType.s_document_type_desc_custom_04 = txtDescription_Custom04.Text;
            updateDocumentType.s_document_type_name_custom_05 = txtDocumentTypeName_Custom05.Text;
            updateDocumentType.s_document_type_desc_custom_05 = txtDescription_Custom05.Text;
            updateDocumentType.s_document_type_name_custom_06 = txtDocumentTypeName_Custom06.Text;
            updateDocumentType.s_document_type_desc_custom_06 = txtDescription_Custom06.Text;
            updateDocumentType.s_document_type_name_custom_07 = txtDocumentTypeName_Custom07.Text;
            updateDocumentType.s_document_type_desc_custom_07 = txtDescription_Custom07.Text;
            updateDocumentType.s_document_type_name_custom_08 = txtDocumentTypeName_Custom08.Text;
            updateDocumentType.s_document_type_desc_custom_08 = txtDescription_Custom08.Text;
            updateDocumentType.s_document_type_name_custom_09 = txtDocumentTypeName_Custom09.Text;
            updateDocumentType.s_document_type_desc_custom_09 = txtDescription_Custom09.Text;
            updateDocumentType.s_document_type_name_custom_10 = txtDocumentTypeName_Custom10.Text;
            updateDocumentType.s_document_type_desc_custom_10 = txtDescription_Custom10.Text;
            updateDocumentType.s_document_type_name_custom_11 = txtDocumentTypeName_Custom11.Text;
            updateDocumentType.s_document_type_desc_custom_11 = txtDescription_Custom11.Text;
            updateDocumentType.s_document_type_name_custom_12 = txtDocumentTypeName_Custom12.Text;
            updateDocumentType.s_document_type_desc_custom_12 = txtDescription_Custom12.Text;
            updateDocumentType.s_document_type_name_custom_13 = txtDocumentTypeName_Custom13.Text;
            updateDocumentType.s_document_type_desc_custom_13 = txtDescription_Custom13.Text;

            error = SystemDocumentTypesBLL.UpdateDocumentType(updateDocumentType);
            if (error != -2)
            {
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerText = LocalResources.GetText("app_succ_update_text");
            }
            else
            {
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_document_type_id_already_exists_error_text");

            }
        }
    }
}