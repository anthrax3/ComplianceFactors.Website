﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
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
        $(function () {

            $("#<%= ddlOperator.ClientID %> option[value='Between']").attr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Not Between']").attr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Starts with']").removeAttr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Not Starts with']").removeAttr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Contains']").removeAttr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Not Contains']").removeAttr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Less than']").attr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Greater than']").attr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='Before']").attr("disabled", "disabled");
            $("#<%= ddlOperator.ClientID %> option[value='After']").attr("disabled", "disabled");

            $('#<%= ddlElement.ClientID %>').change(function () {
                if (this.value == 'u_hris_hire_date' || this.value == 'u_hris_last_rehire_date') {
                    $("#<%= ddlOperator.ClientID %> option[value='Between']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Between']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Starts with']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Starts with']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Contains']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Contains']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Less than']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Greater than']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Before']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='After']").removeAttr("disabled", "disabled");
                }
                else if (this.value == 'u_country_id_fk' || this.value == 'u_locale_id_fk' || this.value == 'u_timezone_fk') {
                    $("#<%= ddlOperator.ClientID %> option[value='Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Starts with']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Starts with']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Contains']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Contains']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Less than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Greater than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Before']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='After']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Null']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Null']").attr("disabled", "disabled");
                }

                else if (this.value == 'u_sr_is_manager' || this.value == 'u_sr_is_instructor' || this.value == 'u_sr_is_compliance' || this.value == 'u_sr_is_training' || this.value == 'u_sr_is_administrator') {
                    $("#<%= ddlOperator.ClientID %> option[value='Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Starts with']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Starts with']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Contains']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Contains']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Less than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Greater than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Before']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='After']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Null']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Null']").attr("disabled", "disabled");
                }
                else {
                    $("#<%= ddlOperator.ClientID %> option[value='Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Between']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Starts with']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Starts with']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Contains']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Not Contains']").removeAttr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Less than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Greater than']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='Before']").attr("disabled", "disabled");
                    $("#<%= ddlOperator.ClientID %> option[value='After']").attr("disabled", "disabled");
                }
            });
        });      
    </script>
    <script type="text/javascript">
        function HideMsg() {
            $("[id*=divSuccess]").fadeOut(500);
        }
    </script>
    
       <script type="text/javascript">
           $(function () {
               $('#<%= ddlElement.ClientID %>').change(function () {
                   if (this.value == 'Assigned' || this.value == 'Enrolled' || this.value == 'Completed' || this.value == 'Passed' || this.value == 'Failed') {
                       $('#<%=txtValues.ClientID %>,#<%=ddlOperator.ClientID %>').attr("disabled", "disabled");
                   }
                   else {
                       $('#<%=txtValues.ClientID %>,#<%=ddlOperator.ClientID %>').removeAttr("disabled");

                   }
               });
           });
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
                        <asp:DropDownList ID="ddlElement" runat="server" CssClass="ddl_user_advanced_search test"
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
