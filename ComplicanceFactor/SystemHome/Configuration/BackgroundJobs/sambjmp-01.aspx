<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sambjmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.sambjmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        $(document).ready(function () {

            $(".manage").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");


                var jobId = record_id.split('-');
                if (jobId[0] == 'HRIS') {
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
                        'width': 700,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../BackgroundJobs/Popup/samhrismp-01.aspx?Id=' + record_id,
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
                }
                else if (jobId[0] == 'DIMP') {
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
                        'href': '../BackgroundJobs/Popup/samdimpmp-01.aspx?Id=' + record_id,
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
                }
                else if (jobId[0] == 'DEXP') {
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
                        'width': 930,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../BackgroundJobs/Popup/samdexpmp-01.aspx?Id=' + record_id,
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
                }
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".viewLogs").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");


                var jobId = record_id.split('-');
                if (jobId[0] == 'HRIS') {
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
                        'width': 732,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../HRISIntegration/Popup/p-samdhrislo-01.aspx',
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
                }
                else if (jobId[0] == 'DIMP') {
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
                        'width': 732,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../Data%20Imports/Popup/p_samddimplo-01.aspx',
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
                }
                else if (jobId[0] == 'DEXP') {
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
                        'width': 732,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../DataExports/Popup/p-samdexplo-01.aspx',
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
                }
                else if (jobId[0] == 'DCUB') {
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
                        'width': 732,
                        'height': 200,
                        'margin': 0,
                        'padding': 0,
                        'overlayColor': '#000',
                        'overlayOpacity': 0.7,
                        'hideOnOverlayClick': false,
                        'href': '../Data%20Imports/Popup/p_samddimplo-01.aspx',
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
                }
            });

        });
    </script>
    <div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_background_jobs_name_text")%>:
        </div>
        <div class="page_text" align="center">
            <asp:GridView ID="gvBackgroundJobs" CellPadding="0" CellSpacing="0" runat="server"
                AutoGenerateColumns="false" GridLines="None" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" CssClass="gridview_long tablesorter"
                DataKeyNames="u_sftp_id_pk" OnRowDataBound="gvBackgroundJobs_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_7"
                        ItemStyle-CssClass="gridview_row_width_4" DataField="BackgroundJobName" HeaderText="<%$ LabelResourceExpression: app_background_jobs_name_text %>" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_7"
                        HeaderStyle-CssClass="gridview_row_width_7" HeaderText="<%$ LabelResourceExpression: app_frequency_text %>">
                        <ItemTemplate>
                            <asp:Label ID="lblOccursEvery" runat="server" Text="<%$ LabelResourceExpression: app_occurs_every_text %>" ></asp:Label>                            
                            <asp:TextBox ID="txtOccursEvery" runat="server" CssClass="textbox_50" Text='<%#Eval("u_sftp_occurs_every") %>'></asp:TextBox>
                            <asp:Label ID="lblEveryDays" runat="server" Text="<%$ LabelResourceExpression: app_days_text %>"></asp:Label>
                            <asp:Label ID="lblOccursCommon" runat="server" Text="Occurs Every Day" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_7"
                        HeaderStyle-CssClass="gridview_row_width_7" HeaderText="Time">
                        <ItemTemplate>
                            <%=LocalResources.GetLabel("app_at_text")%>:
                            <asp:TextBox ID="txtTime" CssClass="textbox_75" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlTime" runat="server">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gridview_row_width_2"
                        ItemStyle-CssClass="gridview_row_width_2" DataField="" HeaderText="Status " />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <asp:Literal ID="ltlButton" runat="server"></asp:Literal>
                            <%--<input type="button" id='<%#Eval("u_sftp_id_pk") %>' class="manage" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_button_text %>" />' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <input type="button" id='<%#Eval("u_sftp_id_pk") %>' class="viewLogs" value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_view_logs_button_text %>" />' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <div class="align_center">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
