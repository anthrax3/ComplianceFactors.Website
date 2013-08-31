<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lhp-01.aspx.cs" Inherits="ComplicanceFactor.lhp_01" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_employee').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_employee').addClass('selected');
                return false;
            });
        });

        $(function () {
            $('#<%=gvCourses.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $('#<%=gvCurriculum.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $('#<%=gvLearningHistory.ClientID %>')
			.tablesorter({ headers: { 5: { sorter: false }, 6: { sorter: false}} });

        });


        function expandDetailsInCourse(_this) {
            //
            var div_course = document.getElementById('<%=this.div_course.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgCourse", "div_course");  //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus";
                //
                div_course.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus";
                //
                div_course.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInCurriculum(_this) {
            //
            var div_curriculum = document.getElementById('<%= this.div_curriculum.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgCurriculum", "div_curriculum") //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                //
                div_curriculum.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                //
                div_curriculum.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;

        }


        function expandDetailsLearningHistory(_this) {
            //
            var div_LearningHistory = document.getElementById('<%= this.div_LearningHistory.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgLearningHistory", "div_LearningHistory") //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                //
                div_LearningHistory.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                //
                div_LearningHistory.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;

        }


        // Course view popup
        $(document).ready(function () {

            $(".courseviewdetails").click(function () {
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
                    'width': 732,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Employee/Course/lvcd-01.aspx?id=' + record_id,
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

            $(".ViewLearningdetails").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 732,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Employee/Course/p-lvcomd.aspx?cid=' + element[0] + '&eid=' + element[1],
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


            //Curriculum popup
            //            $(document).ready(function () {

            //                $(".curriculumviewdetails").click(function () {
            //                    //Get the Id of the record to delete
            //                    var record_id = $(this).attr("id");
            //                    //Get the GridView Row reference
            //                    var tr_id = $(this).parents("#.record");
            //                    $.fancybox({

            //                        'type': 'iframe',
            //                        'titlePosition': 'over',
            //                        'titleShow': true,
            //                        'showCloseButton': true,
            //                        'scrolling': 'yes',
            //                        'autoScale': false,
            //                        'autoDimensions': false,
            //                        'helpers': { overlay: { closeClick: false} },
            //                        'width': 732,
            //                        'height': 200,
            //                        'margin': 0,
            //                        'padding': 0,
            //                        'overlayColor': '#000',
            //                        'overlayOpacity': 0.7,
            //                        'hideOnOverlayClick': false,
            //                        'href': '/Employee/Curricula/lvcurd-01.aspx?id=' + record_id,
            //                        'onComplete': function () {
            //                            $.fancybox.showActivity();
            //                            $('#fancybox-frame').load(function () {
            //                                $.fancybox.hideActivity();
            //                                $('#fancybox-content').height($(this).contents().find('body').height() + 20);
            //                                var heightPane = $(this).contents().find('#content').height();
            //                                $(this).contents().find('#fancybox-frame').css({
            //                                    'height': heightPane + 'px'

            //                                })
            //                            });

            //                        }

            //                    });
            //                });

            //            });
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area">
        <div>
            <%= LocalResources.GetText("app_welcome_content_employee_home_text")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_courses_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInCourse(this);return false;" runat="server"
                ID="imgCourse" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_course" runat="server">
        <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" DataKeyNames="e_enroll_course_id_fk" AutoGenerateColumns="False"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowDataBound="gvCourses_RowDataBound"
            OnRowCommand="gvCourses_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text%>" DataField='title'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_required_text %>" DataField='required'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_due_date_text %>" DataField='duedate'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_status_text %>" DataField='status'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%--                        <asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="View" runat="server" Text="View Details"/>--%>
                        <input type="button" id='<%# Eval("e_enroll_course_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="<%$LabelResourceExpression: app_view_details_button_text %>" />'
                            class="courseviewdetails cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDrop" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>' CommandName="Drop"
                            runat="server" Text="<%$LabelResourceExpression: app_drop_button_text %>" Style="display: none;"
                            OnClientClick="return confirmStatus();" />
                        <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>' runat="server"
                            CommandName="Enroll" Text="<%$LabelResourceExpression: app_enroll_button_text %>"
                            Style="display: none;" />
                        <asp:Button ID="btnLaunch" runat="server" CommandArgument='<%# Eval("scormURL") %>'
                            CommandName="Launch" Text="<%$LabelResourceExpression: app_launch_button_text %>"
                            Style="display: none;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCourses" runat="server" Text="<%$LabelResourceExpression: app_view_all_my_course_button_text%>"
                OnClick="lnkViewAllCourses_Click" CssClass="body_link"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_curricula_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInCurriculum(this);return false;" runat="server"
                ID="imgCurriculum" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_curriculum" runat="server">
        <asp:GridView ID="gvCurriculum" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" DataKeyNames="e_curriculum_assign_curriculum_id_fk" AutoGenerateColumns="False"
            OnRowCommand="gvCurriculum_RowCommand" EmptyDataRowStyle-CssClass="empty_row"
            PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$LabelResourceExpression: app_curriculum_title_with_id_text%>"
                    DataField='title' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$LabelResourceExpression: app_assignment_date_text%>" DataField='e_curriculum_assign_date_time'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_due_date_text %>" DataField='e_curriculum_assign_target_due_date'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_status_text %>" DataField='status'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewDetail" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="View" runat="server" Text="<%$LabelResourceExpression: app_view_details_button_text %>"
                            CssClass="cursor_hand" />
                        <%--   <input type="button" id='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'--%>
                        <%-- class="curriculumviewdetails cursor_hand" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="Enroll" runat="server" Text="<%$LabelResourceExpression: app_enroll_button_text %>"
                            CssClass="cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCurriculum" runat="server" Text="<%$LabelResourceExpression: app_view_all_my_curricula_button_text%>"
                OnClick="lnkViewAllCurriculum_Click" CssClass="body_link"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_learning_history_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsLearningHistory(this);return false;"
                runat="server" ID="imgLearningHistory" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_LearningHistory" runat="server">
        <asp:GridView ID="gvLearningHistory" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row"
            DataKeyNames="t_transcript_course_id_fk,title,t_transcript_delivery_id_fk" PagerSettings-Visible="false"
            OnRowCommand="gvLearningHistory_RowCommand" OnRowDataBound="gvLearningHistory_RowDataBound">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$LabelResourceExpression: app_course_title_with_id_text%>" DataField='title'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$LabelResourceExpression: app_completion_date_text%>" DataField='date'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_status_text %>" DataField='status'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_score_text %>" DataField='score'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$LabelResourceExpression: app_delivery_text %>" DataField='deliveryType'
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnReview" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                            CommandName="Review" runat="server" Text="<%$ LabelResourceExpression:app_review_button_text %>"
                            Style="display: none;" />
                        <%--<asp:Button ID="btnViewDetails" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                            Style="display: none;" runat="server" CommandName="View" Text="<%$LabelResourceExpression: app_view_details_button_text %>" />--%>
                        <asp:Literal ID="ltlViewDetails" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnEnroll" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                            runat="server" CommandName="Enroll" Text="Re-Enroll" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnCertificate" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                            CommandName="Certificate" Style="display: none;" runat="server" Text="<%$LabelResourceExpression: app_certificate_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllLearningHistory" runat="server" CssClass="body_link"
                Text="<%$LabelResourceExpression: app_view_all_my_learning_history_button_text %>"
                OnClick="lnkViewAllLearningHistory_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_employee_home_text")%>
        <br />
        <br />
    </div>
    <br />
    <rsweb:ReportViewer ID="rvLearningHistory" runat="server" Style="display: none;"
        DocumentMapCollapsed="true" ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
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
