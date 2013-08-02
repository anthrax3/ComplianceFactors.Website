using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups
{
    public partial class saanagn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStatus.DataSource = SystemAssignmentGroupBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();
            }
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            CreateAssignmentGroups();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            CreateAssignmentGroups();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }
        private void CreateAssignmentGroups()
        {
            
            SystemAssingnmentGroup createAssignmentGroup = new SystemAssingnmentGroup();
            createAssignmentGroup.s_assignment_group_system_id_pk = Guid.NewGuid().ToString();
            createAssignmentGroup.s_assignment_group_id = txtAssignmentGroupId_EnglishUs.Text;
            createAssignmentGroup.s_assignment_group_status_id_fk = ddlStatus.SelectedValue;
            createAssignmentGroup.s_assignment_group_name_us_english = txtAssignmentGroupName_EnglishUs.Text;
            createAssignmentGroup.s_assignment_group_desc_us_english = txtAssignmentGroupDescription_EnglishUs.Value;
            createAssignmentGroup.s_assignment_group_name_uk_english = txtAssignmentGroupName_EnglishUk.Text;
            createAssignmentGroup.s_assignment_group_desc_uk_english = txtDescription_EnglishUk.Value;
            createAssignmentGroup.s_assignment_group_name_ca_france = txtAssignmentGroupName_FrenchCa.Text;
            createAssignmentGroup.s_assignment_group_desc_ca_france = txtDescription_FrenchCa.Value;
            createAssignmentGroup.s_assignment_group_name_fr_french = txtAssignmentGroupName_FrenchFr.Text;
            createAssignmentGroup.s_assignment_group_desc_fr_french = txtDescription_FrenchFr.Value;
            createAssignmentGroup.s_assignment_group_name_mx_spanish = txtAssignmentGroupName_SpanishMx.Text;
            createAssignmentGroup.s_assignment_group_desc_mx_spanish = txtDescription_SpanishMx.Value;
            createAssignmentGroup.s_assignment_group_name_sp_spanish = txtAssignmentGroupName_SpanishSp.Text;
            createAssignmentGroup.s_assignment_group_desc_sp_spanish = txtDescription_SpanishSp.Value;
            createAssignmentGroup.s_assignment_group_name_portuguse = txtAssignmentGroupName_Portuguese.Text;
            createAssignmentGroup.s_assignment_group_desc_portuguse = txtDescription_Portuguese.Value;
            createAssignmentGroup.s_assignment_group_name_chinese = txtAssignmentGroupName_Chinese.Text;
            createAssignmentGroup.s_assignment_group_desc_chinese = txtDescription_Chinese.Value;
            createAssignmentGroup.s_assignment_group_name_german = txtAssignmentGroupName_German.Text;
            createAssignmentGroup.s_assignment_group_desc_german = txtDescription_German.Value;
            createAssignmentGroup.s_assignment_group_name_japanese = txtAssignmentGroupName_Japanese.Text;
            createAssignmentGroup.s_assignment_group_desc_japanese = txtDescription_Japanese.Value;
            createAssignmentGroup.s_assignment_group_name_russian = txtAssignmentGroupName_Russian.Text;
            createAssignmentGroup.s_assignment_group_desc_russian = txtDescription_Russian.Value;
            createAssignmentGroup.s_assignment_group_name_danish = txtAssignmentGroupName_Danish.Text;
            createAssignmentGroup.s_assignment_group_desc_danish = txtDescription_Danish.Value;
            createAssignmentGroup.s_assignment_group_name_polish = txtAssignmentGroupName_Polish.Text;
            createAssignmentGroup.s_assignment_group_desc_polish = txtDescription_Polish.Value;
            createAssignmentGroup.s_assignment_group_name_swedish = txtAssignmentGroupName_Swedish.Text;
            createAssignmentGroup.s_assignment_group_desc_swedish = txtDescription_Swedish.Value;
            createAssignmentGroup.s_assignment_group_name_finnish = txtAssignmentGroupName_Finnish.Text;
            createAssignmentGroup.s_assignment_group_desc_finnish = txtDescription_Finnish.Value;
            createAssignmentGroup.s_assignment_group_name_korean = txtAssignmentGroupName_Korean.Text;
            createAssignmentGroup.s_assignment_group_desc_korean = txtDescription_Korean.Value;
            createAssignmentGroup.s_assignment_group_name_italian = txtAssignmentGroupName_Italian.Text;
            createAssignmentGroup.s_assignment_group_desc_italian = txtDescription_Italian.Value;
            createAssignmentGroup.s_assignment_group_name_dutch = txtAssignmentGroupName_Dutch.Text;
            createAssignmentGroup.s_assignment_group_desc_dutch = txtDescription_Dutch.Value;
            createAssignmentGroup.s_assignment_group_name_indonesian = txtAssignmentGroupName_Indonesian.Text;
            createAssignmentGroup.s_assignment_group_desc_indonesian = txtDescription_Indonesian.Value;
            createAssignmentGroup.s_assignment_group_name_greek = txtAssignmentGroupName_Greek.Text;
            createAssignmentGroup.s_assignment_group_desc_greek = txtDescription_Greek.Value;
            createAssignmentGroup.s_assignment_group_name_hungarian = txtAssignmentGroupName_Hungarian.Text;
            createAssignmentGroup.s_assignment_group_desc_hungarian = txtDescription_Hungarian.Value;
            createAssignmentGroup.s_assignment_group_name_norwegian = txtAssignmentGroupName_Norwegian.Text;
            createAssignmentGroup.s_assignment_group_desc_norwegian = txtDescription_Norwegian.Value;
            createAssignmentGroup.s_assignment_group_name_turkish = txtAssignmentGroupName_Turkish.Text;
            createAssignmentGroup.s_assignment_group_desc_turkish = txtDescription_Turkish.Value;
            createAssignmentGroup.s_assignment_group_name_arabic = txtAssignmentGroupName_Arabic.Text;
            createAssignmentGroup.s_assignment_group_desc_arabic = txtDescription_Arabic.Value;
            createAssignmentGroup.s_assignment_group_name_custom_01 = txtAssignmentGroupName_Custom01.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_01 = txtDescription_Custom01.Value;
            createAssignmentGroup.s_assignment_group_name_custom_02 = txtAssignmentGroupName_Custom02.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_02 = txtDescription_Custom02.Value;
            createAssignmentGroup.s_assignment_group_name_custom_03 = txtAssignmentGroupName_Custom03.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_03 = txtDescription_Custom03.Value;
            createAssignmentGroup.s_assignment_group_name_custom_04 = txtAssignmentGroupName_Custom04.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_04 = txtDescription_Custom04.Value;
            createAssignmentGroup.s_assignment_group_name_custom_05 = txtAssignmentGroupName_Custom05.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_05 = txtDescription_Custom05.Value;
            createAssignmentGroup.s_assignment_group_name_custom_06 = txtAssignmentGroupName_Custom06.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_06 = txtDescription_Custom06.Value;
            createAssignmentGroup.s_assignment_group_name_custom_07 = txtAssignmentGroupName_Custom07.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_07 = txtDescription_Custom07.Value;
            createAssignmentGroup.s_assignment_group_name_custom_08 = txtAssignmentGroupName_Custom08.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_08 = txtDescription_Custom08.Value;
            createAssignmentGroup.s_assignment_group_name_custom_09 = txtAssignmentGroupName_Custom09.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_09 = txtDescription_Custom09.Value;
            createAssignmentGroup.s_assignment_group_name_custom_10 = txtAssignmentGroupName_Custom10.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_10 = txtDescription_Custom10.Value;
            createAssignmentGroup.s_assignment_group_name_custom_11 = txtAssignmentGroupName_Custom11.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_11 = txtDescription_Custom11.Value;
            createAssignmentGroup.s_assignment_group_name_custom_12 = txtAssignmentGroupName_Custom12.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_12 = txtDescription_Custom12.Text;
            createAssignmentGroup.s_assignment_group_name_custom_13 = txtAssignmentGroupName_Custom13.Text;
            createAssignmentGroup.s_assignment_group_desc_custom_13 = txtDescription_Custom13.Value;


            int error = SystemAssignmentGroupBLL.CreateAssignmentGroup(createAssignmentGroup);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Catalog/AssignmentGroup/saeag-01.aspx?id=" + SecurityCenter.EncryptText(createAssignmentGroup.s_assignment_group_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }

            else
            {
                divError.Style.Add("display", "block");
                divError.InnerText = "Assignment group id already exist";
            }
        }
    }
}