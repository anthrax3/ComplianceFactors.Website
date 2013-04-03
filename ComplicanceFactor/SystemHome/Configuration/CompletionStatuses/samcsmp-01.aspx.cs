using System;
using System.Data;
using System.Data.SqlClient;
using ComplicanceFactor.BusinessComponent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace ComplicanceFactor.SystemHome.Configuration.Completion_Statuses
{
    public partial class samcsmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind the values into the label values.
            //DataTable dtCompletionStatuses = new DataTable();
            //dtCompletionStatuses = SystemCompletionStatusesBLL.GetLocalCompletionStatuses();
            //hfldAssignId.Value = dtCompletionStatuses.Rows[63]["s_ui_dropdown_id_pk"].ToString();
            //txtlblAssigned.Text = dtCompletionStatuses.Rows[63]["s_ui_dropdown_native"].ToString();
            //txtlblEnrolled.Text = dtCompletionStatuses.Rows[21]["s_ui_dropdown_native"].ToString();
            //txtlblIncomplete.Text = dtCompletionStatuses.Rows[28]["s_ui_dropdown_native"].ToString();
            //txtlblCompleted.Text = dtCompletionStatuses.Rows[29]["s_ui_dropdown_native"].ToString();
            //txtlblBrowse.Text = dtCompletionStatuses.Rows[70]["s_ui_dropdown_native"].ToString();
            //txtlblAttended.Text = dtCompletionStatuses.Rows[71]["s_ui_dropdown_native"].ToString();
            //txtlblDidNotAttend.Text = dtCompletionStatuses.Rows[7]["s_ui_dropdown_native"].ToString();
            //txtlblAttendedWaikIn.Text = dtCompletionStatuses.Rows[47]["s_ui_dropdown_native"].ToString();
            //txtlblUnknown.Text = dtCompletionStatuses.Rows[66]["s_ui_dropdown_native"].ToString();
            //txtlblOltPlayer.Text = dtCompletionStatuses.Rows[19]["s_ui_dropdown_native"].ToString();
            //txtlblVLSSystem.Text = dtCompletionStatuses.Rows[26]["s_ui_dropdown_native"].ToString();
            //txtlblPassed.Text = dtCompletionStatuses.Rows[61]["s_ui_dropdown_native"].ToString();
            //txtlblFailed.Text = dtCompletionStatuses.Rows[76]["s_ui_dropdown_native"].ToString();
            //txtlblExempt.Text = dtCompletionStatuses.Rows[52]["s_ui_dropdown_native"].ToString();
            //txtlblNotScord.Text = dtCompletionStatuses.Rows[69]["s_ui_dropdown_native"].ToString();
            //txtlblPendingAssesmentSurvey.Text = dtCompletionStatuses.Rows[17]["s_ui_dropdown_native"].ToString();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        //protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
            
        //}

        //protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    { 
        //     //txtlblAssigned
        //    }
        //}
    }
}