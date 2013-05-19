<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samuiltdr-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.samuiltdr_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
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

            //edit locale
            $(".EditUi").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                if (element[1] == "Label") {
                    $.fancybox({
                        'type': 'iframe',
                        'titlePosition': 'over',
                        'titleShow': true,
                        'showCloseButton': true,
                        'scrolling': 'yes',
                        'autoScale': false,
                        'autoDimensions': false,
                        'helpers': { overlay: { closeClick: false} },
                        'width': 683,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../UI Texts and Labels/p-seul-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
                else if (element[1] == "Dropdown") {
                    $.fancybox({
                        'type': 'iframe',
                        'titlePosition': 'over',
                        'titleShow': true,
                        'showCloseButton': true,
                        'scrolling': 'yes',
                        'autoScale': false,
                        'autoDimensions': false,
                        'helpers': { overlay: { closeClick: false} },
                        'width': 683,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../UI Texts and Labels/p-seud-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
                else if (element[1] == "Text") {
                    $.fancybox({
                        'type': 'iframe',
                        'titlePosition': 'over',
                        'titleShow': true,
                        'showCloseButton': true,
                        'scrolling': 'yes',
                        'autoScale': false,
                        'autoDimensions': false,
                        'helpers': { overlay: { closeClick: false} },
                        'width': 783,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                         'href': '../UI Texts and Labels/p-seut-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
            });

        });
        function resetall() {
            document.getElementById('<%=txtUiId.ClientID %>').value = '';
            document.getElementById('<%=txtUiPages.ClientID %>').value = '';
            document.getElementById('<%=txtKeyWord.ClientID %>').value = '';
            document.getElementById('<%=ddlUiType.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLanguages.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=txtNativeLabel.ClientID %>').value = '';
            return false;
        }

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false}} });

        });
    </script>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_ui_search_results_text")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" OnClick="btnHeaderFirst_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>" />
                        <asp:Button ID="btnHeaderPrevious" OnClick="btnHeaderPrevious_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>" />
                        <asp:Button ID="btnHeaderNext" OnClick="btnHeaderNext_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>" />
                        <asp:Button ID="btnHeaderLast" OnClick="btnHeaderLast_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged"
                            runat="server" AutoPostBack="true">
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
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" OnClick="btnHeaderGoto_Click"
                            runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" DataKeyNames="system_id,uitype" EmptyDataText="No result found."
                AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="10">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_ui_id_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        DataField="uid" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="<%$ LabelResourceExpression: app_ui_page_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        DataField="uipage" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_native_label_text %>" ItemStyle-HorizontalAlign="Left" DataField="nativelabel" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_ui_type_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        DataField="uitype" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("system_id").ToString() + "," +  Eval("uitype").ToString()%>'
                                value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />' class="EditUi cursor_hand" />
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
                        <asp:Button ID="btnFooterFirst" OnClick="btnFooterFirst_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>" />
                        <asp:Button ID="btnFooterPrevious" OnClick="btnFooterPrevious_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>" />
                        <asp:Button ID="btnFooterNext" OnClick="btnFooterNext_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>" />
                        <asp:Button ID="btnFooterLast" OnClick="btnFooterLast_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged"
                            runat="server" AutoPostBack="true">
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
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" OnClick="btnFooterGoto_Click"
                            runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
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
                <%=LocalResources.GetLabel("app_ui_advanced_search_text")%>: 
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUiId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_page_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUiPages" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_keyword_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyWord" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_ui_type_text")%>: 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUiType" CssClass="ddl_user_advanced_search" runat="server">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Label" Value="Label"></asp:ListItem>
                                <asp:ListItem Text="Text" Value="Text"></asp:ListItem>
                                <asp:ListItem Text="Dropdown" Value="Dropdown"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_languages_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLanguages" DataTextField="s_locale_description" DataValueField="s_locale_short_Name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_native_label_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNativeLabel" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddNewUser" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_new_user_button_text %>" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" OnClientClick="return resetall();"
                                Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" OnClick="btnGosearch_Click" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
