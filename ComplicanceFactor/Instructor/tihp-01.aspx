﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tihp-01.aspx.cs" Inherits="ComplicanceFactor.Instructor.tihp_01" %>
  <%@ Register Src="~/Compliance/MIRIS/Reports/mrp-01.ascx" TagName="mrp" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_instructor').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_instructor').addClass('selected');
                return false;
            });
        });

        $(function () {
            $('#<%=gvMyToDo.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $('#<%=gvMyRosters.ClientID %>')
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
        function expandDetailsInMyRoaster(_this) {
            var div_curriculum = document.getElementById('<%= this.div_MyRosters.ClientID %>');
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
            var div_Reports = document.getElementById('<%= this.div_MyReports.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_Reports.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_Reports.style.display = 'none';
            }

            return false;

        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_instructor_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_dos_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInMyToDo(this);return false;" runat="server"
                ID="imgMyToDo" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyToDo" runat="server">
        <asp:GridView ID="gvMyToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvMyToDo_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField="title" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employees_text %>" DataField="name" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_training_date_text %>" DataField="Coursedate" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField="deliveryType" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeny" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Deny" runat="server" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnTemp" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="" runat="server" Text="" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <b>
        <asp:LinkButton ID="lnkViewAllToDos" runat="server" CssClass="body_link"
        Text="<%$ LabelResourceExpression: app_view_all_my_todos_button_text %>" onclick="lnkViewAllToDos_Click"></asp:LinkButton></b>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_rosters_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsInMyRoaster(this);return false;" runat="server"
                ID="imgMyRosters" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyRosters" runat="server">
        <asp:GridView ID="gvMyRosters" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" GridLines="None" DataKeyNames="c_course_system_id_pk,c_delivery_system_id_pk,DeliveryType"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            OnRowCommand="gvMyRosters_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField="courseTitle" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_name_with_id_text %>" DataField="deliveryTitle" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_dates_text %>" DataField="Coursedate" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnManageRosters" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Completion" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_manage_roster_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnPrint" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Print" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_print_sign_up_sheets_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <b>
            <asp:LinkButton ID="lnkViewAllMyRosters" runat="server" CssClass="body_link"
            Text="<%$ LabelResourceExpression: app_view_all_my_rosters_button_text %>" onclick="lnkViewAllMyRosters_Click"></asp:LinkButton></b>
        <br />
    </div>
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
        <br />
        <b>
            <asp:LinkButton ID="lnkViewAllMyReports" runat="server" CssClass="body_link"
            Text="<%$ LabelResourceExpression: app_view_all_my_report_button_text %>" 
            onclick="lnkViewAllMyReports_Click"></asp:LinkButton></b>
        <br />
    </div>
    <div>
        <div class="div_header_long">
            &nbsp;
        </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_instructor_home_text")%>
        <br />
        <br />
    </div>
    </div>
    <rsweb:ReportViewer ID="rvMySignUpSheet" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
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
