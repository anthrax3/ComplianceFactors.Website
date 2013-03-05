<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ascp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Catalog.ascp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_manager').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_manager').addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtId.ClientID %>').value = '';
            document.getElementById('<%=txtTitle.ClientID %>').value = '';
            document.getElementById('<%=txtKeyword.ClientID %>').value = '';
            document.getElementById('<%=ddlType.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlDelivery.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLanguage.ClientID %>').selectedIndex = '0';
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
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div class="content_area_long">
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_catalog_advanced_search_text")%>
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_id_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_title_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_keyword_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyword" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_type_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" DataValueField="c_type_id" DataTextField="c_type_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDelivery" DataValueField="s_delivery_type_system_id_pk" DataTextField="s_delivery_type_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_language_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLanguage" CssClass="ddl_user_advanced_search" runat="server" DataTextField="s_locale_description" DataValueField="s_locale_id_pk">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                                OnClientClick="return resetall();" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                runat="server" OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
