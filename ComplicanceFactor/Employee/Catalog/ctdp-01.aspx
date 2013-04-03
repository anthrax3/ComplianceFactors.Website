<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ctdp-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Catalog.ctdp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
            $(".enroll").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
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
                    'href': '/Employee/Enroll/ecolt-01.aspx?id=' + element[0] + "&type=" + element[1] + "&courseid=" + element[2] + "&waitlist=" + element[3] + "&approval=" + element[4] + "&ca=" + element[5],
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
        function lastEquivalenciesrow() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }
       
    </script>

   <script type="text/javascript" language="javascript">
            function confirmStatus() {
                if (confirm('Are you sure?') == true)
                    return true;
                else
                    return false;

            }
    </script>
   
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_course_details_text")%>
            <asp:Label ID="lblCourseTitleId" runat="server"></asp:Label>
            :
        </div>
        <br />
        <br />
        <div>
            <div class="page_text">
                <asp:GridView ID="gvsearchDetails" GridLines="None" ShowFooter="true" ShowHeader="false"
                    CssClass="search_result" CellPadding="0" CellSpacing="0" runat="server" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                    AutoGenerateColumns="False" AllowPaging="false" 
                    EmptyDataRowStyle-CssClass="empty_row" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <%#Eval("c_course_title_and_id")%>
                                        </td>
                                        <td>
                                            <%=LocalResources.GetLabel("app_revision_text")%>
                                            <%#Eval("c_course_version")%>
                                        </td>
                                        <td class="tdright">
                                           <%#Eval("c_delivery_type")%>
                                        </td>
                                    </tr>
                                    </td> </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%=LocalResources.GetLabel("app_description_text")%>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="font_normal text_justify" colspan="3">
                                            <%#Eval("c_course_desc")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%=LocalResources.GetLabel("app_abstract_text")%>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="font_normal text_justify" colspan="3">
                                            <%#Eval("c_course_abstract")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%=LocalResources.GetLabel("app_cost_text")%>
                                            Free
                                        </td>
                                        <td>
                                            CEU:
                                            <%#Eval("c_course_credit_hours")%>
                                        </td>
                                        <td class="tdright">
                                            <%=LocalResources.GetLabel("app_owner_text")%>
                                            <%#Eval("ownername")%>
                                            /
                                            <%=LocalResources.GetLabel("app_coordinator_text")%>
                                            <%#Eval("coordinatorname")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_delivery_text")%>
        </div>
        <br />
        <div class="div_control_normal">
            <asp:GridView ID="gvDeliveries" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" EmptyDataText="No record found." 
                EmptyDataRowStyle-CssClass="empty_row"  ShowFooter="false" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="gvDeliveries_RowDataBound" 
                DataKeyNames="c_delivery_system_id_pk,c_delivery_approval_req" 
                onrowcommand="gvDeliveries_RowCommand1">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="horizontal_line2" colspan="3">
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_350 font_12_pixel">
                                        <%#Eval("c_delivery_type_text")%>
                                    </td>
                                    <td class="gridview_row_width_350 font_12_pixel">
                                      <%--  <%#Eval("c_delivery_title")%>--%>
                                         <asp:Label ID="lblSession" runat="server" ></asp:Label>
                                    </td>
                                    <td class="gridview_row_width_300 tdright" align="right">
                                        <asp:Button ID="btnQuickLunch" CommandName="Detail" CommandArgument='<%#Eval("c_delivery_system_id_pk")%>'
                                            CssClass="cursor_hand" Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_quick_launch_button_text %>" />
                                         <asp:Label ID="lblAlreadyEnrollMessage" runat="server"></asp:Label>
                                        <asp:Button ID="btnDrop" Style="display: none;" OnClientClick="return confirmStatus();"
                                         runat="server" Text="<%$ LabelResourceExpression: app_drop_button_text %>" CommandName="Drop" CommandArgument='<%#Eval("c_course_id_fk")%>' />
                                        <asp:Literal ID="ltlEnroll" runat="server"></asp:Literal>
                                        
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_recurrence_text")%>
        </div>
        <br />
        <div class="div_controls_from_left">
            <asp:Label ID="lblRecurrences" runat="server"></asp:Label>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_prerequisite_text")%>
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>" EmptyDataRowStyle-CssClass="empty_row"  ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_course_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="<%$LabelResourceExpression: app_or_text %>"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_equivalancy_text")%>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>" EmptyDataRowStyle-CssClass="empty_row" ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_course_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="<%$LabelResourceExpression: app_or_text %>"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_fullfilment_text")%>
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" EmptyDataText="<%$ LabelResourceExpression: app_none_text %>" EmptyDataRowStyle-CssClass="empty_row" ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_course_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="<%$LabelResourceExpression: app_or_text %>"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
        &nbsp;
        </div>
        <br />
        <br />
    </div>
</asp:Content>
