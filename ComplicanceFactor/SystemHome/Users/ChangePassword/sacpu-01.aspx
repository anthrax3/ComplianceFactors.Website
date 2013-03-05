<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sacpu-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ChangePassword.sacpu_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 600px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 250px;
        }
    </style>
    <div>
        <div id="Message">
        </div>
        <div class="div_header_600">
            Reset Your Password:
        </div>
        <br />
        <asp:ValidationSummary ID="vsPassword" CssClass="validation_summary_error" ValidationGroup="Password"
            runat="server" />
        <div id="div_error" runat="server" style="display: none;" class="validation_summary_error">
            
        </div>
        <div id="div_success" runat="server" style="display: none;" class="msgarea_success">
            Your password is successfully reset.
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Current Password:
                    </td>
                    <td>
                        <input id="txtCurrentPassword" runat="server" type="text" class="textbox_250" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" ErrorMessage="Please enter the current password."
                            ValidationGroup="Password" ControlToValidate="txtCurrentPassword"> &nbsp;
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password:
                    </td>
                    <td>
                        <input id="txtNewPassWord" runat="server" type="text" class="textbox_250" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="Please enter the new password."
                            ValidationGroup="Password" ControlToValidate="txtNewPassWord">&nbsp;
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password:
                    </td>
                    <td>
                        <input id="txtConfirmPassword" runat="server" type="text" class="textbox_250" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Please enter the confirm password."
                            ValidationGroup="Password" ControlToValidate="txtNewPassWord">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password do not match."
                            ControlToCompare="txtNewPassword" ValidationGroup="Password" ControlToValidate="txtConfirmPassword">
                        &nbsp;</asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnSave" ValidationGroup="Password" runat="server" Text="Save New Password"
                    OnClick="btnSave_Click" />
            </div>
            <div class="right">
                <input id="btnCancel" class="cursor_hand" type="submit" value="Cancel" onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close()" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
