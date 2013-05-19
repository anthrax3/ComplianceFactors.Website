<%@ Page Title="ComplicanceFactor&#0153 - Compliance Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="cchp-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.cchp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>    
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
       

        $(function () {
            $('#<%=gvMyToDo.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $('#<%=gvMyReports.ClientID %>')
			.tablesorter({ headers: { 5: { sorter: false }, 6: { sorter: false}} });
            $('#<%=gvMyGiris.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false }, 8: { sorter: false}} });
            $('#<%=gvharmDetails.ClientID %>').tablesorter({ headers: { 3: { sorter: false }, 7: { sorter: false}} });

        });
    });

        function expandDetailsInMyToDo(_this) {
            var div_MyToDo = document.getElementById('<%=this.div_MyToDo.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus";
                div_MyToDo.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus";
                div_MyToDo.style.display = 'none';
            }
            return false;
        }

        function expandDetailsInMyHarm(_this) {
            var div_MyHarm = document.getElementById('<%= this.div_MyHarm.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_MyHarm.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_MyHarm.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInMyGiris(_this) {
            var div_MyGiris = document.getElementById('<%= this.div_MyGiris.ClientID %>');
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                div_MyGiris.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                div_MyGiris.style.display = 'none';
            }

            return false;

        }
        function expandDetailsInMyReport(_this) {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ToolkitScriptManager>
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_compliance_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_to_dos_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton runat="server" ID="imgMyToDo" OnClientClick="expandDetailsInMyToDo(this);return false;"
                ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyToDo" runat="server">
        <asp:GridView ID="gvMyToDo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" 
            EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" 
            GridLines="None" DataKeyNames="id,enroll_system_id_pk,todo_system_id_pk,e_enroll_user_id_fk,delivery_id"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" 
            PagerSettings-Visible="false" onrowcommand="gvMyToDo_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" DataField="title" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_employees_text %>" DataField="name" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_2"
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
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Approve" runat="server" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllToDos" runat="server" 
            Text="<%$ LabelResourceExpression: app_view_all_my_todos_button_text %>" 
            onclick="lnkViewAllToDos_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_harm_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton runat="server" ID="imgMyHarm" OnClientClick="expandDetailsInMyHarm(this);return false;"
                ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyHarm" runat="server">
        <asp:GridView ID="gvharmDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" 
            DataKeyNames="h_harm_id_pk" AutoGenerateColumns="False"
            AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            PageSize="5" OnRowCommand="gvharmDetails_RowCommand" 
            OnRowEditing="gvharmDetails_RowEditing" 
            onrowdatabound="gvharmDetails_RowDataBound">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderStyle-HorizontalAlign="Left" DataField="h_harm_number" HeaderText="<%$ LabelResourceExpression: app_harm_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderStyle-HorizontalAlign="Left" DataField="h_case_category_text" HeaderText="<%$ LabelResourceExpression: app_type_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderStyle-HorizontalAlign="Left" DataField="h_case_title" HeaderText="<%$ LabelResourceExpression: app_analysis_title_text %>" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_analysis_description_text %>">
                    <ItemTemplate>
                        <asp:Button ID="btnView" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="View" runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Left" DataField="h_creation_date" HeaderText="<%$ LabelResourceExpression: app_created_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Left" DataField="h_status_text" HeaderText="<%$ LabelResourceExpression: app_status_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ LabelResourceExpression: app_related_data_text %>" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_actions_text %>">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CommandName="Edit" CssClass='cursor_hand' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />
                        <asp:Button ID="btnCopy" CssClass='cursor_hand' runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Copy" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />
                        <asp:Button ID="btnClose" CssClass='cursor_hand' OnClientClick="return confirmStatus();"
                            runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            Text="<%$ LabelResourceExpression: app_approve_button_text %>" CommandName="Approve" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="lnkViewAllHARM" runat="server" 
            Text="<%$ LabelResourceExpression: app_view_all_my_harm_button_text %>" onclick="lnkViewAllHARM_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        My GIRIS:
        <div class="right div_padding_10">
            <asp:ImageButton runat="server" ID="imgMyGiris" OnClientClick="expandDetailsInMyGiris(this);return false;"
                ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_MyGiris" runat="server">
        <asp:GridView ID="gvMyGiris" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" 
            AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" DataKeyNames="c_case_id_pk,c_status_text,c_case_number"
            PagerSettings-Visible="false" PageSize="5" OnRowCommand="gvMyGiris_RowCommand"
            OnRowEditing="gvMyGiris_RowEditing" 
            onrowdatabound="gvMyGiris_RowDataBound">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderStyle-HorizontalAlign="Left" DataField="c_case_number" HeaderText="<%$ LabelResourceExpression: app_case_number_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderStyle-HorizontalAlign="Left" DataField="c_case_type_text" HeaderText="<%$ LabelResourceExpression: app_case_type_text %>" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderStyle-HorizontalAlign="Left" DataField="c_case_title" HeaderText="<%$ LabelResourceExpression: app_title_text %>" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ LabelResourceExpression: app_description_text %>">
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
                            CommandName="Copy" Text="<%$ LabelResourceExpression: app_copy_button_text %>" CssClass="cursor_hand" />
                        <asp:Button ID="btnClose" OnClientClick="return confirmStatus();" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Text="<%$ LabelResourceExpression: app_close_button_text %>"
                            CommandName="Close" CssClass="cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <b>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%$ LabelResourceExpression: app_view_all_my_giris_button_text %>" 
            onclick="LinkButton1_Click"></asp:LinkButton></b>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton runat="server" OnClientClick="expandDetailsInMyReport(this);return false;"  ID="imgMyReports" ImageUrl="~/Images/addplus-sm.gif" />
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
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" DataField='' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_compliance_home_text")%>
        <br />
        <br />
    </div>
    <asp:Button ID="btnpnlCompleteCase" runat="server" Style="display: none;" />
    <div class="font_normal">
        <asp:Panel ID="pnlCompleteCase" runat="server" CssClass="modalPopup_width_620" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
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
                            <%=LocalResources.GetLabel("app_select_approver_text")%>
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
    <%--<br />
<br />
<center ><b><%=LocalResources.GetLocaleResourceText("app_cchp_pagename")%> - <%=LocalResources.GetLocaleResourceText("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />--%>
    <%--    <div class="content_align ">
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="IRIS/ccasip-01.aspx">
                            <%=LocalResources.GetLabel("app_compliance_pod_mincident_report_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="right ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="MyToDo/cctdl-01.aspx">
                            <%=LocalResources.GetLabel("app_compliance_pod_mtodo_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear ">
        </div>
        <br />
        <br />
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="HARM/ccjhap-01.aspx">
                            <%=LocalResources.GetLabel("app_compliance_pod_mhazard_analysis_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="right ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="MyDashboard/ccmdd-01.aspx">
                            <%=LocalResources.GetLabel("app_compliance_pod_mdashboard_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear ">
        </div>
        <br />
        <br />
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="SiteView/ccsv-01.aspx">
                            <%=LocalResources.GetLabel("app_compliance_pod_site_view_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear ">
        </div>
    </div>
    <div class="clear ">
    </div>
    <br />
    <br />--%>
</asp:Content>
