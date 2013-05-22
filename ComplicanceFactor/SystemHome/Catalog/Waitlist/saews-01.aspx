<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saews-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Approvals.saews_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".moveRoaster").click(function () {
                var record_id = $(this).attr("id");
                var element = $(this).attr("id").split(",");
                window.location.replace("/SystemHome/Catalog/Waitlist/saews-01.aspx?process=roaster&waitlistId=" + element[0] + "&userId=" + element[1]);
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".removeWaitlist").click(function () {                
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                var element = $(this).attr("id").split(",");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saews-01.aspx/DeleteWaitList",

                        //Pass the selected record id
                        data: "{'args': '" + element[0] + "','args2': '" + element[1] + "','args3':'" + element[2] + "'}",
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
            $(".addUser").click(function () {
                var record_id = $(this).attr("id");
                var element = $(this).attr("id").split(",");
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
                    'href': 'Popup/sasumsm-01.aspx?courseId='+element[0] +'&deliveryId='+element[1],
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
        });
    </script>
    <div class="content_area_long">
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" runat="server" Text="Save Waitlist" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderReset" runat="server" Text="Reset" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Wailist Information:
        </div>
        <br />
        <div>
            <table class="div_controls font_1">
                <tr>
                    <td class="align_right">
                        Waitlist ID:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblWaitlistId" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        Course Name / Id:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Delivery Id:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryId" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        Delivery Name:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Delivery Start:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryStart" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        Delivery End:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblDeliveryEnd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Min Enroll:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblMinEnroll" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        Max Enroll:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblMaxEnroll" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Wailist Details:
        </div>
        <br />
        <table>
            <tr>
                <td class="align_left font_1">
                    <asp:Label ID="lblWaitlistStatus" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="gvWaitlistDetails" CellPadding="0" CellSpacing="0" RowStyle-CssClass="record" CssClass="gridview_long tablesorter"
                runat="server" EmptyDataText="No Result Found" AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" PageSize="10"
                DataKeyNames="e_enroll_waitlist_system_id_pk,e_enroll_waitlist_user_sequence"
                OnRowCommand="gvWaitlistDetails_RowCommand" OnRowDataBound="gvWaitlistDetails_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Employee ID" HeaderStyle-HorizontalAlign="Center" DataField="u_hris_employee_id"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Center" DataField="employee_Name"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderText="Priority" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPriority" CssClass="width_75" runat="server">
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderText="Rank" HeaderStyle-HorizontalAlign="Center" DataField="e_enroll_waitlist_user_sequence"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnUp" CssClass="cursor_hand" CommandName="Up" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Up" />&nbsp;
                            <asp:Button ID="btnDown" CssClass="cursor_hand" CommandName="Down" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="Down" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlRoaster" runat="server"></asp:Literal>
                            <asp:Literal ID="ltlRemove" runat="server"></asp:Literal>
                            <asp:Literal ID="ltlAdd" Visible="false" runat="server"></asp:Literal>
                            <%--  <asp:Button ID="btnManageRoster" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Manage Roster" />
                            <asp:Button ID="btnRemove" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Remove" />
                            <asp:Button ID="btnAdd" Visible="false" CssClass="cursor_hand" CommandName="Copy" runat="server"
                                Text="Add" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:HiddenField ID="hdnDeliveryId" runat="server" />
        <asp:HiddenField ID="hdnCourseId" runat="server" />
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div>
            <table class="table_td_300">
                <tr>
                    <td>
                        <asp:Button ID="btnFooterSave" runat="server" Text="Save Waitlist" 
                            onclick="btnFooterSave_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnFooterReset" runat="server" Text="Reset" 
                            onclick="btnFooterReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnFooterCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
