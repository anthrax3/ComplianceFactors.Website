<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lmcp-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Course.lmcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
            $(".viewdetails").click(function () {
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
        });

        $(function () {
            $('#<%=gvCourses.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });

        });

  
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="content">
        <div class="content_area">
            <div>
                <%= LocalResources.GetText("app_welcome_content_emp_course_text")%>
                <br />
                <br />
                <br />
            </div>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_my_courses_text")%>:
            <div class="right div_padding_10">
                <asp:Button ID="btnPrintPdf" runat="server" Text="<%$ LabelResourceExpression: app_print_to_PDF_button_text %>"
                    OnClick="btnPrintPdf_Click" />
                <asp:Button ID="btnExportExcel" runat="server" Text="<%$ LabelResourceExpression: app_export_to_excel_button_text %>"
                    OnClick="btnExportExcel_Click" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="div_padding_10" id="div_course" runat="server">
            <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                GridLines="None" DataKeyNames="e_enroll_course_id_fk" AutoGenerateColumns="False"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowDataBound="gvCourses_RowDataBound"
                OnRowCommand="gvCourses_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField='title'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_required_text %>" DataField='required'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_due_date_text %>" DataField='duedate'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_status_text %>" DataField='status'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("e_enroll_course_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="<%$ LabelResourceExpression: app_view_details_button_text %>" />'
                                class="viewdetails cursor_hand" />
                            <%-- <asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="View" runat="server" Text="View Details" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnDrop" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>' CommandName="Drop"
                                runat="server" Text="<%$ LabelResourceExpression: app_drop_button_text %>" Style="display: none;" />
                            <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_enroll_course_id_fk")%>' runat="server"
                                CommandName="Enroll" Text="<%$ LabelResourceExpression: app_enroll_button_text %>"
                                Style="display: none;" />
                            <asp:Button ID="btnLaunch" runat="server" CommandArgument='<%# Eval("scormURL") %>'
                                CommandName="Launch" Text="<%$LabelResourceExpression: app_launch_button_text %>"
                                Style="display: none;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_footer_emp_course_text")%>
        </div>
        <br />
        <br />
        <rsweb:ReportViewer ID="rvCourses" runat="server" Style="display: none;" DocumentMapCollapsed="true"
            ShowDocumentMapButton="false">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
