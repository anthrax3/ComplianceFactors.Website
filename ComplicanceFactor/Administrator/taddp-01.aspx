<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="taddp-01.aspx.cs" Inherits="ComplicanceFactor.Administrator.taddp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_admin').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_admin').addClass('selected');
                return false;
            });
        });

        $(function () {
            $('#<%=gvMyDeliveries.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
        });
    </script>
    <div class="content_area">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_administrator_home_text")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_courses_text")%>:
        <div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="<%$ LabelResourceExpression: app_print_to_pdf_button_text %>"
                OnClick="btnPrintPdf_Click" />
            <asp:Button ID="btnExportExcel" runat="server" Text="<%$ LabelResourceExpression: app_export_to_excel_button_text %>"
                OnClick="btnExportExcel_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                        runat="server" OnClick="btnHeaderFirst_Click" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                        runat="server" OnClick="btnHeaderPrevious_Click" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                        runat="server" OnClick="btnHeaderNext_Click" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                        runat="server" OnClick="btnHeaderLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                    <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" Text="of" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                        OnClick="btnHeaderGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvMyDeliveries" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" DataKeyNames="system_id" AllowPaging="true"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvMyDeliveries_RowCommand" OnRowEditing="gvMyDeliveries_RowEditing">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField="title_and_id"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_dates_text %>" DataField="c_course_cert_date"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_name_with_id_text %>" DataField="c_delivery_type"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageCourse" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Manage" runat="server" Text="Manage Courses" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField="courseTitle" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_name_with_id_text %>" DataField="deliveryTitle" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_dates_text %>" DataField="Coursedate" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageRosters" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Completion" runat="server" Text="<%$ LabelResourceExpression: app_manage_roster_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnPrint" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Print" runat="server" Text="<%$ LabelResourceExpression: app_print_sign_up_sheets_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                        runat="server" OnClick="btnFooterFirst_Click" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                        runat="server" OnClick="btnFooterPrevious_Click" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                        runat="server" OnClick="btnFooterNext_Click" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                        runat="server" OnClick="btnFooterLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                    <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" Text="of" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                        OnClick="btnFooterGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_deliveries_search_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_course_name_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_from_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtDateFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="ceDateFrom" Format="MM/dd/yyyy" TargetControlID="txtDateFrom"
                        runat="server">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_to_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtDateTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="ceDateTp" Format="MM/dd/yyyy" TargetControlID="txtDateTo"
                        runat="server">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_delivery_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDeliveryType" DataValueField="s_delivery_type_system_id_pk"
                        DataTextField="s_delivery_type_name" CssClass="dropdownlist_width" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <table>
            <tr>
                <td colspan="10">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2">
                    <asp:Button ID="btnReset" runat="server" class="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                        OnClick="btnReset_Click" />
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" class="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                        OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <div class="div_header_long">
            &nbsp;
        </div>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_footer_administrator_home_text")%>
            <br />
            <br />
        </div>
        <rsweb:ReportViewer ID="rvMyDelivery" runat="server" Style="display: none;" DocumentMapCollapsed="true"
            ShowDocumentMapButton="false">
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="rvMySignUpSheet" runat="server" Style="display: none;" DocumentMapCollapsed="true"
            ShowDocumentMapButton="false">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
