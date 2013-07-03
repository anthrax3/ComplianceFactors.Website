<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saent-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Notification.saent_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/jquery.fancybox.css" />
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
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
        // Add locale
        $(document).ready(function () {
            $("#btnCreateNewLocale").click(function (e) {

                var editNotificationId = $('input#<%=hdNotificationId.ClientID %>').val();

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 820,
                    'height': 550,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Locale/saaloc-01.aspx?mode=create' + "&editNotificationId=" + editNotificationId + "&editLocaleId=" + localeid,
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
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".editlocale").click(function (e) {

                var editNotificationId = $('input#<%=hdNotificationId.ClientID %>').val();

                var record_id = $(this).attr("id");

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 820,
                    'height': 550,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Locale/saaloc-01.aspx?mode=edit' + "&editNotificationId=" + editNotificationId + "&editLocalepk=" + record_id,
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
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deletelocale").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saent-01.aspx/DeleteLocale",

                        //Pass the selected record id
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                $("#<%= ddlLocale.ClientID %>").append("<option value=" + element[1] + ">" + element[2] + " </option>");
                                $("#<%= ddlLocale.ClientID %>").val(element[1]);
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">
        function RemoveLocale(value) {

            var exists = false;
            $('#<%=ddlLocale.ClientID %>  option').each(function () {
                if (this.value == value) {
                    exists = true;
                    $('#<%=ddlLocale.ClientID %> option[value=' + value + ']').remove();
                }
            });



        }
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saent" runat="server"
        ValidationGroup="saent"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:HiddenField ID="hdNotificationId" runat="server" />
    <br />
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNotification" ValidationGroup="saent" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_notification_button_text %>" OnClick="btnHeaderSaveNotification_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" CssClass="cursor_hand"
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
            <%=LocalResources.GetLabel("app_notification_info_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                         <%--<asp:RequiredFieldValidator ID="rfvNotificationId" runat="server" ValidationGroup="saent"
                            ControlToValidate="lblNotificationId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>--%>
                        * <%=LocalResources.GetLabel("app_notification_id_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblNotificationId" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator ID="rfvNotificationName" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtNotificationName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_notification_name_text")%>: 
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNotificationName" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_type_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        * <%=LocalResources.GetLabel("app_description_text")%>: 
                        <asp:RequiredFieldValidator ID="tfvDescription" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                    </td>
                    <td class="align_left" colspan="7">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_copy_manager_text")%>: 
                    </td>
                    <td class="align_left" colspan="7">
                        <table>
                            <tr>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkCopyManager" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_second_level_manager_text")%>: 
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chk2ndLevelManager" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_third_level_manager_text")%>:
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chk3rdLevelManager" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_copy_supervisor_text")%>: 
                    </td>
                    <td class="align_left" colspan="7">
                        <table>
                            <tr>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkSupervisor" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_copy_mentor_text")%>: 
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkMentor" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_copy_owner_text")%>:  
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkOwner" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_copy_coordinator_text")%>:  
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkCoordinator" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr id="Scheduledays" runat="server">
                    <td>
                        <%=LocalResources.GetLabel("app_schedule_days_text")%>: 
                    </td>
                    <td colspan="7" class="align_left">
                        <asp:TextBox ID="txtScheduleDays" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_email_msg_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_cc_text")%>: 
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtCC" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_bcc_text")%>: 
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtBCC" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtSubject" ErrorMessage="<%$ TextResourceExpression: app_subject_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_subject_text")%>: 
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtSubject" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_center">
                        <asp:RequiredFieldValidator ID="rfvEmailContent" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtEmailContent" ErrorMessage="<%$ TextResourceExpression: app_email_content_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_email_content_text")%>: 
                    </td>
                    <td class="align_left">
                        <textarea id="txtEmailContent" runat="server" style="height: 178px; overflow-x: hidden;
                            overflow: auto" class="textarea_long_1" rows="15" cols="150"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_sms_text_information_text")%>: 
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSmsTextContent" runat="server" ValidationGroup="saent"
                        ControlToValidate="txtSmsContent" ErrorMessage="<%$ TextResourceExpression: app_sms_content_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_sms_text_content_text")%>: 
                    </td>
                    <td>
                        <textarea id="txtSmsContent" runat="server" class="textarea_long_1" style="height: 100px; overflow-x: hidden; overflow: auto" rows="5" cols="150"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_attachments_text")%>:  
        </div>
        <br />
        <div class="div_padding_40 div_controls_from_left">
            <div>
                <asp:GridView ID="gvNotificationAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="s_notifications_attachment_file_guid,s_notifications_attachment_file_name,s_notifications_attchments_system_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvNotificationAttachments_RowCommand"
                    OnRowEditing="gvNotificationAttachments_RowEditing">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("s_notifications_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnRemoveWitnessFiles" OnClientClick="return confirmStatus();" CommandName="Remove"
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
                        <asp:Button CssClass="cursor_hand" ID="btnAddAttachment" runat="server" Text="<%$ LabelResourceExpression: app_add_attachment_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_all_locale_text")%>:  
        </div>
        <br />
        <div class="div_padding_40 div_controls_from_left">
            <asp:GridView ID="gvNotificationLocales" RowStyle-CssClass="record" CssClass="grid_700"
                runat="server" GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7">
                        <ItemTemplate>
                            <%#Eval("s_locale_description")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_notification_locale_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                class="editlocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_notification_locale_system_id_pk").ToString() + "," +  Eval("s_notification_locale_id_fk").ToString() + "," +  Eval("s_locale_description").ToString()%>'
                                value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />' class="deletelocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="grid_700" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="width_300 align_left">
                        <asp:DropDownList ID="ddlLocale" DataTextField="s_locale_description" DataValueField="s_locale_id_pk"
                            CssClass="dropdown_width_300" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right">
                        <input type="button" id="btnCreateNewLocale" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_create_new_locale_button_text %>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveNotification" ValidationGroup="saent" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_notification_button_text %>" OnClick="btnFooterSaveNotification_Click" />
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
        <br />
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
                        <asp:Button ID="btnUploadAttachements" runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>" CssClass="cursor_hand"
                            OnClick="btnUploadAttachements_Click" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
