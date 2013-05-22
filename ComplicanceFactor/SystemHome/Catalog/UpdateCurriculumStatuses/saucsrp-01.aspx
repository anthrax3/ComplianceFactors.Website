﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saucsrp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses.saucsrp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 6: { sorter: false }, 7: { sorter: false }, 8: { sorter: false}} });

        });
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnSearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_courses_curricula_search_text")%>:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            runat="server" OnClick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            runat="server" OnClick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            runat="server" OnClick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            runat="server" OnClick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
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
                            OnClick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" DataKeyNames="c_curriculum_system_id_pk" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_curriculum_id_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="c_curriculum_id_pk" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_curriculum_title_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="c_curriculum_title" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_curriculum_type_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_status_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="c_curriculum_status_name" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_owner_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="ownername" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_coordinator_text %>" HeaderStyle-HorizontalAlign="Center"
                        DataField="coordinatorname" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" CommandName="Select" CssClass="cursor_hand" runat="server"
                                Text="<%$ LabelResourceExpression: app_select_button_text %>" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
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
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                            runat="server" OnClick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                            runat="server" OnClick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                            runat="server" OnClick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                            runat="server" OnClick="btnFooterLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
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
                            OnClick="btnFooterGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_curricula_search_text")%>:
        </div>
        <br />
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_curriculum_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_curriculum_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_curriculum_type_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCurriculumType" DataTextField="c_curriculum_type_name" DataValueField="c_curriculum_type_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                            <%-- DataTextField="s_curriculum_type_name" DataValueField="s_curriculum_type_system_id_pk"--%>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="c_curriculum_status_name" DataValueField="c_curriculum_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnReset" runat="server" class="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSearch" class="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                            OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <%-- <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" class="cursor_hand" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSearch" class="cursor_hand" runat="server" Text="Go Search!" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>--%>
    </div>
</asp:Content>