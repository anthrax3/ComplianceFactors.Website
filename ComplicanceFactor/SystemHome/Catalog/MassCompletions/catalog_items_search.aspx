<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="catalog_items_search.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassCompletions.catalog_items_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" div_header_700">
        Catalog Items Search:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    Catalog Item Name:
                </td>
                <td>
                    <asp:TextBox ID="txtCatalogName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    Catalog Item Id:
                </td>
                <td>
                    <asp:TextBox ID="txtCatalogId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" />
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
