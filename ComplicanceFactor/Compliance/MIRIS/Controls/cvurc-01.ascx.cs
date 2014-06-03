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
    public partial class cvurc_01 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SearchRac(string c_case_id_pk)
        {
            if (!string.IsNullOrEmpty(c_case_id_pk))
            {
                Rca rca = RcaBLL.SearchRca(c_case_id_pk);
                rca.c_case_id_pk = c_case_id_pk;
                lblIncidentInvestigationSummary.Text = rca.c_rca_summary;
                lblRcaSufficientInformation.Text = rca.c_rca_have_sufficient_information == true ? "Yes" : "No";
                lblRcaCatagoryPeople.Text = rca.c_rca_category_people;
                lblRcaCategoryProcedure.Text = rca.c_rca_category_procedure;
                lblRcaCategoryHardware.Text = rca.c_rca_category_hardware;
                lblRcaCategoryEnvironment.Text = rca.c_rca_category_environment;
                lblRcaCategoryEternal.Text = rca.c_rca_eternal;
                lblRcaCorrectiveAction.Text = rca.c_rca_corrective_action_solutions;
                lblRcaActivators.Text = rca.c_rca_activators;
                lblRcaConsequences.Text = rca.c_rca_consequences;
                lblQuestion1.Text = rca.c_rca_question1;
                lblAnswer1.Text = rca.c_rca_answer1;
                lblQuestion2.Text = rca.c_rca_question2;
                lblAnswer2.Text = rca.c_rca_answer2;
                lblQuestion3.Text = rca.c_rca_question3;
                lblAnswer3.Text = rca.c_rca_answer3;
                lblQuestion4.Text = rca.c_rca_question4;
                lblAnswer4.Text = rca.c_rca_answer4;
                lblQuestion5.Text = rca.c_rca_question5;
                lblAnswer5.Text = rca.c_rca_answer5;
                lblQuestion6.Text = rca.c_rca_question6;
                lblAnswer6.Text = rca.c_rca_answer6;
                lblQuestion7.Text = rca.c_rca_question7;
                lblAnswer7.Text = rca.c_rca_answer7;
                lblQuestion8.Text = rca.c_rca_question8;
                lblAnswer8.Text = rca.c_rca_answer8;
                lblQuestion9.Text = rca.c_rca_question9;
                lblAnswer9.Text = rca.c_rca_answer9;
                lblQuestion10.Text = rca.c_rca_question10;
                lblAnswer10.Text = rca.c_rca_answer10;
            }

        }
    }
}