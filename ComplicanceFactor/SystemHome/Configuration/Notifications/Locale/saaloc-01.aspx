<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saaloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Notifications.Locale.saaloc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 800px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saaloc" runat="server"
        ValidationGroup="saaloc" />
    <asp:HiddenField ID="hdNotificationId" runat="server" />
    <%--Heading--%>
    <div id="content">
        <div class="div_header_800" id="divLocaleHeader" runat="server">
            <%=LocalResources.GetLabel("app_notification_info_text")%>:
        </div>
        <div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNotificationName" runat="server" ValidationGroup="saaloc"
                                ControlToValidate="txtNotificationName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_notification_name_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtNotificationName" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="saaloc"
                                ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td>
                            <textarea id="txtDescription" runat="server" rows="7" cols="80"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_800" runat="server">
                <%=LocalResources.GetLabel("app_email_msg_information_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmailContent" runat="server" ValidationGroup="saaloc"
                                ControlToValidate="txtEmailContent" ErrorMessage="<%$ TextResourceExpression: app_email_content_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_email_content_text")%>:
                        </td>
                        <td class="align_left">
                            <textarea id="txtEmailContent" style="height: 178px; overflow-x: hidden; overflow: auto"
                                runat="server" rows="14" cols="80"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_800" runat="server">
                <%=LocalResources.GetLabel("app_sms_text_information_text")%>:
            </div>
            <div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvSmsContent" runat="server" ValidationGroup="saaloc"
                                    ControlToValidate="txtSmsContent" ErrorMessage="<%$ TextResourceExpression: app_sms_content_error_empty %>">&nbsp;
                                </asp:RequiredFieldValidator>
                                *
                                <%=LocalResources.GetLabel("app_sms_text_content_text")%>:
                            </td>
                            <td class="align_left">
                                <textarea id="txtSmsContent" style="height: 100px; overflow-x: hidden; overflow: auto"
                                    runat="server" rows="14" cols="80"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div id="Div1" class="div_header_800" runat="server">
                    &nbsp;
                </div>
                <br />
                <div>
                    <table cellpadding="0" cellspacing="0" class="paging_800">
                        <tr>
                            <td class="align_left">
                                <asp:Button ID="btnSave" ValidationGroup="saaloc" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>"
                                    OnClick="btnSave_Click" />
                            </td>
                            <td class="align_center">
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                                    Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
