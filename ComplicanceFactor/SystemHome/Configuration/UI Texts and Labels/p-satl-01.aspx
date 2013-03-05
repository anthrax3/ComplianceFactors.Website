<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-satl-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.Add_text_Locale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 650px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 370px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnPreview.ClientID %>").click(function () {
                $('#divPreview').html($('#<%=txtUiText.ClientID %>').val());

            });
        });
        //reset scroll position popup
        function ResetScroll() {
            $('#divPreview').animate({ scrollTop: 0 });

        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <div class="div_header_650">
            UI Text:
        </div>
        <br />
        <asp:ValidationSummary class="validation_summary_error" ID="vssatl" runat="server"
            ValidationGroup="satl" />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td class="align_left" colspan="8">
                        <asp:RequiredFieldValidator ID="rfvText" runat="server" ValidationGroup="satl" ControlToValidate="txtUiText"
                            ErrorMessage="Please enter the text.">&nbsp;
                        </asp:RequiredFieldValidator>
                        <textarea id="txtUiText" runat="server" rows="10" cols="77"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnSaveUiText" ValidationGroup="satl" CssClass="cursor_hand" Text="Save UI Text"
                    runat="server" OnClick="btnSaveUiText_Click" />
            </div>
            <div class="right">
                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    runat="server" Text="Cancel" />
            </div>
            <center>
                <asp:Button ID="btnPreview" CssClass="cursor_hand" OnClientClick="ResetScroll();"
                    Text="Preview" runat="server" />
            </center>
            <div class="clear">
            </div>
        </div>
        <br />
    </div>
    <div class="font_normal">
        <asp:Panel ID="pnlPreview" runat="server" CssClass="modalPopup_width_500" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlPreviewHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                        UI Text Preview:
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
                    <asp:Button ID="btnClosePreview" CssClass="cursor_hand" runat="server" Text="Close" />
                </center>
            </div>
            <div class="clear">
            </div>
        </asp:Panel>
    </div>
    </div>
    <asp:ModalPopupExtender ID="mpPreview" runat="server" TargetControlID="btnPreview"
        OkControlID="btnClosePreview" CancelControlID="imgClosePreview" PopupControlID="pnlPreview"
        BackgroundCssClass="transparent_class" DropShadow="false" PopupDragHandleControlID="pnlPreviewHeading">
    </asp:ModalPopupExtender>
</asp:Content>
