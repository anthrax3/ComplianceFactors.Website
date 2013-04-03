<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saucmcp-01_SearchEmp.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Update_Curriculum.saucmcp_01_SearchEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--SearchEmployee Popup--%>
    <div id="divSearchEmployee" class="div_controls font_1">
        <table cellpadding="0" cellspacing="0">
            <tr style="background-color: #96CD19">
                <td style="width: 630px; height: 20px; text-align: left">
                    Employees Search:
                </td>
                <td style="height: 20px; width: 100px">
                    <input id="imgClosePopup" class="cursor_hand" src="../../../Images/contentCloseButton.png"
                        style="margin: 0px; height: 10px; padding: 0px; cursor: pointer;" tabindex="0"
                        type="image" />
                </td>
            </tr>
        </table>
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
                    <asp:Button CssClass="cursor_hand" ID="btnGoSearch" runat="server" 
                        Text="Go Search" 
                        PostBackUrl="~/SystemHome/Configuration/Update Curriculum/saucmcp-01_SearchEmpResults.aspx" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button CssClass="cursor_hand" ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                </td>
                <td>
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
</asp:Content>
