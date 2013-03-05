<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="sascr-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.sascr_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active'); s

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
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
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtCurriculumId.ClientID %>').value = '';
            document.getElementById('<%=txtTitle.ClientID %>').value = '';
            document.getElementById('<%=txtVersion.ClientID %>').value = '';
            document.getElementById('<%=txtOwner.ClientID %>').value = '';
            document.getElementById('<%=txtCoordinator.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlType.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            Advanced Curricula Search:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" 
                            Text="|<<First" onclick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" 
                            Text="<<Previous" onclick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" 
                            Text="Next>>" onclick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" 
                            Text="Last>>|" onclick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" 
                            AutoPostBack="true" 
                            onselectedindexchanged="ddlHeaderResultPerPage_SelectedIndexChanged">
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
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" 
                            Text="Go To" onclick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." DataKeyNames="c_curriculum_system_id_pk"
                AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="10" OnPageIndexChanging="gvsearchDetails_PageIndexChanging"
                OnRowCommand="gvsearchDetails_RowCommand" 
                onrowediting="gvsearchDetails_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Curriculum ID" HeaderStyle-HorizontalAlign="Center" DataField="c_curriculum_id_pk"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Curriculum Title" HeaderStyle-HorizontalAlign="Center" DataField="c_curriculum_title"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Version" HeaderStyle-HorizontalAlign="Center" DataField="c_curriculum_version" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Active" HeaderStyle-HorizontalAlign="Center" DataField="c_curriculum_status_name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Owner" HeaderStyle-HorizontalAlign="Center" DataField="ownername" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Coordinator" HeaderStyle-HorizontalAlign="Center" DataField="coordinatorname" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CommandName="Edit" CssClass="cursor_hand" runat="server"
                                Text="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCopy" CommandName="Copy" CssClass="cursor_hand" runat="server"
                                Text="Copy" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnArchive" CommandName="Archive" CssClass="cursor_hand" runat="server"
                                Text="Archive" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
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
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" 
                            Text="|<<First" onclick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" 
                            Text="<<Previous" onclick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" 
                            Text="Next>>" onclick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" 
                            Text="Last>>|" onclick="btnFooterLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" 
                            AutoPostBack="true" 
                            onselectedindexchanged="ddlFooterResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" 
                            Text="Go To" onclick="btnFooterGoto_Click" />
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
                Advanced Curricula Search:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            Curriculum Id:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCurriculumId" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Title:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Version:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVersion" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" DataTextField="c_curriculum_status_name" DataValueField="c_curriculum_status_id_pk"
                             CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Owner:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Coordinator:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Type:
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlType" DataTextField="c_curriculum_type_name"  DataValueField="c_curriculum_type_system_id_pk" CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddNewCurriculum" CssClass="cursor_hand" runat="server" 
                                Text="Add New Curriculum" onclick="btnAddNewCurriculum_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" runat="server"  OnClientClick="return resetall();" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search !" 
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

