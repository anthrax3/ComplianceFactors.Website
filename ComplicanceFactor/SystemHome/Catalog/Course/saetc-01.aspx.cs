using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using ComplicanceFactor.Common.Languages;


namespace ComplicanceFactor.SystemHome.Catalog
{
    public partial class saetc_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Course/Icons/";
        #endregion
        private static string editCourseId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide validation on postback (if user select owner,coordinator,prerequisite,equivalence and fullfillments)
            vs_saetc.Style.Add("display", "none");
            //Get course id
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                editCourseId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                hdCourseId.Value = editCourseId;
                SessionWrapper.AuthInstructorCourseId = editCourseId;
            }
            //Store Prerequisites,Equivalencies and Fulfillments in dataset (For Reset to store in session)
            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(editCourseId);
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + LocalResources.GetLabel("app_manage_training_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_course_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + LocalResources.GetLabel("app_manage_training_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_course_text") + "</a>";


                //bind locale
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();
                ///Show success message
                if (!string.IsNullOrEmpty(Request.QueryString["arc"]))
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_archieved_text");

                }
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                try
                {
                    //bind previous version list
                    gvVersionList.DataSource = SystemCatalogBLL.GetCourseVersionList(editCourseId, Convert.ToInt32(SessionWrapper.u_timezone));
                    gvVersionList.DataBind();
                    //store course id in session
                    SessionWrapper.editCourseId = editCourseId;
                    //Bind status
                    ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName, "saetc-01");
                    ddlStatus.DataBind();
                    //Bind Approval
                    ddlApprovalRequired.DataSource = SystemCatalogBLL.GetApprovalForCourse(SessionWrapper.CultureName);
                    ddlApprovalRequired.DataBind();
                    //clear course related sessoin
                    ClearCourseSession();
                    //Populate course details
                    PopulateCourse(editCourseId);
                    //store icon in viewstate for reset 
                    ViewState["iconUri"] = SessionWrapper.iconUri;
                    ViewState["iconUrifilename"] = SessionWrapper.iconUrifilename;
                    //Add column in course related sessoin
                    SessionWrapper.PrerequisiteCourseSelected = Prerequisites();
                    SessionWrapper.EquivalenciesCourseSelected = Equivalencies();
                    SessionWrapper.FulfillmentsCourseSelected = Fulfillments();
                    SessionWrapper.ResetPrerequisite = Prerequisites();
                    SessionWrapper.ResetEquivalencies = Equivalencies();
                    SessionWrapper.ResetFulfillments = Fulfillments();
                    //Add column in resource datatable
                    SessionWrapper.DeliveryResource = TempDataTables.TempDeliveryResource();
                    //Add column in instructor datatable
                    SessionWrapper.DeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    //Add column in material datatable
                    SessionWrapper.DeliveryMaterial = TempDataTables.TempDeliveryMaterials();
                    //Add column in delivery session datatable
                    SessionWrapper.DeliverySessions = TempDataTables.TempDeliverySessions();
                    SessionWrapper.TempDeliverySessions = TempDataTables.TempDeliverySessions();
                    //Add column in delivery datatable
                    SessionWrapper.Deliveries = TempDataTables.TempDeliveries();
                    //Add column in delivery attachments
                    SessionWrapper.DeliveryAttachments = TempDataTables.TempDeliveryattachments();
                    //Get Prerequisites session
                    SessionWrapper.ResetPrerequisite = dsprerequisiteEquivalenciesFullfillments.Tables[0];
                    //Get Equivalencies session
                    SessionWrapper.ResetEquivalencies = dsprerequisiteEquivalenciesFullfillments.Tables[1];
                    //Get Fulfillments session
                    SessionWrapper.ResetFulfillments = dsprerequisiteEquivalenciesFullfillments.Tables[2];
                    //RevertBack
                    RevertBack(editCourseId);
                    

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saetc-01", ex.Message);
                        }
                    }
                }


            }
            try
            {
                //Get owner session
                if (!string.IsNullOrEmpty(SessionWrapper.c_owner_name))
                {
                    lblOwner.Text = SessionWrapper.c_owner_name;

                }
                //Get Coordinator session
                if (!string.IsNullOrEmpty(SessionWrapper.c_coordinator_name))
                {
                    lblcoordinator.Text = SessionWrapper.c_coordinator_name;
                }
                //Show iconuri file name and show remove button
                if (!string.IsNullOrEmpty(SessionWrapper.iconUrifilename))
                {
                    lnkDownload.Text = SessionWrapper.iconUrifilename;
                    btnRemove.Style.Add("display", "inline");
                    btnSelectIconUri.Style.Add("display", "none");
                }
                else
                {
                    lnkDownload.Text = "";
                    btnRemove.Style.Add("display", "none");
                    btnSelectIconUri.Style.Add("display", "inline");
                }

                //Get Prerequisites session
                gvPrerequisites.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[3];
                gvPrerequisites.DataBind();
                //Get Equivalencies session
                gvEquivalencies.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[4];
                gvEquivalencies.DataBind();
                //Get Fulfillments session
                gvFulfillments.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[5];
                gvFulfillments.DataBind();
                //Get delivery(ies)
                GetDeliveries();
                //Get domain
                gvDomain.DataSource = SystemCatalogBLL.GetCourseDomain(editCourseId);
                gvDomain.DataBind();
                //Get category
                gvCategory.DataSource = SystemCategoriesBLL.GetCourseCategory(editCourseId);
                gvCategory.DataBind();
                //using jquery hide the '-or-' in last row
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
                //Get course locale
                DataTable dtLocale = new DataTable();
                SessionWrapper.Locale.Clear();
                dtLocale = ManageCourseBLL.GetCourseLocale(editCourseId);
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
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }




        }
        /// <summary>
        /// DeleteLocale
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
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
                ManageCourseBLL.DeleteCourseLocale(string.Empty, string.Empty, args.Trim());

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01.aspx(Course locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Course locale)", ex.Message);
                    }
                }
            }


        }
        // Prerequisites table
        private DataTable Prerequisites()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Equivalencies table
        private DataTable Equivalencies()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Fulfillments table
        private DataTable Fulfillments()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        //Delete Icon
        [System.Web.Services.WebMethod]
        public static void DeleteIcon()
        {
            try
            {
                SessionWrapper.iconUri = "";
                SessionWrapper.iconUrifilename = "";
                SystemCatalog deleteIcon = new SystemCatalog();
                deleteIcon.c_course_system_id_pk = editCourseId;
                SystemCatalogBLL.RemoveIcon(deleteIcon);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }
        }
        //Delete Prerequisites
        [System.Web.Services.WebMethod]
        public static void DeletePrerequisite(string args)
        {

            try
            {

                //Delete Prerequisites
                SystemCatalog deletePrerequisite = new SystemCatalog();
                deletePrerequisite.c_related_course_group_id = args.Trim();
                deletePrerequisite.c_course_system_id_pk = editCourseId;
                SystemCatalogBLL.DeletePrerequisite(deletePrerequisite);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }

        }
        //Delete Equivalencies
        [System.Web.Services.WebMethod]
        public static void DeleteEquivalencies(string args)
        {

            try
            {

                //Delete Equivalencies
                SystemCatalog deleteEquivalencies = new SystemCatalog();
                deleteEquivalencies.c_related_course_group_id = args.Trim();
                deleteEquivalencies.c_course_system_id_pk = editCourseId;
                SystemCatalogBLL.DeleteEquivalencies(deleteEquivalencies);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }

        }
        //Delete Fulfillments
        [System.Web.Services.WebMethod]
        public static void DeleteFulfillments(string args)
        {
            try
            {

                //Delete Equivalencies
                SystemCatalog deleteFulfillments = new SystemCatalog();
                deleteFulfillments.c_related_course_group_id = args.Trim();
                deleteFulfillments.c_course_system_id_pk = editCourseId;
                SystemCatalogBLL.DeleteFulfillments(deleteFulfillments);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// DeleteDelivery
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteDelivery(string args)
        {
            try
            {
                SystemCatalogBLL.DeleteDelivery(args.Trim());
                //delete deliveries
                if (SessionWrapper.Deliveries.Rows.Count > 0)
                {

                    var rows = SessionWrapper.Deliveries.Select("c_delivery_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Deliveries.AcceptChanges();
                }
                //delete deliveries sessions
                if (SessionWrapper.DeliverySessions.Rows.Count > 0)
                {
                    var srows = SessionWrapper.DeliverySessions.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in srows)
                        row.Delete();
                    SessionWrapper.DeliverySessions.AcceptChanges();
                }
                //delete temp deliveries sessions
                if (SessionWrapper.TempDeliverySessions.Rows.Count > 0)
                {
                    var strows = SessionWrapper.TempDeliverySessions.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in strows)
                        row.Delete();
                    SessionWrapper.TempDeliverySessions.AcceptChanges();
                }
                //delete resources
                if (SessionWrapper.DeliveryResource.Rows.Count > 0)
                {
                    var resRows = SessionWrapper.DeliveryResource.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in resRows)
                        row.Delete();
                    SessionWrapper.DeliveryResource.AcceptChanges();
                }
                //delete materials
                if (SessionWrapper.DeliveryMaterial.Rows.Count > 0)
                {
                    var matRows = SessionWrapper.DeliveryMaterial.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in matRows)
                        row.Delete();
                    SessionWrapper.DeliveryMaterial.AcceptChanges();
                }
                //delete attachments
                if (SessionWrapper.DeliveryAttachments.Rows.Count > 0)
                {
                    var attRows = SessionWrapper.DeliveryAttachments.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in attRows)
                        row.Delete();
                    SessionWrapper.DeliveryAttachments.AcceptChanges();
                }
                //delete instructors
                if (SessionWrapper.DeliveryInstructor.Rows.Count > 0)
                {
                    var insRows = SessionWrapper.DeliveryInstructor.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in insRows)
                        row.Delete();
                    SessionWrapper.DeliveryInstructor.AcceptChanges();
                }
                //temp delete instructors
                if (SessionWrapper.TempDeliveryInstructor.Rows.Count > 0)
                {
                    var insTempRows = SessionWrapper.TempDeliveryInstructor.Select("c_delivery_id_fk= '" + args.Trim() + "'");
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
                        Logger.WriteToErrorLog("saetc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01.aspx", ex.Message);
                    }
                }
            }


        }

        /// <summary>
        /// Delete Domain
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteDomain(string args)
        {

            try
            {

                //Delete Prerequisites
                SystemCatalog deleteDomain = new SystemCatalog();
                deleteDomain.c_related_domain_id_fk = args.Trim();
                deleteDomain.c_course_system_id_pk = editCourseId;
                SystemCatalogBLL.DeleteDomain(deleteDomain);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }


        }


        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteCategory(string args)
        {

            try
            {

                SystemCategories  deleteCatalog = new SystemCategories();
                deleteCatalog.CategoryID = args.Trim();
                deleteCatalog.s_category_system_id_pk = editCourseId;
                SystemCategoriesBLL.DeleteCategory(deleteCatalog);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }


        }

        /// <summary>
        /// Clear delivery session
        /// </summary>
        private void ClearDeliverySession()
        {

            SessionWrapper.c_delivery_owner_name = string.Empty;
            SessionWrapper.c_delivery_owner_id_fk = string.Empty;
            SessionWrapper.c_delivery_coordinator_id_fk = string.Empty;
            SessionWrapper.c_delivery_coordinator_name = string.Empty;

            SessionWrapper.Deliveries = null;
            SessionWrapper.DeliverySessions = null;
            SessionWrapper.Deliveries = null;
            SessionWrapper.DeliveryAttachments = null;
            SessionWrapper.DeliveryResource = null;
            SessionWrapper.DeliveryMaterial = null;
            SessionWrapper.DeliverySessions = null;
            SessionWrapper.DeliveryInstructor = null;

            SessionWrapper.TempDeliverySessions = null;
            SessionWrapper.TempDeliveryResource = null;
            SessionWrapper.TempDeliveryMaterial = null;
            SessionWrapper.TempDeliveryAttachments = null;
            SessionWrapper.TempDeliveryInstructor = null;

            SessionWrapper.c_delivery_system_id_pk = string.Empty;
            SessionWrapper.c_session_location_id_fk = string.Empty;
            SessionWrapper.c_session_facility_id_fk = string.Empty;
            SessionWrapper.c_session_room_id_fk = string.Empty;
            SessionWrapper.c_location_name = string.Empty;
            SessionWrapper.c_facility_name = string.Empty;
            SessionWrapper.c_room_name = string.Empty;
            SessionWrapper.c_course_system_id_pk = string.Empty;

            SessionWrapper.Reset_Deliveries = null;
            SessionWrapper.Reset_DeliverySessions = null;
            SessionWrapper.Reset_DeliveryAttachments = null;
            SessionWrapper.Reset_DeliveryResource = null;
            SessionWrapper.Reset_DeliveryMaterial = null;
            SessionWrapper.Reset_DeliveryInstructor = null;
            SessionWrapper.Reset_Edit_DeliveryInstructor = null;
            SessionWrapper.Reset_Course_Domain = null;
            SessionWrapper.Reset_Course_Category = null;

            SessionWrapper.Reset_Course_Deliveries = null;
            SessionWrapper.Reset_Course_DeliverySessions = null;
            SessionWrapper.Reset_Course_DeliveryAttachments = null;
            SessionWrapper.Reset_Course_DeliveryResource = null;
            SessionWrapper.Reset_Course_DeliveryMaterial = null;
            SessionWrapper.Reset_Course_DeliveryInstructor = null;

        }
        protected void btnHeaderSaveCourse_Click(object sender, EventArgs e)
        {

            UpdateCourse();
        }
        /// <summary>
        /// Update Course
        /// </summary>
        private void UpdateCourse()
        {
            try
            {
                SystemCatalog CreateCourse = new SystemCatalog();
                CreateCourse.c_course_system_id_pk = editCourseId;
                CreateCourse.c_course_id_pk = txtCourseID.Text;
                CreateCourse.c_course_title = txtTitle.Text;
                CreateCourse.c_course_desc = txtDescription.Value;
                CreateCourse.c_course_abstract = txtAbstract.Value;
                CreateCourse.c_course_version = txtVersion.Text;
                CreateCourse.c_course_owner_id_fk = SessionWrapper.c_course_owner_id_fk;
                CreateCourse.c_course_coordinator_id_fk = SessionWrapper.c_course_coordinator_id_fk;
                //
                // Use int.TryParse on a valid numeric string.
                //
                int tempCost;
                if (int.TryParse(txtcost.Text, out tempCost))
                {
                    CreateCourse.c_course_cost = tempCost;
                }
                else
                {
                    CreateCourse.c_course_cost = null;
                }
                int tempCreditUnits;
                if (int.TryParse(txtCreditUnits.Text, out tempCreditUnits))
                {
                    CreateCourse.c_course_credit_units = tempCreditUnits;
                }
                else
                {
                    CreateCourse.c_course_credit_units = null;
                }
                int tempCreditHours;
                if (int.TryParse(txtCreditHours.Text, out tempCreditHours))
                {
                    CreateCourse.c_course_credit_hours = tempCreditHours;
                }
                else
                {
                    CreateCourse.c_course_credit_hours = null;
                }
                //Upload icon uri
                HttpPostedFile file = default(HttpPostedFile);
                foreach (string files in Request.Files)
                {
                    file = Request.Files[files];
                    string icon_name = null;
                    string icon_extension = null;
                    string icon_guid = Guid.NewGuid().ToString();
                    if (file != null && file.ContentLength > 0)
                    {
                        icon_name = Path.GetFileName(file.FileName);

                        icon_extension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath(_pathIcon + icon_guid + icon_extension));
                        CreateCourse.c_course_icon_uri = icon_guid + icon_extension;

                    }

                }
                //iconuri
                CreateCourse.c_course_icon_uri = SessionWrapper.iconUri;
                CreateCourse.c_course_icon_uri_file_name = SessionWrapper.iconUrifilename;
                CreateCourse.c_course_active_type_id_fk = ddlStatus.SelectedValue;
                CreateCourse.c_course_visible_flag = chkVisible.Checked;
                CreateCourse.c_course_approval_req = chkApprovalRequired.Checked;
                CreateCourse.c_course_approval_id_fk = ddlApprovalRequired.SelectedValue;
                //recurrance
                int tempEvery;
                if (int.TryParse(txtEvery.Text, out tempEvery))
                {
                    CreateCourse.c_cource_recurrance_every = tempEvery;
                }
                else
                {
                    CreateCourse.c_cource_recurrance_every = null;
                }
                CreateCourse.c_cource_recurrance_period = ddlEvery.SelectedValue;
                CreateCourse.c_cource_recurance_date_option = rbtnDate.SelectedValue;
                DateTime? recurancedate = null;
                DateTime temprecurancedate;
                CultureInfo culture = new CultureInfo("en-US");
                if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                {
                    recurancedate = temprecurancedate;
                }
                CreateCourse.c_cource_recurance_date = recurancedate;
                //custom section
                CreateCourse.c_course_custom_01 = txtCustom01.Text;
                CreateCourse.c_course_custom_02 = txtCustom02.Text;
                CreateCourse.c_course_custom_03 = txtCustom03.Text;
                CreateCourse.c_course_custom_04 = txtCustom04.Text;
                CreateCourse.c_course_custom_05 = txtCustom05.Text;
                CreateCourse.c_course_custom_06 = txtCustom06.Text;
                CreateCourse.c_course_custom_07 = txtCustom07.Text;
                CreateCourse.c_course_custom_08 = txtCustom08.Text;
                CreateCourse.c_course_custom_09 = txtCustom09.Text;
                CreateCourse.c_course_custom_10 = txtCustom10.Text;
                CreateCourse.c_course_custom_11 = txtCustom11.Text;
                CreateCourse.c_course_custom_12 = txtCustom12.Text;
                CreateCourse.c_course_custom_13 = txtCustom13.Text;
                //c_course_cert_flag
                CreateCourse.c_course_cert_flag = false;
               
                //c_course_recurrance_grace_days
                int tempGraceDays;
                if (int.TryParse(txtGracePreiod.Text, out tempGraceDays))
                {
                    CreateCourse.c_course_recurrance_grace_days = tempGraceDays;
                }
                else
                {
                    CreateCourse.c_course_recurrance_grace_days = null;
                }
                //c_course_active_flag
                if (ddlStatus.SelectedItem.Text == "Active")
                {
                    CreateCourse.c_course_active_flag = true;
                }
                else
                {
                    CreateCourse.c_course_active_flag = false;
                }

                int error;
                error = SystemCatalogBLL.UpdateCourse(CreateCourse);
                if (error != -2)
                {
                    //Show success message
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");


                }
                else
                {
                    //Show error message 
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_course_id_already_exists_error_text");

                }



            }
            catch (Exception ex)
            {
                //Show error message
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_date_not_updated_error_wrong");
                divSuccess.Style.Add("display", "none");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }
            }
        }
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
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
        protected void btnFooterSaveCourse_Click(object sender, EventArgs e)
        {
            UpdateCourse();
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");

        }
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");
        }
        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset(editCourseId);
        }
        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset(editCourseId);


        }
        ///<summary>
        ///Populate Course
        private void PopulateCourse(string courseId)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetCourse(courseId, SessionWrapper.CultureName);
            lblCreatedBy.Text = Course.c_created_name;
            txtCourseID.Text = Course.c_course_id_pk;
            txtTitle.Text = Course.c_course_title;
            txtDescription.Value = Course.c_course_desc;
            txtAbstract.Value = Course.c_course_abstract;
            txtVersion.Text = Course.c_course_version;
            lblOwner.Text = Course.c_course_owner_name;
            lblcoordinator.Text = Course.c_course_coordinator_name;
            //Set c_course_owner_id_fk
            SessionWrapper.c_course_owner_id_fk = Course.c_course_owner_id_fk;
            //Set c_course_coordinator_id_fk
            SessionWrapper.c_course_coordinator_id_fk = Course.c_course_coordinator_id_fk;
            txtcost.Text = Convert.ToString(Course.c_course_cost);
            txtCreditUnits.Text = Convert.ToString(Course.c_course_credit_units);
            txtCreditHours.Text = Convert.ToString(Course.c_course_credit_hours);
            txtGracePreiod.Text = Convert.ToString(Course.c_course_recurrance_grace_days);
            ddlStatus.SelectedValue = Course.c_course_active_type_id_fk;
            chkVisible.Checked = Course.c_course_visible_flag;
            chkApprovalRequired.Checked = Course.c_course_approval_req;
            if (!string.IsNullOrEmpty(Course.c_course_approval_id_fk))
            {
                if (Course.c_course_approval_id_fk != "0")
                    ddlApprovalRequired.SelectedValue = Course.c_course_approval_id_fk;
            }
            else
            {
                ListItem liFirstItem = new ListItem();
                liFirstItem.Text = "Select";
                liFirstItem.Value = "0";
                ddlApprovalRequired.Items.Insert(0, liFirstItem);

            }
            //recurrance
            txtEvery.Text = Convert.ToString(Course.c_cource_recurrance_every);
            ddlEvery.SelectedValue = Course.c_cource_recurrance_period;
            if (Course.c_cource_recurance_date_option != "")
            {
                rbtnDate.SelectedValue = Course.c_cource_recurance_date_option;
            }
            DateTime? recurancedate = null;
            DateTime temprecurancedate;
            CultureInfo culture = new CultureInfo("en-US");
            if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
            {
                recurancedate = temprecurancedate;
            }
            if (!string.IsNullOrEmpty(Course.c_cource_recurance_date.ToString()))
            {
                txtDate.Text = Convert.ToDateTime(Course.c_cource_recurance_date, culture).ToString("MM/dd/yyyy");
            }
            //icon
            if (!string.IsNullOrEmpty(Course.c_course_icon_uri))
            {
                lnkDownload.Text = Course.c_course_icon_uri_file_name;
                SessionWrapper.iconUri = Course.c_course_icon_uri;
                SessionWrapper.iconUrifilename = Course.c_course_icon_uri_file_name;
                btnRemove.Style.Add("display", "inline");
                btnSelectIconUri.Style.Add("display", "none");

            }
            //custom section
            txtCustom01.Text = Course.c_course_custom_01;
            txtCustom02.Text = Course.c_course_custom_02;
            txtCustom03.Text = Course.c_course_custom_03;
            txtCustom04.Text = Course.c_course_custom_04;
            txtCustom05.Text = Course.c_course_custom_05;
            txtCustom06.Text = Course.c_course_custom_06;
            txtCustom07.Text = Course.c_course_custom_07;
            txtCustom08.Text = Course.c_course_custom_08;
            txtCustom09.Text = Course.c_course_custom_09;
            txtCustom10.Text = Course.c_course_custom_10;
            txtCustom11.Text = Course.c_course_custom_11;
            txtCustom12.Text = Course.c_course_custom_12;
            txtCustom13.Text = Course.c_course_custom_13;
            //c_course_cert_date
            lblCreatedOn.Text = Convert.ToDateTime(Course.c_course_cert_date).ToString("MM/dd/yyyy hh:mm tt");

        }
        ///<summary>
        ///Reset course
        private void Reset(string courseId)
        {
            SystemCatalog courseReset = new SystemCatalog();
            courseReset.c_related_course_group_id = "";
            courseReset.c_course_system_id_pk = courseId;
            ///Delete Prerequisite, Equivalencies and Fulfillments
            SystemCatalogBLL.DeletePrerequisite(courseReset);
            SystemCatalogBLL.DeleteEquivalencies(courseReset);
            SystemCatalogBLL.DeleteFulfillments(courseReset);
            //Prerequisites
            courseReset.c_course_Prerequistist = ConvertDataTableToXml(SessionWrapper.ResetPrerequisite);
            //Equivalencies
            courseReset.c_course_Equivalencies = ConvertDataTableToXml(SessionWrapper.ResetEquivalencies);
            //Fulfillments
            courseReset.c_course_Fulfillments = ConvertDataTableToXml(SessionWrapper.ResetFulfillments);
            SystemCatalogBLL.UpdateSystemCatalogPrerequistist(courseReset);
            SystemCatalogBLL.UpdateSystemCatalogEquivalencies(courseReset);
            SystemCatalogBLL.UpdateSystemCatalogFulfillments(courseReset);
            SystemCatalog createCourseDelivery = new SystemCatalog();
            createCourseDelivery.c_course_id_fk = courseId;
            //delivery(ies)
            createCourseDelivery.c_deliveries = ConvertDataTableToXml(SessionWrapper.Reset_Course_Deliveries);
            //delivery attachment
            createCourseDelivery.c_delivery_attachments = ConvertDataTableToXml(SessionWrapper.Reset_Course_DeliveryAttachments);
            //delivery Resource
            createCourseDelivery.c_delivery_resources = ConvertDataTableToXml(SessionWrapper.Reset_Course_DeliveryResource);
            //delivery Material
            createCourseDelivery.c_delivery_material = ConvertDataTableToXml(SessionWrapper.Reset_Course_DeliveryMaterial);
            //session
            createCourseDelivery.c_sessions = ConvertDataTableToXml(SessionWrapper.Reset_Course_DeliverySessions);
            //session instructor
            createCourseDelivery.c_session_instructor = ConvertDataTableToXml(SessionWrapper.Reset_Course_DeliveryInstructor);
            createCourseDelivery.c_delivery_system_id_pk = string.Empty;
            createCourseDelivery.c_related_domain_id_fk = ConvertDataTableToXml(SessionWrapper.Reset_Course_Domain);
            createCourseDelivery.c_course_category = ConvertDataTableToXml(SessionWrapper.Reset_Course_Category);
            createCourseDelivery.s_course_locale = ConvertDataTableToXml(SessionWrapper.Reset_Course_Locales);
            createCourseDelivery.s_delivery_locale = ConvertDataTableToXml(SessionWrapper.Reset_Delivery_Locales);
            try
            {
                SystemCatalogBLL.InsertDeliveries(createCourseDelivery, true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetc-01", ex.Message);
                    }
                }

            }

            Response.Redirect(Request.RawUrl);
        }
        ///<summary>
        ///Clear course related session
        private void ClearCourseSession()
        {
            ///<summary>
            //clear course related sessoin

            SessionWrapper.c_owner_name = "";
            SessionWrapper.c_coordinator_name = "";
            SessionWrapper.c_course_owner_id_fk = "";
            SessionWrapper.c_course_coordinator_id_fk = "";
            //clear Prerequisite
            SessionWrapper.TempPrerequisite = null;
            SessionWrapper.Prerequisite = null;
            SessionWrapper.PrerequisiteCourseSelected = null;
            SessionWrapper.TempPrerequisiteCourseGuid = "";
            //clear Equivalencies
            SessionWrapper.TempEquivalencies = null;
            SessionWrapper.Equivalencies = null;
            SessionWrapper.EquivalenciesCourseSelected = null;
            SessionWrapper.TempEquivalenciesCourseGuid = "";
            //clear Fulfillments
            SessionWrapper.TempFulfillments = null;
            SessionWrapper.Fulfillments = null;
            SessionWrapper.FulfillmentsCourseSelected = null;
            SessionWrapper.TempFulfillmentsCourseGuid = "";
            //Clear iconuri
            SessionWrapper.iconUri = "";
            SessionWrapper.iconUrifilename = "";
            SessionWrapper.CourseCategory.Clear();
            SessionWrapper.Reset_Course_Category.Clear();
            //clear delivery session
            ClearDeliverySession();
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_pathIcon + SessionWrapper.iconUri);

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.iconUrifilename + "\"");
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
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {

                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":

                    return "image/png";


                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";

            }
        }
        /// <summary>
        /// RevertBack delivery section
        /// </summary>
        /// <param name="courseId"></param>
        private void RevertBack(string courseId)
        {
            //Get course related data and stored in session
            DataSet dsCourseRelatedData = SystemCatalogBLL.GetCourseRelatedData(courseId, SessionWrapper.CultureName);
            //Deliveries
            SessionWrapper.Reset_Course_Deliveries = dsCourseRelatedData.Tables[1]; ;
            //Delivery resources
            SessionWrapper.Reset_Course_DeliveryResource = dsCourseRelatedData.Tables[2];
            //Delivery material
            SessionWrapper.Reset_Course_DeliveryMaterial = dsCourseRelatedData.Tables[3];
            //Delivery attachment
            SessionWrapper.Reset_Course_DeliveryAttachments = dsCourseRelatedData.Tables[4];
            //Delivery Session
            SessionWrapper.Reset_Course_DeliverySessions = dsCourseRelatedData.Tables[5];
            //instructor
            SessionWrapper.Reset_Course_DeliveryInstructor = dsCourseRelatedData.Tables[6];
            //Domain
            SessionWrapper.Reset_Course_Domain = dsCourseRelatedData.Tables[7];
            //Category
            SessionWrapper.Reset_Course_Category = dsCourseRelatedData.Tables[8];
            //Course locale
            SessionWrapper.Reset_Course_Locales = dsCourseRelatedData.Tables[9];
            //delivery locale
            SessionWrapper.Reset_Delivery_Locales = dsCourseRelatedData.Tables[10];
        }
        protected void btnSaveNewVersion_Click(object sender, EventArgs e)
        {
            try
            {
                SystemCatalog course = new SystemCatalog();
                course.c_course_system_id_pk = editCourseId;
                course.c_new_course_system_id_pk = Guid.NewGuid().ToString();
                course.c_course_version = txtNewVersionNumber.Text;
                course.c_category = chkCategorys.Checked;
                course.c_domain = chkDomains.Checked;
                course.c_audiences = chkAudiences.Checked;
                course.c_recurrance = chkRecurrance.Checked;
                course.c_prerequisite = chkPrerequisite.Checked;
                course.c_equivalency = chkEquivalencies.Checked;
                course.c_fulfillment = chkFulfillments.Checked;
                course.c_delivery = chkDeliveries.Checked;
                course.c_course_created_by_id_fk = SessionWrapper.u_userid;
                SystemCatalogBLL.CreateCourseNewVersion(course);
                Response.Redirect("~/SystemHome/Catalog/Course/saetc-01.aspx?id=" + SecurityCenter.EncryptText(course.c_new_course_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saetc-01", ex.Message);
                }

            }
        }
        protected void gvVersionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewVersion = (Button)e.Row.FindControl("btnViewVersion");
                LinkButton lnkViewVersion = (LinkButton)e.Row.FindControl("lnkViewVersion");
                lnkViewVersion.OnClientClick = "window.open('saatc-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) + "','',''); return false;";
                btnViewVersion.OnClientClick = "window.open('saatc-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) + "','',''); return false;";
                //mpVersionList.Show();
            }
        }

        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string c_delivery_id_pk = gvDeliveries.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    Label lblSession = (Label)e.Row.FindControl("lblSession");
                    SystemCatalog sessionDate = new SystemCatalog();
                    sessionDate = SystemCatalogBLL.GetSessionDate(c_delivery_id_pk);
                    if (!string.IsNullOrEmpty(sessionDate.c_session_date_format))
                    {
                        lblSession.Text = sessionDate.c_session_date_format;
                    }
                    else
                    {
                        lblSession.Text = "(Self-paced - Anytime/Anywhere)";
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saetc-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saetc-01", ex.Message);
                }
            }

        }

        
        private void GetDeliveries()
        {
            DataSet dsGetcourseDelivery = new DataSet();
            dsGetcourseDelivery = SystemCatalogBLL.GetCourseDelivery(editCourseId);
            gvDeliveries.DataSource = dsGetcourseDelivery.Tables[0];
            gvDeliveries.DataBind();
        }

       
    }
}