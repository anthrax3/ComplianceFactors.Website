<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="ccvharm-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.HARM.ccvharm_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {
            document.getElementById('<%=txtMultipe.ClientID %>').value = '';
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
            if (clicked_id == "ContentPlaceHolder1_btnSendtoOtherEmail") {
                document.getElementById('<%=btnSendMultipleMobile.ClientID%>').style.display = "none";
                document.getElementById('<%=btnSendMutipleEmail.ClientID%>').style.display = "inline";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Send Other Email(s):";
                document.getElementById('<%=lblTextHeading.ClientID%>').innerHTML = "Enter Email Address:";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSendtoOtherMobile") {
                document.getElementById('<%=btnSendMultipleMobile.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnSendMutipleEmail.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Send Other Mobile(s):";
                document.getElementById('<%=lblTextHeading.ClientID%>').innerHTML = "Enter Mobile Number:";
            }
        }

        //reset scroll position popup
        function ResetScroll() {
            window.scrollTo = function () { }
        }

    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <div id="content">
            <!-- Header -->
            <div id="header">
                <div class="content_align">
                    <!-- Logo-->
                    <div id="logo">
                        <asp:Image ID="imgLogo" runat="server" AlternateText="" ImageAlign="Left" CssClass="logo_image" />
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
                    <%=LocalResources.GetLabel("app_harm_information_text")%>
                    <asp:Label ID="lblPageHarmNumber" runat="server"></asp:Label>
                    :
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_harm_number_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHarmNumber" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_analysis_title_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHarmCaseTitle" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_analysis_date_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHarmCaseDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_category_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHarmCaseCategory" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                *
                                <%=LocalResources.GetLabel("app_status_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblHarmStatus" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%--  *
                                <%=LocalResources.GetLabel("app_employee_report_location_text")%>--%>
                            </td>
                            <td class="lable_td_width_1">
                                <%-- <asp:Label ID="lblHarmEmployeeReportLocation" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_hazard_and_control_measure_summary_text")%>
                </div>
                <br />
                <div class="hazard_control_measure">
                    <div id="emptyrow" runat="server">
                        <%=LocalResources.GetLabel("app_no_hazard_and_control_measure_text")%>
                    </div>
                    <div id="divAddJobTitle" runat="server">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <b>
                                        <%=LocalResources.GetLabel("app_job_title_text")%>:</b>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <asp:DataList ID="dlHazardSummary" runat="server" ShowFooter="true" CellPadding="0"
                        CellSpacing="0" DataKeyField="h_hazard_id_pk" Width="700px" OnItemDataBound="dlHazardSummary_ItemDataBound">
                        <ItemTemplate>
                            <fieldset>
                                <legend>
                                    <%=LocalResources.GetLabel("app_hazard_text")%>
                                    #<asp:Label ID="lblHazardNumber" runat="server" Text="0"></asp:Label></legend>
                                <br />
                                <table>
                                    <tr>
                                        <td class="td_hazard_control_measure">
                                            <asp:Label ID="lblHazard" runat="server" Text='<%# Bind("h_hazard_description") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td class="program_permit">
                                            <%=LocalResources.GetLabel("app_program_compliance_text")%>:
                                        </td>
                                        <td align="left">
                                            <b>
                                                <%# Eval("h_program_compliance_name") %>
                                            </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%=LocalResources.GetLabel("app_permit_compliance_text")%>:
                                        </td>
                                        <td align="left">
                                            <b>
                                                <%# Eval("h_permit_compliance_name")%>
                                            </b>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:GridView ID="gvControlMeasureSummary" ShowHeader="false" GridLines="None" runat="server"
                                    AutoGenerateColumns="False" CssClass="grid_900" OnRowDataBound="gvControlMeasureSummary_RowDataBound"
                                    DataKeyNames="h_hazard_id_fk,h_hazard_control_meausre_id_pk">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_control_measures_text %>"
                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="gvrow_padding">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <b>
                                                                <asp:Label ID="lblControlCategory" runat="server" Text='<%#Eval("h_control_measure_text") %>'></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblControlMeasure" runat="server" Text='<%#Eval("h_control_measure_summary") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </fieldset>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_additional_information_text")%>
                </div>
                <br />
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_custom_form(s)_text")%>
                            </td>
                            <td>
                                <asp:GridView ID="gvCustomCustomer" runat="server" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="grid_table_800" CellPadding="0" CellSpacing="0" DataKeyNames="h_file_guid,h_file_name"
                                    ShowHeader="false" ShowFooter="false" OnRowCommand="gvCustomCustomer_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkAddForm" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                                                    runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand font_1">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_photo(s)_text")%>
                            </td>
                            <td>
                                <asp:GridView ID="gvPhoto" runat="server" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="grid_table_800" CellPadding="0" CellSpacing="0" DataKeyNames="h_file_guid,h_file_name"
                                    ShowHeader="false" ShowFooter="false" OnRowCommand="gvPhoto_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPhoto" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                                                    runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand font_1"> 
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_scene_sketch(es)_text")%>
                            </td>
                            <td>
                                <asp:GridView ID="gvSceneSketch" GridLines="None" runat="server" AutoGenerateColumns="false"
                                    CssClass="grid_table_800" CellPadding="0" CellSpacing="0" ShowHeader="false"
                                    DataKeyNames="h_file_guid,h_file_name" ShowFooter="false" OnRowCommand="gvSceneSketch_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSceneSketch" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                                                    runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand font_1">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_extenuating_condition(s)_text")%>
                            </td>
                            <td>
                                <asp:GridView ID="gvExtenuatingCondition" GridLines="None" runat="server" AutoGenerateColumns="false"
                                    CssClass="grid_table_800" CellPadding="0" CellSpacing="0" ShowHeader="false"
                                    ShowFooter="false" DataKeyNames="h_file_guid,h_file_name" OnRowCommand="gvExtenuatingCondition_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkExtenuatingCondition" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                                                    runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand font_1">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_employee_interview(s)_text")%>
                            </td>
                            <td>
                                <asp:GridView ID="gvEmployeeInterview" GridLines="None" runat="server" AutoGenerateColumns="false"
                                    DataKeyNames="h_file_guid,h_file_name" CssClass="grid_table_800" CellPadding="0"
                                    CellSpacing="0" ShowFooter="false" ShowHeader="false" OnRowCommand="gvEmployeeInterview_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEmployeeInterview" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                                                    runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand font_1">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("h_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%= LocalResources.GetLabel("app_contact_information_text")%>
                                                :&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("h_contact_info") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_custom_fields_text")%>
                </div>
                <br />
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_01_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_02_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_03_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_04_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_05_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_06_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_07_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_08_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_09_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_10_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_11_text")%>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_custom_12_text")%>
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
                                <asp:Button ID="btnSendtoMyMobile" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_mobile_button_text %>"
                                    CssClass="cursor_hand" OnClick="btnSendtoMyMobile_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoMyEmail" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_email_button_text %>"
                                    CssClass="cursor_hand" OnClick="btnSendtoMyEmail_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrintPdf" runat="server" Text="<%$ LabelResourceExpression: app_print_button_text %>"
                                    CssClass="cursor_hand" OnClick="btnPrintPdf_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnDownload" runat="server" Text="<%$ LabelResourceExpression: app_download_button_text %>"
                                    CssClass="cursor_hand" OnClick="btnDownload_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherMobile" OnClientClick="Showpopup(this.id);" runat="server"
                                    Text="<%$ LabelResourceExpression: app_send_other_mobile_button_text %>" CssClass="cursor_hand" />
                            </td>
                            <td>
                                <asp:Button ID="btnSendtoOtherEmail" OnClientClick="Showpopup(this.id);" runat="server"
                                    Text="<%$ LabelResourceExpression: app_send_to_other_email_button_text %>" CssClass="cursor_hand" />
                            </td>
                        </tr>
                    </table>
                </div>
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
            padding-left: 0px; background-color: White; padding-right: 0px;" DefaultButton="btnSendMutipleEmail">
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
                    <asp:TextBox ID="txtMultipe" TextMode="MultiLine" Rows="3" Columns="68" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexMultipleEmailAddress" runat="server" ValidationExpression="^(\s*,?\s*[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})+\s*$"
                        ControlToValidate="txtMultipe" ValidationGroup="email" ErrorMessage="<%$ TextResourceExpression: app_invalid_email_error_wrong%>">&nbsp;</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="reqMultipleEmailAddress" runat="server" ControlToValidate="txtMultipe"
                        ValidationGroup="email" ErrorMessage="<%$ TextResourceExpression: app_email_error_empty%>">&nbsp;</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="revMultipleMobile" runat="server" ControlToValidate="txtMultipe"
                        ValidationGroup="mobile" ErrorMessage="<%$ TextResourceExpression: app_mobile_error_empty%>">&nbsp;</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <br />
                    <div class="popup_send_button">
                        <asp:Button ID="btnSendMutipleEmail" OnClientClick="ResetScroll();" ValidationGroup="email"
                            Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>"
                            OnClick="btnSendMutipleEmail_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnSendMultipleMobile" OnClientClick="ResetScroll();" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" OnClick="btnSendMultipleMobile_Click"
                            ValidationGroup="mobile" CssClass="cursor_hand" />
                    </div>
                    <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <br />
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMultipleHeader" runat="server" TargetControlID="btnSendtoOtherEmail"
            PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeMultipelMobileheader" runat="server" TargetControlID="btnSendtoOtherMobile"
            PopupControlID="pnlMultiple" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlMutipleHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnCancel">
        </asp:ModalPopupExtender>
    </div>
    <div>
     <rsweb:ReportViewer ID="rvHARM" runat="server"  DocumentMapCollapsed="false" Style="display: none;"  ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
    </div>
</asp:Content>
