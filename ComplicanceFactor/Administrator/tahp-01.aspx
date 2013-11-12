<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tahp-01.aspx.cs" Inherits="ComplicanceFactor.Administrator.tahp_01" %>
    <%@ Register Src="~/Compliance/MIRIS/Reports/mrp-01.ascx" TagName="mrp" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_admin').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_admin').addClass('selected');
                return false;
            });
        });

        $(function () {
            $('#<%=gvMyToDo.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $('#<%=gvMyCourses.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
           

        });

        function expandDetailsInMyToDo(_this) {
            var div_course = document.getElementById('<%=this.div_MyToDo.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus";
                div_course.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus";
                div_course.style.display = 'none';
            }
            return false;
        }
        function expandDetailsInMyCourses(_this) {
            var div_curriculum = document.getElementById('<%= this.div_MyCourses.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_curriculum.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_curriculum.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInMyReports(_this) {
            var div_curriculum = document.getElementById('<%= this.div_MyReports.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_curriculum.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_curriculum.style.display = 'none';
            }

            return false;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <%= LocalResources.GetText("app_welcome_content_administrator_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_do_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInMyToDo(this);return false;" runat="server"
                ID="imgMyToDo" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyToDo" runat="server">
        <asp:GridView ID="gvMyToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvMyToDo_RowCommand" OnRowEditing="gvMyToDo_RowEditing">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField="title"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employees_text %>" DataField="name"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" DataField="Coursedate"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField="deliveryType"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnTemp" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="" runat="server" Text="" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllToDos" runat="server" CssClass="body_link" Text="<%$ LabelResourceExpression: app_view_all_my_todos_button_text %>"
                OnClick="lnkViewAllToDos_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_courses_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInMyCourses(this);return false;" runat="server"
                ID="imgMyCourses" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyCourses" runat="server">
        <asp:GridView ID="gvMyCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
            GridLines="None" DataKeyNames="system_id" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row"
            PagerSettings-Visible="false" OnRowCommand="gvMyCourses_RowCommand" OnRowEditing="gvMyCourses_RowEditing">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField="title_and_id"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_created_text %>" DataField="c_course_cert_date"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_types_text %>" DataField="c_delivery_type"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageCourse" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Manage" runat="server" Text="<%$ LabelResourceExpression: app_manage_courses_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllCourses" runat="server" CssClass="body_link" Text="<%$ LabelResourceExpression: app_view_all_my_course_button_text %>"
                OnClick="lnkViewAllCourses_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInMyReports(this);return false;" runat="server"
                ID="imgMyReports" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyReports" runat="server">
         <uc1:mrp ID="mrp1" runat="server" />
        <b>
            <asp:LinkButton ID="lnkViewAllMyReports" runat="server" CssClass="body_link" Text="<%$ LabelResourceExpression: app_view_all_my_report_button_text %>"
                OnClick="lnkViewAllMyReports_Click"></asp:LinkButton></b>
    </div>
    <div>
        <br />
        <div class="clear">
        </div>
        <div class="div_header_long">
            <br />
        </div>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_footer_administrator_home_text")%>
            <br />
            <br />
        </div>
    </div>
    <asp:Button ID="btnSplash" runat="server" Style="display: none;" />
    <asp:Panel ID="pnlSplashPage" runat="server" CssClass="modalPopup_width_900 modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlSplashPageHeading" runat="server" CssClass="drag">
            <div>
                <div class="div_header_900">
                    <span class="font_1" style="color:Black;">Splash Preview:</span>
                </div>
                <asp:ImageButton ID="ibtnCloseSplash" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                    z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" OnClick="ibtnCloseSplash_Click" />
            </div>
        </asp:Panel>
        <br />
        <div class="div_controls">
            <div class="div_padding_10" id="spalsh" style="height: 495px; overflow: auto" runat="server">
            </div>
        </div>
        <div class="div_header_900">
            &nbsp;
        </div>
        <br />
        <div>
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnDonotShow" ValidationGroup="JobTitle" runat="server" Text="Do Not Display Again"
                        OnClick="btnDonotShow_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCloseSplashPage" OnClick="btnCloseSplashPage_Click" CssClass="cursor_hand"
                        runat="server" Text="Close Splash Page" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <br />
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpSplashPage" runat="server" TargetControlID="btnSplash"
        PopupControlID="pnlSplashPage" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlSplashPageHeading">
    </asp:ModalPopupExtender>
</asp:Content>
