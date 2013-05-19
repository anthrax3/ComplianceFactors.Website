<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samuiltdp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.samuiltdp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

        function resetall() {
            document.getElementById('<%=txtUiId.ClientID %>').value = '';
            document.getElementById('<%=txtUiPages.ClientID %>').value = '';
            document.getElementById('<%=txtKeyWord.ClientID %>').value = '';
            document.getElementById('<%=ddlUiTypes.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLanguages.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=txtNativeLabel.ClientID %>').value = '';
            return false;
        }
    </script>
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
    <br />
        <div class="content_area_long">
            <div class="div_header_long">
            <%=LocalResources.GetLabel("app_ui_advanced_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_ui_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUiId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_page_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUiPages" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_keyword_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyWord" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_type_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUiTypes" CssClass="ddl_user_advanced_search" runat="server">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Label" Value="Label"></asp:ListItem>
                                <asp:ListItem Text="Text" Value="Text"></asp:ListItem>
                                <asp:ListItem Text="Dropdown" Value="Dropdown"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_languages_text")%>: 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLanguages" DataTextField="s_locale_description" DataValueField="s_locale_short_Name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_id_text")%>: :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNativeLabel" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                           <%-- <asp:Button ID="btnAddnewuser" CssClass="cursor_hand" runat="server" Text="Add New User" />--%>
                           &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" OnClientClick="return resetall();" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" 
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
