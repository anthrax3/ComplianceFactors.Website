<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvack-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.FieldNotes.Popup.csvack_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 240px;
        }
    </style>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div>
        <div class="div_header_700">
            Change Acknowledgement:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        Field Note Id
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblFieldNote" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Creation Date Time:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDateTime" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        Send By:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblSendBy" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5" class="align_left">
                        Acknowledgement Required, Do you acknowledge receipt?
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnAcknowledge" runat="server" Text="Yes" OnClick="btnAcknowledge_Click" />
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnNoAcknowledge" runat="server" Text="No" OnClick="btnNoAcknowledge_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
