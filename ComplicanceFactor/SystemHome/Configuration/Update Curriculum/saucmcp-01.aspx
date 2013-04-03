<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saucmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Update_Curriculum.saucmcp_01" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Default_Cell_Style
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
        }
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
        .Inner_Cell_Style_left_350
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 350px;
            text-align: left;
        }
        .Inner_Cell_Style_left_600
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 600px;
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
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Curriculum Details:
        </div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="center" colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td class="Title_Cell_Style">
                    Curriculum Title (Curriculum ID)
                </td>
                <td class="Title_Cell_Style">
                    Revision: {Version}
                </td>
                <td>
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
            </tr>
            <tr>
                <td colspan="3" style="font-size: 12px; padding: 3px 7px 0 10px;">
                    {Curriculum Description Text}
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_300">
                    Cost: Free
                </td>
                <td class="Inner_Cell_Style_centered">
                    CEU: 2 hours
                </td>
                <td class="Inner_Cell_Style_right">
                    Owner: David Ealy / Coordinator: Davis Ealy
                </td>
            </tr>
        </table>
        <br />
        <br />
        <div class="div_header_long">
            paths(s) Details:
        </div>
        <br />
        <table>
            <tr>
                <td class="Inner_Cell_Style_left_350">
                    Certification Path #1: Academia Path
                </td>
                <td class="Inner_Cell_Style_left_600">
                    Section #1<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ New Hire Onboarding (CF-NEW-HIRE-ILT)<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Business Conduct (CF-BUS-CONDUCT-2012)
                    <br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Manager Guidlines (CF-MANAGER-2013)
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_350">
                    Certification Path #2: Simulation Path
                </td>
                <td class="Inner_Cell_Style_left_600">
                    Section #1<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ New Hire Onboarding (CF-NEW-HIRE-ILT)<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Business Conduct (CF-BUS-CONDUCT-2012)
                    <br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Manager Guidlines (CF-MANAGER-2013)
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_350">
                    Recertification Path #1: Academia Path
                </td>
                <td class="Inner_Cell_Style_left_600">
                    Section #1<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ New Hire Onboarding (CF-NEW-HIRE-ILT)<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Business Conduct (CF-BUS-CONDUCT-2012)
                    <br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Manager Guidlines (CF-MANAGER-2013)
                </td>
            </tr>
            <tr>
                <td class="Inner_Cell_Style_left_350">
                    Recertification Path #2: Simulation Path
                </td>
                <td class="Inner_Cell_Style_left_600">
                    Section #1<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ New Hire Onboarding (CF-NEW-HIRE-ILT)<br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Business Conduct (CF-BUS-CONDUCT-2012)
                    <br>
                    &nbsp;&nbsp;&nbsp;- ComplianceFactors™ Manager Guidlines (CF-MANAGER-2013)
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            Roaster:
        </div>
        <br />
        <asp:GridView ID="gvEmployees" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
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
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Last Name"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee First Name"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Number"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Current Status"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="% Completed"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table>
            <tr>
                <td style="width: 400px">
                </td>
                <td>
                    Select New Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlChangeStatus" runat="server">
                        <asp:ListItem>In Progress</asp:ListItem>
                        <asp:ListItem>Assigned</asp:ListItem>
                        <asp:ListItem>Acquired</asp:ListItem>
                        <asp:ListItem>Waived</asp:ListItem>
                        <asp:ListItem>Revoked</asp:ListItem>
                        <asp:ListItem>No Longer Required</asp:ListItem>
                        <asp:ListItem>Warining</asp:ListItem>
                        <asp:ListItem>Retrain</asp:ListItem>
                        <asp:ListItem>Expired/Overdue</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="Default_Cell_Style">
                    <asp:Button ID="btnAddUsers" runat="server" Text="Add Users" 
                        PostBackUrl="~/SystemHome/Configuration/Update Curriculum/saucmcp-01_SearchEmp.aspx" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
        </div>
        <table>
            <tr>
                <td align="center" colspan="3" width="1030px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" width="1030px">
                    <asp:Button ID="btn_UpdateCurriculum" runat="server" 
                        Text="Update Curriculum Status" 
                        PostBackUrl="~/SystemHome/Configuration/Update Curriculum/enter-notes-pin-01.aspx" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
        </div>
        <br />
        <br />
    </div>
</asp:Content>
