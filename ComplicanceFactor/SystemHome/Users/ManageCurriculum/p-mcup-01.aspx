<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-mcup-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ManageCurriculum.p_mcup_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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

            $(".viewCurriculum").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                var userid = document.getElementById('<%=hdEditUser.ClientID %>').value;
                //alert(userid);
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
                    'width': 830,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lvcurd-01.aspx?id=' + record_id + '&userid=' + userid,
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

            $(".changestatus").click(function () {
                var hdnValue = document.getElementById('<%= hdIsCurriculumBind.ClientID %>');
                hdnValue.value = 1;
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                $.fancybox({

                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'afterClose': function () {
                        location.reload();
                        return;
                    },
                    'width': 740,
                    'height': 400,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-mcuccs-01.aspx?curriculumid=' + record_id + '&userid=' + userId,
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
            $("#<%=btnAddCurriculum.ClientID %>").click(function () {
                var hdnValue = document.getElementById('<%= hdIsCurriculumBind.ClientID %>');
                hdnValue.value = 1;
                $("#<%=btnAddCurriculum.ClientID %>").fancybox({
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
                    'href': '../AddCurriculum/sauac-01.aspx?userId=' + userId,
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
                $('#<%=gvCurriculum.ClientID %>')
			.tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false}} });

            });
        });
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdEditUser" runat="server" />
    <asp:HiddenField ID="hdIsCurriculumBind" runat="server" />
    <div id="content">
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header_1005">
            My Curriculum:
            <div class="right div_padding_10">
                <asp:Button ID="btnAddCurriculum" runat="server" Text=" Add Curriculum" CssClass="cursor_hand" />
            </div>
        </div>
        <br />
        <div class="clear">
        </div>
        <div class="div_padding_10" id="div_course" runat="server">
            <asp:GridView ID="gvCurriculum" CellPadding="0" CellSpacing="0" runat="server" EmptyDataText="No result found"
                GridLines="Both" DataKeyNames="e_curriculum_assign_curriculum_id_fk" AutoGenerateColumns="False"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Curriculum Title (ID)" DataField='title' HeaderStyle-BackColor="LightGray"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Assignment Date" DataField='e_curriculum_assign_date_time' HeaderStyle-BackColor="LightGray"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Due Date" DataField='e_curriculum_assign_target_due_date'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:TemplateField HeaderText="Due Date" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-BackColor="LightGray">
                        <ItemTemplate>
                            <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtduedate">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtduedate" class="CompletionDate" Text='<%# Eval("e_curriculum_assign_target_due_date") %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Status" DataField='status' HeaderStyle-BackColor="LightGray" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="LightGray" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>                           
                            <input type="button" id='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'
                                class="viewCurriculum cursor_hand" />                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="LightGray" ItemStyle-HorizontalAlign="Center"
                        HeaderText="Remove">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRemove" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="LightGray" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>' value='<asp:Literal ID="ltlChangeStatus" runat="server" Text="Change Status" />'
                                class="changestatus cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_1005">
            &nbsp;
        </div>
        <br />
        <div class="div_padding_40">
            <asp:Button ID="btnSaveChanges" runat="server" CssClass="cursor_hand" Text="Save Changes"
                OnClick="btnSaveChanges_Click" />
        </div>
        <br />
    </div>
</asp:Content>
