<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saaloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Splash_Pages.Locale.saaloc_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 800px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 350px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnPreview.ClientID %>").click(function () {
                $('#divPreview').html($('#<%=txtSplashPage.ClientID %>').val());
            });
        });
        //reset scroll position popup
        function ResetScroll() {
            $('#divPreview').animate({ scrollTop: 0 });

        }
    </script>
    <div id="content">
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <asp:HiddenField ID="hdSplashId" runat="server" />
        <%--Heading--%>
        <div class="div_header_800" id="divLocaleHeader" runat="server">
           <%=LocalResources.GetLabel("app_splash_page_text")%>:
        </div>
        <div>
            <br />
            <asp:ValidationSummary class="validation_summary_error" ID="vs_saaloc" runat="server"
                ValidationGroup="saaloc" />
            <div class="div_controls font_1">
                <asp:RequiredFieldValidator ID="rfvContent" runat="server" ValidationGroup="saaloc"
                    ControlToValidate="txtSplashPage" ErrorMessage="<%$ TextResourceExpression: app_splash_details_error_empty %>">&nbsp;
                </asp:RequiredFieldValidator>
                <textarea id="txtSplashPage" runat="server" rows="14" cols="92"></textarea>
            </div>
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="paging_800">
                    <tr>
                        <td class="align_left">
                            <asp:Button ID="btnSave" ValidationGroup="saaloc" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>" OnClick="btnSave_Click" />
                        </td>
                        <td class="align_center">
                            <asp:Button ID="btnPreview" ValidationGroup="saaloc" runat="server" Text="<%$ LabelResourceExpression: app_preview_button_text %>"
                                OnClientClick="ResetScroll();" />
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                                Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="font_normal">
            <asp:Panel ID="pnlPreview" runat="server" CssClass="modalPopup_width_500 modal_popup_background" Style="display: none;
                padding-left: 0px;  padding-right: 0px;">
                <asp:Panel ID="pnlPreviewHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            <%=LocalResources.GetLabel("app_splash_preview_text")%>:
                        </div>
                        <asp:ImageButton ID="imgClosePreview" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <br />
                <div class="div_padding_10 font_normal" id="divPreview" style="height: 178px; overflow-x: hidden;
                    overflow: auto">
                </div>
                <br />
                <div class="div_padding_10">
                    <center>
                        <asp:Button ID="btnClosePreview" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_close_button_text %>" />
                    </center>
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </div>
        <asp:ModalPopupExtender ID="mpPreview" runat="server" TargetControlID="btnPreview"
            OkControlID="btnClosePreview" CancelControlID="imgClosePreview" PopupControlID="pnlPreview"
            BackgroundCssClass="transparent_class" DropShadow="false" PopupDragHandleControlID="pnlPreviewHeading">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>
