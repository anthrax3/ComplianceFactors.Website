<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saews-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.saews_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" runat="server" Text="Save Waitlist" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Wailist Information:
        </div>
        <br />
        <div>
            <table class="table_td_300 div_controls font_1">
                <tr>
                    <td class="align_right">
                        Waitlist ID:
                    </td>
                    <td>
                        <asp:Label ID="lblWaitlistId" runat="server" Text="000000001"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Course Name / Id:
                    </td>
                    <td>
                        <asp:Label ID="lblCourseName" runat="server" Text="New Hire Orientation (CF-NEW-HIRE-ILT)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Delivery Id:
                    </td>
                    <td>
                        <asp:Label ID="lblDeliveryId" runat="server" Text="CF-NEW-HIRE-ILT-04212013"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Delivery Name:
                    </td>
                    <td>
                        <asp:Label ID="lblDeliveryName" runat="server" Text="New Hire Orientation 04/21/2013 (ILT)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Delivery Start:
                    </td>
                    <td>
                        <asp:Label ID="lblDeliveryStart" runat="server" Text="02/21/2013"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Delivery End:
                    </td>
                    <td>
                        <asp:Label ID="lblDeliveryEnd" runat="server" Text="02/21/2013"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Min Enroll:
                    </td>
                    <td>
                        <asp:Label ID="lblMinEnroll" runat="server" Text="3"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Max Enroll:
                    </td>
                    <td>
                        <asp:Label ID="lblMaxEnroll" runat="server" Text="12"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Wailist Details:
        </div>
        <br />
        <div class="div_controls">
            <table>
                <tr>
                    <td class="align_left font_1">
                        Waitlist(3/5):
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvWaitlistDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No Result Found" AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="10">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Employee ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderText="Priority" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPriority" CssClass=" width_75" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderText="Rank" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnUp" CssClass="cursor_hand" CommandName="Copy" runat="server" Text="Up" />
                            <asp:Button ID="btnDown" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Down" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnManageRoster" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Manage Roster" />
                            <asp:Button ID="btnRemove" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnFooterSave" runat="server" Text="Save Approval WorkFlow" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnFooterReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnFooterCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
