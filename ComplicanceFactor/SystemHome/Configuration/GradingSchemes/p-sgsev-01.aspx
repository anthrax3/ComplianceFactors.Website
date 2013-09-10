<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sgsev-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.GradingSchemes.edit_grading_value" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 575px;
        }
    </style>
      <script type="text/javascript">
          $(document).ready(function () {
              alert(1);
              $(".allownumeric").keypress(function (e) {
                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $(".allowalpha").keypress(function (e) {
                  if (e.which < 97 /* a */ || e.which > 122 /* z */) {
                      e.preventDefault();
                  }
              });
          });
    </script>  
    <script type="text/javascript">
        function validateMinMaxPercentage(sender, args) {
            var minPercentage = document.getElementById('<%=txtMinScore_InPercentage.ClientID %>').value;
            var maxPercentage = document.getElementById('<%=txtMaxScore_InPercentage.ClientID %>').value;
            if (minPercentage != "" && maxPercentage != "") {
                if (parseInt(minPercentage) < parseInt(maxPercentage)) {
                    args.IsValid = true;
                }
                else {
                    args.IsValid = false;
                }
            }

        }
        function validateMinMaxNumeric(sender, args) {
            var minNumeric = document.getElementById('<%=txtMinScore_InNumbers.ClientID %>').value;
            var maxNumeric = document.getElementById('<%=txtMaxScore_InNumbers.ClientID %>').value;
            if (minNumeric != "" && maxNumeric != "") {
                if (parseInt(minNumeric) < parseInt(maxNumeric)) {
                    args.IsValid = true;
                }
                else {
                    args.IsValid = false;
                }
            }

        }
    </script>
    <%--<div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>--%>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_sgsev" runat="server"
        ValidationGroup="sgsev"></asp:ValidationSummary> 
    
        <div id="content">
        <div class="div_header_900">
            <%=LocalResources.GetLabel("app_add_grading_value_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellspacing="10px">
                <tr>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" CssClass="textarea_long_3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" CssClass="textarea_long_3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td>
                        <textarea id="txtDescription" runat="server" rows="7" cols="60" class="style1"></textarea>
                    </td>
                </tr>
            </table>
            <table cellspacing="10px">
                <tr>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_minimum_percent_score_text")%>:
                        <asp:RegularExpressionValidator ID="revMinPercentage" runat="server" ErrorMessage="Min Percentage Score between 0 to 99 only."
                            ControlToValidate="txtMinScore_InPercentage" ValidationExpression="^([0-9]|[1-9][0-9])$"
                            ValidationGroup="sgsev">&nbsp;
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMinPercentage" runat="server" ValidationGroup="sgsev"
                            ControlToValidate="txtMinScore_InPercentage" ErrorMessage="Please Enter Minimum Percentage Value.">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvValidateMinMaxPercentage" EnableClientScript="true" ClientValidationFunction="validateMinMaxPercentage"
                        ValidateEmptyText="true" ValidationGroup="sgsev" runat="server" ErrorMessage="Min Percentage value should not exceed from max Percentage score.">&nbsp;</asp:CustomValidator>
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InPercentage" runat="server" CssClass="textbox_50 allownumeric"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_maximum_percent_score_text")%>:
                        <asp:RegularExpressionValidator ID="revMaxPercentage" runat="server" ErrorMessage="Max Percentage Score between 1 to 100 only."
                            ControlToValidate="txtMaxScore_InPercentage" ValidationExpression="^(100|[1-9][0-9]?)$"
                            ValidationGroup="sgsev">&nbsp;
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMaxPercentage" runat="server" ValidationGroup="sgsev"
                            ControlToValidate="txtMaxScore_InPercentage" ErrorMessage="Please Enter Maximum Percentage Value.">&nbsp;
                        </asp:RequiredFieldValidator>
                        
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InPercentage" runat="server" CssClass="textbox_50 allownumeric"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_grade_letters_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGrade" runat="server" CssClass="textbox_75 allowalpha"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        <asp:RegularExpressionValidator ID="revMinNumeric" runat="server" ErrorMessage="Min Numeric Score between 0 to 99 only."
                            ControlToValidate="txtMinScore_InNumbers" ValidationExpression="^([0-9]|[1-9][0-9])$"
                            ValidationGroup="sgsev">&nbsp;
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMinNumeric" runat="server" ValidationGroup="sgsev"
                            ControlToValidate="txtMinScore_InNumbers" ErrorMessage="Please Enter Minimum Numeric Value.">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvValidateMinMaxNumeric" EnableClientScript="true" ClientValidationFunction="validateMinMaxNumeric"
                      ValidateEmptyText="true" ValidationGroup="sgsev" runat="server" ErrorMessage="Min Numeric value should not exceed from max Numeric score.">&nbsp;</asp:CustomValidator>
                        <%=LocalResources.GetLabel("app_minimum_numeric_grade_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InNumbers" runat="server" CssClass="textbox_50 allownumeric"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        <asp:RegularExpressionValidator ID="revMaxNumeric" runat="server" ErrorMessage="Max Numeric Score between 1 to 100 only."
                            ControlToValidate="txtMaxScore_InNumbers" ValidationExpression="^(100|[1-9][0-9]?)$"
                            ValidationGroup="sgsev">&nbsp;
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMaxNumeric" runat="server" ValidationGroup="sgsev"
                            ControlToValidate="txtMaxScore_InNumbers" ErrorMessage="Please Enter Maximum Numeric Value.">&nbsp;
                        </asp:RequiredFieldValidator>
                        <%=LocalResources.GetLabel("app_maximum_numeric_grade_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InNumbers" runat="server" CssClass="textbox_50 allownumeric"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        GPA:
                        <%-- <asp:RequiredFieldValidator ID="rfvGpa" ValidationGroup="sgsev" runat="server" ControlToValidate="txtGpa">
                    </asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGpa" runat="server" CssClass="textbox_75 allownumeric"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_descriptor_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescriptor" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_qualification_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtQualification" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_passing_status_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:DropDownList ID="ddlPassingStatus" DataTextField="s_grading_scheme_value_pass_status_name"
                            DataValueField="s_grading_scheme_value_pass_status_id_fk" runat="server" CssClass="width_30">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="text_align">
                        <asp:Button ID="btnSaveAndAdd" runat="server" Text="<%$ LabelResourceExpression: app_save_and_add_new_value_button_text %>"
                            OnClick="btnSaveAndAdd_Click" ValidationGroup="sgsev" />
                    </td>
                    <td colspan="3">
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                            Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
