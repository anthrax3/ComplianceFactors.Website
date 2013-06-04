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
            <%=LocalResources.GetLabel("app_fieldnote_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_fieldnote_id_text")%>
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblFieldNote" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_title_text")%>:
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
            </table>
        </div>
        <br />
        <div class="div_header_popup_1">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <div class="div_padding_40">
            <asp:GridView ID="gvAttachment" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False" onrowcommand="gvAttachment_RowCommand" DataKeyNames="sv_file_path,sv_file_name,sv_fieldnotes_attachments_id_pk">
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
                                        <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            runat="server" Text='<%#Eval("sv_file_name") %>' ForeColor="Black" CssClass="cursor_hand"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" ItemStyle-CssClass="gridview_row_width_7"
                        HeaderStyle-HorizontalAlign="Left" DataField="sv_file_name" HeaderText="Acknowledgements" />--%>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_popup_1">
            Acknowledgement:
        </div>
        <br />
        <div class="div_padding_40 font_1">
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
                <input type="button" value="<%=LocalResources.GetLabel("app_cancel_button_text")%>"
                    onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    class="cursor_hand" />
            </center>
        </div>
    </div>
</asp:Content>
