<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="enter-notes-pin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Update_Curriculum.enter_notes_pin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table_content_font
        {
            font-family: sans-serif;
            font-size: 12px;
            font-weight: bold;
        }
        .inner_table
        {
            margin-left: 10px;
        }
        .popup_CloseButton
        {
            margin: 0px;
            height: 20px;
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divPopup_EnterNotes">
        <table cellspacing="0" border="0" class="table_content_font">
            <tr style="background-color: #96CD19; padding: 5px 5px 5px 0px">
                <td style="width: 600px; height: 20px; text-align: left">
                    Enter PIN and Reasons for Curriculum Status Change:
                </td>
                <td style="height: 20px; width: 100px; text-align: right">
                    <input class="popup_CloseButton cursor_hand" id="imgClosePopup" src="../../../Images/contentCloseButton.png"
                        tabindex="0" type="image" />
                </td>
            </tr>
        </table>
        <br />
        <table cellpadding="5" class="table_content_font inner_table">
            <tr>
                <td>
                    Selected Employee(s):
                </td>
                <td>
                    David Ealy (In Progress - 90%) Jeff Kady (Revoked - 100%) Guy Tourigny (Acquired
                    - 100%)
                </td>
            </tr>
            <tr>
                <td>
                    New Status:
                </td>
                <td>
                    Retrain
                </td>
            </tr>
            <tr>
                <td>
                    New Due Date:
                </td>
                <td>
                    <asp:TextBox ID="txtDueDate" runat="server" Text="mm/dd/yy"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Notes:
                </td>
                <td>
                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="15" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    PIN:
                </td>
                <td>
                    <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCreatePin" runat="server" Text="Create a PIN" 
                        PostBackUrl="~/SystemHome/Configuration/Update Curriculum/create-pin-01.aspx" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveStatus" runat="server" Text="Save New Status" />
                </td>
                <td align="right">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
