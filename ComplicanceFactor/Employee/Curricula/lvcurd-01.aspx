<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lvcurd-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Curricula.lvcurd_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_employee').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_employee').addClass('selected');
                return false;
            });
            $(".viewdetails").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 732,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Employee/Course/lvcd-01.aspx?id=' + record_id,
                    'onComplete': function () {
                        $.fancybox.showActivity();
                        $('#fancybox-frame').load(function () {
                            $.fancybox.hideActivity();
                            $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                            var heightPane = $(this).contents().find('#content').height();
                            $(this).contents().find('#fancybox-frame').css({
                                'height': heightPane + 'px'

                            })
                        });

                    }

                });

            });
        });

    </script>
    <script type="text/javascript">
        function lastEquivalenciesrow() {
            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }
       

    </script>
    <script type="text/javascript" language="javascript">
        function ConfrimArchive() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ToolkitScriptManager>
  <div id="content">
        <div class="content_area_long">
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_curriculum_information_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="text_font_normal">
                            *
                            <%=LocalResources.GetLabel("app_curriculum_id_text")%>
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCurriculumId" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="text_font_normal">
                            *
                            <%=LocalResources.GetLabel("app_curriculum_title_text")%>
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblCurriculumTitle" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" valign="top">
                            *
                            <%=LocalResources.GetLabel("app_description_text")%>
                        </td>
                        <td class="lable_td_width_1" colspan="6">
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal" valign="top">
                            <%=LocalResources.GetLabel("app_abstract_text")%>:
                        </td>
                        <td class="lable_td_width_1" colspan="6">
                            <asp:Label ID="lblAbstract" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_version_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblVersion" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_icon_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_owner_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblOwner" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblcoordinator" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_cost_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblCost" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="text_font_normal">
                                        <%=LocalResources.GetLabel("app_credit_hours_text")%>
                                    </td>
                                    <td class="lable_td_width_1">
                                        <asp:Label ID="lblCreditHours" CssClass="lable_td_width" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_credit_units_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCreditUnits" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_status_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:Label ID="lblStatus" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                                <tr>
                                    <td class="text_font_normal">
                                        <%=LocalResources.GetLabel("app_visible_text")%>:
                                    </td>
                                    <td class="lable_td_width_1">
                                        <asp:Label ID="lblVisible" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2" class="text_font_normal">
                            <%=LocalResources.GetLabel("app_approval_required_text")%>:
                            <asp:Label ID="lblChkApprovalRequired" Font-Bold="true" CssClass="lable_td_width"
                                runat="server"></asp:Label>
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblApprovalRequired" CssClass="lable_td_width" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <asp:DataList ID="dlPath" runat="server" ShowHeader="false" ShowFooter="true" CellPadding="0"
                CssClass="grid_870" CellSpacing="0" OnItemDataBound="dlPath_ItemDataBound" DataKeyField="c_curricula_path_system_id_pk">
                <ItemTemplate>
                    <div class="div_header_long">
                        <%#Eval("c_curricula_path_name")%><br />
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <asp:Label ID="lblCompleteSection" runat="server"></asp:Label><br />
                        <asp:Label ID="lblPathCompletionPercentage" runat="server" Text="Label"></asp:Label>
                        <%--Currently 0% Completed--%>
                    </div>
                    <asp:GridView ID="gvSection" ShowHeader="false" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                        runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                        GridLines="None" DataKeyNames="c_curricula_path_id_fk,c_curricula_path_section_id_pk"
                        AutoGenerateColumns="False" OnRowDataBound="gvSection_RowDataBound" EmptyDataRowStyle-CssClass="empty_row"
                        PagerSettings-Visible="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <hr />
                                    <%=LocalResources.GetLabel("app_section_text")%>:<%#Eval("c_curricula_path_section_seq_number")%>
                                    <asp:Label ID="lblComplete" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCompletedCoursePercentage" runat="server" Text="Label"></asp:Label>
                                    <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                                        runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                                        GridLines="None" DataKeyNames="c_curricula_path_course_id_fk" AutoGenerateColumns="False"
                                        EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowCommand="gvCourses_RowCommand"
                                        OnRowDataBound="gvCourses_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                                                HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField='title'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                                                HeaderText="<%$ LabelResourceExpression: app_required_text %>" DataField='required'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                                                HeaderText="<%$ LabelResourceExpression: app_due_date_text %>" DataField='duedate'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                                                HeaderText="<%$ LabelResourceExpression: app_status_text %>" DataField='status'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <input type="button" id='<%# Eval("c_curricula_path_course_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="<%$ LabelResourceExpression: app_view_details_button_text %>" />'
                                                        class="viewdetails cursor_hand" />
                                                    <%--  <asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_path_course_id_fk") %>'
                                                    CommandName="View" runat="server" Text="View Details" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDrop" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_path_course_id_fk") %>'
                                                        CommandName="Drop" Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_drop_button_text %>" />
                                                    <asp:Button ID="btnEnroll" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_path_course_id_fk") %>'
                                                        CommandName="Enroll" Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_enroll_button_text %>" />
                                                    <asp:Button ID="btnLaunch" runat="server" Text="<%$ LabelResourceExpression: app_launch_button_text %>"
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "scormURL")%>' CommandName="Launch"
                                                        Style="display: none;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_recertification_paths_text")%>:
            </div>
            <div class="div_controls_from_left">
                <asp:GridView ID="gvRecertPath" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                    CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                    ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <%#Eval("c_curricula_recert_path_name")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <%--   <asp:DataList ID="dlRecertPath" runat="server" ShowHeader="false" ShowFooter="true"
            CellPadding="0" CssClass="grid_870" CellSpacing="0" OnItemDataBound="dlRecertPath_ItemDataBound"
            DataKeyField="c_curricula_recert_path_system_id_pk">
            <ItemTemplate>
                <div class="div_header_long">
                    <%#Eval("c_curricula_recert_path_name")%>
                </div>
                <br />
                <div class="div_controls font_1">
                    <asp:Label ID="lblCompleteSection" runat="server"></asp:Label>
                </div>
                <asp:GridView ID="gvRecertSection" ShowHeader="false" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                    runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="c_curricula_recert_path_id_fk,c_curricula_recert_path_section_id_pk"
                    AutoGenerateColumns="False" OnRowDataBound="gvRecertSection_RowDataBound" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <hr />
                                section:
                                <%#Eval("c_curricula_recert_path_section_seq_number")%>
                                <asp:Label ID="lblComplete" runat="server"></asp:Label>
                                <asp:GridView ID="gvRecertCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                                    runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="c_curricula_recert_path_course_id_fk"
                                    AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                                    OnRowCommand="gvRecertCourses_RowCommand" OnRowDataBound="gvRecertCourses_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                                            HeaderText="Course Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                                            HeaderText="Required" DataField='required' HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                                            HeaderText="Due Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                                            HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    CommandName="View" runat="server" Text="View Details" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDrop" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_recert_path_course_id_fk") %>'
                                                    CommandName="Drop" Style="display: none;" runat="server" Text="Drop" />
                                                <asp:Button ID="btnEnroll" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_recert_path_course_id_fk") %>'
                                                    CommandName="Enroll" Style="display: none;" runat="server" Text="Enroll" />
                                                <asp:Button ID="btnLaunch" runat="server" Text="Launch" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "c_curricula_recert_path_course_id_fk")%>'
                                                    CommandName="Launch" Style="display: none;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:DataList>--%>
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_recurrance_text")%>:
            </div>
            <br />
            <div class="div_controls_from_left">
                <asp:Label ID="lblRecurrance" runat="server"></asp:Label>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_attachments_text")%>:
            </div>
            <div class="div_controls_from_left">
                <asp:GridView ID="gvCurriculumAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_curriculum_attachment_file_guid,c_curriculum_attachment_file_name,c_curriculum_attchments_system_id_pk"
                    runat="server" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                    AutoGenerateColumns="False" OnRowCommand="gvCurriculumAttachments_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("c_curriculum_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_prerequisites_text")%>:
            </div>
            <br />
            <div class="div_controls_from_left">
                <asp:Label ID="lblEmptyPrerequisites" runat="server"></asp:Label>
                <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                    CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                    ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_6">
                                    <tr>
                                        <td>
                                            <%#Eval("c_curriculum_text")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_equivalencies_text")%>:
            </div>
            <br />
            <div class="div_controls_from_left">
                <asp:Label ID="lblEmptyEquivalencies" runat="server"></asp:Label>
                <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                    CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                    ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_6">
                                    <tr>
                                        <td>
                                            <%#Eval("c_curriculum_text")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_fulfillments_text")%>:
            </div>
            <br />
            <div class="div_controls_from_left">
                <asp:Label ID="lblEmptyFulfillments" runat="server"></asp:Label>
                <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                    CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                    ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_6">
                                    <tr>
                                        <td>
                                            <%#Eval("c_curriculum_text")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_custom_fields_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_01_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_02_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_03_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_04_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_05_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_06_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_07_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_08_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_09_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_10_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_11_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                        </td>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_12_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class=" text_font_normal">
                            <%=LocalResources.GetLabel("app_custom_13_text")%>:
                        </td>
                        <td class="lable_td_width_1">
                            <asp:Label ID="lblCustom13" runat="server"></asp:Label>
                        </td>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_long">
                &nbsp;
            </div>
            <br />
        </div>
    </div>
</asp:Content>
