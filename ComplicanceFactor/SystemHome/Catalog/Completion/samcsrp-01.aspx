<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcsrp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.samcsrp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_long">
            Courses Deliveries Search:
        </div>
        <br />
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="|<<First" runat="server" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="Next>>" runat="server" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="Last>>|" runat="server" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblHeaderPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvCourseSearchResults" CellPadding="0" CellSpacing="0" CssClass="gridview_long tablesorter"
            runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Course ID" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Curriculum Title" HeaderStyle-HorizontalAlign="Center" DataField=""
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Delivery ID" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Delivery Title" HeaderStyle-HorizontalAlign="Center" DataField=""
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderText="Delivery Type" HeaderStyle-HorizontalAlign="Center" DataField=""
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Instructor(s)" HeaderStyle-HorizontalAlign="Center" DataField=""
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderText="Dates" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Facility" HeaderStyle-HorizontalAlign="Center" DataField="" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="|<<First" runat="server" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="Next>>" runat="server" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="Last>>|" runat="server" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To" />
                </td>
            </tr>
        </table>
        <br />
        <div class="div_header_long">
            Courses / Deliveries Search:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellspacing="10">
                <tr>
                    <td>
                        Course Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Course Title:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Version:
                    </td>
                    <td>
                        <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Delivery Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Delivery Title:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Delivery Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryType" CssClass="dropdownlist_width" runat="server">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>SOPT</asp:ListItem>
                            <asp:ListItem>VLT</asp:ListItem>
                            <asp:ListItem>Lunchbox</asp:ListItem>
                            <asp:ListItem>OJT</asp:ListItem>
                            <asp:ListItem>Survery01</asp:ListItem>
                            <asp:ListItem>Brownbag</asp:ListItem>
                            <asp:ListItem>OLT</asp:ListItem>
                            <asp:ListItem>Exam</asp:ListItem>
                            <asp:ListItem>SLM01</asp:ListItem>
                            <asp:ListItem>Checklist</asp:ListItem>
                            <asp:ListItem>ILT</asp:ListItem>
                            <asp:ListItem>Survey</asp:ListItem>
                            <asp:ListItem>Observation</asp:ListItem>
                            <asp:ListItem>SLM01</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date From:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Date To:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Instructor:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructor" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Location:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Facility:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFacility" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Room:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoom" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td class="text_align">
                        <asp:DropDownList ID="ddlStatus" CssClass="width_30" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Owner:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Coordinator:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <br />
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
