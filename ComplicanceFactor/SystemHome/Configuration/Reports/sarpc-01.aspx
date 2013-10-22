<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="sarpc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Reports.sarpc_01" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style type="text/css">
       body
        {
            width: 500px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 380px;
             overflow-x:hidden;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtColumnName.ClientID %>').value = '';


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


    </script>
      <div id="content">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnSave">
            <div class="div_header_popup_1">
                  <%=LocalResources.GetLabel("app_report_column_title")%>: 
            </div>
           <br />
            <asp:ValidationSummary class="validation_summary_error" ID="vssacataml" runat="server"
                ValidationGroup="sarespc" />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="sarespc"
                                ControlToValidate="txtColumnName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>                           
                           * <%=LocalResources.GetLabel("app_report_column_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtColumnName" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sarespc"
                                ControlToValidate="txtLabelId" ErrorMessage="<%$ TextResourceExpression: app_report_label_id_error_empty %>">&nbsp;
                            </asp:RequiredFieldValidator>                            
                            * <%=LocalResources.GetLabel("app_report_label_id")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLabelId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_report_type")%>:
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlType" CssClass="ddl_user_advanced_search" runat="server">
                                <asp:ListItem Text="Varchar" Value="Varchar"></asp:ListItem>
                                <asp:ListItem Text="Date" Value="Date"></asp:ListItem>
                                <asp:ListItem Text="Int" Value ="Int"></asp:ListItem>
                                 <asp:ListItem Text="System Drop-down" Value="System Drop-down"></asp:ListItem>
                                <asp:ListItem Text="System Table" Value ="System Table"></asp:ListItem>
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
                            <asp:Button ID="btnSave" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_save_button_text %>" runat="server" ValidationGroup="sarespc"
                                OnClick="btnSave_Click" />
                        </td>
                        <td class="align_left" >
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td class="align_right"  >
                            <asp:Button ID="btnCancel" CssClass="cursor_hand"  OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();" 
                            runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </td>
                    </tr>
                </table>
            </div>

        </asp:Panel>
    </div>
</asp:Content>


