<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samwmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.samwmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
        });

    </script>
    <div class="content_area_long">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            Advanced Wailists Search:
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        Employee ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Employee Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Course ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Course Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Coordinator:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery Start Date:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceDeliveryStartDate" Format="MM/dd/yyyy" TargetControlID="txtDeliveryStartDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtDeliveryStartDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Delivery End Date
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceDeliveryEndDate" Format="MM/dd/yyyy" TargetControlID="txtDeliveryEndDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtDeliveryEndDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                         &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" 
                            onclick="btnReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnGoSearch" runat="server" Text="Go Search!" OnClick="btnGoSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
