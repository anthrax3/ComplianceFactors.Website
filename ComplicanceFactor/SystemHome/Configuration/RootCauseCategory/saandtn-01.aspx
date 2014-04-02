<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saandtn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.RootCauseCategory.saandtn_01" %>

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

    </script>
    <br />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saandtn" runat="server"
        ValidationGroup="saandtn"></asp:ValidationSummary>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNewDeliveryType" ValidationGroup="saandtn" CssClass="cursor_hand"
                            runat="server" Text="Save New Category" OnClick="btnHeaderSaveNewDeliveryType_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
       
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        * Category Id:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDeliveryTypeId" runat="server" ValidationGroup="saandtn"
                            ControlToValidate="txtCategoryId" ErrorMessage="<%$ TextResourceExpression: app_delivery_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCategoryId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        * Category Name:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDeliveryTypeName" runat="server" ValidationGroup="saandtn"
                            ControlToValidate="txtCategoryName" ErrorMessage="<%$ TextResourceExpression: app_delivery_type_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCategoryName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                       * Description:
                    </td>
                    <td class="align_left" colspan="6">
                        <asp:RequiredFieldValidator ID="rfvDeliveryDescription" runat="server" ValidationGroup="saandtn"
                            ControlToValidate="txtDescriptionUS" ErrorMessage="<%$ TextResourceExpression: app_delivery_desc_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <textarea id="txtDescriptionUS" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="ddl_user_advanced_search" DataTextField="s_status_name"
                            DataValueField="s_status_id_pk" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Category Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoryType" CssClass="ddl_user_advanced_search"  runat="server"
                            >                          
                            <asp:ListItem Text= "People"></asp:ListItem>
                             <asp:ListItem Text= "Procedures"></asp:ListItem>
                              <asp:ListItem Text= "Hardware/Equipment"></asp:ListItem>
                               <asp:ListItem Text= "Environment"></asp:ListItem>
                                <asp:ListItem Text= "External"></asp:ListItem>
                            </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <br />
       
    
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveNewDeliveryType" CssClass="cursor_hand" ValidationGroup="saandtn"
                            runat="server" Text="Save New Category" OnClick="btnFooterSaveNewDeliveryType_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
