<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saeloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Course.Delivery.Locale.saeloc_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 650px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 440px;
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
                ValidationGroup="saeloc" />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="saeloc"
                                ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_delivery_title_error_empty%>">&nbsp;
                            </asp:RequiredFieldValidator>
                            * <%=LocalResources.GetLabel("app_delivery_title_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtTitle" runat="server"  CssClass="textbox_long_444"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td>
                            <textarea id="txtDescriptoin" runat="server" rows="3" cols="53"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <%=LocalResources.GetLabel("app_abstract_text")%>:
                        </td>
                        <td class="align_left">
                            <textarea id="txtAbstract" runat="server" rows="3" cols="53"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_650">
                <%=LocalResources.GetLabel("app_non_conformant_aicc_text")%>:
                <asp:Label ID="lblNonConformantHeading" runat="server"></asp:Label>
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_aicc_url_text")%>: 
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtAiccUrl" runat="server"  CssClass="textbox_long_444"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_650">
                <%=LocalResources.GetLabel("app_scorm_text")%>:
                <asp:Label ID="lblScormHeading" runat="server"></asp:Label>
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_scorm_url_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:TextBox ID="txtScormUrl" runat="server"  CssClass="textbox_long_444"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_padding_10">
                <div class="left">
                    <asp:Button ID="btnSave" ValidationGroup="saeloc" runat="server" Text="<%$ LabelResourceExpression: app_save_locale_button_text%>"
                        OnClick="btnSave_Click" />
                </div>
                <div class="right">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                        Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                </div>
                <div class="clear">
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
