<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcsp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.samcsp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
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
                            <asp:ListItem>All</asp:ListItem>
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
                          <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>InActive</asp:ListItem>
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
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
