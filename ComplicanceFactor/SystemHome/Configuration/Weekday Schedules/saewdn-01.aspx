<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saewdn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Weekday_Schedules.saewdn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
    <br />
     <asp:ValidationSummary class="validation_summary_error" ID="vs_saewdn" runat="server"
        ValidationGroup="saewdn"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveWeekdaySchedule" CssClass="cursor_hand" runat="server" ValidationGroup="saewdn"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" OnClick="btnHeaderSaveWeekdaySchedule_Click" />
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
            <%=LocalResources.GetLabel("app_weekday_schedule_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                       <asp:RequiredFieldValidator ID="rfvScheduleId" runat="server" ValidationGroup="saewdn"
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
                        <asp:RequiredFieldValidator ID="rfvScheduleName" runat="server" ValidationGroup="saewdn"
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
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="saewdn"
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
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_days_text")%>: 
                    </td>
                    <td colspan="7">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkSunday" runat="server" />
                                    &nbsp;Sunday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkMonday" runat="server" />
                                    &nbsp;Monday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkTuesday" runat="server" />
                                    &nbsp;Tuesday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkWednesday" runat="server" />
                                    &nbsp;Wednesday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkThursday" runat="server" />
                                    &nbsp;Thursday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkFriday" runat="server" />
                                    &nbsp;Friday
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkSaturday" runat="server" />
                                    &nbsp;Saturday
                                </td>
                            </tr>
                        </table>
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
                        <asp:Button ID="btnFooterSaveWeekdaySchedule" CssClass="cursor_hand" runat="server" ValidationGroup="saewdn"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" OnClick="btnFooterSaveWeekdaySchedule_Click" />
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
