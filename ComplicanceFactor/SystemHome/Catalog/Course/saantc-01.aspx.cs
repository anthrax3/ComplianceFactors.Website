using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.SystemHome.Catalog.DeliveryPopup;

namespace ComplicanceFactor.SystemHome.Catalog
{
    public partial class saantc_01 : BasePage
    {

        #region "Private Member Variables"
        private string _pathIcon = "~/SystemHome/Catalog/Course/Icons/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<summary>
            ///Hide validation on postback (if user select owner,coordinator,prerequisite,equivalence and fullfillments)
            ///</summary>
            vs_saantc.Style.Add("display", "none");
            if (!IsPostBack)
            {


                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + LocalResources.GetLabel("app_manage_catalog_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_course_text");
                //created by
                lblCreatedBy.Text = SessionWrapper.u_firstname + ' ' + SessionWrapper.u_lastname;
                //clear course related sessoin
                ClearCourseRelatedSession();
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
                // Add Column in Domain Datatable
                SessionWrapper.CourseDomain = TempDataTables.TempDomain();
                // Add Column in Category Datatable
                SessionWrapper.CourseCategory = TempDataTables.TempCategory();
                //Add column in course selected prerequsites sessoin
                SessionWrapper.PrerequisiteCourseSelected = Prerequisites();
                SessionWrapper.EquivalenciesCourseSelected = Equivalencies();
                SessionWrapper.FulfillmentsCourseSelected = Fulfillments();


                try
                {

                    //Bind status
                    ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName,"saantc-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind Approval
                    ddlApprovalRequired.DataSource = SystemCatalogBLL.GetApprovalForCourse(SessionWrapper.CultureName);
                    ddlApprovalRequired.DataBind();
                    ///Copy Course
                    if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                    {
                        CopyCourse(SecurityCenter.DecryptText(Request.QueryString["copy"]));

                    }
                    else
                    {
                        ///Add default item in Approval required dropdownlist
                        ListItem liFirstItem = new ListItem();
                        liFirstItem.Text = "Select";
                        liFirstItem.Value = "0";
                        ddlApprovalRequired.Items.Insert(0, liFirstItem);
                        ddlApprovalRequired.SelectedIndex = 0;
                    }
                    TimeZoneDAO tz = new TimeZoneDAO();
                    tz = TimeZoneBLL.GetDateTime(Convert.ToInt32(SessionWrapper.u_timezone));
                    SessionWrapper.CourseDateTime = tz.s_date_time;
                    lblCreatedOn.Text = SessionWrapper.CourseDateTime.ToString("MM/dd/yyyy hh:mm tt");
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saantc-01", ex.Message);
                        }
                    }
                }
            }

            try
            {
                //Get owner session
                lblOwner.Text = SessionWrapper.c_owner_name;
                lblcoordinator.Text = SessionWrapper.c_coordinator_name;
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
                gvPrerequisites.DataSource = SessionWrapper.TempPrerequisite;
                gvPrerequisites.DataBind();
                //Get Equivalencies session
                gvEquivalencies.DataSource = SessionWrapper.TempEquivalencies;
                gvEquivalencies.DataBind();
                //Get Fulfillments session
                gvFulfillments.DataSource = SessionWrapper.TempFulfillments;
                gvFulfillments.DataBind();
                //Get delivery(ies)
                gvDeliveries.DataSource = SessionWrapper.Deliveries;
                gvDeliveries.DataBind();
                //using jquery hide the '-or-' in last row
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
                //Get domain
                gvDomain.DataSource = SessionWrapper.CourseDomain;
                gvDomain.DataBind();
                //Get Category
                gvCategory.DataSource = SessionWrapper.CourseCategory;
                gvCategory.DataBind();
               

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
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

                //Delete previous selected course
                var rows = SessionWrapper.TempPrerequisite.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempPrerequisite.AcceptChanges();

                var rowsCourseSelected = SessionWrapper.PrerequisiteCourseSelected.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCourseSelected)
                    row.Delete();
                SessionWrapper.PrerequisiteCourseSelected.AcceptChanges();


            }
            catch
            {
                //Handle Error
            }
            finally
            {

            }

        }
        //Delete Equivalencies
        [System.Web.Services.WebMethod]
        public static void DeleteEquivalencies(string args)
        {

            try
            {

                //Delete previous selected course
                var rows = SessionWrapper.TempEquivalencies.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempEquivalencies.AcceptChanges();

                var rowsCourseSelected = SessionWrapper.EquivalenciesCourseSelected.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCourseSelected)
                    row.Delete();
                SessionWrapper.EquivalenciesCourseSelected.AcceptChanges();


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
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

                //Delete previous selected course
                var rows = SessionWrapper.TempFulfillments.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempFulfillments.AcceptChanges();

                var rowsCourseSelected = SessionWrapper.FulfillmentsCourseSelected.Select("c_related_course_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCourseSelected)
                    row.Delete();
                SessionWrapper.FulfillmentsCourseSelected.AcceptChanges();


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
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
                //delete deliveries
                var rows = SessionWrapper.Deliveries.Select("c_delivery_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Deliveries.AcceptChanges();
                //delete deliveries sessions
                var srows = SessionWrapper.DeliverySessions.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                foreach (var row in srows)
                    row.Delete();
                SessionWrapper.DeliverySessions.AcceptChanges();
                //delete temp deliveries sessions
                if (SessionWrapper.TempDeliverySessions.Rows.Count > 0)
                {
                    var strows = SessionWrapper.TempDeliverySessions.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                    foreach (var row in strows)
                        row.Delete();
                    SessionWrapper.TempDeliverySessions.AcceptChanges();
                }

                //delete resources
                var resRows = SessionWrapper.DeliveryResource.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                foreach (var row in resRows)
                    row.Delete();
                SessionWrapper.DeliveryResource.AcceptChanges();
                //delete materials
                var matRows = SessionWrapper.DeliveryMaterial.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                foreach (var row in matRows)
                    row.Delete();
                SessionWrapper.DeliveryMaterial.AcceptChanges();
                //delete attachments
                var attRows = SessionWrapper.DeliveryAttachments.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                foreach (var row in attRows)
                    row.Delete();
                SessionWrapper.DeliveryAttachments.AcceptChanges();
                //delete instructors
                var insRows = SessionWrapper.DeliveryInstructor.Select("c_delivery_id_fk= '" + args.Trim() + "'");
                foreach (var row in insRows)
                    row.Delete();
                SessionWrapper.DeliveryInstructor.AcceptChanges();
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
                        Logger.WriteToErrorLog("saantc.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc.aspx", ex.Message);
                    }
                }
            }


        }
        //Delete Domain
        [System.Web.Services.WebMethod]
        public static void DeleteDomain(string args)
        {

            try
            {

                //Delete previous selected course
                var rows = SessionWrapper.CourseDomain.Select("c_related_domain_id_fk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.CourseDomain.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
                    }
                }
            }


        }
        //Delete Category
        [System.Web.Services.WebMethod]
        public static void DeleteCategory(string args)
        {

            try
            {

                //Delete previous selected course
                var rows = SessionWrapper.CourseCategory.Select("CategoryID= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.CourseCategory.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
                    }
                }
            }


        }
        protected void btnHeaderSaveNewCourse_Click(object sender, EventArgs e)
        {
            SaveNewCourse();
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
        protected void btnFooterSaveNewCourse_Click(object sender, EventArgs e)
        {
            SaveNewCourse();
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");

        }
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/sastcp-01.aspx");
        }
        /// <summary>
        /// Save New course
        /// </summary>
        private void SaveNewCourse()
        {
            try
            {
                SystemCatalog CreateCourse = new SystemCatalog();
                CreateCourse.c_course_system_id_pk = Guid.NewGuid().ToString();
                CreateCourse.c_course_id_pk = txtCourseID.Text;
                CreateCourse.c_course_title = txtTitle.Text;
                CreateCourse.c_course_desc = txtDescription.Value;
                CreateCourse.c_course_abstract = txtAbstract.Value;
                CreateCourse.c_course_version = txtVersion.Text;
                CreateCourse.c_course_owner_id_fk = SessionWrapper.c_course_owner_id_fk;
                CreateCourse.c_course_coordinator_id_fk = SessionWrapper.c_course_coordinator_id_fk;
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
                //Prerequisites
                CreateCourse.c_course_Prerequistist = ConvertDataTableToXml(SessionWrapper.PrerequisiteCourseSelected);
                //Equivalencies
                CreateCourse.c_course_Equivalencies = ConvertDataTableToXml(SessionWrapper.EquivalenciesCourseSelected);
                //Fulfillments
                CreateCourse.c_course_Fulfillments = ConvertDataTableToXml(SessionWrapper.FulfillmentsCourseSelected);
                //Domain
                CreateCourse.c_course_domains = ConvertDataTableToXml(SessionWrapper.CourseDomain);
                //Category
                CreateCourse.c_course_category = ConvertDataTableToXml(SessionWrapper.CourseCategory);
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
                CreateCourse.c_course_cert_date = SessionWrapper.CourseDateTime;
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
                CreateCourse.c_course_created_by_id_fk = SessionWrapper.u_userid;
                int error;
                error = SystemCatalogBLL.CreateCourse(CreateCourse);
                if (error != -2)
                {
                    ///<summary>
                    /// Create Course Delivery 
                    /// <parm>c_course_system_id_pk </parm>
                    /// </summary>
                    CreateCourseDelivery(CreateCourse.c_course_system_id_pk);
                    ///<summary>
                    ///Redirect to saetc-01.aspx for editing course
                    ///</summary>
                    Response.Redirect("~/SystemHome/Catalog/Course/saetc-01.aspx?id=" + SecurityCenter.EncryptText(CreateCourse.c_course_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    ///<summary>S
                    ///Show error message 
                    ///</summary>
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_course_id_already_exist_error_wrong");
                }

            }
            catch (Exception ex)
            {

                ///<summary>
                ///Show error message
                divError.Style.Add("display", "block");
                ///</summary>

                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
                    }
                }
            }
        }
        private void CreateCourseDelivery(string c_course_id_fk)
        {
            SystemCatalog createCourseDelivery = new SystemCatalog();
            createCourseDelivery.c_course_id_fk = c_course_id_fk;
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
            createCourseDelivery.c_related_domain_id_fk = string.Empty;
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
                        Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saantc-01", ex.Message);
                    }
                }

            }

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
        ///Clear course related session
        /// </summary>
        private void ClearCourseRelatedSession()
        {
            SessionWrapper.AuthInstructorCourseId = string.Empty;
            SessionWrapper.c_owner_name = "";
            SessionWrapper.c_coordinator_name = "";
            SessionWrapper.c_course_coordinator_id_fk = "";
            SessionWrapper.c_course_owner_id_fk = "";

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

            //clear Domain
            SessionWrapper.CourseDomain = null;

            //clear Category
            SessionWrapper.CourseCategory = null;
            SessionWrapper.CourseCategory.Clear();
            SessionWrapper.Reset_Course_Category.Clear();
            //clear delivery session
            ClearDeliverySession();
            

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

            SessionWrapper.DeliveryAttachments = null;
            SessionWrapper.DeliveryResource = null;
            SessionWrapper.DeliveryMaterial = null;

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

            SessionWrapper.Reset_Course_Deliveries = null;
            SessionWrapper.Reset_Course_DeliverySessions = null;
            SessionWrapper.Reset_Course_DeliveryAttachments = null;
            SessionWrapper.Reset_Course_DeliveryResource = null;
            SessionWrapper.Reset_Course_DeliveryMaterial = null;
            SessionWrapper.Reset_Course_DeliveryInstructor = null;
            SessionWrapper.Reset_Course_Domain = null;
            SessionWrapper.Reset_Course_Category = null;




        }
        /// <summary>
        ///Copy course
        /// </summary>
        private void CopyCourse(string courseId)
        {
            ClearCourseRelatedSession();
            
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetCourse(courseId,SessionWrapper.CultureName);
            txtCourseID.Text = Course.c_course_id_pk +"_Copy";
            txtTitle.Text = Course.c_course_title;
            txtDescription.Value = Course.c_course_desc;
            txtAbstract.Value = Course.c_course_abstract;
            txtVersion.Text = Course.c_course_version;
            //Set c_course_owner_id_fk and owner name
            SessionWrapper.c_course_owner_id_fk = Course.c_course_owner_id_fk;
            SessionWrapper.c_owner_name = Course.c_course_owner_name;
            //Set c_course_coordinator_id_fk
            SessionWrapper.c_course_coordinator_id_fk = Course.c_course_coordinator_id_fk;
            SessionWrapper.c_coordinator_name = Course.c_course_coordinator_name;
            txtcost.Text = Convert.ToString(Course.c_course_cost);
            txtCreditUnits.Text = Convert.ToString(Course.c_course_credit_units);
            txtCreditHours.Text = Convert.ToString(Course.c_course_credit_hours);
            txtGracePreiod.Text = Convert.ToString(Course.c_course_recurrance_grace_days);
            ddlStatus.SelectedValue = Course.c_course_active_type_id_fk;
            chkVisible.Checked = Course.c_course_visible_flag;
            chkApprovalRequired.Checked = Course.c_course_approval_req;
            if (!string.IsNullOrEmpty(Course.c_course_approval_id_fk) || Course.c_course_approval_id_fk != "0")
            {
                ddlApprovalRequired.SelectedValue = Course.c_course_approval_id_fk;
            }
            else
            {
                ListItem liFirstItem = new ListItem();
                liFirstItem.Text = "Select";
                liFirstItem.Value = "0";
                ddlApprovalRequired.Items.Insert(0, liFirstItem);

            }
            //icon
            if (!string.IsNullOrEmpty(Course.c_course_icon_uri))
            {
                lnkDownload.Text = Course.c_course_icon_uri_file_name;
                SessionWrapper.iconUri = Course.c_course_icon_uri;
                SessionWrapper.iconUrifilename = Course.c_course_icon_uri_file_name;
                btnRemove.Style.Add("display", "inline");
            }
            else
            {
                lnkDownload.Text = "";
                btnRemove.Style.Add("display", "none");
                btnSelectIconUri.Style.Add("display", "inline");
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
            //Add column in course related sessoin
            SessionWrapper.PrerequisiteCourseSelected = Prerequisites();
            SessionWrapper.EquivalenciesCourseSelected = Equivalencies();
            SessionWrapper.FulfillmentsCourseSelected = Fulfillments();
            SessionWrapper.ResetPrerequisite = Prerequisites();
            SessionWrapper.ResetEquivalencies = Equivalencies();
            SessionWrapper.ResetFulfillments = Fulfillments();
            ///<summary>
            //Store Prerequisites,Equivalencies and Fulfillments in dataset (For Reset to store in session)
            ///</summary>
            DataSet dsCourse = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(courseId);
            ///<summary>
            ///On copy change the  c_course_related_group_id column value for prerequisite
            //TempPrequisite
            DataTable dtTempPrerequisite = new DataTable();
            dtTempPrerequisite = dsCourse.Tables[3];
            var tempPreCol = dtTempPrerequisite.Columns["c_related_course_group_id"];
            //Prequisite
            DataTable dtPrerequisite = new DataTable();
            dtPrerequisite = dsCourse.Tables[0];
            var preCol = dtPrerequisite.Columns["c_related_course_group_id"];
            //Assign c_related_course_group_id
            foreach (DataRow tempRow in dtTempPrerequisite.Rows)
            {
                string groupid = Guid.NewGuid().ToString();
                foreach (DataRow row in dtPrerequisite.Rows)
                {
                    if (tempRow[tempPreCol].ToString() == row[preCol].ToString())
                    {

                        row[preCol] = groupid;
                    }
                }
                tempRow[tempPreCol] = groupid;

            }
            dtTempPrerequisite.AcceptChanges();
            dtPrerequisite.AcceptChanges();
            ///<summary>
            ///On copy change the  c_course_related_group_id column value for Equivalencies
            //TempPrequisite
            DataTable dtTempEquivalencies = new DataTable();
            dtTempEquivalencies = dsCourse.Tables[4];
            var tempEquiCol = dtTempEquivalencies.Columns["c_related_course_group_id"];
            //Prequisite
            DataTable dtEquivalencies = new DataTable();
            dtEquivalencies = dsCourse.Tables[1];
            var equiCol = dtEquivalencies.Columns["c_related_course_group_id"];
            //Assign c_related_course_group_id
            foreach (DataRow tempRow in dtTempEquivalencies.Rows)
            {
                string groupid = Guid.NewGuid().ToString();
                foreach (DataRow row in dtEquivalencies.Rows)
                {
                    if (tempRow[tempEquiCol].ToString() == row[equiCol].ToString())
                    {

                        row[equiCol] = groupid;
                    }
                }
                tempRow[tempEquiCol] = groupid;

            }
            dtTempEquivalencies.AcceptChanges();
            dtEquivalencies.AcceptChanges();
            ///<summary>
            ///On copy change the  c_course_related_group_id column value for Fullfillments
            //TempPrequisite
            DataTable dtTempFullfillments = new DataTable();
            dtTempFullfillments = dsCourse.Tables[5];
            var tempFulCol = dtTempFullfillments.Columns["c_related_course_group_id"];
            //Prequisite
            DataTable dtFullfillments = new DataTable();
            dtFullfillments = dsCourse.Tables[2];
            var fulCol = dtFullfillments.Columns["c_related_course_group_id"];
            //Assign c_related_course_group_id
            foreach (DataRow tempRow in dtTempFullfillments.Rows)
            {
                string groupid = Guid.NewGuid().ToString();
                foreach (DataRow row in dtFullfillments.Rows)
                {
                    if (tempRow[tempFulCol].ToString() == row[fulCol].ToString())
                    {

                        row[fulCol] = groupid;
                    }
                }
                tempRow[tempFulCol] = groupid;

            }
            dtTempFullfillments.AcceptChanges();
            dtFullfillments.AcceptChanges();
            //Get Prerequisites session
            SessionWrapper.ResetPrerequisite = dtPrerequisite;
            SessionWrapper.PrerequisiteCourseSelected = dtPrerequisite;
            //Get Equivalencies session
            SessionWrapper.ResetEquivalencies = dtEquivalencies;
            SessionWrapper.EquivalenciesCourseSelected = dtEquivalencies;
            //Get Fulfillments session
            SessionWrapper.ResetFulfillments = dtFullfillments;
            SessionWrapper.FulfillmentsCourseSelected = dtFullfillments;
            //Get Prerequisites session
            SessionWrapper.TempPrerequisite = dtTempPrerequisite;
            //Get Equivalencies session
            SessionWrapper.TempEquivalencies = dtTempEquivalencies;
            //Get Fulfillments session
            SessionWrapper.TempFulfillments = dtTempFullfillments;
            //Get course related data and stored in session
            DataSet dsCourseRelatedData = SystemCatalogBLL.GetCourseRelatedData(courseId, SessionWrapper.CultureName);
            // Get Domain
            DataTable dtDomain = new DataTable();
            dtDomain = dsCourseRelatedData.Tables[7];
            // Get Category
            DataTable dtCategory = new DataTable();
            dtCategory = dsCourseRelatedData.Tables[8];
            //Delivery
            DataTable dtDelivery = new DataTable();
            dtDelivery = dsCourseRelatedData.Tables[1];
            DataTable dtResource = new DataTable();
            dtResource = dsCourseRelatedData.Tables[2];
            DataTable dtMaterial = new DataTable();
            dtMaterial = dsCourseRelatedData.Tables[3];
            DataTable dtAttachments = new DataTable();
            dtAttachments = dsCourseRelatedData.Tables[4];
            DataTable dtSessions = new DataTable();
            dtSessions = dsCourseRelatedData.Tables[5];
            DataTable dtInstructor = new DataTable();
            dtInstructor = dsCourseRelatedData.Tables[6];
            //After copy change the delivery system id and session,because we get the already exsiting delivery system id and session from database (i.e primary key )
            for (int i = 0; i <= dtDelivery.Rows.Count - 1; i++)
            {
                string c_delivery_system_id_pk = Guid.NewGuid().ToString();
                //deliveries
                var deliveryRows = dtDelivery.Select("c_course_id_fk= '" + courseId + "'");
                int rowDeliveryLength = deliveryRows.Length;
                if (rowDeliveryLength > 0)
                {
                    var indexOfRow = dtDelivery.Rows.IndexOf(deliveryRows[i]);

                    //Delivery resources
                    for (int j = 0; j <= dtResource.Rows.Count - 1; j++)
                    {

                        var resourceRows = dtResource.Select("c_delivery_id_fk= '" + dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"] + "'");
                        int rowResourceLength = resourceRows.Length;
                        if (rowResourceLength > 0)
                        {
                            var resourceindexOfRow = dtResource.Rows.IndexOf(resourceRows[0]);
                            if (dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"].ToString().Trim() == dtResource.Rows[resourceindexOfRow]["c_delivery_id_fk"].ToString().Trim())
                            {
                                dtResource.Rows[resourceindexOfRow]["c_delivery_id_fk"] = c_delivery_system_id_pk;
                                dtResource.AcceptChanges();
                            }
                        }
                    }

                    //Delivery Material

                    for (int k = 0; k <= dtMaterial.Rows.Count - 1; k++)
                    {

                        var materialRows = dtMaterial.Select("c_delivery_id_fk= '" + dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"] + "'");
                        int rowMaterialLength = materialRows.Length;
                        if (rowMaterialLength > 0)
                        {
                            var materialindexOfRow = dtMaterial.Rows.IndexOf(materialRows[0]);
                            if (dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"].ToString().Trim() == dtMaterial.Rows[materialindexOfRow]["c_delivery_id_fk"].ToString().Trim())
                            {
                                dtMaterial.Rows[materialindexOfRow]["c_delivery_id_fk"] = c_delivery_system_id_pk;
                                dtMaterial.AcceptChanges();
                            }
                        }
                    }
                    //Delivery attachments
                    for (int l = 0; l <= dtAttachments.Rows.Count - 1; l++)
                    {


                        var attachmentRows = dtAttachments.Select("c_delivery_id_fk= '" + dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"] + "'");
                        int rowAttachmentLength = attachmentRows.Length;
                        if (rowAttachmentLength > 0)
                        {
                            var attachmentindexOfRow = dtAttachments.Rows.IndexOf(attachmentRows[0]);

                            if (dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"].ToString().Trim() == dtAttachments.Rows[attachmentindexOfRow]["c_delivery_id_fk"].ToString().Trim())
                            {
                                dtAttachments.Rows[attachmentindexOfRow]["c_delivery_id_fk"] = c_delivery_system_id_pk;
                                dtAttachments.AcceptChanges();
                            }
                        }
                    }
                    //Delivery session
                    for (int m = 0; m <= dtSessions.Rows.Count - 1; m++)
                    {
                        string c_session_system_id_pk = Guid.NewGuid().ToString();
                        var sessoinRows = dtSessions.Select("c_delivery_id_fk= '" + dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"] + "'");

                        int rowSessionLength = sessoinRows.Length;
                        if (rowSessionLength > 0)
                        {
                            var sessoinindexOfRow = dtSessions.Rows.IndexOf(sessoinRows[0]);

                            for (int n = 0; n <= dtInstructor.Rows.Count - 1; n++)
                            {
                                var instructorRows = dtInstructor.Select("c_session_id_fk= '" + dtSessions.Rows[sessoinindexOfRow]["c_session_system_id_pk"] + "'");
                                int rowInstructorLength = instructorRows.Length;
                                if (rowInstructorLength > 0)
                                {
                                    var instructorindexOfRow = dtInstructor.Rows.IndexOf(instructorRows[0]);

                                    if (dtInstructor.Rows[instructorindexOfRow]["c_session_id_fk"].ToString().Trim() == dtSessions.Rows[sessoinindexOfRow]["c_session_system_id_pk"].ToString().Trim())
                                    {
                                        dtInstructor.Rows[instructorindexOfRow]["c_session_id_fk"] = c_session_system_id_pk;
                                        dtInstructor.AcceptChanges();
                                    }
                                    if (dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"].ToString().Trim() == dtInstructor.Rows[instructorindexOfRow]["c_delivery_id_fk"].ToString().Trim())
                                    {
                                        dtInstructor.Rows[instructorindexOfRow]["c_delivery_id_fk"] = c_delivery_system_id_pk;
                                        dtInstructor.AcceptChanges();
                                    }
                                }
                            }
                            if (dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"].ToString().Trim() == dtSessions.Rows[sessoinindexOfRow]["c_delivery_id_fk"].ToString().Trim())
                            {
                                dtSessions.Rows[sessoinindexOfRow]["c_delivery_id_fk"] = c_delivery_system_id_pk;
                                dtSessions.Rows[sessoinindexOfRow]["c_session_system_id_pk"] = c_session_system_id_pk;
                                dtSessions.AcceptChanges();
                            }

                        }
                    }
                    dtDelivery.Rows[indexOfRow]["c_delivery_system_id_pk"] = c_delivery_system_id_pk;
                    dtDelivery.AcceptChanges();
                }
            }

            SessionWrapper.Reset_Course_Deliveries = dtDelivery;
            SessionWrapper.Deliveries = dtDelivery;
            //Delivery resource
            SessionWrapper.Reset_Course_DeliveryResource = dtResource;
            SessionWrapper.DeliveryResource = dtResource;
            //Delivery material
            SessionWrapper.Reset_Course_DeliveryMaterial = dtMaterial;
            SessionWrapper.DeliveryMaterial = dtMaterial;
            //Delivery attachment
            SessionWrapper.Reset_Course_DeliveryAttachments = dtAttachments;
            SessionWrapper.DeliveryAttachments = dtAttachments;
            //Session
            SessionWrapper.Reset_Course_DeliverySessions = dtSessions;
            SessionWrapper.DeliverySessions = dtSessions;
            //Session instructor
            SessionWrapper.Reset_Course_DeliveryInstructor = dtInstructor;
            SessionWrapper.DeliveryInstructor = dtInstructor;
            //Session domain
            SessionWrapper.Reset_Course_Domain = dtDomain;
            SessionWrapper.CourseDomain = dtDomain;
            //session Category
            SessionWrapper.Reset_Course_Category = dtCategory;
            SessionWrapper.CourseCategory = dtCategory;
        }
        /// <summary>
        ///create prerequisites
        /// </summary>
        private void AddDataToPrerequisites(string c_related_course_id_fk, string c_course_text, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Add prerequisites function

            DataRow row;
            row = dtTempPrerequisites.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempPrerequisiteCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempPrerequisites.Rows.Add(row);
        }
        /// <summary>
        ///create Equivalencies
        /// </summary>
        private void AddDataToEquivalencies(string c_related_course_id_fk, string c_course_text, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempEquivalencies.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempEquivalenciesCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempEquivalencies.Rows.Add(row);
        }
        /// <summary>
        ///create fulfillments
        /// </summary>
        private void AddDataToFulfillments(string c_related_course_id_fk, string c_course_text, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempFulfillments.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempFulfillmentsCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempFulfillments.Rows.Add(row);
        }
        protected void btnHeaderReset_Click1(object sender, EventArgs e)
        {
            Reset();
        }
        protected void btnFooterReset_Click1(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Reset
        /// </summary>
        private void Reset()
        {
            //if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
            // {

            //copy course
            //CopyCourse(SecurityCenter.DecryptText(Request.QueryString["copy"]));

            //try
            //{
            //    //Get owner session
            //    lblOwner.Text = SessionWrapper.c_owner_name;
            //    lblcoordinator.Text = SessionWrapper.c_coordinator_name;
            //    //Show iconuri file name and show remove button
            //    if (!string.IsNullOrEmpty(SessionWrapper.iconUrifilename))
            //    {
            //        lnkDownload.Text = SessionWrapper.iconUrifilename;
            //        btnRemove.Style.Add("display", "inline");
            //        btnSelectIconUri.Style.Add("display", "none");
            //    }
            //    else
            //    {
            //        lnkDownload.Text = "";
            //        btnRemove.Style.Add("display", "none");
            //        btnSelectIconUri.Style.Add("display", "inline");
            //    }
            //    //Get Prerequisites session
            //    gvPrerequisites.DataSource = SessionWrapper.TempPrerequisite;
            //    gvPrerequisites.DataBind();
            //    //Get Equivalencies session
            //    gvEquivalencies.DataSource = SessionWrapper.TempEquivalencies;
            //    gvEquivalencies.DataBind();
            //    //Get Fulfillments session
            //    gvFulfillments.DataSource = SessionWrapper.TempFulfillments;
            //    gvFulfillments.DataBind();
            //    //using jquery hide the '-or-' in last row
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);

            //}
            //catch (Exception ex)
            //{
            //    //TODO: Show user friendly error here
            //    //Log here
            //    if (ConfigurationWrapper.LogErrors == true)
            //    {
            //        if (ex.InnerException != null)
            //        {
            //            Logger.WriteToErrorLog("saantc-01", ex.Message, ex.InnerException.Message);
            //        }
            //        else
            //        {
            //            Logger.WriteToErrorLog("saantc-01", ex.Message);
            //        }
            //    }
            //}


            //}
            //else
            //{
            Response.Redirect(Request.RawUrl);
            // ClearCourseRelatedSession();

            //txtCourseID.Text = "";
            //txtTitle.Text = "";
            //txtDescription.Value = "";
            //txtAbstract.Value = "";
            //lblOwner.Text = "";
            //lblcoordinator.Text = "";
            //txtcost.Text = "";
            //txtCreditUnits.Text = "";
            //txtCreditHours.Text = "";
            //lnkDownload.Text = "";
            //btnRemove.Style.Add("display", "none");
            //btnSelectIconUri.Style.Add("display", "inline");
            //ddlStatus.SelectedIndex = 0;
            //chkApprovalRequired.Checked = false;
            //chkVisible.Checked = false;
            //ddlApprovalRequired.SelectedIndex = 0;
            //txtEvery.Text = "";
            //txtGracePreiod.Text = "";
            //txtDate.Text = "";
            //ddlEvery.SelectedIndex = 0;
            //rbtnDate.ClearSelection();

            //txtVersion.Text = "";

            ////custom section
            //txtCustom01.Text = "";
            //txtCustom02.Text = "";
            //txtCustom03.Text = "";
            //txtCustom04.Text = "";
            //txtCustom05.Text = "";
            //txtCustom06.Text = "";
            //txtCustom07.Text = "";
            //txtCustom08.Text = "";
            //txtCustom09.Text = "";
            //txtCustom10.Text = "";
            //txtCustom11.Text = "";
            //txtCustom12.Text = "";
            //txtCustom13.Text = "";

            //gvPrerequisites.DataSource = null;
            //gvPrerequisites.DataBind();

            //gvEquivalencies.DataSource = null;
            //gvEquivalencies.DataBind();

            //gvFulfillments.DataSource = null;
            //gvFulfillments.DataBind();

            // }
        }

        protected void gvDeliveries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string c_delivery_id_pk = gvDeliveries.DataKeys[e.Row.RowIndex].Values[0].ToString();
                Label lblSession = (Label)e.Row.FindControl("lblSession");
                DataView dvSession = new DataView(SessionWrapper.DeliverySessions);
                dvSession.RowFilter = "c_delivery_id_fk ='" + c_delivery_id_pk +"'";
                dvSession.Sort = "c_session_start_date";


            }
        }
    }
}