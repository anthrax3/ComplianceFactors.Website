using System;
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
        public DataTable dtResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadConditions();
            SelectDetails.InnerHtml = string.Empty;

            //Its for Shows the selected users and Course and Delivery
            if (!string.IsNullOrEmpty(SessionWrapper.selectedUserId_learningReport))
            {
                SelectDetails.Style.Add("display", "Block");
                SelectDetails.InnerHtml = "<b>Selected Users: </b>" + SessionWrapper.selectedUserName_learningReport + "<br /><br />";
            }
            if (!string.IsNullOrEmpty(SessionWrapper.selectedCourseId_learningReport))
            {
                SelectDetails.Style.Add("display", "Block");
                SelectDetails.InnerHtml = SelectDetails.InnerHtml + "<b>Selected Courses: </b>" + SessionWrapper.selectedCourseName_learningReport + "<br /><br />";
            }
            if (!string.IsNullOrEmpty(SessionWrapper.selectedDeliveryTypeId_learningReport))
            {
                SelectDetails.Style.Add("display", "Block");
                SelectDetails.InnerHtml = SelectDetails.InnerHtml + "<b>Selected Delivery Type:</b> " + SessionWrapper.selectedDeliveryTypeName_learningReport + "<br /><br />";
            }
            if (!string.IsNullOrEmpty(SessionWrapper.selectedStatusNameText_learningReport))
            {
                SelectDetails.Style.Add("display", "Block");
                SelectDetails.InnerHtml = SelectDetails.InnerHtml + "<b>Selected Completion Status:</b> " + SessionWrapper.selectedStatusNameText_learningReport + "<br /><br />";
            }
        }
        private string GetValues(string id)
        {
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    DataRow[] rows = dtResult.Select("s_report_users_params_param_id_fk = '" + id + "'");
                    if (rows.Length > 0)
                        return dtResult.Select("s_report_users_params_param_id_fk = '" + id + "'")[0][3].ToString();
                    else
                        return "";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
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
                    if (row["s_report_param_type_id_fk"].ToString() != "System Drop-down" && row["s_report_param_type_id_fk"].ToString() != "Button" && row["s_report_param_type_id_fk"].ToString() != "Radio Button list")
                    {
                        Label lbl = new Label();
                        lbl.Text = row["s_report_param_name"].ToString() + ":";

                        HtmlTableCell cell1 = new HtmlTableCell();

                        cell1.Controls.Add(lbl);
                        r.Cells.Add(cell1);

                        TextBox txt = new TextBox();
                        txt.CssClass = "textbox_long";
                        txt.ID = row["s_report_param_system_id_pk"].ToString();
                        txt.Text = GetValues(txt.ID);

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
                    }
                    else if (row["s_report_param_type_id_fk"].ToString() == "Button")
                    {
                        Label lbl = new Label();
                        lbl.Text = row["s_report_param_name"].ToString() + ":";

                        HtmlTableCell cell1 = new HtmlTableCell();

                        cell1.Controls.Add(lbl);
                        r.Cells.Add(cell1);

                        Button btn = new Button();
                        btn.ID = row["s_report_param_system_id_pk"].ToString();
                        if (row["s_report_param_field_id_pk"].ToString() == "u_user_id_pk")
                        {
                            btn.CssClass = "cursor_hand selectusers";
                            btn.OnClientClick = "SelectUsers(); return false;";
                        }
                        else if (row["s_report_param_field_id_pk"].ToString() == "CourseId")
                        {
                            btn.CssClass = "cursor_hand selectcourse";
                            btn.OnClientClick = "SelectCourse(); return false;";
                        }
                        else if (row["s_report_param_field_id_pk"].ToString() == "DeliveryId")
                        {
                            btn.CssClass = "cursor_hand selectdelivery";
                            btn.OnClientClick = "SelectDelivery(); return false;";
                        }
                        else if (row["s_report_param_field_id_pk"].ToString() == "Completionstatus")
                        {
                            btn.CssClass = "cursor_hand selectcompletion";
                            btn.OnClientClick = "SelectCompletionStatus(); return false;";
                        }

                        btn.Text = row["s_report_param_name"].ToString();
                        //
                        HtmlTableCell cell2 = new HtmlTableCell();
                        cell2.Controls.Add(btn);
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
                    }
                    else if (row["s_report_param_type_id_fk"].ToString() == "Radio Button list")
                    {
                        Label lbl = new Label();
                        lbl.Text = row["s_report_param_name"].ToString() + ":";

                        HtmlTableCell cell1 = new HtmlTableCell();

                        cell1.Controls.Add(lbl);
                        r.Cells.Add(cell1);

                        RadioButtonList radioRequired = new RadioButtonList();
                        radioRequired.ID = row["s_report_param_system_id_pk"].ToString();

                        radioRequired.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
                        //radioRequired.RepeatLayout = RepeatLayout.Table;
                        radioRequired.Items.Add(new ListItem("Required", "Required"));
                        radioRequired.Items.Add(new ListItem("Optional", "Optional"));
                        radioRequired.Items.Add(new ListItem("Both", "Both"));


                        HtmlTableCell cell2 = new HtmlTableCell();
                        cell2.Controls.Add(radioRequired);
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

                    }
                    else
                    {
                        Label lbl = new Label();
                        lbl.Text = row["s_report_param_name"].ToString() + ":";

                        HtmlTableCell cell1 = new HtmlTableCell();

                        cell1.Controls.Add(lbl);
                        r.Cells.Add(cell1);

                        DropDownList ddl = new DropDownList();
                        ddl.CssClass = "textbox_long";
                        ddl.ID = row["s_report_param_system_id_pk"].ToString();
                        if (row["s_report_param_field_id_pk"].ToString() == "c_incident_location" ||
                            row["s_report_param_field_id_pk"].ToString() == "c_employee_report_location")
                        {
                            ddl.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                            {
                                s_establishment_id_pk = "",
                                s_establishment_city = "",
                                s_establishment_name = "",
                                s_establishment_status_id_fk = "app_ddl_active_text"
                            });

                            ddl.DataTextField = "s_establishment_name";
                            ddl.DataValueField = "s_establishment_system_id_pk";
                            ddl.DataBind();
                            ddl.Items.Insert(0, new ListItem("", ""));
                            ddl.SelectedValue = GetValues(ddl.ID);
                        }
                        else
                        {
                            string[] items = row["s_report_param_items"].ToString().Split(new char[] { ';' });
                            ddl.Items.Add(new ListItem(""));
                            foreach (string item in items)
                            {
                                ListItem li = new ListItem(item);
                                ddl.Items.Add(li);
                            }
                            ddl.Text = GetValues(ddl.ID);
                        }
                        HtmlTableCell cell2 = new HtmlTableCell();
                        cell2.Controls.Add(ddl);
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
                    txt.Text = GetValues(txt.ID);
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
                    case "System Drop-down":
                        if (row["s_report_param_field_id_pk"].ToString() == "c_incident_location" ||
                         row["s_report_param_field_id_pk"].ToString() == "c_employee_report_location")
                        {
                            row["s_report_param_value"] = ((DropDownList)phConditions.FindControl(row["s_report_param_system_id_pk"].ToString())).SelectedValue;
                        }
                        else
                        {
                            row["s_report_param_value"] = ((DropDownList)phConditions.FindControl(row["s_report_param_system_id_pk"].ToString())).Text;
                        }
                        break;
                    case "Radio Button list":
                        row["s_report_param_value"] = ((RadioButtonList)phConditions.FindControl(row["s_report_param_system_id_pk"].ToString())).SelectedValue;
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
                        if (string.IsNullOrEmpty(row["s_report_param_value"].ToString()))
                        {
                            strCondition += "(" + row["s_report_param_field_id_pk"].ToString() + " like '%" + row["s_report_param_value"] + "%' or "
                            + row["s_report_param_field_id_pk"].ToString() + " is null) and ";
                        }
                        else
                        {
                            strCondition += row["s_report_param_field_id_pk"].ToString() + " like '%" + row["s_report_param_value"] + "%' and ";
                        }
                        break;
                    case "Date":
                        if (row["s_report_param_name"].ToString().ToLower().IndexOf("start") != -1 ||
                            row["s_report_param_name"].ToString().ToLower().IndexOf("from") != -1)
                        {
                            if (!string.IsNullOrEmpty(row["s_report_param_value"].ToString()))
                            {
                                strCondition += row["s_report_param_field_id_pk"].ToString() + " >=#" + row["s_report_param_value"] + "# and ";
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(row["s_report_param_value"].ToString()))
                            {
                                strCondition += row["s_report_param_field_id_pk"].ToString() + " <=#" + row["s_report_param_value"] + "# and ";
                            }
                        }
                        break;
                    case "System Drop-down":
                        if (string.IsNullOrEmpty(row["s_report_param_value"].ToString()))
                        {
                            strCondition += "(" + row["s_report_param_field_id_pk"].ToString() + " like '%" + row["s_report_param_value"] + "%' or "
                            + row["s_report_param_field_id_pk"].ToString() + " is null) and ";
                        }
                        else
                        {
                            strCondition += row["s_report_param_field_id_pk"].ToString() + " like '%" + row["s_report_param_value"] + "%' and ";
                        }
                        break;
                    case "Radio Button list":
                        if (!string.IsNullOrEmpty(row["s_report_param_value"].ToString()))
                        {
                            if (row["s_report_param_value"].ToString() != "Both")
                            {
                                strCondition += row["s_report_param_field_id_pk"].ToString() + " = '" + row["s_report_param_value"] + "' and ";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(strCondition))
            {
                strCondition = strCondition.Substring(0, strCondition.Length - 4);
            }
            return strCondition;
        }
        public void RecordLastGenerate(DataTable dtParams, string commonid, string s_report_system_id_fk, string s_reports_users_system_id)
        {
            if (!string.IsNullOrEmpty(commonid))
            {
                for (int i = 0; i < dtParams.Rows.Count; i++)
                {
                    dtParams.Rows[i]["s_report_param_value"] = commonid;
                }

            }
            MyReportBLL.ManageLastGenerate(s_reports_users_system_id, s_report_system_id_fk, ConvertDataTableToXml(dtParams));

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