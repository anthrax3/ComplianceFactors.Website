<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="enter-mass-completion-pin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.enter_mass_completion_pin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class=" div_header_700">
            Enter PIN and Reasons for Mass Completion Creation:
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="">
                <tr>
                    <td>
                        Selected Courses(s)/Delivery(ies):
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        Selected Employee(s):
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        Completion Status:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        Completion Date:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        Notes:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotes" TextMode="MultiLine" Rows="6" Width="500px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
        </div>
        <div  class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        PIN:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPin" CssClass="width_40" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnCreatePin" runat="server" Text="Create A PIN" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnCreateCompletion" runat="server" Text="Create Completion Records" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
