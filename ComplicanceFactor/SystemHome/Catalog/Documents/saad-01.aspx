<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saad-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.saad_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_information_text")%>:
        </div>
        <div class=" div_controls font_12_pixel">
            <table class="table_td_300" cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_version_no_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblVersionNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_id_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblDocumentId" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_document_name_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblDocumentName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:Label ID="lblDocumentDesc" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_file_name_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblDocumentFileName" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblDocumentType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
