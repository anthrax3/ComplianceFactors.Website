<%@ Page Language="C#"  MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="saerp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Reports.saerp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var message = $.QueryString("mode");

            message = (!message) ? "null" : message; // Passing the value null to string
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
            $("#<%=btnAddParameter.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false } },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'sarpp-01.aspx?id=<%= webReportId%>&mode='+message,
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                        var heightPane = $(this).contents().find('#content').height()+100;
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            $(".deleteparam").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saerp-01.aspx/DeleteParam",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "','reportId':'<%= ReportId%>'}",
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

            $("#<%=btnAddColumn.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false } },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': 'sarpc-01.aspx?id=<%= webReportId%>&mode=' + message,
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                        var heightPane = $(this).contents().find('#content').height() + 100;
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });
            $(".deletecolumn").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saerp-01.aspx/DeleteColumn",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "','reportId':'<%= ReportId%>'}",
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
            $("#btnCreateNewLocale").click(function (e) {

              

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false } },
                    'width': 820,
                    'height': 750,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    //'href': 'webform1.aspx',
                    'href': 'sarpl-01.aspx?mode=' + message + "&Id=<%= webReportId%>&editLocaleId=" + localeid + "&editLocaleText=" + localeText+"&localeMode=create",
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
            $(".editlocale").click(function (e) {

                
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

                 var record_id = $(this).attr("id");

                 $.fancybox({
                     'type': 'iframe',
                     'titlePosition': 'over',
                     'titleShow': true,
                     'showCloseButton': true,
                     'scrolling': 'yes',
                     'autoScale': false,
                     'autoDimensions': false,
                     'helpers': { overlay: { closeClick: false } },
                     'width': 820,
                     'height': 550,
                     'margin': 0,
                     'padding': 0,
                     'overlayColor': '#000',
                     'overlayOpacity': 0.7,
                     'hideOnOverlayClick': false,
                     'href': 'sarpl-01.aspx?mode=' + message + "&Id=<%= webReportId%>&editLocaleId=" + record_id + "&editLocaleText=" + localeText + "&localeMode=edit",
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
           
            var localeHref = "";
            if (message == "create") {
                localeHref = 'Locale/savloc-01.aspx?mode=create';
            } else if (message == "edit") {
                localeHref = 'Locale/savloc-01.aspx?mode=edit&id=<%= ReportId%>';
            }
           
            $("#btnManageLocale").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'no',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false } },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': localeHref,
                'onComplete': function () {
                    $.fancybox.showActivity();
                    $('#fancybox-frame').load(function () {
                        $.fancybox.hideActivity();
                        $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                        var heightPane = $(this).contents().find('#content').height() + 100;
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });

                }

            });

            $(".deletelocale").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saerp-01.aspx/DeleteLocale",

                        //Pass the selected record id
                        data: "{'reportId':'<%= ReportId%>', 'args': '" + record_id + "'}",
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
    <script type="text/javascript" language="javascript">
        function confirmremove() {
            if (confirm('Are you sure you want to remove this file.?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">
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
        function HideFileValidationSummary() {
            $("#<%=vsFileUpload.ClientID%>").hide();
        }

        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {

            var oFileUpload = document.getElementsByName('<%=fupFiles.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);
            HideFileValidationSummary();

        }

    </script>
      <script type="text/javascript">
          function RemoveLocale(value) {

              var exists = false;
              $('#<%=ddlLocale.ClientID %>  option').each(function () {
                if (this.value == value) {
                    exists = true;
                    $('#<%=ddlLocale.ClientID %> option[value=' + value + ']').remove();
                }
            });



        }
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saent" runat="server"
        ValidationGroup="saent"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:HiddenField ID="hdNotificationId" runat="server" />
    <br />
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNotification" ValidationGroup="saent" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_report_button_text %>"  OnClick="btnSaveReport_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" CssClass="cursor_hand"
                            />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                          OnClick="btnCancel_Click"  />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_report_info_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                         <asp:RequiredFieldValidator ID="rfvReportnId" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtReportId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_report_id_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblReportId" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtReportId" CssClass="textarea_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator ID="rfvReportName" runat="server" ValidationGroup="saent"
                            ControlToValidate="txtReportName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_report_name_text")%>: 
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtReportName" CssClass="textarea_long_2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_type_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                         <%=LocalResources.GetLabel("app_description_text")%>: 
                      
                    </td>
                    <td class="align_left" colspan="7">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_manager_text")%>: 
                    </td>
                    <td class="align_left" colspan="7">
                        <table>
                            <tr>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkManager" runat="server" />
                                </td>
                                  <td class="width_180">
                                   <%=LocalResources.GetLabel("app_report_compliance_text")%>: 
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkCompliance" runat="server" />
                                </td>
                                <td class="width_180">
                                   <%=LocalResources.GetLabel("app_report_instructor_text")%>: 
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkInstructor" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_report_coordinator_text")%>: 
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkCoordinator" runat="server" />
                                </td>
                                <td class="width_180">
                                    <%=LocalResources.GetLabel("app_report_administrator_text")%>:
                                </td>
                                <td class="width_180 align_left">
                                    <asp:CheckBox ID="chkAdminstrator" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
                <tr>
                   
                    <td class="align_left" colspan="7">
                        <asp:Button ID="btnAttachment" runat="server" CssClass="cursor_hand" Text="Upload Report Source File" />
                        <asp:LinkButton ID="lnkFileName" runat="server" CssClass="cursor_hand" OnClick="lnkFileName_Click"></asp:LinkButton>
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="cursor_hand" OnClick="btnView_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="cursor_hand" />
                        <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" runat="server"
                            Text="Remove"  CssClass="cursor_hand" OnClick="btnRemove_Click" />
                    </td>
                    <td class="align_right" style="text-align:right;">
                        <input type="button" id="btnManageLocale" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />' />

                    </td>
                </tr>
               
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_report_parameter_title")%>: 
        </div>
        <br />
         <div class="div_controls_from_left">
            <asp:GridView ID="gvParameters" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("s_report_param_name")%>
                                    </td>
                                     <td>
                                        <%#Eval("s_report_param_label_name")%>
                                    </td>
                                    <td>
                                        <%#Eval("s_report_param_table_id_pk")%>
                                    </td>
                                     <td>
                                        <%#Eval("s_report_param_field_id_pk")%>
                                    </td>
                                    <td>
                                        Visible: <asp:CheckBox ID="chkVisible" runat="server"  Checked='<%# Eval("s_report_param_visible_flag")%>'/>
                                    </td>
                                </tr>
                               
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_report_param_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                                class="deleteparam cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls font_1">
            <asp:Button ID="btnAddParameter" runat="server" CssClass="cursor_hand" Text="Add New Parameter"  CausesValidation="false"/>
        </div>
        <br/>
         <div class="div_header_long">
           <%=LocalResources.GetLabel("app_report_column_title")%>: 
        </div>
        <br />
         <div class="div_controls_from_left">
            <asp:GridView ID="gvColumns" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("s_report_column_name")%>
                                    </td>
                                      <td>
                                        <%#Eval("s_report_column_label_name")%>
                                    </td>
                                    <td>
                                        Visible: <asp:CheckBox ID="chkVisible" runat="server"  Checked='<%#Eval("s_report_column_visible_flag")%>'/>
                                    </td>
                                </tr>
                               
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_report_column_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                                class="deletecolumn cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls font_1">
            <asp:Button ID="btnAddColumn" runat="server" CssClass="cursor_hand" Text="Add New Column" />
        </div>
       
        <br />
          <div class="div_header_long">
          <%=LocalResources.GetLabel("app_report_all_locales")%>: 
        </div>
        <br />
        <div class="div_padding_40 div_controls_from_left">
            <asp:Button ID="btnImportCsvFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_report_upload_labels %>"
                             />
            <asp:GridView ID="gvReportLocales" RowStyle-CssClass="record" CssClass="grid_700"
                runat="server" GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7">
                        <ItemTemplate>
                            <%#Eval("s_locale_description")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_locale_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="Edit" />'
                                class="editlocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("s_locale_id_pk")%>'
                                value='<asp:Literal ID="Literal6" runat="server" Text="Remove" />' class="deletelocale cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_controls font_1">
            <table class="grid_700" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="width_300 align_left">
                        <asp:DropDownList ID="ddlLocale" DataTextField="s_locale_description" DataValueField="s_locale_id_pk"
                            CssClass="dropdown_width_300" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right">
                        <input type="button" id="btnCreateNewLocale" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_create_new_locale_button_text %>" />' />
                    </td>
                </tr>
            </table>
        </div>
       <br/>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveNotification" ValidationGroup="saent" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_report_button_text %>"  OnClick="btnSaveReport_Click"/>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                             OnClick="btnCancel_Click"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

     <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnImportCsvFile"
        PopupControlID="pnlImportCsv" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
     <asp:Panel ID="pnlImportCsv" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlImportCsv2" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                         Upload Report Labels / Texts CSV File:
                    </div>
                    <div class="right">
                        <asp:ImageButton ID="ImageButton1" CssClass="cursor_hand" Style="top: -15px; right: -15px;
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
            <div class="uploadpanel font_normal">
                <asp:ValidationSummary class="validation_summary_error_popup" ID="ValidationSummary1" runat="server"
                    ValidationGroup="digitalmediaupload" />
                <asp:CustomValidator ValidationGroup="digitalmediaupload" ID="CustomValidator1" runat="server"
                    EnableClientScript="true" ErrorMessage="No file chosen" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                Select File:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="460" size="60" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <div class="multiple_button">
                    <asp:Button ID="btnUploadCsv"  runat="server"
                        Text="Upload" CssClass="cursor_hand"  OnClick="btnUploadCsv_Click"/>
                </div>
                <asp:Button ID="Button2" CssClass="cursor_hand" runat="server" Text="Cancel" />
            </div>
            <br />
        </div>
    </asp:Panel>



     <asp:ModalPopupExtender ID="mpeAddAttachment" runat="server" TargetControlID="btnAttachment"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeEditAttachment" runat="server" TargetControlID="btnEdit"
        PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
        OnCancelScript="cleartext();" CancelControlID="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
        padding-left: 0px;  padding-right: 0px;">
        <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
            <div>
                <div class="uploadpopup_header">
                    <div class="left">
                         Add Report Source File:
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
            <div class="uploadpanel font_normal">
                <asp:ValidationSummary class="validation_summary_error_popup" ID="vsFileUpload" runat="server"
                    ValidationGroup="digitalmediaupload" />
                <asp:CustomValidator ValidationGroup="digitalmediaupload" ID="cvFileUpload" runat="server"
                    EnableClientScript="true" ErrorMessage="No file chosen" ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                <div class="div_controls">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                Select File:
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
                    <asp:Button ID="btnUploadAttachment" ValidationGroup="digitalmediaupload" runat="server"
                        Text="Upload" CssClass="cursor_hand" OnClick="btnUploadAttachment_Click" />
                </div>
                <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="Cancel" />
            </div>
            <br />
        </div>
    </asp:Panel>
</asp:Content>