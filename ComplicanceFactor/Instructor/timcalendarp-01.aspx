<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="timcalendarp-01.aspx.cs" Inherits="ComplicanceFactor.Instructor.timcalendarp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="ECalendar" Namespace="ExtendedControls" Assembly="EventCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_instructor').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_instructor').addClass('selected');
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".baselink").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                //var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 1040,
                    'height': 550,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'tiddv-01.aspx?deliveryId=' + record_id,
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area">
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_instructor_calendar_text")%><br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_calendar_text")%>:
        <div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_print_to_pdf_button_text %>"
                OnClick="btnPrintPdf_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div>
        <div class="div_padding_40">
            <div class="div_padding_40 font_1">
                <table class="paging_popup_1">
                    <tr>
                        <td>
                            <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_month_button_text %>"
                                OnClick="btnHeaderPrevious_Click" />
                        </td>
                        <td class="align_right">
                            <%=LocalResources.GetLabel("app_showing_text")%>:
                            <asp:DropDownList ID="ddlHeaderMonth" runat="server">
                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="align_center">
                            <%=LocalResources.GetLabel("app_for_text")%>:
                            <asp:DropDownList ID="ddlHeaderYear" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnHeaderGo" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_button_text %>"
                                OnClick="btnHeaderGo_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_month_button_text %>"
                                OnClick="btnHeaderNext_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div id="div_calendar">
                <div class="div_padding_40">
                    <ECalendar:EventCalendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Silver"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="550px"
                        Width="850px" FirstDayOfWeek="Sunday" NextMonthText="" PrevMonthText="" SelectionMode="None"
                        ShowGridLines="True" ShowTitle="False" NextPrevFormat="CustomText" DayNameFormat="Full"
                        ShowDescriptionAsToolTip="True" BorderStyle="Solid" EventDateColumnName="" EventHeaderColumnName=""
                        EventDescriptionColumnName="" OnDayRender="Calendar1_DayRender">
                        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                        <DayHeaderStyle BorderWidth="1px" Height="15px" BackColor="Gray" Font-Bold="True"
                            Font-Size="8pt" />
                    </ECalendar:EventCalendar>
                    <%--  --%>
                </div>
            </div>
            <br />
            <div class="div_padding_40 font_1">
                <table class="paging_popup_1">
                    <tr>
                        <td>
                            <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_month_button_text %>"
                                OnClick="btnFooterPrevious_Click" />
                        </td>
                        <td class="align_right">
                            <%=LocalResources.GetLabel("app_showing_text")%>:
                            <asp:DropDownList ID="ddlFooterMonth" runat="server">
                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="align_center">
                            <%=LocalResources.GetLabel("app_for_text")%>:
                            <asp:DropDownList ID="ddlFooterYear" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnFooterGo" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_go_button_text %>"
                                OnClick="btnFooterGo_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_month_button_text %>"
                                OnClick="btnFooterNext_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
     <rsweb:ReportViewer ID="rvMyCalendar" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
    <br />
    <br />
</asp:Content>
