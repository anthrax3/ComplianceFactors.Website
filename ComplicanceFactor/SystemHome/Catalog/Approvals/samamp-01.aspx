<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samamp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.samamp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
<script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script><script type="text/javascript">

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
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <div class="content_area_long">
        <div class=" div_header_long">
            <%=LocalResources.GetLabel("app_advanced_approvals_queue_search_text")%>:
        </div>
        <br />
        <table class="table_td_300 div_controls">
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_employee_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_employee_name_text")%>: 
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_status_text")%>: 
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" CssClass="width_75" runat="server" 
                    DataValueField="e_enroll_approval_status_system_id_pk" DataTextField="e_enroll_approval_status_name">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_approver_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtApproverId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_approver_name_text")%>: 
                </td>
                <td>
                    <asp:TextBox ID="txtApproverName" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_approval_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtApprovalId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
        </table>
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"  />
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnGoSearch" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"  OnClick="btnGoSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
