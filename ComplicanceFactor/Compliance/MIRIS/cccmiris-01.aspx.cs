using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance
{
    public partial class cccmiris_01 : BasePage
    {
        private static string caseNumber;
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.navigationText = "app_nav_compliance";
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_miris_text") + "</a>";
            if (!IsPostBack)
            {
                try
                {
                    //category
                    ddlCaseCategory.DataSource = ComplianceBLL.GetMirisCaseCategory(SessionWrapper.CultureName, "cccmiris-01");
                    ddlCaseCategory.DataBind();
                    //case type
                    casetypeText.Visible = false;
                    casetype.Visible = false;

                    string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
                    if (caseCategory == "MV")
                    {
                        ddlCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                        ddlCaseTypes.DataBind();                        

                    }
                    else
                    {
                        ddlCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "cccmiris-01");
                        ddlCaseTypes.DataBind();
                        ddlCaseTypes.SelectedValue = "app_ddl_recordable_text";                        
                    }

                    //Compliance Approver
                    ddlComplianceApprover.DataSource = UserBLL.GetComplianceApproverList();
                    ddlComplianceApprover.DataBind();

                    //ListItem liAll = new ListItem();
                    //liAll.Text = "All";
                    //liAll.Value = "0";
                    //search category
                    ddlSearchCaseCategory.DataSource = ComplianceBLL.GetMirisAllCaseCategory(SessionWrapper.CultureName, "cccmiris-01");
                    ddlSearchCaseCategory.DataBind();
                    ddlSearchCaseCategory.SelectedValue = "app_ddl_motor_vehicle_incident_text";
                    string searchCaseCategory = GetBracketText(ddlSearchCaseCategory.SelectedItem.Text);
                    if (searchCaseCategory == "MV")
                    {
                        ddlSearchCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                        ddlSearchCaseTypes.DataBind();
                        ddlSearchCaseTypes.Items.Insert(0, new ListItem("All", "app_ddl_all_text"));
                    }
                    else
                    {
                        ddlSearchCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "cccmiris-01");
                        ddlSearchCaseTypes.DataBind();
                        ddlSearchCaseTypes.SelectedValue = "app_ddl_recordable_text";
                    }

                    //ddlSearchCaseCategory.Items.Insert(0, liAll);
                    //Search status
                    ddlSearchCaseStatus.DataSource = ComplianceBLL.GetMirisCaseAllStatus(SessionWrapper.CultureName, "cccmiris-01");
                    ddlSearchCaseStatus.DataBind();
                    //ddlSearchCaseStatus.Items.Insert(0, liAll);
                    txtCreationStartDate.Text = DateTime.Now.AddYears(-1).ToString("MM/dd/yyyy");
                    txtCreationEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

                    ddlEmployeeReportLocation.DataSource = SystemEstablishmentBLL.SearchEstablishment(new SystemEstablishment()
                    {
                        s_establishment_id_pk = "",
                        s_establishment_city = "",
                        s_establishment_name = "",
                        s_establishment_status_id_fk = "app_ddl_active_text"
                    });

                    ddlEmployeeReportLocation.DataTextField = "s_establishment_name";
                    ddlEmployeeReportLocation.DataValueField = "s_establishment_system_id_pk";
                    ddlEmployeeReportLocation.DataBind();
                    ddlEmployeeReportLocation.Items.Insert(0, new ListItem("All", ""));
                   
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Succ"]))
                {
                    success_msg.Style.Add("display", "block");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_created_sento_compliance_approver_text");
                }
                searchResult();
                lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            }
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            uccb1.show("");
        }

        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewCaseDescription = (Button)e.Row.FindControl("btnViewCaseDescription");
                string caseId = gvsearchDetails.DataKeys[e.Row.RowIndex][0].ToString();
                string caseCategory = gvsearchDetails.DataKeys[e.Row.RowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);

                if (caseCategory == "OI")
                {
                    btnViewCaseDescription.OnClientClick = "window.open('cvoi-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
                else if (caseCategory == "MV")
                {
                    btnViewCaseDescription.OnClientClick = "window.open('cvmv-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
                else
                {
                    btnViewCaseDescription.OnClientClick = "window.open('ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
            }
        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                string caseStatus = gvsearchDetails.DataKeys[rowIndex][1].ToString();
                string caseCategory = gvsearchDetails.DataKeys[rowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);

                if (caseCategory == "OI")
                {
                    //code for closed and Redirect to Edit page
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnCompleteOI(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                                }
                            }

                        }

                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }

                }
                else if (caseCategory == "MV")
                {
                    //code for Motor Vehicle closed and Redirect to Edit page 
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnCompleteMV(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                                }
                            }

                        }

                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }
                }
                else
                {
                    //int rowIndex = int.Parse(e.CommandArgument.ToString());
                    //string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                    //string caseStatus = gvsearchDetails.DataKeys[rowIndex][1].ToString();
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnComplete(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }
                }

            }
            else if (e.CommandName == "Copy")
            {
                ComplianceDAO miris = new ComplianceDAO();
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                string caseStatus = gvsearchDetails.DataKeys[rowIndex][1].ToString();
                string caseCategory = gvsearchDetails.DataKeys[rowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);
                if (caseCategory == "OI")
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                else if (caseCategory == "MV")
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);

                }
                else
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                //Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId), false);
            }
            else if (e.CommandName == "Close")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                {
                   
                    string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                    try
                    {
                        ComplianceDAO miris = new ComplianceDAO();
                        miris.c_case_id_pk = caseId;
                        miris.c_case_status = "close";
                        ComplianceBLL.UpdateCaseStatus(miris);
                        searchResult();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    caseNumber = gvsearchDetails.DataKeys[rowIndex][2].ToString();
                    mpCompleteCase.Show();
                    
                }
            }
            //else if (e.CommandName == "View")
            //{
            //    int rowIndex = int.Parse(e.CommandArgument.ToString());
            //    string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
            //    //Page.ClientScript.RegisterStartupScript(   this.GetType(),"OpenWindow","window.open('YourURL','_newtab');",true);

            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Compliance/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(caseId)+"',_newtab');", true);

            //    Response.Redirect("~/Compliance/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(caseId));
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User approverInfo = new User();
            approverInfo = UserBLL.GetApprovalNameandEmail(ddlComplianceApprover.SelectedValue.ToString());

            string toEmailid = approverInfo.EmailId;
            toEmailid = "compliancefactor.project@gmail.com";
            //"compliancefactor.project@gmail.com";
            string[] toaddress = toEmailid.Split(',');
            List<MailAddress> mailAddresses = new List<MailAddress>();
            foreach (string recipient in toaddress)
            {
                if (recipient.Trim() != string.Empty)
                {
                    mailAddresses.Add(new MailAddress(recipient));
                }
            }
            try
            {
                StringBuilder sbCompleteCase = new StringBuilder();
                sbCompleteCase.Append("Hello " + approverInfo.Username + ",");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("This email is to change the case as completed case.");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("I sent the request to you for change this " + caseNumber + " to Complete Case.");
                sbCompleteCase.Append("<br><br>");
                sbCompleteCase.Append("by");
                sbCompleteCase.Append("<br>");               
                sbCompleteCase.Append(SessionWrapper.u_username);
                Utility.SendEMailMessage(mailAddresses, "***Request for Complete Case***", sbCompleteCase.ToString());
                success_msg.Style.Add("display", "block");                
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "Request Was Send Successfully to" + " " + approverInfo.Username;
                caseNumber = string.Empty;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("coi-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("coi-01", ex.Message);
                    }
                }
            }
        }


        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            //ddlresultperpage_header.SelectedIndex = 0;
            //ddlresultperpage_footer.SelectedIndex = 0;
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Top Last Button
        protected void btnLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Top Next Button
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Top Previous Button
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        //Top Result Per Page DropdownList
        protected void ddlresultperpage_header_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlresultperpage_header.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlresultperpage_header.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            searchResult();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlresultperpage_footer.SelectedValue = ddlresultperpage_header.SelectedValue;
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }
        //Top Goto Button
        protected void btnGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtPage.Text) - 1;
            searchResult();
            txtdownpage.Text = txtPage.Text;
        }

        //Down First Button
        protected void btndownFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Down Previous Button
        protected void btndownPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Down Next Button
        protected void btndownNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Down Last Button
        protected void btndownLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //down Result Per Page DropDownList
        protected void ddlresultperpage_footer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlresultperpage_footer.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlresultperpage_footer.Text);
                gvsearchDetails.PageSize = selectedValue;
            }
            searchResult();
            txtdownpage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lbldownPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlresultperpage_header.SelectedValue = ddlresultperpage_footer.SelectedValue;
            txtPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblPage.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        //Down Goto Button
        protected void btndownGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtdownpage.Text) - 1;
            searchResult();
            txtPage.Text = txtdownpage.Text;
        }
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;
            searchResult();
        }

        private void searchResult()
        {
            try
            {
                DataTable dtSearchCase = new DataTable();
                ComplianceDAO miris = new ComplianceDAO();

                miris.c_case_number = txtSearchCaseNumber.Text;
                miris.c_case_title = txtSearchCaseTitle.Text;
                DateTime? caseDate = null;
                DateTime tempCaseDate;
                if (DateTime.TryParseExact(txtSearchCasedate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempCaseDate))
                {
                    caseDate = tempCaseDate;
                }
                //if (DateTime.TryParse(txtSearchCasedate.Text, out tempCaseDate))
                //{
                //    caseDate = tempCaseDate;
                //}
                miris.c_case_date = caseDate;
                if (ddlSearchCaseCategory.SelectedValue == "app_ddl_all_text")
                {
                    miris.c_case_category_fk = "0";
                }
                else
                {
                    miris.c_case_category_fk = ddlSearchCaseCategory.SelectedValue;
                }
                if (ddlSearchCaseTypes.SelectedValue == "app_ddl_all_text")
                {
                    miris.c_case_type_fk = "0";
                }
                else
                {
                    miris.c_case_type_fk = ddlSearchCaseTypes.SelectedValue;
                }               
                if (ddlSearchCaseStatus.SelectedValue == "app_ddl_all_text")
                {
                    miris.c_case_status = "0";
                }
                else
                {
                    miris.c_case_status = ddlSearchCaseStatus.SelectedValue;
                }
                if (string.IsNullOrEmpty(ddlEmployeeReportLocation.SelectedValue))
                {
                    miris.c_employee_report_location = "";
                }
                else
                {
                    miris.c_employee_report_location = ddlEmployeeReportLocation.SelectedValue;
                }
                miris.c_employee_name = txtEmployeeName.Text;
                miris.c_employee_last_name = txtLastName.Text;
                miris.c_incident_location = txtIncidentLocation.Text;
                miris.c_supervisor = txtSupervisor.Text;
                
                dtSearchCase = ComplianceBLL.SearchCase(miris, txtCreationStartDate.Text, txtCreationEndDate.Text);
                gvsearchDetails.DataSource = dtSearchCase;
                gvsearchDetails.DataBind();

                if (dtSearchCase.Rows.Count == 0)
                {
                    disable();
                }
                else
                {
                    enable();
                }
                if (dtSearchCase.Rows.Count > 0)
                {
                    gvsearchDetails.UseAccessibleHeader = true;
                    if (gvsearchDetails.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccemiris-01", ex.Message);
                    }
                }
            }
        }
        private void disable()
        {
            btnFirst.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btndownFirst.Visible = false;
            btndownNext.Visible = false;
            btndownPrevious.Visible = false;
            btndownLast.Visible = false;
            ddlresultperpage_footer.Visible = false;
            ddlresultperpage_header.Visible = false;
            txtPage.Visible = false;
            lblPage.Visible = false;
            txtdownpage.Visible = false;
            lbldownPage.Visible = false;
            btndownGoto.Visible = false;
            btnGoto.Visible = false;
            lblHeaderPage.Visible = false;
            lblFooterPage.Visible = false;
            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;
        }

        private void enable()
        {
            btnFirst.Visible = true;
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btndownFirst.Visible = true;
            btndownNext.Visible = true;
            btndownPrevious.Visible = true;
            btndownLast.Visible = true;
            ddlresultperpage_footer.Visible = true;
            ddlresultperpage_header.Visible = true;
            txtPage.Visible = true;
            lblPage.Visible = true;
            txtdownpage.Visible = true;
            lbldownPage.Visible = true;
            btndownGoto.Visible = true;
            btnGoto.Visible = true;
            lblHeaderPage.Visible = true;
            lblFooterPage.Visible = true;
            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;
        }

        protected void btnCreateNewCase_Click(object sender, EventArgs e)
        {
            try
            {
                ComplianceDAO miris = new ComplianceDAO();
                DataTable dtCaseId = new DataTable();
                string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
                miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                if (caseCategory == "MV")
                {
                    Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(uccb1.uc_values) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                }
                else if (caseCategory == "OI")
                {
                    Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                }
                else
                {
                    Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
                }
                //Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?cid=" + SecurityCenter.EncryptText(ddlCaseCategory.SelectedValue) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number) + "&type=" + SecurityCenter.EncryptText(ddlCaseTypes.SelectedValue) + "&title=" + SecurityCenter.EncryptText(txtCaseTitle.Text), false);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cccmiris-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cccmiris-01", ex.Message);
                    }
                }
            }
        }

        private string GetBracketText(string strCaseCategory)
        {
            string regularExpressionPattern = @"\((.*?)\)";
            string inputText = strCaseCategory;
            Regex re = new Regex(regularExpressionPattern);
            string strresult = string.Empty;
            foreach (Match m in re.Matches(inputText))
            {
                strresult = m.Value;
            }
            strresult = strresult.Replace("(", "").Replace(")", "");
            return strresult;
        }
        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ddlCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string caseCategory = GetBracketText(ddlCaseCategory.SelectedItem.Text);
            if (caseCategory == "MV")
            {
                casetypeText.Visible = false;
                casetype.Visible = false;
                ddlCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                ddlCaseTypes.DataBind();
            }
            else
            {
                uccb1.Visible = false;
                casetypeText.Visible = true;
                casetype.Visible = true;
                ddlCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "cccmiris-01");
                ddlCaseTypes.DataBind();
                ddlCaseTypes.SelectedValue = "app_ddl_recordable_text";
            }
        }
        protected void ddlSearchCaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string caseCategory = GetBracketText(ddlSearchCaseCategory.SelectedItem.Text);
            if (caseCategory == "MV")
            {
               
                ddlSearchCaseTypes.DataSource = ComplianceBLL.GetMirisMVCaseType(SessionWrapper.CultureName, "cmv-01");
                ddlSearchCaseTypes.DataBind();
            }
            else
            {
               
                ddlSearchCaseTypes.DataSource = ComplianceBLL.GetMirisCaseType(SessionWrapper.CultureName, "cccmiris-01");
                ddlSearchCaseTypes.DataBind();
                ddlSearchCaseTypes.SelectedValue = "app_ddl_recordable_text";
            }
        }


    }
}