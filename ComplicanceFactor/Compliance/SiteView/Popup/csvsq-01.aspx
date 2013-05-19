<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="csvsq-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Popup.csvsq_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 150px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".deleteUser").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "csvsq-01.aspx/DeleteUser",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary class="validation_summary_error" ID="vs_csvsq" runat="server"
        ValidationGroup="csvsq"></asp:ValidationSummary>
    <div>
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_inspection_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="<%$ TextResourceExpression: app_user_name_error_empty %>" ValidationGroup="csvsq">&nbsp;
                        </asp:RequiredFieldValidator>
                        <%=LocalResources.GetLabel("app_user_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" CssClass="textbox_width_260" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="<%$ LabelResourceExpression: app_add_button_text %>"
                            OnClick="btnAdd_Click" ValidationGroup="csvsq" />
                    </td>
                </tr>
            </table>
            <div style="padding: 0 0 0 70px;">
                <asp:GridView ID="gvNewUser" RowStyle-CssClass="record" ShowHeader="false" GridLines="None"
                    CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAddUser" Text='<%#Eval("s_user_summary") %>' Enabled="false" CssClass="textbox_width_260"
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35px">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("s_send_user_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="X" />'
                                    class="deleteUser cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div class="div_padding_135">
                <div class="left">
                    <asp:Button ID="btnSend" runat="server" Text="<%$ LabelResourceExpression: app_send_button_text %>" OnClick="btnSend_Click" />
                </div>
                <div class="right">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
