<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-samvhrislo-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.HRIS_Integration.Popup.p_samvhrislo_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 650px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <div>
        <div class="div_header_650">
            HRIS Log Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <div id="LogDetails" runat="server" style="height:450px; overflow:auto;">
            </div>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2" class="align_left">
                        <asp:Button ID="btnDownloadLog" CssClass="cursor_hand" Text="Download Log" 
                            runat="server" onclick="btnDownloadLog_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnPrint" CssClass="cursor_hand" Text="Print" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Button ID="btnCloseWindow" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                            runat="server" Text="Close Window" onclick="btnCloseWindow_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
