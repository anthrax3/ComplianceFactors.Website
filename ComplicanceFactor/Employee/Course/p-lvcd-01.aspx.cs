using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
namespace ComplicanceFactor.Employee.Course
{
    public partial class p_lvcd_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string deliveryId = Request.QueryString["id"];
                DataSet dsDeliveries = new DataSet();
                if(!IsPostBack)
                {
                    //bind session details
                    dsDeliveries = SystemCatalogBLL.GetDeliveries(deliveryId);
                    gvSession.DataSource = dsDeliveries.Tables[4];
                    gvSession.DataBind();
                    
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
                        Logger.WriteToErrorLog("p-lvcd.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-lvcd.aspx", ex.Message);
                    }
                }
            }
        }

 

        /// <summary>
        /// add session delimiters
        /// </summary>
        /// <param name="location"></param>
        /// <param name="facility"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        private string AddLocationFacilityRoomDelimiters(string location, string facility, string room)
        {
            string strLocationFacilityRoom = string.Empty;

            if (location != "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "]";
            }
            else if (location == "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + room + "]";
            }
            else if (location != "" && facility != "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "]";
            }
            else if (location == "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + room + "]";
            }
            else
            {
                strLocationFacilityRoom = string.Empty;
            }
            return strLocationFacilityRoom;

        }

        /// <summary>
        /// AddInstructorDelimiters
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        private string AddInstructorDelimiters(string instructor)
        {
            string strInstructor = string.Empty;

            if (instructor != "")
            {
                strInstructor = "<br> (" + instructor + ")";
            }
            else
            {
                strInstructor = string.Empty;
            }
            return strInstructor;
        }

        protected void gvSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSession1 = (Label)e.Row.FindControl("lblSession1");
                Label lblSession2 = (Label)e.Row.FindControl("lblSession2");
                lblSession1.Text = DataBinder.Eval(e.Row.DataItem, "c_session_title").ToString() + "<br>" + "(" + DataBinder.Eval(e.Row.DataItem, "c_session_id_pk").ToString() + ")";
                //Get Instructors
                DataTable dtInstructors = new DataTable();
                dtInstructors = SystemCatalogBLL.GetSessionInstructor(gvSession.DataKeys[e.Row.RowIndex].Values[0].ToString());
                string strInstructors = string.Empty;
                for (int i = 0; i < dtInstructors.Rows.Count; i++)
                {
                    strInstructors = strInstructors + dtInstructors.Rows[i]["c_instructor_name"].ToString();
                    strInstructors += (i < dtInstructors.Rows.Count - 1) ? " - " : string.Empty;

                }

                lblSession2.Text = DataBinder.Eval(e.Row.DataItem, "c_session_date")
                                       + AddLocationFacilityRoomDelimiters(DataBinder.Eval(e.Row.DataItem, "c_location_name").ToString(),
                                       DataBinder.Eval(e.Row.DataItem, "c_facility_name").ToString(), DataBinder.Eval(e.Row.DataItem, "c_room_name").ToString())
                                        + AddInstructorDelimiters(strInstructors);


            }
        }

        
    }
}