       <%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="saefrm-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Facilities.Room.saefrm_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 800px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
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
                'href': '../Room/Resource/safrmrs-01.aspx?mode=edit',
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
                        url: "saefrm-01.aspx/DeleteResource",

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
        <asp:ValidationSummary class="validation_summary_error" ID="vs_saafrm" runat="server"
            ValidationGroup="saafrm"></asp:ValidationSummary>
        <div class="div_header_800">
           <%=LocalResources.GetLabel("app_room_information_english_uk_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvRoomId" runat="server" ValidationGroup="saafrm"
                            ControlToValidate="txtRoomId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_room_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvRoomName" runat="server" ValidationGroup="saafrm"
                            ControlToValidate="txtRoomName" ErrorMessage="<%$ TextResourceExpression: app_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_room_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvRoomDescription" runat="server" ValidationGroup="saafrm"
                            ControlToValidate="txtRoomDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="4">
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
                        <asp:DropDownList ID="ddlRoomType" DataValueField="s_room_type_system_id_pk" DataTextField="s_room_english_us_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_800">
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
                                    <td class="horizontal_line" colspan="3">
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_300">
                                        <%#Eval("s_resource_name")%><br />
                                        <%# "(" + Eval("s_resource_id_pk") + ")"%>
                                    </td>
                                    <td class="gridview_row_width_300">
                                        <%#Eval("s_resource_description")%><br />
                                        <%# "(" + Eval("s_resource_serial_number") + ")"%>
                                    </td>
                                    <td class="gridview_row_width_1" align="center">
                                        <input type="button" id='<%# Eval("s_resource_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
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
            <input type="button" id="btnAddResource" value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_add_resource_button_text%>" />' />
        </div>
        <br />
        <div class="div_header_800">
            &nbsp;
        </div>
        <br />
        <div class="div_padding_10">
            <div class="left">
                <asp:Button ID="btnSave" ValidationGroup="saafrm" CssClass="cursor_hand" runat="server"
                    Text="<%$ LabelResourceExpression: app_save_room_button_text %>" onclick="btnSave_Click"  />
            </div>
            <div>
                <div class="right">
                    <asp:Button CssClass="cursor_hand" ID="btnCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <center>
                    <asp:Button ID="btnReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>" 
                        onclick="btnReset_Click" />
                </center>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
