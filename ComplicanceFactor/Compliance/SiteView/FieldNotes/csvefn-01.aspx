<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="csvefn-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.FieldNotes.csvefn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_compliance').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_compliance').addClass('selected');
                return false;
            });
        });
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_csvefn" runat="server"
        ValidationGroup="csvefn"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveFieldNotes" ValidationGroup="csvefn" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_fieldnotes_text %>"
                            OnClick="btnHeaderSaveFieldNotes_Click" />
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
            <%=LocalResources.GetLabel("app_fieldnotes_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_fieldnotes_id_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblFieldNotesId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ValidationGroup="csvefn"
                            ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_title_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ValidationGroup="csvefn"
                            ControlToValidate="txtLocation" ErrorMessage="<%$ TextResourceExpression: app_location_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_location_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        *<asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="csvefn"
                            ControlToValidate="txtFieldDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtFieldDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_is_acknowledged_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsAcknowledge" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <br />
        <div class="div_padding_40 div_controls_from_left">
            <div>
                <asp:GridView ID="gvFieldNotesAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="sv_file_path,sv_file_name,sv_fieldnotes_attachments_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvFieldNotesAttachments_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("sv_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnRemoveFiles" OnClientClick="return confirmStatus();" CommandName="Remove"
                                    runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="align_left">
                        <asp:Button CssClass="cursor_hand" ID="btnAddAttachment" runat="server" Text="<%$ LabelResourceExpression: app_attachment_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveFieldNotes" ValidationGroup="saelin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_fieldnotes_text %>"
                            OnClick="btnFooterSaveFieldNotes_Click" />
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnAddAttachment"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
            padding-left: 0px;  padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <div class="uploadpopup_header">
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
                            CssClass="cursor_hand" OnClick="btnUploadAttachements_Click" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
