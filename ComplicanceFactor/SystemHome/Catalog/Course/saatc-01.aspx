<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saatc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.saatc_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>    <script type="text/javascript">

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
        function lastEquivalenciesrow() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }
       

    </script>
    <script type="text/javascript" language="javascript">
        function ConfrimArchive() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderArchiveCourse" OnClientClick="return ConfrimArchive();"
                            CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_confirm_archive_course_text%>"
                            OnClick="btnHeaderArchiveCourse_Click" />
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_course_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_created_by_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal" valign="top">
                        <%=LocalResources.GetLabel("app_created_on_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreatedOn" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        *
                        <%=LocalResources.GetLabel("app_course_id_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCourseId" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        *
                        <%=LocalResources.GetLabel("app_course_title_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCourseTitle" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal" valign="top">
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="lable_td_width_1" colspan="6">
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal" valign="top">
                        <%=LocalResources.GetLabel("app_abstract_text")%>:
                    </td>
                    <td class="lable_td_width_1" colspan="6">
                        <asp:Label ID="lblAbstract" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_version_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblVersion" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_icon_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOwner" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblcoordinator" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_cost_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCost" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="text_font_normal">
                                    <%=LocalResources.GetLabel("app_credit_hours_text")%>:
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:Label ID="lblCreditHours" CssClass="lable_td_width" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_credit_units_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreditUnits" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblStatus" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td class="text_font_normal">
                                    <%=LocalResources.GetLabel("app_visible_text")%>:
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:Label ID="lblVisible" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2" class="text_font_normal">
                        <%=LocalResources.GetLabel("app_approval_required_text")%>:
                        <asp:Label ID="lblChkApprovalRequired" Font-Bold="true" CssClass="lable_td_width"
                            runat="server"></asp:Label>
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblApprovalRequired" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Available From:
                    </td>
                    <td class="align_left">
                         <asp:TextBox ID="txtAvailableFrom" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="text_font_normal">
                                   Available To:
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:TextBox ID = "txtAvailableTo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="text_font_normal">
                         Effective Date:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:TextBox ID="txtEffectiveDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="text_font_normal">
                        Cut-off Date:
                    </td>
                    <td class="align_left">
                         <asp:TextBox ID="txtCutOffDate" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="text_font_normal">
                                  Cut-off Time:
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:TextBox ID = "txtCutoffTime" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>                   
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_delivery_(ies)_text")%>:
        </div>
        <br />
        <div>
            <asp:GridView ID="gvDeliveries" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                DataKeyNames="c_delivery_system_id_pk" CellSpacing="0" ShowHeader="false" ShowFooter="false"
                runat="server" AutoGenerateColumns="False" OnRowDataBound="gvDeliveries_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table class="font_normal">
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
                                        <asp:Label ID="lblSession" runat="server"></asp:Label>
                                    </td>
                                    <td class="gridview_row_width_300" align="right">
                                        <table>
                                            <tr>
                                                <td class="gridview_row_width_1" align="right">
                                                </td>
                                                <td class="gridview_row_width_1" align="right">
                                                </td>
                                            </tr>
                                        </table>
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
            <%=LocalResources.GetLabel("app_category_text")%>:
        </div>
        <br />
        <div>
            <asp:GridView ID="gvCategory" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("s_category_name_us_english")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- <%# "(" + Eval("s_category_id") + ")"%>--%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_domain_text")%>:
        </div>
        <br />
        <div>
            <asp:GridView ID="gvDomain" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("u_domain_name")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- <%# "(" + Eval("u_domain_id_pk") + ")"%>--%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_audience_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_Recurrance_text")%>:
        </div>
        <div class="div_controls_from_left">
        </div>
        <br />
        <div class="default_font_size ">
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td valign="top" class="font_normal">
                        <asp:Label ID="lblRecurrance" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <%--start--%>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_prerequisites_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_6">
                                <tr>
                                    <td>
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
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
            <%=LocalResources.GetLabel("app_equivalencies_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_6">
                                <tr>
                                    <td>
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
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
            <%=LocalResources.GetLabel("app_fulfillments_text")%>:
        </div>
        <div class="div_controls_from_left">
            <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_6" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_6">
                                <tr>
                                    <td>
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Label ID="lblFulfillments" runat="server"></asp:Label>
        </div>
        <%--End--%>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_01_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_02_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_03_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_04_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_05_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_06_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_07_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_08_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_09_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_10_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_11_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_12_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        <%=LocalResources.GetLabel("app_custom_13_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom13" runat="server"></asp:Label>
                    </td>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterConfirmArchiveCourse" OnClientClick="return ConfrimArchive();"
                            CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_confirm_archive_course_text%>"
                            OnClick="btnFooterConfirmArchiveCourse_Click" />
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
