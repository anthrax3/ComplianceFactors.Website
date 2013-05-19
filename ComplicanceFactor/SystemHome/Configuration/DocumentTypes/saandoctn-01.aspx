<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandoctn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DocumentTypes.saandoctn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saandoctn" runat="server"
        ValidationGroup="saandoctn"></asp:ValidationSummary>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saandoctn" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_document_type_button_text %>" OnClick="btnHeaderSave_Click" />
                    </td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                    </td>
                    <td  class="btnreset_td align_right">
                        <asp:Button ID="btnHeaderReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        &nbsp;</td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" runat="server"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_english_us_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_id_text")%>:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDocumentTypeId" runat="server" ValidationGroup="saandoctn"
                            ControlToValidate="txtDocumentTypeId_EnglishUS" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDocumentTypeId_EnglishUS" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:RequiredFieldValidator ID="rfvDocumentTypeName" runat="server" ValidationGroup="saandoctn"
                            ControlToValidate="txtDocumentTypeName_EnglishUs" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDocumentTypeName_EnglishUs" CssClass="textbox_long" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:RequiredFieldValidator ID="rfvDocumentDescription" runat="server" ValidationGroup="saandoctn"
                            ControlToValidate="txtDescription_EnglishUs" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDescription_EnglishUs" TextMode="MultiLine" Rows="7" Width="672px"
                            runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlStatus" CssClass="width_75" DataTextField="s_status_name"
                            DataValueField="s_status_id_pk" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_english_uk_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_EnglishUk" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_EnglishUk" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>                       
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_document_type_info_french_ca_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_FrenchCa" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_FrenchCa" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_french_fr_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_FrenchFr" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_FrenchFr" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_spanish_mx_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_SpanishMx" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_SpanishMx" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_spanish_sp_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_SpanishSp" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_SpanishSp" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_portuguese_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Portuguese" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Portuguese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_chinese_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Chinese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Chinese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_german_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_German" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_German" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_japanese_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Japanese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Japanese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_russian_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Russian" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Russian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_danish_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Danish" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Danish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_polish_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Polish" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Polish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_swedish_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Swedish" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Swedish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_finnish_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Finnish" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Finnish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_korean_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Korean" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Korean" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_italian_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Italian" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Italian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_dutch_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Dutch" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Dutch" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_indonesian_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Indonesian" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Indonesian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_greek_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Greek" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Greek" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_hunagarian_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDcoumentTypeName_Hungarian" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Hungarian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_norwegian_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Norwegian" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Norwegian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_turkish_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Turkish" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Turkish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_arabic_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Arabic" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Arabic" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_01_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom01" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom01" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_02_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom02" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom02" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_03_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom03" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom03" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_04_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom04" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom04" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_05_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom05" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom05" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_06_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom06" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom06" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_07_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom07" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom07" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_08_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom08" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom08" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_09_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom09" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom09" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_10_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom10" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom10" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_11_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom11" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom11" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_12_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom12" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom12" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_document_type_info_custom_13_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_document_type_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName_Custom13" CssClass=" textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" >
                    </td>
                    <td>
                    </td>
                    <td style=" width:180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom13" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnFooterSave" CssClass="cursor_hand" runat="server" ValidationGroup="saandoctn"
                            Text="<%$ LabelResourceExpression: app_save_new_document_type_button_text %>" OnClick="btnHeaderSave_Click" />
                    </td>
                    <td colspan="2" class="btnsave_new_user_td">
                        &nbsp;</td>
                    <td>
                    </td>
                    <td class="btnreset_td align_right">
                        <asp:Button ID="btnFooterReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" runat="server"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        &nbsp;</td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnFooterCancel" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" runat="server"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
