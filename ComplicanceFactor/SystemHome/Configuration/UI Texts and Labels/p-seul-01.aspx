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
            UI Label:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Native
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
                        English (US)
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnglishUs"  CssClass="textbox_250" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        English (UK)
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
                        French (CA)
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
                        French (FR)
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
                        Spanish (MX)
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
                        Spanish (SP)
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
                       Portuguese
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
                        Chinese (Simplified)
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
                        German
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
                        Japanese
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
                        Russian
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
                        Danish
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
                        Polish
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
                        Swedish
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
                        Finnish
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
                        Korean
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
                        Italian
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
                        Dutch
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
                        Indonesian
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
                        Greek
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
                        Hungarian
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
                        Norwegian
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
                        Turkish
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
                        Arabic
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
                        Custom 01
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
                        Custom 02
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
                        Custom 03
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
                        Custom 04
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
                        Custom 05
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
                        Custom 06
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
                        Custom 07
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
                        Custom 08
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
                        Custom 09
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
                        Custom 10
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
                        Custom 11
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
                        Custom 12
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
                        Custom 13
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
                <asp:Button ID="btnSaveUiLabel" CssClass="cursor_hand" Text="Save UI Label" 
                    runat="server" onclick="btnSaveUiLabel_Click" />
            </div>
            <div class="right">
                <asp:Button ID="btnCloseWindow" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    runat="server" Text="Close Window" />
            </div>
            <div class="clear">
            </div>
        </div>
        <br />
    </div>
</asp:Content>
