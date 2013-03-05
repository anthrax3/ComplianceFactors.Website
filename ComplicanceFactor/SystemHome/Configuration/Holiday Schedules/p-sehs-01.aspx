<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-sehs-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules.p_sehs_01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 300px;
        }
    </style>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/SystemHome/Catalog/GenerateFile/iframe.js" />
        </Scripts>
    </asp:ToolkitScriptManager>
    <div>
        <%--Heading--%>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_editholiday" runat="server"
            ValidationGroup="editholiday"></asp:ValidationSummary>
        <div class="div_header_700">
           <%=LocalResources.GetLabel("app_holiday_information_uk_english_text")%>:
        </div>
        <div>
            <br />
            <div class="default_font_size">
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td valign="top" class="align_right">
                            <asp:RequiredFieldValidator ID="rfvHolidayName" runat="server" ValidationGroup="editholiday"
                                ControlToValidate="txtHolidayName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            * <%=LocalResources.GetLabel("app_holiday_name_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtHolidayName" runat="server" CssClass="textbox_long_444"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="align_right">
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ValidationGroup="editholiday"
                                ControlToValidate="txtDate" ErrorMessage="<%$ TextResourceExpression: app_date_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            * <%=LocalResources.GetLabel("app_date_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:RegularExpressionValidator ID="regexDate" runat="server" ControlToValidate="txtDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="<%$ TextResourceExpression: app_date_error_wrong %>" Display="Dynamic" ValidationGroup="saantc">&nbsp;</asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox_width"></asp:TextBox>
                            <asp:CalendarExtender ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtDate" runat="server">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="align_right">
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="editholiday"
                                ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            * <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td class="align_left" colspan="4">
                            <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="80"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnSaveHoliday" runat="server" ValidationGroup="editholiday" Text="<%$ LabelResourceExpression: app_save_holiday_button_text %>"
                        OnClick="btnSaveHoliday_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                        Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

