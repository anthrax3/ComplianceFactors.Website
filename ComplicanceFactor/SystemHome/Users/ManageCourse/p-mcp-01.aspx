<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-mcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ManageCourse.p_mcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 1010px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".viewCourse").click(function () {

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
                    'width': 700,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p_lvcd-01.aspx?id=' + record_id,
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

            var userId = document.getElementById('<%=hdEditUser.ClientID %>').value

            $(".markcompletion").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
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
                    'width': 740,
                    'height': 400,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-cmcp-01.aspx?courseid=' + element[0] + '&deliveryid=' + element[1] + '&userid=' + userId,
                    'afterClose': function () {
                        location.reload();
                        return;
                    },
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

            var userId = document.getElementById('<%=hdEditUser.ClientID %>').value
            //alert(userId);
            //btnAddCourses
            $("#<%=btnAddCourses.ClientID %>").click(function () {
                var hdnValue = document.getElementById('<%= hdIsCourseBind.ClientID %>');
                hdnValue.value = 1;
                $("#<%=btnAddCourses.ClientID %>").fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 980,
                    'height': 500,
                    'margin': 0,
                    'padding': 5,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../AddCourses/sauatc-01.aspx?userId=' + userId,
                    'afterClose': function () {
                        location.reload();
                        return;
                    },
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
            $(function () {
                $('#<%=gvCourses.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

            });
        });
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdEditUser" runat="server" />
    <asp:HiddenField ID="hdIsCourseBind" runat="server" />
    <div class="content_area_long">
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div class="div_header_1005">
            My Courses:
            <div class="right div_padding_10">
                <asp:Button ID="btnAddCourses" runat="server" Text=" Add Courses" CssClass="cursor_hand" />
            </div>
        </div>
        <br />
        <div class="clear">
        </div>
        <div>
            <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" runat="server" EmptyDataText="No result found"
                GridLines="Both" DataKeyNames="e_enroll_course_id_fk,e_enroll_delivery_id_fk"
                AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                OnRowDataBound="gvCourses_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_3" HeaderText="Course Title (ID)" DataField='title'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderText="Required" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_4">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRequired" DataTextField="required_text" DataValueField="required_id"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Due Date" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtduedate">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtduedate" class="CompletionDate" Text='<%# Eval("duedate") %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_2" HeaderText="Status" DataField='status'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("e_enroll_course_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'
                                class="viewCourse cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" HeaderText="Remove">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRemove" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlMarkCompletion" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_padding_40">
            <asp:Button ID="btnSaveChanges" runat="server" CssClass="cursor_hand" Text="Save Changes"
                OnClick="btnSaveChanges_Click" />
        </div>
        <br />
        <div class="div_header_1005">
            &nbsp;
        </div>
    </div>
</asp:Content>
