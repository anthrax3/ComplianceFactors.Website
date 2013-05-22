<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samwmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.samwmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Advanced Wailists Search:
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        Employee ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Employee Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        WaitList ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWaitListId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Course ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Course Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
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
                    <td class="align_right">
                        Delivery ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
        &nbsp;
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                    <td></td>
                    <td></td>
                    <td class="align_right">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                    <td></td>
                    <td></td>
                    <td class="align_right">
                        <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" 
                            onclick="btnGoSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
