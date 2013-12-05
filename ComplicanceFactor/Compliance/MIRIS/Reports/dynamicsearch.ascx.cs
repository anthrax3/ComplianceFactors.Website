﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using AjaxControlToolkit;
namespace ComplicanceFactor.Compliance.MIRIS.Reports
{
    public partial class dynamicsearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["ReportConditions"] = null;
            LoadConditions();
        }
        private void LoadConditions()
        {
            DataTable dtParams = SystemReportBLL.GetParamsOfReport(Request.Params["id"].ToString());
            int i = 0;
            HtmlTableRow r = new HtmlTableRow();
            foreach (DataRow row in dtParams.Rows)
            {
                if (row["s_report_param_type_id_fk"].ToString() != "Date")
                {
                    Label lbl = new Label();
                    lbl.Text = row["s_report_param_name"].ToString() + ":";

                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.Controls.Add(lbl);
                    r.Cells.Add(cell1);

                    TextBox txt = new TextBox();
                    txt.CssClass = "textbox_long";
                    txt.ID = row["s_report_param_system_id_pk"].ToString();


                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.Controls.Add(txt);
                    r.Cells.Add(cell2);

                    if (i % 2 != 0)
                    {
                        phConditions.Controls.Add(r);
                        r = new HtmlTableRow();
                    }
                    else
                    {
                        if (i + 1 == dtParams.Select("s_report_param_type_id_fk <>'Date'").Count())
                        {
                            phConditions.Controls.Add(r);
                        }
                    }

                    i++;
                }
               
            }
            i = 0;
            r = new HtmlTableRow();
            foreach (DataRow row in dtParams.Rows)
            {
                if (row["s_report_param_type_id_fk"].ToString() == "Date")
                {
                    Label lbl = new Label();
                    lbl.Text = row["s_report_param_name"].ToString() + ":";

                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.Controls.Add(lbl);
                    r.Cells.Add(cell1);

                   
                    TextBox txt = new TextBox();
                    txt.CssClass = "textbox_long";
                    txt.ID = row["s_report_param_system_id_pk"].ToString();
                    CalendarExtender ce = new CalendarExtender();
                    ce.TargetControlID = txt.ID;
                  
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.Controls.Add(ce);
                    cell2.Controls.Add(txt);
                    r.Cells.Add(cell2);

                    if (i % 2 != 0)
                    {
                        phConditions.Controls.Add(r);
                        r = new HtmlTableRow();
                    }
                    else
                    {
                        if (i + 1 == dtParams.Select("s_report_param_type_id_fk ='Date'").Count())
                        {
                            phConditions.Controls.Add(r);
                        }
                    }

                    i++;
                }

            }
        }
        public void PopulateCondition(string report_system_id, string s_report_users_system_id_fk)
        {
            DataTable dtParams = SystemReportBLL.GetParamsOfReport(report_system_id);

            dtParams.Columns.Add("s_report_users_last_generate_system_id_pk");
            dtParams.Columns.Add("s_report_users_system_id_fk");
            dtParams.Columns.Add("s_report_param_value");
            foreach (DataRow row in dtParams.Rows)
            {
                row["s_report_users_last_generate_system_id_pk"] = Guid.NewGuid();
                row["s_report_users_system_id_fk"] = s_report_users_system_id_fk;
                switch (row["s_report_param_type_id_fk"].ToString())
                {
                    case "Varchar":
                        row["s_report_param_value"] = ((TextBox)phConditions.FindControl(row["s_report_param_system_id_pk"].ToString())).Text;
                        break;
                    case "Date":
                        row["s_report_param_value"] = ((TextBox)phConditions.FindControl(row["s_report_param_system_id_pk"].ToString())).Text;
                        break;
                    default:
                        break;
                }
                
               
            }
         
            Session["ReportConditions"] = dtParams;
        }
        public string GetCondition(DataTable dtParams)
        {
           
            string strCondition = "";
            foreach (DataRow row in dtParams.Rows)
            {
                switch (row["s_report_param_type_id_fk"].ToString())
                {
                    case "Varchar":
                        strCondition += row["s_report_param_field_id_pk"].ToString() + " like '%" + row["s_report_param_value"] + "%' and ";
                        break;
                    case "Date":
                        if (row["s_report_param_name"].ToString().ToLower().IndexOf("start") != -1 ||
                            row["s_report_param_name"].ToString().ToLower().IndexOf("from") != -1)
                        {
                            strCondition += row["s_report_param_field_id_pk"].ToString() + " >=#" + row["s_report_param_value"] + "# and ";
                        }
                        else
                        {
                            strCondition += row["s_report_param_field_id_pk"].ToString() + " <=#" + row["s_report_param_value"] + "# and ";
                        }
                        break;
                    default:
                        break;
                }
            }
            strCondition = strCondition.Substring(0, strCondition.Length-4);
            return strCondition;
        }
        public void RecordLastGenerate(DataTable dtParams,string commonid,string s_report_system_id_fk, string s_reports_users_system_id)
        {
            if (!string.IsNullOrEmpty(commonid))
            {
                for (int i = 0; i < dtParams.Rows.Count; i++)
                {
                    dtParams.Rows[i]["s_report_param_value"] = commonid;
                }

            }
            MyReportBLL.ManageLastGenerate(s_reports_users_system_id,s_report_system_id_fk, ConvertDataTableToXml(dtParams));

        }
        ///<summary>
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        
    }
}