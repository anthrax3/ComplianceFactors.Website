using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog.Audiences.Popup
{
    public partial class p_saap_01 : System.Web.UI.Page
    {
        private static string groupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // Get assignment groups id
                    groupId = Request.QueryString["id"].ToString();
                }
                //Bind Elementd
                ddlElement.DataSource = SystemAssignmentGroupBLL.GetAssignmentElement();
                ddlElement.DataBind();
                //Bind Operator
                ddlOperator.DataSource = SystemAssignmentGroupBLL.GetAssignmentOperator();
                ddlOperator.DataBind();
            }
        }

        protected void btnAddParameter_Click(object sender, EventArgs e)
        {
            //Add parameter
            divError.Style.Add("display", "none");
            divSuccess.Style.Add("display", "none");
            SystemAudiences assignparam = new SystemAudiences();
            /// Hash encryption for username and password
            /// </summary>
            HashEncryption encHash = new HashEncryption();
            assignparam.u_audience_id_fk = groupId;
            if (ddlElement.SelectedValue == "Assigned" || ddlElement.SelectedValue == "Enrolled" || ddlElement.SelectedValue == "Completed" || ddlElement.SelectedValue == "Passed" || ddlElement.SelectedValue == "Failed")
            {
                assignparam.u_audience_param_values = null;
                assignparam.u_audience_param_operator_id_fk = null;
            }
            else
            {

                if (ddlElement.SelectedValue == "u_username_enc" && !string.IsNullOrEmpty(txtValues.Text))
                {
                    string[] usernames = txtValues.Text.Split(',');
                    for (int i = 0; i < usernames.Length; i++)
                    {
                        assignparam.u_audience_param_values += encHash.GenerateHashvalue(usernames[i], true) + ",";
                    }
                    assignparam.u_audience_param_values = assignparam.u_audience_param_values.TrimEnd(',');
                }
                else
                {
                    assignparam.u_audience_param_values = txtValues.Text;
                }
                assignparam.u_audience_param_operator_id_fk = ddlOperator.SelectedValue;
            }
            assignparam.u_audience_param_element_id_fk = ddlElement.SelectedValue;

            int error = SystemAudiencesBLL.AddAudienceParameter(assignparam);
            if (error != -1)
            {
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerText = "Inserted successfully";
                //divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "HideMsg();", true);
            }
            else
            {
                divError.Style.Add("display", "block");
                divSuccess.Style.Add("display", "none");
                divError.InnerText = "Parameter was not inseterd";
                //divError.InnerText = LocalResources.GetText("app_date_not_inserted_error_wrong");
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}