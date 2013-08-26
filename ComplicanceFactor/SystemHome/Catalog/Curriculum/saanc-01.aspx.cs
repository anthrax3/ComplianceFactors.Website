using System;
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

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class saanc_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Catalog/Curriculum/Attachments/";
        private string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            ///<summary>
            ///Hide validation on postback (if user select owner,coordinator,prerequisite,equivalence and fullfillments)
            ///</summary>
            vs_saanc.Style.Add("display", "none");
            if (!IsPostBack)
            {
                try
                {
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Curriculum/sascp-01.aspx>" + "Manage Curriculum" + "</a>&nbsp;" + " >&nbsp;" + "Create Curriculum";

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Curriculum/sascp-01.aspx>" + LocalResources.GetLabel("app_manage_curriculam_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_curriculum_text") + "</a>";


                    // Clear Curriculum Related Session
                    ClearCurriculumeRelatedSession();
                    //Created By
                    lblCreatedBy.Text = SessionWrapper.u_firstname + ' ' + SessionWrapper.u_lastname;
                    //Add column in attachment
                    SessionWrapper.TempCurriculumAttachments = TempDataTables.TempCurriculumattachments();
                    //Add Category Column
                    SessionWrapper.CurriculumCategory = TempDataTables.TempCurriculumCategory();
                    //Add Domain Column
                    SessionWrapper.CurriculumDomain = TempDataTables.TempCurriculumDomain();
                    //Add column in curriculum selected prerequsites sessoin
                    SessionWrapper.PrerequisiteCurriculumSelected = Prerequisites();
                    SessionWrapper.EquivalenciesCurriculumSelected = Equivalencies();
                    SessionWrapper.FulfillmentsCurriculumSelected = Fulfillments();
                    //Bind status
                    ddlStatus.DataSource = SystemCurriculumBLL.GetCurriculumStatus(SessionWrapper.CultureName, "saanc-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind Approval
                    ddlApprovalRequired.DataSource = SystemCurriculumBLL.GetApprovalForCurriculum(SessionWrapper.CultureName);
                    ddlApprovalRequired.DataBind();
                    //Copy Curriculum
                    if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                    {
                        CopyCurriculum(SecurityCenter.DecryptText(Request.QueryString["copy"]));

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
                    SessionWrapper.CurriculumDateTime = tz.s_date_time;
                    lblCreatedOn.Text = SessionWrapper.CurriculumDateTime.ToString("MM/dd/yyyy hh:mm tt");
                    //Bind Curriculam Attchments
                    this.gvCurriculumAttachments.DataSource = (SessionWrapper.TempCurriculumAttachments).DefaultView;
                    this.gvCurriculumAttachments.DataBind();

                }

                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saanc-01", ex.Message);
                        }
                    }
                }

            }
            try
            {
                //Get Owner Session
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_owner_text))
                {
                    lblOwner.Text = SessionWrapper.c_curriculum_owner_text;
                }
                // Get Coordinatoe Session
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_coordinator_text))
                {
                    lblcoordinator.Text = SessionWrapper.c_curriculum_coordinator_text;
                }
                //Show iconuri file name and show remove button
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_icon_uri))
                {
                    lnkDownload.Text = SessionWrapper.c_curriculum_icon_uri_file_name;
                    btnRemove.Style.Add("display", "inline");
                    btnSelectIconUri.Style.Add("display", "none");
                }
                else
                {
                    lnkDownload.Text = "";
                    btnRemove.Style.Add("display", "none");
                    btnSelectIconUri.Style.Add("display", "inline");
                }
                //using jquery hide the '-or-' in last row
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Equivalencies", "lastEquivalenciesrow();", true);
                //Bind Category
                gvCategory.DataSource = SessionWrapper.CurriculumCategory;
                gvCategory.DataBind();
                //Bind Domain
                gvDomain.DataSource = SessionWrapper.CurriculumDomain;
                gvDomain.DataBind();
                //Get Prerequisites session
                gvPrerequisites.DataSource = SessionWrapper.TempCurriculumPrerequisite;
                gvPrerequisites.DataBind();
                //Get Equivalencies session
                gvEquivalencies.DataSource = SessionWrapper.TempCurriculumEquivalencies;
                gvEquivalencies.DataBind();
                //Get Fulfillments session
                gvFulfillments.DataSource = SessionWrapper.TempCurriculumFulfillments;
                gvFulfillments.DataBind();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message);
                    }
                }
            }

        }
        private void CreateCurriculum()
        {
            try
            {
                SystemCurriculum CreateCurriculum = new SystemCurriculum();
                CreateCurriculum.c_curriculum_system_id_pk = Guid.NewGuid().ToString();
                CreateCurriculum.c_curriculum_id_pk = txtCurriculumId.Text;
                CreateCurriculum.c_curriculum_title = txtCurriculumTitle.Text;
                CreateCurriculum.c_curriculum_desc = txtDescription.Value;
                CreateCurriculum.c_curriculum_abstract = txtAbstract.Value;
                CreateCurriculum.c_curriculum_version = txtVersion.Text;
                CreateCurriculum.c_curriculum_owner_id_fk = SessionWrapper.c_curriculum_owner_id_fk;
                CreateCurriculum.c_curriculum_coordinator_id_fk = SessionWrapper.c_curriculum_coordinator_id_fk;
                int tempCost;
                if (int.TryParse(txtcost.Text, out tempCost))
                {
                    CreateCurriculum.c_curriculum_cost = tempCost;
                }
                else
                {
                    CreateCurriculum.c_curriculum_cost = null;
                }

                int tempCreditUnits;
                if (int.TryParse(txtCreditUnits.Text, out tempCreditUnits))
                {
                    CreateCurriculum.c_curriculum_credit_units = tempCreditUnits;
                }
                else
                {
                    CreateCurriculum.c_curriculum_credit_units = null;
                }
                int tempCreditHours;
                if (int.TryParse(txtCreditHours.Text, out tempCreditHours))
                {
                    CreateCurriculum.c_curriculum_credit_hours = tempCreditHours;
                }
                else
                {
                    CreateCurriculum.c_curriculum_credit_hours = null;
                }
                CreateCurriculum.c_curriculum_icon_uri = SessionWrapper.c_curriculum_icon_uri;
                CreateCurriculum.c_curriculum_icon_uri_file_name = SessionWrapper.c_curriculum_icon_uri_file_name;
                CreateCurriculum.c_curriculum_active_type_id_fk = ddlStatus.SelectedValue;
                CreateCurriculum.c_curriculum_visible_flag = chkVisible.Checked;
                CreateCurriculum.c_curriculum_approval_req = chkApprovalRequired.Checked;
                CreateCurriculum.c_curriculum_approval_id_fk = ddlApprovalRequired.SelectedValue;

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

                DateTime? timeofday = null;
                DateTime temptimeofday;
                if (DateTime.TryParseExact(txtCutoffTime.Text, "h:mm tt", culturenew, DateTimeStyles.None, out temptimeofday))
                {
                    timeofday = temptimeofday;
                }

                CreateCurriculum.c_curriculum_available_from_date = availableFrom;
                CreateCurriculum.c_curriculum_available_to_date = availableTo;
                CreateCurriculum.c_curriculum_effective_date = effectiveDate;
                CreateCurriculum.c_curriculum_cut_off_date = cuttoffDate;
                CreateCurriculum.c_curriculum_cut_off_time = timeofday; 

                //recurrance
                int tempEvery;
                if (int.TryParse(txtEvery.Text, out tempEvery))
                {
                    CreateCurriculum.c_curriculum_recurrance_every = tempEvery;
                }
                else
                {
                    CreateCurriculum.c_curriculum_recurrance_every = null;
                }
                CreateCurriculum.c_curriculum_recurrance_period = ddlEvery.SelectedValue;
                CreateCurriculum.c_curriculum_recurance_date_option = rbtnDate.SelectedValue;
                DateTime? recurancedate = null;
                DateTime temprecurancedate;
                CultureInfo culture = new CultureInfo("en-US");
                if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                {
                    recurancedate = temprecurancedate;
                }
                CreateCurriculum.c_curriculum_recurance_date = recurancedate;
                //Prerequisites
                CreateCurriculum.c_curriculum_Prerequistist = ConvertDataTableToXml(SessionWrapper.PrerequisiteCurriculumSelected);
                //Equivalencies
                CreateCurriculum.c_curriculum_Equivalencies = ConvertDataTableToXml(SessionWrapper.EquivalenciesCurriculumSelected);
                //Fulfillments
                CreateCurriculum.c_curriculum_Fulfillments = ConvertDataTableToXml(SessionWrapper.FulfillmentsCurriculumSelected);
                //Domain
                CreateCurriculum.c_curriculum_domain = ConvertDataTableToXml(SessionWrapper.CurriculumDomain);
                //Category
                CreateCurriculum.c_curriculum_category = ConvertDataTableToXml(SessionWrapper.CurriculumCategory);
                //Attchments
                CreateCurriculum.c_curriculum_attachment = ConvertDataTableToXml(SessionWrapper.TempCurriculumAttachments);
                //custom section
                CreateCurriculum.c_curriculum_custom_01 = txtCustom01.Text;
                CreateCurriculum.c_curriculum_custom_02 = txtCustom02.Text;
                CreateCurriculum.c_curriculum_custom_03 = txtCustom03.Text;
                CreateCurriculum.c_curriculum_custom_04 = txtCustom04.Text;
                CreateCurriculum.c_curriculum_custom_05 = txtCustom05.Text;
                CreateCurriculum.c_curriculum_custom_06 = txtCustom06.Text;
                CreateCurriculum.c_curriculum_custom_07 = txtCustom07.Text;
                CreateCurriculum.c_curriculum_custom_08 = txtCustom08.Text;
                CreateCurriculum.c_curriculum_custom_09 = txtCustom09.Text;
                CreateCurriculum.c_curriculum_custom_10 = txtCustom10.Text;
                CreateCurriculum.c_curriculum_custom_11 = txtCustom11.Text;
                CreateCurriculum.c_curriculum_custom_12 = txtCustom12.Text;
                CreateCurriculum.c_curriculum_custom_13 = txtCustom13.Text;
                //c_curriculum_cert_flag
                CreateCurriculum.c_curriculum_cert_date = SessionWrapper.CurriculumDateTime;
                CreateCurriculum.c_curriculum_cert_flag = false;
                //c_curriculum_recurrance_grace_days
                int tempGraceDays;
                if (int.TryParse(txtGracePreiod.Text, out tempGraceDays))
                {
                    CreateCurriculum.c_curriculum_recurrance_grace_days = tempGraceDays;
                }
                else
                {
                    CreateCurriculum.c_curriculum_recurrance_grace_days = null;
                }
                //c_curriculum_active_flag
                if (ddlStatus.SelectedItem.Text == "Active")
                {
                    CreateCurriculum.c_curriculum_active_flag = true;
                }
                else
                {
                    CreateCurriculum.c_curriculum_active_flag = false;
                }
                CreateCurriculum.c_curriculum_created_by_id_fk = SessionWrapper.u_userid;
                int error;
                error = SystemCurriculumBLL.CreateCurriculum(CreateCurriculum);
                if (error != -2)
                {

                    Response.Redirect("~/SystemHome/Catalog/Curriculum/saec-01.aspx?id=" + SecurityCenter.EncryptText(CreateCurriculum.c_curriculum_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    ///<summary>
                    ///Show error message 
                    ///</summary>
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_curriculum_id_already_exist_error_wrong");
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
                        Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message);
                    }
                }
            }
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

        protected void btnHeaderSaveNewCurriculum_Click(object sender, EventArgs e)
        {
            CreateCurriculum();
        }

        protected void btnFooterSaveNewCurriculum_Click(object sender, EventArgs e)
        {
            CreateCurriculum();
        }
        private void ClearCurriculumeRelatedSession()
        {
            SessionWrapper.c_curriculum_owner_id_fk = "";
            SessionWrapper.c_curriculum_owner_text = "";
            SessionWrapper.c_curriculum_coordinator_id_fk = "";
            SessionWrapper.c_curriculum_coordinator_text = "";
            SessionWrapper.c_curriculum_icon_uri = "";
            SessionWrapper.c_curriculum_icon_uri_file_name = "";


            //clear Prerequisite
            SessionWrapper.TempCurriculumPrerequisite = null;
            SessionWrapper.Curriculum_Prerequisite = null;
            SessionWrapper.PrerequisiteCurriculumSelected = null;
            SessionWrapper.TempPrerequisitteCurriculumGuid = "";

            //clear Equivalencies
            SessionWrapper.TempCurriculumEquivalencies = null;
            SessionWrapper.Curriculum_Equivalencies = null;
            SessionWrapper.EquivalenciesCurriculumSelected = null;
            SessionWrapper.TempEquivalenciesCurriculumGuid = "";

            //clear Fulfillments
            SessionWrapper.TempCurriculumFulfillments = null;
            SessionWrapper.Curriculum_Fulfillments = null;
            SessionWrapper.FulfillmentsCurriculumSelected = null;
            SessionWrapper.TempFulfillmentsCurriculumGuid = "";

            //clear IconUri
            SessionWrapper.c_curriculum_icon_uri = "";
            SessionWrapper.c_curriculum_icon_uri_file_name = "";

            //clear Domain
            SessionWrapper.CurriculumDomain = null;
            SessionWrapper.Reset_Curriculum_Domain = null;

            //clear Category
            SessionWrapper.CurriculumCategory = null;


            //Attachments
            SessionWrapper.TempCurriculumAttachments = null;



        }

        //Delete Icon
        [System.Web.Services.WebMethod]
        public static void DeleteIcon()
        {
            try
            {
                SessionWrapper.c_curriculum_icon_uri = "";
                SessionWrapper.c_curriculum_icon_uri_file_name = "";
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message);
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

                //Delete previous selected curriculum
                var rows = SessionWrapper.CurriculumCategory.Select("c_related_category_id_fk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.CurriculumCategory.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message);
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

                //Delete previous selected curriculum
                var rows = SessionWrapper.CurriculumDomain.Select("c_related_domain_id_fk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.CurriculumDomain.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanc-01", ex.Message);
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

                //Delete previous selected Curriculum
                var rows = SessionWrapper.TempCurriculumPrerequisite.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempCurriculumPrerequisite.AcceptChanges();

                var rowsCurriculumelected = SessionWrapper.PrerequisiteCurriculumSelected.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCurriculumelected)
                    row.Delete();
                SessionWrapper.PrerequisiteCurriculumSelected.AcceptChanges();


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

                //Delete previous selected curriculum
                var rows = SessionWrapper.TempCurriculumEquivalencies.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempCurriculumEquivalencies.AcceptChanges();

                var rowsCurriculumSelected = SessionWrapper.EquivalenciesCurriculumSelected.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCurriculumSelected)
                    row.Delete();
                SessionWrapper.EquivalenciesCurriculumSelected.AcceptChanges();


            }
            catch
            {
                //Handle Error
            }
            finally
            {

            }

        }

        //Delete Fullfillments
        [System.Web.Services.WebMethod]
        public static void DeleteFulfillments(string args)
        {

            try
            {

                //Delete previous selected curriculum
                var rows = SessionWrapper.TempCurriculumEquivalencies.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempCurriculumEquivalencies.AcceptChanges();

                var rowsCurriculumSelected = SessionWrapper.EquivalenciesCurriculumSelected.Select("c_related_curriculum_group_id= '" + args.Trim() + "'");
                foreach (var row in rowsCurriculumSelected)
                    row.Delete();
                SessionWrapper.EquivalenciesCurriculumSelected.AcceptChanges();


            }
            catch
            {
                //Handle Error
            }
            finally
            {

            }

        }

        // Prerequisites table
        private DataTable Prerequisites()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Equivalencies table
        private DataTable Equivalencies()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Fulfillments table
        private DataTable Fulfillments()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

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
                        EditDataToTempCurriculumattachments(Convert.ToInt32(hdAttachments.Value), c_file_guid + c_file_extension, c_file_name, SessionWrapper.TempCurriculumAttachments);
                        hdAttachments.Value = "";
                    }
                    else
                    {
                        AddDataToTempCurriculumattachments(SessionWrapper.c_curriculum_system_id_pk, c_file_guid + c_file_extension, c_file_name, SessionWrapper.TempCurriculumAttachments);
                    }
                }
            }
            this.gvCurriculumAttachments.DataSource = (SessionWrapper.TempCurriculumAttachments).DefaultView;
            this.gvCurriculumAttachments.DataBind();
        }

        private void EditDataToTempCurriculumattachments(int rowIndex, string c_curriculum_attachment_file_guid, string c_curriculum_attachment_file_name, DataTable dtTempCurriculumattachments)
        {
            dtTempCurriculumattachments.Rows[rowIndex]["c_curriculum_attachment_file_guid"] = c_curriculum_attachment_file_guid;
            dtTempCurriculumattachments.Rows[rowIndex]["c_curriculum_attachment_file_name"] = c_curriculum_attachment_file_name;
            dtTempCurriculumattachments.AcceptChanges();
        }
        private void AddDataToTempCurriculumattachments(string c_curriculum_id_fk, string c_curriculum_attachment_file_guid, string c_curriculum_attachment_file_name, DataTable dtTempCurriculumattachments)
        {
            DataRow row;
            row = dtTempCurriculumattachments.NewRow();
            if (!string.IsNullOrEmpty(c_curriculum_id_fk))
            {
                row["c_curriculum_id_fk"] = c_curriculum_id_fk;

            }
            else
            {
                row["c_curriculum_id_fk"] = DBNull.Value;
            }
            row["c_curriculum_attachment_file_guid"] = c_curriculum_attachment_file_guid;
            row["c_curriculum_attachment_file_name"] = c_curriculum_attachment_file_name;
            dtTempCurriculumattachments.Rows.Add(row);
        }
        private DataTable dtTempCurriculumattachments()
        {
            DataTable dtTempCurriculumattachments = new DataTable();
            DataColumn dtTempCurriculumattachmentsColumn;
            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attchments_system_id_pk";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_id_fk";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attachment_file_guid";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attachment_file_name";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);
            return dtTempCurriculumattachments;
        }
        protected void gvCurriculumAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvCurriculumAttachments.DataKeys[rowIndex][0].ToString();
                hdAttachments.Value = e.CommandArgument.ToString();
                mpeAttachment.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string attachmentFileId = gvCurriculumAttachments.DataKeys[rowIndex][0].ToString();
                string attachmentFileName = gvCurriculumAttachments.DataKeys[rowIndex][1].ToString();
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
                DeleteDataToTempCurriculumattachments(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.TempCurriculumAttachments);
            }

        }
        private void DeleteDataToTempCurriculumattachments(int rowIndex, DataTable dtTempCurriculumattachments)
        {
            dtTempCurriculumattachments.Rows[rowIndex].Delete();
            dtTempCurriculumattachments.AcceptChanges();
            this.gvCurriculumAttachments.DataSource = (SessionWrapper.TempCurriculumAttachments).DefaultView;
            this.gvCurriculumAttachments.DataBind();
        }
        protected void gvCurriculumAttachments_RowEditing(object sender, GridViewEditEventArgs e)
        {

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

        private void CopyCurriculum(string curriculumId)
        {
            ClearCurriculumeRelatedSession();
            SystemCurriculum Curriculum = new SystemCurriculum();
            Curriculum = SystemCurriculumBLL.GetCurriculum(curriculumId, SessionWrapper.CultureName);
            txtCurriculumId.Text = Curriculum.c_curriculum_id_pk + "_Copy";
            txtCurriculumTitle.Text = Curriculum.c_curriculum_title;
            txtDescription.Value = Curriculum.c_curriculum_desc;
            txtAbstract.Value = Curriculum.c_curriculum_abstract;
            txtVersion.Text = Curriculum.c_curriculum_version;
            //Set c_curriculum_owner_id_fk and owner name
            SessionWrapper.c_curriculum_owner_id_fk = Curriculum.c_curriculum_owner_id_fk;
            SessionWrapper.c_curriculum_owner_text = Curriculum.c_curriculum_owner_name;
            //Set c_curriculum_coordinator_id_fk
            SessionWrapper.c_curriculum_coordinator_id_fk = Curriculum.c_curriculum_coordinator_id_fk;
            SessionWrapper.c_curriculum_coordinator_text = Curriculum.c_curriculum_coordinator_name;
            txtcost.Text = Convert.ToString(Curriculum.c_curriculum_cost);
            txtCreditUnits.Text = Convert.ToString(Curriculum.c_curriculum_credit_units);
            txtCreditHours.Text = Convert.ToString(Curriculum.c_curriculum_credit_hours);
            txtGracePreiod.Text = Convert.ToString(Curriculum.c_curriculum_recurrance_grace_days);
            ddlStatus.SelectedValue = Curriculum.c_curriculum_active_type_id_fk;
            chkVisible.Checked = Curriculum.c_curriculum_visible_flag;
            chkApprovalRequired.Checked = Curriculum.c_curriculum_approval_req;
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_approval_id_fk) || Curriculum.c_curriculum_approval_id_fk != "0")
            {
                ddlApprovalRequired.SelectedValue = Curriculum.c_curriculum_approval_id_fk;
            }
            else
            {
                ListItem liFirstItem = new ListItem();
                liFirstItem.Text = "Select";
                liFirstItem.Value = "0";
                ddlApprovalRequired.Items.Insert(0, liFirstItem);

            }
            //icon
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_icon_uri))
            {
                lnkDownload.Text = Curriculum.c_curriculum_icon_uri_file_name;
                SessionWrapper.c_curriculum_icon_uri = Curriculum.c_curriculum_icon_uri;
                SessionWrapper.c_curriculum_icon_uri_file_name = Curriculum.c_curriculum_icon_uri_file_name;
                btnRemove.Style.Add("display", "inline");
            }
            else
            {
                lnkDownload.Text = "";
                btnRemove.Style.Add("display", "none");
                btnSelectIconUri.Style.Add("display", "inline");
            }
            //recurrance
            txtEvery.Text = Convert.ToString(Curriculum.c_curriculum_recurrance_every);
            ddlEvery.SelectedValue = Curriculum.c_curriculum_recurrance_period;
            if (Curriculum.c_curriculum_recurance_date_option != "")
            {
                rbtnDate.SelectedValue = Curriculum.c_curriculum_recurance_date_option;
            }
            DateTime? recurancedate = null;
            DateTime temprecurancedate;
            CultureInfo culture = new CultureInfo("en-US");
            if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
            {
                recurancedate = temprecurancedate;
            }
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_recurance_date.ToString()))
            {
                txtDate.Text = Convert.ToDateTime(Curriculum.c_curriculum_recurance_date, culture).ToString("MM/dd/yyyy");
            }

            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_available_from_date.ToString()))
            {
                txtAvailableFrom.Text = Convert.ToDateTime(Curriculum.c_curriculum_available_from_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_available_to_date.ToString()))
            {
                txtAvailableTo.Text = Convert.ToDateTime(Curriculum.c_curriculum_available_to_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_effective_date.ToString()))
            {
                txtEffectiveDate.Text = Convert.ToDateTime(Curriculum.c_curriculum_effective_date).ToShortDateString();
            }
            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_cut_off_date.ToString()))
            {
                txtCutOffDate.Text = Convert.ToDateTime(Curriculum.c_curriculum_cut_off_date).ToShortDateString();
            }

            if (!string.IsNullOrEmpty(Curriculum.c_curriculum_cut_off_time_string.ToString()))
            {
                txtCutoffTime.Text = Convert.ToDateTime(Curriculum.c_curriculum_cut_off_time_string).ToShortTimeString();
            }

            //custom section
            txtCustom01.Text = Curriculum.c_curriculum_custom_01;
            txtCustom02.Text = Curriculum.c_curriculum_custom_02;
            txtCustom03.Text = Curriculum.c_curriculum_custom_03;
            txtCustom04.Text = Curriculum.c_curriculum_custom_04;
            txtCustom05.Text = Curriculum.c_curriculum_custom_05;
            txtCustom06.Text = Curriculum.c_curriculum_custom_06;
            txtCustom07.Text = Curriculum.c_curriculum_custom_07;
            txtCustom08.Text = Curriculum.c_curriculum_custom_08;
            txtCustom09.Text = Curriculum.c_curriculum_custom_09;
            txtCustom10.Text = Curriculum.c_curriculum_custom_10;
            txtCustom11.Text = Curriculum.c_curriculum_custom_11;
            txtCustom12.Text = Curriculum.c_curriculum_custom_12;
            txtCustom13.Text = Curriculum.c_curriculum_custom_13;
            //Add column in curriculum related sessoin
            SessionWrapper.PrerequisiteCurriculumSelected = Prerequisites();
            SessionWrapper.EquivalenciesCurriculumSelected = Equivalencies();
            SessionWrapper.FulfillmentsCurriculumSelected = Fulfillments();
            SessionWrapper.ResetCurriculumPrerequisite = Prerequisites();
            SessionWrapper.ResetCurriculumEquivalencies = Equivalencies();
            SessionWrapper.ResetCurriculumFulfillments = Fulfillments();
            ///<summary>
            //Store Prerequisites,Equivalencies and Fulfillments in dataset (For Reset to store in session)
            ///</summary>
            DataSet dsCurriculum = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(curriculumId);
            ///<summary>
            ///On copy change the  c_curriculum_related_group_id column value for prerequisite
            //TempPrequisite
            DataTable dtTempPrerequisite = new DataTable();
            dtTempPrerequisite = dsCurriculum.Tables[3];
            var tempPreCol = dtTempPrerequisite.Columns["c_related_curriculum_group_id"];
            //Prequisite
            DataTable dtPrerequisite = new DataTable();
            dtPrerequisite = dsCurriculum.Tables[0];
            var preCol = dtPrerequisite.Columns["c_related_curriculum_group_id"];
            //Assign c_related_curriculum_group_id
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
            ///On copy change the  c_curriculum_related_group_id column value for Equivalencies
            //TempPrequisite
            DataTable dtTempEquivalencies = new DataTable();
            dtTempEquivalencies = dsCurriculum.Tables[4];
            var tempEquiCol = dtTempEquivalencies.Columns["c_related_curriculum_group_id"];
            //Prequisite
            DataTable dtEquivalencies = new DataTable();
            dtEquivalencies = dsCurriculum.Tables[1];
            var equiCol = dtEquivalencies.Columns["c_related_curriculum_group_id"];
            //Assign c_related_curriculum_group_id
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
            ///On copy change the  c_curriculum_related_group_id column value for Fullfillments
            //TempPrequisite
            DataTable dtTempFullfillments = new DataTable();
            dtTempFullfillments = dsCurriculum.Tables[5];
            var tempFulCol = dtTempFullfillments.Columns["c_related_curriculum_group_id"];
            //Prequisite
            DataTable dtFullfillments = new DataTable();
            dtFullfillments = dsCurriculum.Tables[2];
            var fulCol = dtFullfillments.Columns["c_related_curriculum_group_id"];
            //Assign c_related_curriculum_group_id
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
            SessionWrapper.ResetCurriculumPrerequisite = dtPrerequisite;
            SessionWrapper.PrerequisiteCurriculumSelected = dtPrerequisite;
            //Get Equivalencies session
            SessionWrapper.ResetCurriculumEquivalencies = dtEquivalencies;
            SessionWrapper.EquivalenciesCurriculumSelected = dtEquivalencies;
            //Get Fulfillments session
            SessionWrapper.ResetCurriculumFulfillments = dtFullfillments;
            SessionWrapper.FulfillmentsCurriculumSelected = dtFullfillments;
            //Get Prerequisites session
            SessionWrapper.TempCurriculumPrerequisite = dtTempPrerequisite;
            //Get Equivalencies session
            SessionWrapper.TempCurriculumEquivalencies = dtTempEquivalencies;
            //Get Fulfillments session
            SessionWrapper.TempCurriculumFulfillments = dtTempFullfillments;
            //Get curriculum related data and stored in session
            DataSet dsCurriculumRelatedData = SystemCurriculumBLL.GetCurriculumRelatedData(curriculumId, SessionWrapper.CultureName);
            // Get Category
            DataTable dtCategory = new DataTable();
            dtCategory = dsCurriculumRelatedData.Tables[1];
            // Get Domain
            DataTable dtDomain = new DataTable();
            dtDomain = dsCurriculumRelatedData.Tables[2];
            //Attchments
            DataTable dtAttachments = new DataTable();
            dtAttachments = dsCurriculumRelatedData.Tables[3];
            //Session domain
            SessionWrapper.Reset_Curriculum_Domain = dtDomain;
            SessionWrapper.CurriculumDomain = dtDomain;
            //session Category
            SessionWrapper.Reset_Curriculum_Category = dtCategory;
            SessionWrapper.CurriculumCategory = dtCategory;
            //Session attchments
            SessionWrapper.Reset_Curriculum_Attachments = dtAttachments;
            SessionWrapper.TempCurriculumAttachments = dtAttachments;
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_pathIcon + SessionWrapper.c_curriculum_icon_uri);


            if (System.IO.File.Exists(filePath))
            {

                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.c_curriculum_icon_uri_file_name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = ReturnExtension(file.Extension.ToLower());
                        Response.Write(file.FullName);
                        Response.End();
                        Response.Clear();
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
}

