<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saangsn-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.GradingSchemes.saangsn_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
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


        //Get poup for grading value
        $(document).ready(function () {
            $(".createSchemeValue").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 300,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': '/SystemHome/Configuration/GradingSchemes/p-sgscv-01.aspx',
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
    <%--<script type="text/javascript">

        $(document).ready(function () {

            $(".deleteGradingSchemes").click(function () {

                document.getElementById('<%=hdUpdateValue.ClientID %>').value = '0';
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saangsn-01.aspx/DeleteGradingSchemes",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".editGradingSchemes").click(function () {

                document.getElementById('<%=hdUpdateValue.ClientID %>').value = '0';
                //Get the Id of the record to delete
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
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Configuration/GradingSchemes/p-sgsev-01.aspx?mode=edit&page=saangsn' + "&id=" + record_id,
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


            $(".copyGradingSchemes").click(function () {

                document.getElementById('<%=hdUpdateValue.ClientID %>').value = '0';
                //Get the Id of the record to delete
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
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Configuration/GradingSchemes/p-sgscv-01.aspx?mode=copy&page=saangsn' + "&id=" + record_id,
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
        function check_hdUpdateValue(id) {
            if (id == "btnAddNew") {
                document.getElementById('<%=hdUpdateValue.ClientID %>').value = "0";
            }
            else {
                document.getElementById('<%=hdUpdateValue.ClientID %>').value = "1";
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function ValidateText(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
        }
    </script>
            <script type="text/javascript">
                function ConfirmRemove() {
                    if (confirm("Do you want to delete this record?") == true) {
                        document.getElementById('<%=hdUpdateValue.ClientID %>').value = "1";
                        return true;
                    }
                    else {
                        return false;
                    }
                }
    </script>
        <script type="text/javascript" language="javascript">
            function validateMinvalue(sender, args) {
                var gridView = document.getElementById('<%= gvGradingSchemeValues.ClientID %>');
                for (var i = 0; i < gridView.rows.length-1; i++) {
                        var inputs = gridView.rows[i].getElementsByTagName('input');
                        if (inputs != null) {
                            if (inputs[0].type == "text") {
                                    if (inputs[0].value != "") {
                                        if (inputs[0].value < 100) {
                                            args.IsValid = true;
                                        }
                                        else {
                                            args.IsValid = false;
                                            break;
                                        }
                                    }
                                    else {
                                        args.IsValid = false;
                                        break;
                                    }
                            }
                        }
                    }
                }
                function validateMaxvalue(sender, args) {
                    var gridView = document.getElementById('<%= gvGradingSchemeValues.ClientID %>');
                    for (var i = 0; i < gridView.rows.length - 1; i++) {
                        var inputs = gridView.rows[i].getElementsByTagName('input');
                        if (inputs != null) {
                            if (inputs[1].type == "text") {
                                if (inputs[1].value != "") {
                                    if (inputs[1].value <= 100) {
                                        args.IsValid = true;
                                    }
                                    else {
                                        args.IsValid = false;
                                        break;
                                    }
                                }
                                else {
                                    args.IsValid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                function validateMinMaxvalue(sender, args) {
                    var gridView = document.getElementById('<%= gvGradingSchemeValues.ClientID %>');
                    for (var i = 0; i < gridView.rows.length - 1; i++) {
                        var inputs = gridView.rows[i].getElementsByTagName('input');
                        var dropdowns = gridView.getElementsByTagName('select');
                        if (inputs != null) {
                            if (inputs[0].value < inputs[1].value) {
                                args.IsValid = true;
                            }
                            else {
                                args.IsValid = false;
                                break;
                            }
                        }
                    }
                }       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdUpdateValue" runat="server" />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saangsn" runat="server"
        ValidationGroup="saangsn"></asp:ValidationSummary>
    <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
        ValidationGroup="saangsn_values"></asp:ValidationSummary>

     <asp:CustomValidator ID="cvValidateMinvalue" EnableClientScript="true" ClientValidationFunction="validateMinvalue"
            ValidateEmptyText="true" ValidationGroup="saangsn_values" runat="server" ErrorMessage="Please check min score value.">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvValidateMaxvalue" EnableClientScript="true" ClientValidationFunction="validateMaxvalue"
            ValidateEmptyText="true" ValidationGroup="saangsn_values" runat="server" ErrorMessage="Please check max score value.">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvValidateMinMax" EnableClientScript="true" ClientValidationFunction="validateMinMaxvalue"
            ValidateEmptyText="true" ValidationGroup="saangsn_values" runat="server" ErrorMessage="Min value should not exceed from max score.">&nbsp;</asp:CustomValidator>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">

    </div>
    <div class="content_area_long">
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnHeaderSave" ValidationGroup="saangsn" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_new_grading_scheme_button_text %>"
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
            <%=LocalResources.GetLabel("app_grading_scheme_information_english_us_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        *<%=LocalResources.GetLabel("app_grading_scheme_id_text")%>:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGradingSchemeId" runat="server" ValidationGroup="saangsn"
                            ControlToValidate="txtGradingSchemeId_EnglishUs" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtGradingSchemeId_EnglishUs" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator ID="rfvGradingSchemeName" runat="server" ValidationGroup="saangsn"
                            ControlToValidate="txtGradingSchmeName_EnglishUs" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchmeName_EnglishUs" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGradingSchemeDescription" runat="server" ValidationGroup="saangsn"
                            ControlToValidate="txtGradingDescription_EnglishUs" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *<%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td colspan="6" class="align_left">
                        <asp:TextBox ID="txtGradingDescription_EnglishUs" TextMode="MultiLine" Rows="7" Width="780px"
                            runat="server"></asp:TextBox>
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
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_type_text")%>:
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
            <%=LocalResources.GetLabel("app_grading_scheme_values_pass_fail_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvGradingSchemeValues" RowStyle-CssClass="record" GridLines="None"
                            CssClass="gridview_width_9" CellPadding="0" CellSpacing="0" ShowHeader="false"
                            ShowFooter="true" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvGradingSchemes_RowDataBound"
                            DataKeyNames="s_grading_scheme_system_value_id_pk" 
                            onrowcommand="gvGradingSchemeValues_RowCommand">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("s_grading_scheme_value_name")%>(<%#Eval("s_grading_scheme_value_id")%>)
                                                </td>
                                                <td>                                                        
                                                    <%=LocalResources.GetLabel("app_score_text")%>:<asp:TextBox ID="txtMinscore" runat="server"
                                                        onkeyup="ValidateText(this);" CssClass="textbox_50"/>&nbsp;<%=LocalResources.GetLabel("app_to_text")%>&nbsp;
                                                    <asp:TextBox ID="txtMaxscore" runat="server" onkeyup="ValidateText(this);" CssClass="textbox_50" /></td>                                                                                                   </td>
                                                <td>
                                                    <%-- <asp:RequiredFieldValidator ID="rfvGpa" runat="server" ValidationGroup="saangsn" Display="Dynamic"
                                                    ControlToValidate="txtGpa" ErrorMessage="<%$ TextResourceExpression: app_gpa_error_empty %>">&nbsp;
                                                    </asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="rfvGPA" runat="server" ErrorMessage="Plese enter only the numbers in GPA"
                                                        ControlToValidate="txtGpa" ValidationGroup="saangsn" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                                                    <asp:DropDownList ID="ddlPassingStatus" runat="server" DataTextField="s_grading_scheme_value_pass_status_name"
                                                        DataValueField="s_grading_scheme_value_pass_status_id_fk" />
                                                     &nbsp;GPA&nbsp;<asp:TextBox ID="txtGpa" runat="server" onkeyup="ValidateText(this);"
                                                        CssClass="textbox_50" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("s_grading_scheme_system_value_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                            class="editGradingSchemes cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("s_grading_scheme_system_value_id_pk") %>' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_copy_button_text %>" />'
                                            class="copyGradingSchemes cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<input type="button" id='<%# Eval("s_grading_scheme_system_value_id_pk") %>' value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                            class="deleteGradingSchemes cursor_hand" />--%>
                                        <asp:Button ID="btnRemove" runat="server" CommandArgument='<%# Eval("s_grading_scheme_system_value_id_pk") %>'
                                     CommandName="Remove" Text="<%$ LabelResourceExpression: app_remove_button_text %>" OnClientClick="return ConfirmRemove();" CssClass="cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td style="padding-left: 150px;">
                        <input type="button" id="btnAddNew" value='<asp:Literal runat="server" Text="<%$ LabelResourceExpression:app_add_new_value_button_text%>" />'
                            onclick="javascript:check_hdUpdateValue(this.id)" class="createSchemeValue cursor_hand" />
                    </td>
                    <td style="padding-left: 450px;">
                        <asp:Button ID="btnUpdateValue" OnClientClick="javascript:check_hdUpdateValue(this.id)"
                            Visible="false"  runat="server" Text="<%$ LabelResourceExpression:app_update_value_button_text %>"
                            OnClick="btnUpdateValue_Click" ValidationGroup="saangsn_values" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_english_uk_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_EnglishUk" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_EnglishUk" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_french_ca_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_FrenchCa" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_FrenchCa" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_french_fr_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_FrenchFr" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_FrenchFr" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_spanish_mx")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_SpanishMx" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_SpanishMx" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_spanish_sp")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_SpanishSp" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_SpanishSp" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_portuguese")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Portuguese" CssClass="textbox_manage_user"
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Portuguese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_chinese_simplified")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Chinese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Chinese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_german")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_German" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_German" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_japanese")%>
            :
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Japanese" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Japanese" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_russian")%>
            :
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Russian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Russian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_danish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Danish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Danish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_polish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Polish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Polish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_swedish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Swedish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Swedish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_finnish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Finnish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Finnish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_korean")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Korean" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Korean" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_italian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Italian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Italian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_dutch")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Dutch" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Dutch" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_indonesian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Indonesian" CssClass="textbox_manage_user"
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Indonesian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_greek")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Greek" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Greek" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_hungarian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Hungarian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Hungarian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_norwegian")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Norwegian" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Norwegian" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_turkish")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Turkish" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Turkish" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_arabic")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Arabic" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Arabic" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_01")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom01" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom01" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_02")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom02" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom02" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_03")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom03" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom03" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_04")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom04" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom04" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_05")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom05" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom05" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_06")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom06" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom06" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_07")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom07" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom07" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_08")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom08" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom08" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_09")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom09" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom09" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_10")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom10" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom10" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_11")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom11" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom11" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_12")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom12" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                    <td colspan="5">
                        <asp:TextBox ID="txtDescription_Custom12" TextMode="MultiLine" Rows="7" Width="670px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_grading_scheme_information_custom_13")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="5" cellspacing="10">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_grading_scheme_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradingSchemeName_Custom13" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
                        <asp:Button ID="btnFooterSave" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_save_new_grading_scheme_button_text %>"
                            OnClick="btnFooterSave_Click" ValidationGroup="saangsn" />
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
