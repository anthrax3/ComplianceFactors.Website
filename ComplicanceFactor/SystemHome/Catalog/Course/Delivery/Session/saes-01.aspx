<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="saes-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.DeliveryPopup.saes_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <%-- <script src="../../../Scripts/JQuery.Zoom.js" type="text/javascript"></script>--%>
    <%--<link href="../../../Scripts/JQuery.Zoom.Style.css" rel="stylesheet" type="text/css" />--%>
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
                'href': '../Session/LocationSearch/salocs-01.aspx?page=saed',
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
                'href': '../Session/FacilitySearch/safacs-01.aspx?page=saed',
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
                'href': '../Session/RoomSearch/sarms-01.aspx?page=saed',
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
                'href': '../Session/InstructorSearch/sainss-01.aspx?page=saed',
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
                        url: "saes-01.aspx/DeleteInstructor",

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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </asp:ToolkitScriptManager>
    <div class="div_header_940">
        <%=LocalResources.GetLabel("app_session_text")%>:
    </div>
    <div class="div_controls font_1">
        <asp:CustomValidator ID="cvValidateDate" EnableClientScript="true" ClientValidationFunction="DateCheck"
            ValidationGroup="saes" runat="server" ErrorMessage="Please select the end date as greater than start date">&nbsp;</asp:CustomValidator>
        <asp:ValidationSummary CssClass="validation_summary_error" ID="vs_sand" runat="server"
            ValidationGroup="saes"></asp:ValidationSummary>
        <br />
        <table>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionId" runat="server" ValidationGroup="saes"
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
                    <asp:RequiredFieldValidator ID="rfvSessionTitle" runat="server" ValidationGroup="saes"
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
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="saes"
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
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionStartDate" runat="server" ValidationGroup="saes"
                        ControlToValidate="txtStartDate" ErrorMessage="<%$ TextResourceExpression: app_start_date_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexStartDate" runat="server" ControlToValidate="txtStartDate"
                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                        ErrorMessage="<%$ TextResourceExpression: app_invalid_start_date_error_wrong%>"
                        Display="Dynamic" ValidationGroup="saes">&nbsp;</asp:RegularExpressionValidator>
                    *
                    <%=LocalResources.GetLabel("app_start_date_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox_long"></asp:TextBox>
                    <asp:CalendarExtender ID="ceStartDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtStartDate">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionEndDate" runat="server" ValidationGroup="saes"
                        ControlToValidate="txtEndDate" ErrorMessage="<%$ TextResourceExpression: app_end_date_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexEndDate" runat="server" ControlToValidate="txtEndDate"
                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                        ErrorMessage="<%$ TextResourceExpression: app_invalid_end_date_error_wrong%>"
                        Display="Dynamic" ValidationGroup="saes">&nbsp;</asp:RegularExpressionValidator>
                    *
                    <%=LocalResources.GetLabel("app_end_date_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox_long"></asp:TextBox>
                    <asp:CalendarExtender ID="ceEndDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtEndDate">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionStartTime" runat="server" ValidationGroup="saes"
                        ControlToValidate="txtStartTime" ErrorMessage="<%$ TextResourceExpression: app_start_time_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvStartChecktime" EnableClientScript="true" ClientValidationFunction="Checktime"
                        ValidationGroup="saes" runat="server" ErrorMessage="<%$ TextResourceExpression: app_check_time_error_empty%>">&nbsp;</asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="regexStartTime" runat="server" ControlToValidate="txtStartTime"
                        ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"
                        ErrorMessage="<%$ TextResourceExpression: app_check_start_time_format_error_wrong%>"
                        Display="Dynamic" ValidationGroup="saes">&nbsp;</asp:RegularExpressionValidator>
                    *
                    <%=LocalResources.GetLabel("app_start_time_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtStartTime" CssClass="textbox_75" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionEndTime" runat="server" ValidationGroup="saes"
                        ControlToValidate="txtEndTime" ErrorMessage="<%$ TextResourceExpression: app_end_time_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexEndTime" runat="server" ControlToValidate="txtEndTime"
                        ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"
                        ErrorMessage="<%$ TextResourceExpression: app_check_end_time_format_error_wrong%>"
                        Display="Dynamic" ValidationGroup="saes">&nbsp;</asp:RegularExpressionValidator>
                    *
                    <%=LocalResources.GetLabel("app_end_time_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtEndTime" CssClass="textbox_75" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSessionDuration" runat="server" ValidationGroup="saes"
                        ControlToValidate="txtDuration" ErrorMessage="<%$ TextResourceExpression: app_duration_error_empty%>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexDuration" runat="server" ControlToValidate="txtDuration"
                        ValidationExpression="(^([0-9]|[0-1][0-9]|[2][0-3]):([0-5][0-9])$)|(^([0-9]|[1][0-9]|[2][0-3])$)"
                        ErrorMessage="<%$ TextResourceExpression: app_check_duration_time_format_error_wrong%>"
                        Display="Dynamic" ValidationGroup="saes">&nbsp;</asp:RegularExpressionValidator>
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
                AutoGenerateColumns="False" onrowdatabound="gvInstructor_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="horizontal_line" colspan="4">
                                        <hr>
                                    </td>
                                </tr>
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
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="btnAddInstructor" runat="server" Text="<%$ LabelResourceExpression: app_add_instructor_button_text %>" />
    </div>
    <br />
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
                    <asp:Button ID="btnSaveSessionInformation" ValidationGroup="saes" CssClass="cursor_hand"
                        runat="server" Text="<%$ LabelResourceExpression: app_save_session_information_text %>"
                        OnClick="btnSaveSessionInformation_Click" />
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
</asp:Content>
