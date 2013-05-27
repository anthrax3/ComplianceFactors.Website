<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ctdocp-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Catalog.ctdocp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#app_nav_employee').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_employee').addClass('selected');
                return false;
            });
        });
    </script>
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_details_text")%>
            <asp:Label ID="lblDocumentDetails" runat="server"></asp:Label>:
        </div>
        <br />
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvsearchDetails" GridLines="None" ShowFooter="true" ShowHeader="false"
                    CssClass="search_result" CellPadding="0" CellSpacing="0" runat="server" EmptyDataText="No Result found."
                    AutoGenerateColumns="False" AllowPaging="false" EmptyDataRowStyle-CssClass="empty_row"
                    OnRowCommand="gvsearchDetails_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <%#Eval("s_document_name")%>
                                        </td>
                                        <td>
                                            (<%# Eval("s_document_id_pk")%>)
                                        </td>
                                        <td class="tdright">
                                            <%#Eval("s_document_type_name_us_english")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Description
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="font_normal text_justify" colspan="3">
                                            <%#Eval("s_document_description")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDownloadDocument" runat="server" CommandName="Download" CommandArgument='<%#Eval("s_document_system_id_pk")%>'
                                                Text="<%$ LabelResourceExpression: app_download_document_button_text %>" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
