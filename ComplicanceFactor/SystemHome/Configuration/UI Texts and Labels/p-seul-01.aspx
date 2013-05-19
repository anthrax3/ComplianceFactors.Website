<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-seul-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.Edit_Ui_Label" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" 
    runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 650px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 450px;
        }
    </style>
    <div>
        <div class="div_header_650">
            <%=LocalResources.GetLabel("app_ui_label_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_native_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblNative" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_english_us_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnglishUs"  CssClass="textbox_250" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_english_uk_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txEnglishUk" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_french_ca_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrenchCa" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_french_fr_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrenchFr" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_spanish_mx_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSpanishMx" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_spanish_spain_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSpanishSp" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                 <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_portuguese_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPortuguese" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_chinese_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtChineseSimplified" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_german_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGerman" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                      <%=LocalResources.GetLabel("app_japanese_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtJapanese" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_russian_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRussian" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                      <%=LocalResources.GetLabel("app_danish_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDanish" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_polish_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPolish" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_swedish_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSwedish" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_finish_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFinish" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_korean_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtKorean" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_italian_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtItalian" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                      <%=LocalResources.GetLabel("app_dutch_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDutch" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_indonesian_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtIndonesian" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_greek_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGreek" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_hungarian_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHungarian" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                         <%=LocalResources.GetLabel("app_norwegian_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNorwegian" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_turkish_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTurkish" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_arabic_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtArabic" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_01_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom01" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom02" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom03" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_04_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom04" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_05_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom05" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_06_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom06" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom07" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom08" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom09" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom10" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_11_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom11" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_12_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom12" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_custom_13_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom13" CssClass="textbox_250" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                
            </table>
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnSaveUiLabel" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_save_ui_label_button_text %>" 
                    runat="server" onclick="btnSaveUiLabel_Click" />
            </div>
            <div class="right">
                <asp:Button ID="btnCloseWindow" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    runat="server" Text="<%$ LabelResourceExpression: app_close_window_button_text %>" />
            </div>
            <div class="clear">
            </div>
        </div>
        <br />
    </div>
</asp:Content>
