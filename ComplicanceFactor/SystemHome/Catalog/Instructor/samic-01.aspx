<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samic-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Instructor.samic_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
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

            //Get the Id 
            var uid = $('input#<%=hdId.ClientID %>').val();
            //Add course
            $(".addcourse").click(function () {

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
                    'href': '../Instructor/sacs-01.aspx?uid=' + uid,
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

            $(".deletecourse").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "samic-01.aspx/DeleteCourse",
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
    <div class="content_area_long">
        <asp:HiddenField ID="hdId" runat="server" />
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderClose" runat="server" 
                            Text="<%$ LabelResourceExpression: app_close_button_text%>" OnClick="btnHeaderClose_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_instructor_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_last_name_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_first_name_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_middle_name_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_user_status_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblUserStatus" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_user_types_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblUserTypes" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_user_domain_text")%>:
                    </td>
                    <td class="td_width_200">
                        <asp:Label ID="lblUserDomain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_course_information_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:GridView ID="gvCourse" runat="server" Width="100%" RowStyle-CssClass="record"
                AutoGenerateColumns="false" ShowHeader="false" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <%=LocalResources.GetLabel("app_course_id_text")%>:
                                    </td>
                                    <td class="td_width_200">
                                        <%#Eval("c_course_id_pk")%>
                                    </td>
                                    <td>
                                        <%=LocalResources.GetLabel("app_course_name_text")%>:
                                    </td>
                                    <td class="td_width_200">
                                        <%#Eval("c_course_title")%>
                                    </td>
                                    <td class="align_center">
                                        <%#Eval("s_delivery_type_name_us_english")%>
                                    </td>
                                    <td class="td_width_200">
                                        <input type="button" class="deletecourse" id='<%# Eval("c_instructor_course_system_id_pk") %>'
                                            value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <input type="button" id="btnAddCourse" class="addcourse cursor_hand" value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_add_course_button_text%>" />' />
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterClose" runat="server" 
                            Text="<%$ LabelResourceExpression: app_close_button_text%>" onclick="btnFooterClose_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
