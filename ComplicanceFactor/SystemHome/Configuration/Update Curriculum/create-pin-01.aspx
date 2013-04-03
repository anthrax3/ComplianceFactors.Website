<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="create-pin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Update_Curriculum.create_pin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table
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
    <div id="divPopup_CreatePin">
        <table cellspacing="0" border="0">
            <tr style="background-color: #96CD19; padding: 5px 5px 5px 0px">
                <td style="width: 620px; height: 20px; text-align: left">
                    Create a PIN:
                </td>
                <td style="height: 20px; width: 100px; text-align: right">
                    <input class="popup_CloseButton cursor_hand" id="imgClosePopup" src="../../../Images/contentCloseButton.png"
                        tabindex="0" type="image" />
                </td>
            </tr>
        </table>
        <br />
        <table cellpadding="5px" class="inner_table">
            <tr>
                <td>
                    Login Username:
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Login Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Enter PIN(5 digits):
                </td>
                <td>
                    <asp:TextBox ID="txtEnterPin" CssClass="textbox_50" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Validate PIN(5 digits):
                </td>
                <td>
                    <asp:TextBox ID="txtValidatePin" CssClass="textbox_50" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
        <table class="inner_table">
            <tr>
                <td style="width: 600px">
                    <asp:Button ID="btnSavePin" runat="server" Text="Save PIN" />
                </td>
                <td style="width: 100px" align="right">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
