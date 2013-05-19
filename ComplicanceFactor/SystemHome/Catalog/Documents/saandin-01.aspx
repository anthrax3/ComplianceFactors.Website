<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.saandin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" runat="server" Text="Save New Document" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderReset" CssClass="align_right" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnHeaderCancel" CssClass="align_right" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Document Information (English US):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Document Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="800px" runat="server"></asp:TextBox>
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
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Document Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDocumentType" CssClass=" width_115" runat="server">
                            <asp:ListItem>Standard Operating Procedure(SOP)</asp:ListItem>
                            <asp:ListItem>Material Safety Data Sheet(MSDS)</asp:ListItem>
                            <asp:ListItem>Best Practices</asp:ListItem>
                            <asp:ListItem>CheckLists</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnManageLocales" runat="server" Text="Manage Locales" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnFooterSave" runat="server" Text="Save New Document" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterReset" CssClass="align_right" runat="server" Text="Reset" />
                </td>
                <td>
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterCancel" CssClass="align_right" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
