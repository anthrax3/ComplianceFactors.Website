﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.saandmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
    <script type="text/javascript" language="javascript">
        function confirmremove() {
            if (confirm('Are you sure you want to remove this file.?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">
        function ValidateFileUpload(source, args) {
            var fuData = document.getElementById('<%= fupFiles.ClientID %>');
            var FileUploadPath = fuData.value;
            if (FileUploadPath == '') {
                // There is no file selected
                window.scrollTo = function () { }
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function HideFileValidationSummary() {
            $("#<%=vsFileUpload.ClientID%>").hide();
        }

        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {

            var oFileUpload = document.getElementsByName('<%=fupFiles.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);
            HideFileValidationSummary();

        }

    </script>
    <br />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saandmp" runat="server"
        ValidationGroup="saandmp"></asp:ValidationSummary>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveDigitalMedia" ValidationGroup="saandmp" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_digital_media_file_information_text %>" OnClick="btnHeaderSaveDigitalMedia_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
             <%=LocalResources.GetLabel("app_digital_media_file_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDigitalMediaId" runat="server" ValidationGroup="saandmp"
                            ControlToValidate="txtDigitalMediaId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *  <%=LocalResources.GetLabel("app_digital_media_file_id_text")%>: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtDigitalMediaId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDigitalMediaTitle" runat="server" ValidationGroup="saandmp"
                            ControlToValidate="txtDigitalMediaTitle" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *  <%=LocalResources.GetLabel("app_digital_media_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDigitalMediaTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDigitalMediaDescription" runat="server" ValidationGroup="saandmp"
                            ControlToValidate="txtDigitalMediaDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *  <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDigitalMediaDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_type_text")%>: 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFileType" DataValueField="s_file_id_pk" DataTextField="s_file_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_upload_digital_media_file_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <asp:Button ID="btnAttachment" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_upload_digital_media_file_button_text %>" />
                        <asp:LinkButton ID="lnkFileName" runat="server" CssClass="cursor_hand" OnClick="lnkFileName_Click"></asp:LinkButton>
                        <asp:Button ID="btnView" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" OnClick="btnView_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" runat="server"
                            Text="<%$ LabelResourceExpression: app_remove_button_text %>"  CssClass="cursor_hand" OnClick="btnRemove_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveDigitalMedia" ValidationGroup="saandmp" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_digital_media_file_information_text %>" OnClick="btnFooterSaveDigitalMedia_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:ModalPopupExtender ID="mpeAddAttachment" runat="server" TargetControlID="btnAttachment"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeEditAttachment" runat="server" TargetControlID="btnEdit"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                         <%=LocalResources.GetLabel("app_add_digital_media_file_text")%>:
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
            <div class="uploadpanel font_normal">
                <asp:ValidationSummary class="validation_summary_error_popup" ID="vsFileUpload" runat="server"
                    ValidationGroup="digitalmediaupload" />
                <asp:CustomValidator ValidationGroup="digitalmediaupload" ID="cvFileUpload" runat="server"
                    EnableClientScript="true" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty%>" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <%=LocalResources.GetLabel("app_select_file_text")%>:
                            </td>
                            <td>
                                <asp:FileUpload ID="fupFiles" runat="server" Width="460" size="60" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <div class="multiple_button">
                    <asp:Button ID="btnUploadAttachment" ValidationGroup="digitalmediaupload" runat="server"
                        Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand" OnClick="btnUploadAttachment_Click" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
            </div>
            <br />
        </div>
    </asp:Panel>
</asp:Content>
