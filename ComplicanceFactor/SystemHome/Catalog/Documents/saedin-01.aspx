<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saedin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.saedin_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=button], input[type=submit]
        {
            cursor: pointer;
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

    </script>
    <script type="text/javascript" language="javascript">
        function ClearVersion() {

            document.getElementById('<%=txtNewVersionNumber.ClientID %>').value = '';
            document.getElementById('<%=chkCopyDocuments.ClientID %>').checked = false;
            document.getElementById('<%=chkCopyLocale.ClientID %>').checked = false;
            return false;
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {


            var editDocumentId = $('input#<%=hdDocumentId.ClientID %>').val();
            // Add and view  locale
            $("#btnManageLocale").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Documents/Locale/savloc-01.aspx?mode=edit&documentid=' + editDocumentId,
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
    <style type="text/css">
        .style1
        {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdDocumentId" runat="server" />
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saandin" runat="server"
        ValidationGroup="saandin"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saandin" runat="server" Text="<%$ LabelResourceExpression: app_save_new_document_button_text %>"
                            OnClick="btnHeaderSave_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderReset" CssClass="align_right" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderCancel" CssClass="align_right" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnHeaderCancel_Click" />
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
                        <asp:RequiredFieldValidator ID="rfvDocumentId" runat="server" Style="display: none"
                            ValidationGroup="saandin" ControlToValidate="txtDocumentId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                    <td style="text-align: right" valign="top">
                        * <%=LocalResources.GetLabel("app_document_name_text")%>:
                    </td>
                    <td style="text-align: right">
                        <asp:TextBox ID="txtDocumentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" Style="display: none"
                            ValidationGroup="saandin" ControlToValidate="txtDocumentName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        * <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="800px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Style="display: none"
                            ValidationGroup="saandin" ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_version_text")%>:
                    </td>
                    <td style="text-align:left">
                        <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="btnCreateNewVersion" runat="server" Text="<%$ LabelResourceExpression: app_create_new_version_button_text %>" />
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="btnViewAllVersion" runat="server" Text="<%$ LabelResourceExpression: app_view_all_version_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <%=LocalResources.GetLabel("app_document_file_text")%>:
                    </td>
                    <td class="align_left" colspan="4">
                        <asp:Button ID="btnAttachment" runat="server" Text="<%$ LabelResourceExpression: app_upload_file_button_text %>" />
                        <br />
                        <asp:LinkButton ID="lnkFileName" runat="server" CssClass="cursor_hand" OnClick="lnkFileName_Click"></asp:LinkButton>
                        <asp:Button ID="btnView" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" OnClick="btnView_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="style1" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnRemove" runat="server" OnClientClick="return confirmremove();"
                            Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand" OnClick="btnRemove_Click" />
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
                        <asp:DropDownList ID="ddlDocumentType" CssClass="ddl_user_advanced_search" runat="server"
                            DataTextField="s_document_type_name" DataValueField="s_document_type_system_id_pk">
                            <%--                            <asp:ListItem>Standard Operating Procedure(SOP)</asp:ListItem>
                            <asp:ListItem>Material Safety Data Sheet(MSDS)</asp:ListItem>
                            <asp:ListItem>Best Practices</asp:ListItem>
                            <asp:ListItem>CheckLists</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:right">
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
                    <asp:Button ID="btnFooterSave" ValidationGroup="saandin" runat="server" Text="<%$ LabelResourceExpression: app_save_new_document_button_text %>"
                        OnClick="btnHeaderSave_Click" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterReset" CssClass="align_right" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                        OnClick="btnHeaderReset_Click" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterCancel" CssClass="align_right" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                        OnClick="btnHeaderCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ModalPopupExtender ID="mpeAddAttachment" TargetControlID="btnAttachment" BackgroundCssClass="transparent_class"
        PopupControlID="pnlAddAttachment" OkControlID="imgClose" DropShadow="false" PopupDragHandleControlID="pnlUploadFileHeading" CancelControlID="btnCancel"
        OnCancelScript="cleartext()" OnOkScript="cleartext()" runat="server">
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
                                Select File:
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
                        Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand" OnClick="btnUploadAttachment_Click" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
            </div>
            <br />
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpeCreateNewVersion" TargetControlID="btnCreateNewVersion"
        CancelControlID="imgCloseVersionPopup" PopupControlID="pnlCreateNewVersion" BackgroundCssClass="transparent_class"
        OkControlID="btnCancelNewVersion" OnOkScript="ClearVersion()" DropShadow="false"
        PopupDragHandleControlID="pnlCreateNewCersionHeading" runat="server">
    </asp:ModalPopupExtender>
    <div class="font_normal">
        <asp:Panel ID="pnlCreateNewVersion" CssClass="modalPopup_width_620 modal_popup_background" Style="display: none;
            padding-left: 0px;  padding-right: 0px;" runat="server">
            <asp:Panel ID="pnlCreateNewCersionHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                        <%=LocalResources.GetLabel("app_create_new_version_text")%>:
                    </div>
                    <asp:ImageButton ID="imgCloseVersionPopup" CssClass="cursor_hand" Style="top: -15px;
                        right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                </div>
            </asp:Panel>
            <br />
            <asp:ValidationSummary class="validation_summary_error" ID="vssaedin" runat="server"
                ValidationGroup="saedin" />
            <asp:RequiredFieldValidator ID="rfvNewVersionNo" style=" display:none" ControlToValidate="txtNewVersionNumber" runat="server" ValidationGroup="saedin" ErrorMessage="<%$ TextResourceExpression: app_version_number_error_empty %>"></asp:RequiredFieldValidator>
            <div class="table_right">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_new_version_number_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewVersionNumber" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_copy_document_text")%>:
                        </td>
                        <td class="align_left">
                            <input id="chkCopyDocuments" type="checkbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_copy_locale_text")%>:
                        </td>
                        <td class="align_left">
                            <input id="chkCopyLocale" type="checkbox" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table cellpadding="0" cellspacing="0" class="button_600">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnSaveNewVersion" CssClass="cursor_hand" runat="server" ValidationGroup="saedin" Text="<%$ LabelResourceExpression: app_create_new_version_button_text %>"
                                OnClick="btnSaveNewVersion_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnResetNewVersion" CssClass="cursor_hand" OnClientClick="return ClearVersion();"
                                runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnCancelNewVersion" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    <asp:ModalPopupExtender ID="mpVersionList" runat="server" TargetControlID="btnViewAllVersion"
        OkControlID="btnCloseVersionList" CancelControlID="imgClosePreviousVersionList"
        PopupControlID="pnlViewPreviousVersionList" BackgroundCssClass="transparent_class"
        DropShadow="false" PopupDragHandleControlID="pnlViewPreviousVersionHeading">
    </asp:ModalPopupExtender>
    <div class=" font_normal">
        <asp:Panel ID="pnlViewPreviousVersionList" runat="server" CssClass="modalPopup_width_620 modal_popup_background"
            Style=" display:none; padding-left: 0px; padding-right: 0px;">
            <asp:Panel ID="pnlViewPreviousVersionHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                        <%=LocalResources.GetLabel("app_all_previous_version_text")%>:
                    </div>
                    <asp:ImageButton ID="imgClosePreviousVersionList" CssClass="cursor_hand" Style="top: -15px;
                        right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                </div>
            </asp:Panel>
            <div style="padding: 0 0 0 10px;">
                <asp:GridView ID="gvVersionList" CssClass="table_left" GridLines="None" ShowHeader="false"
                    DataKeyNames="s_document_system_id_pk" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="gvVersionList_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="width_320" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewVersion" runat="server" Text='<%#Eval("s_document_version_list") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnViewVersion" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="button_600">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnCloseVersionList" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_close_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
