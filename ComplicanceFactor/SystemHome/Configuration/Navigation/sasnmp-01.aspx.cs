using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;
using System.IO;
using System.Web.Hosting;

namespace ComplicanceFactor.SystemHome.Configuration.Navigation
{
    public partial class sasnmp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //breadcrumb
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/sascmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_configuration_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_system_navigation_text");

                    //first time the web and application navigation will be load
                    PopulateAppNavigation();
                    //bind web navigation main menu
                    dlWebNav.DataSource = NavigationBLL.GetWebNavMainMenu(SessionWrapper.CultureName);
                    dlWebNav.DataBind();
                }
                if (!string.IsNullOrEmpty(SessionWrapper.Active_Popup))
                {
                    //if create and edit the locale for website and application navigation that will be update into the application naviation textboxes.
                    //website
                    dlWebNav.DataSource = NavigationBLL.GetWebNavMainMenu(SessionWrapper.CultureName);
                    dlWebNav.DataBind();
                    //application navigation
                    PopulateAppNavigation();
                    SessionWrapper.Active_Popup = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// bind website navigation submenu
        /// </summary>
        /// <param name="GridView"></param>
        /// <param name="s_web_nav_id"></param>
        private void BindWebNavSubMenu(GridView GridView, string s_web_nav_id)
        {
            try
            {
                DataTable dtSubMenu = new DataTable();
                dtSubMenu = NavigationBLL.GetWebNavSubMenu(SessionWrapper.CultureName, s_web_nav_id);
                if (dtSubMenu.Rows.Count == 0)
                {
                    DataRow row;
                    row = dtSubMenu.NewRow();
                    row["s_web_nav_id"] = s_web_nav_id;
                    row["s_web_nav_active_flag"] = false;
                    row["s_ui_label_us_english"] = "None";
                    dtSubMenu.Rows.Add(row);
                }
                GridView.DataSource = dtSubMenu;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message);
                    }
                }
            }

        }
        protected void dlWebNav_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                CheckBox chkVisible = (CheckBox)e.Item.FindControl("chkVisible");
                Label lblVisible = (Label)e.Item.FindControl("lblVisible");
                lblVisible.Style.Add("display","none");
                chkVisible.Style.Add("display", "none");
            }
            GridView gvWebSubMenus = (GridView)e.Item.FindControl("gvWebSubMenus");
            BindWebNavSubMenu(gvWebSubMenus, dlWebNav.DataKeys[e.Item.ItemIndex].ToString());
        }
        protected void gvWebSubMenus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            DataListItem dlItem = (DataListItem)GridView1.Parent;
            DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str_s_web_nav_label_name = DataBinder.Eval(e.Row.DataItem, "s_web_nav_label_name").ToString();
                string str_s_web_nav_id = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                if (string.IsNullOrEmpty(str_s_web_nav_label_name))
                {
                    string str_s_web_nav_system_id_pk = GridView1.DataKeys[e.Row.RowIndex][1].ToString();
                    e.Row.Style.Add("display", "none");
                }
                string str_s_web_nav_default_page = DataBinder.Eval(e.Row.DataItem, "s_web_nav_default_page").ToString();
                string str_s_web_nav_url = DataBinder.Eval(e.Row.DataItem, "s_web_nav_url").ToString();
                if (str_s_web_nav_default_page == "False")
                {
                    Literal ltlRemove = (Literal)e.Row.FindControl("ltlRemove");
                    ltlRemove.Text = "<input id=" + str_s_web_nav_id + ',' + str_s_web_nav_url + " class='deleteui cursor_hand' type='button' value='" + LocalResources.GetLabel("app_remove_ui_page_button_text") + "'>";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string s_web_nav_id = dlWebNav.DataKeys[dle.Item.ItemIndex].ToString();
                if (dle.Item.ItemIndex != 0)
                {
                    e.Row.Cells[0].Text = "<input id=" + s_web_nav_id + " class='newpage cursor_hand' type='button' value='" + LocalResources.GetLabel("app_add_ui_page_button_text") + "'>";
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static void DeleteUI(string args, string args1)
        {
            try
            {
                NavigationBLL.DeleteWebUIPage(args.Trim());
                string s = HostingEnvironment.MapPath(args1);
                FileInfo TheFile = new FileInfo(HostingEnvironment.MapPath(args1));
                if (TheFile.Exists)
                {
                    File.Delete(HostingEnvironment.MapPath(args1));
                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message);
                    }
                }
            }


        }
        private void PopulateAppNavigation()
        {
            try
            {
                BusinessComponent.DataAccessObject.Navigation nav = new BusinessComponent.DataAccessObject.Navigation();
                nav = NavigationBLL.GetAppNavigation();
                txtEmployee.Text = nav.app_nav_employee;
                txtMyEmployeeTraining.Text = nav.app_emp_pod_mtraining_title;
                txtEmployeeMyLearningHistory.Text = nav.app_emp_pod_mlhistory_title;
                txtEmpMyCompliance.Text = nav.app_emp_pod_mcompliance_title;
                txtEmpMyCatalog.Text = nav.app_emp_pod_mcatalog_title;
                txtManager.Text = nav.app_nav_manager;
                txtManagerHome.Text = nav.app_manager_pod_home_title;
                txtManagerMyToDo.Text = nav.app_manager_pod_mtodo_title;
                txtManagerMyTeamManage.Text = nav.app_manager_pod_mteam_title;
                txtManagerMyReports.Text = nav.app_manager_pod_mreports_title;
                txtManagerMyProfile.Text = nav.app_manager_pod_mprofile_title;
                txtManagerBrowseCatalog.Text = nav.app_manager_pod_browse_catalog_title;
                txtManagerSearchCatalog.Text = nav.app_manager_pod_search_catalog_title;
                txtManagerSplashPage.Text = nav.app_manager_pod_splash_page_title;
                txtCompliance.Text = nav.app_nav_compliance;
                txtComplianceMyToDo.Text = nav.app_compliance_pod_mtodo_title;
                txtCompliancerMyDashboard.Text = nav.app_compliance_pod_mdashboard_title;
                txtCompliancerSiteView.Text = nav.app_compliance_pod_site_view_title;
                txtComplianceHarm.Text = nav.app_compliance_pod_mhazard_analysis_title;
                txtComplianceGiris.Text = nav.app_compliance_pod_mincident_report_title;
                txtComplianceCerts.Text = nav.app_compliance_pod_certs_title;
                txtComplianceReports.Text = nav.app_compliance_pod_mreports_title;
                txtComplianceMark.Text = nav.app_compliance_pod_mark_title;
                txtInstructor.Text = nav.app_nav_instructor;
                txtInstructorMyToDo.Text = nav.app_instructor_pod_mtodo_title;
                txtInstructorMyDashboard.Text = nav.app_my_dashboard_text;
                txtInstructorClassRosters.Text = nav.app_instructor_pod_mclassroster_title;
                txtInstructorReports.Text = nav.app_instructor_pod_mreports_title;
                txtTraining.Text = nav.app_nav_training;
                txtTrainingMyToDo.Text = nav.app_training_pod_mtodo_title;
                txtTrainingMyDashBoard.Text = nav.app_training_pod_mdashboard_title;
                txtTrainingMyTrainig.Text = nav.app_training_pod_mtraining_title;
                txtTrainingManageCatalog.Text = nav.app_training_pod_mtrainingcatalog_title;
                txtTrainingReport.Text = nav.app_training_pod_mreports_title;
                txtAdministrator.Text = nav.app_nav_admin;
                txt_app_admin_pod_minstructor_title.Text = nav.app_admin_pod_minstructor_title;
                txt_app_admin_pod_mtodo_title.Text = nav.app_admin_pod_mtodo_title;
                txt_app_admin_pod_mdashboard_title.Text = nav.app_admin_pod_mdashboard_title;
                txt_app_admin_pod_mcatalog_title.Text = nav.app_admin_pod_mcatalog_title;
                txtAdministratorReports.Text = nav.app_admin_pod_mreports_title;
                txtAdministratorMark.Text = nav.app_admin_pod_mark_title;
                txtSystem.Text = nav.app_nav_system;
                txtSystemManageUsers.Text = nav.app_system_pod_muser_title;
                txtSystemManageCatalog.Text = nav.app_system_pod_mcatalog_title;
                txtSystemManageConfiguration.Text = nav.app_system_pod_mconfiguration_title;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01.aspx", ex.Message);
                    }
                }
            }

        }
        private void UpdateAppNavigation()
        {
            BusinessComponent.DataAccessObject.Navigation nav = new BusinessComponent.DataAccessObject.Navigation();
            nav.app_nav_employee = txtEmployee.Text;
            nav.app_emp_pod_mtraining_title = txtMyEmployeeTraining.Text;
            nav.app_emp_pod_mlhistory_title = txtEmployeeMyLearningHistory.Text;
            nav.app_emp_pod_mcompliance_title = txtEmpMyCompliance.Text;
            nav.app_emp_pod_mcatalog_title = txtEmpMyCatalog.Text;
            nav.app_nav_manager = txtManager.Text;
            nav.app_manager_pod_home_title = txtManagerHome.Text;
            nav.app_manager_pod_mtodo_title = txtManagerMyToDo.Text;
            nav.app_manager_pod_mteam_title = txtManagerMyTeamManage.Text;
            nav.app_manager_pod_mreports_title = txtManagerMyReports.Text;
            nav.app_manager_pod_mprofile_title = txtManagerMyProfile.Text;
            nav.app_manager_pod_browse_catalog_title = txtManagerBrowseCatalog.Text;
            nav.app_manager_pod_search_catalog_title = txtManagerSearchCatalog.Text;
            nav.app_manager_pod_splash_page_title = txtManagerSplashPage.Text;
            nav.app_nav_compliance = txtCompliance.Text;
            nav.app_compliance_pod_mtodo_title = txtComplianceMyToDo.Text;
            nav.app_compliance_pod_mdashboard_title = txtCompliancerMyDashboard.Text;
            nav.app_compliance_pod_site_view_title = txtCompliancerSiteView.Text;
            nav.app_compliance_pod_mhazard_analysis_title = txtComplianceHarm.Text;
            nav.app_compliance_pod_mincident_report_title = txtComplianceGiris.Text;
            nav.app_compliance_pod_certs_title = txtComplianceCerts.Text;
            nav.app_compliance_pod_mreports_title = txtComplianceReports.Text;
            nav.app_compliance_pod_mark_title = txtComplianceMark.Text;
            nav.app_nav_instructor = txtInstructor.Text;
            nav.app_instructor_pod_mtodo_title = txtInstructorMyToDo.Text;
            nav.app_my_dashboard_text = txtInstructorMyDashboard.Text;
            nav.app_instructor_pod_mclassroster_title = txtInstructorClassRosters.Text;
            nav.app_instructor_pod_mreports_title = txtInstructorReports.Text;
            nav.app_nav_training = txtTraining.Text;
            nav.app_training_pod_mtodo_title = txtTrainingMyToDo.Text;
            nav.app_training_pod_mdashboard_title = txtTrainingMyDashBoard.Text;
            nav.app_training_pod_mtraining_title = txtTrainingMyTrainig.Text;
            nav.app_training_pod_mtrainingcatalog_title = txtTrainingManageCatalog.Text;
            nav.app_training_pod_mreports_title = txtTrainingReport.Text;
            nav.app_nav_admin = txtAdministrator.Text;
            nav.app_admin_pod_minstructor_title = txt_app_admin_pod_minstructor_title.Text;
            nav.app_admin_pod_mtodo_title = txt_app_admin_pod_mtodo_title.Text;
            nav.app_admin_pod_mdashboard_title = txt_app_admin_pod_mdashboard_title.Text;
            nav.app_admin_pod_mcatalog_title = txt_app_admin_pod_mcatalog_title.Text;
            nav.app_admin_pod_mreports_title = txtAdministratorReports.Text;
            nav.app_admin_pod_mark_title = txtAdministratorMark.Text;
            nav.app_nav_system = txtSystem.Text;
            nav.app_system_pod_muser_title = txtSystemManageUsers.Text;
            nav.app_system_pod_mcatalog_title = txtSystemManageCatalog.Text;
            nav.app_system_pod_mconfiguration_title = txtSystemManageConfiguration.Text;
            try
            {
                int error;
                error = NavigationBLL.UpdateAppNavigation(nav);
                if (error != -1)
                {
                    //Show success message
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerHtml = "Updated Successfully";


                }
                else
                {
                    //Show error message 
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerText = "Data Not Updated";

                } 
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01", ex.Message);
                    }
                }
            }
        }
        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            SaveNavigation();
        }
        private void SaveNavigation()
        {
            try
            {
                #region webnav
                //web navgiation
                for (int i = 0; i < dlWebNav.Items.Count; i++)
                {
                    DataListItem dlItem = dlWebNav.Items[i];
                    int dlIndex = dlItem.ItemIndex;
                    string s_web_nav_system_id_pk = dlWebNav.DataKeys[dlIndex].ToString();
                    GridView gvWebSubMenus = (GridView)dlWebNav.Items[i].FindControl("gvWebSubMenus");
                    TextBox txtParentNativeLabe = (TextBox)dlWebNav.Items[i].FindControl("txtNativeLabel");
                    CheckBox chkVisible = (CheckBox)dlWebNav.Items[i].FindControl("chkVisible");
                    //update parent menu
                    NavigationBLL.UpdateWebParentNavigation(chkVisible.Checked, s_web_nav_system_id_pk, txtParentNativeLabe.Text);
                    for (int j = 0; j < gvWebSubMenus.Rows.Count; j++)
                    {
                        TextBox txtChildNativeLabel = (TextBox)gvWebSubMenus.Rows[j].FindControl("txtNativeLabel");
                        if (txtChildNativeLabel.Text != "None")
                        {
                            string s_web_nav_id = gvWebSubMenus.DataKeys[j]["s_web_nav_id"].ToString();
                            CheckBox chkVisible1 = (CheckBox)gvWebSubMenus.Rows[j].FindControl("chkVisible");
                            //update child menu
                            NavigationBLL.UpdateWebChildNavigation(chkVisible1.Checked, txtChildNativeLabel.Text, s_web_nav_id);
                        }

                    }
                }
                //re-bind web navigation
                dlWebNav.DataSource = NavigationBLL.GetWebNavMainMenu(SessionWrapper.CultureName);
                dlWebNav.DataBind();
                #endregion
                //application navigation
                UpdateAppNavigation();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasnmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasnmp-01r", ex.Message);
                    }
                }
            }
        }
        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/sascmp-01.aspx", false);

        }
        protected void btnFooterSave_Click(object sender, EventArgs e)
        {
            SaveNavigation();
        }
        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/sascmp-01.aspx", false);
        }


    }
}