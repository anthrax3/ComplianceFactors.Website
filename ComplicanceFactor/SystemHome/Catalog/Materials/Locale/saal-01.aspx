<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saal-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Materials.Locale.saal_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../../Scripts/JQuery.Zoom.Style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ValidateFileUpload(source, args) {



            var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                window.scrollTo = function () { }
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

    </script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 502px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 210px;
            overflow: hidden;
        }
    </style>
    <div id="content">
        <div class="div_upload_file">
            <div id="divIcon">
                <div class="fancy-popup-header">
                    <div class="left">
                        <%=LocalResources.GetLabel("app_attachment_text")%>:
                    </div>
                </div>
                <div>
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_saal" runat="server"
                        ValidationGroup="vsAttachment"></asp:ValidationSummary>
                    <asp:CustomValidator ID="cvFile" runat="server" EnableClientScript="true" ValidationGroup="vsAttachment"
                        ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty %>" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                    <div class="uploadpanel">
                        <%=LocalResources.GetLabel("app_select_file_text")%>:
                        <br />
                        <br />
                        <asp:FileUpload Width="400" size="50" ID="FileUpload1" runat="server" /><br />
                        <br />
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="align_left" style="width: 350px;">
                                    <asp:Button ID="btnUpload" runat="server" ValidationGroup="vsAttachment" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                        OnClick="btnUpload_Click" CssClass="cursor_hand" />
                                </td>
                                <td class="align_right">
                                    <input type="button" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />'
                                        onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                        class="cursor_hand" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
