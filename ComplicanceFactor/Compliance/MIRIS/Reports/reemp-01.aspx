<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Empty.Master" CodeBehind="reemp-01.aspx.cs"
    Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.reemp_01" %>

<%@ Register Src="dynamicsearch.ascx" TagName="dynamicsearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 1000px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
           
            return false;
        }
    </script>
    <div id="content">
        <div>
            <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
                <div class="div_header_800" style="width: 980px;">
                    Case Search:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <uc1:dynamicsearch ID="dynamicsearch1" runat="server" />
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="align_left">
                                <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search!" runat="server"
                                    OnClick="btnGosearch_Click" />
                            </td>
                            <td class="align_left">
                                <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick="return resetall();"
                                    runat="server" />
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                    runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
