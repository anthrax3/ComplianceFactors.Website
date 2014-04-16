using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance.MIRIS.Controls
{
    public partial class uccb_01 : System.Web.UI.UserControl
    {
        private string _uc_values;
        public string _checkboxs;
        public string uc_values 
        {
            get { return Request.Params["chkvalue"]; }
            set { _uc_values = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }

        private void OutputOptions(string setval)
        {
            StringBuilder builder = new StringBuilder();
            DataTable source = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
            string[] values = setval.Split(',');
            bool check = false;
            foreach (DataRow row in source.Rows)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Trim() == row["c_type_id"].ToString().Trim())
                    {
                        check = true;
                        break;
                    }
                }

                builder.Append("<td class=\"width_180\">");
                builder.Append(row["c_type_name"].ToString());
                builder.Append("</td>");
                builder.Append("<td class=\"width_180 align_left\">");
                if (check)
                {
                    builder.Append("<input type=\"checkbox\" name=\"chkvalue\" checked  value=\"" + row["c_type_id"].ToString() + "\" />");
                    check = false;
                }
                else
                {
                    builder.Append("<input type=\"checkbox\" name=\"chkvalue\"  value=\"" + row["c_type_id"].ToString() + "\" />");
                }
               
                builder.Append("</td>");
            }
            _checkboxs = builder.ToString();
        }

        public void show(string setval)
        {
            
            OutputOptions(setval);
         
        }
    }
}