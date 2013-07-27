<%@ Page Title="ComplicanceFactor&#0153 - Manager Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="mhp-01.aspx.cs"
    Inherits="ComplicanceFactor.Manager.mhp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_manager').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_manager').addClass('selected');
                return false;
            });
        });


        $(function () {
            $('#<%=gvToDo.ClientID %>')
            .tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

        });

        function expandDetailsInToDo(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgToDo", "div_to_do") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInTeam(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgTeam", "div_team") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }

        function expandDetailsInReport(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgReport", "div_report") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
        
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewCourse").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 830,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmcp-01.aspx?id=' + record_id,
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

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewCurricula").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 900,
                    'height': 420,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmcurp-01.aspx?id=' + record_id,
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

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewLearninghistory").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 900,
                    'height': 420,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmhp-01.aspx?id=' + record_id,
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

        });
    </script>
    <div class="content_area">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <%= LocalResources.GetText("app_welcome_content_manager_home_text")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%= LocalResources.GetLabel("app_my_to_do_text")%>(s):
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInToDo(this);return false;" runat="server"
                ID="imgToDo" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_to_do" runat="server">
        <asp:GridView ID="gvToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
            GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvToDo_RowCommand" OnRowEditing="gvToDo_RowEditing">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_curriculum_title_with_id_text %>"
                    DataField='title' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employee_text %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" DataField='name'></asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField='type' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="float: right; margin-right: 26px;">
        <table>
            <tr>
                <td style="padding-right: 30px;">
                    <asp:Button ID="btnDenyAll" runat="server" Text="<%$ LabelResourceExpression: app_deny_all_button_text %>"
                        OnClick="btnDenyAll_Click" />
                </td>
                <td>
                    <asp:Button ID="btnApproveAll" runat="server" Text="<%$ LabelResourceExpression: app_approve_all_button_text %>"
                        OnClick="btnApproveAll_Click" />
                </td>
            </tr>
        </table>
    </div>
    <b>
        <asp:LinkButton ID="lnkViewAllToDo" runat="server" Text="<%$ LabelResourceExpression: app_view_all_my_todos_button_text %>"
            OnClick="lnkViewAllToDo_Click" CssClass="body_link"></asp:LinkButton></b>
    <br />
    <br />
    <br />
    <div class="div_header_long">
        <%= LocalResources.GetLabel("app_my_team_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInTeam(this);return false;" runat="server"
                ID="imgTeam" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_team" runat="server">
        <asp:ListView ID="lvMyteam" runat="server" OnItemDataBound="lvMyteam_ItemDataBound"
            OnItemCommand="lvMyteam_ItemCommand">
            <LayoutTemplate>
                <table class="gridview_long_no_border">
                    <tr style="background-color: #C0C0C0">
                        <th style="width: 400px;">
                            Employee Name(ID)
                        </th>
                        <th style="width: 400px;">
                            Job Title
                        </th>
                        <th style="width: 150px;">
                        </th>
                        <th style="width: 150px;">
                        </th>
                        <th style="width: 150px;">
                        </th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 400px;">
                        <asp:Literal ID="litIndent" runat="server"></asp:Literal>
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        <asp:LinkButton ID="lnkExpandCollapse" runat="server" CommandName="ExpandCollapse"
                            CausesValidation="false"> [+]                         
                        </asp:LinkButton>
                    </td>
                    <td align="center" style="width: 370px;">
                        <asp:Label ID="lblJobTitle" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label>
                    </td>
                    <td align="center" style="width: 160px;">
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="<%$ LabelResourceExpression: app_view_course_button_text %>" />'
                            class="ViewCourse cursor_hand" />
                    </td>
                    <td align="center" style="width: 160px;">
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewCurricula" runat="server" Text="<%$ LabelResourceExpression: app_view_curricula_button_text %>" />'
                            class="ViewCurricula cursor_hand" />
                    </td>
                    <td align="center" style="width: 160px;">
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewLearningHistory" runat="server" Text="<%$ LabelResourceExpression: app_view_learning_history_button_text %>" />'
                            class="ViewLearninghistory cursor_hand" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <%--<asp:GridView ID="gvMyTeam" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="None" GridLines="None" AutoGenerateColumns="False"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowDataBound="gvMyTeam_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" HeaderText="Employee Name (ID)" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <div id="firstNameDiv" runat="server">
                            <asp:Label ID="lblFirstName" Text='<%#Eval("FirstName")%>' runat="server"></asp:Label>
                        </div>                       
                    </ItemTemplate>
                </asp:TemplateField>                 
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Job Title" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                    DataField='JobTitle'></asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewCourse" runat="server" Text="View Course" />'
                            class="ViewCourse cursor_hand" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewCurricula" runat="server" Text="View Curricula" />'
                            class="ViewCurricula cursor_hand" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewLearningHistory" runat="server" Text="View Learning History" />'
                            class="ViewLearninghistory cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
        <b>
            <asp:LinkButton ID="lnkViewAllTeam" runat="server" Text="<%$ LabelResourceExpression: app_view_all_my_team_button_text %>"
                OnClick="lnkViewAllTeam_Click" CssClass="body_link"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInReport(this);return false;" runat="server"
                ID="imgReport" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_report" runat="server">
        <asp:GridView ID="gvReport" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
            GridLines="None" DataKeyNames="e_curriculum_assign_curriculum_id_fk" AutoGenerateColumns="False"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_report_name_with_id_text %>" DataField='title'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField='e_curriculum_assign_date_time'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_run_date_text %> " DataField='e_curriculum_assign_date_time'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewLast" runat="server" Text="<%$ LabelResourceExpression: app_view_last_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnScheduleIt" runat="server" Text="<%$ LabelResourceExpression: app_schedule_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnGenrateIt" runat="server" Text="<%$ LabelResourceExpression: app_generate_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllReport" runat="server" Text="<%$ LabelResourceExpression: app_view_all_my_report_button_text %>"
                OnClick="lnkViewAllReport_Click" CssClass="body_link"></asp:LinkButton></b>
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_manager_home_text")%>
        <br />
        <br />
    </div>
    <br />
    <br />
    <asp:Button ID="btnSplash" runat="server" Style="display: none;" />
    <asp:Panel ID="pnlSplashPage" runat="server" CssClass="modalPopup_width_900 modal_popup_background"
        Style="display: none; padding-left: 0px; padding-right: 0px;">
        <asp:Panel ID="pnlSplashPageHeading" runat="server" CssClass="drag">
            <div>
                <div class="div_header_900">
                    <span class="font_1" style="color: Black;">Splash Preview:</span>
                </div>
                <asp:ImageButton ID="ibtnCloseSplash" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                    z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png"
                    OnClick="ibtnCloseSplash_Click" />
            </div>
        </asp:Panel>
        <br />
        <div class="div_controls">
            <div class="div_padding_10" id="spalsh" style="height: 495px; overflow: auto" runat="server">
            </div>
        </div>
        <div class="div_header_900">
            &nbsp;
        </div>
        <br />
        <div>
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnDonotShow" ValidationGroup="JobTitle" runat="server" Text="Do Not Display Again"
                        OnClick="btnDonotShow_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCloseSplashPage" OnClick="btnCloseSplashPage_Click" CssClass="cursor_hand"
                        runat="server" Text="Close Splash Page" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <br />
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpSplashPage" runat="server" TargetControlID="btnSplash"
        PopupControlID="pnlSplashPage" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlSplashPageHeading">
    </asp:ModalPopupExtender>
</asp:Content>
