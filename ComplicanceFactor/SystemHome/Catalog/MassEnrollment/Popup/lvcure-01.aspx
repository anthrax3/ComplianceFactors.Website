<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="lvcure-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassEnrollment.Popup.lvcure_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        function RemoveLastTableCell() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }
       
    </script>
<div id="content">
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_curriculum_details_text")%>:
        </div>
        <div class="table_150 font_1">
            <br />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        *
                        <%=LocalResources.GetLabel("app_curriculum_id_text")%>:
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
                        <%=LocalResources.GetLabel("app_curriculum_title_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCurriculumTitle" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal" valign="top">
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
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
                        &nbsp;
                    </td>
                    <td class="lable_td_width_1">
                        &nbsp;
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
                                    <%=LocalResources.GetLabel("app_credit_hours_text")%>:
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
        <div>
            <asp:DataList ID="dlPath" runat="server" ShowHeader="false" ShowFooter="true" CellPadding="0"
                CssClass="grid_870" CellSpacing="0" OnItemDataBound="dlPath_ItemDataBound" DataKeyField="c_curricula_path_system_id_pk">
                <ItemTemplate>
                    <div class="div_header_700">
                        <%#Eval("c_curricula_path_name")%>
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <asp:Label ID="lblCompleteSection" runat="server"></asp:Label>
                    </div>
                    <asp:GridView ID="gvSection" ShowHeader="false" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                        runat="server" GridLines="None" OnRowDataBound="gvSection_RowDataBound" DataKeyNames="c_curricula_path_id_fk,c_curricula_path_section_id_pk"
                        AutoGenerateColumns="False" PagerSettings-Visible="false" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>">
                        <RowStyle CssClass="record"></RowStyle>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <hr />
                                    <%=LocalResources.GetLabel("app_section_text")%>:
                                    <%#Eval("c_curricula_path_section_seq_number")%>
                                    <asp:Label ID="lblComplete" runat="server"></asp:Label>
                                    <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_small_no_border"
                                        runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                                        GridLines="None" DataKeyNames="c_curricula_path_course_id_fk" AutoGenerateColumns="False"
                                        EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowDataBound="gvCourses_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField='title'
                                                HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderText="<%$ LabelResourceExpression: app_required_text %>" DataField='required'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderText="<%$ LabelResourceExpression: app_due_date_text %>" DataField='duedate'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderText="<%$ LabelResourceExpression: app_status_text %>" DataField='status'
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_Recurrance_text")%>:
        </div>
        <div class="div_controls font_1">
            <br />
            <asp:Label ID="lblRecurrence" runat="server"></asp:Label>
        </div>
        <br />
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_prerequisites_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_curriculum_text")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_equivalencies_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_curriculum_text")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_fulfillments_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_curriculum_text")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_700">
            &nbsp;
        </div>
    </div>
</asp:Content>
