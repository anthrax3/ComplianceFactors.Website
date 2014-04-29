using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;
namespace ComplicanceFactor.BusinessComponent
{
    public class RcaBLL
    {
        public static int UpdateRca(Rca rca)
        {

            Hashtable htUpdateRca = new Hashtable();
            htUpdateRca.Add("@c_case_id_pk", rca.c_case_id_pk);
            htUpdateRca.Add("@c_rca_summary", rca.c_rca_summary);
            htUpdateRca.Add("@c_rca_have_sufficient_information", rca.c_rca_have_sufficient_information);
            htUpdateRca.Add("@c_rca_category_people", rca.c_rca_category_people);
            htUpdateRca.Add("@c_rca_category_procedure", rca.c_rca_category_procedure);
            htUpdateRca.Add("@c_rca_category_hardware", rca.c_rca_category_hardware);
            htUpdateRca.Add("@c_rca_category_environment", rca.c_rca_category_environment);
            htUpdateRca.Add("@c_rca_eternal", rca.c_rca_eternal);
            htUpdateRca.Add("@c_rca_corrective_action_solutions", rca.c_rca_corrective_action_solutions);
            htUpdateRca.Add("@c_rca_activators", rca.c_rca_activators);
            htUpdateRca.Add("@c_rca_consequences", rca.c_rca_consequences);

            htUpdateRca.Add("@c_rca_question1", rca.c_rca_question1);
            htUpdateRca.Add("@c_rca_answer1", rca.c_rca_answer1);
            htUpdateRca.Add("@c_rca_question2", rca.c_rca_question2);
            htUpdateRca.Add("@c_rca_answer2", rca.c_rca_answer2);
            htUpdateRca.Add("@c_rca_question3", rca.c_rca_question3);
            htUpdateRca.Add("@c_rca_answer3", rca.c_rca_answer3);
            htUpdateRca.Add("@c_rca_question4", rca.c_rca_question4);
            htUpdateRca.Add("@c_rca_answer4", rca.c_rca_answer4);
            htUpdateRca.Add("@c_rca_question5", rca.c_rca_question5);
            htUpdateRca.Add("@c_rca_answer5", rca.c_rca_answer5);
            htUpdateRca.Add("@c_rca_question6", rca.c_rca_question6);
            htUpdateRca.Add("@c_rca_answer6", rca.c_rca_answer6);
            htUpdateRca.Add("@c_rca_question7", rca.c_rca_question7);
            htUpdateRca.Add("@c_rca_answer7", rca.c_rca_answer7);
            htUpdateRca.Add("@c_rca_question8", rca.c_rca_question8);
            htUpdateRca.Add("@c_rca_answer8", rca.c_rca_answer8);
            htUpdateRca.Add("@c_rca_question9", rca.c_rca_question9);
            htUpdateRca.Add("@c_rca_answer9", rca.c_rca_answer9);
            htUpdateRca.Add("@c_rca_question10", rca.c_rca_question10);
            htUpdateRca.Add("@c_rca_answer10", rca.c_rca_answer10);
          
           

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_rca", htUpdateRca);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Rca SearchRca(string c_case_id_pk)
        {

            Hashtable htSearchRca = new Hashtable();
            htSearchRca.Add("@c_case_id_pk", c_case_id_pk);

            try
            {
                DataTable dt = DataProxy.FetchDataTable("c_miris_sp_search_rca", htSearchRca);
                Rca rca = new Rca();
                rca.c_case_id_pk = dt.Rows[0]["c_case_id_pk"].ToString();
                rca.c_rca_summary = dt.Rows[0]["c_rca_summary"].ToString();
                rca.c_rca_have_sufficient_information = string.IsNullOrEmpty(dt.Rows[0]["c_rca_have_sufficient_information"].ToString())?
                    false:(bool)dt.Rows[0]["c_rca_have_sufficient_information"];
                rca.c_rca_category_people = dt.Rows[0]["c_rca_category_people"].ToString();
                rca.c_rca_category_procedure = dt.Rows[0]["c_rca_category_procedure"].ToString();
                rca.c_rca_category_hardware = dt.Rows[0]["c_rca_category_hardware"].ToString();
                rca.c_rca_category_environment = dt.Rows[0]["c_rca_category_environment"].ToString();
                rca.c_rca_eternal = dt.Rows[0]["c_rca_eternal"].ToString();
                rca.c_rca_corrective_action_solutions = dt.Rows[0]["c_rca_corrective_action_solutions"].ToString();
                rca.c_rca_activators = dt.Rows[0]["c_rca_activators"].ToString();
                rca.c_rca_consequences = dt.Rows[0]["c_rca_consequences"].ToString();
                rca.c_rca_question1 = dt.Rows[0]["c_rca_question1"].ToString();
                rca.c_rca_answer1 = dt.Rows[0]["c_rca_answer1"].ToString();
                rca.c_rca_question2 = dt.Rows[0]["c_rca_question2"].ToString();
                rca.c_rca_answer2 = dt.Rows[0]["c_rca_answer2"].ToString();
                rca.c_rca_question3 = dt.Rows[0]["c_rca_question3"].ToString();
                rca.c_rca_answer3 = dt.Rows[0]["c_rca_answer3"].ToString();
                rca.c_rca_question4 = dt.Rows[0]["c_rca_question4"].ToString();
                rca.c_rca_answer4 = dt.Rows[0]["c_rca_answer4"].ToString();
                rca.c_rca_question5 = dt.Rows[0]["c_rca_question5"].ToString();
                rca.c_rca_answer5 = dt.Rows[0]["c_rca_answer5"].ToString();
                rca.c_rca_question6 = dt.Rows[0]["c_rca_question6"].ToString();
                rca.c_rca_answer6 = dt.Rows[0]["c_rca_answer6"].ToString();
                rca.c_rca_question7 = dt.Rows[0]["c_rca_question7"].ToString();
                rca.c_rca_answer7 = dt.Rows[0]["c_rca_answer7"].ToString();
                rca.c_rca_question8 = dt.Rows[0]["c_rca_question8"].ToString();
                rca.c_rca_answer8 = dt.Rows[0]["c_rca_answer8"].ToString();
                rca.c_rca_question9 = dt.Rows[0]["c_rca_question9"].ToString();
                rca.c_rca_answer9 = dt.Rows[0]["c_rca_answer9"].ToString();
                rca.c_rca_question10 = dt.Rows[0]["c_rca_question10"].ToString();
                rca.c_rca_answer10 = dt.Rows[0]["c_rca_answer10"].ToString();
                return rca;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
