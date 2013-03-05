<%@ Page Title="ComplicanceFactor&#0153 - Manager Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="mhp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.mhp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
        });

        $(function () {
            $('#<%=gvToDo.ClientID %>')
			.tablesorter({ headers: { 5: { sorter: false }, 6: { sorter: false}} });

        });

        function expandDetailsInToDo(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgToDo", "div_to_do") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInTeam(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgTeam", "div_team") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
        
    </script>
    <div class="content_area">
        <div>
            <%= LocalResources.GetText("app_welcome_content")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        My To Dos:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInToDo(this);return false;" runat="server"
                ID="imgToDo" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_to_do" runat="server">
        <asp:GridView ID="gvToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="None" GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvToDo_RowCommand" OnRowEditing="gvToDo_RowEditing" ShowFooter="true">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Course/Curriculum Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_7"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_3"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Employee" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                    DataField='name'>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Training Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Type" DataField='type' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="Deny" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <table>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnDenyAll" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                     CommandName="DenyAll" runat="server" Text="Deny All" />
                                </td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="Approve" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <table>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnApproveAll" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    CommandName="ApproveAll" runat="server" Text="Approve All" />
                                </td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="empty_row"></EmptyDataRowStyle>
            <PagerSettings Visible="False"></PagerSettings>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllToDo" runat="server" Text="View All My To Dos..."></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        My Team:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInTeam(this);return false;" runat="server"
                ID="imgTeam" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_team" runat="server">
        <asp:GridView ID="gvTeam" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="None" GridLines="None" DataKeyNames="e_curriculum_assign_curriculum_id_fk"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Employee Name (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Job Title" DataField='e_curriculum_assign_date_time' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewCourses" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="ViewCourses" runat="server" Text="View Courses" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewCurriculum" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="ViewCurriculum" runat="server" Text="View Curriculum" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewLearningHistory" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="ViewLearningHistory" runat="server" Text="View Learning History" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCurriculum" runat="server" Text="View All My Team..."></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        My Reports:
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_footer_content")%>
        <br />
        <br />
    </div>
    <br />
    <br />
</asp:Content>
