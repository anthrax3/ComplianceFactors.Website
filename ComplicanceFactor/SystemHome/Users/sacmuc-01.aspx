<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sacmuc-01.aspx.cs" Inherits="ComplicanceFactor.sacmuc_01" %>

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
    <div class="content_area_long">
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnConfirm_merge_user" runat="server" Text="<%$ LabelResourceExpression: app_confirm_merge_users_button_text %>"
                            OnClick="btnConfirm_merge_user_Click" />
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_user_1_merge_text")%>
        </div>
        <br />
        <br />
        <div class="page_text" align="center">
            <asp:GridView ID="gvUser1" CellPadding="0" CellSpacing="0" CssClass="gridview_long"
                runat="server" AutoGenerateColumns="False" DataKeyNames="u_username_enc,u_user_id_pk"
                OnRowDataBound="gvUser1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_last_name" HeaderText="<%$ LabelResourceExpression: app_last_name_text %>" />
                    <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_first_name" HeaderText="<%$ LabelResourceExpression: app_first_name_text %>" />
                    <asp:BoundField HeaderStyle-CssClass="gv_middle_name_header" ItemStyle-CssClass="gv_middle_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_middle_name" HeaderText="<%$ LabelResourceExpression: app_middle_name_text %>" />
                    <asp:TemplateField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_username_text %>">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" Text='<%#Eval("u_username_enc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_active_status_flag_text" HeaderText="<%$ LabelResourceExpression: app_status_text %>"
                        SortExpression="Status" />
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="user_type" HeaderText="<%$ LabelResourceExpression: app_type_text %>"
                        SortExpression="Type" />
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="user_domain_name" HeaderText="<%$ LabelResourceExpression: app_user_domain_text %>"
                        SortExpression="Domain" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_user_2_merge_text")%>
        </div>
        <br />
        <br />
        <div class="page_text" align="center">
            <asp:GridView ID="gvUser2" CellPadding="0" CellSpacing="0" CssClass="gridview_long"
                runat="server" AutoGenerateColumns="False" DataKeyNames="u_user_id_pk" OnRowDataBound="gvUser2_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_last_name" HeaderText="<%$ LabelResourceExpression: app_last_name_text %>" />
                    <asp:BoundField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_first_name" HeaderText="<%$ LabelResourceExpression: app_first_name_text %>" />
                    <asp:BoundField HeaderStyle-CssClass="gv_middle_name_header" ItemStyle-CssClass="gv_middle_name_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_middle_name" HeaderText="<%$ LabelResourceExpression: app_middle_name_text %>" />
                    <asp:TemplateField HeaderStyle-CssClass="gv_name_header" ItemStyle-CssClass="gv_name_item"
                        HeaderStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_username_text %>">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" Text='<%#Eval("u_username_enc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="u_active_status_flag_text" HeaderText="<%$ LabelResourceExpression: app_status_text %>"
                        SortExpression="Status" />
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="user_type" HeaderText="<%$ LabelResourceExpression: app_type_text %>"
                        SortExpression="Type" />
                    <asp:BoundField HeaderStyle-CssClass="gv_default_header" ItemStyle-CssClass="gv_default_item"
                        HeaderStyle-HorizontalAlign="Center" DataField="user_domain_name" HeaderText="<%$ LabelResourceExpression: app_domain_text %>"
                        SortExpression="Domain" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
       <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnConfirm_merge_user_footer" runat="server" Text="<%$ LabelResourceExpression: app_confirm_merge_users_button_text %>"
                            OnClick="btnConfirm_merge_user_footer_Click" />
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel_footer" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_footer_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
