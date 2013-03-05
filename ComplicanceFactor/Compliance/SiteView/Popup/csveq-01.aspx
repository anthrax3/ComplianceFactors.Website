<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="csveq-01.aspx.cs"
    Inherits="ComplicanceFactor.Compliance.SiteView.Popup.csveq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        function DisableRequiredField(ddlId) {
            var ControlName = document.getElementById(ddlId.id);

            if (ControlName.value == 1) {                
                ValidatorEnable(document.getElementById('<%=rfvOption1.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption2.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption3.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption4.ClientID%>'), false);
            }
            if (ControlName.value == 2) {
                ValidatorEnable(document.getElementById('<%=rfvOption1.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption2.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption3.ClientID%>'), false);
                ValidatorEnable(document.getElementById('<%=rfvOption4.ClientID%>'), false);
            }


            if (ControlName.value == 3) {                 
                ValidatorEnable(document.getElementById('<%=rfvOption1.ClientID%>'), true);
                ValidatorEnable(document.getElementById('<%=rfvOption2.ClientID%>'), true);
                ValidatorEnable(document.getElementById('<%=rfvOption3.ClientID%>'), true);
                ValidatorEnable(document.getElementById('<%=rfvOption4.ClientID%>'), true);
            }
        } 
    </script>
    <div>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_csveq" runat="server"
            ValidationGroup="csveq"></asp:ValidationSummary>
        <div>
            <div class="div_header_700">
                Question:
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvQuestionType" InitialValue="0" runat="server"
                                ControlToValidate="ddlQuestionType" ErrorMessage="Please select question type"
                                ValidationGroup="csveq" Causesvalidation="True">&nbsp;
                            </asp:RequiredFieldValidator>
                            * Question Type:
                        </td>
                        <td class="align_left">
                            <asp:DropDownList ID="ddlQuestionType" onchange="DisableRequiredField(this);" CssClass="ddl_user_advanced_search"
                                runat="server">
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
                                ErrorMessage="Please Enter Question Order" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revQuestionOrder" runat="server" ControlToValidate="txtQuestionOrder"
                                ErrorMessage="Please Enter Only Numbers In Question Order" ValidationExpression="^\d+$"
                                ValidationGroup="csveq">&nbsp;
                            </asp:RegularExpressionValidator>
                            * Question Order:
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
                                ErrorMessage="Please enter question type" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            * Enter Question:
                        </td>
                        <td colspan="3">
                            <textarea id="txtQuestion" runat="server" class="textarea_long_3" rows="3" cols="200"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOption1" runat="server" ControlToValidate="txtOption1"
                                ErrorMessage="Please enter option 1" Enabled="false" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            Option 1:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtOption1" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOption2" runat="server" ControlToValidate="txtOption2"
                                ErrorMessage="Please enter option 2" Enabled="false" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            Option 2:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtOption2" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOption3" runat="server" ControlToValidate="txtOption3"
                                ErrorMessage="Please enter option 3" Enabled="false" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            Option 3:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtOption3" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOption4" runat="server" ControlToValidate="txtOption4"
                                ErrorMessage="Please enter option 4" Enabled="false" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            Option 4:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtOption4" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer"
                                ErrorMessage="Please enter answer" ValidationGroup="csveq">&nbsp;
                            </asp:RequiredFieldValidator>
                            * Answer:
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
                            <asp:Button ID="btnAddQuestion" CssClass="cursor_hand" runat="server" Text="Add Question"
                                OnClick="btnAddQuestion_Click" ValidationGroup="csveq" />
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
