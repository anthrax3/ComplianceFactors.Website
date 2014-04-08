<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mrp-01.ascx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.mrp_01" %>
<script type="text/javascript">

    function lastview(url) {

        var h = '';
        var width = 1000;
        var height = 600;

        h = url;


        $.fancybox({
            'type': 'iframe',
            'titlePosition': 'over',
            'titleShow': true,
            'showCloseButton': true,
            'scrolling': 'yes',
            'autoScale': false,
            'autoDimensions': false,
            'helpers': { overlay: { closeClick: false} },
            'width': width,
            'height': height,
            'margin': 0,
            'padding': 0,
            'overlayColor': '#000',
            'overlayOpacity': 0.7,
            'hideOnOverlayClick': false,
            'href': h,
            'onComplete': function () {
                $.fancybox.showActivity();

                $('#fancybox-frame').load(function () {

                    $.fancybox.hideActivity();
                    $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                    var heightPane = $(this).contents().find('#content').height() + 100;
                    $(this).contents().find('#fancybox-frame').css({
                        'height': heightPane + 'px'

                    })
                });

            }

        });
    }
    function generate(url) {         
        var h = url;
        var width = 1000;
        var height = 600;

        $.fancybox({
            'type': 'iframe',
            'titlePosition': 'over',
            'titleShow': true,
            'showCloseButton': true,
            'scrolling': 'yes',
            'autoScale': false,
            'autoDimensions': false,
            'helpers': { overlay: { closeClick: false} },
            'width': width,
            'height': height,
            'margin': 0,
            'padding': 0,
            'overlayColor': '#000',
            'overlayOpacity': 0.7,
            'hideOnOverlayClick': false,
            'href': h,
            'onComplete': function () {
                $.fancybox.showActivity();

                $('#fancybox-frame').load(function () {

                    $.fancybox.hideActivity();
                    $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                    var heightPane = $(this).contents().find('#content').height() + 100;
                    $(this).contents().find('#fancybox-frame').css({
                        'height': heightPane + 'px'

                    })
                });

            }

        });
    }
    function schedule(url) {

        var h = url;
        var width = 1000;
        var height = 600;

        $.fancybox({
            'type': 'iframe',
            'titlePosition': 'over',
            'titleShow': true,
            'showCloseButton': true,
            'scrolling': 'yes',
            'autoScale': false,
            'autoDimensions': false,
            'helpers': { overlay: { closeClick: false} },
            'width': width,
            'height': height,
            'margin': 0,
            'padding': 0,
            'overlayColor': '#000',
            'overlayOpacity': 0.7,
            'hideOnOverlayClick': false,
            'href': h,
            'onComplete': function () {
                $.fancybox.showActivity();

                $('#fancybox-frame').load(function () {

                    $.fancybox.hideActivity();
                    $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                    var heightPane = $(this).contents().find('#content').height() + 100;
                    $(this).contents().find('#fancybox-frame').css({
                        'height': heightPane + 'px'

                    })
                });

            }

        });

    }

  
</script>
<asp:GridView ID="gvMyReports" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
    DataKeyNames="s_report_id_pk,s_report_users_system_id_pk,s_report_system_id_pk,s_report_name"
    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
    PagerSettings-Visible="false" PageSize="100" OnRowDataBound="gvMyReports_RowDataBound"
    OnRowCommand="gvMyReports_RowCommand">
    <Columns>
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
            DataField='s_report_system_id_pk' HeaderStyle-HorizontalAlign="Center" Visible="false"
            ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
            DataField='s_report_id_pk' HeaderStyle-HorizontalAlign="Center" Visible="false"
            ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
            DataField='s_report_users_system_id_pk' HeaderStyle-HorizontalAlign="Center"
            Visible="false" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
            HeaderText="<%$ LabelResourceExpression: app_report_name_with_id_text %>" DataField='s_report_name_id'
            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_3"
            HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField='s_report_type_id_fk'
            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
            HeaderText="Recurrence" DataField='s_report_users_when_to_run_text'
            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
            HeaderText="<%$ LabelResourceExpression: app_run_date_text %>"
            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Button ID="btnViewLast" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                    CommandName="viewlast" Style="display: none;" CssClass="lastview cursor_hand"
                    runat="server" Text="<%$ LabelResourceExpression: app_view_last_button_text %>" />
                <asp:Button ID="btnSchedule" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                    CommandName="schedule" runat="server" Text="<%$ LabelResourceExpression: app_schedule_it_button_text %>" />
                <asp:Button ID="btnGenerate" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                    CommandName="generate" runat="server" Text="<%$ LabelResourceExpression: app_generate_it_button_text %>" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
