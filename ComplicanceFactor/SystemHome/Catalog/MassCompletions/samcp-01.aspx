<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.MassCompletions.samcp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addCatalog").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 733,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'p-mcsc-01.aspx',
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
         $(document).ready(function () {
             $(".addEmployee").fancybox({
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
                 'href': 'sasumsm-01.aspx',
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
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            Catalog Item(s):
        </div>
        <br />
        <div>
            <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" CssClass="grid_870" ShowHeader="false"
                ShowFooter="false" GridLines="None" DataKeyNames="c_course_system_id_pk" runat="server"
                OnRowDataBound="gvCatalog_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblCourse" runat="server" Style="text-align: left;" Text="Course:"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_4_1" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseName" runat="server" Style="text-align: left;" Text='<%#Eval("c_course_title")  + "(" + Eval("c_course_id_pk") +")"%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" DataTextField="deliveryname"
                                DataValueField="c_delivery_system_id_pk" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveCatalogItem" runat="server" Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddCatalogItem" runat="server" CssClass="addCatalog cursor_hand"
                Text="Add Catalog Item(s)" />
            <br />
            <br />
        </div>
        <div class="div_header_long">
            Employee(s):
        </div>
        <div class=" div_controls font_1">
            <br />
            <asp:GridView ID="gvEmployee" AutoGenerateColumns="false" CssClass=" grid_870" ShowHeader="false"
                ShowFooter="false" GridLines="None" DataKeyNames="u_user_id_pk" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("u_username")  + "(" + Eval("u_hris_employee_id") +")"%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveEmployee" runat="server" Text="Remove" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAddEmployee" runat="server"  CssClass="addEmployee cursor_hand" Text="Add Employee(s)" />
            <br />
            <br />
        </div>
        <div class=" div_header_long">
            Completion Information:
        </div>
        <br />
        <div class="div_padding_10" id="div_course" runat="server">
            <asp:GridView ID="gvCompletionInfo" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
                runat="server" EmptyDataText="No Result Found" GridLines="None" AutoGenerateColumns="False"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4 align_center" HeaderText="Comments"
                        ItemStyle-CssClass="gridview_row_width_4" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Rows="7" Width="300px">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3 align_center" HeaderText="Completion Date"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCompletionDate" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attendance" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlAttendance" runat="server">
                                <asp:ListItem>Attended</asp:ListItem>
                                <asp:ListItem>Did Not Attend/No Show</asp:ListItem>
                                <asp:ListItem>Partially Attended</asp:ListItem>
                                <asp:ListItem>Attended/Walk In</asp:ListItem>
                                <asp:ListItem>Unknown</asp:ListItem>
                                <asp:ListItem>OLT Player</asp:ListItem>
                                <asp:ListItem>VLS System</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Passign Status" HeaderStyle-CssClass="gridview_row_width_3 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPassingStatus" runat="server">
                                <asp:ListItem>Passed</asp:ListItem>
                                <asp:ListItem>Failed</asp:ListItem>
                                <asp:ListItem>Exempt</asp:ListItem>
                                <asp:ListItem>Not Scored</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlGrade" runat="server">
                                <asp:ListItem>S</asp:ListItem>
                                <asp:ListItem>U</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" CssClass=" width_30" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="font_1">
            <table class="table_td_300">
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnProcessMassCompletion" runat="server" Text="Process Mass Completion" />
                    </td>
                    <td>
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
