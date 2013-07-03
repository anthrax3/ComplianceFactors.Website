<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-lmhp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Popup.p_lmhp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 870px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 420px;
        }
    </style>
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
                    'href': '/Employee/Course/lvcd-01.aspx?id=' + record_id,
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

        $(function () {
            $('#<%=gvLearningHistory.ClientID %>')
			.tablesorter({ headers: { 5: { sorter: false }, 6: { sorter: false }, 7: { sorter: false }, 8: { sorter: false}} });

        });

       

  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vs_lmhp" runat="server"
        ValidationGroup="lmhp" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   <div id="content">
        <div class="div_header_870">
            <%=LocalResources.GetLabel("app_my_learning_history_text")%>:
            <div class="right div_padding_10">
                <asp:Button ID="btnPrintPdf" runat="server" Text="<%$ LabelResourceExpression: app_print_to_pdf_button_text %>"
                    OnClick="btnPrintPdf_Click" />
                <asp:Button ID="btnExportExcel" runat="server" Text="<%$ LabelResourceExpression: app_export_to_excel_button_text %>"
                    OnClick="btnExportExcel_Click" />
            </div>
            <div class="clear">
            </div>
        </div>
        <br />
        <div class="div_padding_10" id="div_course" runat="server">
            <asp:GridView ID="gvLearningHistory" CellPadding="0" CellSpacing="0" CssClass="gridview_800 tablesorter"
                runat="server" EmptyDataText="<%$ LabelResourceExpression: app_No_result_found_text %>"
                GridLines="None" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row"
                PagerSettings-Visible="false" DataKeyNames="t_transcript_user_id_fk,t_transcript_course_id_fk"
                OnRowCommand="gvLearningHistory_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="<%$ LabelResourceExpression: app_course_title_text %>" DataField='title'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="<%$ LabelResourceExpression: app_completion_date_text %>" DataField='date'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_status_text %>" DataField='status'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_score_text %>" DataField='score'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="<%$ LabelResourceExpression: app_delivery_text %>" DataField='deliveryType'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCertificate" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CommandName="Certificate" runat="server" Text="<%$ LabelResourceExpression: app_certificate_button_text %>" />
                        </ItemTemplate>
                        <%--CommandArgument='<%#Eval("t_transcript_course_id_fk") %>'--%>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <rsweb:ReportViewer ID="rvLearningHistory" runat="server" Style="display: none;"
        DocumentMapCollapsed="true" ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
</asp:Content>
