<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="mmtdp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.mmtdp_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />

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


            $(function () {
                $('#<%=gvToDo.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

            });

            $(".viewdetails").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 732,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Employee/Curricula/lvcurd-01.aspx?id=' + record_id,
                    'onComplete': function () {
                        $.fancybox.showActivity();
                        $('#fancybox-frame').load(function () {
                            $.fancybox.hideActivity();
                            $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                            var heightPane = $(this).contents().find('#content').height();
                            $(this).contents().find('#fancybox-frame').css({
                                'height': heightPane + 'px'

                            })
                        });

                    }

                });

            });
        });
    </script>


    
    <div class="content_area">
        <div>
           <%= LocalResources.GetText("app_welcome_content_mytodo_text")%>
            <br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_do_text")%>:
        <%--<div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="Print to PDF"/>
            <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel"/>
        </div>--%>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_to_do" runat="server">
        <asp:GridView ID="gvToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>" GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvToDo_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_curriculum_title_with_id_text %>" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_7"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_3"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employee_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                    DataField='name'>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField='type' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
        <br />
       
       <div style="float: right; margin-right: 16px;">
        <table>
            <tr>
                <td style="padding-right:20px;">
                    <asp:Button ID="btnDenyAll" runat="server" Text="<%$ LabelResourceExpression: app_deny_all_button_text %>" 
                        onclick="btnDenyAll_Click" />
                </td>
                <td>
                    <asp:Button ID="btnApproveAll" runat="server" Text="<%$ LabelResourceExpression: app_approve_all_button_text %>" 
                        onclick="btnApproveAll_Click" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    <br />
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
   <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_mytodo_text")%>
        <br />
        <br />
    </div>
    <br />
    <br />
    
</asp:Content>

