<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resch-01.aspx.cs" MasterPageFile="~/Empty.Master"
    Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.resch_01" %>

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
        $(document).ready(function () {
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
    </script>
    <div id="content">
        <div>
            <asp:Panel ID="pnlDefault" runat="server">
                <div class="div_header_800" style="width: 980px;">
                    Case Search:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table>
                        <tr>
                            <td>
                                Report Name:
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:TextBox ID="txtReportName" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
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
                                <asp:Button ID="btnAddUsers" runat="server" CssClass="adduser cursor_hand" Text="Add Users" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                When to Run:
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:DropDownList runat="server" ID="ddlWhentorun">
                                    <asp:ListItem Value="0" Text="Every Day"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Every Week"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Every Month"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Every Year"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <uc1:dynamicsearch ID="dynamicsearch1" runat="server" />
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="align_left">
                                <asp:Button ID="btnSchedule" CssClass="cursor_hand" Text="Schedule" runat="server"
                                    OnClick="btnSchedule_Click" />
                            </td>
                            <td class="align_left">
                                <asp:Button ID="btnScheduleNew" CssClass="cursor_hand" Text="Schedule New" runat="server"
                                    OnClick="btnScheduleNew_Click" />
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                    runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
