<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saear-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.AssignmentRules.saear_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

            $(navigationSelectedValue).addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $(navigationSelectedValue).addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addCatalog").click(function () {
                var hdnValue = document.getElementById('<%= hdnEditAssignmentRule.ClientID %>');
                $(".addCatalog").fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 733,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-saarcs-01.aspx?ruleId=' + hdnValue.value,
                    'onComplete': function () {
                        $.fancybox.showActivity();
                        $('#fancybox-frame').load(function () {
                            $.fancybox.hideActivity();
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
        $(document).ready(function () {
            $(".addGroup").click(function () {
                var hdnValue = document.getElementById('<%= hdnEditAssignmentRule.ClientID %>');
                $(".addGroup").fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 733,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/p-saargs-01.aspx?ruleId=' + hdnValue.value,
                    'onComplete': function () {
                        $.fancybox.showActivity();
                        $('#fancybox-frame').load(function () {
                            $.fancybox.hideActivity();
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
        $(document).ready(function () {
            $(".deleteCatalog").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saear-01.aspx/DeleteCatalog",
                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            // Do some animation effect
                            tr_id.fadeOut(500, function () {
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".deleteGroup").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saear-01.aspx/DeleteGroup",
                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            // Do some animation effect
                            tr_id.fadeOut(500, function () {
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        function lastCatalogItemsrow() {
            $('#<%=gvCatalogItems.ClientID %> tr:last').eq(-1).css("display", "none");
        }
    </script>
    <script type="text/javascript">
        function lastGroupItemsrow() {
            $('#<%=gvAssignmentGroups.ClientID %> tr:last').eq(-1).css("display", "none");
        }
    </script>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdnEditAssignmentRule" runat="server" />
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2" class="btnsave_new_user_td" align="left">
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saear" CssClass="cursor_hand" runat="server"
                            Text="Save Assignment Rule" OnClick="btnHeaderSave_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center" class="btnreset_td">
                        <asp:Button ID="btnHeaderReset" CssClass="cursor_hand" Text="Reset" runat="server"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btncancel_td">
                        <asp:Button ID="btnHeaderCancel" CssClass="cursor_hand" Text="Cancel" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <br />
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div class="div_header_long">
            Assignment Rule Information (English US):
        </div>
        <br />
        <div>
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="align_right">
                            *Assignment Rule Id:
                        </td>
                        <td class="align_left">
                            <asp:RequiredFieldValidator ID="rfvAssignmentRuleId" runat="server" ValidationGroup="saear"
                                ControlToValidate="txtAssignmentRuleId_EnglishUs" ErrorMessage="Please enter Assignment Rule Id">&nbsp;
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAssignmentRuleId_EnglishUs" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="align_right">
                            *Assignment Rule Name:
                        </td>
                        <td class="align_left">
                            <asp:RequiredFieldValidator ID="rfvAssignmentRuleName" runat="server" ValidationGroup="saear"
                                ControlToValidate="txtAssignmentRuleName_EnglishUs" ErrorMessage="Please enter Assignment Rule Name">&nbsp;
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAssignmentRuleName_EnglishUs" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvAssignmentDescriptionUS" runat="server" ValidationGroup="saear"
                                ControlToValidate="txtAssignmentDescriptionUS" ErrorMessage="Please enter the description">&nbsp;
                            </asp:RequiredFieldValidator>
                            *Description:
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtAssignmentDescriptionUS" TextMode="MultiLine" Rows="7" Width="850px"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td class="align_left">
                            <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="div_header_long">
                Assignment Rule Catalog Item(s):
            </div>
            <br />
            <div>
                <div>
                    <div>
                        <asp:GridView ID="gvCatalogItems" AutoGenerateColumns="false" RowStyle-CssClass="record"
                            CssClass=" grid_870" ShowHeader="false" ShowFooter="false" GridLines="None" DataKeyNames="u_assignment_rule_item_system_id_pk"
                            runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td class="width_450 align_left">
                                                    <asp:Label ID="lblCourseName" runat="server" Style="text-align: left;" Text='<%#Eval("title")  + "(" + Eval("Id") +")"%>'></asp:Label>
                                                </td>
                                                <td class="width_200 align_left">
                                                    <asp:Label ID="Label1" runat="server" Style="text-align: left;" Text='<%#Eval("type")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <input type="button" id='<%# Eval("u_assignment_rule_item_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                                                        class="deleteCatalog cursor_hand" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="align_center">
                                                    -- and --
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_4_1"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="record"></RowStyle>
                        </asp:GridView>
                        <br />
                    </div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnCatalogItems" runat="server" CssClass="addCatalog cursor_hand"
                                    Text="Add New Item(s)" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    Assignment Rule Group(s):
                </div>
                <br />
                <div>
                    <asp:GridView ID="gvAssignmentGroups" AutoGenerateColumns="false" RowStyle-CssClass="record"
                        CssClass=" grid_870" ShowHeader="false" ShowFooter="false" GridLines="None" DataKeyNames="u_assignment_rule_group_system_id_pk"
                        runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td class="width_450 align_left">
                                                <asp:Label ID="lblGroupName" runat="server" Style="text-align: left;" Text='<%#Eval("u_assignment_group_name")  + "(" + Eval("u_assignment_group_id_pk") +")"%>'></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="button" id='<%# Eval("u_assignment_rule_group_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                                                    class="deleteGroup cursor_hand" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="align_center">
                                                -- and --
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_4_1"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="record"></RowStyle>
                    </asp:GridView>
                    <br />
                </div>
                <br />
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnNewGroups" runat="server" CssClass="addGroup cursor_hand" Text="Add New Group(s)" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    Assignment Rule Parameter(s):
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Required:&nbsp;&nbsp;
                                <asp:CheckBox ID="chkRequired" runat="server" />
                            </td>
                            <td style="width: 100px;">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td class="align_left width_180">
                                            <input id="rbtTagetduedate" type="radio" name="group1" runat="server" />
                                            <%--<asp:RadioButton ID="rbtTagetduedate" runat="server" />--%>
                                            &nbsp;Target Due Date:
                                        </td>
                                        <td>
                                            <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetduedate">
                                            </asp:CalendarExtender>
                                            <asp:TextBox ID="txtTargetduedate" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="align_left">
                                ---or---
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <%--<asp:RadioButton ID="rbtDue" runat="server" />--%>
                                            <input id="rbtDue" type="radio" name="group1" runat="server" />
                                        </td>
                                        <td>
                                            Due:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDue" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            Days From:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDuedaysfrom" CssClass="ddl_user_advanced_search" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    Assignment Rule Information (English UK):
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleUk" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescriptionUk" TextMode="MultiLine" Rows="7" Width="850px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_french_ca_text")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_FrenchCa" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_FrenchCa" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_french_fr_text")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_FrenchFr" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_FrenchFr" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_spanish_mx")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_SpanishMx" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_SpanishMx" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_spanish_sp")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_SpanishSp" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_SpanishSp" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_portuguese")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Portuguese" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Portuguese" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_chinese_simplified")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Chinese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Chinese" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_german")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_German" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_German" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_japanese")%>
                    :
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Japanese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Japanese" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_russian")%>
                    :
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Russian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Russian" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_danish")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Danish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Danish" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_polish")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Polish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Polish" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_swedish")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Swedish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Swedish" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_finnish")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Finnish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Finnish" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_korean")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Korean" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Korean" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_italian")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Italian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Italian" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_dutch")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Dutch" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Dutch" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_indonesian")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Indonesian" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <td colspan="2">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Indonesian" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_greek")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Greek" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Greek" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_hungarian")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Hungarian" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Hungarian" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_norwegian")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Norwegian" CssClass="textbox_manage_user"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Norwegian" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_turkish")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Turkish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Turkish" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    <%=LocalResources.GetLabel("app_assignment_rule_information_arabic")%>:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_assignment_rule_name_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Arabic" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_description_text")%>:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Arabic" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_header_long">
                    Custom 01:
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 01):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom01" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom01" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 02):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom02" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom02" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 03):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom03" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom03" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 04):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom04" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom04" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 05):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom05" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom05" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 06):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom06" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom06" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 07):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom07" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom07" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 08):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom08" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom08" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 09):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom09" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom09" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 10):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom10" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom10" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 11):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom11" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom11" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 12):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom12" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom12" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="div_controls font_1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Assignment Rule Name (Custom 13):
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssignmentRuleName_Custom13" CssClass="textbox_long" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description:
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescription_Custom13" TextMode="MultiLine" Rows="7" Width="850px"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td" align="left">
                            <asp:Button ID="btnFooterSaveAssignmentRule" ValidationGroup="saear" CssClass="cursor_hand"
                                runat="server" Text="Save Assignment Rule" OnClick="btnFooterSaveAssignmentRule_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" class="btnreset_td">
                            <asp:Button ID="btnFooterReset" CssClass="cursor_hand" Text="Reset" runat="server"
                                OnClick="btnFooterReset_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btncancel_td">
                            <asp:Button ID="btnFooterCancel" CssClass="cursor_hand" Text="Cancel" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
</asp:Content>
