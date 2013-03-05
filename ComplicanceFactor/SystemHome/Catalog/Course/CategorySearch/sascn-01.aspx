<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sascn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.CatalogPopup.sascn_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <title></title>
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
            document.getElementById('<%=txtCategoryName.ClientID %>').value = '';
            document.getElementById('<%=txtCategoryId.ClientID %>').value = '';

            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_popup_1">
               <%=LocalResources.GetLabel("app_categories_search_text")%>:
              
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_category_name_text")%>:
                           
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_category_id_text")%>:
                            
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text%>" runat="server"
                                OnClick="btnGosearch_Click" />
                        </td>
                        <td class="align_left" >
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td class="align_right"  >
                            <asp:Button ID="btnCancel" CssClass="cursor_hand"  OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();" 
                            runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                        </td>
                    </tr>
                </table>
            </div>

        </asp:Panel>
    </div>
    </form>
</body>
</html>
