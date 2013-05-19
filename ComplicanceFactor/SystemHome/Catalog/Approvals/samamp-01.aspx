<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samamp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.samamp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class=" div_header_long">
            Advanced Approvals Queue Search:
        </div>
        <br />
        <table class="table_td_300 div_controls">
            <tr>
                <td>
                    Employee Id:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    Employee Name:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server" 
                    DataValueField="e_enroll_approval_status_system_id_pk" DataTextField="e_enroll_approval_status_name">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td>
                    Approver ID:
                </td>
                <td>
                    <asp:TextBox ID="txtApproverId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    Approver Name:
                </td>
                <td>
                    <asp:TextBox ID="txtApproverName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    Approval ID:
                </td>
                <td>
                    <asp:TextBox ID="txtApprovalId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
        </table>
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" OnClick="btnGoSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
