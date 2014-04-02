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
                return rca;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
