<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sasup-01.aspx.cs" Inherits="ComplicanceFactor.Administrator.sasup_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_admin').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_admin').addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtUsername.ClientID %>').value = '';
            document.getElementById('<%=txtFirstName.ClientID %>').value = '';
            document.getElementById('<%=txtLastName.ClientID %>').value = '';
            document.getElementById('<%=ddlUserdomain.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserTypes.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserstatus.ClientID %>').selectedIndex = '0';
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
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
       <div id="content">
            <div class="content_area_long">
                <asp:HiddenField ID="hdNav_selected" runat="server" />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_users_advanced_search_text")%>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_last_name_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_first_name_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_username_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_user_status_text")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserstatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                                    CssClass="ddl_user_advanced_search" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_user_types_text")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserTypes" DataTextField="u_user_type_name" DataValueField="u_user_type_id_pk"
                                    CssClass="ddl_user_advanced_search" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_user_domain_text")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserdomain" DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk"
                                    CssClass="ddl_user_advanced_search" runat="server">
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
                                <asp:Button ID="btnAddnewuser" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_new_user_button_text %>"
                                    OnClick="btnAddnewuser_Click" />
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
        </div>
    </asp:Panel>
</asp:Content>
