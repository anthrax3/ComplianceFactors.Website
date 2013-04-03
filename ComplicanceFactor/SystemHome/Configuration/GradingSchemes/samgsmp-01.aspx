<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samgsmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.GradingSchemes.samgsmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
            document.getElementById('<%=txtGradingSchemeId.ClientID %>').value = '';
            document.getElementById('<%=txtName.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex ='0';
            document.getElementById('<%=ddlType.ClientID %>').selectedIndex = '0';
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Advanced Delivery Types Search Results:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<<First" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="Next>>" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="Last>>|" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true">
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
            <asp:GridView ID="gvgradingSchemes" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." DataKeyNames="s_grading_scheme_system_id_pk" AutoGenerateColumns="False"
                AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                PageSize="10">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Grading Scheme ID" HeaderStyle-HorizontalAlign="Center" DataField="s_grading_scheme_id"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Grading Scheme Name" HeaderStyle-HorizontalAlign="Center" DataField="s_grading_scheme_english_us_name"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4_1" ItemStyle-CssClass="gridview_row_width_4_1"
                        HeaderText="Type" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Status" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CssClass="cursor_hand" runat="server" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCopy" CssClass="cursor_hand" runat="server" Text="Copy" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnArchive" CssClass="cursor_hand" runat="server" Text="Archive" />
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
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="|<<First" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="Next>>" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="Last>>|" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server">
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
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="div_header_long">
            Advanced Delivery Types Search:</div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Grading Scheme Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeId" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:DropDownList ID="ddlType" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>NUMERIC</asp:ListItem>
                            <asp:ListItem>ACADEMIA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnAddNewCurriculum" CssClass="cursor_hand" runat="server" 
                            Text="Create New Grading Scheme" onclick="btnAddNewCurriculum_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="center" class="btnreset_td">
                        <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick=" return resetall();" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search !" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
