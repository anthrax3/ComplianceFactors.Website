<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="mescurr-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Enroll.mescurr_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 800px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtEmployeeName.ClientID %>').value = '';
            document.getElementById('<%=txtEmployeeNumber.ClientID %>').value = '';

            return false;
        }
        function toggleSelection() {

            $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', false);
            });


        }
        
    </script>
    <script type="text/javascript">
        function CheckRequired() {
            var isChecked = $('#<%= chkRequired.ClientID %>').attr('checked') ? true : false;
            if (isChecked) {
                var TargetDueDate = $('#<%= txtTargetDueDate.ClientID %>').val();
                if (TargetDueDate == "" || TargetDueDate == null) {
                    alert('Please select TargetDueDate')
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vsMesc" runat="server"
        ValidationGroup="mesc"></asp:ValidationSummary>
    <div id="content">
        <div class="div_header_800">
            <%=LocalResources.GetLabel("app_view_curriculum_details_text")%>:
        </div>
        <div class="table_150">
            <br />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_revision_text")%>:
                        <asp:Label ID="lblRevision" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <%=LocalResources.GetLabel("app_description_text")%>:<br />
                        <asp:Label ID="lblDescription" CssClass="font_normal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_approval_text")%>:
                        <asp:Label ID="lblApproval" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_manager_text")%>:
                        <asp:Label ID="lblManager" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_cost_text")%>:
                        <asp:Label ID="lblCost" runat="server"></asp:Label>
                    </td>
                    <td>
                        CEU:
                        <asp:Label ID="lblCEU" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                        <asp:Label ID="lblOwner" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_800 tablesorter"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>"
                DataKeyNames="u_user_id_fk" AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_employee_last_name_text %>" DataField='u_first_name'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_employee_first_name_text %>" DataField='u_first_name'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderText="<%$ LabelResourceExpression: app_employee_number_text %>" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="right">
            <asp:Button ID="btnRemoveSelected" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_remove_selected_button_text %>"
                OnClick="btnRemoveSelected_Click" />
        </div>
        <br />
        <br />
        <div class="clear">
        </div>
        <center>
            <div class="font_12_pixel">
                <br />
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_required_text")%>:&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkRequired" runat="server" />&nbsp;&nbsp;&nbsp;
                            <%=LocalResources.GetLabel("app_target_due_text")%>:&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTargetDueDate" Style="font-size: small;" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceTargetDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDueDate">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="regexEndDate" runat="server" ControlToValidate="txtTargetDueDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="Invalid target due date." Display="Dynamic" ValidationGroup="mesc">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirmAssignment" runat="server" Text="<%$ LabelResourceExpression: app_confirm_assignment_button_text %>"
                                OnClick="btnConfirmAssignment_Click" OnClientClick="return CheckRequired();" />
                            <%-- <asp:Button ID="btnConfirm" runat="server" Text="Confirm Assignment" OnClick="btnConfirmAssignMent_Click"  OnClientClick="return validateCheckBoxes();" />--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </div>
        </center>
        <br />
        <div>
            <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
                <div class="div_header_800">
                    <%=LocalResources.GetLabel("app_employee_search_text")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_employee_name_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_employee_number_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="align_left">
                                <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                    runat="server" OnClick="btnGosearch_Click" />
                            </td>
                            <td colspan="2" class="align_left">
                                <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                                    OnClientClick="return resetall();" runat="server" />
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                    runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
