<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvvojt.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Ojt.csvvojt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="content">
        <div class="div_header_popup_1">
            On Job Training Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        OJT Number:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtNumber" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Title:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtTitle" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Description:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Location:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtLocation" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Trainer:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtTrainer" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Date:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Start Time:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtStartTime" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        End Time:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtEndTime" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Duration:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDuration" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Type:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtType" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        Safety Brief:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkOjtIsSafety" runat="server" />
                    </td>
                    <td class="text_font_normal">
                        Frequency:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtFrequency" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Harm Related:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkOjtIsHarm" runat="server" />
                    </td>
                    <td class="text_font_normal">
                        Harm Title:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtHarmTitle" runat="server" Text=""></asp:Label> 
                    </td>
                    <td class="text_font_normal">
                        Harm Number:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtHarmNo" runat="server" Text=""></asp:Label> 
                    </td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        Certification Related:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkIsCertRelated" runat="server" />
                    </td>
                    <td class="text_font_normal">
                       Others: 
                    </td>
                    <td class="lable_td_width_1">
                       <asp:Label ID="lblOthers" runat="server" Text=""></asp:Label>  
                    </td>
                    <td></td>
                    <td></td>
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
                CellPadding="0" CellSpacing="0"  ShowHeader="false" ShowFooter="false" runat="server"
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
         <div class="div_header_popup_1">
            Acknowledgement:
        </div>
        <br />
        <div  class="div_padding_40 font_1">
        <asp:GridView ID="gvAcknowledgement" RowStyle-CssClass="record" GridLines="None"
            CssClass="gridview_normal_800" CellPadding="0" CellSpacing="0" ShowHeader="false"
            ShowFooter="false" runat="server" AutoGenerateColumns="False">
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
                                <td class="gridview_row_width_5">
                                    <%#Eval("acknowlegmentUser")%>
                                </td>
                                <td class="gridview_row_width_1" align="center">
                                    <%#Eval("acknowledged")%>
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
                <input type="button" value="Cancel" onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    class="cursor_hand" />
            </center>
        </div>
    </div>
</asp:Content>
