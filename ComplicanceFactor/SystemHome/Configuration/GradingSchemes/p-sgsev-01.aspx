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
              $("#<%=txtMinScore_InPercentage.ClientID %>").keypress(function (e) {

                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $("#<%=txtMaxScore_InPercentage.ClientID %>").keypress(function (e) {

                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $("#<%=txtMinScore_InNumbers.ClientID %>").keypress(function (e) {

                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $("#<%=txtMaxScore_InNumbers.ClientID %>").keypress(function (e) {

                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $("#<%=txtGpa.ClientID %>").keypress(function (e) {

                  if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                      return false;
                  }
              });
              $("#<%=txtGrade.ClientID %>").keypress(function (e) {

                  if (e.which > 31 && (e.which < 65 || e.which > 90) && (e.which < 97 || e.which > 122)) {
                      return false;
                  }
              });

          });
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
                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Min Percentage Score between 0 to 99 only."
                            ControlToValidate="txtMinScore_InPercentage" ValidationExpression="^([0-9]|[1-9][0-9])$" ValidationGroup="sgscv">&nbsp;
                            </asp:RegularExpressionValidator>
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InPercentage" runat="server" CssClass="textbox_50"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_maximum_score_text")%>:
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Max Percentage Score between 1 to 100 only."
                            ControlToValidate="txtMaxScore_InPercentage" ValidationExpression="^(100|[1-9][0-9]?)$" ValidationGroup="sgscv">&nbsp;
                            </asp:RegularExpressionValidator>
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InPercentage" runat="server" CssClass="textbox_50"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        <%=LocalResources.GetLabel("app_grade_letters_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGrade" runat="server" CssClass="textbox_75"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Min Percentage Score between 0 to 99 only."
                            ControlToValidate="txtMinScore_InNumbers" ValidationExpression="^([0-9]|[1-9][0-9])$" ValidationGroup="sgscv">&nbsp;
                            </asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_minimum_numeric_grade_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InNumbers" runat="server" CssClass="textbox_50"></asp:TextBox>
                    </td>
                    <td class="text_align">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Max Percentage Score between 1 to 100 only."
                            ControlToValidate="txtMaxScore_InNumbers" ValidationExpression="^(100|[1-9][0-9]?)$" ValidationGroup="sgscv">&nbsp;
                            </asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_maximum_numeric_grade_text")%>:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InNumbers" runat="server" CssClass="textbox_50"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        GPA:
                    <%-- <asp:RequiredFieldValidator ID="rfvGpa" ValidationGroup="sgsev" runat="server" ControlToValidate="txtGpa">
                    </asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGpa" runat="server" CssClass="textbox_75"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlPassingStatus" DataTextField="s_grading_scheme_value_pass_status_name" DataValueField="s_grading_scheme_value_pass_status_id_fk" runat="server" CssClass="width_30">
                   
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
                        <asp:Button ID="btnSaveAndAdd" runat="server"   Text="<%$ LabelResourceExpression: app_save_and_add_new_value_button_text %>" 
                            onclick="btnSaveAndAdd_Click" />
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
