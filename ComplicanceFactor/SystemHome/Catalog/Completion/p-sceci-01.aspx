<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sceci-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.p_sceci_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <div class="div_header_popup_1">
        <%=LocalResources.GetLabel("app_completion_information_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table cellspacing="5">
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_employee_name_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_employee_number_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblEmployeeNumber" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div class="div_header_popup_1">
        <%=LocalResources.GetLabel("app_session_text")%>:
    </div>
    <br />
    <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass=" gridview_popup_1 tablesorter"
        runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
        AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
        PagerSettings-Visible="false" DataKeyNames="t_transcript_id_pk" OnRowDataBound="gvsearchDetails_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="Session Name(ID)"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_4"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSeesion" runat="server" Text=' <%#Eval("c_session_title") + "(" + Eval("c_session_id_pk") + ")"%>  '></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" HeaderText="<%$ LabelResourceExpression: app_date_with_time_text %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_4"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblSessionStartDate" runat="server" Text='<%#"Starts:"+ Eval("c_session_start_date")  + " @ " + Eval("c_session_start_time")%>'></asp:Label><br />
                    <asp:Label ID="lblSessionEndDate" runat="server" Text='<%#"Ends:"+ Eval("c_session_end_date")  + " @ " + Eval("c_sessions_end_time")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_attendance_text %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlAttendanceStatus" Width="100px" DataTextField="s_status_name"
                        DataValueField="s_status_id_pk" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_passing_status_text %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlPassignStatus" Width="100px" DataTextField="s_status_name"
                        DataValueField="s_status_id_pk" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="<%$ LabelResourceExpression: app_grade_text %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlGrade" DataValueField="s_grading_scheme_system_value_id_pk"
                        DataTextField="s_grading_scheme_value_grade" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2 align_center" HeaderText="<%$ LabelResourceExpression: app_score_text %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtScore" Width="50px" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <div class="div_header_popup_1">
        <br />
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td colspan="3" width="940px">
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnSaveCompletion" runat="server" Text="<%$ LabelResourceExpression: app_save_completion_information_button_text %>"
                        OnClick="btnSaveCompletion_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
