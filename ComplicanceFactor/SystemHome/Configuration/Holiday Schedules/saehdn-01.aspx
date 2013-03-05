<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saehdn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules.saehdn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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

            var editScheduleId = $('input#<%=hdScheduleId.ClientID %>').val();

            $("#<%=btnAddNewHoliday.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 740,
                'height': 400,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'p-sahs-01.aspx?mode=edit&page=saehdn' + "&editScheduleId=" + editScheduleId,
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
            //edit locale
            $(".editHoliday").click(function () {

                //Get the Id of the record to edit
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
                    'height': 400,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'p-sehs-01.aspx?mode=edit&page=saehdn' + "&holidayid=" + record_id,
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

            $(".removeHoliday").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saehdn-01.aspx/DeleteHoliday",

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
    <br />
    <asp:HiddenField ID="hdScheduleId" runat="server" />
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saehdn" runat="server"
        ValidationGroup="saehdn"></asp:ValidationSummary>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveHolidaySchedule" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" ValidationGroup="saehdn" OnClick="btnHeaderSaveHolidaySchedule_Click" />
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
            <%=LocalResources.GetLabel("app_holiday_schedule_info_button_text")%>: 
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvScheduleId" runat="server" ValidationGroup="saehdn"
                            ControlToValidate="txtScheduleId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_schedule_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtScheduleId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvScheduleName" runat="server" ValidationGroup="saehdn"
                            ControlToValidate="txtScheduleName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_schedule_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtScheduleName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="saehdn"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
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
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_holiday_day_text")%>: 
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvHoliday" RowStyle-CssClass="record" CssClass="grid_700" runat="server"
                GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_300">
                        <ItemTemplate>
                            <%#Eval("u_holiday_name") + "(" + Eval("u_holiday_date") + ")"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("u_holiday_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                class="editHoliday cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("u_holiday_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                class="removeHoliday cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Button ID="btnAddNewHoliday" runat="server" Text="<%$ LabelResourceExpression: app_add_new_holiday_button_text %>" />
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
                        <asp:Button ID="btnFooterSaveHolidaySchedule" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" ValidationGroup="saehdn" OnClick="btnFooterSaveHolidaySchedule_Click" />
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
        <br />
    </div>
</asp:Content>
