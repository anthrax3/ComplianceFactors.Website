<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samdimp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.samdimp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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
        });
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;
        }

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

        });
        function resetall() {
            document.getElementById('<%=txtDocumentId.ClientID %>').value = '';
            document.getElementById('<%=txtDocumentName.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlDocumentType.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_advanced_document_search_results_text")%>:
        </div>
        <br />
        <div id="divHeaderPaging" runat="server">
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>" runat="server"
                            OnClick="btnFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>" runat="server"
                            OnClick="btnPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>" runat="server"
                            OnClick="btnNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>" runat="server"
                            OnClick="btnLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblHeaderPageOf" runat="server" Text="of" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                UseAccessibleHeader="true" runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None"
                AutoGenerateColumns="False" PageSize="10" DataKeyNames="s_document_system_id_pk"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        DataField="s_document_id_pk" HeaderText="<%$ LabelResourceExpression: app_document_id_text %>" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        DataField="s_document_name" HeaderText="<%$ LabelResourceExpression: app_document_name_text %>" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        DataField="s_document_version" HeaderText="<%$ LabelResourceExpression: app_version_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        DataField="s_document_type_name_us_english" HeaderText="Document Type" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        DataField="s_status_name" HeaderText="<%$ LabelResourceExpression: app_status_text %>" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CssClass="cursor_hand"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCopy" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_copy_button_text %>" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CommandName="Copy" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnArchive" runat="server" CommandName="Archive" CssClass="cursor_hand"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' OnClientClick="return confirmStatus();"
                                Text="<%$ LabelResourceExpression: app_archive_button_text %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div runat="server" id="divFooterPaging">
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>" runat="server"
                            OnClick="btnFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>" runat="server"
                            OnClick="btnPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>" runat="server"
                            OnClick="btnNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>" runat="server"
                            OnClick="btnLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" Text="of" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                            OnClick="btnGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_advanced_documents_search_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_document_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_version_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server" DataTextField="s_status_name"
                            DataValueField="s_status_id_pk">
                        </asp:DropDownList>
                    </td>
                    <td class=" align_right">
                        <%=LocalResources.GetLabel("app_type_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDocumentType" CssClass="ddl_user_advanced_search" runat="server"
                            DataTextField="s_document_type_name" DataValueField="s_document_type_system_id_pk">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnCreateNew" runat="server" Text="<%$ LabelResourceExpression: app_create_new_document_type_text %>" CssClass="cursor_hand"
                        OnClick="btnCreateNew_Click" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" OnClientClick="return resetall();"
                        CssClass="cursor_hand align_right" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnGoSearch" CssClass="align_right cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                        OnClick="btnGosearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
