using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.IO;
using System.Globalization;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saed_02 : BasePage
    {
        private  string editDelivery;
        /// <summary>
        /// set delivery attachment path
        /// </summary>
        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Catalog/Course/Delivery/Attachments/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get delivery id
                editDelivery = Request.QueryString["editdelivery"];
                hdEditdelivery.Value = editDelivery;
                hdEditcourseid.Value = Request.QueryString["editcourseid"];
                //create object for delivery dataset
                DataSet dsDeliveries = new DataSet();
                if (!IsPostBack)
                {
                    //clear session
                    ClearSession();
                    if (!string.IsNullOrEmpty(Request.QueryString["editdelivery"]))
                    {
                        //add column to temp session
                        SessionWrapper.TempDeliverySessions = TempDataTables.TempDeliverySessions();
                        //Bind delivery type
                        ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                        ddlDeliveryType.DataBind();
                        ListItem itemRemove = ddlDeliveryType.Items.FindByValue("app_ddl_all_text");
                        ddlDeliveryType.Items.Remove(itemRemove);
                        //Bind approval required
                        ddlApprovalRequired.DataSource = SystemCatalogBLL.GetApprovalForCourse(SessionWrapper.CultureName);
                        ddlApprovalRequired.DataBind();
                        //Bind status
                        ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName,"saed-02");
                        ddlStatus.DataBind();
                        //bind locale
                        ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                        ddlLocale.DataBind();
                        //Bind wrapper
                        ddlNcWrapper.DataSource = ManageCourseBLL.GetOLTWrapper(SessionWrapper.CultureName, "saed-02");
                        ddlNcWrapper.DataBind();

                        //Bind Grading Scheme
                        ddlScoringScheme.DataSource = SystemCurriculumBLL.GetGradingScheme(SessionWrapper.CultureName);
                        ddlScoringScheme.DataBind();


                        //Dataset get delivery,resource,materials and attachments
                        dsDeliveries = SystemCatalogBLL.GetDeliveries(editDelivery);
                        PopulateDelivery(editDelivery, dsDeliveries.Tables[0]);
                        //Bind delivery attachments
                        gvAddDeliveryAttachments.DataSource = dsDeliveries.Tables[3];
                        gvAddDeliveryAttachments.DataBind();
                    }
                    //For restore
                    RevertBack();
                }
                //set delivery id in session
                SessionWrapper.c_delivery_system_id_pk = Request.QueryString["editdelivery"];
                //Dataset get resource,materials and attachments
                if (hdCheckCopy.Value != "1")
                {
                    dsDeliveries = SystemCatalogBLL.GetDeliveries(editDelivery);
                    //Get owner name
                    lblDeliveryOwner.Text = SessionWrapper.c_delivery_owner_name;
                    //Get coordinator name
                    lblDeliveryCoordinator.Text = SessionWrapper.c_delivery_coordinator_name;
                    //Get resources
                    gvResources.DataSource = dsDeliveries.Tables[1];
                    gvResources.DataBind();
                    //Get Materials
                    gvMaterials.DataSource = dsDeliveries.Tables[2];
                    gvMaterials.DataBind();
                    //Get sessions
                    gvSession.DataSource = dsDeliveries.Tables[4];
                    gvSession.DataBind();
                }
                //Get course locale
                DataTable dtLocale = new DataTable();
                SessionWrapper.Locale.Clear();
                dtLocale = ManageCourseBLL.GetDeliveryLocale(editDelivery);
                gvLocale.DataSource = dtLocale;
                gvLocale.DataBind();
                foreach (DataRow dtrow in dtLocale.Rows)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_fk"], "RemoveLocale('" + dtrow["s_locale_id_fk"] + "');", true);
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
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message);
                    }
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1)
        {
            try
            {
                if (SessionWrapper.Locale.Rows.Count > 0)
                {
                    var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                ManageCourseBLL.DeleteDeliveryLocale(string.Empty, string.Empty, args.Trim());

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01.aspx(Delivery locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Delivery locale)", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// DeleteResource
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteResource(string args)
        {

            try
            {
                SystemCatalogBLL.DeleteDeliveryResource(args.Trim());
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Delete material
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteMaterial(string args)
        {

            try
            {
                SystemCatalogBLL.DeleteDeliveryMaterial(args.Trim());
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// DeleteSession
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteSession(string args)
        {
            try
            {
                SystemCatalogBLL.DeleteDeliverySession(args.Trim());

                //delete session
                if (SessionWrapper.TempDeliverySessions.Rows.Count > 0)
                {
                    var rows = SessionWrapper.TempDeliverySessions.Select("c_session_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.TempDeliverySessions.AcceptChanges();
                }
                //delete instructors
                if (SessionWrapper.DeliveryInstructor.Rows.Count > 0)
                {
                    var insRows = SessionWrapper.DeliveryInstructor.Select("c_session_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in insRows)
                        row.Delete();
                    SessionWrapper.DeliveryInstructor.AcceptChanges();
                }
                //temp delete instructors
                if (SessionWrapper.TempDeliveryInstructor.Rows.Count > 0)
                {
                    var insTempRows = SessionWrapper.TempDeliveryInstructor.Select("c_session_id_fk= '" + args.Trim() + "'");
                    foreach (var row in insTempRows)
                        row.Delete();
                    SessionWrapper.TempDeliveryInstructor.AcceptChanges();
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
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Clear session
        /// </summary>
        private void ClearSession()
        {
            SessionWrapper.c_delivery_system_id_pk = string.Empty;
            SessionWrapper.c_session_system_id_pk = string.Empty;
            SessionWrapper.c_room_system_id_pk = string.Empty;
            SessionWrapper.c_facility_system_id_pk = string.Empty;
            SessionWrapper.c_location_system_id_pk = string.Empty;
            SessionWrapper.c_location_name = string.Empty;
            SessionWrapper.c_facility_name = string.Empty;
            SessionWrapper.c_room_name = string.Empty;
            SessionWrapper.TempDeliverySessions = null;
            SessionWrapper.TempDeliveryInstructor = null;
            SessionWrapper.Reset_Edit_DeliveryInstructor = null;
            SessionWrapper.Reset_Deliveries = null;
            SessionWrapper.Reset_DeliverySessions = null;
            SessionWrapper.Reset_DeliveryAttachments = null;
            SessionWrapper.Reset_DeliveryResource = null;
            SessionWrapper.Reset_DeliveryMaterial = null;
            SessionWrapper.Reset_DeliveryInstructor = null;

        }
        /// <summary>
        /// Get particular delivery data from database
        /// </summary>
        /// <param name="deliveryId"></param>
        private void PopulateDelivery(string deliveryId, DataTable dtDelivery)
        {
            SystemCatalog delivery = new SystemCatalog();
            delivery = SystemCatalogBLL.GetDelivery(editDelivery, dtDelivery);
            txtDeliveyID.Text = delivery.c_delivery_id_pk;
            ddlDeliveryType.SelectedValue = delivery.c_delivery_type_id_fk;
            txtDeliveryTitle.Text = delivery.c_delivery_title;
            txtDescription.Value = delivery.c_delivery_desc;
            txtAbstract.Value = delivery.c_delivery_abstract;
            chkApproval.Checked = delivery.c_delivery_approval_req;
            ddlApprovalRequired.SelectedValue = delivery.c_delivery_approval_id_fk;
            txtCreditHours.Text = Convert.ToString(delivery.c_delivery_credit_hours);
            txtCreditUnits.Text = Convert.ToString(delivery.c_delivery_credit_units);
            SessionWrapper.c_delivery_owner_id_fk = delivery.c_delivery_owner_id_fk;
            SessionWrapper.c_delivery_coordinator_id_fk = delivery.c_delivery_coordinator_id_fk;
            SessionWrapper.c_delivery_owner_name = delivery.c_delivery_owner_name;
            SessionWrapper.c_delivery_coordinator_name = delivery.c_delivery_coordinator_name;
            //chkVisible.Checked = delivery.c_delivery_active_flag;
            ddlStatus.SelectedValue = delivery.c_delivery_active_type_id_fk;
            chkVisible.Checked = delivery.c_delivery_visible_flag;

            //txtAvailableFrom.Text = delivery.c_delivery_available_from_date;
            //txtAvailableTo.Text = delivery.c_delivery_available_to_date;
            //txtEffectiveDate.Text = delivery.c_delivery_effective_date;
            //txtCutOffDate.Text = delivery.c_delivery_cut_off_date;
            //txtCutoffTime.Text = delivery.c_delivery_cut_off_time;


            txtMinEnroll.Text = Convert.ToString(delivery.c_delivery_min_enroll);
            txtMaxEnroll.Text = Convert.ToString(delivery.c_delivery_max_enroll);
            txtEnrollThreshhold.Text = Convert.ToString(delivery.c_delivery_enroll_threshold);
            chkWaitingList.Checked = delivery.c_delivery_waitlist_flag;
            txtMaxwaitList.Text = Convert.ToString(delivery.c_delivery_max_waitlist);
            txtScormUrl.Text = delivery.c_olt_launch_url;
            txtScromLaunchParameters.Text = delivery.c_olt_launch_param;
            txtVlsUrl.Text = delivery.c_vlt_launch_url;

            if (!string.IsNullOrEmpty(delivery.c_delivery_available_from_date.ToString()))
            {
                txtAvailableFrom.Text = Convert.ToDateTime(delivery.c_delivery_available_from_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(delivery.c_delivery_available_to_date.ToString()))
            {
                txtAvailableTo.Text = Convert.ToDateTime(delivery.c_delivery_available_to_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(delivery.c_delivery_effective_date.ToString()))
            {
                txtEffectiveDate.Text = Convert.ToDateTime(delivery.c_delivery_effective_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(delivery.c_delivery_cut_off_date.ToString()))
            {
                txtCutOffDate.Text = Convert.ToDateTime(delivery.c_delivery_cut_off_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(delivery.c_delivery_cut_off_time_string))
            {
                txtCutoffTime.Text = Convert.ToDateTime(delivery.c_delivery_cut_off_time_string).ToShortTimeString();
            }

            txtCustom01.Text = delivery.c_delivery_custom_01;
            txtCustom02.Text = delivery.c_delivery_custom_02;
            txtCustom03.Text = delivery.c_delivery_custom_03;
            txtCustom04.Text = delivery.c_delivery_custom_04;
            txtCustom05.Text = delivery.c_delivery_custom_05;
            txtCustom06.Text = delivery.c_delivery_custom_06;
            txtCustom07.Text = delivery.c_delivery_custom_07;
            txtCustom08.Text = delivery.c_delivery_custom_08;
            txtCustom09.Text = delivery.c_delivery_custom_09;
            txtCustom10.Text = delivery.c_delivery_custom_10;
            txtCustom11.Text = delivery.c_delivery_custom_11;
            txtCustom12.Text = delivery.c_delivery_custom_12;
            txtCustom13.Text = delivery.c_delivery_custom_13;
            lblDeliveryOwner.Text = delivery.c_delivery_owner_name;
            lblDeliveryCoordinator.Text = delivery.c_delivery_coordinator_name;
            txtNCUrl.Text = delivery.c_nc_olt_launch_url;
            txtNcLaunchParameter.Text = delivery.c_nc_olt_launch_param;
            chkNcWaitList.Checked = delivery.c_nc_olt_waitlist_flag;
            if (!string.IsNullOrEmpty(delivery.c_nc_olt_wrapper_id_fk))
            {
                ddlNcWrapper.SelectedValue = delivery.c_nc_olt_wrapper_id_fk;
            }
            ddlScoringScheme.SelectedValue = delivery.c_survey_scoring_scheme_id_fk;
            chkCompleteOnLaunch.Checked = delivery.c_delivery_complete_on_launch;
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
        /// edit and remove delivery attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAddDeliveryAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvAddDeliveryAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Edit"))
            {

                hdAttachments.Value = attachmentId;
                mpeAttachment.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
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
            else if (e.CommandName.Equals("Remove"))
            {
                try
                {
                    SystemCatalogBLL.DeleteDeliveryAttachment(attachmentId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saed-02", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saed-02", ex.Message);
                        }
                    }
                }
                this.gvAddDeliveryAttachments.DataSource = SystemCatalogBLL.GetDeliveryAttachments(editDelivery);
                this.gvAddDeliveryAttachments.DataBind();



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
        /// <summary>
        /// Upload delivery attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUploadattachments_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile file = default(HttpPostedFile);
                foreach (string files in Request.Files)
                {
                    file = Request.Files[files];
                    string c_file_name = null;
                    string c_file_extension = null;
                    string c_file_guid = Guid.NewGuid().ToString();
                    if (file != null && file.ContentLength > 0)
                    {
                        c_file_name = Path.GetFileName(file.FileName);
                        c_file_extension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath(_attachmentpath + c_file_guid + c_file_extension));

                        SystemCatalog deliveryAttachment = new SystemCatalog();
                        deliveryAttachment.c_delivery_id_fk = editDelivery;
                        deliveryAttachment.c_delivery_attachment_file_guid = c_file_guid + c_file_extension;
                        deliveryAttachment.c_delivery_attachment_file_name = c_file_name;

                        if (!string.IsNullOrEmpty(hdAttachments.Value))
                        {
                            deliveryAttachment.c_delivery_attachment_id_pk = hdAttachments.Value;
                            SystemCatalogBLL.UpdateDeliveryAttachment(deliveryAttachment);
                            hdAttachments.Value = "";
                        }
                        else
                        {
                            SystemCatalogBLL.InsertDeliveryAttachment(deliveryAttachment);

                        }
                    }
                }
                this.gvAddDeliveryAttachments.DataSource = SystemCatalogBLL.GetDeliveryAttachments(editDelivery);
                this.gvAddDeliveryAttachments.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-02", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02", ex.Message);
                    }
                }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //update delivery
            UpdateDelivery();
        }
        /// <summary>
        /// UpdateDelivery
        /// </summary>
        private void UpdateDelivery()
        {
            SystemCatalog updateDelivery = new SystemCatalog();
            int tempCreditHours, tempMinEnroll, tempCreditUnits, tempMaxEnroll, tempEnrollThreshhold, tempMaxWaitList;
            int? CreditHours, MinEnroll, CreditUnits, MaxEnroll, EnrollThreshhold, MaxWaitList;
            if (int.TryParse(txtCreditHours.Text, out tempCreditHours))
            {
                CreditHours = tempCreditHours;
            }
            else
            {
                CreditHours = null;
            }

            if (int.TryParse(txtMinEnroll.Text, out tempMinEnroll))
            {
                MinEnroll = tempMinEnroll;
            }
            else
            {
                MinEnroll = null;
            }

            if (int.TryParse(txtCreditUnits.Text, out tempCreditUnits))
            {
                CreditUnits = tempCreditUnits;
            }
            else
            {
                CreditUnits = null;
            }
            if (int.TryParse(txtMaxEnroll.Text, out tempMaxEnroll))
            {
                MaxEnroll = tempMaxEnroll;
            }
            else
            {
                MaxEnroll = null;
            }
            if (int.TryParse(txtEnrollThreshhold.Text, out tempEnrollThreshhold))
            {
                EnrollThreshhold = tempEnrollThreshhold;
            }
            else
            {
                EnrollThreshhold = null;
            }
            if (int.TryParse(txtMaxwaitList.Text, out tempMaxWaitList))
            {
                MaxWaitList = tempMaxWaitList;
            }
            else
            {
                MaxWaitList = null;
            }
            updateDelivery.c_delivery_system_id_pk = editDelivery;
            updateDelivery.c_delivery_id_pk = txtDeliveyID.Text;
            updateDelivery.c_delivery_type_id_fk = ddlDeliveryType.SelectedValue;
            updateDelivery.c_delivery_title = txtDeliveryTitle.Text;
            updateDelivery.c_delivery_desc = txtDescription.Value;
            updateDelivery.c_delivery_abstract = txtAbstract.Value;
            updateDelivery.c_delivery_approval_req = chkApproval.Checked;
            updateDelivery.c_delivery_approval_id_fk = ddlApprovalRequired.SelectedValue;
            updateDelivery.c_delivery_credit_hours = CreditHours;
            updateDelivery.c_delivery_credit_units = CreditUnits;
            updateDelivery.c_delivery_owner_id_fk = SessionWrapper.c_delivery_owner_id_fk;
            updateDelivery.c_delivery_coordinator_id_fk = SessionWrapper.c_delivery_coordinator_id_fk;
            updateDelivery.c_delivery_active_flag = false;
            updateDelivery.c_delivery_active_type_id_fk = ddlStatus.SelectedValue;
            updateDelivery.c_delivery_visible_flag = chkVisible.Checked;
            updateDelivery.c_delivery_complete_on_launch = chkCompleteOnLaunch.Checked;
            DateTime? availableFrom = null;
            DateTime tempavailableFrom;
            CultureInfo culturenew = new CultureInfo("en-US");
            if (DateTime.TryParseExact(txtAvailableFrom.Text, "MM/dd/yyyy", culturenew, DateTimeStyles.None, out tempavailableFrom))
            {
                availableFrom = tempavailableFrom;
            }


            DateTime? availableTo = null;
            DateTime tempavailableTo;
            if (DateTime.TryParseExact(txtAvailableTo.Text, "MM/dd/yyyy", culturenew, DateTimeStyles.None, out tempavailableTo))
            {
                availableTo = tempavailableTo;
            }

            DateTime? effectiveDate = null;
            DateTime tempeffectiveDate;
            if (DateTime.TryParseExact(txtEffectiveDate.Text, "MM/dd/yyyy", culturenew, DateTimeStyles.None, out tempeffectiveDate))
            {
                effectiveDate = tempeffectiveDate;
            }

            DateTime? cuttoffDate = null;
            DateTime tempcuttoffDate;
            if (DateTime.TryParseExact(txtCutOffDate.Text, "MM/dd/yyyy", culturenew, DateTimeStyles.None, out tempcuttoffDate))
            {
                cuttoffDate = tempcuttoffDate;
            }            

            DateTime? cutofftime = null;
            DateTime temptimeofday;
            if (DateTime.TryParseExact(txtCutoffTime.Text, "h:mm tt", culturenew, DateTimeStyles.None, out temptimeofday))
            {
                cutofftime = temptimeofday;
            }

            updateDelivery.c_delivery_available_from_date = availableFrom;
            updateDelivery.c_delivery_available_to_date = availableTo;
            updateDelivery.c_delivery_effective_date = effectiveDate;
            updateDelivery.c_delivery_cut_off_date = cuttoffDate;
            updateDelivery.c_delivery_cut_off_time = cutofftime; 

            updateDelivery.c_delivery_min_enroll = MinEnroll;
            updateDelivery.c_delivery_max_enroll = MaxEnroll;
            updateDelivery.c_delivery_enroll_threshold = EnrollThreshhold;
            updateDelivery.c_delivery_waitlist_flag = chkWaitingList.Checked;
            updateDelivery.c_delivery_max_waitlist = MaxWaitList;
            updateDelivery.c_vlt_launch_url = txtVlsUrl.Text;
            updateDelivery.c_olt_launch_url = txtScormUrl.Text;
            updateDelivery.c_olt_launch_param = txtScromLaunchParameters.Text;
            updateDelivery.c_delivery_custom_01 = txtCustom01.Text;
            updateDelivery.c_delivery_custom_02 = txtCustom02.Text;
            updateDelivery.c_delivery_custom_03 = txtCustom03.Text;
            updateDelivery.c_delivery_custom_04 = txtCustom04.Text;
            updateDelivery.c_delivery_custom_05 = txtCustom05.Text;
            updateDelivery.c_delivery_custom_06 = txtCustom06.Text;
            updateDelivery.c_delivery_custom_07 = txtCustom07.Text;
            updateDelivery.c_delivery_custom_08 = txtCustom08.Text;
            updateDelivery.c_delivery_custom_09 = txtCustom09.Text;
            updateDelivery.c_delivery_custom_10 = txtCustom10.Text;
            updateDelivery.c_delivery_custom_11 = txtCustom11.Text;
            updateDelivery.c_delivery_custom_12 = txtCustom12.Text;
            updateDelivery.c_delivery_custom_13 = txtCustom13.Text;
            updateDelivery.c_nc_olt_launch_url = txtNCUrl.Text.IndexOf("://") == -1 ? "http://" + txtNCUrl.Text : txtNCUrl.Text;
            updateDelivery.c_nc_olt_launch_param = txtNcLaunchParameter.Text;
            updateDelivery.c_nc_olt_waitlist_flag = chkNcWaitList.Checked;
            updateDelivery.c_survey_scoring_scheme_id_fk = ddlScoringScheme.SelectedValue;
            if (chkNcWaitList.Checked == true)
            {
                updateDelivery.c_nc_olt_wrapper_id_fk = ddlNcWrapper.SelectedValue;
            }
            else
            {
                updateDelivery.c_nc_olt_wrapper_id_fk = string.Empty;
            }
            try
            {
                SystemCatalogBLL.UpdateCourseDelivery(updateDelivery);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02.aspx", ex.Message);
                    }
                }
            }

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            
            RestoreDelivery();
            Response.Redirect(Request.RawUrl);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RestoreDelivery();
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// RevertBack delivery on edit (ie. creating new course)
        /// </summary>
        private void RevertBack()
        {
            //Dataset get resource,materials and attachments
            DataSet dsDeliveries = SystemCatalogBLL.GetDeliveries(editDelivery);
            //Deliveries
            SessionWrapper.Reset_Deliveries = dsDeliveries.Tables[0];
            //Delivery attachments
            SessionWrapper.Reset_DeliveryAttachments = dsDeliveries.Tables[3];
            //Delivery owner
            string str_delivery_onwer;
            str_delivery_onwer = lblDeliveryOwner.Text;
            SessionWrapper.Reset_c_delivery_owner_name = str_delivery_onwer;
            //Delivery coordinator
            string str_delivery_coordinator;
            str_delivery_coordinator = lblDeliveryCoordinator.Text;
            SessionWrapper.Reset_c_delivery_coordinator_name = str_delivery_coordinator;
            //Delivery resources
            SessionWrapper.Reset_DeliveryResource = dsDeliveries.Tables[1]; 
            //Delivery material
            SessionWrapper.Reset_DeliveryMaterial = dsDeliveries.Tables[2];
            //Delivery session
            SessionWrapper.Reset_DeliverySessions = dsDeliveries.Tables[4];
            //Delivery instructor
            SessionWrapper.Reset_DeliveryInstructor = dsDeliveries.Tables[5];
            //delivery owner id
            string str_c_delivery_owner_id_fk;
            str_c_delivery_owner_id_fk = SessionWrapper.c_delivery_owner_id_fk;
            SessionWrapper.Reset_c_delivery_owner_id_fk = str_c_delivery_owner_id_fk;
            //delivery coordinator id
            string str_c_delivery_coordinator_id_fk;
            str_c_delivery_coordinator_id_fk = SessionWrapper.c_delivery_coordinator_id_fk;
            SessionWrapper.Reset_c_delivery_coordinator_id_fk = str_c_delivery_coordinator_id_fk;


        }
        /// <summary>
        /// Restore delivery on edit delivery (i.e while creating new course)
        /// </summary>
        private void RestoreDelivery()
        {

            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog createCourseDelivery = new SystemCatalog();
            createCourseDelivery.c_course_id_fk = Request.QueryString["editcourseid"];
            //delivery(ies)
            createCourseDelivery.c_deliveries = ConvertDataTableToXml(SessionWrapper.Reset_Deliveries);
            //delivery attachment
            createCourseDelivery.c_delivery_attachments = ConvertDataTableToXml(SessionWrapper.Reset_DeliveryAttachments);
            //delivery Resource
            createCourseDelivery.c_delivery_resources = ConvertDataTableToXml(SessionWrapper.Reset_DeliveryResource);
            //delivery Material
            createCourseDelivery.c_delivery_material = ConvertDataTableToXml(SessionWrapper.Reset_DeliveryMaterial);
            //session
            createCourseDelivery.c_sessions = ConvertDataTableToXml(SessionWrapper.Reset_DeliverySessions);
            //session instructor
            createCourseDelivery.c_session_instructor = ConvertDataTableToXml(SessionWrapper.Reset_DeliveryInstructor);
            //delivery locale
            createCourseDelivery.s_delivery_locale = ConvertDataTableToXml(SessionWrapper.Reset_Delivery_Locales);
            createCourseDelivery.c_delivery_system_id_pk = editDelivery;

            try
            {
                SystemCatalogBLL.InsertDeliveries(createCourseDelivery, false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-02", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-02", ex.Message);
                    }
                }

            }

            //SessionWrapper.Deliveries = SessionWrapper.Reset_Deliveries;
            //SessionWrapper.DeliveryAttachments = SessionWrapper.Reset_DeliveryAttachments;
            //SessionWrapper.c_delivery_owner_name = SessionWrapper.Reset_c_delivery_owner_name;
            //SessionWrapper.c_delivery_coordinator_name = SessionWrapper.Reset_c_delivery_coordinator_name;
            //SessionWrapper.DeliveryResource = SessionWrapper.Reset_DeliveryResource;
            //SessionWrapper.DeliveryMaterial = SessionWrapper.Reset_DeliveryMaterial;
            //SessionWrapper.DeliverySessions = SessionWrapper.Reset_DeliverySessions;
            //SessionWrapper.c_session_facility_id_fk = SessionWrapper.Reset_c_session_facility_id_fk;
            //SessionWrapper.c_session_location_id_fk = SessionWrapper.Reset_c_session_location_id_fk;
            //SessionWrapper.c_session_room_id_fk = SessionWrapper.Reset_c_session_room_id_fk;
            //SessionWrapper.c_delivery_owner_id_fk = SessionWrapper.Reset_c_delivery_owner_id_fk;
            //SessionWrapper.c_delivery_coordinator_id_fk = SessionWrapper.Reset_c_delivery_coordinator_id_fk;
            //lblDeliveryOwner.Text = SessionWrapper.Reset_c_delivery_owner_name;
            //lblDeliveryCoordinator.Text = SessionWrapper.Reset_c_delivery_coordinator_name;


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

        protected void gvSession_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Copy"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                int error = SystemCatalogBLL.CopySingleSession(gvSession.DataKeys[rowIndex].Values[0].ToString(), gvSession.DataKeys[rowIndex].Values[1].ToString());
                if (error == -2)
                {
                    //
                }
                DataSet dsDeliveries = new DataSet();
                dsDeliveries = SystemCatalogBLL.GetDeliveries(editDelivery);
                gvSession.DataSource = dsDeliveries.Tables[4];
                gvSession.DataBind();
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                StatusLabel.Text = Scorm.UploadHandler(FileUploadControl);

                if (SessionWrapper.scorm_url != "")
                {
                    txtDeliveryTitle.Text = SessionWrapper.c_course_title;
                    txtScormUrl.Text = SessionWrapper.scorm_url;
                }
            }
        }
    }
}