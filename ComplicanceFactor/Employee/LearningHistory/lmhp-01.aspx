<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="lmhp-01.aspx.cs" Inherits="ComplicanceFactor.Employee.LearningHistory.lmhp_01" %>

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

        function resetall() {
            document.getElementById('<%=txtKeyword.ClientID %>').value = '';
            document.getElementById('<%=txtFromDate.ClientID %>').value = '';
            document.getElementById('<%=txtToDate.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = 0;
            document.getElementById('<%=ddlDeliveryType.ClientID %>').selectedIndex = 0;
        }

  
    </script>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vs_lmhp" runat="server" ValidationGroup="lmhp" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area">
        <div>
            <%= LocalResources.GetText("app_welcome_content_learnig_history_text")%>
            <br />
            <br />
            <br />
        </div>
    </div>
    <div class="div_header_long">
        <%= LocalResources.GetLabel("app_my_learning_history_text")%>:
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
    <div>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text%>"
                        OnClick="btnHeaderFirst_Click" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text%>"
                        OnClick="btnHeaderPrevious_Click" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text%>"
                        OnClick="btnHeaderNext_Click" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text%>"
                        OnClick="btnHeaderLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text%>"></asp:Label>
                    <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text%>"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text%>"
                        OnClick="btnHeaderGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="div_padding_10" id="div_course" runat="server">
        <asp:GridView ID="gvLearningHistory" CellPadding="0" CellSpacing="0" CssClass="gridview_long_no_border tablesorter"
            runat="server" EmptyDataText="No result found." GridLines="None" AutoGenerateColumns="False"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="t_transcript_course_id_fk,title"
            OnRowDataBound="gvLearningHistory_RowDataBound"
            OnRowCommand="gvLearningHistory_RowCommand">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="<%$ LabelResourceExpression: app_course_title_with_id_text %>" DataField='title'
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
                        <asp:Button ID="btnReview" CommandArgument='<%#Eval("t_transcript_course_id_fk")%>' CommandName="Review"
                            runat="server" Text="<%$ LabelResourceExpression:app_review_button_text %>"  Style="display: none;"/>
                        <asp:Button ID="btnEnroll" CommandArgument='<%#Eval("t_transcript_course_id_fk")%>' Style="display:none;" 
                            runat="server" CommandName="Enroll" Text="<%$ LabelResourceExpression: app_enroll_button_text %>" />
                        <%--<asp:Button ID="btnViewDetails" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' 
                            runat="server" Style="display:none;"  CommandName="View" Text="View Details" />--%>
                        <asp:Literal ID="ltlViewDetails" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                       <asp:Button ID="btnCertificate" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'
                         CommandName="Certificate" style="display:none;" runat="server" Text="Certificate" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text%>"
                        OnClick="btnFooterFirst_Click" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text%>"
                        OnClick="btnFooterPrevious_Click" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text%>"
                        OnClick="btnFooterNext_Click" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text%>"
                        OnClick="btnFooterLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text%>"></asp:Label>
                    <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text%>"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text%>"
                        OnClick="btnFooterGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <br />
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
         <div class="div_header_long">
            <%= LocalResources.GetLabel("app_advanced_learning_history_search_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                       <%= LocalResources.GetLabel("app_keyword_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyword" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="refromdate" runat="server" ControlToValidate="txtFromDate"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                    ErrorMessage="In Valid From Date" Display="Dynamic" ValidationGroup="lmhp">&nbsp;</asp:RegularExpressionValidator>
                      <%= LocalResources.GetLabel("app_from_text")%>:
                    </td>
                    <td>
                       <asp:TextBox ID="txtFromDate" CssClass="textbox_long" Style="font-size: small;" runat="server"></asp:TextBox>
                       <asp:CalendarExtender ID="ceFromdate" TargetControlID="txtFromDate" Format="MM/dd/yyyy" runat="server">
                       </asp:CalendarExtender>
                    </td>
                    <td>
                    <asp:RegularExpressionValidator ID="reTodate" runat="server" ControlToValidate="txtToDate"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                    ErrorMessage="In Valid To Date" Display="Dynamic" ValidationGroup="lmhp">&nbsp;</asp:RegularExpressionValidator>
                        To:
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" CssClass="textbox_long" Style="font-size: small;" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceTodate" TargetControlID="txtToDate" Format="MM/dd/yyyy" runat="server">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="textbox_long" runat="server" DataTextField="e_learning_history_status_name"
                         DataValueField="e_learning_history_status_id">
                        
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%= LocalResources.GetLabel("app_delivery_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryType" DataValueField="s_delivery_type_system_id_pk"
                            DataTextField="s_delivery_type_name" CssClass="textbox_long" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" runat="server"
                            OnClick="btnGosearch_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                       <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" OnClientClick="return resetall();"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_learnig_history_text")%>
    </div>
    <br />
    <br />
    <rsweb:ReportViewer ID="rvLearningHistory" runat="server" Style="display: none;"
        DocumentMapCollapsed="true" ShowDocumentMapButton="false">
    </rsweb:ReportViewer>
</asp:Content>
