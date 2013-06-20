<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saeas-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.saeas_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>  <script type="text/javascript">

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
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" runat="server" Text="<%$ LabelResourceExpression: app_save_approval_workflow_button_text %>"/>
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" 
                            onclick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
             <%=LocalResources.GetLabel("app_approval_workflow_information_text")%>:
        </div>
        <br />
        <div>
            <table class="table_td_300 div_controls font_1">
                <tr>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_approval_id_text")%>: 
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalID" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_approval_workflow_text")%>:
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
                         <%=LocalResources.GetLabel("app_employee_id_text")%>: 
                    </td>
                    <td>
                        <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                         <%=LocalResources.GetLabel("app_employee_name_text")%>:
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
                        <%=LocalResources.GetLabel("app_training_id_and_training_type_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblTrainingId" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_training_name_text")%>: 
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
                       <%=LocalResources.GetLabel("app_request_date_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <%=LocalResources.GetLabel("app_request_type_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblRequestType" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
           <%=LocalResources.GetLabel("app_approval_workflow_details_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left font_1">
            <asp:GridView ID="gvApprovalWorkflowDetails" AutoGenerateColumns="false" GridLines="None"
                CssClass="gridview_width_9" ShowHeader="false" ShowFooter="false" runat="server"
                DataKeyNames="e_enroll_approval_system_id_pk,s_todo_system_id_pk,e_enroll_delivery_id_fk,e_enroll_user_id_fk"
                OnRowDataBound="gvApprovalWorkflowDetails_RowDataBound" OnRowCommand="gvApprovalWorkflowDetails_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--class=" table_td_300 div_controls font_1"--%>
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        <%# Eval("ApproverRole")%>:
                                    </td>
                                    <td style="width: 30%">
                                         <%# Eval("ApproverName")%>
                                    </td>
                                    <td>
                                        <%=LocalResources.GetLabel("app_status_text")%>:<%# Eval("ApprovalStatus")%></td>
                                    <td class="align_right">
                                        <asp:Button ID="btnDeny" runat="server" Style="display: none;" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            CommandName="Deny" Text="<%$ LabelResourceExpression: app_deny_button_text %>" />
                                    </td>
                                    <td width="20%" class="align_right">
                                        <asp:Button ID="btnApprove" runat="server" Style="display: none;" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            CommandName="Approve" Text="<%$ LabelResourceExpression: app_approve_button_text %>" />
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
                        <asp:Button ID="btnSaveApprovalWorkFlow" runat="server" Text="<%$ LabelResourceExpression: app_save_approval_workflow_button_text %>"
                            OnClick="btnSaveApprovalWorkFlow_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnFooterCancel" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" 
                            onclick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
