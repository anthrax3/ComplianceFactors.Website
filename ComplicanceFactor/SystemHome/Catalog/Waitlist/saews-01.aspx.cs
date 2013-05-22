using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Text;
using System.Configuration;
using System.Net.Mail;

namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class saews_01 : System.Web.UI.Page
    {
        private static string courseId;
        private static string deliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.isWaitlistAdded = false;

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "System" + "&nbsp;>&nbsp;" + "Manage Waitlist" + "&nbsp;>&nbsp;" + "Edit Waitlist Information";

                if (!string.IsNullOrEmpty(Request.QueryString["process"]))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["waitlistId"].ToString()) && !string.IsNullOrEmpty(Request.QueryString["userId"].ToString()))
                    {
                        string waitlistId = SecurityCenter.DecryptText(Request.QueryString["waitlistId"].ToString());
                        string userId = SecurityCenter.DecryptText(Request.QueryString["userId"].ToString());
                        MoveToRoaster(waitlistId, userId);
                    }
                }
                if (!string.IsNullOrEmpty(Request.QueryString["deliveryId"]))
                {

                    deliveryId = SecurityCenter.DecryptText(Request.QueryString["deliveryId"].ToString());
                    hdnDeliveryId.Value = SecurityCenter.EncryptText(deliveryId);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
                {
                    courseId = SecurityCenter.DecryptText(Request.QueryString["courseId"].ToString());
                    hdnCourseId.Value = SecurityCenter.EncryptText(courseId);
                }

                SessionWrapper.Reset_WaitList = SystemWaitListBLL.GetAllWaitList(deliveryId);

                PopulateWaitList();
            }
            if (SessionWrapper.isWaitlistAdded == true)
            {
                //gvWaitlistDetails.DataSource = SystemWaitListBLL.GetAllWaitList(deliveryId);
                //gvWaitlistDetails.DataBind();
                PopulateWaitList();
                SessionWrapper.isWaitlistAdded = false;
            }
        }

        private void PopulateWaitList()
        {
            SystemCatalog catalog = new SystemCatalog();
            try
            {
                catalog = SystemWaitListBLL.GetDeliveryDetails(deliveryId);
                lblCourseName.Text = catalog.c_course_title;
                if (!string.IsNullOrEmpty(catalog.c_session_end_date_time))
                {
                    DateTime dt = Convert.ToDateTime(catalog.c_session_end_date_time);
                    lblDeliveryEnd.Text = dt.ToShortDateString();
                }

                lblDeliveryId.Text = catalog.c_delivery_id_pk;
                lblDeliveryName.Text = catalog.c_delivery_title;
                //string c_session_start_date = catalog.c_session_start_date.ToString();
                if (!string.IsNullOrEmpty(catalog.c_session_start_date_time))
                {
                    DateTime dt = Convert.ToDateTime(catalog.c_session_start_date_time);
                    lblDeliveryStart.Text = dt.ToShortDateString();
                }
                lblMaxEnroll.Text = catalog.c_delivery_max_enroll.ToString();
                lblMinEnroll.Text = catalog.c_delivery_min_enroll.ToString();
                lblWaitlistId.Text = "";

                int? maxWaitlist = 0;
                if (!string.IsNullOrEmpty(catalog.c_delivery_max_waitlist.ToString()))
                {
                    maxWaitlist = catalog.c_delivery_max_waitlist;
                }
                DataTable dtWaitlist = new DataTable();
                dtWaitlist = SystemWaitListBLL.GetAllWaitList(deliveryId);

                lblWaitlistStatus.Text = "Waitlist (" + Convert.ToString(dtWaitlist.Rows.Count) + "/" + Convert.ToString(maxWaitlist.Value) + ")";

                int remainingRows = maxWaitlist.Value - dtWaitlist.Rows.Count;
                if (remainingRows > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < remainingRows; i++)
                    {
                        dr = dtWaitlist.NewRow();
                        dr[0] = Guid.NewGuid().ToString();
                        dr[1] = Guid.NewGuid().ToString();
                        dr[2] = dr[3] = dr[4] = dr[5] = dr[8] = dr[9] = dr[10] = "";
                        dr[7] = dr[6] = dtWaitlist.Rows.Count + 1;
                        dr[11] = dr[12] = Guid.NewGuid().ToString();
                        //index goes the no of cols in the table
                        dtWaitlist.Rows.Add(dr);
                    }
                    dtWaitlist.AcceptChanges();
                }

                SessionWrapper.WaitList_details = dtWaitlist;
                gvWaitlistDetails.DataSource = SessionWrapper.WaitList_details;
                gvWaitlistDetails.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saews-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saews-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void gvWaitlistDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Up"))
            {
                GridView GridView1 = (GridView)sender;
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string currentId = GridView1.DataKeys[gvRowIndex][0].ToString();
                string previousId = GridView1.DataKeys[gvRowIndex - 1][0].ToString();
                int sequenceNumber = Convert.ToInt16(GridView1.DataKeys[gvRowIndex][1]);
                SystemWaitListBLL.UpdateWaitListSeqNumberforUp(currentId, previousId);
                //Rankup(currentId, sequenceNumber);

            }
            else if (e.CommandName.Equals("Down"))
            {
                GridView GridView1 = (GridView)sender;
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string currentId = GridView1.DataKeys[gvRowIndex][0].ToString();
                string nextId = GridView1.DataKeys[gvRowIndex + 1][0].ToString();
                int sequenceNumber = Convert.ToInt16(GridView1.DataKeys[gvRowIndex][1]);
                SystemWaitListBLL.UpdateWaitListSeqNumberforDown(currentId, nextId);
            }
            PopulateWaitList();
        }

        protected void gvWaitlistDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //GridViewRow FirstRow = gvWaitlistDetails.Rows[0];
                //Button btnUp = (Button)FirstRow.FindControl("btnUp");
                //btnUp.Enabled = false;
                //GridViewRow LastRow = gvWaitlistDetails.Rows[gvWaitlistDetails.Rows.Count - 1];
                //Button btnDown = (Button)LastRow.FindControl("btnDown");
                //btnDown.Enabled = false;

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string attendenceName = Convert.ToString(drv["employee_Name"]);

                DataRowView drpassing = (DataRowView)e.Row.DataItem;
                string waitlist = Convert.ToString(drpassing["e_enroll_waitlist_system_id_pk"]);

                string encwaitlist = SecurityCenter.EncryptText(waitlist);

                DataRowView druser = (DataRowView)e.Row.DataItem;
                string userId = SecurityCenter.EncryptText(Convert.ToString(drpassing["e_enroll_waitlist_user_id_fk"]));

                DataRowView drpriority = (DataRowView)e.Row.DataItem;
                int priority = Convert.ToInt16(drpriority["e_enroll_waitlist_user_priority"]);

                DropDownList ddlPriority = (DropDownList)e.Row.FindControl("ddlPriority");
                ddlPriority.SelectedValue = priority.ToString();

                Literal ltlRoaster = (Literal)e.Row.FindControl("ltlRoaster");
                Literal ltlRemove = (Literal)e.Row.FindControl("ltlRemove");
                Literal ltlAdd = (Literal)e.Row.FindControl("ltlAdd");

                if (!string.IsNullOrEmpty(attendenceName))
                {
                    ltlRoaster.Text = "<input id=" + encwaitlist + ',' + userId + " class='moveRoaster cursor_hand' type='button' value='Move to Roaster'/>";
                    //ltlRoaster.Text = "<input id=" + + ',' + + ','+userId+ " class='moveRoaster cursor_hand' type='button' value='Move to Roaster'/>";
                    ltlRemove.Text = "<input id=" + waitlist + ','+courseId+ ','+ deliveryId+" class='removeWaitlist cursor_hand' type='button' value='Remove' />";
                }
                else
                {
                    ltlRoaster.Visible = false;
                    ltlRemove.Visible = false;
                    ltlAdd.Visible = true;
                    ltlAdd.Text = "<input id=" + courseId + ',' + deliveryId + " class='addUser cursor_hand' type='button' value='Add' />";
                    //Button btnRoaster = (Button)e.Row.FindControl("btnManageRoster");
                    //Button btnRemove = (Button)e.Row.FindControl("btnRemove");
                    //Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                    //btnAdd.Visible = true;
                    //btnRoaster.Visible = false;
                    //btnRemove.Visible = false;
                }
            }
        }

        private void MoveToRoaster(string waitlistId, string userId)
        {
            //process enrollment and delete the record from waitlist table

            Enrollment enrollOLT = new Enrollment();
            //enrollOLT.e_check_course_approval = true;//Check yhe current course id is approval required
            //enrollOLT.e_check_delivery_approval = true;//Check yhe current delivery id is approval required
            enrollOLT.e_enroll_user_id_fk = userId;
            enrollOLT.e_enroll_delivery_id_fk = deliveryId;
            enrollOLT.e_enroll_course_id_fk = courseId;
            enrollOLT.e_enroll_required_flag = false;
            enrollOLT.e_enroll_approval_required_flag = false;
            enrollOLT.e_enroll_type_name = "Manager Enroll";
            //enrollOLT.e_enroll_approval_status_name = "Pending";
            enrollOLT.e_enroll_status_name = "Enrolled";
            DateTime? target_due_date = null;
            DateTime temp_target_due_date;
            string strTemp = string.Empty;
            if (DateTime.TryParse(strTemp, out temp_target_due_date))
            {
                target_due_date = temp_target_due_date;
            }
            //DateTime tempEnrollTargetDueDate;
            enrollOLT.e_enroll_target_due_date = target_due_date;
            enrollOLT.e_course_waitlist_system_id_pk = waitlistId;
            try
            {
                SystemWaitListBLL.SingleEnroll(enrollOLT);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }
            SendConfirmationEmail(userId);
            Response.Redirect("~/SystemHome/Catalog/Waitlist/saews-01.aspx?deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&courseId=" + SecurityCenter.EncryptText(courseId), false);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            SystemCatalog waitlistReset = new SystemCatalog();
            waitlistReset.c_course_id_pk = courseId;
            waitlistReset.c_delivery_id_pk = deliveryId;
            waitlistReset.s_reset_waitlist = ConvertDataTableToXml(SessionWrapper.Reset_WaitList);

            try
            {
                int result = SystemWaitListBLL.ResetWaitlist(waitlistReset);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }
            PopulateWaitList();
        }

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

        private void SendConfirmationEmail(string userid)
        {
            try
            {
                User user = new User();
                user = UserBLL.GetUserInfo_by_id(userid);

                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryId);
                StringBuilder sbConfirmEnrollment = new StringBuilder();

                string deliveryType = SystemWaitListBLL.GetDeliveryType(deliveryId);  

                //For Couese Title and Course Id
                SystemCatalog courseDetails = new SystemCatalog();
                courseDetails = EnrollmentBLL.GetCourseDetails(deliveryId);

                if (deliveryType == "OLT")
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

                        sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
                        sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", courseDetails.c_course_title);
                        sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", courseDetails.c_course_id_pk);

                        string toEmailid = user.EmailId;
                        if (!string.IsNullOrEmpty(toEmailid))
                        {
                            string[] toaddress = toEmailid.Split(',');
                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            foreach (string recipient in toaddress)
                            {
                                if (recipient.Trim() != string.Empty)
                                {
                                    mailAddresses.Add(new MailAddress(recipient));
                                }
                            }
                            string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                            sbConfirmEnrollment.Append(sbConfirmOLT);
                            Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                            {
                                StringBuilder smsText = new StringBuilder();
                                string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                string messagetext = notification.s_notification_SMS_text;
                                messagetext = messagetext.Replace("", "");
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
                //Enroll ILT/VLT
                else if ((deliveryType == "ILT" || deliveryType == "VLT"))
                {
                    SystemNotification notificationILT = new SystemNotification();
                    notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON", SessionWrapper.CultureName);
                    if (notificationILT.s_notification_on_off_flag == true)
                    {
                        string confirmILTSubject = string.Empty;
                        confirmILTSubject = notificationILT.s_notification_email_subject;
                        confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                        string confirmILT = string.Empty;
                        confirmILT = notificationILT.s_notification_email_text;

                        confirmILT = confirmILT.Replace("@$&User First Name&$@", user.Firstname);
                        confirmILT = confirmILT.Replace("@$&Course Name&$@", courseDetails.c_course_title);
                        confirmILT = confirmILT.Replace("@$&Course ID&$@", courseDetails.c_course_id_pk);
                        confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
                        confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
                        confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
                        confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
                        confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
                        confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

                        string toEmailid = user.EmailId;//Course.c_to_address;
                        if (!string.IsNullOrEmpty(toEmailid))
                        {
                            string[] toaddress = toEmailid.Split(',');
                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            foreach (string recipient in toaddress)
                            {
                                if (recipient.Trim() != string.Empty)
                                {
                                    mailAddresses.Add(new MailAddress(recipient));
                                }
                            }
                            string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                            sbConfirmEnrollment.Append(confirmILT);
                            Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                            {
                                StringBuilder smsText = new StringBuilder();
                                string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                string messagetext = notificationILT.s_notification_SMS_text;
                                messagetext = messagetext.Replace("", "");
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
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) sawes-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) sawes-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            DataTable dtUpdateWaitlist = UpdateWaitlist();
            DataRow dr;
            foreach (GridViewRow row in gvWaitlistDetails.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[1].Text))
                {
                    string e_waitlist_system_id_pk = gvWaitlistDetails.DataKeys[row.RowIndex][0].ToString();
                    DropDownList ddlPriority = (DropDownList)row.FindControl("ddlPriority");
                    string e_enroll_waitlist_user_priority = ddlPriority.SelectedValue;
                    dr = dtUpdateWaitlist.NewRow();
                    dr["e_enroll_waitlist_system_id_pk"] = e_waitlist_system_id_pk;
                    dr["e_enroll_waitlist_user_priority"] = e_enroll_waitlist_user_priority;
                    dtUpdateWaitlist.Rows.Add(dr);
                }
            }

            if (dtUpdateWaitlist.Rows.Count > 0)
            {
                String updatexml = ConvertDataTableToXml(dtUpdateWaitlist);

                try
                {
                    SystemWaitListBLL.UpdatePriority(updatexml);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sawes-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sawes-01.aspx", ex.Message);
                        }
                    }
                }
            }

        }

        private DataTable UpdateWaitlist()
        {
            DataTable dtupdateWaitlist = new DataTable();
            DataColumn dtTempWaitlistColumn;

            dtTempWaitlistColumn = new DataColumn();
            dtTempWaitlistColumn.DataType = Type.GetType("System.String");
            dtTempWaitlistColumn.ColumnName = "e_enroll_waitlist_system_id_pk";
            dtupdateWaitlist.Columns.Add(dtTempWaitlistColumn);

            //s_resource_locale_description
            dtTempWaitlistColumn = new DataColumn();
            dtTempWaitlistColumn.DataType = Type.GetType("System.String");
            dtTempWaitlistColumn.ColumnName = "e_enroll_waitlist_user_priority";
            dtupdateWaitlist.Columns.Add(dtTempWaitlistColumn);

            return dtupdateWaitlist;
        }

        [System.Web.Services.WebMethod]
        public static void DeleteWaitList(string args, string args2, string args3)
        {
            //update the enrollment table to inactive= false
            try
            {
                int result = SystemWaitListBLL.DeleteWaitlist(args, args2, args3);
                //SessionWrapper.isWaitlistAdded = true;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }

        }


        //private void Rankup(string currentId, int  seqnumber)
        //{
        //    try
        //    {
        //        //sort the course then get the index of the course
        //        DataTable dtWaitingList = new DataTable();
        //        //Get particular course from section
        //        dtWaitingList = SessionWrapper.WaitList_details;

        //        //get current index
        //        var rows = dtWaitingList.Select("e_enroll_waitlist_system_id_pk='" + currentId + "' ", "e_enroll_waitlist_user_sequence ASC");
        //        var indexOfRow = dtWaitingList.Rows.IndexOf(rows[0]);
        //        if (indexOfRow > 0)
        //        {
        //            //update
        //            dtWaitingList.Rows[indexOfRow]["e_enroll_waitlist_user_sequence"] = seqnumber - 1;
        //            dtWaitingList.Rows[indexOfRow - 1]["e_enroll_waitlist_user_sequence"] = seqnumber;
        //            dtWaitingList.AcceptChanges();                  

        //        }

        //        SessionWrapper.WaitList_details = dtWaitingList;


        //        //DataRow[] currentrows = SessionWrapper.WaitList_details.Select("e_enroll_waitlist_system_id_pk= '" + currentId + "'");
        //        //foreach (var row in currentrows)
        //        //    row["e_enroll_waitlist_user_sequence"] = Convert.ToInt16(row["e_enroll_waitlist_user_sequence"])-1;
        //        //SessionWrapper.WaitList_details.AcceptChanges();

        //        //DataRow[] previousrows = SessionWrapper.WaitList_details.Select("e_enroll_waitlist_system_id_pk= '" + previousId + "'");
        //        //foreach (var row in previousrows)
        //        //    row["e_enroll_waitlist_user_sequence"] = Convert.ToInt16(row["e_enroll_waitlist_user_sequence"]) + 1;
        //        //SessionWrapper.WaitList_details.AcceptChanges();

        //        gvWaitlistDetails.DataSource = SessionWrapper.WaitList_details;
        //        gvWaitlistDetails.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}