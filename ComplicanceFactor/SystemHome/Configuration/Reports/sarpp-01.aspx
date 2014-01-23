<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="sarpp-01.aspx.cs"
    Inherits="ComplicanceFactor.SystemHome.Configuration.Reports.sarpp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 500px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 380px;
            overflow-x: hidden;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtParameterName.ClientID %>').value = '';


            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnSave.ClientID %>').click();
                return true;

            }
        });

        function changeType() {
            if ($("#<%=ddlType.ClientID %>").val() == "System Drop-down") {
                $("#trItems").show();
            } else {
                $("#trItems").hide();

            }
        }
        function changeTable() {
            if ($("#<%=ddlTable.ClientID %>").val() == "c_tb_miris_master") {
                $("#<%=ddlField.ClientID %>").show();
                $("#<%=ddlCourseField.ClientID %>").hide();
            } else {
                $("#<%=ddlField.ClientID %>").hide();
                $("#<%=ddlCourseField.ClientID %>").show();
            }
        }
    </script>
    <div id="content">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnSave">
            <div class="div_header_popup_1">
                <%=LocalResources.GetLabel("app_report_parameter_title")%>:
            </div>
            <br />
            <asp:ValidationSummary class="validation_summary_error" ID="vssacataml" runat="server"
                ValidationGroup="sarespp" />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="sarespp"
                                ControlToValidate="txtParameterName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *
                            <%=LocalResources.GetLabel("app_report_parameter_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtParameterName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_report_visible")%>:
                        </td>
                        <td>
                            <asp:CheckBox ID="chkVisible" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sarespp"
                                ControlToValidate="txtLabelId" ErrorMessage="<%$ TextResourceExpression: app_report_label_id_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>
                            *<%=LocalResources.GetLabel("app_report_label_id")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLabelId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_report_type")%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" CssClass="ddl_user_advanced_search" runat="server"
                                onchange="changeType()">
                                <asp:ListItem Text="Varchar" Value="Varchar"></asp:ListItem>
                                <asp:ListItem Text="Date" Value="Date"></asp:ListItem>
                                <asp:ListItem Text="Int" Value="Int"></asp:ListItem>
                                <asp:ListItem Text="System Drop-down" Value="System Drop-down"></asp:ListItem>
                                <asp:ListItem Text="System Table" Value="System Table"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display: none" id="trItems">
                        <td>
                            items:
                        </td>
                        <td colspan="3" style="text-align: left;">
                            <asp:TextBox ID="txtItems" CssClass="textbox_long" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Table:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTable" CssClass="ddl_user_advanced_search" runat="server"  onchange="changeTable()">
                                <asp:ListItem Text="c_tb_miris_master" Value="c_tb_miris_master" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="e_sp_get_all_completion_courses" Value="e_sp_get_all_completion_courses"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Field:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlField" CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCourseField" CssClass="ddl_user_advanced_search" runat="server"
                                Style="display: none;">
                                <asp:ListItem Text="u_first_name" Value="u_first_name" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="u_last_name" Value="u_last_name"></asp:ListItem>
                                <asp:ListItem Text="title" Value="title"  ></asp:ListItem>
                                <asp:ListItem Text="completeddate" Value="completeddate"></asp:ListItem>
                                <asp:ListItem Text="score" Value="score" ></asp:ListItem>                                
                                  <asp:ListItem Text="status" Value="status"></asp:ListItem>
                                   <asp:ListItem Text="deliveryType" Value="deliveryType"></asp:ListItem>
                                <asp:ListItem Text="t_transcript_time_spent" Value="t_transcript_time_spent"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <%=LocalResources.GetLabel("app_description_text")%>:
                        </td>
                        <td class="align_left" colspan="7">
                            <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="50"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnSave" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_save_button_text %>"
                                runat="server" ValidationGroup="sarespp" OnClick="btnSave_Click" />
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
