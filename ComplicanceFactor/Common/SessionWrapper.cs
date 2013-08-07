using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ComplicanceFactor.Common
{
    public class SessionWrapper
    {
        /// <summary>
        /// Gets or sets the session id.
        /// <value>The session id of the user.</value>

        public static string sessionid
        {
            get
            {
                if (HttpContext.Current.Session["Sessionid"] != null)
                {
                    return HttpContext.Current.Session["Sessionid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Sessionid"] = value;
            }
        }
        /// <summary>
        /// culture name
        /// </summary>
        public static string CultureName
        {
            get
            {
                if (HttpContext.Current.Session["CultureName"] != null)
                {
                    return HttpContext.Current.Session["CultureName"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["CultureName"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the session guid.
        /// <value>The session guid of the user.</value>

        public static string u_sessionguid
        {
            get
            {
                if (HttpContext.Current.Session["u_sessionguid"] != null)
                {
                    return HttpContext.Current.Session["u_sessionguid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_sessionguid"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// <value>The name of the user.</value>
        public static string u_username
        {
            get
            {
                if (HttpContext.Current.Session["u_username"] != null)
                {
                    return HttpContext.Current.Session["u_username"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["u_username"] = value;
            }
        }
        /// <summary>
        /// user email id
        /// </summary>
        public static string u_email_id
        {
            get
            {
                if (HttpContext.Current.Session["u_email_id"] != null)
                {
                    return HttpContext.Current.Session["u_email_id"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_email_id"] = value;

            }

        }
        /// <summary>
        /// user mobile number
        /// </summary>
        public static string u_mobile_number
        {
            get
            {
                if (HttpContext.Current.Session["u_mobile_number"] != null)
                {
                    return HttpContext.Current.Session["u_mobile_number"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_mobile_number"] = value;

            }
        }
        /// <summary>
        /// Gets or sets the firstname.
        /// <value>The firstname of the user.</value>
        public static string u_firstname
        {
            get
            {
                if (HttpContext.Current.Session["u_firstname"] != null)
                {
                    return HttpContext.Current.Session["u_firstname"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["u_firstname"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the middlename.
        /// <value>The middlename of the user.</value>
        public static string u_middlename
        {
            get
            {
                if (HttpContext.Current.Session["u_middlename"] != null)
                {
                    return HttpContext.Current.Session["u_middlename"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_middlename"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the lastname.
        /// <value>The lastname of the user.</value>
        public static string u_lastname
        {
            get
            {
                if (HttpContext.Current.Session["u_lastname"] != null)
                {
                    return HttpContext.Current.Session["u_lastname"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_lastname"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the userid.
        /// <value>The userid of the user.</value>
        public static string u_userid
        {
            get
            {
                if (HttpContext.Current.Session["u_userid"] != null)
                {
                    return HttpContext.Current.Session["u_userid"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_userid"] = value;
            }
        }
        public static string u_profile_my_courses_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_courses_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_courses_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_courses_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_curricula_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_curricula_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_curricula_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_curricula_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_learning_history_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_learning_history_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_learning_history_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_learning_history_collapse_pref"] = value;
            }

        }
        public static int u_profile_my_courses_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_courses_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_courses_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_courses_records_display_pref"] = value;
            }

        }
        public static int u_profile_my_curricula_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_curricula_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_curricula_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_curricula_records_display_pref"] = value;
            }

        }
        public static int u_profile_my_learning_history_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_learning_history_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_learning_history_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_learning_history_records_display_pref"] = value;
            }

        }


        public static string u_profile_my_todos_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_todos_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_todos_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_todos_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_team_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_team_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_team_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_team_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_report_history_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_report_history_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_report_history_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_report_history_collapse_pref"] = value;
            }

        }
        public static int u_profile_my_todos_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_todos_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_todos_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_todos_records_display_pref"] = value;
            }

        }
        public static int u_profile_my_team_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_team_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_team_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_team_records_display_pref"] = value;
            }

        }
        public static int u_profile_my_report_history_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_report_history_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_report_history_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_report_history_records_display_pref"] = value;
            }

        }
        /// <summary>
        /// Gets or sets the language.
        /// <value>The user select language.</value>
        public static string language
        {
            get
            {
                if (HttpContext.Current.Session["language"] != null)
                {
                    return HttpContext.Current.Session["language"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["language"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the domain
        ///<value>The user select domain</value>
        public static string u_domain
        {
            get
            {
                if (HttpContext.Current.Session["u_domain"] != null)
                {
                    return HttpContext.Current.Session["u_domain"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_domain"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the locale(Language)
        ///<value>The user select locale(Language)</value>
        public static string u_locale
        {
            get
            {
                if (HttpContext.Current.Session["u_locale"] != null)
                {
                    return HttpContext.Current.Session["u_locale"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_locale"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the timezone
        ///<value>The user timezone</value>
        public static string u_timezone
        {
            get
            {
                if (HttpContext.Current.Session["u_timezone"] != null)
                {
                    return HttpContext.Current.Session["u_timezone"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_timezone"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the user type
        ///<value>The user type (internal or external)</value>
        public static string u_user_type
        {
            get
            {
                if (HttpContext.Current.Session["u_user_type"] != null)
                {
                    return HttpContext.Current.Session["u_user_type"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_user_type"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	User Employee Security Role Flag 
        ///<value>The User Employee Security Role Flag </value>
        public static bool u_sr_is_employee
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_employee"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_employee"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_employee"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the User Manager Security Role Flag  
        ///<value>The User Manager Security Role Flag </value>
        public static bool u_sr_is_manager
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_manager"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_manager"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_manager"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the User Compliance Security Role Flag  
        ///<value>The User Compliance Security Role Flag   </value>
        public static bool u_sr_is_compliance
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_compliance"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_compliance"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_compliance"] = value;
            }
        }
        ///Gets or sets the User Instructor Security Role Flag 
        ///<value>The User Instructor Security Role Flag   </value>
        public static bool u_sr_is_instructor
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_instructor"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_instructor"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_instructor"] = value;
            }
        }
        ///Gets or sets the User Training Security Role Flag 
        ///<value>The User Training Security Role Flag    </value>
        public static bool u_sr_is_training
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_training"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_training"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_training"] = value;
            }
        }
        ///Gets or sets the user Administrator Security Role Flag  
        ///<value>The user Administrator Security Role Flag </value>
        public static bool u_sr_is_administrator
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_administrator"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_administrator"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_administrator"] = value;
            }
        }
        ///Gets or sets the User System Security Role Flag  
        ///<value>The User System Security Role Flag </value>
        public static bool u_sr_is_system_admin
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_system_admin"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_system_admin"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_system_admin"] = value;
            }
        }

        public static bool u_sr_is_compliance_approver
        {
            get
            {
                if (HttpContext.Current.Session["u_sr_is_compliance_approver"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["u_sr_is_compliance_approver"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                HttpContext.Current.Session["u_sr_is_compliance_approver"] = value;
            }
        }
        ///Gets or sets the User hris manager 
        ///<value>The User hirs manager </value>
        public static string u_hris_manager_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_manager_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_manager_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_manager_id_fk"] = value;
            }
        }
        ///Gets or sets the u_hris_supervisor_id_fk
        ///<value>The User u_hris_supervisor_id_fk </value>
        public static string u_hris_supervisor_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_supervisor_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_supervisor_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_supervisor_id_fk"] = value;
            }
        }
        ///Gets or sets the u_hris_alternate_manager_id_fk
        ///<value>The User u_hris_alternate_manager_id_fk </value>
        public static string u_hris_alternate_manager_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_manager_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_manager_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_manager_id_fk"] = value;
            }
        }
        ///Gets or sets the u_hris_alternate_supervisor_id_fk
        ///<value>The User u_hris_alternate_supervisor_id_fk </value>
        public static string u_hris_alternate_supervisor_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_supervisor_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_supervisor_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_supervisor_id_fk"] = value;
            }
        }
        ///Gets or sets the u_hris_mentor_id_fk
        ///<value>The User u_hris_mentor_id_fk </value>
        public static string u_hris_mentor_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_mentor_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_mentor_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_mentor_id_fk"] = value;
            }
        }

        public static string u_hris_alternate_mentor_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_mentor_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_mentor_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_mentor_id_fk"] = value;
            }
        }
        public static string u_hris_manager_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_manager_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_manager_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_manager_text"] = value;
            }
        }
        public static string u_hris_supervisor_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_supervisor_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_supervisor_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_supervisor_text"] = value;
            }
        }
        ///Gets or sets the u_hris_alternate_manager_text
        ///<value>The User u_hris_alternate_manager_text </value>
        public static string u_hris_alternate_manager_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_manager_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_manager_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_manager_text"] = value;
            }
        }
        ///Gets or sets the u_hris_alternate_supervisor_text
        ///<value>The User u_hris_alternate_supervisor_text </value>
        public static string u_hris_alternate_supervisor_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_supervisor_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_supervisor_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_supervisor_text"] = value;
            }
        }
        ///Gets or sets the u_hris_mentor_text
        ///<value>The User u_hris_mentor_text </value>
        public static string u_hris_mentor_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_mentor_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_mentor_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_mentor_text"] = value;
            }
        }
        public static string u_hris_alternate_mentor_text
        {
            get
            {
                if (HttpContext.Current.Session["u_hris_alternate_mentor_text"] != null)
                {
                    return HttpContext.Current.Session["u_hris_alternate_mentor_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_hris_alternate_mentor_text"] = value;
            }
        }
        public static string user_password
        {
            get
            {
                if (HttpContext.Current.Session["user_password"] != null)
                {
                    return HttpContext.Current.Session["user_password"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["user_password"] = value;
            }
        }
        public static string converted_datetime
        {
            get
            {
                if (HttpContext.Current.Session["converted_datetime"] != null)
                {
                    return HttpContext.Current.Session["converted_datetime"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["converted_datetime"] = value;
            }
        }
        public static DataTable session_witness
        {
            get
            {
                if (HttpContext.Current.Session["session_witness"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_witness"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_witness"] = value;
            }
        }
        public static DataTable session_PoliceReport
        {
            get
            {
                if (HttpContext.Current.Session["session_PoliceReport"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_PoliceReport"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_PoliceReport"] = value;
            }
        }
        public static DataTable session_Photo
        {
            get
            {
                if (HttpContext.Current.Session["session_Photo"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_Photo"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_Photo"] = value;
            }
        }
        public static DataTable session_SceneSketch
        {
            get
            {
                if (HttpContext.Current.Session["session_SceneSketch"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_SceneSketch"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_SceneSketch"] = value;
            }
        }
        public static DataTable session_ExtenuatingCondition
        {
            get
            {
                if (HttpContext.Current.Session["session_ExtenuatingCondition"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_ExtenuatingCondition"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_ExtenuatingCondition"] = value;
            }
        }
        public static DataTable session_EmployeeInterview
        {
            get
            {
                if (HttpContext.Current.Session["session_EmployeeInterview"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["session_EmployeeInterview"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_EmployeeInterview"] = value;
            }
        }
        public static DataTable session_EmployeeStatement
        {
            get
            {
                if (HttpContext.Current.Session["session_EmployeeStatement"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_EmployeeStatement"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_EmployeeStatement"] = value;
            }
        }
        public static DataTable session_Policies
        {
            get
            {
                if (HttpContext.Current.Session["session_Policies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_Policies"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_Policies"] = value;
            }
        }
        public static DataTable session_TrainingHistory
        {
            get
            {
                if (HttpContext.Current.Session["session_TrainingHistory"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_TrainingHistory"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_TrainingHistory"] = value;
            }
        }
        public static DataTable session_Observation
        {
            get
            {
                if (HttpContext.Current.Session["session_Observation"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_Observation"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_Observation"] = value;
            }
        }
        public static DataTable session_IncidentHistory
        {
            get
            {
                if (HttpContext.Current.Session["session_IncidentHistory"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_IncidentHistory"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_IncidentHistory"] = value;
            }
        }
        public static DataTable session_Custom_Customer
        {
            get
            {
                if (HttpContext.Current.Session["session_Custom_Customer"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["session_Custom_Customer"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_Custom_Customer"] = value;
            }
        }

        public static DateTime casedate
        {
            get
            {
                return (DateTime)HttpContext.Current.Session["casedate"];

            }
            set
            {
                HttpContext.Current.Session["casedate"] = value;
            }

        }
        public static DateTime CourseDateTime
        {
            get
            {
                return (DateTime)HttpContext.Current.Session["CourseDateTime"];

            }
            set
            {
                HttpContext.Current.Session["CourseDateTime"] = value;
            }

        }
        public static string viewHtml
        {
            get
            {
                if (HttpContext.Current.Session["viewHtml"] != null)
                {
                    return HttpContext.Current.Session["viewHtml"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["viewHtml"] = value;
            }
        }
        public static DateTime HarmCaseDate
        {
            get
            {
                return (DateTime)HttpContext.Current.Session["HarmCaseDate"];

            }
            set
            {
                HttpContext.Current.Session["HarmCaseDate"] = value;
            }

        }
        public static DataTable Hazard
        {
            get
            {
                if (HttpContext.Current.Session["Hazard"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Hazard"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Hazard"] = value;
            }
        }
        public static DataTable ControlMeasure
        {
            get
            {
                if (HttpContext.Current.Session["ControlMeasure"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ControlMeasure"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ControlMeasure"] = value;
            }
        }
        public static string temp_h_hazard_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["temp_h_hazard_id_pk"] != null)
                {
                    return HttpContext.Current.Session["temp_h_hazard_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["temp_h_hazard_id_pk"] = value;
            }
        }
        public static string temp_h_control_measure_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["temp_h_control_measure_id_pk"] != null)
                {
                    return HttpContext.Current.Session["temp_h_control_measure_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["temp_h_control_measure_id_pk"] = value;
            }
        }

        public static string brwcatalog_bredcrumb
        {
            get
            {
                if (HttpContext.Current.Session["brwcatalog_bredcrumb"] != null)
                {
                    return HttpContext.Current.Session["brwcatalog_bredcrumb"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["brwcatalog_bredcrumb"] = value;
            }
        }

        ///<summary>
        ///Gets or sets the ix.	course owner name 
        ///<value>The course owner name </value>
        public static string c_owner_name
        {
            get
            {
                if (HttpContext.Current.Session["c_owner_name"] != null)
                {
                    return HttpContext.Current.Session["c_owner_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_owner_name"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	course coordinator name 
        ///<value>The course coordinator name </value>
        public static string c_coordinator_name
        {
            get
            {
                if (HttpContext.Current.Session["c_coordinator_name"] != null)
                {
                    return HttpContext.Current.Session["c_coordinator_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_coordinator_name"] = value;
            }
        }

        ///<summary>
        ///Gets or sets the ix.	course Prerequisite 
        ///<value>The course Prerequisite datatable </value>

        public static DataTable Prerequisite
        {
            get
            {
                if (HttpContext.Current.Session["Prerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Prerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Prerequisite"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp course Prerequisite 
        ///<value>Temp course Prerequisite datatable </value>

        public static DataTable TempPrerequisite
        {
            get
            {
                if (HttpContext.Current.Session["TempPrerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempPrerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempPrerequisite"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	 Prerequisite course selected
        ///<value>Temp  Prerequisite course selected datatable </value>

        public static DataTable PrerequisiteCourseSelected
        {
            get
            {
                if (HttpContext.Current.Session["PrerequisiteCourseSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["PrerequisiteCourseSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["PrerequisiteCourseSelected"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp Prerequisite course guid
        ///<value>Temp course guid </value>

        public static string TempPrerequisiteCourseGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempPrerequisiteCourseGuid"] != null)
                {
                    return HttpContext.Current.Session["TempPrerequisiteCourseGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempPrerequisiteCourseGuid"] = value;
            }
        }

        ///<summary>
        ///Gets or sets the ix.	course Equivalencies 
        ///<value>The course Equivalencies datatable </value>

        public static DataTable Equivalencies
        {
            get
            {
                if (HttpContext.Current.Session["Equivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Equivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Equivalencies"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp course Equivalencies 
        ///<value>Temp course Equivalencies datatable </value>

        public static DataTable TempEquivalencies
        {
            get
            {
                if (HttpContext.Current.Session["TempEquivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempEquivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempEquivalencies"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	 Equivalencies course selected
        ///<value>Temp  Equivalencies course selected datatable </value>

        public static DataTable EquivalenciesCourseSelected
        {
            get
            {
                if (HttpContext.Current.Session["EquivalenciesCourseSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["EquivalenciesCourseSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["EquivalenciesCourseSelected"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp Equivalencies course guid
        ///<value>Temp course guid </value>

        public static string TempEquivalenciesCourseGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempEquivalenciesCourseGuid"] != null)
                {
                    return HttpContext.Current.Session["TempEquivalenciesCourseGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempEquivalenciesCourseGuid"] = value;
            }
        }


        ///<summary>
        ///Gets or sets the ix.	course Fulfillments 
        ///<value>The course Fulfillments datatable </value>

        public static DataTable Fulfillments
        {
            get
            {
                if (HttpContext.Current.Session["Fulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Fulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Fulfillments"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp course Fulfillments 
        ///<value>Temp course Fulfillments datatable </value>

        public static DataTable TempFulfillments
        {
            get
            {
                if (HttpContext.Current.Session["TempFulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempFulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempFulfillments"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	 Fulfillments course selected
        ///<value>Temp  Fulfillments course selected datatable </value>

        public static DataTable FulfillmentsCourseSelected
        {
            get
            {
                if (HttpContext.Current.Session["FulfillmentsCourseSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["FulfillmentsCourseSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["FulfillmentsCourseSelected"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp Fulfillments course guid
        ///<value>Temp course guid </value>

        public static string TempFulfillmentsCourseGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempFulfillmentsCourseGuid"] != null)
                {
                    return HttpContext.Current.Session["TempFulfillmentsCourseGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempFulfillmentsCourseGuid"] = value;
            }
        }

        ///<summary>
        ///Gets or sets the ix.	course owner id 
        ///<value>The course owner id </value>
        public static string c_course_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_course_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_course_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_course_owner_id_fk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	course coordinator id 
        ///<value>The course coordinator id </value>
        public static string c_course_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_course_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_course_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_course_coordinator_id_fk"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the course icon uri.
        /// <value>The icon url file name.</value>

        public static string iconUri
        {
            get
            {
                if (HttpContext.Current.Session["iconUri"] != null)
                {
                    return HttpContext.Current.Session["iconUri"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["iconUri"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the course icon uri filename.
        /// <value>The icon url file name.</value>

        public static string iconUrifilename
        {
            get
            {
                if (HttpContext.Current.Session["iconUrifilename"] != null)
                {
                    return HttpContext.Current.Session["iconUrifilename"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["iconUrifilename"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the course id.
        /// <value>edit mode course id.</value>

        public static string editCourseId
        {
            get
            {
                if (HttpContext.Current.Session["editCourseId"] != null)
                {
                    return HttpContext.Current.Session["editCourseId"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["editCourseId"] = value;
            }
        }

        ///<summary>
        ///Gets or sets the ix.	course Prerequisite on reset
        ///<value>The course Prerequisite datatable </value>

        public static DataTable ResetPrerequisite
        {
            get
            {
                if (HttpContext.Current.Session["ResetPrerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetPrerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetPrerequisite"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	temp course Fulfillments on reset
        ///<value>Temp course Fulfillments datatable </value>

        public static DataTable ResetFulfillments
        {
            get
            {
                if (HttpContext.Current.Session["ResetFulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetFulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetFulfillments"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	 Equivalencies course on reset
        ///<value>Temp  Equivalencies course  datatable </value>

        public static DataTable ResetEquivalencies
        {
            get
            {
                if (HttpContext.Current.Session["ResetEquivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetEquivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetEquivalencies"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	delivery owner id 
        ///<value>The course owner id </value>
        public static string c_delivery_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_delivery_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_delivery_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_delivery_owner_id_fk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_delivery_coordinator_id_fk
        ///<value>The course coordinator id </value>
        public static string c_delivery_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_delivery_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_delivery_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_delivery_coordinator_id_fk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_delivery_owner_name 
        ///<value>The course owner id </value>
        public static string c_delivery_owner_name
        {
            get
            {
                if (HttpContext.Current.Session["c_delivery_owner_name"] != null)
                {
                    return HttpContext.Current.Session["c_delivery_owner_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_delivery_owner_name"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_delivery_coordinator_name
        ///<value>The course coordinator id </value>
        public static string c_delivery_coordinator_name
        {
            get
            {
                if (HttpContext.Current.Session["c_delivery_coordinator_name"] != null)
                {
                    return HttpContext.Current.Session["c_delivery_coordinator_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_delivery_coordinator_name"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	location id 
        ///<value>The location id </value>
        public static string c_location_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_location_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_location_system_id_pk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_location_system_id_pk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_location_name
        ///<value>c_location_name </value>
        public static string c_location_name
        {
            get
            {
                if (HttpContext.Current.Session["c_location_name"] != null)
                {
                    return HttpContext.Current.Session["c_location_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_location_name"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	facility id 
        ///<value>The facility id </value>
        public static string c_facility_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_facility_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_facility_system_id_pk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_facility_system_id_pk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_facility_name
        ///<value>c_facility_name </value>
        public static string c_facility_name
        {
            get
            {
                if (HttpContext.Current.Session["c_facility_name"] != null)
                {
                    return HttpContext.Current.Session["c_facility_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_facility_name"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	room id 
        ///<value>The room id </value>
        public static string c_room_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_room_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_room_system_id_pk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_room_system_id_pk"] = value;
            }
        }
        ///<summary>
        ///Gets or sets the ix.	c_room_name
        ///<value>c_room_name </value>
        public static string c_room_name
        {
            get
            {
                if (HttpContext.Current.Session["c_room_name"] != null)
                {
                    return HttpContext.Current.Session["c_room_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_room_name"] = value;
            }
        }
        /// <summary>
        /// Get or sets the delivery attachments
        /// </summary>
        public static DataTable DeliveryAttachments
        {
            get
            {
                if (HttpContext.Current.Session["DeliveryAttachments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["DeliveryAttachments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["DeliveryAttachments"] = value;
            }
        }
        /// <summary>
        /// TempDeliveryAttachments
        /// </summary>
        public static DataTable TempDeliveryAttachments
        {
            get
            {
                if (HttpContext.Current.Session["TempDeliveryAttachments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempDeliveryAttachments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempDeliveryAttachments"] = value;
            }
        }
        /// <summary>
        /// Get or sets the c_delivery_system_id_pk
        /// </summary>
        public static string c_delivery_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_delivery_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_delivery_system_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_delivery_system_id_pk"] = value;
            }
        }

        /// <summary>
        /// Get or sets the c_session_system_id_pk
        /// </summary>
        public static string c_session_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_session_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_session_system_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_session_system_id_pk"] = value;
            }
        }

        /// <summary>
        /// Get or sets the c_session_location_id_fk
        /// </summary>
        public static string c_session_location_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_session_location_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_session_location_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_session_location_id_fk"] = value;
            }
        }
        /// <summary>
        /// Get or sets the c_session_facility_id_fk
        /// </summary>
        public static string c_session_facility_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_session_facility_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_session_facility_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_session_facility_id_fk"] = value;
            }
        }
        /// <summary>
        /// Get or sets the c_sessions_room_id_fk
        /// </summary>
        public static string c_session_room_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_session_room_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_session_room_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_session_room_id_fk"] = value;
            }
        }
        /// <summary>
        /// Get or Set Deliver instructor in datatable
        /// </summary>
        public static DataTable DeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["DeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["DeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["DeliveryInstructor"] = value;
            }
        }

        public static DataTable TempDeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["TempDeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempDeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempDeliveryInstructor"] = value;
            }
        }
        /// <summary>
        /// TempAddDeliveryInstructor
        /// </summary>
        public static DataTable TempAddDeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["TempAddDeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempAddDeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempAddDeliveryInstructor"] = value;
            }
        }

        /// <summary>
        /// Get or Set Deliver resource in datatable
        /// </summary>
        public static DataTable DeliveryResource
        {
            get
            {
                if (HttpContext.Current.Session["DeliveryResource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["DeliveryResource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["DeliveryResource"] = value;
            }
        }
        /// <summary>
        /// TempDeliveryResource
        /// </summary>
        public static DataTable TempDeliveryResource
        {
            get
            {
                if (HttpContext.Current.Session["TempDeliveryResource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempDeliveryResource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempDeliveryResource"] = value;
            }
        }
        /// <summary>
        /// Get or Set Deliver material in datatable
        /// </summary>
        public static DataTable DeliveryMaterial
        {
            get
            {
                if (HttpContext.Current.Session["DeliveryMaterial"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["DeliveryMaterial"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["DeliveryMaterial"] = value;
            }
        }
        public static DataTable TempDeliveryMaterial
        {
            get
            {
                if (HttpContext.Current.Session["TempDeliveryMaterial"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempDeliveryMaterial"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempDeliveryMaterial"] = value;
            }
        }

        /// <summary>
        /// Delivery Sessions
        /// </summary>
        public static DataTable DeliverySessions
        {
            get
            {
                if (HttpContext.Current.Session["DeliverySessions"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["DeliverySessions"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["DeliverySessions"] = value;
            }
        }
        /// <summary>
        /// TempDeliverySessions
        /// </summary>
        public static DataTable TempDeliverySessions
        {
            get
            {
                if (HttpContext.Current.Session["TempDeliverySessions"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempDeliverySessions"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempDeliverySessions"] = value;
            }
        }
        /// <summary>
        /// Deliverys sessions
        /// </summary>
        public static DataTable Deliveries
        {
            get
            {
                if (HttpContext.Current.Session["Deliveries"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Deliveries"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Deliveries"] = value;
            }
        }

        //Reset delivery and session
        /// <summary>
        /// Reset_Deliveries
        /// </summary>
        public static DataTable Reset_Deliveries
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Deliveries"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Deliveries"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Deliveries"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_Locales
        /// </summary>
        public static DataTable Reset_Course_Locales
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_Locales"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_Locales"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_Locales"] = value;
            }
        }
        /// <summary>
        /// Reset_Delivery_Locales
        /// </summary>
        public static DataTable Reset_Delivery_Locales
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Delivery_Locales"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Delivery_Locales"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Delivery_Locales"] = value;
            }
        }
        /// <summary>
        /// Reset_DeliveryAttachments
        /// </summary>
        public static DataTable Reset_DeliveryAttachments
        {
            get
            {
                if (HttpContext.Current.Session["Reset_DeliveryAttachments"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_DeliveryAttachments"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_DeliveryAttachments"] = value;
            }
        }
        /// <summary>
        /// Reset_DeliveryResource
        /// </summary>
        public static DataTable Reset_DeliveryResource
        {
            get
            {
                if (HttpContext.Current.Session["Reset_DeliveryResource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_DeliveryResource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_DeliveryResource"] = value;
            }
        }
        /// <summary>
        /// Reset_DeliveryMaterial
        /// </summary>
        public static DataTable Reset_DeliveryMaterial
        {
            get
            {
                if (HttpContext.Current.Session["Reset_DeliveryMaterial"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_DeliveryMaterial"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_DeliveryMaterial"] = value;
            }
        }
        /// <summary>
        /// Reset_DeliverySessions
        /// </summary>
        public static DataTable Reset_DeliverySessions
        {
            get
            {
                if (HttpContext.Current.Session["Reset_DeliverySessions"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_DeliverySessions"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_DeliverySessions"] = value;
            }
        }
        /// <summary>
        /// Reset_c_delivery_owner_name
        /// </summary>
        public static string Reset_c_delivery_owner_name
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_delivery_owner_name"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_delivery_owner_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_delivery_owner_name"] = value;
            }
        }
        /// <summary>
        /// Reset_c_delivery_coordinator_name
        /// </summary>
        public static string Reset_c_delivery_coordinator_name
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_delivery_coordinator_name"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_delivery_coordinator_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_delivery_coordinator_name"] = value;
            }
        }
        /// <summary>
        /// Reset_DeliveryInstructor
        /// </summary>
        public static DataTable Reset_DeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["Reset_DeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_DeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_DeliveryInstructor"] = value;
            }
        }
        /// <summary>
        /// Reset_Edit_DeliveryInstructor
        /// </summary>
        public static DataTable Reset_Edit_DeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Edit_DeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Edit_DeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Edit_DeliveryInstructor"] = value;
            }
        }
        /// <summary>
        /// Reset_c_session_location_id_fk
        /// </summary>
        public static string Reset_c_session_location_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_session_location_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_session_location_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_session_location_id_fk"] = value;
            }
        }
        /// <summary>
        /// Reset_c_session_facility_id_fk
        /// </summary>
        public static string Reset_c_session_facility_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_session_facility_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_session_facility_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_session_facility_id_fk"] = value;
            }
        }
        /// <summary>
        /// Reset_c_session_room_id_fk
        /// </summary>
        public static string Reset_c_session_room_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_session_room_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_session_room_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_session_room_id_fk"] = value;
            }
        }
        /// <summary>
        /// Reset_c_delivery_owner_id_fk
        /// </summary>
        public static string Reset_c_delivery_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_delivery_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_delivery_owner_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_delivery_owner_id_fk"] = value;
            }
        }
        /// <summary>
        /// Reset_c_delivery_coordinator_id_fk
        /// </summary>
        public static string Reset_c_delivery_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Reset_c_delivery_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Reset_c_delivery_coordinator_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_c_delivery_coordinator_id_fk"] = value;
            }
        }
        //Reset course delivery and session
        /// <summary>
        /// Reset_Course_Deliveries
        /// </summary>
        public static DataTable Reset_Course_Deliveries
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_Deliveries"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_Deliveries"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_Deliveries"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_DeliveryAttachments
        /// </summary>
        public static DataTable Reset_Course_DeliveryAttachments
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_DeliveryAttachments"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_DeliveryAttachments"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_DeliveryAttachments"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_DeliveryResource
        /// </summary>
        public static DataTable Reset_Course_DeliveryResource
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_DeliveryResource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_DeliveryResource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_DeliveryResource"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_DeliveryMaterial
        /// </summary>
        public static DataTable Reset_Course_DeliveryMaterial
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_DeliveryMaterial"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_DeliveryMaterial"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_DeliveryMaterial"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_DeliverySessions
        /// </summary>
        public static DataTable Reset_Course_DeliverySessions
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_DeliverySessions"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_DeliverySessions"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_DeliverySessions"] = value;
            }
        }

        /// <summary>
        /// Reset_Course_DeliveryInstructor
        /// </summary>
        public static DataTable Reset_Course_DeliveryInstructor
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_DeliveryInstructor"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_DeliveryInstructor"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_DeliveryInstructor"] = value;
            }
        }

        /// <summary>
        /// Edit_delivery_id_fk
        /// </summary>
        public static string Edit_delivery_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["Edit_delivery_id_fk"] != null)
                {
                    return HttpContext.Current.Session["Edit_delivery_id_fk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Edit_delivery_id_fk"] = value;
            }
        }
        /// <summary>
        /// u_domain_owner_id_fk
        /// </summary>
        public static string u_domain_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_domain_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_domain_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_domain_owner_id_fk"] = value;
            }
        }
        /// <summary>
        ///u_domain_coordinator_id_fk 
        /// </summary>
        public static string u_domain_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["u_domain_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["u_domain_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_domain_coordinator_id_fk"] = value;
            }
        }
        /// <summary>
        /// u_domain_owner_text
        /// </summary>
        public static string u_domain_owner_text
        {
            get
            {
                if (HttpContext.Current.Session["u_domain_owner_text"] != null)
                {
                    return HttpContext.Current.Session["u_domain_owner_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_domain_owner_text"] = value;
            }
        }
        /// <summary>
        /// u_domain_coordinator_text
        /// </summary>
        public static string u_domain_coordinator_text
        {
            get
            {
                if (HttpContext.Current.Session["u_domain_coordinator_text"] != null)
                {
                    return HttpContext.Current.Session["u_domain_coordinator_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["u_domain_coordinator_text"] = value;
            }
        }

        /// <summary>
        /// CourseDomain
        /// </summary>
        public static DataTable CourseDomain
        {
            get
            {
                if (HttpContext.Current.Session["CourseDomain"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["CourseDomain"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["CourseDomain"] = value;
            }
        }

        /// <summary>
        ///c_course_system_id_pk 
        /// </summary>
        public static string c_course_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_course_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_course_system_id_pk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_course_system_id_pk"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_Doamin
        /// </summary>
        public static DataTable Reset_Course_Domain
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_Domain"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_Domain"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_Domain"] = value;
            }
        }
        /// <summary>
        /// h_control_measure
        /// </summary>
        public static DataTable h_control_measure
        {
            get
            {
                if (HttpContext.Current.Session["h_control_measure"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["h_control_measure"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["h_control_measure"] = value;
            }
        }
        /// <summary>
        /// Hazard job title
        /// </summary>
        public static string h_job_title
        {
            get
            {
                if (HttpContext.Current.Session["h_job_title"] != null)
                {
                    return HttpContext.Current.Session["h_job_title"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["h_job_title"] = value;
            }
        }

        /// <summary>
        /// Course category
        /// </summary>
        public static DataTable CourseCategory
        {
            get
            {
                if (HttpContext.Current.Session["CourseCategory"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["CourseCategory"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["CourseCategory"] = value;
            }
        }
        /// <summary>
        /// Reset_Course_Category
        /// </summary>
        public static DataTable Reset_Course_Category
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Course_Category"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Course_Category"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Course_Category"] = value;
            }
        }
        /// <summary>
        /// Locale
        /// </summary>
        public static DataTable Locale
        {
            get
            {
                if (HttpContext.Current.Session["Locale"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Locale"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Locale"] = value;
            }
        }
        /// <summary>
        /// TempLocale
        /// </summary>
        public static DataTable TempLocale
        {
            get
            {
                if (HttpContext.Current.Session["TempLocale"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["TempLocale"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["TempLocale"] = value;
            }
        }
        public static DataTable session_Attachment
        {
            get
            {
                if (HttpContext.Current.Session["session_Attachment"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_Attachment"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_Attachment"] = value;
            }
        }
        /// <summary>
        /// Attachment_guid
        /// </summary>

        public static string Attachment_guid
        {
            get
            {
                if (HttpContext.Current.Session["Attachment_guid"] != null)
                {
                    return HttpContext.Current.Session["Attachment_guid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Attachment_guid"] = value;
            }
        }
        /// <summary>
        /// Attachment_file_name
        /// </summary>

        public static string Attachment_file_name
        {
            get
            {
                if (HttpContext.Current.Session["Attachment_file_name"] != null)
                {
                    return HttpContext.Current.Session["Attachment_file_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Attachment_file_name"] = value;
            }
        }
        /// <summary>
        /// s_facility_room_resource_id_pk
        /// </summary>
        public static string s_room_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["s_room_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["s_room_system_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_room_system_id_pk"] = value;
            }
        }
        /// <summary>
        /// Get or Set Facility_Room_Resource in datatable
        /// </summary>
        public static DataTable Facility_Room_Resource
        {
            get
            {
                if (HttpContext.Current.Session["Facility_Room_Resource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Facility_Room_Resource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Facility_Room_Resource"] = value;
            }
        }
        /// <summary>
        /// Reset_Facility_Room_Resource
        /// </summary>
        public static DataTable Reset_Facility_Room_Resource
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Facility_Room_Resource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Facility_Room_Resource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Facility_Room_Resource"] = value;
            }
        }
        /// <summary>
        /// Get or set Temp_Facility_Room_Resource
        /// </summary>
        public static DataTable Temp_Facility_Room_Resource
        {
            get
            {
                if (HttpContext.Current.Session["Temp_Facility_Room_Resource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Temp_Facility_Room_Resource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Temp_Facility_Room_Resource"] = value;
            }
        }
        /// <summary>
        /// Facility_Rooms
        /// </summary>
        public static DataTable Facility_Rooms
        {
            get
            {
                if (HttpContext.Current.Session["Facility_Rooms"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Facility_Rooms"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Facility_Rooms"] = value;
            }
        }
        /// <summary>
        /// Reset_Facility_Rooms
        /// </summary>
        public static DataTable Reset_Facility_Rooms
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Facility_Rooms"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Facility_Rooms"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Facility_Rooms"] = value;
            }
        }
        public static DataTable Reset_Rooms
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Rooms"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Rooms"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Rooms"] = value;
            }
        }
        public static DataTable Reset_Room_Resource
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Room_Resource"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Room_Resource"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Room_Resource"] = value;
            }
        }

        public static string file_guid
        {
            get
            {
                if (HttpContext.Current.Session["file_guid"] != null)
                {
                    return HttpContext.Current.Session["file_guid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["file_guid"] = value;
            }
        }
        public static string file_name
        {
            get
            {
                if (HttpContext.Current.Session["file_name"] != null)
                {
                    return HttpContext.Current.Session["file_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["file_name"] = value;
            }
        }
        /// <summary>
        /// Get or set authorized instructor course id
        /// </summary>
        public static string AuthInstructorCourseId
        {
            get
            {
                if (HttpContext.Current.Session["AuthInstructorCourseId"] != null)
                {
                    return HttpContext.Current.Session["AuthInstructorCourseId"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["AuthInstructorCourseId"] = value;
            }
        }
        /// <summary>
        /// TimeZoneLocatoin
        /// </summary>
        public static string TimeZoneLocatoin
        {
            get
            {
                if (HttpContext.Current.Session["TimeZoneLocatoin"] != null)
                {
                    return HttpContext.Current.Session["TimeZoneLocatoin"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TimeZoneLocatoin"] = value;
            }
        }

        /// Get or set the Questions
        /// </summary>
        public static DataTable session_Add_Questions
        {
            get
            {
                if (HttpContext.Current.Session["session_Add_Questions"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_Add_Questions"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_Add_Questions"] = value;
            }
        }
        /// <summary>
        /// Get or set the Questions
        /// </summary>
        public static DataTable Reset_Questions
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Questions"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Questions"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Questions"] = value;
            }
        }
        /// <summary>
        /// s_specific_user_for_first_level_id
        /// </summary>
        public static string s_specific_user_for_first_level_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_first_level_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_first_level_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_first_level_id_fk"] = value;
            }
        }
        /// <summary>
        /// s_specific_user_for_first_level_text
        /// </summary>
        public static string s_specific_user_for_first_level_text
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_first_level_text"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_first_level_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_first_level_text"] = value;
            }
        }

        /// <summary>
        /// s_specific_user_for_second_level_id
        /// </summary>
        public static string s_specific_user_for_second_level_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_second_level_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_second_level_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_second_level_id_fk"] = value;
            }
        }
        /// <summary>
        /// s_specific_user_for_second_level_text
        /// </summary>
        public static string s_specific_user_for_second_level_text
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_second_level_text"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_second_level_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_second_level_text"] = value;
            }
        }

        /// <summary>
        /// s_specific_user_for_third_level_id
        /// </summary>
        public static string s_specific_user_for_third_level_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_third_level_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_third_level_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_third_level_id_fk"] = value;
            }
        }
        /// <summary>
        /// s_specific_user_for_third_level_text
        /// </summary>
        public static string s_specific_user_for_third_level_text
        {
            get
            {
                if (HttpContext.Current.Session["s_specific_user_for_third_level_text"] != null)
                {
                    return HttpContext.Current.Session["s_specific_user_for_third_level_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_specific_user_for_third_level_text"] = value;
            }
        }
        /// <summary>
        /// preview
        /// </summary>
        public static string Preview
        {
            get
            {
                if (HttpContext.Current.Session["Preview"] != null)
                {
                    return HttpContext.Current.Session["Preview"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Preview"] = value;
            }
        }
        /// <summary>
        /// Session For Holiday Dates
        /// </summary>
        public static DataTable session_HolidayDates
        {
            get
            {
                if (HttpContext.Current.Session["session_HolidayDates"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_HolidayDates"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_HolidayDates"] = value;
            }
        }
        /// <summary>
        /// Session for Reset Holiday Dates
        /// </summary>
        public static DataTable session_reset_HolidayDates
        {
            get
            {
                if (HttpContext.Current.Session["session_HolidayDates"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_HolidayDates"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_HolidayDates"] = value;
            }
        }
        /// <summary>
        /// Splash Locales
        /// </summary>
        public static DataTable session_splash_locales
        {
            get
            {
                if (HttpContext.Current.Session["session_splash_locales"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_splash_locales"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_splash_locales"] = value;
            }
        }

        /// <summary>
        /// Splash Owner id fk
        /// </summary>
        public static string s_splash_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_splash_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_splash_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_splash_owner_id_fk"] = value;
            }
        }
        /// <summary>
        /// Splash coordinator id
        /// </summary>
        public static string s_splash_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_splash_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_splash_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_splash_coordinator_id_fk"] = value;
            }
        }

        /// <summary>
        /// Splash Coordinator name
        /// </summary>
        public static string s_splash_coordinator_name
        {
            get
            {
                if (HttpContext.Current.Session["s_splash_coordinator_name"] != null)
                {
                    return HttpContext.Current.Session["s_splash_coordinator_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_splash_coordinator_name"] = value;
            }
        }
        /// <summary>
        /// Splash owner name
        /// </summary>
        public static string s_splash_owner_name
        {
            get
            {
                if (HttpContext.Current.Session["s_splash_owner_name"] != null)
                {
                    return HttpContext.Current.Session["s_splash_owner_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_splash_owner_name"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_owner_id_fk
        /// </summary>
        public static string c_curriculum_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_curriculum_owner_id_fk"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_owner_text
        /// </summary>
        public static string c_curriculum_owner_text
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_owner_text"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_owner_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_curriculum_owner_text"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_coordinator_id_fk
        /// </summary>
        public static string c_curriculum_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_curriculum_coordinator_id_fk"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_coordinator_text
        /// </summary>
        public static string c_curriculum_coordinator_text
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_coordinator_text"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_coordinator_text"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["c_curriculum_coordinator_text"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_icon_uri
        /// </summary>
        public static string c_curriculum_icon_uri
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_icon_uri"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_icon_uri"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_curriculum_icon_uri"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the curriculum icon uri filename.
        /// <value>The icon url file name.</value>

        public static string c_curriculum_icon_uri_file_name
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_icon_uri_file_name"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_icon_uri_file_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_curriculum_icon_uri_file_name"] = value;
            }
        }

        /// <summary>
        /// Curriculum category
        /// </summary>
        public static DataTable CurriculumCategory
        {
            get
            {
                if (HttpContext.Current.Session["CurriculumCategory"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["CurriculumCategory"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["CurriculumCategory"] = value;
            }
        }
        /// <summary>
        /// CurriculumDomain
        /// </summary>
        public static DataTable CurriculumDomain
        {
            get
            {
                if (HttpContext.Current.Session["CurriculumDomain"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["CurriculumDomain"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["CurriculumDomain"] = value;
            }
        }
        /// <summary>
        /// Curriculum Prerequisite
        /// </summary>
        public static DataTable Curriculum_Prerequisite
        {
            get
            {
                if (HttpContext.Current.Session["Curriculum_Prerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Curriculum_Prerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Curriculum_Prerequisite"] = value;
            }
        }
        /// <summary>
        /// Curriculum Prerequisite Selected
        /// </summary>
        public static DataTable PrerequisiteCurriculumSelected
        {
            get
            {
                if (HttpContext.Current.Session["PrerequisiteCurriculumSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["PrerequisiteCurriculumSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["PrerequisiteCurriculumSelected"] = value;
            }
        }
        /// <summary>
        /// Temp Prerequisite Curriculum Guid
        /// </summary>
        public static string TempPrerequisitteCurriculumGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempPrerequisitteCurriculumGuid"] != null)
                {
                    return HttpContext.Current.Session["TempPrerequisitteCurriculumGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempPrerequisitteCurriculumGuid"] = value;
            }
        }
        /// <summary>
        /// Temp Curriculum Prerequisite
        /// </summary>
        public static DataTable TempCurriculumPrerequisite
        {
            get
            {
                if (HttpContext.Current.Session["TempCurriculumPrerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempCurriculumPrerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempCurriculumPrerequisite"] = value;
            }
        }
        /// <summary>
        /// Curriculum Equivalencies
        /// </summary>
        public static DataTable Curriculum_Equivalencies
        {
            get
            {
                if (HttpContext.Current.Session["Curriculum_Equivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Curriculum_Equivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Curriculum_Equivalencies"] = value;
            }
        }
        /// <summary>
        /// Curriculum Equivalencies Selected
        /// </summary>
        public static DataTable EquivalenciesCurriculumSelected
        {
            get
            {
                if (HttpContext.Current.Session["EquivalenciesCurriculumSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["EquivalenciesCurriculumSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["EquivalenciesCurriculumSelected"] = value;
            }
        }
        /// <summary>
        /// Temp Equivalencies Curriculum Guid
        /// </summary>
        public static string TempEquivalenciesCurriculumGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempEquivalenciesCurriculumGuid"] != null)
                {
                    return HttpContext.Current.Session["TempEquivalenciesCurriculumGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempEquivalenciesCurriculumGuid"] = value;
            }
        }
        /// <summary>
        /// Temp Curriculum Equivalencies
        /// </summary>
        public static DataTable TempCurriculumEquivalencies
        {
            get
            {
                if (HttpContext.Current.Session["TempCurriculumEquivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempCurriculumEquivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempCurriculumEquivalencies"] = value;
            }
        }
        /// <summary>
        /// Curriculum Fulfillments
        /// </summary>
        public static DataTable Curriculum_Fulfillments
        {
            get
            {
                if (HttpContext.Current.Session["Curriculum_Fulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Curriculum_Fulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Curriculum_Fulfillments"] = value;
            }
        }
        /// <summary>
        /// Curriculum Fulfillments Selected
        /// </summary>
        public static DataTable FulfillmentsCurriculumSelected
        {
            get
            {
                if (HttpContext.Current.Session["FulfillmentsCurriculumSelected"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["FulfillmentsCurriculumSelected"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["FulfillmentsCurriculumSelected"] = value;
            }
        }
        /// <summary>
        /// Temp Fulfillments Curriculum Guid
        /// </summary>
        public static string TempFulfillmentsCurriculumGuid
        {
            get
            {
                if (HttpContext.Current.Session["TempFulfillmentsCurriculumGuid"] != null)
                {
                    return HttpContext.Current.Session["TempFulfillmentsCurriculumGuid"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["TempFulfillmentsCurriculumGuid"] = value;
            }
        }
        /// <summary>
        /// Temp Curriculum Fulfillments
        /// </summary>
        public static DataTable TempCurriculumFulfillments
        {
            get
            {
                if (HttpContext.Current.Session["TempCurriculumFulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempCurriculumFulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempCurriculumFulfillments"] = value;
            }
        }
        /// <summary>
        /// c_curriculum_system_id_pk
        /// </summary>
        public static string c_curriculum_system_id_pk
        {
            get
            {
                if (HttpContext.Current.Session["c_curriculum_system_id_pk"] != null)
                {
                    return HttpContext.Current.Session["c_curriculum_system_id_pk"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["c_curriculum_system_id_pk"] = value;
            }
        }
        /// <summary>
        /// TempCurriculumAttachments
        /// </summary>
        public static DataTable TempCurriculumAttachments
        {
            get
            {
                if (HttpContext.Current.Session["TempCurriculumAttachments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempCurriculumAttachments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempCurriculumAttachments"] = value;
            }
        }
        /// <summary>
        /// Reset_Curriculum_Attachments
        /// </summary>
        public static DataTable Reset_Curriculum_Attachments
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curriculum_Attachments"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Curriculum_Attachments"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curriculum_Attachments"] = value;
            }
        }
        /// <summary>
        /// Reset_Curriculum_Domain
        /// </summary>
        public static DataTable Reset_Curriculum_Domain
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curriculum_Domain"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Curriculum_Domain"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curriculum_Domain"] = value;
            }
        }
        /// <summary>
        /// Reset_Curriculum_Category
        /// </summary>
        public static DataTable Reset_Curriculum_Category
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curriculum_Category"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Curriculum_Category"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curriculum_Category"] = value;
            }
        }
        /// <summary>
        /// Reset_Curriculum_Locales
        /// </summary>
        public static DataTable Reset_Curriculum_Locales
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curriculum_Locales"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_Curriculum_Locales"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curriculum_Locales"] = value;
            }
        }
        /// <summary>
        /// ResetCurriculumPrerequisite
        /// </summary>
        public static DataTable ResetCurriculumPrerequisite
        {
            get
            {
                if (HttpContext.Current.Session["ResetCurriculumPrerequisite"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetCurriculumPrerequisite"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetCurriculumPrerequisite"] = value;
            }
        }
        /// <summary>
        /// ResetCurriculumEquivalencies
        /// </summary>
        public static DataTable ResetCurriculumEquivalencies
        {
            get
            {
                if (HttpContext.Current.Session["ResetCurriculumEquivalencies"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetCurriculumEquivalencies"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetCurriculumEquivalencies"] = value;
            }
        }
        /// <summary>
        /// ResetCurriculumFulfillments
        /// </summary>
        public static DataTable ResetCurriculumFulfillments
        {
            get
            {
                if (HttpContext.Current.Session["ResetCurriculumFulfillments"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetCurriculumFulfillments"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["ResetCurriculumFulfillments"] = value;
            }
        }
        /// <summary>
        /// CurriculumDateTime
        /// </summary>
        public static DateTime CurriculumDateTime
        {
            get
            {
                return (DateTime)HttpContext.Current.Session["CurriculumDateTime"];

            }
            set
            {
                HttpContext.Current.Session["CurriculumDateTime"] = value;
            }

        }
        public static string IsClose
        {
            get
            {
                if (HttpContext.Current.Session["IsClose"] != null)
                {
                    return HttpContext.Current.Session["IsClose"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["IsClose"] = value;
            }
        }
        public static DataTable session_notification_locale
        {
            get
            {
                if (HttpContext.Current.Session["session_notification_locale"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["session_notification_locale"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_notification_locale"] = value;
            }
        }

        public static DataTable session_notification_attachment
        {
            get
            {
                if (HttpContext.Current.Session["session_notification_attachment"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["session_notification_attachment"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_notification_attachment"] = value;
            }
        }
        public static string Active_Popup
        {
            get
            {
                if (HttpContext.Current.Session["Active_Popup"] != null)
                {
                    return HttpContext.Current.Session["Active_Popup"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["Active_Popup"] = value;
            }
        }
        public static DataTable TempPathSection
        {
            get
            {
                if (HttpContext.Current.Session["TempPathSection"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempPathSection"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempPathSection"] = value;
            }
        }
        public static DataTable TempPathCourse
        {
            get
            {
                if (HttpContext.Current.Session["TempPathCourse"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempPathCourse"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempPathCourse"] = value;
            }
        }
        public static DataTable AddUserForSendInspection
        {
            get
            {
                if (HttpContext.Current.Session["AddUserForSendInspection"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["AddUserForSendInspection"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["AddUserForSendInspection"] = value;
            }
        }

        public static DataTable AddUserForSendFieldNotes
        {
            get
            {
                if (HttpContext.Current.Session["AddUserForSendFieldNotes"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["AddUserForSendFieldNotes"];


                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["AddUserForSendFieldNotes"] = value;
            }
        }
        public static DataTable AddUserForSendOjt
        {
            get
            {
                if (HttpContext.Current.Session["AddUserForSendOjt"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["AddUserForSendOjt"];


                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["AddUserForSendOjt"] = value;
            }
        }
        public static DataTable TempAttachment
        {
            get
            {
                if (HttpContext.Current.Session["TempAttachment"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempAttachment"];


                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempAttachment"] = value;
            }
        }
        public static DataTable ResetFieldNotesAttachment
        {
            get
            {
                if (HttpContext.Current.Session["ResetFieldNotesAttachment"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetFieldNotesAttachment"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["ResetFieldNotesAttachment"] = value;
            }
        }
        public static DataTable TempRecertPathSection
        {
            get
            {
                if (HttpContext.Current.Session["TempRecertPathSection"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempRecertPathSection"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempRecertPathSection"] = value;
            }
        }
        public static DataTable TempRecertPathCourse
        {
            get
            {
                if (HttpContext.Current.Session["TempRecertPathCourse"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempRecertPathCourse"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["TempRecertPathCourse"] = value;
            }
        }
        /// <summary>
        /// Reset Curricula Path
        /// </summary>
        public static DataTable Reset_Curricula_Path
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Path"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Path"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Path"] = value;
            }
        }

        public static DataTable Reset_Curricula_Sections
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Sections"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Sections"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Sections"] = value;
            }
        }


        public static DataTable Reset_Curricula_Courses
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Courses"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Courses"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Courses"] = value;
            }
        }
        public static DataTable Reset_Curricula_Recert_Path
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Recert_Path"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Recert_Path"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Recert_Path"] = value;
            }
        }

        public static DataTable Reset_Curricula_Recert_Sections
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Recert_Sections"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Recert_Sections"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Recert_Sections"] = value;
            }
        }


        public static DataTable Reset_Curricula_Recert_Courses
        {
            get
            {
                if (HttpContext.Current.Session["Reset_Curricula_Recert_Courses"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_Curricula_Recert_Courses"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["Reset_Curricula_Recert_Courses"] = value;
            }
        }
        public static DataTable Employee
        {
            get
            {
                if (HttpContext.Current.Session["Employee"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Employee"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Employee"] = value;
            }
        }
        public static DataTable session_vehicle_values
        {
            get
            {
                if (HttpContext.Current.Session["session_vehicle_values"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_vehicle_values"];



                }
                else
                {
                    DataTable dtnull = new DataTable();

                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["session_vehicle_values"] = value;
            }
        }
        /// <summary>
        /// GradingSchemeValues
        /// </summary>
        public static DataTable GradingSchemeValues
        {
            get
            {
                if (HttpContext.Current.Session["GradingSchemeValues"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["GradingSchemeValues"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["GradingSchemeValues"] = value;
            }
        }
        public static DataTable TempEmployeelist
        {
            get
            {
                if (HttpContext.Current.Session["TempEmployeelist"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempEmployeelist"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["TempEmployeelist"] = value;
            }
        }
        public static DataTable SelectedEmployeelist
        {
            get
            {
                if (HttpContext.Current.Session["SelectedEmployeelist"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["SelectedEmployeelist"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["SelectedEmployeelist"] = value;
            }
        }

        public static DataTable TempEmployeelist_delivery
        {
            get
            {
                if (HttpContext.Current.Session["TempEmployeelist_delivery"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["TempEmployeelist_delivery"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["TempEmployeelist_delivery"] = value;
            }
        }
        public static string selecteduserId_OLT
        {
            get
            {
                if (HttpContext.Current.Session["selecteduserId_OLT"] != null)
                {
                    return HttpContext.Current.Session["selecteduserId_OLT"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["selecteduserId_OLT"] = value;
            }
        }
        public static string u_profile_my_system_splashes_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_splashes_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_system_splashes_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_splashes_collapse_pref"] = value;
            }

        }


        public static int u_profile_my_system_splashes_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_splashes_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_system_splashes_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_splashes_records_display_pref"] = value;
            }

        }


        public static string u_profile_my_system_themes_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_themes_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_system_themes_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_themes_collapse_pref"] = value;
            }

        }


        public static int u_profile_my_system_themes_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_themes_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_system_themes_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_themes_records_display_pref"] = value;
            }

        }

        public static string u_profile_my_system_reports_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_reports_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_system_reports_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_reports_collapse_pref"] = value;
            }

        }


        public static int u_profile_my_system_reports_records_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_system_reports_records_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_system_reports_records_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_system_reports_records_display_pref"] = value;
            }

        }


        public static int u_profile_my_admin_todos_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_admin_todos_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_admin_todos_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_admin_todos_display_pref"] = value;
            }

        }
        public static int u_profile_my_admin_courses_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_admin_courses_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_admin_courses_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_admin_courses_display_pref"] = value;
            }

        }
        public static int u_profile_my_admin_reports_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_admin_reports_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_admin_reports_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_admin_reports_display_pref"] = value;
            }

        }

        public static string u_profile_my_admin_todos_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_admin_todos_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_admin_todos_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_admin_todos_collapse_pref"] = value;
            }

        }

        public static string u_profile_my_amdin_courses_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_amdin_courses_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_amdin_courses_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_amdin_courses_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_admin_reports_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_admin_reports_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_admin_reports_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_admin_reports_collapse_pref"] = value;
            }

        }

        public static string u_profile_my_inst_todos_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_todos_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_inst_todos_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_todos_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_inst_rosters_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_rosters_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_inst_rosters_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_rosters_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_inst_reports_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_reports_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_inst_reports_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_reports_collapse_pref"] = value;
            }

        }

        public static int u_profile_my_inst_todos_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_todos_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_inst_todos_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_todos_display_pref"] = value;
            }

        }
        public static int u_profile_my_inst_rosters_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_rosters_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_inst_rosters_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_rosters_display_pref"] = value;
            }

        }
        public static int u_profile_my_inst_reports_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_inst_reports_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_inst_reports_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_inst_reports_display_pref"] = value;
            }

        }

        public static string u_profile_my_train_todos_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_todos_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_train_todos_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_todos_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_train_deliveries_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_deliveries_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_train_deliveries_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_deliveries_collapse_pref"] = value;
            }

        }

        public static string u_profile_my_train_reports_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_reports_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_train_reports_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_reports_collapse_pref"] = value;
            }

        }
        public static int u_profile_my_train_todos_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_todos_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_train_todos_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_todos_display_pref"] = value;
            }

        }

        public static int u_profile_my_train_deliveries_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_deliveries_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_train_deliveries_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_deliveries_display_pref"] = value;
            }

        }

        public static int u_profile_my_train_reports_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_train_reports_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_train_reports_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_train_reports_display_pref"] = value;
            }

        }
        public static string u_profile_my_comp_todos_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_todos_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_comp_todos_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_todos_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_comp_harm_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_harm_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_comp_harm_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_harm_collapse_pref"] = value;
            }

        }
        public static string u_profile_my_comp_giris_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_giris_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_comp_giris_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_giris_collapse_pref"] = value;
            }

        }

        public static string u_profile_my_comp_reports_collapse_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_reports_collapse_pref"] != null)
                {
                    return HttpContext.Current.Session["u_profile_my_comp_reports_collapse_pref"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_reports_collapse_pref"] = value;
            }

        }

        public static int u_profile_my_comp_todos_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_todos_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_comp_todos_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_todos_display_pref"] = value;
            }

        }

        public static int u_profile_my_comp_harm_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_harm_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_comp_harm_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_harm_display_pref"] = value;
            }

        }
        public static int u_profile_my_comp_giris_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_giris_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_comp_giris_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_giris_display_pref"] = value;
            }

        }
        public static int u_profile_my_comp_reports_display_pref
        {
            get
            {
                if (HttpContext.Current.Session["u_profile_my_comp_reports_display_pref"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["u_profile_my_comp_reports_display_pref"]);
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                HttpContext.Current.Session["u_profile_my_comp_reports_display_pref"] = value;
            }

        }

        public static string navigationText
        {
            get
            {
                if (HttpContext.Current.Session["navigationText"] != null)
                {
                    return HttpContext.Current.Session["navigationText"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["navigationText"] = value;
            }

        }
        public static bool isLeraningHistory
        {
            get
            {
                if (HttpContext.Current.Session["isLeraningHistory"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["isLeraningHistory"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["isLeraningHistory"] = value;
            }
        }
        public static DataTable ResetOjtAttachment
        {
            get
            {
                if (HttpContext.Current.Session["ResetOjtAttachment"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["ResetOjtAttachment"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["ResetOjtAttachment"] = value;
            }
        }

        public static DataTable WaitList_details
        {
            get
            {
                if (HttpContext.Current.Session["WaitList_details"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["WaitList_details"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["WaitList_details"] = value;
            }
        }

        public static DataTable Reset_WaitList 
        {
            get
            {
                if (HttpContext.Current.Session["Reset_WaitList"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_WaitList"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_WaitList"] = value;
            }
        }
        public static bool isWaitlistAdded
        {
            get
            {
                if (HttpContext.Current.Session["isWaitlistAdded"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["isWaitlistAdded"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["isWaitlistAdded"] = value;
            }
        }

        public static DataTable Compltion_courses
        {
            get
            {
                if (HttpContext.Current.Session["Compltion_courses"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Compltion_courses"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Compltion_courses"] = value;
            }
        }

        public static DataTable Compltion_employees
        {
            get
            {
                if (HttpContext.Current.Session["Compltion_employees"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Compltion_employees"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Compltion_employees"] = value;
            }
        }

        public static DataTable MassEnrollment_employees
        {
            get
            {
                if (HttpContext.Current.Session["MassEnrollment_employees"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["MassEnrollment_employees"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["MassEnrollment_employees"] = value;
            }
        }

        public static DataTable Enrollment_courses_curriculum
        {
            get
            {
                if (HttpContext.Current.Session["Enrollment_courses_curriculum"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Enrollment_courses_curriculum"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Enrollment_courses_curriculum"] = value;
            }
        }
        public static DataTable Enrollment_employees
        {
            get
            {
                if (HttpContext.Current.Session["Enrollment_employees"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Enrollment_employees"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Enrollment_employees"] = value;
            }
        }
        public static DataTable Selected_delivery
        {
            get
            {
                if (HttpContext.Current.Session["Selected_delivery"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Selected_delivery"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Selected_delivery"] = value;
            }
        }
        public static bool  isFieldNoteLoad
        {
            get
            {
                if (HttpContext.Current.Session["isFieldNoteLoad"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Session["isFieldNoteLoad"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["isFieldNoteLoad"] = value;
            }
        }

        public static DataTable defaults_theme_logo
        {
            get
            {
                if (HttpContext.Current.Session["defaults_theme_logo"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["defaults_theme_logo"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["defaults_theme_logo"] = value;
            }
        }

        public static DataTable defaults_theme_color
        {
            get
            {
                if (HttpContext.Current.Session["defaults_theme_color"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["defaults_theme_color"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["defaults_theme_color"] = value;
            }
        }

        public static DataTable s_theme_edit_color
        {
            get
            {
                if (HttpContext.Current.Session["s_theme_edit_color"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["s_theme_edit_color"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["s_theme_edit_color"] = value;
            }
        }

        public static string s_theme_owner_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_theme_owner_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_theme_owner_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_theme_owner_id_fk"] = value;
            }
        }
        /// <summary>
        /// Splash coordinator id
        /// </summary>
        public static string s_theme_coordinator_id_fk
        {
            get
            {
                if (HttpContext.Current.Session["s_theme_coordinator_id_fk"] != null)
                {
                    return HttpContext.Current.Session["s_theme_coordinator_id_fk"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_theme_coordinator_id_fk"] = value;
            }
        }

        /// <summary>
        /// Splash Coordinator name
        /// </summary>
        public static string s_theme_coordinator_name
        {
            get
            {
                if (HttpContext.Current.Session["s_theme_coordinator_name"] != null)
                {
                    return HttpContext.Current.Session["s_theme_coordinator_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_theme_coordinator_name"] = value;
            }
        }
        /// <summary>
        /// Splash owner name
        /// </summary>
        public static string s_theme_owner_name
        {
            get
            {
                if (HttpContext.Current.Session["s_theme_owner_name"] != null)
                {
                    return HttpContext.Current.Session["s_theme_owner_name"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                HttpContext.Current.Session["s_theme_owner_name"] = value;
            }
        }

        public static DataTable Reset_theme_logo
        {
            get
            {
                if (HttpContext.Current.Session["Reset_theme_logo"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["Reset_theme_logo"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_theme_logo"] = value;
            }
        }
        public static string s_digital_media_source_file_name
        {
            get
            {
                if (HttpContext.Current.Session["s_digital_media_source_file_name"] != null)
                {
                    return HttpContext.Current.Session["s_digital_media_source_file_name"].ToString();

                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["s_digital_media_source_file_name"] = value;
            }
        }

        public static DataTable session_reset_DigitalMediaFiles
        {
            get
            {
                if (HttpContext.Current.Session["session_reset_DigitalMediaFiles"] != null)
                {

                    return (DataTable)HttpContext.Current.Session["session_reset_DigitalMediaFiles"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["session_reset_DigitalMediaFiles"] = value;
            }
        }

        public static string ojt_upload_certification_file_name
        {
            get
            {
                if (HttpContext.Current.Session["ojt_upload_certification"] != null)
                {
                    return HttpContext.Current.Session["ojt_upload_certification"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["ojt_upload_certification"] = value;
            }
        }

        public static string ojt_upload_certification_file_path
        {
            get
            {
                if (HttpContext.Current.Session["ojt_upload_certification_file_path"] != null)
                {
                    return HttpContext.Current.Session["ojt_upload_certification_file_path"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["ojt_upload_certification_file_path"] = value;
            }
        }

        public static string ojt_upload_certification_file_extension
        {
            get
            {
                if (HttpContext.Current.Session["ojt_upload_certification_file_extension"] != null)
                {
                    return HttpContext.Current.Session["ojt_upload_certification_file_extension"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["ojt_upload_certification_file_extension"] = value;
            }
        }

        public static string ojt_upload_certification_check_file_name
        {
            get
            {
                if (HttpContext.Current.Session["ojt_upload_certification_file_path"] != null)
                {
                    return HttpContext.Current.Session["ojt_upload_certification_file_path"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                HttpContext.Current.Session["ojt_upload_certification_file_path"] = value;
            }
        }

        /// <summary>
        /// BackgroundJobs
        /// </summary>
        public static DataTable BackgroundJobs
        {
            get
            {
                if (HttpContext.Current.Session["BackgroundJobs"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["BackgroundJobs"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["BackgroundJobs"] = value;
            }
        }

        public static DataTable AssignmentRule_CatalogItem
        {
            get
            {
                if (HttpContext.Current.Session["AssignmentRule_CatalogItem"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["AssignmentRule_CatalogItem"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }

            }
            set
            {
                HttpContext.Current.Session["AssignmentRule_CatalogItem"] = value;
            }
        }

        public static DataTable Reset_AssignmentRule_CatalogItem
        {
            get
            {
                if (HttpContext.Current.Session["Reset_AssignmentRule_CatalogItem"] != null)
                {
                    return (DataTable)HttpContext.Current.Session["Reset_AssignmentRule_CatalogItem"];
                }
                else
                {
                    DataTable dtnull = new DataTable();
                    return dtnull;
                }
            }
            set
            {
                HttpContext.Current.Session["Reset_AssignmentRule_CatalogItem"] = value;
            }
        }

        public static void clearsession()
        {
            sessionid = "";
            u_sessionguid = "";
            u_username = "";
            u_firstname = "";
            u_middlename = "";
            u_lastname = "";
            u_userid = "";
            language = "";
            u_domain = "";
            u_locale = "";
            u_timezone = "";
            u_user_type = "";
            u_sr_is_employee = false;
            u_sr_is_manager = false;
            u_sr_is_compliance = false;
            u_sr_is_instructor = false;
            u_sr_is_training = false;
            u_sr_is_administrator = false;
            u_sr_is_system_admin = false;
            user_password = "";

            u_hris_alternate_manager_id_fk = "";
            u_hris_alternate_manager_text = "";

            u_hris_alternate_mentor_id_fk = "";
            u_hris_alternate_mentor_text = "";

            u_hris_alternate_supervisor_id_fk = "";
            u_hris_alternate_supervisor_text = "";

            u_hris_manager_id_fk = "";
            u_hris_manager_text = "";

            u_hris_mentor_id_fk = "";
            u_hris_mentor_text = "";

            u_hris_supervisor_id_fk = "";
            u_hris_supervisor_text = "";

            converted_datetime = "";
            session_witness = null;
            session_EmployeeInterview = null;
            session_ExtenuatingCondition = null;
            session_Photo = null;
            session_PoliceReport = null;
            session_SceneSketch = null;

            session_Custom_Customer = null;
            Prerequisite = null;
            TempPrerequisite = null;
            Hazard = null;
            ControlMeasure = null;
            temp_h_hazard_id_pk = "";
            brwcatalog_bredcrumb = "";
            c_owner_name = "";
            c_coordinator_name = "";
            TempPrerequisiteCourseGuid = "";

            c_course_coordinator_id_fk = "";
            c_course_owner_id_fk = "";
            editCourseId = "";
            c_delivery_coordinator_id_fk = "";
            c_delivery_owner_id_fk = "";
            c_delivery_owner_name = "";
            c_delivery_coordinator_name = "";
            CourseDomain = null;
            c_course_system_id_pk = "";
            Reset_Course_Domain = null;



        }


    }
}