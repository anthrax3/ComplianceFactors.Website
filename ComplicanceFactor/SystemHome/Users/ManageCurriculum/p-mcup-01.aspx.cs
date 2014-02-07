using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Users.ManageCurriculum
{
    public partial class p_mcup_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCurriculum();
            }
            if (hdIsCurriculumBind.Value == "1")
            {
                GetAllCurriculum();
            }
        }

        /// <summary>
        /// Bind My Curriculum
        /// </summary>
        private void GetAllCurriculum()
        {
            try
            {
                DataSet dsEmployee = EmployeeBLL.GetAllEmployeeFromUser(Request.QueryString["id"]);
                gvCurriculum.DataSource = dsEmployee.Tables[1];
                gvCurriculum.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcup-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcup-01", ex.Message);
                    }
                }
            }
            hdEditUser.Value = Request.QueryString["id"];

            if (gvCurriculum.Rows.Count > 0)
            {
                gvCurriculum.UseAccessibleHeader = true;
                if (gvCurriculum.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCurriculum.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataTable dtUpdateCurriculum = TempUpdateMyCurriculum();
            DataTable dtRemoveCurriculum = TempRemoveCurriculum();

            foreach (GridViewRow row in gvCurriculum.Rows)
            {
                CheckBox chkRemove = (CheckBox)row.FindControl("chkRemove");
                if (chkRemove.Checked == true)
                {
                    string c_curriculum_id_pk = gvCurriculum.DataKeys[row.RowIndex][0].ToString();
                    DataRow curriculumrow;
                    curriculumrow = dtRemoveCurriculum.NewRow();
                    curriculumrow["curriculum_id"] = c_curriculum_id_pk;
                    curriculumrow["user_id"] = Convert.ToString(Request.QueryString["id"]);
                    dtRemoveCurriculum.Rows.Add(curriculumrow);
                }
                else
                {
                    TextBox txtduedate = (TextBox)row.FindControl("txtduedate");
                    string c_course_id_pk = gvCurriculum.DataKeys[row.RowIndex][0].ToString();
                    DataRow curriculumrow;
                    curriculumrow = dtUpdateCurriculum.NewRow();
                    curriculumrow["curriculum_id"] = c_course_id_pk;
                    curriculumrow["user_id"] = Convert.ToString(Request.QueryString["id"]);
                    if (!string.IsNullOrEmpty(txtduedate.Text))
                    {
                        curriculumrow["duedate"] = txtduedate.Text;
                    }
                    else
                    {
                        curriculumrow["duedate"] = DBNull.Value;
                    }
                    dtUpdateCurriculum.Rows.Add(curriculumrow);
                }
            }

            ConvertDataTables convert = new ConvertDataTables();

            try
            {
                //Update Curriculum Details
                int result = EnrollmentBLL.UpdateCurriculumDetailsFromUser(convert.ConvertDataTableToXml(dtUpdateCurriculum));
                if (dtRemoveCurriculum.Rows.Count > 0)
                {
                    EnrollmentBLL.DropCurriculumFromUser(convert.ConvertDataTableToXml(dtRemoveCurriculum));
                }
                if (result == 1)
                {
                    //Drop Curriculum
                    GetAllCurriculum();
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Curriculum Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-mcup-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-mcup-01", ex.Message);
                    }
                }
            }


        }

        /// <summary>
        /// Temp datatable for update my curriculum
        /// </summary>
        /// <returns></returns>
        private DataTable TempUpdateMyCurriculum()
        {
            DataTable dtTempUpdateMyCurriculum = new DataTable();
            DataColumn dtUpdateMyCurriculumColumn;

            dtUpdateMyCurriculumColumn = new DataColumn();
            dtUpdateMyCurriculumColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCurriculumColumn.ColumnName = "curriculum_id";
            dtTempUpdateMyCurriculum.Columns.Add(dtUpdateMyCurriculumColumn);

            dtUpdateMyCurriculumColumn = new DataColumn();
            dtUpdateMyCurriculumColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCurriculumColumn.ColumnName = "user_id";
            dtTempUpdateMyCurriculum.Columns.Add(dtUpdateMyCurriculumColumn);


            dtUpdateMyCurriculumColumn = new DataColumn();
            dtUpdateMyCurriculumColumn.DataType = Type.GetType("System.String");
            dtUpdateMyCurriculumColumn.ColumnName = "duedate";
            dtTempUpdateMyCurriculum.Columns.Add(dtUpdateMyCurriculumColumn);

            return dtTempUpdateMyCurriculum;
        }

        private DataTable TempRemoveCurriculum()
        {
            DataTable dtTempRemoveMyCurriculum = new DataTable();
            DataColumn dtRemoveMyCurriculumColumn;

            dtRemoveMyCurriculumColumn = new DataColumn();
            dtRemoveMyCurriculumColumn.DataType = Type.GetType("System.String");
            dtRemoveMyCurriculumColumn.ColumnName = "curriculum_id";
            dtTempRemoveMyCurriculum.Columns.Add(dtRemoveMyCurriculumColumn);

            dtRemoveMyCurriculumColumn = new DataColumn();
            dtRemoveMyCurriculumColumn.DataType = Type.GetType("System.String");
            dtRemoveMyCurriculumColumn.ColumnName = "user_id";
            dtTempRemoveMyCurriculum.Columns.Add(dtRemoveMyCurriculumColumn);

            return dtTempRemoveMyCurriculum;
        }
    }
}