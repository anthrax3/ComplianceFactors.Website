<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sasw-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Popup.sasw_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 960px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <%--    Hide/Show Div Tag based on recurrance selected value--%>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtStartTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });



            });
        })(jQuery);

        (function ($) {
            $(function () {
                $('#<%=txtEndTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });

            });
        })(jQuery);


        (function ($) {
            $(function () {
                $('#<%=txtDuration.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm' });

            });
        })(jQuery);

    </script>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=txtEndTime.ClientID %>').change(function () {
                if ($('#<%=txtStartTime.ClientID %>').val() != "") {
                    Setduration();

                }
            });



        });
    </script>--%>
    <%--<script type="text/javascript">
        function Setduration() {
            if ($('#<%=txtStartTime.ClientID %>').val() != "" && $('#<%=txtEndTime.ClientID %>').val()) {
                var start_actual_time = "01/17/2012 " + $('#<%=txtStartTime.ClientID %>').val();
                var end_actual_time = "01/17/2012 " + $('#<%=txtEndTime.ClientID %>').val();

                start_actual_time = new Date(start_actual_time);
                end_actual_time = new Date(end_actual_time);

                var diff = end_actual_time - start_actual_time;

                var diffSeconds = diff / 1000;
                var HH = Math.floor(diffSeconds / 3600);
                var MM = Math.floor(diffSeconds % 3600) / 60;

                var formatted = ((HH < 10) ? ("0" + HH) : HH) + ":" + ((MM < 10) ? ("0" + MM) : MM)
                $('#<%=txtDuration.ClientID %>').val(formatted);
            }
        }
    </script>--%>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#RadioDiv input').click(function () {
                var selectedValue = $("#RadioDiv input:radio:checked").val();

                //clear recurrance pattern

                //daily
                $("#<%=txtRecurranceEveryDaily.ClientID %>").val('');
                $("#<%=chkRespectWeekDays.ClientID %>").prop("checked", false);
                $("#<%=chkRespectHolidays.ClientID %>").prop("checked", false);

                //weekly
                $("#<%=txtRecurranceEveryWeekly.ClientID %>").val('');

                $("#<%=chkWeeklyLst.ClientID %>").find(':checked').each(function () {
                    $(this).removeAttr('checked');
                });

                //monthly
                $("#<%=ddlMonths.ClientID %>")[0].selectedIndex = 0;
                $("#<%=ddlDays.ClientID %>")[0].selectedIndex = 0;
                $("#<%=txtRecurranceEveryMonthly.ClientID %>").val('');

                //yearly
                $("#<%=txtRecurranceEveryYearly.ClientID %>").val('');
                $("#<%=txtYearly.ClientID %>").val('');


                if (selectedValue == 'daily') {
                    $('#divDaily').css("display", "block");
                    $('#divWeekly').css("display", "none");
                    $('#divMonthly').css("display", "none");
                    $('#divYearly').css("display", "none");

                }
                else if (selectedValue == 'weekly') {
                    $('#divDaily').css("display", "none");
                    $('#divWeekly').css("display", "block");
                    $('#divMonthly').css("display", "none");
                    $('#divYearly').css("display", "none");
                }
                else if (selectedValue == 'monthly') {
                    $('#divDaily').css("display", "none");
                    $('#divWeekly').css("display", "none");
                    $('#divMonthly').css("display", "block");
                    $('#divYearly').css("display", "none");
                }
                else if (selectedValue == 'yearly') {
                    $('#divDaily').css("display", "none");
                    $('#divWeekly').css("display", "none");
                    $('#divMonthly').css("display", "none");
                    $('#divYearly').css("display", "block");

                }

            });
        }); 
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtStartTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtStartTime.ClientID %>").click(
			function () {
			    $("#<%=txtStartTime.ClientID %>")[0].focus();
			}
		);
        });
        $(function () {
            $("#<%=txtEndTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtEndTime.ClientID %>").click(
			function () {
			    $("#<%=txtEndTime.ClientID %>")[0].focus();
			}
		);
        });
        $(function () {
            $("#<%=txtDuration.ClientID %>").watermark("HH:MM");
            $("#<%=txtDuration.ClientID %>").click(
			function () {
			    $("#<%=txtDuration.ClientID %>")[0].focus();
			    // Setduration();
			}
		);
        });
    </script>
    <script type="text/javascript">
        //location search popup
        $(document).ready(function () {

            $("#<%=btnLocation.ClientID %>").fancybox({
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
                'href': '../Session/LocationSearch/salocs-01.aspx?page=sand',
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
            //facility search popup
            $("#<%=btnFacility.ClientID %>").fancybox({
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
                'href': '../Session/FacilitySearch/safacs-01.aspx?page=sand',
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

            //room search popup
            $("#<%=btnRoom.ClientID %>").fancybox({
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
                'href': '../Session/RoomSearch/sarms-01.aspx?page=sand',
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

            //Instructor popup
            $("#<%=btnAddInstructor.ClientID %>").fancybox({
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
                'href': '../Session/InstructorSearch/sainss-01.aspx?page=sand',
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
    <script type="text/javascript">

        function Checktime(sender, args) {
            var txtStartTime = document.getElementById('<%=txtStartTime.ClientID %>').value;
            var txtEndTime = document.getElementById('<%=txtEndTime.ClientID %>').value;
            var selectedValue = $("#RadioDiv input:radio:checked").val();
            if (txtStartTime != '' && txtEndTime == '') {

                args.IsValid = false;

            }
            else if (txtStartTime == '' && txtEndTime != '') {
                args.IsValid = false;
            }


            else if (txtStartTime == '' && txtEndTime == '') {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateTimeandDate(sender, args) {
            var selectedValue = $("#RadioDiv input:radio:checked").val();
            if (selectedValue == 'daily' || selectedValue == 'weekly' || selectedValue == 'monthly' || selectedValue == 'yearly') {
                if ($('#<%=txtStartTime.ClientID %>').val() == "" || $('#<%=txtEndTime.ClientID %>').val() == "" || $('#<%=txtStartDate.ClientID %>').val() == "" || $('#<%=txtEndDate.ClientID %>').val() == "") {
                    args.IsValid = false;
                }


                else {
                    args.IsValid = true;

                }
            }
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteinstructor").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "sasw-01.aspx/DeleteInstructor",

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
        function RangeOfReccurence() {
            var rad1 = document.getElementById("<%=rbNoEndDate.ClientID %>");
            var rad2 = document.getElementById("<%=rbEndAfter.ClientID %>");
            var rad3 = document.getElementById("<%=rbEndBy.ClientID %>");
            if (rad1.checked) {
                document.getElementById("<%=txtBreakOccurranceDate.ClientID %>").disabled = true;
                document.getElementById("<%=txtBreakOccurencesCount.ClientID %>").disabled = true;
                document.getElementById("<%=txtBreakOccurencesCount.ClientID %>").value = '';
                document.getElementById("<%=txtBreakOccurranceDate.ClientID %>").value = '';

            }
            else if (rad2.checked) {
                document.getElementById("<%=txtBreakOccurranceDate.ClientID %>").value = '';
                document.getElementById("<%=txtBreakOccurranceDate.ClientID %>").disabled = true;
                document.getElementById("<%=txtBreakOccurencesCount.ClientID %>").disabled = false;
            }
            else if (rad3.checked) {
                document.getElementById("<%=txtBreakOccurencesCount.ClientID %>").value = '';
                document.getElementById("<%=txtBreakOccurencesCount.ClientID %>").disabled = true;
                document.getElementById("<%=txtBreakOccurranceDate.ClientID %>").disabled = false;
            }

        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            RangeOfReccurence();
        }
    </script>
    <!--- Allow Numeri conly-->
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtBreakOccurencesCount").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#txtRecurranceEveryDaily").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#txtRecurranceEveryWeekly").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#txtRecurranceEveryMonthly").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#txtRecurranceEveryYearly").keypress(function (e) {

                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

        });
    </script>
    <script type="text/javascript">
        function DateCheck(sender, args) {
            var StartDate = document.getElementById('<%=txtStartDate.ClientID %>').value;
            var EndDate = document.getElementById('<%=txtEndDate.ClientID %>').value;
            var eDate = new Date(EndDate);
            var sDate = new Date(StartDate);
            if (StartDate != '' && StartDate != '' && sDate > eDate) {
                args.IsValid = false;
            }
        }
    
    </script>
    <script type="text/javascript">
        function stop_rebind_for_instructor(id) {
            if (id == "ContentPlaceHolder1_btnGenerateSession") {
                var gridView = document.getElementById('<%= gvInstructor.ClientID %>');
                if (gridView.rows.length > 0) {
                    document.getElementById('<%=hdValue.ClientID %>').value = "0";
                }
            }           
        }
    </script>    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vs_sasw" runat="server"
        ValidationGroup="sasw"></asp:ValidationSummary>
    <asp:HiddenField ID="hdValue" runat="server" />
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div id="content">
        <div>
            <div class="div_header_940">
                <%=LocalResources.GetLabel("app_session_text")%>:
            </div>
        </div>
        <div class="div_controls font_1">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSessionId" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSessionTitle" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_title_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5" valign="top" class="align_left">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <div class="div_control_normal font_1">
            <table>
                <tr>
                    <td class="align_right" style="width: 110px;">
                        <asp:CustomValidator ID="cvValidateDate" EnableClientScript="true" ClientValidationFunction="DateCheck"
                            ValidationGroup="sasw" runat="server" ErrorMessage="Please select the end date as greater than start date">&nbsp;</asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="rfvSessionStartDate" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtStartDate" ErrorMessage="<%$ TextResourceExpression: app_start_date_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_start_date_text")%>:
                    </td>
                    <td style="width: 110px;">
                        <asp:RegularExpressionValidator ID="regexStartDate" runat="server" ControlToValidate="txtStartDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_invalid_start_date_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox_long"></asp:TextBox>
                        <asp:CalendarExtender ID="ceStartDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtStartDate">
                        </asp:CalendarExtender>
                    </td>
                    <td style="width: 110px;">
                        &nbsp;
                    </td>
                    <td style="width: 110px;">
                        &nbsp;
                    </td>
                    <td class="align_right" style="width: 110px;">
                        <asp:RequiredFieldValidator ID="rfvSessionEndDate" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtEndDate" ErrorMessage="<%$ TextResourceExpression: app_end_date_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_end_date_text")%>:
                    </td>
                    <td style="width: 110px;">
                        <asp:RegularExpressionValidator ID="regexEndDate" runat="server" ControlToValidate="txtEndDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_invalid_end_date_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox_long"></asp:TextBox>
                        <asp:CalendarExtender ID="ceEndDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtEndDate">
                        </asp:CalendarExtender>
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSessionStartTime" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtStartTime" ErrorMessage="<%$ TextResourceExpression: app_start_time_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvStartChecktime" EnableClientScript="true" ClientValidationFunction="Checktime"
                            ValidationGroup="sasw" runat="server" ErrorMessage="<%$ TextResourceExpression: app_check_time_error_empty%>">&nbsp;</asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="regexStartTime" runat="server" ControlToValidate="txtStartTime"
                            ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"
                            ErrorMessage="<%$ TextResourceExpression: app_check_start_time_format_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_start_time_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtStartTime" CssClass="textbox_75" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSessionEndTime" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtEndTime" ErrorMessage="<%$ TextResourceExpression: app_end_time_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexEndTime" runat="server" ControlToValidate="txtEndTime"
                            ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"
                            ErrorMessage="<%$ TextResourceExpression: app_check_end_time_format_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_end_time_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtEndTime" CssClass="textbox_75" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSessionDuration" runat="server" ValidationGroup="sasw"
                            ControlToValidate="txtDuration" ErrorMessage="<%$ TextResourceExpression: app_duration_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexDuration" runat="server" ControlToValidate="txtDuration"
                            ValidationExpression="(^([0-9]|[0-1][0-9]|[2][0-3]):([0-5][0-9])$)|(^([0-9]|[1][0-9]|[2][0-3])$)"
                            ErrorMessage="<%$ TextResourceExpression: app_check_duration_time_format_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_duration_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox_50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_location_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        <asp:Button ID="btnLocation" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_facility_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblFacility" runat="server"></asp:Label>
                        <asp:Button ID="btnFacility" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_room_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblRoom" runat="server"></asp:Label>
                        <asp:Button ID="btnRoom" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_940">
            <%=LocalResources.GetLabel("app_instructor_text")%>:
        </div>
        <br />
        <div class="div_control_normal">
            <div>
                <asp:GridView ID="gvInstructor" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                    AutoGenerateColumns="False" OnRowDataBound="gvInstructor_RowDataBound" DataKeyNames="c_user_id_fk">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="horizontal_line" colspan="4">
                                            <hr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="gridview_row_width_300">
                                            <%#Eval("c_instructor_name")%>
                                        </td>
                                        <%--<td class="gridview_row_width_1" align="center">
                                        <input type="button" id='<%# Eval("c_instructor_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                            class="editinstructor cursor_hand" />
                                    </td>--%>
                                        <td class="align_left">
                                            <asp:DropDownList ID="ddlInstrcdtorType" runat="server" DataTextField="s_instructor_type_name"
                                                DataValueField="s_instructor_type_system_id_pk" />
                                        </td>
                                        <td class="gridview_row_width_3">
                                        </td>
                                        <td class="gridview_row_width_1" align="center">
                                            <input type="button" id='<%# Eval("c_instructor_system_id_pk") %>' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                                class="deleteinstructor cursor_hand" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:Button ID="btnAddInstructor"  runat="server" Text="<%$ LabelResourceExpression: app_add_instructor_button_text %>" />
        </div>
        <br />
        <div class="div_header_940">
            <%=LocalResources.GetLabel("app_recurrance_pattern_text")%>:
        </div>
        <br />
        <div class="div_control_normal left divwidth_270">
            <div id="RadioDiv">
                <asp:RadioButtonList ID="rbtnRecurrancePattern" runat="server" RepeatDirection="Vertical"
                    RepeatColumns="1">
                    <asp:ListItem Text="Daily" Selected="True" Value="daily"></asp:ListItem>
                    <asp:ListItem Text="Weekly" Value="weekly"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="monthly"></asp:ListItem>
                    <asp:ListItem Text="Yearly" Value="yearly"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
        </div>
        <div class="div_control_normal left">
            <%--  daily --%>
            <div id="divDaily">
                <table class="no_wrap">
                    <tr>
                        <td>
                            Recurrance Every
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecurranceEveryDaily" CssClass="textbox_50" runat="server"></asp:TextBox>
                            Day(s)
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:CheckBox ID="chkRespectWeekDays" runat="server" Text="Respect Weekdays" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRespectWeekDays" runat="server" CssClass="ddl_user_advanced_search"
                                DataTextField="s_weekday_schedule_name" DataValueField="s_weekday_schedule_system_id_pk">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:CheckBox ID="chkRespectHolidays" runat="server" Text="Respect Holidays" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRespectHolidays" runat="server" CssClass="ddl_user_advanced_search"
                                DataTextField="u_holiday_schedule_name" DataValueField="u_holiday_schedule_system_id_pk">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <%--     End daily--%>
            <%--  weekly--%>
            <div id="divWeekly" style="display: none;">
                <table class="no_wrap">
                    <tr>
                        <td>
                            Recurrance Every
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecurranceEveryWeekly" CssClass="textbox_50" runat="server"></asp:TextBox>
                            Week(s) on:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBoxList ID="chkWeeklyLst" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Sunday" Value="sunday"></asp:ListItem>
                                <asp:ListItem Text="Monday" Value="monday"></asp:ListItem>
                                <asp:ListItem Text="Tuesday" Value="tuesday"></asp:ListItem>
                                <asp:ListItem Text="Wednesday" Value="wednesday"></asp:ListItem>
                                <asp:ListItem Text="Thursday" Value="thursday"></asp:ListItem>
                                <asp:ListItem Text="Friday" Value="friday"></asp:ListItem>
                                <asp:ListItem Text="Saturday" Value="saturday"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </div>
            <%--End weekly--%>
            <%--    Monthly--%>
            <div id="divMonthly" style="display: none;">
                <table>
                    <tr>
                        <td colspan="6" class="no_wrap">
                            <asp:DropDownList ID="ddlMonths" runat="server">
                                <asp:ListItem Text="First" Value="first">
                                </asp:ListItem>
                                <asp:ListItem Text="Second" Value="second">
                                </asp:ListItem>
                                <asp:ListItem Text="Third" Value="third">
                                </asp:ListItem>
                                <asp:ListItem Text="Fourth" Value="fourth">
                                </asp:ListItem>
                                <asp:ListItem Text="Last" Value="last">
                                </asp:ListItem>
                            </asp:DropDownList>
                            Day
                            <asp:DropDownList ID="ddlDays" runat="server">
                                <asp:ListItem Text="Sunday" Value="sunday"></asp:ListItem>
                                <asp:ListItem Text="Monday" Value="monday"></asp:ListItem>
                                <asp:ListItem Text="Tuesday" Value="tuesday"></asp:ListItem>
                                <asp:ListItem Text="Wednesday" Value="wednesday"></asp:ListItem>
                                <asp:ListItem Text="Thursday" Value="thursday"></asp:ListItem>
                                <asp:ListItem Text="Friday" Value="friday"></asp:ListItem>
                                <asp:ListItem Text="Saturday" Value="saturday"></asp:ListItem>
                            </asp:DropDownList>
                            of every
                            <asp:TextBox ID="txtRecurranceEveryMonthly" CssClass="textbox_50" runat="server"></asp:TextBox>
                            month(s).
                        </td>
                    </tr>
                </table>
            </div>
            <%--   End monthly--%>
            <%--  Yearly--%>
            <div id="divYearly" style="display: none;">
                <table>
                    <tr>
                        <td>
                            Recurrance Every
                            <asp:RegularExpressionValidator ID="regexYearly" runat="server" ControlToValidate="txtYearly"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                ErrorMessage="Invalid yearly date." Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        </td>
                        <td colspan="5" class="no_wrap">
                            <asp:TextBox ID="txtRecurranceEveryYearly" CssClass="textbox_50" runat="server"></asp:TextBox>
                            Years on
                            <asp:TextBox ID="txtYearly" CssClass="textbox_75" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceYearly" Format="MM/dd/yyyy" TargetControlID="txtYearly"
                                runat="server">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </div>
            <%--  End yearly--%>
        </div>
        <div class="clear">
        </div>
        <div class="div_header_940">
            <%=LocalResources.GetLabel("app_range_of_recurrance_text")%>:
        </div>
        <br />
        <div class="div_control_normal left divwidth_380">
            Start:
            <asp:RegularExpressionValidator ID="regexStart" runat="server" ControlToValidate="txtStartFrom"
                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                ErrorMessage="<%$ TextResourceExpression: app_invalid_recurr_start_date_error_wrong%>"
                Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
            <asp:TextBox ID="txtStartFrom" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="ceStart" Format="MM/dd/yyyy" TargetControlID="txtStartFrom"
                runat="server">
            </asp:CalendarExtender>
        </div>
        <div class="div_control_normal">
            <table>
                <tr>
                    <td>
                        <asp:RadioButton ID="rbNoEndDate" Checked="true" onclick="RangeOfReccurence()" GroupName="recurrance"
                            runat="server" Text="No end Date" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="rbEndAfter" onclick="RangeOfReccurence()" GroupName="recurrance"
                            runat="server" Text="End After:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtBreakOccurencesCount" CssClass="textbox_50" runat="server" />&nbsp;&nbsp;Occurences
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="rbEndBy" onclick="RangeOfReccurence()" GroupName="recurrance"
                            runat="server" Text="End By:" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="regexEndByDate" runat="server" ControlToValidate="txtBreakOccurranceDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_invalid_end_by_date_error_wrong%>"
                            Display="Dynamic" ValidationGroup="sasw">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtBreakOccurranceDate" runat="server" />
                        <asp:CalendarExtender ID="ceEndByDate" Format="MM/dd/yyyy" runat="server" TargetControlID="txtBreakOccurranceDate">
                        </asp:CalendarExtender>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <div class="div_header_940">
            &nbsp;
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td align="left"> 
                        <asp:Button ID="btnGenerateSession"  CssClass="cursor_hand" ValidationGroup="sasw" Onclientclick="javascript:stop_rebind_for_instructor(this.id)"
                            runat="server" Text="<%$ LabelResourceExpression: app_generatr_session_button_text %>"
                              OnClick="btnGenerateSession_Click"/>
                    </td>
                    <td class="textbox_long">
                        &nbsp;
                    </td>
                    <td class="textbox_long">
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Click" />
                    </td>
                    <td class="textbox_long">
                        &nbsp;
                    </td>
                    <td class="textbox_long">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
