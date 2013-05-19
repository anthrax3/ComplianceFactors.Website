<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ccasharm-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.ccasharm_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
        function pageLoad() {


            $(function () {


                $('#<%=gvsearchDetails.ClientID %>').tablesorter({ headers: { 3: { sorter: false }, 7: { sorter: false}} });

            });
        }
    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtSearchHarmNumber.ClientID %>').value = '';
            document.getElementById('<%=txtSearchTitle.ClientID %>').value = '';
            document.getElementById('<%=txtSearchDate.ClientID %>').value = '';
            document.getElementById('<%=ddlSearchCategory.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlSearchStatus.ClientID %>').selectedIndex = '0';
            return false;
        }
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
        //if user keypress in Create New Case

        $(document).keypress(function (e) {
            $('#<%=txtTitle.ClientID%>').keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    document.getElementById('<%=btnCreate.ClientID %>').click();
                }
                event.stopPropagation();
            });
        });

        //if user keypress in MIRIS Advanced search section

        $(document).keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_ccasharm" runat="server"
        ValidationGroup="ccasharm" />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_search_date" runat="server"
        ValidationGroup="ccasharmdate" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" >
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_harm_results_text")%>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFirstHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnFirstHeader_Click" />
                        <asp:Button ID="btnPreviousHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnPreviousHeader_Click" />
                        <asp:Button ID="btnNextHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnNextHeader_Click" />
                        <asp:Button ID="btnLastHeader" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnLastHeader_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlPerPage_header" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPerPage_header_SelectedIndexChanged">
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
                        <asp:TextBox ID="txtPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblPage" runat="server" />
                        <asp:Button OnClick="btnGotoHeader_Click" CssClass="cursor_hand" ID="btnGotoHeader"
                            runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="clear">
        </div>
        <div>
            <div id="container">
                <div class="page_text" align="center">
                    <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                        runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" DataKeyNames="h_harm_id_pk" AutoGenerateColumns="False"
                        AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                        PageSize="5" OnPageIndexChanging="gvsearchDetails_PageIndexChanging" OnRowCommand="gvsearchDetails_RowCommand"
                        OnRowDataBound="gvsearchDetails_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="h_harm_number" HeaderText="<%$ LabelResourceExpression: app_harm_text%>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                                HeaderStyle-HorizontalAlign="Left" DataField="h_case_category_text" HeaderText="<%$ LabelResourceExpression: app_type_text %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                HeaderStyle-HorizontalAlign="Left" DataField="h_case_title" HeaderText="<%$ LabelResourceExpression: app_analysis_title_text %>" />
                            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_analysis_description_text %>">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        CommandName="View" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                HeaderStyle-HorizontalAlign="Left" DataField="h_creation_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                HeaderStyle-HorizontalAlign="Left" DataField="h_status_text" HeaderText="<%$ LabelResourceExpression: app_status_text %>" />
                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                                HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_related_data_text %>" />
                            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" CommandName="Edit" CssClass='cursor_hand' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                                    <asp:Button ID="btnCopy" CssClass='cursor_hand' runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        CommandName="Copy" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />
                                    <asp:Button ID="btnClose" CssClass='cursor_hand' OnClientClick="return confirmStatus();"
                                        runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        Text="<%$ LabelResourceExpression: app_approve_button_text %>" CommandName="Approve" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFirstFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            OnClick="btnFirstFooter_Click" />
                        <asp:Button ID="btnPreviousFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            OnClick="btnPreviousFooter_Click" />
                        <asp:Button ID="btnNextFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            OnClick="btnNextFooter_Click" />
                        <asp:Button ID="btnLastFooter" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            OnClick="btnLastFooter_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlPerPage_footer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPerPage_footer_SelectedIndexChanged">
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
                        <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtdownpage" runat="server" Text="1" CssClass="textbox_page_of_page"></asp:TextBox>
                        <asp:Label ID="lbldownPage" runat="server" />
                        <asp:Button OnClick="btnGotoFooter_Click" CssClass="cursor_hand" ID="btnGotoFooter"
                            runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_create_new_analysis_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        *<%=LocalResources.GetLabel("app_category_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategeory" DataValueField="h_category_id" DataTextField="h_category_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ValidationGroup="ccasharm"
                            ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_case_title_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="retitle" runat="server" ErrorMessage="<%$ TextResourceExpression: app_size_limit_error_wrong%>"
                            ControlToValidate="txtTitle" ValidationGroup="ccasharm" ValidationExpression=".{0,20}">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_analysis_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnCreate" CssClass="cursor_hand" ValidationGroup="ccasharm" runat="server"
                            Text="<%$ LabelResourceExpression: app_create_new_button_text %>" OnClick="btnCreate_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_harm_advanced_search_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_harm_number_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchHarmNumber" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_analysis_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchTitle" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revSearchDateofBirth" runat="server" ValidationGroup="ccasharmdate"
                            ControlToValidate="txtSearchDate" ErrorMessage="<%$ TextResourceExpression: app_date_error_wrong%>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_analysis_date_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchDate" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceSearchDate" Format="MM/dd/yyyy" TargetControlID="txtSearchDate"
                            runat="server">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_category_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSearchCategory" DataValueField="h_category_id" DataTextField="h_category_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSearchStatus" DataValueField="h_status_id" DataTextField="h_status_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                    <td>
                        <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClientClick="return resetall();" runat="server" OnClick="btnReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnGosearch" ValidationGroup="ccasharmdate" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                            OnClick="btnGosearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
