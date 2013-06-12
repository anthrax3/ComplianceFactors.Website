<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassCompletions.samcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
        function validateCheckBoxes(sender, args) {
            var gvRows = $("#<%=gvCatalog.ClientID %> tr").length;
            if (gvRows == 0) {
                args.IsValid = false;
            }
            else {
                var gridView = document.getElementById('<%= gvCatalog.ClientID %>');
                for (var i = 0; i < gridView.rows.length; i++) {
                    var dropdowns = gridView.getElementsByTagName('select');
                    if (dropdowns.item(i).value == 'Select a Delivery') {
                        args.IsValid = false;
                        break; //break the loop as there is no need to check further.
                    }
                }
            }
        }        
    </script>
    <script type="text/javascript" language="javascript">
        function validateCourse(sender, args) {
            var gvRows = $("#<%=gvCatalog.ClientID %> tr").length;
            if (gvRows == 0) {
                args.IsValid = false;
            }
        }        
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
        function ClientValidate(source, clientside_arguments) {
            ///Test whether the length of the value is more than 5 characters
            if (clientside_arguments.Value.length > 5) {
                clientside_arguments.IsValid = false

            }
            else { clientside_arguments.IsValid = true; };
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addCatalog").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 733,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'p-mcsc-01.aspx',
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
        $(document).ready(function () {
            $(".deleteCourse").click(function () {
                var hdnValue = document.getElementById('<%= hdnIsCatalogBind.ClientID %>');
                hdnValue.value = 0;

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "samcp-01.aspx/DeleteCourse",
                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            // Do some animation effect
                            tr_id.fadeOut(500, function () {
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });

            $(".deleteEmployee").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "samcp-01.aspx/DeleteEmployee",
                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            // Do some animation effect
                            tr_id.fadeOut(500, function () {
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addEmployee").click(function () {

                var gvRows = $("#<%=gvCatalog.ClientID %> tr").length;
                if (gvRows == 0) {
                    args.IsValid = false;
                }
                else {
                    var hdnValue = document.getElementById('<%= hdnIsCatalogBind.ClientID %>');
                    hdnValue.value = 0;
                    $(".addEmployee").fancybox({
                        'type': 'iframe',
                        'titlePosition': 'over',
                        'titleShow': true,
                        'showCloseButton': true,
                        'scrolling': 'yes',
                        'autoScale': false,
                        'autoDimensions': false,
                        'helpers': { overlay: { closeClick: false} },
                        'width': 733,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': 'sasumsm-01.aspx',
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

                }

            });
        });
    </script>
    <script type="text/javascript" language="javascript">
        function getEmployeeCount(sender, args) {
            var gvRows = $("#<%=gvEmployee.ClientID %> tr").length;
            if (gvRows == 0) {
                args.IsValid = false;
            }
        }
    </script>
    <script type="text/javascript">
        function validateCompletion(sender, args) {
            var gridCompletion = document.getElementById('<%= gvCompletionInfo.ClientID %>');
            if (gridCompletion.rows.length > 0) {
                for (var i = 1; i < gridCompletion.rows.length; i++) {
                    var inputs = gridCompletion.rows[i].getElementsByTagName('input');

                    if (inputs[0].type == "text") {
                        if (inputs[0].value == '') {

                            args.IsValid = false;
                            break;
                        }
                    }
                }
            }
            else {

                args.IsValid = false;
            }
        }
    </script>
    <script type="text/javascript">
        function validateAll() {
            var isValid = false;
            isValid = Page_ClientValidate('samcp');
            if (isValid) {
                isValid = Page_ClientValidate('samcp_employee');
            }
            if (isValid) {
                isValid = Page_ClientValidate('samcp_completion');
            }
            return isValid;
        }
    </script>
    <div class="content_area_long">
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp" runat="server"
            ValidationGroup="samcp"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
            ValidationGroup="samcp_completion"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp_employee" runat="server"
            ValidationGroup="samcp_employee"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvValidateEmployee" EnableClientScript="true" ClientValidationFunction="getEmployeeCount"
            ValidationGroup="samcp" runat="server" ErrorMessage="<%$ TextResourceExpression: app_select_atleast_one_employee_error_empty %>">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCheckboxes" EnableClientScript="true" ClientValidationFunction="validateCheckBoxes"
            ValidationGroup="samcp" runat="server" ErrorMessage="<%$ TextResourceExpression: app_select_delivery_error_empty %>">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCourse" EnableClientScript="true" ClientValidationFunction="validateCourse"
            ValidationGroup="samcp_employee" runat="server" ErrorMessage="Please select course and delivery">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCompletion" EnableClientScript="true" ClientValidationFunction="validateCompletion"
            ValidationGroup="samcp_completion" runat="server" ErrorMessage="Please select completion date.">&nbsp;</asp:CustomValidator>
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_catalog_items_text")%>:
        </div>
        <br />
        <asp:HiddenField ID="hdnIsCatalogBind" runat="server" />
        <div>
            <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" RowStyle-CssClass="record"
                CssClass=" grid_870" ShowHeader="false" ShowFooter="false" GridLines="None" DataKeyNames="c_course_system_id_pk"
                runat="server" OnRowDataBound="gvCatalog_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblCourse" runat="server" Style="text-align: left;" Text="Course:"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_4_1" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseName" runat="server" Style="text-align: left;" Text='<%#Eval("c_course_title")  + "(" + Eval("c_course_id_pk") +")"%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_4_1"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" DataTextField="deliveryname"
                                DataValueField="c_delivery_system_id_pk" runat="server" OnSelectedIndexChanged="ddlDelivery_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:Button ID="btnRemoveCatalogItem" OnClientClick="return confirmStatus();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="Remove" />--%>
                            <input type="button" id='<%# Eval("c_course_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                class="deleteCourse cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="record"></RowStyle>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddCatalogItem" runat="server" CssClass="addCatalog cursor_hand"
                Text="<%$ LabelResourceExpression: app_add_catalog_items_button_text %>" />
            <br />
            <br />
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_employees_text")%>:
        </div>
        <div>
            <br />
            <asp:GridView ID="gvEmployee" AutoGenerateColumns="false" RowStyle-CssClass="record"
                CssClass="grid_870" ShowHeader="false" ShowFooter="false" GridLines="None" DataKeyNames="u_user_id_pk"
                runat="server" OnRowDataBound="gvEmployee_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--  + "(" + Eval("u_hris_employee_id") +")"--%>
                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("u_username")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeId" Text='<%#Eval("u_hris_employee_id")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--  <asp:Button ID="btnRemoveEmployee" OnClientClick="return confirmStatus();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="Remove" />--%>
                            <input type="button" id='<%# Eval("u_user_id_pk") %>' 
                                value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                class="deleteEmployee cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddEmployee" runat="server" ValidationGroup="samcp_employee" CssClass="addEmployee cursor_hand"
                Text="<%$ LabelResourceExpression: app_add_employee_button_text %>" />
            <br />
            <br />
        </div>
        <div class=" div_header_long">
            <%=LocalResources.GetLabel("app_completion_information_text")%>:
        </div>
        <br />
        <div class="clear">
        </div>
        <div>
       <%-- CssClass="gridview_long tablesorter font_1"--%>
            <asp:GridView ID="gvCompletionInfo" CellPadding="0" CellSpacing="0" 
                runat="server" EmptyDataText="No Result Found" GridLines="Both"  DataKeyNames="c_delivery_id_pk"
                AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                OnRowDataBound="gvCompletionInfo_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4 align_center" HeaderStyle-BackColor="LightGray" HeaderText="<%$ LabelResourceExpression: app_delivery_Id_and_name_text %>"
                        ItemStyle-CssClass="gridview_row_width_4" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                             
                            <asp:Label ID="lblDeliveryIdName" runat="server"></asp:Label>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3 align_center" HeaderStyle-BackColor="LightGray" HeaderText="<%$ LabelResourceExpression: app_comments_text %>"
                        ItemStyle-CssClass="gridview_row_width_3" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtComments" Columns="20" TextMode="MultiLine">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1 align_center" HeaderStyle-BackColor="LightGray" HeaderText="<%$ LabelResourceExpression: app_completion_date_text %>"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtCompletionDate">
                            </asp:CalendarExtender>                            
                            <asp:TextBox ID="txtCompletionDate" class="CompletionDate" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="LightGray"  HeaderText="<%$ LabelResourceExpression: app_attendance_text %>"
                        HeaderStyle-CssClass="gridview_row_width_1 align_center" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlAttendanceStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="LightGray" HeaderText="<%$ LabelResourceExpression: app_passing_status_text %>"
                        HeaderStyle-CssClass="gridview_row_width_1 align_center" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPassignStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ LabelResourceExpression: app_grade_text %>" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlGrade" DataValueField="s_grading_scheme_system_value_id_pk"
                                DataTextField="s_grading_scheme_value_grade" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ LabelResourceExpression: app_score_text %>" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" CssClass="textbox_50" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <div class="font_1">
            <table class="table_td_300">
                <tr>
                    <%-- ValidationGroup="samcp_completion"--%>
                    <td class="align_right">
                        <asp:Button ID="btnProcessMassCompletion" runat="server" OnClientClick="return validateAll()"
                            Text="<%$ LabelResourceExpression: app_process_mass_completion_button_text %>"
                            OnClick="btnProcessMassCompletion_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Style="display: none;" />
        <asp:ModalPopupExtender ID="mpeCurriculumNotes" runat="server" TargetControlID="btnUpdate"
            PopupControlID="pnlNotes" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlNotesHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnCancelCompletion">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="MpeCreatePin" runat="server" TargetControlID="btnCreatePin"
            PopupControlID="pnlCreatePin" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlPinHeading" OkControlID="imgClosePin" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnCancelPin">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlNotes" runat="server" CssClass="modalPopup_width_700" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlNotesHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_700">
                        <%=LocalResources.GetLabel("app_enter_pin_reason_for_mass_completion_text")%>:
                    </div>
                    <asp:ImageButton ID="imgCloseJobTitle" CssClass="cursor_hand" Style="top: -15px;
                        right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                </div>
            </asp:Panel>
            <br />
            <div class="default_font_size">
                <table>
                    <tr>
                        <td class="text_font_normal" style="width: 100px;" align="right">
                            <%=LocalResources.GetLabel("app_selected_courses_and_delivery_text")%>:
                        </td>
                        <td class="align_left">
                            <div id="SelectedCourses" style="float: left;" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" align="right">
                            <%=LocalResources.GetLabel("app_selected_employees_text")%>:
                        </td>
                        <td class="align_left">
                            <div id="selectedEmployee" style="float: left;" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" align="right">
                            <%=LocalResources.GetLabel("app_completion_statuses_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" align="right">
                            <%=LocalResources.GetLabel("app_completion_date_text")%>:
                            <%-- <asp:RegularExpressionValidator ID="regexStartDate" runat="server" ControlToValidate="txtDueDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="Invalid date format">&nbsp;</asp:RegularExpressionValidator>--%>
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblCompletionDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" align="right">
                            <%=LocalResources.GetLabel("app_notes_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="8" Columns="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" align="right">
                            <%=LocalResources.GetLabel("app_pin_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCreatePin" runat="server" Text="<%$ LabelResourceExpression: app_create_PIN_button_text %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--OnClientClick="return confirmStatus();"--%>
                            <asp:Button ID="btnSaveStatus" ValidationGroup="samcp" OnClick="btnSaveStatus_Click"
                                runat="server" Text="<%$ LabelResourceExpression: app_create_completion_record_button_text %>" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnCancelCompletion" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlCreatePin" runat="server" CssClass="modalPopup_width_500" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlPinHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                        <%=LocalResources.GetLabel("app_create_PIN_text")%>:
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
                            <%=LocalResources.GetLabel("app_user_name_text")%>:
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
                            <%=LocalResources.GetLabel("app_enter_PIN_Number_text")%>:
                            <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPinNumber"
                                ForeColor="Red" ErrorMessage="<%$ TextResourceExpression: app_pin_error_empty %>"
                                ValidationGroup="Pinnumber">&nbsp;</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvalPinnumber" ClientValidationFunction="ClientValidate"
                                ControlToValidate="txtPinNumber" runat="server" ForeColor="Red" ValidationGroup="Pinnumber"
                                ErrorMessage="<%$ TextResourceExpression: app_pin_error_wrong %>">&nbsp;</asp:CustomValidator>
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
                            <%=LocalResources.GetLabel("app_validate_PIN_text")%>:
                            <asp:RequiredFieldValidator ID="rfvPinNumber" runat="server" ControlToValidate="txtValidatePin"
                                ForeColor="Red" ErrorMessage="<%$ TextResourceExpression: app_pin_error_empty %>"
                                ValidationGroup="Pinnumber">&nbsp;</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvalPassword" runat="server" ControlToCompare="txtPinNumber"
                                ForeColor="Red" ControlToValidate="txtValidatePin" ErrorMessage="<%$ TextResourceExpression: app_pin_error_wrong %>"
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
                                Text="<%$ LabelResourceExpression: app_save_button_text %>" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnCancelPin" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
        </asp:Panel>
    </div>
</asp:Content>
