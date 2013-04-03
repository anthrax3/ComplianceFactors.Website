<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saucmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses.saucmcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Default_Cell_Style
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
        }
        .Title_Cell_Style
        {
            font-size: 14px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
        }
        .Inner_Cell_Style_left_300
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: left;
        }
        .Inner_Cell_Style_left_350
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 350px;
            text-align: left;
        }
        .Inner_Cell_Style_left_600
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 600px;
            text-align: left;
        }
        .Inner_Cell_Style_centered
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: center;
        }
        .Inner_Cell_Style_right
        {
            font-size: 12px;
            padding: 3px 7px 0 10px;
            font-weight: bold;
            width: 300px;
            text-align: right;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //Select Image
            $(".adduser").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 720,
                'height': 200,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': 'p-sase.aspx',
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

            $(".deleteuser").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saucmcp-01.aspx/DeleteUser",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();
                                $('#<%=gvEmployees.ClientID %> tr:last').eq(-1).css("display", "none");
                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <div class="content_area_long">
        <div class="div_header_long">
            Curriculum Details:
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        Curriculum Title (Curriculum ID):
                    </td>
                    <td>
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
                    <td align="right">
                        Revision:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Description:
                    </td>
                    <td class="align_left">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Cost:
                    </td>
                    <td>
                    </td>
                    <td colspan="2" align="right">
                        CEU
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        Owner
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            paths(s) Details:
        </div>
        <div>
            <asp:GridView ID="gvPath" ShowHeader="false" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border"
                runat="server" EmptyDataText="No result found" OnRowDataBound="gvPath_RowDataBound"
                GridLines="None" DataKeyNames="c_curricula_path_system_id_pk,c_curriculum_system_id_pk"
                AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPath" runat="server" Text='<%#Eval("c_curricula_path_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvSection" ShowHeader="false" AutoGenerateColumns="False" runat="server"
                                            GridLines="None" DataKeyNames="c_curricula_path_id_fk,c_curricula_path_section_id_pk"
                                            OnRowDataBound="gvSection_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <b>section:</b>
                                                        <%#Eval("c_curricula_path_section_seq_number")%>
                                                        <asp:GridView ID="gvCourse" CellPadding="0" CellSpacing="0" ShowHeader="false" runat="server"
                                                            AutoGenerateColumns="false" GridLines="None">
                                                            <Columns>
                                                                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                                                                    HeaderText="Curriculum ID" HeaderStyle-HorizontalAlign="Center" DataField="c_course_name"
                                                                    ItemStyle-HorizontalAlign="Left" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <div class="div_header_long">
                Roaster:
            </div>
            <br />
            <div>
                <asp:GridView ID="gvEmployees" RowStyle-CssClass="record" CellPadding="0" CellSpacing="0"
                    CssClass="gridview_long tablesorter" runat="server" EmptyDataText="No result found."
                    AutoGenerateColumns="False" AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row"
                    PagerSettings-Visible="false" DataKeyNames="u_user_id_pk" OnRowCommand="gvEmployees_RowCommand"
                    OnRowEditing="gvEmployees_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Last Name"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_last_name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee First Name"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_first_name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Number"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="u_hris_employee_id" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Current Status"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="e_enroll_status_name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="% Completed"
                            ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                            DataField="e_curriculum_assign_percent_complete" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("u_user_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="Remove" />'
                                    class="deleteuser cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="div_padding_135">
                <table>
                    <tr>
                        <td style="width: 180px;">
                        </td>
                        <td>
                            Select New Status:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChangeStatus" runat="server">
                                <asp:ListItem>In Progress</asp:ListItem>
                                <asp:ListItem>Assigned</asp:ListItem>
                                <asp:ListItem>Acquired</asp:ListItem>
                                <asp:ListItem>Waived</asp:ListItem>
                                <asp:ListItem>Revoked</asp:ListItem>
                                <asp:ListItem>No Longer Required</asp:ListItem>
                                <asp:ListItem>Warining</asp:ListItem>
                                <asp:ListItem>Retrain</asp:ListItem>
                                <asp:ListItem>Expired/Overdue</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnAddUser" runat="server" CssClass="adduser cursor_hand" Text="Add User" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_header_long">
            </div>
            <table>
                <tr>
                    <td align="center" colspan="3" width="1030px">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" width="1030px">
                        <asp:Button ID="btnUpdateCurriculum" runat="server" Text="Update Curriculum Status" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="div_header_long">
            </div>
            <br />
            <br />
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
        </asp:ToolkitScriptManager>
        <asp:ModalPopupExtender ID="mpeCustomCustomer" runat="server" TargetControlID="btnUpdateCurriculum"
            PopupControlID="pnlNotes" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlNotesHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnCancel">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlNotes" runat="server" CssClass="modalPopup_width_620" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlNotesHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_620">
                        Eneter PIN and Reasons for Curriculum Status Change:
                    </div>
                    <asp:ImageButton ID="imgCloseJobTitle" CssClass="cursor_hand" Style="top: -15px;
                        right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                </div>
            </asp:Panel>
            <br />
            <div>
                <table>
                    <tr>
                        <td align="right">
                            Selected Employee(s):
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            New Status:
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            New Due Date:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDueDate" runat="server" Text="mm/dd/yy"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Notes:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="15" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            PIN:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCreatePin" runat="server" Text="Create a PIN" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveStatus" runat="server" Text="Save New Status" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
        </asp:Panel>
    </div>
</asp:Content>
