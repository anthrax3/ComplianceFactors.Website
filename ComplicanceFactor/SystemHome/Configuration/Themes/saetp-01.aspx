<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saetp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Themes.saetp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnPreview.ClientID %>").click(function () {
                $('#divPreview').html($('#<%=txtContent.ClientID %>').val());
            });
        });
        //reset scroll position popup
        function ResetScroll() {
            $('#divPreview').animate({ scrollTop: 0 });

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%=btnOwner.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 980,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '/SystemHome/sasumsm-01.aspx?themeowner=true&page=saantp',
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
            $("#<%=btnCoordinator.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 980,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '/SystemHome/sasumsm-01.aspx?themeCoordinator=true&page=saantp',
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".editAttachment").click(function () {

                var themeId = document.getElementById('<%=hdThemeId.ClientID %>').value;
                alert(themeId);
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 740,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-satim-01.aspx?uploadedImage=' + record_id + '&editThemeId=' + themeId,
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

        });
    </script>
    <script type="text/javascript">
        function validateAll(sender, args) {

            var gridView = document.getElementById('<%= gvColors.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {

                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs[0].type == "text") {
                    if (inputs[0].value == '') {
                        args.IsValid = false;
                        break;
                    }
                    else {
                        //alert(inputs[0].value);                       
                        var regColorcode = /^(#)?([0-9a-fA-F]{3})([0-9a-fA-F]{3})?$/;
                        if (regColorcode.test(inputs[0].value) == false) {
                            //alert(1);
                            args.IsValid = false;
                            break;
                        }
                    }
                }
            }
            return args.IsValid;
        }
    </script>
    <script type="text/javascript">
        function validateColor() {
            var isValid = false;
            isValid = Page_ClientValidate('saetp');
            if (isValid) {
                isValid = Page_ClientValidate('saantp_validatecolor');
            }
            return isValid;
        }
    </script>
    <br />
    <br />
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saetp" runat="server"
        ValidationGroup="saetp"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saantp_validatecolor"
        runat="server" ValidationGroup="saantp_validatecolor"></asp:ValidationSummary>
    <div class="content_area_long">
        <asp:HiddenField ID="hdThemeId" runat="server" />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
        </asp:ToolkitScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderUpdateTheme" OnClientClick="return validateColor()" CssClass="cursor_hand"
                            runat="server" Text="Update Theme" OnClick="btnHeaderUpdateTheme_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="Reset" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Theme Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvThemeId" runat="server" ValidationGroup="saetp"
                            ControlToValidate="txtThemeId" ErrorMessage="please enter Id">&nbsp;
                        </asp:RequiredFieldValidator>
                        * Theme Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtThemeId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="width_180">
                        <asp:RequiredFieldValidator ID="rfvThemeName" runat="server" ValidationGroup="saetp"
                            ControlToValidate="txtThemeName" ErrorMessage="Please enter theme name">&nbsp;
                        </asp:RequiredFieldValidator>
                        * Theme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtThemeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:RequiredFieldValidator ID="rfvContent" runat="server" ValidationGroup="saetp"
                            ControlToValidate="txtContent" ErrorMessage="Please enter description">&nbsp;
                        </asp:RequiredFieldValidator>
                        * Description:<br />
                        <br />
                        <br />
                        <asp:Button ID="btnPreview" CssClass="cursor_hand" runat="server" Text="Preview" />
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtContent" runat="server" class="txtInput_long" rows="10" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right" colspan="2">
                        Owner:
                        <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnOwner" runat="server" Text="Owner" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right" colspan="2">
                        Coordinator:
                        <asp:Label ID="lblCoordinator" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnCoordinator" runat="server" Text="Coordinator" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Domain:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDomain" DataTextField="u_domain_id_pk" DataValueField="u_domain_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server" />
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Logos:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvLogos" CellPadding="0" CellSpacing="0" CssClass="gridview_width_900"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="keyvalue,s_theme_description,FileName"
                OnRowCommand="gvLogos_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderStyle-HorizontalAlign="Center" DataField="s_theme_description" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="" DataField="FileName" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("keyvalue") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Upload" />'
                                class="editAttachment cursor_hand" />
                            <%--  <asp:Button ID="btnUpload" CommandName="Upload" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Upload" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnPreview" CommandName="Preview" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Preview" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
        <div class="div_header_long">
            Colors:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvColors" CellPadding="0" CellSpacing="0" CssClass="gridview_width_900"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" DataKeyNames="keyvalue" OnRowDataBound="gvColors_RowDataBound"
                OnRowCommand="gvColors_RowCommand" OnRowEditing="gvColors_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="" HeaderStyle-HorizontalAlign="Center" DataField="s_theme_description"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblHex" runat="server" Text="HEX#:"></asp:Label>
                            <asp:TextBox ID="txtHex" runat="server" Text='<%#Eval("Colorvalue") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblPreview" runat="server" Text="Preview:"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div style="border: 1px solid black; width: 25px; height: 25px;">
                                <div id="ColorDiv" runat="server" style="width: 20px; height: 20px;">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnReset" CommandName="Reset" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Reset" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterUpdateTheme" OnClientClick ="return validateColor()" CssClass="cursor_hand"
                            runat="server" Text="Update Theme" OnClick="btnFooterUpdateTheme_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="Reset" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Button ID="btnAttachment" runat="server" Visible="false" />
    <asp:ModalPopupExtender ID="mpeAddAttachment" runat="server" TargetControlID="btnAttachment"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload" Style="display: none;
        padding-left: 0px; background-color: White; padding-right: 0px;">
        <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                        <asp:Label ID="lblHeading" Text="Add Digital Media File" runat="server"></asp:Label>
                    </div>
                    <div class="right">
                        <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                            ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div>
            <br />
            <div class="uploadpanel font_normal">
                <asp:ValidationSummary class="validation_summary_error_popup" ID="vsFileUpload" runat="server"
                    ValidationGroup="themeUpload" />
                <asp:CustomValidator ValidationGroup="themeUpload" ID="cvFileUpload" runat="server"
                    EnableClientScript="true" ErrorMessage="please upload valid files" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                Select File:
                            </td>
                            <td>
                                <asp:FileUpload ID="fupFiles" runat="server" Width="460" size="60" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <div class="multiple_button">
                    <asp:Button ID="btnUploadAttachment" ValidationGroup="themeUpload" runat="server"
                        Text="Upload" CssClass="cursor_hand" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="Cancel" />
            </div>
            <br />
        </div>
    </asp:Panel>
</asp:Content>
