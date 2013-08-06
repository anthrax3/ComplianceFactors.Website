using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.Popup
{
    public partial class p_sagp_01 : System.Web.UI.Page
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
            }
        }

        protected void btnAddParameter_Click(object sender, EventArgs e)
        {
            //Add parameter
            SystemAssingnmentGroup assignparam = new SystemAssingnmentGroup();
            assignparam.u_assignment_group_id_fk = groupId;
            assignparam.u_assignment_group_param_element_id_fk = ddlElement.SelectedValue;
            assignparam.u_assignment_group_param_operator_id_fk = ddlOperator.SelectedValue;
            assignparam.u_assignment_group_param_values = txtValues.Text;
            SystemAssignmentGroupBLL.AddParameter(assignparam);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

    }
}