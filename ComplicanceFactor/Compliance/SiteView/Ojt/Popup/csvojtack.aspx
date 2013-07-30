<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvojtack.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Ojt.Popup.csvojtack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 300px;
        }
    </style>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div id="content">
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_acknowledgement_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_ojt_id_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOJT" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_ojt_title_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOJTTitle" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_creation_date_time_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDateTime" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_send_by_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblSendBy" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_location_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5" class="align_left">
                        <%=LocalResources.GetLabel("app_acknowledgement_required_do_you_etc_text")%>:
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnAcknowledge" runat="server" class="cursor_hand" Text="<%$ LabelResourceExpression: app_yes_button_text %>" OnClick="btnAcknowledge_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnNoAcknowledge" runat="server" class="cursor_hand" Text="<%$ LabelResourceExpression: app_no_button_text %>" OnClick="btnNoAcknowledge_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
