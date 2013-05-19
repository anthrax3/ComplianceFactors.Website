using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;


namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saed_01 : BasePage
    {
        private string editDelivery;
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
                //Get edit delivery id
                editDelivery = Request.QueryString["editdelivery"];
                SessionWrapper.Edit_delivery_id_fk = editDelivery;
                if (!IsPostBack)
                {
                    //clear session
                    ClearSession();
                    if (!string.IsNullOrEmpty(Request.QueryString["editdelivery"]))
                    {
                        //Bind delivery type
                        ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                        ddlDeliveryType.DataBind();
                        ListItem itemRemove = ddlDeliveryType.Items.FindByValue("app_ddl_all_text");
                        ddlDeliveryType.Items.Remove(itemRemove);
                        //Bind approval required
                        ddlApprovalRequired.DataSource = SystemCatalogBLL.GetApprovalForCourse(SessionWrapper.CultureName);
                        ddlApprovalRequired.DataBind();
                        //Bind status
                        ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName,"saed-01");
                        ddlStatus.DataBind();
                        //Bind wrapper
                        ddlNcWrapper.DataSource = ManageCourseBLL.GetOLTWrapper(SessionWrapper.CultureName,"saed-01");
                        ddlNcWrapper.DataBind();
                        //Get particular delivery from session
                        DataView dvDelivery = new DataView(SessionWrapper.Deliveries);
                        dvDelivery.RowFilter = "c_delivery_system_id_pk= '" + editDelivery + "'";
                        //Get Temp delivery
                        TempGetCourseDelivery(dvDelivery.ToTable());
                        //Get particular delivery attachments
                        DataView dvAttachments = new DataView(SessionWrapper.DeliveryAttachments);
                        dvAttachments.RowFilter = "c_delivery_id_fk= '" + editDelivery + "'";

                        //Bind Grading Scheme
                        ddlScoringScheme.DataSource = SystemCurriculumBLL.GetGradingScheme(SessionWrapper.CultureName);
                        ddlScoringScheme.DataBind();

                        //Bind delivery attachments
                        gvAddDeliveryAttachments.DataSource = dvAttachments.ToTable();
                        gvAddDeliveryAttachments.DataBind();


                    }
                    //For reset
                    RevertBack();

                }
                //Get owner name
                lblDeliveryOwner.Text = SessionWrapper.c_delivery_owner_name;
                //Get coordinator name
                lblDeliveryCoordinator.Text = SessionWrapper.c_delivery_coordinator_name;
                //set delivery id
                SessionWrapper.c_delivery_system_id_pk = editDelivery;
                //Get particular delivery related resources
                DataView dvResources = new DataView(SessionWrapper.DeliveryResource);
                dvResources.RowFilter = "c_delivery_id_fk= '" + editDelivery + "'";
                //Bind resources
                gvResources.DataSource = dvResources.ToTable();
                gvResources.DataBind();
                //Get particular delivery related materials
                DataView dvMaterials = new DataView(SessionWrapper.DeliveryMaterial);
                dvMaterials.RowFilter = "c_delivery_id_fk= '" + editDelivery + "'";
                //Bind material
                gvMaterials.DataSource = dvMaterials.ToTable();
                gvMaterials.DataBind();
                if (hdCheckCopy.Value != "1" || string.IsNullOrEmpty(hdCheckCopy.Value))
                {
                    //Get particular delivery related session
                    DataView dtSessions = new DataView(SessionWrapper.DeliverySessions);
                    dtSessions.RowFilter = "c_delivery_id_fk= '" + editDelivery + "'";
                    //Bind session
                    gvSession.DataSource = dtSessions.ToTable();
                    gvSession.DataBind();
                }
                //Delete if confirm instructor is false
                var rows = SessionWrapper.DeliveryInstructor.Select("c_instructor_confirm= '" + false + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliveryInstructor.AcceptChanges();


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Clear delivery related session
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

            //Deliveries
            SessionWrapper.Reset_Deliveries = null;
            //Delivery attachments
            SessionWrapper.Reset_DeliveryAttachments = null;
            //Delivery owner
            SessionWrapper.Reset_c_delivery_owner_name = string.Empty;
            //Delivery coordinator
            SessionWrapper.Reset_c_delivery_coordinator_name = string.Empty;
            //Delivery resources
            SessionWrapper.Reset_DeliveryResource = null;
            //Delivery material
            SessionWrapper.Reset_DeliveryMaterial = null;
            //Delivery session
            SessionWrapper.Reset_DeliverySessions = null;
            //Delivery instructor
            SessionWrapper.Reset_DeliveryInstructor = null;
            //delivery owner id
            SessionWrapper.Reset_c_delivery_owner_id_fk = string.Empty;
            //delivery coordinator id
            SessionWrapper.Reset_c_delivery_coordinator_id_fk = string.Empty;
            //edit delivery instructor
            SessionWrapper.Reset_Edit_DeliveryInstructor = null;
            SessionWrapper.Edit_delivery_id_fk = string.Empty;
        }
        /// <summary>
        /// TempGetCourseDelivery this would be used on create mode
        /// </summary>
        private void TempGetCourseDelivery(DataTable dtDelivery)
        {
            SystemCatalog delivery = new SystemCatalog();
            delivery = SystemCatalogBLL.TempGetCourseDelivery(editDelivery, dtDelivery);
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
            ddlStatus.SelectedValue = delivery.c_delivery_active_type_id_fk;
            chkVisible.Checked = delivery.c_delivery_visible_flag;
            txtMinEnroll.Text = Convert.ToString(delivery.c_delivery_min_enroll);
            txtMaxEnroll.Text = Convert.ToString(delivery.c_delivery_max_enroll);
            txtEnrollThreshhold.Text = Convert.ToString(delivery.c_delivery_enroll_threshold);
            chkWaitingList.Checked = delivery.c_delivery_waitlist_flag;
            txtMaxwaitList.Text = Convert.ToString(delivery.c_delivery_max_waitlist);
            txtScormUrl.Text = delivery.c_olt_launch_url;
            txtScromLaunchParameters.Text = delivery.c_olt_launch_param;
            ddlScoringScheme.SelectedValue = delivery.c_survey_scoring_scheme_id_fk;
            txtVlsUrl.Text = delivery.c_vlt_launch_url;
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
            ddlScoringScheme.SelectedValue = delivery.c_survey_scoring_scheme_id_fk;
            
            chkNcWaitList.Checked = delivery.c_nc_olt_waitlist_flag;
            if (!string.IsNullOrEmpty(delivery.c_nc_olt_wrapper_id_fk))
            {
                ddlNcWrapper.SelectedValue = delivery.c_nc_olt_wrapper_id_fk;
            }
            SessionWrapper.c_delivery_owner_name = delivery.c_delivery_owner_name;
            SessionWrapper.c_delivery_coordinator_name = delivery.c_delivery_coordinator_name;
        }
        /// <summary>
        /// Delete resource
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteResource(string args)
        {

            try
            {


                var rows = SessionWrapper.DeliveryResource.Select("c_resource_system_id_pk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliveryResource.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message);
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


                var rows = SessionWrapper.DeliveryMaterial.Select("c_material_system_id_pk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliveryMaterial.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message);
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

                //delete session

                var rows = SessionWrapper.DeliverySessions.Select("c_session_system_id_pk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliverySessions.AcceptChanges();

                if (SessionWrapper.TempDeliverySessions.Rows.Count > 0)
                {
                    var trows = SessionWrapper.TempDeliverySessions.Select("c_session_system_id_pk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                    foreach (var row in trows)
                        row.Delete();
                    SessionWrapper.TempDeliverySessions.AcceptChanges();
                }

                //delete instructors
                if (SessionWrapper.DeliveryInstructor.Rows.Count > 0)
                {
                    var insRows = SessionWrapper.DeliveryInstructor.Select("c_session_id_fk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                    foreach (var row in insRows)
                        row.Delete();
                    SessionWrapper.DeliveryInstructor.AcceptChanges();
                }
                //temp delete instructors
                if (SessionWrapper.TempDeliveryInstructor.Rows.Count > 0)
                {
                    var insTempRows = SessionWrapper.TempDeliveryInstructor.Select("c_session_id_fk= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
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
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Delete attachment
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteAttachment(string args)
        {

            try
            {

                //delete session
                var rows = SessionWrapper.DeliveryAttachments.Select("c_delivery_attachment_file_guid= '" + args.Trim() + "' and c_delivery_id_fk= '" + SessionWrapper.Edit_delivery_id_fk + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliveryAttachments.AcceptChanges();

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saed-01.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// EditDataToTempDeliveryattachments
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="c_delivery_attachment_file_guid"></param>
        /// <param name="c_delivery_attachment_file_name"></param>
        /// <param name="dtTempDeliveryattachments"></param>
        private void EditDataToTempDeliveryattachments(int rowIndex, string c_delivery_attachment_file_guid, string c_delivery_attachment_file_name, DataTable dtTempDeliveryattachments)
        {
            dtTempDeliveryattachments.Rows[rowIndex]["c_delivery_attachment_file_guid"] = c_delivery_attachment_file_guid;
            dtTempDeliveryattachments.Rows[rowIndex]["c_delivery_attachment_file_name"] = c_delivery_attachment_file_name;
            dtTempDeliveryattachments.AcceptChanges();
        }
        /// <summary>
        /// DeleteDataToTempDeliveryattachments
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="dtTempDeliveryattachments"></param>
        private void DeleteDataToTempDeliveryattachments(string id, DataTable dtTempDeliveryattachments)
        {
            //delete session
            var rows = SessionWrapper.DeliveryAttachments.Select("c_delivery_attachment_file_guid= '" + id + "'");
            foreach (var row in rows)
                row.Delete();
            SessionWrapper.DeliveryAttachments.AcceptChanges();
            DataView dvAttachments = new DataView(SessionWrapper.DeliveryAttachments);
            dvAttachments.RowFilter = "c_delivery_id_fk= '" + editDelivery + "'";

            this.gvAddDeliveryAttachments.DataSource = dvAttachments.ToTable();
            this.gvAddDeliveryAttachments.DataBind();
        }
        /// <summary>
        /// edit and remove delivery attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAddDeliveryAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvAddDeliveryAttachments.DataKeys[rowIndex][0].ToString();
                hdAttachments.Value = e.CommandArgument.ToString();
                mpeAttachment.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
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

                DeleteDataToTempDeliveryattachments(gvAddDeliveryAttachments.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Values["c_delivery_attachment_file_guid"].ToString(), SessionWrapper.DeliveryAttachments);
            }

        }
        protected void gvAddDeliveryAttachments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        /// <summary>
        /// ReturnExtension
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
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
                    if (!string.IsNullOrEmpty(hdAttachments.Value))
                    {
                        EditDataToTempDeliveryattachments(Convert.ToInt32(hdAttachments.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.DeliveryAttachments);
                        hdAttachments.Value = "";
                    }
                    else
                    {
                        AddDataToTempDeliveryattachments(SessionWrapper.c_delivery_system_id_pk, c_file_guid + c_file_extension, c_file_name, SessionWrapper.DeliveryAttachments);
                    }
                }
            }
            DataView dvAttachments = new DataView(SessionWrapper.DeliveryAttachments);
            dvAttachments.RowFilter = "c_delivery_id_fk= '" + SessionWrapper.c_delivery_system_id_pk + "'";
            DataTable dtAttachments = new DataTable();
            dtAttachments = dvAttachments.ToTable();
            this.gvAddDeliveryAttachments.DataSource = (dtAttachments).DefaultView;
            this.gvAddDeliveryAttachments.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateDelivery();
        }
        /// <summary>
        /// Update delivery
        /// </summary>
        private void UpdateDelivery()
        {
            var rows = SessionWrapper.Deliveries.Select("c_delivery_system_id_pk= '" + editDelivery + "'");
            var indexOfRow = SessionWrapper.Deliveries.Rows.IndexOf(rows[0]);
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

            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_system_id_pk"] = SessionWrapper.c_delivery_system_id_pk;
            //SessionWrapper.Deliveries["c_course_id_fk"] = c_course_id_fk;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_id_pk"] = txtDeliveyID.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_type_id_fk"] = ddlDeliveryType.SelectedValue;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_title"] = txtDeliveryTitle.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_desc"] = txtDescription.Value;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_abstract"] = txtAbstract.Value;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_approval_req"] = chkApproval.Checked;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_approval_id_fk"] = ddlApprovalRequired.SelectedValue;
            if (CreditHours != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_credit_hours"] = CreditHours;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_credit_hours"] = DBNull.Value;
            }
            if (CreditUnits != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_credit_units"] = CreditUnits;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_credit_units"] = DBNull.Value;

            }
            if (!string.IsNullOrEmpty(SessionWrapper.c_delivery_owner_id_fk))
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_owner_id_fk"] = SessionWrapper.c_delivery_owner_id_fk;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_owner_id_fk"] = DBNull.Value;
            }
            if (!string.IsNullOrEmpty(SessionWrapper.c_delivery_coordinator_id_fk))
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_coordinator_id_fk"] = SessionWrapper.c_delivery_coordinator_id_fk;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_coordinator_id_fk"] = DBNull.Value;
            }
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_active_flag"] = false;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_active_type_id_fk"] = ddlStatus.SelectedValue;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_visible_flag"] = chkVisible.Checked;
            if (MinEnroll != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_min_enroll"] = MinEnroll;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_min_enroll"] = DBNull.Value;
            }
            if (MaxEnroll != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_max_enroll"] = MaxEnroll;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_max_enroll"] = DBNull.Value;
            }
            if (EnrollThreshhold != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_enroll_threshold"] = EnrollThreshhold;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_enroll_threshold"] = DBNull.Value;
            }
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_waitlist_flag"] = chkWaitingList.Checked;
            if (MaxWaitList != null)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_max_waitlist"] = MaxWaitList;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_max_waitlist"] = DBNull.Value;

            }
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_vlt_launch_url"] = txtVlsUrl.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_olt_launch_url"] = txtScormUrl.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_olt_launch_param"] = txtScromLaunchParameters.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_grading_scheme_id_fk"] = ddlScoringScheme.SelectedValue;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_01"] = txtCustom01.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_02"] = txtCustom02.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_03"] = txtCustom03.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_04"] = txtCustom04.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_05"] = txtCustom05.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_06"] = txtCustom06.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_07"] = txtCustom07.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_08"] = txtCustom08.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_09"] = txtCustom09.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_10"] = txtCustom10.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_11"] = txtCustom11.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_12"] = txtCustom12.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_custom_13"] = txtCustom13.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_type_text"] = ddlDeliveryType.SelectedItem.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_owner_name"] = lblDeliveryOwner.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_delivery_coordinator_name"] = lblDeliveryCoordinator.Text;

            SessionWrapper.Deliveries.Rows[indexOfRow]["c_nc_olt_launch_url"] = txtNCUrl.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_nc_olt_launch_param"] = txtNcLaunchParameter.Text;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_survey_scoring_scheme_id_fk"] = ddlScoringScheme.SelectedValue;
            SessionWrapper.Deliveries.Rows[indexOfRow]["c_nc_olt_waitlist_flag"] = chkNcWaitList.Checked;
            if (chkNcWaitList.Checked == true)
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_nc_olt_wrapper_id_fk"] = ddlNcWrapper.SelectedValue;
            }
            else
            {
                SessionWrapper.Deliveries.Rows[indexOfRow]["c_nc_olt_wrapper_id_fk"] = DBNull.Value;
            }

            SessionWrapper.Deliveries.AcceptChanges();

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// AddDataToTempDeliveryattachments
        /// </summary>
        /// <param name="c_delivery_id_fk"></param>
        /// <param name="c_delivery_attachment_file_guid"></param>
        /// <param name="c_delivery_attachment_file_name"></param>
        /// <param name="dtTempDeliveryattachments"></param>
        private void AddDataToTempDeliveryattachments(string c_delivery_id_fk, string c_delivery_attachment_file_guid, string c_delivery_attachment_file_name, DataTable dtTempDeliveryattachments)
        {
            DataRow row;
            row = dtTempDeliveryattachments.NewRow();
            row["c_delivery_id_fk"] = editDelivery;
            row["c_delivery_attachment_file_guid"] = c_delivery_attachment_file_guid;
            row["c_delivery_attachment_file_name"] = c_delivery_attachment_file_name;
            dtTempDeliveryattachments.Rows.Add(row);
        }
        protected void gvSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSession1 = (Label)e.Row.FindControl("lblSession1");
                Label lblSession2 = (Label)e.Row.FindControl("lblSession2");
                lblSession1.Text = DataBinder.Eval(e.Row.DataItem, "c_session_title").ToString() + "<br>" + "(" + DataBinder.Eval(e.Row.DataItem, "c_session_id_pk").ToString() + ")";
                DataTable dtInstructors = new DataTable();
                dtInstructors = SessionWrapper.DeliveryInstructor;
                DataView dvInstructor = new DataView(dtInstructors);
                dvInstructor.RowFilter = "c_session_id_fk= '" + gvSession.DataKeys[e.Row.RowIndex].Values[0] + "' and c_instructor_confirm= '" + true + "'";


                string strInstructors = string.Empty;
                for (int i = 0; i < dvInstructor.Count; i++)
                {
                    strInstructors = strInstructors + dvInstructor[i]["c_instructor_name"].ToString();
                    strInstructors += (i < dvInstructor.Count - 1) ? " - " : string.Empty;

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
            //Deliveries
            DataTable dtDeliveries_1 = new DataTable();
            DataTable dtDeliveries_2 = (DataTable)SessionWrapper.Deliveries;
            dtDeliveries_1 = dtDeliveries_2.Copy();
            SessionWrapper.Reset_Deliveries = dtDeliveries_1;
            //Delivery attachments
            DataTable dtDeliveryAttachments_1 = new DataTable();
            DataTable dtDeliveryAttachments_2 = (DataTable)SessionWrapper.DeliveryAttachments;
            dtDeliveryAttachments_1 = dtDeliveryAttachments_2.Copy();
            SessionWrapper.Reset_DeliveryAttachments = dtDeliveryAttachments_1;
            //Delivery owner
            string str_delivery_onwer;
            str_delivery_onwer = lblDeliveryOwner.Text;
            SessionWrapper.Reset_c_delivery_owner_name = str_delivery_onwer;
            //Delivery coordinator
            string str_delivery_coordinator;
            str_delivery_coordinator = lblDeliveryCoordinator.Text;
            SessionWrapper.Reset_c_delivery_coordinator_name = str_delivery_coordinator;
            //Delivery resources
            DataTable dtDeliveryResource_1 = new DataTable();
            DataTable dtDeliveryResoruce_2 = (DataTable)SessionWrapper.DeliveryResource;
            dtDeliveryResource_1 = dtDeliveryResoruce_2.Copy();
            SessionWrapper.Reset_DeliveryResource = dtDeliveryResource_1;
            //Delivery material
            DataTable dtDeliveryMaterial_1 = new DataTable();
            DataTable dtDeliveryMaterial_2 = (DataTable)SessionWrapper.DeliveryMaterial;
            dtDeliveryMaterial_1 = dtDeliveryMaterial_2.Copy();
            SessionWrapper.Reset_DeliveryMaterial = dtDeliveryMaterial_1;
            //Delivery session
            DataTable dtDeliverySessions_1 = new DataTable();
            DataTable dtDeliverySessions_2 = (DataTable)SessionWrapper.DeliverySessions;
            dtDeliverySessions_1 = dtDeliverySessions_2.Copy();
            SessionWrapper.Reset_DeliverySessions = dtDeliverySessions_1;
            //Delivery instructor
            DataTable dtDeliverySessionInstructor_1 = new DataTable();
            DataTable dtDeliverySessionInstructor_2 = (DataTable)SessionWrapper.DeliveryInstructor;
            dtDeliverySessionInstructor_1 = dtDeliverySessionInstructor_2.Copy();
            SessionWrapper.Reset_DeliveryInstructor = dtDeliverySessionInstructor_1;

            //delivery owner id
            string str_c_delivery_owner_id_fk;
            str_c_delivery_owner_id_fk = SessionWrapper.c_delivery_owner_id_fk;
            SessionWrapper.Reset_c_delivery_owner_id_fk = str_c_delivery_owner_id_fk;

            //delivery coordinator id
            string str_c_delivery_coordinator_id_fk;
            str_c_delivery_coordinator_id_fk = SessionWrapper.c_delivery_coordinator_id_fk;
            SessionWrapper.Reset_c_delivery_coordinator_id_fk = str_c_delivery_coordinator_id_fk;

            //SessionWrapper.Reset_c_session_facility_id_fk = SessionWrapper.c_session_facility_id_fk;
            //SessionWrapper.Reset_c_session_location_id_fk = SessionWrapper.c_session_location_id_fk;
            //SessionWrapper.Reset_c_session_room_id_fk = SessionWrapper.c_session_room_id_fk;


        }
        /// <summary>
        /// Restore delivery on edit delivery (i.e while creating new course)
        /// </summary>
        private void RestoreDelivery()
        {

            //Deliveries
            DataTable dtDeliveries_1 = new DataTable();
            DataTable dtDeliveries_2 = (DataTable)SessionWrapper.Reset_Deliveries;
            dtDeliveries_1 = dtDeliveries_2.Copy();
            SessionWrapper.Deliveries = dtDeliveries_1;
            //Delivery attachments
            DataTable dtDeliveryAttachments_1 = new DataTable();
            DataTable dtDeliveryAttachments_2 = (DataTable)SessionWrapper.Reset_DeliveryAttachments;
            dtDeliveryAttachments_1 = dtDeliveryAttachments_2.Copy();
            SessionWrapper.DeliveryAttachments = dtDeliveryAttachments_1;
            //Delivery owner
            string str_delivery_onwer;
            str_delivery_onwer = SessionWrapper.Reset_c_delivery_owner_name;
            SessionWrapper.c_delivery_owner_name = str_delivery_onwer;
            //Delivery coordinator
            string str_delivery_coordinator;
            str_delivery_coordinator = SessionWrapper.Reset_c_delivery_coordinator_name;
            SessionWrapper.c_delivery_coordinator_name = str_delivery_coordinator;
            //Delivery resources
            DataTable dtDeliveryResource_1 = new DataTable();
            DataTable dtDeliveryResoruce_2 = (DataTable)SessionWrapper.Reset_DeliveryResource;
            dtDeliveryResource_1 = dtDeliveryResoruce_2.Copy();
            SessionWrapper.DeliveryResource = dtDeliveryResource_1;
            //Delivery material
            DataTable dtDeliveryMaterial_1 = new DataTable();
            DataTable dtDeliveryMaterial_2 = (DataTable)SessionWrapper.Reset_DeliveryMaterial;
            dtDeliveryMaterial_1 = dtDeliveryMaterial_2.Copy();
            SessionWrapper.DeliveryMaterial = dtDeliveryMaterial_1;
            //Delivery session
            DataTable dtDeliverySessions_1 = new DataTable();
            DataTable dtDeliverySessions_2 = (DataTable)SessionWrapper.Reset_DeliverySessions;
            dtDeliverySessions_1 = dtDeliverySessions_2.Copy();
            SessionWrapper.DeliverySessions = dtDeliverySessions_1;
            //Delivery instructor
            DataTable dtDeliverySessionInstructor_1 = new DataTable();
            DataTable dtDeliverySessionInstructor_2 = (DataTable)SessionWrapper.Reset_DeliveryInstructor;
            dtDeliverySessionInstructor_1 = dtDeliverySessionInstructor_2.Copy();
            SessionWrapper.DeliveryInstructor = dtDeliverySessionInstructor_1;

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

        protected void gvSession_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Copy"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string c_session_system_id_pk = gvSession.DataKeys[rowIndex].Values[0].ToString();
                //string c_session_id_pk = gvSession.DataKeys[rowIndex].Values[1].ToString();
                DataView dvcopySession = new DataView(SessionWrapper.DeliverySessions);
                dvcopySession.RowFilter = "c_session_system_id_pk= '" + c_session_system_id_pk + "'";
                DataTable dtCopySession = dvcopySession.ToTable();
                DataRow row;
                row = SessionWrapper.TempDeliverySessions.NewRow();
                row["c_session_system_id_pk"] = Guid.NewGuid().ToString();
                row["c_session_id_pk"] = dtCopySession.Rows[0]["c_session_id_pk"].ToString() + "_copy";
                row["c_delivery_id_fk"] = dtCopySession.Rows[0]["c_delivery_id_fk"].ToString();
                row["c_session_title"] = dtCopySession.Rows[0]["c_session_title"].ToString();
                row["c_sessions_desc"] = dtCopySession.Rows[0]["c_sessions_desc"].ToString();

                row["c_session_start_date"] = dtCopySession.Rows[0]["c_session_start_date"].ToString();
                row["c_session_end_date"] = dtCopySession.Rows[0]["c_session_end_date"].ToString();
                row["c_session_duration"] = dtCopySession.Rows[0]["c_session_duration"].ToString();

                row["c_session_start_time"] = dtCopySession.Rows[0]["c_session_start_time"].ToString();
                row["c_sessions_end_time"] = dtCopySession.Rows[0]["c_sessions_end_time"].ToString();

                row["c_session_location_id_fk"] = dtCopySession.Rows[0]["c_session_location_id_fk"].ToString();
                row["c_session_facility_id_fk"] = dtCopySession.Rows[0]["c_session_facility_id_fk"].ToString();
                row["c_sessions_room_id_fk"] = dtCopySession.Rows[0]["c_sessions_room_id_fk"].ToString();

                row["c_location_name"] = dtCopySession.Rows[0]["c_location_name"].ToString();
                row["c_facility_name"] = dtCopySession.Rows[0]["c_facility_name"].ToString();
                row["c_room_name"] = dtCopySession.Rows[0]["c_room_name"].ToString();

                row["c_session_date"] = dtCopySession.Rows[0]["c_session_date"].ToString();
                if (!string.IsNullOrEmpty(dtCopySession.Rows[0]["c_session_confirm"].ToString()))
                {
                    row["c_session_confirm"] = Convert.ToBoolean(dtCopySession.Rows[0]["c_session_confirm"].ToString());
                }
                SessionWrapper.TempDeliverySessions.Rows.Add(row);
                SessionWrapper.TempDeliverySessions.AcceptChanges();

                ConvertDataTables removeDuplicaterow = new ConvertDataTables();
                if (SessionWrapper.TempDeliverySessions.Rows.Count > 0)
                {
                    SessionWrapper.TempDeliverySessions = removeDuplicaterow.RemoveDuplicateRows(SessionWrapper.TempDeliverySessions, "c_session_id_pk");
                }

                //Bind sessions
                gvSession.DataSource = SessionWrapper.TempDeliverySessions;
                gvSession.DataBind();

            }
        }

    }
}