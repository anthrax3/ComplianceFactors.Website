<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="salpmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Languages.salpmp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });


        });
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {
            $("#<%=vsFileUpload.ClientID%>").hide();
            var oFileUpload = document.getElementsByName('<%=fupFiles.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);
        }
        function ValidateFileUpload(source, args) {



            var fuData = document.getElementById('<%= fupFiles.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                window.scrollTo = function () { }
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }

        }
        function vali_type(sender, args) {
            var id_value = document.getElementById('<%=fupFiles.ClientID %>').value;

            if (id_value != '') {
                var valid_extensions = /(.xls|.xlsx|.csv)$/i;
                if (valid_extensions.test(id_value)) {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;

                }
            }

        }
    </script>
   
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
      <div class="right div_padding_10">
            <asp:Button ID="btnHeaderClose" runat="server" 
                Text="<%$ LabelResourceExpression: app_close_button_text %>" 
                onclick="btnHeaderClose_Click" />
        </div>
        <div class="clear">
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_language_information_text")%>:
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        &nbsp;
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_left">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_english_us_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtus_english" CssClass="textbox_250 txtus_english" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <%--<input type="checkbox"  id="us_english" class="visibility" />--%>
                        <asp:CheckBox ID="chk_us_english" AutoPostBack="true" runat="server" OnCheckedChanged="chk_us_english_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_english_uk_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnglishUK" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_uk_english" AutoPostBack="true" runat="server" OnCheckedChanged="chk_uk_english_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_french_ca_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrenchCA" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_ca_french" AutoPostBack="true" runat="server" OnCheckedChanged="chk_ca_french_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_french_fr_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrenchFR" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_fr_french" AutoPostBack="true" runat="server" OnCheckedChanged="chk_fr_french_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_spanish_mx_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSpanishMX" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_mx_spanish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_mx_spanish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_spanish_spain_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSpanishSpain" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_sp_spanish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_sp_spanish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_portuguese_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPortuguese" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_portuguese" AutoPostBack="true" runat="server" OnCheckedChanged="chk_portuguese_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_chinese_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtChinese" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_simp_chinese" AutoPostBack="true" runat="server" OnCheckedChanged="chk_simp_chinese_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_german_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGerman" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_german" AutoPostBack="true" runat="server" OnCheckedChanged="chk_german_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_japanese_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtJapanese" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_japanese" AutoPostBack="true" runat="server" OnCheckedChanged="chk_japanese_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_russian_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRussian" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_russian" AutoPostBack="true" runat="server" OnCheckedChanged="chk_russian_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_danish_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDanish" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_danish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_danish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_polish_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPolish" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_polish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_polish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_swedish_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSwedish" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_swedish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_swedish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_finish_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFinnish" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_finnish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_finnish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_korean_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtKorean" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_korean" AutoPostBack="true" runat="server" OnCheckedChanged="chk_korean_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_italian_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtItalian" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_italian" AutoPostBack="true" runat="server" OnCheckedChanged="chk_italian_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_dutch_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDutch" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_dutch" AutoPostBack="true" runat="server" OnCheckedChanged="chk_dutch_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_indonesian_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtIndonesian" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_indonesian" AutoPostBack="true" runat="server" OnCheckedChanged="chk_indonesian_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_greek_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGreek" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_greek" AutoPostBack="true" runat="server" OnCheckedChanged="chk_greek_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_hungarian_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHungarian" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_hungarian" AutoPostBack="true" runat="server" OnCheckedChanged="chk_hungarian_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_norwegian_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNorwegian" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_norwegian" AutoPostBack="true" runat="server" OnCheckedChanged="chk_norwegian_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_turkish_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTurkish" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_turkish" AutoPostBack="true" runat="server" OnCheckedChanged="chk_turkish_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_arabic_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtArabic" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_arabic_rtl" AutoPostBack="true" runat="server" OnCheckedChanged="chk_arabic_rtl_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_01_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom01" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom01" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom01_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_02_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom02" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom02" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom02_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_03_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom03" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom03" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom03_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_04_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom04" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom04" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom04_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_05_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom05" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom05" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom05_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_06_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom06" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom06" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom06_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_07_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom07" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom07" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom07_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_08_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom08" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom08" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom08_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_09_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom09" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom09" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom09_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_10_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom10" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom10" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom10_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_11_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom11" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom11" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom11_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_12_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom12" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom12" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom12_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_custom_13_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom13" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_visible_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chk_Custom13" AutoPostBack="true" runat="server" OnCheckedChanged="chk_Custom13_CheckedChanged" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_language_administration_text")%>:
        </div>
        <br />
        <div class="div_controls_normal font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_export_lang_csv_file_tetxt")%>:
                    </td>
                    <td>
                        <asp:Button ID="btnExportLanguage" runat="server" Text="<%$ LabelResourceExpression: app_export_lang_csv_file_button_text %>"
                            OnClick="btnExportLanguage_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_import_lnag_csv_file_text")%>:
                    </td>
                    <td>
                        <asp:Button ID="btnImportLanguage"  runat="server" Text="<%$ LabelResourceExpression: app_import_lnag_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div class="right div_padding_10">
            <asp:Button ID="btnFooterClose" runat="server" 
                Text="<%$ LabelResourceExpression: app_close_button_text %>" 
                onclick="btnFooterClose_Click" />
        </div>
        <div class="clear">
        </div>
        <br />
    </div>
   
    <asp:ModalPopupExtender ID="mpeImport" runat="server" TargetControlID="btnImportLanguage"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload" Style="display: none;
        padding-left: 0px; background-color: White; padding-right: 0px;">
        <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                        Import Language:
                    </div>
                    <div class="right">
                        <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                            ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div>
            <br />
            <div class="uploadpanel">
                <asp:ValidationSummary CssClass="validation_summary_error_popup" ID="vsFileUpload" runat="server"
                    ValidationGroup="fileupload" />
                <asp:CustomValidator ValidationGroup="fileupload" ID="cvFileupload1" runat="server"
                    EnableClientScript="true" ErrorMessage="Please select file." ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                 <asp:CustomValidator ValidationGroup="fileupload" ID="CustomValidator1" runat="server"
                    EnableClientScript="true" ErrorMessage="Please select only xls,xlsx,csv." ClientValidationFunction="vali_type">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                Select file:
                            </td>
                            <td>
                                <asp:FileUpload ID="fupFiles" runat="server" Width="460" size="60" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <div class="multiple_button">
                    <asp:Button ID="btnUpload" ValidationGroup="fileupload" runat="server" Text="Upload"
                        CssClass="cursor_hand" OnClick="btnUpload_Click" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="Cancel" />
            </div>
        </div>
        <br />
    </asp:Panel>
</asp:Content>
