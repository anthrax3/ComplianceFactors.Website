﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samspmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Splash_Pages.samspmp_01" %>

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
                $(this).addClass('active');

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
			.tablesorter({ headers: { 6: { sorter: false }, 7: { sorter: false }, 8: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtSplashPageId.ClientID %>').value = '';
            document.getElementById('<%=txtName.ClientID %>').value = '';
            document.getElementById('<%=txtOwner.ClientID %>').value = '';
            document.getElementById('<%=txtCoordinator.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlDomain.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <br />
     <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div class="div_header_long">
             <%=LocalResources.GetLabel("app_advanced_splash_page_search_results_text")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnHeaderLast_Click" />
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
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="10"
                DataKeyNames="u_splash_system_id_pk" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_splash_page_id_text %>" HeaderStyle-HorizontalAlign="Center" DataField="u_splash_id_pk"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_splash_page_name_text %>" HeaderStyle-HorizontalAlign="Center" DataField="u_splash_name"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_domain_text %>" HeaderStyle-HorizontalAlign="Center" DataField="u_domain_name"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_status_text %>" HeaderStyle-HorizontalAlign="Center" DataField="s_status_name"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_owner_text %>" HeaderStyle-HorizontalAlign="Center" DataField="ownername"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_coordinator_text %>" HeaderStyle-HorizontalAlign="Center" DataField="coordinatorname"
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
                            <asp:Button ID="btnCopy" CommandName="Copy" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnArchive" CommandName="Archive" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                OnClientClick="return confirmStatus();" CssClass="cursor_hand" runat="server"
                                Text="<%$ LabelResourceExpression: app_archive_button_text %>" />
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
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnFooterLast_Click" />
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
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnFooterGoto_Click" />
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
                 <%=LocalResources.GetLabel("app_advances_splash_pages_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_splash_page_id_text")%>: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtSplashPageId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_splash_page_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_domain_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDomain" DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_status_text")%>: 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_owner_text")%>: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnCreateNewSplashPage" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_create_new_splash_pages_button_text %>"
                                OnClick="btnCreateNewSplashPage_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" OnClientClick="return resetall();" CssClass="cursor_hand"
                                Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                                OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <br />
    </div>
</asp:Content>