<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="csvein-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.csvein_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_compliance').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_compliance').addClass('selected');
                return false;
            });
        });
        $(document).ready(function () {

            var editQuestionId = $('input#<%=hdQuestionId.ClientID %>').val();

            $("#<%=btnAddQuestions.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 740,
                'height': 400,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'Popup/csvanq-01.aspx?mode=edit&page=csvein' + "&editQuestionId=" + editQuestionId,
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            var editQuestionId = $('input#<%=hdQuestionId.ClientID %>').val();
            //edit  Question
            $(".editQuestion").click(function () {

                //Get the Id of the record to edit
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 740,
                    'height': 400,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/csveq-01.aspx?mode=edit&page=csvein&editQuestionId=' + record_id + '&edituserId=' + editQuestionId,
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

        $(document).ready(function () {

            $(".deleteQuestion").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "csvein-01.aspx/DeleteQuestion",

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
    <div>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_csvein" runat="server"
            ValidationGroup="csvein"></asp:ValidationSummary>
        <asp:HiddenField ID="hdQuestionId" runat="server" />
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header_long">
            Inspection Details:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Inspection Id:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblInspectionId" runat="server" Text=""></asp:Label>
                        <%--<asp:TextBox ID="txtInspectionId" CssClass="textbox_long" runat="server"></asp:TextBox>--%>
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
                    <td class="width_180 align_right">
                        <asp:RequiredFieldValidator ID="rfvInspectionName" runat="server" ControlToValidate="txtInspectionName"
                            ValidationGroup="csvein" ErrorMessage="Please Enter Inspection Name">&nbsp;
                        </asp:RequiredFieldValidator>
                        * Inspection Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInspectionName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%-- <asp:RequiredFieldValidator ID="rfvInspectionDescription" runat="server"  
                            ControlToValidate="txtInspectionDescription" ErrorMessage="Please Enter Description">&nbsp;
                        </asp:RequiredFieldValidator>--%>
                        Inspection Description:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtInspectionDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        IsDefault:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsDefault" runat="server" />
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
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            Questions:
        </div>
        <br />
        <div align="center">
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
                                       <%-- <%#Eval("sv_mi_templete_question_type")%>--%>
                                    </td>
                                    <td class="gridview_row_width_1" align="center">
                                        <input type="button" id='<%# Eval("sv_mi_templete_question_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="Edit" />'
                                            class="editQuestion cursor_hand" />
                                    </td>
                                    <td class="gridview_row_width_1" align="center">
                                        <input type="button" id='<%# Eval("sv_mi_templete_question_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="Remove" />'
                                            class="deleteQuestion cursor_hand" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnAddQuestions" runat="server" CssClass="cursor_hand" Text="Add Questions" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td colspan="2" class="btnsave_new_user_td">
                        <asp:Button ID="btnFooterSaveInspection" ValidationGroup="csvein" CssClass="cursor_hand"
                            runat="server" Text="Save Inspection" OnClick="btnFooterSaveInspection_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="Reset"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2" class="btncancel_td">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="Cancel"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
