<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="tiddv-01.aspx.cs" Inherits="ComplicanceFactor.Instructor.tiddv_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function closeFancyboxAndRedirectToUrl() {
            var courseId = document.getElementById('<%=hdnCourseId.ClientID %>').value;
            var deliveryId = document.getElementById('<%=hdnDeliveryId.ClientID %>').value;
            var deliveryType = document.getElementById('<%=hdnDeliveryType.ClientID %>').value;
            parent.document.forms[0].submit(); parent.jQuery.fancybox.close();
            window.parent.location.href = '../SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=' + courseId + '&deliveryId=' + deliveryId + '&deliveryType=' + deliveryType;
        }
    </script>
    <style type="text/css">
        body
        {
            width: 1010px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <div id="content">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:HiddenField ID="hdnCourseId" runat="server" />
        <asp:HiddenField ID="hdnDeliveryId" runat="server" />
        <asp:HiddenField ID="hdnDeliveryType" runat="server" />
        <div class="div_header_1005">
            <%=LocalResources.GetLabel("app_delivery_details_text")%>:
        </div>
        <br />
        <div class="div_padding_40">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_type_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDeliveryType" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_id_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDeliveryId" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_delivery_title_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDeliverTitle" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="lable_td_width_1" colspan="2">
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_abstract_text")%>:
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="lable_td_width_1" colspan="2">
                        <asp:Label ID="lblAbstract" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_approval_required_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblApprovalRequired" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_credit_hours_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreditHours" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_credit_units_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreditUnits" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCoordinator" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_min_enroll_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblMinEnroll" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_max_enroll_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblMaxEnroll" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_currently_enrolled_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCurrentlyEnrolled" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_location_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_airport_code_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblAirportCode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnUpperManage" OnClientClick="closeFancyboxAndRedirectToUrl();"
                            runat="server" Text="<%$ LabelResourceExpression: app_manage_roster_button_text %>" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnUpperPrint" runat="server" Text="<%$ LabelResourceExpression: app_print_sign_up_sheets_text %>" OnClick="btnUpperPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_1005">
            Session(s):
        </div>
        <br />
        <asp:GridView ID="gvSessionDetails" ShowHeader="false" GridLines="None" AutoGenerateColumns="false"
            runat="server">
            <Columns>
                <asp:BoundField DataField="deliveryTitle" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_350" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="gridview_row_width_600">
                    <ItemTemplate>
                        <asp:Label ID="lblSessionDate" runat="server" Text='<%# Eval("SessionDate") %>'></asp:Label><br />
                        <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("c_location_name") %>'></asp:Label><br />
                        <asp:Label ID="lblRoom" runat="server" Text='<%# Eval("c_room_name") %>'></asp:Label><br />
                        <asp:Label ID="lblInstructor" runat="server" Text='<%# Eval("InstructorName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <div class="div_header_1005">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <div class="div_padding_90">
            <asp:GridView ID="gvAttachments" ShowHeader="false" GridLines="None" AutoGenerateColumns="false"
                runat="server" DataKeyNames="c_delivery_attachment_file_guid,c_delivery_attachment_file_name"
                OnRowCommand="gvAttachments_RowCommand">
                <Columns>
                    <asp:BoundField DataField="c_delivery_attachment_file_name" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-CssClass="gridview_row_width_750" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1">
                        <ItemTemplate>
                            <asp:Button ID="btnDownload" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"RowIndex") %>'
                                CommandName="Download" Text="Download" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_1005">
            <%=LocalResources.GetLabel("app_employees_enrolled_text")%>:
        </div>
        <br />
        <asp:GridView ID="gvEnrolledEmployees"  ShowHeader="false" GridLines="None"  AutoGenerateColumns="false"
            runat="server">
            <Columns>
                <asp:BoundField DataField="EnrollUser" ItemStyle-CssClass=" gridview_row_width_350" />
            </Columns>
        </asp:GridView>
        <br />
        <div class="div_header_1005">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>:
        </div>
        <br />
        <div class="div_control_normal">
            <table cellpadding="3" cellspacing="2">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_01_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField01" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField02" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField03" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_04_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField04" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_05_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField05" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_06_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField06" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField07" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField08" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField09" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField10" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_11_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField11" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_12_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField12" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_13_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustomField13" CssClass="textbox_long" runat="server" Text=" "></asp:Label>
                    </td>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_1005">
            &nbsp;
        </div>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    <asp:Button ID="btnFooterManage" OnClientClick="closeFancyboxAndRedirectToUrl();" runat="server" Text="<%$ LabelResourceExpression: app_manage_roster_button_text %>" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnFooterPrint" runat="server" Text="<%$ LabelResourceExpression: app_print_sign_up_sheets_text %>" 
                        onclick="btnFooterPrint_Click" />
                </td>
            </tr>
        </table>
    </div>
        <rsweb:ReportViewer ID="rvMySignUpSheet" runat="server" Style="display: none;" DocumentMapCollapsed="true"
            ShowDocumentMapButton="false">
        </rsweb:ReportViewer>
</asp:Content>
