<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="view_data_import_log_details.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Imports.view_data_import_log_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 150px;
        }
    </style>
    <div>
        <div class="div_header_650">
         Data Import Log Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td class="align_left" colspan="8">
                        <textarea id="txtDataImportLogDetails" runat="server" rows="30" cols="77"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2" class="align_left">
                        <asp:Button ID="btnDownloadLog" CssClass="cursor_hand" Text="Download Log"
                            runat="server" />
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
                            runat="server" Text="CloseWindow" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

