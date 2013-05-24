<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saeas-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.saeas_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" runat="server" Text="Save Approval WorkFlow" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Approval WorkFlow Information:
        </div>
        <br />
        <div>
            <table class="table_td_300 div_controls font_1">
                <tr>
                    <td class="align_right">
                        Approval ID:
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalID" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Approval WorkFlow:
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalWorkFlowName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Employee ID:
                    </td>
                    <td>
                        <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Employee Name:
                    </td>
                    <td>
                        <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Training ID / Training Type:
                    </td>
                    <td>
                        <asp:Label ID="lblTrainingId" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Training Name:
                    </td>
                    <td>
                        <asp:Label ID="lblTrainingName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Request Date:
                    </td>
                    <td>
                        <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        Request Type:
                    </td>
                    <td>
                        <asp:Label ID="lblRequestType" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Approval Workflow Details:
        </div>
        <br />
        <div>
            <asp:GridView ID="gvApprovalWorkflowDetails" AutoGenerateColumns="false" GridLines="None"
                ShowHeader="false" ShowFooter="false" runat="server" DataKeyNames="e_enroll_approval_system_id_pk,s_todo_system_id_pk,e_enroll_delivery_id_fk,e_enroll_user_id_fk"
                OnRowDataBound="gvApprovalWorkflowDetails_RowDataBound" OnRowCommand="gvApprovalWorkflowDetails_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table class=" table_td_300 div_controls font_1">
                                <tr>
                                    <td style="text-align: left;">
                                        <%# Eval("ApproverRole")%>:
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("ApproverName")%>
                                    </td>
                                    <td class="gridview_row_width_1">
                                        <%# Eval("ApprovalStatus")%>
                                    </td>
                                    <td class="align_right">
                                        <asp:Button ID="btnDeny" runat="server" Style="display: none;" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            CommandName="Deny" runat="server" Text="Deny" />
                                    </td>
                                    <td class="align_right">
                                        <asp:Button ID="btnApprove" runat="server" Style="display: none;" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            CommandName="Approve" runat="server" Text="Approve" />
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
            <br />
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnFooterSave" runat="server" Text="Save Approval WorkFlow" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnFooterReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnFooterCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
