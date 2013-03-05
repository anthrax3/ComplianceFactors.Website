<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Domains.saandn_01" %>

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

            $("#<%=btnOnwer.ClientID %>").fancybox({
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
                'href': '/SystemHome/sasumsm-01.aspx?domainowner=true&page=saandn',
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
                'href': '/SystemHome/sasumsm-01.aspx?domaincoordinatorowner=true&page=saandn',
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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saandn" runat="server"
        ValidationGroup="saandn"></asp:ValidationSummary>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNewDomain" ValidationGroup="saandn" CssClass="cursor_hand"
                            runat="server" Text="<%$ LocalizationResourceExpression: app_save_new_domain_button_text %>" OnClick="btnHeaderSaveNewDomain_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="<%$ LocalizationResourceExpression: app_reset_button_text %>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LocalizationResourceExpression: app_cancel_button_text %>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLocalizationResourceLabelText("app_domain_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDomainId" runat="server" ValidationGroup="saandn"
                            ControlToValidate="txtDomainId" ErrorMessage="<%$ LocalizationResourceExpression: app_domain_id_error_msg %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLocalizationResourceLabelText("app_domain_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomainId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDomainName" runat="server" ValidationGroup="saandn"
                            ControlToValidate="txtDomainName" ErrorMessage="<%$ LocalizationResourceExpression: app_domain_name_error_msg %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLocalizationResourceLabelText("app_domain_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomainName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDomainDescription" runat="server" ValidationGroup="saandn"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ LocalizationResourceExpression: app_domain_description_error_msg %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLocalizationResourceLabelText("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLocalizationResourceLabelText("app_owner_text")%>:
                    </td>
                    <td colspan="3" class="align_left">
                        <asp:Label ID="lblOwner" CssClass="font_normal cursor_hand" runat="server"></asp:Label>
                        <asp:Button ID="btnOnwer" runat="server" CausesValidation="false" CssClass="cursor_hand"
                            Text="<%$ LocalizationResourceExpression: app_select_button_text %>" />
                    </td>
                    <td colspan="3" class="align_right">
                        <%=LocalResources.GetLocalizationResourceLabelText("app_coordinator_text")%>:&nbsp;
                        <asp:Label ID="lblcoordinator" CssClass="font_normal cursor_hand" runat="server"></asp:Label>
                        <asp:Button ID="btnCoordinator" runat="server" CssClass="cursor_hand" Text="<%$ LocalizationResourceExpression: app_select_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLocalizationResourceLabelText("app_status_text")%>:
                    </td>
                    <td colspan="3" class="align_left">
                        <asp:DropDownList ID="ddlStatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3" class="align_right">
                        <%=LocalResources.GetLocalizationResourceLabelText("app_theme_text")%>:&nbsp;
                        <asp:DropDownList ID="ddlTheme" DataTextField="u_theme_name" DataValueField="u_theme_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
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
                        <asp:Button ID="btnFooterSaveNewDomain" ValidationGroup="saandn" CssClass="cursor_hand"
                            runat="server" Text="<%$ LocalizationResourceExpression: app_save_new_domain_button_text %>" OnClick="btnFooterSaveNewDomain_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LocalizationResourceExpression: app_reset_button_text %>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LocalizationResourceExpression: app_cancel_button_text %>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
