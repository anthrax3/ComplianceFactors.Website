﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sauac-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.AddCurriculum.sauac_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/jquery.fancybox.css" />
    <style type="text/css">
        body
        {
            width: 900px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 500px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {

            //Get  course Popup
            $(".addcurriculum").click(function () {
                $.fancybox({
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
                    'href': '/SystemHome/Users/AddCurriculum/p-mcsc-01.aspx',
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

            $(".viewdetails").click(function () {
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
                    'width': 733,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '/SystemHome/Catalog/MassEnrollment/Popup/lvcure-01.aspx?id=' + record_id,
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


            //Remove Course or curriculum
            $(".deletecoursecurriculum").click(function () {

                var hdCheckdelivery = document.getElementById('<%= hdCheckdelivery.ClientID %>');
                hdCheckdelivery.value = 0;

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "samep-01.aspx/DeleteCurriculum",
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
        function confirmremove(sender, args) {
            var isValid = validateAll();
            if (isValid == true) {
                if (confirm('Are you sure') == true)
                    return true;
                else
                    return false;
            }
        }
    </script>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdCheckdelivery" runat="server" />
    <div class="div_header_long">
        Add Curriculum:
    </div>
    <br />
    <div>
        <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" CssClass="grid_870" ShowHeader="false"
            ShowFooter="false" GridLines="None" runat="server" DataKeyNames="sysId" OnRowDataBound="gvCatalog_RowDataBound">
            <RowStyle CssClass="record"></RowStyle>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblType" Style="text-align: left;" runat="server" Text="Curriculum:"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_4_1" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" Style="text-align: left;" runat="server" Text='<%#Eval("Id")  + "(" + Eval("title") +")"%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectDelivery" runat="server" Style="display: none; padding-right: 5px;" />
                        <asp:Literal ID="ltlViewDetails" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" Style="display: none;"
                            DataTextField="deliveryname" DataValueField="c_delivery_system_id_pk" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <input type="button" id='<%# Eval("sysId") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Delete" />'
                            class="deletecoursecurriculum cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <input type="button" class="addcurriculum cursor_hand" value='<asp:Literal ID="Literal6" runat="server" Text="Add Curriculum" />' />
        <br />
        <br />
        <div class="div_header_long">
            <br />
        </div>
        <div class="clear">
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        Required&nbsp;<asp:CheckBox ID="chkRequired" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Target Due Date:
                    </td>
                    <td class="clear">
                        <asp:TextBox ID="txtTargetDueDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceTargetDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDueDate">
                        </asp:CalendarExtender>
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnProcessMassEnrollment" runat="server" Text="Process Mass Enrollment"
                            OnClick="btnProcessMassEnrollment_Click" OnClientClick="return confirmremove()"
                            CssClass="cursor_hand" />
                    </td>
                    <td colspan="4">
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
