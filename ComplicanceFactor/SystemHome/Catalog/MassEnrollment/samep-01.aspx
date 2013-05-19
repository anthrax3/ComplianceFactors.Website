<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samep-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassEnrollment.samep_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Catalog Item(s):
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" CssClass=" grid_900" ShowHeader="false"
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
                            <asp:CheckBox ID="chkSelectDelivery" runat="server" />
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
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkRequired" Text="Required" TextAlign="Left" runat="server" />
                    </td>
                    <td>
                        Target Due Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTargetDueDate" CssClass="width_75" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnProcessMassEnrollment" runat="server" Text="Process Mass Enrollment" />
                    </td>
                    <td colspan="3">
                    </td>
                    <td>
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
