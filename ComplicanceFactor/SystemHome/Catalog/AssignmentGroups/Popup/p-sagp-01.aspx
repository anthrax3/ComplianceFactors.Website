<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sagp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.Popup.p_sagp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 800px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 200px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        function HideMsg() {
            $("[id*=divSuccess]").fadeOut(500);
        }
    </script>
    <div id="content">
        <asp:ValidationSummary ID="vs_p_sagp" ValidationGroup="sagp" class="validation_summary_error"
            runat="server" />
        <div id="divError" runat="server" class="msgarea_error" style="display: none;" />
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;" />
        <div class="div_header_800">
            <%=LocalResources.GetLabel("app_add_parameter_text")%>:
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_element_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlElement" runat="server" CssClass="ddl_user_advanced_search"
                            DataTextField="e_assignment_element_name" DataValueField="e_assignment_element_id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_operator_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="ddl_user_advanced_search"
                            DataTextField="e_assignment_operator_name" DataValueField="e_assignment_operator_id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvValues" runat="server" ValidationGroup="sagp"
                            ControlToValidate="txtValues" ErrorMessage="Please enter values.">&nbsp;</asp:RequiredFieldValidator>--%>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_values_text")%>:                        
                    </td>
                    <td>
                        <asp:TextBox ID="txtValues" runat="server" CssClass="textbox_long"></asp:TextBox>                                
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnAddParameter" runat="server" ValidationGroup="sagp" Text="<%$ LabelResourceExpression: app_save_and_add_new_parameter_button_text %>"
                            OnClick="btnAddParameter_Click" />
                    </td>
                    <td colspan="5">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
