<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sambjmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.sambjmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $(".manage").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'no',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../BackgroundJobs/Popup/samhrismp-01.aspx',
                    'onComplete': function () {
                        $('#fancybox-frame').load(function () {
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
    <div>
        <div class="div_header_long">
            Background Jobs:
        </div>
        <div class="page_text" align="center">
            <asp:GridView ID="gvBackgroundJobs" CellPadding="0" CellSpacing="0" runat="server"
                AutoGenerateColumns="false" GridLines="none" EmptyDataText="No Result found."
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" CssClass="gridview_long tablesorter"
                DataKeyNames="">
                <Columns>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_3"
                        ItemStyle-CssClass="gridview_row_width_3" DataField="BackgroundJobName" HeaderText="Background Job Name" />
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_3"
                        ItemStyle-CssClass="gridview_row_width_3" DataField="Frequency" HeaderText="Frequency" />
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_3"
                        ItemStyle-CssClass="gridview_row_width_3" DataField="Time" HeaderText="Time" />
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_2"
                        ItemStyle-CssClass="gridview_row_width_2" DataField="Status" HeaderText="Status " />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnManage" runat="server" CssClass="cursor_hand" CommandName="Manage"
                                Text="Manage" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />--%>
                            <input type="button" id="btnManage" class="manage" value="Manage" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnViewLogs" runat="server" CssClass="cursor_hand" CommandName="view"
                                Text="View Logs" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />--%>
                            <input type="button" id="btnManage" class="viewLogs" value="View Logs" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
