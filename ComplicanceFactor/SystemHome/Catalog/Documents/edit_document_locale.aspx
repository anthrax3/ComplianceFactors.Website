<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="edit_document_locale.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.edit_document_locale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" div_header_650">
    </div>
    <div class=" div_controls font_1">
        <table class="">
            <tr>
                <td>
                    Document Name:
                </td>
                <td>
                    <asp:TextBox ID="txtDocumentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description:
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="500px" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <%--<table>
            <tr>
                <td>
                    Document File:
                </td>
                <td>
                    <asp:Label ID="lblDocumentFileName" runat="server" Text="FileName"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnView" runat="server" Text="View" />
                </td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" />
                </td>
                <td>
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" />
                </td>
            </tr>
        </table>--%>
    </div>

        <asp:GridView ID="gvLocales" style=" margin-left:20px" AutoGenerateColumns="false" CssClass="grid_700" GridLines="None"
            ShowHeader="false" ShowFooter="false" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table class="div_controls font_1">
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

    <div>
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnSaveLocale" runat="server" Text="Save Locale" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
