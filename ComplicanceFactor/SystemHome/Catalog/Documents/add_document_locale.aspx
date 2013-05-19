<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="add_document_locale.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.add_document_locale" %>

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
            <tr>
                <td>
                    Document File:
                </td>
                <td>
                    <asp:Button ID="btnUploadDocument" runat="server" Text="Upload Document File" />
                </td>
            </tr>
        </table>
    </div>
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
