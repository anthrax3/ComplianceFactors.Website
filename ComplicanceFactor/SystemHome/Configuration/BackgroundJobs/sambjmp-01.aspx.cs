using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs
{
    public partial class sambjmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtBackgroundjobs = new DataTable();
            DataColumn dccolon;

            //Background Job Name 
            dccolon = new DataColumn();
            dccolon.DataType = Type.GetType("System.String");
            dccolon.ColumnName = "BackgroundJobName";
            dtBackgroundjobs.Columns.Add(dccolon);

            //Frequency
            dccolon = new DataColumn();
            dccolon.DataType = Type.GetType("System.String");
            dccolon.ColumnName = "Frequency";
            dtBackgroundjobs.Columns.Add(dccolon);

            //Time
            dccolon = new DataColumn();
            dccolon.DataType = Type.GetType("System.DateTime");
            dccolon.ColumnName = "Time";
            dtBackgroundjobs.Columns.Add(dccolon);

            //Status
            dccolon = new DataColumn();
            dccolon.DataType = Type.GetType("System.String");
            dccolon.ColumnName = "Status";
            dtBackgroundjobs.Columns.Add(dccolon);

            for (int i = 0; i <= 5; i++)
            {
                DataRow row;
                row = dtBackgroundjobs.NewRow();
                row["BackgroundJobName"] = "Jobname" + i;
                row["Frequency"] = "Frequency" + i;
                row["Time"] = DateTime.Now.ToString();
                row["Status"] = "Status" + i;
                dtBackgroundjobs.Rows.Add(row);
            }

            gvBackgroundJobs.DataSource = dtBackgroundjobs;
            gvBackgroundJobs.DataBind();
        }
    }
}