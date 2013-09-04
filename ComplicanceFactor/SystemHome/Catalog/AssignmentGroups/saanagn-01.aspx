<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saanagn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.saanagn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <script type="text/javascript">
        function lastEquivalenciesrow() {
            $('#<%=gvAssignmentGroupParameters.ClientID %> tr:last').eq(-1).css("display", "none");
        }
    </script>
    <script type="text/javascript">
        function ConfirmRemove() {
            if (confirm("Do you want to delete this record?") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
     <script type="text/javascript">
         $(document).ready(function () {

             $(".previewAssignment").click(function () {
                 $.fancybox({
                     'type': 'iframe',
                     'titlePosition': 'over',
                     'titleShow': true,
                     'showCloseButton': true,
                     'scrolling': 'yes',
                     'autoScale': false,
                     'autoDimensions': false,
                     'helpers': { overlay: { closeClick: false} },
                     'width': 1050,
                     'height': 200,
                     'margin': 0,
                     'padding': 0,
                     'overlayColor': '#000',
                     'overlayOpacity': 0.7,
                     'hideOnOverlayClick': false,
                     'href': 'Popup/p-sapag-01.aspx',  //?id=' + record_id,
                     'onComplete': function () {
                         $('#fancybox-frame').load(function () {
                             $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                             var heightPane = $(this).contents().find('#content').height();
                             $(this).contents().find('#fancybox-frame').css({
                                 'height': heightPane + 'px'

                             })
                         });

                     }

                 });
             });

         });
     </script>
    <script type="text/javascript">
        $(function () {
            var gridView = document.getElementById('<%= gvAssignmentGroupParameters.ClientID %>');
            for (var i = 0; i < gridView.rows.length; i++) {
                var element = gridView.rows[i].cells[0].getElementsByTagName("span");
                var dropdowns = gridView.getElementsByTagName('select');
                if (element[0].innerHTML == 'u_hris_hire_date' || element[0].innerHTML == 'u_hris_last_rehire_date') {
                    $(dropdowns.item(i) + "option[value='Between']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Between']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Starts with']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Starts with']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Contains']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Contains']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Less than']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Greater than ']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Before']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='After']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Null']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Null']").removeAttr("disabled", "disabled");

                }
                else if (element[0].innerHTML == 'u_country_id_fk' || element[0].innerHTML == 'u_locale_id_fk' || element[0].innerHTML == 'u_timezone_fk') {
                    $(dropdowns.item(i) + "option[value='Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Starts with']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Starts with']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Contains']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Contains']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Less than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Greater than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Before']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='After']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Null']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Null']").attr("disabled", "disabled");
                }
                else if (element[0].innerHTML == 'u_sr_is_manager' || element[0].innerHTML == 'u_sr_is_instructor' || element[0].innerHTML == 'u_sr_is_compliance' || element[0].innerHTML == 'u_sr_is_training' ||  element[0].innerHTML == 'u_sr_is_administrator') {
                    $(dropdowns.item(i) + "option[value='Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Starts with']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Starts with']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Contains']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Contains']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Less than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Greater than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Before']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='After']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Null']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Null']").attr("disabled", "disabled");
                }                
                else {
                    $(dropdowns.item(i) + "option[value='Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Between']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Starts with']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Starts with']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Contains']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Contains']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Less than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Greater than']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Before']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='After']").attr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Null']").removeAttr("disabled", "disabled");
                    $(dropdowns.item(i) + "option[value='Not Null']").removeAttr("disabled", "disabled");
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saanagn" runat="server"
        ValidationGroup="saanagn"></asp:ValidationSummary>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdStopRebind" runat="server" />
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saanagn" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_new_assignment_group_button_text %>"
                            OnClick="btnHeaderSave_Click" />
                    </td>
                    <td class="btnsave_new_user_td">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            runat="server" OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="center" class="btnreset_td">
                        &nbsp;
                    </td>
                    <td class="btncancel_td">
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHeaderCancel" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            runat="server" OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_english_us_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_assignment_group_id_text")%>:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAssignmentGroupId" runat="server" ValidationGroup="saanagn"
                            ControlToValidate="txtAssignmentGroupId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAssignmentGroupId" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator ID="rfvAssignmentGroupIdName" runat="server" ValidationGroup="saanagn"
                            ControlToValidate="txtAssignmentGroupName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAssignmentGroupDescription" runat="server" ValidationGroup="saanagn"
                            ControlToValidate="txtAssignmentGroupDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtAssignmentGroupDescription" runat="server" class="txtInput_long"
                            rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_Parameters_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <asp:UpdatePanel ID="upnlAssignmentGroup" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvAssignmentGroupParameters" RowStyle-CssClass="record" GridLines="None"
                        CssClass="gridview_width_9" CellPadding="0" CellSpacing="0" ShowHeader="false"
                        runat="server" DataKeyNames="u_assignment_group_param_system_id_pk,u_assignment_group_param_operator_id_fk,u_assignment_group_param_values"
                        AutoGenerateColumns="false" OnRowDataBound="gvAssignmentGroupParameters_RowDataBound"
                        OnRowCommand="gvAssignmentGroupParameters_RowCommand">
                        <RowStyle CssClass="record"></RowStyle>
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td class="gridview_row_width_7">
                                               <span><%# Eval("u_assignment_group_param_element_id_fk")%></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="ddl_user_advanced_search"
                                                    DataTextField="e_assignment_operator_name" DataValueField="e_assignment_operator_id">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;" class="gridview_row_width_1">
                                                <%=LocalResources.GetLabel("app_values_text")%>:
                                            </td>
                                            <td class="gridview_row_width_1">
                                                <asp:TextBox ID="txtValues" CssClass="textbox_long" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="gridview_row_width_1">
                                                <%-- <input type="button" id='<%# Eval("u_assignment_group_param_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                                                    class="deleteParam cursor_hand" />--%>
                                                <asp:Button ID="btnRemove" runat="server" CommandArgument='<%# Eval("u_assignment_group_param_system_id_pk") %>'
                                                    CommandName="Remove" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                                    OnClientClick="return ConfirmRemove();" CssClass="cursor_hand" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                --<%=LocalResources.GetLabel("app_and_text")%>--
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <table>
                <tr>
                    <td style="padding-left: 80px;">
                        <asp:Button ID="btnAddNewParameters" ValidationGroup="saanagn" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_add_new_parameter_button_text %>" OnClick="btnAddNewParameters_Click" />
                    </td>
                    <td style="padding-left: 450px;">
                        <input type="button" id="btnpReviewAssignmentGroup" value='<asp:Literal runat="server" Text="<%$ LabelResourceExpression: app_preview_assignment_group_button_text %>" />'
                            class="previewAssignment cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_english_uk_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_EnglishUk" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_EnglishUk" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_french_ca_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_FrenchCa" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_FrenchCa" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_french_fr_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_FrenchFr" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_FrenchFr" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_spanish_mx")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_SpanishMx" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_SpanishMx" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_spanish_sp")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_SpanishSp" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_SpanishSp" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_portuguese")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Portuguese" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Portuguese" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_chinese_simplified")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Chinese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Chinese" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_german")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_German" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_German" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_japanese")%>
            :
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Japanese" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Japanese" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_russian")%>
            :
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Russian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Russian" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_danish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Danish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Danish" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_polish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Polish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Polish" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_swedish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Swedish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Swedish" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_finnish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Finnish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Finnish" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_korean")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Korean" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Korean" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_italian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Italian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Italian" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_dutch")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Dutch" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Dutch" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_indonesian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Indonesian" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Indonesian" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_greek")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Greek" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Greek" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_hungarian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Hungarian" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Hungarian" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_norwegian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Norwegian" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Norwegian" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_turkish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Turkish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Turkish" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_arabic")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Arabic" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Arabic" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_01_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom01" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom01" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_02_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom02" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom02" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_03_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom03" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom03" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_04_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom04" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom04" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_05_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom05" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom05" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_06_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom06" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom06" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_07_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom07" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom07" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_08_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom08" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom08" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_09_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom09" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom09" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_10_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom10" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom10" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_11_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom11" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom11" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_12_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom12" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom12" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_assignment_group_information_custom_13_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_assignment_group_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignmentGroupName_Custom13" CssClass="textbox_manage_user"
                            runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                    <td>
                    </td>
                    <td style="width: 180px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription_Custom13" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
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
                        <asp:Button ID="btnFooterSave" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_save_new_assignment_group_button_text %>"
                            OnClick="btnFooterSave_Click" ValidationGroup="saanagn" />
                    </td>
                    <td colspan="2" class="btnsave_new_user_td">
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td align="center" class="btnreset_td">
                        <asp:Button ID="btnFooterReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            runat="server" OnClick="btnFooterReset_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btncancel_td">
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnFooterCancel" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            runat="server" OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
