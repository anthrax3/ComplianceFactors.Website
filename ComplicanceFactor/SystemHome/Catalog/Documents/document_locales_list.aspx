<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="document_locales_list.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.document_locales_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" div_header_600">
        All Locale(s):
    </div>
    <br />
    <asp:GridView ID="gvLocales" AutoGenerateColumns="false" CssClass="grid_700" GridLines="None"
        ShowHeader="false"  ShowFooter="false" runat="server">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table class=" table_td_300 div_controls font_1">
                        <tr>
                            <td class="align_left">
                                <asp:Label ID="lblLocaleName" runat="server" Text="Locale-Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" />
                            </td>
                            <td>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddlLocales" CssClass="width_115" runat="server">
                <asp:ListItem>Espanol(Espana,Alfabetizacion Internacional)</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnCreateNewLocale" runat="server" Text="Create New Locale" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnClosePopup" runat="server" Text="Close Window" />
            </td>
        </tr>
    </table>
</asp:Content>
