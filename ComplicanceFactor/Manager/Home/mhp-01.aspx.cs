using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Collections;
using ComplianceFactors.MyTeam;
using System.Net;
namespace ComplicanceFactor.Manager
{
    public partial class mhp_01 : BasePage
    {
        #region
        private string e_enroll_system_id_pk;
        private string todo_system_id_pk;
        private string delivery_id;
        private string e_enroll_user_id_fk;
        private string e_enroll_course_id_fk;
        #endregion

        DataSet dsManager = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            mrp1.flag = ReportEnum.Manager;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_userid))
                {
                    User userSplash = new User();
                    try
                    {
                        userSplash = UserBLL.GetUserSplash(SessionWrapper.u_userid);
                        bool result = userSplash.u_splash_display_flag;
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain, SessionWrapper.CultureName);
                        spalsh.InnerHtml = WebUtility.HtmlDecode(splashContent.u_splash_content);
                        if (result == false && (!string.IsNullOrEmpty(splashContent.u_splash_content)) && string.IsNullOrEmpty(SessionWrapper.IsClose))
                        {
                            mpSplashPage.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("mhp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("mhp-01.aspx", ex.Message);
                            }
                        }
                    }
                }
                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + "&nbsp>&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>";
                // GetAllCourse();
                //set todo recored display pref
                if (SessionWrapper.u_profile_my_todos_records_display_pref != 0)
                {
                    gvToDo.AllowPaging = true;
                    gvToDo.PageSize = SessionWrapper.u_profile_my_todos_records_display_pref;
                }
                //GetAllEmployee();
                //expand and collapsed based on user for todo
                if (SessionWrapper.u_profile_my_todos_collapse_pref == "app_ddl_collapsed")
                {
                    div_to_do.Style.Add("display", "none");
                    imgToDo.ImageUrl = "~/Images/addplus-sm.gif";
                    imgToDo.AlternateText = "plus";
                }
                else
                {
                    div_to_do.Style.Add("display", "block");
                    imgToDo.ImageUrl = "~/Images/addminus-sm.gif";
                    imgToDo.AlternateText = "minus";
                }
                //expand and collapsed based on user for team
                if (SessionWrapper.u_profile_my_team_collapse_pref == "app_ddl_collapsed")
                {
                    div_team.Style.Add("display", "none");
                    imgTeam.ImageUrl = "~/Images/addplus-sm.gif";
                    imgTeam.AlternateText = "plus";
                }
                else
                {
                    div_team.Style.Add("display", "block");
                    imgTeam.ImageUrl = "~/Images/addminus-sm.gif";
                    imgTeam.AlternateText = "minus";
                }

                if (SessionWrapper.u_profile_my_report_history_collapse_pref == "app_ddl_collapsed")
                {
                    div_report.Style.Add("display", "none");
                    imgReport.ImageUrl = "~/Images/addplus-sm.gif";
                    imgReport.AlternateText = "plus";
                }
                else
                {
                    div_report.Style.Add("display", "block");
                    imgReport.ImageUrl = "~/Images/addminus-sm.gif";
                    imgReport.AlternateText = "minus";
                }

                //Bind all (Todo,Team and report)
                BindToDo_Team_Report();

            }

            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Manager/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/ascp-01.aspx", false);
        }

        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/bchp-01.aspx", false);
        }
        private void BindToDo_Team_Report()
        {
            if (!String.IsNullOrEmpty(SessionWrapper.u_userid))
            {

                dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);

                //bind todos
                gvToDo.DataSource = dsManager.Tables[0];
                gvToDo.DataBind();


                if (gvToDo.Rows.Count > 0)
                {
                    gvToDo.UseAccessibleHeader = true;
                    if (gvToDo.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvToDo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                if (gvToDo.Rows.Count == 0 || gvToDo.Rows.Count == 1)
                {
                    btnApproveAll.Visible = false;
                    btnDenyAll.Visible = false;
                }

                MyTeamDataAccess da = new MyTeamDataAccess();
                //get the data
                MyTeam_Dataset ds = da.GetData(SessionWrapper.u_userid);
                Cache["data"] = ds;
                this.BindData(ds);
            }
        }
        private void BindData(MyTeam_Dataset dataSet)
        {
            List<MyTeam_Dataset.e_sp_get_team_dataRow> dataSourceRows = new List<MyTeam_Dataset.e_sp_get_team_dataRow>();

            //gets a collection of top-level rows
            IEnumerable<MyTeam_Dataset.e_sp_get_team_dataRow> topLevelRows = from MyTeam_Dataset.e_sp_get_team_dataRow teamRow
                                                                 in dataSet.e_sp_get_team_data.Rows
                                                                             where teamRow.LevelPos <= 0
                                                                             select teamRow;


            List<MyTeam_Dataset.e_sp_get_team_dataRow> rowsToBind = new List<MyTeam_Dataset.e_sp_get_team_dataRow>();

            //recursively builds a collection consisting of all the top level rows
            //and any children where isExpanded = true in the data row
            this.BuildDataSetRecursive(topLevelRows, ref rowsToBind, 0);

            //binds the locations listview
            this.lvMyteam.DataSource = rowsToBind;
            this.lvMyteam.DataBind();
        }



        private void BuildDataSetRecursive(IEnumerable<MyTeam_Dataset.e_sp_get_team_dataRow> inputRows, ref List<MyTeam_Dataset.e_sp_get_team_dataRow> outputRows, int indentationLevel)
        {
            foreach (MyTeam_Dataset.e_sp_get_team_dataRow inputRow in inputRows)
            {
                //inputRow.indentationLevel = indentationLevel;

                //add the current row to the output collection
                outputRows.Add(inputRow);

                //if the row expanded state is set to true, add any children to the output collection.
                if (inputRow.isExpanded) // need to change
                {
                    //using the data relation on the typed dataset to find the children of the current row.
                    DataRow[] childRows = inputRow.GetChildRows("FK_e_sp_get_team_data");

                    if (childRows.Length > 0)
                    {
                        List<MyTeam_Dataset.e_sp_get_team_dataRow> locationChildRows = new List<MyTeam_Dataset.e_sp_get_team_dataRow>(
                            childRows.Cast<MyTeam_Dataset.e_sp_get_team_dataRow>());
                        this.BuildDataSetRecursive(locationChildRows, ref outputRows, indentationLevel + 1);
                    }
                }
            }
        }
        protected void expandCollapse(string userId, int levelPos)
        {
            MyTeam_Dataset ds = (MyTeam_Dataset)Cache["data"];
            MyTeam_Dataset.e_sp_get_team_dataRow locationRow = (ds.e_sp_get_team_data.Select("LevelPos =" + levelPos + " AND userId ='" + userId + "'")[0] as MyTeam_Dataset.e_sp_get_team_dataRow);

            ////set the isExpanded state for the row
            this.SetExpandState(locationRow, !locationRow.isExpanded);//to pass the is expanded

            //persist the changes
            ds.AcceptChanges();

            //update the label text
            //lbt.Text = (locationRow.isExpanded) ? "-" : "+";

            //rebind the listview
            this.BindData(ds);
        }

        private void SetExpandState(MyTeam_Dataset.e_sp_get_team_dataRow row, bool state)
        {
            //update isExpanded
            row.isExpanded = state;
            if (!state)
            {
                DataRow[] childRows = row.GetChildRows("FK_e_sp_get_team_data");
                foreach (DataRow childRow in childRows)
                {
                    this.SetExpandState((MyTeam_Dataset.e_sp_get_team_dataRow)childRow, state);
                }
            }
        }
        protected void lvMyteam_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item is ListViewDataItem)
            {
                this.InitialiseOfficeRow((ListViewDataItem)e.Item);
            }
        }
        private void SetPlusSymbol(string userId, LinkButton btn)
        {
            DataSet ds = new DataSet();
            ds = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
            DataRow[] drTeam = ds.Tables[1].Select("ManagerId ='" + userId + "'");

            if (drTeam.Length > 0)
            {
                btn.Text = " [+]";
            }
            else
            {
                btn.Visible = false;
            }
        }
        private void InitialiseOfficeRow(ListViewDataItem item)
        {
            MyTeam_Dataset.e_sp_get_team_dataRow row = (MyTeam_Dataset.e_sp_get_team_dataRow)item.DataItem;

            LinkButton lbt = (LinkButton)item.FindControl("lnkExpandCollapse");
            lbt.CommandArgument = DataBinder.Eval(item.DataItem, "userId").ToString() + "," + DataBinder.Eval(item.DataItem, "LevelPos").ToString();



            string id = DataBinder.Eval(item.DataItem, "userId").ToString();
            SetPlusSymbol(id, lbt);

            if (row.isExpanded)
            {
                lbt.Text = " [-]";
            }

            if (row.LevelPos > 0)
            {
                Literal lit = (Literal)item.FindControl("litIndent");
                lit.Text = string.Concat(System.Collections.ArrayList.Repeat("&nbsp;&nbsp;", row.LevelPos).ToArray());
            }

            //set the location name text
            Label lbl = (Label)item.FindControl("lblFirstName");
            lbl.Text = DataBinder.Eval(item.DataItem, "FirstName").ToString();

        }

        protected void lvMyteam_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "ExpandCollapse"))
            {
                string positionandId = e.CommandArgument.ToString();
                string[] seperate = positionandId.Split(',');

                string userId = seperate[0].ToString();
                int levelPos = Convert.ToInt16(seperate[1]);

                expandCollapse(userId, levelPos);

            }

        }


        protected void gvToDo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Approve"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_system_id_pk, todo_system_id_pk);
                ApproveEmailConfirmation(delivery_id, e_enroll_user_id_fk);
            }
            else if (e.CommandName.Equals("Deny"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.DenyEnrollment(e_enroll_system_id_pk, todo_system_id_pk);
                //send Enrollment denial Email and Sms 
                denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);

            }

            BindToDo_Team_Report();
        }

        protected void gvToDo_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
        private void denyEmailConfirmation(string delivery_id, string e_enroll_user_id_fk)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = EnrollmentBLL.GetCourseDetails(delivery_id);

            User user = new User();
            user = UserBLL.GetUserInfo_by_id(e_enroll_user_id_fk);


            StringBuilder sbConfirmEnrollment = new StringBuilder();

            SystemNotification notification = new SystemNotification();
            notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL- APPROVAL-DENIED", SessionWrapper.CultureName);//Enroll-Approval-Denied
            if (notification.s_notification_on_off_flag == true)
            {
                string denySubject = string.Empty;
                denySubject = notification.s_notification_email_subject;
                denySubject = denySubject.Replace("@$&Course Title&$@", Course.c_course_title);

                string denyText = string.Empty;
                denyText = notification.s_notification_email_text;
                denyText = denyText.Replace("@$&user_name&$@", user.Firstname);
                denyText = denyText.Replace("@$&Course Title&$@", Course.c_course_title);
                denyText = denyText.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                denyText = denyText.Replace("@$&manager_name&$@", SessionWrapper.u_username);

                sbConfirmEnrollment.Append(denyText);

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
                    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                    Utility.SendEMailMessages(mailAddresses, fromaddress, denySubject, sbConfirmEnrollment.ToString());
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
                        messagetext = messagetext.Replace("@$&Status&$@", "Denied");
                        messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                        Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                    }
                }
            }
        }

        private void ApproveEmailConfirmation(string delivery_id, string e_enroll_user_id_fk)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetSingleDeliveryList(delivery_id);
            StringBuilder sbConfirmEnrollment = new StringBuilder();
            //SystemNotification notification = new SystemNotification();
            //notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT");

            //Get emplyee first name
            User user = new User();
            user = UserBLL.GetUserInfo_by_id(e_enroll_user_id_fk);
            string type = Course.c_delivery_type_id;

            SystemNotification notificationApproval = new SystemNotification();
            notificationApproval = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL- APPROVAL-APPROVED", SessionWrapper.CultureName);
            if (notificationApproval.s_notification_on_off_flag == true)
            {
                string ApproveSubject = string.Empty;
                ApproveSubject = notificationApproval.s_notification_email_subject;
                ApproveSubject = ApproveSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                string ApproveText = string.Empty;
                ApproveText = notificationApproval.s_notification_email_text;
                ApproveText = ApproveText.Replace("@$&user_name&$@", user.Firstname);
                ApproveText = ApproveText.Replace("@$&Course Title&$@", Course.c_course_title);
                ApproveText = ApproveText.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                ApproveText = ApproveText.Replace("@$&manager_name&$@", SessionWrapper.u_username);

                sbConfirmEnrollment.Append(ApproveText);

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
                    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                    Utility.SendEMailMessages(mailAddresses, fromaddress, ApproveSubject, sbConfirmEnrollment.ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                    {
                        StringBuilder smsText = new StringBuilder();
                        string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                        string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                        string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                        string messagetext = notificationApproval.s_notification_SMS_text;
                        messagetext = messagetext.Replace("", "");
                        messagetext = messagetext.Replace("", "");

                        if (messagetext.Length > 180)
                        {
                            messagetext = messagetext.Substring(0, 179);
                        }
                        messagetext = messagetext.Replace("@$&Status&$@", "Approved");
                        messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                        Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                    }
                }
            }
        }


        // if (type == "OLT")
        // {
        //     SystemNotification notification = new SystemNotification();
        //     notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT",SessionWrapper.CultureName);
        //     //if (notification.s_notification_on_off_flag == true)
        //     //{
        //     //Enroll OLT
        //     string confirmOLTSubject = string.Empty;
        //     confirmOLTSubject = notification.s_notification_email_subject;
        //     confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

        //     string sbConfirmOLT = string.Empty;
        //     sbConfirmOLT = notification.s_notification_email_text;

        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);

        //     string toEmailid = user.EmailId;
        //     if (!string.IsNullOrEmpty(toEmailid))
        //     {
        //         string[] toaddress = toEmailid.Split(',');
        //         List<MailAddress> mailAddresses = new List<MailAddress>();
        //         foreach (string recipient in toaddress)
        //         {
        //             if (recipient.Trim() != string.Empty)
        //             {
        //                 mailAddresses.Add(new MailAddress(recipient));
        //             }
        //         }
        //         string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        //         sbConfirmEnrollment.Append(sbConfirmOLT);
        //         Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
        //     }
        //     else
        //     {
        //         if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
        //         {
        //             StringBuilder smsText = new StringBuilder();
        //             string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
        //             string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
        //             string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

        //             string messagetext = notification.s_notification_SMS_text;
        //             messagetext = messagetext.Replace("", "");
        //             messagetext = messagetext.Replace("", "");

        //             if (messagetext.Length > 180)
        //             {
        //                 messagetext = messagetext.Substring(0, 179);
        //             }
        //             messagetext = messagetext.Replace("@$&Status&$@", "Approved");
        //             messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //             Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //         }
        //     }

        //     // }


        ////Enroll ILT/VLT
        // else if ((type == "ILT" || type == "VLT"))
        // {
        //     SystemNotification notificationILT = new SystemNotification();
        //     notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON",SessionWrapper.CultureName);
        //     //if (notificationILT.s_notification_on_off_flag == true)
        //     //{
        //     string confirmILTSubject = string.Empty;
        //     confirmILTSubject = notificationILT.s_notification_email_subject;
        //     confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

        //     string confirmILT = string.Empty;
        //     confirmILT = notificationILT.s_notification_email_text;

        //     confirmILT = confirmILT.Replace("@$&User First Name&$@", user.Firstname);
        //     confirmILT = confirmILT.Replace("@$&Course Name&$@", Course.c_course_title);
        //     confirmILT = confirmILT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
        //     confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
        //     confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
        //     confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
        //     confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
        //     confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
        //     confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

        //     string toEmailid = user.EmailId;
        //     if (!string.IsNullOrEmpty(toEmailid))
        //     {
        //         string[] toaddress = toEmailid.Split(',');
        //         List<MailAddress> mailAddresses = new List<MailAddress>();
        //         foreach (string recipient in toaddress)
        //         {
        //             if (recipient.Trim() != string.Empty)
        //             {
        //                 mailAddresses.Add(new MailAddress(recipient));
        //             }
        //         }
        //         string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        //         sbConfirmEnrollment.Append(confirmILT);
        //         Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
        //     }
        //     else
        //     {
        //         if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
        //         {
        //             StringBuilder smsText = new StringBuilder();
        //             string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
        //             string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
        //             string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

        //             string messagetext = notificationILT.s_notification_SMS_text;
        //             messagetext = messagetext.Replace("", "");
        //             messagetext = messagetext.Replace("", "");

        //             if (messagetext.Length > 180)
        //             {
        //                 messagetext = messagetext.Substring(0, 179);
        //             }
        //             messagetext = messagetext.Replace("@$&Status&$@", "Approved");
        //             messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //             Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //         }
        //     }
        //     // }
        // }

        //sbConfirmEnrollment.Append("Hello " + user.Firstname + ",");
        //sbConfirmEnrollment.Append("<br>");
        //sbConfirmEnrollment.Append("This email is to confirm that you are enrolled in the {" + Course.c_course_title + "} + (" + Course.c_course_id_pk + ")).");
        //sbConfirmEnrollment.Append("<br>");
        //if ((type == "ILT" || type == "VLT"))
        //{
        //      sbConfirmEnrollment.Append("Location:" + Course.c_session_location_names + ", " + Course.c_session_facility_names + ", " + Course.c_session_room_names + "");
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("Instructor(S):" + Course.c_instructor_list);
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("Starting on:" + Course.c_session_start_date_time);
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("Ending on:" + Course.c_session_end_date_time);
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("Please login to the system and go to your 'My Course' section to access the details for this training or launch the course for eLearning Training or simply click on the link below:");
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("www.compliancefactors.com/login_redirect/?url=lmcp-01.aspx");
        //      sbConfirmEnrollment.Append("<br>");
        //      sbConfirmEnrollment.Append("We are looking forward to seeing you!");
        //}
        //sbConfirmEnrollment.Append("Thanks!");
        //sbConfirmEnrollment.Append("<br><br>");
        //sbConfirmEnrollment.Append("The Training Department");
        //List<MailAddress> mailAddresses = new List<MailAddress>();
        //mailAddresses.Add(new MailAddress(user.EmailId));
        //string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        ////mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
        //Utility.SendEMailMessages(mailAddresses, fromAddress, "*** Enrollment Confirmation Approved in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());



        protected void btnDenyAll_Click(object sender, EventArgs e)
        {
            try
            {

                dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
                DataTable dtTodo = dsManager.Tables[0];
                for (int i = 0; i <= dtTodo.Rows.Count - 1; i++)
                {
                    e_enroll_course_id_fk = dtTodo.Rows[i]["id"].ToString();
                    e_enroll_system_id_pk = dtTodo.Rows[i]["enroll_system_id_pk"].ToString();
                    todo_system_id_pk = dtTodo.Rows[i]["todo_system_id_pk"].ToString();
                    delivery_id = dtTodo.Rows[i]["delivery_id"].ToString();
                    e_enroll_user_id_fk = dtTodo.Rows[i]["e_enroll_user_id_fk"].ToString();
                    int result = EnrollmentBLL.DenyEnrollment(e_enroll_system_id_pk, todo_system_id_pk);
                    denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);
                    BindToDo_Team_Report();
                    btnDenyAll.Visible = false;
                    btnApproveAll.Visible = false;
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
                        Logger.WriteToErrorLog("mhp-01 (Deny All)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mhp-01 (Deny All)", ex.Message);
                    }
                }
            }

        }

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            try
            {

                dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
                DataTable dtTodo = dsManager.Tables[0];
                for (int i = 0; i <= dtTodo.Rows.Count - 1; i++)
                {
                    e_enroll_course_id_fk = dtTodo.Rows[i]["id"].ToString();
                    e_enroll_system_id_pk = dtTodo.Rows[i]["enroll_system_id_pk"].ToString();
                    todo_system_id_pk = dtTodo.Rows[i]["todo_system_id_pk"].ToString();
                    delivery_id = dtTodo.Rows[i]["delivery_id"].ToString();
                    e_enroll_user_id_fk = dtTodo.Rows[i]["e_enroll_user_id_fk"].ToString();
                    int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_system_id_pk, todo_system_id_pk);
                    ApproveEmailConfirmation(delivery_id, e_enroll_user_id_fk);
                    BindToDo_Team_Report();
                    btnDenyAll.Visible = false;
                    btnApproveAll.Visible = false;
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
                        Logger.WriteToErrorLog("mhp-01 (Approve All)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mhp-01 (Approve All)", ex.Message);
                    }
                }
            }
        }

        protected void lnkViewAllToDo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Manager/mmtdp-01.aspx", false);
        }

        protected void lnkViewAllTeam_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Manager/mmtp-01.aspx", false);
        }

        protected void lnkViewAllReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Manager/mmrp-01.aspx", false);
        }

        protected void gvMyTeam_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                GridView GridView1 = (GridView)sender;
                string FirstName = DataBinder.Eval(e.Row.DataItem, "FirstName").ToString();
                if (FirstName.Contains("->"))
                {
                    int count = FirstName.Split('>').Length - 1;
                    int paddingValue = count * 10;
                    HtmlGenericControl msgDiv = (HtmlGenericControl)e.Row.FindControl("firstNameDiv");
                    msgDiv.Attributes.Add("style", "padding-left:" + paddingValue + "px;");
                    //Label lblFirstName = (Label)e.Row.FindControl("lblFirstName");
                    //lblFirstName.CssClass = "padding_1";
                }
                // bool result = CheckIsEmployee(userID);
                // if (result == true)
                //{
                //    ImageButton imgPlus = (ImageButton)e.Row.FindControl("A_View");
                //    imgPlus.Visible = true;
                //    //To show the + button(Image)
                //    //Add the gridview                

                //}
                //else
                //{
                //    ImageButton imgPlus = (ImageButton)e.Row.FindControl("A_View");
                //    imgPlus.Visible = false;
                //}
            }
        }

        //Splash page

        protected void btnDonotShow_Click(object sender, EventArgs e)
        {
            //Set the u_splash_display_flag as 1.
            User userSplash = new User();
            userSplash.Userid = SessionWrapper.u_userid;
            userSplash.u_splash_display_flag = true;

            try
            {
                int result = UserBLL.UpdateSplash(userSplash);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mhp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mhp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnCloseSplashPage_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }
        protected void ibtnCloseSplash_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }     

        //private bool CheckIsEmployee(string userId)
        //{
        //    //DataTable employee = new DataTable();
        //    //employee.Columns.Add(new DataColumn("userId", typeof(string)));
        //    //employee.Columns.Add(new DataColumn("FirstName", typeof(string)));
        //    //employee.Columns.Add(new DataColumn("JobTitle", typeof(string)));
        //    //employee.Columns.Add(new DataColumn("ManagerId", typeof(string)));            
        //    //employee.Columns.Add(new DataColumn("LevelPos", typeof(int)));

        //    DataTable dtmanager = dsManager.Tables[1];
        //    DataRow[] drEmployee = dtmanager.Select("RecCount > 0 AND userId='" + userId + "'");

        //    if (drEmployee.Length > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


    }
}