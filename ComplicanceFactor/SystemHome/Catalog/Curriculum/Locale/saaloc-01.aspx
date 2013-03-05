<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saaloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.Locale.saaloc_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 650px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 290px;
        }
    </style>
    <div>
        <%--Heading--%>
        <div class="div_header_650">
            <asp:Label ID="lblLocaleHeading" runat="server"></asp:Label>
        </div>
        <div>
            <br />
            <asp:ValidationSummary class="validation_summary_error" ID="vssacataml" runat="server"
                ValidationGroup="saaloc" />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="saaloc"
                                ControlToValidate="txtTitle" ErrorMessage="Please enter the Curriculum title.">&nbsp;
                            </asp:RequiredFieldValidator>
                            * Curriculum Title:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="textbox_long_444"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Description:
                        </td>
                        <td>
                            <textarea id="txtDescriptoin" runat="server" rows="3" cols="53"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Abstract:
                        </td>
                        <td class="align_left">
                           <textarea id="txtAbstract" runat="server" rows="3" cols="53"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnSave" ValidationGroup="saaloc" runat="server" Text="Save Locale"
                        OnClick="btnSave_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                        Text="Cancel" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
