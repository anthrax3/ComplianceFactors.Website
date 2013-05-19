<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tcmdmp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tcmdmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    function resetall() {
        document.getElementById('<%=txtCourseId.ClientID %>').value = '';
        document.getElementById('<%=txtTitle.ClientID %>').value = '';
        document.getElementById('<%=txtVersion.ClientID %>').value = '';
        document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
        document.getElementById('<%=txtOwner.ClientID %>').value = '';
        document.getElementById('<%=txtCoordinator.ClientID %>').value = '';
        return false;
    }
    </script>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_catalog_search_text")%>:
    </div>
    <div class="div_controls font_1">
        <br />
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_course_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_title_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_version_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtVersion" CssClass="textbox_long" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_status_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus"  DataTextField="c_course_status_name" DataValueField="c_course_status_id" CssClass="ddl_user_advanced_search" runat="server">
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
        </table>
        <br />
        <table class="table_td_300">
            <tr>
                <td>
                    
                </td>
                <td class="align_center">
                    <asp:Button ID="btnReset" runat="server" OnClientClick="return resetall();" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                </td>
                <td class="align_right">
                    <asp:Button ID="btnGoSearch" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" 
                        onclick="btnGoSearch_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
