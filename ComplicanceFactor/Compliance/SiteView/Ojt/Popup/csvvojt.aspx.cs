using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.Compliance.SiteView.Ojt
{
    public partial class csvvojt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "view")
                {
                    PopulateOjt(Request.QueryString["id"].ToString());
                }
            }
        }
        private void PopulateOjt(string ojtId)
        {
            SiteViewOnJobTraining ojt;
            ojt = SiteViewOnJobTrainingBLL.GetSingleOjt(ojtId);
            lblOjtNumber.Text = ojt.sv_ojt_number;
            lblOjtTitle.Text = ojt.sv_ojt_title;
            lblOjtDescription.Text = ojt.sv_ojt_description;
            lblOjtLocation.Text = ojt.sv_ojt_location;
            lblOjtTrainer.Text = ojt.sv_ojt_Trainer;
            lblOjtDate.Text = Convert.ToDateTime(ojt.sv_ojt_date).ToString("MM/dd/yyyy");
            lblOjtStartTime.Text = ojt.sv_ojt_start_time.ToString();
            lblOjtEndTime.Text = ojt.sv_ojt_end_time.ToString();
            lblOjtDuration.Text = ojt.sv_ojt_duration;
            lblOjtType.Text = ojt.sv_ojt_type;
            if (ojt.sv_ojt_issafty_brief == true)
            {
                chkOjtIsSafety.Checked = true;
            }
            lblOjtFrequency.Text = ojt.sv_ojt_frequency;
            if (ojt.sv_ojt_isharm_related == true)
            {
                chkOjtIsHarm.Checked = true;
            }
            lblOjtHarmTitle.Text = ojt.sv_ojt_harm_title;
            lblOjtHarmNo.Text = ojt.sv_ojt_harm_number;
            if (ojt.sv_ojt_iscertification_related == true)
            {
                chkIsCertRelated.Checked = true;
            }
            lblOthers.Text = ojt.sv_ojt_other;


            gvAttachment.DataSource = SiteViewOnJobTrainingBLL.GetOjtAttachment(ojtId);
            gvAttachment.DataBind();

            gvAcknowledgement.DataSource = SiteViewOnJobTrainingBLL.GetOjtAcknowledge(ojtId);
            gvAcknowledgement.DataBind();
        }
    }
}