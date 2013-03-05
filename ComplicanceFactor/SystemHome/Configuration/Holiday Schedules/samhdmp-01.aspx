<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samhdmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules.samhdmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active'); s

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
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

         $(function () {
             $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

         });
    </script>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            Holiday Schedule(s):
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_first_button_text %>" onclick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_previous_button_text %>" onclick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_next_button_text %>" onclick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_last_button_text %>" onclick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" 
                            AutoPostBack="true" 
                            onselectedindexchanged="ddlHeaderResultPerPage_SelectedIndexChanged">
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
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" 
                            Text="<%$ LabelResourceExpression: app_go_to_button_text %>" onclick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" DataKeyNames="u_holiday_schedule_system_id_pk" EmptyDataText="No result found."
                AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="10" 
                onpageindexchanging="gvsearchDetails_PageIndexChanging" 
                onrowcommand="gvsearchDetails_RowCommand" 
                onrowediting="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_schedule_id_text %>" HeaderStyle-HorizontalAlign="Center" DataField="u_holiday_schedule_id"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_schedule_name_text %>" HeaderStyle-HorizontalAlign="Center" DataField="u_holiday_schedule_name"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_days_text %>" HeaderStyle-HorizontalAlign="Center" DataField="totalDays"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_status_text %>" HeaderStyle-HorizontalAlign="Center" DataField="s_status_name"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCopy" CommandName="Copy" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnArchive" CommandName="Archive" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CssClass="cursor_hand" OnClientClick="return confirmStatus();" runat="server" Text="<%$ LabelResourceExpression: app_archive_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_first_button_text %>" onclick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_previous_button_text %>" onclick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_next_button_text %>" onclick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_last_button_text %>" onclick="btnFooterLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" 
                            AutoPostBack="true" 
                            onselectedindexchanged="ddlFooterResultPerPage_SelectedIndexChanged">
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
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" 
                            Text="<%$ LabelResourceExpression: app_go_to_button_text %>" onclick="btnFooterGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Button ID="btnCreateNewSchedule" runat="server" Text="<%$ LabelResourceExpression: app_create_new_schedule_button_text %>" OnClick="btnCreateNewSchedule_Click" />
        </div>
    </div>
</asp:Content>
