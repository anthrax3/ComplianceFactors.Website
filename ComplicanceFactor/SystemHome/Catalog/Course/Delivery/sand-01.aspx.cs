using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.IO;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor.SystemHome.Catalog.Popup
{
    public partial class sand_01 : BasePage
    {
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
                //Show and hide validation summary
                vs_sand.Style.Add("display", "none");

                if (!IsPostBack)
                {
                    clearDeliverySession();

                    if( !string.IsNullOrEmpty(Request.QueryString["userName"]))
                    {
                        SessionWrapper.c_delivery_coordinator_name = Request.QueryString["userName"].ToString();
                        
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
                    {
                        
                        SessionWrapper.c_delivery_coordinator_id_fk = Request.QueryString["userId"].ToString();
                    }

                    

                    //Add column in resource datatable
                    SessionWrapper.TempDeliveryResource = TempDataTables.TempDeliveryResource();
                    //Add column in instructor datatable
                    SessionWrapper.TempDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    //Add column in material datatable
                    SessionWrapper.TempDeliveryMaterial = TempDataTables.TempDeliveryMaterials();
                    //Add column in attachment
                    SessionWrapper.TempDeliveryAttachments = TempDataTables.TempDeliveryattachments();
                    //Add column in TempAddDeliveryInstructor
                    SessionWrapper.TempAddDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    //Add column in TempDeliverySessions
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
                    ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName,"sand-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind wrapper
                    ddlNcWrapper.DataSource = ManageCourseBLL.GetOLTWrapper(SessionWrapper.CultureName, "sand-01");
                    ddlNcWrapper.DataBind();
                    //Set delivery system id 
                    SessionWrapper.c_delivery_system_id_pk = Guid.NewGuid().ToString();
                    if (Request.QueryString["mode"] == "createcopy")
                    {

                        //Set checkcopy value because instead of postback
                        hdCheckCopy.Value = "1";
                        DataView dvcopyDelivery = new DataView(SessionWrapper.Deliveries);
                        DataView dvcopySession = new DataView(SessionWrapper.DeliverySessions);
                        DataView dvcopyResources = new DataView(SessionWrapper.DeliveryResource);
                        DataView dvcopyMaterials = new DataView(SessionWrapper.DeliveryMaterial);
                        DataView dvcopyattachment = new DataView(SessionWrapper.DeliveryAttachments);

                        dvcopyDelivery.RowFilter = "c_delivery_system_id_pk= '" + Request.QueryString["copydelivery"] + "'";
                        dvcopySession.RowFilter = "c_delivery_id_fk= '" + Request.QueryString["copydelivery"] + "'";
                        dvcopyResources.RowFilter = "c_delivery_id_fk= '" + Request.QueryString["copydelivery"] + "'";
                        dvcopyMaterials.RowFilter = "c_delivery_id_fk= '" + Request.QueryString["copydelivery"] + "'";
                        dvcopyattachment.RowFilter = "c_delivery_id_fk= '" + Request.QueryString["copydelivery"] + "'";
                        TempCopyDeliveries(Request.QueryString["id"], dvcopyDelivery.ToTable(), dvcopySession.ToTable(), dvcopyResources.ToTable(), dvcopyMaterials.ToTable(), dvcopyattachment.ToTable());
                    }
                    else if (Request.QueryString["mode"] == "editcopy")
                    {
                        string newDeliveryId = Guid.NewGuid().ToString();
                        int error = TrainingBLL.CopyDelivery(Request.QueryString["copydelivery"].ToString(), Request.QueryString["editcourseId"].ToString(), newDeliveryId);
                        if (error != -2)
                        {
                            Response.Redirect("/SystemHome/Catalog/Course/Delivery/saed-02.aspx?editdelivery=" + newDeliveryId, false);
                        }

                    }
                    //copy 
                    //if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    //{
                    //    //TODO
                    //}
                    ////create
                    //else
                    //{

                    //    this.gvAddDeliveryAttachments.DataSource = SessionWrapper.TempDeliveryAttachments;
                    //    this.gvAddDeliveryAttachments.DataBind();
                    //}

                    //Bind Grading Scheme
                    ddlScoringScheme.DataSource = SystemCurriculumBLL.GetGradingScheme(SessionWrapper.CultureName);
                    ddlScoringScheme.DataBind();

                }

                //Get owner name
                lblDeliveryOwner.Text = SessionWrapper.c_delivery_owner_name;
                lblDeliveryCoordinator.Text = SessionWrapper.c_delivery_coordinator_name;

                if(hdCheckCopy.Value!="1" || string.IsNullOrEmpty(hdCheckCopy.Value))
                {
                    if (Request.QueryString["mode"] != "createcopy" || Request.QueryString["mode"] != "editcopy")
                    {
                        //Bind Resource
                        gvResources.DataSource = SessionWrapper.TempDeliveryResource;
                        gvResources.DataBind();

                        //Bind materials
                        gvMaterials.DataSource = SessionWrapper.TempDeliveryMaterial;
                        gvMaterials.DataBind();

                        //Bind sessions
                        gvSession.DataSource = SessionWrapper.TempDeliverySessions;
                        gvSession.DataBind();

                        this.gvAddDeliveryAttachments.DataSource = SessionWrapper.TempDeliveryAttachments;
                        this.gvAddDeliveryAttachments.DataBind();
                    }
                    
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
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Clear delivery session
        /// </summary>
        private void clearDeliverySession()
        {
            SessionWrapper.c_delivery_system_id_pk = "";
            SessionWrapper.c_delivery_owner_id_fk = "";
            SessionWrapper.c_delivery_owner_name = "";
            SessionWrapper.c_delivery_coordinator_id_fk = "";
            SessionWrapper.c_delivery_coordinator_name = "";
            SessionWrapper.c_room_name = "";
            SessionWrapper.c_room_system_id_pk = "";
            SessionWrapper.c_facility_name = "";
            SessionWrapper.c_facility_system_id_pk = "";
            SessionWrapper.c_location_name = "";
            SessionWrapper.c_location_system_id_pk = "";

            SessionWrapper.TempDeliveryAttachments = null;
            SessionWrapper.TempDeliveryResource = null;
            SessionWrapper.TempDeliveryMaterial = null;
            SessionWrapper.TempDeliveryInstructor = null;
            //SessionWrapper.DeliveryInstructor = null;

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


                var rows = SessionWrapper.TempDeliveryResource.Select("c_resource_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempDeliveryResource.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message);
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


                var rows = SessionWrapper.TempDeliveryMaterial.Select("c_material_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempDeliveryMaterial.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message);
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
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sand-01.aspx", ex.Message);
                    }
                }
            }


        }
        //Temp Delivery attachments column
        private DataTable tempDeliveryattachments()
        {
            DataTable dtTempDeliveryattachments = new DataTable();
            DataColumn dtTempDeliveryattachmentsColumn;
            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_id_pk";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_file_guid";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_file_name";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);
            return dtTempDeliveryattachments;
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
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["c_delivery_attachment_file_guid"] = c_delivery_attachment_file_guid;
            row["c_delivery_attachment_file_name"] = c_delivery_attachment_file_name;
            dtTempDeliveryattachments.Rows.Add(row);
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
        private void DeleteDataToTempDeliveryattachments(int rowIndex, DataTable dtTempDeliveryattachments)
        {
            dtTempDeliveryattachments.Rows[rowIndex].Delete();
            dtTempDeliveryattachments.AcceptChanges();
            this.gvAddDeliveryAttachments.DataSource = (SessionWrapper.TempDeliveryAttachments).DefaultView;
            this.gvAddDeliveryAttachments.DataBind();
        }
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
                DeleteDataToTempDeliveryattachments(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.TempDeliveryAttachments);
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
                        EditDataToTempDeliveryattachments(Convert.ToInt32(hdAttachments.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.TempDeliveryAttachments);
                        hdAttachments.Value = "";
                    }
                    else
                    {
                        AddDataToTempDeliveryattachments(SessionWrapper.c_delivery_system_id_pk, c_file_guid + c_file_extension, c_file_name, SessionWrapper.TempDeliveryAttachments);
                    }
                }
            }
            this.gvAddDeliveryAttachments.DataSource = (SessionWrapper.TempDeliveryAttachments).DefaultView;
            this.gvAddDeliveryAttachments.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveDeliveryAndSession();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
        /// <summary>
        /// SaveDeliveryAndSession
        /// </summary>
        private void SaveDeliveryAndSession()
        {

            try
            {
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
                //Have to add the newly added columns into this session(session.Deliveries)
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


                AddDataToDeliveries(SessionWrapper.c_delivery_system_id_pk, "", txtDeliveyID.Text,
                    ddlDeliveryType.SelectedValue, txtDeliveryTitle.Text, txtDescription.Value,
                    txtAbstract.InnerText, chkApproval.Checked, ddlApprovalRequired.SelectedValue,
                    CreditHours, CreditUnits, SessionWrapper.c_delivery_owner_id_fk, SessionWrapper.c_delivery_coordinator_id_fk, false,
                    ddlStatus.SelectedValue, chkVisible.Checked, MinEnroll, MaxEnroll,
                    EnrollThreshhold, chkWaitingList.Checked, MaxWaitList, txtVlsUrl.Text, txtScormUrl.Text,
                    txtScromLaunchParameters.Text,
                    availableFrom.ToString(),
                    availableTo.ToString(),
                    effectiveDate.ToString(),
                    cuttoffDate.ToString(),
                    cutofftime.ToString(),
                    txtCustom01.Text,
                    txtCustom02.Text,
                    txtCustom03.Text,
                    txtCustom04.Text,
                    txtCustom05.Text,
                    txtCustom06.Text,
                    txtCustom07.Text,
                    txtCustom08.Text,
                    txtCustom09.Text,
                    txtCustom10.Text,
                    txtCustom11.Text,
                    txtCustom12.Text,
                    txtCustom13.Text, ddlDeliveryType.SelectedItem.Text, lblDeliveryOwner.Text, lblDeliveryCoordinator.Text,
                    txtNCUrl.Text,txtNcLaunchParameter.Text,chkNcWaitList.Checked,ddlNcWrapper.SelectedValue,ddlScoringScheme.SelectedValue,
                    SessionWrapper.Deliveries);


               
                    SessionWrapper.DeliveryResource.Merge(SessionWrapper.TempDeliveryResource);
                    SessionWrapper.DeliveryMaterial.Merge(SessionWrapper.TempDeliveryMaterial);
                    SessionWrapper.DeliveryAttachments.Merge(SessionWrapper.TempDeliveryAttachments);
                    //Aug 24,2012 at 6:27
                    SessionWrapper.DeliverySessions.Merge(SessionWrapper.TempDeliverySessions);
                

                //Add new delivery and session on while in edit course
                if (Request.QueryString["mode"] == "adddelivery")
                {
                    CultureInfo culture = new CultureInfo("en-US");
                    SystemCatalog createCourseDelivery = new SystemCatalog();
                    
                    createCourseDelivery.c_course_id_fk = Request.QueryString["editCourseId"];
                    //delivery(ies)
                    createCourseDelivery.c_deliveries = ConvertDataTableToXml(SessionWrapper.Deliveries);
                    //delivery attachment
                    createCourseDelivery.c_delivery_attachments = ConvertDataTableToXml(SessionWrapper.DeliveryAttachments);
                    //delivery Resource
                    createCourseDelivery.c_delivery_resources = ConvertDataTableToXml(SessionWrapper.DeliveryResource);
                    //delivery Material
                    createCourseDelivery.c_delivery_material = ConvertDataTableToXml(SessionWrapper.DeliveryMaterial);
                    //session
                    createCourseDelivery.c_sessions = ConvertDataTableToXml(SessionWrapper.DeliverySessions);
                    //session instructor
                    createCourseDelivery.c_session_instructor = ConvertDataTableToXml(SessionWrapper.DeliveryInstructor);
                    createCourseDelivery.c_delivery_system_id_pk = string.Empty;

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
                                Logger.WriteToErrorLog("sand-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("sand-01", ex.Message);
                            }
                        }

                    }
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
                        Logger.WriteToErrorLog("sand-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sand-01", ex.Message);
                    }
                }

            }
        }
        /// <summary>
        /// AddDataToDeliveries
        /// </summary>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <param name="c_course_id_fk"></param>
        /// <param name="c_delivery_id_pk"></param>
        /// <param name="c_delivery_type_id_fk"></param>
        /// <param name="c_delivery_title"></param>
        /// <param name="c_delivery_desc"></param>
        /// <param name="c_delivery_abstract"></param>
        /// <param name="c_delivery_approval_req"></param>
        /// <param name="c_delivery_approval_id_fk"></param>
        /// <param name="c_delivery_credit_hours"></param>
        /// <param name="c_delivery_credit_units"></param>
        /// <param name="c_delivery_owner_id_fk"></param>
        /// <param name="c_delivery_coordinator_id_fk"></param>
        /// <param name="c_delivery_active_flag"></param>
        /// <param name="c_delivery_active_type_id_fk"></param>
        /// <param name="c_delivery_visible_flag"></param>
        /// <param name="c_delivery_min_enroll"></param>
        /// <param name="c_delivery_max_enroll"></param>
        /// <param name="c_delivery_enroll_threshold"></param>
        /// <param name="c_delivery_waitlist_flag"></param>
        /// <param name="c_delivery_max_waitlist"></param>
        /// <param name="c_vlt_launch_url"></param>
        /// <param name="c_olt_launch_url"></param>
        /// <param name="c_olt_launch_param"></param>
        /// <param name="c_delivery_custom_01"></param>
        /// <param name="c_delivery_custom_02"></param>
        /// <param name="c_delivery_custom_03"></param>
        /// <param name="c_delivery_custom_04"></param>
        /// <param name="c_delivery_custom_05"></param>
        /// <param name="c_delivery_custom_06"></param>
        /// <param name="c_delivery_custom_07"></param>
        /// <param name="c_delivery_custom_08"></param>
        /// <param name="c_delivery_custom_09"></param>
        /// <param name="c_delivery_custom_10"></param>
        /// <param name="c_delivery_custom_11"></param>
        /// <param name="c_delivery_custom_12"></param>
        /// <param name="c_delivery_custom_13"></param>
        /// <param name="dtTempDeliveries"></param>
        private void AddDataToDeliveries(string c_delivery_system_id_pk,
                                            string c_course_id_fk,
                                            string c_delivery_id_pk,
                                            string c_delivery_type_id_fk,
                                            string c_delivery_title,
                                            string c_delivery_desc,
                                            string c_delivery_abstract,
                                            bool c_delivery_approval_req,
                                            string c_delivery_approval_id_fk,
                                            int? c_delivery_credit_hours,
                                            int? c_delivery_credit_units,
                                            string c_delivery_owner_id_fk,
                                            string c_delivery_coordinator_id_fk,
                                            bool c_delivery_active_flag,
                                            string c_delivery_active_type_id_fk,
                                            bool c_delivery_visible_flag,
                                            int? c_delivery_min_enroll,
                                            int? c_delivery_max_enroll,
                                            int? c_delivery_enroll_threshold,
                                            bool c_delivery_waitlist_flag,
                                            int? c_delivery_max_waitlist,
                                            string c_vlt_launch_url,
                                            string c_olt_launch_url,
                                            string c_olt_launch_param,
                                            string availableFrom,
                                            string availableTo,
                                            string effectiveDate,
                                            string cutoffDate,
                                            string cutoffTime,
                                            string c_delivery_custom_01,
                                            string c_delivery_custom_02,
                                            string c_delivery_custom_03,
                                            string c_delivery_custom_04,
                                            string c_delivery_custom_05,
                                            string c_delivery_custom_06,
                                            string c_delivery_custom_07,
                                            string c_delivery_custom_08,
                                            string c_delivery_custom_09,
                                            string c_delivery_custom_10,
                                            string c_delivery_custom_11,
                                            string c_delivery_custom_12,
                                            string c_delivery_custom_13,
                                            string c_delivery_type_text,
                                            string c_delivery_owner_name,
                                            string c_delivery_coordinator_name,
                                            string c_nc_olt_launch_url,
                                            string c_nc_olt_launch_param,
                                            bool c_nc_olt_waitlist_flag,
                                            string c_nc_olt_wrapper_id_fk,
                                            string c_survey_scoring_scheme_id_fk,
                                            DataTable dtTempDeliveries)
        {

            DataRow row;
            row = dtTempDeliveries.NewRow();
            row["c_delivery_system_id_pk"] = SessionWrapper.c_delivery_system_id_pk;
            row["c_course_id_fk"] = c_course_id_fk;
            row["c_delivery_id_pk"] = c_delivery_id_pk;
            row["c_delivery_type_id_fk"] = c_delivery_type_id_fk;
            row["c_delivery_title"] = c_delivery_title;
            row["c_delivery_desc"] = c_delivery_desc;
            row["c_delivery_abstract"] = c_delivery_abstract;
            row["c_delivery_approval_req"] = c_delivery_approval_req;
            row["c_delivery_approval_id_fk"] = c_delivery_approval_id_fk;
            if (c_delivery_credit_hours != null)
            {
                row["c_delivery_credit_hours"] = c_delivery_credit_hours;
            }
            else
            {
                row["c_delivery_credit_hours"] = DBNull.Value;
            }
            if (c_delivery_credit_units != null)
            {
                row["c_delivery_credit_units"] = c_delivery_credit_units;
            }
            else
            {
                row["c_delivery_credit_units"] = DBNull.Value;
            }
            row["c_delivery_owner_id_fk"] = c_delivery_owner_id_fk;
            row["c_delivery_coordinator_id_fk"] = c_delivery_coordinator_id_fk;
            row["c_delivery_active_flag"] = c_delivery_active_flag;
            row["c_delivery_active_type_id_fk"] = c_delivery_active_type_id_fk;
            row["c_delivery_visible_flag"] = c_delivery_visible_flag;
            if (c_delivery_min_enroll != null)
            {
                row["c_delivery_min_enroll"] = c_delivery_min_enroll;
            }
            else
            {
                row["c_delivery_min_enroll"] = DBNull.Value;
            }
            if (c_delivery_max_enroll != null)
            {
                row["c_delivery_max_enroll"] = c_delivery_max_enroll;
            }
            else
            {
                row["c_delivery_max_enroll"] = DBNull.Value;

            }
            if (c_delivery_enroll_threshold != null)
            {
                row["c_delivery_enroll_threshold"] = c_delivery_enroll_threshold;
            }
            else
            {
                row["c_delivery_enroll_threshold"] = DBNull.Value;
            }
            row["c_delivery_waitlist_flag"] = c_delivery_waitlist_flag;
            if (c_delivery_max_waitlist != null)
            {
                row["c_delivery_max_waitlist"] = c_delivery_max_waitlist;
            }
            else
            {
                row["c_delivery_max_waitlist"] = DBNull.Value;
            }
            row["c_vlt_launch_url"] = c_vlt_launch_url;
            row["c_olt_launch_url"] = c_olt_launch_url;
            row["c_olt_launch_param"] = c_olt_launch_param;

            row["c_delivery_available_from_date"] = availableFrom;
            row["c_delivery_available_to_date"] = availableTo;
            row["c_delivery_effective_date"] = effectiveDate;
            row["c_delivery_cut_off_date"] = cutoffDate;
            row["c_delivery_cut_off_time"] = cutoffTime;

            row["c_delivery_custom_01"] = c_delivery_custom_01;
            row["c_delivery_custom_02"] = c_delivery_custom_02;
            row["c_delivery_custom_03"] = c_delivery_custom_03;
            row["c_delivery_custom_04"] = c_delivery_custom_04;
            row["c_delivery_custom_05"] = c_delivery_custom_05;
            row["c_delivery_custom_06"] = c_delivery_custom_06;
            row["c_delivery_custom_07"] = c_delivery_custom_07;
            row["c_delivery_custom_08"] = c_delivery_custom_08;
            row["c_delivery_custom_09"] = c_delivery_custom_09;
            row["c_delivery_custom_10"] = c_delivery_custom_10;
            row["c_delivery_custom_11"] = c_delivery_custom_11;
            row["c_delivery_custom_12"] = c_delivery_custom_12;
            row["c_delivery_custom_13"] = c_delivery_custom_13;
            row["c_delivery_type_text"] = c_delivery_type_text;
            row["c_delivery_owner_name"] = c_delivery_owner_name;
            row["c_delivery_coordinator_name"] = c_delivery_coordinator_name;
            row["c_nc_olt_launch_url"] = c_nc_olt_launch_url;
            row["c_nc_olt_launch_param"] = c_nc_olt_launch_param;
            row["c_nc_olt_waitlist_flag"] = c_nc_olt_waitlist_flag;
            if (c_nc_olt_waitlist_flag == true)
            {
                row["c_nc_olt_wrapper_id_fk"] = c_nc_olt_wrapper_id_fk;
            }
            else
            {
                row["c_nc_olt_wrapper_id_fk"] = DBNull.Value;
            }
            row["c_survey_scoring_scheme_id_fk"] = c_survey_scoring_scheme_id_fk;

            dtTempDeliveries.Rows.Add(row);
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
                dvInstructor.RowFilter = "c_session_id_fk= '" + gvSession.DataKeys[e.Row.RowIndex].Values[0] + "'";


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
        protected void btnReset_Click(object sender, EventArgs e)
        {

            ClearandResetDelivery();
            Response.Redirect(Request.RawUrl);

        }
        /// <summary>
        /// clear and Reset delivery section
        /// </summary>
        private void ClearandResetDelivery()
        {
            SessionWrapper.c_delivery_system_id_pk = "";
            SessionWrapper.c_delivery_owner_id_fk = "";
            SessionWrapper.c_delivery_owner_name = "";
            SessionWrapper.c_delivery_coordinator_id_fk = "";
            SessionWrapper.c_delivery_coordinator_name = "";
            SessionWrapper.c_room_name = "";
            SessionWrapper.c_room_system_id_pk = "";
            SessionWrapper.c_facility_name = "";
            SessionWrapper.c_facility_system_id_pk = "";
            SessionWrapper.c_location_name = "";
            SessionWrapper.c_location_system_id_pk = "";

            SessionWrapper.TempDeliveryResource = null;
            SessionWrapper.TempDeliveryMaterial = null;
            SessionWrapper.TempDeliverySessions = null;
            SessionWrapper.TempDeliveryInstructor = null;
            SessionWrapper.TempAddDeliveryInstructor = null;
            SessionWrapper.c_session_facility_id_fk = "";
            SessionWrapper.c_session_location_id_fk = "";
            SessionWrapper.c_session_room_id_fk = "";
            SessionWrapper.c_session_system_id_pk = "";
            SessionWrapper.DeliveryAttachments = null;




        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearandResetDelivery();
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        private void TempCopyDeliveries(string s_grading_scheme_system_value_id_pk, DataTable dtCopydeliveries,DataTable dtCopySession,DataTable dtCopyResources ,DataTable dtCopyMaterials,DataTable dtCopyAttachment)
        {
            txtDeliveyID.Text = dtCopydeliveries.Rows[0]["c_delivery_id_pk"].ToString()+"_copy";
            ddlDeliveryType.SelectedValue = dtCopydeliveries.Rows[0]["c_delivery_type_id_fk"].ToString();
            txtDeliveryTitle.Text = dtCopydeliveries.Rows[0]["c_delivery_title"].ToString();
            txtDescription.Value = dtCopydeliveries.Rows[0]["c_delivery_desc"].ToString();
            txtAbstract.Value = dtCopydeliveries.Rows[0]["c_delivery_abstract"].ToString();
            chkApproval.Checked = Convert.ToBoolean(dtCopydeliveries.Rows[0]["c_delivery_approval_req"]);
            ddlApprovalRequired.SelectedValue = dtCopydeliveries.Rows[0]["c_delivery_approval_id_fk"].ToString();
            txtCreditHours.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_credit_hours"]);
            txtCreditUnits.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_credit_units"]);
            SessionWrapper.c_delivery_owner_id_fk = dtCopydeliveries.Rows[0]["c_delivery_owner_id_fk"].ToString();
            SessionWrapper.c_delivery_coordinator_id_fk = dtCopydeliveries.Rows[0]["c_delivery_coordinator_id_fk"].ToString();
            SessionWrapper.c_delivery_owner_name = dtCopydeliveries.Rows[0]["c_delivery_owner_name"].ToString();
            SessionWrapper.c_delivery_coordinator_name = dtCopydeliveries.Rows[0]["c_delivery_coordinator_name"].ToString();
            ddlStatus.SelectedValue = dtCopydeliveries.Rows[0]["c_delivery_active_type_id_fk"].ToString();
            chkVisible.Checked = Convert.ToBoolean(dtCopydeliveries.Rows[0]["c_delivery_visible_flag"].ToString());
            txtMinEnroll.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_min_enroll"]);
            txtMaxEnroll.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_max_enroll"]);
            txtEnrollThreshhold.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_enroll_threshold"]);
            chkWaitingList.Checked = Convert.ToBoolean(dtCopydeliveries.Rows[0]["c_delivery_waitlist_flag"].ToString());
            txtMaxwaitList.Text = Convert.ToString(dtCopydeliveries.Rows[0]["c_delivery_max_waitlist"].ToString());
            txtScormUrl.Text = dtCopydeliveries.Rows[0]["c_olt_launch_url"].ToString();
            txtScromLaunchParameters.Text = dtCopydeliveries.Rows[0]["c_olt_launch_param"].ToString();
            txtVlsUrl.Text = dtCopydeliveries.Rows[0]["c_vlt_launch_url"].ToString();

            txtAvailableFrom.Text = dtCopydeliveries.Rows[0]["c_delivery_available_from_date"].ToString();
            txtAvailableTo.Text = dtCopydeliveries.Rows[0]["c_delivery_available_to_date"].ToString();
            txtEffectiveDate.Text = dtCopydeliveries.Rows[0]["c_delivery_effective_date"].ToString();
            txtCutOffDate.Text = dtCopydeliveries.Rows[0]["c_delivery_cut_off_date"].ToString();
            txtCutoffTime.Text = dtCopydeliveries.Rows[0]["c_delivery_cut_off_time"].ToString();


            txtCustom01.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_01"].ToString();
            txtCustom02.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_02"].ToString();
            txtCustom03.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_03"].ToString();
            txtCustom04.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_04"].ToString();
            txtCustom05.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_05"].ToString();
            txtCustom06.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_06"].ToString();
            txtCustom07.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_07"].ToString();
            txtCustom08.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_08"].ToString();
            txtCustom09.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_09"].ToString();
            txtCustom10.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_10"].ToString();
            txtCustom11.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_11"].ToString();
            txtCustom12.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_12"].ToString();
            txtCustom13.Text = dtCopydeliveries.Rows[0]["c_delivery_custom_13"].ToString();
            lblDeliveryOwner.Text = dtCopydeliveries.Rows[0]["c_delivery_owner_name"].ToString();
            lblDeliveryCoordinator.Text = dtCopydeliveries.Rows[0]["c_delivery_coordinator_name"].ToString();
            txtNCUrl.Text = dtCopydeliveries.Rows[0]["c_nc_olt_launch_url"].ToString();
            txtNcLaunchParameter.Text = dtCopydeliveries.Rows[0]["c_nc_olt_launch_param"].ToString();
            chkNcWaitList.Checked = Convert.ToBoolean(dtCopydeliveries.Rows[0]["c_nc_olt_waitlist_flag"].ToString());
            if (!string.IsNullOrEmpty(dtCopydeliveries.Rows[0]["c_nc_olt_wrapper_id_fk"].ToString()))
            {
                ddlNcWrapper.SelectedValue = dtCopydeliveries.Rows[0]["c_nc_olt_wrapper_id_fk"].ToString();
            }
            ddlScoringScheme.SelectedValue = dtCopydeliveries.Rows[0]["c_survey_scoring_scheme_id_fk"].ToString(); ;

            SessionWrapper.TempDeliverySessions = CopyDelivery(dtCopySession, SessionWrapper.c_delivery_system_id_pk,"session");

            SessionWrapper.TempDeliveryResource = CopyDelivery(dtCopyResources, SessionWrapper.c_delivery_system_id_pk, "resource");

            SessionWrapper.TempDeliveryMaterial = CopyDelivery(dtCopyMaterials, SessionWrapper.c_delivery_system_id_pk, "material");

            SessionWrapper.TempDeliveryAttachments = CopyDelivery(dtCopyAttachment, SessionWrapper.c_delivery_system_id_pk, "attachment");
            //Bind Session
            gvSession.DataSource = SessionWrapper.TempDeliverySessions;
            gvSession.DataBind();
            //Bind Resources
            gvResources.DataSource = SessionWrapper.TempDeliveryResource;
            gvResources.DataBind();
            //Bind Materials
            gvMaterials.DataSource = SessionWrapper.TempDeliveryMaterial;
            gvMaterials.DataBind();
            //Bind Attachment
            gvAddDeliveryAttachments.DataSource = SessionWrapper.TempDeliveryAttachments;
            gvAddDeliveryAttachments.DataBind();
        }

        protected void gvSession_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName.Equals("Copy"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string c_session_system_id_pk = gvSession.DataKeys[rowIndex].Values[0].ToString();
                //string c_session_id_pk = gvSession.DataKeys[rowIndex].Values[1].ToString();
                DataView dvcopySession = new DataView(SessionWrapper.TempDeliverySessions);
                dvcopySession.RowFilter = "c_session_system_id_pk= '" + c_session_system_id_pk + "'";
                DataTable dtCopySession = dvcopySession.ToTable();
                DataRow row;
                row = SessionWrapper.TempDeliverySessions.NewRow();
                string c_session_new_id = Guid.NewGuid().ToString();
                row["c_session_system_id_pk"] = c_session_new_id;
                row["c_session_id_pk"] = dtCopySession.Rows[0]["c_session_id_pk"].ToString()+"_copy";
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

                //var rows = SessionWrapper.TempDeliveryInstructor.Select("c_session_id_fk='" + c_session_system_id_pk + "'");
                //var indexOfRow = SessionWrapper.TempDeliveryInstructor.Rows.IndexOf(rows[0]);

                var rows = SessionWrapper.DeliveryInstructor.Select("c_session_id_fk='" + c_session_system_id_pk + "'");
              
                for( int i=0;i<rows.Length;i++)
                {

                    var indexOfRow = SessionWrapper.DeliveryInstructor.Rows.IndexOf(rows[i]);
                    DataRow rowInstrctor;
                    rowInstrctor = SessionWrapper.DeliveryInstructor.NewRow();
                    rowInstrctor["c_instructor_system_id_pk"] = Guid.NewGuid().ToString();
                    rowInstrctor["c_user_id_fk"] = SessionWrapper.DeliveryInstructor.Rows[indexOfRow]["c_user_id_fk"];
                    rowInstrctor["c_instructor_name"] = SessionWrapper.DeliveryInstructor.Rows[indexOfRow]["c_instructor_name"];
                    rowInstrctor["c_session_id_fk"] = c_session_new_id;
                    rowInstrctor["c_delivery_id_fk"] = SessionWrapper.DeliveryInstructor.Rows[indexOfRow]["c_delivery_id_fk"];
                    rowInstrctor["c_instructor_confirm"] = true;
                    rowInstrctor["c_instructor_type_id_fk"] = SessionWrapper.DeliveryInstructor.Rows[indexOfRow]["c_instructor_type_id_fk"];
                    SessionWrapper.DeliveryInstructor.Rows.Add(rowInstrctor);
                    SessionWrapper.DeliveryInstructor.AcceptChanges();
                }
                
                



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

        private DataTable CopyDelivery(DataTable dt, string c_delivery_system_id_pk, string type)
        {
          
            if (type == "session")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["c_session_system_id_pk"] = Guid.NewGuid().ToString();
                    row["c_delivery_id_fk"] = c_delivery_system_id_pk;
                    
                }
            }
            else if (type == "resource")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["c_resource_system_id_pk"] = Guid.NewGuid().ToString();
                    row["c_delivery_id_fk"] = c_delivery_system_id_pk;
                    
                }
            }
            
            else if (type == "material")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["c_material_system_id_pk"] = Guid.NewGuid().ToString();
                    row["c_delivery_id_fk"] = c_delivery_system_id_pk;
                    
                }
            }
            else if (type == "attachment")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["c_delivery_attachment_id_pk"] = Guid.NewGuid().ToString();
                    row["c_delivery_id_fk"] = c_delivery_system_id_pk;
                   
                }
            }
            return dt;
            
        }

    }
}