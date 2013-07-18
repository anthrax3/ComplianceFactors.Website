<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="samdexpmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.Popup.samdexpmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 700px;
        }
    </style>
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
            isValid = Page_ClientValidate('samdexpmp');
            if (isValid) {
                isValid = Page_ClientValidate('samdexpmp_time');
            }
            return isValid;

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".displayHris").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 730,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '/SystemHome/Configuration/DataExports/Popup/p-samdexplo-01.aspx',
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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_samdexpmp" runat="server"
        ValidationGroup="samdexpmp"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
        ValidationGroup="samdexpmp_time"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvValidateTime" EnableClientScript="true" ClientValidationFunction="checkTime"
        ValidationGroup="samdexpmp_time" runat="server" ErrorMessage="Please select valid time">&nbsp;</asp:CustomValidator>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="content">
        <div class="content_area_long">
            <div class="div_header_popup_1">
                <%=LocalResources.GetLabel("app_single_file_manual_upload_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadHrisCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_hris_csv_file_button_text %>"
                                OnClick="btnDownloadHrisCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadFacilitiesCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_facilities_csv_file_button_text %>"
                                OnClick="btnDownloadFacilitiesCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadRoomsCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_rooms_csv_file_button_text %>"
                                OnClick="btnDownloadRoomsCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadCoursesCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_courses_csv_file_button_text %>"
                                OnClick="btnDownloadCoursesCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadBaseCurriculamCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_base_curriculum_csv_file_button_text %>"
                                OnClick="btnDownloadBaseCurriculamCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadEnrollmentsCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_enrollments_csv_file_button_text %>"
                                OnClick="btnDownloadEnrollmentsCsvFile_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_download_file_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnDownloadLearningHistory" runat="server" Text="<%$ LabelResourceExpression: app_download_learning_history_csv_file_button_text %>"
                                OnClick="btnDownloadLearningHistory_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_popup_1">
                <%=LocalResources.GetLabel("app_sftp_server_and_synchronization_info_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvServerUrl" runat="server" ValidationGroup="samdexpmp"
                                ControlToValidate="txtSftpServerUrl" ErrorMessage="Please enter the server url">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_sftp_server_uri_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSftpServerUrl" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td style="padding-left: 60px">
                            &nbsp;
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvSftpSeverPort" runat="server" ValidationGroup="samdexpmp"
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
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup="samdexpmp"
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
                            <asp:RequiredFieldValidator ID="rfvpassword" runat="server" ValidationGroup="samdexpmp"
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
                            <asp:TextBox ID="txtHris" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_hiris_text")%>
                        </td>
                        <td class="align_left">
                            <asp:CheckBox ID="chkHris" CssClass="textbox_long" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCatalogOfferings" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_catalog_offering_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:CheckBox ID="chkCatalogOfferings" CssClass="textbox_long" runat="server" />
                        </td>
                        <td>
                            &nbsp;
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
                            <asp:CheckBox ID="chkLearningHistory" CssClass="textbox_long" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOccuranceEvery" runat="server" ValidationGroup="samdexpmp"
                                ControlToValidate="txtOccursEvery" ErrorMessage="Please enter the ocuurance every">&nbsp;
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfvEvery" runat="server" ErrorMessage="Plese enter only the numbers"
                                ControlToValidate="txtOccursEvery" ValidationGroup="samdexpmp" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                            *
                            <%=LocalResources.GetLabel("app_occurs_every_text")%>:
                        </td>
                        <td class="align_left" colspan="2">
                            <asp:TextBox ID="txtOccursEvery" CssClass="textbox_50" runat="server"></asp:TextBox>&nbsp;&nbsp;<%=LocalResources.GetLabel("app_days_text")%>
                            &nbsp;<%=LocalResources.GetLabel("app_at_text")%>
                            <asp:RequiredFieldValidator ID="rfvOccuranceTime" runat="server" ValidationGroup="samdexpmp"
                                ControlToValidate="txtHours" ErrorMessage="Please enter the time">&nbsp;
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfvOccuranceTimeValid" runat="server" ErrorMessage="Please enter valid time"
                                ValidationGroup="samdexpmp" ControlToValidate="txtHours" ValidationExpression="^[0-9]+:\d\d$">&nbsp;
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
                                ErrorMessage="Please enter the valid date" Display="Dynamic" ValidationGroup="samdexpmp">&nbsp;</asp:RegularExpressionValidator>
                            <%=LocalResources.GetLabel("app_beginning_text")%>:&nbsp;&nbsp;
                            <asp:TextBox ID="txtBegining" CssClass="textbox_75" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtBegining"
                                runat="server">
                            </asp:CalendarExtender>
                            &nbsp;&nbsp;&nbsp;<%--<asp:Button ID="btnDisplayExportLogs" runat="server" Text="<%$ LabelResourceExpression: app_display_export_logs_button_text %>" />--%>
                            <input type="button" class="displayHris cursor_hand" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_display_export_logs_button_text %>" />' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="align_left" colspan="2">
                            <asp:Button ID="btnSaveDataExportSftpInformation" runat="server" CssClass="cursor_hand"
                                OnClientClick="return validateAll()" Text="<%$ LabelResourceExpression: app_save_data_export_sftp_information_button_text %>"
                                OnClick="btnSaveDataExportSftpInformation_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                                OnClick="btnReset_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_popup_1">
                <br />
            </div>
        </div>
    </div>
</asp:Content>
