﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sasur-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.sasur_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
            $('#<%=gvsearchDetails.ClientID %>').tablesorter({ headers: { 7: { sorter: false }, 8: { sorter: false }, 9: { sorter: false }, 10: { sorter: false}} });

        });
      
    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtUsername.ClientID %>').value = '';
            document.getElementById('<%=txtFirstName.ClientID %>').value = '';
            document.getElementById('<%=txtLastName.ClientID %>').value = '';
            document.getElementById('<%=ddlUserdomain.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserTypes.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserstatus.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_users_search_details_text")%>
            </div>
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="paging">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                                OnClick="btnFirst_Click" />
                            <asp:Button ID="btnPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                                OnClick="btnPrevious_Click" />
                            <asp:Button ID="btnNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                                OnClick="btnNext_Click" />
                            <asp:Button ID="btnLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                                OnClick="btnLast_Click" />
                        </td>
                        <td align="center">
                            <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                            <asp:DropDownList ID="ddresultperpage" runat="server" OnSelectedIndexChanged="ddresultperpage_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem>5</asp:ListItem>
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
                            <asp:TextBox ID="txtPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                            <asp:Label ID="lblPage" runat="server" />
                            <asp:Button OnClick="btnGoto_Click" CssClass="cursor_hand" ID="btnGoto" runat="server"
                                Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <div class="page_text" align="center">
                    <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                        runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" DataKeyNames="u_username_enc,u_user_id_pk"
                        AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                        PageSize="5" OnPageIndexChanging="gvsearchDetails_PageIndexChanging" OnRowDataBound="gvsearchDetails_RowDataBound"
                        OnRowCommand="gvsearchDetails_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="u_last_name" HeaderText="<%$ LabelResourceExpression: app_last_name_text_header %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="u_first_name" HeaderText="<%$ LabelResourceExpression: app_first_name_text_header %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="u_middle_name" HeaderText="<%$ LabelResourceExpression: app_middle_name_text_header %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_username_text_header %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="u_active_status_flag_text" HeaderText="<%$ LabelResourceExpression: app_status_text_header %>"
                                SortExpression="Status" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="user_type" HeaderText="<%$ LabelResourceExpression: app_type_text %>"
                                SortExpression="Type" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                                HeaderStyle-HorizontalAlign="Left" DataField="user_domain_name" HeaderText="<%$ LabelResourceExpression: app_domain_text %>"
                                SortExpression="Domain" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" CommandName="Edit" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnCopy" CommandName="Copy" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnRetire" CommandName="Retire" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_retire_button_text %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnMerge" CommandName="Merge" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_merge_button_text %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="paging">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btndownFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                                OnClick="btndownFirst_Click" />
                            <asp:Button ID="btndownPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                                OnClick="btndownPrevious_Click" />
                            <asp:Button ID="btndownNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                                OnClick="btndownNext_Click" />
                            <asp:Button ID="btndownLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                                OnClick="btndownLast_Click" />
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                            <asp:DropDownList ID="dddownresultperpage" runat="server" OnSelectedIndexChanged="dddownresultperpage_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem>5</asp:ListItem>
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
                            <asp:TextBox ID="txtdownpage" runat="server" Text="1" CssClass="textbox_page_of_page"></asp:TextBox>
                            <asp:Label ID="lbldownPage" runat="server" />
                            <asp:Button OnClick="btndownGoto_Click" CssClass="cursor_hand" ID="btndownGoto" runat="server"
                                Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_users_advanced_search_text")%>
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_last_name_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_first_name_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_username_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsername" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_user_status_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUserstatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_user_types_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUserTypes" DataTextField="u_user_type_name" DataValueField="u_user_type_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_user_domain_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUserdomain" DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddnewuser" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_new_user_button_text %>"
                                OnClick="btnAddnewuser_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" OnClientClick="return resetall();"
                                Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
