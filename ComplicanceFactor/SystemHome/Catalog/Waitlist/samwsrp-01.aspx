<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samwsrp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.samwsrp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Advanced Wailists Search Reults:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<<First" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="Next>>" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="Last>>|" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Results Per Page"></asp:Label>
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
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No Result Found" AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="c_delivery_system_id_pk,c_course_system_id_pk"
                PageSize="10" onrowcommand="gvsearchDetails_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Course ID" HeaderStyle-HorizontalAlign="Center" DataField="c_course_id_pk"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Course Name" HeaderStyle-HorizontalAlign="Center" DataField="c_course_title"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderText="WaitList Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Delivery ID" HeaderStyle-HorizontalAlign="Center" DataField="c_delivery_id_pk"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Delivery Name" HeaderStyle-HorizontalAlign="Center" DataField="c_delivery_title"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" CssClass="cursor_hand" CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="Select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="|<<First" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="Next>>" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="Last>>|" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Results Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Advanced Wailists Search:
        </div>
        <br />
        <table class="table_td_300 div_controls">
            <tr>
                <td>
                    Employee ID:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Employee Name:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    WaitList ID:
                </td>
                <td>
                    <asp:TextBox ID="txtWaitlistId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Course ID:
                </td>
                <td>
                    <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Approver Name:
                </td>
                <td>
                    <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Coordinator:
                </td>
                <td>
                    <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Delivery ID:
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Delivery Name:
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Delivery Date:
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
