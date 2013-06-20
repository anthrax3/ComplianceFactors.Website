<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sasumsm-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.sasumsm_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 960px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 200px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        function resetsearchpopup() {

            document.getElementById('<%=txtSearchUserName.ClientID %>').value = '';
            document.getElementById('<%=txtSearchFirstName.ClientID %>').value = '';
            document.getElementById('<%=txtSearchLastName.ClientID %>').value = '';
            document.getElementById('<%=ddlSearchUserDomain.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlSearchUserTypes.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlSearchUserStatus.ClientID %>').selectedIndex = '0';



            return false;
        }
    </script>
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div>
            <div class="manage_user_header">
                <%=LocalResources.GetLabel("app_users_advanced_search_text")%>
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_last_name_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchLastName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_first_name_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchFirstName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_username_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchUserName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                            <asp:DropDownList ID="ddlSearchUserStatus" DataValueField="u_status_id_pk" DataTextField="u_status_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                                <%-- <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Reitred" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_user_types_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSearchUserTypes" DataTextField="u_user_type_name" DataValueField="u_user_type_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_user_domain_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSearchUserDomain" DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk"
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
                            <%-- <asp:Button ID="btnAddnewuser" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_new_user_button_text %>"
                            OnClick="btnAddnewuser_Click" />--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" OnClientClick="return resetsearchpopup();"
                                runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>