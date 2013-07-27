<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.samcmcp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 0: { sorter: false }, 8: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            var editDelivery = $('input#<%=hdnDeliveryId.ClientID %>').val();

            //Select Image
            $(".adduser").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'scrolling': 'yes',
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 916,
                'height': 200,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': 'p-sces-01.aspx?editDeliveryId=' + editDelivery,
                'onComplete': function () {
                    $('#fancybox-frame').load(function () {
                        $('#fancybox-content').height($(this).contents().find('body').height() + 10);
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
        function toggleSelection(source) {

            $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', source.checked);
            });


        }
        function clearSelection() {
            if ($("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").length == $("#gvsearchDetails input[name$='chkSelect']:checked").length) {
                $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelectAll']").first().attr('checked', true);

            }
            else {
                $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelectAll']").first().attr('checked', false);
            }
        }
    </script>     

    <script type="text/javascript">
        $(document).ready(function () {
            $(".editCompletion").click(function () {

                var courseId = document.getElementById('<%=hdCourseId.ClientID %>').value
                var deliveryId = document.getElementById('<%=hdnDeliveryId.ClientID %>').value
                //Get the Id of the record to delete
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
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Catalog/Completion/p-sceci-01.aspx?userId=' + record_id + '&courseId=' + courseId + '&deliveryId=' + deliveryId,
                    'onComplete': function () {
                        $('#fancybox-frame').load(function () {
                            $('#fancybox-content').height($(this).contents().find('body').height() + 10);
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
            $(".deleteUser").click(function () {
                var courseId = document.getElementById('<%=hdCourseId.ClientID %>').value

                var deliveryId = document.getElementById('<%=hdnDeliveryId.ClientID %>').value
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "samcmcp-01.aspx/DeleteUserDetails",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "','args2': '" + courseId + "','args3':'" + deliveryId + "'}",
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
        var TargetBaseControl = null;

        window.onload = function () {
            try {
                //get target base control.
                TargetBaseControl =
           document.getElementById('<%= this.gvsearchSession.ClientID %>');
            }
            catch (err) {
                TargetBaseControl = null;
            }
        }

        function TestCheckBox() {
            if (TargetBaseControl == null) return false;

            //get target child control.
            var TargetChildControl = "chkSelect";

            //get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                    return true;

            alert('Select at least one checkbox in session and roster!');
            return false;
        }
    </script>
    <script type="text/javascript">
        function ConfirmSave(sender, args) {
                document.getElementById('<%=hdUpdateValue.ClientID %>').value = "0";
                var isValid = validateAll();
                if (isValid == true) {
                    if (confirm('Are you sure') == true)
                        return true;
                    else
                        return false;
                }

            }
    </script>
        <script type="text/javascript">
            function validateAll() {
                var isValid = false;
                isValid = Page_ClientValidate('samcmcp');
                if (isValid) {
                    isValid = Page_ClientValidate('samcmcp_employee')
                }
                return isValid;
            }
    </script>
    <script type="text/javascript">
        function CheckScore(sender, args) {
            var grid = document.getElementById('<%=gvsearchDetails.ClientID %>');
            for (var i = 0; i < grid.getElementsByTagName("input").length; i++) {
                if (grid.getElementsByTagName("input").item(i).type == "text") {
                    if (grid.getElementsByTagName("input").item(i).value > 100 && grid.getElementsByTagName("input").item(i).value!="") {
                        grid.getElementsByTagName("input").item(i).focus();
                        args.IsValid = false;
                    }
                    else {
                        args.IsValid = true;
                    }

                }

            }
        }
    </script>
    <script type="text/javascript">
        function validateCheckBoxes(sender, args) {
            var gridView = document.getElementById('<%= gvsearchDetails.ClientID %>');
            var flag = 0;
            if (gridView.rows.length == 1) {
                args.IsValid = false;
            }
            for (var i = 1; i < gridView.rows.length; i++) {
                if (flag == 0) {
                    var inputs = gridView.rows[i].getElementsByTagName('input');
                    if (inputs != null) {
                        if (inputs[0].type == "checkbox") {
                            if (inputs[0].checked) {
                                args.IsValid = true;
                                flag = 1;
                            }
                            else {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }
    </script>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_samcmcp" runat="server"
        ValidationGroup="samcmcp"></asp:ValidationSummary>

    <asp:ValidationSummary class="validation_summary_error" ID="vs_samcmcp_employee" runat="server"
        ValidationGroup="samcmcp_employee"></asp:ValidationSummary>

    <asp:CustomValidator ID="cvValidateScore" EnableClientScript="true" ClientValidationFunction="CheckScore"
        ValidationGroup="samcmcp" runat="server" ErrorMessage="<%$ TextResourceExpression: app_score_limit_error_wrong %>">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvValidateCheckbox" EnableClientScript="true" ClientValidationFunction="validateCheckBoxes"
        ValidationGroup="samcmcp" runat="server" ErrorMessage="<%$ TextResourceExpression: app_select_atleast_one_employee_error_empty %>">&nbsp;</asp:CustomValidator>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_course_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" class="align_left">
                        <asp:Label ID="lblCourseTitle" runat="server" Text=""></asp:Label>
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
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_revision_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblVersion" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="align_right">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_cost_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCost" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        CEU
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCEU" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblOwner" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCoordinator" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_delivery_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" class="align_left">
                        <asp:Label ID="lblDeliveryTitle" runat="server" Text=""></asp:Label>
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
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_type_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <asp:Label ID="lblDeliveryDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
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
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryOwner" runat="server" Text=" "></asp:Label>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryCoordinator" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_sessions_details_text")%>:
        </div>
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvsearchSession" CellPadding="0" CellSpacing="0" CssClass="gridview_width_900 font_1"
                    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                    DataKeyNames="c_session_system_id_pk" OnRowDataBound="gvsearchSession_RowDataBound">
                    <RowStyle CssClass="gvrow_padding" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_4" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionTitle" runat="server" Style="text-align: left;" Text='<%#Eval("c_session_title")%>'></asp:Label><br />
                                <asp:Label ID="lblSessionID" runat="server" Style="text-align: left;" Text='<%#"("+ Eval("c_session_id_pk")+")"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_4" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionStartDate" runat="server" Style="text-align: left;" Text='<%#"Starts: "+ Eval("c_session_start_date")  + " @ " + Eval("c_session_start_time")%>'></asp:Label><br />
                                <asp:Label ID="lblSessionEndDate" runat="server" Style="text-align: left;" Text='<%#"Ends: "+ Eval("c_session_end_date")  + " @ " + Eval("c_sessions_end_time")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_4" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionLocation" runat="server" Text='<%#Eval("c_location_name")%>'></asp:Label><br />
                                <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("c_room_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </div>
            <br />
            <asp:HiddenField ID="hdnDeliveryId" runat="server" />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_roaster_text")%>:
            </div>
            <div>
                <asp:GridView ID="gvsearchDetails" CellPadding="0" RowStyle-CssClass="record" CellSpacing="0"
                    CssClass="gridview_long tablesorter" runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" DataKeyNames="u_user_id_pk,t_transcript_id_pk"
                    OnRowDataBound="gvsearchDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" onclick="toggleSelection(this);" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_last_name_text %>"
                            ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_last_name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_first_name_text %>"
                            ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_first_name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_employee_number_text %>"
                            ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_hris_employee_id" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_attendance_text %>"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAttendanceStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                    runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_passing_status_text %> "
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPassignStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                    runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Grade"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlGrade" DataValueField="s_grading_scheme_system_value_id_pk"
                                    DataTextField="s_grading_scheme_value_grade" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_score_text %>"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>                                
                                <asp:TextBox ID="txtScore" CssClass="textbox_50" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Literal ID="ltlButton" runat="server"></asp:Literal>
                                <%-- <input id='<%# Eval("u_user_id_pk") %>' name="EditRemove" onclick="EditandRemove(this.id);" type="button"
                                    value="<%= this.hdnButtonName.Value %>" class="editcompletion cursor_hand" />--%>
                                <%-- <asp:Button ID="btnEdit" CommandName="Edit" style="display:none;" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Edit" />
                            <asp:Button ID="btnRemove" CommandName="Remove" style="display:none;" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Remove" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnAddUsers" runat="server" CssClass="adduser cursor_hand" Text="<%$ LabelResourceExpression: app_add_users_button_text %>" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:HiddenField ID="hdnButtonName" Value="Remove" runat="server" />
            <asp:HiddenField ID="hdUpdateValue" runat="server" />
            <%--<asp:HiddenField ID="hdDeliveryId" runat="server" />--%>
            <asp:HiddenField ID="hdCourseId" runat="server" />
            <div class="div_header_long">
                <br />
            </div>
            <table>
                <tr>
                    <td colspan="3" width="1030px">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="btnSaveCompletion" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_save_completion_information_button_text %>"
                            OnClientClick="ConfirmSave()" OnClick="btnSaveCompletion_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_header_long">
                <br />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
