<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samdimpmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Imports.samdimpmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

    </script>
    <script language="javascript" type="text/javascript">

        //Function to Show ModalPopUp
        function Showpopup(clicked_id) {
            if (clicked_id == "ContentPlaceHolder1_btnSelectFacilitiesCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectCoursesCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectRoomCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectBaseCurriculamCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectEnrollmentsCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectLearningHistoryCsvFile") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnSelectMatrixAssignment") {
                document.getElementById('<%=btnFacilityUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnRoomUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCourseUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnCurriculumUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnEnrollmentUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnLearningHistoryUpload.ClientID%>').style.display = "none";
                document.getElementById('<%=btnMatrixAssignmentUpload.ClientID%>').style.display = "inline";
                
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {
            var oFileUpload = document.getElementsByName('<%=FileUpload1.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);
            HideFileValidationSummary();

        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtHours.ClientID %>").watermark("HH:MM");
            $("#<%=txtHours.ClientID %>").click(
			function () {
			    $("#<%=txtHours.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        function checkTime(sender, args) {
            var timeStr = document.getElementById('<%=txtHours.ClientID %>').value;
            var regex = /^(\d{1,2}):(\d{2})?$/;
            var timArr = timeStr.match(regex);
            hour = timArr[1];
            minute = timArr[2];
            if (hour < 0 || hour > 12) {
                args.IsValid = false;
            }
            if (minute < 0 || minute > 59) {
                args.IsValid = false;
            }

        }
    </script>
    <script type="text/javascript">
        function validateAll() {
            var isValid = false;
            isValid = Page_ClientValidate('samdimpmp');
            if (isValid) {
                isValid = Page_ClientValidate('samdimpmp_time');
            }
            return isValid;

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".displayImportLog").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 740,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'Popup/p_samddimplo-01.aspx',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }
            });
        });
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_samdimpmp" runat="server"
        ValidationGroup="samdimpmp"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
        ValidationGroup="samdimpmp_time"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvValidateTime" EnableClientScript="true" ClientValidationFunction="checkTime"
        ValidationGroup="samdimpmp_time" runat="server" ErrorMessage="Please select valid time">&nbsp;</asp:CustomValidator>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_single_file_manual_upload_text")%>:
        </div>
        <br />
        <div class=" div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectFacilitiesCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_facilities_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_facilities_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleFacilitiesFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_facilities_csv_file_button_text %>"
                            OnClick="btnSampleFacilitiesFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectRoomCsvFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_rooms_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_rooms_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleRoomFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_rooms_csv_file_button_text %>"
                            OnClick="btnSampleRoomFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectCoursesCsvFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_courses_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_courses_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleCoursesFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_courses_csv_file_button_text %>"
                            OnClick="btnSampleCoursesFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectBaseCurriculamCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_base_curricula_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_base_curricula_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleBaseCurriculamFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_base_curricula_csv_file_button_text %>"
                            OnClick="btnSampleBaseCurriculamFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectEnrollmentsCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_enrollments_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_enrollments_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleEnrollmentsCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_enrollments_csv_file_button_text %>"
                            OnClick="btnSampleEnrollmentsCsvFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectLearningHistoryCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_learning_history_csv_file_button_text %>"
                            OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="width_200">
                        <%=LocalResources.GetLabel("app_learning_history_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleLearningHistoryCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_learning_history_csv_file_button_text %>"
                            OnClick="btnSampleLearningHistoryCsvFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Upload Matrix Assignment:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectMatrixAssignment" CssClass="cursor_hand" runat="server"
                            Text="Select Matrix Assignment csv file" OnClientClick="Showpopup(this.id);" />
                    </td>
                    <td colspan="2">
                        Sample Matrix Assignment:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleMatrixAssignment" CssClass="cursor_hand" runat="server"
                            Text="Sample Matrix Assignment csv file" OnClick="btnSampleMatrixAssignment_Click" />
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
            <%=LocalResources.GetLabel("app_sftp_server_and_synchronization_info_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvServerUrl" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtSftpServerUrl" ErrorMessage="Please enter the server url">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_sftp_server_uri_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSftpServerUrl" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding-left: 110px">
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSftpSeverPort" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtSftpServerPort" ErrorMessage="Please enter the server port">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_sftp_server_port_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSftpServerPort" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtUserName" ErrorMessage="Please enter user name">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_username_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvpassword" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtPassword" ErrorMessage="Please enter password">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_password_text")%>:
                    </td>
                    <td class="align_left">
                        <input id="txtPassword" name="password" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnrollments" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_enrollments_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkEnrollments" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLearningHistory" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_learning_history_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkLearningHistory" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOccuranceEvery" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtOccursEvery" ErrorMessage="Please enter the ocuurance every">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvEvery" runat="server" ErrorMessage="Plese enter only the numbers"
                            ControlToValidate="txtOccursEvery" ValidationGroup="samdimpmp" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_occurs_every_text")%>:
                    </td>
                    <td class="align_left" colspan="2">
                        <asp:TextBox ID="txtOccursEvery" CssClass="textbox_50" runat="server"></asp:TextBox>&nbsp;&nbsp;<%=LocalResources.GetLabel("app_days_text")%>
                        &nbsp;<%=LocalResources.GetLabel("app_at_text")%>
                        <asp:RequiredFieldValidator ID="rfvOccuranceTime" runat="server" ValidationGroup="samdimpmp"
                            ControlToValidate="txtHours" ErrorMessage="Please enter the time">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvOccuranceTimeValid" runat="server" ErrorMessage="Please enter valid time"
                            ValidationGroup="samdimpmp" ControlToValidate="txtHours" ValidationExpression="^[0-9]+:\d\d$">&nbsp;
                        </asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtHours" CssClass="textbox_75" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlTimeConversion" CssClass="textbox_50" runat="server">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="align_left" colspan="3">
                        <asp:RegularExpressionValidator ID="regexDate" runat="server" ControlToValidate="txtBegining"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="Please enter the valid date" Display="Dynamic" ValidationGroup="samdimpmp">&nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_beginning_text")%>:&nbsp;&nbsp;
                        <asp:TextBox ID="txtBegining" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtBegining"
                            runat="server">
                        </asp:CalendarExtender>
                        &nbsp;&nbsp;<asp:Button ID="btnDisplayImportLogs" runat="server" CssClass="displayImportLog cursor_hand"
                            Text="<%$ LabelResourceExpression: app_display_import_logs_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_left" colspan="2">
                        <asp:Button ID="btnSaveDataImportSftpInformation" runat="server" CssClass="cursor_hand"
                            OnClientClick="return validateAll()" Text="<%$ LabelResourceExpression: app_save_data_import_sftp_info_text %>"
                            OnClick="btnSaveDataImportSftpInformation_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:ModalPopupExtender ID="mpeFacilityAttachment" runat="server" TargetControlID="btnSelectFacilitiesCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeRoomAttachment" runat="server" TargetControlID="btnSelectRoomCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeCourseAttachment" runat="server" TargetControlID="btnSelectCoursesCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeCurriculumAttachment" runat="server" TargetControlID="btnSelectBaseCurriculamCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeEnrollmentAttachment" runat="server" TargetControlID="btnSelectEnrollmentsCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeLearningHistoryAttachment" runat="server" TargetControlID="btnSelectLearningHistoryCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
         <asp:ModalPopupExtender ID="mpeMatrixAssignment" runat="server" TargetControlID="btnSelectMatrixAssignment"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background"
            Style="display: none; padding-left: 0px; padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_samhrismp" runat="server"
                        ValidationGroup="vsFileupload"></asp:ValidationSummary>
                    <div class="uploadpopup_header">
                        <asp:CustomValidator ID="cvFileupload" runat="server" ValidationGroup="vsFileupload"
                            ErrorMessage="Please select the csv file" ClientValidationFunction="vali_type">&nbsp;</asp:CustomValidator>
                        <div class="left">
                            Upload File:
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
                <div class="uploadpanel">
                    Select File:
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="525" size="70" />
                    <br />
                    <br />
                    <br />
                    <div class="uploadbutton">
                        <asp:Button ID="btnFacilityUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnFacilityUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnRoomUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnRoomUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnCourseUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnCourseUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnCurriculumUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnCurriculumUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnEnrollmentUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnEnrollmentUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnLearningHistoryUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                            OnClick="btnLearningHistoryUpload_Click" ValidationGroup="vsFileupload" />
                        <asp:Button ID="btnMatrixAssignmentUpload" runat="server" Text="Upload File" CssClass="cursor_hand"
                           OnClick="btnMatrixAssignmentUpload_Click"  ValidationGroup="vsFileupload" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="Cancel" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
