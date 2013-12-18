<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resch-01.aspx.cs" MasterPageFile="~/Empty.Master"
    Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.resch_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Src="dynamicsearch.ascx" TagName="dynamicsearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 1000px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {

            return false;
        }
        function changeWhentorun() {
            if ($("#<%=ddlWhentorun.ClientID %>").val() == "-1") {
                $("#trDate").hide();
            } else {
                $("#trDate").show();
            }
        }
        $(document).ready(function () {
            if ($("#<%=ddlWhentorun.ClientID %>").val() == "-1") {
                $("#trDate").hide();            
            } else {
                $("#trDate").show();    
            }
            $(".adduser").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'scrolling': 'yes',
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 916,
                'height': 200,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': 'p-sces-01.aspx?editDeliveryId=',
                'onComplete': function () {
                    $('#fancybox-frame').load(function () {
                        $('#fancybox-content').height($(this).contents().find('body').height() + 10);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            $(".delete").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "resch-01.aspx/Delete",

                        //Pass the selected record id
                        data: "{ 'args': '" + record_id + "'}",
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
        function reloadWin() {
            if ($.browser.mozilla) {
                parent.window.location.href = parent.window.location.href;
            } else {
               // alert(parent.window.location.href)
                parent.window.location.reload();
                parent.jQuery.fancybox.close();
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Do you wish to delete this report?') == true)
                return true;
            else
                return false;
        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="content">
        <div>
            <asp:Panel ID="pnlDefault" runat="server">
                <div class="div_header_800" style="width: 980px;">
                    Search:
                </div>
                <br />
                <div class="div_controls font_1">
                    <div class="div_header_long" style="width: 98%;">
                        Report Information:
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <table>
                            <tr>
                                <td>
                                    Report Name:
                                </td>
                                <td colspan="3" style="text-align: left; width: 500px;">
                                    <asp:TextBox ID="txtReportName" CssClass="textarea_long_2" runat="server" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="div_header_long" style="width: 98%;">
                        Parameters:
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <table>
                            <uc1:dynamicsearch ID="dynamicsearch1" runat="server" />
                        </table>
                    </div>
                    <div class="div_header_long" style="width: 98%;">
                        Email to:
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <table style="width: 65%;">
                            <tr style="display: none;">
                                <td>
                                    Mail to:
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_popup_1 tablesorter"
                                        runat="server" Width="550px" GridLines="None" AutoGenerateColumns="False" AllowPaging="true"
                                        EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="u_user_id_pk"
                                        RowStyle-CssClass="record">
                                        <Columns>
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" HeaderText="Employee Last name"
                                                ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                                                DataField="u_last_name" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" HeaderText="Employee First name"
                                                ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                                                DataField="u_first_name" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" HeaderText="Employee Number"
                                                ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                                                DataField="u_hris_employee_id" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" HeaderText="Mail" ItemStyle-CssClass="gridview_row_width_1"
                                                HeaderStyle-HorizontalAlign="Center" DataField="u_email_address" ItemStyle-HorizontalAlign="Left" />
                                            <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_3"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <input type="button" id='<%# Eval("s_report_users_mailto_system_id_pk")%>' value='<asp:Literal ID="Literal6" runat="server" Text="Remove" />'
                                                        class="delete cursor_hand" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td>
                                    Last Name:
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtLastName" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    Frist Name:
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFirstName" runat="server" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mail to:
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="txtMail" CssClass="textarea_long_2" runat="server" Width="100%"
                                        TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:Button ID="btnSaveNewUsers" runat="server" CssClass=" cursor_hand" Text="Save New User"
                                        OnClick="btnSaveNewUsers_Click" Style="display: none;" />
                                    <asp:Button ID="btnAddUsers" runat="server" CssClass="adduser cursor_hand" Text="Add Users" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="div_header_long" style="width: 98%;">
                        Recurrence:
                    </div>
                    <br />
                    <div class="div_controls font_1">
                        <table>
                            <tr>
                                <td>
                                    When to Run:
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:DropDownList runat="server" ID="ddlWhentorun" Width="200px" onchange = "changeWhentorun()">
                                        <asp:ListItem Value="-1" Text=""></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Every Day"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Every Week"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Every Month"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Every Year"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trDate">
                                <td>
                                    From:
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtDateFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="ceDateFrom" Format="MM/dd/yyyy" TargetControlID="txtDateFrom"
                                        runat="server">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    To:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="ceDateTp" Format="MM/dd/yyyy" TargetControlID="txtDateTo"
                                        runat="server">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="align_left">
                                    <asp:Button ID="btnScheduleNew" CssClass="cursor_hand" Text="Save" runat="server"
                                        OnClick="btnScheduleNew_Click" />
                                 
                                </td>
                                <td style="text-align:center">
                                   <asp:Button ID="btnDelete" CssClass="cursor_hand" Text="Delete" runat="server" OnClick="btnDelete_Click"
                                        OnClientClick="return confirmStatus();" />
                                </td>
                                <td class="align_right">
                                    <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                        runat="server" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
