<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saeu-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.saeu_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/JQuery.Zoom.js" type="text/javascript"></script>
    <link href="../../Scripts/JQuery.Zoom.Style.css" rel="stylesheet" type="text/css" />
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
        function resetall() {
            document.getElementById('<%=txtPassword_login.ClientID %>').value = '';
            document.getElementById('<%=txtUsername_login.ClientID %>').value = '';
            document.getElementById('<%=txtFirstName.ClientID %>').value = '';
            document.getElementById('<%=txtMiddelName.ClientID %>').value = '';
            document.getElementById('<%=txtLastName.ClientID %>').value = '';
            document.getElementById('<%=txtEmailAddress.ClientID %>').value = '';

            document.getElementById('<%=ddlMobileType.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlCarrier.ClientID %>').selectedIndex = '0';


            document.getElementById('<%=txtMobilenumber.ClientID %>').value = '';
            document.getElementById('<%=txtWorkPhone.ClientID %>').value = '';
            document.getElementById('<%=txtWorkExtension.ClientID %>').value = '';
            document.getElementById('<%=txtAddress1.ClientID %>').value = '';
            document.getElementById('<%=txtAddress2.ClientID %>').value = '';
            document.getElementById('<%=txtAddress3.ClientID %>').value = '';
            document.getElementById('<%=txtCity.ClientID %>').value = '';
            document.getElementById('<%=txtStateprovince.ClientID %>').value = '';
            document.getElementById('<%=txtzippostalcode.ClientID %>').value = '';
            document.getElementById('<%=ddlCountry.ClientID %>').selectedIndex = '0';

            document.getElementById('<%=ddlUserdomain.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLocale.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlTimezone.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserTypes.ClientID %>').selectedIndex = '0';



            //user creation type
            document.getElementById('<%=ddlUserTypes.ClientID %>').selectedIndex = '0';

            //End

            document.getElementById('<%=ddlUserstatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlUserTypes.ClientID %>').selectedIndex = '0';

            document.getElementById('<%=txtEmployeeid.ClientID %>').value = '';
            document.getElementById('<%=ddlEmployeeType.ClientID %>').selectedIndex = '0';



            document.getElementById('<%=txtHiredate.ClientID %>').value = '';
            document.getElementById('<%=txtLastrehire.ClientID %>').value = '';
            document.getElementById('<%=txtCompany.ClientID %>').value = '';
            document.getElementById('<%=txtRegion.ClientID %>').value = '';
            document.getElementById('<%=txtDivision.ClientID %>').value = '';
            document.getElementById('<%=txtDepartment.ClientID %>').value = '';
            document.getElementById('<%=txtcostcenter.ClientID %>').value = '';
            document.getElementById('<%=txtJobgroup.ClientID %>').value = '';
            document.getElementById('<%=txtJobcode.ClientID %>').value = '';
            document.getElementById('<%=txtJobtitle.ClientID %>').value = '';
            document.getElementById('<%=txtJobPosition.ClientID %>').value = '';
            document.getElementById('<%=txtPayGrade.ClientID %>').value = '';




            //questions

            document.getElementById('<%=lblManager.ClientID %>').innerHTML = '';
            document.getElementById('<%=lblSupervisor.ClientID %>').innerHTML = '';
            document.getElementById('<%=lblAltManager.ClientID %>').innerHTML = '';
            document.getElementById('<%=lblAltSupervisor.ClientID %>').innerHTML = '';
            document.getElementById('<%=lblMentor.ClientID %>').innerHTML = '';
            document.getElementById('<%=lblAltMentor.ClientID %>').innerHTML = '';

            //End

            document.getElementById('<%=chkEmployee.ClientID %>').checked = false;
            document.getElementById('<%=chkManager.ClientID %>').checked = false;
            document.getElementById('<%=chkCompliance.ClientID %>').checked = false;
            document.getElementById('<%=chkInstructor.ClientID %>').checked = false;
            document.getElementById('<%=chkTrainig.ClientID %>').checked = false;
            document.getElementById('<%=chkAdministrator.ClientID %>').checked = false;
            document.getElementById('<%=chkSystemadmin.ClientID %>').checked = false;
            document.getElementById('<%=chkRehire.ClientID %>').checked = false;


            document.getElementById('<%=txtCustom01.ClientID %>').value = '';
            document.getElementById('<%=txtCustom02.ClientID %>').value = '';
            document.getElementById('<%=txtCustom03.ClientID %>').value = '';
            document.getElementById('<%=txtCustom04.ClientID %>').value = '';
            document.getElementById('<%=txtCustom05.ClientID %>').value = '';
            document.getElementById('<%=txtCustom06.ClientID %>').value = '';
            document.getElementById('<%=txtCustom07.ClientID %>').value = '';
            document.getElementById('<%=txtCustom08.ClientID %>').value = '';
            document.getElementById('<%=txtCustom09.ClientID %>').value = '';
            document.getElementById('<%=txtCustom10.ClientID %>').value = '';
            document.getElementById('<%=txtCustom11.ClientID %>').value = '';
            document.getElementById('<%=txtCustom12.ClientID %>').value = '';
            document.getElementById('<%=txtCustom13.ClientID %>').value = '';

            document.getElementById('<%=success_msg.ClientID %>').style.display = "none";
            document.getElementById('<%=error_msg.ClientID %>').style.display = "none";


            return true;


        }
    </script>
    <script type="text/javascript">

        //Random password generator- 
        var keylist = "abcdefghijklmnopqrstuvwxyz123456789"
        var temp = ''

        function generatepass(plength) {

            temp = ''
            for (i = 0; i < plength; i++)
                temp += keylist.charAt(Math.floor(Math.random() * keylist.length))
            return temp
        }

        function populateform() {
            document.getElementById('<%=txtPassword_login.ClientID %>').value = generatepass("10")
            document.getElementById('<%=success_msg.ClientID %>').style.display = "none";
            document.getElementById('<%=error_msg.ClientID %>').style.display = "none";
            return false;
        }
    </script>
    <script type="text/javascript">
        function checkroles(sender, args) {
            var chkEmployee = document.getElementById('<%=chkEmployee.ClientID %>').checked;
            var chkManager = document.getElementById('<%=chkManager.ClientID %>').checked;
            var chkCompliance = document.getElementById('<%=chkCompliance.ClientID %>').checked;
            var chkInstructor = document.getElementById('<%=chkInstructor.ClientID %>').checked;
            var chkTraining = document.getElementById('<%=chkTrainig.ClientID %>').checked;
            var chkAdmin = document.getElementById('<%=chkAdministrator.ClientID %>').checked;
            var chkSystemAdmin = document.getElementById('<%=chkSystemadmin.ClientID %>').checked;
            if (chkEmployee == false && chkManager == false && chkCompliance == false && chkInstructor == false && chkTraining == false && chkAdmin == false && chkSystemAdmin == false) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
            document.getElementById('<%=success_msg.ClientID %>').style.display = "none";
            document.getElementById('<%=error_msg.ClientID %>').style.display = "none";


        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {

                //Add manager
                $("#<%=btnManager.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?manager=true&page=saau',
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



                //Alternate manager
                $("#<%=btnAltManager.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?altmanager=true&page=saau',
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


                //supervisor
                $("#<%=btnSupervisor.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?supervisor=true&page=saau',
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


                //Alternate supervisor
                $("#<%=btnAltSupervisor.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?altsupervisor=true&page=saau',
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

                //mentor

                $("#<%=btnMentor.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?mentor=true&page=saau',
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
                //alternate mentor
                $("#<%=btnAltMentor.ClientID %>").fancybox({
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
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../sasumsm-01.aspx?altmentor=true&page=saau',
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
        }
       
    </script>
    <script language="javascript" type="text/javascript">
        //Function to Hide ModalPopUp
        function Hidepopup() {
            $find('ContentPlaceHolder1_mpeRemove').hide();
        }
        //Function to Show ModalPopUp
        function Showpopup() {
            $find('ContentPlaceHolder1_mpeRemove').hide();
        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saeu" runat="server"
        ValidationGroup="saeu" />
    <asp:CustomValidator ID="cvSecurityRoles" EnableClientScript="true" ClientValidationFunction="checkroles"
        ValidationGroup="saeu" runat="server" ErrorMessage="<%$ TextResourceExpression: app_security_role_error_empty %>">&nbsp;</asp:CustomValidator>
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
        <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
    </div>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_updated_error_wrong")%>
    </div>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_controls">
            <table class="div_table">
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnSaveuserinfo_header" ValidationGroup="saeu" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_user_information_button_text %>"
                            runat="server" OnClick="btnSaveuserinfo_header_Click" />
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnReset_header" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_header_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel_header" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_header_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_user_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ValidationGroup="saeu"
                            ControlToValidate="txtLastName" ErrorMessage="<%$ TextResourceExpression: app_last_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_last_name_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ValidationGroup="saeu"
                            ControlToValidate="txtFirstName" ErrorMessage="<%$ TextResourceExpression: app_first_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_first_name_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_middle_name_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMiddelName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_user_status_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserstatus" DataTextField="u_status_name" DataValueField="u_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_user_types_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserTypes" DataTextField="u_user_type_name" DataValueField="u_user_type_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_user_domain_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserdomain" DataTextField="u_domain_name" DataValueField="u_domain_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
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
            <%=LocalResources.GetLabel("app_login_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ValidationGroup="saeu"
                            ControlToValidate="txtUsername_login" ErrorMessage="<%$ TextResourceExpression: app_user_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_username_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername_login" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ValidationGroup="saeu"
                            ControlToValidate="txtPassword_login" ErrorMessage="<%$ TextResourceExpression: app_password_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_password_text")%>
                    </td>
                    <td>
                        <input id="txtPassword_login" name="password" runat="server" />
                        <%--<asp:TextBox ID="txtPassword_login"   CssClass="textbox_manage_user" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>
                        <asp:Button ID="btnGenerate" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_generate_button_text %>"
                            OnClick="btnGenerate_Click" OnClientClick=" return populateform();" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnResetNotify" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_notify_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_contact_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_email_address_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailAddress" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_work_phone_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWorkPhone" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_work_extension_text")%>
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
                        <%=LocalResources.GetLabel("app_mobile_number_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobilenumber" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_mobile_type_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMobileType" DataValueField="u_mobile_type_id_pk" DataTextField="u_mobile_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_carrier_text")%>
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
                        <%=LocalResources.GetLabel("app_address_1_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_address_2_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_address_3_text")%>
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
                        <%=LocalResources.GetLabel("app_city_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_state_province_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateprovince" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_zip_postal_code_text")%>
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
                        <%=LocalResources.GetLabel("app_country_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" DataValueField="u_country_id_pk"
                            DataTextField="u_country_name" CssClass="ddl_user_advanced_search">
                        </asp:DropDownList>
                        <%--  <asp:TextBox ID="txtcountry" CssClass="textbox_manage_user" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_locale_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocale" runat="server" CssClass="ddl_user_advanced_search"
                            DataTextField="s_locale_description" DataValueField="s_locale_id_pk">
                        </asp:DropDownList>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_timezone_text")%>
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
            <%=LocalResources.GetLabel("app_security_roles_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_is_employee_text")%>
                    </td>
                    <td class="chkbox_left_side chkbox_td_width">
                        <asp:CheckBox ID="chkEmployee" runat="server" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_is_manager_text")%>
                    </td>
                    <td class="chkbox_left_side chkbox_td_width">
                        <asp:CheckBox ID="chkManager" runat="server" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_is_compliance_text")%>
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkCompliance" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_is_instructor_text")%>
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkInstructor" runat="server" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_is_training_text")%>
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkTrainig" runat="server" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_is_administrator_text")%>
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkAdministrator" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_is_system_admin_text")%>
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkSystemadmin" runat="server" />
                    </td>
                    <td>
                        Is Compliance Approver
                    </td>
                    <td class="chkbox_left_side">
                        <asp:CheckBox ID="chkComplianceApprover" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_hris_information_text")%>
        </div>
        <br />
        <asp:UpdatePanel ID="upnlSaeu" runat="server">
            <ContentTemplate>
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_manager_text")%>
                            </td>
                            <td class="text_align" style="width: 325px;" colspan="2">
                                <asp:Label ID="lblManager" runat="server"></asp:Label>
                                <asp:Button ID="btnManager" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnManagerRemove" CssClass="cursor_hand" Style="display: none;" runat="server"
                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" OnClick="btnManagerRemove_Click" />
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_alt_manager_text")%>
                            </td>
                            <td class="text_align" style="white-space: nowrap;" colspan="2">
                                <asp:Label ID="lblAltManager" runat="server"></asp:Label>
                                <asp:Button ID="btnAltManager" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnRemoveAltManager" CssClass="cursor_hand" Style="display: none;"
                                    runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                    OnClick="btnRemoveAltManager_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_supervisor_text")%>
                            </td>
                            <td class="text_align" colspan="2">
                                <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                                <asp:Button ID="btnSupervisor" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnRemoveSupervisor" CssClass="cursor_hand" Style="display: none;"
                                    runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                    OnClick="btnRemoveSupervisor_Click" />
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_alt_supervisor_text")%>
                            </td>
                            <td class="align_left" style="white-space: nowrap;" colspan="2">
                                <asp:Label ID="lblAltSupervisor" runat="server"></asp:Label>
                                <asp:Button ID="btnAltSupervisor" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnRemoveAltSupervisor" CssClass="cursor_hand" Style="display: none;"
                                    runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                    OnClick="btnRemoveAltSupervisor_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_mentor_text")%>
                            </td>
                            <td class="text_align" colspan="2">
                                <asp:Label ID="lblMentor" runat="server"></asp:Label>
                                <asp:Button ID="btnMentor" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnRemoveMentor" CssClass="cursor_hand" Style="display: none;" runat="server"
                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" OnClick="btnRemoveMentor_Click" />
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_alt_mentor_text")%>
                            </td>
                            <td class="align_left" style="white-space: nowrap;" colspan="2">
                                <asp:Label ID="lblAltMentor" CssClass="cursor_hand" runat="server"></asp:Label>
                                <asp:Button ID="btnAltMentor" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                                <asp:Button ID="btnRemoveAltMentor" CssClass="cursor_hand" Style="display: none;"
                                    runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                    OnClick="btnRemoveAltMentor_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_employee_id_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeid" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_employee_type_text")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEmployeeType" DataValueField="s_employee_type_system_id_pk"
                                    DataTextField="s_employee_type_name" runat="server" CssClass="ddl_user_advanced_search">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_company_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompany" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RegularExpressionValidator ID="reHiredate" runat="server" ControlToValidate="txtHiredate"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                    ErrorMessage="<%$ TextResourceExpression: app_hire_date_error_valid %>" Display="Dynamic"
                                    ValidationGroup="saau">&nbsp;</asp:RegularExpressionValidator>
                                <%=LocalResources.GetLabel("app_hire_date_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHiredate" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="ceHiredate" TargetControlID="txtHiredate" Format="MM/dd/yyyy"
                                    runat="server">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_is_rehire_text")%>
                            </td>
                            <td class="chkbox_left_side">
                                <asp:CheckBox ID="chkRehire" runat="server" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="reLastrehire" runat="server" ControlToValidate="txtHiredate"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                    ErrorMessage="<%$ TextResourceExpression: app_last_hire_date_error_valid %>"
                                    Display="Dynamic" ValidationGroup="saau">&nbsp;</asp:RegularExpressionValidator>
                                <%=LocalResources.GetLabel("app_last_rehire_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastrehire" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="ceLastretire" Format="MM/dd/yyyy" TargetControlID="txtLastrehire"
                                    runat="server">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_region_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegion" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_division_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDivision" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_department_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDepartment" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_cost_center_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcostcenter" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_job_group_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobgroup" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_job_code_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobcode" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_job_title_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobtitle" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_job_position_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobPosition" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_pay_grade_text")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPayGrade" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_01_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom01" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom02" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom03" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_04_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom04" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_05_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom05" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_06_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom06" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom07" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom08" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom09" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom10" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_11_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom11" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_12_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom12" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_13_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom13" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <div class="manage_user_header">
            <br />
        </div>
        <br />
        <div class="label_required_field">
            *
            <%=LocalResources.GetLabel("app_required_fields_text")%>
        </div>
        <br />
        <div class="div_controls">
            <table class="div_table">
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnsaveuserinfo_footer" Text="<%$ LabelResourceExpression: app_save_user_information_button_text %>"
                            runat="server" ValidationGroup="saeu" CssClass="cursor_hand" OnClick="btnsaveuserinfo_footer_Click" />
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnreset_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnreset_footer_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btncancel_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btncancel_footer_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <asp:Button ID="btnRemove" runat="server" Style="display: none;" />
        <asp:Panel ID="pnlRemove" runat="server" CssClass="modalPopupInner_remove" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlRemoveHeading" runat="server" CssClass="drag">
                <div class="headerControl-jaha">
                    <div class="manage_user_header_popup">
                        <%=LocalResources.GetLabel("app_remove_confirmation_text")%>
                        <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                            ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </div>
            </asp:Panel>
            <asp:UpdatePanel runat="server" ID="updatePanel3">
                <ContentTemplate>
                    <br />
                    <br />
                    <div class="remove_heading">
                        <%=LocalResources.GetLabel("app_you_are_about_to_remove_text")%>
                    </div>
                    <div class="remove_content">
                        <table>
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_last_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveLastName" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%=LocalResources.GetLabel("app_first_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveFirstName" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%=LocalResources.GetLabel("app_middle_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveMiddleName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="remove_heading">
                        <%=LocalResources.GetLabel("app_as_the_manager_for_text")%>
                    </div>
                    <div class="remove_content">
                        <table>
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_last_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveLastName2" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%=LocalResources.GetLabel("app_first_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveFristName2" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%=LocalResources.GetLabel("app_middle_name_text")%>
                                </td>
                                <td class="lable_td_width">
                                    <asp:Label ID="lblRemoveMiddleName2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <br>
                                    <br>
                                </td>
                            </tr>
                        </table>
                        <div class="left">
                            <asp:Button ID="btnRemoveSubmit" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_confirm_button_text %>"
                                OnClick="btnRemoveSubmit_Click" />
                        </div>
                        <div class="right">
                            <asp:Button ID="btnRemoveCancel" OnClientClick="Hidepopup();" CssClass="cursor_hand"
                                runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <asp:ModalPopupExtender ID="mpeRemove" runat="server" TargetControlID="btnRemove"
        PopupControlID="pnlRemove" BackgroundCssClass="transparent_class" OkControlID="btnRemoveCancel"
        CancelControlID="imgClose" DropShadow="false" PopupDragHandleControlID="pnlRemoveHeading">
    </asp:ModalPopupExtender>
</asp:Content>
