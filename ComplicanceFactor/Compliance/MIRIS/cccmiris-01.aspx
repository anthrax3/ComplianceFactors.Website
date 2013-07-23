<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="cccmiris-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.cccmiris_01" %>

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

                $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 8: { sorter: false}} });

            });
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
        function resetall() {
            document.getElementById('<%=txtSearchCaseNumber.ClientID %>').value = '';
            document.getElementById('<%=txtSearchCaseTitle.ClientID %>').value = '';
            document.getElementById('<%=txtSearchCasedate.ClientID %>').value = '';
            document.getElementById('<%=ddlSearchCaseCategory.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlSearchCaseTypes.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlSearchCaseStatus.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <script type="text/javascript">
        //if user keypress in Create New Case

        $(document).keypress(function (e) {
            $('#<%=txtCaseTitle.ClientID%>').keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    document.getElementById('<%=btnCreateNewCase.ClientID %>').click();
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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_ccasir" runat="server"
        ValidationGroup="ccasir" />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_search_date" runat="server"
        ValidationGroup="ccasirdate" />
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_miris_search_results_text")%>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFirst" OnClick="btnFirst_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_first_button_text %>" />
                        <asp:Button ID="btnPrevious" OnClick="btnPrevious_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_previous_button_text %>" />
                        <asp:Button ID="btnNext" OnClick="btnNext_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_next_button_text %>" />
                        <asp:Button ID="btnLast" OnClick="btnLast_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_last_button_text %>" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlresultperpage_header" OnSelectedIndexChanged="ddlresultperpage_header_SelectedIndexChanged"
                            runat="server" AutoPostBack="true">
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
                        <asp:Button CssClass="cursor_hand" ID="btnGoto" OnClick="btnGoto_Click" runat="server"
                            Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div class="page_text" align="center">
                <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                    runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                    EmptyDataRowStyle-CssClass="empty_row" DataKeyNames="c_case_id_pk,c_status_text,c_case_number"
                    PagerSettings-Visible="false" PageSize="5" OnRowCommand="gvsearchDetails_RowCommand"
                    OnRowDataBound="gvsearchDetails_RowDataBound" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                    OnRowEditing="gvsearchDetails_RowEditing">
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_case_number" HeaderText="<%$ LabelResourceExpression: app_case_number_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_case_type_text" HeaderText="<%$ LabelResourceExpression: app_case_type_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_case_title" HeaderText="<%$ LabelResourceExpression: app_case_title_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_case_description_text %>">
                            <ItemTemplate>
                                <asp:Button ID="btnViewCaseDescription" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_creation_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_status_text" HeaderText="<%$ LabelResourceExpression: app_status_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_root_cause_analysic_info" HeaderText="<%$ LabelResourceExpression: app_root_cause_analysis_text %>" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                            HeaderStyle-HorizontalAlign="Left" DataField="c_corrective_action_info" HeaderText="<%$ LabelResourceExpression: app_corrective_action_text %>" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                                <asp:Button ID="btnCopy" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    CommandName="Copy" Text="<%$ LabelResourceExpression: app_copy_button_text %>"
                                    CssClass="cursor_hand" />
                                <asp:Button ID="btnClose" OnClientClick="return confirmStatus();" runat="server"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Text="<%$ LabelResourceExpression: app_close_button_text %>"
                                    CommandName="Close" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btndownFirst" OnClick="btndownFirst_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>" />
                        <asp:Button ID="btndownPrevious" OnClick="btndownPrevious_Click" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>" />
                        <asp:Button ID="btndownNext" OnClick="btndownNext_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_next_button_text %>" />
                        <asp:Button ID="btndownLast" OnClick="btndownLast_Click" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_last_button_text %>" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlresultperpage_footer" OnSelectedIndexChanged="ddlresultperpage_footer_SelectedIndexChanged"
                            runat="server" AutoPostBack="true">
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
                        <asp:Button CssClass="cursor_hand" ID="btndownGoto" OnClick="btndownGoto_Click" runat="server"
                            Text="<%$ LabelResourceExpression: app_go_to_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_creative_new_case_text")%>
    </div>
    <br />
    <asp:Panel ID="PnlCreatecase" DefaultButton="btnCreateNewCase" runat="server">
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_case_category_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseCategory" DataValueField="c_category_id" DataTextField="c_category_name"
                            AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCaseCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_case_types_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseTypes" DataValueField="c_type_id" DataTextField="c_type_name"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvcasetitle" runat="server" ValidationGroup="ccasir"
                            ControlToValidate="txtCaseTitle" ErrorMessage="<%$ TextResourceExpression: app_case_title_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="recasetitle" runat="server" ErrorMessage="<%$ TextResourceExpression: app_size_limit_error_wrong %>"
                            ControlToValidate="txtCaseTitle" ValidationGroup="ccasir" ValidationExpression=".{0,100}">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_case_title_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCaseTitle" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnCreateNewCase" ValidationGroup="ccasir" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_creative_new_case_button_text %>"
                            OnClick="btnCreateNewCase_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlSearch" DefaultButton="btnGosearch" runat="server">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_miris_advanced_search_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_case_number_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchCaseNumber" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_case_title_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchCaseTitle" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revSearchDate" runat="server" ValidationGroup="ccasirdate"
                            ControlToValidate="txtSearchCasedate" ErrorMessage="<%$ TextResourceExpression: app_case_date_error_empty %>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_case_date_text")%>
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceSearchCaseDate" Format="MM/dd/yyyy" runat="server" TargetControlID="txtSearchCasedate">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtSearchCasedate" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_case_category_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSearchCaseCategory" DataValueField="c_category_id" DataTextField="c_category_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_case_types_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSearchCaseTypes" DataValueField="c_type_id" DataTextField="c_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_case_status_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSearchCaseStatus" DataValueField="c_status_id" DataTextField="c_status_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="btnReset" OnClientClick="return resetall();" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnGosearch" ValidationGroup="ccasirdate" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                            OnClick="btnGosearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Button ID="btnpnlCompleteCase" runat="server" Style="display: none;" />
    <div class="font_normal">
        <asp:Panel ID="pnlCompleteCase" runat="server" CssClass="modalPopup_width_620 modal_popup_background" Style="display: none;
            padding-left: 0px;  padding-right: 0px;">
            <asp:Panel ID="pnlCompleteCasePageHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                         <%=LocalResources.GetLabel("app_select_approver_for_complete_case_text")%>
                    </div>
                    <div class="right">
                        <asp:ImageButton ID="imgCloseCompleteCase" CssClass="cursor_hand" Style="top: -15px;
                            right: -15px; z-index: 1103; position: absolute; width: 30px; height: 30px;"
                            runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </div>
            </asp:Panel>
            <br />
            <div class="div_controls">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_select_approver_text")%>: 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlComplianceApprover" DataValueField="u_user_id_pk" DataTextField="u_first_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <div class="div_padding_10">
                <div class="left">
                </div>
                <div class="right">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="cursor_hand"
                        Text="<%$ LabelResourceExpression: app_submit_button_text %>" />
                    <asp:Button ID="btnCancelCompleteCase" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:ModalPopupExtender ID="mpCompleteCase" runat="server" TargetControlID="btnpnlCompleteCase"
        PopupControlID="pnlCompleteCase" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlSplashPageHeading" OkControlID="imgCloseCompleteCase"
        CancelControlID="btnCancelCompleteCase">
    </asp:ModalPopupExtender>
    <br />
    <br />
</asp:Content>
