<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saantp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Themes.saantp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

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

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'no',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 640,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-satim-01.aspx?uploadedImage=' + record_id,
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
        function validateColorCode() {
            alert(hai);            
            var gridView = document.getElementById('<%= gvColors.ClientID %>');
            for (var i = 0; i < gridView.rows.length; i++) {
                alert(test);
                var inputs = gridView.rows[i].getElementsByTagName('input');                 
                if (inputs[0].type == "text") {
                    if (inputs[0].value == '') {
                        args.IsValid = false;
                        break;
                    }
                    else {
                        alert(1);
                        args.IsValid = validateColor(txtboxes.item(i).value);
                        alert(args.IsValid);
                    }
                }
            }
        }               
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
             isValid = Page_ClientValidate('saantp');
             if (isValid) {
                 isValid = Page_ClientValidate('saantp_validatecolor');
             }             
             return isValid;
         }
    </script>
    <script type="text/javascript">
        function previewcolor(id) {
            var gridCompletion = document.getElementById('<%= gvColors.ClientID %>');
            var test;
            if (gridCompletion.rows.length > 0) {
                for (var i = 1; i < gridCompletion.rows.length; i++) {
                    var inputs = gridCompletion.rows[i].getElementsByTagName('input');
                    if (inputs[0].type == "text") {
                        //div.style.backgroundColor = '#' + inputs[i].value;
                        test = '#' + inputs[0].value;
                        inputs[1].style.backgroundColor = test;

                    }
                }
            }
        }
    </script>
        <script type="text/javascript">
            $(document).ready(function () {

                $(".preview").click(function () {
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
                        'height': 500,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': 'Popup/p-preview.aspx?imgId=' + record_id,
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
    <br />
    <br />
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saantp_validatecolor" runat="server"
            ValidationGroup="saantp_validatecolor"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saanspn" runat="server"
        ValidationGroup="saantp"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvValidateColor" EnableClientScript="true" ClientValidationFunction="validateAll"
        ValidationGroup="saantp_validatecolor" runat="server" ErrorMessage="<%$ TextResourceExpression: app_color_code_error_empty_text %>">&nbsp;</asp:CustomValidator>
    <div class="content_area_long">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
        </asp:ToolkitScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveTheme"  CssClass="cursor_hand"    
                            runat="server" Text="<%$ LabelResourceExpression: app_save_theme_button_text %>" OnClientClick ="return validateColor()" OnClick="btnHeaderSaveTheme_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" 
                            Text="<%$ LabelResourceExpression: app_reset_button_text %>" onclick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" onclick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_theme_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvThemeId" runat="server" ValidationGroup="saantp"
                            ControlToValidate="txtThemeId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_theme_id_text")%>:
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
                        <asp:RequiredFieldValidator ID="rfvThemeName" runat="server" ValidationGroup="saantp"
                            ControlToValidate="txtThemeName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_theme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtThemeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:RequiredFieldValidator ID="rfvContent" runat="server" ValidationGroup="saantp"
                            ControlToValidate="txtContent" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_description_text")%>:<br />
                        <br />
                        <br />
                        <asp:Button ID="btnPreview" CssClass="cursor_hand" runat="server" 
                            Text="<%$ LabelResourceExpression: app_preview_button_text %>" 
                            onclick="btnPreview_Click" />  
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtContent" runat="server" class="txtInput_long" rows="10" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right" colspan="2">
                         <%=LocalResources.GetLabel("app_owner_text")%>:
                        <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnOwner" runat="server" Text="<%$ LabelResourceExpression: app_owner_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right" colspan="2">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        <asp:Label ID="lblCoordinator" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnCoordinator" runat="server" Text="<%$ LabelResourceExpression: app_Coordinator_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_domain_text")%>:
                    </td>
                    <td>
                        <asp:Label ID="lblDomains" runat="server" Text=" "></asp:Label>
                        <%-- <asp:DropDownList ID="ddlDomain" DataTextField="u_domain_id_pk" DataValueField="u_domain_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server" />--%>
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_logos_text")%>:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvLogos" CellPadding="0" CellSpacing="0" CssClass="gridview_width_900"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" AutoGenerateColumns="False" AllowPaging="true"
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
                            <input type="button" id='<%# Eval("keyvalue") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>" />'
                                class="editAttachment cursor_hand" />
                            <%--  <asp:Button ID="btnUpload" CommandName="Upload" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Upload" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
         <%--                   <asp:Button ID="btnPreview" CommandName="Preview" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_preview_button_text %>" />--%>
                           <input type="button" id='<%# Eval("FileName") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_preview_button_text %>" />'
                                class="preview cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_colors_text")%>:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvColors" CellPadding="0" CellSpacing="0" CssClass="gridview_width_900"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" DataKeyNames="keyvalue" OnRowDataBound="gvColors_RowDataBound"
                OnRowEditing="gvColors_RowEditing" OnRowCommand="gvColors_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="" HeaderStyle-HorizontalAlign="Center" DataField="s_theme_description"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%=LocalResources.GetLabel("app_hex_text")%>#:
                            <%--<asp:Label ID="lblHex" runat="server" Text="<%$ LabelResourceExpression: app_hex_text %>"></asp:Label>--%>
                            <asp:TextBox ID="txtHex" runat="server" Text='<%#Eval("Colorvalue") %>' onblur="previewcolor(this.value);"></asp:TextBox>
                          <%--   <asp:Literal ID="ltlHex" runat="server" />--%>
                            <%--<input type="text" value='<%#Eval("Colorvalue") %>' onchange="validateCompletion(this.value);" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%--<asp:Label ID="lblPreview" runat="server" Text="<%$ LabelResourceExpression: app_preview_text %>"></asp:Label>:--%>
                             <%=LocalResources.GetLabel("app_preview_text")%>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                           <%-- <div style="border: 1px solid black; width: 25px; height: 25px;">
                                <div id="ColorDiv" runat="server" style="width: 20px; height: 20px;">
                                </div>
                            </div>--%>
                            <asp:Literal ID="ltlPreviewColor" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnReset" CommandName="Reset" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
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
                        <asp:Button ID="btnFooterSaveTheme" CssClass="cursor_hand" OnClientClick ="return validateColor()"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_theme_button_text %>" OnClick="btnFooterSaveTheme_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" 
                            Text="<%$ LabelResourceExpression: app_reset_button_text %>" onclick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" 
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" onclick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
