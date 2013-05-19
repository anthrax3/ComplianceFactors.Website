<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="p-sacp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.CurriculumPath.p_sacp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 885px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".newcourse").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 725,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../CourseSearch/p-spcs-01.aspx?course=true&mode=add&page=p-sacp-01&sec=' + record_id,
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

            $(".couserequired").change(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
                var tr_id = $(this).parents("#.record");
                if ($(".couserequired").is(":checked")) {

                    // checkbox is checked -> do something
                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "p-sacp-01.aspx/CourseRequired",

                        //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "','args2': '" + "true" + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            $('#' + record_id).prop("checked", true);
                        }
                    });

                } else {
                    alert('false');
                    // checkbox is not checked -> do something different
                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "p-sacp-01.aspx/CourseRequired",

                        //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "','args2': '" + "false" + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {


                        }
                    });

                }

                return false;
            });

            $(".down_button").click(function () {
                var rowToMove = $(this).parents('tr.MoveableRow:first');
                var next = rowToMove.next('tr.MoveableRow')
                if (next.length == 1) { next.after(rowToMove); }
                return false;
            });
            $(".up_button").click(function () {
                var rowToMove = $(this).parents('tr.MoveableRow:first');
                var prev = rowToMove.prev('tr.MoveableRow')
                if (prev.length == 1) { prev.before(rowToMove); }
                return false;
            });

        });
        function Removeconfirmation() {
            if (confirm("Do you want to delete this record?")) {
                return true;
            }
            else {
                return false;
            }

        }
        function CountSection() {
            var totalRow = $("[id*=lblCourse]").html();
            if (totalRow == 0) {
                alert("Please add atleast one course in above section.");
                return false;
            }
            else {
                return true;
            }

        }
        function Check() {

            //Get the Id of the record to delete
            var record_id = $(this).attr("id");
            // Ask user's confirmation before delete records
            var element = $(this).attr("id").split(",");
            var tr_id = $(this).parents("#.record");
            if ($(".couserequired").is(":checked")) {

                // checkbox is checked -> do something
                $.ajax({
                    type: "POST",

                    //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                    url: "p-sacp-01.aspx/CourseRequired",

                    //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                    data: "{'args': '" + element[0] + "','args1': '" + element[1] + "','args2': '" + "true" + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    state: { "checked": "checked" },
                    success: function () {

                    }
                });

            }




        }
    </script>
    <div class="div_header_1005">
       <%=LocalResources.GetLabel("app_curriculum_path_information_text")%>:
    </div>
    <div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_path_name_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtPathName" runat="server" CssClass="textarea_long_3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_description_text")%>: 
                    </td>
                    <td class="align_left">
                        <textarea id="txtDescription" runat="server" rows="7" cols="60"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_abstract_text")%>:
                    </td>
                    <td class="align_left">
                        <textarea id="txtAbstract" runat="server" rows="7" cols="60"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="width_200">
                        <%=LocalResources.GetLabel("app_enforce_sections_sequence_text")%>: 
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkHeaderEnforceSectionsSequence" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="width_230_bold">
                        <%=LocalResources.GetLabel("app_completed_text")%>&nbsp;<asp:TextBox ID="txtComplete" runat="server" CssClass="textbox_50" />
                    </td>
                    <td class="align_left">
                        <%=LocalResources.GetLabel("app_out_text")%>&nbsp;<%=LocalResources.GetLabel("app_of_text")%>
                        <asp:Label ID="lblSectionCount" runat="server"></asp:Label>
                        <%=LocalResources.GetLabel("app_sections_text")%>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:DataList ID="dlSection" runat="server" ShowFooter="true" CellPadding="0" CssClass="grid_870"
            CellSpacing="0" DataKeyField="c_curricula_path_section_id_pk" OnItemDataBound="dlSection_ItemDataBound">
            <ItemTemplate>
                <div class="div_header_870">
                    <asp:Label ID="lblSectionNumber" runat="server"></asp:Label>
                </div>
                <div>
                    <br />
                    <table cellpadding="0" cellspacing="0" class="grid_870">
                        <tr>
                            <td valign="top" class="width_280">
                                <%=LocalResources.GetLabel("app_enforce_courses_sequence_text")%>
                                <asp:CheckBox ID="chkEnforceSectionsSequence" runat="server" />
                            </td>
                            <td>
                               <%=LocalResources.GetLabel("app_completed_text")%>&nbsp;<asp:TextBox ID="txtCourseComplete" runat="server" CssClass="textbox_50" />
                               <%=LocalResources.GetLabel("app_out_text")%>&nbsp;<%=LocalResources.GetLabel("app_of_text")%>
                                <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                <asp:TextBox ID="txtCourse" Style="display: none;" runat="server"></asp:TextBox>
                                <%=LocalResources.GetLabel("app_courses_text")%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="gvCourse" CellPadding="0" CellSpacing="0" RowStyle-CssClass="record MoveableRow"
                    GridLines="None" CssClass="grid_870" ShowHeader="false" runat="server" ShowFooter="true"
                    OnRowDataBound="gvCourse_RowDataBound" OnRowCommand="gvCourse_RowCommand" AutoGenerateColumns="False"
                    DataKeyNames="c_curricula_path_course_id_fk,c_curricula_path_course_seq_number">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" class="record" cellspacing="0">
                                    <tr>
                                        <td class="width_280">
                                            <%#Eval("c_course_name") %>
                                        </td>
                                        <td class="width_75">
                                            <%=LocalResources.GetLabel("app_required_text")%>:
                                        </td>
                                        <td class="width_30">
                                            <asp:Literal ID="ltlcheck" runat="server"></asp:Literal>
                                        <%--    <input type="checkbox" id='<%# Eval("c_curricula_path_course_id_fk").ToString() + "," +  Eval("c_curricula_path_section_id_fk").ToString()%>'
                                                class="couserequired" checked='<%# Eval("c_curricula_path_required").ToString() == "1" ? "checked" : "false" %>' />--%>
                                            <%-- <asp:CheckBox ID="chkRequired" AutoPostBack="true" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                CommandName="chkbocCheck" Checked='<%# Eval("c_curricula_path_required").ToString() == "1" ? true : false %>'
                                                runat="server" />--%>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnUp" runat="server" Text="<%$ LabelResourceExpression: app_up_button_text%>" CommandName="Up" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDown" runat="server" Text="<%$ LabelResourceExpression: app_down_button_text%>" CommandName="Down" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnRemove" OnClientClick="return Removeconfirmation();" runat="server"
                                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="width_280">
                                            <%--<input type="button" id='btnAddNewPage1' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_add_ui_page_button_text %>" />'
                                                    class="newpage cursor_hand" />--%>
                                            <%--<asp:Button ID="btnAddNewPage" runat="server" Text="<%$ LabelResourceExpression: app_add_ui_page_button_text %>" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <div class="div_header_1005">
            <br />
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnAddSection" OnClientClick="return CountSection();" runat="server"
                            Text="<%$ LabelResourceExpression: app_add_section_button_text%>" OnClick="btnAddSection_Click" />
                    </td>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnSavePath" runat="server" Text="<%$ LabelResourceExpression: app_save_path_button_text%>" OnClick="btnSavePath_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close()"
                            Text="<%$ LabelResourceExpression: app_save_path_button_text%>" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
