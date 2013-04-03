<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="qscr-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Catalog.qscr_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
            $(".assign").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
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
                    'width': 820,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Enroll/mese-01.aspx?id=' + element[0] + "&ctype=" + element[1] + "&da=" + element[2] + "&ca=" + element[3] + "&check=" + element[4],
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
            $(".enroll").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
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
                    'width': 820,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Enroll/mese-01.aspx?id=' + element[0] + "&type=" + element[1] + "&courseid=" + element[2] + "&waitlist=" + element[3] + "&approval=" + element[4] + "&ca=" + element[5]+"&check=" + element[6],
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
        function resetall() {
            document.getElementById('<%=txtId.ClientID %>').value = '';
            document.getElementById('<%=txtTitle.ClientID %>').value = '';
            document.getElementById('<%=txtKeyword.ClientID %>').value = '';
            document.getElementById('<%=ddlType.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlDelivery.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLanguage.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div class="content_area_long">
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_search_results_text")%>
            </div>
            <br />
            <br />
            <div class="page_text">
                <div class="button_div_long">
                    <div class="button_div_sub_long">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnFirstHeader" CssClass="cursor_hand" runat="server" Text="<%$  LabelResourceExpression: app_first_button_text %>"
                                        OnClick="btnFirstHeader_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPreviousHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                                        OnClick="btnPreviousHeader_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNextHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                                        OnClick="btnNextHeader_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnLastHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                                        OnClick="btnLastHeader_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="left">
                        <table>
                            <tr>
                                <td class="font_1">
                                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_result_per_page_text %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlResultPerPageHeader" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlResultPerPageHeader_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>Show All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="div_page_search">
                        <table>
                            <tr>
                                <td class="font_1">
                                    <asp:Label ID="lblPageOfPageHeader" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPageHeader" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                                </td>
                                <td class="font_1">
                                    <asp:Label ID="lblPageHeader" runat="server" />
                                </td>
                                <td>
                                    <asp:Button CssClass="cursor_hand" ID="btnGotoHeader" runat="server" Text="<%$ LabelResourceExpression: app_goto_button_text %>"
                                        OnClick="btnGotoHeader_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <br />
            <div>
                <div class="page_text">
                    <asp:GridView ID="gvsearchDetails" GridLines="None" ShowFooter="true" ShowHeader="false"
                        CssClass="search_result" CellPadding="0" CellSpacing="0" runat="server" EmptyDataText="<%$ LabelResourceExpression: app_No_result_found_text %>"
                        AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                        DataKeyNames="system_id,type,c_approval_req" PagerSettings-Visible="false" PageSize="5"
                        OnPageIndexChanging="gvsearchDetails_PageIndexChanging" OnRowCommand="gvsearchDetails_RowCommand"
                        OnRowDataBound="gvsearchDetails_RowDataBound" OnRowEditing="gvsearchDetails_RowEditing">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <tr>
                                                    <td class="horizontal_line" colspan="3">
                                                        <hr>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lnkCourseDetailId" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    CommandName="Detail" runat="server" Text='<%#Bind("title_and_id")%>'></asp:LinkButton>
                                                <%-- <asp:Label ID="lblCouseTitleID" runat="server" Text='<%#Bind("c_course_title_and_id")%>'></asp:Label>--%>
                                            </td>
                                            <td>
                                                <%=LocalResources.GetLabel("app_revision_text")%>
                                                <asp:Label ID="lblVersion" runat="server" Text='<%#Bind("version")%>'></asp:Label>
                                            </td>
                                            <td class="tdright">
                                                <%#Eval("c_delivery_type")%>
                                            </td>
                                        </tr>
                                        </td> </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="font_normal" colspan="3">
                                                <asp:Label ID="lblCouseDescription" runat="server" Text='<%#Bind("description")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="font_bold">
                                                <%=LocalResources.GetLabel("app_cost_text")%>
                                                Free
                                            </td>
                                            <td>
                                            </td>
                                            <td class="tdright">
                                                <asp:Label ID="lblAlreadyEnrollMessage" runat="server"></asp:Label>
                                                <asp:Button ID="btnEnroll"  CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    CommandName="Detail" Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_enroll_button_text %>" />
                                                <%--  <input type="button" id='<%# Eval("system_id") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="Enroll" />'
                                                    class="employeesearch cursor_hand" />--%>
                                                <%-- <asp:Button ID="btnAssign" CssClass="cursor_hand" CommandArgument='<%#Eval("system_id")%>'
                                                    CommandName="Assign" runat="server" Text="Assign" Style="display: none;" />--%>
                                                
                                                <asp:Literal ID="ltlAssign" runat="server"></asp:Literal>
                                                <asp:Literal ID="ltlEnrollOLT" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <tr>
                                                    <td class="horizontal_line" colspan="3">
                                                        <hr>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div class="page_text">
                <div class="button_div_long">
                    <div class="button_div_sub_long">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnFirstFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                                        OnClick="btnFirstFooter_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPreviousFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                                        OnClick="btnPreviousFooter_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNextFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                                        OnClick="btnNextFooter_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnLastFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                                        OnClick="btnLastFooter_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="left">
                        <table>
                            <tr>
                                <td class="font_1">
                                    <asp:Label ID="lblResultPerPageFooter" runat="server" Text="<%$ LabelResourceExpression: app_result_per_page_text %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlResultPerPageFooter" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlResultPerPageFooter_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>Show All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="div_page_search">
                        <table>
                            <tr>
                                <td class="font_1">
                                    <asp:Label ID="lblPageOfPageFooter" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPageFooter" runat="server" Text="1" CssClass="textbox_page_of_page"></asp:TextBox>
                                </td>
                                <td class="font_1">
                                    <asp:Label ID="lblPageFooter" runat="server" />
                                </td>
                                <td>
                                    <asp:Button CssClass="cursor_hand" ID="btnGotoFooter" runat="server" Text="<%$ LabelResourceExpression: app_goto_button_text %>"
                                        OnClick="btnGotoFooter_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <br />
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_catalog_advanced_search_text")%>
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_id_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_title_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_keyword_text")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyword" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_type_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" DataValueField="c_type_id" DataTextField="c_type_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDelivery" DataValueField="s_delivery_type_system_id_pk"
                                DataTextField="s_delivery_type_name" CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_language_text")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLanguage" CssClass="ddl_user_advanced_search" runat="server"
                                DataTextField="s_locale_description" DataValueField="s_locale_id_pk">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                                OnClientClick="return resetall();" runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                runat="server" OnClick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
