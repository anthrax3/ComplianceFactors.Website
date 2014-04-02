﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samdtmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.RootCauseCategory.samdtmp_01" %>

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
                $(this).addClass('active');s

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

    </script>
     <script type="text/javascript">

         $(function () {
             $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

         });
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtCategoryId.ClientID %>').value = '';
            document.getElementById('<%=txtCategoryName.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlCategoryType.ClientID %>').selectedIndex = '0';
            return false;
        }

        function ConfirmArchive() {
            if (confirm("Are you sure?") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
           Advanced Root Cause Category Search Results:
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
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                DataKeyNames="c_tb_rc_category_system_id_pk" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="10" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Category Id" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        DataField="c_tb_rc_category_id" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Category Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        DataField="c_tb_rc_category_title" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Category Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        DataField="c_tb_rc_category_type" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        DataField="status" />
                    
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
                            <asp:Button ID="btnArchive" CommandName="Archive" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_archive_button_text %>" OnClientClick="return ConfirmArchive();" />
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
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_long">
               Advanced Root Cause Category Search Results:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            Category Id:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                          Name: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_status_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" CssClass="ddl_user_advanced_search" DataTextField="s_status_name"
                            DataValueField="s_status_id_pk" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Category Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategoryType" CssClass="ddl_user_advanced_search"  runat="server"
                            >
                            <asp:ListItem Text= "All" Value=""></asp:ListItem>
                            <asp:ListItem Text= "People"></asp:ListItem>
                             <asp:ListItem Text= "Procedures"></asp:ListItem>
                              <asp:ListItem Text= "Hardware/Equipment"></asp:ListItem>
                               <asp:ListItem Text= "Environment"></asp:ListItem>
                                <asp:ListItem Text= "External"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddNewCategory" CssClass="cursor_hand" runat="server" Text="Create New Category"
                                OnClick="btnAddNewCategory_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" OnClientClick="return resetall();" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" 
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
