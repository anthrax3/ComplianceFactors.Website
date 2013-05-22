﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sacmu-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.sacmu_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
    <div class="content_area_long">
        
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_user_1_selected_text")%>
            </div>
            <br />
            <br />
            <div class="page_text" align="center">
                <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long"
                   runat="server" AutoGenerateColumns="False" DataKeyNames="u_username_enc,u_user_id_pk"
                    OnRowDataBound="gvsearchDetails_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_last_name" HeaderText="<%$ LabelResourceExpression: app_last_name_header_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_first_name" HeaderText="<%$ LabelResourceExpression: app_first_name_header_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gv_middle_name_header" ItemStyle-CssClass="gv_middle_name_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_middle_name" HeaderText="<%$ LabelResourceExpression: app_middle_name_header_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_username_header_text %>">
                            <ItemTemplate>
                                <asp:Label ID="lblUsername" Text='<%#Eval("u_username_enc") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_active_status_flag_text" HeaderText="<%$ LabelResourceExpression: app_status_header_text %>"
                            SortExpression="Status" />
                        <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="user_type" HeaderText="<%$ LabelResourceExpression: app_type_text %>"
                            SortExpression="Type" />
                        <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                            HeaderStyle-HorizontalAlign="Left" DataField="user_domain_name" HeaderText="<%$ LabelResourceExpression: app_domain_text %>"
                            SortExpression="Domain" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
       <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_user_2_search_text")%>
        </div>
        <br />
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
                        <asp:DropDownList ID="ddlUserstatus" DataTextField="u_status_name" DataValueField="u_status_id_pk" CssClass="ddl_user_advanced_search" runat="server">
                        
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_user_types_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserTypes" DataTextField="u_user_type_name" DataValueField="u_user_type_id_pk" CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                         <%=LocalResources.GetLabel("app_user_domain_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserdomain"  DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk" CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="btncancel_td">
                        <asp:Button ID="btnCancel" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" 
                            onclick="btnCancel_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnReset" runat="server" OnClientClick="return resetall();" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnGosearch" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" OnClick="btnGosearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Panel> 
      
</asp:Content>