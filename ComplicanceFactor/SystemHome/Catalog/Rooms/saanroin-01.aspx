<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saanroin-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Rooms.saanroin_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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


        // Add and view  locale
        $(document).ready(function () {
            $("#btnManageLocale").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 783,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Rooms/Locale/savloc-01.aspx?mode=create',
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

        //Resource popup
        $("#btnAddResource").fancybox({
            'type': 'iframe',
            'titlePosition': 'over',
            'titleShow': true,
            'showCloseButton': true,
            'scrolling': 'yes',
            'autoScale': false,
            'autoDimensions': false,
            'helpers': { overlay: { closeClick: false} },
            'width': 720,
            'height': 200,
            'margin': 0,
            'padding': 0,
            'overlayColor': '#000',
            'overlayOpacity': 0.7,
            'hideOnOverlayClick': false,
            'href': '../Rooms/Resource/sars-01.aspx?mode=create',
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

        $("#<%=btnFacility.ClientID %>").fancybox({
            'type': 'iframe',
            'titlePosition': 'over',
            'titleShow': true,
            'showCloseButton': true,
            'scrolling': 'yes',
            'autoScale': false,
            'autoDimensions': false,
            'helpers': { overlay: { closeClick: false} },
            'width': 732,
            'height': 200,
            'margin': 0,
            'padding': 0,
            'overlayColor': '#000',
            'overlayOpacity': 0.7,
            'hideOnOverlayClick': false,
            'href': '../Rooms/Facility/safs-01.aspx',
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

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".deleteresource").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanroin-01.aspx/DeleteResource",

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
    <br />
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saanroin" runat="server"
        ValidationGroup="saanroin"></asp:ValidationSummary>
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <asp:TextBox ID="txtTempFacility" runat="server" Style="display: none;"></asp:TextBox>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNewRoom" ValidationGroup="saanroin" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_room_button_text %>"
                            OnClick="btnHeaderSaveNewRoom_Click" />
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
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_room_information_english_us_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFacility" runat="server" ValidationGroup="saanroin"
                            ControlToValidate="txtTempFacility" ErrorMessage="<%$ TextResourceExpression: app_facility_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_facility_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblFacility" runat="server"></asp:Label>
                        <asp:Button ID="btnFacility" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_select_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvRoomId" runat="server" ValidationGroup="saanroin"
                            ControlToValidate="txtRoomId" ErrorMessage="<%$ TextResourceExpression: app_room_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_room_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomId" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvRoomName" runat="server" ValidationGroup="saanroin"
                            ControlToValidate="txtRoomName" ErrorMessage="<%$ TextResourceExpression: app_room_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_room_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvRoomDescription" runat="server" ValidationGroup="saanroin"
                            ControlToValidate="txtRoomDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtRoomDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_room_type_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRoomType" DataTextField="s_room_type_name" DataValueField="s_room_type_system_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="btnManageLocale" class="cursor_hand" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />' />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_resources_text")%>:
        </div>
        <br />
        <div class="div_control_normal">
            <asp:GridView ID="gvResources" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_700"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="gridview_row_width_300">
                                        <%#Eval("s_resource_description")%>
                                        &nbsp;
                                        <%# "(" + Eval("s_resource_id_pk") + ")"%>
                                    </td>
                                    <td class="gridview_row_width_300" align="center">
                                        <input type="button" id='<%# Eval("s_resource_system_id_pk") %>' value='<asp:Literal ID="Literal4" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                            class="deleteresource cursor_hand" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls font_1">
            <br />
            <input type="button" class="cursor_hand" id="btnAddResource" value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_add_resources_button_text %>" />' />
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnFooterSaveNewRoom" ValidationGroup="saanroin" CssClass="cursor_hand"
                    runat="server" Text="<%$ LabelResourceExpression: app_save_new_room_button_text %>"
                    OnClick="btnFooterSaveNewRoom_Click" />
            </div>
            <div>
                <div class="right">
                    <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                        OnClick="btnFooterCancel_Click" />
                </div>
                <center>
                    <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                        OnClick="btnFooterReset_Click" />
                </center>
            </div>
            <div class="clear">
            </div>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
