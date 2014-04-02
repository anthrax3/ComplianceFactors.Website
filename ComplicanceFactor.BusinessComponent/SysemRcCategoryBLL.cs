using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemRcCategoryBLL
    {
       
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRcCategory"></param>
        /// <returns></returns>
        public static int CreateRcCategory(RcaCategory createRcCategory)
        {
            Hashtable htCreateDeliveryTypes = new Hashtable();

            htCreateDeliveryTypes.Add("@c_tb_rc_category_System_id_pk", createRcCategory.c_tb_rc_category_System_id_pk);
            htCreateDeliveryTypes.Add("@c_tb_rc_category_id", createRcCategory.c_tb_rc_category_id);
            htCreateDeliveryTypes.Add("@c_tb_rc_category_title", createRcCategory.c_tb_rc_category_title);
            htCreateDeliveryTypes.Add("@c_tb_rc_category_desc", createRcCategory.c_tb_rc_category_desc);

            htCreateDeliveryTypes.Add("@c_tb_rc_category_type", createRcCategory.c_tb_rc_category_type);
            htCreateDeliveryTypes.Add("@c_tb_rc_category_status", createRcCategory.c_tb_rc_category_status);
           


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_rc_category", htCreateDeliveryTypes);
            }
            catch (Exception)
            {
                throw;
            }



        }
        /// <summary>
        /// Get Delivery Types
        /// </summary>
        /// <param name="c_tb_rc_category_System_id_pk"></param>
        /// <returns></returns>
        public static RcaCategory GetRcCategory(string c_tb_rc_category_System_id_pk)
        {
            RcaCategory rcaCategory;

            try
            {
                Hashtable htGetRcaCategory = new Hashtable();
                htGetRcaCategory.Add("@c_tb_rc_category_system_id_pk", c_tb_rc_category_System_id_pk);
                rcaCategory = new RcaCategory();
                DataTable dtGetRcaCategory = DataProxy.FetchDataTable("s_sp_get_rc_category", htGetRcaCategory);
                rcaCategory.c_tb_rc_category_System_id_pk = dtGetRcaCategory.Rows[0]["c_tb_rc_category_System_id_pk"].ToString();
                rcaCategory.c_tb_rc_category_id = dtGetRcaCategory.Rows[0]["c_tb_rc_category_id"].ToString();
                rcaCategory.c_tb_rc_category_title = dtGetRcaCategory.Rows[0]["c_tb_rc_category_title"].ToString();

                rcaCategory.c_tb_rc_category_desc = dtGetRcaCategory.Rows[0]["c_tb_rc_category_desc"].ToString();
                rcaCategory.c_tb_rc_category_type = dtGetRcaCategory.Rows[0]["c_tb_rc_category_type"].ToString();
                rcaCategory.c_tb_rc_category_status = dtGetRcaCategory.Rows[0]["c_tb_rc_category_status"].ToString();
               
                return rcaCategory;
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRcaCategory"></param>
        /// <returns></returns>
        public static int UpdateRcaCategory(RcaCategory updateRcaCategory)
        {
            Hashtable htUpdateRcaCategory = new Hashtable();

            htUpdateRcaCategory.Add("@c_tb_rc_category_System_id_pk", updateRcaCategory.c_tb_rc_category_System_id_pk);
            htUpdateRcaCategory.Add("@c_tb_rc_category_id", updateRcaCategory.c_tb_rc_category_id);
            htUpdateRcaCategory.Add("@c_tb_rc_category_title", updateRcaCategory.c_tb_rc_category_title);
            htUpdateRcaCategory.Add("@c_tb_rc_category_desc", updateRcaCategory.c_tb_rc_category_desc);

            htUpdateRcaCategory.Add("@c_tb_rc_category_type", updateRcaCategory.c_tb_rc_category_type);
            htUpdateRcaCategory.Add("@c_tb_rc_category_status", updateRcaCategory.c_tb_rc_category_status);
           

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_rc_category", htUpdateRcaCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchRcaCategory(RcaCategory rcaCategory)
        {
            Hashtable htRcaCategory = new Hashtable();
         
            htRcaCategory.Add("@c_tb_rc_category_id", rcaCategory.c_tb_rc_category_id);
            htRcaCategory.Add("@c_tb_rc_category_title", rcaCategory.c_tb_rc_category_title);

            if (rcaCategory.c_tb_rc_category_status == "0")
                htRcaCategory.Add("@c_tb_rc_category_status", DBNull.Value);
            else
                htRcaCategory.Add("@c_tb_rc_category_status", rcaCategory.c_tb_rc_category_status);

            htRcaCategory.Add("@c_tb_rc_category_type", rcaCategory.c_tb_rc_category_type);

            try
            {
                return DataProxy.FetchDataTable("s_sp_rc_category_search", htRcaCategory);
            }
            catch (Exception)
            {
                throw;
            }

        }

      
    }
}
