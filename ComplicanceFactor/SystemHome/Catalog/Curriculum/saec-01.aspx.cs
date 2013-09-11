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
    public partial class saec_01 : System.Web.UI.Page
    {
        #region "Private Member Variables"
        private string _attachmentpath = "~/SystemHome/Catalog/Curriculum/Attachments/";
        private static string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        #endregion
        private static string editCurriculumId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<summary>
            ///Hide validation on postback (if user select owner,coordinator,prerequisite,equivalence and fullfillments)
            ///</summary>
             vs_saec.Style.Add("display", "none");

             ///<summary>
             //Get Curriculum id
             /// </summary>
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                editCurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                hdCurriculumId.Value = editCurriculumId;
                //SessionWrapper.AuthInstructorcurriculumId = editcurriculumId;
                
            }
            ///<summary>
            //Store Prerequisites,Equivalencies and Fulfillments in dataset (For Reset to store in session)
            ///</summary>
            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(editCurriculumId);
            if (!Page.IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Curriculum/sascp-01.aspx>" + "Manage Curriculum" + "</a>&nbsp;" + " >&nbsp;" + "Edit Curriculum";

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Curriculum/sascp-01.aspx>" + LocalResources.GetLabel("app_manage_curriculam_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_curriculum_text") + "</a>";

              
                ///Show success message
                if (!string.IsNullOrEmpty(Request.QueryString["arc"]))
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_archieved_text");

                }
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "Block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    
                }
                
                if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editCurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                }
                try
                {
                    //bind previous version list
                    gvVersionList.DataSource = SystemCurriculumBLL.GetCurriculumVersionList(editCurriculumId, Convert.ToInt32(SessionWrapper.u_timezone));
                    gvVersionList.DataBind();
                    //ClearSession
                    ClearcurriculumSession();
                    //Bind status
                    ddlStatus.DataSource = SystemCurriculumBLL.GetCurriculumStatus(SessionWrapper.CultureName, "saec-01");
                    ddlStatus.DataBind();
                    //Bind Approval
                    ddlApprovalRequired.DataSource = SystemCurriculumBLL.GetApprovalForCurriculum(SessionWrapper.CultureName);
                    ddlApprovalRequired.DataBind();
                    //Bind Curriculum type
                    ddlCurriculumType.DataSource = SystemCurriculumBLL.GetCurriculumType(SessionWrapper.CultureName);
                    ddlCurriculumType.DataBind();
                    //Add column in curriculum related sessoin
                    SessionWrapper.PrerequisiteCurriculumSelected = Prerequisites();
                    SessionWrapper.EquivalenciesCurriculumSelected = Equivalencies();
                    SessionWrapper.FulfillmentsCurriculumSelected = Fulfillments();
                    SessionWrapper.ResetCurriculumPrerequisite = Prerequisites();
                    SessionWrapper.ResetCurriculumEquivalencies = Equivalencies();
                    SessionWrapper.ResetCurriculumFulfillments = Fulfillments();
                    //Get Prerequisites session
                    SessionWrapper.ResetCurriculumPrerequisite = dsprerequisiteEquivalenciesFullfillments.Tables[0];
                    //Get Equivalencies session
                    SessionWrapper.ResetCurriculumEquivalencies = dsprerequisiteEquivalenciesFullfillments.Tables[1];
                    //Get Fulfillments session
                    SessionWrapper.ResetCurriculumFulfillments = dsprerequisiteEquivalenciesFullfillments.Tables[2];
                    //Populate Curriculum
                    PopulateCurriculum(editCurriculumId);
                    //SessionWrapper.TempCurriculumAttachments = TempDeliveryDataTable.TempCurriculumattachments();
                    ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                    ddlLocale.DataBind();
                    //Attchenents
                    this.gvCurriculumAttachments.DataSource = SystemCurriculumBLL.GetCurriculumAttchments(editCurriculumId);
                    this.gvCurriculumAttachments.DataBind();
                    //RevertBack
                    RevertBack(editCurriculumId);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saec-01", ex.Message);
                        }
                    }
                }

            }
            try
            {  //Get owner session
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_owner_text))
                {
                    lblOwner.Text = SessionWrapper.c_curriculum_owner_text;

                }
                //Get Coordinator session
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_coordinator_text))
                {
                    lblcoordinator.Text = SessionWrapper.c_curriculum_coordinator_text;
                }
                //Show iconuri file name and show remove button
                if (!string.IsNullOrEmpty(SessionWrapper.c_curriculum_icon_uri_file_name))
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
                gvCategory.DataSource = SystemCurriculumBLL.GetCurriculumCatgory(editCurriculumId);
                gvCategory.DataBind();
                //Bind Domian
                gvDomain.DataSource = SystemCurriculumBLL.GetCurriculumDomain(editCurriculumId);
                gvDomain.DataBind();
                //Bind Audience
                gvAudience.DataSource = SystemCurriculumBLL.GetCurriculumAudiences(editCurriculumId);
                gvAudience.DataBind();
                //Get Prerequisites
                gvPrerequisites.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[3];
                gvPrerequisites.DataBind();
                //Get Equivalencies
                gvEquivalencies.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[4];
                gvEquivalencies.DataBind();
                //Get Fulfillments
                gvFulfillments.DataSource = dsprerequisiteEquivalenciesFullfillments.Tables[5];
                gvFulfillments.DataBind();
                //Get Path
                DataSet dsCurriculumPath = SystemCurriculumBLL.GetCurriculumPathCourseSection(editCurriculumId, string.Empty);
                gvPath.DataSource = dsCurriculumPath.Tables[0];
                gvPath.DataBind();
                //Get Recert Path Section
                DataSet dsCurriculumRecertPath = SystemCurriculumBLL.GetCurriculumRecertPathCourseSection(editCurriculumId, string.Empty);
                gvRecertPath.DataSource = dsCurriculumRecertPath.Tables[0];
                gvRecertPath.DataBind();
                //Get curriculum locale
                DataTable dtLocale = new DataTable();
                SessionWrapper.Locale.Clear();
                dtLocale = SystemCurriculumBLL.GetCurriculumLocale(editCurriculumId);
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
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }
            
        }

        //Populate Curriculum
        private void PopulateCurriculum(string editCurriculumId)
        {
            try
            {
                SystemCurriculum curriculum = new SystemCurriculum();
                curriculum = SystemCurriculumBLL.GetCurriculum(editCurriculumId,SessionWrapper.CultureName);

                txtCurriculumId.Text = curriculum.c_curriculum_id_pk;
                txtCurriculumTitle.Text = curriculum.c_curriculum_title;
                txtDescription.Value = curriculum.c_curriculum_desc;
                txtAbstract.Value = curriculum.c_curriculum_abstract;
                txtVersion.Text = curriculum.c_curriculum_version;
                lblOwner.Text = curriculum.c_curriculum_owner_name;
                lblcoordinator.Text = curriculum.c_curriculum_coordinator_name;
                //Set c_curriculum_owner_id_fk
                SessionWrapper.c_curriculum_owner_id_fk = curriculum.c_curriculum_owner_id_fk;
                //Set c_curriculum_coordinator_id_fk
                SessionWrapper.c_curriculum_coordinator_id_fk = curriculum.c_curriculum_coordinator_id_fk;
                txtcost.Text = Convert.ToString(curriculum.c_curriculum_cost);
                txtCreditUnits.Text = Convert.ToString(curriculum.c_curriculum_credit_units);
                txtCreditHours.Text = Convert.ToString(curriculum.c_curriculum_credit_hours);
                txtGracePreiod.Text = Convert.ToString(curriculum.c_curriculum_recurrance_grace_days);
                ddlStatus.SelectedValue = curriculum.c_curriculum_active_type_id_fk;
                chkVisible.Checked = curriculum.c_curriculum_visible_flag;
                chkApprovalRequired.Checked = curriculum.c_curriculum_approval_req;
                if (!string.IsNullOrEmpty(curriculum.c_curriculum_approval_id_fk))
                {
                    if (curriculum.c_curriculum_approval_id_fk != "0")
                    {
                       ddlApprovalRequired.SelectedValue = curriculum.c_curriculum_approval_id_fk;  
                    }
                }
                else
                {
                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "Select";
                    liFirstItem.Value = "0";
                    ddlApprovalRequired.Items.Insert(0, liFirstItem);

                }


                if (!string.IsNullOrEmpty(curriculum.c_curriculum_type_id_fk))
                {
                    if (curriculum.c_curriculum_type_id_fk != "0")
                    {
                        ddlCurriculumType.SelectedValue = curriculum.c_curriculum_type_id_fk;
                    }
                }
                else
                {
                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "Select";
                    liFirstItem.Value = "0";
                    ddlCurriculumType.Items.Insert(0, liFirstItem);

                }


                //recurrance
                txtEvery.Text = Convert.ToString(curriculum.c_curriculum_recurrance_every);
                ddlEvery.SelectedValue = curriculum.c_curriculum_recurrance_period;
                if (curriculum.c_curriculum_recurance_date_option != "")
                {
                    rbtnDate.SelectedValue = curriculum.c_curriculum_recurance_date_option;
                }
                DateTime? recurancedate = null;
                DateTime temprecurancedate;
                CultureInfo culture = new CultureInfo("en-US");
                if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                {
                    recurancedate = temprecurancedate;
                }
                if (!string.IsNullOrEmpty(curriculum.c_curriculum_recurance_date.ToString()))
                {
                    txtDate.Text = Convert.ToDateTime(curriculum.c_curriculum_recurance_date, culture).ToString("MM/dd/yyyy");
                }
                //icon
                if (!string.IsNullOrEmpty(curriculum.c_curriculum_icon_uri))
                {
                    lnkDownload.Text = curriculum.c_curriculum_icon_uri_file_name;
                    SessionWrapper.c_curriculum_icon_uri = curriculum.c_curriculum_icon_uri;
                    SessionWrapper.c_curriculum_icon_uri_file_name = curriculum.c_curriculum_icon_uri_file_name;
                    btnRemove.Style.Add("display", "inline");
                    btnSelectIconUri.Style.Add("display", "none");

                }

                if (!string.IsNullOrEmpty(curriculum.c_curriculum_recurance_date.ToString()))
                {
                    txtDate.Text = Convert.ToDateTime(curriculum.c_curriculum_recurance_date, culture).ToString("MM/dd/yyyy");
                }

                if (!string.IsNullOrEmpty(curriculum.c_curriculum_available_from_date.ToString()))
                {
                    txtAvailableFrom.Text = Convert.ToDateTime(curriculum.c_curriculum_available_from_date).ToShortDateString();
                }

                if (!string.IsNullOrEmpty(curriculum.c_curriculum_available_to_date.ToString()))
                {
                    txtAvailableTo.Text = Convert.ToDateTime(curriculum.c_curriculum_available_to_date).ToShortDateString();
                }
                if (!string.IsNullOrEmpty(curriculum.c_curriculum_effective_date.ToString()))
                {
                    txtEffectiveDate.Text = Convert.ToDateTime(curriculum.c_curriculum_effective_date).ToShortDateString();
                }
                if (!string.IsNullOrEmpty(curriculum.c_curriculum_cut_off_date.ToString()))
                {
                    txtCutOffDate.Text = Convert.ToDateTime(curriculum.c_curriculum_cut_off_date).ToShortDateString();
                }

                if (!string.IsNullOrEmpty(curriculum.c_curriculum_cut_off_time_string))
                {
                    txtCutoffTime.Text = Convert.ToDateTime(curriculum.c_curriculum_cut_off_time_string).ToShortTimeString();
                }
                
                //custom section
                txtCustom01.Text = curriculum.c_curriculum_custom_01;
                txtCustom02.Text = curriculum.c_curriculum_custom_02;
                txtCustom03.Text = curriculum.c_curriculum_custom_03;
                txtCustom04.Text = curriculum.c_curriculum_custom_04;
                txtCustom05.Text = curriculum.c_curriculum_custom_05;
                txtCustom06.Text = curriculum.c_curriculum_custom_06;
                txtCustom07.Text = curriculum.c_curriculum_custom_07;
                txtCustom08.Text = curriculum.c_curriculum_custom_08;
                txtCustom09.Text = curriculum.c_curriculum_custom_09;
                txtCustom10.Text = curriculum.c_curriculum_custom_10;
                txtCustom11.Text = curriculum.c_curriculum_custom_11;
                txtCustom12.Text = curriculum.c_curriculum_custom_12;
                txtCustom13.Text = curriculum.c_curriculum_custom_13;
                //c_curriculum_cert_date
                lblCreatedOn.Text = Convert.ToDateTime(curriculum.c_curriculum_cert_date).ToString("MM/dd/yyyy hh:mm tt");
                lblCreatedBy.Text = curriculum.c_created_name;

                
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }
        }
        //Update Curriculum
        private void UpdateCurriculum()
        {
            try
            {
                SystemCurriculum UpdateCurriculum = new SystemCurriculum();
                UpdateCurriculum.c_curriculum_system_id_pk = editCurriculumId;
                UpdateCurriculum.c_curriculum_id_pk = txtCurriculumId.Text;
                UpdateCurriculum.c_curriculum_title = txtCurriculumTitle.Text;
                UpdateCurriculum.c_curriculum_desc = txtDescription.Value;
                UpdateCurriculum.c_curriculum_abstract = txtAbstract.Value;
                UpdateCurriculum.c_curriculum_version = txtVersion.Text;
                UpdateCurriculum.c_curriculum_owner_id_fk = SessionWrapper.c_curriculum_owner_id_fk;
                UpdateCurriculum.c_curriculum_coordinator_id_fk = SessionWrapper.c_curriculum_coordinator_id_fk;
                //
                // Use int.TryParse on a valid numeric string.
                //
                int tempCost;
                if (int.TryParse(txtcost.Text, out tempCost))
                {
                    UpdateCurriculum.c_curriculum_cost = tempCost;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_cost = null;
                }
                int tempCreditUnits;
                if (int.TryParse(txtCreditUnits.Text, out tempCreditUnits))
                {
                    UpdateCurriculum.c_curriculum_credit_units = tempCreditUnits;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_credit_units = null;
                }
                int tempCreditHours;
                if (int.TryParse(txtCreditHours.Text, out tempCreditHours))
                {
                    UpdateCurriculum.c_curriculum_credit_hours = tempCreditHours;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_credit_hours = null;
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
                        UpdateCurriculum.c_curriculum_icon_uri = icon_guid + icon_extension;

                    }

                }
                //iconuri
                UpdateCurriculum.c_curriculum_icon_uri = SessionWrapper.c_curriculum_icon_uri;
                UpdateCurriculum.c_curriculum_icon_uri_file_name = SessionWrapper.c_curriculum_icon_uri_file_name;
                UpdateCurriculum.c_curriculum_active_type_id_fk = ddlStatus.SelectedValue;
                UpdateCurriculum.c_curriculum_visible_flag = chkVisible.Checked;
                UpdateCurriculum.c_curriculum_approval_req = chkApprovalRequired.Checked;
                UpdateCurriculum.c_curriculum_approval_id_fk = ddlApprovalRequired.SelectedValue;
                UpdateCurriculum.c_curriculum_type_id_fk = ddlCurriculumType.SelectedValue;
                //recurrance
                int tempEvery;
                if (int.TryParse(txtEvery.Text, out tempEvery))
                {
                    UpdateCurriculum.c_curriculum_recurrance_every = tempEvery;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_recurrance_every = null;
                }
                UpdateCurriculum.c_curriculum_recurrance_period = ddlEvery.SelectedValue;
                UpdateCurriculum.c_curriculum_recurance_date_option = rbtnDate.SelectedValue;
                DateTime? recurancedate = null;
                DateTime temprecurancedate;
                CultureInfo culture = new CultureInfo("en-US");
                if (DateTime.TryParseExact(txtDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out temprecurancedate))
                {
                    recurancedate = temprecurancedate;
                }
                UpdateCurriculum.c_curriculum_recurance_date = recurancedate;

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

                UpdateCurriculum.c_curriculum_available_from_date = availableFrom;
                UpdateCurriculum.c_curriculum_available_to_date = availableTo;
                UpdateCurriculum.c_curriculum_effective_date = effectiveDate;
                UpdateCurriculum.c_curriculum_cut_off_date = cuttoffDate;
                UpdateCurriculum.c_curriculum_cut_off_time = timeofday; 
                //custom section
                UpdateCurriculum.c_curriculum_custom_01 = txtCustom01.Text;
                UpdateCurriculum.c_curriculum_custom_02 = txtCustom02.Text;
                UpdateCurriculum.c_curriculum_custom_03 = txtCustom03.Text;
                UpdateCurriculum.c_curriculum_custom_04 = txtCustom04.Text;
                UpdateCurriculum.c_curriculum_custom_05 = txtCustom05.Text;
                UpdateCurriculum.c_curriculum_custom_06 = txtCustom06.Text;
                UpdateCurriculum.c_curriculum_custom_07 = txtCustom07.Text;
                UpdateCurriculum.c_curriculum_custom_08 = txtCustom08.Text;
                UpdateCurriculum.c_curriculum_custom_09 = txtCustom09.Text;
                UpdateCurriculum.c_curriculum_custom_10 = txtCustom10.Text;
                UpdateCurriculum.c_curriculum_custom_11 = txtCustom11.Text;
                UpdateCurriculum.c_curriculum_custom_12 = txtCustom12.Text;
                UpdateCurriculum.c_curriculum_custom_13 = txtCustom13.Text;
                //c_curriculum_cert_flag
                UpdateCurriculum.c_curriculum_cert_flag = false;
               
                //c_curriculum_recurrance_grace_days
                int tempGraceDays;
                if (int.TryParse(txtGracePreiod.Text, out tempGraceDays))
                {
                    UpdateCurriculum.c_curriculum_recurrance_grace_days = tempGraceDays;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_recurrance_grace_days = null;
                }
                //c_curriculum_active_flag
                if (ddlStatus.SelectedItem.Text == "Active")
                {
                    UpdateCurriculum.c_curriculum_active_flag = true;
                }
                else
                {
                    UpdateCurriculum.c_curriculum_active_flag = false;
                }

                int error;
                error = SystemCurriculumBLL.UpdateCurriculum(UpdateCurriculum);
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
                    divError.InnerHtml= LocalResources.GetText("app_curriculum_id_already_exist_error_wrong");

                }



            }
            catch (Exception ex)
            {
                //Show error message
                divError.Style.Add("display", "block");
                LocalResources.GetText("app_date_not_updated_error_wrong");
                divSuccess.Style.Add("display", "none");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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

                SystemCurriculum deleteCatalog = new SystemCurriculum();
                deleteCatalog.c_related_category_id_fk = args.Trim();
                deleteCatalog.c_curriculum_id_fk = editCurriculumId;
                SystemCurriculumBLL.DeleteCategory(deleteCatalog);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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
                SystemCurriculum deleteDomain = new SystemCurriculum();
                deleteDomain.c_related_domain_id_fk = args.Trim();
                deleteDomain.c_domain_id_fk = editCurriculumId;
                SystemCurriculumBLL.DeleteDomain(deleteDomain);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }


        }
        //Delete Icon
        [System.Web.Services.WebMethod]
        public static void DeleteIcon()
        {
            try
            {
                SessionWrapper.c_curriculum_icon_uri = "";
                SessionWrapper.c_curriculum_icon_uri_file_name = "";
                SystemCurriculum deleteIcon = new SystemCurriculum();
                deleteIcon.c_curriculum_system_id_pk = editCurriculumId;
                SystemCurriculumBLL.RemoveIcon(deleteIcon);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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
                SystemCurriculum deletePrerequisite = new SystemCurriculum();
                deletePrerequisite.c_related_curriculum_group_id = args.Trim();
                deletePrerequisite.c_curriculum_system_id_pk = editCurriculumId;
                SystemCurriculumBLL.DeletePrerequisite(deletePrerequisite);
               



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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
                SystemCurriculum deleteEquivalencies = new SystemCurriculum();
                deleteEquivalencies.c_related_curriculum_group_id = args.Trim();
                deleteEquivalencies.c_curriculum_system_id_pk = editCurriculumId;
                SystemCurriculumBLL.DeleteEquivalencies(deleteEquivalencies);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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
                SystemCurriculum deleteFulfillments = new SystemCurriculum();
                deleteFulfillments.c_related_curriculum_group_id = args.Trim();
                deleteFulfillments.c_curriculum_system_id_pk = editCurriculumId;
                SystemCurriculumBLL.DeleteFulfillments(deleteFulfillments);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
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
                    var rows = SessionWrapper.Locale.Select("s_curriculum_locales_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                SystemCurriculumBLL.DeleteCurriculumLocale(string.Empty, string.Empty, args.Trim());
                

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01.aspx(Curriculum locale)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01.aspx(Curriculum locale)", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Delete Path
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeletePath(string args)
        {

            try
            {

                //Delete Prerequisites
                SystemCurriculum deletePath = new SystemCurriculum();
                deletePath.c_curricula_path_system_id_pk = args.Trim();
                deletePath.c_curricula_id_fk = editCurriculumId;
                SystemCurriculumBLL.DeleteCurricilaPath(deletePath);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }


        }

        /// <summary>
        /// Delete Recert Path
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteRecertPath(string args)
        {

            try
            {

                //Delete Prerequisites
                SystemCurriculum deleteRecertPath = new SystemCurriculum();
                deleteRecertPath.c_curricula_recert_path_system_id_pk = args.Trim();
                deleteRecertPath.c_curricula_recert_id_fk = editCurriculumId;
                SystemCurriculumBLL.DeleteCurricilaRecertPath(deleteRecertPath);



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }


        }
        //Clear Curriculum Session
        private void ClearcurriculumSession()
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

            //Category
            SessionWrapper.CurriculumCategory = null;
            SessionWrapper.Reset_Curriculum_Category = null;

            //Domain
            SessionWrapper.CurriculumDomain = null;
            SessionWrapper.Reset_Curriculum_Domain = null;

            //Attachments
            SessionWrapper.Reset_Curriculum_Attachments = null;
            SessionWrapper.TempCurriculumAttachments = null;


            //path
            SessionWrapper.Reset_Curricula_Path = null;
            SessionWrapper.Reset_Curricula_Sections = null;
            SessionWrapper.Reset_Curricula_Courses = null;

            //Recert Path
            SessionWrapper.Reset_Curricula_Recert_Path = null;
            SessionWrapper.Reset_Curricula_Recert_Sections = null;
            SessionWrapper.Reset_Curricula_Recert_Courses = null;
            
            
        }

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

                        SystemCurriculum curriculumAttachment = new SystemCurriculum();
                        curriculumAttachment.c_curriculum_id_fk = editCurriculumId;
                        curriculumAttachment.c_curriculum_attachment_file_guid = c_file_guid + c_file_extension;
                        curriculumAttachment.c_curriculum_attachment_file_name = c_file_name;

                        if (!string.IsNullOrEmpty(hdAttachments.Value))
                        {
                            curriculumAttachment.c_curriculum_attchments_system_id_pk = hdAttachments.Value;
                            SystemCurriculumBLL.UpdateCurriculumAttachment(curriculumAttachment);
                            hdAttachments.Value = "";
                        }
                        else
                        {
                            SystemCurriculumBLL.InsertCurriculumAttachment(curriculumAttachment);

                        }
                    }
                }
                this.gvCurriculumAttachments.DataSource = SystemCurriculumBLL.GetCurriculumAttchments(editCurriculumId);
                this.gvCurriculumAttachments.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01", ex.Message);
                    }
                }
            }
        }



        protected void btnHeaderSaveCurriculum_Click(object sender, EventArgs e)
        {
            UpdateCurriculum();
        }

        protected void btnFooterSaveCurriculum_Click(object sender, EventArgs e)
        {
            UpdateCurriculum();
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
        protected void gvCurriculumAttachments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvCurriculumAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string attachmentId = gvCurriculumAttachments.DataKeys[rowIndex][2].ToString();
            if (e.CommandName.Equals("Edit"))
            {

                hdAttachments.Value = attachmentId;
                mpeAttachment.Show();
            }
            else if (e.CommandName.Equals("View") || e.CommandName.Equals("Download"))
            {

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
                try
                {
                    SystemCurriculumBLL.DeleteCurriculumAttachment(attachmentId);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saec-01", ex.Message);
                        }
                    }
                }
                this.gvCurriculumAttachments.DataSource = SystemCurriculumBLL.GetCurriculumAttchments(editCurriculumId);
                this.gvCurriculumAttachments.DataBind();



            }
        }

        protected void btnSaveNewVersion_Click(object sender, EventArgs e)
        {
            try
            {
                SystemCurriculum curriculum = new SystemCurriculum();

                curriculum.c_curriculum_system_id_pk = editCurriculumId;
                curriculum.c_new_curriculum_system_id_pk = Guid.NewGuid().ToString();
                curriculum.c_curriculum_version = txtNewVersionNumber.Text;
                curriculum.c_category = chkCategorys.Checked;
                curriculum.c_domain = chkDomains.Checked;
                curriculum.c_audiences = chkAudiences.Checked;
                curriculum.c_recurrance = chkRecurrance.Checked;
                curriculum.c_prerequisite = chkPrerequisite.Checked;
                curriculum.c_equivalency = chkEquivalencies.Checked;
                curriculum.c_fulfillment = chkFulfillments.Checked;
                curriculum.c_attchment = chkAttachments.Checked;
                curriculum.c_path = chkPaths.Checked;
                curriculum.c_recert_path = chkRecertification.Checked;
                curriculum.c_curriculum_created_by_id_fk = SessionWrapper.u_userid;
                int error = SystemCurriculumBLL.CreateCurriculumNewVersion(curriculum);             

                if (error != -2)
                {
                    divVersion.Style.Add("display", "none");
                    Response.Redirect("~/SystemHome/Catalog/Curriculum/saec-01.aspx?id=" + SecurityCenter.EncryptText(curriculum.c_new_curriculum_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    mpeCreateNewVersion.Show();
                    divVersion.Style.Add("display", "block");
                    divVersion.InnerText = LocalResources.GetText("app_version_id_already_exist_error_wrong");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saec-01", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saec-01", ex.Message);
                }

            }
        }
        protected void gvVersionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewVersion = (Button)e.Row.FindControl("btnViewVersion");
                LinkButton lnkViewVersion = (LinkButton)e.Row.FindControl("lnkViewVersion");
                lnkViewVersion.OnClientClick = "window.open('saac-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) + "','',''); return false;";
                btnViewVersion.OnClientClick = "window.open('saac-01.aspx?id=" + SecurityCenter.EncryptText(gvVersionList.DataKeys[e.Row.RowIndex][0].ToString()) + "','',''); return false;";
                //mpVersionList.Show();
            }
        }

        private void RevertBack(string editCurriculumId)
        {
            //Get curriculum related data and stored in session
            DataSet dsCurriculumDate = SystemCurriculumBLL.GetCurriculumRelatedData(editCurriculumId, SessionWrapper.CultureName);
            //Category
            SessionWrapper.Reset_Curriculum_Category = dsCurriculumDate.Tables[1];
            //Domain
            SessionWrapper.Reset_Curriculum_Domain = dsCurriculumDate.Tables[2];
            //Curriculum attachment
            SessionWrapper.Reset_Curriculum_Attachments = dsCurriculumDate.Tables[3];
            //Curriculum locale
            SessionWrapper.Reset_Curriculum_Locales = dsCurriculumDate.Tables[4];
            //Curriculum Path
            SessionWrapper.Reset_Curricula_Path = dsCurriculumDate.Tables[5];
            //Curriculum Path Sestions
            SessionWrapper.Reset_Curricula_Sections = dsCurriculumDate.Tables[6];
            //Curriculum Path Courses
            SessionWrapper.Reset_Curricula_Courses = dsCurriculumDate.Tables[7];
            //Curriculum Recert Path
            SessionWrapper.Reset_Curricula_Recert_Path = dsCurriculumDate.Tables[8];
            //Curriculum Recert Path Sections
            SessionWrapper.Reset_Curricula_Recert_Sections = dsCurriculumDate.Tables[9];
            //Curriculum Recert Path Courses
            SessionWrapper.Reset_Curricula_Recert_Courses = dsCurriculumDate.Tables[10];
            //Curriculum Audiences
            SessionWrapper.Reset_Curriculum_Audience = dsCurriculumDate.Tables[11];

            
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset(editCurriculumId);
        }
        private void Reset(string editCurriculumId)
        {
            SystemCurriculum curriculumReset = new SystemCurriculum();
            curriculumReset.c_related_curriculum_group_id = "";
            curriculumReset.c_curriculum_system_id_pk = editCurriculumId;
            ///Delete Prerequisite, Equivalencies and Fulfillments
            SystemCurriculumBLL.DeletePrerequisite(curriculumReset);
            SystemCurriculumBLL.DeleteEquivalencies(curriculumReset);
            SystemCurriculumBLL.DeleteFulfillments(curriculumReset);
            //Prerequisites
            curriculumReset.c_curriculum_Prerequistist = ConvertDataTableToXml(SessionWrapper.ResetCurriculumPrerequisite);
            //Equivalencies
            curriculumReset.c_curriculum_Equivalencies = ConvertDataTableToXml(SessionWrapper.ResetCurriculumEquivalencies);
            //Fulfillments
            curriculumReset.c_curriculum_Fulfillments = ConvertDataTableToXml(SessionWrapper.ResetCurriculumFulfillments);
            SystemCurriculumBLL.UpdateSystemCurriculumPrerequistist(curriculumReset);
            SystemCurriculumBLL.UpdateSystemCurriculumEquivalencies(curriculumReset);
            SystemCurriculumBLL.UpdateSystemCurriculumFulfillments(curriculumReset);
            //ReInsert
            SystemCurriculum Createcurriculum = new SystemCurriculum();
            //Attachments
            Createcurriculum.c_curriculum_attachment = ConvertDataTableToXml(SessionWrapper.Reset_Curriculum_Attachments);
            //Category
            Createcurriculum.c_curriculum_category = ConvertDataTableToXml(SessionWrapper.Reset_Curriculum_Category);
            //Domain
            Createcurriculum.c_curriculum_domain = ConvertDataTableToXml(SessionWrapper.Reset_Curriculum_Domain);
            //Audiences
            Createcurriculum.c_curriculum_audience = ConvertDataTableToXml(SessionWrapper.Reset_Curriculum_Audience);
            //Locale
            Createcurriculum.s_curriculum_locale = ConvertDataTableToXml(SessionWrapper.Reset_Curriculum_Locales);
            //Path
            Createcurriculum.c_curriculum_path = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Path);
            //Sections
            Createcurriculum.c_curriculum_path_sections = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Sections);
            //Courses
            Createcurriculum.c_curriculum_path_courses = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Courses);
            //Recert Path
            Createcurriculum.c_curriculum_recert_path = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Recert_Path);
            //Recert Path Sections
            Createcurriculum.c_curriculum_recert_path_sections = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Recert_Sections);
            //Recert Path Courses
            Createcurriculum.c_curriculum_recert_path_courses = ConvertDataTableToXml(SessionWrapper.Reset_Curricula_Recert_Courses);
            Createcurriculum.c_curriculum_system_id_pk = editCurriculumId;
           
            try
            {

                SystemCurriculumBLL.ResetCurriculum(Createcurriculum, true);
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

        protected void gvCurriculumAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset(editCurriculumId);
        }

        //Delete Audience
        [System.Web.Services.WebMethod]
        public static void DeleteAudience(string args)
        {
            try
            {
                SystemCurriculumBLL.DeleteAudiences(args.Trim(), editCurriculumId);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saec-01 (Remove Audience)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saec-01 (Remove Audience)", ex.Message);
                    }
                }
            }
        }
    }
}