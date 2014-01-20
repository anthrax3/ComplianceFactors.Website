<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sascn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.CategorySearch.sascn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 150px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtCategoryName.ClientID %>').value = '';
            document.getElementById('<%=txtCategoryId.ClientID %>').value = '';

            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <div id="content">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_popup_1">
                <%=LocalResources.GetLabel("app_categories_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_category_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_category_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text%>"
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
                                OnClientClick="return resetall();" runat="server" />
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
