<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samhrismp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.HRISIntegration.samhrismp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
        function vali_type(sender, args) {
            var id_value = document.getElementById('<%=FileUpload1.ClientID %>').value;

            if (id_value != '') {
                var valid_extensions = /(.csv|.xlsx)$/i;
                if (valid_extensions.test(id_value)) {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;

                }
            }

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
                'width': 732,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'Popup/p-samdhrislo-01.aspx',
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
            isValid = Page_ClientValidate('samhrismp');
            if (isValid) {
                isValid = Page_ClientValidate('samhrismp_time');
            }
            return isValid;

        }
    </script>     
    <asp:ValidationSummary class="validation_summary_error" ID="vs_samhris" runat="server"
        ValidationGroup="samhrismp"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
        ValidationGroup="samhrismp_time"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvValidateTime" EnableClientScript="true" ClientValidationFunction="checkTime"
        ValidationGroup="samhrismp_time" runat="server" ErrorMessage="Please select valid time">&nbsp;</asp:CustomValidator>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_single_file_manual_upload_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td colspan="2" style="padding-left: 75px;">
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td>
                        <asp:Button ID="btnSelectHrisCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_select_hris_csv_file_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="padding-left: 43px;">
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_sample_hris_file_text")%>:
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnDownloadSampleHrisCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_sample_hris_csv_file_button_text %>"
                            OnClick="btnDownloadSampleHrisCsvFile_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
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
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvServerUrl" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtSftpServerUrl" ErrorMessage="<%$ TextResourceExpression: app_uri_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_sftp_server_uri_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSftpServerUrl" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSftpSeverPort" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtSftpServerPort" ErrorMessage="<%$ TextResourceExpression: app_port_error_empty %>">&nbsp;
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
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtUserName" ErrorMessage="<%$ TextResourceExpression: app_user_name_error_empty %>">&nbsp;
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
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvpassword" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtPassword" ErrorMessage="<%$ TextResourceExpression: app_password_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_password_text")%>:
                    </td>
                    <td class="align_left">
                        <input id="txtPassword" name="password" runat="server" />
                        <%--<asp:TextBox ID="txtPassword" TextMode="Password" CssClass="textbox_long" runat="server"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvcsvFilename" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtHrisCsvFileName" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_hris_csv_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHrisCsvFileName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOccuranceEvery" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtOccursEvery" ErrorMessage="<%$ TextResourceExpression: app_occurrence_every_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvEvery" runat="server" ErrorMessage="<%$ TextResourceExpression: app_every_error_wrong%>"
                            ControlToValidate="txtOccursEvery" ValidationGroup="samhrismp" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_occurs_every_text")%>:
                    </td>
                    <td class="align_left" colspan="2">
                        <asp:TextBox ID="txtOccursEvery" CssClass="textbox_50" runat="server"></asp:TextBox>&nbsp;&nbsp;Day(s)
                        &nbsp;<%=LocalResources.GetLabel("app_at_text")%>
                        <asp:RequiredFieldValidator ID="rfvOccuranceTime" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtHours" ErrorMessage="Please enter the time">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter valid time"
                            ValidationGroup="samhrismp" ControlToValidate="txtHours" ValidationExpression="^[0-9]+:\d\d$">&nbsp;
                        </asp:RegularExpressionValidator><%--^[0-9][0-9]:[0-9][0-9]$--%>
                        <asp:TextBox ID="txtHours" CssClass="textbox_75" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlTimeConversion" CssClass="textbox_50" runat="server">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="align_left" colspan="2">
                        <%=LocalResources.GetLabel("app_beginning_text")%>:&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="regexDate" runat="server" ControlToValidate="txtBegining"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_date_error_wrong %>" Display="Dynamic"
                            ValidationGroup="samhrismp">&nbsp;</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvBegining" runat="server" ValidationGroup="samhrismp"
                            ControlToValidate="txtBegining" ErrorMessage="<%$ TextResourceExpression: app_date_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBegining" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtBegining"
                            runat="server">
                        </asp:CalendarExtender>
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDisplayHrisLogs" runat="server" Text="<%$ LabelResourceExpression: app_display_hris_logs_button_text %>"
                            CssClass="displayHris cursor_hand" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnSaveHrisSftpInformation" runat="server" OnClientClick="return validateAll()"
                            Text="<%$ LabelResourceExpression: app_save_hris_sftp_information_button_text %>"
                            OnClick="btnSaveHrisSftpInformation_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnSelectHrisCsvFile"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
            padding-left: 0px;  padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_samhrismp" runat="server"
                        ValidationGroup="vsFileupload"></asp:ValidationSummary>
                    <div class="uploadpopup_header">
                        <asp:CustomValidator ID="cvFileupload" runat="server" ValidationGroup="vsFileupload"
                            ErrorMessage="<%$ TextResourceExpression: app_select_csv_file_error_empty %>"
                            ClientValidationFunction="vali_type">&nbsp;</asp:CustomValidator>
                        <div class="left">
                            <%=LocalResources.GetLabel("app_upload_file_text")%>:
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
                    <%=LocalResources.GetLabel("app_select_file_text")%>:
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="525" size="70" />
                    <br />
                    <br />
                    <br />
                    <div class="uploadbutton">
                        <asp:Button ID="btnUploadAttachements" runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            CssClass="cursor_hand" OnClick="btnUploadAttachements_Click" ValidationGroup="vsFileupload" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
