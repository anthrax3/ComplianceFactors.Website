<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tcmtdp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tcmtdp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_training').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_training').addClass('selected');
            return false;
        });

        $('#<%=gvToDo.ClientID %>')
	    .tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
    });

    </script>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_training_my_to_do_text")%><br />
        <br />
        <br />
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_dos_text")%>:
    </div>
    <div class="div_padding_10" id="div_MyToDo" runat="server">
    <asp:GridView ID="gvToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" AllowPaging="false" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvToDo_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_7"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_3"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employees_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                    DataField='name'>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" DataField="Coursedate" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField="deliveryType" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                   
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="empty_row"></EmptyDataRowStyle>
            <PagerSettings Visible="False"></PagerSettings>
        </asp:GridView>
    </div>
    <div class="clear">
    </div>
    <div>
      
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_training_my_to_do_text")%>
        <br />
        <br />
    </div>
    </div>
</asp:Content>
  