<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-tcdlp-01.aspx.cs" Inherits="ComplicanceFactor.Training.p_tcdlp_01" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 1030px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
        }
    </style>
    <script type="text/javascript">
        //Get deliveries Popup
        $(document).ready(function () {
            //Get Course ID
            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();
            var userName = $('input#<%=hdUserName.ClientID %>').val();
            $(".addDelivery").click(function () {
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
                    'width': 1040,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Catalog/Course/Delivery/sand-01.aspx?mode=adddelivery&page=p-tcdlp&editCourseId=' + editCourseId+'&userName='+userName,
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

        });
    </script>
    <script type="text/javascript">
        function check_hdAddNewDeliveyClick(id) {
            if (id == "btnAddNewDelivery") {
                document.getElementById('<%=hdAddNewDelivery.ClientID %>').value = "0";
            }

        }
    </script>
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>--%>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:HiddenField ID="hdAddNewDelivery" runat="server" />
    <asp:HiddenField ID="hdUserName" runat="server" />
    <asp:HiddenField ID="hdUserID" runat="server" />
    <div class="div_header_1060">
        <%=LocalResources.GetLabel("app_course_deliveries_text")%>:
        <div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="<%$ LabelResourceExpression: app_print_to_pdf_button_text %>" OnClick="btnPrintPdf_Click" />
            <asp:Button ID="btnExportExcel" runat="server" Text="<%$ LabelResourceExpression: app_export_to_excel_button_text %>" OnClick="btnExportExcel_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <asp:HiddenField ID="hdCourseId" runat="server" />
    <div class="div_padding_120">
        <asp:GridView ID="gvCourseDeliveries" CellPadding="0" CellSpacing="0" CssClass="gridview_small_no_border tablesorter"
            runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>" AutoGenerateColumns="False" GridLines="None"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="c_delivery_system_id_pk,c_course_id_fk"
            OnRowCommand="gvCourseDeliveries_RowCommand" AllowPaging="false">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_6"
                    HeaderText="<%$ LabelResourceExpression: app_course_name_with_id_text %>" HeaderStyle-HorizontalAlign="Left" DataField="Course_Title_With_Id"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_6"
                    HeaderText="<%$ LabelResourceExpression: app_delivery_name_with_id_text %>" HeaderStyle-HorizontalAlign="Center" DataField="Delivery_Title_With_Id"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_6" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="<%$ LabelResourceExpression: app_dates_text %>" HeaderStyle-HorizontalAlign="Center" DataField="Sessions_Date"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                    HeaderText="<%$ LabelResourceExpression: app_type_text %>" HeaderStyle-HorizontalAlign="right" DataField="Delivery_Type"
                    ItemStyle-HorizontalAlign="right" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnMakeCopy" CommandName="Copy" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_make_a_copy_button_text %>" CommandArgument='<%#DataBinder.Eval(Container,"RowIndex") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="div_header_1060">
        <br />
    </div>
    <br />
    <div class="div_padding_120">
        <table class="table_td_300">
            <tr>
                <td>
                    <%-- <asp:Button ID="btnAddNewDelivery" runat="server" Text="Add New Delivery" />--%>
                    <input type="button" id="btnAddNewDelivery" onclick='javascript:check_hdAddNewDeliveyClick(this.id)'
                        class="addDelivery cursor_hand" value='<asp:Literal ID="Literal1" Text="<%$ LabelResourceExpression: app_add_new_delivery_button_text %>" runat="server"></asp:Literal>' />
                </td>
                <td class="align_right">
                    <asp:Button ID="Button1" CssClass="cursor_hand" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                        Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </td>
            </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="rvDelivery" runat="server" Style="display: none;" DocumentMapCollapsed="true"
        ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
</asp:Content>
