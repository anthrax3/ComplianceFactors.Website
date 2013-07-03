<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saaloc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Documents.add_document_locale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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

            $(".attachment").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 500,
                'height': 205,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': '../Locale/saal-01.aspx',
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
   <div id="content">
        <div style="margin-right: 10px;">
            <div class=" div_header_650">
                <asp:Label ID="lblLocaleHeading" runat="server"></asp:Label>
            </div>
            <div class="div_controls font_1">
                <asp:ValidationSummary class="validation_summary_error" ID="vssaaloc" runat="server"
                    ValidationGroup="saaloc" />
                <table class="">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="saaloc"
                                ControlToValidate="txtDocumentName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *<%=LocalResources.GetLabel("app_document_name_text")%>:
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtDocumentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="7" Width="500px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_document_file_text")%>:
                        </td>
                        <td style="text-align: left; white-space: nowrap;">
                            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                            <asp:Button ID="btnAttachment" CssClass="attachment cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_attachment_button_text %>" />
                            <div id="divAttachment" runat="server">
                                <asp:Button ID="btnAttachmentView" runat="server" Text="View" OnClick="btnAttachmentView_Click" />
                                <asp:Button ID="btnEdit" CssClass="attachment cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>"
                                    OnClick="btnEdit_Click" />
                                <asp:Button ID="btnRemove" runat="server" OnClientClick="return confirmRemove();"
                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" OnClick="btnRemove_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table class="table_td_300">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveLocale" ValidationGroup="saaloc" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>"
                                OnClick="btnSaveLocale_Click" />
                        </td>
                        <td class="align_right">
                            <%--                        <input id="button1" type="button" value="Cancel" onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close()" />--%>
                            <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close()"
                                Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
