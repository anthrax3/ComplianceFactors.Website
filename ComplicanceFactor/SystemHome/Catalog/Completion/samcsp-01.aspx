<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcsp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.samcsp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGoSearch">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="content_area_long">
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_courses_deliveries_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table cellspacing="10">
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_course_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_course_title_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_version_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeliveryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_title_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeliveryTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_delivery_type_text")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDeliveryType" DataValueField="s_delivery_type_system_id_pk"
                                DataTextField="s_delivery_type_name" CssClass="dropdownlist_width" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_date_from_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceDateFrom" Format="MM/dd/yyyy" TargetControlID="txtDateFrom"
                                runat="server">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_date_to_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceDateTo" Format="MM/dd/yyyy" TargetControlID="txtDateTo"
                                runat="server">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_instructor_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstructor" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_location_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocation" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_facility_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFacility" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_room_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtRoom" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_status_text")%>:
                        </td>
                        <td class="text_align">
                            <asp:DropDownList ID="ddlStatus" DataTextField="c_course_status_name" DataValueField="c_course_status_id"
                                CssClass="width_30" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_owner_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOwner" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoordinator" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_long">
                <br />
            </div>
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                                OnClick="btnReset_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnGoSearch" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"
                                OnClick="btnGoSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
