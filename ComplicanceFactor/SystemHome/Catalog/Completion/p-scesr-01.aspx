<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-scesr-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.p_scesr_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_1005">
            Employees Search Results:
        </div>
        <br />
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="|<<First" runat="server" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="Next>>" runat="server" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="Last>>|" runat="server" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblHeaderPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvEmployeeSearchResults" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
            runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="Employee LastName"
                    ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="Employee FirstName"
                    ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Number"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllSelect" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRowSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table>
            <tr>
                <td style="width: 800px">
                </td>
                <td style="width: 205px; text-align: right">
                    <asp:Button ID="btnSaveSelected" runat="server" Text="Save Selected" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="|<<First" runat="server" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="Next>>" runat="server" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="Last>>|" runat="server" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_1005">
            Employee Search:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Employee Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        Employee Number:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
