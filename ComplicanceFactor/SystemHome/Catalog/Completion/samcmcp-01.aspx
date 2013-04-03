<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.samcmcp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Title_Cell_Style
        {
            font-size: 14px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
        }
        .Inner_Cell_Style_left_300
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: left;
        }
        .Inner_Cell_Style_centered
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: center;
        }
        .Inner_Cell_Style_right
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: right;
        }
        .ddl_width_75
        {
            width: 75px;
        }
        .ddl_width_35
        {
            width: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Course Details:
        </div>
        <table>
            <tr>
                <td colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td class="Title_Cell_Style">
                    Course Title (Course ID)
                </td>
                <td class="Title_Cell_Style">
                    Revision:{Version}
                </td>
                <td class="Title_Cell_Style">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    Description:
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-size: 12px; padding: 3px 7px 0 10px;">
                    {Curriculum Description Text}
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    Cost:Free
                </td>
                <td class="Inner_Cell_Style_centered">
                    CEU:2 hours
                </td>
                <td class="Inner_Cell_Style_right">
                    Owner: David Ealy / Coordinator: Davis Ealy
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            Delivery Details:
        </div>
        <table>
            <tr>
                <td colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td class="Title_Cell_Style">
                    Delivery Title (Delivery ID)
                </td>
                <td class="Title_Cell_Style">
                    Delivery Type: {OLT}
                </td>
                <td class="Title_Cell_Style">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    Description:
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-size: 12px; padding: 3px 7px 0 10px;">
                    {Curriculum Description Text}
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td class="Inner_Cell_Style_right">
                    Owner: David Ealy / Coordinator: Davis Ealy
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
        <div class="div_header_long">
            Session(s) Details:
        </div>
        <table>
            <tr>
                <td colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    Solution Overview Session #1<br />
                    (CF-OVERVIEW-OLT-2012-Q4)
                </td>
                <td>
                </td>
                <td class="Inner_Cell_Style_right">
                    (Self-paced - Anytime/Anywhere)
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
        <div class="div_header_long">
            Roaster:
        </div>
        <div>
            <asp:GridView ID="gvSelectedEmployees" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAllSelect" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRowSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee LastName"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        DataField="" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee FirstName"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        DataField="" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Number"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        DataField="" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Attendance"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlAttendanceStatus" CssClass="dropdownlist_width" runat="server">
                                <asp:ListItem>Attended</asp:ListItem>
                                <asp:ListItem>Did Not Attend/No Show</asp:ListItem>
                                <asp:ListItem>Partially Attended</asp:ListItem>
                                <asp:ListItem>Attended/Walk In</asp:ListItem>
                                <asp:ListItem>UnKnown</asp:ListItem>
                                <asp:ListItem>OLTPlayer</asp:ListItem>
                                <asp:ListItem>VLS System</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Passign Status "
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPassignStatus" CssClass="ddl_width_75" runat="server">
                                <asp:ListItem>Failed</asp:ListItem>
                                <asp:ListItem>Passed</asp:ListItem>
                                <asp:ListItem>Exempt</asp:ListItem>
                                <asp:ListItem>Not Scored</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Passign Status "
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlGrade" CssClass="ddl_width_35" runat="server">
                                <asp:ListItem>U</asp:ListItem>
                                <asp:ListItem>S</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Score"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" CssClass="textbox_50" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    <asp:Button ID="btn_AddUsers" runat="server" Text="Add Users" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <table>
            <tr>
                <td colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnSaveCompletion" runat="server" Text="Save Completion Information" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
    </div>
</asp:Content>
