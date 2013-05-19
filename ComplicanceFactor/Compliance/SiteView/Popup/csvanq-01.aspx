<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="csvanq-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Popup.csvanq_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 380px;
        }
    </style>
    <script type="text/javascript">
        function DisableRequiredField(ddlId) {
            var ControlName = document.getElementById(ddlId.id);

            if (ControlName.value == 1) {
                ValidatorEnable(document.getElementById("rfvOption1"), false);
                ValidatorEnable(document.getElementById("rfvOption2"), false);
                ValidatorEnable(document.getElementById("rfvOption3"), false);
                ValidatorEnable(document.getElementById("rfvOption4"), false);
            }
            if (ControlName.value == 2) {
                ValidatorEnable(document.getElementById("rfvOption1"), false);
                ValidatorEnable(document.getElementById("rfvOption2"), false);
                ValidatorEnable(document.getElementById("rfvOption3"), false);
                ValidatorEnable(document.getElementById("rfvOption4"), false);
            }
            if (ControlName.value == 3) {
                ValidatorEnable(document.getElementById("rfvOption1"), true);
                ValidatorEnable(document.getElementById("rfvOption2"), true);
                ValidatorEnable(document.getElementById("rfvOption3"), true);
                ValidatorEnable(document.getElementById("rfvOption4"), true);
            }
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_saanfin" runat="server"
            ValidationGroup="csvanq"></asp:ValidationSummary>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_question_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvQuestionType" InitialValue="0" runat="server"
                            ControlToValidate="ddlQuestionType" ErrorMessage="<%$ TextResourceExpression: app_select_question_type_error_empty %>"
                            ValidationGroup="csvanq" Causesvalidation="True">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_question_type_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlQuestionType" onchange="DisableRequiredField(this);" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Filling the blanks " Value="1"></asp:ListItem>
                            <asp:ListItem Text="True/False" Value="2"></asp:ListItem>
                            <asp:ListItem Text="MultiChoice" Value="3"></asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:RequiredFieldValidator ID="rfvQuestionOrder" runat="server" ControlToValidate="txtQuestionOrder"
                            ErrorMessage="<%$ TextResourceExpression: app_question_order_error_empty %>" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revQuestionOrder" runat="server" ControlToValidate="txtQuestionOrder"
                            ErrorMessage="<%$ TextResourceExpression: app_question_order_error_wrong %>" ValidationExpression="^\d+$"
                            ValidationGroup="csvanq">&nbsp;
                        </asp:RegularExpressionValidator>
                        * <%=LocalResources.GetLabel("app_question_order_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtQuestionOrder" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestion"
                            ErrorMessage="<%$ TextResourceExpression: app_question_type_error_empty %>" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_enter_question_text")%>:
                    </td>
                    <td colspan="3">
                        <textarea id="txtQuestion" runat="server" class="textarea_long_3" rows="3" cols="200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOption1" runat="server" ControlToValidate="txtOption1"
                            ErrorMessage="<%$ TextResourceExpression: app_option_1_error_empty %>" Enabled="false" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                         <%=LocalResources.GetLabel("app_option_text")%> 1:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtOption1" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOption2" runat="server" ControlToValidate="txtOption2"
                            ErrorMessage="<%$ TextResourceExpression: app_option_2_error_empty %>" Enabled="false" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                         <%=LocalResources.GetLabel("app_option_text")%> 2:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtOption2" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOption3" runat="server" ControlToValidate="txtOption3"
                            ErrorMessage="<%$ TextResourceExpression: app_option_3_error_empty %>" Enabled="false" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                         <%=LocalResources.GetLabel("app_option_text")%> 3:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtOption3" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOption4" runat="server" ControlToValidate="txtOption4"
                            ErrorMessage="<%$ TextResourceExpression: app_option_4_error_empty %>" Enabled="false" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                         <%=LocalResources.GetLabel("app_option_text")%> 4:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtOption4" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer"
                            ErrorMessage="<%$ TextResourceExpression: app_answer_error_empty %>" ValidationGroup="csvanq">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_answer_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtAnswer" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnAddQuestion" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_question_button_text %>"
                            OnClick="btnAddQuestion_Click" ValidationGroup="csvanq" />
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
