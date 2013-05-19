<%@ Page Title="ComplicanceFactor&#0153 - Training Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="tchp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tchp_01" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_training').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_training').addClass('selected');
                return false;
            });

            $(function () {
                $('#<%=gvToDo.ClientID %>')
			    .tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
                $('#<%=gvMyDeliveries.ClientID %>')
			    .tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
            });
        });

    </script>
    <script type="text/javascript">
        function ShowandHidetodo(_this) {
            var div_SplashPages = document.getElementById('<%=this.div_MyToDo.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus";
                div_SplashPages.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus";
                div_SplashPages.style.display = 'none';
            }

            return false;
        }
        
    </script>
    <script type="text/javascript">

        function ShowandHideDeliveries(_this) {
            var div_Themes = document.getElementById('<%= this.div_MyDeliveries.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_Themes.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_Themes.style.display = 'none';
            }

            return false;

        }
    </script>
    <script type="text/javascript">
        function ShowandHideReport(_this) {
            var div_MyReports = document.getElementById('<%= this.div_MyReports.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_MyReports.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_MyReports.style.display = 'none';
            }

            return false;
        }
    </script>
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_training_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_dos_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="ShowandHidetodo(this); return false;" runat="server"
                ID="imgMyToDo" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyToDo" runat="server">
        <asp:GridView ID="gvToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvToDo_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_7"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_3"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employees_text %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                    DataField='name'>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" DataField ="Coursedate" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_4"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField="deliveryType" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_2"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                   
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="gridview_row_width_1"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="empty_row"></EmptyDataRowStyle>
            <PagerSettings Visible="False"></PagerSettings>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllToDos" runat="server" 
            Text="<%$ LabelResourceExpression: app_view_all_my_todos_button_text %>" 
            onclick="lnkViewAllToDos_Click"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_deliveries_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="ShowandHideDeliveries(this); return false;" runat="server"
                ID="imgMyDeliveries" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyDeliveries" runat="server">
        <asp:GridView ID="gvMyDeliveries" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="c_course_system_id_pk,c_delivery_system_id_pk,delivery_type"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" 
            PagerSettings-Visible="false" 
              OnRowCommand="gvMyDeliveries_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField='course_title_and_id' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_name_with_id_text %>" DataField='delivery_title_and_id' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_type_text %>" DataField='delivery_type' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageRosters" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                         CommandName="ManageRoster" runat="server" Text="<%$ LabelResourceExpression: app_manage_roster_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnPrint" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' 
                        CommandName="Print" runat="server" Text="<%$ LabelResourceExpression: app_print_sign_up_sheets_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllMyRosters" runat="server" 
            Text="<%$ LabelResourceExpression: app_view_all_my_rosters_button_text %>" 
            onclick="lnkViewAllMyRosters_Click"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="ShowandHideReport(this); return false;" runat="server"
                ID="imgMyReports" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyReports" runat="server">
        <asp:GridView ID="gvMyReports" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames=""
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_report_name_with_id_text %>" DataField='' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_type_text %>" DataField='' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_run_date_text %>" DataField='' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnViewLast" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_view_last_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnScheduleIt" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_schedule_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnGenerateIt" CommandArgument='' CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_generate_it_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllMyReports" runat="server" 
            Text="<%$ LabelResourceExpression: app_view_all_my_report_button_text %>" 
            onclick="lnkViewAllMyReports_Click"></asp:LinkButton></b>
        <div class="clear">
        </div>
    </div>
    <div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_training_home_text")%>
        <br />
        <br />
    </div>
      <rsweb:ReportViewer ID="rvMySignUpSheet" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
    </div>
</asp:Content>
