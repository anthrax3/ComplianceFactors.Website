<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saucsrp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.saucsrp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <div class="content_area_long">
        <div class="div_header_long">
            Courses Curricula Search:
        </div>
        <br />
        <div>
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
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Curriculum ID" HeaderStyle-HorizontalAlign="Center" DataField=""
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Curriculum Title" HeaderStyle-HorizontalAlign="Center" DataField=""
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Curriculum Type" HeaderStyle-HorizontalAlign="Center" DataField=""
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Status" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Owner" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Cordinator" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Select" />
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
        </div>
        <br />
        <div class="div_header_long">
            Curricula Search:
        </div>
        <br />
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Curriculum Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Curriculum Title:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Curriculum Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCurriculumType" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Onboarding</asp:ListItem>
                            <asp:ListItem>Curriculum</asp:ListItem>
                            <asp:ListItem>Certification</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddStatus" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Owner:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Coordinator:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSearch" runat="server" Text="Go Search!" 
                            PostBackUrl="~/SystemHome/Configuration/Update Curriculum/saucmcp-01.aspx" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
