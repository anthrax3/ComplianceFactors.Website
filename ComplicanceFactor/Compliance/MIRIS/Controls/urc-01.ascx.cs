using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.Compliance.MIRIS.Controls
{
    public partial class urc_01 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
            }
        }
        public void UpdateRac(string c_case_id_pk)
        {
            Rca rca = new Rca();
            rca.c_case_id_pk = c_case_id_pk;
            rca.c_rca_summary =txtIncidentInvestigationSummary.Text;
            rca.c_rca_have_sufficient_information = rbtnRcaSufficientInformation.SelectedValue=="1"?true:false;
            rca.c_rca_category_people = ddlRcaCategoryPeople.SelectedValue;
            rca.c_rca_category_procedure = ddlRcaCategoryProcedure.SelectedValue;
            rca.c_rca_category_hardware = ddlRcaCategoryHardware.SelectedValue;
            rca.c_rca_category_environment = ddlRcaCategoryEnvironment.SelectedValue;
            rca.c_rca_eternal = ddlRcaCategoryEternal.SelectedValue;
            rca.c_rca_corrective_action_solutions =ddlRcaCorrectiveAction.SelectedValue;
            rca.c_rca_activators = ddlRcaActivators.SelectedValue;
            rca.c_rca_consequences =ddlRcaConsequences.SelectedValue;

            rca.c_rca_question1 = txtQuestion1.Text;
            rca.c_rca_answer1 = txtAnswer1.Text;
            rca.c_rca_question2 = txtQuestion2.Text;
            rca.c_rca_answer2 = txtAnswer2.Text;
            rca.c_rca_question3 = txtQuestion3.Text;
            rca.c_rca_answer3 = txtAnswer3.Text;
            rca.c_rca_question4 = txtQuestion4.Text;
            rca.c_rca_answer4 = txtAnswer4.Text;
            rca.c_rca_question5 = txtQuestion5.Text;
            rca.c_rca_answer5 = txtAnswer5.Text;
            rca.c_rca_question6 = txtQuestion6.Text;
            rca.c_rca_answer6 = txtAnswer6.Text;
            rca.c_rca_question7 = txtQuestion7.Text;
            rca.c_rca_answer7 = txtAnswer7.Text;
            rca.c_rca_question8 = txtQuestion8.Text;
            rca.c_rca_answer8 = txtAnswer8.Text;
            rca.c_rca_question9 = txtQuestion9.Text;
            rca.c_rca_answer9 = txtAnswer9.Text;
            rca.c_rca_question10 = txtQuestion10.Text;
            rca.c_rca_answer10 = txtAnswer10.Text;
             RcaBLL.UpdateRca(rca);
        }
        public void SearchRac(string c_case_id_pk)
        {
            if (!string.IsNullOrEmpty(c_case_id_pk))
            {
                Rca rca = RcaBLL.SearchRca(c_case_id_pk);
                rca.c_case_id_pk = c_case_id_pk;
                txtIncidentInvestigationSummary.Text = rca.c_rca_summary;
                rbtnRcaSufficientInformation.SelectedValue = rca.c_rca_have_sufficient_information == true ? "1" : "0";
                ddlRcaCategoryPeople.SelectedValue = rca.c_rca_category_people;
                ddlRcaCategoryProcedure.SelectedValue = rca.c_rca_category_procedure;
                ddlRcaCategoryHardware.SelectedValue = rca.c_rca_category_hardware;
                ddlRcaCategoryEnvironment.SelectedValue = rca.c_rca_category_environment;
                ddlRcaCategoryEternal.SelectedValue = rca.c_rca_eternal;
                ddlRcaCorrectiveAction.SelectedValue = rca.c_rca_corrective_action_solutions;
                ddlRcaActivators.SelectedValue = rca.c_rca_activators;
                ddlRcaConsequences.SelectedValue = rca.c_rca_consequences;
                txtQuestion1.Text = rca.c_rca_question1;
                txtAnswer1.Text = rca.c_rca_answer1;
                txtQuestion2.Text = rca.c_rca_question2;
                txtAnswer2.Text = rca.c_rca_answer2;
                txtQuestion3.Text = rca.c_rca_question3;
                txtAnswer3.Text = rca.c_rca_answer3;
                txtQuestion4.Text = rca.c_rca_question4;
                txtAnswer4.Text = rca.c_rca_answer4;
                txtQuestion5.Text = rca.c_rca_question5;
                txtAnswer5.Text = rca.c_rca_answer5;
                txtQuestion6.Text = rca.c_rca_question6;
                txtAnswer6.Text = rca.c_rca_answer6;
                txtQuestion7.Text = rca.c_rca_question7;
                txtAnswer7.Text = rca.c_rca_answer7;
                txtQuestion8.Text = rca.c_rca_question8;
                txtAnswer8.Text = rca.c_rca_answer8;
                txtQuestion9.Text = rca.c_rca_question9;
                txtAnswer9.Text = rca.c_rca_answer9;
                txtQuestion10.Text = rca.c_rca_question10;
                txtAnswer10.Text = rca.c_rca_answer10;
            }

        }
    }
}