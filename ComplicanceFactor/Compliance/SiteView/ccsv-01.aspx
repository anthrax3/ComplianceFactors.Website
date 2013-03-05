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
			.tablesorter({ headers: { 3: { sorter: false }, 7: { sorter: false}} });

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
                    'height': 150,
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
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            FieldNotes:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<< First"
                            OnClick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<< Previous"
                            OnClick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="Next >>"
                            OnClick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="Last >>|"
                            OnClick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
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
                        <asp:Label ID="lblHeaderPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvFieldNoteDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                    EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="5"
                    DataKeyNames="sv_fieldnote_id_pk,sv_fieldnote_created_by_fk" OnRowCommand="gvFieldNoteDetails_RowCommand"
                    OnRowEditing="gvFieldNoteDetails_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="FieldNote Id">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_fieldnote_id")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="Title">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_fieldnote_title") %></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_title" HeaderText="Title"/>--%>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_location" HeaderText="Location" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="attachmentCount" HeaderText="Attachment" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="Note Datails">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_fieldnote_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="View" />'
                                    class="viewFieldNotes cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_fieldnote_creation_date" HeaderText="Created" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="CreatedBy" HeaderText="Created By" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="Edit" CssClass="cursor_hand" />
                                <%--<asp:Button ID="btnSend" CommandName="Send" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="Send" CssClass="cursor_hand" />--%>
                                <input type="button" id='<%# Eval("sv_fieldnote_id_pk").ToString() + "," +  Eval("sv_fieldnote_created_by_fk").ToString() %>'
                                    value='<asp:Literal ID="Literal6" runat="server" Text="Send" />' class="SendFieldNotes cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="Archive" CommandName="Archive" CssClass="cursor_hand" />
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
            M-Inspections:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnInspectionHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<< First"
                            OnClick="btnInspectionHeaderFirst_Click" />
                        <asp:Button ID="btnInspectionHeaderPrevious" CssClass="cursor_hand" runat="server"
                            Text="<< Previous" OnClick="btnInspectionHeaderPrevious_Click" />
                        <asp:Button ID="btnInspectionHeaderNext" CssClass="cursor_hand" runat="server" Text="Next >>"
                            OnClick="btnInspectionHeaderNext_Click" />
                        <asp:Button ID="btnInspectionHeaderLast" CssClass="cursor_hand" runat="server" Text="Last >>|"
                            OnClick="btnInspectionHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblInspectionHeaderResultperPage" runat="server" Text="Result Per Page"></asp:Label>
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
                        <asp:Label ID="lblInspectionHeaderPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtInspectionHeaderPage" runat="server" CssClass="textbox_page_of_page"
                            Text="1"></asp:TextBox>
                        <asp:Label ID="lblInspectionHeaderPageof" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnInspectionGoTo" runat="server" Text="Go To"
                            OnClick="btnInspectionGoTo_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvInspectionDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                    EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="5"
                    DataKeyNames="sv_mi_templete_id_pk" OnPageIndexChanging="gvInspectionDetails_PageIndexChanging"
                    OnRowCommand="gvInspectionDetails_RowCommand" OnRowEditing="gvInspectionDetails_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="Spect#">
                            <ItemTemplate>
                                <div style="width: 150px;">
                                    <%# DataBinder.Eval(Container, "DataItem.sv_mi_templete_id")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" HeaderText="Title">
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
                            HeaderStyle-HorizontalAlign="Left" DataField="" HeaderText="Attachment" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="Spect Datails">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_mi_templete_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="View" />'
                                    class="viewInspection cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="sv_mi_templete_created_date" HeaderText="Created" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="u_first_name" HeaderText="Created By" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="Edit" CommandName="Edit" CssClass="cursor_hand" />
                                <input type="button" id='<%# Eval("sv_mi_templete_id_pk") %>' value='<asp:Literal ID="Literal7" runat="server" Text="Send" />'
                                    class="SendInspection cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="Archive" CommandName="Archive" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="align_left">
                            <asp:Button ID="btnAddInspection" runat="server" Text="Add Inspection" CssClass="cursor_hand"
                                OnClick="btnAddInspection_Click" />
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
            On-the-Job-Training:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnTrainingHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<< First"
                            OnClick="btnTrainingHeaderFirst_Click" />
                        <asp:Button ID="btnTraningHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<< Previous"
                            OnClick="btnTraningHeaderPrevious_Click" />
                        <asp:Button ID="btnTrainingHeaderNext" CssClass="cursor_hand" runat="server" Text="Next >>"
                            OnClick="btnTrainingHeaderNext_Click" />
                        <asp:Button ID="btnTrainingHeaderLast" CssClass="cursor_hand" runat="server" Text="Last >>|"
                            OnClick="btnTrainingHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblTrainingResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
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
                        <asp:Label ID="lblTraingPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtTrainingPage" runat="server" CssClass="textbox_page_of_page"
                            Text="1"></asp:TextBox>
                        <asp:Label ID="lblTrainingPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnTrainingGoTo" runat="server" Text="Go To" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text" align="center">
                <asp:GridView ID="gvJobTrainingDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                    EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="5">
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="OJTNumber" HeaderText="OJT Number" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="Title" HeaderText="Title" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="Attachment" HeaderText="Attachment" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="OJT Datails">
                            <ItemTemplate>
                                <asp:Button ID="btnViewCaseDescription" runat="server" Text="View" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="Created" HeaderText="Created" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="CreatedBy" HeaderText="Created By" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="" HeaderText="Action" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CommandName="Edit" runat="server" Text="Edit " CssClass="cursor_hand" />
                                <asp:Button ID="btnSend" runat="server" CommandName="Send" Text="Send" CssClass="cursor_hand" />
                                <asp:Button ID="btnArchive" OnClientClick="return confirmStatus();" runat="server"
                                    Text="Archive" CommandName="Archive" CssClass="cursor_hand" />
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
                        Title:
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
                        Category:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>OJT</asp:ListItem>
                            <asp:ListItem>Field Note</asp:ListItem>
                            <asp:ListItem>Inspection</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Case Status:
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
                        <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" runat="server" />
                    </td>
                    <td colspan="2" class="btncancel_td">
                        <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search!" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
