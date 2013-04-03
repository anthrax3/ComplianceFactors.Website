<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saucmcp-01_SearchEmpResults.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Update_Curriculum.saucmcp_01_SearchEmpResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table_content_font
        {
            font-family: sans-serif;
            font-size: 12px;
            font-weight: bold;
        }
        .popup_CloseButton
        {
            margin: 0px;
            height: 20px;
            padding: 0px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divPopup_SearchEmpResult">
        <table class="table_content_font">
            <tr style="background-color: #96CD19; padding: 5px 5px 5px 0px">
                <td style="width: 920px; height: 20px; text-align: left">
                    Employees Search Results:
                </td>
                <td style="height: 20px; width: 100px; text-align: right">
                    <input class="popup_CloseButton cursor_hand" id="imgClosePopup" src="../../../Images/contentCloseButton.png"
                        tabindex="0" type="image" />
                </td>
            </tr>
        </table>
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
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
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
        <br />
        <asp:GridView ID="gvSearchResults" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
            runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="Employee Last Name"
                    ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="Employee First Name"
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
                <td style="width: 820px">
                </td>
                <td style="width: 200px; text-align: right">
                    <asp:Button ID="btnSaveSelected" runat="server" Text="Save Selected" 
                        PostBackUrl="~/SystemHome/Configuration/Update Curriculum/saucmcp-01.aspx" />
                </td>
            </tr>
        </table>
        <br />
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
        <div class="div_controls font_1">
            <div class="div_header_long">
                Employee Search:
            </div>
            <br />
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
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button CssClass="cursor_hand" ID="btnGoSearch" runat="server" Text="Go Search" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button CssClass="cursor_hand" ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Button CssClass="cursor_hand" ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <br />
                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>
