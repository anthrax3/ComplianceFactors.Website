<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-samdexplo-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DataExports.Popup.p_samdexplo_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 650px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".viewLog").click(function () {

                var record_id = $(this).attr("id");

                $(".viewLog").fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 682,
                    'height': 550,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'p-samvexplo-01.aspx?logid=' + record_id,
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
    <div id="content">
        <%--Heading--%>
        <div class="div_header_700">
            Data Export Job Run(s):
        </div>
        <div>
            <br />
            <div class="div_controls font_1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:GridView ID="gvExportJobRun" CssClass="grid_table_600" ShowHeader="false" ShowFooter="false"
                                GridLines="None" AutoGenerateColumns="false" AllowPaging="false" runat="server">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_600" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourseName" runat="server" Style="text-align: left;" Text='<%#Eval("u_sftp_run_result")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1">
                                        <ItemTemplate>
                                            <input type="button" id='<%# Eval("u_sftp_run_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="View Log Details" />'
                                                class="viewLog cursor_hand" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCloseWindow" ValidationGroup="saaloc" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                Text="Close Window" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
