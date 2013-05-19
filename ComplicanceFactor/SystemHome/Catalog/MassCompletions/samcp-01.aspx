<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassCompletions.samcp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Catalog Item(s):
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" CssClass=" grid_870" ShowHeader="false"
                ShowFooter="false" GridLines="None" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblCourse" runat="server" Text="Course"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseName" runat="server" Text="CourseName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" runat="server">
                                <asp:ListItem>Select a Delivery...</asp:ListItem>
                                <asp:ListItem>CF-CODE-ETHICS-OLT-04212013</asp:ListItem>
                                <asp:ListItem>CF-CODE-ETHICS-OLT-05212013</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveCatalogItem" runat="server" Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddCatalogItem" runat="server" Text="Add Catalog Item(s)" />
            <br />
            <br />
        </div>
        <div class="div_header_long">
            Employee(s):
        </div>
        <div class=" div_controls font_1">
        <br />
            <asp:GridView ID="gvEmployee" AutoGenerateColumns="false" CssClass=" grid_870" ShowHeader="false"
                ShowFooter="false" GridLines="None" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeName" runat="server" Text="EmployeeName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeId" runat="server" Text="EmployeeId"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveEmployee" runat="server" Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee(s)" />
            <br />
            <br />
        </div>
        <div class=" div_header_long">
            Completion Information:
        </div>
        <br />
        <div class="div_padding_10" id="div_course" runat="server">
            <asp:GridView ID="gvCompletionInfo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                runat="server" EmptyDataText="No Result Found" GridLines="None" AutoGenerateColumns="False"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4 align_center" HeaderText="Comments"
                        ItemStyle-CssClass="gridview_row_width_4" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Rows="7" Width="300px">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3 align_center" HeaderText="Completion Date"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCompletionDate" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attendance" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlAttendance" runat="server">
                                <asp:ListItem>Attended</asp:ListItem>
                                <asp:ListItem>Did Not Attend/No Show</asp:ListItem>
                                <asp:ListItem>Partially Attended</asp:ListItem>
                                <asp:ListItem>Attended/Walk In</asp:ListItem>
                                <asp:ListItem>Unknown</asp:ListItem>
                                <asp:ListItem>OLT Player</asp:ListItem>
                                <asp:ListItem>VLS System</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Passign Status" HeaderStyle-CssClass="gridview_row_width_3 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPassingStatus" runat="server">
                                <asp:ListItem>Passed</asp:ListItem>
                                <asp:ListItem>Failed</asp:ListItem>
                                <asp:ListItem>Exempt</asp:ListItem>
                                <asp:ListItem>Not Scored</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlGrade" runat="server">
                                <asp:ListItem>S</asp:ListItem>
                                <asp:ListItem>U</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" CssClass=" width_30" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnProcessMassCompletion" runat="server" Text="Process Mass Completion" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
