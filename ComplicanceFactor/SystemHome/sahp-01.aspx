<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sahp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.sahp_01"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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


            $(function () {
                $('#<%=gvSplashPages.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
                $('#<%=gvThemes.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
                $('#<%=gvMyReports.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });
            });
        });
    </script>
    <script type="text/javascript">
        function ShowandHideSplash(_this) {
            var div_SplashPages = document.getElementById('<%=this.div_SplashPages.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgCourse", "div_course");  //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus";
                //
                div_SplashPages.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus";
                //
                div_SplashPages.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;
        }
        
    </script>
    <script type="text/javascript">

        function ShowandHideTheme(_this) {
            var div_Themes = document.getElementById('<%= this.div_Themes.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgCurriculum", "div_curriculum") //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                //
                div_Themes.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                //
                div_Themes.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;

        }
    </script>
    <script type="text/javascript">
        function ShowandHideReport(_this) {
            var div_MyReports = document.getElementById('<%= this.div_MyReports.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            //var currowid = id.replace("imgLearningHistory", "div_LearningHistory") //GETTING THE ID OF SUMMARY ROW
            //var rowdetelemid = currowid;
            //var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                //
                div_MyReports.style.display = 'block';
                //rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                //
                div_MyReports.style.display = 'none';
                //rowdetelem.style.display = 'none';
            }

            return false;
        }
    </script>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_system_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_splash_page_text")%>:
        <div class="div_padding_10 right">
            <asp:ImageButton OnClientClick="ShowandHideSplash(this); return false;" runat="server"
                ID="imgSpalshPage" ImageUrl="~/Images/addplus-sm.gif" />
            <%--<asp:Button ID="Button1" runat="server" OnClientClick="sample();" Text="Button" />--%>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_SplashPages" runat="server">
        <asp:GridView ID="gvSplashPages" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="u_splash_system_id_pk"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvSplashPages_RowCommand" OnRowEditing="gvSplashPages_RowEditing">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_splash_page_name_with_id_text %>" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSplashName" ForeColor="Black" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Detail" runat="server" Text='<%#Bind("splashname")%>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Splash Page Name(ID)" DataField="splashname" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />--%>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_created_text %>" DataField="u_splash_created_date" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_domain_text %>" DataField="u_domain_name" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageSplashPage" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Edit" runat="server" Text="<%$ LabelResourceExpression: app_manage_splash_pages_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkManageSplashPage" Text="<%$ LabelResourceExpression: app_all_manage_splash_pages_button_text %>" runat="server"
                OnClick="lnkManageSplashPage_Click"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_themes_text")%>:
        <div class="div_padding_10 right">
            <asp:ImageButton runat="server" OnClientClick="ShowandHideTheme(this);return false;"
                ID="imgTheme" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_Themes" runat="server">
        <asp:GridView ID="gvThemes" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames=""
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_theme_name_with_id_text %>" DataField="ThemeName" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_created_text %>" DataField="Created" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_domains_text %>" DataField="Domain" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageTheme" runat="server" Text="<%$ LabelResourceExpression: app_manage_themes_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkManageThemes" Text="<%$ LabelResourceExpression: app_all_manage_themes_button_text %>" runat="server"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <div class="div_padding_10 right">
            <asp:ImageButton runat="server" OnClientClick="ShowandHideReport(this);return false;"
                ID="imgReport" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyReports" runat="server">
        <asp:GridView ID="gvMyReports" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="No Result Found" GridLines="None" DataKeyNames=""
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_report_name_with_id_text %>" DataField="ReportName" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField="Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_run_date_text %>" DataField="Created" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewLast" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_view_last_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnSchedule" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_schedule_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnGenerate" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_generate_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="btnViewAllReports" Text="<%$ LabelResourceExpression: app_view_all_my_report_button_text %>" runat="server"
                OnClick="btnViewAllReports_Click"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        <br />
    </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_system_home_text")%>
        <br />
        <br />
    </div>
</asp:Content>
