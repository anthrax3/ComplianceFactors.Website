using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Threading;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Users.AddCurriculum
{
    public partial class sauac_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.Enrollment_curriculum_from_user = TempDataTables.TempEnrollmentCourseCurriculum();
                SessionWrapper.Enrollment_curriculum_from_user.Clear();
            }

            if (SessionWrapper.Enrollment_curriculum_from_user.Rows.Count > 0 && (hdCheckdelivery.Value != "1" || string.IsNullOrEmpty(hdCheckdelivery.Value)))
            {
                gvCatalog.DataSource = SessionWrapper.Enrollment_curriculum_from_user;
                gvCatalog.DataBind();
                hdCheckdelivery.Value = "1";
            }
        }
        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sysId = DataBinder.Eval(e.Row.DataItem, "sysId").ToString();
                string type = DataBinder.Eval(e.Row.DataItem, "type").ToString();
                CheckBox chkSelectDelivery = (CheckBox)e.Row.FindControl("chkSelectDelivery");
                DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                //Button btnViewDetails = (Button)e.Row.FindControl("btnViewDetails");
                Literal ltlViewDetails = (Literal)e.Row.FindControl("ltlViewDetails");
                if (type == "Course")
                {
                    chkSelectDelivery.Style.Add("display", "inline");
                    ddlDelivery.Style.Add("display", "inline");
                    //btnViewDetails.Style.Add("display", "none");
                }
                else
                {
                    chkSelectDelivery.Style.Add("display", "none");
                    ddlDelivery.Style.Add("display", "none");
                    //btnViewDetails.Style.Add("display", "inline"); Style='float:left;margin-left:70px;'
                    ltlViewDetails.Text = "<input type= 'button' id =" + sysId + " value='" + LocalResources.GetGlobalLabel("app_view_details_button_text") + "' class='viewdetails cursor_hand'  align='center'/> ";
                }
            }
        }

        //Delete courseCurriculum
        [System.Web.Services.WebMethod]
        public static void DeleteCurriculum(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.Enrollment_curriculum_from_user.Select("sysId= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Enrollment_curriculum_from_user.AcceptChanges();
            }
            catch (Exception ex)
            {//Enrollment_curriculum_from_user
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sausc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sausc-01", ex.Message);
                    }
                }
            }

        }

        protected void btnProcessMassEnrollment_Click(object sender, EventArgs e)
        {

            AssignCurriculum();
            if (SessionWrapper.Enrollment_curriculum_from_user.Rows.Count > 0)
            {
                divSuccess.Style.Add("display", "block");
                divSuccess.InnerText = "Curriculum Was Added Successfully";
            }
        }

        /// <summary>
        /// Temp Datatable for Curriculum
        /// </summary>
        /// <returns></returns>
        private DataTable TempCurriculumDatatable()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "curriculum_id";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "required";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "DueDate";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }

        /// <summary>
        /// Assign Curriculum process
        /// </summary>
        private void AssignCurriculum()
        {
            DataTable dtCurriculum = TempCurriculumDatatable();
            for (int i = 0; i < SessionWrapper.Enrollment_curriculum_from_user.Rows.Count; i++)
            {
                if (SessionWrapper.Enrollment_curriculum_from_user.Rows[i]["type"].ToString() == "Curriculum")
                {
                    DataRow curriculumrow;
                    curriculumrow = dtCurriculum.NewRow();
                    curriculumrow["curriculum_id"] = SessionWrapper.Enrollment_curriculum_from_user.Rows[i]["sysId"].ToString();
                    curriculumrow["employeeID"] = Request.QueryString["userId"];
                    curriculumrow["required"] = chkRequired.Checked;
                    curriculumrow["DueDate"] = TryParse(txtTargetDueDate.Text);
                    dtCurriculum.Rows.Add(curriculumrow);
                }
            }
            ConvertDataTables ConvertToXml = new ConvertDataTables();
            DataSet dsSingleOLTCourseFromCurriculum = new DataSet();
            try
            {
                dsSingleOLTCourseFromCurriculum = SystemMassEnrollmentBLL.Curriculum_Assign(ConvertToXml.ConvertDataTableToXml(dtCurriculum), SessionWrapper.u_userid);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sausc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sausc-01", ex.Message);
                    }
                }
            }
            SystemCatalog Course = new SystemCatalog();
            User edituser = new User();
            StringBuilder sbConfirmEnrollment = new StringBuilder();
            DataTable dtSingleOLTCourseFromCurriculum = dsSingleOLTCourseFromCurriculum.Tables[dsSingleOLTCourseFromCurriculum.Tables.Count-1];
            if (dtSingleOLTCourseFromCurriculum.Rows.Count > 0)
            {
                for (int i = 0; i <= dtSingleOLTCourseFromCurriculum.Rows.Count - 1; i++)
                {
                    string curr_deliveryId = dtSingleOLTCourseFromCurriculum.Rows[i]["c_delivery_system_id_pk"].ToString();
                    string curr_employeeId = dtSingleOLTCourseFromCurriculum.Rows[i]["employeeId"].ToString();

                    Course = SystemCatalogBLL.GetSingleDeliveryList(curr_deliveryId);
                    edituser = UserBLL.GetUserInfo_by_id(curr_employeeId);

                    if (Course.c_delivery_type_id == "OLT")
                    {
                        SystemNotification notification = new SystemNotification();
                        notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT", SessionWrapper.CultureName);
                        if (notification.s_notification_on_off_flag == true)
                        {
                            //Enroll OLT
                            string confirmOLTSubject = string.Empty;
                            confirmOLTSubject = notification.s_notification_email_subject;
                            confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string sbConfirmOLT = string.Empty;
                            sbConfirmOLT = notification.s_notification_email_text;

                            sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", Course.c_created_name);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                            sbConfirmEnrollment.Clear();

                            List<MailAddress> mailAddresses = new List<MailAddress>();

                            if (!string.IsNullOrEmpty(edituser.EmailId))
                            {
                                Thread threadSendMails;
                                threadSendMails = new Thread(delegate()
                                {
                                    mailAddresses.Add(new MailAddress(edituser.EmailId));
                                    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                    sbConfirmEnrollment.Append(sbConfirmOLT);
                                    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
                                });
                                threadSendMails.IsBackground = true;
                                threadSendMails.Start();

                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(edituser.MobileNumber))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = edituser.MobileNumber.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notification.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");

                                    if (messagetext.Length > 180)
                                    {
                                        messagetext = messagetext.Substring(0, 179);
                                    }
                                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                }
            }             
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}