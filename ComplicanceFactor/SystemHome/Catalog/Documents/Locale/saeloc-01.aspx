<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saeloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.edit_document_locale" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <style type="text/css">
        input[type=button], input[type=submit]
        {
            cursor: pointer;
        }
    </style>
    <style type="text/css">
        body
        {
            width: 550px;
            height: 350px;
            margin: 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var localeid = $.QueryString("id"),
            localeid = (!localeid) ? "null" : localeid; // Passing the value null to string

            var mode = $.QueryString("mode"),
            mode = (!mode) ? "null" : mode; // Passing the value null to string

            $(".attachment").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 510,
                'height': 205,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': '../Locale/saal-01.aspx?&mode=' + mode + "&id=" + localeid,
                'onComplete': function () {
                    $('#fancybox-frame').load(function () {
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });



                }

            });
        });
        function confirmRemove() {
            if (confirm("Are you sure?") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/SystemHome/Catalog/Documents/Locale/GenerateFile/iframe.js" />
        </Scripts>
    </asp:ToolkitScriptManager>
    <div id="content">
        <div class=" div_header_650" id="divLocaleHeader" runat="server">
            <asp:Label ID="lblLocaleHeading" runat="server"></asp:Label>
        </div>
        <asp:ValidationSummary class="validation_summary_error" Style="width: 600px" ID="vssaeloc"
            runat="server" ValidationGroup="saeloc" />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="saeloc"
                            ControlToValidate="txtName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_document_name_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox_width"></asp:TextBox>
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
                    <td>
                        <%=LocalResources.GetLabel("app_attachment_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="white-space: nowrap">
                                            <asp:LinkButton ID="lnkDownload"  runat="server"></asp:LinkButton>
                                            <asp:Button ID="btnAttachment" CssClass="attachment cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_attachment_button_text %>" />
                                            <div id="divAttachment" runat="server">
                                                <asp:Button ID="btnAttachmentView" runat="server" Text="View"/>
                                                <asp:Button ID="btnEdit" CssClass="attachment cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>"
                                                    OnClick="btnEdit_Click" />
                                                <asp:Button ID="btnRemove" runat="server" OnClientClick="return confirmRemove();"
                                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" OnClick="btnRemove_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnSaveLocale" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>" ValidationGroup="saeloc" OnClick="btnSave_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
