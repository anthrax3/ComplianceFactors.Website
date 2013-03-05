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
             else if (deliveryType == 'ILT' || deliveryType =='VLT' || deliveryType == 'OLT-VLT-ILT') {
                 alert('Your request for enrollment is pending approval and the approver(s) have been notified.');
             }
         });
     });
    </script>
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <asp:HiddenField ID="hdDeliveryType" runat="server" />
    <div>
        <div class="div_header_700">
            Delivery Details:
        </div>
    </div>
    <div class="div_controls">
        <table>
            <tr>
                <td>
                    Delivery Type:
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
                    Delivery ID:
                </td>
                <td class="align_left" colspan="3">
                    <b>
                        <asp:Label ID="lblDeliveryId" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    Delivery Title:
                </td>
                <td colspan="3" class="align_left">
                    <b>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    Description:
                </td>
                <td class="align_left" colspan="3">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Abstract:
                </td>
                <td class="align_left" colspan="3">
                    <asp:Label ID="lblAbstract" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Approval Required:
                </td>
                <td colspan="2" class="align_left">
                    <b>
                        <asp:Label ID="lblApprovalRequired" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    Credit Hours:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCreditHours" runat="server"></asp:Label>
                </td>
                <td>
                    Credit Units:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCreditUnits" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Owner:
                </td>
                <td class="align_left" colspan="3">
                    <b>
                        <asp:Label ID="lblOwner" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    Coordinator:
                </td>
                <td class="align_left" colspan="4">
                    <b>
                        <asp:Label ID="lblCoordinator" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    Min Enroll:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblMinEnroll" runat="server"></asp:Label>
                </td>
                <td>
                    Max Enroll:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblMaxEnroll" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Currectly Enrolled:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCurrentlyEnrolled" runat="server"></asp:Label>
                </td>
                <td>
                    Waitlist:
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
                <input id="btnCancel" class="cursor_hand" type="submit" value="Cancel" onclick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()" />
            </div>
            <div class="right">
                <asp:Button ID="btnConfirmEnrollment" runat="server" style="display:none;" Text="Confirm Enrollment" OnClick="btnConfirmEnrollment_Click" />
                <asp:Button ID="btnGoToWaitList" runat="server" style="display:none;" Text="Go to Waitlist" OnClick="btnGoToWaitList_Click" />
                <asp:Button ID="btnSubmitRequest" runat="server" style="display:none;" Text="Submit Request" OnClick="btnSubmitRequest_Click" />
                <asp:Button ID="btnRequestApproval" runat="server" style="display:none;" Text="Request Approval!"  OnClick="btnRequestApproval_Click"/>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <br />
    <div class="div_header_700">
        Session(s):
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
        Attachments:
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
        Custom fields:
    </div>
    <br />
    <div class="div_controls">
        <table>
            <tr>
                <td>
                    Custom 01:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 02:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 03:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 04:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 05:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 06:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 07:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 08:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 09:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 10:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 11:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                </td>
                <td>
                    Custom 12:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Custom 13:
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
</asp:Content>
