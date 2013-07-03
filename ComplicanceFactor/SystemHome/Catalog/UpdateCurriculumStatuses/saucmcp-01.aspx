<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saucmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses.saucmcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
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

            var editCurriculumId = $('input#<%=hdnCurriculumId.ClientID %>').val();            

            //Select Image
            $(".adduser").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 733,
                'height': 200,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': 'p-sase.aspx?editCurriculumId=' + editCurriculumId,
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

        $(document).ready(function () {

            $(".deleteuser").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saucmcp-01.aspx/DeleteUser",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();
                                //$('#<%=gvEmployees.ClientID %> tr:last').eq(-1).css("display", "none");
                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".userselected").change(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
                var tr_id = $(this).parents("#.record");
                if ($(".userselected").is(":checked")) {

                    // checkbox is checked -> do something
                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saucmcp-01.aspx/SelectedUser",

                        //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                        data: "{'args': '" + element[0] + "','args2': '" + "true" + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            $('#' + record_id).prop("checked", true);
                        }
                    });

                } else {                    
                    // checkbox is not checked -> do something different
                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saucmcp-01.aspx/SelectedUser",

                        //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                        data: "{'args': '" + element[0] + "','args2': '" + "false" + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            $('#' + record_id).prop("checked", false);
                        }
                    });
                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        function ClientValidate(source, clientside_arguments) {
            ///Test whether the length of the value is more than 5 characters
            if (clientside_arguments.Value.length > 5) {
                clientside_arguments.IsValid = false

            }
            else { clientside_arguments.IsValid = true; };
        }
    </script>
    <script type="text/javascript" language="javascript">
        function toggleSelection(source) {

            $("#<%=gvEmployees.ClientID %> input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', source.checked);
            });


        }
        function clearSelection() {
            if ($("#<%=gvEmployees.ClientID %> input[name$='chkSelect']").length == $("#gvEmployees input[name$='chkSelect']:checked").length) {
                $("#<%=gvEmployees.ClientID %> input[name$='chkSelectAll']").first().attr('checked', true);

            }
            else {
                $("#<%=gvEmployees.ClientID %> input[name$='chkSelectAll']").first().attr('checked', false);
            }
        }
        function check_hdUpdateValue(id) {
            
            if (id == "ContentPlaceHolder1_btnUpdateCurriculum") {
                
                document.getElementById('<%=hdUpdatevalue.ClientID %>').value = "1";
            }
            
        }        
    </script>
    <asp:HiddenField ID="hdUpdatevalue" runat="server" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
     <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
     <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
    <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_curriculum_details_text")%>:
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_curriculum_title_with_id_text")%>:
                    </td>
                    <td class="align_left" style="width: 130px;">
                        <asp:Label ID="lblCurriculumTitle" runat="server" Text=""></asp:Label>
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
                    <td align="right">
                        <%=LocalResources.GetLabel("app_revision_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblRevision" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_cost_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblCost" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2" align="right">
                        CEU
                    </td>
                    <td>
                        <asp:Label ID="lblCEU" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_owner_text")%>
                    </td>
                    <td>
                        <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_path_details_text")%>:
        </div>
        <div>
            <asp:GridView ID="gvPath" ShowHeader="false" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" OnRowDataBound="gvPath_RowDataBound"
                GridLines="None" DataKeyNames="c_curricula_path_system_id_pk,c_curriculum_system_id_pk"
                AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPath" runat="server" Text='<%#Eval("c_curricula_path_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvSection" ShowHeader="false" AutoGenerateColumns="False" runat="server"
                                            GridLines="None" DataKeyNames="c_curricula_path_id_fk,c_curricula_path_section_id_pk"
                                            OnRowDataBound="gvSection_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                    <b><%=LocalResources.GetLabel("app_section_text")%></b>
                                                        <%--<b><%$ LabelResourceExpression: app_section_text %>:</b>--%>
                                                        <%#Eval("c_curricula_path_section_seq_number")%>
                                                        <asp:GridView ID="gvCourse" CellPadding="0" CellSpacing="0" ShowHeader="false" runat="server"
                                                            AutoGenerateColumns="false" GridLines="None">
                                                            <Columns>
                                                                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                                                    HeaderText="Curriculum ID" HeaderStyle-HorizontalAlign="Center" DataField="c_course_name"
                                                                    ItemStyle-HorizontalAlign="Left" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_roaster_text")%>:
            </div>
            <br />
            <div>
                <asp:GridView ID="gvEmployees" RowStyle-CssClass="record" CellPadding="0" CellSpacing="0"
                    CssClass="gridview_long tablesorter" runat="server" EmptyDataText="<%$ LabelResourceExpression: app_No_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" DataKeyNames="u_user_id_pk,e_enroll_status_name,e_curriculum_assign_percent_complete"
                     OnRowEditing="gvEmployees_RowEditing" OnRowDataBound="gvEmployees_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                            <asp:CheckBox ID="chkSelectAll" onclick="toggleSelection(this);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                        </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_last_name_text %>"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_last_name" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_first_name_text %>"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_first_name" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_number_text %>"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_hris_employee_id" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_current_status_text %>"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="e_enroll_status_name" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_completed_text %>"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="e_curriculum_assign_percent_complete" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("u_user_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                    class="deleteuser cursor_hand" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="empty_row"></EmptyDataRowStyle>
                    <PagerSettings Visible="False"></PagerSettings>
                    <RowStyle CssClass="record"></RowStyle>
                </asp:GridView>
            </div>
            <div class="div_padding_135">
                <table>
                    <tr>
                        <td style="width: 180px;">
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_select_new_status_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChangeStatus" DataTextField="s_curr_status_name" DataValueField="s_curr_status_system_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hdnCurriculumId" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnAddUser" runat="server" CssClass="adduser cursor_hand" Text="<%$ LabelResourceExpression: app_add_new_user_button_text %>" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_header_long">
            <br />
            </div>
            <br />
            <table>
                <tr>
                    <td align="center" colspan="3" width="1030px">
                        <asp:Button ID="btnUpdateCurriculum" runat="server" OnClientClick="javascript:check_hdUpdateValue(this.id)" 
                        Text="<%$ LabelResourceExpression: app_update_curriculum_statuses_text %>" OnClick="btnUpdateCurriculum_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_header_long">
            <br />
            </div>
            <br />
            <br />
        </div>
    </div>
    <asp:Button ID="btnUpdate" runat="server" Style="display: none;" />
    <asp:ModalPopupExtender ID="mpeCurriculumNotes" runat="server" TargetControlID="btnUpdate"
        PopupControlID="pnlNotes" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlNotesHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="MpeCreatePin" runat="server" TargetControlID="btnCreatePin"
        PopupControlID="pnlCreatePin" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlPinHeading" OkControlID="imgClosePin" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancelPin">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlNotes" runat="server" CssClass="modalPopup_width_700 modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlNotesHeading" runat="server" CssClass="drag">
            <div>
                <div class="div_header_700">
                    <%=LocalResources.GetLabel("app_reason_for_curriculum_status_change_text")%>:
                </div>
                <asp:ImageButton ID="imgCloseJobTitle" CssClass="cursor_hand" Style="top: -15px;
                    right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
            </div>
        </asp:Panel>
        <br />
        <div class="default_font_size">
            <table>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_selected_employees_text")%>:
                    </td>
                    <td class="align_left">
                        <div id="selectedEmployee" style="float: left;" runat="server">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_new_status_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_new_due_date_text")%>:
                        <%-- <asp:RegularExpressionValidator ID="regexStartDate" runat="server" ControlToValidate="txtDueDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="Invalid date format">&nbsp;</asp:RegularExpressionValidator>--%>
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDueDate">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtDueDate" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_notes_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="15" Columns="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_pin_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCreatePin" runat="server" Text="<%$ LabelResourceExpression: app_create_a_pin_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSaveStatus" OnClick="btnSaveStatus_Click" runat="server" Text="<%$ LabelResourceExpression: app_save_new_status_button_text %>" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlCreatePin" runat="server" CssClass="modalPopup_width_500 modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlPinHeading" runat="server" CssClass="drag">
            <div>
                <div class="div_header_620">
                    <%=LocalResources.GetLabel("app_create_a_pin_text")%>:
                </div>
                <asp:ImageButton ID="imgClosePin" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                    z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
            </div>
        </asp:Panel>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_saucmcp" runat="server"
            ValidationGroup="Pinnumber"></asp:ValidationSummary>
        <br />
        <div class="div_controls">
            <table>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_login_user_name_text")%>:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_login_password_text")%>:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_enter_pin_with_five_digits_text")%>:
                        <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPinNumber"
                            ForeColor="Red" ErrorMessage="<%$ TextResourceExpression: app_pin_error_empty%>" ValidationGroup="Pinnumber">&nbsp;</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvalPinnumber" ClientValidationFunction="ClientValidate"
                            ControlToValidate="txtPinNumber" runat="server" ForeColor="Red" ValidationGroup="Pinnumber"
                            ErrorMessage="<%$ TextResourceExpression: app_pin_length_error_wrong%>">&nbsp;</asp:CustomValidator>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPinNumber" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=LocalResources.GetLabel("app_validate_pin_with_five_digits_text")%>:
                        <asp:RequiredFieldValidator ID="rfvPinNumber" runat="server" ControlToValidate="txtValidatePin"
                            ForeColor="Red" ErrorMessage="<%$ TextResourceExpression: app_pin_error_valid%>" ValidationGroup="Pinnumber">&nbsp;</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvalPassword" runat="server" ControlToCompare="txtPinNumber"
                            ForeColor="Red" ControlToValidate="txtValidatePin" ErrorMessage="<%$ TextResourceExpression: app_pin_no_mismatched_error_wrong%>"
                            ValidationGroup="Pinnumber">&nbsp;</asp:CompareValidator>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtValidatePin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnSavePin" OnClick="btnSavePin_Click" runat="server" ValidationGroup="Pinnumber"
                            Text="<%$ LabelResourceExpression: app_save_pin_button_text %>" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnCancelPin" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </asp:Panel>
</asp:Content>
