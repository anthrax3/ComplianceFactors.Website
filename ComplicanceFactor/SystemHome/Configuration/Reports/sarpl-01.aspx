<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="sarpl-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Reports.sarpl_01" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="ContentPlaceHolder1_pnlSelectUserHeading" class="drag" 
        style="margin: 0px; padding: 0px; cursor: move; width: 100%; color: rgb(0, 0, 0); font-family: Arial, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; ">
        <div class="headerControl-jaha" style="margin: 0px; padding: 0px; ">
            <div class="manage_user_header_popup" 
                style="margin: 0px; padding: 3px; font-size: 12px; font-weight: bold; background-color: rgb(150, 205, 25); width: 796px; cursor: move;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:100%; ">
                            Add Report Locale Information <%=localeText %>:</td>
                        <td>
                            <input id="ContentPlaceHolder1_imgClose" class="cursor_hand" 
                                name="ctl00$ContentPlaceHolder1$imgClose" 
                                src="../../../Images/contentCloseButton.png" 
                                style="margin: 0px; padding: 0px; cursor: pointer; " type="image" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Repeater ID="rpLocles" runat="server">

        <HeaderTemplate>
          <table cellpadding="0" cellspacing="0" border="1" style="width:796px;">
             <tr>

                                       <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold;" align="center" width="200px" bgcolor="#C0C0C0">

                                            Label/Text 
                                            ID</td>                                  

                                       <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold;" 
                                            align="center" bgcolor="#C0C0C0"  width="200px">

                                            Native Label/Text</td>                                  


 

                                                                      

                                      <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold;" align="center" width="200px" bgcolor="#C0C0C0">
                                             <%=localeText %> Label/Text
                                        </td>                                  
                                       </tr>

        </HeaderTemplate>
        <ItemTemplate>
               <tr>

                                       <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold;" align="left">

                                             <%#Eval("s_report_param_label_name")%></td>                                  

                                       <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold;" 
                                            align="left" class="style4">

                                              <%#Eval("s_report_param_name")%></td>   </td>                                  



                                                                    
                                      <td style="font-size: 10px; padding: 3px 7px 0 10px; font-weight: bold; text-align:center;"  >
<input name="language_value" type="text"   value='<%#Eval("s_report_label")%>' />
                                            </td>                                  
                                  </tr>

        </ItemTemplate>
        <FooterTemplate>
            <tr><td colspan="4"> <asp:Button ID="btnFooterSaveNotification" ValidationGroup="saent" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_button_text %>"  OnClick="btnSave_Click"/><asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                             OnClick="btnCancel_Click"  /></td></tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
 <br /><br /><br /><br /><br /><br /><br /><br /><br />
                 
    </asp:Content>
