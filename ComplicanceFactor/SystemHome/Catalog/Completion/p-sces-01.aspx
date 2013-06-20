<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sces-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Completion.p_sces_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 150px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtEmployeeName.ClientID %>').value = '';
            document.getElementById('<%=txtEmployeeNumber.ClientID %>').value = '';

            return false;
        }
    </script>
    <div>
        <asp:Panel ID="pnlDefault" runat="server">
            <div class="div_header_popup_1">
                <%=LocalResources.GetLabel("app_employee_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_employee_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_employee_number_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGoSearch" runat="server" Text="<%$ LabelResourceExpression: app_go_search_button_text %>" OnClick="btnGoSearch_Click" />
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnReset" OnClientClick="return resetall();"  runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                        </td>
                        <td>
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
