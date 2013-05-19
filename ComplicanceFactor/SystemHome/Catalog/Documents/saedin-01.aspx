<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saedin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.saedin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnHeaderSave" runat="server" Text="Save New Document" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnHeaderReset" runat="server" Text="Reset" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnHeaderCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            Document Information (English US):
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        Document Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentId" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Document Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Description:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="650px" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvDocument" Style="margin-left: 130px" AutoGenerateColumns="false"
            CssClass="grid_700" GridLines="None" ShowHeader="false" ShowFooter="false" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table class="div_controls font_1">
                            <tr>
                                <td class="align_left">
                                    <asp:Label ID="lblLocaleName" runat="server" Text="Locale-Name"></asp:Label>
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
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class=" align_right">
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
                <td class="align_right">
                    <asp:Button ID="btnfooterReset" runat="server" Text="Reset" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>
