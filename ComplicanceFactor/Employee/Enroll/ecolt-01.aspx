<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="ecolt-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Enroll.ecolt_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var deliveryType = $('#<%=hdDeliveryType.ClientID %>').val();
            $('#<%=btnRequestApproval.ClientID%>').click(function () {
                if (deliveryType == 'OLT') {
                    alert('This Enrollment Requires Approval.');
                }
                else if (deliveryType == 'ILT' || deliveryType == 'VLT' || deliveryType == 'OLT-VLT-ILT') {
                    alert('Your request for enrollment is pending approval and the approver(s) have been notified.');
                }
            });
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdDeliveryType" runat="server" />
<div id="content">
        <div>
            <div class="div_header_700">
                <%=LocalResources.GetLabel("app_delivery_details_text")%>:
            </div>
        </div>
        <div class="div_controls">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_type_text")%>:
                    </td>
                    <td class="align_left">
                        <b>
                            <asp:Label ID="lblDeliveryType" runat="server"></asp:Label></b>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_id_text")%>:
                    </td>
                    <td class="align_left" colspan="3">
                        <b>
                            <asp:Label ID="lblDeliveryId" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_title_text")%>:
                    </td>
                    <td colspan="3" class="align_left">
                        <b>
                            <asp:Label ID="lblTitle" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="3">
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_abstract_text")%>:
                    </td>
                    <td class="align_left" colspan="3">
                        <asp:Label ID="lblAbstract" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_approval_required_text")%>:
                    </td>
                    <td colspan="2" class="align_left">
                        <b>
                            <asp:Label ID="lblApprovalRequired" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_credit_hours_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCreditHours" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_credit_units_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCreditUnits" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td class="align_left" colspan="3">
                        <b>
                            <asp:Label ID="lblOwner" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                    </td>
                    <td class="align_left" colspan="4">
                        <b>
                            <asp:Label ID="lblCoordinator" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_min_enroll_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblMinEnroll" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_max_enroll_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblMaxEnroll" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_currently_enrolled_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCurrentlyEnrolled" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_waitlist_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblWaitList" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <div class="div_padding_10">
                <div class="left">
                    <input id="btnCancel" class="cursor_hand" type="submit" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />'
                        onclick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()" />
                </div>
                <div class="right">
                    <asp:Button ID="btnConfirmEnrollment" runat="server" Style="display: none;" Text="<%$ LabelResourceExpression: app_confirm_enrollment_button_text %>"
                        OnClick="btnConfirmEnrollment_Click" />
                    <asp:Button ID="btnGoToWaitList" runat="server" Style="display: none;" Text="<%$ LabelResourceExpression: app_go_to_waitlist_button_text %>"
                        OnClick="btnGoToWaitList_Click" />
                    <asp:Button ID="btnSubmitRequest" runat="server" Style="display: none;" Text="<%$ LabelResourceExpression: app_submit_request_button_text %>"
                        OnClick="btnSubmitRequest_Click" />
                    <asp:Button ID="btnRequestApproval" runat="server" Style="display: none;" Text="<%$ LabelResourceExpression: app_request_approval_button_text %>"
                        OnClick="btnRequestApproval_Click" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <br />
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_session_text")%>:
        </div>
        <br />
        <div class="div_padding_10">
            <b>
                <asp:Label ID="lblSessionNone" runat="server"></asp:Label></b>
        </div>
        <div class="div_control_normal">
            <div>
                <asp:GridView ID="gvSession" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_700"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_session_system_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSession_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="horizontal_line" colspan="4">
                                            <hr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="gridview_row_width_300">
                                            <asp:Label ID="lblSession1" runat="server"></asp:Label>
                                        </td>
                                        <td class="gridview_row_width_300">
                                            <asp:Label ID="lblSession2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <div class="div_padding_10">
            <b>
                <asp:Label ID="lblAttachmentNone" runat="server"></asp:Label></b>
        </div>
        <div class="div_control_normal">
            <asp:GridView ID="gvAddDeliveryAttachments" GridLines="None" CssClass="gridview_normal_700"
                CellPadding="2" CellSpacing="2" ShowHeader="false" ShowFooter="false" DataKeyNames="c_delivery_attachment_file_guid,c_delivery_attachment_file_name,c_delivery_attachment_id_pk"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvAddDeliveryAttachments_RowCommand"
                OnRowEditing="gvAddDeliveryAttachments_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_3" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_delivery_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnDownload" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Download" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>:
        </div>
        <br />
        <div class="div_controls">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_01_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_04_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_05_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_06_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_11_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_12_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_13_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCustom13" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
</asp:Content>
