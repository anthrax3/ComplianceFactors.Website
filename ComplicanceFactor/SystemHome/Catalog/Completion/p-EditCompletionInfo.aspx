<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-EditCompletionInfo.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.p_EditCompletionInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ddl_width_35
        {
            width: 35px;
        }
        .ddl_width_50
        {
            width: 50px;
        }
        
        .ddl_width_75
        {
            width: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_940">
            Completion Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellspacing="5">
                <tr>
                    <td>
                        Employee Name:
                    </td>
                    <td class="align_left">
                        Employee1
                    </td>
                    <td>
                    </td>
                    <td>
                        Employee Number:
                    </td>
                    <td class="align_left">
                        00001
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="div_header_940">
            Session(s):
        </div>
        <br />
        <asp:GridView ID="gvEditCompletionStatus" CellPadding="0" CellSpacing="0" CssClass=" gridview_popup_1 tablesorter"
            runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Session Name(ID)"
                    ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Date/Times"
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
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Grade "
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlGrade" CssClass="ddl_width_35" runat="server">
                            <asp:ListItem>U</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_2 align_center" HeaderText="Score"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtScore" CssClass="ddl_width_50" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <div class="div_header_940">
            <br />
        </div>
        <br />
        <table>
            <tr>
                <td colspan="3" width="940px">
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnSaveCompletion" runat="server" Text="Save Completion Information" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
