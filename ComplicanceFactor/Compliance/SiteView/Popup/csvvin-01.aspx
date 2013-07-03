<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="csvvin-01.aspx.cs"
    Inherits="ComplicanceFactor.Compliance.SiteView.Popup.csvvin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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
  <div id="content">
        <div class="div_header_popup_1">
            <%=LocalResources.GetLabel("app_inspection_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_inspection_id_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblInspectionId" runat="server" Text="Label"></asp:Label>
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
                        <%=LocalResources.GetLabel("app_inspection_name_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblInspectionName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_inspection_description_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_is_default_text")%>:
                    </td>
                    <td class="align_left">
                        &nbsp;
                        <asp:CheckBox ID="chkIsDefault" Enabled="false" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_popup_1">
            <%=LocalResources.GetLabel("app_questions_text")%>:
        </div>
        <br />
        <div class="div_padding_40 align_center">
            <asp:GridView ID="gvQuestions" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="horizontal_line" colspan="5">
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_1" align="center">
                                        <%#Eval("sv_mi_templete_question_display_order")%>
                                    </td>
                                    <td class="gridview_row_width_300">
                                        <%#Eval("sv_mi_templete_question")%>
                                    </td>
                                    <td class="gridview_row_width_300" align="center">
                                      <%--  <%#Eval("sv_mi_templete_question_type")%>--%>
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
                <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                    OnClick="btnFooterCancel_Click" />
            </center>
        </div>
    </div>
</asp:Content>
