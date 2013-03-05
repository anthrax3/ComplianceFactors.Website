<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-seut-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.Edit_Ui_Text" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 750px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
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

        //reset scroll position popup
        function ResetScroll() {
            $('#divPreview').animate({ scrollTop: 0 });

        }
    </script>
    <script type="text/javascript">

        // Add locale
        $(document).ready(function () {

            var type = $.QueryString("type"),
            type = (!type) ? "null" : type; // Passing the value null to string

            var id = $.QueryString("id"),
            id = (!id) ? "" : id; // Passing the value null to string

            var appname = $.QueryString("appname"),
            appname = (!appname) ? "" : appname; // Passing the value null to string

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
                    'helpers': { overlay: { closeClick: false} },
                    'width': 683,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../UI Texts and Labels/p-satl-01.aspx?mode=add' + '&localeid=' + localeid + "&localeText=" + localeText + "&type=" + type + "&editTextId=" + id +"&appname=" + appname,
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


            $(".deletelocale").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "p-seut-01.aspx/DeleteLocale",

                        //Pass the selected record id
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "','args2': '" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                $("#<%= ddlLocale.ClientID %>").append("<option value=" + element[0] + ">" + element[1] + " </option>");
                                $("#<%= ddlLocale.ClientID %>").val(element[1]);
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });

            //edit locale
            $(".editlocale").click(function () {

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

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
                    'width': 683,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../UI Texts and Labels/p-satl-01.aspx?mode=edit' + "&localeid=" + record_id + "&editTextId=" + id + "&appname=" + appname,
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
            $("#<%=btnPreview.ClientID %>").click(function () {
                $('#divPreview').html($('#<%=txtUiText.ClientID %>').val());

            });
        });
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <div class="div_header_750">
            UI Text:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td class="align_left" colspan="8">
                        <textarea id="txtUiText" runat="server" rows="10" cols="88"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnSaveUiText" CssClass="cursor_hand" Text="Save UI Text" runat="server"
                    OnClick="btnSaveUiText_Click" />
            </div>
            <div class="right">
                <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    runat="server" Text="Cancel" />
            </div>
            <center>
                <asp:Button ID="btnPreview" CssClass="cursor_hand" OnClientClick="ResetScroll();"
                    Text="Preview" runat="server" />
            </center>
            <div class="clear">
            </div>
        </div>
        <br />
        <div class="div_header_750" id="divLocaleHeader" runat="server">
            All Locale(s):
        </div>
        <div>
            <br />
            <%-- locale list--%>
            <div class="div_padding_40">
                <asp:GridView ID="gvLocale" RowStyle-CssClass="record" CssClass="grid_700" runat="server"
                    GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="width_300">
                            <ItemTemplate>
                                <%#Eval("s_locale_text")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="width_35">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("s_locale_id_fk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="Edit" />'
                                    class="editlocale cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <input type="button" id='<%#Eval("s_locale_id_fk").ToString() + "," +  Eval("s_locale_text").ToString()%>'
                                    value='<asp:Literal ID="Literal6" runat="server" Text="Remove" />' class="deletelocale cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <div>
                    <table class="grid_700" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="width_300">
                                <asp:DropDownList ID="ddlLocale" CssClass="dropdown_width_300" runat="server" DataTextField="s_locale_description"
                                    DataValueField="s_locale_short_Name">
                                </asp:DropDownList>
                            </td>
                            <td class="align_right">
                                <input type="button" id="btnCreateNewLocale" value='<asp:Literal ID="Literal3" runat="server" Text="Create New Locale" />' />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnClose" runat="server" Text="Close Window" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close()" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="font_normal">
            <asp:Panel ID="pnlPreview" runat="server" CssClass="modalPopup_width_500" Style="display: none;
                padding-left: 0px; background-color: White; padding-right: 0px;">
                <asp:Panel ID="pnlPreviewHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            UI Text Preview:
                        </div>
                        <asp:ImageButton ID="imgClosePreview" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <br />
                <div class="div_padding_10 font_normal" id="divPreview" style="height: 278px; overflow-x: hidden;
                    overflow: auto">
                </div>
                <br />
                <div class="div_padding_10">
                    <center>
                        <asp:Button ID="btnClosePreview" CssClass="cursor_hand" runat="server" Text="Close" />
                    </center>
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </div>
    </div>
    <asp:ModalPopupExtender ID="mpPreview" runat="server" TargetControlID="btnPreview"
        OkControlID="btnClosePreview" CancelControlID="imgClosePreview" PopupControlID="pnlPreview"
        BackgroundCssClass="transparent_class" DropShadow="false" PopupDragHandleControlID="pnlPreviewHeading">
    </asp:ModalPopupExtender>
</asp:Content>
