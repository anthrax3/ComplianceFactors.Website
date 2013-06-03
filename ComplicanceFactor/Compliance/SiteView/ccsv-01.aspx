<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ccsv-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.ccsv_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_compliance').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_compliance').addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvInspectionDetails.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 6: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvFieldNoteDetails.ClientID %>')
			.tablesorter({ headers: { 6: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvJobTrainingDetails.ClientID %>')
			.tablesorter({ headers: { 6: { sorter: false}} });

        });
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //edit locale
            $(".viewInspection").click(function () {
                //Get the Id of the record to edit
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
                    'width': 920,
                    'height': 300,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/csvvin-01.aspx?mode=view' + "&id=" + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            //Send Inspection
            $(".SendInspection").click(function () {
                //Get the Id of the record to edit
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
                    'width': 740,
                    'height': 150,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/csvsq-01.aspx?mode=send' + "&id=" + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            //edit locale
            $(".viewonjobtraining").click(function () {
                //Get the Id of the record to edit
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
                    'width': 920,
                    'height': 300,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Ojt/Popup/csvvojt.aspx?mode=view' + "&id=" + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            //Send Inspection
            $(".SendFieldNotes").click(function () {
                //Get the Id of the record to edit
                var record_id = $(this).attr("id");
                var element = $(this).attr("id").split(",");
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
                    'width': 740,
                    'height': 300,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'FieldNotes/Popup/csvsfn-01.aspx?mode=send' + "&id=" + element[0] + "&CreatedBy=" + element[1],
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
    <script type="text/javascript">
        $(document).ready(function () {
            //edit locale
            $(".viewFieldNotes").click(function () {
                //Get the Id of the record to edit
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
                    'width': 920,
                    'height': 300,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'FieldNotes/Popup/csvvfn-01.aspx?mode=view' + "&id=" + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            //edit locale
            $(".editacknowledge").click(function () {
                //Get the Id of the record to edit
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
                    'width': 740,
                    'height': 300,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'FieldNotes/Popup/csvack-01.aspx?mode=acknowledge' + "&id=" + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            //Send Inspection
            $(".SendJobTraining").click(function () {
                //Get the Id of the record to edit
                var record_id = $(this).attr("id");
                var element = $(this).attr("id").split(",");
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
                    'width': 740,
                    'height': 400,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Ojt/Popup/csvsojt.aspx?mode=send' + "&id=" + element[0] + "&CreatedBy=" + element[1],
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
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_fieldnotes_text")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvFieldNoteDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" PageSize="5" DataKeyNames="sv_fieldnote_id_pk,sv_fieldnote_created_by_fk"
                    OnRowCommand="gvFieldNoteDetails_RowCommand"  
                    OnRowEditing="gvFieldNoteDetails_RowEditing" 
                    onrowdatabound="gvFieldNoteDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_fieldnote_id_text %>">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_fieldnote_id")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_title_text %>">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_fieldnote_title") %></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_location" HeaderText="<%$ LabelResourceExpression: app_location_text %>" />
                       <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="attachmentCount" HeaderText="<%$ LabelResourceExpression: app_attachment_text %>" />--%>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Acknowledgements">
                            <ItemTemplate>
                             <asp:Literal ID="ltlAcknowledge" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_is_acknowledge" HeaderText="Acknowledgement" />--%>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_creation_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="CreatedBy" HeaderText="<%$ LabelResourceExpression: app_created_by_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="width_180" ItemStyle-CssClass="width_180"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_fieldnote_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />'
                                    class="viewFieldNotes cursor_hand" />
                                <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                                <input type="button" id='<%# Eval("sv_fieldnote_id_pk").ToString() + "," +  Eval("sv_fieldnote_created_by_fk").ToString() %>'
                                    value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" />'
                                    class="SendFieldNotes cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_archive_button_text %>"
                                    CommandName="Archive" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_m_inspections")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnInspectionHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnInspectionHeaderFirst_Click" />
                        <asp:Button ID="btnInspectionHeaderPrevious" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_previous_button_text %>" OnClick="btnInspectionHeaderPrevious_Click" />
                        <asp:Button ID="btnInspectionHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnInspectionHeaderNext_Click" />
                        <asp:Button ID="btnInspectionHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnInspectionHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblInspectionHeaderResultperPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlInspectionHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlInspectionHeaderResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblInspectionHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtInspectionHeaderPage" runat="server" CssClass="textbox_page_of_page"
                            Text="1"></asp:TextBox>
                        <asp:Label ID="lblInspectionHeaderPageof" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnInspectionGoTo" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnInspectionGoTo_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvInspectionDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" PageSize="5" DataKeyNames="sv_mi_templete_id_pk"
                    OnPageIndexChanging="gvInspectionDetails_PageIndexChanging" OnRowCommand="gvInspectionDetails_RowCommand"
                    OnRowEditing="gvInspectionDetails_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_spect_#_text %>">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_mi_templete_id")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_title_text %>">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_mi_templete_title")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_mi_templete_id" HeaderText="Spect#" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_mi_templete_title" HeaderText="Title" />--%>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="" HeaderText="<%$ LabelResourceExpression: app_attachment_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_spect_details_text %>">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_mi_templete_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />'
                                    class="viewInspection cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_mi_templete_created_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_first_name" HeaderText="<%$ LabelResourceExpression: app_created_by_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CommandName="Edit"
                                    CssClass="cursor_hand" />
                                <input type="button" id='<%# Eval("sv_mi_templete_id_pk") %>' value='<asp:Literal ID="Literal7" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" />'
                                    class="SendInspection cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_archive_button_text %>"
                                    CommandName="Archive" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="align_left">
                            <asp:Button ID="btnAddInspection" runat="server" Text="<%$ LabelResourceExpression: app_add_inspection_button_text %>"
                                CssClass="cursor_hand" OnClick="btnAddInspection_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <br />
    <div class="clear">
    </div>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_on_the_job_training_text")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnTrainingHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnTrainingHeaderFirst_Click" />
                        <asp:Button ID="btnTraningHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnTraningHeaderPrevious_Click" />
                        <asp:Button ID="btnTrainingHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnTrainingHeaderNext_Click" />
                        <asp:Button ID="btnTrainingHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnTrainingHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblTrainingResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlTrainingResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTrainingResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblTraingPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtTrainingPage" runat="server" CssClass="textbox_page_of_page"
                            Text="1"></asp:TextBox>
                        <asp:Label ID="lblTrainingPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnTrainingGoTo" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text" align="center">
                <asp:GridView ID="gvJobTrainingDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" PageSize="5" DataKeyNames="sv_ojt_id_pk,sv_ojt_created_by_fk"
                    OnRowCommand="gvJobTrainingDetails_RowCommand" OnRowEditing="gvJobTrainingDetails_RowEditing">
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_ojt_number" HeaderText="<%$ LabelResourceExpression: app_OJT_Number_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_ojt_title" HeaderText="<%$ LabelResourceExpression: app_title_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_ojt_is_acknowledge" HeaderText="Acknowledgement" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="attachmentCount" HeaderText="<%$ LabelResourceExpression: app_attachment_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_ojt_creation_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="CreatedBy" HeaderText="<%$ LabelResourceExpression: app_created_by_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_ojt_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />'
                                    class="viewonjobtraining cursor_hand" />
                                <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                                <input type="button" id='<%# Eval("sv_ojt_id_pk").ToString() + "," +  Eval("sv_ojt_created_by_fk").ToString() %>'
                                    value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" />'
                                    class="SendJobTraining cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_archive_button_text %>"
                                    CommandName="Archive" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <br />
    <div class="clear">
    </div>
    <div class="content_area_long">
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_category_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>OJT</asp:ListItem>
                            <asp:ListItem>Field Note</asp:ListItem>
                            <asp:ListItem>Inspection</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_case_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseStatus" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Approved</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="btnsave_new_user_td">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            runat="server" />
                    </td>
                    <td colspan="2" class="btncancel_td">
                        <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
