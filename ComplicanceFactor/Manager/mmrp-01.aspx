<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="mmrp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.mmrp_01" %>

<%@ Register Src="../Compliance/MIRIS/Reports/mrp-01.ascx" TagName="mrp" TagPrefix="uc1" %>
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
            $('#app_nav_manager').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_manager').addClass('selected');
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
                    'href': '/Employee/Curricula/lvcurd-01.aspx?id=' + record_id,
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
    <div class="content_area">
        <div>
            <%= LocalResources.GetText("app_welcome_content_myreport_text")%>
            <br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
        <%--<div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="Print to PDF"/>
            <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel"/>
        </div>--%>
        <div class="clear">
        </div>
    </div>
    <div class="div_padding_10" id="div_report" runat="server">
        <uc1:mrp ID="mrp1" runat="server" />
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_myreport_text")%>
        <br />
        <br />
    </div>
    <br />
    <br />
    <%--<rsweb:ReportViewer ID="rvCurricula" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">--%>
    <%--</rsweb:ReportViewer>--%>
</asp:Content>
