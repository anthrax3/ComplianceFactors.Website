<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p_samvdimplo-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Imports.Popup.p_samvdimplo_01" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <div id="content">
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header_650">
            HRIS Log Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <div id="LogDetails" runat="server" style="height: 450px; overflow: auto;">
            </div>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2" class="align_left">
                        <asp:Button ID="btnDownloadLog" CssClass="cursor_hand" Text="Download Log" runat="server"
                            OnClick="btnDownloadLog_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnPrint" CssClass="cursor_hand" Text="Print" runat="server" OnClick="btnPrint_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Button ID="btnCloseWindow" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                            runat="server" Text="Close Window" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <rsweb:ReportViewer ID="rvErrorLog" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
</asp:Content>
