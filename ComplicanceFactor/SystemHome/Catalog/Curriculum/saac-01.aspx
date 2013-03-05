<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="saac-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.saac_01" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
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
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderArchiveCurriculum" OnClientClick="return ConfrimArchive();"
                            CssClass="cursor_hand" runat="server" Text="Confirm Archive Curriculum" 
                            onclick="btnHeaderArchiveCurriculum_Click"/>
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" 
                            Text="Cancel" onclick="btnHeaderCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
           Curriculum Information:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        Created by:
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
                        Created On:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreatedOn" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        * Curriculum Id
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCurriculumId" runat="server"></asp:Label>
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
                        * Curriculum Title
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCurriculumTitle" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal" valign="top">
                        * Description
                    </td>
                    <td class="lable_td_width_1" colspan="6">
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal" valign="top">
                        Abstract:
                    </td>
                    <td class="lable_td_width_1" colspan="6">
                        <asp:Label ID="lblAbstract" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                       Version:
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
                       Icon:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Owner:
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
                        Coordinator:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblcoordinator" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Cost:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCost" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="text_font_normal">
                                    Credit Hours
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:Label ID="lblCreditHours" CssClass="lable_td_width" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="text_font_normal">
                        Credit Units: 	
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCreditUnits" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Status: 
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblStatus" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td class="text_font_normal">
                                    Visible:
                                </td>
                                <td class="lable_td_width_1">
                                    <asp:Label ID="lblVisible" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2" class="text_font_normal">
                        Approval Required: 
                        <asp:Label ID="lblChkApprovalRequired" Font-Bold="true" CssClass="lable_td_width"
                            runat="server"></asp:Label>
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblApprovalRequired" CssClass="lable_td_width" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Path(s):
        </div>
        <br />
        <div>
            <div class="div_controls_from_left">
                <asp:GridView ID="gvPath" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                    AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_5">
                                    <tr>
                                        <td>
                                            <%#Eval("c_curricula_path_name")%>
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
        </div>
        <br />
        <div class="div_header_long">
            Recertificstion Path(s):
        </div>
        <br />
        <div>
            <div class="div_controls_from_left">
                <asp:GridView ID="gvRecertPath" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                    AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_5">
                                    <tr>
                                        <td>
                                            <%#Eval("c_curricula_recert_path_name")%>
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
        </div>
        <br />
        <div class="div_header_long">
            Category(ies): 
        </div>
        <br />
       <div class="div_controls_from_left">
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
            Domain(s): 
        </div>
        <br />
        <div class="div_controls_from_left">
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
           Audience(s): 
        </div>
        <br />
        <div class="div_header_long">
        Recurrance: 
        </div>
        <br />
        <div class="default_font_size font_1 ">
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td valign="top" class="font_normal">
                        <asp:Label ID="lblRecurrance" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
         <br />
        <div class="div_header_long">
         Attachment(s):  
        </div>
         <div class="div_controls_from_left">
            <asp:GridView ID="gvCurriculumAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_curriculum_attachment_file_guid,c_curriculum_attachment_file_name,c_curriculum_attchments_system_id_pk"
                    runat="server" AutoGenerateColumns="False" CssClass="gridview_normal_800" 
                onrowcommand="gvCurriculumAttachments_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("c_curriculum_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
          Prerequisites: 
        </div>
        <div class="div_controls_from_left">
            <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("c_curriculum_text")%>
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
           Equivalencies: 
        </div>
         <div class="div_controls_from_left">
        <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("c_curriculum_text")%>
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
           Fulfillments: 
        </div>
          <div class="div_controls_from_left">
        <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("c_curriculum_text")%>
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
            Custom Fields: 
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td class="text_font_normal">
                        Custom 01:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                         Custom 02:
                    </td>
                    <td class="lable_td_width_1">
                      <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 03:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Custom 04:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                         Custom 05:
                    </td>
                    <td class="lable_td_width_1">
                      <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 06:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        Custom 07:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 08:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 09:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        Custom 10:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 11:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                    </td>
                    <td class=" text_font_normal">
                        Custom 12:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class=" text_font_normal">
                        Custom 13:
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
                        <asp:Button ID="btnFooterConfirmArchiveCurriculum" OnClientClick="return ConfrimArchive();"
                            CssClass="cursor_hand" runat="server" Text="Confirm Archive Curriculum" 
                            onclick="btnFooterConfirmArchiveCurriculum_Click"/>
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" 
                            Text="Cancel" onclick="btnFooterCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
