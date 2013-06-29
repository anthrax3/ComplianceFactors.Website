<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samdmmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.samdmmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
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

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        function resetall() {

            document.getElementById('<%=txtDate.ClientID %>').value = '';
            document.getElementById('<%=txtDigitalMediaName.ClientID %>').value = '';
            document.getElementById('<%=txtDigitalMediaId.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlFileType.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {

            $(".preview").click(function () {

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
                    'width': 740,
                    'height': 500,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-samdp-01.aspx',
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
    </script>--%>
    <script type="text/javascript">
        function ShowPreviewTheme() {
            var s_digital_media_source_file_name = $('input#<%=hds_digital_media_source_file_name.ClientID %>').val();
            var Type = $('input#<%=hdType.ClientID %>').val();
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
                'height': 500,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'Popup/p-samdp-01.aspx?fname=' + s_digital_media_source_file_name + '&ftype=' + Type,
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
        }
    </script>
    <br />
    <div class="content_area_long">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_advanced_media_files_search_results_text")%>:
        </div>
        <br />
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <asp:HiddenField ID="hds_digital_media_source_file_name" runat="server" />
        <asp:HiddenField ID="hdType" runat="server" />
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
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="s_digital_media_file_system_id_pk,s_digital_media_source_file_name,Type"
                PageSize="10" OnPageIndexChanging="gvsearchDetails_PageIndexChanging" OnRowCommand="gvsearchDetails_RowCommand"
                OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_digital_media_file_id_text %>" HeaderStyle-HorizontalAlign="Center" DataField="s_digital_media_file_id_pk"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_digital_media_file_name_text %>" HeaderStyle-HorizontalAlign="Center" DataField="s_digital_media_file_name"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderText="<%$ LabelResourceExpression: app_type_text %>" HeaderStyle-HorizontalAlign="Center" DataField="Type" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_date_time_uploaded_text %>" HeaderStyle-HorizontalAlign="Center" DataField="s_digital_media_file_date_time"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" CommandName="Remove" OnClientClick="return confirmStatus();"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
<%--                         <input type="button" id='<%# Eval("s_digital_media_file_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_preview_button_text %>" />'
                                class="preview cursor_hand" />--%>
                            <asp:Button ID="btnPreview" CommandName="Preview" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Preview" CssClass ="preview cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnFooterLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                       <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                       <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnFooterGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_advanced_digital_media_files_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_digital_media_file_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDigitalMediaId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDigitalMediaName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_type_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFileType" DataValueField="s_file_id_pk" DataTextField="s_file_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_date_text")%>:
                        </td>
                        <td>
                        <asp:CalendarExtender ID="ceDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDate">
                            </asp:CalendarExtender>  
                            <asp:TextBox ID="txtDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddNewMaterial" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_new_digital_media_file_button_text %>"
                                OnClick="btnAddNewMaterial_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" OnClientClick="return resetall();" CssClass="cursor_hand"
                                Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                                OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
