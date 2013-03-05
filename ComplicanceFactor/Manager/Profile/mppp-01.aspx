<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="mppp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Profile.mppp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_employee').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_employee').addClass('selected');
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
        <%=LocalResources.GetText("app_succ_update_text")%>
    </div>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_updated_error_wrong")%>
    </div>
    <div>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content")%>
            <br />
            <br />
            <br />
        </div>
        <div class="div_header_long">
            My Personal Information:
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Last Name:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                    </td>
                    <td>
                        First Name:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                    </td>
                    <td>
                        Middle Name:
                    </td>
                    <td class="lable_td_width">
                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Manager:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblManager" runat="server"></asp:Label>
                    </td>
                    <td>
                        Supervisor:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                    </td>
                    <td>
                        Mentor:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblMentor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Alt Manager:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblAltManager" runat="server"></asp:Label>
                    </td>
                    <td>
                        Alt Supervisor:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblAltSupervisor" runat="server"></asp:Label>
                    </td>
                    <td>
                        Alt Mentor:
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblAltMentor" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Login Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Username
                    </td>
                    <td class="lable_td_width">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <input type="button" class="rstpwd" value="Reset Your Password" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            Contact and Locale Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Email Address:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailAddress" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Work Phone:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWorkPhone" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Work Extension:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWorkExtension" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        Mobile Number:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobilenumber" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Mobile Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMobileType" DataValueField="u_mobile_type_id_pk" DataTextField="u_mobile_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Carrier:
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
                        Address 1:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Address 2:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Address 3:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress3" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        City:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        State / Province:
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateprovince" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        ZIP / Postal Code:
                    </td>
                    <td>
                        <asp:TextBox ID="txtzippostalcode" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        Country:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" DataValueField="u_country_id_pk"
                            DataTextField="u_country_name" CssClass="ddl_user_advanced_search">
                        </asp:DropDownList>
                    </td>
                    <td>
                        * Locale:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocale" runat="server" CssClass="ddl_user_advanced_search"
                            DataTextField="s_locale_description" DataValueField="s_locale_id_pk">
                        </asp:DropDownList>
                    </td>
                    <td>
                        * Timezone:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTimezone" DataTextField="u_time_zone_location" DataValueField="u_time_zone_id_pk"
                            runat="server" CssClass="ddl_user_advanced_search">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            My Preferences:
        </div>
        <br />
        <div class="div_padding_10">
            <table cellspacing="0" cellpadding="0" class="gridview_long_no_border">
                <thead>
                    <tr>
                        <th class="th_width_700" align="left">
                            Home Page Section
                        </th>
                        <th align="center">
                            Number of Records
                        </th>
                        <th align="center">
                            Collapsed
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            My To Dos
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlNumberOfRecordToDo" runat="server">
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
                            <asp:DropDownList ID="ddlCollapsedToDo" DataValueField="id" DataTextField="name"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            My Team
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlNumberOfRecourdsTeam" runat="server">
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
                            <asp:DropDownList ID="ddlCollapsedTeam" DataValueField="id" DataTextField="name"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            My Reports
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
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="gridview_long_no_border">
                <tr>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="button_style">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnSave" runat="server" Text="Save My Profile Information" OnClick="btnSave_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_footer_content")%>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
