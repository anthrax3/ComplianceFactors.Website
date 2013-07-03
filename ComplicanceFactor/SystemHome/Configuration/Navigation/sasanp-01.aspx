<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sasanp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Navigation.sasanp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 650px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 200px;
        }
    </style>
   <div id="content">
        <div class="div_header_650">
            UI Page Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Native Label:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtNativeLabel" CssClass="textarea_long_2" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        UI Page URI:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageURI" CssClass="textarea_long_2" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnGeneratePage" CssClass="cursor_hand" Text="Generate UI Page" 
                        runat="server" onclick="btnGeneratePage_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                        runat="server" Text="Cancel" />
                </div>
                <div class="clear">
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
