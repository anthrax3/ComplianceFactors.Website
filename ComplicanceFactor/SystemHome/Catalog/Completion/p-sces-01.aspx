<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sces-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.p_sces_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_750">
            Employees Search:
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
