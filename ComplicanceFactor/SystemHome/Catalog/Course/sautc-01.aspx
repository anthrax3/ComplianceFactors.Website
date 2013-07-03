<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sautc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Popup.sautc_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script type="text/javascript">
        function vali_type(sender, args) {
            var id_value = document.getElementById('<%=FileUpload1.ClientID %>').value;

            if (id_value != '') {
                var valid_extensions = /(.jpg|.jpeg|.gif|.tif|.tiff|.png|.bmp)$/i;
                if (valid_extensions.test(id_value)) {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;

                }
            }

        }
    </script>
    <div id="content">
        <div class="div_upload_file">
            <div id="divIcon">
                <div class="fancy-popup-header">
                    <div class="left">
                        <%=LocalResources.GetLabel("app_upload_icon_text")%>:
                    </div>
                </div>
                <div>
                    <asp:ValidationSummary class="validation_summary_error" ID="vs_saantc" runat="server"
                        ValidationGroup="vsIcon"></asp:ValidationSummary>
                    <asp:CustomValidator ID="cvIconUri" runat="server" ValidationGroup="vsIcon" ErrorMessage="<%$ TextResourceExpression: app_icon_image_error_wrong%>"
                        ClientValidationFunction="vali_type">&nbsp;</asp:CustomValidator>
                    <div class="uploadpanel">
                        <b>
                            <%=LocalResources.GetLabel("app_select_file_text")%>: </b>
                        <br />
                        <br />
                        <asp:FileUpload Width="400" size="50" ID="FileUpload1" runat="server" /><br />
                        <br />
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="align_left" style="width: 350px;">
                                    <asp:Button ID="btnUpload" runat="server" ValidationGroup="vsIcon" Text="<%$ LabelResourceExpression: app_upload_button_text%>"
                                        OnClick="btnUpload_Click" CssClass="cursor_hand" />
                                </td>
                                <td class="align_right">
                                    <input type="button" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />'
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
