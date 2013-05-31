using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.Waitlist.Popup
{
    public partial class sasumsm_01 : System.Web.UI.Page
    {
        private static string courseId;
        private static string deliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
                    {
                        courseId = Request.QueryString["courseId"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["deliveryId"]))
                    {
                        deliveryId = Request.QueryString["deliveryId"].ToString();
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
                            Logger.WriteToErrorLog("sasumsm-01 (waitlist)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sasumsm-01 (waitlist)", ex.Message);
                        }
                    }

                }
            }
        }

       
        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Waitlist/Popup/sasumsmr-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&employeeName=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&employeeId=" + SecurityCenter.EncryptText(txtEmployeeId.Text));
        }


    }
}