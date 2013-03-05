<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvsfn-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.FieldNotes.Popup.csvsfn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 180px;
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
                        url: "csvsfn-01.aspx/DeleteUser",

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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_csvsfn" runat="server"
        ValidationGroup="csvsfn"></asp:ValidationSummary>
    <div>
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header_700">
            Inspection Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="Please enter user name" ValidationGroup="csvsfn">&nbsp;
                        </asp:RequiredFieldValidator>
                        User Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" CssClass="textbox_width_260" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="csvsfn" />
                    </td>
                </tr>
            </table>
            <div style="padding: 0 0 0 70px;">
                <asp:GridView ID="gvNewUser" RowStyle-CssClass="record" ShowHeader="false" GridLines="None"
                    CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAddUser" Text='<%#Eval("s_user_summary") %>' Enabled="false"
                                    CssClass="textbox_width_260" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35px">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("sv_fieldnote_sent_to_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="X" />'
                                    class="deleteUser cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" class="paging_700">
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
