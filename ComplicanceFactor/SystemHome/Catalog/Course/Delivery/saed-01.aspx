<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saed-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.DeliveryPopup.saed_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 1010px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            //delivery owner
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
                'href': '/SystemHome/sasumsm-01.aspx?deliveryowner=true&page=saed',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            //delivery coordinator
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
                'href': '/SystemHome/sasumsm-01.aspx?deliverycoordiantor=true&page=saed',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            //open session wizard

            $("#<%=btnOpenSessionWizard.ClientID %>").fancybox({
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
                'href': '../Delivery/Session/sasw-01.aspx?page=saes',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });

            //Resource popup
            $("#<%=btnAddResources.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 820,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Delivery/ResourseSearch/saress-01.aspx?page=saed',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            //Material popup
            $("#<%=btnAddMaterials.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 820,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Delivery/MaterialSearch/samats-01.aspx?page=saed',
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
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
    <script language="javascript" type="text/javascript">

        function cleartext() {

            document.getElementById('<%=hdAttachments.ClientID %>').value = '';
            var oFileUpload = document.getElementsByName('<%=FileUpload1.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);


        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteresource").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saed-01.aspx/DeleteResource",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

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

        $(document).ready(function () {

            $(".deletematerial").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saed-01.aspx/DeleteMaterial",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

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

        $(document).ready(function () {

            $(".deletesession").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saed-01.aspx/DeleteSession",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });

            $(".deleteattachment").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saed-01.aspx/DeleteAttachment",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

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
        $(document).ready(function () {

            $(".editsession").click(function () {

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
                    'width': 980,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Delivery/Session/saes-01.aspx?page=saes&editSession=' + record_id,
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
    <!--- Allow Numeri conly-->
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtCreditHours.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#<%=txtCreditUnits.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#<%=txtMinEnroll.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#<%=txtMaxEnroll.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#<%=txtEnrollThreshhold.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#<%=txtMaxwaitList.ClientID %>").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

        });
    </script>
    <script type="text/javascript">
        function checkCopy() {
            document.getElementById('<%=hdCheckCopy.ClientID %>').value = "1";
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtCutoffTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtCutoffTime.ClientID %>").click(
			function () {
			    $("#<%=txtCutoffTime.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtCutoffTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });
            });
        })(jQuery);
    </script>
    <script type="text/javascript">
        function DateCheck(sender, args) {
            var StartDate = document.getElementById('<%=txtAvailableFrom.ClientID %>').value;
            var EndDate = document.getElementById('<%=txtAvailableTo.ClientID %>').value;
            var eDate = new Date(EndDate);
            var sDate = new Date(StartDate);
            if (StartDate != '' && StartDate != '' && sDate > eDate) {
                args.IsValid = false;
            }
        }    
    </script>
    <asp:HiddenField ID="hdCheckCopy" runat="server" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vs_sand" runat="server"
        ValidationGroup="sand"></asp:ValidationSummary>
    <div id="content">
        <div>
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_delivery_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_type_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDeliveryType" DataValueField="s_delivery_type_system_id_pk"
                                DataTextField="s_delivery_type_name" CssClass="textbox_long" runat="server">
                            </asp:DropDownList>
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
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvdeliveryId" runat="server" ValidationGroup="sand"
                                ControlToValidate="txtDeliveyID" ErrorMessage="<%$ TextResourceExpression: app_delivery_id_error_empty%>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_delivery_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeliveyID" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDeliveryTitle" runat="server" ValidationGroup="sand"
                                ControlToValidate="txtDeliveryTitle" ErrorMessage="<%$ TextResourceExpression: app_delivery_title_error_empty%>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_delivery_title_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeliveryTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td colspan="5">
                            <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <%=LocalResources.GetLabel("app_abstract_text")%>:
                        </td>
                        <td colspan="5">
                            <textarea id="txtAbstract" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" class="align_left">
                            <%=LocalResources.GetLabel("app_approval_required_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkApproval" runat="server" />
                            <asp:DropDownList ID="ddlApprovalRequired" CssClass="textbox_long" DataTextField="s_approval_workflow_name"
                                DataValueField="s_approval_workflow_system_id_pk" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_credit_hours_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCreditHours" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_credit_units_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCreditUnits" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_owner_text")%>:
                        </td>
                        <td colspan="3" class="align_left">
                            <asp:Label ID="lblDeliveryOwner" runat="server"></asp:Label>
                            <asp:Button ID="btnOwner" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                        </td>
                        <td colspan="2" class="align_right">
                            <%=LocalResources.GetLabel("app_coordinator_text")%>:
                            <asp:Label ID="lblDeliveryCoordinator" runat="server"></asp:Label>
                            <asp:Button ID="btnCoordinator" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_status_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" DataTextField="c_course_status_name" DataValueField="c_course_status_id"
                                CssClass="textbox_long" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_visible_text")%>:
                        </td>
                        <td class="align_left">
                            <asp:CheckBox ID="chkVisible" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_available_from_text")%>:
                            <asp:RegularExpressionValidator ID="regexAvailableFrom" runat="server" ControlToValidate="txtAvailableFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="<%$ TextResourceExpression: app_available_from_date_error_wrong%>" Display="Dynamic" ValidationGroup="sand">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td class="align_left">
                            <asp:CalendarExtender ID="ceAvailableFrom" Format="MM/dd/yyyy" TargetControlID="txtAvailableFrom"
                                runat="server">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtAvailableFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_available_to_text")%>:
                            <asp:CustomValidator ID="cvValidateDate" EnableClientScript="true" ClientValidationFunction="DateCheck"
                                ValidationGroup="sand" runat="server" ErrorMessage="<%$ TextResourceExpression: app_check_from_and_to_date_error_wrong%>">&nbsp;</asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="regexAvailableTo" runat="server" ControlToValidate="txtAvailableTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="<%$ TextResourceExpression: app_available_to_date_error_wrong%>" Display="Dynamic" ValidationGroup="sand">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:CalendarExtender ID="ceAvailableTo" Format="MM/dd/yyyy" TargetControlID="txtAvailableTo"
                                runat="server">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtAvailableTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_effective_date_text")%>:
                            <asp:RegularExpressionValidator ID="regexEffectiveDate" runat="server" ControlToValidate="txtEffectiveDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="<%$ TextResourceExpression: app_effective_date_error_wrong%>" Display="Dynamic" ValidationGroup="sand">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td class="align_left">
                            <asp:CalendarExtender ID="ceEffectiveDate" Format="MM/dd/yyyy" TargetControlID="txtEffectiveDate"
                                runat="server">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtEffectiveDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_cut_off_date_text")%>:
                            <asp:RegularExpressionValidator ID="regexCutOffDate" runat="server" ControlToValidate="txtCutOffDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="<%$ TextResourceExpression: app_cut_off_date_error_wrong%>" Display="Dynamic" ValidationGroup="sand">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td class="align_left">
                            <asp:CalendarExtender ID="ceCutOffDate" Format="MM/dd/yyyy" TargetControlID="txtCutOffDate"
                                runat="server">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtCutOffDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_cut_off_time_text")%>:
                              <asp:RegularExpressionValidator ID="regexEndTime" runat="server" ControlToValidate="txtCutoffTime"
                                        ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"
                                        ErrorMessage="<%$ TextResourceExpression: app_cut_off_time_error_wrong%>" Display="Dynamic"
                                        ValidationGroup="sand">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCutoffTime" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_min_enroll_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtMinEnroll" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_max_enroll_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtMaxEnroll" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_enroll_threshhold_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnrollThreshhold" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_waiting_list_text")%>:
                            <asp:CheckBox ID="chkWaitingList" runat="server" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_max_waitlist_text")%>
                            #:<asp:TextBox ID="txtMaxwaitList" Width="95px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_session_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <div>
                    <asp:GridView ID="gvSession" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                        CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_session_system_id_pk"
                        runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSession_RowDataBound"
                        OnRowCommand="gvSession_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="horizontal_line" colspan="5">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="gridview_row_width_300">
                                                <asp:Label ID="lblSession1" runat="server"></asp:Label>
                                            </td>
                                            <td class="gridview_row_width_300">
                                                <asp:Label ID="lblSession2" runat="server"></asp:Label>
                                            </td>
                                            <td class="gridview_row_width_1" align="center">
                                                <input type="button" id='<%# Eval("c_session_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                                    class="editsession cursor_hand" />
                                            </td>
                                            <td class="gridview_row_width_1" align="center">
                                                <asp:Button ID="btnCopy" runat="server" CommandName='Copy' CommandArgument='<%#DataBinder.Eval(Container,"RowIndex") %>'
                                                    OnClientClick='javascript:checkCopy();' Text="<%$ LabelResourceExpression:app_copy_button_text %>" />
                                            </td>
                                            <td class="gridview_row_width_1" align="center">
                                                <input type="button" id='<%# Eval("c_session_system_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                                    class="deletesession cursor_hand" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="div_control_normal">
                <asp:Button ID="btnOpenSessionWizard" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_open_session_wizard_button_text%>" />
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_resources_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <div>
                    <asp:GridView ID="gvResources" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                        CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="horizontal_line" colspan="3">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="gridview_row_width_300">
                                                <%#Eval("c_resource_name")%><br />
                                                <%# "(" + Eval("c_resource_id_pk") + ")"%>
                                            </td>
                                            <td class="gridview_row_width_300">
                                                <%#Eval("c_resource_description")%><br />
                                                <%# "(" + Eval("c_resource_serial_number") + ")"%>
                                            </td>
                                            <%--  <td class="gridview_row_width_1" align="center">
                                            <input type="button" id='<%# Eval("c_resource_system_id_pk") %>' value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                                class="editresource cursor_hand" />
                                        </td>--%>
                                            <td class="gridview_row_width_1" align="center">
                                                <input type="button" id='<%# Eval("c_resource_system_id_pk") %>' value='<asp:Literal ID="Literal4" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                                    class="deleteresource cursor_hand" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div class="div_control_normal">
                <asp:Button ID="btnAddResources" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_resources_button_text%>" />
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_materials_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <div>
                    <asp:GridView ID="gvMaterials" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                        CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="horizontal_line" colspan="3">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="gridview_row_width_300">
                                                <%#Eval("c_material_name")%><br />
                                                <%# "(" + Eval("c_material_id_pk") + ")"%>
                                            </td>
                                            <td class="gridview_row_width_300">
                                                <%#Eval("c_material_description")%>
                                            </td>
                                            <%-- <td class="gridview_row_width_1" align="center">
                                            <input type="button" id='<%# Eval("c_material_system_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                                class="editmaterial cursor_hand" />
                                        </td>--%>
                                            <td class="gridview_row_width_1" align="center">
                                                <input type="button" id='<%# Eval("c_material_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                                    class="deletematerial cursor_hand" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div class="div_control_normal">
                <asp:Button ID="btnAddMaterials" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_material_button_text%>" />
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_non_conformant_aicc_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <table>
                    <tr>
                        <td align="right">
                            <%=LocalResources.GetLabel("app_url_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNCUrl" CssClass="textarea_long_2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_launch_parameters_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNcLaunchParameter" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <%=LocalResources.GetLabel("app_non_conformant_text")%>:
                        </td>
                        <td>
                            <asp:CheckBox ID="chkNcWaitList" runat="server" />&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlNcWrapper" CssClass="ddl_user_advanced_search" DataValueField="s_wrapper_system_id_pk"
                                DataTextField="s_wrapper_name" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_scorm_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <table>
                    <tr>
                        <td align="right">
                            <%=LocalResources.GetLabel("app_url_text")%>:
                            <asp:TextBox ID="txtScormUrl" CssClass="textarea_long_2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_launch_parameters_text")%>:
                            <asp:TextBox ID="txtScromLaunchParameters" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_vls_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_url_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVlsUrl" CssClass="textarea_long_3" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_scoring_scheme_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <asp:DropDownList ID="ddlScoringScheme" DataTextField="s_grading_scheme_english_us_name"
                    DataValueField="s_grading_scheme_system_id_pk" CssClass="textbox_long" runat="server">
                </asp:DropDownList>
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_attachments_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <asp:GridView ID="gvAddDeliveryAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_delivery_attachment_file_guid,c_delivery_attachment_file_name,c_delivery_attachment_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvAddDeliveryAttachments_RowCommand"
                    OnRowEditing="gvAddDeliveryAttachments_RowEditing">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("c_delivery_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnViewWitnessFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnEditWitnessFiles" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnRemoveWitnessFiles" OnClientClick="return confirmremove();" CommandName="Remove"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                    Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="div_control_normal">
                <asp:Button ID="btnAddAttachment" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_attachment_button_text%>" />
            </div>
            <br />
            <div class="div_header_1005">
                <%=LocalResources.GetLabel("app_custom_fields_text")%>:
            </div>
            <br />
            <div class="div_control_normal">
                <table cellpadding="3" cellspacing="2">
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_01_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom01" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_02_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom02" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_03_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom03" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_04_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom04" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_05_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom05" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_06_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom06" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_07_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom07" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_08_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom08" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_08_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom09" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_10_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom10" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_11_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom11" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_12_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom12" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_13_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCustom13" CssClass="textbox_long" runat="server"></asp:TextBox>
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
            <br />
            <div class="div_header_1005">
                &nbsp;
            </div>
            <br />
            <div class="div_control_normal">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="align_left">
                            <asp:Button ID="btnSave" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_save_button_text%>"
                                OnClick="btnSave_Click" ValidationGroup="sand" />
                        </td>
                        <td class="align_center">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
                                OnClick="btnReset_Click" />
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
        </div>
        <asp:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnAddAttachment"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background"
            Style="display: none; padding-left: 0px; padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <div class="uploadpopup_header">
                        <div class="left">
                            <%=LocalResources.GetLabel("app_upload_file_text")%>:
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
                <div class="uploadpanel">
                    <%=LocalResources.GetLabel("app_select_file_text")%>:
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="525" size="70" />
                    <br />
                    <br />
                    <br />
                    <div class="uploadbutton">
                        <asp:Button ID="btnUploadAttachements" runat="server" Text="<%$ LabelResourceExpression: app_upload_text%>"
                            OnClick="btnUploadattachments_Click" CssClass="cursor_hand" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
