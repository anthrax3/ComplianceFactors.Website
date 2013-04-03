<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="mmtp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.mmtp_01" %>

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
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewCourse").click(function () {

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
                    'width': 830,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmcp-01.aspx?id=' + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewCurricula").click(function () {

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
                    'width': 900,
                    'height': 420,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmcurp-01.aspx?id=' + record_id,
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ViewLearninghistory").click(function () {

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
                    'width': 900,
                    'height': 420,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/Manager/Popup/p-lmhp-01.aspx?id=' + record_id,
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
           <%= LocalResources.GetText("app_welcome_content_myteam_text")%>
            <br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_team_text")%>:
        <%--<div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="Print to PDF"/>
            <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel"/>
        </div>--%>
        <div class="clear">
        </div>
    </div>
    <br />
    <div class="div_padding_10" id="div_course" runat="server">
         <asp:ListView ID="lvMyteam" runat="server" OnItemDataBound="lvMyteam_ItemDataBound"
            OnItemCommand="lvMyteam_ItemCommand">
            <LayoutTemplate>
                <table>
                  <tr style="background-color:#C0C0C0">
                        <th style="width: 400px;">
                            Employee Name (ID)<%--<%=LocalResources.GetLabel("app_employee_name_with_id_text")%>--%>
                        </th>
                        <th style="width: 400px;">
                            Job Title<%--<%=LocalResources.GetLabel("app_job_title_text")%>--%>
                        </th>
                        <th style="width: 150px;">
                        </th>
                        <th style="width: 150px;">
                        </th>
                        <th style="width: 150px;">
                        </th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:400px;">
                        <asp:Literal ID="litIndent" runat="server"></asp:Literal>
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        <asp:LinkButton ID="lnkExpandCollapse" runat="server" CommandName="ExpandCollapse"
                            CausesValidation="false"> [+]                         
                        </asp:LinkButton>
                    </td>
                    <td align="center" style="width:370px;">
                       <asp:Label ID="lblJobTitle" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label>
                    </td>
                    <td align="center" style="width:160px;">
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewDetails" runat="server" Text="<%$ LabelResourceExpression: app_view_course_button_text %>" />'
                            class="ViewCourse cursor_hand" />
                    </td>
                    <td align="center" style="width:160px;">
                        <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewCurricula" runat="server" Text="<%$ LabelResourceExpression: app_view_curricula_button_text %>" />'
                            class="ViewCurricula cursor_hand" />
                    </td>
                    <td align="center" style="width:160px;">
                         <input type="button" id='<%# Eval("userId") %>' value='<asp:Literal ID="ltlViewLearningHistory" runat="server" Text="<%$ LabelResourceExpression: app_view_learning_history_button_text %>" />'
                            class="ViewLearninghistory cursor_hand" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
   <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_myteam_text")%>
        <br />
        <br />
    </div>
    <br />
    <br />
    <%--<rsweb:ReportViewer ID="rvCurricula" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">--%>
    <%--</rsweb:ReportViewer>--%>
</asp:Content>
