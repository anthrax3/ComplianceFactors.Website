using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome
{
    public partial class sasumsm_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    ddlSearchUserStatus.DataSource = UserBLL.GetUserAllStatusList(SessionWrapper.CultureName,"sasumsm-01");
                    ddlSearchUserStatus.DataBind();
                    //ListItem lstStatus = new ListItem();
                    //lstStatus.Text = "All";
                    //lstStatus.Value = "0";
                    //ddlSearchUserStatus.Items.Insert(0, lstStatus);

                    //ddlSearchUserStatus.SelectedIndex = 0;


                    ddlSearchUserTypes.DataSource = UserBLL.GetAllUserTypes(SessionWrapper.CultureName, "sasumsm-01");
                    ddlSearchUserTypes.DataBind();
                    ddlSearchUserDomain.DataSource = UserBLL.GetUserDomains();
                    ddlSearchUserDomain.DataBind();

                    ListItem lstAll = new ListItem();
                    lstAll.Text = "All Types";
                    lstAll.Value = "0";

                    //ddlSearchUserTypes.Items.Insert(0, lstAll);
                    //ddlSearchUserTypes.SelectedIndex = 0;
                    ddlSearchUserDomain.Items.Insert(0, lstAll);
                    ddlSearchUserDomain.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sasumsm-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sasumsm-01", ex.Message);
                        }
                    }

                }
            }
        }

        protected void btnAddnewuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/saau-01.aspx");

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc" || Request.QueryString["page"] == "saantc")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["courseowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&courseowner=" + SecurityCenter.EncryptText("true") + "&coursecoordinatorowner=" + SecurityCenter.EncryptText("false"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["coursecoordinatorowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&coursecoordinatorowner=" + SecurityCenter.EncryptText("true") + "&courseowner=" + SecurityCenter.EncryptText("false"));
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saau" || Request.QueryString["page"] == "saeu")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["manager"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&manager=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["altmanager"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&altmanager=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["supervisor"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&supervisor=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["altsupervisor"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&altsupervisor=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mentor"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&mentor=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["altmentor"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&altmentor=" + SecurityCenter.EncryptText("true"));
                }


            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["deliveryowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&deliveryowner=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["deliverycoordiantor"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&deliverycoordiantor=" + SecurityCenter.EncryptText("true"));
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saandn" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saedn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["domainowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&domainowner=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["domaincoordinatorowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&domaincoordinatorowner=" + SecurityCenter.EncryptText("true"));
                }
            }

            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanawn" || Request.QueryString["page"] == "saeaw")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["specificFirstLevelApprover"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&specificFirstLevelApprover=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["specificSecondLevelApprover"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&specificSecondLevelApprover=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["specificThirdLevelApprover"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&specificThirdLevelApprover=" + SecurityCenter.EncryptText("true"));
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanspn" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saespn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["splashowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&splashowner=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["splashCoordinator"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&splashCoordinator=" + SecurityCenter.EncryptText("true"));
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["curriculumowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&curriculumowner=" + SecurityCenter.EncryptText("true"));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["curriculumcoordinatorowner"]))
                {
                    Response.Redirect("~/SystemHome/sasumsmr-01.aspx?lastname=" + SecurityCenter.EncryptText(txtSearchLastName.Text) + "&firstname=" + SecurityCenter.EncryptText(txtSearchFirstName.Text) + "&username=" + SecurityCenter.EncryptText(txtSearchUserName.Text) + "&userstatus=" + SecurityCenter.EncryptText(ddlSearchUserStatus.SelectedValue) + "&usertype=" + SecurityCenter.EncryptText(ddlSearchUserTypes.SelectedValue) + "&userdomain=" + SecurityCenter.EncryptText(ddlSearchUserDomain.SelectedValue) + "&page=" + SecurityCenter.EncryptText(Request.QueryString["page"]) + "&curriculumcoordinatorowner=" + SecurityCenter.EncryptText("true"));
                }
            }



        }
    }
}