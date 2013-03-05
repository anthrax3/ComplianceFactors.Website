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
    public class SiteViewInspectionBLL
    {
        public static int CreateNewInspectionTemplate(SiteViewInspectionTemplate createInspection)
        {
            Hashtable htcreateInspection = new Hashtable();
            htcreateInspection.Add("@sv_mi_templete_id_pk", createInspection.sv_mi_templete_id_pk);
            htcreateInspection.Add("@sv_mi_templete_id ", createInspection.sv_mi_templete_id);
            htcreateInspection.Add("@sv_mi_templete_title ", createInspection.sv_mi_templete_title);
            htcreateInspection.Add("@sv_mi_templete_description", createInspection.sv_mi_templete_description);
            htcreateInspection.Add("@sv_mi_templete_created_by_fk  ", createInspection.sv_mi_templete_created_by_fk);
            htcreateInspection.Add("@sv_mi_templete_created_date", createInspection.sv_mi_templete_created_date);
            htcreateInspection.Add("@sv_mi_templete_last_modify_date ", createInspection.sv_mi_templete_last_modify_date);
            htcreateInspection.Add("@sv_mi_templete_is_default ", createInspection.sv_mi_templete_is_default);
            htcreateInspection.Add("@sv_mi_templete_status ", createInspection.sv_mi_templete_status);
            htcreateInspection.Add("@sv_mi_questions ", createInspection.sv_mi_questions);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_inspection_templete", htcreateInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInspection(SiteViewInspectionTemplate createInspection)
        {
            Hashtable htupdateInspection = new Hashtable();
            htupdateInspection.Add("@sv_mi_templete_id_pk", createInspection.sv_mi_templete_id_pk);
            htupdateInspection.Add("@sv_mi_templete_id ", createInspection.sv_mi_templete_id);
            htupdateInspection.Add("@sv_mi_templete_title ", createInspection.sv_mi_templete_title);
            htupdateInspection.Add("@sv_mi_templete_description", createInspection.sv_mi_templete_description);
            htupdateInspection.Add("@sv_mi_templete_created_by_fk  ", createInspection.sv_mi_templete_created_by_fk);
            htupdateInspection.Add("@sv_mi_templete_last_modify_date ", createInspection.sv_mi_templete_last_modify_date);
            htupdateInspection.Add("@sv_mi_templete_is_default ", createInspection.sv_mi_templete_is_default);
            htupdateInspection.Add("@sv_mi_templete_status ", createInspection.sv_mi_templete_status);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_inspection_templete", htupdateInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateQuestions(SiteViewInspectionTemplate createInspection)
        {
            Hashtable htupdateQuestions = new Hashtable();
            htupdateQuestions.Add("@sv_mi_templete_id_pk", createInspection.sv_mi_templete_id_pk);
            htupdateQuestions.Add("@sv_mi_questions ", createInspection.sv_mi_questions);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_inspection_templete_questions", htupdateQuestions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetQuestions(SiteViewInspectionTemplate resetInspection)
        {
            Hashtable htresetQuestions = new Hashtable();
            htresetQuestions.Add("@sv_mi_templete_id_pk", resetInspection.sv_mi_templete_id_pk);
            htresetQuestions.Add("@sv_mi_questions ", resetInspection.sv_mi_questions);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_inspection_template_question", htresetQuestions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status",htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchInspectionTemplate()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_inspection_template");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleInspection(string sv_mi_templete_id_pk)
        {
            Hashtable htgetInspection = new Hashtable();
            htgetInspection.Add("@sv_mi_templete_id_pk", sv_mi_templete_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_single_inspection_template", htgetInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SiteViewInspectionTemplate GetSingleInspectionQuestion(string sv_mi_templete_question_id_pk)
        {
            SiteViewInspectionTemplate inspection;
            try
            {
                inspection = new SiteViewInspectionTemplate();
                Hashtable htGetQuestion = new Hashtable();
                htGetQuestion.Add("@sv_mi_templete_question_id_pk", sv_mi_templete_question_id_pk);
                DataTable dtGetInspection = DataProxy.FetchDataTable("s_sp_get_single_inspection_template_question", htGetQuestion);
                inspection.sv_mi_templete_question_id_pk = dtGetInspection.Rows[0]["sv_mi_templete_question_id_pk"].ToString();
                inspection.sv_mi_templete_id_fk = dtGetInspection.Rows[0]["sv_mi_templete_id_fk"].ToString();
                inspection.sv_mi_templete_question = dtGetInspection.Rows[0]["sv_mi_templete_question"].ToString();
                inspection.sv_mi_templete_question_type = Convert.ToInt16(dtGetInspection.Rows[0]["sv_mi_templete_question_type"]);
                inspection.sv_mi_templete_question_answer_optionsA = dtGetInspection.Rows[0]["sv_mi_templete_question_answer_optionsA"].ToString();
                inspection.sv_mi_templete_question_answer_optionsB = dtGetInspection.Rows[0]["sv_mi_templete_question_answer_optionsB"].ToString();
                inspection.sv_mi_templete_question_answer_optionsC = dtGetInspection.Rows[0]["sv_mi_templete_question_answer_optionsC"].ToString();
                inspection.sv_mi_templete_question_answer_optionsD = dtGetInspection.Rows[0]["sv_mi_templete_question_answer_optionsD"].ToString();
                inspection.sv_mi_templete_question_display_order = Convert.ToInt16(dtGetInspection.Rows[0]["sv_mi_templete_question_display_order"]);
                inspection.sv_mi_templete_question_answer = dtGetInspection.Rows[0]["sv_mi_templete_question_answer"].ToString();
                return inspection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInspectionStatus(string sv_mi_templete_id_pk)
        {
            Hashtable htUpdateInspectionStatus = new Hashtable();
            htUpdateInspectionStatus.Add("@sv_mi_templete_id_pk", sv_mi_templete_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_inspection_template_status", htUpdateInspectionStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertQuestions(SiteViewInspectionTemplate createQuestion)
        {
            Hashtable htCreateQuestions = new Hashtable();
            htCreateQuestions.Add("@sv_mi_templete_question_id_pk", createQuestion.sv_mi_templete_question_id_pk);
            htCreateQuestions.Add("@sv_mi_templete_id_fk", createQuestion.sv_mi_templete_id_fk);
            htCreateQuestions.Add("@sv_mi_templete_question", createQuestion.sv_mi_templete_question);
            htCreateQuestions.Add("@sv_mi_templete_question_type", createQuestion.sv_mi_templete_question_type);
            htCreateQuestions.Add("@sv_mi_templete_question_answer_optionsA", createQuestion.sv_mi_templete_question_answer_optionsA);
            htCreateQuestions.Add("@sv_mi_templete_question_answer_optionsB", createQuestion.sv_mi_templete_question_answer_optionsB);
            htCreateQuestions.Add("@sv_mi_templete_question_answer_optionsC", createQuestion.sv_mi_templete_question_answer_optionsC);
            htCreateQuestions.Add("@sv_mi_templete_question_answer_optionsD ", createQuestion.sv_mi_templete_question_answer_optionsD);
            htCreateQuestions.Add("@sv_mi_templete_question_display_order ", createQuestion.sv_mi_templete_question_display_order);
            htCreateQuestions.Add("@sv_mi_templete_question_answer ", createQuestion.sv_mi_templete_question_answer);
            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_inspection_template_question", htCreateQuestions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateSingleQuestion(SiteViewInspectionTemplate updateQuestion)
        {
            Hashtable htupdateQuestions = new Hashtable();
            htupdateQuestions.Add("@sv_mi_templete_question_id_pk", updateQuestion.sv_mi_templete_question_id_pk);
            htupdateQuestions.Add("@sv_mi_templete_id_fk", updateQuestion.sv_mi_templete_id_fk);
            htupdateQuestions.Add("@sv_mi_templete_question", updateQuestion.sv_mi_templete_question);
            htupdateQuestions.Add("@sv_mi_templete_question_type", updateQuestion.sv_mi_templete_question_type);
            htupdateQuestions.Add("@sv_mi_templete_question_answer_optionsA", updateQuestion.sv_mi_templete_question_answer_optionsA);
            htupdateQuestions.Add("@sv_mi_templete_question_answer_optionsB", updateQuestion.sv_mi_templete_question_answer_optionsB);
            htupdateQuestions.Add("@sv_mi_templete_question_answer_optionsC", updateQuestion.sv_mi_templete_question_answer_optionsC);
            htupdateQuestions.Add("@sv_mi_templete_question_answer_optionsD ", updateQuestion.sv_mi_templete_question_answer_optionsD);
            htupdateQuestions.Add("@sv_mi_templete_question_display_order ", updateQuestion.sv_mi_templete_question_display_order);
            htupdateQuestions.Add("@sv_mi_templete_question_answer ", updateQuestion.sv_mi_templete_question_answer);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_single_question", htupdateQuestions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all Question by inspection Id
        /// </summary>
        /// <param name="sv_mi_templete_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetAllInspectionQuestion(string sv_mi_templete_id_pk)
        {
            Hashtable htgetInspection = new Hashtable();
            htgetInspection.Add("@sv_mi_templete_id_pk", sv_mi_templete_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_inspection_template_question", htgetInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Question
        /// </summary>
        /// <param name="sv_mi_templete_question_id_pk"></param>
        /// <returns></returns>
        public static int DeleteSingleQuestion(string sv_mi_templete_question_id_pk)
        {
            Hashtable htdeleteQuestion = new Hashtable();
            htdeleteQuestion.Add("@sv_mi_templete_question_id_pk", sv_mi_templete_question_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_inspection_question", htdeleteQuestion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Inspection Table
        // Send button

        public static int CreateNewInspection(SiteViewInspection createInspection)
        {
            Hashtable htcreateInspection = new Hashtable();
            htcreateInspection.Add("@sv_inspection_id_pk", createInspection.sv_inspection_id_pk);
            htcreateInspection.Add("@sv_inspection_created_by_fk ", createInspection.sv_inspection_created_by_fk);
            htcreateInspection.Add("@sv_inspection_title ", createInspection.sv_inspection_title);
            htcreateInspection.Add("@sv_inspection_description", createInspection.sv_inspection_description);
            htcreateInspection.Add("@sv_inspection_creation_date  ", createInspection.sv_inspection_creation_date);
            htcreateInspection.Add("@sv_inspection_last_modify_date", createInspection.sv_inspection_last_modify_date);
            htcreateInspection.Add("@sv_inspection_status_id_fk ", createInspection.sv_inspection_status_id_fk);
            htcreateInspection.Add("@sv_mi_questions ", createInspection.sv_mi_questions);

            htcreateInspection.Add("@sv_inspection_sent_to_id_pk", createInspection.sv_inspection_sent_to_id_pk);
           // htcreateInspection.Add("@sv_inspection_id_fk", createInspection.sv_inspection_id_fk);            
            htcreateInspection.Add("@sv_inspection_sent_to_user_fk ", createInspection.sv_inspection_sent_to_user_fk);
            htcreateInspection.Add("@sv_inspection_is_acknowledged", createInspection.sv_inspection_is_acknowledged);
            htcreateInspection.Add("@sv_inspection_acknowledged_status  ", createInspection.sv_inspection_acknowledged_status);
            htcreateInspection.Add("@sv_inspection_is_completed", createInspection.sv_inspection_is_completed);
            htcreateInspection.Add("@sv_inspection_is_completed_sync", createInspection.sv_inspection_is_completed_sync);
            htcreateInspection.Add("@sv_inspection_is_sync_mobile ", createInspection.sv_inspection_is_sync_mobile);
            htcreateInspection.Add("@sv_inspection_is_archive ", createInspection.sv_inspection_is_archive);            

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_inspection", htcreateInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateNewSentUsers(SiteViewInspection createSentUsers)
        {
            Hashtable htcreateSentUsers = new Hashtable();
            htcreateSentUsers.Add("@sv_inspection_sent_to_id_pk", createSentUsers.sv_inspection_sent_to_id_pk);
            htcreateSentUsers.Add("@sv_inspection_id_fk ", createSentUsers.sv_inspection_id_fk);
            htcreateSentUsers.Add("@sv_inspection_sent_to_user_fk ", createSentUsers.sv_inspection_sent_to_user_fk);
            htcreateSentUsers.Add("@sv_inspection_is_acknowledged", createSentUsers.sv_inspection_is_acknowledged);
            htcreateSentUsers.Add("@sv_inspection_acknowledged_status  ", createSentUsers.sv_inspection_acknowledged_status);
            htcreateSentUsers.Add("@sv_inspection_is_completed", createSentUsers.sv_inspection_is_completed);
            htcreateSentUsers.Add("@sv_inspection_is_completed_sync", createSentUsers.sv_inspection_is_completed_sync);
            htcreateSentUsers.Add("@sv_inspection_is_sync_mobile ", createSentUsers.sv_inspection_is_sync_mobile);
            htcreateSentUsers.Add("@sv_inspection_is_archive ", createSentUsers.sv_inspection_is_archive);             

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_sent_users", htcreateSentUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get Inspection Id

        public static SiteViewInspection GetInspectionId()
        {
            SiteViewInspection inspection = new SiteViewInspection();

            DataTable dtInspectionId = new DataTable();

            try
            {
                dtInspectionId = DataProxy.FetchDataTable("s_sp_get_inspection_id");
                inspection.sv_inspection_id_pk = dtInspectionId.Rows[0]["InspectionId"].ToString();
            }

            catch (Exception)
            {
                throw;
            }

            return inspection;
        }


       
        public static DataTable GetSingleInspectionTemplate(string sv_mi_templete_id_pk)
        {
            Hashtable htgetInspection = new Hashtable();
            htgetInspection.Add("@sv_mi_templete_id_pk", sv_mi_templete_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_inspection_template", htgetInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateInspectionSent(string sv_mi_inspection, string sv_mi_inspection_questions, string sv_mi_inspection_sent_to_user, string sv_mi_inspection_created_by)
        {
            Hashtable htcreateInspection = new Hashtable();
            htcreateInspection.Add("@sv_mi_inspection", sv_mi_inspection);
            htcreateInspection.Add("@sv_mi_inspection_questions ", sv_mi_inspection_questions);
            htcreateInspection.Add("@sv_mi_inspection_sent_to_user", sv_mi_inspection_sent_to_user);
            htcreateInspection.Add("@sv_mi_inspection_created_by", sv_mi_inspection_created_by);            

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_inspection_sent", htcreateInspection);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
