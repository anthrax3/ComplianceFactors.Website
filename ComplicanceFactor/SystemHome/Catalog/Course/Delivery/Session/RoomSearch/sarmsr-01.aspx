<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sarmsr-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.DeliveryPopup.sarmsr_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ComplianceFactors - Room Search Results</title>
    <link href="../../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 800px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 300px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtRoomName.ClientID %>').value = '';
            document.getElementById('<%=txtRoomId.ClientID %>').value = '';

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 2: { sorter: false}} });

        });
    </script>
    <div>
        <%-- Room search result--%>
        <div>
            <div class="div_header_800">
               <%=LocalResources.GetLabel("app_room_search_result_text")%>:
            </div>
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="paging_800">
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
                            <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                            <asp:Label ID="lblHeaderPageOf" runat="server" />
                            <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                                OnClick="btnHeaderGoto_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_800 tablesorter"
                runat="server" EmptyDataText="No result found." DataKeyNames="c_room_system_id_pk"
                AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="5" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_room_name_text %>" DataField='c_room_name' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_room_id_text %>" DataField='c_room_id_pk' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CommandName="Select" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging_800">
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
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnFooterGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <%--  close Room search result--%>
        <br />
        <%--    Room search--%>
        <div>
            <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
                <div class="div_header_800">
                   <%=LocalResources.GetLabel("app_room_search_text")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_room_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtRoomName" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_room_id_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtRoomId" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="align_left">
                                <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                                    OnClick="btnGosearch_Click" />
                            </td>
                            <td class="align_left">
                                <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" OnClientClick="return resetall();"
                                    runat="server" />
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                    runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
    <%-- close Room search--%>
    </form>
</body>
</html>
