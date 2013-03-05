<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lhp-01.aspx.cs" Inherits="ComplicanceFactor.lhp_01" MaintainScrollPositionOnPostback="true" %>

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

        });

        function expandDetailsInCourse(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgCourse", "div_course") //GETTING THE ID OF SUMMARY ROW

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
        function expandDetailsInCurriculum(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgCurriculum", "div_curriculum") //GETTING THE ID OF SUMMARY ROW

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
                    'href': '/Employee/Course/p-lvcd-01.aspx?id=' + record_id,
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
    <div class="content_area">
        <div>
            <%= LocalResources.GetText("app_welcome_content")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        My Courses:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInCourse(this);return false;" runat="server"
                ID="imgCourse" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_course" runat="server">
        <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="e_enroll_course_id_fk"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowDataBound="gvCourses_RowDataBound" OnRowCommand="gvCourses_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Course Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Required" DataField='required' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Due Date" DataField='duedate' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
<%--                        <asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="View" runat="server" Text="View Details"/>--%>
                  <input type="button" id='<%# Eval("deliveryId") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'
                   class="courseviewdetails cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDrop" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>' CommandName="Drop"
                            runat="server" Text="Drop" Style="display: none;" />
                        <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>'
                            runat="server" CommandName="Enroll" Text="Enroll" Style="display: none;" />
                        <asp:Button ID="btnLaunch" runat="server" CommandArgument='<%# Eval("e_enroll_course_id_fk") %>'
                            CommandName="Launch" Text="Launch" Style="display: none;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCourses" runat="server" Text="View All My Courses..."
                OnClick="lnkViewAllCourses_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        My Curricula:
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
            runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="e_curriculum_assign_curriculum_id_fk"
            AutoGenerateColumns="False" OnRowCommand="gvCurriculum_RowCommand" EmptyDataRowStyle-CssClass="empty_row"
            PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Curriculum Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Assignment Date" DataField='e_curriculum_assign_date_time' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Due Date" DataField='e_curriculum_assign_target_due_date' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewDetail" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="View" runat="server" Text="View Details" class="" />
                <%--   <input type="button" id='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'--%>
                  <%-- class="curriculumviewdetails cursor_hand" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="Enroll" runat="server" Text="Enroll" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCurriculum" runat="server" Text="View All My Curricula..."
                OnClick="lnkViewAllCurriculum_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        My Learning History:
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_footer_content")%>
        <br />
        <br />
    </div>
    <br />
    <br />
</asp:Content>
