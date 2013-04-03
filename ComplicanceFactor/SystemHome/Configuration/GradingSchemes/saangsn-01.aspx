<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saangsn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.GradingSchemes.saangsn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 110px;
        }
    </style>
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnHeaderSave" CssClass="cursor_hand" runat="server" Text="Save New Grading Scheme" />
                    </td>
                    <td>
                    </td>
                    <td align="center" class="btnreset_td">
                        <asp:Button ID="btnHeaderReset" CssClass="cursor_hand" Text="Reset" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnHeaderCancel" CssClass="cursor_hand" Text="Cancel" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="div_header_long">
            Grading Scheme Information (English US):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Id:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeId_EnglishUs" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchmeName_EnglishUs" CssClass="textbox_manage_user" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtGradingDescription_EnglishUs" TextMode="MultiLine" Rows="7" Width="672px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                        CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>

                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                        Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlType" DataTextField="s_grading_scheme_type_name" DataValueField="s_grading_scheme_type_id"
                         CssClass="ddl_user_advanced_search" runat="server">         
                        </asp:DropDownList>

                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Grading Scheme Values (Minimum of 2 Values for Pass / Fail):
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Button ID="btnAddNew" runat="server" Text="Add New Value" />
        </div>
        <br />
        <div class="div_header_long">
            Grading Scheme Information (English UK):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_EnglishUk" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (French CA):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_FrenchCa" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (French FR):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_FrenchFr" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Spanish MX):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_SpanishMx" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Spanish SP):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_SpanishSp" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Portuguese):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Portuguese" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Chinese Simplified):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Chinese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (German):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_German" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Japanese):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Japanese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Russian):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Russian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Danish):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Danish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Polish):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Polish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Swedish):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Swedish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Finnish):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Finnish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Korean):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Korean" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Italian):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Italian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Dutch):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Dutch" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Indonesian):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Indonesian" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Greek):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Greek" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Hungarian):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Hungarian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Norwegian):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Norwegian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Turkish):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Turkish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Arabic - Right-to-Left):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Arabic" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 01):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom01" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 02):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom02" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 03):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom03" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 04):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom04" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 05):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom05" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 06):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom06" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 07):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom07" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 08):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom08" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 09):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom09" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 10):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom10" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 11):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom11" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 12):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom12" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
            Grading Scheme Information (Custom 13):
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        Grading Scheme Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom13" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
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
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnFooterSave" CssClass="cursor_hand" runat="server" Text="Save New Grading Scheme" />
                    </td>
                    <td>
                    </td>
                    <td align="center" class="btnreset_td">
                        <asp:Button ID="btnFooterReset" CssClass="cursor_hand" Text="Reset" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnFooterCancel" CssClass="cursor_hand" Text="Cancel" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
