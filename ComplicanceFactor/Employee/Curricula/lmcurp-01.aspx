<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lmcurp-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Curricula.lmcurp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('#app_nav_employee').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_employee').addClass('selected');
                return false;
            });
     

        $(".viewdetails").click(function () {
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
                    'width': 732,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Employee/Curricula/p-lvcurd-01.aspx?id=' + record_id,
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


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area">
        <div>
            Welcome to ComplianceFactors!<br />
            <br />
            ComplianceFactors&#0153 (CF) provides an innovative turnkey solution to ensure full
            compliance with any regulation such as: OSHA, DOT, EPA, FDA CFR 21 Part 11, FAA,
            ISO, SEC, JCAHO.<br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        My Curricula:
        <div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="Print to PDF" OnClick="btnPrintPdf_Click" />
            <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel" OnClick="btnExportExcel_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_course" runat="server">
        <asp:GridView ID="gvCurriculum" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="e_curriculum_assign_curriculum_id_fk"
            AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
             OnRowDataBound="gvCurriculum_RowDataBound" OnRowCommand="gvCurriculum_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Curriculum Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Assignment Date" DataField='e_curriculum_assign_date_time' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Due Date" DataField='e_curriculum_assign_target_due_date' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%--<asp:Button ID="btnViewDetail" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="View" runat="server" Text="View Details" />--%>
                        <input type="button" id='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="View Details" />'
                            class="viewdetails cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%--<asp:Button ID="btnDrop" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>' CommandName="Drop"
                            runat="server" Text="Drop" Style="display: none;" />--%>
                            <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            CommandName="Enroll" runat="server" Text="Enroll" />
                    </ItemTemplate>
                        <%--<asp:Button ID="btnEnroll" CommandArgument='<%#Eval("e_curriculum_assign_curriculum_id_fk")%>'
                            runat="server" CommandName="Enroll" Text="Enroll" Style="display: none;" />
                        <asp:Button ID="btnLaunch" runat="server" CommandArgument='<%# Eval("e_curriculum_assign_curriculum_id_fk") %>'
                            CommandName="Launch" Text="Launch" Style="display: none;" />--%>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
    <div class="content_area">
        If you need assistance with the ComplianceFactors&#0153 (CF), please email David
        Ealy at: <a href="mailto:dealy@ComplianceFactors.com">dealy@ComplianceFactors.com</a>
        <br />
        <br />
    </div>
    <br />
    <br />
    <rsweb:ReportViewer ID="rvCurricula" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
</asp:Content>
