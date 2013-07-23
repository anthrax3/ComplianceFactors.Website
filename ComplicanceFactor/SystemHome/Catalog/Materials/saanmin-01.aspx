<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saanmin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Materials.saanmin_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">

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
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Materials/Locale/savloc-01.aspx?mode=create',
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
    <br />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saanmin" runat="server"
        ValidationGroup="saanmin"></asp:ValidationSummary>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNewMaterial" ValidationGroup="saanmin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_material_button_text %> "
                            OnClick="btnHeaderSaveNewMaterial_Click" />
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
            <%=LocalResources.GetLabel("app_material_information_english_us_types_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMaterialId" runat="server" ValidationGroup="saanmin"
                            ControlToValidate="txtMaterialId" ErrorMessage="<%$ TextResourceExpression: app_material_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_material_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaterialId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvMaterialName" runat="server" ValidationGroup="saanmin"
                            ControlToValidate="txtMaterialName" ErrorMessage="<%$ TextResourceExpression: app_material_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_material_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaterialName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvMaterialDescription" runat="server" ValidationGroup="saanmin"
                            ControlToValidate="txtMaterialDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtMaterialDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_attachment_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <asp:Button ID="btnAttachment" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_attachment_text %>" />
                        <asp:LinkButton ID="lnkFileName" runat="server" CssClass="cursor_hand" OnClick="lnkFileName_Click"></asp:LinkButton>
                        <asp:Button ID="btnView" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>"
                            CssClass="cursor_hand" OnClick="btnView_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>"
                            CssClass="cursor_hand" />
                        <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" runat="server"
                            Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand"
                            OnClick="btnRemove_Click" />
                    </td>
                    <%-- <td class="align_left" colspan="4">
                        <asp:GridView ID="gvAttachment" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                            CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_material_file_guid,c_material_file_name"
                            runat="server" AutoGenerateColumns="False" OnRowCommand="gvAttachment_RowCommand"
                            OnRowEditing="gvAttachment_RowEditing">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>--%>
                </tr>
            </table>
            <div class="div_padding_135">
            </div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_material_type_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMaterialType" DataTextField="s_material_type_name" DataValueField="s_material_type_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <input type="button" id="btnManageLocale" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveNewMaterials" ValidationGroup="saanmin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_material_button_text %>"
                            OnClick="btnFooterSaveNewMaterials_Click" />
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
    <%--<asp:ModalPopupExtender ID="mpeAddAttachment" runat="server" TargetControlID="btnAttachment"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeEditAttachment" runat="server" TargetControlID="btnEdit"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUploadFile" Style="display: none;  padding-left: 0px;
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
                    ValidationGroup="materialfileupload" />
                <asp:CustomValidator ValidationGroup="materialfileupload" ID="cvFileUpload" runat="server"
                    EnableClientScript="true" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty %>"
                    ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
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
                    <asp:Button ID="btnUploadAttachment" ValidationGroup="materialfileupload" runat="server"
                        Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand"
                        OnClick="btnUploadAttachment_Click" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
            </div>
            <br />
        </div>
    </asp:Panel>--%>
    <asp:ModalPopupExtender ID="mpeAddAttachment" TargetControlID="btnAttachment"
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
                        OnClick="btnUploadAttachment_Click" Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
            </div>
            <br />
        </div>
    </asp:Panel>
</asp:Content>

