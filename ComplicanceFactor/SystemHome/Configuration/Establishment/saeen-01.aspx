<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saeen-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Establishment.saeen_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var editEstablishmentId = $('input#<%=hdEstablishmentId.ClientID %>').val();
            // Add and view  locale
            $("#btnManageLocale").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'Locale/savloc-01.aspx?mode=edit&establishmentid=' + editEstablishmentId,
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
    <br />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saefin" runat="server"
        ValidationGroup="saefin"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:HiddenField ID="hdEstablishmentId" runat="server" />
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveEstablishment" ValidationGroup="saefin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_establishment_text %>"
                            OnClick="btnHeaderSaveEstablishment_Click" />
                    </td>
                    <td align="left">
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
            <%=LocalResources.GetLabel("app_establishment_information_english_us_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEstablishmentlId" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtEstablishmentId" ErrorMessage="<%$ TextResourceExpression: app_establishment_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_establishment_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEstablishmentId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEstablishmentName" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtEstablishmentName" ErrorMessage="<%$ TextResourceExpression: app_establishment_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_establishment_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEstablishmentName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvEstablishmentDescription" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtEstablishmentDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtEstablishmentDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
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
                  
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="btnManageLocale" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
          
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
              
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtCity" ErrorMessage="<%$ TextResourceExpression: app_city_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>*
                        <%=LocalResources.GetLabel("app_city_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtState" ErrorMessage="<%$ TextResourceExpression: app_state_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_state_province_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ValidationGroup="saefin"
                            ControlToValidate="txtZipCode" ErrorMessage="<%$ TextResourceExpression: app_zipcode_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_zip_postal_code_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipCode" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_country_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" DataTextField="u_country_name" DataValueField="u_country_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_locale_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocale" DataTextField="s_locale_description" DataValueField="s_locale_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_timezone_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTimezone" DataTextField="u_time_zone_description" DataValueField="u_time_zone_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        
        
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveEstablishment" ValidationGroup="saefin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_establishment_button_text %>"
                            OnClick="btnFooterSaveEstablishment_Click" />
                    </td>
                    <td align="left">
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
    </div>
</asp:Content>
