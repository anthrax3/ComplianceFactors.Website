using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using ComplicanceFactor.Common;
using System.Configuration;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Employee.Enroll
{
    public partial class ecolt_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string deliveryId;
        private string type;
        private string courseid;
        private string waitList;
        private string _attachmentpath = "~/SystemHome/Catalog/Course/Delivery/Attachments/";
        private bool c_course_approval;
        private bool c_delivery_approval;
        private bool submitRequest;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            submitRequest = false;
            deliveryId = Request.QueryString["id"];
            type = Request.QueryString["type"];
            courseid = Request.QueryString["courseid"];
            waitList = Request.QueryString["waitlist"];
            hdDeliveryType.Value = type;
            if (!string.IsNullOrEmpty(Request.QueryString["ca"]))
            {
                c_course_approval = Convert.ToBoolean(Request.QueryString["ca"]);
            }
            else
            {
                c_course_approval = false;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["approval"]))
            {
                c_delivery_approval = Convert.ToBoolean(Request.QueryString["approval"]);
            }
            else
            {
                c_delivery_approval = false;
            }
            if (!IsPostBack)
            {
                GetDelivery(deliveryId);
            }
        }
        private void GetDelivery(string deliveryId)
        {
            DataSet dsDeliveries = SystemCatalogBLL.GetDeliveries(deliveryId);
            //get delivery
            SystemCatalog delivery = new SystemCatalog();
            delivery = SystemCatalogBLL.GetDelivery(deliveryId, dsDeliveries.Tables[0]);
            //bind delivery session
            gvSession.DataSource = dsDeliveries.Tables[4];
            gvSession.DataBind();
            //bind delivery attachment
            gvAddDeliveryAttachments.DataSource = dsDeliveries.Tables[3];
            gvAddDeliveryAttachments.DataBind();
            if ((type == "ILT" || type == "VLT"))
            {
                //Approval
                if (c_course_approval == true || delivery.c_delivery_approval_req == true)
                {
                    ////ILT/VLT not full
                    //if ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False")
                    //{
                    //    btnRequestApproval.Style.Add("display", "block");
                    //}
                    ////ILT/VLT not full and waitlist (waitlist count not equal to max waitlist)
                    //else if ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count != Convert.ToString(delivery.c_delivery_max_waitlist))
                    //{
                    //    btnGoToWaitList.Style.Add("display", "block");
                    //}
                    ////ILT/VLT not full and waitlist (waitlist count equal to max waitlist)
                    //else if ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    //{
                    //    btnGoToWaitList.Style.Add("display", "block");
                    //}
                    ////ILT/VLT full and waitlist
                    //else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False")
                    //{
                    //    btnRequestApproval.Style.Add("display", "block");
                    //}
                    ////ILT/VLT full and waitlist full
                    //else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    //{
                    //    btnSubmitRequest.Style.Add("display", "block");
                    //}
                    //else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True")
                    //{
                    //    btnGoToWaitList.Style.Add("display", "block");
                    //}

                    //ILT/VLT not full and waitlist false
                    if ((delivery.c_delivery_max_enroll > Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False")
                    {
                        btnRequestApproval.Style.Add("display", "block");
                    }
                    //ILT/VLT not full and max=0 and min=0
                    else if ((delivery.c_delivery_max_enroll == 0) && (Convert.ToInt32(delivery.c_enroll_delivery_count) == 0) && waitList == "False")
                    {
                        btnRequestApproval.Style.Add("display", "block");
                    }
                    // If max=0 and c_enroll_delivery_count> 0
                    else if (Convert.ToInt32(delivery.c_enroll_delivery_count) > (delivery.c_delivery_max_enroll) && waitList == "False")
                    {
                        btnRequestApproval.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist not full
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False" && delivery.c_waitlist_count != Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist full
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnSubmitRequest.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist,waitlist=True
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count != Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist full,waitlist=True
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT not full ,waitlist=True
                    if ((delivery.c_delivery_max_enroll > Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True")
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                }
                //Not approval
                else
                {
                    //ILT/VLT not full and waitlist=false
                    if ((delivery.c_delivery_max_enroll > Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False")
                    {
                        btnConfirmEnrollment.Style.Add("display", "block");
                    }
                    //ILT/VLT not full and max=0 and min=0
                    else if ((delivery.c_delivery_max_enroll == 0) && (Convert.ToInt32(delivery.c_enroll_delivery_count) == 0) && waitList == "False")
                    {
                        btnConfirmEnrollment.Style.Add("display", "block");
                    }
                    // If max=0 and c_enroll_delivery_count> 0
                    else if (Convert.ToInt32(delivery.c_enroll_delivery_count) > (delivery.c_delivery_max_enroll) && waitList == "False")
                    {
                        btnConfirmEnrollment.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist full,waitlist=false
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False" && delivery.c_waitlist_count != Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist full
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnSubmitRequest.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist not full
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count != Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT full and waitlist full,waitlist=True
                    else if ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True" && delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }
                    //ILT/VLT not full ,waitlist=True
                    if ((delivery.c_delivery_max_enroll > Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True")
                    {
                        btnGoToWaitList.Style.Add("display", "block");
                    }

                }

                ///

                //if ((delivery.c_delivery_approval_req == true && delivery.c_waitlist_count == "5") || ((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False") || ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False") && (delivery.c_delivery_approval_req == false && c_course_approval == "False"))
                //{
                //    btnRequestApproval.Style.Add("display", "block");
                //}
                //else if (delivery.c_waitlist_count == Convert.ToString(delivery.c_delivery_max_waitlist))
                //{
                //    btnSubmitRequest.Style.Add("display", "block");
                //}
                //else if (((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False") || ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "False") && (delivery.c_delivery_approval_req == false && c_course_approval == "False"))
                //{
                //    btnConfirmEnrollment.Style.Add("display", "block");
                //}
                //else if (((delivery.c_delivery_max_enroll == Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True") || ((delivery.c_delivery_max_enroll != Convert.ToInt32(delivery.c_enroll_delivery_count)) && waitList == "True"))
                //{
                //    btnGoToWaitList.Style.Add("display", "block");
                //}

            }
            else if (delivery.c_delivery_approval_req == false && c_course_approval == false)
            {
                btnConfirmEnrollment.Style.Add("display", "block");
            }
            else if (delivery.c_delivery_approval_req == true || c_course_approval == true)
            {
                btnRequestApproval.Style.Add("display", "inline");
            }

            //if (type != "OLT" && waitList == "False")
            //{
            //    gvSession.DataSource = dsDeliveries.Tables[4];
            //    gvSession.DataBind();
            //    //bind delivery attachment
            //    gvAddDeliveryAttachments.DataSource = dsDeliveries.Tables[3];
            //    gvAddDeliveryAttachments.DataBind();
            //    if (delivery.c_delivery_approval_req == true && delivery.c_waitlist_count !="5")
            //    {
            //        //btnConfirmEnrollment.Style.Add("display", "none");
            //        //btnGoToWaitList.Style.Add("display", "none");
            //        //btnSubmitRequest.Style.Add("display", "none");
            //        btnRequestApproval.Style.Add("display", "block");
            //    }
            //    else if (delivery.c_waitlist_count == "5")
            //    {
            //        //btnConfirmEnrollment.Style.Add("display", "none");
            //        //btnGoToWaitList.Style.Add("display", "none");
            //        btnSubmitRequest.Style.Add("display", "block");
            //    }
            //    else
            //    {
            //        btnConfirmEnrollment.Style.Add("display", "block");
            //    }
            //    lblWaitList.Text = delivery.c_waitlist_count + " out of 5";
            //}
            //else if (type != "OLT" && waitList == "True")
            //{
            //    gvSession.DataSource = dsDeliveries.Tables[4];
            //    gvSession.DataBind();
            //    //bind delivery attachment
            //    gvAddDeliveryAttachments.DataSource = dsDeliveries.Tables[3];
            //    gvAddDeliveryAttachments.DataBind();
            //    if (delivery.c_delivery_approval_req == true)
            //    {
            //        //btnConfirmEnrollment.Style.Add("display", "none");
            //        //btnGoToWaitList.Style.Add("display", "none");
            //        //btnSubmitRequest.Style.Add("display", "none");
            //        btnRequestApproval.Style.Add("display", "block");
            //    }
            //    else if (delivery.c_waitlist_count == "5")
            //    {
            //        //btnConfirmEnrollment.Style.Add("display", "none");
            //        //btnGoToWaitList.Style.Add("display", "none");
            //        btnSubmitRequest.Style.Add("display", "block");
            //    }
            //    else
            //    {
            //        //btnConfirmEnrollment.Style.Add("display", "none");
            //        btnGoToWaitList.Style.Add("display", "block");
            //    }


            //    lblWaitList.Text = delivery.c_waitlist_count + " out of 5";
            //}
            //else if (delivery.c_delivery_approval_req == true)
            //{
            //    btnConfirmEnrollment.Style.Add("display", "none");
            //    btnGoToWaitList.Style.Add("display", "none");
            //    btnSubmitRequest.Style.Add("display", "none");
            //    btnRequestApproval.Style.Add("display", "block");
            //}
            //else
            //{
            //    lblSessionNone.Text = "None";
            //    lblAttachmentNone.Text = "None";
            //    btnConfirmEnrollment.Style.Add("display", "block");
            //}

            lblDeliveryId.Text = delivery.c_delivery_id_pk;
            lblDeliveryType.Text = delivery.s_delivery_type_text;
            lblTitle.Text = delivery.c_delivery_title;
            lblDescription.Text = delivery.c_delivery_desc;
            lblAbstract.Text = delivery.c_delivery_abstract;
            lblApprovalRequired.Text = delivery.c_delivery_approval_req_text;
            lblCreditHours.Text = Convert.ToString(delivery.c_delivery_credit_hours);
            lblCreditUnits.Text = Convert.ToString(delivery.c_delivery_credit_units);
            lblOwner.Text = delivery.c_delivery_owner_name;
            lblCoordinator.Text = delivery.c_delivery_coordinator_name;
            lblMinEnroll.Text = Convert.ToString(delivery.c_delivery_min_enroll);
            lblMaxEnroll.Text = Convert.ToString(delivery.c_delivery_max_enroll);
            lblCustom01.Text = delivery.c_delivery_custom_01;
            lblCustom02.Text = delivery.c_delivery_custom_02;
            lblCustom03.Text = delivery.c_delivery_custom_03;
            lblCustom04.Text = delivery.c_delivery_custom_04;
            lblCustom05.Text = delivery.c_delivery_custom_05;
            lblCustom06.Text = delivery.c_delivery_custom_06;
            lblCustom07.Text = delivery.c_delivery_custom_07;
            lblCustom08.Text = delivery.c_delivery_custom_08;
            lblCustom09.Text = delivery.c_delivery_custom_09;
            lblCustom10.Text = delivery.c_delivery_custom_10;
            lblCustom11.Text = delivery.c_delivery_custom_11;
            lblCustom12.Text = delivery.c_delivery_custom_12;
            lblCustom13.Text = delivery.c_delivery_custom_13;
            lblCurrentlyEnrolled.Text = delivery.c_enroll_delivery_count;
            lblWaitList.Text = delivery.c_waitlist_count + " out of " + delivery.c_delivery_max_waitlist;

        }
        protected void gvSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSession1 = (Label)e.Row.FindControl("lblSession1");
                Label lblSession2 = (Label)e.Row.FindControl("lblSession2");
                lblSession1.Text = DataBinder.Eval(e.Row.DataItem, "c_session_title").ToString() + "<br>" + "(" + DataBinder.Eval(e.Row.DataItem, "c_session_id_pk").ToString() + ")";
                //Get Instructors
                DataTable dtInstructors = new DataTable();
                dtInstructors = SystemCatalogBLL.GetSessionInstructor(gvSession.DataKeys[e.Row.RowIndex].Values[0].ToString());
                string strInstructors = string.Empty;
                for (int i = 0; i < dtInstructors.Rows.Count; i++)
                {
                    strInstructors = strInstructors + dtInstructors.Rows[i]["c_instructor_name"].ToString();
                    strInstructors += (i < dtInstructors.Rows.Count - 1) ? " - " : string.Empty;

                }

                lblSession2.Text = DataBinder.Eval(e.Row.DataItem, "c_session_date")
                                       + AddLocationFacilityRoomDelimiters(DataBinder.Eval(e.Row.DataItem, "c_location_name").ToString(),
                                       DataBinder.Eval(e.Row.DataItem, "c_facility_name").ToString(), DataBinder.Eval(e.Row.DataItem, "c_room_name").ToString())
                                        + AddInstructorDelimiters(strInstructors);


            }

        }
        /// <summary>
        /// add session delimiters
        /// </summary>
        /// <param name="location"></param>
        /// <param name="facility"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        private string AddLocationFacilityRoomDelimiters(string location, string facility, string room)
        {
            string strLocationFacilityRoom = string.Empty;

            if (location != "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "]";
            }
            else if (location == "" && facility != "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + facility + "/" + room + "]";
            }
            else if (location != "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + room + "]";
            }
            else if (location != "" && facility != "" & room == "")
            {
                strLocationFacilityRoom = "<br>" + "[" + location + "/" + facility + "]";
            }
            else if (location == "" && facility == "" & room != "")
            {
                strLocationFacilityRoom = "<br>" + "[" + room + "]";
            }
            else
            {
                strLocationFacilityRoom = string.Empty;
            }
            return strLocationFacilityRoom;

        }
        /// <summary>
        /// AddInstructorDelimiters
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        private string AddInstructorDelimiters(string instructor)
        {
            string strInstructor = string.Empty;

            if (instructor != "")
            {
                strInstructor = "<br> (" + instructor + ")";
            }
            else
            {
                strInstructor = string.Empty;
            }
            return strInstructor;
        }
        protected void gvAddDeliveryAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvAddDeliveryAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Download"))
            {

                string attachmentFileId = gvAddDeliveryAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvAddDeliveryAttachments.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_attachmentpath + attachmentFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + attachmentFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }

            }


        }
        protected void gvAddDeliveryAttachments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        protected void btnConfirmEnrollment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["action"]) && Request.QueryString["action"].ToString() == "re")
            {
                //Re enrollment
                Enrollment(false, c_course_approval, c_delivery_approval,true);
                SessionWrapper.isLeraningHistory = false;
            }
            else
            {
                //Enrollment without approval
                Enrollment(false, c_course_approval, c_delivery_approval,false);
            }
            //send enrollment confirmation
            SendConfirmationEmail();
            //
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/lhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);

        }
        private void Enrollment(bool check_enroll, bool course_approval, bool delivery_approval, bool reEnroll)
        {
            try
            {
                //insert enrollment
                BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                enrollOLT.e_check_course_approval = course_approval;
                enrollOLT.e_check_delivery_approval = delivery_approval;
                enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_delivery_id_fk = deliveryId;
                enrollOLT.e_enroll_course_id_fk = courseid;
                enrollOLT.e_enroll_required_flag = reEnroll;// If reEnroll means e_enroll_required_flag true Otherwise false
                enrollOLT.e_enroll_approval_required_flag = false;
                enrollOLT.e_enroll_type_name = "Self-enroll";
                enrollOLT.e_enroll_approval_status_name = "Pending";
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
                //for approval
                enrollOLT.e_enroll_level_1_req_flag = false;
                enrollOLT.e_enroll_approver_1_type = true;
                enrollOLT.e_enroll_approver_1_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_approver_1_decision_flag = false;
                enrollOLT.e_enroll_approver_1_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_2_req_flag = false;
                enrollOLT.e_enroll_approver_2_type = false;
                enrollOLT.e_enroll_approver_2_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_2_decision_flag = false;
                enrollOLT.e_enroll_approver_2_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_3_req_flag = false;
                enrollOLT.e_enroll_approver_3_type = false;
                enrollOLT.e_enroll_approver_3_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_3_decision_flag = false;
                enrollOLT.e_enroll_approver_3_decision_date = DateTime.Now;
                enrollOLT.e_enroll_enroll_approval_status_id_fk = string.Empty;
                enrollOLT.e_enroll_approval_final_decision_date = DateTime.Now;
                enrollOLT.e_re_enroll = reEnroll;
                EnrollmentBLL.SingleEnroll(enrollOLT, check_enroll);
                //popup active
                //SessionWrapper.Active_Popup = "true";
                //


            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        private void SendApprovalRequest()
        {
            try
            {
                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryId);
                StringBuilder sbApprovalRequest = new StringBuilder();

                //To Manager Approval Request
                SystemNotification notificationManager = new SystemNotification();
                notificationManager = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-APPROVAL-NOTICE", SessionWrapper.CultureName);
                if (notificationManager.s_notification_on_off_flag == true)
                {
                    string approvalSubjectMananger = string.Empty;
                    approvalSubjectMananger = notificationManager.s_notification_email_subject;
                    approvalSubjectMananger = approvalSubjectMananger.Replace("@$&Course Title&$@ (@$&Course ID&$@)", Course.c_course_list);
                    approvalSubjectMananger = approvalSubjectMananger.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                    //approvalSubjectMananger = approvalSubjectMananger.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);

                    string approvalTextManager = string.Empty;
                    approvalTextManager = notificationManager.s_notification_email_text;
                    approvalTextManager = approvalTextManager.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                    approvalTextManager = approvalTextManager.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);
                    approvalTextManager = approvalTextManager.Replace("@$&Course Name&$@(@$&Course ID&$@)", Course.c_course_list);
                    approvalTextManager = approvalTextManager.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", Course.c_delivery_list);
                    approvalTextManager = approvalTextManager.Replace("@$&Session ID(s)&$@", Course.c_session_list);

                    sbApprovalRequest.Append(approvalTextManager);

                    //string toEmailid = EnrollmentBLL.GetApproverEmailAddress(SessionWrapper.u_userid);
                    //string[] toaddress = toEmailid.Split(',');
                    //List<MailAddress> mailAddresses = new List<MailAddress>();
                    //foreach (string recipient in toaddress)
                    //{
                    //    if (recipient.Trim() != string.Empty)
                    //    {
                    //        mailAddresses.Add(new MailAddress(recipient));
                    //    }
                    //}

                    //string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// for Approval request from:admin@compliancefactors.com to: approeremailid
                    ////mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                    //Utility.SendEMailMessages(mailAddresses, fromAddress, approvalSubjectMananger, sbApprovalRequest.ToString());
                    string toEmailid = EnrollmentBLL.GetApproverEmailAddress(SessionWrapper.u_userid);
                    string[] toaddress = toEmailid.Split(',');
                    List<MailAddress> mailAddresses = new List<MailAddress>();
                    foreach (string recipient in toaddress)
                    {
                        if (recipient.Trim() != string.Empty)
                        {
                            mailAddresses.Add(new MailAddress(recipient));
                        }
                    }

                    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// for Approval request from:admin@compliancefactors.com to: approeremailid
                    //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                    if (mailAddresses.Count > 0)
                    {
                        Utility.SendEMailMessages(mailAddresses, fromAddress, approvalSubjectMananger, sbApprovalRequest.ToString());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                        {
                            StringBuilder smsText = new StringBuilder();
                            string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                            string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                            string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                            string messagetext = notificationManager.s_notification_SMS_text;
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
                //send notification
                SystemNotification notification = new SystemNotification();
                notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-APPROVAL-PENDING", SessionWrapper.CultureName);
                if (notification.s_notification_on_off_flag == true)
                {
                    StringBuilder sbNotification = new StringBuilder();
                    //To Employee pending Request
                    string approvalSubjectEmployee = string.Empty;
                    approvalSubjectEmployee = notification.s_notification_email_subject;
                    approvalSubjectEmployee = approvalSubjectEmployee.Replace("@$&Course Title&$@", Course.c_course_title);

                    string approvalTextEmployee = string.Empty;
                    approvalTextEmployee = notification.s_notification_email_text;
                    approvalTextEmployee = approvalTextEmployee.Replace("@$&User First Name&$@", Course.c_created_name);
                    approvalTextEmployee = approvalTextEmployee.Replace("@$&Course Name&$@(@$&Course ID&$@)", Course.c_course_list);

                    sbNotification.Append(approvalTextEmployee);

                    //List<MailAddress> notifyMailAddress = new List<MailAddress>();
                    //if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                    //{
                    //    notifyMailAddress.Add(new MailAddress(SessionWrapper.u_email_id));
                    //    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// the system also send pedind approval from:admin@compliancefactors.com to employeeemailaddress
                    //    Utility.SendEMailMessages(notifyMailAddress, fromaddress, approvalSubjectEmployee, sbNotification.ToString());
                    //}
                    List<MailAddress> notifyMailAddress = new List<MailAddress>();
                    if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                    {
                        notifyMailAddress.Add(new MailAddress(SessionWrapper.u_email_id));
                        string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// the system also send pedind approval from:admin@compliancefactors.com to employeeemailaddress
                        Utility.SendEMailMessages(notifyMailAddress, fromaddress, approvalSubjectEmployee, sbNotification.ToString());
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
                            messagetext = messagetext.Replace("@$&Status&$@", "Approval Pending");
                            messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                            Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
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
                        Logger.WriteToErrorLog("(Approval request mail) ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(Approval request mail) ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        private void SendConfirmationEmail()
        {
            try
            {
                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryId);
                StringBuilder sbConfirmEnrollment = new StringBuilder();
                if (type == "OLT")
                {
                    if (waitList == "False" && submitRequest == false)
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

                            //List<MailAddress> mailAddresses = new List<MailAddress>();
                            //if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                            //{
                            //    mailAddresses.Add(new MailAddress(SessionWrapper.u_email_id));
                            //    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                            //    sbConfirmEnrollment.Append(sbConfirmOLT);
                            //    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
                            //}
                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                            {
                                mailAddresses.Add(new MailAddress(SessionWrapper.u_email_id));
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
                }

                //Enroll ILT/VLT
                else if ((type == "ILT" || type == "VLT") && (waitList == "False"))
                {
                    if (waitList == "False" && submitRequest == false)
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

                            confirmILT = confirmILT.Replace("@$&User First Name&$@", Course.c_created_name);
                            confirmILT = confirmILT.Replace("@$&Course Name&$@", Course.c_course_title);
                            confirmILT = confirmILT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                            confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
                            confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
                            confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
                            confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
                            confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
                            confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

                            //List<MailAddress> mailAddresses = new List<MailAddress>();
                            //if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                            //{
                            //    mailAddresses.Add(new MailAddress(SessionWrapper.u_email_id));
                            //    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                            //    sbConfirmEnrollment.Append(confirmILT);
                            //    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
                            //}
                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                            {
                                mailAddresses.Add(new MailAddress(SessionWrapper.u_email_id));
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
                    else if ((type == "ILT" || type == "VLT") && (waitList == "True") || (waitList == "False"))
                    {
                        SystemNotification notificationWaitList = new SystemNotification();
                        notificationWaitList = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-WAITLIST", SessionWrapper.CultureName);
                        if (notificationWaitList.s_notification_on_off_flag == true)
                        {
                            string confirmWaitListSubject = string.Empty;
                            confirmWaitListSubject = notificationWaitList.s_notification_email_subject;
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);

                            string confirmWaitlist = string.Empty;
                            confirmWaitlist = notificationWaitList.s_notification_email_text;

                            confirmWaitlist = confirmWaitlist.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                            confirmWaitlist = confirmWaitlist.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Course Name&$@(@$&Course ID&$@)", Course.c_course_list);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", Course.c_delivery_list);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Session ID(s)&$@", Course.c_session_list);

                            sbConfirmEnrollment.Append(confirmWaitlist);

                            //ENROLL-CONFIRM-WAITLIST
                            //sbConfirmEnrollment.Append(SessionWrapper.u_firstname + ' ' + SessionWrapper.u_lastname + " has sent a request for the following training: ");
                            //sbConfirmEnrollment.Append("<br>");
                            //sbConfirmEnrollment.Append("Course: " + Course.c_course_list);
                            //sbConfirmEnrollment.Append("<br>");
                            //sbConfirmEnrollment.Append("Delivery: " + Course.c_delivery_list);
                            //sbConfirmEnrollment.Append("<br>");
                            //sbConfirmEnrollment.Append("Sessions: " + Course.c_session_list);
                            //sbConfirmEnrollment.Append("<br>");
                            //string toEmailid = Course.c_to_address;
                            //string[] toaddress = toEmailid.Split(',');
                            //List<MailAddress> mailAddresses = new List<MailAddress>();
                            //foreach (string recipient in toaddress)
                            //{
                            //    if (recipient.Trim() != string.Empty)
                            //    {
                            //        mailAddresses.Add(new MailAddress(recipient));
                            //    }
                            //}
                            //string fromAddress = SessionWrapper.u_email_id;// for submite Request from: employeeemailId to admin@compliancefactors.com,owneremailId,coordinatoremailId 
                            ////mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                            //Utility.SendEMailMessages(mailAddresses, fromAddress, confirmWaitListSubject, sbConfirmEnrollment.ToString());
                            string toEmailid = Course.c_to_address;
                            string[] toaddress = toEmailid.Split(',');
                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            foreach (string recipient in toaddress)
                            {
                                if (recipient.Trim() != string.Empty)
                                {
                                    mailAddresses.Add(new MailAddress(recipient));
                                }
                            }
                            string fromAddress = SessionWrapper.u_email_id;// for submite Request from: employeeemailId to admin@compliancefactors.com,owneremailId,coordinatoremailId 
                            //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                            if (mailAddresses.Count > 0)
                            {
                                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmWaitListSubject, sbConfirmEnrollment.ToString());
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notificationWaitList.s_notification_SMS_text;

                                    if (messagetext.Length > 180)
                                    {
                                        messagetext = messagetext.Substring(0, 179);
                                    }
                                    messagetext = messagetext.Replace("@$&Status&$@", "Wait List");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                }


                //Close popup
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()", true);
                //SessionWrapper.u_firstname = "";
                //SessionWrapper.u_lastname = "";
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnGoToWaitList_Click(object sender, EventArgs e)
        {
            try
            {
                //insert waitlist
                BusinessComponent.DataAccessObject.Enrollment waitlist = new BusinessComponent.DataAccessObject.Enrollment();
                waitlist.e_enroll_waitlist_course_id_fk = courseid;
                waitlist.e_enroll_waitlist_course_delivery_id_fk = deliveryId;
                waitlist.e_enroll_waitlist_user_id_fk = SessionWrapper.u_userid;
                EnrollmentBLL.InsertWaitList(waitlist);
                //popup active
                //SessionWrapper.Active_Popup = "true";
                //
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/lhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            try
            {
                submitRequest = true;
                SendConfirmationEmail();
                //popup active
                //SessionWrapper.Active_Popup = "true";
                //
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/lhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(submit request) ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(submit request) ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnRequestApproval_Click(object sender, EventArgs e)
        {
            try
            {
                //insert enrollment with approval
                if (!string.IsNullOrEmpty(Request.QueryString["action"]) && Request.QueryString["action"].ToString() == "re")
                {
                    //Re-enroll course with approval
                    Enrollment(true, c_course_approval, c_delivery_approval, true);
                }
                else
                {
                    //enroll course with approval
                    Enrollment(true, c_course_approval, c_delivery_approval, false);
                }
                //send approval request to employee and first approval
                SendApprovalRequest();
                //Close popup
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()", true);
                //
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/lhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(Request Approval) ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(Request Approval) ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }

        
    }
}