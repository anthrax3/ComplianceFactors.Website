<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ccvmiris-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.ccvmiris_01" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {

            document.getElementById('<%=txtMultipeEmailAddress.ClientID %>').value = '';
            HideValidationErrors();
        }
    </script>
    <script type="text/javascript">
        function HideValidationErrors() {
            //Hide all validation errors
            if (window.Page_Validators)
                for (var vI = 0; vI < Page_Validators.length; vI++) {
                    var vValidator = Page_Validators[vI];
                    vValidator.isvalid = true;
                    ValidatorUpdateDisplay(vValidator);
                }
            //Hide all validaiton summaries
            if (typeof (Page_ValidationSummaries) != "undefined") { //hide the validation summaries
                for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
                    summary = Page_ValidationSummaries[sums];
                    summary.style.display = "none";
                }
            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        //Function to Show ModalPopUp
        function Showpopup(clicked_id) {

            if (clicked_id == "btnSendtoOtherEmail_header" || clicked_id == "btnSendtoOtherEmail_foooter") {

                document.getElementById('<%=btnSendMultipleMobile.ClientID%>').style.display = "none";
                document.getElementById('<%=btnSendMutiple.ClientID%>').style.display = "inline";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Send Other Email(s):";
                document.getElementById('<%=lblTextHeading.ClientID%>').innerHTML = "Enter Email Address:";
            }
            else if (clicked_id == "btnSendtoOtherMobile_header" || clicked_id == "btnSendtoOtherMobile_footer") {
                document.getElementById('<%=btnSendMultipleMobile.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnSendMutiple.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Send Other Mobile(s):";
                document.getElementById('<%=lblTextHeading.ClientID%>').innerHTML = "Enter Mobile Number:";
            }
        }

        function ResetScroll() {
            window.scrollTo = function () { }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <div>
        <div id="content">
            <!---header   --->
            <div id="header">
                <div class="content_align ">
                    <!---logo   --->
                    <div id="logo">
                        <%--  <img alt="Logo" src="../Images/ComplianceFactorsLogo.jpg" />--%>
                        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ComplianceFactorsLogo.jpg"
                            AlternateText="Logo" ImageAlign="Left" CssClass="logo_image" />
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
            </div>
            <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
            </div>
            <div class="content_area_long">
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_case_details_page_text")%>
                    <asp:Label ID="lblPageCaseNumber" runat="server"></asp:Label>
                    :
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_number_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseNumber" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_title_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseTitle" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_date_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_category_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseCategory" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_types_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseTypes" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_case_status_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_case_description_text")%>:
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_employee_name_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_date_of_birth_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDateOfBirth" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_employee_hire_date_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeHireDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_employee_id_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_last_digit_of_ssn#_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblLastFourDigitOfSSN" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_supervisor_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_incident_location_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentLocation" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_incident_date_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentDate" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_incident_time_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_employee_report_location_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeReportLocation" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_timezone_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_note_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNote" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_additional_Information_text")%>:
                </div>
                <br />
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_witness(es)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvAddWitness" GridLines="None" CssClass="grid_table_800" CellPadding="0"
                                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvAddWitness_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkWitness" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp;
                                                &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_contact_information_text")%>
                                                :&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_contact_info") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_police_reports(s)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvPoliceReport" GridLines="None" CssClass="grid_table_800" CellPadding="0"
                                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvPoliceReport_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPoliceReport" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_photo(s)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvPhoto" GridLines="None" CssClass="grid_table_800" CellPadding="0"
                                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvPhoto_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPhoto" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_scene_sketch(es)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvSceneSketch" GridLines="None" CssClass="grid_table_800" CellPadding="0"
                                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvSceneSketch_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSceneSketch" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_extenuating_condition(s)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvExtenuatingcondition" GridLines="None" CssClass="grid_table_800"
                                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvExtenuatingcondition_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkExtenuatingCondition" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp;
                                                &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_contact_information_text")%>
                                                :&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_contact_info") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_employee_interview(s)_text")%>:
                            </td>
                            <td>
                                <asp:GridView ID="gvEmployeeInterview" GridLines="None" CssClass="grid_table_800"
                                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvEmployeeInterview_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEmployeeInterview" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp;
                                                &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_contact_information_text")%>
                                                :&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_contact_info") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="table_send_print_buttons">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSendtoMyMobile_header" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_mobile_button_text %>"
                                    OnClick="btnSendtoMyMobile_header_Click1" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoMyEmail_header" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_email_button_text %>"
                                    OnClick="btnSendtoMyEmail_header_Click2" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrintPdf_header" runat="server" Text="<%$ LabelResourceExpression: app_print_button_text %>"
                                    OnClick="btnPrintPdf_header_Click" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnDownloadZip_header" runat="server" Text="<%$ LabelResourceExpression: app_download_button_text %>"
                                    OnClick="btnDownloadZip_header_Click" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherMobile_header" OnClientClick="Showpopup(this.id);"
                                    runat="server" Text="<%$ LabelResourceExpression: app_send_other_mobile_button_text %>"
                                    CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherEmail_header" OnClientClick="Showpopup(this.id);" runat="server"
                                    Text="<%$ LabelResourceExpression: app_send_to_other_email_button_text %>"
                                    CssClass="cursor_hand" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_root_cause_analysis_infornation_text")%>:
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_root_cause_analysis_details_text")%>:
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblRootCauseAnalysisDetails" runat="server"></asp:Label>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_corrective_action_information_text")%>:
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_corrective_action_details_text")%>:
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblCorrectiveActionDetails" runat="server"></asp:Label>
                </div>
                <br />
                <%-- <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_osha_300_information_text")%>
                </div>
                <br />
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_case_outcome_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCaseOutCome" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_days_away_from_work_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDaysAwayFromWork" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_days_of_restrictions_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDaysOfRestrictions" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_data_of_death_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDateOfDeath" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_type_of_illness_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTypeofIllness" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_describe_injury_or_illness_text")%>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblOSHA300info" runat="server"></asp:Label>
                   
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_oosha_301_information_text")%>
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_worker_gender_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblWorkerGender" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_works_start_time_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblWorkStartTime" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_physician_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPhysician" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_treatment_facility_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTreatmentFacility" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_emergency_room_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmergencyRoom" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_hospitalized_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHospitalized" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_1_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_2_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_3_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAddress3" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_city_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_zip_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_what_was_the_employee_text")%>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblOSHA301Info1" runat="server"></asp:Label>
                   
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_what_happened_tell_text")%>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblOSHA301Info2" runat="server"></asp:Label>
                  
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_what_was_the_injury_text")%>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblOSHA301Info3" runat="server"></asp:Label>
                   
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_what_object_or_substance_text")%>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblOSHA301Info4" runat="server"></asp:Label>
                   
                </div>--%>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_custom_fields_text")%>
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_01_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_02_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_03_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_04_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_05_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_06_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_07_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_08_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_09_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_10_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_11_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_12_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_13_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom13" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="div_header_long">
                    <br />
                </div>
                <br />
                <div class="label_required_field">
                    *
                    <%=LocalResources.GetLabel("app_required_fields_text")%>
                </div>
                <br />
                <div class="table_send_print_buttons">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSendtoMyMobile_footer" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_mobile_button_text %>"
                                    OnClick="btnSendtoMyMobile_footer_Click" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoMyEmail_footer" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_email_button_text %>"
                                    OnClick="btnSendtoMyEmail_footer_Click1" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrintPdf_footer" runat="server" Text="<%$ LabelResourceExpression: app_print_button_text %>"
                                    OnClick="btnPrintPdf_footer_Click" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnDownload_footer" runat="server" Text="<%$ LabelResourceExpression: app_download_button_text %>"
                                    OnClick="btnDownload_footer_Click" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherMobile_footer" runat="server" Text="<%$ LabelResourceExpression: app_send_other_mobile_button_text %>"
                                    OnClientClick="Showpopup(this.id);" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherEmail_foooter" runat="server" Text="<%$ LabelResourceExpression: app_send_to_other_email_button_text %>"
                                    OnClientClick="Showpopup(this.id);" CssClass="cursor_hand" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="footer">
                <div class="left ">
                    <%=LocalResources.GetText("wp_app_release_number")%>
                </div>
                <div class="right ">
                <%=LocalResources.GetText("wp_powered_by_content")%>
                    
                </div>
                <br />
                <br />
            </div>
            <asp:Button ID="btnUploadFile" CssClass="cursor_hand" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlMultiple" runat="server" CssClass="modalPopup_upload" Style="display: none;
                padding-left: 0px; background-color: White; padding-right: 0px;" DefaultButton="btnSendMutiple">
                <asp:Panel ID="pnlMutipleHeading" runat="server" CssClass="drag_uploadpopup">
                    <div>
                        <div class="uploadpopup_header">
                            <div class="left">
                                <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            </div>
                            <div class="right">
                                <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                                    z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                                    ImageUrl="~/Images/Zoom/fancy_close.png" />
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div>
                    <br />
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_email" runat="server"
                        ValidationGroup="email" />
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_mobile" runat="server"
                        ValidationGroup="mobile" />
                    <div class="uploadpanel">
                        <asp:Label ID="lblTextHeading" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="txtMultipeEmailAddress" TextMode="MultiLine" Rows="3" Columns="68"
                            runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexMultipleEmailAddress" runat="server" ValidationExpression="^(\s*,?\s*[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})+\s*$"
                            ControlToValidate="txtMultipeEmailAddress" ValidationGroup="email" ErrorMessage="<%$ TextResourceExpression: app_invalid_email_error_wrong %>">&nbsp;</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="reqMultipleEmailAddress" runat="server" ControlToValidate="txtMultipeEmailAddress"
                            ValidationGroup="email" ErrorMessage="<%$ TextResourceExpression: app_email_error_empty %>">&nbsp;</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="revMultipleMobile" runat="server" ControlToValidate="txtMultipeEmailAddress"
                            ValidationGroup="mobile" ErrorMessage="<%$ TextResourceExpression: app_mobile_error_empty %>">&nbsp;</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <br />
                        <div class="popup_send_button">
                            <asp:Button ID="btnSendMutiple" OnClientClick="ResetScroll();" ValidationGroup="email"
                                Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" OnClick="btnSendMutiple_Click"
                                CssClass="cursor_hand" />
                            <asp:Button ID="btnSendMultipleMobile" OnClientClick="ResetScroll();" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" OnClick="btnSendMultipleMobile_Click" ValidationGroup="mobile"
                                CssClass="cursor_hand" />
                        </div>
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </div>
                    <br />
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpeMultipleHeader" runat="server" TargetControlID="btnSendtoOtherEmail_header"
                PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeMutlipe_Footer" runat="server" TargetControlID="btnSendtoOtherEmail_foooter"
                PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeMultipelMobileheader" runat="server" TargetControlID="btnSendtoOtherMobile_header"
                PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeMultipleMobileFooter" runat="server" TargetControlID="btnSendtoOtherMobile_footer"
                PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
        </div>
    </div>
    <rsweb:ReportViewer ID="rvMIRIS" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
    <div class="clear">
    </div>
   
    </form>
</body>
</html>
