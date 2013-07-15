using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
namespace ComplicanceFactor.SystemHome.Configuration.BackgroundJobs
{
    public partial class sambjmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_manage_background_jobs_text") + "</a>";

                
                gvBackgroundJobs.DataSource = SystemBackgroundJobsBLL.GetBackgroundJobs();
                gvBackgroundJobs.DataBind();

                SessionWrapper.BackgroundJobs = SystemBackgroundJobsBLL.GetBackgroundJobs();
            }
        }

        protected void gvBackgroundJobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DataRowView drheader = (DataRowView)e.Row.DataItem;
                    string time = Convert.ToString(drheader["u_sftp_time_every"]);

                    int length = time.Length;
                    DropDownList ddlTime = (DropDownList)e.Row.FindControl("ddlTime");
                    ddlTime.SelectedValue = time.Substring(length-2,2);


                    TextBox txtTime = (TextBox)e.Row.FindControl("txtTime");
                    txtTime.Text = time.Substring(0,length-2);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sambjmp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sambjmp-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvBackgroundJobs.Rows)
            {
                //TextBox txtOccursEvery = (TextBox)row.FindControl("txtOccursEvery");
                //TextBox txtTime = (TextBox)row.FindControl("txtTime");
                //DropDownList ddlTime = (DropDownList)row.FindControl("ddlTime");
                //string u_sftp_id_pk = gvBackgroundJobs.DataKeys[row.RowIndex].Value.ToString();
                //var rows = SessionWrapper.BackgroundJobs.Select("u_sftp_id_pk='" + u_sftp_id_pk + "'");
                //var indexOfRow = SessionWrapper.BackgroundJobs.Rows.IndexOf(rows[0]);
                //SessionWrapper.BackgroundJobs.Rows[indexOfRow]["u_sftp_time_every"] = txtTime.Text;
                //SessionWrapper.BackgroundJobs.Rows[indexOfRow]["u_sftp_occurs_every"] = txtOccursEvery.Text;
            }
        }
    }
}