<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tappp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Profile.tappp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
            $(".rstpwd").click(function () {

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 632,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Users/ChangePassword/sacpu-01.aspx',
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
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_system_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_personal_information_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_last_name_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_first_name_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_middle_name_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtMiddleName" CssClass="textbox_65" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_manager_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblManager" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_supervisor_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_mentor_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblMentor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_alt_manager_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblAltManager" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_alt_supervisor_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblAltSupervisor" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_alt_mentor_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblAltMentor" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_login_information_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_user_name_text")%>:
                </td>
                <td class="lable_td_width">
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <input type="button" class="rstpwd" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_reset_your_password_button_text %>" />' />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_contact_and_locale_information_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_email_address_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmailAddress" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_work_phone_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtWorkPhone" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_work_extension_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtWorkExtension" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_mobile_number_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtMobilenumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_mobile_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMobileType" DataValueField="u_mobile_type_id_pk" DataTextField="u_mobile_type_name"
                        CssClass="ddl_user_advanced_search" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_carrier_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCarrier" DataValueField="u_mobile_carrier_type_id_pk" DataTextField="u_mobile_carrier_type_name"
                        CssClass="ddl_user_advanced_search" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_address_1_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_address_2_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_address_3_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress3" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_city_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCity" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_state_province_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtStateprovince" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_zip_postal_code_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtzippostalcode" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_country_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCountry" DataValueField="u_country_id_pk" DataTextField="u_country_name"
                        CssClass="ddl_user_advanced_search" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    *<%=LocalResources.GetLabel("app_locale_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLocale" CssClass="ddl_user_advanced_search" DataTextField="s_locale_description"
                        DataValueField="s_locale_id_pk" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    *<%=LocalResources.GetLabel("app_timezone_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTimezone" DataTextField="u_time_zone_location" DataValueField="u_time_zone_id_pk"
                        runat="server" CssClass="ddl_user_advanced_search">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="clear">
    </div>
    <div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_my_preferences_text")%>:
        </div>
        <br />
        <div class="div_padding_10">
            <table cellspacing="0" cellpadding="0" class="gridview_long_no_border">
                <thead>
                    <tr>
                        <th class="th_width_700" align="left">
                            <%=LocalResources.GetLabel("app_home_page_section_text")%>
                        </th>
                        <th align="center">
                            <%=LocalResources.GetLabel("app_no_of_records_text")%>
                        </th>
                        <th align="center">
                            <%=LocalResources.GetLabel("app_collapsed_text")%>
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <%=LocalResources.GetLabel("app_splash_page_text")%>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlNumberOfRecordSplash" runat="server">
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="0">Show All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlCollapsedSpalsh" DataValueField="id" DataTextField="name"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <%=LocalResources.GetLabel("app_theme_text")%>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlNumberOfRecourdsTheme" runat="server">
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="0">Show All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlCollapsedTheme" DataValueField="id" DataTextField="name"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <%=LocalResources.GetLabel("app_my_reports_text")%>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlNumberOfRecordsReport" runat="server">
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="0">Show All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlCollapsedReport" DataValueField="id" DataTextField="name"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </thead>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div>
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_center">
                        <asp:Button ID="btnSave" runat="server" Text="<%$ LabelResourceExpression: app_save_my_profile_information_button_text %>"
                            OnClick="btnSave_Click" />
                    </td>
                    <td class="align_center">
                        <asp:Button ID="btnReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Click" />
                    </td>
                    <td class="align_center">
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="clear">
        </div>
    </div>
    <div>
        <div class="div_header_long">
            &nbsp;
        </div>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_footer_system_home_text")%>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
