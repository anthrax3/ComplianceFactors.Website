<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="dsiplay_data_export_logs.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Exports.dsiplay_data_export_logs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 650px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 250px;
        }
    </style>
    <div>
        <%--Heading--%>
        <div class="div_header_650">
          Data Export Job Run(s):
        </div>
        <div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:GridView ID="gvDataExportJobRuns" AutoGenerateColumns="false" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCloseWindow" ValidationGroup="saaloc" runat="server" Text="Close Window" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

