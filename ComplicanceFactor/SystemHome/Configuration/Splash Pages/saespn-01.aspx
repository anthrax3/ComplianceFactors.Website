<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saespn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Splash_Pages.saespn_02" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 960px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
        }
    </style>--%>
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
                'href': '/SystemHome/sasumsm-01.aspx?splashowner=true&page=saanspn',
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
                'href': '/SystemHome/sasumsm-01.aspx?splashCoordinator=true&page=saespn',
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
        // Add locale
        $(document).ready(function () {
            //var message = $.QueryString("mode"),
            //message = (!message) ? "null" : message; // Passing the value null to string

            // var editlocationId = $.QueryString("splashPageid"),
            //editlocationId = (!editlocationId) ? "null" : editlocationId; // Passing the value null to string

            $("#btnCreateNewLocale").click(function (e) {

                var editsplashPageId = $('input#<%=hdSplashId.ClientID %>').val();

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 820,
                    'height': 350,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Locale/saaloc-01.aspx?mode=create' + "&editSplashId=" + editsplashPageId + "&editLocaleId=" + localeid,
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
        // Add locale
        $(document).ready(function () {
            //var message = $.QueryString("mode"),
            //message = (!message) ? "null" : message; // Passing the value null to string

            // var editlocationId = $.QueryString("splashPageid"),
            //editlocationId = (!editlocationId) ? "null" : editlocationId; // Passing the value null to string

            $(".editlocale").click(function (e) {

                var editsplashPageId = $('input#<%=hdSplashId.ClientID %>').val();

                var record_id = $(this).attr("id");

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 820,
                    'height': 350,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Locale/saaloc-01.aspx?mode=edit' + "&editSplashId=" + editsplashPageId + "&editLocalepk=" + record_id,
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

        $(document).ready(function () {

            $(".deletelocale").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saespn-01.aspx/DeleteLocale",

                        //Pass the selected record id
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                $("#<%= ddlLocale.ClientID %>").append("<option value=" + element[1] + ">" + element[2] + " </option>");
                                $("#<%= ddlLocale.ClientID %>").val(element[1]);
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        function RemoveLocale(value) {

            var exists = false;
            $('#<%=ddlLocale.ClientID %>  option').each(function () {
                if (this.value == value) {
                    exists = true;
                    $('#<%=ddlLocale.ClientID %> option[value=' + value + ']').remove();
                }
            });



        }
    </script>
    <br />
    <br />
    <asp:HiddenField ID="hdSplashId" runat="server" />
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saespn02" runat="server"
        ValidationGroup="saespn02"></asp:ValidationSummary>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveSplashPage" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>"
                            ValidationGroup="saespn02" OnClick="btnHeaderSaveSplashPage_Click" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_splash_page_info_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSplashId" runat="server" ValidationGroup="saespn02"
                            ControlToValidate="txtSplashPageId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *  <%=LocalResources.GetLabel("app_splash_page_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSplashPageId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvSplashName" runat="server" ValidationGroup="saespn02"
                            ControlToValidate="txtSplashPageName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_splash_page_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSplashPageName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:RequiredFieldValidator ID="rfvContent" runat="server" ValidationGroup="saespn02"
                            ControlToValidate="txtContent" ErrorMessage="<%$ TextResourceExpression: app_content_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_status_text")%>:<br />
                        <br />
                        <br />
                        <asp:Button ID="btnPreview" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_preview_button_text %>" OnClientClick="ResetScroll();" />
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
                        <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right" colspan="2">
                       <%=LocalResources.GetLabel("app_owner_text")%>:
                        <asp:Label ID="lblOwner" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btnOwner" runat="server" Text="<%$ LabelResourceExpression: app_owner_button_text %>" />
                    </td>
                    <td class="align_right" colspan="2">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        <asp:Label ID="lblCoordinator" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btnCoordinator" runat="server" Text="<%$ LabelResourceExpression: app_Coordinator_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                      <%=LocalResources.GetLabel("app_domain_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDomain" DataTextField="u_domain_id_pk" DataValueField="u_domain_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server" />
                    </td>
                    <td colspan="5">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
           <%=LocalResources.GetLabel("app_all_locale_text")%>:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvSplashLocales" RowStyle-CssClass="record" CssClass="grid_700"
                runat="server" GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_300">
                        <ItemTemplate>
                            <%#Eval("s_locale_description")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("u_splash_locale_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                class="editlocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("u_splash_locale_system_id_pk").ToString() + "," +  Eval("u_splash_locale_id_fk").ToString() + "," +  Eval("s_locale_description").ToString()%>'
                                value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />' class="deletelocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <table class="grid_700" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="width_300">
                        <asp:DropDownList ID="ddlLocale" DataTextField="s_locale_description" DataValueField="s_locale_id_pk"
                            CssClass="dropdown_width_300" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right">
                        <input type="button" id="btnCreateNewLocale" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_create_new_locale_button_text %>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveSplashPage" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>"
                            ValidationGroup="saespn02" OnClick="btnFooterSaveSplashPage_Click" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="font_normal">
            <asp:Panel ID="pnlPreview" runat="server" CssClass="modalPopup_width_700" Style="display: none;
                padding-left: 0px; background-color: White; padding-right: 0px;">
                <asp:Panel ID="pnlPreviewHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_700">
                            <%=LocalResources.GetLabel("app_splash_preview_text")%>:
                        </div>
                        <asp:ImageButton ID="imgClosePreview" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <br />
                <div class="div_padding_10 font_normal" id="divPreview" style="height: 178px; overflow-x: hidden;
                    overflow: auto">
                </div>
                <br />
                <div class="div_padding_10">
                    <center>
                        <asp:Button ID="btnClosePreview" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_close_button_text %>" />
                    </center>
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </div>
        <asp:ModalPopupExtender ID="mpPreview" runat="server" TargetControlID="btnPreview"
            OkControlID="btnClosePreview" CancelControlID="imgClosePreview" PopupControlID="pnlPreview"
            BackgroundCssClass="transparent_class" DropShadow="false" PopupDragHandleControlID="pnlPreviewHeading">
        </asp:ModalPopupExtender>
    </div>
    <br />
</asp:Content>
