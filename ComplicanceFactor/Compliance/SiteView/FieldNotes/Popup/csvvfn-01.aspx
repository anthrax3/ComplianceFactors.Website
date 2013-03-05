<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvvfn-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.FieldNotes.Popup.csvvfn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 300px;
        }
    </style>
    <div>
        <div class="div_header_popup_1">
            FieldNote Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        FieldNote Id
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblFieldNote" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Title:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        Location:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Description:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_popup_1">
            Attachments:
        </div>
        <br />
        <div class="div_padding_40 align_center">
            <asp:GridView ID="gvAttachment" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_1" align="center">
                                        <%#Eval("sv_file_name")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="div_controls font_1">
            <center>
            <input type="button" value="Cancel" onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();" class="cursor_hand" />
               
            </center>
        </div>
    </div>
</asp:Content>
