<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.saandin_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=button],input[type=submit]
        {
           cursor:pointer;
            }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
        });

        $(document).ready(function () {

            $("#btnManageLocale").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 820,
                'height': 500,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Documents/Locale/savloc-01.aspx?mode=create',
                'onComplete': function () {
                    $('#fancybox-frame').load(function () {
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
        function confirmremove() {
            if (confirm('Are you sure you want to remove this file.?') == true)
                return true;
            else
                return false;

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saedin" runat="server"
        ValidationGroup="saedin"></asp:ValidationSummary>
        <asp:HiddenField ID="hdNav_selected" runat="server" />
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saedin" runat="server" 
                            Text="<%$ LabelResourceExpression: app_save_new_document_button_text %>" onclick="btnHeaderSave_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderReset" CssClass="align_right" runat="server" 
                            Text="<%$ LabelResourceExpression: app_reset_button_text %>" onclick="btnHeaderReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderCancel" CssClass="align_right" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" onclick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_information_us_english_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td valign="top">
                        * <%=LocalResources.GetLabel("app_document_id_text")%>:
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtDocumentId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDocumentId" runat="server" style=" display:none" ValidationGroup="saedin"
                            ControlToValidate="txtDocumentId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                    <td class="align_right" valign="top">
                        * <%=LocalResources.GetLabel("app_document_name_text")%>:
                    </td>
                    <td style="text-align: right">
                        <asp:TextBox ID="txtDocumentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" style=" display:none"  ValidationGroup="saedin"
                            ControlToValidate="txtDocumentName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        * <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="800px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" style=" display:none"  ValidationGroup="saedin"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_version_text")%>:
                    </td>
                    <td style=" text-align:left">
                        <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <%=LocalResources.GetLabel("app_document_file_text")%>:
                    </td>
                    <td class="align_left" colspan="4">
                        <asp:Button ID="btnUploadDocument" runat="server" Text="<%$ LabelResourceExpression: app_upload_file_button_text %>" />
                        <br />
                        <asp:LinkButton ID="lnkFileName" runat="server" CssClass="cursor_hand" 
                            onclick="lnkFileName_Click"></asp:LinkButton>
                        <asp:Button ID="btnView" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" 
                            onclick="btnView_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        <asp:Button ID="btnRemove" runat="server" OnClientClick="return confirmremove();"
                            Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server" DataTextField="s_status_name"
                            DataValueField="s_status_id_pk">
                            <%--                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_text")%>:
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlDocumentType" CssClass="ddl_user_advanced_search" runat="server" DataTextField="s_document_type_name"
                            DataValueField="s_document_type_system_id_pk">
                            <%--                            <asp:ListItem>Standard Operating Procedure(SOP)</asp:ListItem>
                            <asp:ListItem>Material Safety Data Sheet(MSDS)</asp:ListItem>
                            <asp:ListItem>Best Practices</asp:ListItem>
                            <asp:ListItem>CheckLists</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <input type="button" id="btnManageLocale" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnFooterSave" ValidationGroup="saedin" runat="server" 
                        Text="<%$ LabelResourceExpression: app_save_new_document_button_text %>" onclick="btnHeaderSave_Click" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterReset" CssClass="align_right" runat="server" 
                        Text="<%$ LabelResourceExpression: app_reset_button_text %>" onclick="btnHeaderReset_Click" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterCancel" CssClass="align_right" runat="server" 
                        Text="<%$ LabelResourceExpression: app_cancel_button_text %>" onclick="btnHeaderCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ModalPopupExtender ID="mpeAddAttachment" TargetControlID="btnUploadDocument"
        BackgroundCssClass="transparent_class" PopupControlID="pnlAddAttachment" OkControlID="imgClose" 
        DropShadow="false" PopupDragHandleControlID="pnlUploadFileHeading" OnCancelScript="cleartext()" CancelControlID="btnCancel"
        OnOkScript="cleartext()" runat="server">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeEditAttachment" runat="server" TargetControlID="btnEdit"
        PopupControlID="pnlAddAttachment" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlAddAttachment" Style="display: none;  padding-left: 0px;
        padding-right: 0px" runat="server" CssClass="modalPopup_upload modal_popup_background">
        <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                        <asp:Label ID="lblHeading" Text="<%$ LabelResourceExpression: app_add_attachement_text %>" runat="server"></asp:Label>
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
                    ValidationGroup="vs_documentUpload" />
                <asp:CustomValidator ValidationGroup="vs_documentUpload" ID="cvFileUpload" runat="server"
                    EnableClientScript="true" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty %>" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="middle">
                                <%=LocalResources.GetLabel("app_select_file_text")%>
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
                    <asp:Button ID="btnUploadAttachment" runat="server" ValidationGroup="vs_documentUpload"
                        OnClick="btnUploadDocument_Click" Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
            </div>
            <br />
        </div>
    </asp:Panel>
</asp:Content>
