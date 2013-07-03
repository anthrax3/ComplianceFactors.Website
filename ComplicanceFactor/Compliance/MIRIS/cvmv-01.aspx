<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="cvmv-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.cvmv_01" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
            if (clicked_id == "ContentPlaceHolder1_btnSendtoOtherEmail_header" || clicked_id == "ContentPlaceHolder1_btnSendtoOtherEmail_foooter") {
                document.getElementById('<%=btnSendMultipleMobile.ClientID%>').style.display = "none";
                document.getElementById('<%=btnSendMutiple.ClientID%>').style.display = "inline";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Send Other Email(s):";
                document.getElementById('<%=lblTextHeading.ClientID%>').innerHTML = "Enter Email Address:";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSendtoOtherMobile_header" || clicked_id == "ContentPlaceHolder1_btnSendtoOtherMobile_footer") {
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
                        <%--<asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ComplianceFactorsLogo.jpg"
                            AlternateText="Logo" ImageAlign="Left" CssClass="logo_image" />--%>
                            <asp:Image ID="imgLogo" runat="server" AlternateText=""
                         ImageAlign="Left" CssClass="logo_image" />
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
            </div>
            <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
            </div>
            <div class="table_send_print_buttons">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSendtoMyMobile_header" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_mobile_button_text %>"
                                OnClick="btnSendtoMyMobile_header_Click" CssClass="cursor_hand" />
                        </td>
                        <td>
                            <asp:Button ID="btnSendtoMyEmail_header" runat="server" Text="<%$ LabelResourceExpression: app_send_to_my_email_button_text %>"
                                OnClick="btnSendtoMyEmail_header_Click" CssClass="cursor_hand" />
                        </td>
                        <td>
                            <asp:Button ID="btnPrintPdf_header" runat="server" Text="<%$ LabelResourceExpression: app_print_button_text %>"
                                OnClick="btnPrintPdf_header_Click" CssClass="cursor_hand" />
                        </td>
                        <td>
                            <asp:Button ID="btnDownloadZip_header" runat="server" OnClick="btnDownloadZip_header_Click"
                                Text="<%$ LabelResourceExpression: app_download_button_text %>" CssClass="cursor_hand" />
                        </td>
                        <td>
                            <asp:Button ID="btnSendtoOtherMobile_header" OnClientClick="Showpopup(this.id);"
                                runat="server" Text="<%$ LabelResourceExpression: app_send_other_mobile_button_text %>"
                                CssClass="cursor_hand" />
                        </td>
                        <td>
                            <asp:Button ID="btnSendtoOtherEmail_header" OnClientClick="Showpopup(this.id);" runat="server"
                                Text="<%$ LabelResourceExpression: app_send_to_other_email_button_text %>" CssClass="cursor_hand" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="content_area_long">
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_case_details_text")%>
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
                                <%=LocalResources.GetLabel("app_employee_name_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_date_of_birth_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDateOfBirth" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_employee_hire_date_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeHireDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_employee_id_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_last_digit_of_ssn#_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblLastFourDigitOfSSN" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_supervisor_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_incident_location_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentLocation" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_incident_date_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentDate" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_incident_time_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblIncidentTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_employee_report_location_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblEmployeeReportLocation" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
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
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_text")%>
                                1:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicle01" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleType" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vin_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVIN" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_license_number_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblLicenseNumber" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleMake" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_model_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleModel" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_year_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblYear" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_text")%>
                                2:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicle02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleType02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleId02" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vin_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVIN02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_license_number_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblLicenceNumber02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblState02" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblMake02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_model_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblModel02" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_year_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblYear02" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <asp:GridView ID="gvVehicle" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_vehicle_text")%>
                                                         <%#Container.DataItemIndex + 03 %>
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_fk")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_type_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_type")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_id")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_vin_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_vin")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_license_number_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_number")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_make")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_model_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_model")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_year_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_year")%>
                                                    </td>
                                                    <td class="text_font_normal">
                                                        <%=LocalResources.GetLabel("app_state_text")%>:
                                                    </td>
                                                    <td class="lable_td_width_1">
                                                        <%#Eval("vehicle_state")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </tr>
                    </table>
                </div>
                <div class="div_controls">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_company_vehicle_struck_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCompanyVehicleStruck" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_company_vehicle_struck_by_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCompanyVehicleStruckby" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                            </td>
                            <td class="lable_td_width_1">
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_non_collision_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNonCollision" runat="server"></asp:Label>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNonCollisionText" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                            </td>
                            <td class="lable_td_width_1">
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_case_details_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_drivers_lic_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriversLic" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_and_class_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblStateandClass" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_expiry_state_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblExpireDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_city_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriverState" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_nearest_cross_street_intersection_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNearestCrossStreet" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_type_of_roadway_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTypeofRoadway" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_road_condition_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblRoadCondition" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_time_of_day_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTimeofDay" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                                <%-- <asp:Label ID="Label2" runat="server"></asp:Label>--%>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_weather_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblWeather" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_traffic_condition_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTrafficCondition" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_traffic_controls_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTrafficControls" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_operating_speed_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblOperatingSpeed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_speed_limit_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblSpeedLimit" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_struck_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleStruck" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_struck_by_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblVehicleStruckby" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCollisionType" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_location_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCollisionLocation" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_direction_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCollisionDirection" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_non_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNonCollisionType" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_number_of_vehicles_involved_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNumberofVehicleInvolved" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_number_of_vehicles_towed_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNumberofVehicletowed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_injured_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriverInjured" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_passenger_injured_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPassengerInjured" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_situation_issued_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCituationIssued" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_number_of_people_injured_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNoofPeopleInjured" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                               <%=LocalResources.GetLabel("app_number_of_fatalities_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNoofPeopleKilled" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_at_home_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAtWhom" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_at_fault_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAtfault" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_contributory_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblContributory" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_cross_vehicle_weight_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblGrossVehicleWeight" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp
                            </td>
                            <td colspan="2" class="text_font_normal align_right">
                                <%=LocalResources.GetLabel("app_combined_gross_vehicle_weight_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCombinedGrossVehicleWeight" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_dot_vehicle_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDotVehicle" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_dot_driver_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDotDriver" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_seat_belt_used_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblSeatBeltUsed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_air_bag_equipped_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAirBagEquipped" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_air_bag_deployed_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAirBagDeployed" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_cellphone_use_during_operation_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblCellphoneinUse" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_computer_use_during_operation_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblComputerInUse" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_special_equipment_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblSpecialEquipment" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                                <%--<asp:Label ID="Label3" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_location_of_impact_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblLocationofImpact" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_injured_text")%>:
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
                    <%=LocalResources.GetLabel("app_description_of_damage_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_heavy_text")%>:
                            </td>
                            <td class="lable_td_width_1" colspan="5">
                                <asp:Label ID="lblHeavyDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_moderate_text")%>:
                            </td>
                            <td class="lable_td_width_1" colspan="5">
                                <asp:Label ID="lblModerateDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_light_text")%>:
                            </td>
                            <td class="lable_td_width_1" colspan="5">
                                <asp:Label ID="lblLightDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_public_vehicle_info_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_name_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriverAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_contact_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblDriverContact" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_owner_name_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblOwnerName" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_owner_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblOwnerAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_owner_contact_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblOwnerContact" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicVehicleId" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vin_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicVehicleVIN" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_license_number_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicLicenseNumber" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicVehicleMake" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_model_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicVehicleModel" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicVehicleType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_year_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicYear" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_state_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicState" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                                <%--<asp:Label ID="Label3" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_cross_vehicle_weight_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicGrossVehicleWeight" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td colspan="2" class="text_font_normal align_right">
                                <%=LocalResources.GetLabel("app_combined_gross_vehicle_weight_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicCombinedVehicleWeight" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_dot_vehicle_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicDotVehicle" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_dot_vehicle_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicDotDriver" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_seat_belt_used_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicSeatBeltUsed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_air_bag_equipped_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicAirBagEquipped" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_air_bag_deployed_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicAirBagDeployed" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_cellphone_use_during_operation_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicCellphoneinUse" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_computer_use_during_operation_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicComputerInUse" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_special_equipment_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicSpecialEquipment" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <asp:Label ID="lblPublicSpecialEquipmentText" runat="server"></asp:Label>
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                                <%--<asp:Label ID="Label3" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_location_of_impact_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicLocationofImpact" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_driver_injured_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicDriverInjured" runat="server"></asp:Label>
                            </td>
                            <td class="lable_td_width_1" colspan="2">
                                <asp:Label ID="lblPublicDriverInjuredText" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_passenger_injured_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicPassengerInjured" runat="server"></asp:Label>
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPublicPassengerInjuredText" runat="server"></asp:Label>
                            </td>
                            <td colspan="2" class="text_font_normal align_right">
                                <%=LocalResources.GetLabel("app_number_total_vehicle_occupant_injuries_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblTotalvehicleOccupant" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_description_public_vehicle_damage_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_heavy_text")%>:
                            </td>
                            <td class="lable_td_width" colspan="5">
                                <asp:Label ID="lblPublicHeavyDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_moderate_text")%>:
                            </td>
                            <td class="lable_td_width" colspan="5">
                                <asp:Label ID="lblPublicModerateDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_light_text")%>:
                            </td>
                            <td class="lable_td_width" colspan="5">
                                <asp:Label ID="lblPublicLightDamage" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_pedestrain_incident_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_name_of_the_pedestrain_involved_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblNameofPedestrian" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPedestrianAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_phone_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPedestrainPhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_sex_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPedestrainSex" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_age_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPedestrainAge" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPedestrainCollisionType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5" class="lable_td_width_1">
                                <asp:Label ID="lblPedestrainDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_bicycle_incident_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_name_person_involved_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicycleNameofPerson" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicyclePersonAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_phone_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicyclePersonPhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_sex_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicyclePersonSex" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_age_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicyclePersonAge" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblBicycleCollisionType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5" class="lable_td_width_1">
                                <asp:Label ID="lblBicycleDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_animal_incident_text")%>:
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_name_of_animal_involved_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAnimalName" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_place_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPlace" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                &nbsp;
                            </td>
                            <td class="lable_td_width_1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblAnimalCollisionType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5" class="lable_td_width_1">
                                <asp:Label ID="lblAnimalDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                     <%=LocalResources.GetLabel("app_fixed_object_incident_text")%>: 
                </div>
                <div class="div_controls_from_left">
                    <table>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_property_owner_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPropertyOwner" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_address_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPropertyAddress" runat="server"></asp:Label>
                            </td>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_contact_information_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblContactInformation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_collision_type_text")%>:
                            </td>
                            <td class="lable_td_width_1">
                                <asp:Label ID="lblPropertyCollisionType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5" class="lable_td_width_1">
                                <asp:Label ID="lblPropertyDesc" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal">
                                <%=LocalResources.GetLabel("app_physical_description_of_property_text")%>:
                            </td>
                            <td colspan="5" class="lable_td_width_1">
                                <asp:Label ID="lblPhysicalPropertyDesc" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
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
                                                <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%=LocalResources.GetLabel("app_contact_information_text")%>:&nbsp;&nbsp; &nbsp;
                                                <b>
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
                                                <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%=LocalResources.GetLabel("app_contact_information_text")%>:&nbsp;&nbsp; &nbsp;
                                                <b>
                                                    <%#Eval("c_contact_info") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_font_normal" valign="top">
                                <%=LocalResources.GetLabel("app_employee_interview(s)_text")%>
                                :
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
                                                <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                                    <%#Eval("c_name") %></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="width_250" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%=LocalResources.GetLabel("app_contact_information_text")%>:&nbsp;&nbsp; &nbsp;
                                                <b>
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
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_root_cause_analysis_infornation_text")%>
                    :
                </div>
                <br />
                <div class="div_long_textbox">
                    <div class="text_font_normal">
                        <%=LocalResources.GetLabel("app_root_cause_analysis_details_text")%>
                        :
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
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_custom_fields_text")%>:
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
                                <%=LocalResources.GetLabel("app_custom_13_text")%>:
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
                <%--<div class="label_required_field">
                    *
                    <%=LocalResources.GetLabel("app_required_fields_text")%>
                </div>--%>
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
                                    OnClick="btnSendtoMyEmail_footer_Click" CssClass="cursor_hand" />
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
            <%--<div class="footer">
                <div class="left ">
                    <%=LocalResources.GetText("wp_app_release_number")%>
                </div>
                <div class="right ">
                    <%=LocalResources.GetText("wp_powered_by_content")%>
                </div>
                <br />
                <br />
            </div>
            --%><asp:Button ID="btnUploadFile" CssClass="cursor_hand" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlMultiple" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
                padding-left: 0px;  padding-right: 0px;" DefaultButton="btnSendMutiple">
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
                                Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>"
                                CssClass="cursor_hand" OnClick="btnSendMutiple_Click" />
                            <asp:Button ID="btnSendMultipleMobile" OnClientClick="ResetScroll();" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" ValidationGroup="mobile"
                                OnClick="btnSendMultipleMobile_Click" CssClass="cursor_hand" />
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
</asp:Content>
